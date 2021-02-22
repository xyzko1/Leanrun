using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-13 14:15
    /// 描 述：泥石流调查表
    /// </summary>
    public class TBL_DEBRISFLOWMap : EntityTypeConfiguration<TBL_DEBRISFLOWEntity>
    {
        public TBL_DEBRISFLOWMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_DEBRISFLOW");
            //主键
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion

            #region 配置关系
            Property(x => x.X).HasColumnName("X").IsOptional().HasPrecision(10, 2);
            Property(x => x.Y).HasColumnName("Y").IsOptional().HasPrecision(10, 2);
            Property(x => x.Z).HasColumnName("Z").IsOptional().HasPrecision(10, 2);
            Property(x => x.ALTTOP).HasColumnName("ALTTOP").IsOptional().HasPrecision(10, 2);
            Property(x => x.ALTBOTOM).HasColumnName("ALTBOTOM").IsOptional().HasPrecision(10, 2);
            Property(x => x.MIZDISTOMRIVER).HasColumnName("MIZDISTOMRIVER").IsOptional().HasPrecision(9, 2);
            Property(x => x.YEARMAXIMUMRAINFALL).HasColumnName("YEARMAXIMUMRAINFALL").IsOptional().HasPrecision(10, 2);
            Property(x => x.YEARAVERAGERAINFALL).HasColumnName("YEARAVERAGERAINFALL").IsOptional().HasPrecision(10, 2);
            Property(x => x.DAYMAXIMUMRAINFALL).HasColumnName("DAYMAXIMUMRAINFALL").IsOptional().HasPrecision(10, 2);
            Property(x => x.DAYAVERAGERAINFALL).HasColumnName("DAYAVERAGERAINFALL").IsOptional().HasPrecision(10, 2);
            Property(x => x.HOURMAXIMUMRAINFALL).HasColumnName("HOURMAXIMUMRAINFALL").IsOptional().HasPrecision(10, 2);
            Property(x => x.HOURAVERAGERAINFALL).HasColumnName("HOURAVERAGERAINFALL").IsOptional().HasPrecision(10, 2);
            Property(x => x.MINUTES10MAXIMUMRAINFALL).HasColumnName("MINUTES10MAXIMUMRAINFALL").IsOptional().HasPrecision(10, 2);
            Property(x => x.MINUTES10AVERAGERAINFALL).HasColumnName("MINUTES10AVERAGERAINFALL").IsOptional().HasPrecision(10, 2);
            Property(x => x.MIZSECTORLANDAMPLITUDE).HasColumnName("MIZSECTORLANDAMPLITUDE").IsOptional().HasPrecision(7, 3);
            Property(x => x.MIZSECTORLANDFANLONG).HasColumnName("MIZSECTORLANDFANLONG").IsOptional().HasPrecision(8, 2);
            Property(x => x.MIZSECTORLANDFANKUAN).HasColumnName("MIZSECTORLANDFANKUAN").IsOptional().HasPrecision(8, 2);
            Property(x => x.MIZSECTORLANDSPREADANGLE).HasColumnName("MIZSECTORLANDSPREADANGLE").IsOptional().HasPrecision(7, 2);
            Property(x => x.FOREST).HasColumnName("FOREST").IsOptional().HasPrecision(5, 2);
            Property(x => x.SHRUB).HasColumnName("SHRUB").IsOptional().HasPrecision(5, 2);
            Property(x => x.LAWN).HasColumnName("LAWN").IsOptional().HasPrecision(5, 2);
            Property(x => x.GENTSLOPEARALAND).HasColumnName("GENTSLOPEARALAND").IsOptional().HasPrecision(5, 2);
            Property(x => x.WASTELAND).HasColumnName("WASTELAND").IsOptional().HasPrecision(5, 2);
            Property(x => x.STEEPLAND).HasColumnName("STEEPLAND").IsOptional().HasPrecision(5, 2);
            Property(x => x.BUILDINGLAND).HasColumnName("BUILDINGLAND").IsOptional().HasPrecision(5, 2);
            Property(x => x.OTHERSITES).HasColumnName("OTHERSITES").IsOptional().HasPrecision(5, 2);
            Property(x => x.THREATENASSETS).HasColumnName("THREATENASSETS").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYCOMPDESFARMLAND1).HasColumnName("DISHISTORYCOMPDESFARMLAND1").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYSDESFARMLAND1).HasColumnName("DISHISTORYSDESFARMLAND1").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYDESROAD1).HasColumnName("DISHISTORYDESROAD1").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYDIRECTLOSS1).HasColumnName("DISHISTORYDIRECTLOSS1").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYCOMPDESFARMLAND2).HasColumnName("DISHISTORYCOMPDESFARMLAND2").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYSDESFARMLAND2).HasColumnName("DISHISTORYSDESFARMLAND2").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYDESROAD2).HasColumnName("DISHISTORYDESROAD2").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYDIRECTLOSS2).HasColumnName("DISHISTORYDIRECTLOSS2").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYCOMPDESFARMLAND3).HasColumnName("DISHISTORYCOMPDESFARMLAND3").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYSDESFARMLAND3).HasColumnName("DISHISTORYSDESFARMLAND3").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYDESROAD3).HasColumnName("DISHISTORYDESROAD3").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYDIRECTLOSS3).HasColumnName("DISHISTORYDIRECTLOSS3").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYCOMPDESFARMLAND4).HasColumnName("DISHISTORYCOMPDESFARMLAND4").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYSDESFARMLAND4).HasColumnName("DISHISTORYSDESFARMLAND4").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYDESROAD4).HasColumnName("DISHISTORYDESROAD4").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYDIRECTLOSS4).HasColumnName("DISHISTORYDIRECTLOSS4").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYCOMPDESFARMLAND5).HasColumnName("DISHISTORYCOMPDESFARMLAND5").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYSDESFARMLAND5).HasColumnName("DISHISTORYSDESFARMLAND5").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYDESROAD5).HasColumnName("DISHISTORYDESROAD5").IsOptional().HasPrecision(10, 2);
            Property(x => x.DISHISTORYDIRECTLOSS5).HasColumnName("DISHISTORYDIRECTLOSS5").IsOptional().HasPrecision(10, 2);
            Property(x => x.DEBRISFLOWOUTSQUCAP).HasColumnName("DEBRISFLOWOUTSQUCAP").IsOptional().HasPrecision(9, 2);
            Property(x => x.DEBRISFLOWMUDPOSITION).HasColumnName("DEBRISFLOWMUDPOSITION").IsOptional().HasPrecision(7, 2);
            Property(x => x.SCORE1).HasColumnName("SCORE1").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE2).HasColumnName("SCORE2").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE3).HasColumnName("SCORE3").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE4).HasColumnName("SCORE4").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE5).HasColumnName("SCORE5").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE6).HasColumnName("SCORE6").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE7).HasColumnName("SCORE7").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE8).HasColumnName("SCORE8").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE9).HasColumnName("SCORE9").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE10).HasColumnName("SCORE10").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE11).HasColumnName("SCORE11").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE12).HasColumnName("SCORE12").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE13).HasColumnName("SCORE13").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE14).HasColumnName("SCORE14").IsOptional().HasPrecision(6, 5);
            Property(x => x.SCORE15).HasColumnName("SCORE15").IsOptional().HasPrecision(6, 5);
            Property(x => x.DIRECTECONOMICLOSSES).HasColumnName("DIRECTECONOMICLOSSES").IsOptional().HasPrecision(10, 2);
            Property(x => x.DEBRISFLOWCAPACITY).HasColumnName("DEBRISFLOWCAPACITY").IsOptional().HasPrecision(7, 2);
            Property(x => x.DEBRISFLOWDISCHARGE).HasColumnName("DEBRISFLOWDISCHARGE").IsOptional().HasPrecision(7, 2);
            #endregion
        }
    }
}
