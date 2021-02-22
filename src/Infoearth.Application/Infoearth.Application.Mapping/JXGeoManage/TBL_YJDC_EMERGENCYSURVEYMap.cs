using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-13 13:27
    /// 描 述：
    /// </summary>
    public class TBL_YJDC_EMERGENCYSURVEYMap : EntityTypeConfiguration<TBL_YJDC_EMERGENCYSURVEYEntity>
    {
        public TBL_YJDC_EMERGENCYSURVEYMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_YJDC_EMERGENCYSURVEY");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12, 8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12, 8);
            Property(x => x.DANGERPOTENTIALECONOMICLOSSES).HasColumnName("DANGERPOTENTIALECONOMICLOSSES").IsOptional().HasPrecision(12, 8);
            Property(x => x.LANDSLIDEDIRECTION).HasColumnName("LANDSLIDEDIRECTION").IsOptional().HasPrecision(12, 8);
            Property(x => x.LANDSLIDESLOPE).HasColumnName("LANDSLIDESLOPE").IsOptional().HasPrecision(12, 8);
            Property(x => x.LANDSLIDELENGTH).HasColumnName("LANDSLIDELENGTH").IsOptional().HasPrecision(12, 8);
            Property(x => x.LANDSLIDEWIDTH).HasColumnName("LANDSLIDEWIDTH").IsOptional().HasPrecision(12, 8);
            Property(x => x.LANDSLIDETHICKNESS).HasColumnName("LANDSLIDETHICKNESS").IsOptional().HasPrecision(12, 8);
            Property(x => x.LANDSLIDEAREA).HasColumnName("LANDSLIDEAREA").IsOptional().HasPrecision(12, 8);
            Property(x => x.LANDSLIDEVOLUME).HasColumnName("LANDSLIDEVOLUME").IsOptional().HasPrecision(12, 8);
            Property(x => x.COLLAPSEDIRECTION).HasColumnName("COLLAPSEDIRECTION").IsOptional().HasPrecision(12, 8);
            Property(x => x.COLLAPSESLOPE).HasColumnName("COLLAPSESLOPE").IsOptional().HasPrecision(12, 8);
            Property(x => x.COLLAPSEHEIGHT).HasColumnName("COLLAPSEHEIGHT").IsOptional().HasPrecision(12, 8);
            Property(x => x.COLLAPSEWIDTH).HasColumnName("COLLAPSEWIDTH").IsOptional().HasPrecision(12, 8);
            Property(x => x.COLLAPSETHICKNESS).HasColumnName("COLLAPSETHICKNESS").IsOptional().HasPrecision(12, 8);
            Property(x => x.COLLAPSEVOLUME).HasColumnName("COLLAPSEVOLUME").IsOptional().HasPrecision(12, 8);
            Property(x => x.COLLAPSEMAXBLOCKDEGREE).HasColumnName("COLLAPSEMAXBLOCKDEGREE").IsOptional().HasPrecision(12, 8);
            Property(x => x.DEBRISFLOWGULLYSLOPE).HasColumnName("DEBRISFLOWGULLYSLOPE").IsOptional().HasPrecision(12, 8);
            Property(x => x.DEBRISFLOWSLOPE).HasColumnName("DEBRISFLOWSLOPE").IsOptional().HasPrecision(12, 8);
            Property(x => x.DEBRISFLOWMUD).HasColumnName("DEBRISFLOWMUD").IsOptional().HasPrecision(12, 8);
            Property(x => x.DEBRISFLOWFANLENGTH).HasColumnName("DEBRISFLOWFANLENGTH").IsOptional().HasPrecision(12, 8);
            Property(x => x.DEBRISFLOWFANWIDTH).HasColumnName("DEBRISFLOWFANWIDTH").IsOptional().HasPrecision(12, 8);
            Property(x => x.DEBRISFLOWSTACKEXTENSION).HasColumnName("DEBRISFLOWSTACKEXTENSION").IsOptional().HasPrecision(12, 8);
            Property(x => x.DEBRISFLOWFANTHICKNESS).HasColumnName("DEBRISFLOWFANTHICKNESS").IsOptional().HasPrecision(12, 8);
            Property(x => x.DEBRISFLOWOUTOFVOLUME).HasColumnName("DEBRISFLOWOUTOFVOLUME").IsOptional().HasPrecision(12, 8);
            Property(x => x.GROUNDAREA).HasColumnName("GROUNDAREA").IsOptional().HasPrecision(12, 8);
            Property(x => x.GROUNDFALLWAYSCALE).HasColumnName("GROUNDFALLWAYSCALE").IsOptional().HasPrecision(12, 8);
            Property(x => x.GROUNDDEPTH).HasColumnName("GROUNDDEPTH").IsOptional().HasPrecision(12, 8);
            Property(x => x.GROUNDFRACTURELENGTH).HasColumnName("GROUNDFRACTURELENGTH").IsOptional().HasPrecision(12, 8);
            Property(x => x.TRIGGERRAINFALL).HasColumnName("TRIGGERRAINFALL").IsOptional().HasPrecision(12, 8);
            Property(x => x.TRIGGEREARTHQUAKEMAGNITUDE).HasColumnName("TRIGGEREARTHQUAKEMAGNITUDE").IsOptional().HasPrecision(12, 8);
            Property(x => x.TRIGGEREARTHQUAKEINTENSITY).HasColumnName("TRIGGEREARTHQUAKEINTENSITY").IsOptional().HasPrecision(12, 8);
            Property(x => x.TRIGGERHTEMPERATURE).HasColumnName("TRIGGERHTEMPERATURE").IsOptional().HasPrecision(12, 8);
            Property(x => x.TRIGGERLTEMPERATURE).HasColumnName("TRIGGERLTEMPERATURE").IsOptional().HasPrecision(12, 8);
            Property(x => x.DISASTERDIRECTECONOMICLOSSES).HasColumnName("DISASTERDIRECTECONOMICLOSSES").IsOptional().HasPrecision(12, 8);
            Property(x => x.DISASTERSCALE).HasColumnName("DISASTERSCALE").IsOptional().HasPrecision(12, 8);
            #region 配置关系
            #endregion
        }
    }
}
