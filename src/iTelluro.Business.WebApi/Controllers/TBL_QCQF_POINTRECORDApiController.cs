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
using System.Collections.Generic;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-13 16:23
    /// 描 述：群测群防监测流水数据表
    /// </summary>
    public class TBL_QCQF_POINTRECORDApiController : ApiControllerBase
    {
        private TBL_QCQF_POINTRECORDBLL tbl_qcqf_pointrecordbll = new TBL_QCQF_POINTRECORDBLL();
        private TBL_QCQF_LAYOUTPOINTINFOBLL tbl_qcqf_layoutpointinfobll = new TBL_QCQF_LAYOUTPOINTINFOBLL();
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
            var data = tbl_qcqf_pointrecordbll.GetPageList(pagination, queryJson);
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
        public IEnumerable<TBL_QCQF_POINTRECORDEntity> GetListJson(string queryJson)
        {
            var data = tbl_qcqf_pointrecordbll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_QCQF_POINTRECORDEntity GetFormJson(string keyValue)
        {
            var data = tbl_qcqf_pointrecordbll.GetEntity(keyValue);
            return data;
        }
        [HttpGet]
        public TBL_QCQF_POINTRECORDEntity GetFormByMONITORPOINTGUID(string keyValue)
        {
            var data = tbl_qcqf_pointrecordbll.GetFormByMONITORPOINTGUID(keyValue);
            return data;
        }

        /// <summary>
        ///根据DISASTERNAME和UPLOADNAME查询监测流水数据
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
                var data = from a in tbl_qcqf_pointrecordbll.GetListByUploadName(queryJson)
                           join c in tbl_qcqf_layoutpointinfobll.GetAllList("") on a.MONITORPOINTGUID equals c.GUID
                           join b in tbl_hazardbasicinfobll.GetList("").Where(t => t.DISASTERNAME.Contains(strDISASTERNAME)) on c.UNIFIEDCODE equals b.UNIFIEDCODE
                           where b.UNIFIEDCODE != null
                           select new { a.GUID, a.MONITORTIME, a.SLITWIDTH, a.TODRUMHEIGH, a.SPRINGAMOUNT, a.SPRINGVOICING, a.WELLLEVEL, a.WELLVOICING, a.UPLOADLONGITUDE, a.UPLOADLATITUDE, a.UPLOADID, a.UPLOADNAME, a.SOURCETYPE, b.DISASTERNAME, b.UNIFIEDCODE, c.MONITORPOINTCODE };
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
                var data = from a in tbl_qcqf_pointrecordbll.GetListByUploadName(queryJson)
                           join c in tbl_qcqf_layoutpointinfobll.GetAllList("") on a.MONITORPOINTGUID equals c.GUID
                           join b in tbl_hazardbasicinfobll.GetList("") on c.UNIFIEDCODE equals b.UNIFIEDCODE
                           where b.UNIFIEDCODE != null
                           select new { a.GUID, a.MONITORTIME, a.SLITWIDTH, a.TODRUMHEIGH, a.SPRINGAMOUNT, a.SPRINGVOICING, a.WELLLEVEL, a.WELLVOICING, a.UPLOADLONGITUDE, a.UPLOADLATITUDE, a.UPLOADID, a.UPLOADNAME, a.SOURCETYPE, b.DISASTERNAME, b.UNIFIEDCODE, c.MONITORPOINTCODE };
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
            tbl_qcqf_pointrecordbll.RemoveForm(param.KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromBody]TBL_QCQF_POINTRECORDEntity entity)
        {
            tbl_qcqf_pointrecordbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        [HttpPost]
        public WebApiResult SaveFormByMONITORPOINTGUID(string keyValue, [FromBody]TBL_QCQF_POINTRECORDEntity entity)
        {
            tbl_qcqf_pointrecordbll.SaveFormByMONITORPOINTGUID(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
