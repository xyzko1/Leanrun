using Infoearth.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 
    /// 创 建：超级管理员
    /// 日 期：2017-07-28 10:00
    /// 描 述：Base_WebApiLog
    /// </summary>
    public class WebApiLogMap : EntityTypeConfiguration<WebApiLogEntity>
    {
        public WebApiLogMap()
        {
            #region 表、主键
            //表
            this.ToTable("BASE_WEBAPILOG");//Base_WebApiLog
            //主键
            this.HasKey(t => t.F_LogId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
