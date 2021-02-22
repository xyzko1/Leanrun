﻿using Infoearth.Application.Entity.CustomerManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.CustomerManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：佘赐雄
    /// 日 期：2016-03-16 13:54
    /// 描 述：订单明细
    /// </summary>
    public class OrderEntryMap : EntityTypeConfiguration<OrderEntryEntity>
    {
        public OrderEntryMap()
        {
            #region 表、主键
            //表
            this.ToTable("CLIENT_ORDERENTRY");//Client_OrderEntry
            //主键
            this.HasKey(t => t.F_OrderEntryId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}