using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-13 14:53
    /// 描 述：地裂缝调查表
    /// </summary>
    public class TBL_LANDCRACKMap : EntityTypeConfiguration<TBL_LANDCRACKEntity>
    {
        public TBL_LANDCRACKMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_LANDCRACK");
            //主键
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion

            #region 配置关系
            Property(x => x.X).HasColumnName("X").IsOptional().HasPrecision(10,2);
            Property(x => x.Y).HasColumnName("Y").IsOptional().HasPrecision(10,2);
            Property(x => x.Z).HasColumnName("Z").IsOptional().HasPrecision(10,2);
            Property(x => x.ONECRACKNUM1).HasColumnName("ONECRACKNUM1").IsOptional().HasPrecision(8,2);
            Property(x => x.ONECRACKNUM2).HasColumnName("ONECRACKNUM2").IsOptional().HasPrecision(8,2);
            Property(x => x.ONECRACKNUM3).HasColumnName("ONECRACKNUM3").IsOptional().HasPrecision(8,2);
            Property(x => x.GROUPCRACKDISTRAREA).HasColumnName("GROUPCRACKDISTRAREA").IsOptional().HasPrecision(8,2);
            Property(x => x.GROUPCRACKDEVELOPSPA).HasColumnName("GROUPCRACKDEVELOPSPA").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKLENGTHMAX).HasColumnName("CRACKLENGTHMAX").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKLENGTHMIN).HasColumnName("CRACKLENGTHMIN").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKWIDTHMAX).HasColumnName("CRACKWIDTHMAX").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKWIDTHMIN).HasColumnName("CRACKWIDTHMIN").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKDEPTHMAX).HasColumnName("CRACKDEPTHMAX").IsOptional().HasPrecision(8,2);
            Property(x => x.CRACKDEPTHMIN).HasColumnName("CRACKDEPTHMIN").IsOptional().HasPrecision(8,2);
            Property(x => x.EXPCONTSOILMOICONT).HasColumnName("EXPCONTSOILMOICONT").IsOptional().HasPrecision(8,2);
            Property(x => x.CAVEDEPTH).HasColumnName("CAVEDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.CAVELENGTH).HasColumnName("CAVELENGTH").IsOptional().HasPrecision(8,2);
            Property(x => x.CAVEWIDTH).HasColumnName("CAVEWIDTH").IsOptional().HasPrecision(8,2);
            Property(x => x.CAVEHIGH).HasColumnName("CAVEHIGH").IsOptional().HasPrecision(8,2);
            Property(x => x.DRAWELLDEPTH).HasColumnName("DRAWELLDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.DRAWATLEVVOL).HasColumnName("DRAWATLEVVOL").IsOptional().HasPrecision(8,2);
            Property(x => x.DRADAYPUMPVOL).HasColumnName("DRADAYPUMPVOL").IsOptional().HasPrecision(8,2);
            Property(x => x.ACTFAULTDIRE).HasColumnName("ACTFAULTDIRE").IsOptional();
            Property(x => x.ACTFAULTANGLE).HasColumnName("ACTFAULTANGLE").IsOptional();
            Property(x => x.ACTFAULTLENGTH).HasColumnName("ACTFAULTLENGTH").IsOptional().HasPrecision(8,2);
            Property(x => x.WATROLEEXCADEPTH).HasColumnName("WATROLEEXCADEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.DIRECTLOSSES).HasColumnName("DIRECTLOSSES").IsOptional().HasPrecision(8,2);
            Property(x => x.THREATENASSETS).HasColumnName("THREATENASSETS").IsOptional().HasPrecision(8,2);
            Property(x => x.ARROUNDCIRCLEPOSITIONLONGITUDE).HasColumnName("ARROUNDCIRCLEPOSITIONLONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.ARROUNDCIRCLEPOSITIONLATITUDE).HasColumnName("ARROUNDCIRCLEPOSITIONLATITUDE").IsOptional().HasPrecision(12,8);
            #endregion
        }
    }
}
