﻿using Infoearth.Application.Entity.MessageManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.MessageManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：陈彬彬
    /// 日 期：2015.11.26 18:23
    /// 描 述：即时通信用户群组表
    /// </summary>
    public class IMGroupMap: EntityTypeConfiguration<IMGroupEntity>
    {
        public IMGroupMap()
        {
            #region 表、主键
            //表
            this.ToTable("IM_GROUP");//IM_Group
            //主键
            this.HasKey(t => t.F_GroupId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
