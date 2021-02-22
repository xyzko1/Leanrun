using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:25
    /// �� ������Ǩ������Ϣ��
    /// </summary>
    public class TBL_BQBRMap : EntityTypeConfiguration<TBL_BQBREntity>
    {
        public TBL_BQBRMap()
        {
            #region ������
            //��
            this.ToTable("TBL_BQBR");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.JFMJ).HasColumnName("JFMJ").IsOptional().HasPrecision(12, 8);
            Property(x => x.JFJD).HasColumnName("JFJD").IsOptional().HasPrecision(12, 8);
            Property(x => x.JFWD).HasColumnName("JFWD").IsOptional().HasPrecision(12, 8);
            Property(x => x.XFMJ).HasColumnName("XFMJ").IsOptional().HasPrecision(12, 8);
            Property(x => x.XFJD).HasColumnName("XFJD").IsOptional().HasPrecision(12, 8);
            Property(x => x.XFWD).HasColumnName("XFWD").IsOptional().HasPrecision(12, 8);
            #region ���ù�ϵ
            #endregion
        }
    }
}
