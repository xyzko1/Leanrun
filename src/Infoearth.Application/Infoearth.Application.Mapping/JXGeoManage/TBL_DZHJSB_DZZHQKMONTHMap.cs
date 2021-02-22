using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-10 09:58
    /// �� ����TBL_DZHJSB_DZZHQKMONTH
    /// </summary>
    public class TBL_DZHJSB_DZZHQKMONTHMap : EntityTypeConfiguration<TBL_DZHJSB_DZZHQKMONTHEntity>
    {
        public TBL_DZHJSB_DZZHQKMONTHMap()
        {
            #region ������
            //��
            this.ToTable("TBL_DZHJSB_DZZHQKMONTH");
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
