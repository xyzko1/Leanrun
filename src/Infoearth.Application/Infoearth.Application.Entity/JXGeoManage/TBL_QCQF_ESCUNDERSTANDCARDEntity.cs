using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:21
    /// �� ����Ⱥ��Ⱥ���������׿�
    /// </summary>
    public class TBL_QCQF_ESCUNDERSTANDCARDEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// �ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// CGH�ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("CGHUNIFIEDCODE")]
        public string CGHUNIFIEDCODE { get; set; }
        /// <summary>
        /// ��ģ
        /// </summary>
        /// <returns></returns>
        [Column("SCALE")]
        public string SCALE { get; set; }
        /// <summary>
        /// ��ģ�ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("SCALELEVEL")]
        public string SCALELEVEL { get; set; }
        /// <summary>
        /// ��ס��ע������
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEHOLDNOTES")]
        public string HOUSEHOLDNOTES { get; set; }
        /// <summary>
        /// ����·��
        /// </summary>
        /// <returns></returns>
        [Column("LEAVEROUTES")]
        public string LEAVEROUTES { get; set; }
        /// <summary>
        /// �������ŵ�λ
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNIT")]
        public string CARDRELEASUNIT { get; set; }
        /// <summary>
        /// ���ŵ�λ������
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNITHEADER")]
        public string CARDRELEASUNITHEADER { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNITTEL")]
        public string CARDRELEASUNITTEL { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETIME")]
        public DateTime? UPDATETIME { get; set; }
        /// <summary>
        /// ��¼״̬
        /// </summary>
        /// <returns></returns>
        [Column("RECORDSTATUS")]
        public string RECORDSTATUS { get; set; }
        /// <summary>
        /// ����״̬
        /// </summary>
        /// <returns></returns>
        [Column("EXPSTATUS")]
        public string EXPSTATUS { get; set; }
        /// <summary>
        /// ������ID
        /// </summary>
        /// <returns></returns>
        [Column("CREATORUSERID")]
        public string CREATORUSERID { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CREATORTIME")]
        public DateTime? CREATORTIME2 { get; set; }
        /// <summary>
        /// ������ID
        /// </summary>
        /// <returns></returns>
        [Column("UPDATEUSERID")]
        public string UPDATEUSERID { get; set; }
        /// <summary>
        /// ���´���
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETIMES")]
        public short? UPDATETIMES { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEHOLDERNAME")]
        public string HOUSEHOLDERNAME { get; set; }
        /// <summary>
        /// ��ͥ����
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEHOLDSIZE")]
        public short? HOUSEHOLDSIZE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("HOUSINGTYPE")]
        public string HOUSINGTYPE { get; set; }
        /// <summary>
        /// ��ͥסַ
        /// </summary>
        /// <returns></returns>
        [Column("ADDRESS")]
        public string ADDRESS { get; set; }
        /// <summary>
        /// ����1
        /// </summary>
        /// <returns></returns>
        [Column("NAME1")]
        public string NAME1 { get; set; }
        /// <summary>
        /// ����2
        /// </summary>
        /// <returns></returns>
        [Column("NAME2")]
        public string NAME2 { get; set; }
        /// <summary>
        /// ����3
        /// </summary>
        /// <returns></returns>
        [Column("NAME3")]
        public string NAME3 { get; set; }
        /// <summary>
        /// ����4
        /// </summary>
        /// <returns></returns>
        [Column("NAME4")]
        public string NAME4 { get; set; }
        /// <summary>
        /// ����5
        /// </summary>
        /// <returns></returns>
        [Column("NAME5")]
        public string NAME5 { get; set; }
        /// <summary>
        /// ����6
        /// </summary>
        /// <returns></returns>
        [Column("NAME6")]
        public string NAME6 { get; set; }
        /// <summary>
        /// ����7
        /// </summary>
        /// <returns></returns>
        [Column("NAME7")]
        public string NAME7 { get; set; }
        /// <summary>
        /// ����8
        /// </summary>
        /// <returns></returns>
        [Column("NAME8")]
        public string NAME8 { get; set; }
        /// <summary>
        /// �Ա�1
        /// </summary>
        /// <returns></returns>
        [Column("SEX1")]
        public string SEX1 { get; set; }
        /// <summary>
        /// �Ա�2
        /// </summary>
        /// <returns></returns>
        [Column("SEX2")]
        public string SEX2 { get; set; }
        /// <summary>
        /// �Ա�3
        /// </summary>
        /// <returns></returns>
        [Column("SEX3")]
        public string SEX3 { get; set; }
        /// <summary>
        /// �Ա�4
        /// </summary>
        /// <returns></returns>
        [Column("SEX4")]
        public string SEX4 { get; set; }
        /// <summary>
        /// �Ա�5
        /// </summary>
        /// <returns></returns>
        [Column("SEX5")]
        public string SEX5 { get; set; }
        /// <summary>
        /// �Ա�6
        /// </summary>
        /// <returns></returns>
        [Column("SEX6")]
        public string SEX6 { get; set; }
        /// <summary>
        /// �Ա�7
        /// </summary>
        /// <returns></returns>
        [Column("SEX7")]
        public string SEX7 { get; set; }
        /// <summary>
        /// �Ա�8
        /// </summary>
        /// <returns></returns>
        [Column("SEX8")]
        public string SEX8 { get; set; }
        /// <summary>
        /// ��������1
        /// </summary>
        /// <returns></returns>
        [Column("AGE1")]
        public DateTime? AGE1 { get; set; }
        /// <summary>
        /// ��������2
        /// </summary>
        /// <returns></returns>
        [Column("AGE2")]
        public DateTime? AGE2 { get; set; }
        /// <summary>
        /// ��������3
        /// </summary>
        /// <returns></returns>
        [Column("AGE3")]
        public DateTime? AGE3 { get; set; }
        /// <summary>
        /// ��������4
        /// </summary>
        /// <returns></returns>
        [Column("AGE4")]
        public DateTime? AGE4 { get; set; }
        /// <summary>
        /// ��������5
        /// </summary>
        /// <returns></returns>
        [Column("AGE5")]
        public DateTime? AGE5 { get; set; }
        /// <summary>
        /// ��������6
        /// </summary>
        /// <returns></returns>
        [Column("AGE6")]
        public DateTime? AGE6 { get; set; }
        /// <summary>
        /// ��������7
        /// </summary>
        /// <returns></returns>
        [Column("AGE7")]
        public DateTime? AGE7 { get; set; }
        /// <summary>
        /// ��������8
        /// </summary>
        /// <returns></returns>
        [Column("AGE8")]
        public DateTime? AGE8 { get; set; }
        /// <summary>
        /// �������ŵ�λID
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNITID")]
        public string CARDRELEASUNITID { get; set; }
        /// <summary>
        /// ���ŵ�λ������ID
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNITHEADERID")]
        public string CARDRELEASUNITHEADERID { get; set; }
        /// <summary>
        /// �ֺ����뱾ס����λ�ù�ϵ
        /// </summary>
        /// <returns></returns>
        [Column("POSITIONALRELATIONSHIP")]
        public string POSITIONALRELATIONSHIP { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.GUID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.GUID = keyValue;
        }
        #endregion
    }
}