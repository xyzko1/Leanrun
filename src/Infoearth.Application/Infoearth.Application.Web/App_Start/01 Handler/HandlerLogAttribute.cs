using Infoearth.Application.Code;
using Infoearth.Application.Entity.SystemManage;
using iTelluro.Busness.WebApiProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infoearth.Application.Web
{
    /// <summary>
    /// 操作日志记录拦截器
    /// </summary>
    public class HandlerLogAttribute : ActionFilterAttribute
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            object[] atters = filterContext.ActionDescriptor.GetCustomAttributes(typeof(LogContentAttribute), false);
            if (atters == null || atters.Length <= 0)
            {
                return;
            }

            LogContentAttribute logA = atters[0] as LogContentAttribute;
            if (logA == null)
            {
                return;
            }
            HttpRequestBase Request = filterContext.HttpContext.Request;
            //路由信息
            RouteValueDictionary routes = filterContext.RouteData.Values;
            string baseUrl = Request.Url.ToString();
            var areaName = filterContext.RouteData.DataTokens["area"];
            string controller = routes["controller"].ToString();
            string action = routes["action"].ToString();
            ParameterDescriptor[] pp = filterContext.ActionDescriptor.GetParameters();

            switch (logA.OpType)
            {
                case OpType.Delete:
                    {
                        if (pp == null || pp.Length <= 0)
                        {
                            return;
                        }
                        ParameterDescriptor p = pp[0];
                        if (p.ParameterType != typeof(string))
                        {
                            return;
                        }

                        object value = filterContext.ActionParameters[p.ParameterName];
                        if (value == null)
                        {
                            return;
                        }
                        LogEntity _logEntity = new LogEntity();
                        _logEntity.F_ExecuteResultJson = "用户：" + OperatorProvider.Provider.Current().Account + ":删除了" + value.ToString() + "数据";
                        _logEntity.F_CategoryId = 3;
                        _logEntity.F_Module = logA.ModuleName + "管理";
                        _logEntity.F_OperateTypeId = "5";
                        _logEntity.F_OperateType = "操作";
                        _logEntity.F_ExecuteResult = 1;
                        _logEntity.F_LOGFROM = System.Configuration.ConfigurationManager.AppSettings["BusinessName"];
                        ssoWS.SavaLog(_logEntity);
                    }

                    break;
                case OpType.Details:
                    {
                        if (pp == null || pp.Length <= 0)
                        {
                            return;
                        }
                        ParameterDescriptor p = pp[0];
                        if (p.ParameterType != typeof(string))
                        {
                            return;
                        }
                        object value = filterContext.ActionParameters[p.ParameterName];
                        if (value == null)
                        {
                            return;
                        }
                        LogEntity _logEntity = new LogEntity();
                        _logEntity.F_ExecuteResultJson = "用户：" + OperatorProvider.Provider.Current().Account + ":查询了" + value.ToString() + "数据";
                        _logEntity.F_CategoryId = 3;
                        _logEntity.F_Module = logA.ModuleName + "管理";
                        _logEntity.F_OperateTypeId = "5";
                        _logEntity.F_OperateType = "操作";
                        _logEntity.F_ExecuteResult = 1;
                        _logEntity.F_LOGFROM = System.Configuration.ConfigurationManager.AppSettings["BusinessName"];
                        ssoWS.SavaLog(_logEntity);
                    }
                    break;
                case OpType.Query:
                    {
                        LogEntity _logEntity = new LogEntity();
                        _logEntity.F_ExecuteResultJson = "用户：" + OperatorProvider.Provider.Current().Account + ":查询了" + logA.ModuleName + "数据";
                        _logEntity.F_CategoryId = 3;
                        _logEntity.F_Module = logA.ModuleName + "管理";
                        _logEntity.F_OperateTypeId = "5";
                        _logEntity.F_OperateType = "操作";
                        _logEntity.F_ExecuteResult = 1;
                        _logEntity.F_LOGFROM = System.Configuration.ConfigurationManager.AppSettings["BusinessName"];
                        ssoWS.SavaLog(_logEntity);
                    }
                    break;
                case OpType.Update:
                    {
                        if (pp == null || pp.Length <= 0)
                        {
                            return;
                        }
                        ParameterDescriptor p = pp[0];
                        if (p.ParameterType != typeof(string))
                        {
                            return;
                        }
                        object value = filterContext.ActionParameters[p.ParameterName];
                        if (value == null)
                        {
                            return;
                        }
                        LogEntity _logEntity = new LogEntity();
                        _logEntity.F_ExecuteResultJson = "用户：" + OperatorProvider.Provider.Current().Account + ":修改了" + value.ToString() + "数据";
                        _logEntity.F_CategoryId = 3;
                        _logEntity.F_Module = logA.ModuleName + "管理";
                        _logEntity.F_OperateTypeId = "5";
                        _logEntity.F_OperateType = "操作";
                        _logEntity.F_ExecuteResult = 1;
                        _logEntity.F_LOGFROM = System.Configuration.ConfigurationManager.AppSettings["BusinessName"];
                        ssoWS.SavaLog(_logEntity);
                    }
                    break;
            }
        }
    }
}