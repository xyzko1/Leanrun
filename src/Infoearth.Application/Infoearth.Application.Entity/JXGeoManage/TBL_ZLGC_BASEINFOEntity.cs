using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-05-09 14:53
    /// �� ������������Ϣ��
    /// </summary>
    public class TBL_ZLGC_BASEINFOEntity : BaseEntity
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
        /// �ֺ�������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERNAME")]
        public string DISASTERNAME { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCNAME")]
        public string ZLGCNAME { get; set; }
        /// <summary>
        /// ʡ
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// ʡ���
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        /// <summary>
        /// �У��ݣ�
        /// </summary>
        /// <returns></returns>
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// �У��ݣ����
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        /// <summary>
        /// �����أ�
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
        /// <summary>
        /// �����أ����
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGE")]
        public string VILLAGE { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("TEAM")]
        public string TEAM { get; set; }
        /// <summary>
        /// ���̵���λ��
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        public string LOCATION { get; set; }
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
        /// �ֺ�����������
        /// </summary>
        /// <returns></returns>
        [Column("ZHDZLQS")]
        public string ZHDZLQS { get; set; }
        /// <summary>
        /// ʩ��ͼ��ƿ�ʼʱ��
        /// </summary>
        /// <returns></returns>
        [Column("DESIGNSTARTTIME")]
        public DateTime? DESIGNSTARTTIME { get; set; }
        /// <summary>
        /// ʩ��ͼ��ƽ���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("DESIGNENDTIME")]
        public DateTime? DESIGNENDTIME { get; set; }
        /// <summary>
        /// �б�׶ο�ʼʱ��
        /// </summary>
        /// <returns></returns>
        [Column("TENDERSTARTTIME")]
        public DateTime? TENDERSTARTTIME { get; set; }
        /// <summary>
        /// �б�׶ν���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("TENDERENDTIME")]
        public DateTime? TENDERENDTIME { get; set; }
        /// <summary>
        /// ʩ���׶ο�ʼʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONSTARTTIME")]
        public DateTime? CONSTRUCTIONSTARTTIME { get; set; }
        /// <summary>
        /// ʩ���׶ν���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONENDTIME")]
        public DateTime? CONSTRUCTIONENDTIME { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("BEGINNINGTIME")]
        public DateTime? BEGINNINGTIME { get; set; }
        /// <summary>
        /// ��������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("APPLYTIME")]
        public DateTime? APPLYTIME { get; set; }
        /// <summary>
        /// �������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("ACCEPTANCETIME")]
        public DateTime? ACCEPTANCETIME { get; set; }
        /// <summary>
        /// ��Ŀ��ܵ�λ
        /// </summary>
        /// <returns></returns>
        [Column("REGULATORS")]
        public string REGULATORS { get; set; }
        /// <summary>
        /// ��Ŀʵʩ��λ
        /// </summary>
        /// <returns></returns>
        [Column("IMPLEMENTATION")]
        public string IMPLEMENTATION { get; set; }
        /// <summary>
        /// ������Ҫ��������
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONCONTENT")]
        public string CONSTRUCTIONCONTENT { get; set; }
        /// <summary>
        /// ��Ŀ�´�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("GIVETIME")]
        public DateTime? GIVETIME { get; set; }
        /// <summary>
        /// ��Ŀ�����´��ĺ�
        /// </summary>
        /// <returns></returns>
        [Column("GIVENUMBER")]
        public string GIVENUMBER { get; set; }
        /// <summary>
        /// Ԥ���깤ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("COMPLETIONTIME")]
        public DateTime? COMPLETIONTIME { get; set; }
        /// <summary>
        /// ���鵥λ
        /// </summary>
        /// <returns></returns>
        [Column("PROSPECTING")]
        public string PROSPECTING { get; set; }
        /// <summary>
        /// ��Ƶ�λ
        /// </summary>
        /// <returns></returns>
        [Column("DESIGN")]
        public string DESIGN { get; set; }
        /// <summary>
        /// ����λ
        /// </summary>
        /// <returns></returns>
        [Column("SUPERVISION")]
        public string SUPERVISION { get; set; }
        /// <summary>
        /// �����ֳ�������
        /// </summary>
        /// <returns></returns>
        [Column("SUPERVISIONPEOPLEP")]
        public string SUPERVISIONPEOPLEP { get; set; }
        /// <summary>
        /// �����ֳ������˵绰
        /// </summary>
        /// <returns></returns>
        [Column("SUPERVISIONPHONE")]
        public string SUPERVISIONPHONE { get; set; }
        /// <summary>
        /// ʩ����λ
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTION")]
        public string CONSTRUCTION { get; set; }
        /// <summary>
        /// ʩ�����ֳ�������
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONPEOPLE")]
        public string CONSTRUCTIONPEOPLE { get; set; }
        /// <summary>
        /// �����ֳ������˵绰
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONPHONE")]
        public string CONSTRUCTIONPHONE { get; set; }
        /// <summary>
        /// Ԥ���ʽ���Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("BUDGET")]
        public decimal? BUDGET { get; set; }
        /// <summary>
        /// �´��ʽ���Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("ISSUEDCAPITAL")]
        public decimal? ISSUEDCAPITAL { get; set; }
        /// <summary>
        /// ��������ʽ���Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("CENTRALFUNDS")]
        public decimal? CENTRALFUNDS { get; set; }
        /// <summary>
        /// �����ʽ���Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("FINALMONEY")]
        public decimal? FINALMONEY { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("NOTE")]
        public string NOTE { get; set; }
        /// <summary>
        /// �ؼ������
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYPEOPLE")]
        public string COUNTYPEOPLE { get; set; }
        /// <summary>
        /// �ؼ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYTIME")]
        public DateTime? COUNTYTIME { get; set; }
        /// <summary>
        /// �ؼ�������
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYOPINION")]
        public string COUNTYOPINION { get; set; }
        /// <summary>
        /// �м������
        /// </summary>
        /// <returns></returns>
        [Column("CITYPEOPLE")]
        public string CITYPEOPLE { get; set; }
        /// <summary>
        /// �м����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CITYTIME")]
        public DateTime? CITYTIME { get; set; }
        /// <summary>
        /// �м�������
        /// </summary>
        /// <returns></returns>
        [Column("CITYOPINION")]
        public string CITYOPINION { get; set; }
        /// <summary>
        /// ��ע1
        /// </summary>
        /// <returns></returns>
        [Column("BZ")]
        public string BZ { get; set; }
        /// <summary>
        /// ԭ���
        /// </summary>
        /// <returns></returns>
        [Column("OLDUNIFIEDCODE")]
        public string OLDUNIFIEDCODE { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public DateTime? CREATETIME { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("CREATEUSER")]
        public string CREATEUSER { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYTIME")]
        public DateTime? MODIFYTIME { get; set; }
        /// <summary>
        /// �޸���
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYUSER")]
        public string MODIFYUSER { get; set; }
        /// <summary>
        /// ��Ŀ��׼����
        /// </summary>
        /// <returns></returns>
        [Column("XMPZBM")]
        public string XMPZBM { get; set; }
        /// <summary>
        /// �ֺ�������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        /// <summary>
        /// ��Ŀ��׼�ĺ�
        /// </summary>
        /// <returns></returns>
        [Column("XMPZWH")]
        public string XMPZWH { get; set; }
        /// <summary>
        /// ��Ŀ���赥λ
        /// </summary>
        /// <returns></returns>
        [Column("XMJSDW")]
        public string XMJSDW { get; set; }
        /// <summary>
        /// ��Ŀ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("XMJLXSJ")]
        public DateTime? XMJLXSJ { get; set; }
        /// <summary>
        /// ��Ŀ�����ʽ���Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("XMPFZJ")]
        public decimal? XMPFZJ { get; set; }
        /// <summary>
        /// ��Ŀ����λ
        /// </summary>
        /// <returns></returns>
        [Column("XMFZDW")]
        public string XMFZDW { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        [Column("XMXMRW")]
        public string XMXMRW { get; set; }
        /// <summary>
        /// ��Ŀ�׶�
        /// </summary>
        [Column("ZLSTATE")]
        public string ZLSTATE { get; set; }
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
    public class PASTBL_ZLGC_BASEINFOEntity
    {
        public string MEDIAGUID { get; set; }
        public string GUID { get; set; }
    }
}