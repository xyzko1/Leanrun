using System;
using Infoearth.Application.Code;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infoearth.Application.Entity.PublicInfoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� �����ܴ���
    /// �� �ڣ�2016-04-25 10:45
    /// �� �����ճ̹���
    /// </summary>
    public class ScheduleEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// �ճ�����
        /// </summary>
        /// <returns></returns>
        [Column("F_SCHEDULEID")]
        public string F_ScheduleId { get; set; }
        /// <summary>
        /// �ճ�����
        /// </summary>
        /// <returns></returns>
        [Column("F_SCHEDULENAME")]
        public string F_ScheduleName { get; set; }
        /// <summary>
        /// �ճ�����
        /// </summary>
        /// <returns></returns>
        [Column("F_SCHEDULECONTENT")]
        public string F_ScheduleContent { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("F_CATEGORY")]
        public string F_Category { get; set; }
        /// <summary>
        /// ��ʼ����
        /// </summary>
        /// <returns></returns>
        [Column("F_STARTDATE")]
        public DateTime? F_StartDate { get; set; }
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        /// <returns></returns>
        [Column("F_STARTTIME")]
        public string F_StartTime { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("F_ENDDATE")]
        public DateTime? F_EndDate { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("F_ENDTIME")]
        public string F_EndTime { get; set; }
        /// <summary>
        /// ��ǰ����
        /// </summary>
        /// <returns></returns>
        [Column("F_EARLY")]
        public int? F_Early { get; set; }
        /// <summary>
        /// �ʼ�����
        /// </summary>
        /// <returns></returns>
        [Column("F_ISMAILALERT")]
        public int? F_IsMailAlert { get; set; }
        /// <summary>
        /// �ֻ�����
        /// </summary>
        /// <returns></returns>
        [Column("F_ISMOBILEALERT")]
        public int? F_IsMobileAlert { get; set; }
        /// <summary>
        /// ΢������
        /// </summary>
        /// <returns></returns>
        [Column("F_ISWECHATALERT")]
        public int? F_IsWeChatAlert { get; set; }
        /// <summary>
        /// �ճ�״̬
        /// </summary>
        /// <returns></returns>
        [Column("F_SCHEDULESTATE")]
        public int? F_ScheduleState { get; set; }
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
        public DateTime? F_CreateDate { get; set; }
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
        public DateTime? F_ModifyDate { get; set; }
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
            this.F_ScheduleId = Guid.NewGuid().ToString();
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
            this.F_ScheduleId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            this.F_ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.F_ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}