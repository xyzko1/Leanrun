using System;
using Infoearth.Application.Code;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infoearth.Application.Entity.CustomerManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� �����ܴ���
    /// �� �ڣ�2016-04-28 16:48
    /// �� �����ֽ����
    /// </summary>
    public class CashBalanceEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// �ֽ��������
        /// </summary>
        /// <returns></returns>
        [Column("F_CASHBALANCEID")]
        public string F_CashBalanceId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("F_OBJECTID")]
        public string F_ObjectId { get; set; }
        /// <summary>
        /// F_ExecutionDate
        /// </summary>
        /// <returns></returns>
        [Column("F_EXECUTIONDATE")]
        public DateTime? F_ExecutionDate { get; set; }
        /// <summary>
        /// F_CashAccount
        /// </summary>
        /// <returns></returns>
        [Column("F_CASHACCOUNT")]
        public string F_CashAccount { get; set; }
        /// <summary>
        /// F_Receivable
        /// </summary>
        /// <returns></returns>
        [Column("F_RECEIVABLE")]
        public decimal? F_Receivable { get; set; }
        /// <summary>
        /// F_Expenses
        /// </summary>
        /// <returns></returns>
        [Column("F_EXPENSES")]
        public decimal? F_Expenses { get; set; }
        /// <summary>
        /// F_Balance
        /// </summary>
        /// <returns></returns>
        [Column("F_BALANCE")]
        public decimal? F_Balance { get; set; }
        /// <summary>
        /// F_Abstract
        /// </summary>
        /// <returns></returns>
        [Column("F_ABSTRACT")]
        public string F_Abstract { get; set; }
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
            this.F_CashBalanceId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            this.F_CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.F_CreateUserName = OperatorProvider.Provider.Current().UserName;
            this.F_DeleteMark = 0;
            this.F_EnabledMark = 1;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_CashBalanceId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            this.F_ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.F_ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}