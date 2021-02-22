using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:19
    /// �� ����Ⱥ��Ⱥ������Ԥ����
    /// </summary>
    public class TBL_QCQF_DISASTERPREVENTIONEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// �ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// ���������ֺ�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTIME")]
        public string DISASTERTIME { get; set; }
        /// <summary>
        /// ���ʻ�������
        /// </summary>
        /// <returns></returns>
        [Column("GEOLOGICALENVIRONMENT")]
        public string GEOLOGICALENVIRONMENT { get; set; }
        /// <summary>
        /// ������������ʷ����
        /// </summary>
        /// <returns></returns>
        [Column("DEFORMATIONHISTORICALE")]
        public string DEFORMATIONHISTORICALE { get; set; }
        /// <summary>
        /// �ȶ��Է���
        /// </summary>
        /// <returns></returns>
        [Column("STABILITYANALYSIS")]
        public string STABILITYANALYSIS { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERFACTORS")]
        public string TRIGGERFACTORS { get; set; }
        /// <summary>
        /// Ǳ��Σ��
        /// </summary>
        /// <returns></returns>
        [Column("POTENTIALHAZARDS")]
        public string POTENTIALHAZARDS { get; set; }
        /// <summary>
        /// ����״̬Ԥ��
        /// </summary>
        /// <returns></returns>
        [Column("STATEPREDICTION")]
        public string STATEPREDICTION { get; set; }
        /// <summary>
        /// ��ⷽ��
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMETHOD")]
        public string MONITORMETHOD { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("MONITORCYCLE")]
        public string MONITORCYCLE { get; set; }
        /// <summary>
        /// ���������
        /// </summary>
        /// <returns></returns>
        [Column("MONITORRESPONSIBLE")]
        public string MONITORRESPONSIBLE { get; set; }
        /// <summary>
        /// ��������˵绰
        /// </summary>
        /// <returns></returns>
        [Column("MONITORRESPONSIBLETEL")]
        public string MONITORRESPONSIBLETEL { get; set; }
        /// <summary>
        /// Ⱥ��Ⱥ����Ա
        /// </summary>
        /// <returns></returns>
        [Column("GROUPMONITORINGSTAFF")]
        public string GROUPMONITORINGSTAFF { get; set; }
        /// <summary>
        /// Ⱥ��Ⱥ����Ա�绰
        /// </summary>
        /// <returns></returns>
        [Column("GROUPMONITORINGSTAFFTEL")]
        public string GROUPMONITORINGSTAFFTEL { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("ALARMMETHOD")]
        public string ALARMMETHOD { get; set; }
        /// <summary>
        /// �����ź�
        /// </summary>
        /// <returns></returns>
        [Column("ALARMSIGNAL")]
        public string ALARMSIGNAL { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("ALARMPEOPLE")]
        public string ALARMPEOPLE { get; set; }
        /// <summary>
        /// �����˵绰
        /// </summary>
        /// <returns></returns>
        [Column("ALARMTEL")]
        public string ALARMTEL { get; set; }
        /// <summary>
        /// Ԥ�����ֵص�
        /// </summary>
        /// <returns></returns>
        [Column("BOOKESCAPINGLOCATION")]
        public string BOOKESCAPINGLOCATION { get; set; }
        /// <summary>
        /// ��Ա����·��
        /// </summary>
        /// <returns></returns>
        [Column("EVACUATIONROUTES")]
        public string EVACUATIONROUTES { get; set; }
        /// <summary>
        /// ���ν���
        /// </summary>
        /// <returns></returns>
        [Column("TREATMENTSUGGESTION")]
        public string TREATMENTSUGGESTION { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETIME")]
        public DateTime? UPDATETIME1 { get; set; }
        /// <summary>
        /// ��¼״̬
        /// </summary>
        /// <returns></returns>
        [Column("RECORDSTATUS")]
        public string RECORDSTATUS1 { get; set; }
        /// <summary>
        /// ����״̬
        /// </summary>
        /// <returns></returns>
        [Column("EXPSTATUS")]
        public string EXPSTATUS1 { get; set; }
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
        public DateTime? CREATORTIME1 { get; set; }
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
        /// ��Ա����·��ʾ��ͼ
        /// </summary>
        /// <returns></returns>
        [Column("EVACUATIONROUTESPIC")]
        public string EVACUATIONROUTESPIC { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENPOINTTYPE")]
        public string HIDDENPOINTTYPE { get; set; }
        /// <summary>
        /// ���������ID
        /// </summary>
        /// <returns></returns>
        [Column("MONITORRESPONSIBLEID")]
        public string MONITORRESPONSIBLEID { get; set; }
        /// <summary>
        /// Ⱥ��Ⱥ����ԱID
        /// </summary>
        /// <returns></returns>
        [Column("GROUPMONITORINGSTAFFID")]
        public string GROUPMONITORINGSTAFFID { get; set; }
        /// <summary>
        /// ������ID
        /// </summary>
        /// <returns></returns>
        [Column("ALARMPEOPLEID")]
        public string ALARMPEOPLEID { get; set; }
        /// <summary>
        /// GUID
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
    public class TBL_QCQF_Entity
    {
        public string UNIFIEDCODE { get; set; }
        public string DISASTERNAME { get; set; }
        public string LOCATION { get; set; }
        public string PROVINCE { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITY { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTY { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWN { get; set; }
        public string TOWNNAME { get; set; }
        public string DISASTERTYPE { get; set; }
        public string GROUPMONITORINGSTAFF { get; set; }
        public string GROUPMONITORINGSTAFFTEL { get; set; }
        public string MONITORRESPONSIBLE { get; set; }
        public string MONITORRESPONSIBLETEL { get; set; }
        public string GROUPMONITORINGSTAFFID { get; set; }
    }
}