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
    /// 日 期：2018-06-13 16:23
    /// 描 述：群测群防监测流水数据表
    /// </summary>
    public class TBL_QCQF_POINTRECORDController : MvcControllerBase
    {
        private TBL_QCQF_POINTRECORDBLL tbl_qcqf_pointrecordbll = new TBL_QCQF_POINTRECORDBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_QCQF_POINTRECORDIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_POINTRECORDForm()
        {
            return View();
        }
        #endregion
    }
}
