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
    /// 工作明白卡接口  by huangzy 2019-1-22
    /// 用于工作明白卡查询、管理
    /// </summary>
    public class TBL_QCQF_WORKUNDERSTANDCARDApiController : ApiControllerBase
    {
		private DataItemCache dataItemCache = new DataItemCache();
        //工作明白卡
        private TBL_QCQF_WORKUNDERSTANDCARDBLL tbl_qcqf_workunderstandcardbll = new TBL_QCQF_WORKUNDERSTANDCARDBLL();
        SSOWebApiWS ws = new SSOWebApiWS("");

        #region 获取数据
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_QCQF_WORKUNDERSTANDCARDEntity> GetPageList([FromUri]Pagination pagination, string queryJson)
        {
            return tbl_qcqf_workunderstandcardbll.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_WORKUNDERSTANDCARDEntity> GetList(string queryJson)
        {
            return tbl_qcqf_workunderstandcardbll.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_WORKUNDERSTANDCARDEntity GetEntity(string keyValue)
        {
            return tbl_qcqf_workunderstandcardbll.GetEntity(keyValue);
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
            tbl_qcqf_workunderstandcardbll.RemoveForm(keyValue.KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromUri]TBL_QCQF_WORKUNDERSTANDCARDEntity entity)
        {
            tbl_qcqf_workunderstandcardbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion

    }
}