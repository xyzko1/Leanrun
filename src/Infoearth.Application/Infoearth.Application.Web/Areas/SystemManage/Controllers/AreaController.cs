using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Code;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Util;
using iTelluro.Busness.WebApiProxy;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 
    /// 创建人：佘赐雄
    /// 日 期：2015.11.12 16:40
    /// 描 述：区域管理
    /// </summary>
    public class AreaController : MvcControllerBase
    {
        #region 获取数据

        /// <summary>
        /// 区域列表（主要是绑定下拉框）
        /// </summary>
        /// <param name="parentId">节点Id</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetAreaListJson(string parentId)
        {
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            var data = ws.GetAreaListJson(parentId == null ? "0" : parentId);
            return Content(data.ToJson());
        }

        /// <summary>
        /// 区域列表（主要是绑定下拉框）
        /// </summary>
        /// <param name="parentId">节点Id</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetProvinceListJson(string parentId, string provinceIds)
        {
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
           
            if (string.IsNullOrEmpty(parentId))
                parentId = "0";
            if (!string.IsNullOrEmpty(provinceIds))
            {
                var provinces = ws.GetAllProvinceByCodes(provinceIds);
                return Content(provinces.ToJson());
            }
            return GetAreaListJson(parentId);
        }
        [HttpGet]
        public ActionResult GetAllByParentCodes(string codes)
        {
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);


            var provinces = ws.GetAllByParentCodes(codes);
            return Content(provinces.ToJson());

        }

        #endregion
    }
}
