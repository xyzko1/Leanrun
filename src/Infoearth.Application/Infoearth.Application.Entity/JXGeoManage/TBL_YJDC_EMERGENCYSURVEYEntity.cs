using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-13 13:27
    /// �� ����
    /// </summary>
    public class TBL_YJDC_EMERGENCYSURVEYEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ���������(����������)
        /// </summary>
        /// <returns></returns>
        [Column("NAME")]
        public string NAME { get; set; }
        /// <summary>
        /// ʡ
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONPROVINCE")]
        public string GOEPOSITIONPROVINCE { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONCITY")]
        public string GOEPOSITIONCITY { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONCOUNTY")]
        public string GOEPOSITIONCOUNTY { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONTOWN")]
        public string GOEPOSITIONTOWN { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONVILLAGE")]
        public string GOEPOSITIONVILLAGE { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONGROUP")]
        public string GOEPOSITIONGROUP { get; set; }
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
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("OCCURRENCETIME")]
        public DateTime? OCCURRENCETIME { get; set; }
        /// <summary>
        /// �Ƿ��ڲ�
        /// </summary>
        /// <returns></returns>
        [Column("ISREGISTERED")]
        public short? ISREGISTERED { get; set; }
        /// <summary>
        /// �ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("TYPE")]
        public string TYPE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERDEATHPEOPLENUM")]
        public short? DISASTERDEATHPEOPLENUM { get; set; }
        /// <summary>
        /// ʧ������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERMISSINGPEOPLENUM")]
        public short? DISASTERMISSINGPEOPLENUM { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERINJURYPEOPLENUM")]
        public short? DISASTERINJURYPEOPLENUM { get; set; }
        /// <summary>
        /// �ٻ�����
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERDESTRUCTEDHOUSENUM")]
        public short? DISASTERDESTRUCTEDHOUSENUM { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DISASTEROTHER")]
        public string DISASTEROTHER { get; set; }
        /// <summary>
        /// Ǳ�ھ�����ʧ
        /// </summary>
        /// <returns></returns>
        [Column("DANGERPOTENTIALECONOMICLOSSES")]
        public decimal? DANGERPOTENTIALECONOMICLOSSES { get; set; }
        /// <summary>
        /// ����ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DANGERGRATE")]
        public string DANGERGRATE { get; set; }
        /// <summary>
        /// ��չ�������
        /// </summary>
        /// <returns></returns>
        [Column("GOVERNMENTDEPARTMENT")]
        public string GOVERNMENTDEPARTMENT { get; set; }
        /// <summary>
        /// ҽ�Ʋ���
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALDEPARTMENT")]
        public string MEDICALDEPARTMENT { get; set; }
        /// <summary>
        /// �侯�ٱ�
        /// </summary>
        /// <returns></returns>
        [Column("ARMEDPOLICE")]
        public string ARMEDPOLICE { get; set; }
        /// <summary>
        /// ���ಿ��2
        /// </summary>
        /// <returns></returns>
        [Column("SAFETYSUPERVISIONDEPARTMENT")]
        public string SAFETYSUPERVISIONDEPARTMENT { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("POLICEDEPARTMENT")]
        public string POLICEDEPARTMENT { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("LANDDEPARTMENT")]
        public string LANDDEPARTMENT { get; set; }
        /// <summary>
        /// ��ͨ���䲿��
        /// </summary>
        /// <returns></returns>
        [Column("TRANSPORTATIONDEPARTMENT")]
        public string TRANSPORTATIONDEPARTMENT { get; set; }
        /// <summary>
        /// ���ಿ��2
        /// </summary>
        /// <returns></returns>
        [Column("SAFETYSUPERVISIONDEPARTMENT2")]
        public string SAFETYSUPERVISIONDEPARTMENT2 { get; set; }
        /// <summary>
        /// ���»���
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDEDIRECTION")]
        public decimal? LANDSLIDEDIRECTION { get; set; }
        /// <summary>
        /// �����¶�
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDESLOPE")]
        public decimal? LANDSLIDESLOPE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDESOIL")]
        public string LANDSLIDESOIL { get; set; }
        /// <summary>
        /// ���³���
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDELENGTH")]
        public decimal? LANDSLIDELENGTH { get; set; }
        /// <summary>
        /// ���¿��
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDEWIDTH")]
        public decimal? LANDSLIDEWIDTH { get; set; }
        /// <summary>
        /// ���º��
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDETHICKNESS")]
        public decimal? LANDSLIDETHICKNESS { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDEAREA")]
        public decimal? LANDSLIDEAREA { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDEVOLUME")]
        public decimal? LANDSLIDEVOLUME { get; set; }
        /// <summary>
        /// ���¹�ģ�ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDESCALE")]
        public string LANDSLIDESCALE { get; set; }
        /// <summary>
        /// �������ݷ���
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEDIRECTION")]
        public decimal? COLLAPSEDIRECTION { get; set; }
        /// <summary>
        /// ���������¶�
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSESLOPE")]
        public decimal? COLLAPSESLOPE { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSESOIL")]
        public string COLLAPSESOIL { get; set; }
        /// <summary>
        /// �������ݸ߶�
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEHEIGHT")]
        public decimal? COLLAPSEHEIGHT { get; set; }
        /// <summary>
        /// �������ݿ��
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEWIDTH")]
        public decimal? COLLAPSEWIDTH { get; set; }
        /// <summary>
        /// �������ݺ��
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSETHICKNESS")]
        public decimal? COLLAPSETHICKNESS { get; set; }
        /// <summary>
        /// �������ݷ���
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEVOLUME")]
        public decimal? COLLAPSEVOLUME { get; set; }
        /// <summary>
        /// �������������
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEMAXBLOCKDEGREE")]
        public decimal? COLLAPSEMAXBLOCKDEGREE { get; set; }
        /// <summary>
        /// �������ݹ�ģ�ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSESCALE")]
        public string COLLAPSESCALE { get; set; }
        /// <summary>
        /// ��ʯ����������
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWGULLYSLOPE")]
        public decimal? DEBRISFLOWGULLYSLOPE { get; set; }
        /// <summary>
        /// ��ʯ������б�¿��
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWSLOPE")]
        public decimal? DEBRISFLOWSLOPE { get; set; }
        /// <summary>
        /// ��ʯ����λ
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWMUD")]
        public decimal? DEBRISFLOWMUD { get; set; }
        /// <summary>
        /// ��ʯ���ѻ��ȳ�
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWFANLENGTH")]
        public decimal? DEBRISFLOWFANLENGTH { get; set; }
        /// <summary>
        /// ��ʯ���ѻ��ȿ�
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWFANWIDTH")]
        public decimal? DEBRISFLOWFANWIDTH { get; set; }
        /// <summary>
        /// ��ʯ����ɢ��
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWSTACKEXTENSION")]
        public decimal? DEBRISFLOWSTACKEXTENSION { get; set; }
        /// <summary>
        /// ��ʯ���ѻ��Ⱥ�
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWFANTHICKNESS")]
        public decimal? DEBRISFLOWFANTHICKNESS { get; set; }
        /// <summary>
        /// ��ʯ���������
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWOUTOFVOLUME")]
        public decimal? DEBRISFLOWOUTOFVOLUME { get; set; }
        /// <summary>
        /// ��ʯ����ģ�ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWSCALE")]
        public string DEBRISFLOWSCALE { get; set; }
        /// <summary>
        /// �ѷ���״
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDSHAPE")]
        public string GROUNDSHAPE { get; set; }
        /// <summary>
        /// �ѷ�������
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDAREA")]
        public decimal? GROUNDAREA { get; set; }
        /// <summary>
        /// �ѷ�ӿڹ�ģ
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDFALLWAYSCALE")]
        public decimal? GROUNDFALLWAYSCALE { get; set; }
        /// <summary>
        /// �ѷ����
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDDEPTH")]
        public decimal? GROUNDDEPTH { get; set; }
        /// <summary>
        /// �ѷ�����ѷ���̬
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDFRACTUREMORPHOLOGY")]
        public string GROUNDFRACTUREMORPHOLOGY { get; set; }
        /// <summary>
        /// �ѷ�����ѷ쳤��
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDFRACTURELENGTH")]
        public decimal? GROUNDFRACTURELENGTH { get; set; }
        /// <summary>
        /// �ѷ��ģ�ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDSCALE")]
        public string GROUNDSCALE { get; set; }
        /// <summary>
        /// ��ò����
        /// </summary>
        /// <returns></returns>
        [Column("GEOSHANBEIESERTPLATEAU")]
        public string GEOSHANBEIESERTPLATEAU { get; set; }
        /// <summary>
        /// ��ò����
        /// </summary>
        /// <returns></returns>
        [Column("GEOSHANBEILOESSPLATEAU")]
        public string GEOSHANBEILOESSPLATEAU { get; set; }
        /// <summary>
        /// ��ò����
        /// </summary>
        /// <returns></returns>
        [Column("GEOGUANZHONGFAULTEDPLATE")]
        public string GEOGUANZHONGFAULTEDPLATE { get; set; }
        /// <summary>
        /// ��ò����
        /// </summary>
        /// <returns></returns>
        [Column("GEOQINBAMOUNTAIN")]
        public string GEOQINBAMOUNTAIN { get; set; }
        /// <summary>
        /// �ز�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("STRATAGE")]
        public string STRATAGE { get; set; }
        /// <summary>
        /// �ز�����
        /// </summary>
        /// <returns></returns>
        [Column("STRATGORIESTYPE")]
        public string STRATGORIESTYPE { get; set; }
        /// <summary>
        /// �����̶�
        /// </summary>
        /// <returns></returns>
        [Column("STRATGORIESINTEGRITY")]
        public string STRATGORIESINTEGRITY { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERFACTOR")]
        public string TRIGGERFACTOR { get; set; }
        /// <summary>
        /// ���꿪ʼʱ��
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERRAINFALLSTARTTIME")]
        public DateTime? TRIGGERRAINFALLSTARTTIME { get; set; }
        /// <summary>
        /// �������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERRAINFALLENDTIME")]
        public DateTime? TRIGGERRAINFALLENDTIME { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERRAINFALL")]
        public decimal? TRIGGERRAINFALL { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGEREARTHQUAKEEPICENTER")]
        public string TRIGGEREARTHQUAKEEPICENTER { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGEREARTHQUAKEMAGNITUDE")]
        public decimal? TRIGGEREARTHQUAKEMAGNITUDE { get; set; }
        /// <summary>
        /// �Ҷ�
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGEREARTHQUAKEINTENSITY")]
        public decimal? TRIGGEREARTHQUAKEINTENSITY { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERHTEMPERATURE")]
        public decimal? TRIGGERHTEMPERATURE { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERLTEMPERATURE")]
        public decimal? TRIGGERLTEMPERATURE { get; set; }
        /// <summary>
        /// ��Ϊ����
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERFACTORHUMAN")]
        public string TRIGGERFACTORHUMAN { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGEGEOGRAPHICALPOSITION")]
        public string TRIGGEGEOGRAPHICALPOSITION { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGECONCLUSIONCAUSE")]
        public string TRIGGECONCLUSIONCAUSE { get; set; }
        /// <summary>
        /// ���ν���A
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONSUGGESTIONA")]
        public short? PREVENTIONSUGGESTIONA { get; set; }
        /// <summary>
        /// ���ν���B
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONSUGGESTIONB")]
        public short? PREVENTIONSUGGESTIONB { get; set; }
        /// <summary>
        /// ���ν���C
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONSUGGESTIONC")]
        public short? PREVENTIONSUGGESTIONC { get; set; }
        /// <summary>
        /// ���ν���D
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONSUGGESTIOND")]
        public short? PREVENTIONSUGGESTIOND { get; set; }
        /// <summary>
        /// ���ν���E
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONSUGGESTIONE")]
        public short? PREVENTIONSUGGESTIONE { get; set; }
        /// <summary>
        /// ���ν���F
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONSUGGESTIONF")]
        public short? PREVENTIONSUGGESTIONF { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("EIOUPRINCIPAL")]
        public string EIOUPRINCIPAL { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        [Column("EIOUUNITNAME")]
        public string EIOUUNITNAME { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("LIVERECORD")]
        public string LIVERECORD { get; set; }
        /// <summary>
        /// �ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERCODE")]
        public string DISASTERCODE { get; set; }
        /// <summary>
        /// ֱ�Ӿ�����ʧ
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERDIRECTECONOMICLOSSES")]
        public decimal? DISASTERDIRECTECONOMICLOSSES { get; set; }
        /// <summary>
        /// ����ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERGRADE")]
        public string DISASTERGRADE { get; set; }
        /// <summary>
        /// ��в����
        /// </summary>
        /// <returns></returns>
        [Column("DANGERTHREATFAMILY")]
        public short? DANGERTHREATFAMILY { get; set; }
        /// <summary>
        /// ��в����
        /// </summary>
        /// <returns></returns>
        [Column("DANGERTHREATPEOPLENUM")]
        public short? DANGERTHREATPEOPLENUM { get; set; }
        /// <summary>
        /// ��в����
        /// </summary>
        /// <returns></returns>
        [Column("DANGERTHREATHOUSENUM")]
        public short? DANGERTHREATHOUSENUM { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DANGEROTHER")]
        public string DANGEROTHER { get; set; }
        /// <summary>
        /// �ֺ�������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERNAME")]
        public string DISASTERNAME { get; set; }
        /// <summary>
        /// �ֺ���ģ(m2)
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERSCALE")]
        public decimal? DISASTERSCALE { get; set; }
        /// <summary>
        /// �����ֺ���Ҫ����
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERDESCRIPTION")]
        public string DISASTERDESCRIPTION { get; set; }
        /// <summary>
        /// ����ԭ��
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERCAUSE")]
        public string TRIGGERCAUSE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("PRECAUTIONARYADVICE")]
        public string PRECAUTIONARYADVICE { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("INVESTIGATOR")]
        public string INVESTIGATOR { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("INVESTIGATORTIME")]
        public DateTime? INVESTIGATORTIME { get; set; }
        /// <summary>
        /// ��ϸ��ַ
        /// </summary>
        /// <returns></returns>
        [Column("DETAILEDADDRESS")]
        public string DETAILEDADDRESS { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONCOUNTYNAME")]
        public string GOEPOSITIONCOUNTYNAME { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONCITYNAME")]
        public string GOEPOSITIONCITYNAME { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONTOWNNAME")]
        public string GOEPOSITIONTOWNNAME { get; set; }
        /// <summary>
        /// ��Ȼ����
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERFACTORNATURAL")]
        public string TRIGGERFACTORNATURAL { get; set; }
        /// <summary>
        /// �����˿�
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERPEOPLENUM")]
        public short? DISASTERPEOPLENUM { get; set; }
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