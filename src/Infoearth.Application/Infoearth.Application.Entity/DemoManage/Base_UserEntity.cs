using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.DemoManage
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-01-09 16:18
    /// 描 述：用户信息表
    /// </summary>
    public class Base_UserEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 用户主键
        /// </summary>
        /// <returns></returns>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// 用户编码
        /// </summary>
        /// <returns></returns>
        [Column("F_ENCODE")]
        public string F_EnCode { get; set; }
        /// <summary>
        /// 登录账户
        /// </summary>
        /// <returns></returns>
        [Column("F_ACCOUNT")]
        public string F_Account { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        /// <returns></returns>
        [Column("F_PASSWORD")]
        public string F_Password { get; set; }
        /// <summary>
        /// 密码秘钥
        /// </summary>
        /// <returns></returns>
        [Column("F_SECRETKEY")]
        public string F_Secretkey { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        /// <returns></returns>
        [Column("F_REALNAME")]
        public string F_RealName { get; set; }
        /// <summary>
        /// 呢称
        /// </summary>
        /// <returns></returns>
        [Column("F_NICKNAME")]
        public string F_NickName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        /// <returns></returns>
        [Column("F_HEADICON")]
        public string F_HeadIcon { get; set; }
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <returns></returns>
        [Column("F_QUICKQUERY")]
        public string F_QuickQuery { get; set; }
        /// <summary>
        /// 简拼
        /// </summary>
        /// <returns></returns>
        [Column("F_SIMPLESPELLING")]
        public string F_SimpleSpelling { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        [Column("F_GENDER")]
        public int? F_Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        /// <returns></returns>
        [Column("F_BIRTHDAY")]
        public System.DateTime? F_Birthday { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        /// <returns></returns>
        [Column("F_MOBILE")]
        public string F_Mobile { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        [Column("F_TELEPHONE")]
        public string F_Telephone { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        /// <returns></returns>
        [Column("F_EMAIL")]
        public string F_Email { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>
        /// <returns></returns>
        [Column("F_OICQ")]
        public string F_OICQ { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        /// <returns></returns>
        [Column("F_WECHAT")]
        public string F_WeChat { get; set; }
        /// <summary>
        /// MSN
        /// </summary>
        /// <returns></returns>
        [Column("F_MSN")]
        public string F_MSN { get; set; }
        /// <summary>
        /// 主管主键
        /// </summary>
        /// <returns></returns>
        [Column("F_MANAGERID")]
        public string F_ManagerId { get; set; }
        /// <summary>
        /// 主管
        /// </summary>
        /// <returns></returns>
        [Column("F_MANAGER")]
        public string F_Manager { get; set; }
        /// <summary>
        /// 机构主键
        /// </summary>
        /// <returns></returns>
        [Column("F_ORGANIZEID")]
        public string F_OrganizeId { get; set; }
        /// <summary>
        /// 部门主键
        /// </summary>
        /// <returns></returns>
        [Column("F_DEPARTMENTID")]
        public string F_DepartmentId { get; set; }
        /// <summary>
        /// 角色主键
        /// </summary>
        /// <returns></returns>
        [Column("F_ROLEID")]
        public string F_RoleId { get; set; }
        /// <summary>
        /// 岗位主键
        /// </summary>
        /// <returns></returns>
        [Column("F_DUTYID")]
        public string F_DutyId { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>
        /// <returns></returns>
        [Column("F_DUTYNAME")]
        public string F_DutyName { get; set; }
        /// <summary>
        /// 职位主键
        /// </summary>
        /// <returns></returns>
        [Column("F_POSTID")]
        public string F_PostId { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        /// <returns></returns>
        [Column("F_POSTNAME")]
        public string F_PostName { get; set; }
        /// <summary>
        /// 工作组主键
        /// </summary>
        /// <returns></returns>
        [Column("F_WORKGROUPID")]
        public string F_WorkGroupId { get; set; }
        /// <summary>
        /// 安全级别
        /// </summary>
        /// <returns></returns>
        [Column("F_SECURITYLEVEL")]
        public int? F_SecurityLevel { get; set; }
        /// <summary>
        /// 在线状态
        /// </summary>
        /// <returns></returns>
        [Column("F_USERONLINE")]
        public int? F_UserOnLine { get; set; }
        /// <summary>
        /// 单点登录标识
        /// </summary>
        /// <returns></returns>
        [Column("F_OPENID")]
        public int? F_OpenId { get; set; }
        /// <summary>
        /// 密码提示问题
        /// </summary>
        /// <returns></returns>
        [Column("F_QUESTION")]
        public string F_Question { get; set; }
        /// <summary>
        /// 密码提示答案
        /// </summary>
        /// <returns></returns>
        [Column("F_ANSWERQUESTION")]
        public string F_AnswerQuestion { get; set; }
        /// <summary>
        /// 允许多用户同时登录
        /// </summary>
        /// <returns></returns>
        [Column("F_CHECKONLINE")]
        public int? F_CheckOnLine { get; set; }
        /// <summary>
        /// 允许登录时间开始
        /// </summary>
        /// <returns></returns>
        [Column("F_ALLOWSTARTTIME")]
        public System.DateTime? F_AllowStartTime { get; set; }
        /// <summary>
        /// 允许登录时间结束
        /// </summary>
        /// <returns></returns>
        [Column("F_ALLOWENDTIME")]
        public System.DateTime? F_AllowEndTime { get; set; }
        /// <summary>
        /// 暂停用户开始日期
        /// </summary>
        /// <returns></returns>
        [Column("F_LOCKSTARTDATE")]
        public System.DateTime? F_LockStartDate { get; set; }
        /// <summary>
        /// 暂停用户结束日期
        /// </summary>
        /// <returns></returns>
        [Column("F_LOCKENDDATE")]
        public System.DateTime? F_LockEndDate { get; set; }
        /// <summary>
        /// 第一次访问时间
        /// </summary>
        /// <returns></returns>
        [Column("F_FIRSTVISIT")]
        public System.DateTime? F_FirstVisit { get; set; }
        /// <summary>
        /// 上一次访问时间
        /// </summary>
        /// <returns></returns>
        [Column("F_PREVIOUSVISIT")]
        public System.DateTime? F_PreviousVisit { get; set; }
        /// <summary>
        /// 最后访问时间
        /// </summary>
        /// <returns></returns>
        [Column("F_LASTVISIT")]
        public System.DateTime? F_LastVisit { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        /// <returns></returns>
        [Column("F_LOGONCOUNT")]
        public int? F_LogOnCount { get; set; }
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
        public System.DateTime? F_CreateDate { get; set; }
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
        public System.DateTime? F_ModifyDate { get; set; }
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
            this.F_UserId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            this.F_CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.F_CreateUserName = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_UserId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            this.F_ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.F_ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}