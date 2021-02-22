﻿using Infoearth.Application.Busines;
using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Entity.SystemManage.ViewModel;
using Infoearth.Cache.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infoearth.Application.Cache
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.12.29 9:56
    /// 描 述：数据字典缓存
    /// </summary>
    public class DataItemCache
    {
        private DataItemDetailBLL busines = new DataItemDetailBLL();

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemModel> GetDataItemList()
        {
            try
            {
                var cacheList = CacheFactory.Cache().GetCache<IEnumerable<DataItemModel>>(busines.cacheKey);
                if (cacheList == null)
                {
                    var data = busines.GetDataItemList();
                    CacheFactory.Cache().WriteCache(data, busines.cacheKey);
                    return data;
                }
                else
                {
                    return cacheList;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="EnCode">分类代码</param>
        /// <returns></returns>
        public IEnumerable<DataItemModel> GetDataItemList(string EnCode)
        {
            return this.GetDataItemList().Where(t => t.F_EnCode == EnCode);
        }
        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="EnCode">分类代码</param>
        /// <param name="ItemValue">项目值</param>
        /// <returns></returns>
        public IEnumerable<DataItemModel> GetSubDataItemList(string EnCode, string ItemValue)
        {
            var data = this.GetDataItemList().Where(t => t.F_EnCode == EnCode);
            string ItemDetailId = data.First(t => t.F_ItemValue == ItemValue).F_ItemDetailId;
            return data.Where(t => t.F_ParentId == ItemDetailId);
        }
        /// <summary>
        /// 项目值转换名称
        /// </summary>
        /// <param name="EnCode">分类代码</param>
        /// <param name="ItemValue">项目值</param>
        /// <returns></returns>
        public string ToItemName(string EnCode, string ItemValue)
        {
            var data = this.GetDataItemList().Where(t => t.F_EnCode == EnCode);
            return data.First(t => t.F_ItemValue == ItemValue).F_ItemName;
        }
    }
}
