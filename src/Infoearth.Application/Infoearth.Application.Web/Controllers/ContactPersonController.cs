using iTelluro.Busness.WebApiProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infoearth.Util;
using iTelluro.SYS.Entity;
using Infoearth.Util.WebControl;

namespace Infoearth.Application.Web.Controllers
{
    /// <summary>
    /// 联系人信息控制器  by wc
    /// </summary>
    public class ContactPersonController : MvcControllerBase
    {
        SSOWebApiWS ws = new SSOWebApiWS("");
        /// <summary>
        /// 默认首页
        /// </summary>
        /// <returns></returns>
        public ActionResult ContactPersonForm()
        {
            return View();
        }
        public ActionResult gdzb()
        {
            return View();
        }
        /// <summary>
        /// 根据名称查询联系人信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetContactPerson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = ws.GetUser(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(jsonData.ToJson().Replace("\\r\\n", "").Replace("\\", "").Replace("\"[", "[").Replace("]\"", "]"));
            //return Content(jsonData.ToJson());
        }
    }
}
