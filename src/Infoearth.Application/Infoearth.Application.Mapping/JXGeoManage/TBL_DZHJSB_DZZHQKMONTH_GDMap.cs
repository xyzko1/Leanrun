using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-15 15:38
    /// �� ����Ѳ�������������
    /// </summary>
    public class TBL_DZHJSB_DZZHQKMONTH_GDMap : EntityTypeConfiguration<TBL_DZHJSB_DZZHQKMONTH_GDEntity>
    {
        public TBL_DZHJSB_DZZHQKMONTH_GDMap()
        {
            #region ������
            //��
            this.ToTable("TBL_DZHJSB_DZZHQKMONTH_GD");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.ZHGM).HasColumnName("ZHGM").IsOptional().HasPrecision(15,8);
            Property(x => x.ZJJJSS).HasColumnName("ZJJJSS").IsOptional().HasPrecision(10,2);
            #region ���ù�ϵ
            #endregion
        }
    }
}
