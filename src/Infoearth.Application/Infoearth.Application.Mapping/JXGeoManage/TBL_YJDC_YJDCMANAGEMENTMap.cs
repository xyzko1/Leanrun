using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-15 11:31
    /// 描 述：应急调查数据管理
    /// </summary>
    public class TBL_YJDC_YJDCMANAGEMENTMap : EntityTypeConfiguration<TBL_YJDC_YJDCMANAGEMENTEntity>
    {
        public TBL_YJDC_YJDCMANAGEMENTMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_YJDC_YJDCMANAGEMENT");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.SLOPEAREA).HasColumnName("SLOPEAREA").IsOptional().HasPrecision(12,8);
            Property(x => x.SLOPEVOLUME).HasColumnName("SLOPEVOLUME").IsOptional().HasPrecision(12,8);
            #region 配置关系
            #endregion
        }
    }
}
