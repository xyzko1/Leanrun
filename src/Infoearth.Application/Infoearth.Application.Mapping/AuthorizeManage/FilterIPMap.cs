﻿using Infoearth.Application.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.20 13:32
    /// 描 述：过滤时段
    /// </summary>
    public class FilterIPMap : EntityTypeConfiguration<FilterIPEntity>
    {
        public FilterIPMap()
        {
            #region 表、主键
            //表
            this.ToTable("BASE_FILTERIP");
            //主键
            this.HasKey(t => t.F_FilterIPId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
