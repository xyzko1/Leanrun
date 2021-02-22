using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-26 10:50
    /// �� ����������������
    /// </summary>
    public class TBL_LANDSETTLEMENTEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ͳһ���
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// CGHϵͳ�ֺ������
        /// </summary>
        /// <returns></returns>
        [Column("CGHUNIFIEDCODE")]
        public string CGHUNIFIEDCODE { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERUNITNAME")]
        public string DISASTERUNITNAME { get; set; }
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
        /// ʡ
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        /// <summary>
        /// �У��أ�
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
        /// <summary>
        /// ����λ�ã��壩
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        public string LOCATION { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        public string LONGITUDE { get; set; }
        /// <summary>
        /// γ��
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        public string LATITUDE { get; set; }
        /// <summary>
        /// X����
        /// </summary>
        /// <returns></returns>
        [Column("X")]
        public decimal? X { get; set; }
        /// <summary>
        /// Y����
        /// </summary>
        /// <returns></returns>
        [Column("Y")]
        public decimal? Y { get; set; }
        /// <summary>
        /// Z����
        /// </summary>
        /// <returns></returns>
        [Column("Z")]
        public decimal? Z { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENTIME")]
        public string HAPPENTIME { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("SETTLEMENTTYPE")]
        public string SETTLEMENTTYPE { get; set; }
        /// <summary>
        /// ��������λ��
        /// </summary>
        /// <returns></returns>
        [Column("SETTLEMENTCENTERLOCATION")]
        public string SETTLEMENTCENTERLOCATION { get; set; }
        /// <summary>
        /// �������ľ���
        /// </summary>
        /// <returns></returns>
        [Column("SETTLEMENTCENTERLONGITUDE")]
        public decimal? SETTLEMENTCENTERLONGITUDE { get; set; }
        /// <summary>
        /// ��������γ��
        /// </summary>
        /// <returns></returns>
        [Column("SETTLEMENTCENTERLATITUDE")]
        public decimal? SETTLEMENTCENTERLATITUDE { get; set; }
        /// <summary>
        /// ���������
        /// </summary>
        /// <returns></returns>
        [Column("SETTLEMENTAREA")]
        public decimal? SETTLEMENTAREA { get; set; }
        /// <summary>
        /// ��ƽ��������
        /// </summary>
        /// <returns></returns>
        [Column("AVERAGEYEARSETTLEMENTVOLUME")]
        public decimal? AVERAGEYEARSETTLEMENTVOLUME { get; set; }
        /// <summary>
        /// �����ۼƳ�����
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIVESETTLEMENTVOLUME")]
        public decimal? ACCUMULATIVESETTLEMENTVOLUME { get; set; }
        /// <summary>
        /// ƽ����������
        /// </summary>
        /// <returns></returns>
        [Column("AVERAGESETTLEMENTRATE")]
        public decimal? AVERAGESETTLEMENTRATE { get; set; }
        /// <summary>
        /// ���ε�ò
        /// </summary>
        /// <returns></returns>
        [Column("TOPOGRAPHY")]
        public string TOPOGRAPHY { get; set; }
        /// <summary>
        /// ���ʹ��켰����
        /// </summary>
        /// <returns></returns>
        [Column("GEOLOGICALSTRUCTURE")]
        public string GEOLOGICALSTRUCTURE { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("LITH")]
        public string LITH { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("DEPTH")]
        public string DEPTH { get; set; }
        /// <summary>
        /// �ṹ
        /// </summary>
        /// <returns></returns>
        [Column("ARCH")]
        public string ARCH { get; set; }
        /// <summary>
        /// �ռ�仯����
        /// </summary>
        /// <returns></returns>
        [Column("SPACECHANGELAW")]
        public string SPACECHANGELAW { get; set; }
        /// <summary>
        /// ˮ�ĵ�������
        /// </summary>
        /// <returns></returns>
        [Column("HYDROLOGYGEOLOGYFEATURE")]
        public string HYDROLOGYGEOLOGYFEATURE { get; set; }
        /// <summary>
        /// ��Ҫ������λ
        /// </summary>
        /// <returns></returns>
        [Column("MAINSETTLEMENTLOCATION")]
        public string MAINSETTLEMENTLOCATION { get; set; }
        /// <summary>
        /// �꿪����
        /// </summary>
        /// <returns></returns>
        [Column("YEARMININGVOLUME")]
        public decimal? YEARMININGVOLUME { get; set; }
        /// <summary>
        /// �겹����
        /// </summary>
        /// <returns></returns>
        [Column("YEARSUPPLYVOLUME")]
        public decimal? YEARSUPPLYVOLUME { get; set; }
        /// <summary>
        /// ����ˮ����
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATERDEPTH")]
        public decimal? GROUNDWATERDEPTH { get; set; }
        /// <summary>
        /// ��ˮλ�仯����
        /// </summary>
        /// <returns></returns>
        [Column("YEARWATLEVCHANGEMARGIN")]
        public decimal? YEARWATLEVCHANGEMARGIN { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("OTHER")]
        public string OTHER { get; set; }
        /// <summary>
        /// �շ�����ԭ��
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDSUBSIDENCECAUSES")]
        public string INDUCEDSUBSIDENCECAUSES { get; set; }
        /// <summary>
        /// �仯����
        /// </summary>
        /// <returns></returns>
        [Column("CHANGELAW")]
        public string CHANGELAW { get; set; }
        /// <summary>
        /// ������״
        /// </summary>
        /// <returns></returns>
        [Column("SETTLEMENTCURRENTSITUATION")]
        public string SETTLEMENTCURRENTSITUATION { get; set; }
        /// <summary>
        /// ��չ����
        /// </summary>
        /// <returns></returns>
        [Column("DEVELOPMENTTREND")]
        public string DEVELOPMENTTREND { get; set; }
        /// <summary>
        /// ��ҪΣ��
        /// </summary>
        /// <returns></returns>
        [Column("MAINHARM")]
        public string MAINHARM { get; set; }
        /// <summary>
        /// ������ʧ
        /// </summary>
        /// <returns></returns>
        [Column("ECONOMICLOSSES")]
        public decimal? ECONOMICLOSSES { get; set; }
        /// <summary>
        /// �����ʩ
        /// </summary>
        /// <returns></returns>
        [Column("CONTROLMEASURES")]
        public string CONTROLMEASURES { get; set; }
        /// <summary>
        /// ����Ч��
        /// </summary>
        /// <returns></returns>
        [Column("CONTROLEFFECT")]
        public string CONTROLEFFECT { get; set; }
        /// <summary>
        /// ���鸺����
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYHEADER")]
        public string SURVEYHEADER { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEPEOPLE")]
        public string FILLTABLEPEOPLE { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [Column("VERIFYPEOPLE")]
        public string VERIFYPEOPLE { get; set; }
        /// <summary>
        /// ���鵥λ
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYDEPT")]
        public string SURVEYDEPT { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEDATE")]
        public DateTime? FILLTABLEDATE { get; set; }
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
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("CONTROLSTATE")]
        public string CONTROLSTATE { get; set; }
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
        /// ����Ԥ��
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONPLAN")]
        public string PREVENTIONPLAN { get; set; }
        /// <summary>
        /// ��Ŀ���
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTID")]
        public string PROJECTID { get; set; }
        /// <summary>
        /// ͼ�����
        /// </summary>
        /// <returns></returns>
        [Column("MAPID")]
        public string MAPID { get; set; }
        /// <summary>
        /// ͼ������
        /// </summary>
        /// <returns></returns>
        [Column("MAPNAME")]
        public string MAPNAME { get; set; }
        /// <summary>
        /// ���б��
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYCODE")]
        public string COUNTYCODE { get; set; }
        /// <summary>
        /// ң�н���㣨0����1���ǣ�
        /// </summary>
        /// <returns></returns>
        [Column("ISRSPNT")]
        public string ISRSPNT { get; set; }
        /// <summary>
        /// ����㣨0����1���ǣ�
        /// </summary>
        /// <returns></returns>
        [Column("ISSURVEYPNT")]
        public string ISSURVEYPNT { get; set; }
        /// <summary>
        /// ���㣨0����1���ǣ�
        /// </summary>
        /// <returns></returns>
        [Column("ISMEASURINGPNT")]
        public string ISMEASURINGPNT { get; set; }
        /// <summary>
        /// �Ƿ������㣨0����1���ǣ�
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENDANGER")]
        public string HIDDENDANGER { get; set; }
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
        /// �����������ˣ�
        /// </summary>
        /// <returns></returns>
        [Column("DEATHSPEOPLE")]
        public int? DEATHSPEOPLE { get; set; }
        /// <summary>
        /// ֱ����ʧ����Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTLOSS")]
        public decimal? DIRECTLOSS { get; set; }
        /// <summary>
        /// ��в���ݣ�����
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOME")]
        public int? THREATENHOME { get; set; }
        /// <summary>
        /// ��в�������ˣ�
        /// </summary>
        /// <returns></returns>
        [Column("THREATENPEOPLE")]
        public int? THREATENPEOPLE { get; set; }
        /// <summary>
        /// ��в�Ʋ�����Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("THREATENASSETS")]
        public decimal? THREATENASSETS { get; set; }
        /// <summary>
        /// Σ������
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDOBJECT")]
        public string DESTROYEDOBJECT { get; set; }
        /// <summary>
        /// ��в����
        /// </summary>
        /// <returns></returns>
        [Column("THREATENOBJECT")]
        public string THREATENOBJECT { get; set; }
        /// <summary>
        /// Ұ���¼��Ϣ
        /// </summary>
        /// <returns></returns>
        [Column("OUTDOORRECORD")]
        public string OUTDOORRECORD { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("RIVERBASIN")]
        public string RIVERBASIN { get; set; }
        /// <summary>
        /// ʧ������
        /// </summary>
        /// <returns></returns>
        [Column("MISSINGPERSON")]
        public int? MISSINGPERSON { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("INJUREDPERSON")]
        public int? INJUREDPERSON { get; set; }
        /// <summary>
        /// �Ƿ�������
        /// </summary>
        /// <returns></returns>
        [Column("ISZLGCPNT")]
        public string ISZLGCPNT { get; set; }
        /// <summary>
        /// �Ƿ��м���
        /// </summary>
        /// <returns></returns>
        [Column("ISMONITORPNT")]
        public string ISMONITORPNT { get; set; }
        /// <summary>
        /// ң�н���
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERSID")]
        public string DISASTERSID { get; set; }
        /// <summary>
        /// ������(���)
        /// </summary>
        /// <returns></returns>
        [Column("UPDATEUSER")]
        public string UPDATEUSER { get; set; }
        /// <summary>
        /// ���鸺����ID
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYHEADERID")]
        public string SURVEYHEADERID { get; set; }
        /// <summary>
        /// �����ID
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEPEOPLEID")]
        public string FILLTABLEPEOPLEID { get; set; }
        /// <summary>
        /// �����ID
        /// </summary>
        /// <returns></returns>
        [Column("VERIFYPEOPLEID")]
        public string VERIFYPEOPLEID { get; set; }
        /// <summary>
        /// ���鵥λID
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYDEPTID")]
        public string SURVEYDEPTID { get; set; }
        /// <summary>
        /// ����ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERLEVEL")]
        public string DISASTERLEVEL { get; set; }
        /// <summary>
        /// ����ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DANGERLEVEL")]
        public string DANGERLEVEL { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// LOCATIONOLD
        /// </summary>
        /// <returns></returns>
        [Column("LOCATIONOLD")]
        public string LOCATIONOLD { get; set; }

        /// <summary>
        /// ������ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERRISKLEVEL")]
        public string DISASTERRISKLEVEL { get; set; }
        /// <summary>
        /// Ŀǰ�ȶ�״̬
        /// </summary>
        /// <returns></returns>
        [Column("CURSTABLESTATUS")]
        public string CURSTABLESTATUS { get; set; }
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
        /// ������
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
        /// �Ƿ��ش�������
        /// </summary>
        /// <returns></returns>
        [Column("ISZDYHD")]
        public string ISZDYHD { get; set; }
        /// <summary>
        /// ������Դ
        /// </summary>
        /// <returns></returns>
        [Column("DATASOURCE")]
        public string DATASOURCE { get; set; }
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
