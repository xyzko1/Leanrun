using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;


namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{          /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-28 14:24
    /// 描 述：范围图层样式表
    /// </summary>
    public class TBL_SPATIALRENDERSTYLEController : MvcControllerBase
    {
        private TBL_SPATIALRENDERSTYLEBLL tbl_spatialrenderstylebll = new TBL_SPATIALRENDERSTYLEBLL();
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        [HttpGet]
        public ActionResult GetPageList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_spatialrenderstylebll.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        [HttpGet]
        public ActionResult GetList(string queryJson)
        {
            var data = tbl_spatialrenderstylebll.GetList(queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetEntity(string keyValue)
        {
            var data = tbl_spatialrenderstylebll.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteEntity(string keyValue)
        {
            tbl_spatialrenderstylebll.DeleteEntity(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult SaveEntity(string keyValue, TBL_SPATIALRENDERSTYLEEntity entity)
        {
            tbl_spatialrenderstylebll.SaveEntity(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}