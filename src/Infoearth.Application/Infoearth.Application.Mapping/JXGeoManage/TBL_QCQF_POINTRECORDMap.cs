using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-13 16:23
    /// �� ����Ⱥ��Ⱥ�������ˮ���ݱ�
    /// </summary>
    public class TBL_QCQF_POINTRECORDMap : EntityTypeConfiguration<TBL_QCQF_POINTRECORDEntity>
    {
        public TBL_QCQF_POINTRECORDMap()
        {
            #region ������
            //��
            this.ToTable("TBL_QCQF_POINTRECORD");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.SLITWIDTH).HasColumnName("SLITWIDTH").IsOptional().HasPrecision(38,2);
            Property(x => x.TODRUMHEIGH).HasColumnName("TODRUMHEIGH").IsOptional().HasPrecision(38,2);
            Property(x => x.SPRINGAMOUNT).HasColumnName("SPRINGAMOUNT").IsOptional().HasPrecision(38,2);
            Property(x => x.WELLLEVEL).HasColumnName("WELLLEVEL").IsOptional().HasPrecision(38,2);
            Property(x => x.UPLOADLONGITUDE).HasColumnName("UPLOADLONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.UPLOADLATITUDE).HasColumnName("UPLOADLATITUDE").IsOptional().HasPrecision(12,8);
            #region ���ù�ϵ
            #endregion
        }
    }
}
