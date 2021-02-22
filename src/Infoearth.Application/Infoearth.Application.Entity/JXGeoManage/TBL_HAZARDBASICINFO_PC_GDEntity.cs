using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-07 16:09
    /// �� �����Ų����ݱ�
    /// </summary>
    public class TBL_HAZARDBASICINFO_PC_GDEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// �ֺ�������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        [Column("TOWN")]
        public string TOWN { get; set; }
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }             
        /// <summary>
        /// �Ų���
        /// </summary>
        /// <returns></returns>
        [Column("PCUNIFIEDCODE")]
        public string PCUNIFIEDCODE { get; set; }
        /// <summary>
        /// ͳһ���
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// ��/��
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
        /// <summary>
        /// ������λ��
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        public string LOCATION { get; set; }
        /// <summary>
        /// ������״̬
        /// </summary>
        /// <returns></returns>
        [Column("YHSTATE")]
        public string YHSTATE { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        public decimal? LONGITUDE { get; set; }
        /// <summary>
        /// γ��
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        public decimal? LATITUDE { get; set; }
        /// <summary>
        /// �ֺ����ģ
        /// </summary>
        /// <returns></returns>
        [Column("SCALE")]
        public string SCALE { get; set; }
        /// <summary>
        /// �ȶ���
        /// </summary>
        /// <returns></returns>
        [Column("CURSTABLESTATUS")]
        public string CURSTABLESTATUS { get; set; }
        /// <summary>
        /// X
        /// </summary>
        /// <returns></returns>
        [Column("X")]
        public string X { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        /// <returns></returns>
        [Column("Y")]
        public string Y { get; set; }
        /// <summary>
        /// Ǳ�ھ�����ʧ/��Ԫ
        /// </summary>
        /// <returns></returns>
        [Column("INDIRECTLOSS")]
        public string INDIRECTLOSS { get; set; }
        /// <summary>
        /// ���������
        /// </summary>
        /// <returns></returns>
        [Column("MONITORINGPEOPLE")]
        public string MONITORINGPEOPLE { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE")]
        public string TELEPHONE { get; set; }
        /// <summary>
        /// �ֻ�
        /// </summary>
        /// <returns></returns>
        [Column("PHONE")]
        public string PHONE { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [Column("JCPEOPLE")]
        public string JCPEOPLE { get; set; }
        /// <summary>
        /// ��ϵ�绰1
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE1")]
        public string TELEPHONE1 { get; set; }
        /// <summary>
        /// �ֻ�1
        /// </summary>
        /// <returns></returns>
        [Column("PHONE1")]
        public string PHONE1 { get; set; }
        /// <summary>
        /// ���ζԲ�
        /// </summary>
        /// <returns></returns>
        [Column("COUNTERMEASURES")]
        public string COUNTERMEASURES { get; set; }
        /// <summary>
        /// ��ûӦ��Ԥ��
        /// </summary>
        /// <returns></returns>
        [Column("YJPLAN")]
        public string YJPLAN { get; set; }
        /// <summary>
        /// ������ʩ
        /// </summary>
        /// <returns></returns>
        [Column("WORKMEASURES")]
        public string WORKMEASURES { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("REMARKS")]
        public string REMARKS { get; set; }
        /// <summary>
        /// �ֵ�/��
        /// </summary>
        /// <returns></returns>
        [Column("STREET")]
        public string STREET { get; set; }
        /// <summary>
        /// Σ����
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDOBJECT")]
        public string DESTROYEDOBJECT { get; set; }
        /// <summary>
        /// ��в��Ա
        /// </summary>
        /// <returns></returns>
        [Column("THREATENPEOPLE")]
        public string THREATENPEOPLE { get; set; }
        /// <summary>
        /// �ϱ���Դ��1Ϊ�ֻ��ˣ�
        /// </summary>
        /// <returns></returns>
        [Column("REPORTLY")]
        public string REPORTLY { get; set; }
        /// <summary>
        /// �ϴ���
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADER")]
        public string UPLOADER { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENDATE")]
        public DateTime? HAPPENDATE { get; set; }
        /// <summary>
        /// �Ų�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("PCTIME")]
        public DateTime? PCTIME { get; set; }
        /// <summary>
        /// �ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("FILETIME")]
        public DateTime? FILETIME { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("SHTIME")]
        public DateTime? SHTIME { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [Column("VERIFYPEOPLE")]
        public string VERIFYPEOPLE { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("SHOPINION")]
        public string SHOPINION { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("OCCURREDTIME")]
        public DateTime? OCCURREDTIME { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEPEOPLE")]
        public string FILLTABLEPEOPLE { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.PCUNIFIEDCODE = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.PCUNIFIEDCODE = keyValue;
        }
        #endregion
    }
}