using Infoearth.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.DemoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-09-20 17:48
    /// 描 述：系统功能表
    /// </summary>
    public class Base_ModuleMap : EntityTypeConfiguration<Base_ModuleEntity>
    {
        public Base_ModuleMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_Module");
            //主键
            this.HasKey(t => t.F_ModuleId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
