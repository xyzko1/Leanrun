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
    /// 日 期：2018-06-07 17:19
    /// 描 述：群测群防观测人信息表
    /// </summary>
    public class TBL_QCQF_OBSERVATIONController : MvcControllerBase
    {
        private TBL_QCQF_OBSERVATIONBLL tbl_qcqf_observationbll = new TBL_QCQF_OBSERVATIONBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_OBSERVATIONIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_OBSERVATIONForm()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TBL_QCQF_OBSERVATIONsearch()
        {
            return View();
        }
        
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_ResponsForm()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult TBL_QCQF_OBForm()
        {
            return View();
        }
        /// <summary>
        /// 关联监测点
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GLJCD()
        {
            return View();
        }
        #endregion

    }
}
