using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-13 16:22
    /// 描 述：巡查记录表
    /// </summary>
    public class TBL_QCQF_AROUNDRECORDController : MvcControllerBase
    {
        private TBL_QCQF_AROUNDRECORDBLL tbl_qcqf_aroundrecordbll = new TBL_QCQF_AROUNDRECORDBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_QCQF_AROUNDRECORDIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_AROUNDRECORDForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        [LogContent("巡查记录表", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
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
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        [LogContent("巡查记录表", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_qcqf_aroundrecordbll.GetList(queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = tbl_qcqf_aroundrecordbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("巡查记录表", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_qcqf_aroundrecordbll.RemoveForm(keyValue);
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
        [LogContent("巡查记录表", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_QCQF_AROUNDRECORDEntity entity)
        {
            tbl_qcqf_aroundrecordbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
