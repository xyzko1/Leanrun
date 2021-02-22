using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApi;
using System.Web.Http;
using System.Collections.Generic;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-17 14:53
    /// 描 述：审计人表
    /// </summary>
    public class TBL_AUDITORSApiController : ApiControllerBase
    {
        private TBL_AUDITORSBLL tbl_auditorsbll = new TBL_AUDITORSBLL();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_auditorsbll.GetPageList(pagination, queryJson);
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
        public IEnumerable<TBL_AUDITORSEntity> GetListJson(string queryJson)
        {
            var data = tbl_auditorsbll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_AUDITORSEntity GetFormJson(string keyValue)
        {
            var data = tbl_auditorsbll.GetEntity(keyValue);
            return data;
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
            tbl_auditorsbll.RemoveForm(param.KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_AUDITORSEntity entity)
        {
            tbl_auditorsbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }

        #endregion


        #region 审核开关

        /// <summary>
        /// 开启审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult DisabledAudit(SingleParam param)
        {
            tbl_auditorsbll.UpdateAudit(param.KeyValue, "1");
            return Success("操作成功。");
        }

        /// <summary>
        /// 禁用审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult EnabledAudit(SingleParam param)
        {
            tbl_auditorsbll.UpdateAudit(param.KeyValue, "0");
            return Success("操作成功。");
        }
        [HttpPost]
        public WebApiResult SaveFormNew(string STATE, string GUIDS)
        {
            tbl_auditorsbll.SaveFormNew(STATE,GUIDS);
            return Success("操作成功。");
        }
        [HttpPost]
        public WebApiResult deleteNew(string GUIDS)
        {
            tbl_auditorsbll.deleteNew(GUIDS);
            return Success("操作成功。");
        }
        #endregion

    }
}
