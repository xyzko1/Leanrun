using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-26 16:30
    /// �� �������ľ��þ���סլ��Ϣ��
    /// </summary>
    public class TBL_RWJJ_RESIDENTIALAREAMap : EntityTypeConfiguration<TBL_RWJJ_RESIDENTIALAREAEntity>
    {
        public TBL_RWJJ_RESIDENTIALAREAMap()
        {
            #region ������
            //��
            this.ToTable("TBL_RWJJ_RESIDENTIALAREA");
            //����
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion

            #region ���ù�ϵ
            Property(x => x.AVERAGEINCOME).HasColumnName("AVERAGEINCOME").IsOptional().HasPrecision(20,2);
            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            #endregion
        }
    }
}
