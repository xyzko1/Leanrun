using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-13 16:23
    /// 描 述：群测群防监测流水数据表
    /// </summary>
    public class TBL_QCQF_POINTRECORDMap : EntityTypeConfiguration<TBL_QCQF_POINTRECORDEntity>
    {
        public TBL_QCQF_POINTRECORDMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_QCQF_POINTRECORD");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.SLITWIDTH).HasColumnName("SLITWIDTH").IsOptional().HasPrecision(38,2);
            Property(x => x.TODRUMHEIGH).HasColumnName("TODRUMHEIGH").IsOptional().HasPrecision(38,2);
            Property(x => x.SPRINGAMOUNT).HasColumnName("SPRINGAMOUNT").IsOptional().HasPrecision(38,2);
            Property(x => x.WELLLEVEL).HasColumnName("WELLLEVEL").IsOptional().HasPrecision(38,2);
            Property(x => x.UPLOADLONGITUDE).HasColumnName("UPLOADLONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.UPLOADLATITUDE).HasColumnName("UPLOADLATITUDE").IsOptional().HasPrecision(12,8);
            #region 配置关系
            #endregion
        }
    }
}
