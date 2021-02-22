﻿using Infoearth.Application.Entity.FormManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.FormManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：陈小二
    /// 日 期：2016.11.29 14:35
    /// 描 述：表单模块关联表映射
    /// </summary>
    public class FormModuleRelationMap : EntityTypeConfiguration<FormModuleRelationEntity>
    {
        public FormModuleRelationMap()
        {
            #region 表、主键
            //表
            this.ToTable("FORM_MODULERELATION");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
