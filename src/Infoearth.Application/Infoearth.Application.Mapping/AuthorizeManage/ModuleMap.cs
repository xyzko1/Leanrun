﻿using Infoearth.Application.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.10.27 09:16
    /// 描 述：系统功能
    /// </summary>
    public class ModuleMap : EntityTypeConfiguration<ModuleEntity>
    {
        public ModuleMap()
        {
            #region 表、主键
            //表
            this.ToTable("BASE_MODULE");//Base_Module
            //主键
            this.HasKey(t => t.F_ModuleId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
