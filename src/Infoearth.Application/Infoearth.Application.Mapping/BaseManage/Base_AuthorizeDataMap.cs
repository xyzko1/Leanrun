using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-05-22 10:48
    /// 描 述：授权数据表
    /// </summary>
    public class Base_AuthorizeDataMap : EntityTypeConfiguration<Base_AuthorizeDataEntity>
    {
        public Base_AuthorizeDataMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_AuthorizeData");
            //主键
            this.HasKey(t => t.F_AuthorizeDataId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
