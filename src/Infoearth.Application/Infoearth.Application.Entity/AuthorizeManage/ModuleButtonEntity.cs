﻿using Infoearth.Application.Code;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infoearth.Application.Entity.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.08.01 14:00
    /// 描 述：系统按钮
    /// </summary>
    public class ModuleButtonEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 按钮主键
        /// </summary>
        /// <returns></returns>
        [Column("F_MODULEBUTTONID")]
        public string F_ModuleButtonId { get; set; }
        /// <summary>
        /// 功能主键
        /// </summary>
        /// <returns></returns>
        [Column("F_MODULEID")]
        public string F_ModuleId { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>
        /// <returns></returns>
        [Column("F_PARENTID")]
        public string F_ParentId { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        /// <returns></returns>
        [Column("F_ICON")]
        public string F_Icon { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        /// <returns></returns>
        [Column("F_ENCODE")]
        public string F_EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        /// <returns></returns>
        [Column("F_FULLNAME")]
        public string F_FullName { get; set; }
        /// <summary>
        /// Action地址
        /// </summary>
        /// <returns></returns>
        [Column("F_ACTIONADDRESS")]
        public string F_ActionAddress { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        /// <returns></returns>
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.F_ModuleButtonId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_ModuleButtonId = keyValue;
        }
        #endregion
    }
}