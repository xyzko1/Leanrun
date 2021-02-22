using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.DemoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.1.7
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-10-17 09:47
    /// �� ������������
    /// </summary>
    public class Client_OrderEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("F_ORDERID")]
        public string F_OrderId { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        /// <returns></returns>
        [Column("F_CUSTOMERID")]
        public string F_CustomerId { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        /// <returns></returns>
        [Column("F_CUSTOMERNAME")]
        public string F_CustomerName { get; set; }
        /// <summary>
        /// ������ԱId
        /// </summary>
        /// <returns></returns>
        [Column("F_SELLERID")]
        public string F_SellerId { get; set; }
        /// <summary>
        /// ������Ա
        /// </summary>
        /// <returns></returns>
        [Column("F_SELLERNAME")]
        public string F_SellerName { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("F_ORDERDATE")]
        public DateTime? F_OrderDate { get; set; }
        /// <summary>
        /// ���ݱ��
        /// </summary>
        /// <returns></returns>
        [Column("F_ORDERCODE")]
        public string F_OrderCode { get; set; }
        /// <summary>
        /// �Żݽ��
        /// </summary>
        /// <returns></returns>
        [Column("F_DISCOUNTSUM")]
        public decimal? F_DiscountSum { get; set; }
        /// <summary>
        /// Ӧ�ս��
        /// </summary>
        /// <returns></returns>
        [Column("F_ACCOUNTS")]
        public decimal? F_Accounts { get; set; }
        /// <summary>
        /// ���ս��
        /// </summary>
        /// <returns></returns>
        [Column("F_RECEIVEDAMOUNT")]
        public decimal? F_ReceivedAmount { get; set; }
        /// <summary>
        /// �տ�����
        /// </summary>
        /// <returns></returns>
        [Column("F_PAYMENTDATE")]
        public DateTime? F_PaymentDate { get; set; }
        /// <summary>
        /// �տʽ
        /// </summary>
        /// <returns></returns>
        [Column("F_PAYMENTMODE")]
        public string F_PaymentMode { get; set; }
        /// <summary>
        /// �տ�״̬��1-δ�տ�2-�����տ�3-ȫ���տ
        /// </summary>
        /// <returns></returns>
        [Column("F_PAYMENTSTATE")]
        public int? F_PaymentState { get; set; }
        /// <summary>
        /// ���۷���
        /// </summary>
        /// <returns></returns>
        [Column("F_SALECOST")]
        public decimal? F_SaleCost { get; set; }
        /// <summary>
        /// ժҪ��Ϣ
        /// </summary>
        /// <returns></returns>
        [Column("F_ABSTRACTINFO")]
        public string F_AbstractInfo { get; set; }
        /// <summary>
        /// ��ͬ���
        /// </summary>
        /// <returns></returns>
        [Column("F_CONTRACTCODE")]
        public string F_ContractCode { get; set; }
        /// <summary>
        /// ��ͬ����
        /// </summary>
        /// <returns></returns>
        [Column("F_CONTRACTFILE")]
        public string F_ContractFile { get; set; }
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
            this.F_OrderId = Guid.NewGuid().ToString();
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
            this.F_OrderId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            this.F_ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.F_ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}