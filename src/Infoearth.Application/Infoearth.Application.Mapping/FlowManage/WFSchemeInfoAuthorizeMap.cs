﻿using Infoearth.Application.Entity.FlowManage;
using System.Data.Entity.ModelConfiguration;
namespace Infoearth.Application.Mapping.FlowManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：陈彬彬
    /// 日 期：2016.03.18 09:58
    /// 描 述：工作流模板权限表
    /// </summary>
    public class WFSchemeInfoAuthorizeMap : EntityTypeConfiguration<WFSchemeInfoAuthorizeEntity>
    {
        public WFSchemeInfoAuthorizeMap()
        {
            #region 表、主键
            //表
            this.ToTable("WF_SCHEMEINFOAUTHORIZE");//WF_SchemeInfoAuthorize
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
