using Infoearth.Application.Entity.MONITORPOINT;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.MONITORPOINT
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-22 18:23
    /// �� �����������������Ϣ��
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTMap : EntityTypeConfiguration<TBL_DMCJ_MONITORPOINTEntity>
    {
        public TBL_DMCJ_MONITORPOINTMap()
        {
            #region ������
            //��
            this.ToTable("TBL_DMCJ_MONITORPOINT");
            //����
            this.HasKey(t => t.MONITORPOINTID);
            #endregion

            #region ���ù�ϵ
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            #endregion
        }
    }
}
