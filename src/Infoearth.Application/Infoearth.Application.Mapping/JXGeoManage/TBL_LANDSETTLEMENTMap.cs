using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-13 15:54
    /// �� ����������������
    /// </summary>
    public class TBL_LANDSETTLEMENTMap : EntityTypeConfiguration<TBL_LANDSETTLEMENTEntity>
    {
        public TBL_LANDSETTLEMENTMap()
        {
            #region ������
            //��
            this.ToTable("TBL_LANDSETTLEMENT");
            //����
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion

            #region ���ù�ϵ
            Property(x => x.X).HasColumnName("X").IsOptional().HasPrecision(10, 2);
            Property(x => x.Y).HasColumnName("Y").IsOptional().HasPrecision(10, 2);
            Property(x => x.Z).HasColumnName("Z").IsOptional().HasPrecision(10, 2);
            Property(x => x.SETTLEMENTCENTERLONGITUDE).HasColumnName("SETTLEMENTCENTERLONGITUDE").IsOptional().HasPrecision(10, 6);
            Property(x => x.SETTLEMENTCENTERLATITUDE).HasColumnName("SETTLEMENTCENTERLATITUDE").IsOptional().HasPrecision(10, 6);
            Property(x => x.SETTLEMENTAREA).HasColumnName("SETTLEMENTAREA").IsOptional().HasPrecision(8, 2);
            Property(x => x.AVERAGEYEARSETTLEMENTVOLUME).HasColumnName("AVERAGEYEARSETTLEMENTVOLUME").IsOptional().HasPrecision(8, 2);
            Property(x => x.ACCUMULATIVESETTLEMENTVOLUME).HasColumnName("ACCUMULATIVESETTLEMENTVOLUME").IsOptional().HasPrecision(8, 2);
            Property(x => x.AVERAGESETTLEMENTRATE).HasColumnName("AVERAGESETTLEMENTRATE").IsOptional().HasPrecision(8, 2);
            Property(x => x.YEARMININGVOLUME).HasColumnName("YEARMININGVOLUME").IsOptional().HasPrecision(8, 2);
            Property(x => x.YEARSUPPLYVOLUME).HasColumnName("YEARSUPPLYVOLUME").IsOptional().HasPrecision(8, 2);
            Property(x => x.GROUNDWATERDEPTH).HasColumnName("GROUNDWATERDEPTH").IsOptional().HasPrecision(8, 2);
            Property(x => x.YEARWATLEVCHANGEMARGIN).HasColumnName("YEARWATLEVCHANGEMARGIN").IsOptional().HasPrecision(8, 2);
            Property(x => x.ECONOMICLOSSES).HasColumnName("ECONOMICLOSSES").IsOptional().HasPrecision(8, 2);
            Property(x => x.DIRECTLOSS).HasColumnName("DIRECTLOSS").IsOptional().HasPrecision(8, 2);
            Property(x => x.THREATENASSETS).HasColumnName("THREATENASSETS").IsOptional().HasPrecision(8, 2);
            #endregion
        }
    }
}
