using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApi;
using System.Web.Http;
using System.Collections.Generic;
using Infoearth.Application.Entity;
using System.Data;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 16:41
    /// 描 述：解译工程项目基本信息表
    /// </summary>
    public class JYGC_PROJECTBASEINFOApiController : ApiControllerBase
    {
        private JYGC_PROJECTBASEINFOBLL jygc_projectbaseinfobll = new JYGC_PROJECTBASEINFOBLL();
        private HarzardTrendAnalyseBLL harzardTrendAnalyseBLL = new HarzardTrendAnalyseBLL();
        #region 获取数据
        /// <summary>
        /// 获取工程类型列表
        /// </summary>
        /// <param name="queryJson">
        /// 查询参数
        /// txt_keyword 模糊匹配工程文件名
        /// </param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public IEnumerable<JYGC_PROJECTBASEINFOEntity> GetListJson(string queryJson)
        {
            return jygc_projectbaseinfobll.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public JYGC_PROJECTBASEINFOEntity GetFormJson(string keyValue)
        {
            var data = jygc_projectbaseinfobll.GetEntity(keyValue);
            return data;
        }

        /// <summary>
        /// 获取所有的调查项目、排查项目
        /// </summary>
        /// <param name="queryJson">
        /// PROJECTTYPE 项目类型(调查、排查)
        /// </param>
        /// <returns></returns>
        [HttpGet]

        public object GetProjectIDList(string queryJson)
        {
            var data = jygc_projectbaseinfobll.GetProjectIDList(queryJson);
            return data;
        }
        /// <summary>
        /// 获取或者创建一个项目ID
        /// </summary>
        /// <param name="projectName">项目名称</param>
        /// <returns></returns>
        [HttpGet]
        public JYGC_PROJECTBASEINFOEntity GetOrCreateProjectId(string projectName)
        {
            return jygc_projectbaseinfobll.GetOrCreateProjectId(projectName);
        }
        /// <summary>
        /// 获取日期范围项目
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetListByDateDiff(string queryJson)
        {
            return jygc_projectbaseinfobll.GetListByDateDiff(queryJson);
        }
        [HttpGet]
        public object QueryStatistics(string queryJson)
        {

            List<MergedRegionEntity> columnList = new List<MergedRegionEntity>();
            DataTable result = harzardTrendAnalyseBLL.QueryStatistics(queryJson, ref columnList);
            var jsonData = new
            {
                Columns = columnList,
                Data = result
            };
            return jsonData;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm(SingleParam keyValue)
        {
            jygc_projectbaseinfobll.RemoveForm(keyValue.KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, JYGC_PROJECTBASEINFOEntity entity)
        {
            jygc_projectbaseinfobll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
