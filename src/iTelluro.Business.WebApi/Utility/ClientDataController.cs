using System.Collections.Generic;
using System.Data;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Infoearth.Util.Offices;
using System.Web;
using System.Threading;
using System;
using System.IO;
using Infoearth.Application.Busines.SystemManage;
using System.Linq;
using Infoearth.Application.Entity.PublicInfoManage;
using Infoearth.Application.Busines.PublicInfoManage;
using Infoearth.Application.Entity.SystemManage;
using System.Data.Common;
using System.Reflection;
using Infoearth.Application.Entity;
using System.Web.Http;
using Infoearth.Application.Entity.SystemManage.ViewModel;
using Infoearth.Application.Cache;

namespace iTelluro.Busness.WebApi
{
   /// <summary>
    /// 客户端数据
   /// </summary>
    public class ClientDataController : ApiControllerBase
    {
        private DataItemCache dataItemCache = new DataItemCache();
        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <returns></returns>
        public object GetDataItem()
        {
            var dataList = dataItemCache.GetDataItemList().Where(t => !string.IsNullOrEmpty(t.F_EnCode)); ;
            var dataSort = dataList.Distinct(new Comparint<DataItemModel>("F_EnCode"));
            Dictionary<string, object> dictionarySort = new Dictionary<string, object>();
            foreach (DataItemModel itemSort in dataSort)
            {
                var dataItemList = dataList.Where(t => t.F_EnCode.Equals(itemSort.F_EnCode));
                Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();
                foreach (DataItemModel itemList in dataItemList)
                {
                    if (!dictionaryItemList.ContainsKey(itemList.F_ItemValue))
                    {
                        dictionaryItemList.Add(itemList.F_ItemValue, itemList.F_ItemName);
                    }
                }
                foreach (DataItemModel itemList in dataItemList)
                {
                    if (!dictionaryItemList.ContainsKey(itemList.F_ItemDetailId))
                    {
                        dictionaryItemList.Add(itemList.F_ItemDetailId, itemList.F_ItemName);
                    }
                }
                dictionarySort.Add(itemSort.F_EnCode, dictionaryItemList);
            }
            return dictionarySort;
        }
    }
}
