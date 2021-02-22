using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:29
    /// 描 述：治理工程-监理
    /// </summary>
    public class TBL_ZLGC_JLINFOMap : EntityTypeConfiguration<TBL_ZLGC_JLINFOEntity>
    {
        public TBL_ZLGC_JLINFOMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_ZLGC_JLINFO");
            //主键
            this.HasKey(t => t.ZLGCID);
            #endregion

            Property(x => x.JLCOST).HasColumnName("JLCOST").IsOptional().HasPrecision(15,2);
            #region 配置关系
            #endregion
        }
    }
}
