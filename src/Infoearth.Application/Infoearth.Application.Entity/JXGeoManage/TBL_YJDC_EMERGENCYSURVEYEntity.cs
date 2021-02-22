using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-13 13:27
    /// 描 述：
    /// </summary>
    public class TBL_YJDC_EMERGENCYSURVEYEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 调查点名称(灾险情名称)
        /// </summary>
        /// <returns></returns>
        [Column("NAME")]
        public string NAME { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONPROVINCE")]
        public string GOEPOSITIONPROVINCE { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONCITY")]
        public string GOEPOSITIONCITY { get; set; }
        /// <summary>
        /// 县
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONCOUNTY")]
        public string GOEPOSITIONCOUNTY { get; set; }
        /// <summary>
        /// 乡镇
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONTOWN")]
        public string GOEPOSITIONTOWN { get; set; }
        /// <summary>
        /// 村
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONVILLAGE")]
        public string GOEPOSITIONVILLAGE { get; set; }
        /// <summary>
        /// 组
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONGROUP")]
        public string GOEPOSITIONGROUP { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        public decimal? LONGITUDE { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        public decimal? LATITUDE { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        /// <returns></returns>
        [Column("OCCURRENCETIME")]
        public DateTime? OCCURRENCETIME { get; set; }
        /// <summary>
        /// 是否在册
        /// </summary>
        /// <returns></returns>
        [Column("ISREGISTERED")]
        public short? ISREGISTERED { get; set; }
        /// <summary>
        /// 灾害类型
        /// </summary>
        /// <returns></returns>
        [Column("TYPE")]
        public string TYPE { get; set; }
        /// <summary>
        /// 死亡人数
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERDEATHPEOPLENUM")]
        public short? DISASTERDEATHPEOPLENUM { get; set; }
        /// <summary>
        /// 失踪人数
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERMISSINGPEOPLENUM")]
        public short? DISASTERMISSINGPEOPLENUM { get; set; }
        /// <summary>
        /// 受伤人数
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERINJURYPEOPLENUM")]
        public short? DISASTERINJURYPEOPLENUM { get; set; }
        /// <summary>
        /// 毁坏房屋
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERDESTRUCTEDHOUSENUM")]
        public short? DISASTERDESTRUCTEDHOUSENUM { get; set; }
        /// <summary>
        /// 其它
        /// </summary>
        /// <returns></returns>
        [Column("DISASTEROTHER")]
        public string DISASTEROTHER { get; set; }
        /// <summary>
        /// 潜在经济损失
        /// </summary>
        /// <returns></returns>
        [Column("DANGERPOTENTIALECONOMICLOSSES")]
        public decimal? DANGERPOTENTIALECONOMICLOSSES { get; set; }
        /// <summary>
        /// 险情等级
        /// </summary>
        /// <returns></returns>
        [Column("DANGERGRATE")]
        public string DANGERGRATE { get; set; }
        /// <summary>
        /// 开展工作情况
        /// </summary>
        /// <returns></returns>
        [Column("GOVERNMENTDEPARTMENT")]
        public string GOVERNMENTDEPARTMENT { get; set; }
        /// <summary>
        /// 医疗部门
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALDEPARTMENT")]
        public string MEDICALDEPARTMENT { get; set; }
        /// <summary>
        /// 武警官兵
        /// </summary>
        /// <returns></returns>
        [Column("ARMEDPOLICE")]
        public string ARMEDPOLICE { get; set; }
        /// <summary>
        /// 安监部门2
        /// </summary>
        /// <returns></returns>
        [Column("SAFETYSUPERVISIONDEPARTMENT")]
        public string SAFETYSUPERVISIONDEPARTMENT { get; set; }
        /// <summary>
        /// 公安部门
        /// </summary>
        /// <returns></returns>
        [Column("POLICEDEPARTMENT")]
        public string POLICEDEPARTMENT { get; set; }
        /// <summary>
        /// 国土部门
        /// </summary>
        /// <returns></returns>
        [Column("LANDDEPARTMENT")]
        public string LANDDEPARTMENT { get; set; }
        /// <summary>
        /// 交通运输部门
        /// </summary>
        /// <returns></returns>
        [Column("TRANSPORTATIONDEPARTMENT")]
        public string TRANSPORTATIONDEPARTMENT { get; set; }
        /// <summary>
        /// 安监部门2
        /// </summary>
        /// <returns></returns>
        [Column("SAFETYSUPERVISIONDEPARTMENT2")]
        public string SAFETYSUPERVISIONDEPARTMENT2 { get; set; }
        /// <summary>
        /// 滑坡滑向
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDEDIRECTION")]
        public decimal? LANDSLIDEDIRECTION { get; set; }
        /// <summary>
        /// 滑坡坡度
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDESLOPE")]
        public decimal? LANDSLIDESLOPE { get; set; }
        /// <summary>
        /// 滑坡性质
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDESOIL")]
        public string LANDSLIDESOIL { get; set; }
        /// <summary>
        /// 滑坡长度
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDELENGTH")]
        public decimal? LANDSLIDELENGTH { get; set; }
        /// <summary>
        /// 滑坡宽度
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDEWIDTH")]
        public decimal? LANDSLIDEWIDTH { get; set; }
        /// <summary>
        /// 滑坡厚度
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDETHICKNESS")]
        public decimal? LANDSLIDETHICKNESS { get; set; }
        /// <summary>
        /// 滑坡面积
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDEAREA")]
        public decimal? LANDSLIDEAREA { get; set; }
        /// <summary>
        /// 滑坡体积
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDEVOLUME")]
        public decimal? LANDSLIDEVOLUME { get; set; }
        /// <summary>
        /// 滑坡规模等级
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIDESCALE")]
        public string LANDSLIDESCALE { get; set; }
        /// <summary>
        /// 地面塌陷方向
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEDIRECTION")]
        public decimal? COLLAPSEDIRECTION { get; set; }
        /// <summary>
        /// 地面塌陷坡度
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSESLOPE")]
        public decimal? COLLAPSESLOPE { get; set; }
        /// <summary>
        /// 地面塌陷性质
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSESOIL")]
        public string COLLAPSESOIL { get; set; }
        /// <summary>
        /// 地面塌陷高度
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEHEIGHT")]
        public decimal? COLLAPSEHEIGHT { get; set; }
        /// <summary>
        /// 地面塌陷宽度
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEWIDTH")]
        public decimal? COLLAPSEWIDTH { get; set; }
        /// <summary>
        /// 地面塌陷厚度
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSETHICKNESS")]
        public decimal? COLLAPSETHICKNESS { get; set; }
        /// <summary>
        /// 地面塌陷方量
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEVOLUME")]
        public decimal? COLLAPSEVOLUME { get; set; }
        /// <summary>
        /// 地面塌陷最大块度
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEMAXBLOCKDEGREE")]
        public decimal? COLLAPSEMAXBLOCKDEGREE { get; set; }
        /// <summary>
        /// 地面塌陷规模等级
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSESCALE")]
        public string COLLAPSESCALE { get; set; }
        /// <summary>
        /// 泥石流沟谷坡率
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWGULLYSLOPE")]
        public decimal? DEBRISFLOWGULLYSLOPE { get; set; }
        /// <summary>
        /// 泥石流两侧斜坡宽度
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWSLOPE")]
        public decimal? DEBRISFLOWSLOPE { get; set; }
        /// <summary>
        /// 泥石流泥位
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWMUD")]
        public decimal? DEBRISFLOWMUD { get; set; }
        /// <summary>
        /// 泥石流堆积扇长
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWFANLENGTH")]
        public decimal? DEBRISFLOWFANLENGTH { get; set; }
        /// <summary>
        /// 泥石流堆积扇宽
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWFANWIDTH")]
        public decimal? DEBRISFLOWFANWIDTH { get; set; }
        /// <summary>
        /// 泥石流扩散角
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWSTACKEXTENSION")]
        public decimal? DEBRISFLOWSTACKEXTENSION { get; set; }
        /// <summary>
        /// 泥石流堆积扇厚
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWFANTHICKNESS")]
        public decimal? DEBRISFLOWFANTHICKNESS { get; set; }
        /// <summary>
        /// 泥石流冲出方量
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWOUTOFVOLUME")]
        public decimal? DEBRISFLOWOUTOFVOLUME { get; set; }
        /// <summary>
        /// 泥石流规模等级
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWSCALE")]
        public string DEBRISFLOWSCALE { get; set; }
        /// <summary>
        /// 裂缝形状
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDSHAPE")]
        public string GROUNDSHAPE { get; set; }
        /// <summary>
        /// 裂缝变形面积
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDAREA")]
        public decimal? GROUNDAREA { get; set; }
        /// <summary>
        /// 裂缝坑口规模
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDFALLWAYSCALE")]
        public decimal? GROUNDFALLWAYSCALE { get; set; }
        /// <summary>
        /// 裂缝深度
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDDEPTH")]
        public decimal? GROUNDDEPTH { get; set; }
        /// <summary>
        /// 裂缝伴生裂缝形态
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDFRACTUREMORPHOLOGY")]
        public string GROUNDFRACTUREMORPHOLOGY { get; set; }
        /// <summary>
        /// 裂缝伴生裂缝长度
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDFRACTURELENGTH")]
        public decimal? GROUNDFRACTURELENGTH { get; set; }
        /// <summary>
        /// 裂缝规模等级
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDSCALE")]
        public string GROUNDSCALE { get; set; }
        /// <summary>
        /// 地貌类型
        /// </summary>
        /// <returns></returns>
        [Column("GEOSHANBEIESERTPLATEAU")]
        public string GEOSHANBEIESERTPLATEAU { get; set; }
        /// <summary>
        /// 地貌类型
        /// </summary>
        /// <returns></returns>
        [Column("GEOSHANBEILOESSPLATEAU")]
        public string GEOSHANBEILOESSPLATEAU { get; set; }
        /// <summary>
        /// 地貌类型
        /// </summary>
        /// <returns></returns>
        [Column("GEOGUANZHONGFAULTEDPLATE")]
        public string GEOGUANZHONGFAULTEDPLATE { get; set; }
        /// <summary>
        /// 地貌类型
        /// </summary>
        /// <returns></returns>
        [Column("GEOQINBAMOUNTAIN")]
        public string GEOQINBAMOUNTAIN { get; set; }
        /// <summary>
        /// 地层时代
        /// </summary>
        /// <returns></returns>
        [Column("STRATAGE")]
        public string STRATAGE { get; set; }
        /// <summary>
        /// 地层类型
        /// </summary>
        /// <returns></returns>
        [Column("STRATGORIESTYPE")]
        public string STRATGORIESTYPE { get; set; }
        /// <summary>
        /// 完整程度
        /// </summary>
        /// <returns></returns>
        [Column("STRATGORIESINTEGRITY")]
        public string STRATGORIESINTEGRITY { get; set; }
        /// <summary>
        /// 触发因素
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERFACTOR")]
        public string TRIGGERFACTOR { get; set; }
        /// <summary>
        /// 降雨开始时间
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERRAINFALLSTARTTIME")]
        public DateTime? TRIGGERRAINFALLSTARTTIME { get; set; }
        /// <summary>
        /// 降雨结束时间
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERRAINFALLENDTIME")]
        public DateTime? TRIGGERRAINFALLENDTIME { get; set; }
        /// <summary>
        /// 降雨量
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERRAINFALL")]
        public decimal? TRIGGERRAINFALL { get; set; }
        /// <summary>
        /// 震中
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGEREARTHQUAKEEPICENTER")]
        public string TRIGGEREARTHQUAKEEPICENTER { get; set; }
        /// <summary>
        /// 震级
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGEREARTHQUAKEMAGNITUDE")]
        public decimal? TRIGGEREARTHQUAKEMAGNITUDE { get; set; }
        /// <summary>
        /// 烈度
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGEREARTHQUAKEINTENSITY")]
        public decimal? TRIGGEREARTHQUAKEINTENSITY { get; set; }
        /// <summary>
        /// 最高气温
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERHTEMPERATURE")]
        public decimal? TRIGGERHTEMPERATURE { get; set; }
        /// <summary>
        /// 最低气温
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERLTEMPERATURE")]
        public decimal? TRIGGERLTEMPERATURE { get; set; }
        /// <summary>
        /// 人为因素
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERFACTORHUMAN")]
        public string TRIGGERFACTORHUMAN { get; set; }
        /// <summary>
        /// 调查点
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGEGEOGRAPHICALPOSITION")]
        public string TRIGGEGEOGRAPHICALPOSITION { get; set; }
        /// <summary>
        /// 引发因素
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGECONCLUSIONCAUSE")]
        public string TRIGGECONCLUSIONCAUSE { get; set; }
        /// <summary>
        /// 防治建议A
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONSUGGESTIONA")]
        public short? PREVENTIONSUGGESTIONA { get; set; }
        /// <summary>
        /// 防治建议B
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONSUGGESTIONB")]
        public short? PREVENTIONSUGGESTIONB { get; set; }
        /// <summary>
        /// 防治建议C
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONSUGGESTIONC")]
        public short? PREVENTIONSUGGESTIONC { get; set; }
        /// <summary>
        /// 防治建议D
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONSUGGESTIOND")]
        public short? PREVENTIONSUGGESTIOND { get; set; }
        /// <summary>
        /// 防治建议E
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONSUGGESTIONE")]
        public short? PREVENTIONSUGGESTIONE { get; set; }
        /// <summary>
        /// 防治建议F
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONSUGGESTIONF")]
        public short? PREVENTIONSUGGESTIONF { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        /// <returns></returns>
        [Column("EIOUPRINCIPAL")]
        public string EIOUPRINCIPAL { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        /// <returns></returns>
        [Column("EIOUUNITNAME")]
        public string EIOUUNITNAME { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("LIVERECORD")]
        public string LIVERECORD { get; set; }
        /// <summary>
        /// 灾害点编号
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERCODE")]
        public string DISASTERCODE { get; set; }
        /// <summary>
        /// 直接经济损失
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERDIRECTECONOMICLOSSES")]
        public decimal? DISASTERDIRECTECONOMICLOSSES { get; set; }
        /// <summary>
        /// 灾情等级
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERGRADE")]
        public string DISASTERGRADE { get; set; }
        /// <summary>
        /// 威胁户数
        /// </summary>
        /// <returns></returns>
        [Column("DANGERTHREATFAMILY")]
        public short? DANGERTHREATFAMILY { get; set; }
        /// <summary>
        /// 威胁人数
        /// </summary>
        /// <returns></returns>
        [Column("DANGERTHREATPEOPLENUM")]
        public short? DANGERTHREATPEOPLENUM { get; set; }
        /// <summary>
        /// 威胁房屋
        /// </summary>
        /// <returns></returns>
        [Column("DANGERTHREATHOUSENUM")]
        public short? DANGERTHREATHOUSENUM { get; set; }
        /// <summary>
        /// 其它
        /// </summary>
        /// <returns></returns>
        [Column("DANGEROTHER")]
        public string DANGEROTHER { get; set; }
        /// <summary>
        /// 灾害点名称
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERNAME")]
        public string DISASTERNAME { get; set; }
        /// <summary>
        /// 灾害规模(m2)
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERSCALE")]
        public decimal? DISASTERSCALE { get; set; }
        /// <summary>
        /// 地质灾害简要描述
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERDESCRIPTION")]
        public string DISASTERDESCRIPTION { get; set; }
        /// <summary>
        /// 引发原因
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERCAUSE")]
        public string TRIGGERCAUSE { get; set; }
        /// <summary>
        /// 防范建议
        /// </summary>
        /// <returns></returns>
        [Column("PRECAUTIONARYADVICE")]
        public string PRECAUTIONARYADVICE { get; set; }
        /// <summary>
        /// 调查人
        /// </summary>
        /// <returns></returns>
        [Column("INVESTIGATOR")]
        public string INVESTIGATOR { get; set; }
        /// <summary>
        /// 调查时间
        /// </summary>
        /// <returns></returns>
        [Column("INVESTIGATORTIME")]
        public DateTime? INVESTIGATORTIME { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        /// <returns></returns>
        [Column("DETAILEDADDRESS")]
        public string DETAILEDADDRESS { get; set; }
        /// <summary>
        /// 县名
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONCOUNTYNAME")]
        public string GOEPOSITIONCOUNTYNAME { get; set; }
        /// <summary>
        /// 市名
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONCITYNAME")]
        public string GOEPOSITIONCITYNAME { get; set; }
        /// <summary>
        /// 乡镇名
        /// </summary>
        /// <returns></returns>
        [Column("GOEPOSITIONTOWNNAME")]
        public string GOEPOSITIONTOWNNAME { get; set; }
        /// <summary>
        /// 自然因素
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERFACTORNATURAL")]
        public string TRIGGERFACTORNATURAL { get; set; }
        /// <summary>
        /// 受灾人口
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERPEOPLENUM")]
        public short? DISASTERPEOPLENUM { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.GUID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.GUID = keyValue;
        }
        #endregion
    }
}