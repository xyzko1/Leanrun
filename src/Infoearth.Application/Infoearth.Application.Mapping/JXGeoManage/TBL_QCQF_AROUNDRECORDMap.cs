using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-13 16:22
    /// �� ����Ѳ���¼��
    /// </summary>
    public class TBL_QCQF_AROUNDRECORDMap : EntityTypeConfiguration<TBL_QCQF_AROUNDRECORDEntity>
    {
        public TBL_QCQF_AROUNDRECORDMap()
        {
            #region ������
            //��
            this.ToTable("TBL_QCQF_AROUNDRECORD");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.UPLOADLONGITUDE).HasColumnName("UPLOADLONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.UPLOADLATITUDE).HasColumnName("UPLOADLATITUDE").IsOptional().HasPrecision(12,8);
            #region ���ù�ϵ
            #endregion
        }
    }
}
