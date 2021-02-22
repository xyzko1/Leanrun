using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-26 16:29
    /// �� �������ľ���ѧУ��Ϣ��
    /// </summary>
    public class TBL_RWJJ_SCHOOLMap : EntityTypeConfiguration<TBL_RWJJ_SCHOOLEntity>
    {
        public TBL_RWJJ_SCHOOLMap()
        {
            #region ������
            //��
            this.ToTable("TBL_RWJJ_SCHOOL");
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
