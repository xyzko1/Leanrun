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
    /// 日 期：2018-03-16 16:41
    /// 描 述：解译工程项目基本信息表
    /// </summary>
    public class JYGC_PROJECTBASEINFOController : MvcControllerBase
    {
        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult JYGC_PROJECTBASEINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult JYGC_PROJECTBASEINFOForm()
        {
            return View();
        }
        #endregion
    }
}
