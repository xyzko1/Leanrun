using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-05 14:36
    /// 描 述：遥感解译表
    /// </summary>
    public class TBL_SENSEMap : EntityTypeConfiguration<TBL_SENSEEntity>
    {
        public TBL_SENSEMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_SENSE");
            //主键
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
