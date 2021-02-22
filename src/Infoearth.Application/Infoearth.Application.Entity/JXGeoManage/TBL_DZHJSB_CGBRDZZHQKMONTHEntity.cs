using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-10 09:57
    /// �� ����TBL_DZHJSB_CGBRDZZHQKMONTH
    /// </summary>
    public class TBL_DZHJSB_CGBRDZZHQKMONTHEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// Ψһ��ʶ
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ����Ԥ������
        /// </summary>
        /// <returns></returns>
        [Column("SENDDATE")]
        public DateTime? SENDDATE { get; set; }
        /// <summary>
        /// Ԥ��ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("YBTIME")]
        public string YBTIME { get; set; }
        /// <summary>
        /// �ֺ���������
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENDATE")]
        public DateTime? HAPPENDATE { get; set; }
        /// <summary>
        /// �ֺ�����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENTIME")]
        public string HAPPENTIME { get; set; }
        /// <summary>
        /// �����������
        /// </summary>
        /// <returns></returns>
        [Column("DISTRICTCODE")]
        public string DISTRICTCODE { get; set; }
        /// <summary>
        /// ʡ
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        /// <summary>
        /// �أ���)
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
        /// <summary>
        /// ʡ����
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// �أ���������
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
        /// <summary>
        /// ���鼰����ص�
        /// </summary>
        /// <returns></returns>
        [Column("SPECIFICLOCATION")]
        public string SPECIFICLOCATION { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERYEAR")]
        public short? DISASTERYEAR { get; set; }
        /// <summary>
        /// �·�
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERMONTH")]
        public short? DISASTERMONTH { get; set; }
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
        /// ���ȣ��ȷ��룩
        /// </summary>
        /// <returns></returns>
        [Column("LON")]
        public string LON { get; set; }
        /// <summary>
        /// γ�ȣ��ȷ��룩
        /// </summary>
        /// <returns></returns>
        [Column("LAT")]
        public string LAT { get; set; }
        /// <summary>
        /// Ԥ�������ͱ��ִ�ʩ
        /// </summary>
        /// <returns></returns>
        [Column("YBFFHBZCS")]
        public string YBFFHBZCS { get; set; }
        /// <summary>
        /// �ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("ZHLX")]
        public string ZHLX { get; set; }
        /// <summary>
        /// �ֺ���ģ
        /// </summary>
        /// <returns></returns>
        [Column("ZHGM")]
        public short? ZHGM { get; set; }
        /// <summary>
        /// ����ת���˿ڣ��ˣ�
        /// </summary>
        /// <returns></returns>
        [Column("JJZYRK")]
        public short? JJZYRK { get; set; }
        /// <summary>
        /// ���⾭����ʧ����Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("BMJJSS")]
        public decimal? BMJJSS { get; set; }
        /// <summary>
        /// ���������˿ڣ��ˣ�
        /// </summary>
        /// <returns></returns>
        [Column("BMSWRK")]
        public short? BMSWRK { get; set; }
        /// <summary>
        /// Ԥ���˻�λ
        /// </summary>
        /// <returns></returns>
        [Column("FORECASTUNIT")]
        public string FORECASTUNIT { get; set; }
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