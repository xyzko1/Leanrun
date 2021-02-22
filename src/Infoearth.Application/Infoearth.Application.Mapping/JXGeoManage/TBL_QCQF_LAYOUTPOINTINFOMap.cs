using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-07 17:24
    /// 描 述：群测群防监测点信息表
    /// </summary>
    public class TBL_QCQF_LAYOUTPOINTINFOMap : EntityTypeConfiguration<TBL_QCQF_LAYOUTPOINTINFOEntity>
    {
        public TBL_QCQF_LAYOUTPOINTINFOMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_QCQF_LAYOUTPOINTINFO");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LON).HasColumnName("LON").IsOptional().HasPrecision(12,8);
            Property(x => x.LAT).HasColumnName("LAT").IsOptional().HasPrecision(12,8);
            #region 配置关系
            #endregion
        }
    }
}
