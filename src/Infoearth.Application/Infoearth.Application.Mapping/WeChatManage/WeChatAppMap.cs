﻿using Infoearth.Application.Entity.WeChatManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.WeChatManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.12.23 11:31
    /// 描 述：企业号应用
    /// </summary>
    public class WeChatAppMap : EntityTypeConfiguration<WeChatAppEntity>
    {
        public WeChatAppMap()
        {
            #region 表、主键
            //表
            this.ToTable("WECHAT_APP");//WeChat_App
            //主键
            this.HasKey(t => t.F_AppId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
