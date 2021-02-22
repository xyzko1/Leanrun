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
    /// 日 期：2018-04-16 23:31
    /// 描 述：治理工程-设计
    /// </summary>
    public class TBL_ZLGC_SJINFOController : MvcControllerBase
    {
        private TBL_ZLGC_SJINFOBLL tbl_zlgc_sjinfobll = new TBL_ZLGC_SJINFOBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_ZLGC_SJINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_SJINFOForm()
        {
            return View();
        }
        /// <summary>
        /// 治理工程施工设计--资质清单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult TBL_ZLGC_SJZZQDList()
        {
            return View();
        }
        /// <summary>
        /// 治理工程施工设计--治理区域划分
        /// </summary>
        /// <returns></returns>
        public ActionResult TBL_ZLGC_SJZLQHList()
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
        [LogContent("治理工程-设计", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_zlgc_sjinfobll.GetList(queryJson);
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
            var data = tbl_zlgc_sjinfobll.GetEntity(keyValue);
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
        [LogContent("治理工程-设计", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_zlgc_sjinfobll.RemoveForm(keyValue);
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
        [LogContent("治理工程-设计", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_ZLGC_SJINFOEntity entity)
        {
            tbl_zlgc_sjinfobll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
