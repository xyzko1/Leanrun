using Infoearth.Application.Busines;
using Infoearth.Application.Busines.AuthorizeManage;
using Infoearth.Application.Busines.BaseManage;
using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Code;
using Infoearth.Application.Entity;
using Infoearth.Application.Entity.BaseManage;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Util;
using Infoearth.Util.Attributes;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Controllers
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 
    /// 创建人：佘赐雄
    /// 日 期：2015.09.01 13:32
    /// 描 述：系统登录
    /// </summary>
    //[HandlerLogin(LoginMode.Ignore)]
    public class LoginController : MvcControllerBase
    {
        #region 视图功能
     
        #endregion

        #region 提交数据
       
        /// <summary>
        /// 安全退出
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [AjaxOnly]
        public ActionResult OutLogin()
        {
            Session.Abandon();                                          //清除当前会话
            Session.Clear();                                            //清除当前浏览器所有Session
            WebHelper.RemoveCookie("learn_autologin");                  //清除自动登录
            WebHelper.RemoveCookie("learn_password");                   //清楚密码
            WebHelper.RemoveCookie("learn_username");                   //清楚账号
            WebHelper.RemoveCookie("Token");                           //清除Token
            OperatorProvider.Provider.EmptyCurrent();

            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            ws.ClearTicket();
            return Content(new AjaxResult { type = ResultType.success, message = "退出系统" }.ToJson());
        }
      
        #endregion

    }
}
