using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:15
    /// �� ����Ⱥ��Ⱥ������������ϵ
    /// </summary>
    public class TBL_QCQF_ADMINISTRATIVEMap : EntityTypeConfiguration<TBL_QCQF_ADMINISTRATIVEEntity>
    {
        public TBL_QCQF_ADMINISTRATIVEMap()
        {
            #region ������
            //��
            this.ToTable("TBL_QCQF_ADMINISTRATIVE");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            #region ���ù�ϵ
            #endregion
        }
    }
}
