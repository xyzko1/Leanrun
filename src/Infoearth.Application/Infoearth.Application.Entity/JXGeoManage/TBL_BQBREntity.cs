using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-18 15:13
    /// �� ������Ǩ������Ϣ��
    /// </summary>
    public class TBL_BQBREntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// �ֺ�������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERNAME")]
        public string DISASTERNAME { get; set; }
        /// <summary>
        /// �ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// ʡ����
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
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// �б��
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
        /// <summary>
        /// �ر��
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }
        /// <summary>
        /// ��������
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
        /// ����λ��
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
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("ANNUAL")]
        public string ANNUAL { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEHOLDERNAME")]
        public string HOUSEHOLDERNAME { get; set; }
        /// <summary>
        /// ���÷�ʽ
        /// </summary>
        /// <returns></returns>
        [Column("RESETTLEMENT")]
        public string RESETTLEMENT { get; set; }
        /// <summary>
        /// ������Ǩ����
        /// </summary>
        /// <returns></returns>
        [Column("MOVEDECIMAL")]
        public long? MOVEDECIMAL { get; set; }
        /// <summary>
        /// ���л��÷�ɢ������
        /// </summary>
        /// <returns></returns>
        [Column("RESETTLEMENTNAME")]
        public string RESETTLEMENTNAME { get; set; }
        /// <summary>
        /// Ѵ���������õ�����
        /// </summary>
        /// <returns></returns>
        [Column("FLOODRESETTLEMENTNAME")]
        public string FLOODRESETTLEMENTNAME { get; set; }
        /// <summary>
        /// ����������סʱ��
        /// </summary>
        /// <returns></returns>
        [Column("RESETTLEMENTTIME")]
        public DateTime? RESETTLEMENTTIME { get; set; }
        /// <summary>
        /// ԭַ�Ƿ���
        /// </summary>
        /// <returns></returns>
        [Column("ISDEMOLITION")]
        public string ISDEMOLITION { get; set; }
        /// <summary>
        /// �ɷ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("DEMOLITIONTIME")]
        public DateTime? DEMOLITIONTIME { get; set; }
        /// <summary>
        /// ���л��ɢ������סʱ��
        /// </summary>
        /// <returns></returns>
        [Column("SCATTEREDRESETTLEMENTTIME")]
        public DateTime? SCATTEREDRESETTLEMENTTIME { get; set; }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        /// <returns></returns>
        [Column("ISCOMPLETE")]
        public string ISCOMPLETE { get; set; }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        /// <returns></returns>
        [Column("ISACCEPTANCE")]
        public string ISACCEPTANCE { get; set; }
        /// <summary>
        /// Ǩ����Ƿ���ڵ�������
        /// </summary>
        /// <returns></returns>
        [Column("ISHIDDENDANGER")]
        public string ISHIDDENDANGER { get; set; }
        /// <summary>
        /// Ǩ����������������������
        /// </summary>
        /// <returns></returns>
        [Column("SITUATION")]
        public string SITUATION { get; set; }
        /// <summary>
        /// �԰�Ǩ������ͬ���
        /// </summary>
        /// <returns></returns>
        [Column("IDENTITY")]
        public string IDENTITY { get; set; }
        /// <summary>
        /// ��ͬ���ԭ��
        /// </summary>
        /// <returns></returns>
        [Column("IDENTITYWHY")]
        public string IDENTITYWHY { get; set; }
        /// <summary>
        /// �Ƿ�ʾ
        /// </summary>
        /// <returns></returns>
        [Column("ISOFPUBLIC")]
        public string ISOFPUBLIC { get; set; }
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
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("BZ001")]
        public string BZ001 { get; set; }
        /// <summary>
        /// �ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("BZ002")]
        public string BZ002 { get; set; }
        /// <summary>
        /// ��չ�ֶ�3
        /// </summary>
        /// <returns></returns>
        [Column("BZ003")]
        public string BZ003 { get; set; }
        /// <summary>
        /// ��չ�ֶ�4
        /// </summary>
        /// <returns></returns>
        [Column("BZ004")]
        public string BZ004 { get; set; }
        /// <summary>
        /// ��չ�ֶ�5
        /// </summary>
        /// <returns></returns>
        [Column("BZ005")]
        public string BZ005 { get; set; }
        /// <summary>
        /// Ұ����
        /// </summary>
        /// <returns></returns>
        [Column("OUTDOORCODE")]
        public string OUTDOORCODE { get; set; }
        /// <summary>
        /// ���ڱ��
        /// </summary>
        /// <returns></returns>
        [Column("INDOORCODE")]
        public string INDOORCODE { get; set; }
        /// <summary>
        /// ��Ǩ������
        /// </summary>
        /// <returns></returns>
        [Column("MINENATURE")]
        public string MINENATURE { get; set; }
        /// <summary>
        /// ʡ������
        /// </summary>
        /// <returns></returns>
        [Column("SHENGGRANT")]
        public string SHENGGRANT { get; set; }
        /// <summary>
        /// �в�����
        /// </summary>
        /// <returns></returns>
        [Column("SHIGRANT")]
        public string SHIGRANT { get; set; }
        /// <summary>
        /// �ز�����
        /// </summary>
        /// <returns></returns>
        [Column("XIANGRANT")]
        public string XIANGRANT { get; set; }
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
        /// �ֺ�������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }


        /// <summary>
        /// ���õ�����
        /// </summary>
        /// <returns></returns>
        [Column("AZDMC")]
        public string AZDMC { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        [Column("XMMC")]
        public string XMMC { get; set; }
        /// <summary>
        /// ��Ǩԭ��
        /// </summary>
        /// <returns></returns>
        [Column("BQYY")]
        public string BQYY { get; set; }
        /// <summary>
        /// ���õ��Ƿ��������
        /// </summary>
        /// <returns></returns>
        [Column("ISYH")]
        public string ISYH { get; set; }
        /// <summary>
        /// �ɻ�����ַ
        /// </summary>
        /// <returns></returns>
        [Column("OLDHJDZ")]
        public string OLDHJDZ { get; set; }
        /// <summary>
        /// �ɷ���ַ
        /// </summary>
        /// <returns></returns>
        [Column("JFDZ")]
        public string JFDZ { get; set; }
        /// <summary>
        /// �ɷ����
        /// </summary>
        /// <returns></returns>
        [Column("JFMJ")]
        public decimal? JFMJ { get; set; }
        /// <summary>
        /// �ɷ�����
        /// </summary>
        /// <returns></returns>
        [Column("JFJD")]
        public decimal? JFJD { get; set; }
        /// <summary>
        /// �ɷ�γ��
        /// </summary>
        /// <returns></returns>
        [Column("JFWD")]
        public decimal? JFWD { get; set; }
        /// <summary>
        /// �»�����ַ
        /// </summary>
        /// <returns></returns>
        [Column("NEWHJDZ")]
        public string NEWHJDZ { get; set; }
        /// <summary>
        /// �·���ַ
        /// </summary>
        /// <returns></returns>
        [Column("XFDZ")]
        public string XFDZ { get; set; }
        /// <summary>
        /// �·����
        /// </summary>
        /// <returns></returns>
        [Column("XFMJ")]
        public decimal? XFMJ { get; set; }
        /// <summary>
        /// �·�����
        /// </summary>
        /// <returns></returns>
        [Column("XFJD")]
        public decimal? XFJD { get; set; }
        /// <summary>
        /// �·�γ��
        /// </summary>
        /// <returns></returns>
        [Column("XFWD")]
        public decimal? XFWD { get; set; }
        /// <summary>
        /// �·�����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("XFJCDATA")]
        public DateTime? XFJCDATA { get; set; }
        /// <summary>
        /// �·�Ǩ��ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("XFQRDATA")]
        public DateTime? XFQRDATA { get; set; }
        /// <summary>
        /// �ɷ����˵��
        /// </summary>
        /// <returns></returns>
        [Column("JFCCSM")]
        public string JFCCSM { get; set; }
        /// <summary>
        /// ������׼
        /// </summary>
        /// <returns></returns>
        [Column("BZBZ")]
        public string BZBZ { get; set; }
        /// <summary>
        /// ���ŵ�λ
        /// </summary>
        /// <returns></returns>
        [Column("FFDW")]
        public string FFDW { get; set; }
        /// <summary>
        /// �ܰ��ò������
        /// </summary>
        /// <returns></returns>
        [Column("ZAZBTJE")]
        public string ZAZBTJE { get; set; }
        /// <summary>
        /// �ѷ����
        /// </summary>
        /// <returns></returns>
        [Column("YFJE")]
        public string YFJE { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("DFJR")]
        public string DFJR { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("FFSJ")]
        public DateTime? FFSJ { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("JSR")]
        public string JSR { get; set; }
        /// <summary>
        /// ��������ƶ����
        /// </summary>
        /// <returns></returns>
        [Column("JDLK")]
        public string JDLK { get; set; }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        /// <returns></returns>
        [Column("SFWC")]
        public string SFWC { get; set; }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        /// <returns></returns>
        [Column("SFYS")]
        public string SFYS { get; set; }
        /// <summary>
        /// �Ƿ�ʾ
        /// </summary>
        /// <returns></returns>
        [Column("SFGS")]
        public string SFGS { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        [Column("HXGZJY")]
        public string HXGZJY { get; set; }
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