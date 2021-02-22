using Infoearth.Application.Entity.MONITORPOINT;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.MONITORPOINT
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-22 18:23
    /// 描 述：地面沉降监测点信息表
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTMap : EntityTypeConfiguration<TBL_DMCJ_MONITORPOINTEntity>
    {
        public TBL_DMCJ_MONITORPOINTMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_DMCJ_MONITORPOINT");
            //主键
            this.HasKey(t => t.MONITORPOINTID);
            #endregion

            #region 配置关系
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            #endregion
        }
    }
}
