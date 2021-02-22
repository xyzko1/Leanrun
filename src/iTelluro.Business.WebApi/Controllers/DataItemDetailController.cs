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
    /// �����ֵ�ӿ�  by wc 2018-4-27
    /// </summary>
    public class DataItemDetailApiController : ApiControllerBase
    {
        private DataItemCache dataItemCache = new DataItemCache();

        #region ��ȡ����
 
        /// <summary>
        /// ��ȡ�����ֵ��б��󶨿ؼ���
        /// </summary>
        /// <param name="EnCode">�ֵ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        public IEnumerable<DataItemModel> GetDataItemListJson(string EnCode)
        {
            var data = dataItemCache.GetDataItemList(EnCode);
            return data;
        }

        #endregion
    }
}
