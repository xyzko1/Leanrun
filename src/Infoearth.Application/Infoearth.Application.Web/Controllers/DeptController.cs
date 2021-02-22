using iTelluro.Busness.WebApiProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infoearth.Util;
using Infoearth.Util.WebControl;

namespace Infoearth.Application.Web.Controllers
{
    public class DeptController : MvcControllerBase
    {
        SSOWebApiWS ws = new SSOWebApiWS("");
        public ActionResult DeptForm()
        {
            return View();
        }

        /// <summary>
        /// 根据名称查询联系人信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllDept(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = ws.GetDept(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(jsonData.ToJson().Replace("\\", "").Replace("\"[", "[").Replace("]\"", "]"));
        }
	}
}