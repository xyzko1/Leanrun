using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-05 09:47
    /// 描 述：滑坡隐患点调查历史表
    /// </summary>
    public class TBL_LANDSLIP_HIDDEN_HISTORYMap : EntityTypeConfiguration<TBL_LANDSLIP_HIDDEN_HISTORYEntity>
    {
        public TBL_LANDSLIP_HIDDEN_HISTORYMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_LANDSLIP_HIDDEN_HISTORY");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            Property(x => x.ALTTOP).HasColumnName("ALTTOP").IsOptional().HasPrecision(10, 2);
            Property(x => x.ALTBOTOM).HasColumnName("ALTBOTOM").IsOptional().HasPrecision(10, 2);
            Property(x => x.AVERAGEYEARRAINFALL).HasColumnName("AVERAGEYEARRAINFALL").IsOptional().HasPrecision(8, 2);
            Property(x => x.MAXDAYRAINFALL).HasColumnName("MAXDAYRAINFALL").IsOptional().HasPrecision(8, 2);
            Property(x => x.MAXHOURRAINFALL).HasColumnName("MAXHOURRAINFALL").IsOptional().HasPrecision(8, 2);
            Property(x => x.MAXWATERLEVEL).HasColumnName("MAXWATERLEVEL").IsOptional().HasPrecision(8, 2);
            Property(x => x.MINWATERLEVEL).HasColumnName("MINWATERLEVEL").IsOptional().HasPrecision(8, 2);
            Property(x => x.ORIGINALSLOPEHEIGHT).HasColumnName("ORIGINALSLOPEHEIGHT").IsOptional().HasPrecision(8, 2);
            Property(x => x.LANDSLIPLENGTH).HasColumnName("LANDSLIPLENGTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.LANDSLIPWIDTH).HasColumnName("LANDSLIPWIDTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.LANDSLIPDEPTH).HasColumnName("LANDSLIPDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.LANDSLIPSIZE).HasColumnName("LANDSLIPSIZE").IsOptional().HasPrecision(16, 2);
            Property(x => x.LANDSLIPVOLUME).HasColumnName("LANDSLIPVOLUME").IsOptional().HasPrecision(16, 2);
            Property(x => x.GROUNDWATERDEPTH).HasColumnName("GROUNDWATERDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.HOUSEMONEY).HasColumnName("HOUSEMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.THREATENASSETS).HasColumnName("THREATENASSETS").IsOptional().HasPrecision(12, 2);
            Property(x => x.LOADMONEY).HasColumnName("LOADMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.WATERMONEY).HasColumnName("WATERMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.OTHERMONEY).HasColumnName("OTHERMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.PEOPLEPRECENT).HasColumnName("PEOPLEPRECENT").IsOptional().HasPrecision(10, 2);
            Property(x => x.PEOPLEMONEY).HasColumnName("PEOPLEMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.TOOLSPRECENT).HasColumnName("TOOLSPRECENT").IsOptional().HasPrecision(10, 2);
            Property(x => x.TOOLSMONEY).HasColumnName("TOOLSMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.ANIMALPRECENT).HasColumnName("ANIMALPRECENT").IsOptional().HasPrecision(10, 2);
            Property(x => x.ANIMALMONEY).HasColumnName("ANIMALMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.CHANGEOTHERPRECENT).HasColumnName("CHANGEOTHERPRECENT").IsOptional().HasPrecision(10, 2);
            Property(x => x.CHANGEOTHERMONEY).HasColumnName("CHANGEOTHERMONEY").IsOptional().HasPrecision(10, 2);
            #endregion
        }
    }
}