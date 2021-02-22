using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-05 11:54
    /// 描 述：崩塌调查表历史表
    /// </summary>
    public class TBL_AVALANCHE_HIDDEN_HISTORYMap : EntityTypeConfiguration<TBL_AVALANCHE_HIDDEN_HISTORYEntity>
    {
        public TBL_AVALANCHE_HIDDEN_HISTORYMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_AVALANCHE_HIDDEN_HISTORY");
            //主键
            this.HasKey(t => t.GUID);
            #endregion
 
            #region 配置关系
            Property(x => x.ALTTOP).HasColumnName("ALTTOP").IsOptional().HasPrecision(10,2);
            Property(x => x.ALTBOTOM).HasColumnName("ALTBOTOM").IsOptional().HasPrecision(10,2);
            Property(x => x.STRATUMDIRECTION).HasColumnName("STRATUMDIRECTION").IsOptional().HasPrecision(8,2);
            Property(x => x.STRATUMANGLE).HasColumnName("STRATUMANGLE").IsOptional().HasPrecision(8,2);
            Property(x => x.AVERAGEYEARRAINFALL).HasColumnName("AVERAGEYEARRAINFALL").IsOptional().HasPrecision(8,2);
            Property(x => x.MAXDAYRAINFALL).HasColumnName("MAXDAYRAINFALL").IsOptional().HasPrecision(8,2);
            Property(x => x.MAXHOURRAINFALL).HasColumnName("MAXHOURRAINFALL").IsOptional().HasPrecision(8,2);
            Property(x => x.MAXWATERLEVEL).HasColumnName("MAXWATERLEVEL").IsOptional().HasPrecision(8,2);
            Property(x => x.MINWATERLEVEL).HasColumnName("MINWATERLEVEL").IsOptional().HasPrecision(8,2);
            Property(x => x.SLOPEHEIGHT).HasColumnName("SLOPEHEIGHT").IsOptional().HasPrecision(8,2);
            Property(x => x.SLOPELENGTH).HasColumnName("SLOPELENGTH").IsOptional().HasPrecision(8,2);
            Property(x => x.SLOPEWIDTH).HasColumnName("SLOPEWIDTH").IsOptional().HasPrecision(8,2);
            Property(x => x.SCALE).HasColumnName("SCALE").IsOptional().HasPrecision(16,2);
            Property(x => x.ROCKDEPTH).HasColumnName("ROCKDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.ROCKLENGTH).HasColumnName("ROCKLENGTH").IsOptional().HasPrecision(8,2);
            Property(x => x.ROCKWIDTH).HasColumnName("ROCKWIDTH").IsOptional().HasPrecision(8,2);
            Property(x => x.ROCKHEIGHT).HasColumnName("ROCKHEIGHT").IsOptional().HasPrecision(8,2);
            Property(x => x.CTRLSURFLENGTH1).HasColumnName("CTRLSURFLENGTH1").IsOptional().HasPrecision(8,2);
            Property(x => x.CTRLSURFSPACE1).HasColumnName("CTRLSURFSPACE1").IsOptional().HasPrecision(8,2);
            Property(x => x.COCTRLSURFLENGTH2).HasColumnName("COCTRLSURFLENGTH2").IsOptional().HasPrecision(8,2);
            Property(x => x.CTRLSURFSPACE2).HasColumnName("CTRLSURFSPACE2").IsOptional().HasPrecision(8,2);
            Property(x => x.CTRLSURFLENGTH3).HasColumnName("CTRLSURFLENGTH3").IsOptional().HasPrecision(8,2);
            Property(x => x.CTRLSURFSPACE3).HasColumnName("CTRLSURFSPACE3").IsOptional().HasPrecision(8,2);
            Property(x => x.WEATHEREDZONEDEPTH).HasColumnName("WEATHEREDZONEDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.UNLOADCRACKDEPTH).HasColumnName("UNLOADCRACKDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.BEDROCKANGLE).HasColumnName("BEDROCKANGLE").IsOptional().HasPrecision(8,2);
            Property(x => x.BEDROCKDIRECTION).HasColumnName("BEDROCKDIRECTION").IsOptional().HasPrecision(8,2);
            Property(x => x.BEDROCKDEPTH).HasColumnName("BEDROCKDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.GROUNDWATERDEPTH).HasColumnName("GROUNDWATERDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.ACCUMULATIONBODYLENGTH).HasColumnName("ACCUMULATIONBODYLENGTH").IsOptional().HasPrecision(8,2);
            Property(x => x.ACCUMULATIONBODYWIDTH).HasColumnName("ACCUMULATIONBODYWIDTH").IsOptional().HasPrecision(8,2);
            Property(x => x.ACCUMULATIONBODYDEPTH).HasColumnName("ACCUMULATIONBODYDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.ACCUMULATIONBODYVOLUME).HasColumnName("ACCUMULATIONBODYVOLUME").IsOptional().HasPrecision(12,2);
            Property(x => x.DESTROYEDROAD).HasColumnName("DESTROYEDROAD").IsOptional().HasPrecision(8,2);
            Property(x => x.DESTROYEDCHANNEL).HasColumnName("DESTROYEDCHANNEL").IsOptional().HasPrecision(8,2);
            Property(x => x.DIRECTLOSS).HasColumnName("DIRECTLOSS").IsOptional().HasPrecision(10,2);
            Property(x => x.THREATENASSETS).HasColumnName("THREATENASSETS").IsOptional().HasPrecision(8,2);
            Property(x => x.DISTRIBUTEALTITUDE).HasColumnName("DISTRIBUTEALTITUDE").IsOptional().HasPrecision(8,2);
            Property(x => x.DEPTH).HasColumnName("DEPTH").IsOptional().HasPrecision(10,2);
            Property(x => x.OCCURREDVOLUME1).HasColumnName("OCCURREDVOLUME1").IsOptional().HasPrecision(10,2);
            Property(x => x.DIRECTLOSS1).HasColumnName("DIRECTLOSS1").IsOptional().HasPrecision(10,2);
            Property(x => x.OCCURREDVOLUME2).HasColumnName("OCCURREDVOLUME2").IsOptional().HasPrecision(10,2);
            Property(x => x.DIRECTLOSS2).HasColumnName("DIRECTLOSS2").IsOptional().HasPrecision(10,2);
            Property(x => x.OCCURREDVOLUME3).HasColumnName("OCCURREDVOLUME3").IsOptional().HasPrecision(10,2);
            Property(x => x.DIRECTLOSS3).HasColumnName("DIRECTLOSS3").IsOptional().HasPrecision(10,2);
            Property(x => x.INDIRECTLOSS).HasColumnName("INDIRECTLOSS").IsOptional().HasPrecision(10,2);
            Property(x => x.CTRLSURFLENGTH2).HasColumnName("CTRLSURFLENGTH2").IsOptional().HasPrecision(38,2);
            Property(x => x.AVALANCETIMES).HasColumnName("AVALANCETIMES").IsOptional().HasPrecision(8,2);
            Property(x => x.CHANGENUMBER).HasColumnName("CHANGENUMBER").IsOptional().HasPrecision(8,2);
            Property(x => x.CHANGELEVEL).HasColumnName("CHANGELEVEL").IsOptional().HasPrecision(8,2);
            Property(x => x.MAXAVALANCHEDISTANCE).HasColumnName("MAXAVALANCHEDISTANCE").IsOptional().HasPrecision(8,2);
            Property(x => x.MAXCHANGEDISTANCE).HasColumnName("MAXCHANGEDISTANCE").IsOptional().HasPrecision(8,2);
            Property(x => x.HOUSEMONEY).HasColumnName("HOUSEMONEY").IsOptional().HasPrecision(10,2);
            Property(x => x.LOADMONEY).HasColumnName("LOADMONEY").IsOptional().HasPrecision(10,2);
            Property(x => x.WATERMONEY).HasColumnName("WATERMONEY").IsOptional().HasPrecision(10,2);
            Property(x => x.OTHERMONEY).HasColumnName("OTHERMONEY").IsOptional().HasPrecision(10,2);
            Property(x => x.PEOPLEPRECENT).HasColumnName("PEOPLEPRECENT").IsOptional().HasPrecision(10,2);
            Property(x => x.PEOPLEMONEY).HasColumnName("PEOPLEMONEY").IsOptional().HasPrecision(10,2);
            Property(x => x.TOOLSPRECENT).HasColumnName("TOOLSPRECENT").IsOptional().HasPrecision(10,2);
            Property(x => x.TOOLSMONEY).HasColumnName("TOOLSMONEY").IsOptional().HasPrecision(10,2);
            Property(x => x.ANIMALPRECENT).HasColumnName("ANIMALPRECENT").IsOptional().HasPrecision(10,2);
            Property(x => x.ANIMALMONEY).HasColumnName("ANIMALMONEY").IsOptional().HasPrecision(10,2);
            Property(x => x.CHANGEOTHERPRECENT).HasColumnName("CHANGEOTHERPRECENT").IsOptional().HasPrecision(10,2);
            Property(x => x.CHANGEOTHERMONEY).HasColumnName("CHANGEOTHERMONEY").IsOptional().HasPrecision(10,2);
            #endregion
        }
    }
}