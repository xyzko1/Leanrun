using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:30
    /// 描 述：治理工程-野外勘察
    /// </summary>
    public class TBL_ZLGC_KCINFOMap : EntityTypeConfiguration<TBL_ZLGC_KCINFOEntity>
    {
        public TBL_ZLGC_KCINFOMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_ZLGC_KCINFO");
            //主键
            this.HasKey(t => t.ZLGCID);
            #endregion

            Property(x => x.KCFY).HasColumnName("KCFY").IsOptional().HasPrecision(15,4);
            #region 配置关系
            #endregion
        }
    }
}
