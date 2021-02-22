using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 11:39
    /// �� �������ѷ�������ʷ��
    /// </summary>
    public class TBL_LANDCRACK_HISTORYMap : EntityTypeConfiguration<TBL_LANDCRACK_HISTORYEntity>
    {
        public TBL_LANDCRACK_HISTORYMap()
        {
            #region ������
            //��
            this.ToTable("TBL_LANDCRACK_HISTORY");
            //����
            this.HasKey(t => t.GUID);
            #endregion

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
            Property(x => x.ACTFAULTDIRE).HasColumnName("ACTFAULTDIRE").IsOptional().HasPrecision(8,2);
            Property(x => x.ACTFAULTANGLE).HasColumnName("ACTFAULTANGLE").IsOptional().HasPrecision(8,2);
            Property(x => x.ACTFAULTLENGTH).HasColumnName("ACTFAULTLENGTH").IsOptional().HasPrecision(8,2);
            Property(x => x.WATROLEEXCADEPTH).HasColumnName("WATROLEEXCADEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.DIRECTLOSSES).HasColumnName("DIRECTLOSSES").IsOptional().HasPrecision(8,2);
            Property(x => x.THREATENASSETS).HasColumnName("THREATENASSETS").IsOptional().HasPrecision(8,2);
            Property(x => x.ARROUNDCIRCLEPOSITIONLONGITUDE).HasColumnName("ARROUNDCIRCLEPOSITIONLONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.ARROUNDCIRCLEPOSITIONLATITUDE).HasColumnName("ARROUNDCIRCLEPOSITIONLATITUDE").IsOptional().HasPrecision(12,8);
            #region ���ù�ϵ
            #endregion
        }
    }
}
