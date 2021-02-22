using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Code;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.CodeGenerator;
using Infoearth.CodeGenerator.Model;
using Infoearth.CodeGenerator.Template;
using Infoearth.Util;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.GeneratorManage.Controllers
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 
    /// 创建人：陈小二
    /// 日 期：2016.12.3 10:29
    /// 描 述：后台类生成器
    /// </summary>
    public class ServiceCodeForViewController : MvcControllerBase
    {
        #region 视图功能
        // GET: GeneratorManage/ServiceCodeForView
        /// <summary>
        /// 代码生成器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CodeBuilder()
        {
            string OutputDirectory = Server.MapPath("~/Web.config"); ;
            for (int i = 0; i < 2; i++)
                OutputDirectory = OutputDirectory.Substring(0, OutputDirectory.LastIndexOf('\\'));
            ViewBag.OutputDirectory = OutputDirectory;
            ViewBag.UserName = OperatorProvider.Provider.Current().UserName;
            return View();
        }
        #endregion

        #region 数据接口
        /// <summary>
        /// 查看代码
        /// </summary>
        /// <param name="baseConfigModel">基本配置信息</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult LookCode(BaseConfigModel baseConfigModel)
        {
            ServiceCodeForView default_Template = new ServiceCodeForView();
            var tableFiled = new DataBaseTableBLL(baseConfigModel.DataBaseLinkId).GetTableFiledList(baseConfigModel.DataBaseLinkId, baseConfigModel.DataBaseTableName);
            baseConfigModel.DataBaseLinkName = "";
            DataBaseLinkEntity dataBaseLinkEntity = new DataBaseLinkBLL().GetEntity(baseConfigModel.DataBaseLinkId);
            baseConfigModel.DataBaseLinkType = dataBaseLinkEntity.F_DbType;
            string connectionString = ConfigurationManager.ConnectionStrings["BaseDb"].ConnectionString;
            if (connectionString != dataBaseLinkEntity.F_DbConnection)
            {
                baseConfigModel.DataBaseLinkName = dataBaseLinkEntity.F_DBName;
                baseConfigModel.DataBaseLinkType = dataBaseLinkEntity.F_DbType;
                if (ConfigurationManager.ConnectionStrings[dataBaseLinkEntity.F_DBName] == null)
                {
                    string providerName = "System.Data.SqlClient";
                    if (dataBaseLinkEntity.F_DbType == "MySql")
                    {
                        providerName = "MySql.Data.MySqlClient";
                    }
                    else if (dataBaseLinkEntity.F_DbType == "Oracle")
                    {
                        providerName = "Oracle.ManagedDataAccess.Client";
                    }
                    Config.UpdateOrCreateConnectionString("XmlConfig\\database.config", dataBaseLinkEntity.F_DBName, dataBaseLinkEntity.F_DbConnection, providerName);
                }
            }

            DataTable dt=DataHelper.ListToDataTable<DataBaseTableFieldEntity>(tableFiled.ToList());
            string entitybuilder = default_Template.EntityBuilder(baseConfigModel, dt);
            string entitymapbuilder = "";// default_Template.EntityMapBuilder(baseConfigModel, dt);
            string servicebuilder = default_Template.ServiceBuilderView(baseConfigModel);
            string iservicebuilder = default_Template.IServiceBuilder(baseConfigModel);
            string businesbuilder = default_Template.BusinesBuilder(baseConfigModel);
            var jsonData = new
            {
                entityCode = entitybuilder,
                entitymapCode = entitymapbuilder,
                serviceCode = servicebuilder,
                iserviceCode = iservicebuilder,
                businesCode = businesbuilder,
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// 创建代码（自动写入VS里面目录）
        /// </summary>
        /// <param name="baseConfigModel">基本配置信息</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult CreateCode(BaseConfigModel baseConfigModel)
        {
            baseConfigModel.DataBaseLinkName = "";
            DataBaseLinkEntity dataBaseLinkEntity = new DataBaseLinkBLL().GetEntity(baseConfigModel.DataBaseLinkId);
            string connectionString = ConfigurationManager.ConnectionStrings["BaseDb"].ConnectionString;
            if (connectionString != dataBaseLinkEntity.F_DbConnection)
            {
                 baseConfigModel.DataBaseLinkName = dataBaseLinkEntity.F_DBName;
                 baseConfigModel.DataBaseLinkType = dataBaseLinkEntity.F_DbType;
            }
            string[] tableNameLists = baseConfigModel.DataBaseTableName.Split(',');
            string[] tablePkLists = baseConfigModel.DataBaseTablePK.Split(',');
            string[] tableDescriptionLists = baseConfigModel.Description.Split(',');
            ServiceCodeForView default_Template = new ServiceCodeForView();
            for (int i = 0; i < tableNameLists.Length; i++)
            {
                baseConfigModel.DataBaseTableName = tableNameLists[i];
                baseConfigModel.DataBaseTablePK = tablePkLists[i];
                baseConfigModel.Description = tableDescriptionLists[i];

                baseConfigModel.EntityClassName = tableNameLists[i] + "Entity";
                baseConfigModel.MapClassName = tableNameLists[i] + "Map";
                baseConfigModel.ServiceClassName = tableNameLists[i] + "Service";
                baseConfigModel.IServiceClassName = tableNameLists[i] + "IService";
                baseConfigModel.BusinesClassName = tableNameLists[i] + "BLL";

                var tableFiled = new DataBaseTableBLL(baseConfigModel.DataBaseLinkId).GetTableFiledList(baseConfigModel.DataBaseLinkId, baseConfigModel.DataBaseTableName);
                DataTable dt = DataHelper.ListToDataTable<DataBaseTableFieldEntity>(tableFiled.ToList());
                string entitybuilder = default_Template.EntityBuilder(baseConfigModel, dt);
                string entitymapbuilder = "";// default_Template.EntityMapBuilder(baseConfigModel, dt);
                string servicebuilder = default_Template.ServiceBuilderView(baseConfigModel);
                string iservicebuilder = default_Template.IServiceBuilder(baseConfigModel);
                string businesbuilder = default_Template.BusinesBuilder(baseConfigModel);

                var jsonData = new
                {
                    entityCode = entitybuilder,
                    entitymapCode = entitymapbuilder,
                    serviceCode = servicebuilder,
                    iserviceCode = iservicebuilder,
                    businesCode = businesbuilder,
                };
                CreateCodeFile.CreateExecution(baseConfigModel, jsonData.ToJson());
            }
           
            return Success("恭喜您，创建成功！");
        }
        #endregion
    }
}