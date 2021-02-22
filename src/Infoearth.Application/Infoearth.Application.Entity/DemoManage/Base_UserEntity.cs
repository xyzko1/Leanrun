using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.DemoManage
{
    /// <summary>
    /// �� �� LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-01-09 16:18
    /// �� �����û���Ϣ��
    /// </summary>
    public class Base_UserEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// �û�����
        /// </summary>
        /// <returns></returns>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// �û�����
        /// </summary>
        /// <returns></returns>
        [Column("F_ENCODE")]
        public string F_EnCode { get; set; }
        /// <summary>
        /// ��¼�˻�
        /// </summary>
        /// <returns></returns>
        [Column("F_ACCOUNT")]
        public string F_Account { get; set; }
        /// <summary>
        /// ��¼����
        /// </summary>
        /// <returns></returns>
        [Column("F_PASSWORD")]
        public string F_Password { get; set; }
        /// <summary>
        /// ������Կ
        /// </summary>
        /// <returns></returns>
        [Column("F_SECRETKEY")]
        public string F_Secretkey { get; set; }
        /// <summary>
        /// ��ʵ����
        /// </summary>
        /// <returns></returns>
        [Column("F_REALNAME")]
        public string F_RealName { get; set; }
        /// <summary>
        /// �س�
        /// </summary>
        /// <returns></returns>
        [Column("F_NICKNAME")]
        public string F_NickName { get; set; }
        /// <summary>
        /// ͷ��
        /// </summary>
        /// <returns></returns>
        [Column("F_HEADICON")]
        public string F_HeadIcon { get; set; }
        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <returns></returns>
        [Column("F_QUICKQUERY")]
        public string F_QuickQuery { get; set; }
        /// <summary>
        /// ��ƴ
        /// </summary>
        /// <returns></returns>
        [Column("F_SIMPLESPELLING")]
        public string F_SimpleSpelling { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        /// <returns></returns>
        [Column("F_GENDER")]
        public int? F_Gender { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("F_BIRTHDAY")]
        public System.DateTime? F_Birthday { get; set; }
        /// <summary>
        /// �ֻ�
        /// </summary>
        /// <returns></returns>
        [Column("F_MOBILE")]
        public string F_Mobile { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        [Column("F_TELEPHONE")]
        public string F_Telephone { get; set; }
        /// <summary>
        /// �����ʼ�
        /// </summary>
        /// <returns></returns>
        [Column("F_EMAIL")]
        public string F_Email { get; set; }
        /// <summary>
        /// QQ��
        /// </summary>
        /// <returns></returns>
        [Column("F_OICQ")]
        public string F_OICQ { get; set; }
        /// <summary>
        /// ΢�ź�
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
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("F_MANAGERID")]
        public string F_ManagerId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("F_MANAGER")]
        public string F_Manager { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("F_ORGANIZEID")]
        public string F_OrganizeId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("F_DEPARTMENTID")]
        public string F_DepartmentId { get; set; }
        /// <summary>
        /// ��ɫ����
        /// </summary>
        /// <returns></returns>
        [Column("F_ROLEID")]
        public string F_RoleId { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        [Column("F_DUTYID")]
        public string F_DutyId { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        [Column("F_DUTYNAME")]
        public string F_DutyName { get; set; }
        /// <summary>
        /// ְλ����
        /// </summary>
        /// <returns></returns>
        [Column("F_POSTID")]
        public string F_PostId { get; set; }
        /// <summary>
        /// ְλ����
        /// </summary>
        /// <returns></returns>
        [Column("F_POSTNAME")]
        public string F_PostName { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("F_WORKGROUPID")]
        public string F_WorkGroupId { get; set; }
        /// <summary>
        /// ��ȫ����
        /// </summary>
        /// <returns></returns>
        [Column("F_SECURITYLEVEL")]
        public int? F_SecurityLevel { get; set; }
        /// <summary>
        /// ����״̬
        /// </summary>
        /// <returns></returns>
        [Column("F_USERONLINE")]
        public int? F_UserOnLine { get; set; }
        /// <summary>
        /// �����¼��ʶ
        /// </summary>
        /// <returns></returns>
        [Column("F_OPENID")]
        public int? F_OpenId { get; set; }
        /// <summary>
        /// ������ʾ����
        /// </summary>
        /// <returns></returns>
        [Column("F_QUESTION")]
        public string F_Question { get; set; }
        /// <summary>
        /// ������ʾ��
        /// </summary>
        /// <returns></returns>
        [Column("F_ANSWERQUESTION")]
        public string F_AnswerQuestion { get; set; }
        /// <summary>
        /// ������û�ͬʱ��¼
        /// </summary>
        /// <returns></returns>
        [Column("F_CHECKONLINE")]
        public int? F_CheckOnLine { get; set; }
        /// <summary>
        /// �����¼ʱ�俪ʼ
        /// </summary>
        /// <returns></returns>
        [Column("F_ALLOWSTARTTIME")]
        public System.DateTime? F_AllowStartTime { get; set; }
        /// <summary>
        /// �����¼ʱ�����
        /// </summary>
        /// <returns></returns>
        [Column("F_ALLOWENDTIME")]
        public System.DateTime? F_AllowEndTime { get; set; }
        /// <summary>
        /// ��ͣ�û���ʼ����
        /// </summary>
        /// <returns></returns>
        [Column("F_LOCKSTARTDATE")]
        public System.DateTime? F_LockStartDate { get; set; }
        /// <summary>
        /// ��ͣ�û���������
        /// </summary>
        /// <returns></returns>
        [Column("F_LOCKENDDATE")]
        public System.DateTime? F_LockEndDate { get; set; }
        /// <summary>
        /// ��һ�η���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("F_FIRSTVISIT")]
        public System.DateTime? F_FirstVisit { get; set; }
        /// <summary>
        /// ��һ�η���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("F_PREVIOUSVISIT")]
        public System.DateTime? F_PreviousVisit { get; set; }
        /// <summary>
        /// ������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("F_LASTVISIT")]
        public System.DateTime? F_LastVisit { get; set; }
        /// <summary>
        /// ��¼����
        /// </summary>
        /// <returns></returns>
        [Column("F_LOGONCOUNT")]
        public int? F_LogOnCount { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        /// <summary>
        /// ɾ�����
        /// </summary>
        /// <returns></returns>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// ��Ч��־
        /// </summary>
        /// <returns></returns>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATE")]
        public System.DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// �����û�
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYDATE")]
        public System.DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// �޸��û�����
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// �޸��û�
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.F_UserId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            this.F_CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.F_CreateUserName = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// �༭����
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