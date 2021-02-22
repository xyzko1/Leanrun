using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Http;

namespace iTelluro.Busness.WebApi.Controllers
{
  public   class TBL_DZHJSB_DZZHQKMONTH_GDApiController : ApiControllerBase
    {
        private TBL_DZHJSB_DZZHQKMONTH_GDBLL tbl_dzhjsb_dzzhqkmonth_gdbll = new TBL_DZHJSB_DZZHQKMONTH_GDBLL();
        /// <summary>
        /// 统计
        /// Year
        /// StartMonth
        /// EndMonth
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public DataTable Getdata(string queryJson)
        {
            return tbl_dzhjsb_dzzhqkmonth_gdbll.Getdata(queryJson);
        }
    }
}
