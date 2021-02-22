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
    /// 日 期：2019-05-09 14:25
    /// 描 述：TBL_DZHJSB_DZZHFZYEAR
    /// </summary>
    public class TBL_DZHJSB_DZZHFZYEARController : MvcControllerBase
    {
        private TBL_DZHJSB_DZZHFZYEARBLL tbl_dzhjsb_dzzhfzyearbll = new TBL_DZHJSB_DZZHFZYEARBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DZHJSB_DZZHFZYEARIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DZHJSB_DZZHFZYEARForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        [LogContent("TBL_DZHJSB_DZZHFZYEAR", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_dzhjsb_dzzhfzyearbll.GetList(queryJson);
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
            var data = tbl_dzhjsb_dzzhfzyearbll.GetEntity(keyValue);
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
        [LogContent("TBL_DZHJSB_DZZHFZYEAR", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_dzhjsb_dzzhfzyearbll.RemoveForm(keyValue);
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
        [LogContent("TBL_DZHJSB_DZZHFZYEAR", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_DZHJSB_DZZHFZYEAREntity entity)
        {
            tbl_dzhjsb_dzzhfzyearbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
