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
    /// 日 期：2018-03-17 14:51
    /// 描 述：审核信息表
    /// </summary>
    public class TBL_AUDITINFOController : MvcControllerBase
    {
        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_AUDITINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// 提交审核列表页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_AUDITINFOSubmitIndex()
        {
            return View();
        }

        /// <summary>
        /// 审核列表页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_AUDITINFOForm()
        {
            return View();
        }

        /// <summary>
        /// 审核信息页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AuditInfoForm()
        {
            return View();
        }
        #endregion
    }
}
