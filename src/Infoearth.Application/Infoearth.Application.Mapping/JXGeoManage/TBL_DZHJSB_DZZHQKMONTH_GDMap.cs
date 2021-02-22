using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-15 15:38
    /// 描 述：巡查隐患点灾情表
    /// </summary>
    public class TBL_DZHJSB_DZZHQKMONTH_GDMap : EntityTypeConfiguration<TBL_DZHJSB_DZZHQKMONTH_GDEntity>
    {
        public TBL_DZHJSB_DZZHQKMONTH_GDMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_DZHJSB_DZZHQKMONTH_GD");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.ZHGM).HasColumnName("ZHGM").IsOptional().HasPrecision(15,8);
            Property(x => x.ZJJJSS).HasColumnName("ZJJJSS").IsOptional().HasPrecision(10,2);
            #region 配置关系
            #endregion
        }
    }
}
