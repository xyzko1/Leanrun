﻿using System;
using Infoearth.Application.Code;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infoearth.Application.Entity.BaseManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.02 14:27
    /// 描 述：部门管理
    /// </summary>
    public class DepartmentEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 部门主键
        /// </summary>
        /// <returns></returns>
        [Column("F_DEPARTMENTID")]
        public string F_DepartmentId { get; set; }
        /// <summary>
        /// 机构主键
        /// </summary>
        /// <returns></returns>
        [Column("F_ORGANIZEID")]
        public string F_OrganizeId { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>
        /// <returns></returns>
        [Column("F_PARENTID")]
        public string F_ParentId { get; set; }
        /// <summary>
        /// 部门代码
        /// </summary>
        /// <returns></returns>
        [Column("F_ENCODE")]
        public string F_EnCode { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        /// <returns></returns>
        [Column("F_FULLNAME")]
        public string F_FullName { get; set; }
        /// <summary>
        /// 部门简称
        /// </summary>
        /// <returns></returns>
        [Column("F_SHORTNAME")]
        public string F_ShortName { get; set; }
        /// <summary>
        /// 部门类型
        /// </summary>
        /// <returns></returns>
        [Column("F_NATURE")]
        public string F_Nature { get; set; }
        /// <summary>
        /// 负责人主键
        /// </summary>
        /// <returns></returns>
        [Column("F_MANAGERID")]
        public string F_ManagerId { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        /// <returns></returns>
        [Column("F_MANAGER")]
        public string F_Manager { get; set; }
        /// <summary>
        /// 外线电话
        /// </summary>
        /// <returns></returns>
        [Column("F_OUTERPHONE")]
        public string F_OuterPhone { get; set; }
        /// <summary>
        /// 内线电话
        /// </summary>
        /// <returns></returns>
        [Column("F_INNERPHONE")]
        public string F_InnerPhone { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        /// <returns></returns>
        [Column("F_EMAIL")]
        public string F_Email { get; set; }
        /// <summary>
        /// 部门传真
        /// </summary>
        /// <returns></returns>
        [Column("F_FAX")]
        public string F_Fax { get; set; }
        /// <summary>
        /// 层
        /// </summary>
        /// <returns></returns>
        [Column("F_LAYER")]
        public int? F_Layer { get; set; }
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
            this.F_DepartmentId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            this.F_CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.F_CreateUserName = OperatorProvider.Provider.Current().UserName;
            this.F_DeleteMark = 0;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_DepartmentId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            this.F_ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.F_ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}