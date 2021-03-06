using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:15
    /// 描 述：群测群防行政管理体系
    /// </summary>
    public class TBL_QCQF_ADMINISTRATIVEMap : EntityTypeConfiguration<TBL_QCQF_ADMINISTRATIVEEntity>
    {
        public TBL_QCQF_ADMINISTRATIVEMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_QCQF_ADMINISTRATIVE");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            #region 配置关系
            #endregion
        }
    }
}
