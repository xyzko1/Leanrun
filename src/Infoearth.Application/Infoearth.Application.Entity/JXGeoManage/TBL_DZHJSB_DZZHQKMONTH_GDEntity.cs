using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-15 15:38
    /// �� ����Ѳ�������������
    /// </summary>
    public class TBL_DZHJSB_DZZHQKMONTH_GDEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// Ψһ��ʶ
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENDATE")]
        public DateTime? HAPPENDATE { get; set; }
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
        /// �أ�����
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
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTEAR")]
        public short? DISASTERTEAR { get; set; }
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
        /// ����ԭ��
        /// </summary>
        /// <returns></returns>
        [Column("COURSE")]
        public string COURSE { get; set; }
        /// <summary>
        /// ����ԭ��
        /// </summary>
        /// <returns></returns>
        [Column("JTYY")]
        public string JTYY { get; set; }
        /// <summary>
        /// �ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("ZHLX")]
        public string ZHLX { get; set; }
        /// <summary>
        /// �ֺ��ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("ZHDJ")]
        public string ZHDJ { get; set; }
        /// <summary>
        /// ���ֶ���
        /// </summary>
        /// <returns></returns>
        [Column("SZDX")]
        public string SZDX { get; set; }
        /// <summary>
        /// ���ֹ�ģ
        /// </summary>
        /// <returns></returns>
        [Column("ZHGM")]
        public decimal? ZHGM { get; set; }
        /// <summary>
        /// �����˿ڣ��ˣ�
        /// </summary>
        /// <returns></returns>
        [Column("SZRK")]
        public short? SZRK { get; set; }
        /// <summary>
        /// ֱ�Ӿ�����ʧ����Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("ZJJJSS")]
        public decimal? ZJJJSS { get; set; }
        /// <summary>
        /// ���ˣ���)
        /// </summary>
        /// <returns></returns>
        [Column("SS")]
        public short? SS { get; set; }
        /// <summary>
        /// ʧ�٣��ˣ�
        /// </summary>
        /// <returns></returns>
        [Column("SZ")]
        public short? SZ { get; set; }
        /// <summary>
        /// �������ˣ�
        /// </summary>
        /// <returns></returns>
        [Column("SW")]
        public short? SW { get; set; }
        /// <summary>
        /// ����Ӧ�����鱨�棨0�У�1�ޣ�
        /// </summary>
        /// <returns></returns>
        [Column("YWYJDCBG")]
        public string YWYJDCBG { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("OCCURRENCETIME")]
        public string OCCURRENCETIME { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [Column("FILLINPERSON")]
        public string FILLINPERSON { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("REVIEWPERSON")]
        public string REVIEWPERSON { get; set; }
        /// <summary>
        /// �ϱ���Դ(����ˡ��ƶ���)��1Ϊ���Ժ��
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
        /// �Ų���
        /// </summary>
        /// <returns></returns>
        [Column("GEONO")]
        public string GEONO { get; set; }
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