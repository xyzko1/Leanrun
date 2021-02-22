using Infoearth.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.DemoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2016-10-17 09:47
    /// 描 述：订单管理
    /// </summary>
    public class Client_OrderEntryMap : EntityTypeConfiguration<Client_OrderEntryEntity>
    {
        public Client_OrderEntryMap()
        {
            #region 表、主键
            //表
            this.ToTable("Client_OrderEntry");
            //主键
            this.HasKey(t => t.F_OrderEntryId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
