﻿using Infoearth.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.PublicInfoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.12.8 11:31
    /// 描 述：邮件收件人
    /// </summary>
    public class EmailAddresseeMap : EntityTypeConfiguration<EmailAddresseeEntity>
    {
        public EmailAddresseeMap()
        {
            #region 表、主键
            //表
            this.ToTable("EMAIL_ADDRESSEE");//Email_Addressee
            //主键
            this.HasKey(t => t.F_AddresseeId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
