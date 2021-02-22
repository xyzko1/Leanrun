using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 11:37
    /// �� �����������ݵ������ʷ��
    /// </summary>
    public class TBL_COLLAPSE_HISTORYEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ͳһ���
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// CGHMDBϵͳ�ֺ������
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
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("Z")]
        public decimal? Z { get; set; }
        /// <summary>
        /// �����ݿӿӺ�1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCONUM1")]
        public string MONOCONUM1 { get; set; }
        /// <summary>
        /// �����ݿ���״1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOSHAPE1")]
        public string MONOCOSHAPE1 { get; set; }
        /// <summary>
        /// �����ݿӿӿڹ�ģ1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOSCALE1")]
        public decimal? MONOCOSCALE1 { get; set; }
        /// <summary>
        /// �����ݿ����1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCODEPTH1")]
        public decimal? MONOCODEPTH1 { get; set; }
        /// <summary>
        /// �����ݿӱ������1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOAREA1")]
        public decimal? MONOCOAREA1 { get; set; }
        /// <summary>
        /// �����ݿӹ�ģ�ȼ�1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOLEVEL1")]
        public string MONOCOLEVEL1 { get; set; }
        /// <summary>
        /// �����ݿӳ��᷽��1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOAXISDIRE1")]
        public string MONOCOAXISDIRE1 { get; set; }
        /// <summary>
        /// �����ݿӳ�ˮˮλ��1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOWATLEVDEPTH1")]
        public decimal? MONOCOWATLEVDEPTH1 { get; set; }
        /// <summary>
        /// �����ݿ�ˮλ�䶯1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOWATLEVCHANGE1")]
        public decimal? MONOCOWATLEVCHANGE1 { get; set; }
        /// <summary>
        /// �����ݿӷ���ʱ��1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOTIME1")]
        public string MONOCOTIME1 { get; set; }
        /// <summary>
        /// �����ݿӷ�չ�仯1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCODEVELOPCHANGE1")]
        public string MONOCODEVELOPCHANGE1 { get; set; }
        /// <summary>
        /// �����ݿӿӺ�2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCONUM2")]
        public string MONOCONUM2 { get; set; }
        /// <summary>
        /// �����ݿ���״2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOSHAPE2")]
        public string MONOCOSHAPE2 { get; set; }
        /// <summary>
        /// �����ݿӿӿڹ�ģ2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOSCALE2")]
        public decimal? MONOCOSCALE2 { get; set; }
        /// <summary>
        /// �����ݿ����2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCODEPTH2")]
        public decimal? MONOCODEPTH2 { get; set; }
        /// <summary>
        /// �����ݿӱ������2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOAREA2")]
        public decimal? MONOCOAREA2 { get; set; }
        /// <summary>
        /// �����ݿӹ�ģ�ȼ�2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOLEVEL2")]
        public string MONOCOLEVEL2 { get; set; }
        /// <summary>
        /// �����ݿӳ��᷽��2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOAXISDIRE2")]
        public string MONOCOAXISDIRE2 { get; set; }
        /// <summary>
        /// �����ݿӳ�ˮˮλ��2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOWATLEVDEPTH2")]
        public decimal? MONOCOWATLEVDEPTH2 { get; set; }
        /// <summary>
        /// �����ݿ�ˮλ�䶯2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOWATLEVCHANGE2")]
        public decimal? MONOCOWATLEVCHANGE2 { get; set; }
        /// <summary>
        /// �����ݿӷ���ʱ��2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOTIME2")]
        public string MONOCOTIME2 { get; set; }
        /// <summary>
        /// �����ݿӷ�չ�仯2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCODEVELOPCHANGE2")]
        public string MONOCODEVELOPCHANGE2 { get; set; }
        /// <summary>
        /// �����ݿӿӺ�3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCONUM3")]
        public string MONOCONUM3 { get; set; }
        /// <summary>
        /// �����ݿ���״3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOSHAPE3")]
        public string MONOCOSHAPE3 { get; set; }
        /// <summary>
        /// �����ݿӿӿڹ�ģ3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOSCALE3")]
        public decimal? MONOCOSCALE3 { get; set; }
        /// <summary>
        /// �����ݿ����3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCODEPTH3")]
        public decimal? MONOCODEPTH3 { get; set; }
        /// <summary>
        /// �����ݿӱ������3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOAREA3")]
        public decimal? MONOCOAREA3 { get; set; }
        /// <summary>
        /// �����ݿӹ�ģ�ȼ�3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOLEVEL3")]
        public string MONOCOLEVEL3 { get; set; }
        /// <summary>
        /// �����ݿӳ��᷽��3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOAXISDIRE3")]
        public string MONOCOAXISDIRE3 { get; set; }
        /// <summary>
        /// �����ݿӳ�ˮˮλ��3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOWATLEVDEPTH3")]
        public decimal? MONOCOWATLEVDEPTH3 { get; set; }
        /// <summary>
        /// �����ݿ�ˮλ�䶯3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOWATLEVCHANGE3")]
        public decimal? MONOCOWATLEVCHANGE3 { get; set; }
        /// <summary>
        /// �����ݿӷ���ʱ��3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOTIME3")]
        public string MONOCOTIME3 { get; set; }
        /// <summary>
        /// �����ݿӷ�չ�仯3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCODEVELOPCHANGE3")]
        public string MONOCODEVELOPCHANGE3 { get; set; }
        /// <summary>
        /// �ݿӿ���
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSENUM")]
        public short? COLLAPSENUM { get; set; }
        /// <summary>
        /// �ݿӷֲ����
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEDISTRAREA")]
        public string COLLAPSEDISTRAREA { get; set; }
        /// <summary>
        /// ������ʽ
        /// </summary>
        /// <returns></returns>
        [Column("ARRFORM")]
        public string ARRFORM { get; set; }
        /// <summary>
        /// ���з���
        /// </summary>
        /// <returns></returns>
        [Column("LONGLISTDIRE")]
        public string LONGLISTDIRE { get; set; }
        /// <summary>
        /// ��С�ݿӿھ�
        /// </summary>
        /// <returns></returns>
        [Column("MINCOLLAPSECALIBER")]
        public decimal? MINCOLLAPSECALIBER { get; set; }
        /// <summary>
        /// ����ݿӿھ�
        /// </summary>
        /// <returns></returns>
        [Column("MAXCOLLAPSECALIBER")]
        public decimal? MAXCOLLAPSECALIBER { get; set; }
        /// <summary>
        /// ��С�ݿ����
        /// </summary>
        /// <returns></returns>
        [Column("MINCOLLAPSEDEPTH")]
        public decimal? MINCOLLAPSEDEPTH { get; set; }
        /// <summary>
        /// ����ݿ����
        /// </summary>
        /// <returns></returns>
        [Column("MAXCOLLAPSEDEPTH")]
        public decimal? MAXCOLLAPSEDEPTH { get; set; }
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
        /// ʢ����ֹʱ��
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
        [Column("DEVELOPING")]
        public string DEVELOPING { get; set; }
        /// <summary>
        /// ������1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNUM1")]
        public string ONECRACKNUM1 { get; set; }
        /// <summary>
        /// ������̬1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFORM1")]
        public string ONECRACKFORM1 { get; set; }
        /// <summary>
        /// �������췽��1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDIRE1")]
        public string ONECRACKDIRE1 { get; set; }
        /// <summary>
        /// ��������1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKTENDENCY1")]
        public int? ONECRACKTENDENCY1 { get; set; }
        /// <summary>
        /// �������1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKANGLE1")]
        public int? ONECRACKANGLE1 { get; set; }
        /// <summary>
        /// ���쳤��1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKLENGTH1")]
        public decimal? ONECRACKLENGTH1 { get; set; }
        /// <summary>
        /// ������1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKWIDTH1")]
        public decimal? ONECRACKWIDTH1 { get; set; }
        /// <summary>
        /// �������1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDEPTH1")]
        public decimal? ONECRACKDEPTH1 { get; set; }
        /// <summary>
        /// ��������1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNATURE1")]
        public string ONECRACKNATURE1 { get; set; }
        /// <summary>
        /// ������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNUM2")]
        public string ONECRACKNUM2 { get; set; }
        /// <summary>
        /// ������̬2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFORM2")]
        public string ONECRACKFORM2 { get; set; }
        /// <summary>
        /// �������췽��2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDIRE2")]
        public string ONECRACKDIRE2 { get; set; }
        /// <summary>
        /// ��������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKTENDENCY2")]
        public int? ONECRACKTENDENCY2 { get; set; }
        /// <summary>
        /// �������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKANGLE2")]
        public int? ONECRACKANGLE2 { get; set; }
        /// <summary>
        /// ���쳤��2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKLENGTH2")]
        public decimal? ONECRACKLENGTH2 { get; set; }
        /// <summary>
        /// ������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKWIDTH2")]
        public decimal? ONECRACKWIDTH2 { get; set; }
        /// <summary>
        /// �������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDEPTH2")]
        public decimal? ONECRACKDEPTH2 { get; set; }
        /// <summary>
        /// ��������2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNATURE2")]
        public string ONECRACKNATURE2 { get; set; }
        /// <summary>
        /// ������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNUM3")]
        public string ONECRACKNUM3 { get; set; }
        /// <summary>
        /// ������̬3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFORM3")]
        public string ONECRACKFORM3 { get; set; }
        /// <summary>
        /// �������췽��3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDIRE3")]
        public string ONECRACKDIRE3 { get; set; }
        /// <summary>
        /// ��������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKTENDENCY3")]
        public int? ONECRACKTENDENCY3 { get; set; }
        /// <summary>
        /// �������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKANGLE3")]
        public int? ONECRACKANGLE3 { get; set; }
        /// <summary>
        /// ���쳤��3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKLENGTH3")]
        public decimal? ONECRACKLENGTH3 { get; set; }
        /// <summary>
        /// ������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKWIDTH3")]
        public decimal? ONECRACKWIDTH3 { get; set; }
        /// <summary>
        /// �������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDEPTH3")]
        public decimal? ONECRACKDEPTH3 { get; set; }
        /// <summary>
        /// ��������3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNATURE3")]
        public string ONECRACKNATURE3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("CRACKNUM")]
        public int? CRACKNUM { get; set; }
        /// <summary>
        /// �ѷ�ֲ����
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDISTRAREA")]
        public decimal? CRACKDISTRAREA { get; set; }
        /// <summary>
        /// �ѷ���
        /// </summary>
        /// <returns></returns>
        [Column("CRACKSPACE")]
        public decimal? CRACKSPACE { get; set; }
        /// <summary>
        /// �ѷ�������ʽ
        /// </summary>
        /// <returns></returns>
        [Column("CRACKARRFORM")]
        public string CRACKARRFORM { get; set; }
        /// <summary>
        /// �ѷ�����
        /// </summary>
        /// <returns></returns>
        [Column("CRACKTENDENCY")]
        public int? CRACKTENDENCY { get; set; }
        /// <summary>
        /// �ѷ����
        /// </summary>
        /// <returns></returns>
        [Column("CRACKANGLE")]
        public int? CRACKANGLE { get; set; }
        /// <summary>
        /// �ѷ쳤MAX
        /// </summary>
        /// <returns></returns>
        [Column("CRACKLENGTHMAX")]
        public decimal? CRACKLENGTHMAX { get; set; }
        /// <summary>
        /// �ѷ쳤MIN
        /// </summary>
        /// <returns></returns>
        [Column("CRACKLENGTHMIN")]
        public decimal? CRACKLENGTHMIN { get; set; }
        /// <summary>
        /// �ѷ��MAX
        /// </summary>
        /// <returns></returns>
        [Column("CRACKWIDTHMAX")]
        public decimal? CRACKWIDTHMAX { get; set; }
        /// <summary>
        /// �ѷ��MIN
        /// </summary>
        /// <returns></returns>
        [Column("CRACKWIDTHMIN")]
        public decimal? CRACKWIDTHMIN { get; set; }
        /// <summary>
        /// �ѷ���MAX
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTHMAX")]
        public decimal? CRACKDEPTHMAX { get; set; }
        /// <summary>
        /// �ѷ���MIN
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTHMIN")]
        public decimal? CRACKDEPTHMIN { get; set; }
        /// <summary>
        /// ��������ò����
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEAREATOPFEA")]
        public string COLLAPSEAREATOPFEA { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEGENETICTYPE")]
        public string COLLAPSEGENETICTYPE { get; set; }
        /// <summary>
        /// �������ݵز�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOSTRATIGRAPHICTIME")]
        public string KARSTCOSTRATIGRAPHICTIME { get; set; }
        /// <summary>
        /// �������ݵز�����
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOLITH")]
        public string KARSTCOLITH { get; set; }
        /// <summary>
        /// ���������Ҳ�����
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOSTRATUMDIRE")]
        public int? KARSTCOSTRATUMDIRE { get; set; }
        /// <summary>
        /// ���������Ҳ����
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOSTRATUMANGLE")]
        public int? KARSTCOSTRATUMANGLE { get; set; }
        /// <summary>
        /// �������ݶ������
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOFRACSITUATION")]
        public string KARSTCOFRACSITUATION { get; set; }
        /// <summary>
        /// ���������ܶ��������
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOCAVEDEVELOPSITUATION")]
        public string KARSTCOCAVEDEVELOPSITUATION { get; set; }
        /// <summary>
        /// ���������Ҳ㷢���̶�
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOROCKDEVELOPDEGREE")]
        public string KARSTCOROCKDEVELOPDEGREE { get; set; }
        /// <summary>
        /// �������������ܶ�����
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOROOFCAVEDEPTH")]
        public decimal? KARSTCOROOFCAVEDEPTH { get; set; }
        /// <summary>
        /// �������ݵ���ˮλ����
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOGROUNDWATERDEPTH")]
        public decimal? KARSTCOGROUNDWATERDEPTH { get; set; }
        /// <summary>
        /// ���������շ���������
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOTRIGGERSPOWER")]
        public string KARSTCOTRIGGERSPOWER { get; set; }
        /// <summary>
        /// �������ݵ�������
        /// </summary>
        /// <returns></returns>
        [Column("HOLECOSINGLESOILNATURE")]
        public string HOLECOSINGLESOILNATURE { get; set; }
        /// <summary>
        /// �������ݵ�������
        /// </summary>
        /// <returns></returns>
        [Column("HOLECOSINGLESOILTHICK")]
        public decimal? HOLECOSINGLESOILTHICK { get; set; }
        /// <summary>
        /// ��������˫���ϲ�����
        /// </summary>
        /// <returns></returns>
        [Column("HOLECODOUBTOPSOILNATURE")]
        public string HOLECODOUBTOPSOILNATURE { get; set; }
        /// <summary>
        /// ��������˫���ϲ�����
        /// </summary>
        /// <returns></returns>
        [Column("HOLECODOUBTOPSOILTHICK")]
        public decimal? HOLECODOUBTOPSOILTHICK { get; set; }
        /// <summary>
        /// ��������˫���²�����
        /// </summary>
        /// <returns></returns>
        [Column("HOLECODOUBLOWERSOILNATURE")]
        public string HOLECODOUBLOWERSOILNATURE { get; set; }
        /// <summary>
        /// ��������˫���²�����
        /// </summary>
        /// <returns></returns>
        [Column("HOLECODOUBLOWERSOILTHICK")]
        public decimal? HOLECODOUBLOWERSOILTHICK { get; set; }
        /// <summary>
        /// ���������·�����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("HOLECOUNDERBEDROCKTIME")]
        public string HOLECOUNDERBEDROCKTIME { get; set; }
        /// <summary>
        /// ���������·���������
        /// </summary>
        /// <returns></returns>
        [Column("HOLECOUNDERBEDROCKLITH")]
        public string HOLECOUNDERBEDROCKLITH { get; set; }
        /// <summary>
        /// �������ݵ���ˮλ����
        /// </summary>
        /// <returns></returns>
        [Column("HOLECOGROUNDWATERDEPTH")]
        public decimal? HOLECOGROUNDWATERDEPTH { get; set; }
        /// <summary>
        /// ���������շ���������
        /// </summary>
        /// <returns></returns>
        [Column("HOLECOTRIGGERSPOWER")]
        public string HOLECOTRIGGERSPOWER { get; set; }
        /// <summary>
        /// ��λ����������
        /// </summary>
        /// <returns></returns>
        [Column("WELLPLACECOAREADIRE")]
        public string WELLPLACECOAREADIRE { get; set; }
        /// <summary>
        /// ��λ����������
        /// </summary>
        /// <returns></returns>
        [Column("WELLPLACECOAREADIST")]
        public decimal? WELLPLACECOAREADIST { get; set; }
        /// <summary>
        /// ��λ��������ˮ����
        /// </summary>
        /// <returns></returns>
        [Column("WELLPLACECOAREAPUMPDEPTH")]
        public decimal? WELLPLACECOAREAPUMPDEPTH { get; set; }
        /// <summary>
        /// ��λ�������ճ�ˮ��
        /// </summary>
        /// <returns></returns>
        [Column("WELLPLACECOAREADAYPUMPVOL")]
        public decimal? WELLPLACECOAREADAYPUMPVOL { get; set; }
        /// <summary>
        /// ����ˮλ����������
        /// </summary>
        /// <returns></returns>
        [Column("RIVERWATLEVCOAREADIRE")]
        public string RIVERWATLEVCOAREADIRE { get; set; }
        /// <summary>
        /// ����ˮλ����������
        /// </summary>
        /// <returns></returns>
        [Column("RIVERWATLEVCOAREADIST")]
        public decimal? RIVERWATLEVCOAREADIST { get; set; }
        /// <summary>
        /// ����ˮλ������ˮλ���
        /// </summary>
        /// <returns></returns>
        [Column("RIVERWATLEVCOAREAAMP")]
        public decimal? RIVERWATLEVCOAREAAMP { get; set; }
        /// <summary>
        /// ����ˮλ�������仯����
        /// </summary>
        /// <returns></returns>
        [Column("RIVERWATLEVCOAREACHANGETYPE")]
        public string RIVERWATLEVCOAREACHANGETYPE { get; set; }
        /// <summary>
        /// ð����������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSOILTIME")]
        public string ROOFFALLCOSOILTIME { get; set; }
        /// <summary>
        /// ð��������������
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSOILNATURE")]
        public string ROOFFALLCOSOILNATURE { get; set; }
        /// <summary>
        /// ð������������
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSOILTHICK")]
        public decimal? ROOFFALLCOSOILTHICK { get; set; }
        /// <summary>
        /// ð�������Ҳ�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSTRATUMTIME")]
        public string ROOFFALLCOSTRATUMTIME { get; set; }
        /// <summary>
        /// ð�������Ҳ�����
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSTRATUMLITH")]
        public string ROOFFALLCOSTRATUMLITH { get; set; }
        /// <summary>
        /// ð�������Ҳ���
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSTRATUMTHICK")]
        public decimal? ROOFFALLCOSTRATUMTHICK { get; set; }
        /// <summary>
        /// ð�����ݵ���ˮλ����
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOGROUNDWATERDEPTH")]
        public decimal? ROOFFALLCOGROUNDWATERDEPTH { get; set; }
        /// <summary>
        /// ð�������շ���������
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOTRIGGERSPOWER")]
        public string ROOFFALLCOTRIGGERSPOWER { get; set; }
        /// <summary>
        /// ð�����ݿ����
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSEAMTHICK")]
        public decimal? ROOFFALLCOSEAMTHICK { get; set; }
        /// <summary>
        /// ð�����ݿ���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOMINETIME")]
        public string ROOFFALLCOMINETIME { get; set; }
        /// <summary>
        /// ð�����ݿ��ɺ��
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOMINETHICK")]
        public decimal? ROOFFALLCOMINETHICK { get; set; }
        /// <summary>
        /// ð�����ݿ������
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOMINEDEPTH")]
        public decimal? ROOFFALLCOMINEDEPTH { get; set; }
        /// <summary>
        /// ð�����ݿ��ɷ���
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOMINEMETHOD")]
        public string ROOFFALLCOMINEMETHOD { get; set; }
        /// <summary>
        /// ð�����ݹ������ƽ��ٶ�
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOWORKSURFFORWSPEED")]
        public decimal? ROOFFALLCOWORKSURFFORWSPEED { get; set; }
        /// <summary>
        /// ð�����ݲɳ���
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOMINEVOL")]
        public decimal? ROOFFALLCOMINEVOL { get; set; }
        /// <summary>
        /// ð�����ݶ��������
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOROOFMANAGEMETHOD")]
        public string ROOFFALLCOROOFMANAGEMETHOD { get; set; }
        /// <summary>
        /// ð�������ظ��ɶ�
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOREPEATMINE")]
        public string ROOFFALLCOREPEATMINE { get; set; }
        /// <summary>
        /// ð�����ݲɿ�����̬
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOGOBFORM")]
        public string ROOFFALLCOGOBFORM { get; set; }
        /// <summary>
        /// ð�����ݲɿ�����ģ
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOGOBSCALE")]
        public string ROOFFALLCOGOBSCALE { get; set; }
        /// <summary>
        /// �ٻ����
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDFARM")]
        public decimal? DESTROYEDFARM { get; set; }
        /// <summary>
        /// �ٻ�����
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOME")]
        public decimal? DESTROYEDHOME { get; set; }
        /// <summary>
        /// ��Ͻ�ͨ
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKINGTRAFFIC")]
        public string BLOCKINGTRAFFIC { get; set; }
        /// <summary>
        /// ����ˮԴ�ݽ�
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATEREXHAUSTED")]
        public string GROUNDWATEREXHAUSTED { get; set; }
        /// <summary>
        /// ����ˮ��ͻˮ
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATERINRUSH")]
        public string GROUNDWATERINRUSH { get; set; }
        /// <summary>
        /// �����������
        /// </summary>
        /// <returns></returns>
        [Column("BURYGROUNDSUBSTANCE")]
        public string BURYGROUNDSUBSTANCE { get; set; }
        /// <summary>
        /// �����˿�
        /// </summary>
        /// <returns></returns>
        [Column("DEATHNUM")]
        public int? DEATHNUM { get; set; }
        /// <summary>
        /// ֱ����ʧ
        /// </summary>
        /// <returns></returns>
        [Column("DIRETLOSSES")]
        public decimal? DIRETLOSSES { get; set; }
        /// <summary>
        /// ����ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERLEVEL")]
        public string DISASTERLEVEL { get; set; }
        /// <summary>
        /// �����ݿ�
        /// </summary>
        /// <returns></returns>
        [Column("ADDCOLLAPSE")]
        public short? ADDCOLLAPSE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("EXPCOLLAPSEAREA")]
        public decimal? EXPCOLLAPSEAREA { get; set; }
        /// <summary>
        /// Ǳ�ڻ���
        /// </summary>
        /// <returns></returns>
        [Column("POTDESTROYEDFARM")]
        public decimal? POTDESTROYEDFARM { get; set; }
        /// <summary>
        /// Ǳ�ڻٷ�
        /// </summary>
        /// <returns></returns>
        [Column("POTDESTROYEDHOME")]
        public int? POTDESTROYEDHOME { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("APPNEWCOLLAPSE")]
        public int? APPNEWCOLLAPSE { get; set; }
        /// <summary>
        /// ���������
        /// </summary>
        /// <returns></returns>
        [Column("NEWCOLLAPSEAREA")]
        public decimal? NEWCOLLAPSEAREA { get; set; }
        /// <summary>
        /// ��·
        /// </summary>
        /// <returns></returns>
        [Column("OPENCIRCUIT")]
        public decimal? OPENCIRCUIT { get; set; }
        /// <summary>
        /// ����Σ��
        /// </summary>
        /// <returns></returns>
        [Column("OTHERHARM")]
        public string OTHERHARM { get; set; }
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
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENPOINT")]
        public string HIDDENPOINT { get; set; }
        /// <summary>
        /// ����Ԥ��
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
        /// �ײ�ָ��
        /// </summary>
        /// <returns></returns>
        [Column("HOMPOINT")]
        public string HOMPOINT { get; set; }
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
        /// �����������
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEDESC")]
        public string COLLAPSEDESC { get; set; }
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
        /// �����·��M)
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKINGRAILWAY")]
        public decimal? BLOCKINGRAILWAY { get; set; }
        /// <summary>
        /// ��Ϲ�·
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKINGROAD")]
        public decimal? BLOCKINGROAD { get; set; }
        /// <summary>
        /// ���ͨѶ(Сʱ)
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKINGCOMMUNICATION")]
        public decimal? BLOCKINGCOMMUNICATION { get; set; }
        /// <summary>
        /// ˮ������(������/�룩
        /// </summary>
        /// <returns></returns>
        [Column("WATERINCREASE")]
        public decimal? WATERINCREASE { get; set; }
        /// <summary>
        /// ������ʧ
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERLOSS")]
        public decimal? DISASTERLOSS { get; set; }
        /// <summary>
        /// �;���ʧ����Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("FLOODEDWELLLOSS")]
        public decimal? FLOODEDWELLLOSS { get; set; }
        /// <summary>
        /// ��ˮ����
        /// </summary>
        /// <returns></returns>
        [Column("RIVERWATERREDUCE")]
        public decimal? RIVERWATERREDUCE { get; set; }
        /// <summary>
        /// ����(������/�ף�
        /// </summary>
        /// <returns></returns>
        [Column("INTERRUPTEDRIVERWATER")]
        public decimal? INTERRUPTEDRIVERWATER { get; set; }
        /// <summary>
        /// ��Ȫˮ��������
        /// </summary>
        /// <returns></returns>
        [Column("WELLWATERREDUCE")]
        public decimal? WELLWATERREDUCE { get; set; }
        /// <summary>
        /// ˮλ���ͣ��ף�
        /// </summary>
        /// <returns></returns>
        [Column("WATERLEVELREDUCE")]
        public decimal? WATERLEVELREDUCE { get; set; }
        /// <summary>
        /// ��в���ݣ�����
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOME")]
        public int? THREATENHOME { get; set; }
        /// <summary>
        /// ��в����
        /// </summary>
        /// <returns></returns>
        [Column("THREATENOBJ")]
        public string THREATENOBJ { get; set; }
        /// <summary>
        /// Σ������
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDOBJ")]
        public string DESTROYEDOBJ { get; set; }
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
        /// Ⱥ����ԱID
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
        [Column("SURVERYHEADERID")]
        public string SURVERYHEADERID { get; set; }
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
        /// ���鵥λ
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYDEPTID")]
        public string SURVEYDEPTID { get; set; }
        /// <summary>
        /// �Ƿ񵥲�
        /// </summary>
        /// <returns></returns>
        [Column("ISHOLECOSINGLE")]
        public string ISHOLECOSINGLE { get; set; }
        /// <summary>
        /// �Ƿ�˫��
        /// </summary>
        /// <returns></returns>
        [Column("ISHOLECODOUBLE")]
        public string ISHOLECODOUBLE { get; set; }
        /// <summary>
        /// �׶�ָ��
        /// </summary>
        /// <returns></returns>
        [Column("CRACKSTAGEPOINT")]
        public int? CRACKSTAGEPOINT { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("VERIFICATION")]
        public string VERIFICATION { get; set; }

        /// <summary>
        /// ������ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERRISKLEVEL")]
        public string DISASTERRISKLEVEL { get; set; }
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
        /// �ɿ�
        /// </summary>
        /// <returns></returns>
        [Column("GK")]
        public string GK { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("BG")]
        public string BG { get; set; }
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