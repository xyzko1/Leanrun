using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 11:51
    /// 描 述：地面沉降调查表历史表
    /// </summary>
    public class TBL_LANDSETTLEMENT_HISTORYMap : EntityTypeConfiguration<TBL_LANDSETTLEMENT_HISTORYEntity>
    {
        public TBL_LANDSETTLEMENT_HISTORYMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_LANDSETTLEMENT_HISTORY");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            Property(x => x.X).HasColumnName("X").IsOptional().HasPrecision(10,2);
            Property(x => x.Y).HasColumnName("Y").IsOptional().HasPrecision(10,2);
            Property(x => x.Z).HasColumnName("Z").IsOptional().HasPrecision(10,2);
            Property(x => x.SETTLEMENTCENTERLONGITUDE).HasColumnName("SETTLEMENTCENTERLONGITUDE").IsOptional().HasPrecision(10,6);
            Property(x => x.SETTLEMENTCENTERLATITUDE).HasColumnName("SETTLEMENTCENTERLATITUDE").IsOptional().HasPrecision(10,6);
            Property(x => x.SETTLEMENTAREA).HasColumnName("SETTLEMENTAREA").IsOptional().HasPrecision(8,2);
            Property(x => x.AVERAGEYEARSETTLEMENTVOLUME).HasColumnName("AVERAGEYEARSETTLEMENTVOLUME").IsOptional().HasPrecision(8,2);
            Property(x => x.ACCUMULATIVESETTLEMENTVOLUME).HasColumnName("ACCUMULATIVESETTLEMENTVOLUME").IsOptional().HasPrecision(8,2);
            Property(x => x.AVERAGESETTLEMENTRATE).HasColumnName("AVERAGESETTLEMENTRATE").IsOptional().HasPrecision(8,2);
            Property(x => x.YEARMININGVOLUME).HasColumnName("YEARMININGVOLUME").IsOptional().HasPrecision(8,2);
            Property(x => x.YEARSUPPLYVOLUME).HasColumnName("YEARSUPPLYVOLUME").IsOptional().HasPrecision(8,2);
            Property(x => x.GROUNDWATERDEPTH).HasColumnName("GROUNDWATERDEPTH").IsOptional().HasPrecision(8,2);
            Property(x => x.YEARWATLEVCHANGEMARGIN).HasColumnName("YEARWATLEVCHANGEMARGIN").IsOptional().HasPrecision(8,2);
            Property(x => x.ECONOMICLOSSES).HasColumnName("ECONOMICLOSSES").IsOptional().HasPrecision(8,2);
            Property(x => x.DIRECTLOSS).HasColumnName("DIRECTLOSS").IsOptional().HasPrecision(8,2);
            Property(x => x.THREATENASSETS).HasColumnName("THREATENASSETS").IsOptional().HasPrecision(8,2);

            #endregion

        }
    }
}
