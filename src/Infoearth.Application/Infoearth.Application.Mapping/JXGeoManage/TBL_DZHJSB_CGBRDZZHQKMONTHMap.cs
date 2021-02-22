using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-10 09:57
    /// �� ����TBL_DZHJSB_CGBRDZZHQKMONTH
    /// </summary>
    public class TBL_DZHJSB_CGBRDZZHQKMONTHMap : EntityTypeConfiguration<TBL_DZHJSB_CGBRDZZHQKMONTHEntity>
    {
        public TBL_DZHJSB_CGBRDZZHQKMONTHMap()
        {
            #region ������
            //��
            this.ToTable("TBL_DZHJSB_CGBRDZZHQKMONTH");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.BMJJSS).HasColumnName("BMJJSS").IsOptional().HasPrecision(10,2);
            #region ���ù�ϵ
            #endregion
        }
    }
}
