using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-28 16:05
    /// 描 述：统计公用报表
    /// </summary>
    public class TBL_REPORTMap : EntityTypeConfiguration<TBL_REPORTEntity>
    {
        public TBL_REPORTMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_REPORT");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
