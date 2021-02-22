using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.BaseManage
{
    /// <summary>
    /// �� �� LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �Ϻ�������Ϣ�������޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-05-22 10:48
    /// �� ������Ȩ���ݱ�
    /// </summary>
    public class Base_AuthorizeDataEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ��Ȩ��������
        /// </summary>
        /// <returns></returns>
        [Column("F_AUTHORIZEDATAID")]
        public string F_AuthorizeDataId { get; set; }
        /// <summary>
        /// 1-���ޱ���2-���ޱ��˼�����3-���ڲ���4-���ڹ�˾5-����ϸ����
        /// </summary>
        /// <returns></returns>
        [Column("F_AUTHORIZETYPE")]
        public int? F_AuthorizeType { get; set; }
        /// <summary>
        /// �������:1-����2-��ɫ3-��λ4-ְλ5-������
        /// </summary>
        /// <returns></returns>
        [Column("F_CATEGORY")]
        public int? F_Category { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("F_OBJECTID")]
        public string F_ObjectId { get; set; }
        /// <summary>
        /// ��ĿId
        /// </summary>
        /// <returns></returns>
        [Column("F_ITEMID")]
        public string F_ItemId { get; set; }
        /// <summary>
        /// ��ĿId
        /// </summary>
        /// <returns></returns>
        [Column("F_ITEMNAME")]
        public string F_ItemName { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        [Column("F_RESOURCEID")]
        public string F_ResourceId { get; set; }
        /// <summary>
        /// ֻ��
        /// </summary>
        /// <returns></returns>
        [Column("F_ISREAD")]
        public int? F_IsRead { get; set; }
        /// <summary>
        /// Լ�����ʽ
        /// </summary>
        /// <returns></returns>
        [Column("F_AUTHORIZECONSTRAINT")]
        public string F_AuthorizeConstraint { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        /// <summary>
        /// ����ʱ��
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
        /// F_ModuleId
        /// </summary>
        /// <returns></returns>
        [Column("F_MODULEID")]
        public string F_ModuleId { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.F_AuthorizeDataId = Guid.NewGuid().ToString();
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
            this.F_AuthorizeDataId = keyValue;
        }
        #endregion
    }
}