using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-03-05 09:47
    /// �� �������������������ʷ��
    /// </summary>
    public class TBL_LANDSLIP_HIDDEN_HISTORYMap : EntityTypeConfiguration<TBL_LANDSLIP_HIDDEN_HISTORYEntity>
    {
        public TBL_LANDSLIP_HIDDEN_HISTORYMap()
        {
            #region ������
            //��
            this.ToTable("TBL_LANDSLIP_HIDDEN_HISTORY");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            Property(x => x.ALTTOP).HasColumnName("ALTTOP").IsOptional().HasPrecision(10, 2);
            Property(x => x.ALTBOTOM).HasColumnName("ALTBOTOM").IsOptional().HasPrecision(10, 2);
            Property(x => x.AVERAGEYEARRAINFALL).HasColumnName("AVERAGEYEARRAINFALL").IsOptional().HasPrecision(8, 2);
            Property(x => x.MAXDAYRAINFALL).HasColumnName("MAXDAYRAINFALL").IsOptional().HasPrecision(8, 2);
            Property(x => x.MAXHOURRAINFALL).HasColumnName("MAXHOURRAINFALL").IsOptional().HasPrecision(8, 2);
            Property(x => x.MAXWATERLEVEL).HasColumnName("MAXWATERLEVEL").IsOptional().HasPrecision(8, 2);
            Property(x => x.MINWATERLEVEL).HasColumnName("MINWATERLEVEL").IsOptional().HasPrecision(8, 2);
            Property(x => x.ORIGINALSLOPEHEIGHT).HasColumnName("ORIGINALSLOPEHEIGHT").IsOptional().HasPrecision(8, 2);
            Property(x => x.LANDSLIPLENGTH).HasColumnName("LANDSLIPLENGTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.LANDSLIPWIDTH).HasColumnName("LANDSLIPWIDTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.LANDSLIPDEPTH).HasColumnName("LANDSLIPDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.LANDSLIPSIZE).HasColumnName("LANDSLIPSIZE").IsOptional().HasPrecision(16, 2);
            Property(x => x.LANDSLIPVOLUME).HasColumnName("LANDSLIPVOLUME").IsOptional().HasPrecision(16, 2);
            Property(x => x.GROUNDWATERDEPTH).HasColumnName("GROUNDWATERDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.HOUSEMONEY).HasColumnName("HOUSEMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.THREATENASSETS).HasColumnName("THREATENASSETS").IsOptional().HasPrecision(12, 2);
            Property(x => x.LOADMONEY).HasColumnName("LOADMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.WATERMONEY).HasColumnName("WATERMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.OTHERMONEY).HasColumnName("OTHERMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.PEOPLEPRECENT).HasColumnName("PEOPLEPRECENT").IsOptional().HasPrecision(10, 2);
            Property(x => x.PEOPLEMONEY).HasColumnName("PEOPLEMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.TOOLSPRECENT).HasColumnName("TOOLSPRECENT").IsOptional().HasPrecision(10, 2);
            Property(x => x.TOOLSMONEY).HasColumnName("TOOLSMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.ANIMALPRECENT).HasColumnName("ANIMALPRECENT").IsOptional().HasPrecision(10, 2);
            Property(x => x.ANIMALMONEY).HasColumnName("ANIMALMONEY").IsOptional().HasPrecision(10, 2);
            Property(x => x.CHANGEOTHERPRECENT).HasColumnName("CHANGEOTHERPRECENT").IsOptional().HasPrecision(10, 2);
            Property(x => x.CHANGEOTHERMONEY).HasColumnName("CHANGEOTHERMONEY").IsOptional().HasPrecision(10, 2);
            #endregion
        }
    }
}