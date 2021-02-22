using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:31
    /// 描 述：治理工程-验收
    /// </summary>
    public class TBL_ZLGC_YSINFOMap : EntityTypeConfiguration<TBL_ZLGC_YSINFOEntity>
    {
        public TBL_ZLGC_YSINFOMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_ZLGC_YSINFO");
            //主键
            this.HasKey(t => t.ZLGCID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
