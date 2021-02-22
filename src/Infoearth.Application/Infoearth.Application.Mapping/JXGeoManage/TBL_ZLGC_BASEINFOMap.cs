using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-05-09 14:53
    /// 描 述：治理工程信息表
    /// </summary>
    public class TBL_ZLGC_BASEINFOMap : EntityTypeConfiguration<TBL_ZLGC_BASEINFOEntity>
    {
        public TBL_ZLGC_BASEINFOMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_ZLGC_BASEINFO");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12, 8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12, 8);
            Property(x => x.BUDGET).HasColumnName("BUDGET").IsOptional().HasPrecision(10, 2);
            Property(x => x.ISSUEDCAPITAL).HasColumnName("ISSUEDCAPITAL").IsOptional().HasPrecision(10, 2);
            Property(x => x.CENTRALFUNDS).HasColumnName("CENTRALFUNDS").IsOptional().HasPrecision(10, 2);
            Property(x => x.FINALMONEY).HasColumnName("FINALMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.XMPFZJ).HasColumnName("XMPFZJ").IsOptional().HasPrecision(15, 2);
            #region 配置关系
            #endregion
        }
    }
}