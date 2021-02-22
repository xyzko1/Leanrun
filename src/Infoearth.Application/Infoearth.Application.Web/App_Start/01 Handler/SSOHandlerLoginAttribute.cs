using Infoearth.Application.Busines.AuthorizeManage;
using Infoearth.Application.Code;
using Infoearth.Util;
using iTelluro.Busness.WebApiProxy;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infoearth.Application.Web
{
    public class SSOHandlerLoginAttribute : AuthorizeAttribute
    {
        private string SSOUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
        private string _meunFrom = System.Configuration.ConfigurationManager.AppSettings["MeunFrom"];
        private string _token = string.Empty;
        private string _samlName = string.Empty;
        private ModuleBLL moduleBll = new ModuleBLL();

        private SSOWebApiWS _ssoWS = null;

        public SSOHandlerLoginAttribute()
        {
            _ssoWS = new SSOWebApiWS(SSOUrl);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //判断是否忽略SSO验证
            var attributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true);
            bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
            if (isAnonymous)
            {
                return;
            }
            var attributesLogin = filterContext.ActionDescriptor.GetCustomAttributes(typeof(LoginAttribute), true);
            bool isLogin = attributesLogin.Any(a => a is LoginAttribute);
            if (!isLogin)
            {
                return;
            }

            #region 访问参数
            HttpRequestBase Request = filterContext.HttpContext.Request;
            //路由信息
            RouteValueDictionary routes = filterContext.RouteData.Values;
            //QueryString信息
            NameValueCollection queryString = Request.QueryString;
            string baseUrl = Request.Url.ToString();
            var areaName = filterContext.RouteData.DataTokens["area"];
            string controller = routes["controller"].ToString();
            string action = routes["action"].ToString();
            string url = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/Home/Index";

            #endregion

            //判断请求路径有没有IsSaml参数
            if (!string.IsNullOrEmpty(queryString["IsSaml"]))
            {
                //获取samlName
                TryFetchSamlName(filterContext);
                //地址中去掉Token参数
                int index = 0;
                for (int i = 0; i < queryString.Count; i++)
                {
                    string qk = queryString.GetKey(i);
                    string qkValue = queryString.Get(i);
                    if (qk == "Token")
                    {
                        continue;
                    }
                    if (index == 0)
                    {
                        url += "?" + qk + "=" + qkValue;
                    }
                    else
                    {
                        url += "&" + qk + "=" + qkValue;
                    }
                    index++;
                }
                if (!Request.IsAuthenticated && string.IsNullOrEmpty(_samlName))
                {
                    //没有带token信息,缓存中没有token信息,直接跳转登陆页面
                    //filterContext.Result = new RedirectResult(SSOUrl + "Login/SSOIndex?BackURL=" + url);
                    var samlEndpoint = @"http://localhost:16471/Account/LogOn";
                    var request = new Infoearth.Application.Web.AuthRequest("infoearth", url);
                    string requestUrl = request.GetRedirectUrl(samlEndpoint);
                    filterContext.Result = new RedirectResult(requestUrl);
                    return;
                }
            }
            else
            {
                //获取token信息
                TryFetchToken(filterContext);
                //地址中去掉Token参数
                int index2 = 0;
                for (int i = 0; i < queryString.Count; i++)
                {
                    string qk = queryString.GetKey(i);
                    string qkValue = queryString.Get(i);
                    if (qk == "Token")
                    {
                        continue;
                    }
                    if (index2 == 0)
                    {
                        url += "?" + qk + "=" + qkValue;
                    }
                    else
                    {
                        url += "&" + qk + "=" + qkValue;
                    }
                    index2++;
                }

                if (!Request.IsAuthenticated && string.IsNullOrEmpty(_token))
                {
                    //没有带token信息,缓存中没有token信息,直接跳转登陆页面
                    filterContext.Result = new RedirectResult(SSOUrl + "Login/SSOIndex?BackURL=" + url);
                    return;
                }

                //验证token的有效性
                string ticket = _token.Split(',')[0];
                if (!_ssoWS.CheckToken(Md5Helper.MD5(ticket, 32).ToUpper()))
                {
                    filterContext.Result = new RedirectResult(SSOUrl + "Login/SSOIndex?BackURL=" + url);
                    return;
                }

                //验证Url是否合法
                string webUrl = string.Empty;
                //string moduleId = string.Empty;
                //if (areaName != null)
                //{
                //    webUrl += "/" + areaName.ToString() + "/";

                //    webUrl += controller + "/" + action;
                //    bool isFromSSO = false;
                //    if (string.IsNullOrEmpty(_meunFrom) || _meunFrom == "0")
                //    {
                //        isFromSSO = false;
                //    }
                //    else
                //    {
                //        isFromSSO = true;
                //    }
                //    if (!isFromSSO)
                //    {
                //        var module = moduleBll.GetModuleByUrl(webUrl);
                //        if (module == null)
                //        {
                //            filterContext.HttpContext.Response.Redirect(SSOUrl + "AccessDeny/Index");
                //            return;
                //        }
                //        else
                //        {
                //            moduleId = module.F_ModuleId;
                //        }
                //    }
                //    if (OperatorProvider.Provider.Current() != null && !OperatorProvider.Provider.Current().IsSystem)
                //    {
                //        if (!_ssoWS.CheckUrlPermission(moduleId, webUrl, isFromSSO))
                //        {
                //            filterContext.HttpContext.Response.Redirect(SSOUrl + "AccessDeny/Index");
                //            return;
                //        }
                //    }
                //}

                //验证是否已登录
                if (bool.Parse(Config.GetValue("CheckOnLine")) == true)
                {
                    if (_ssoWS.IsOnLine(ticket) == 0)
                    {
                        filterContext.Result = new RedirectResult(SSOUrl + "AccessDeny/OnLine?BackURL=" + url);
                        return;
                    }
                }

                //去掉Token后重新定位
                if (!string.IsNullOrEmpty(queryString.Get("Token")))
                {
                    filterContext.Result = new RedirectResult(url);
                    return;
                }
            }

            GetUserInfo();

            ////检测页面权限
            //if (url.Contains('?'))
            //{
            //    url = url.Substring(0, url.IndexOf('?'));//截取页面的url
            //}
            //string moudelId = WebHelper.GetCookie("currentmoduleId");
            //if (string.IsNullOrEmpty(moudelId))
            //{
            //    moudelId = "";
            //}
            //string webUrl = string.Empty;
            //if (areaName != null)
            //{
            //    webUrl += "/" + areaName.ToString();
            //}
            //webUrl += "/" + controller + "/" + action;
            ////检查权限
            //if (!CheckUrlPermission(tiket, moudelId, webUrl))
            //{
            //   // filterContext.HttpContext.Response.Redirect(SSOUrl + "AccessDeny/Index");
            //    return;
            //}
        }

        /// <summary>
        /// 此方法还需要做判断
        /// </summary>
        private void GetUserInfo()
        {
            //获取用户信息

            UserInfo info = _ssoWS.GetUserInfo();
            if (info != null)
            {
                Operator operators = new Operator();
                operators.UserId = info.F_UserId;
                operators.Code = info.F_EnCode;
                operators.Account = info.F_Account;
                operators.UserName = info.F_RealName;
                operators.Password = info.F_Password;
                operators.Secretkey = info.F_Secretkey;
                operators.CompanyId = info.F_OrganizeId;
                operators.DepartmentId = info.F_DepartmentId;
                operators.HeadIcon = info.F_HeadIcon;
                operators.XZQHCode = info.F_XZQHCODE;
                operators.F_ISSYSTEM = false;
                operators.F_ISBMFILTER = false;
                if (info.F_ISSYSTEM.HasValue && info.F_ISSYSTEM.Value == 1)
                {
                    operators.F_ISSYSTEM = true;
                }
                if (info.F_ISBMFILTER.HasValue && info.F_ISBMFILTER.Value == 1)
                {
                    operators.F_ISBMFILTER = true;
                }
                if (string.IsNullOrEmpty(operators.HeadIcon))
                {
                    operators.HeadIcon = "noimg";
                }
                operators.IPAddress = Net.Ip;
                operators.LogTime = DateTime.Now;
                operators.Token = DESEncrypt.Encrypt(_token);
                //写入当前用户数据权限
                //判断是否系统管理员
                if (info.F_Account.ToLower() == "system")
                {
                    operators.IsSystem = true;
                }
                else
                {
                    operators.IsSystem = false;
                }

                OperatorProvider.Provider.AddCurrent(operators, null);
            }
        }

        /// <summary>
        /// 从RquestUrl、Cookie或者Session中获得Token值
        /// 结果保存在成员变量token中，默认情况下token值为string.Empty
        /// </summary>
        private void TryFetchToken(AuthorizationContext filterContext)
        {
            _token = string.Empty;
            if (!string.IsNullOrEmpty(filterContext.HttpContext.Request.QueryString.Get("Token")))
            {
                _token = filterContext.HttpContext.Request.QueryString.Get("Token");
                _token = HttpUtility.UrlDecode(_token);
                filterContext.HttpContext.Response.Cookies.Add(new HttpCookie("Token", _token));
            }
            else
            {
                var cookie = filterContext.HttpContext.Request.Cookies["Token"];
                if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
                {
                    _token = cookie.Value;
                    _token = HttpUtility.UrlDecode(_token);
                }
            }
        }

        /// <summary>
        /// 从RquestUrl、Cookie或者Session中获得saml验证值SamlName
        /// 结果保存在成员变量SamlName中，默认情况下Name值为string.Empty
        /// </summary>
        private void TryFetchSamlName(AuthorizationContext filterContext)
        {
            _samlName = string.Empty;
            if (!string.IsNullOrEmpty(filterContext.HttpContext.Request.QueryString.Get("SAMLResponse")))
            {
                string responseStr = filterContext.HttpContext.Request.QueryString.Get("SAMLResponse");
                string samlCer = "";
                Response samlResponse = new Response(samlCer);
                samlResponse.LoadXmlFromBase64(responseStr);
                if (samlResponse.IsValid())
                {
                    string samlUnique, expireTime;
                    try
                    {
                        samlUnique = samlResponse.GetNameID();
                        expireTime = samlResponse.GetEmail();
                        _samlName = samlUnique;
                    }
                    catch
                    { }
                }
                _samlName = HttpUtility.UrlDecode(_samlName);
                filterContext.HttpContext.Response.Cookies.Add(new HttpCookie("SamlName", _samlName));
            }
            else
            {
                var cookie = filterContext.HttpContext.Request.Cookies["SamlName"];
                if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
                {
                    _samlName = cookie.Value;
                    _samlName = HttpUtility.UrlDecode(_samlName);
                }
            }
        }
    }
}