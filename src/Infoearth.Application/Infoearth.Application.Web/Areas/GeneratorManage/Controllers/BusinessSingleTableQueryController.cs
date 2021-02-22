﻿using Infoearth.Application.Busines.AuthorizeManage;
using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Code;
using Infoearth.Application.Entity.AuthorizeManage;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.CodeGenerator;
using Infoearth.CodeGenerator.Model;
using Infoearth.CodeGenerator.Template;
using Infoearth.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.GeneratorManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 
    /// 创建人：佘赐雄
    /// 日 期：2016.2.2 10:29
    /// 描 述：生成器单表
    /// </summary>
    public class BusinessSingleTableQueryController : MvcControllerBase
    {
        private ModuleBLL moduleBLL = new ModuleBLL();

        #region 视图功能
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
        /// <summary>
        /// 编辑表格
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditGrid()
        {
            return View();
        }
        /// <summary>
        /// 编辑控件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditControl()
        {
            return View();
        }
        /// <summary>
        /// 编辑查询语句
        /// </summary>
        /// <returns></returns>
        public ActionResult EditSearch()
        {
            return View();
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 查看代码
        /// </summary>
        /// <param name="baseInfoJson">基本信息配置Json</param>
        /// <param name="gridInfoJson">表格信息Json</param>
        /// <param name="gridColumnJson">表格字段信息Json</param>
        /// <param name="formInfoJson">表单信息Json</param>
        /// <param name="formFieldJson">表单字段信息Json</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult LookCode(string baseInfoJson, string gridInfoJson, string gridColumnJson, string formInfoJson, string formFieldJson, string queryJson)
        {
            BusinessSingleTableQuery default_Template = new BusinessSingleTableQuery();
            BaseConfigModel baseConfigModel = baseInfoJson.ToObject<BaseConfigModel>();
            baseConfigModel.gridModel = gridInfoJson.ToObject<GridModel>();
            baseConfigModel.gridColumnModel = gridColumnJson.ToList<GridColumnModel>();
            //baseConfigModel.formModel = formInfoJson.ToObject<FormModel>();
            //baseConfigModel.formFieldModel = formFieldJson.ToList<FormFieldModel>();
            baseConfigModel.QueryModel = queryJson.ToObject<QueryModel>();
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

            DataTable dt = DataHelper.ListToDataTable<DataBaseTableFieldEntity>(tableFiled.ToList());
            string entitybuilder = default_Template.EntityBuilder(baseConfigModel, dt);
            string entitymapbuilder = default_Template.EntityMapBuilder(baseConfigModel, dt);
            string servicebuilder = string.Empty;
            if (baseConfigModel.DescriptionEx == "VIEW")
            {
                servicebuilder = default_Template.ServiceBuilderView(baseConfigModel);
            }
            else
            {
                servicebuilder = default_Template.ServiceBuilder(baseConfigModel);
            }
            string iservicebuilder = default_Template.IServiceBuilder(baseConfigModel);
            string businesbuilder = default_Template.BusinesBuilder(baseConfigModel);
            string controllerbuilder = default_Template.ControllerBuilder(baseConfigModel);
            string indexbuilder = default_Template.IndexBuilder(baseConfigModel);
            //string formbuilder = default_Template.FormBuilder(baseConfigModel);
            var jsonData = new
            {
                entityCode = entitybuilder,
                entitymapCode = entitymapbuilder,
                serviceCode = servicebuilder,
                iserviceCode = iservicebuilder,
                businesCode = businesbuilder,
                controllerCode = controllerbuilder,
                indexCode = indexbuilder,
                formCode = ""
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// 创建代码（自动写入VS里面目录）
        /// </summary>
        /// <param name="baseInfoJson">基本信息配置Json</param>
        /// <param name="strCode">生成代码内容</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult CreateCode(string baseInfoJson, string strCode)
        {
            
            BaseConfigModel baseConfigModel = baseInfoJson.ToObject<BaseConfigModel>();
            CreateCodeFile.CreateExecution(baseConfigModel, Server.UrlDecode(strCode));
            return Success("恭喜您，创建成功！");
        }
        /// <summary>
        /// 发布功能（自动创建导航菜单）
        /// </summary>
        /// <param name="baseInfoJson">基本信息配置Json</param>
        /// <param name="ModuleEnCode">功能编码</param>
        /// <param name="FullName">功能名称</param>
        /// <param name="ParentId">上级Id</param>
        /// <param name="Icon">图标</param>
        /// <param name="Description">描述</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult PublishModule(string baseInfoJson, string ModuleEnCode, string FullName, string ParentId, string Icon, string Description)
        {
            BaseConfigModel baseConfigModel = baseInfoJson.ToObject<BaseConfigModel>();
            var urlAddress = "/" + baseConfigModel.OutputAreas + "/" + CommonHelper.DelLastLength(baseConfigModel.ControllerName, 10) + "/" + baseConfigModel.IndexPageName;
            var formUrlAddress =  "/" + baseConfigModel.OutputAreas + "/" + CommonHelper.DelLastLength(baseConfigModel.ControllerName, 10) + "/" + baseConfigModel.FormPageName;
            var deleteUrlAddress = "/" + baseConfigModel.OutputAreas + "/" + CommonHelper.DelLastLength(baseConfigModel.ControllerName, 10) + "/RemoveForm";

            ModuleEntity moduleEntity = new ModuleEntity();
            moduleEntity.F_EnCode = ModuleEnCode;
            moduleEntity.F_FullName = FullName;
            moduleEntity.F_ParentId = ParentId;
            moduleEntity.F_Icon = Icon;
            moduleEntity.F_Description = Description;
            moduleEntity.F_SortCode = moduleBLL.GetSortCode();
            moduleEntity.F_IsMenu = 1;
            moduleEntity.F_EnabledMark = 1;
            moduleEntity.F_Target = "iframe";
            moduleEntity.F_UrlAddress = urlAddress;

            string buttonListJson = "[{\"F_ParentId\":\"0\",\"F_EnCode\":\"lr-replace\",\"F_FullName\":\"刷新\",\"F_SortCode\":0},";
            buttonListJson += "{\"F_ParentId\":\"0\",\"F_EnCode\":\"lr-add\",\"F_FullName\":\"新增\",\"F_ActionAddress\":\"" + formUrlAddress + "\",\"F_SortCode\":1},";
            buttonListJson += "{\"F_ParentId\":\"0\",\"F_EnCode\":\"lr-edit\",\"F_FullName\":\"编辑\",\"F_ActionAddress\":\"" + formUrlAddress + "\",\"F_SortCode\":2},";
            buttonListJson += "{\"F_ParentId\":\"0\",\"F_EnCode\":\"lr-delete\",\"F_FullName\":\"删除\",\"F_ActionAddress\":\"" + deleteUrlAddress + "\",\"F_SortCode\":3}]";

            moduleBLL.SaveForm("", moduleEntity, buttonListJson, "");
            return Success("发布成功！");
        }
        #endregion

        #region 处理数据
        /// <summary>
        /// 加载模板数据
        /// </summary>
        /// <param name="templateId">模板Id</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTemplateData(string templateId)
        {
            string filepath = Server.MapPath("~/Areas/SystemManage/Views/CodeGenerator/template/" + templateId + ".txt");
            FileStream fs = new System.IO.FileStream(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            return Content(sr.ReadToEnd().ToString());
        }
        #endregion
    }
}
