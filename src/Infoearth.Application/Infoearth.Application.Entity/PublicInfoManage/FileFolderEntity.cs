﻿using Infoearth.Application.Code;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infoearth.Application.Entity.PublicInfoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.12.15 10:56
    /// 描 述：文件夹
    /// </summary>
    public class FileFolderEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 文件夹主键
        /// </summary>
        /// <returns></returns>
        [Column("F_FOLDERID")]
        public string F_FolderId { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>
        /// <returns></returns>
        [Column("F_PARENTID")]
        public string F_ParentId { get; set; }
        /// <summary>
        /// 文件夹类型
        /// </summary>
        /// <returns></returns>
        [Column("F_FOLDERTYPE")]
        public string F_FolderType { get; set; }
        /// <summary>
        /// 文件夹名称
        /// </summary>
        /// <returns></returns>
        [Column("F_FOLDERNAME")]
        public string F_FolderName { get; set; }
        /// <summary>
        /// 共享
        /// </summary>
        /// <returns></returns>
        [Column("F_ISSHARE")]
        public int? F_IsShare { get; set; }
        /// <summary>
        /// 共享连接
        /// </summary>
        /// <returns></returns>
        [Column("F_SHARELINK")]
        public string F_ShareLink { get; set; }
        /// <summary>
        /// 共享提取码
        /// </summary>
        /// <returns></returns>
        [Column("F_SHARECODE")]
        public int? F_ShareCode { get; set; }
        /// <summary>
        /// 共享日期
        /// </summary>
        /// <returns></returns>
        [Column("F_SHARETIME")]
        public DateTime? F_ShareTime { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        /// <returns></returns>
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        /// <returns></returns>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>
        /// <returns></returns>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
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
            this.F_FolderId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            this.F_CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.F_CreateUserName = OperatorProvider.Provider.Current().UserName;
            this.F_ModifyDate = DateTime.Now;
            this.F_ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.F_ModifyUserName = OperatorProvider.Provider.Current().UserName;
            this.F_DeleteMark = 0;
            this.F_EnabledMark = 1;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_FolderId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            this.F_ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.F_ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}