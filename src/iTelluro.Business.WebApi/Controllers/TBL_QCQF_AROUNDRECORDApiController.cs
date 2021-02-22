using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Http;
using iTelluro.Busness.WebApi;
using System.Linq;
using Newtonsoft.Json.Linq;
using System;
using iTelluro.Busness.WebApiProxy;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-13 16:22
    /// 描 述：巡查记录表
    /// </summary>
    public class TBL_QCQF_AROUNDRECORDApiController : ApiControllerBase
    {
        private TBL_QCQF_AROUNDRECORDBLL tbl_qcqf_aroundrecordbll = new TBL_QCQF_AROUNDRECORDBLL();
        private TBL_HAZARDBASICINFOBLL tbl_hazardbasicinfobll = new TBL_HAZARDBASICINFOBLL();
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_qcqf_aroundrecordbll.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public object GetListJson(string queryJson)
        {
            var data = tbl_qcqf_aroundrecordbll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_QCQF_AROUNDRECORDEntity GetFormJson(string keyValue)
        {
            var data = tbl_qcqf_aroundrecordbll.GetEntity(keyValue);
            return data;
        }
        [HttpGet]
        public TBL_QCQF_AROUNDRECORDEntity GetFormJsonByUNIFIEDCODE(string keyValue)
        {
            var data = tbl_qcqf_aroundrecordbll.GetFormJsonByUNIFIEDCODE(keyValue);
            return data;
        }
        /// <summary>
        ///根据DISASTERNAME和UPLOADNAME查询宏观巡查数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public object GetPageListJsonByCondition([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var param = new JObject();
            string strDISASTERNAME = "";
            if (queryJson.Trim('"') != "" && !queryJson.Contains("["))
            {
                param = queryJson.ToJObject();
            }
            if (Convert.ToString(param["DISASTERNAME"]) != null && Convert.ToString(param["DISASTERNAME"]) != "")
            {
                strDISASTERNAME = param["DISASTERNAME"].ToString();
                var data = from a in tbl_qcqf_aroundrecordbll.GetListByUploadName(queryJson)
                           join b in tbl_hazardbasicinfobll.GetList("").Where(t => t.DISASTERNAME.Contains(strDISASTERNAME)) on a.UNIFIEDCODE equals b.UNIFIEDCODE
                           where b.UNIFIEDCODE != null
                           select new { a.GUID, a.MONITORTIME, a.NEWSLIT, a.UNIFIEDCODE, a.NEWTODRUM, a.NEWSUBSIDE, a.SMALLCOLLAPSES, a.HOUSEDEFORMATION, a.NEWSPRING, a.WELLLEAK, a.TREESSKEW, a.UNDEDERVOICE, a.ANIMALSABNORMAL, a.REMARK, a.UPLOADLONGITUDE, a.UPLOADLATITUDE, a.UPLOADID, a.UPLOADNAME, b.DISASTERNAME };
                pagination.records = data.Count();
                //分页
                data = data.ToList().OrderByDescending(t => t.MONITORTIME).Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
                var jsonData = new
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return jsonData;
            }
            else
            {
                var data = from a in tbl_qcqf_aroundrecordbll.GetListByUploadName(queryJson)
                           join b in tbl_hazardbasicinfobll.GetList("") on a.UNIFIEDCODE equals b.UNIFIEDCODE
                           where b.UNIFIEDCODE != null
                           select new { a.GUID, a.MONITORTIME, a.NEWSLIT, a.UNIFIEDCODE, a.NEWTODRUM, a.NEWSUBSIDE, a.SMALLCOLLAPSES, a.HOUSEDEFORMATION, a.NEWSPRING, a.WELLLEAK, a.TREESSKEW, a.UNDEDERVOICE, a.ANIMALSABNORMAL, a.REMARK, a.UPLOADLONGITUDE, a.UPLOADLATITUDE, a.UPLOADID, a.UPLOADNAME, b.DISASTERNAME };
                pagination.records = data.Count();
                //分页
                data = data.ToList().OrderByDescending(t => t.MONITORTIME).Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
                var jsonData = new
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return jsonData;
            }
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm(SingleParam param)
        {
            tbl_qcqf_aroundrecordbll.RemoveForm(param.KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromBody]TBL_QCQF_AROUNDRECORDEntity entity)
        {
            tbl_qcqf_aroundrecordbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        [HttpPost]
        public WebApiResult SaveFormByUNIFIEDCODE(string keyValue, [FromBody]TBL_QCQF_AROUNDRECORDEntity entity)
        {
            tbl_qcqf_aroundrecordbll.SaveFormByUNIFIEDCODE(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
