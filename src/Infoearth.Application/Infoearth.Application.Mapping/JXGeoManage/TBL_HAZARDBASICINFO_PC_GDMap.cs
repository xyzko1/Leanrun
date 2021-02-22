using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-07 16:09
    /// �� �����Ų����ݱ�
    /// </summary>
    public class TBL_HAZARDBASICINFO_PC_GDMap : EntityTypeConfiguration<TBL_HAZARDBASICINFO_PC_GDEntity>
    {
        public TBL_HAZARDBASICINFO_PC_GDMap()
        {
            #region ������
            //��
            this.ToTable("TBL_HAZARDBASICINFO_PC_GD");
            //����
            this.HasKey(t => t.PCUNIFIEDCODE);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            #region ���ù�ϵ
            #endregion
        }
    }
}
