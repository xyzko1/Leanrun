using Infoearth.Application.Busines.BaseManage;
using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Code;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Util;
using Infoearth.Util.Attributes;
using iTelluro.Busness.WebApiProxy;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Controllers
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.1.7
    /// Copyright (c) 2013-2016 
    /// 创建人：佘赐雄
    /// 日 期：2015.09.01 13:32
    /// 描 述：系统首页
    /// </summary>
    [SSOHandlerLogin]
    public class HomeController : Controller
    {
        UserBLL user = new UserBLL();
        DepartmentBLL department = new DepartmentBLL();

        private SSOWebApiWS ssoWS = new SSOWebApiWS("");

        #region 视图功能
        /// <summary>
        /// 初始化页面
        /// </summary>
        [Login]
        public ActionResult Index()
        {
            //string sid = this.HttpContext.Session.SessionID;
            var learn_UItheme = WebHelper.GetCookie("learn_UItheme");
            switch (learn_UItheme)
            {
                case "1":
                    return RedirectToAction("AdminDefault", "Home");
                case "2":
                    return RedirectToAction("AdminLTE", "Home");
                case "3":
                    return RedirectToAction("AdminWindos", "Home");
                case "4":
                    return RedirectToAction("AdminPretty", "Home");
                case "5":
                    return RedirectToAction("AdminWater", "Home");
                default:
                    return RedirectToAction("AdminWater", "Home");
            }
        }
        /// <summary>
        /// 默认首页
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult AdminDefault()
        {
            WebHelper.WriteCookie("learn_UItheme", "1");
            return View();
        }
        /// <summary>
        /// 默认首页桌面
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminDefaultDesktop()
        {
            return View();
        }
        /// <summary>
        /// AdminLTE风格首页
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult AdminLTE()
        {
            WebHelper.WriteCookie("learn_UItheme", "2");
            return View();
        }
        /// <summary>
        /// AdminLTE风格首页桌面
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminLTEDesktop()
        {
            return View();
        }
        /// <summary>
        /// Windos风格首页
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult AdminWindos()
        {
            WebHelper.WriteCookie("learn_UItheme", "3");
            return View();
        }
        /// <summary>
        /// Windos风格首页桌面
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminWindosDesktop()
        {
            return View();
        }
        /// <summary>
        /// Pretty风格首页
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult AdminPretty()
        {
            WebHelper.WriteCookie("learn_UItheme", "4");
            return View();
        }
        /// <summary>
        /// Pretty风格首页桌面
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminWaterDesktop()
        {
            return View();
        }
        /// <summary>
        /// 地下水风格首页
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult AdminWater()
        {
            WebHelper.WriteCookie("learn_UItheme", "5");
            return View();
        }
        /// <summary>
        /// 地下水风格首页桌面
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminPrettyDesktop()
        {
            return View();
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 访问功能
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <param name="moduleName">功能模块</param>
        /// <param name="moduleUrl">访问路径</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult VisitModule(string moduleId, string moduleName, string moduleUrl)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 2;
            logEntity.F_OperateTypeId = ((int)OperationType.Visit).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Visit);
            logEntity.F_OperateAccount = OperatorProvider.Provider.Current().Account;
            logEntity.F_OperateUserId = OperatorProvider.Provider.Current().UserId;
            logEntity.F_ModuleId = moduleId;
            logEntity.F_Module = moduleName;
            logEntity.F_ExecuteResult = 1;
            logEntity.F_ExecuteResultJson = "访问地址：" + moduleUrl;
            logEntity.F_LOGFROM = System.Configuration.ConfigurationManager.AppSettings["BusinessName"];
            //logEntity.WriteLog();
            ssoWS.SavaLog(logEntity);
            return Content(moduleId);
        }
        /// <summary>
        /// 离开功能
        /// </summary>
        /// <param name="moduleId">功能模块Id</param>
        /// <returns></returns>
        public ActionResult LeaveModule(string moduleId)
        {
            return null;
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetWebPath()
        {
            string webUrl = System.Configuration.ConfigurationManager.AppSettings["WebBusinessUrl"];
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];

            var JsonData = new
            {
                webUrl = webUrl.TrimEnd('/'),
                ssoUrl = ssoUrl.TrimEnd('/'),
            };
            return Content(JsonData.ToJson());
        }
        #endregion
    }
}
