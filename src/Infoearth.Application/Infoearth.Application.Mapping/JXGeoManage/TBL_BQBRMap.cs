using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:25
    /// 描 述：搬迁避让信息表
    /// </summary>
    public class TBL_BQBRMap : EntityTypeConfiguration<TBL_BQBREntity>
    {
        public TBL_BQBRMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_BQBR");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.JFMJ).HasColumnName("JFMJ").IsOptional().HasPrecision(12, 8);
            Property(x => x.JFJD).HasColumnName("JFJD").IsOptional().HasPrecision(12, 8);
            Property(x => x.JFWD).HasColumnName("JFWD").IsOptional().HasPrecision(12, 8);
            Property(x => x.XFMJ).HasColumnName("XFMJ").IsOptional().HasPrecision(12, 8);
            Property(x => x.XFJD).HasColumnName("XFJD").IsOptional().HasPrecision(12, 8);
            Property(x => x.XFWD).HasColumnName("XFWD").IsOptional().HasPrecision(12, 8);
            #region 配置关系
            #endregion
        }
    }
}
