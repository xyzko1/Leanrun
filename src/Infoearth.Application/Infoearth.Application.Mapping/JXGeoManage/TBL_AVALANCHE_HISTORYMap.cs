using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 11:17
    /// 描 述：崩塌调查表历史表
    /// </summary>
    public class TBL_AVALANCHE_HISTORYMap : EntityTypeConfiguration<TBL_AVALANCHE_HISTORYEntity>
    {
        public TBL_AVALANCHE_HISTORYMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_AVALANCHE_HISTORY");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.X).HasColumnName("X").IsOptional().HasPrecision(10,2);
            Property(x => x.Y).HasColumnName("Y").IsOptional().HasPrecision(10,2);
            Property(x => x.Z).HasColumnName("Z").IsOptional().HasPrecision(10,2);
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
            Property(x => x.FRACTUREGROUPNUM).HasColumnName("FRACTUREGROUPNUM").IsOptional().HasPrecision(8,2);
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
            #region 配置关系
            #endregion
        }
    }
}
