using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Code;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.DemoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 
    /// 创建人：陈小二
    /// 日 期：2016.3.11 14:22
    /// 描 述：客户订单
    /// </summary>
    public class DemoSystemFormController : MvcControllerBase
    {
        private CodeRuleBLL codeRuleBLL = new CodeRuleBLL();
        /// <summary>
        /// 订单表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DemoForm()
        {

            if (Request["keyValue"] == null)
            {
                ViewBag.OrderCode = codeRuleBLL.GetBillCode(SystemInfo.CurrentUserId, "", ((int)CodeRuleEnum.Customer_OrderCode).ToString());
            }
            return View();
        }
    }
}