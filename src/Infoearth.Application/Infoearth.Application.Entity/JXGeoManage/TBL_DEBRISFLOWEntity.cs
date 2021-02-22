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
    /// �� ������ʯ�������
    /// </summary>
    public class TBL_DEBRISFLOWEntity : BaseEntity
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
        [Column("LATITUDE")]
        public string LATITUDE { get; set; }
        /// <summary>
        /// γ��
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        public string LONGITUDE { get; set; }
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
        /// �����
        /// </summary>
        /// <returns></returns>
        [Column("ALTTOP")]
        public decimal? ALTTOP { get; set; }
        /// <summary>
        /// ��С���
        /// </summary>
        /// <returns></returns>
        [Column("ALTBOTOM")]
        public decimal? ALTBOTOM { get; set; }
        /// <summary>
        /// ˮϵ����
        /// </summary>
        /// <returns></returns>
        [Column("WATERNAME")]
        public string WATERNAME { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("MRIVERNAME")]
        public string MRIVERNAME { get; set; }
        /// <summary>
        /// �������λ��
        /// </summary>
        /// <returns></returns>
        [Column("MRIVERLOCATION")]
        public string MRIVERLOCATION { get; set; }
        /// <summary>
        /// ���������ӵ���
        /// </summary>
        /// <returns></returns>
        [Column("MIZDISTOMRIVER")]
        public decimal? MIZDISTOMRIVER { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("FLOWDIRECTION")]
        public string FLOWDIRECTION { get; set; }
        /// <summary>
        /// ˮ��������
        /// </summary>
        /// <returns></returns>
        [Column("HYDRODYNAMICTYPE")]
        public string HYDRODYNAMICTYPE { get; set; }
        /// <summary>
        /// ���ھ�ʯA
        /// </summary>
        /// <returns></returns>
        [Column("MIZOGUCHIROCKA")]
        public string MIZOGUCHIROCKA { get; set; }
        /// <summary>
        /// ���ھ�ʯB
        /// </summary>
        /// <returns></returns>
        [Column("MIZOGUCHIROCKB")]
        public string MIZOGUCHIROCKB { get; set; }
        /// <summary>
        /// ���ھ�ʯC
        /// </summary>
        /// <returns></returns>
        [Column("MIZOGUCHIROCKC")]
        public string MIZOGUCHIROCKC { get; set; }
        /// <summary>
        /// ��ɰ����;��
        /// </summary>
        /// <returns></returns>
        [Column("SEDIMENTSUPPLYROUTE")]
        public string SEDIMENTSUPPLYROUTE { get; set; }
        /// <summary>
        /// ������λ��
        /// </summary>
        /// <returns></returns>
        [Column("RECHARGEZONE")]
        public string RECHARGEZONE { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("YEARMAXIMUMRAINFALL")]
        public decimal? YEARMAXIMUMRAINFALL { get; set; }
        /// <summary>
        /// ��ƽ������
        /// </summary>
        /// <returns></returns>
        [Column("YEARAVERAGERAINFALL")]
        public decimal? YEARAVERAGERAINFALL { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("DAYMAXIMUMRAINFALL")]
        public decimal? DAYMAXIMUMRAINFALL { get; set; }
        /// <summary>
        /// ��ƽ������
        /// </summary>
        /// <returns></returns>
        [Column("DAYAVERAGERAINFALL")]
        public decimal? DAYAVERAGERAINFALL { get; set; }
        /// <summary>
        /// ʱ�����
        /// </summary>
        /// <returns></returns>
        [Column("HOURMAXIMUMRAINFALL")]
        public decimal? HOURMAXIMUMRAINFALL { get; set; }
        /// <summary>
        /// ʱƽ������
        /// </summary>
        /// <returns></returns>
        [Column("HOURAVERAGERAINFALL")]
        public decimal? HOURAVERAGERAINFALL { get; set; }
        /// <summary>
        /// ʮ���������
        /// </summary>
        /// <returns></returns>
        [Column("MINUTES10MAXIMUMRAINFALL")]
        public decimal? MINUTES10MAXIMUMRAINFALL { get; set; }
        /// <summary>
        /// ʮ����ƽ������
        /// </summary>
        /// <returns></returns>
        [Column("MINUTES10AVERAGERAINFALL")]
        public decimal? MINUTES10AVERAGERAINFALL { get; set; }
        /// <summary>
        /// �������ε�������
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDINTEGRITY")]
        public decimal? MIZSECTORLANDINTEGRITY { get; set; }
        /// <summary>
        /// �������εر��
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDAMPLITUDE")]
        public decimal? MIZSECTORLANDAMPLITUDE { get; set; }
        /// <summary>
        /// �������εط�չ����
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDTRENDS")]
        public string MIZSECTORLANDTRENDS { get; set; }
        /// <summary>
        /// �������ε��ȳ�
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDFANLONG")]
        public decimal? MIZSECTORLANDFANLONG { get; set; }
        /// <summary>
        /// �������ε��ȿ�
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDFANKUAN")]
        public decimal? MIZSECTORLANDFANKUAN { get; set; }
        /// <summary>
        /// �������ε���ɢ��
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDSPREADANGLE")]
        public decimal? MIZSECTORLANDSPREADANGLE { get; set; }
        /// <summary>
        /// �������εؼ�ѹ���
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDEXTRUSIONRIVER")]
        public string MIZSECTORLANDEXTRUSIONRIVER { get; set; }
        /// <summary>
        /// ���ʹ���
        /// </summary>
        /// <returns></returns>
        [Column("GEOLOGICALSTRUCTURE")]
        public string GEOLOGICALSTRUCTURE { get; set; }
        /// <summary>
        /// �����Ҷ�
        /// </summary>
        /// <returns></returns>
        [Column("EARTHQUAKEINTENSITY")]
        public string EARTHQUAKEINTENSITY { get; set; }
        /// <summary>
        /// ���»�̶�
        /// </summary>
        /// <returns></returns>
        [Column("SCALEACTIVITYDEGREE")]
        public string SCALEACTIVITYDEGREE { get; set; }
        /// <summary>
        /// ���¹�ģ
        /// </summary>
        /// <returns></returns>
        [Column("SCALEIANDSLIDE")]
        public string SCALEIANDSLIDE { get; set; }
        /// <summary>
        /// �˹������̶�
        /// </summary>
        /// <returns></returns>
        [Column("ARTIFICIALABDBODYACTDEGREE")]
        public string ARTIFICIALABDBODYACTDEGREE { get; set; }
        /// <summary>
        /// �˹������ģ
        /// </summary>
        /// <returns></returns>
        [Column("ARTIFICIALABDBODYSCALE")]
        public string ARTIFICIALABDBODYSCALE { get; set; }
        /// <summary>
        /// ��Ȼ�ѻ���̶�
        /// </summary>
        /// <returns></returns>
        [Column("NATURALACCACTDEGREE")]
        public string NATURALACCACTDEGREE { get; set; }
        /// <summary>
        /// ��Ȼ�ѻ���ģ
        /// </summary>
        /// <returns></returns>
        [Column("NATURALACCSCALE")]
        public string NATURALACCSCALE { get; set; }
        /// <summary>
        /// ɭ��
        /// </summary>
        /// <returns></returns>
        [Column("FOREST")]
        public decimal? FOREST { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("SHRUB")]
        public decimal? SHRUB { get; set; }
        /// <summary>
        /// �ݵ�
        /// </summary>
        /// <returns></returns>
        [Column("LAWN")]
        public decimal? LAWN { get; set; }
        /// <summary>
        /// ���¸���
        /// </summary>
        /// <returns></returns>
        [Column("GENTSLOPEARALAND")]
        public decimal? GENTSLOPEARALAND { get; set; }
        /// <summary>
        /// �ĵ�
        /// </summary>
        /// <returns></returns>
        [Column("WASTELAND")]
        public decimal? WASTELAND { get; set; }
        /// <summary>
        /// ���¸���
        /// </summary>
        /// <returns></returns>
        [Column("STEEPLAND")]
        public decimal? STEEPLAND { get; set; }
        /// <summary>
        /// �����õ�
        /// </summary>
        /// <returns></returns>
        [Column("BUILDINGLAND")]
        public decimal? BUILDINGLAND { get; set; }
        /// <summary>
        /// �����õ�
        /// </summary>
        /// <returns></returns>
        [Column("OTHERSITES")]
        public decimal? OTHERSITES { get; set; }
        /// <summary>
        /// ���δ�ʩ��״
        /// </summary>
        /// <returns></returns>
        [Column("CONTROLMEASTATUSQ")]
        public string CONTROLMEASTATUSQ { get; set; }
        /// <summary>
        /// ���δ�ʩ����
        /// </summary>
        /// <returns></returns>
        [Column("CONTROMEASURETYPE")]
        public string CONTROMEASURETYPE { get; set; }
        /// <summary>
        /// ����ʩ
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMEASURE")]
        public string MONITORMEASURE { get; set; }
        /// <summary>
        /// ����ʩ����
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMEASURETYPE")]
        public string MONITORMEASURETYPE { get; set; }
        /// <summary>
        /// ��вΣ������
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHARMOBJ")]
        public string THREATENHARMOBJ { get; set; }
        /// <summary>
        /// ��в�˿�
        /// </summary>
        /// <returns></returns>
        [Column("THREATENPEOPLE")]
        public int? THREATENPEOPLE { get; set; }
        /// <summary>
        /// ��в�Ʋ�
        /// </summary>
        /// <returns></returns>
        [Column("THREATENASSETS")]
        public decimal? THREATENASSETS { get; set; }
        /// <summary>
        /// ����ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DANGERLEVEL")]
        public string DANGERLEVEL { get; set; }
        /// <summary>
        /// �ֺ�ʷ����ʱ��1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYOCCURT1")]
        public string DISHISTORYOCCURT1 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�����˿�1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDEATHS1")]
        public int? DISHISTORYDEATHS1 { get; set; }
        /// <summary>
        /// �ֺ�ʷ��ʧ����1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYLOSSLIVESTOCK1")]
        public int? DISHISTORYLOSSLIVESTOCK1 { get; set; }
        /// <summary>
        /// �ֺ�ʷȫ�ٷ���1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESHOUSES1")]
        public int? DISHISTORYCOMPDESHOUSES1 { get; set; }
        /// <summary>
        /// �ֺ�ʷ��ٷ���1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESHOUSES1")]
        public int? DISHISTORYSDESHOUSES1 { get; set; }
        /// <summary>
        /// �ֺ�ʷȫ��ũ��1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESFARMLAND1")]
        public decimal? DISHISTORYCOMPDESFARMLAND1 { get; set; }
        /// <summary>
        /// �ֺ�ʷ���ũ��1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESFARMLAND1")]
        public decimal? DISHISTORYSDESFARMLAND1 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�ٻ���·1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESROAD1")]
        public decimal? DISHISTORYDESROAD1 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�ٻ�����1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESBRIDGE1")]
        public int? DISHISTORYDESBRIDGE1 { get; set; }
        /// <summary>
        /// �ֺ�ʷֱ����ʧ1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDIRECTLOSS1")]
        public decimal? DISHISTORYDIRECTLOSS1 { get; set; }
        /// <summary>
        /// �ֺ�ʷ����ȼ�1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDISASTERDEGREES1")]
        public string DISHISTORYDISASTERDEGREES1 { get; set; }
        /// <summary>
        /// �ֺ�ʷ����ʱ��2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYOCCURT2")]
        public string DISHISTORYOCCURT2 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�����˿�2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDEATHS2")]
        public int? DISHISTORYDEATHS2 { get; set; }
        /// <summary>
        /// �ֺ�ʷ��ʧ����2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYLOSSLIVESTOCK2")]
        public int? DISHISTORYLOSSLIVESTOCK2 { get; set; }
        /// <summary>
        /// �ֺ�ʷȫ�ٷ���2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESHOUSES2")]
        public int? DISHISTORYCOMPDESHOUSES2 { get; set; }
        /// <summary>
        /// �ֺ�ʷ��ٷ���2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESHOUSES2")]
        public int? DISHISTORYSDESHOUSES2 { get; set; }
        /// <summary>
        /// �ֺ�ʷȫ��ũ��2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESFARMLAND2")]
        public decimal? DISHISTORYCOMPDESFARMLAND2 { get; set; }
        /// <summary>
        /// �ֺ�ʷ���ũ��2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESFARMLAND2")]
        public decimal? DISHISTORYSDESFARMLAND2 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�ٻ���·2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESROAD2")]
        public decimal? DISHISTORYDESROAD2 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�ٻ�����2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESBRIDGE2")]
        public int? DISHISTORYDESBRIDGE2 { get; set; }
        /// <summary>
        /// �ֺ�ʷֱ����ʧ2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDIRECTLOSS2")]
        public decimal? DISHISTORYDIRECTLOSS2 { get; set; }
        /// <summary>
        /// �ֺ�ʷ����ȼ�2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDISASTERDEGREES2")]
        public string DISHISTORYDISASTERDEGREES2 { get; set; }
        /// <summary>
        /// �ֺ�ʷ����ʱ��3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYOCCURT3")]
        public string DISHISTORYOCCURT3 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�����˿�3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDEATHS3")]
        public int? DISHISTORYDEATHS3 { get; set; }
        /// <summary>
        /// �ֺ�ʷ��ʧ����3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYLOSSLIVESTOCK3")]
        public int? DISHISTORYLOSSLIVESTOCK3 { get; set; }
        /// <summary>
        /// �ֺ�ʷȫ�ٷ���3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESHOUSES3")]
        public int? DISHISTORYCOMPDESHOUSES3 { get; set; }
        /// <summary>
        /// �ֺ�ʷ��ٷ���3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESHOUSES3")]
        public int? DISHISTORYSDESHOUSES3 { get; set; }
        /// <summary>
        /// �ֺ�ʷȫ��ũ��3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESFARMLAND3")]
        public decimal? DISHISTORYCOMPDESFARMLAND3 { get; set; }
        /// <summary>
        /// �ֺ�ʷ���ũ��3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESFARMLAND3")]
        public decimal? DISHISTORYSDESFARMLAND3 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�ٻ���·3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESROAD3")]
        public decimal? DISHISTORYDESROAD3 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�ٻ�����3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESBRIDGE3")]
        public int? DISHISTORYDESBRIDGE3 { get; set; }
        /// <summary>
        /// �ֺ�ʷֱ����ʧ3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDIRECTLOSS3")]
        public decimal? DISHISTORYDIRECTLOSS3 { get; set; }
        /// <summary>
        /// �ֺ�ʷ����ȼ�3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDISASTERDEGREES3")]
        public string DISHISTORYDISASTERDEGREES3 { get; set; }
        /// <summary>
        /// �ֺ�ʷ����ʱ��4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYOCCURT4")]
        public string DISHISTORYOCCURT4 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�����˿�4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDEATHS4")]
        public int? DISHISTORYDEATHS4 { get; set; }
        /// <summary>
        /// �ֺ�ʷ��ʧ����4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYLOSSLIVESTOCK4")]
        public int? DISHISTORYLOSSLIVESTOCK4 { get; set; }
        /// <summary>
        /// �ֺ�ʷȫ�ٷ���4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESHOUSES4")]
        public int? DISHISTORYCOMPDESHOUSES4 { get; set; }
        /// <summary>
        /// �ֺ�ʷ��ٷ���4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESHOUSES4")]
        public int? DISHISTORYSDESHOUSES4 { get; set; }
        /// <summary>
        /// �ֺ�ʷȫ��ũ��4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESFARMLAND4")]
        public decimal? DISHISTORYCOMPDESFARMLAND4 { get; set; }
        /// <summary>
        /// �ֺ�ʷ���ũ��4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESFARMLAND4")]
        public decimal? DISHISTORYSDESFARMLAND4 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�ٻ���·4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESROAD4")]
        public decimal? DISHISTORYDESROAD4 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�ٻ�����4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESBRIDGE4")]
        public int? DISHISTORYDESBRIDGE4 { get; set; }
        /// <summary>
        /// �ֺ�ʷֱ����ʧ4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDIRECTLOSS4")]
        public decimal? DISHISTORYDIRECTLOSS4 { get; set; }
        /// <summary>
        /// �ֺ�ʷ����ȼ�4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDISASTERDEGREES4")]
        public string DISHISTORYDISASTERDEGREES4 { get; set; }
        /// <summary>
        /// �ֺ�ʷ����ʱ��5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYOCCURT5")]
        public string DISHISTORYOCCURT5 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�����˿�5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDEATHS5")]
        public int? DISHISTORYDEATHS5 { get; set; }
        /// <summary>
        /// �ֺ�ʷ��ʧ����5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYLOSSLIVESTOCK5")]
        public int? DISHISTORYLOSSLIVESTOCK5 { get; set; }
        /// <summary>
        /// �ֺ�ʷȫ�ٷ���5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESHOUSES5")]
        public int? DISHISTORYCOMPDESHOUSES5 { get; set; }
        /// <summary>
        /// �ֺ�ʷ��ٷ���5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESHOUSES5")]
        public int? DISHISTORYSDESHOUSES5 { get; set; }
        /// <summary>
        /// �ֺ�ʷȫ��ũ��5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESFARMLAND5")]
        public decimal? DISHISTORYCOMPDESFARMLAND5 { get; set; }
        /// <summary>
        /// �ֺ�ʷ���ũ��5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESFARMLAND5")]
        public decimal? DISHISTORYSDESFARMLAND5 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�ٻ���·5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESROAD5")]
        public decimal? DISHISTORYDESROAD5 { get; set; }
        /// <summary>
        /// �ֺ�ʷ�ٻ�����5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESBRIDGE5")]
        public int? DISHISTORYDESBRIDGE5 { get; set; }
        /// <summary>
        /// �ֺ�ʷֱ����ʧ5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDIRECTLOSS5")]
        public decimal? DISHISTORYDIRECTLOSS5 { get; set; }
        /// <summary>
        /// �ֺ�ʷ����ȼ�5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDISASTERDEGREES5")]
        public string DISHISTORYDISASTERDEGREES5 { get; set; }
        /// <summary>
        /// ��ʯ���������
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWOUTSQUCAP")]
        public decimal? DEBRISFLOWOUTSQUCAP { get; set; }
        /// <summary>
        /// ��ʯ����ģ�ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWRATINGSCALE")]
        public string DEBRISFLOWRATINGSCALE { get; set; }
        /// <summary>
        /// ��ʯ����λ
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWMUDPOSITION")]
        public decimal? DEBRISFLOWMUDPOSITION { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        [Column("BADGEOLOGICALPHENOMENA")]
        public string BADGEOLOGICALPHENOMENA { get; set; }
        /// <summary>
        /// �����γ��ȱ�
        /// </summary>
        /// <returns></returns>
        [Column("SUPPLYLENGTHRATIO")]
        public string SUPPLYLENGTHRATIO { get; set; }
        /// <summary>
        /// �������ε�
        /// </summary>
        /// <returns></returns>
        [Column("MIZOGUCHIFAN")]
        public string MIZOGUCHIFAN { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("MCHANNELLSLOPE")]
        public string MCHANNELLSLOPE { get; set; }
        /// <summary>
        /// �¹���Ӱ��
        /// </summary>
        /// <returns></returns>
        [Column("NEWCONSTRUCTIONAFFECT")]
        public string NEWCONSTRUCTIONAFFECT { get; set; }
        /// <summary>
        /// ֲ��������
        /// </summary>
        /// <returns></returns>
        [Column("VEGETATIONCOVERAGE")]
        public string VEGETATIONCOVERAGE { get; set; }
        /// <summary>
        /// ���ٱ�����ף�
        /// </summary>
        /// <returns></returns>
        [Column("EROSIONAMPLITUDE")]
        public string EROSIONAMPLITUDE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("ROCKFACTOR")]
        public string ROCKFACTOR { get; set; }
        /// <summary>
        /// ��ɢ�ﴢ��(��������/ƽ�����
        /// </summary>
        /// <returns></returns>
        [Column("LOOSEMATRESERVES")]
        public string LOOSEMATRESERVES { get; set; }
        /// <summary>
        /// ɽ���¶�
        /// </summary>
        /// <returns></returns>
        [Column("MOUNTAINSLOPE")]
        public string MOUNTAINSLOPE { get; set; }
        /// <summary>
        /// ���ۺ����
        /// </summary>
        /// <returns></returns>
        [Column("TRENCHCCROSSSECTIONAL")]
        public string TRENCHCCROSSSECTIONAL { get; set; }
        /// <summary>
        /// ��ɢ��ƽ�����ף�
        /// </summary>
        /// <returns></returns>
        [Column("LOOSEMATAVERAGETHICK")]
        public string LOOSEMATAVERAGETHICK { get; set; }
        /// <summary>
        /// ���������ƽ���ף�
        /// </summary>
        /// <returns></returns>
        [Column("DRAINAGESIZE")]
        public string DRAINAGESIZE { get; set; }
        /// <summary>
        /// ��Ը߲�ף�
        /// </summary>
        /// <returns></returns>
        [Column("RELATIVEHEIGHT")]
        public string RELATIVEHEIGHT { get; set; }
        /// <summary>
        /// �����̶�
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKDEGREE")]
        public string BLOCKDEGREE { get; set; }
        /// <summary>
        /// ����1
        /// </summary>
        /// <returns></returns>
        [Column("SCORE1")]
        public decimal? SCORE1 { get; set; }
        /// <summary>
        /// ����2
        /// </summary>
        /// <returns></returns>
        [Column("SCORE2")]
        public decimal? SCORE2 { get; set; }
        /// <summary>
        /// ����3
        /// </summary>
        /// <returns></returns>
        [Column("SCORE3")]
        public decimal? SCORE3 { get; set; }
        /// <summary>
        /// ����4
        /// </summary>
        /// <returns></returns>
        [Column("SCORE4")]
        public decimal? SCORE4 { get; set; }
        /// <summary>
        /// ����5
        /// </summary>
        /// <returns></returns>
        [Column("SCORE5")]
        public decimal? SCORE5 { get; set; }
        /// <summary>
        /// ����6
        /// </summary>
        /// <returns></returns>
        [Column("SCORE6")]
        public decimal? SCORE6 { get; set; }
        /// <summary>
        /// ����7
        /// </summary>
        /// <returns></returns>
        [Column("SCORE7")]
        public decimal? SCORE7 { get; set; }
        /// <summary>
        /// ����8
        /// </summary>
        /// <returns></returns>
        [Column("SCORE8")]
        public decimal? SCORE8 { get; set; }
        /// <summary>
        /// ����9
        /// </summary>
        /// <returns></returns>
        [Column("SCORE9")]
        public decimal? SCORE9 { get; set; }
        /// <summary>
        /// ����10
        /// </summary>
        /// <returns></returns>
        [Column("SCORE10")]
        public decimal? SCORE10 { get; set; }
        /// <summary>
        /// ����11
        /// </summary>
        /// <returns></returns>
        [Column("SCORE11")]
        public decimal? SCORE11 { get; set; }
        /// <summary>
        /// ����12
        /// </summary>
        /// <returns></returns>
        [Column("SCORE12")]
        public decimal? SCORE12 { get; set; }
        /// <summary>
        /// ����13
        /// </summary>
        /// <returns></returns>
        [Column("SCORE13")]
        public decimal? SCORE13 { get; set; }
        /// <summary>
        /// ����14
        /// </summary>
        /// <returns></returns>
        [Column("SCORE14")]
        public decimal? SCORE14 { get; set; }
        /// <summary>
        /// ����15
        /// </summary>
        /// <returns></returns>
        [Column("SCORE15")]
        public decimal? SCORE15 { get; set; }
        /// <summary>
        /// �ܷ�
        /// </summary>
        /// <returns></returns>
        [Column("TOTAL")]
        public string TOTAL { get; set; }
        /// <summary>
        /// �׷��̶�
        /// </summary>
        /// <returns></returns>
        [Column("PRONEDEGREE")]
        public string PRONEDEGREE { get; set; }
        /// <summary>
        /// ��ʯ������
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWTYPE")]
        public string DEBRISFLOWTYPE { get; set; }
        /// <summary>
        /// ��չ�׶�
        /// </summary>
        /// <returns></returns>
        [Column("DEVELOPINGSTAGE")]
        public string DEVELOPINGSTAGE { get; set; }
        /// <summary>
        /// ��⽨��
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWMONITORSUGGESTION")]
        public string DEBRISFLOWMONITORSUGGESTION { get; set; }
        /// <summary>
        /// ���ν���
        /// </summary>
        /// <returns></returns>
        [Column("TREATMENTSUGGESTION")]
        public string TREATMENTSUGGESTION { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENPOINT")]
        public string HIDDENPOINT { get; set; }
        /// <summary>
        /// ����Ԥ��
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERPREPAREDNESS")]
        public string DISASTERPREPAREDNESS { get; set; }
        /// <summary>
        /// Ⱥ����Ա
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMASS")]
        public string MONITORMASS { get; set; }
        /// <summary>
        /// �峤
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGEHEADER")]
        public string VILLAGEHEADER { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        [Column("PHONE")]
        public string PHONE { get; set; }
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
        /// ��ʯ�����
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWDESC")]
        public string DEBRISFLOWDESC { get; set; }
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
        /// ����Ƶ�ʣ���/�꣩
        /// </summary>
        /// <returns></returns>
        [Column("OCCURREDFREQUENCY")]
        public short? OCCURREDFREQUENCY { get; set; }
        /// <summary>
        /// �����˿ڣ��ˣ�
        /// </summary>
        /// <returns></returns>
        [Column("DEATHSPEOPLE")]
        public int? DEATHSPEOPLE { get; set; }
        /// <summary>
        /// ֱ�Ӿ�����ʧ����Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTECONOMICLOSSES")]
        public decimal? DIRECTECONOMICLOSSES { get; set; }
        /// <summary>
        /// ����ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERLEVEL")]
        public string DISASTERLEVEL { get; set; }
        /// <summary>
        /// Σ������
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDOBJECT")]
        public string DESTROYEDOBJECT { get; set; }
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
        /// Ұ���¼��Ϣ
        /// </summary>
        /// <returns></returns>
        [Column("OUTDOORRECORD")]
        public string OUTDOORRECORD { get; set; }
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
        /// Ⱥ��Ⱥ��
        /// </summary>
        /// <returns></returns>
        [Column("MASSMONITORING")]
        public string MASSMONITORING { get; set; }
        /// <summary>
        /// ��Ǩ����
        /// </summary>
        /// <returns></returns>
        [Column("RELOCATION")]
        public string RELOCATION { get; set; }
        /// <summary>
        /// רҵ���
        /// </summary>
        /// <returns></returns>
        [Column("PROFESSIONMONITORING")]
        public string PROFESSIONMONITORING { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("ENGINEERINGMANAGEMENT")]
        public string ENGINEERINGMANAGEMENT { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("OTHER")]
        public string OTHER { get; set; }
        /// <summary>
        /// ��в���ݣ�����
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOME")]
        public int? THREATENHOME { get; set; }
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
        /// Ⱥ����ID
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMASSID")]
        public string MONITORMASSID { get; set; }
        /// <summary>
        /// �峤ID
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGEHEADERID")]
        public string VILLAGEHEADERID { get; set; }
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
        /// ��ʯ����������(t/m3)
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWCAPACITY")]
        public decimal? DEBRISFLOWCAPACITY { get; set; }
        /// <summary>
        /// ��ʯ����������(m3/s)
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWDISCHARGE")]
        public decimal? DEBRISFLOWDISCHARGE { get; set; }
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
