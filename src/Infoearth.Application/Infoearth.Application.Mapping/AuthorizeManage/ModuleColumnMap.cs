﻿using Infoearth.Application.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.10.29 15:13
    /// 描 述：系统视图
    /// </summary>
    public class ModuleColumnMap : EntityTypeConfiguration<ModuleColumnEntity>
    {
        public ModuleColumnMap()
        {
            #region 表、主键
            //表
            this.ToTable("BASE_MODULECOLUMN");
            //主键
            this.HasKey(t => t.F_ModuleColumnId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
