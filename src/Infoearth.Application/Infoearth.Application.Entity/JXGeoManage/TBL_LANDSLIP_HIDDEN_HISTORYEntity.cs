using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;
 
namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-03-05 09:47
    /// �� �������������������ʷ��
    /// </summary>
    public class TBL_LANDSLIP_HIDDEN_HISTORYEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// �޸����ͣ�I���������룻A��������¼��U���޸ļ�¼��D��ɾ����¼��
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYTYPE")]
        public string MODIFYTYPE { get; set; }
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <returns></returns>
        [Column("MODIFIEDDATE")]
        public DateTime? MODIFIEDDATE { get; set; }
        /// <summary>
        /// �޸��ˣ���Ӧ�û����LOGINNAME����
        /// </summary>
        /// <returns></returns>
        [Column("EDITOR")]
        public string EDITOR { get; set; }
        /// <summary>
        /// ���״̬��1������ƣ�2�����ͨ����3����Ʋ�ͨ����4��������5��������֤��
        /// </summary>
        /// <returns></returns>
        [Column("AUDITSTATUS")]
        public string AUDITSTATUS { get; set; }
        /// <summary>
        /// �����ˣ���Ӧ�û����LOGINNAME����
        /// </summary>
        /// <returns></returns>
        [Column("AUDITOR")]
        public string AUDITOR { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("AUDITEDDATE")]
        public DateTime? AUDITEDDATE { get; set; }
        /// <summary>
        /// �������ͣ�1-�����̣�2-��Ǩ���ã�3-�˹��˶���
        /// </summary>
        /// <returns></returns>
        [Column("VERIFICATION")]
        public string VERIFICATION { get; set; }
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
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPTYPE")]
        public string LANDSLIPTYPE { get; set; }
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
        /// ����������̬
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPSECTIONSHAPE")]
        public string LANDSLIPSECTIONSHAPE { get; set; }
        /// <summary>
        /// Ԥ���ģ�ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("SCALELEVEL")]
        public string SCALELEVEL { get; set; }
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
        /// ����ʧ�ȸ���
        /// </summary>
        /// <returns></returns>
        [Column("REINDUCEDPRECENT")]
        public string REINDUCEDPRECENT { get; set; }
        /// <summary>
        /// �Ʋ��˶�����
        /// </summary>
        /// <returns></returns>
        [Column("MOTIONCHARATERISTISCS")]
        public string MOTIONCHARATERISTISCS { get; set; }
        /// <summary>
        /// ����ƾ��루m��
        /// </summary>
        /// <returns></returns>
        [Column("MAXSLPOELENGTH")]
        public int? MAXSLPOELENGTH { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERBEARINGTYPE")]
        public string DISASTERBEARINGTYPE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("HOUSENUMBER")]
        public int? HOUSENUMBER { get; set; }
        /// <summary>
        /// ���ݾ��ü�ֵ
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEMONEY")]
        public decimal? HOUSEMONEY { get; set; }
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
        /// Σ���ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DANGERLEVEL")]
        public string DANGERLEVEL { get; set; }
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
        /// Σ������
        /// </summary>
        /// <returns></returns>
        [Column("HAZARDASSESSMENT")]
        public string HAZARDASSESSMENT { get; set; }
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
        /// Ӧ����Σ��
        /// </summary>
        /// <returns></returns>
        [Column("YJPW")]
        public string YJPW { get; set; }
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
        /// ������(���)
        /// </summary>
        /// <returns></returns>
        [Column("UPDATEUSER")]
        public string UPDATEUSER { get; set; }
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
        /// SURVEYDEPTID
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
        /// ����λ��������
        /// </summary>
        /// <returns></returns>
        [Column("LOCATIONOLD")]
        public string LOCATIONOLD { get; set; }
        /// <summary>
        /// б������
        /// </summary>
        /// <returns></returns>
        [Column("SLOPETYPE")]
        public string SLOPETYPE { get; set; }
        /// <summary>
        /// ����ṹ����
        /// </summary>
        /// <returns></returns>
        [Column("ROCKSTRUCTURETYPETYPE")]
        public string ROCKSTRUCTURETYPETYPE { get; set; }
        /// <summary>
        /// ����ṹ���
        /// </summary>
        /// <returns></returns>
        [Column("ROCKSTRUCTURETHICKNESS")]
        public int? ROCKSTRUCTURETHICKNESS { get; set; }
        /// <summary>
        /// ��϶����
        /// </summary>
        /// <returns></returns>
        [Column("CRACKNUMBER")]
        public int? CRACKNUMBER { get; set; }
        /// <summary>
        /// ����ṹ��ȣ�m3��
        /// </summary>
        /// <returns></returns>
        [Column("ROCKFRACTION")]
        public int? ROCKFRACTION { get; set; }
        /// <summary>
        /// ������ṹ����
        /// </summary>
        /// <returns></returns>
        [Column("CONTROLSURFACETYPE")]
        public string CONTROLSURFACETYPE { get; set; }
        /// <summary>
        /// ��״1
        /// </summary>
        /// <returns></returns>
        [Column("OCCURRENCE1")]
        public string OCCURRENCE1 { get; set; }
        /// <summary>
        /// ��״2
        /// </summary>
        /// <returns></returns>
        [Column("OCCURRENCE2")]
        public string OCCURRENCE2 { get; set; }
        /// <summary>
        /// ��״3
        /// </summary>
        /// <returns></returns>
        [Column("OCCURRENCE3")]
        public string OCCURRENCE3 { get; set; }
        /// <summary>
        /// ����1
        /// </summary>
        /// <returns></returns>
        [Column("LONG1")]
        public int? LONG1 { get; set; }
        /// <summary>
        /// ����2
        /// </summary>
        /// <returns></returns>
        [Column("LONG2")]
        public int? LONG2 { get; set; }
        /// <summary>
        /// ����3
        /// </summary>
        /// <returns></returns>
        [Column("LONG3")]
        public int? LONG3 { get; set; }
        /// <summary>
        /// ���1
        /// </summary>
        /// <returns></returns>
        [Column("SPACING1")]
        public int? SPACING1 { get; set; }
        /// <summary>
        /// ���2
        /// </summary>
        /// <returns></returns>
        [Column("SPACING2")]
        public int? SPACING2 { get; set; }
        /// <summary>
        /// ���3
        /// </summary>
        /// <returns></returns>
        [Column("SPACING3")]
        public int? SPACING3 { get; set; }
        /// <summary>
        /// ȫ�绯����ȣ�m��
        /// </summary>
        /// <returns></returns>
        [Column("WINDDEPTH1")]
        public int? WINDDEPTH1 { get; set; }
        /// <summary>
        /// ж���ѷ���ȣ�m��
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTH1")]
        public int? CRACKDEPTH1 { get; set; }
        /// <summary>
        /// ȫ�绯����ȣ�m��
        /// </summary>
        /// <returns></returns>
        [Column("WINDDEPTH2")]
        public int? WINDDEPTH2 { get; set; }
        /// <summary>
        /// ȫ�绯����ȣ�m��
        /// </summary>
        /// <returns></returns>
        [Column("WINDDEPTH3")]
        public int? WINDDEPTH3 { get; set; }
        /// <summary>
        /// ж���ѷ���ȣ�m��
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTH2")]
        public int? CRACKDEPTH2 { get; set; }
        /// <summary>
        /// ж���ѷ���ȣ�m��
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTH3")]
        public int? CRACKDEPTH3 { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("SOILNAME")]
        public string SOILNAME { get; set; }
        /// <summary>
        /// ������ʵ��
        /// </summary>
        /// <returns></returns>
        [Column("SOILTYPE")]
        public string SOILTYPE { get; set; }
        /// <summary>
        /// ���ʳ��
        /// </summary>
        /// <returns></returns>
        [Column("SOILCONSISTENCY")]
        public string SOILCONSISTENCY { get; set; }
        /// <summary>
        /// �·�����
        /// </summary>
        /// <returns></returns>
        [Column("UNDERLYINGCRACK")]
        public string UNDERLYINGCRACK { get; set; }
        /// <summary>
        /// �·�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("UNDERLYINGTIMES")]
        public string UNDERLYINGTIMES { get; set; }
        /// <summary>
        /// �·���״
        /// </summary>
        /// <returns></returns>
        [Column("UNDERLYINGOCCURRENCE")]
        public string UNDERLYINGOCCURRENCE { get; set; }
        /// <summary>
        /// �·����m��
        /// </summary>
        /// <returns></returns>
        [Column("UNDERLYINGDEPTH")]
        public int? UNDERLYINGDEPTH { get; set; }
        /// <summary>
        /// �����ܻ��ƾ��루m��
        /// </summary>
        /// <returns></returns>
        [Column("MAXCHANGELENGTH")]
        public int? MAXCHANGELENGTH { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEDESTORY")]
        public string HOUSEDESTORY { get; set; }
        /// <summary>
        /// ��·������
        /// </summary>
        /// <returns></returns>
        [Column("LOADDESTORY")]
        public string LOADDESTORY { get; set; }
        /// <summary>
        /// ˮ��������
        /// </summary>
        /// <returns></returns>
        [Column("WATERDESTORY")]
        public string WATERDESTORY { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("OTHERDESTORY")]
        public string OTHERDESTORY { get; set; }
        /// <summary>
        /// ��·����
        /// </summary>
        /// <returns></returns>
        [Column("LOADNUMBER")]
        public int? LOADNUMBER { get; set; }
        /// <summary>
        /// ��·��ֵ
        /// </summary>
        /// <returns></returns>
        [Column("LOADMONEY")]
        public decimal? LOADMONEY { get; set; }
        /// <summary>
        /// ˮ������
        /// </summary>
        /// <returns></returns>
        [Column("WATERNUMBER")]
        public int? WATERNUMBER { get; set; }
        /// <summary>
        /// ˮ����ֵ
        /// </summary>
        /// <returns></returns>
        [Column("WATERMONEY")]
        public decimal? WATERMONEY { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("OTHERNUMBER")]
        public int? OTHERNUMBER { get; set; }
        /// <summary>
        /// ������ֵ
        /// </summary>
        /// <returns></returns>
        [Column("OTHERMONEY")]
        public decimal? OTHERMONEY { get; set; }
        /// <summary>
        /// ��Ա����
        /// </summary>
        /// <returns></returns>
        [Column("PEOPLENUMBER")]
        public int? PEOPLENUMBER { get; set; }
        /// <summary>
        /// ��Աʱ�ո���
        /// </summary>
        /// <returns></returns>
        [Column("PEOPLEPRECENT")]
        public decimal? PEOPLEPRECENT { get; set; }
        /// <summary>
        /// ��Ա���ü�ֵ����Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("PEOPLEMONEY")]
        public decimal? PEOPLEMONEY { get; set; }
        /// <summary>
        /// ��Ա������
        /// </summary>
        /// <returns></returns>
        [Column("PEOLPEDESTORY")]
        public string PEOLPEDESTORY { get; set; }
        /// <summary>
        /// ��ͨ��������
        /// </summary>
        /// <returns></returns>
        [Column("TOOLSNUMBER")]
        public int? TOOLSNUMBER { get; set; }
        /// <summary>
        /// ��ͨ����ʱ�ո���
        /// </summary>
        /// <returns></returns>
        [Column("TOOLSPRECENT")]
        public decimal? TOOLSPRECENT { get; set; }
        /// <summary>
        /// ��ͨ���߾��ü�ֵ����Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("TOOLSMONEY")]
        public decimal? TOOLSMONEY { get; set; }
        /// <summary>
        /// ��ͨ����������
        /// </summary>
        /// <returns></returns>
        [Column("TOOLSDESTORY")]
        public string TOOLSDESTORY { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("ANIMALNUMBER")]
        public int? ANIMALNUMBER { get; set; }
        /// <summary>
        /// ����ʱ�ո���
        /// </summary>
        /// <returns></returns>
        [Column("ANIMALPRECENT")]
        public decimal? ANIMALPRECENT { get; set; }
        /// <summary>
        /// ���󾭼ü�ֵ����Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("ANIMALMONEY")]
        public decimal? ANIMALMONEY { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("ANIMALDESTORY")]
        public string ANIMALDESTORY { get; set; }
        /// <summary>
        /// ������������������
        /// </summary>
        /// <returns></returns>
        [Column("CHANGEOTHERNUMBER")]
        public int? CHANGEOTHERNUMBER { get; set; }
        /// <summary>
        /// ��������������ʱ�ո���
        /// </summary>
        /// <returns></returns>
        [Column("CHANGEOTHERPRECENT")]
        public decimal? CHANGEOTHERPRECENT { get; set; }
        /// <summary>
        /// �������������徭�ü�ֵ����Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("CHANGEOTHERMONEY")]
        public decimal? CHANGEOTHERMONEY { get; set; }
        /// <summary>
        /// ��������������������
        /// </summary>
        /// <returns></returns>
        [Column("CHANGEOTHERDESTORY")]
        public string CHANGEOTHERDESTORY { get; set; }
        /// <summary>
        /// Ⱥ��Ⱥ���㣨0����1���ǣ�
        /// </summary>
        /// <returns></returns>
        [Column("ISQCQF")]
        public string ISQCQF { get; set; }
        /// <summary>
        /// �Ƿ�����ʾ��
        /// </summary>
        /// <returns></returns>
        [Column("ISWARNING")]
        public string ISWARNING { get; set; }
        /// <summary>
        /// ������ṹ����
        /// </summary>
        /// <returns></returns>
        [Column("HAZARDSTRUCTURETYPE")]
        public string HAZARDSTRUCTURETYPE { get; set; }
        /// <summary>
        /// ����ʧ������
        /// </summary>
        /// <returns></returns>
        [Column("REINDUCEDFACTOR")]
        public string REINDUCEDFACTOR { get; set; }
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
