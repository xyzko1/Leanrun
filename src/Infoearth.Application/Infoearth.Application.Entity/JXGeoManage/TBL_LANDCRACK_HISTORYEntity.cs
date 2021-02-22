using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 11:39
    /// �� �������ѷ�������ʷ��
    /// </summary>
    public class TBL_LANDCRACK_HISTORYEntity : BaseEntity
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
        /// ��(��)
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
        /// ����
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
        /// X
        /// </summary>
        /// <returns></returns>
        [Column("X")]
        public decimal? X { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        /// <returns></returns>
        [Column("Y")]
        public decimal? Y { get; set; }
        /// <summary>
        /// Z
        /// </summary>
        /// <returns></returns>
        [Column("Z")]
        public decimal? Z { get; set; }
        /// <summary>
        /// ��������1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNUM1")]
        public decimal? ONECRACKNUM1 { get; set; }
        /// <summary>
        /// ��������̬1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFORM1")]
        public string ONECRACKFORM1 { get; set; }
        /// <summary>
        /// ���������췽��1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDIRE1")]
        public string ONECRACKDIRE1 { get; set; }
        /// <summary>
        /// ����������1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKTENDENCY1")]
        public int? ONECRACKTENDENCY1 { get; set; }
        /// <summary>
        /// ���������1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKANGLE1")]
        public int? ONECRACKANGLE1 { get; set; }
        /// <summary>
        /// �����峤�ȣ��ף�1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKLENGTH1")]
        public string ONECRACKLENGTH1 { get; set; }
        /// <summary>
        /// �������ȣ��ף�1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKWIDTH1")]
        public string ONECRACKWIDTH1 { get; set; }
        /// <summary>
        /// ��������ȣ��ף�1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDEPTH1")]
        public string ONECRACKDEPTH1 { get; set; }
        /// <summary>
        /// �������ģ�ȼ�1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKSCALELEVEL1")]
        public string ONECRACKSCALELEVEL1 { get; set; }
        /// <summary>
        /// ����������1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNATURE1")]
        public string ONECRACKNATURE1 { get; set; }
        /// <summary>
        /// ������λ�Ʒ���1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDISPDIRE1")]
        public string ONECRACKDISPDIRE1 { get; set; }
        /// <summary>
        /// ������λ�ƾ���1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDISPDIST1")]
        public string ONECRACKDISPDIST1 { get; set; }
        /// <summary>
        /// �����������1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFILLER1")]
        public string ONECRACKFILLER1 { get; set; }
        /// <summary>
        /// ���������ʱ��1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKAPPTIME1")]
        public string ONECRACKAPPTIME1 { get; set; }
        /// <summary>
        /// ��������1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKACTIVITY1")]
        public string ONECRACKACTIVITY1 { get; set; }
        /// <summary>
        /// ��������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNUM2")]
        public decimal? ONECRACKNUM2 { get; set; }
        /// <summary>
        /// ��������̬2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFORM2")]
        public string ONECRACKFORM2 { get; set; }
        /// <summary>
        /// ���������췽��2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDIRE2")]
        public string ONECRACKDIRE2 { get; set; }
        /// <summary>
        /// ����������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKTENDENCY2")]
        public int? ONECRACKTENDENCY2 { get; set; }
        /// <summary>
        /// ���������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKANGLE2")]
        public int? ONECRACKANGLE2 { get; set; }
        /// <summary>
        /// �����峤��2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKLENGTH2")]
        public string ONECRACKLENGTH2 { get; set; }
        /// <summary>
        /// ��������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKWIDTH2")]
        public string ONECRACKWIDTH2 { get; set; }
        /// <summary>
        /// ���������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDEPTH2")]
        public string ONECRACKDEPTH2 { get; set; }
        /// <summary>
        /// �������ģ2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKSCALELEVEL2")]
        public string ONECRACKSCALELEVEL2 { get; set; }
        /// <summary>
        /// ����������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNATURE2")]
        public string ONECRACKNATURE2 { get; set; }
        /// <summary>
        /// ������λ�Ʒ���2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDISPDIRE2")]
        public string ONECRACKDISPDIRE2 { get; set; }
        /// <summary>
        /// ������λ�ƾ���2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDISPDIST2")]
        public string ONECRACKDISPDIST2 { get; set; }
        /// <summary>
        /// �����������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFILLER2")]
        public string ONECRACKFILLER2 { get; set; }
        /// <summary>
        /// ���������ʱ��2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKAPPTIME2")]
        public string ONECRACKAPPTIME2 { get; set; }
        /// <summary>
        /// ��������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKACTIVITY2")]
        public string ONECRACKACTIVITY2 { get; set; }
        /// <summary>
        /// ��������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNUM3")]
        public decimal? ONECRACKNUM3 { get; set; }
        /// <summary>
        /// ��������̬3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFORM3")]
        public string ONECRACKFORM3 { get; set; }
        /// <summary>
        /// ���������췽��3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDIRE3")]
        public string ONECRACKDIRE3 { get; set; }
        /// <summary>
        /// ����������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKTENDENCY3")]
        public int? ONECRACKTENDENCY3 { get; set; }
        /// <summary>
        /// ���������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKANGLE3")]
        public int? ONECRACKANGLE3 { get; set; }
        /// <summary>
        /// �����峤��3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKLENGTH3")]
        public string ONECRACKLENGTH3 { get; set; }
        /// <summary>
        /// ��������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKWIDTH3")]
        public string ONECRACKWIDTH3 { get; set; }
        /// <summary>
        /// ���������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDEPTH3")]
        public string ONECRACKDEPTH3 { get; set; }
        /// <summary>
        /// �������ģ3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKSCALELEVEL3")]
        public string ONECRACKSCALELEVEL3 { get; set; }
        /// <summary>
        /// ����������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNATURE3")]
        public string ONECRACKNATURE3 { get; set; }
        /// <summary>
        /// ������λ�Ʒ���3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDISPDIRE3")]
        public string ONECRACKDISPDIRE3 { get; set; }
        /// <summary>
        /// ������λ�ƾ���3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDISPDIST3")]
        public string ONECRACKDISPDIST3 { get; set; }
        /// <summary>
        /// �����������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFILLER3")]
        public string ONECRACKFILLER3 { get; set; }
        /// <summary>
        /// ���������ʱ��3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKAPPTIME3")]
        public string ONECRACKAPPTIME3 { get; set; }
        /// <summary>
        /// ��������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKACTIVITY3")]
        public string ONECRACKACTIVITY3 { get; set; }
        /// <summary>
        /// ��Ⱥ����
        /// </summary>
        /// <returns></returns>
        [Column("GROUPCRACKNUM")]
        public short? GROUPCRACKNUM { get; set; }
        /// <summary>
        /// ��Ⱥ�����ƽ���ף�
        /// </summary>
        /// <returns></returns>
        [Column("GROUPCRACKDISTRAREA")]
        public decimal? GROUPCRACKDISTRAREA { get; set; }
        /// <summary>
        /// ��Ⱥ��ࣨ���ף�
        /// </summary>
        /// <returns></returns>
        [Column("GROUPCRACKDEVELOPSPA")]
        public decimal? GROUPCRACKDEVELOPSPA { get; set; }
        /// <summary>
        /// Ⱥ��������ʽ
        /// </summary>
        /// <returns></returns>
        [Column("GROUPCRACKARRFORM")]
        public string GROUPCRACKARRFORM { get; set; }
        /// <summary>
        /// ���쳤���ף�
        /// </summary>
        /// <returns></returns>
        [Column("CRACKLENGTHMAX")]
        public decimal? CRACKLENGTHMAX { get; set; }
        /// <summary>
        /// ��С�쳤���ף�
        /// </summary>
        /// <returns></returns>
        [Column("CRACKLENGTHMIN")]
        public decimal? CRACKLENGTHMIN { get; set; }
        /// <summary>
        /// ������ף�
        /// </summary>
        /// <returns></returns>
        [Column("CRACKWIDTHMAX")]
        public decimal? CRACKWIDTHMAX { get; set; }
        /// <summary>
        /// ��С����ף�
        /// </summary>
        /// <returns></returns>
        [Column("CRACKWIDTHMIN")]
        public decimal? CRACKWIDTHMIN { get; set; }
        /// <summary>
        /// ������ף�
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTHMAX")]
        public decimal? CRACKDEPTHMAX { get; set; }
        /// <summary>
        /// ��С����ף�
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTHMIN")]
        public decimal? CRACKDEPTHMIN { get; set; }
        /// <summary>
        /// ʼ��ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("STARTTIME")]
        public string STARTTIME { get; set; }
        /// <summary>
        /// ʢ����ʼʱ��
        /// </summary>
        /// <returns></returns>
        [Column("SFSTARTTIME")]
        public string SFSTARTTIME { get; set; }
        /// <summary>
        /// ʢ������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("SFENDTIME")]
        public string SFENDTIME { get; set; }
        /// <summary>
        /// ֹͣʱ��
        /// </summary>
        /// <returns></returns>
        [Column("ENDTIME")]
        public string ENDTIME { get; set; }
        /// <summary>
        /// ���ڷ�չ
        /// </summary>
        /// <returns></returns>
        [Column("CURDEVELOPSITUATION")]
        public string CURDEVELOPSITUATION { get; set; }
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
        [Column("LANDCRACKGENETICTYPE")]
        public string LANDCRACKGENETICTYPE { get; set; }
        /// <summary>
        /// �ѷ�ȥ��ò����
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREATOPFEA")]
        public string CRACKAREATOPFEA { get; set; }
        /// <summary>
        /// �ѷ���ɽ����ɽ�¡�ɽ�Ż�ƽԭ�����������ϵ
        /// </summary>
        /// <returns></returns>
        [Column("CRACKTOPTRENDRELA")]
        public string CRACKTOPTRENDRELA { get; set; }
        /// <summary>
        /// �ѷ죨���ѣ���������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CRACKROCKSOILTIME")]
        public string CRACKROCKSOILTIME { get; set; }
        /// <summary>
        /// �ѷ죨���ѣ�������������
        /// </summary>
        /// <returns></returns>
        [Column("CRACKROCKSOILLITH")]
        public string CRACKROCKSOILLITH { get; set; }
        /// <summary>
        /// ��������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("SPLITSOILTIME")]
        public string SPLITSOILTIME { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        [Column("SPLITSOILNATURE")]
        public string SPLITSOILNATURE { get; set; }
        /// <summary>
        /// �·���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("SPLITSOILUNDERLAYERTIME")]
        public string SPLITSOILUNDERLAYERTIME { get; set; }
        /// <summary>
        /// �·�������
        /// </summary>
        /// <returns></returns>
        [Column("SPLITSOILUNDERLAYERLITH")]
        public string SPLITSOILUNDERLAYERLITH { get; set; }
        /// <summary>
        /// ����������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("SPLITROCKSOILTIME")]
        public string SPLITROCKSOILTIME { get; set; }
        /// <summary>
        /// ��������������
        /// </summary>
        /// <returns></returns>
        [Column("SPLITROCKSOILLITH")]
        public string SPLITROCKSOILLITH { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("EXPCONTSOILFEA")]
        public string EXPCONTSOILFEA { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        [Column("EXPCONTSOILEXPANSION")]
        public string EXPCONTSOILEXPANSION { get; set; }
        /// <summary>
        /// ��������ˮ��(%)
        /// </summary>
        /// <returns></returns>
        [Column("EXPCONTSOILMOICONT")]
        public decimal? EXPCONTSOILMOICONT { get; set; }
        /// <summary>
        /// �ѷ����������1������
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREASTRUFAULTTREND1")]
        public string CRACKAREASTRUFAULTTREND1 { get; set; }
        /// <summary>
        /// �ѷ����������1������
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREASTRUFAULTDIRE1")]
        public int? CRACKAREASTRUFAULTDIRE1 { get; set; }
        /// <summary>
        /// �ѷ����������1�����
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREASTRUFAULTANGLE1")]
        public int? CRACKAREASTRUFAULTANGLE1 { get; set; }
        /// <summary>
        /// �ѷ����������2������
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREASTRUFAULTTREND2")]
        public string CRACKAREASTRUFAULTTREND2 { get; set; }
        /// <summary>
        /// �ѷ����������2������
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREASTRUFAULTDIRE2")]
        public int? CRACKAREASTRUFAULTDIRE2 { get; set; }
        /// <summary>
        /// �ѷ����������2�����
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREASTRUFAULTANGLE2")]
        public int? CRACKAREASTRUFAULTANGLE2 { get; set; }
        /// <summary>
        /// �Ҳ��е���Ҫ��������
        /// </summary>
        /// <returns></returns>
        [Column("ROCKFRACDIRE")]
        public int? ROCKFRACDIRE { get; set; }
        /// <summary>
        /// �Ҳ��е���Ҫ�������
        /// </summary>
        /// <returns></returns>
        [Column("ROCKFRACANGLE")]
        public int? ROCKFRACANGLE { get; set; }
        /// <summary>
        /// �����������¶���
        /// </summary>
        /// <returns></returns>
        [Column("SOILNEWFRAC")]
        public string SOILNEWFRAC { get; set; }
        /// <summary>
        /// �������¶�������
        /// </summary>
        /// <returns></returns>
        [Column("SOILNEWFRACDIRE")]
        public int? SOILNEWFRACDIRE { get; set; }
        /// <summary>
        /// �������¶������
        /// </summary>
        /// <returns></returns>
        [Column("SOILNEWFRACANGLE")]
        public int? SOILNEWFRACANGLE { get; set; }
        /// <summary>
        /// ��Ҫ�������1������
        /// </summary>
        /// <returns></returns>
        [Column("MAINSTRUFRACTREND1")]
        public string MAINSTRUFRACTREND1 { get; set; }
        /// <summary>
        /// ��Ҫ�������1������
        /// </summary>
        /// <returns></returns>
        [Column("MAINSTRUFRACDIRE1")]
        public int? MAINSTRUFRACDIRE1 { get; set; }
        /// <summary>
        /// ��Ҫ�������1�����
        /// </summary>
        /// <returns></returns>
        [Column("MAINSTRUFRACANGLE1")]
        public int? MAINSTRUFRACANGLE1 { get; set; }
        /// <summary>
        /// ��Ҫ�������2������
        /// </summary>
        /// <returns></returns>
        [Column("MAINSTRUFRACTREND2")]
        public string MAINSTRUFRACTREND2 { get; set; }
        /// <summary>
        /// ��Ҫ�������2������
        /// </summary>
        /// <returns></returns>
        [Column("MAINSTRUFRACDIRE2")]
        public int? MAINSTRUFRACDIRE2 { get; set; }
        /// <summary>
        /// ��Ҫ�������2�����
        /// </summary>
        /// <returns></returns>
        [Column("MAINSTRUFRACANGLE2")]
        public int? MAINSTRUFRACANGLE2 { get; set; }
        /// <summary>
        /// �����µĹ������
        /// </summary>
        /// <returns></returns>
        [Column("EXPCONTSOILNEWFRAC")]
        public string EXPCONTSOILNEWFRAC { get; set; }
        /// <summary>
        /// �µĹ����������
        /// </summary>
        /// <returns></returns>
        [Column("EXPCONTSOILNEWFRACDIRE")]
        public int? EXPCONTSOILNEWFRACDIRE { get; set; }
        /// <summary>
        /// �µĹ���������
        /// </summary>
        /// <returns></returns>
        [Column("EXPCONTSOILNEWFRACANGLE")]
        public int? EXPCONTSOILNEWFRACANGLE { get; set; }
        /// <summary>
        /// ��������ף�
        /// </summary>
        /// <returns></returns>
        [Column("CAVEDEPTH")]
        public decimal? CAVEDEPTH { get; set; }
        /// <summary>
        /// ���ҹ�ģ
        /// </summary>
        /// <returns></returns>
        [Column("CAVESCALE")]
        public string CAVESCALE { get; set; }
        /// <summary>
        /// ���ҳ����ף�
        /// </summary>
        /// <returns></returns>
        [Column("CAVELENGTH")]
        public decimal? CAVELENGTH { get; set; }
        /// <summary>
        /// ���ҿ�ף�
        /// </summary>
        /// <returns></returns>
        [Column("CAVEWIDTH")]
        public decimal? CAVEWIDTH { get; set; }
        /// <summary>
        /// ���Ҹߣ��ף�
        /// </summary>
        /// <returns></returns>
        [Column("CAVEHIGH")]
        public decimal? CAVEHIGH { get; set; }
        /// <summary>
        /// ���ѷ���λ�ù�ϵ
        /// </summary>
        /// <returns></returns>
        [Column("CAVECRACKSPACERELA")]
        public string CAVECRACKSPACERELA { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CAVEEXCATIME")]
        public string CAVEEXCATIME { get; set; }
        /// <summary>
        /// ���ڷ�ʽ
        /// </summary>
        /// <returns></returns>
        [Column("CAVEEXCAMANNER")]
        public string CAVEEXCAMANNER { get; set; }
        /// <summary>
        /// ����ǿ��
        /// </summary>
        /// <returns></returns>
        [Column("CAVEEXCASTRENGTH")]
        public string CAVEEXCASTRENGTH { get; set; }
        /// <summary>
        /// ���ŵ���ˮ����
        /// </summary>
        /// <returns></returns>
        [Column("DRAGROUNDWATERTYPE")]
        public string DRAGROUNDWATERTYPE { get; set; }
        /// <summary>
        /// �����ӵ�����(M)
        /// </summary>
        /// <returns></returns>
        [Column("DRAWELLDEPTH")]
        public decimal? DRAWELLDEPTH { get; set; }
        /// <summary>
        /// ˮλˮ��
        /// </summary>
        /// <returns></returns>
        [Column("DRAWATLEVVOL")]
        public decimal? DRAWATLEVVOL { get; set; }
        /// <summary>
        /// �ճ�ˮ��
        /// </summary>
        /// <returns></returns>
        [Column("DRADAYPUMPVOL")]
        public decimal? DRADAYPUMPVOL { get; set; }
        /// <summary>
        /// ����ˮ��ʼʱ��
        /// </summary>
        /// <returns></returns>
        [Column("DRASTARTTIME")]
        public string DRASTARTTIME { get; set; }
        /// <summary>
        /// ����ˮ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("DRAENDTIME")]
        public string DRAENDTIME { get; set; }
        /// <summary>
        /// ����ˮ�Ƿ����ڼ���
        /// </summary>
        /// <returns></returns>
        [Column("DRASTATUS")]
        public string DRASTATUS { get; set; }
        /// <summary>
        /// �����Ҷ�
        /// </summary>
        /// <returns></returns>
        [Column("EARTHQUAKEINTENSITY")]
        public string EARTHQUAKEINTENSITY { get; set; }
        /// <summary>
        /// ������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("EARTHQUAKETIME")]
        public string EARTHQUAKETIME { get; set; }
        /// <summary>
        /// ��ϲ��λ��
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTSPACE")]
        public string ACTFAULTSPACE { get; set; }
        /// <summary>
        /// ��ϲ�����
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTDIRE")]
        public decimal? ACTFAULTDIRE { get; set; }
        /// <summary>
        /// ��ϲ����
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTANGLE")]
        public decimal? ACTFAULTANGLE { get; set; }
        /// <summary>
        /// ��ϲ㳤��
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTLENGTH")]
        public decimal? ACTFAULTLENGTH { get; set; }
        /// <summary>
        /// ��ϲ�����
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTNATURE")]
        public string ACTFAULTNATURE { get; set; }
        /// <summary>
        /// ��ϲ�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTTIME")]
        public string ACTFAULTTIME { get; set; }
        /// <summary>
        /// ��ϲ�����
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTACTRATE")]
        public string ACTFAULTACTRATE { get; set; }
        /// <summary>
        /// ��ϲ�Ͼ�
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTBREAKAWAY")]
        public string ACTFAULTBREAKAWAY { get; set; }
        /// <summary>
        /// ˮ��������Դ
        /// </summary>
        /// <returns></returns>
        [Column("WATROLEWATER")]
        public string WATROLEWATER { get; set; }
        /// <summary>
        /// ˮ������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("WATROLETIME")]
        public string WATROLETIME { get; set; }
        /// <summary>
        /// ˮ������ˮ�ʣ�PH)
        /// </summary>
        /// <returns></returns>
        [Column("WATROLEWATERQUA")]
        public string WATROLEWATERQUA { get; set; }
        /// <summary>
        /// ����ж������
        /// </summary>
        /// <returns></returns>
        [Column("WATROLETYPE")]
        public string WATROLETYPE { get; set; }
        /// <summary>
        /// ����ж�ɿ���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("WATROLEEXCATIME")]
        public string WATROLEEXCATIME { get; set; }
        /// <summary>
        /// ����ж�ɷ�ʽ
        /// </summary>
        /// <returns></returns>
        [Column("WATROLEEXCAMANNER")]
        public string WATROLEEXCAMANNER { get; set; }
        /// <summary>
        /// ����ж�����
        /// </summary>
        /// <returns></returns>
        [Column("WATROLEEXCADEPTH")]
        public decimal? WATROLEEXCADEPTH { get; set; }
        /// <summary>
        /// �ٻ�����(��)
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOME")]
        public int? DESTROYEDHOME { get; set; }
        /// <summary>
        /// ��Ͻ�ͨ������
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKINGTRAFFIC")]
        public int? BLOCKINGTRAFFIC { get; set; }
        /// <summary>
        /// �����˿ڣ��ˣ�
        /// </summary>
        /// <returns></returns>
        [Column("DEATHNUM")]
        public int? DEATHNUM { get; set; }
        /// <summary>
        /// ֱ����ʧ����Ԫ��
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
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENPOINT")]
        public string HIDDENPOINT { get; set; }
        /// <summary>
        /// Ǳ����в���ݣ�����
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOME")]
        public int? THREATENHOME { get; set; }
        /// <summary>
        /// Ǳ����в��Ͻ�ͨ������
        /// </summary>
        /// <returns></returns>
        [Column("TRAFFICHAZARDS")]
        public int? TRAFFICHAZARDS { get; set; }
        /// <summary>
        /// Ǳ���ֺ���в�˿ڣ��ˣ�
        /// </summary>
        /// <returns></returns>
        [Column("THREATENPEOPLE")]
        public int? THREATENPEOPLE { get; set; }
        /// <summary>
        /// Ǳ���ֺ���в�Ʋ�����Ԫ��
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
        /// �ѷ췢չԤ��
        /// </summary>
        /// <returns></returns>
        [Column("DEVELOPFORECAST")]
        public string DEVELOPFORECAST { get; set; }
        /// <summary>
        /// �Ƿ��з���Ԥ��/Ⱥ��Ⱥ����
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONPLAN")]
        public string PREVENTIONPLAN { get; set; }
        /// <summary>
        /// ���δ�ʩ
        /// </summary>
        /// <returns></returns>
        [Column("TREATMENTMEASURE")]
        public string TREATMENTMEASURE { get; set; }
        /// <summary>
        /// ���ν���
        /// </summary>
        /// <returns></returns>
        [Column("TREATMENTSUGGESTION")]
        public string TREATMENTSUGGESTION { get; set; }
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
        /// ���ŵ���ˮ���ѷ�����λ�ù�ϵ
        /// </summary>
        /// <returns></returns>
        [Column("DRAWATERSPACERELA")]
        public string DRAWATERSPACERELA { get; set; }
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
        /// ƽ��Ⱥ������
        /// </summary>
        /// <returns></returns>
        [Column("PARADIR")]
        public int? PARADIR { get; set; }
        /// <summary>
        /// ƽ��Ⱥ�����
        /// </summary>
        /// <returns></returns>
        [Column("PARAANGLE")]
        public int? PARAANGLE { get; set; }
        /// <summary>
        /// ƽ��Ⱥ��ײ�ָ��
        /// </summary>
        /// <returns></returns>
        [Column("PARASTEPFORWARD")]
        public string PARASTEPFORWARD { get; set; }
        /// <summary>
        /// б��Ⱥ������
        /// </summary>
        /// <returns></returns>
        [Column("INCLINEDDIR")]
        public int? INCLINEDDIR { get; set; }
        /// <summary>
        /// б��Ⱥ�����
        /// </summary>
        /// <returns></returns>
        [Column("INCLINEDANGLE")]
        public int? INCLINEDANGLE { get; set; }
        /// <summary>
        /// б��Ⱥ��ײ�ָ��
        /// </summary>
        /// <returns></returns>
        [Column("INCLINEDSTEPFORWARD")]
        public string INCLINEDSTEPFORWARD { get; set; }
        /// <summary>
        /// ��ΧȺ��Բ��λ�þ���
        /// </summary>
        /// <returns></returns>
        [Column("ARROUNDCIRCLEPOSITIONLONGITUDE")]
        public decimal? ARROUNDCIRCLEPOSITIONLONGITUDE { get; set; }
        /// <summary>
        /// ��ΧȺ��Բ��λ��γ��
        /// </summary>
        /// <returns></returns>
        [Column("ARROUNDCIRCLEPOSITIONLATITUDE")]
        public decimal? ARROUNDCIRCLEPOSITIONLATITUDE { get; set; }
        /// <summary>
        /// �Ƿ��жϲ�
        /// </summary>
        /// <returns></returns>
        [Column("ISFRACTUREACTIVITY")]
        public string ISFRACTUREACTIVITY { get; set; }
        /// <summary>
        /// ��Ͻ�ͨ(Сʱ)
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKTRAFFHOURS")]
        public short? BLOCKTRAFFHOURS { get; set; }
        /// <summary>
        /// ���ѷ�������������
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDFACTORS")]
        public string INDUCEDFACTORS { get; set; }
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
        /// Ǳ����в���ݣ��䣩
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOUSE")]
        public int? THREATENHOUSE { get; set; }
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
        /// ���״̬��0������ƣ�1�����ͨ����2����Ʋ�ͨ����
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
        ///   ���鸺����ID  
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYHEADERID")]
        public string SURVEYHEADERID { get; set; }
        /// <summary>
        ///   �����ID  
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEPEOPLEID")]
        public string FILLTABLEPEOPLEID { get; set; }
        /// <summary>
        ///   �����ID  
        /// </summary>
        /// <returns></returns>
        [Column("VERIFYPEOPLEID")]
        public string VERIFYPEOPLEID { get; set; }
        /// <summary>
        ///   ���鵥λID  
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYDEPTID")]
        public string SURVEYDEPTID { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("VERIFICATION")]
        public string VERIFICATION { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        [Column("ELEVATION")]
        public decimal? ELEVATION { get; set; }
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
        /// ������������ĸ�ʪ�仯
        /// </summary>
        /// <returns></returns>
        [Column("QTZYYQGSBH")]
        public string QTZYYQGSBH { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("ZLWZ")]
        public string ZLWZ { get; set; }
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