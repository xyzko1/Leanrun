﻿using Infoearth.Application.Code;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infoearth.Application.Entity.PublicInfoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.12.8 11:31
    /// 描 述：邮件收件人
    /// </summary>
    public class EmailAddresseeEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 邮箱收件人主键
        /// </summary>
        /// <returns></returns>
        [Column("F_ADDRESSEEID")]
        public string F_AddresseeId { get; set; }
        /// <summary>
        /// 邮件信息主键
        /// </summary>
        /// <returns></returns>
        [Column("F_CONTENTID")]
        public string F_ContentId { get; set; }
        /// <summary>
        /// 邮件分类主键
        /// </summary>
        /// <returns></returns>
        [Column("F_CATEGORYID")]
        public string F_CategoryId { get; set; }
        /// <summary>
        /// 收件人Id
        /// </summary>
        /// <returns></returns>
        [Column("F_RECIPIENTID")]
        public string F_RecipientId { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        /// <returns></returns>
        [Column("F_RECIPIENTNAME")]
        public string F_RecipientName { get; set; }
        /// <summary>
        /// 收件状态（0-收件1-抄送2-密送）
        /// </summary>
        /// <returns></returns>
        [Column("F_RECIPIENTSTATE")]
        public int? F_RecipientState { get; set; }
        /// <summary>
        /// 是否阅读
        /// </summary>
        /// <returns></returns>
        [Column("F_ISREAD")]
        public int? F_IsRead { get; set; }
        /// <summary>
        /// 阅读次数
        /// </summary>
        /// <returns></returns>
        [Column("F_READCOUNT")]
        public int? F_ReadCount { get; set; }
        /// <summary>
        /// 最后阅读日期
        /// </summary>
        /// <returns></returns>
        [Column("F_READDATE")]
        public DateTime? F_ReadDate { get; set; }
        /// <summary>
        /// 设置红旗
        /// </summary>
        /// <returns></returns>
        [Column("F_ISHIGHLIGHT")]
        public int? F_IsHighlight { get; set; }
        /// <summary>
        /// 设置待办
        /// </summary>
        /// <returns></returns>
        [Column("F_BACKLOG")]
        public int? F_Backlog { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        /// <returns></returns>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 修改用户主键
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.F_AddresseeId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            this.F_CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.F_CreateUserName = OperatorProvider.Provider.Current().UserName;
            this.F_DeleteMark = 0;
            this.F_ReadCount = 0;
            this.F_IsRead = 0;
        }
        #endregion
    }
}