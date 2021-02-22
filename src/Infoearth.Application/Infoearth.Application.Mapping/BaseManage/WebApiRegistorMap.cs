using Infoearth.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 
    /// 创 建：超级管理员
    /// 日 期：2017-07-27 15:01
    /// 描 述：WebApi注册
    /// </summary>
    public class WebApiRegistorMap : EntityTypeConfiguration<WebApiRegistorEntity>
    {
        public WebApiRegistorMap()
        {
            #region 表、主键
            //表
            this.ToTable("BASE_WEBAPIREGISTOR");//Base_WebApiRegistor
            //主键
            this.HasKey(t => t.F_WebApiId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
