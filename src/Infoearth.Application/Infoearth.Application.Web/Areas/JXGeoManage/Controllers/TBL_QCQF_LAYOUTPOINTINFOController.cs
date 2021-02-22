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
    /// 日 期：2018-06-07 17:24
    /// 描 述：群测群防监测点信息表
    /// </summary>
    public class TBL_QCQF_LAYOUTPOINTINFOController : MvcControllerBase
    {
        private TBL_QCQF_LAYOUTPOINTINFOBLL tbl_qcqf_layoutpointinfobll = new TBL_QCQF_LAYOUTPOINTINFOBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_LAYOUTPOINTINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_LAYOUTPOINTINFOForm()
        {
            return View();
        }
        /// <summary>
        /// 数据上报
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_LAYOUTPOINTINFOSJSB()
        {
            return View();
        }
        /// <summary>
        /// 选择灾害点
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult XZZHD()
        {
            return View();
        }
        /// <summary>
        /// 关联观测人
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GLGCR()
        {
            return View();
        }
        /// <summary>
        /// 宏观巡查
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_AROUNDRECORDForm()
        {
            return View();
        }
        /// <summary>
        /// 监测点数据上报
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_POINTRECORDForm()
        {
            return View();
        }
        /// <summary>
        /// 监测点详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult JCDXQ()
        {
            return View();
        }
        #endregion
    }
}
