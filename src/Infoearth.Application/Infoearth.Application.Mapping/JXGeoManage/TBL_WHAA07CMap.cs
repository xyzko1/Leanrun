using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-26 14:28
    /// 描 述：统计分析查询语句表
    /// </summary>
    public class TBL_WHAA07CMap : EntityTypeConfiguration<TBL_WHAA07CEntity>
    {
        public TBL_WHAA07CMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_WHAA07C");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
