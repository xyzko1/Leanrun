using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-07 17:24
    /// �� ����Ⱥ��Ⱥ��������Ϣ��
    /// </summary>
    public class TBL_QCQF_LAYOUTPOINTINFOMap : EntityTypeConfiguration<TBL_QCQF_LAYOUTPOINTINFOEntity>
    {
        public TBL_QCQF_LAYOUTPOINTINFOMap()
        {
            #region ������
            //��
            this.ToTable("TBL_QCQF_LAYOUTPOINTINFO");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LON).HasColumnName("LON").IsOptional().HasPrecision(12,8);
            Property(x => x.LAT).HasColumnName("LAT").IsOptional().HasPrecision(12,8);
            #region ���ù�ϵ
            #endregion
        }
    }
}
