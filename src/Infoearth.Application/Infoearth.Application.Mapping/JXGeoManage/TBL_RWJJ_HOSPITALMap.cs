using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-26 16:28
    /// �� �������ľ���ҽԺ��Ϣ��
    /// </summary>
    public class TBL_RWJJ_HOSPITALMap : EntityTypeConfiguration<TBL_RWJJ_HOSPITALEntity>
    {
        public TBL_RWJJ_HOSPITALMap()
        {
            #region ������
            //��
            this.ToTable("TBL_RWJJ_HOSPITAL");
            //����
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion

            #region ���ù�ϵ
            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            #endregion
        }
    }
}
