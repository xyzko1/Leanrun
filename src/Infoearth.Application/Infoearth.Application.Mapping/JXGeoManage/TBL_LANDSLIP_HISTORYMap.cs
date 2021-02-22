using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 11:51
    /// �� �������µ������ʷ��
    /// </summary>
    public class TBL_LANDSLIP_HISTORYMap : EntityTypeConfiguration<TBL_LANDSLIP_HISTORYEntity>
    {
        public TBL_LANDSLIP_HISTORYMap()
        {
            #region ������
            //��
            this.ToTable("TBL_LANDSLIP_HISTORY");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            Property(x => x.X).HasColumnName("X").IsOptional().HasPrecision(10, 2);
            Property(x => x.Y).HasColumnName("Y").IsOptional().HasPrecision(10, 2);
            Property(x => x.Z).HasColumnName("Z").IsOptional().HasPrecision(10, 2);
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
            Property(x => x.GRAVELCONTENT).HasColumnName("GRAVELCONTENT").IsOptional().HasPrecision(8, 2);
            Property(x => x.SLIPSURFACEDEPTH).HasColumnName("SLIPSURFACEDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.SLIPZONEDEPTH).HasColumnName("SLIPZONEDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.GROUNDWATERDEPTH).HasColumnName("GROUNDWATERDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.DIRECTLOSSES).HasColumnName("DIRECTLOSSES").IsOptional().HasPrecision(8, 2);
            Property(x => x.THREATENASSETS).HasColumnName("THREATENASSETS").IsOptional().HasPrecision(12, 2);
            Property(x => x.DESTROYEDHOUSE).HasColumnName("DESTROYEDHOUSE").IsOptional().HasPrecision(9, 2);
            Property(x => x.DESTROYEDROAD).HasColumnName("DESTROYEDROAD").IsOptional().HasPrecision(10, 2);
            Property(x => x.DESTROYEDCANAL).HasColumnName("DESTROYEDCANAL").IsOptional().HasPrecision(10, 2);
            Property(x => x.INDIRECTLOSS).HasColumnName("INDIRECTLOSS").IsOptional().HasPrecision(8, 2);
            #endregion
        }
    }
}
