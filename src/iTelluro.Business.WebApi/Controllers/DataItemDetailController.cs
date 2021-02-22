using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApi;
using System.Web.Http;
using System.Collections.Generic;
using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Cache;
using Infoearth.Application.Entity.SystemManage.ViewModel;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 地灾字典接口  by wc 2018-4-27
    /// </summary>
    public class DataItemDetailApiController : ApiControllerBase
    {
        private DataItemCache dataItemCache = new DataItemCache();

        #region 获取数据
 
        /// <summary>
        /// 获取数据字典列表（绑定控件）
        /// </summary>
        /// <param name="EnCode">字典代码</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public IEnumerable<DataItemModel> GetDataItemListJson(string EnCode)
        {
            var data = dataItemCache.GetDataItemList(EnCode);
            return data;
        }

        #endregion
    }
}
