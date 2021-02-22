using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-05-25 16:29
    /// �� �������ι滮�ɹ���
    /// </summary>
    public class TBL_ACHIEVEMENT_PREPLANMap : EntityTypeConfiguration<TBL_ACHIEVEMENT_PREPLANEntity>
    {
        public TBL_ACHIEVEMENT_PREPLANMap()
        {
            #region ������
            //��
            this.ToTable("TBL_ACHIEVEMENT_PREPLAN");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            #endregion
        }
    }
}
