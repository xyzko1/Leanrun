using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-14 14:58
    /// �� �����ֺ��������
    /// </summary>
    public class TBL_HAZARDBASICINFOMap : EntityTypeConfiguration<TBL_HAZARDBASICINFOEntity>
    {
        public TBL_HAZARDBASICINFOMap()
        {
            #region ������
            //��
            this.ToTable("TBL_HAZARDBASICINFO");
            //����
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
            #region ���ù�ϵ
            #endregion
        }
    }
}
