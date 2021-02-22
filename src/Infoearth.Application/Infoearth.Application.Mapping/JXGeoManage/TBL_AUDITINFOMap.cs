using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-17 14:51
    /// 描 述：审核信息表
    /// </summary>
    public class TBL_AUDITINFOMap : EntityTypeConfiguration<TBL_AUDITINFOEntity>
    {
        public TBL_AUDITINFOMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_AUDITINFO");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
