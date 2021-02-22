using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:31
    /// 描 述：治理工程-施工
    /// </summary>
    public class TBL_ZLGC_SGINFOMap : EntityTypeConfiguration<TBL_ZLGC_SGINFOEntity>
    {
        public TBL_ZLGC_SGINFOMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_ZLGC_SGINFO");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.FBJE).HasColumnName("FBJE").IsOptional().HasPrecision(15,2);
            #region 配置关系
            #endregion
        }
    }
}
