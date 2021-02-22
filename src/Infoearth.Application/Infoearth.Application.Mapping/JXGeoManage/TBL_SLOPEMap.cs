using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-13 16:04
    /// �� ����б�µ����
    /// </summary>
    public class TBL_SLOPEMap : EntityTypeConfiguration<TBL_SLOPEEntity>
    {
        public TBL_SLOPEMap()
        {
            #region ������
            //��
            this.ToTable("TBL_SLOPE");
            //����
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion

            #region ���ù�ϵ
            Property(x => x.X).HasColumnName("X").IsOptional().HasPrecision(10, 2);
            Property(x => x.Y).HasColumnName("Y").IsOptional().HasPrecision(10, 2);
            Property(x => x.Z).HasColumnName("Z").IsOptional().HasPrecision(10, 2);
            Property(x => x.ALTTOP).HasColumnName("ALTTOP").IsOptional().HasPrecision(10, 2);
            Property(x => x.ALTBOTOM).HasColumnName("ALTBOTOM").IsOptional().HasPrecision(10, 2);
            Property(x => x.STRATUMDIRECTION).HasColumnName("STRATUMDIRECTION").IsOptional().HasPrecision(8, 2);
            Property(x => x.STRATUMANGLE).HasColumnName("STRATUMANGLE").IsOptional().HasPrecision(8, 2);
            Property(x => x.AVERAGEYEARRAINFALL).HasColumnName("AVERAGEYEARRAINFALL").IsOptional().HasPrecision(8, 2);
            Property(x => x.MAXDAYRAINFALL).HasColumnName("MAXDAYRAINFALL").IsOptional().HasPrecision(8, 2);
            Property(x => x.MAXHOURRAINFALL).HasColumnName("MAXHOURRAINFALL").IsOptional().HasPrecision(8, 2);
            Property(x => x.MAXWATERLEVEL).HasColumnName("MAXWATERLEVEL").IsOptional().HasPrecision(8, 2);
            Property(x => x.MINWATERLEVEL).HasColumnName("MINWATERLEVEL").IsOptional().HasPrecision(8, 2);
            Property(x => x.SLOPEHEIGHT).HasColumnName("SLOPEHEIGHT").IsOptional().HasPrecision(8, 2);
            Property(x => x.SLOPELENGTH).HasColumnName("SLOPELENGTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.SLOPEWIDTH).HasColumnName("SLOPEWIDTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.ROCKDEPTH).HasColumnName("ROCKDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.ROCKLENGTH).HasColumnName("ROCKLENGTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.ROCKWIDTH).HasColumnName("ROCKWIDTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.ROCKHEIGHT).HasColumnName("ROCKHEIGHT").IsOptional().HasPrecision(8, 2);
            Property(x => x.CTRLSURFLENGTH1).HasColumnName("CTRLSURFLENGTH1").IsOptional().HasPrecision(8, 2);
            Property(x => x.CTRLSURFSPACE1).HasColumnName("CTRLSURFSPACE1").IsOptional().HasPrecision(8, 2);
            Property(x => x.COCTRLSURFLENGTH2).HasColumnName("COCTRLSURFLENGTH2").IsOptional().HasPrecision(8, 2);
            Property(x => x.CTRLSURFSPACE2).HasColumnName("CTRLSURFSPACE2").IsOptional().HasPrecision(8, 2);
            Property(x => x.CTRLSURFLENGTH3).HasColumnName("CTRLSURFLENGTH3").IsOptional().HasPrecision(8, 2);
            Property(x => x.CTRLSURFSPACE3).HasColumnName("CTRLSURFSPACE3").IsOptional().HasPrecision(8, 2);
            Property(x => x.WEATHEREDZONEDEPTH).HasColumnName("WEATHEREDZONEDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.UNLOADCRACKDEPTH).HasColumnName("UNLOADCRACKDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.BEDROCKDEPTH).HasColumnName("BEDROCKDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.GROUNDWATERDEPTH).HasColumnName("GROUNDWATERDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.DESTROYEDROAD).HasColumnName("DESTROYEDROAD").IsOptional().HasPrecision(8, 2);
            Property(x => x.DESTROYEDCANAL).HasColumnName("DESTROYEDCANAL").IsOptional().HasPrecision(8, 2);
            Property(x => x.DIRECTLOSSES).HasColumnName("DIRECTLOSSES").IsOptional().HasPrecision(10, 2);
            Property(x => x.THREATENASSETS).HasColumnName("THREATENASSETS").IsOptional().HasPrecision(10, 2);
            Property(x => x.PREDICTIVEVOLUME).HasColumnName("PREDICTIVEVOLUME").IsOptional().HasPrecision(18, 2);
            Property(x => x.SLOPEDEPTH).HasColumnName("SLOPEDEPTH").IsOptional().HasPrecision(6, 2);
            #endregion
        }
    }
}
