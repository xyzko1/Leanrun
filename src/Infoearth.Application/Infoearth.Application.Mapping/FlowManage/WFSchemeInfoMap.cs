﻿using Infoearth.Application.Entity.FlowManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.FlowManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：陈彬彬
    /// 日 期：2016.02.23 09:58
    /// 描 述：工作流模板信息表
    /// </summary>
    public class WFSchemeInfoMap : EntityTypeConfiguration<WFSchemeInfoEntity>
    {
        public WFSchemeInfoMap()
        {
            #region 表、主键
            //表
            this.ToTable("WF_SCHEMEINFO");//WF_SchemeInfo
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
