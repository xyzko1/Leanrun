using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 11:37
    /// 描 述：地面塌陷调查表历史表
    /// </summary>
    public class TBL_COLLAPSE_HISTORYMap : EntityTypeConfiguration<TBL_COLLAPSE_HISTORYEntity>
    {
        public TBL_COLLAPSE_HISTORYMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_COLLAPSE_HISTORY");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.X).HasColumnName("X").IsOptional().HasPrecision(10,2);
            Property(x => x.Y).HasColumnName("Y").IsOptional().HasPrecision(10,2);
            Property(x => x.Z).HasColumnName("Z").IsOptional().HasPrecision(10,2);
            Property(x => x.MONOCOSCALE1).HasColumnName("MONOCOSCALE1").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCODEPTH1).HasColumnName("MONOCODEPTH1").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCOAREA1).HasColumnName("MONOCOAREA1").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCOWATLEVDEPTH1).HasColumnName("MONOCOWATLEVDEPTH1").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCOWATLEVCHANGE1).HasColumnName("MONOCOWATLEVCHANGE1").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCOSCALE2).HasColumnName("MONOCOSCALE2").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCODEPTH2).HasColumnName("MONOCODEPTH2").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCOAREA2).HasColumnName("MONOCOAREA2").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCOWATLEVDEPTH2).HasColumnName("MONOCOWATLEVDEPTH2").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCOWATLEVCHANGE2).HasColumnName("MONOCOWATLEVCHANGE2").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCOSCALE3).HasColumnName("MONOCOSCALE3").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCODEPTH3).HasColumnName("MONOCODEPTH3").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCOAREA3).HasColumnName("MONOCOAREA3").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCOWATLEVDEPTH3).HasColumnName("MONOCOWATLEVDEPTH3").IsOptional().HasPrecision(8,2);
            Property(x => x.MONOCOWATLEVCHANGE3).HasColumnName("MONOCOWATLEVCHANGE3").IsOptional().HasPrecision(8,2);
            Property(x => x.MINCOLLAPSECALIBER).HasColumnName("MINCOLLAPSECALIBER").IsOptional().HasPrecision(8,2);
            Property(x => x.MAXCOLLAPSECALIBER).HasColumnName("MAXCOLLAPSECALIBER").IsOptional().HasPrecision(8,2);
            Property(x => x.MINCOLLAPSEDEPTH).HasColumnName("MINCOLLAPSEDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.MAXCOLLAPSEDEPTH).HasColumnName("MAXCOLLAPSEDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.ONECRACKLENGTH1).HasColumnName("ONECRACKLENGTH1").IsOptional().HasPrecision(8,2);
            Property(x => x.ONECRACKWIDTH1).HasColumnName("ONECRACKWIDTH1").IsOptional().HasPrecision(8,2);
            Property(x => x.ONECRACKDEPTH1).HasColumnName("ONECRACKDEPTH1").IsOptional().HasPrecision(8,2);
            Property(x => x.ONECRACKLENGTH2).HasColumnName("ONECRACKLENGTH2").IsOptional().HasPrecision(8,2);
            Property(x => x.ONECRACKWIDTH2).HasColumnName("ONECRACKWIDTH2").IsOptional().HasPrecision(8,2);
            Property(x => x.ONECRACKDEPTH2).HasColumnName("ONECRACKDEPTH2").IsOptional().HasPrecision(8,2);
            Property(x => x.ONECRACKLENGTH3).HasColumnName("ONECRACKLENGTH3").IsOptional().HasPrecision(8,2);
            Property(x => x.ONECRACKWIDTH3).HasColumnName("ONECRACKWIDTH3").IsOptional().HasPrecision(8,2);
            Property(x => x.ONECRACKDEPTH3).HasColumnName("ONECRACKDEPTH3").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKDISTRAREA).HasColumnName("CRACKDISTRAREA").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKSPACE).HasColumnName("CRACKSPACE").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKLENGTHMAX).HasColumnName("CRACKLENGTHMAX").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKLENGTHMIN).HasColumnName("CRACKLENGTHMIN").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKWIDTHMAX).HasColumnName("CRACKWIDTHMAX").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKWIDTHMIN).HasColumnName("CRACKWIDTHMIN").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKDEPTHMAX).HasColumnName("CRACKDEPTHMAX").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKDEPTHMIN).HasColumnName("CRACKDEPTHMIN").IsOptional().HasPrecision(8,2);
            Property(x => x.KARSTCOROOFCAVEDEPTH).HasColumnName("KARSTCOROOFCAVEDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.KARSTCOGROUNDWATERDEPTH).HasColumnName("KARSTCOGROUNDWATERDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.HOLECOSINGLESOILTHICK).HasColumnName("HOLECOSINGLESOILTHICK").IsOptional().HasPrecision(8,2);
            Property(x => x.HOLECODOUBTOPSOILTHICK).HasColumnName("HOLECODOUBTOPSOILTHICK").IsOptional().HasPrecision(8,2);
            Property(x => x.HOLECODOUBLOWERSOILTHICK).HasColumnName("HOLECODOUBLOWERSOILTHICK").IsOptional().HasPrecision(8,2);
            Property(x => x.HOLECOGROUNDWATERDEPTH).HasColumnName("HOLECOGROUNDWATERDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.WELLPLACECOAREADIST).HasColumnName("WELLPLACECOAREADIST").IsOptional().HasPrecision(8,2);
            Property(x => x.WELLPLACECOAREAPUMPDEPTH).HasColumnName("WELLPLACECOAREAPUMPDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.WELLPLACECOAREADAYPUMPVOL).HasColumnName("WELLPLACECOAREADAYPUMPVOL").IsOptional().HasPrecision(8,2);
            Property(x => x.RIVERWATLEVCOAREADIST).HasColumnName("RIVERWATLEVCOAREADIST").IsOptional().HasPrecision(8,2);
            Property(x => x.RIVERWATLEVCOAREAAMP).HasColumnName("RIVERWATLEVCOAREAAMP").IsOptional().HasPrecision(8,2);
            Property(x => x.ROOFFALLCOSOILTHICK).HasColumnName("ROOFFALLCOSOILTHICK").IsOptional().HasPrecision(8,2);
            Property(x => x.ROOFFALLCOSTRATUMTHICK).HasColumnName("ROOFFALLCOSTRATUMTHICK").IsOptional().HasPrecision(8,2);
            Property(x => x.ROOFFALLCOGROUNDWATERDEPTH).HasColumnName("ROOFFALLCOGROUNDWATERDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.ROOFFALLCOSEAMTHICK).HasColumnName("ROOFFALLCOSEAMTHICK").IsOptional().HasPrecision(8,2);
            Property(x => x.ROOFFALLCOMINETHICK).HasColumnName("ROOFFALLCOMINETHICK").IsOptional().HasPrecision(8,2);
            Property(x => x.ROOFFALLCOMINEDEPTH).HasColumnName("ROOFFALLCOMINEDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.ROOFFALLCOWORKSURFFORWSPEED).HasColumnName("ROOFFALLCOWORKSURFFORWSPEED").IsOptional().HasPrecision(8,2);
            Property(x => x.ROOFFALLCOMINEVOL).HasColumnName("ROOFFALLCOMINEVOL").IsOptional().HasPrecision(8,2);
            Property(x => x.DESTROYEDFARM).HasColumnName("DESTROYEDFARM").IsOptional().HasPrecision(8,2);
            Property(x => x.DESTROYEDHOME).HasColumnName("DESTROYEDHOME").IsOptional().HasPrecision(8,2);
            Property(x => x.DIRETLOSSES).HasColumnName("DIRETLOSSES").IsOptional().HasPrecision(10,2);
            Property(x => x.EXPCOLLAPSEAREA).HasColumnName("EXPCOLLAPSEAREA").IsOptional().HasPrecision(8,2);
            Property(x => x.POTDESTROYEDFARM).HasColumnName("POTDESTROYEDFARM").IsOptional().HasPrecision(8,2);
            Property(x => x.NEWCOLLAPSEAREA).HasColumnName("NEWCOLLAPSEAREA").IsOptional().HasPrecision(8,2);
            Property(x => x.OPENCIRCUIT).HasColumnName("OPENCIRCUIT").IsOptional().HasPrecision(8,2);
            Property(x => x.THREATENASSETS).HasColumnName("THREATENASSETS").IsOptional().HasPrecision(8,2);
            Property(x => x.BLOCKINGRAILWAY).HasColumnName("BLOCKINGRAILWAY").IsOptional().HasPrecision(8,2);
            Property(x => x.BLOCKINGROAD).HasColumnName("BLOCKINGROAD").IsOptional().HasPrecision(8,2);
            Property(x => x.BLOCKINGCOMMUNICATION).HasColumnName("BLOCKINGCOMMUNICATION").IsOptional().HasPrecision(8,2);
            Property(x => x.WATERINCREASE).HasColumnName("WATERINCREASE").IsOptional().HasPrecision(8,2);
            Property(x => x.DISASTERLOSS).HasColumnName("DISASTERLOSS").IsOptional().HasPrecision(8,2);
            Property(x => x.FLOODEDWELLLOSS).HasColumnName("FLOODEDWELLLOSS").IsOptional().HasPrecision(8,2);
            Property(x => x.RIVERWATERREDUCE).HasColumnName("RIVERWATERREDUCE").IsOptional().HasPrecision(8,2);
            Property(x => x.INTERRUPTEDRIVERWATER).HasColumnName("INTERRUPTEDRIVERWATER").IsOptional().HasPrecision(8,2);
            Property(x => x.WELLWATERREDUCE).HasColumnName("WELLWATERREDUCE").IsOptional().HasPrecision(8,2);
            Property(x => x.WATERLEVELREDUCE).HasColumnName("WATERLEVELREDUCE").IsOptional().HasPrecision(8,2);
            #region 配置关系
            #endregion
        }
    }
}
