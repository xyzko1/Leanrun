using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.UIManage.Controllers
{
    /// <summary>
    /// UI设计控制器
    /// </summary>
    public class UIDesignController : Controller
    {
        /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string ControlUrl = System.Configuration.ConfigurationManager.AppSettings["ControlDetailUrl"];
            ViewBag.ControlUrl = ControlUrl;
            return View();
        }

        /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OrmIndex()
        {
            return View();
        }

        /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult RegistorIndex()
        {
            return View();
        }

        /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult MapIndex()
        {
            string ControlUrl = System.Configuration.ConfigurationManager.AppSettings["ControlDetailUrl"];
            ViewBag.ControlUrl = ControlUrl;
            return View();
        }

        /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult PdfIndex()
        {
            return View();
        }

        /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult GuideIndex()
        {
            return View();
        }
        /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult EchartsIndex()
        {
            return View();
        }
        /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult MQIndex()
        {
            return View();
        }
        /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult TaskIndex()
        {
            return View();
        }
   /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportIndex()
        {
            return View();
        }

        /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ImportIndex()
        {
            return View();
        }


  /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SignalrIndex()
        {
            return View();
        }
  /// <summary>
        /// 设计页面
        /// </summary>
        /// <returns></returns>
        public ActionResult BaobiaoIndex()
        {
            return View();
        }

        
    }
}
