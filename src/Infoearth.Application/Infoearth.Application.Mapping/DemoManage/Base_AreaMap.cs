using Infoearth.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.DemoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 
    /// 创 建：超级管理员
    /// 日 期：2017-07-21 14:05
    /// 描 述：行政区域表
    /// </summary>
    public class Base_AreaMap : EntityTypeConfiguration<Base_AreaEntity>
    {
        public Base_AreaMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_Area");
            //主键
            this.HasKey(t => t.F_AreaId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
