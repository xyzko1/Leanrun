using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-05-09 14:53
    /// �� ������������Ϣ��
    /// </summary>
    public class TBL_ZLGC_BASEINFOMap : EntityTypeConfiguration<TBL_ZLGC_BASEINFOEntity>
    {
        public TBL_ZLGC_BASEINFOMap()
        {
            #region ������
            //��
            this.ToTable("TBL_ZLGC_BASEINFO");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12, 8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12, 8);
            Property(x => x.BUDGET).HasColumnName("BUDGET").IsOptional().HasPrecision(10, 2);
            Property(x => x.ISSUEDCAPITAL).HasColumnName("ISSUEDCAPITAL").IsOptional().HasPrecision(10, 2);
            Property(x => x.CENTRALFUNDS).HasColumnName("CENTRALFUNDS").IsOptional().HasPrecision(10, 2);
            Property(x => x.FINALMONEY).HasColumnName("FINALMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.XMPFZJ).HasColumnName("XMPFZJ").IsOptional().HasPrecision(15, 2);
            #region ���ù�ϵ
            #endregion
        }
    }
}