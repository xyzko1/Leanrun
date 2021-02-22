using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:23
    /// �� ����Ⱥ��Ⱥ���������׿�
    /// </summary>
    public class TBL_QCQF_WORKUNDERSTANDCARDEntity : BaseEntity
    {
        #region ʵ���Ա
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
        /// ���ͼ���ģ
        /// </summary>
        /// <returns></returns>
        [Column("TYPEANDSIZE")]
        public string TYPEANDSIZE { get; set; }
        /// <summary>
        /// ��⸺����
        /// </summary>
        /// <returns></returns>
        [Column("MONITORHEADER")]
        public string MONITORHEADER { get; set; }
        /// <summary>
        /// ��������ϵ�绰
        /// </summary>
        /// <returns></returns>
        [Column("MONITORHEADERTEL")]
        public string MONITORHEADERTEL { get; set; }
        /// <summary>
        /// ��Ҫ����
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMAJORSIGNS")]
        public string MONITORMAJORSIGNS { get; set; }
        /// <summary>
        /// ��Ҫ�ֶκͷ���
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMEANSMETHODS")]
        public string MONITORMEANSMETHODS { get; set; }
        /// <summary>
        /// ��ɢ�������
        /// </summary>
        /// <returns></returns>
        [Column("EVACUATIONCOMMANDPUBLISHER")]
        public string EVACUATIONCOMMANDPUBLISHER { get; set; }
        /// <summary>
        /// ��ɢֵ��绰
        /// </summary>
        /// <returns></returns>
        [Column("EVACUATIONDUTYPHONE")]
        public string EVACUATIONDUTYPHONE { get; set; }
        /// <summary>
        /// �����յ�λ������
        /// </summary>
        /// <returns></returns>
        [Column("RISKUNITANDHEADER")]
        public string RISKUNITANDHEADER { get; set; }
        /// <summary>
        /// ������ֵ��绰
        /// </summary>
        /// <returns></returns>
        [Column("RISKDUTYPHONE")]
        public string RISKDUTYPHONE { get; set; }
        /// <summary>
        /// �ΰ�������λ������
        /// </summary>
        /// <returns></returns>
        [Column("PUBLICSECURITYUNITANDHEADER")]
        public string PUBLICSECURITYUNITANDHEADER { get; set; }
        /// <summary>
        /// �ΰ�����ֵ��绰
        /// </summary>
        /// <returns></returns>
        [Column("PUBLICSECURITYDUTYPHONE")]
        public string PUBLICSECURITYDUTYPHONE { get; set; }
        /// <summary>
        /// ҽ�ƾȻ���λ������
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALCAREUNITHEADER")]
        public string MEDICALCAREUNITHEADER { get; set; }
        /// <summary>
        /// ҽ�ƾȻ�ֵ��绰
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALCAREDUTYPHONE")]
        public string MEDICALCAREDUTYPHONE { get; set; }
        /// <summary>
        /// �������ŵ�λ
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNIT")]
        public string CARDRELEASUNIT { get; set; }
        /// <summary>
        /// ���ŵ�λ��ϵ�绰
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNITTEL")]
        public string CARDRELEASUNITTEL { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("RELEASEDATE")]
        public string RELEASEDATE { get; set; }
        /// <summary>
        /// �ֿ���λ�����
        /// </summary>
        /// <returns></returns>
        [Column("CARDUNITSINDIVIDUALS")]
        public string CARDUNITSINDIVIDUALS { get; set; }
        /// <summary>
        /// �ֿ���λ�������ϵ�绰
        /// </summary>
        /// <returns></returns>
        [Column("CARDUNITSINDIVIDUALSTEL")]
        public string CARDUNITSINDIVIDUALSTEL { get; set; }
        /// <summary>
        /// �ֿ�����
        /// </summary>
        /// <returns></returns>
        [Column("DATECARD")]
        public string DATECARD { get; set; }
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
        public DateTime? CREATORTIME { get; set; }
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
        /// ��⸺����ID
        /// </summary>
        /// <returns></returns>
        [Column("MONITORHEADERID")]
        public string MONITORHEADERID { get; set; }
        /// <summary>
        /// ��ɢ�������ID
        /// </summary>
        /// <returns></returns>
        [Column("EVACUATIONCOMMANDPUBLISHERID")]
        public string EVACUATIONCOMMANDPUBLISHERID { get; set; }
        /// <summary>
        /// �����յ�λ������ID
        /// </summary>
        /// <returns></returns>
        [Column("RISKUNITANDHEADERID")]
        public string RISKUNITANDHEADERID { get; set; }
        /// <summary>
        /// �ΰ�������λ������ID
        /// </summary>
        /// <returns></returns>
        [Column("PUBLICSECURITYUNITANDHEADERID")]
        public string PUBLICSECURITYUNITANDHEADERID { get; set; }
        /// <summary>
        /// ҽ�ƾȻ���λ������ID
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALCAREUNITHEADERID")]
        public string MEDICALCAREUNITHEADERID { get; set; }
        /// <summary>
        /// �������ŵ�λID
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNITID")]
        public string CARDRELEASUNITID { get; set; }
        /// <summary>
        /// �����յ�λ
        /// </summary>
        /// <returns></returns>
        [Column("RISKUNIT")]
        public string RISKUNIT { get; set; }
        /// <summary>
        /// �����յ�λID
        /// </summary>
        /// <returns></returns>
        [Column("RISKUNITID")]
        public string RISKUNITID { get; set; }
        /// <summary>
        /// �ΰ�������λ
        /// </summary>
        /// <returns></returns>
        [Column("PUBLICSECURITYUNIT")]
        public string PUBLICSECURITYUNIT { get; set; }
        /// <summary>
        /// �ΰ�������λID
        /// </summary>
        /// <returns></returns>
        [Column("PUBLICSECURITYUNITID")]
        public string PUBLICSECURITYUNITID { get; set; }
        /// <summary>
        /// ҽ�ƾȻ���λ
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALCAREUNIT")]
        public string MEDICALCAREUNIT { get; set; }
        /// <summary>
        /// ҽ�ƾȻ���λID
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALCAREUNITID")]
        public string MEDICALCAREUNITID { get; set; }
        /// <summary>
        /// �����ý��ʹ��
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.UNIFIEDCODE = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.UNIFIEDCODE = keyValue;
        }
        #endregion
    }
}