using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-04-11 11:15
    /// 描 述：App_Project
    /// </summary>
    public class App_ProjectMap : EntityTypeConfiguration<App_ProjectEntity>
    {
        public App_ProjectMap()
        {
            #region 表、主键
            //表
            this.ToTable("App_Project");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
