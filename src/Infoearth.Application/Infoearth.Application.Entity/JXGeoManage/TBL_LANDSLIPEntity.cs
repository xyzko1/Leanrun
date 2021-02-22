using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-26 19:02
    /// �� �������µ����
    /// </summary>
    public class TBL_LANDSLIPEntity : BaseEntity
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
        /// �ֺ�������
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
        /// �µ�
        /// </summary>
        /// <returns></returns>
        [Column("ALTTOP")]
        public decimal? ALTTOP { get; set; }
        /// <summary>
        /// �¶�
        /// </summary>
        /// <returns></returns>
        [Column("ALTBOTOM")]
        public decimal? ALTBOTOM { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPYEAR")]
        public string LANDSLIPYEAR { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPTIME")]
        public string LANDSLIPTIME { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPTYPE")]
        public string LANDSLIPTYPE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPKIND")]
        public string LANDSLIPKIND { get; set; }
        /// <summary>
        /// �ز�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("STRATIGRAPHICTIME")]
        public string STRATIGRAPHICTIME { get; set; }
        /// <summary>
        /// �ز�����
        /// </summary>
        /// <returns></returns>
        [Column("LITHOLOGY")]
        public string LITHOLOGY { get; set; }
        /// <summary>
        /// ���첿λ
        /// </summary>
        /// <returns></returns>
        [Column("TECTONICREGION")]
        public string TECTONICREGION { get; set; }
        /// <summary>
        /// �����Ҷ�
        /// </summary>
        /// <returns></returns>
        [Column("EARTHQUAKEINTENSITY")]
        public string EARTHQUAKEINTENSITY { get; set; }
        /// <summary>
        /// �ز�����
        /// </summary>
        /// <returns></returns>
        [Column("STRATUMDIRECTION")]
        public int? STRATUMDIRECTION { get; set; }
        /// <summary>
        /// �ز����
        /// </summary>
        /// <returns></returns>
        [Column("STRATUMANGLE")]
        public int? STRATUMANGLE { get; set; }
        /// <summary>
        /// ΢��ò
        /// </summary>
        /// <returns></returns>
        [Column("MICROTOPOGRAPHY")]
        public string MICROTOPOGRAPHY { get; set; }
        /// <summary>
        /// ����ˮ����
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATERTYPE")]
        public string GROUNDWATERTYPE { get; set; }
        /// <summary>
        /// ���������
        /// </summary>
        /// <returns></returns>
        [Column("AVERAGEYEARRAINFALL")]
        public decimal? AVERAGEYEARRAINFALL { get; set; }
        /// <summary>
        /// ���������
        /// </summary>
        /// <returns></returns>
        [Column("MAXDAYRAINFALL")]
        public decimal? MAXDAYRAINFALL { get; set; }
        /// <summary>
        /// ʱ�������
        /// </summary>
        /// <returns></returns>
        [Column("MAXHOURRAINFALL")]
        public decimal? MAXHOURRAINFALL { get; set; }
        /// <summary>
        /// ��ˮλ
        /// </summary>
        /// <returns></returns>
        [Column("MAXWATERLEVEL")]
        public decimal? MAXWATERLEVEL { get; set; }
        /// <summary>
        /// ��ˮλ
        /// </summary>
        /// <returns></returns>
        [Column("MINWATERLEVEL")]
        public decimal? MINWATERLEVEL { get; set; }
        /// <summary>
        /// ��Ժ���λ��
        /// </summary>
        /// <returns></returns>
        [Column("POSITIONTORIVER")]
        public string POSITIONTORIVER { get; set; }
        /// <summary>
        /// ԭʼ�¸�
        /// </summary>
        /// <returns></returns>
        [Column("ORIGINALSLOPEHEIGHT")]
        public decimal? ORIGINALSLOPEHEIGHT { get; set; }
        /// <summary>
        /// ԭʼ�¶�
        /// </summary>
        /// <returns></returns>
        [Column("ORIGINALSLOPEANGLE")]
        public short? ORIGINALSLOPEANGLE { get; set; }
        /// <summary>
        /// ԭʼ����
        /// </summary>
        /// <returns></returns>
        [Column("ORIGINALSLOPESHAPE")]
        public string ORIGINALSLOPESHAPE { get; set; }
        /// <summary>
        /// б�½ṹ����
        /// </summary>
        /// <returns></returns>
        [Column("SLOPEARCHTYPE")]
        public string SLOPEARCHTYPE { get; set; }
        /// <summary>
        /// б�½ṹ����
        /// </summary>
        /// <returns></returns>
        [Column("SLOPEASPECTARCHTYPE")]
        public string SLOPEASPECTARCHTYPE { get; set; }
        /// <summary>
        /// �ػ��ṹ������1
        /// </summary>
        /// <returns></returns>
        [Column("SURFACETYPE1")]
        public string SURFACETYPE1 { get; set; }
        /// <summary>
        /// �ػ��ṹ������1
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEDIRECTION1")]
        public int? SURFACEDIRECTION1 { get; set; }
        /// <summary>
        /// �ػ��ṹ�����1
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEANGLE1")]
        public int? SURFACEANGLE1 { get; set; }
        /// <summary>
        /// �ػ��ṹ������2
        /// </summary>
        /// <returns></returns>
        [Column("SURFACETYPE2")]
        public string SURFACETYPE2 { get; set; }
        /// <summary>
        /// �ػ��ṹ������2
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEDIRECTION2")]
        public int? SURFACEDIRECTION2 { get; set; }
        /// <summary>
        /// �ػ��ṹ�����2
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEANGLE2")]
        public int? SURFACEANGLE2 { get; set; }
        /// <summary>
        /// �ػ��ṹ������3
        /// </summary>
        /// <returns></returns>
        [Column("SURFACETYPE3")]
        public string SURFACETYPE3 { get; set; }
        /// <summary>
        /// �ػ��ṹ������3
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEDIRECTION3")]
        public int? SURFACEDIRECTION3 { get; set; }
        /// <summary>
        /// �ػ��ṹ�����3
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEANGLE3")]
        public int? SURFACEANGLE3 { get; set; }
        /// <summary>
        /// ���³���
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPLENGTH")]
        public decimal? LANDSLIPLENGTH { get; set; }
        /// <summary>
        /// ���¿��
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPWIDTH")]
        public decimal? LANDSLIPWIDTH { get; set; }
        /// <summary>
        /// ���º��
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPDEPTH")]
        public decimal? LANDSLIPDEPTH { get; set; }
        /// <summary>
        /// �����¶�
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPANGLE")]
        public int? LANDSLIPANGLE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPDIRECTION")]
        public int? LANDSLIPDIRECTION { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPSIZE")]
        public decimal? LANDSLIPSIZE { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPVOLUME")]
        public decimal? LANDSLIPVOLUME { get; set; }
        /// <summary>
        /// ����ƽ����̬
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPFLATSHAPE")]
        public string LANDSLIPFLATSHAPE { get; set; }
        /// <summary>
        /// ����������̬
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPSECTIONSHAPE")]
        public string LANDSLIPSECTIONSHAPE { get; set; }
        /// <summary>
        /// ��ģ�ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("SCALELEVEL")]
        public string SCALELEVEL { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPLITHOLOGY")]
        public string LANDSLIPLITHOLOGY { get; set; }
        /// <summary>
        /// ����ṹ
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPARCH")]
        public string LANDSLIPARCH { get; set; }
        /// <summary>
        /// ������ʯ����
        /// </summary>
        /// <returns></returns>
        [Column("GRAVELCONTENT")]
        public decimal? GRAVELCONTENT { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPBLOCKDEGREE")]
        public string LANDSLIPBLOCKDEGREE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("SLIPBEDLITHOLOGY")]
        public string SLIPBEDLITHOLOGY { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("SLIPBEDTIME")]
        public string SLIPBEDTIME { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("SLIPBEDDIRECTION")]
        public int? SLIPBEDDIRECTION { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("SLIPBEDANGLE")]
        public int? SLIPBEDANGLE { get; set; }
        /// <summary>
        /// ������̬
        /// </summary>
        /// <returns></returns>
        [Column("SLIPSURFACESHAPE")]
        public string SLIPSURFACESHAPE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("SLIPSURFACEDEPTH")]
        public decimal? SLIPSURFACEDEPTH { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("SLIPSURFACEDIRECTION")]
        public int? SLIPSURFACEDIRECTION { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("SLIPSURFACEANGLE")]
        public int? SLIPSURFACEANGLE { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("SLIPZONEDEPTH")]
        public decimal? SLIPZONEDEPTH { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPSOILNAME")]
        public string LANDSLIPSOILNAME { get; set; }
        /// <summary>
        /// ��������״
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPSOILCHARACTERS")]
        public string LANDSLIPSOILCHARACTERS { get; set; }
        /// <summary>
        /// ����ˮ����
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATERDEPTH")]
        public decimal? GROUNDWATERDEPTH { get; set; }
        /// <summary>
        /// ����ˮ¶ͷ
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATEROUTCROP")]
        public string GROUNDWATEROUTCROP { get; set; }
        /// <summary>
        /// ����ˮ��������
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATERSUPPLYTYPE")]
        public string GROUNDWATERSUPPLYTYPE { get; set; }
        /// <summary>
        /// ����ʹ��
        /// </summary>
        /// <returns></returns>
        [Column("LANDUSAGE")]
        public string LANDUSAGE { get; set; }
        /// <summary>
        /// ���μ�������1
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN1")]
        public string DISTORTIONSIGN1 { get; set; }
        /// <summary>
        /// ���μ���λ1
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE1")]
        public string DISTORTIONPLACE1 { get; set; }
        /// <summary>
        /// ���μ�������1
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER1")]
        public string DISTORTIONCHARACTER1 { get; set; }
        /// <summary>
        /// ���μ������ʱ��1
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE1")]
        public string DISTORTIONINITDATE1 { get; set; }
        /// <summary>
        /// ���μ�������2
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN2")]
        public string DISTORTIONSIGN2 { get; set; }
        /// <summary>
        /// ���μ���λ2
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE2")]
        public string DISTORTIONPLACE2 { get; set; }
        /// <summary>
        /// ���μ�������2
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER2")]
        public string DISTORTIONCHARACTER2 { get; set; }
        /// <summary>
        /// ���μ������ʱ��2
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE2")]
        public string DISTORTIONINITDATE2 { get; set; }
        /// <summary>
        /// ���μ�������3
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN3")]
        public string DISTORTIONSIGN3 { get; set; }
        /// <summary>
        /// ���μ���λ3
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE3")]
        public string DISTORTIONPLACE3 { get; set; }
        /// <summary>
        /// ���μ�������3
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER3")]
        public string DISTORTIONCHARACTER3 { get; set; }
        /// <summary>
        /// ���μ������ʱ��3
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE3")]
        public string DISTORTIONINITDATE3 { get; set; }
        /// <summary>
        /// ���μ�������4
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN4")]
        public string DISTORTIONSIGN4 { get; set; }
        /// <summary>
        /// ���μ���λ4
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE4")]
        public string DISTORTIONPLACE4 { get; set; }
        /// <summary>
        /// ���μ�������4
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER4")]
        public string DISTORTIONCHARACTER4 { get; set; }
        /// <summary>
        /// ���μ������ʱ��4
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE4")]
        public string DISTORTIONINITDATE4 { get; set; }
        /// <summary>
        /// ���μ�������5
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN5")]
        public string DISTORTIONSIGN5 { get; set; }
        /// <summary>
        /// ���μ���λ5
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE5")]
        public string DISTORTIONPLACE5 { get; set; }
        /// <summary>
        /// ���μ�������5
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER5")]
        public string DISTORTIONCHARACTER5 { get; set; }
        /// <summary>
        /// ���μ������ʱ��5
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE5")]
        public string DISTORTIONINITDATE5 { get; set; }
        /// <summary>
        /// ���μ�������6
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN6")]
        public string DISTORTIONSIGN6 { get; set; }
        /// <summary>
        /// ���μ���λ6
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE6")]
        public string DISTORTIONPLACE6 { get; set; }
        /// <summary>
        /// ���μ�������6
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER6")]
        public string DISTORTIONCHARACTER6 { get; set; }
        /// <summary>
        /// ���μ������ʱ��6
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE6")]
        public string DISTORTIONINITDATE6 { get; set; }
        /// <summary>
        /// ���μ�������7
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN7")]
        public string DISTORTIONSIGN7 { get; set; }
        /// <summary>
        /// ���μ���λ7
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE7")]
        public string DISTORTIONPLACE7 { get; set; }
        /// <summary>
        /// ���μ�������7
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER7")]
        public string DISTORTIONCHARACTER7 { get; set; }
        /// <summary>
        /// ���μ������ʱ��7
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE7")]
        public string DISTORTIONINITDATE7 { get; set; }
        /// <summary>
        /// ���μ�������8
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN8")]
        public string DISTORTIONSIGN8 { get; set; }
        /// <summary>
        /// ���μ���λ8
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE8")]
        public string DISTORTIONPLACE8 { get; set; }
        /// <summary>
        /// ���μ�������8
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER8")]
        public string DISTORTIONCHARACTER8 { get; set; }
        /// <summary>
        /// ���μ������ʱ��8
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE8")]
        public string DISTORTIONINITDATE8 { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("GEOLOGICFACTOR")]
        public string GEOLOGICFACTOR { get; set; }
        /// <summary>
        /// ��ò����
        /// </summary>
        /// <returns></returns>
        [Column("GEOMORPHICFACTOR")]
        public string GEOMORPHICFACTOR { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("PHYSICALFACTORS")]
        public string PHYSICALFACTORS { get; set; }
        /// <summary>
        /// ��Ϊ����
        /// </summary>
        /// <returns></returns>
        [Column("HUMANFACTOR")]
        public string HUMANFACTOR { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("MAINFACTOR")]
        public string MAINFACTOR { get; set; }
        /// <summary>
        /// �����շ�����
        /// </summary>
        /// <returns></returns>
        [Column("REINDUCEDFACTOR")]
        public string REINDUCEDFACTOR { get; set; }
        /// <summary>
        /// Ŀǰ�ȶ�״̬
        /// </summary>
        /// <returns></returns>
        [Column("CURSTABLESTATUS")]
        public string CURSTABLESTATUS { get; set; }
        /// <summary>
        /// ���仯����
        /// </summary>
        /// <returns></returns>
        [Column("STABLETREND")]
        public string STABLETREND { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENDANGER")]
        public string HIDDENDANGER { get; set; }
        /// <summary>
        /// �ٻ�����(��)
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOME")]
        public int? DESTROYEDHOME { get; set; }
        /// <summary>
        /// �����˿�
        /// </summary>
        /// <returns></returns>
        [Column("DEATHSPEOPLE")]
        public int? DEATHSPEOPLE { get; set; }
        /// <summary>
        /// ֱ����ʧ
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTLOSSES")]
        public decimal? DIRECTLOSSES { get; set; }
        /// <summary>
        /// ����ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERLEVEL")]
        public string DISASTERLEVEL { get; set; }
        /// <summary>
        /// ��вס��
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOUSEHOLD")]
        public int? THREATENHOUSEHOLD { get; set; }
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
        /// ����Ԥ��
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONPLAN")]
        public string PREVENTIONPLAN { get; set; }
        /// <summary>
        /// ��⽨��
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPMONITORSUGGESTION")]
        public string LANDSLIPMONITORSUGGESTION { get; set; }
        /// <summary>
        /// ���ν���
        /// </summary>
        /// <returns></returns>
        [Column("TREATMENTSUGGESTION")]
        public string TREATMENTSUGGESTION { get; set; }
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
        ///   ���鵥λ  
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
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPDESC")]
        public string LANDSLIPDESC { get; set; }
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
        /// ���λ�׶�
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONACTIVITIESPROGRESS")]
        public string DISTORTIONACTIVITIESPROGRESS { get; set; }
        /// <summary>
        /// ��Ȼ����
        /// </summary>
        /// <returns></returns>
        [Column("NATURALFACTOR")]
        public string NATURALFACTOR { get; set; }
        /// <summary>
        /// �𻵷���(��)
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOUSE")]
        public decimal? DESTROYEDHOUSE { get; set; }
        /// <summary>
        /// ��·���ף�
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDROAD")]
        public decimal? DESTROYEDROAD { get; set; }
        /// <summary>
        /// �������ף�
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDCANAL")]
        public decimal? DESTROYEDCANAL { get; set; }
        /// <summary>
        /// ����Σ��
        /// </summary>
        /// <returns></returns>
        [Column("OTHERHARM")]
        public string OTHERHARM { get; set; }
        /// <summary>
        /// �����ʧ����Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("INDIRECTLOSS")]
        public decimal? INDIRECTLOSS { get; set; }
        /// <summary>
        /// Σ������
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDOBJECT")]
        public string DESTROYEDOBJECT { get; set; }
        /// <summary>
        /// �շ��ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDDAMAGETYPE")]
        public string INDUCEDDAMAGETYPE { get; set; }
        /// <summary>
        /// �շ��ֺ�������Χ
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDDAMAGERANGE")]
        public string INDUCEDDAMAGERANGE { get; set; }
        /// <summary>
        /// �շ��ֺ������ʧ
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDDAMAGELOSS")]
        public string INDUCEDDAMAGELOSS { get; set; }
        /// <summary>
        /// Ǳ��Σ����в����
        /// </summary>
        /// <returns></returns>
        [Column("THREATENOBJECT")]
        public string THREATENOBJECT { get; set; }
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
        /// �ػ��ṹ������4
        /// </summary>
        /// <returns></returns>
        [Column("SURFACETYPE4")]
        public string SURFACETYPE4 { get; set; }
        /// <summary>
        /// �ػ��ṹ������4
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEDIRECTION4")]
        public int? SURFACEDIRECTION4 { get; set; }
        /// <summary>
        /// �ػ��ṹ�����4
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEANGLE4")]
        public int? SURFACEANGLE4 { get; set; }
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
        /// "   Ⱥ����ԱID  "
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMASSID")]
        public string MONITORMASSID { get; set; }
        /// <summary>
        /// "   �峤ID    "
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGEHEADERID")]
        public string VILLAGEHEADERID { get; set; }
        /// <summary>
        /// "   ���鸺����ID "
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYHEADERID")]
        public string SURVEYHEADERID { get; set; }
        /// <summary>
        /// "   �����ID   "
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEPEOPLEID")]
        public string FILLTABLEPEOPLEID { get; set; }
        /// <summary>
        /// "   �����ID   "
        /// </summary>
        /// <returns></returns>
        [Column("VERIFYPEOPLEID")]
        public string VERIFYPEOPLEID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYDEPTID")]
        public string SURVEYDEPTID { get; set; }
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
        /// ���¹�ģ�ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("HPGMDJ")]
        public string HPGMDJ { get; set; }
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