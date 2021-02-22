using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-15 11:31
    /// �� ����Ӧ���������ݹ���
    /// </summary>
    public class TBL_YJDC_YJDCMANAGEMENTMap : EntityTypeConfiguration<TBL_YJDC_YJDCMANAGEMENTEntity>
    {
        public TBL_YJDC_YJDCMANAGEMENTMap()
        {
            #region ������
            //��
            this.ToTable("TBL_YJDC_YJDCMANAGEMENT");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.SLOPEAREA).HasColumnName("SLOPEAREA").IsOptional().HasPrecision(12,8);
            Property(x => x.SLOPEVOLUME).HasColumnName("SLOPEVOLUME").IsOptional().HasPrecision(12,8);
            #region ���ù�ϵ
            #endregion
        }
    }
}
