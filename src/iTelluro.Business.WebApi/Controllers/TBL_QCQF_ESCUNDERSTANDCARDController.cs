using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using Infoearth.Application.Entity.SystemManage;
using System.Linq;
using Infoearth.Application.Cache;
using Infoearth.Util.Offices;
using System;
using System.Data;
using System.Collections;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using Infoearth.Application.Entity;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 避灾明白卡接口  by huangzy 2019-1-22
    /// 用于避灾明白卡查询、管理
    /// </summary>
    public class TBL_QCQF_ESCUNDERSTANDCARDApiController : ApiControllerBase
    {
		private DataItemCache dataItemCache = new DataItemCache();
        //避灾明白卡
        private TBL_QCQF_ESCUNDERSTANDCARDBLL tbl_qcqf_escunderstandcardbll = new TBL_QCQF_ESCUNDERSTANDCARDBLL();
        SSOWebApiWS ws = new SSOWebApiWS("");

        #region 获取数据
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetPageList([FromUri]Pagination pagination, string queryJson)
        {
            return tbl_qcqf_escunderstandcardbll.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetList(string queryJson)
        {
            return tbl_qcqf_escunderstandcardbll.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_ESCUNDERSTANDCARDEntity GetEntity(string keyValue)
        {
            return tbl_qcqf_escunderstandcardbll.GetEntity(keyValue);
        }
        /// <summary>
        /// 根据灾害点编号获取
        /// </summary>
        /// <param name="keyValue">灾害点编号</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetEntity2(string queryJson)
        {
            return tbl_qcqf_escunderstandcardbll.GetEntity2(queryJson);
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
            tbl_qcqf_escunderstandcardbll.RemoveForm(keyValue.KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromUri]TBL_QCQF_ESCUNDERSTANDCARDEntity entity)
        {
            tbl_qcqf_escunderstandcardbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion

    }
}