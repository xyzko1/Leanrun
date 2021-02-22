using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-14 14:58
    /// 描 述：灾害点基本表
    /// </summary>
    public class TBL_HAZARDBASICINFOMap : EntityTypeConfiguration<TBL_HAZARDBASICINFOEntity>
    {
        public TBL_HAZARDBASICINFOMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_HAZARDBASICINFO");
            //主键
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion
            //Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            //Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12, 8);
            Property(x => x.X).HasColumnName("X").IsOptional().HasPrecision(10,2);
            Property(x => x.Y).HasColumnName("Y").IsOptional().HasPrecision(10,2);
            Property(x => x.Z).HasColumnName("Z").IsOptional().HasPrecision(10,2);
            Property(x => x.ALTTOP).HasColumnName("ALTTOP").IsOptional().HasPrecision(10,2);
            Property(x => x.ALTBOTOM).HasColumnName("ALTBOTOM").IsOptional().HasPrecision(10,2);
            Property(x => x.THREATENASSETS).HasColumnName("THREATENASSETS").IsOptional().HasPrecision(20,2);
            Property(x => x.DESTROYEDROAD).HasColumnName("DESTROYEDROAD").IsOptional().HasPrecision(18,2);
            Property(x => x.DESTROYEDCANAL).HasColumnName("DESTROYEDCANAL").IsOptional().HasPrecision(18,2);
            #region 配置关系
            #endregion
        }
    }
}
