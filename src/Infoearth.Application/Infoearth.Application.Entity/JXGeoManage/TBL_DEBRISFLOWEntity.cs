using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-26 10:50
    /// 描 述：泥石流调查表
    /// </summary>
    public class TBL_DEBRISFLOWEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 统一编号
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// CGH系统灾害点编码
        /// </summary>
        /// <returns></returns>
        [Column("CGHUNIFIEDCODE")]
        public string CGHUNIFIEDCODE { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERUNITNAME")]
        public string DISASTERUNITNAME { get; set; }
        /// <summary>
        /// 野外编号
        /// </summary>
        /// <returns></returns>
        [Column("OUTDOORCODE")]
        public string OUTDOORCODE { get; set; }
        /// <summary>
        /// 室内编号
        /// </summary>
        /// <returns></returns>
        [Column("INDOORCODE")]
        public string INDOORCODE { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        /// <summary>
        /// 市（县）
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        /// <summary>
        /// 乡镇
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
        /// <summary>
        /// 地理位置（村）
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        public string LOCATION { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        public string LATITUDE { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        public string LONGITUDE { get; set; }
        /// <summary>
        /// X坐标
        /// </summary>
        /// <returns></returns>
        [Column("X")]
        public decimal? X { get; set; }
        /// <summary>
        /// Y坐标
        /// </summary>
        /// <returns></returns>
        [Column("Y")]
        public decimal? Y { get; set; }
        /// <summary>
        /// Z坐标
        /// </summary>
        /// <returns></returns>
        [Column("Z")]
        public decimal? Z { get; set; }
        /// <summary>
        /// 最大标高
        /// </summary>
        /// <returns></returns>
        [Column("ALTTOP")]
        public decimal? ALTTOP { get; set; }
        /// <summary>
        /// 最小标高
        /// </summary>
        /// <returns></returns>
        [Column("ALTBOTOM")]
        public decimal? ALTBOTOM { get; set; }
        /// <summary>
        /// 水系名称
        /// </summary>
        /// <returns></returns>
        [Column("WATERNAME")]
        public string WATERNAME { get; set; }
        /// <summary>
        /// 主河名称
        /// </summary>
        /// <returns></returns>
        [Column("MRIVERNAME")]
        public string MRIVERNAME { get; set; }
        /// <summary>
        /// 相对主河位置
        /// </summary>
        /// <returns></returns>
        [Column("MRIVERLOCATION")]
        public string MRIVERLOCATION { get; set; }
        /// <summary>
        /// 沟口至主河道距
        /// </summary>
        /// <returns></returns>
        [Column("MIZDISTOMRIVER")]
        public decimal? MIZDISTOMRIVER { get; set; }
        /// <summary>
        /// 流动方向
        /// </summary>
        /// <returns></returns>
        [Column("FLOWDIRECTION")]
        public string FLOWDIRECTION { get; set; }
        /// <summary>
        /// 水动力类型
        /// </summary>
        /// <returns></returns>
        [Column("HYDRODYNAMICTYPE")]
        public string HYDRODYNAMICTYPE { get; set; }
        /// <summary>
        /// 沟口巨石A
        /// </summary>
        /// <returns></returns>
        [Column("MIZOGUCHIROCKA")]
        public string MIZOGUCHIROCKA { get; set; }
        /// <summary>
        /// 沟口巨石B
        /// </summary>
        /// <returns></returns>
        [Column("MIZOGUCHIROCKB")]
        public string MIZOGUCHIROCKB { get; set; }
        /// <summary>
        /// 沟口巨石C
        /// </summary>
        /// <returns></returns>
        [Column("MIZOGUCHIROCKC")]
        public string MIZOGUCHIROCKC { get; set; }
        /// <summary>
        /// 泥砂补给途径
        /// </summary>
        /// <returns></returns>
        [Column("SEDIMENTSUPPLYROUTE")]
        public string SEDIMENTSUPPLYROUTE { get; set; }
        /// <summary>
        /// 补给区位置
        /// </summary>
        /// <returns></returns>
        [Column("RECHARGEZONE")]
        public string RECHARGEZONE { get; set; }
        /// <summary>
        /// 年最大降雨
        /// </summary>
        /// <returns></returns>
        [Column("YEARMAXIMUMRAINFALL")]
        public decimal? YEARMAXIMUMRAINFALL { get; set; }
        /// <summary>
        /// 年平均降雨
        /// </summary>
        /// <returns></returns>
        [Column("YEARAVERAGERAINFALL")]
        public decimal? YEARAVERAGERAINFALL { get; set; }
        /// <summary>
        /// 日最大降雨
        /// </summary>
        /// <returns></returns>
        [Column("DAYMAXIMUMRAINFALL")]
        public decimal? DAYMAXIMUMRAINFALL { get; set; }
        /// <summary>
        /// 日平均降雨
        /// </summary>
        /// <returns></returns>
        [Column("DAYAVERAGERAINFALL")]
        public decimal? DAYAVERAGERAINFALL { get; set; }
        /// <summary>
        /// 时最大降雨
        /// </summary>
        /// <returns></returns>
        [Column("HOURMAXIMUMRAINFALL")]
        public decimal? HOURMAXIMUMRAINFALL { get; set; }
        /// <summary>
        /// 时平均降雨
        /// </summary>
        /// <returns></returns>
        [Column("HOURAVERAGERAINFALL")]
        public decimal? HOURAVERAGERAINFALL { get; set; }
        /// <summary>
        /// 十分钟最大降雨
        /// </summary>
        /// <returns></returns>
        [Column("MINUTES10MAXIMUMRAINFALL")]
        public decimal? MINUTES10MAXIMUMRAINFALL { get; set; }
        /// <summary>
        /// 十分钟平均降雨
        /// </summary>
        /// <returns></returns>
        [Column("MINUTES10AVERAGERAINFALL")]
        public decimal? MINUTES10AVERAGERAINFALL { get; set; }
        /// <summary>
        /// 沟口扇形地完整性
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDINTEGRITY")]
        public decimal? MIZSECTORLANDINTEGRITY { get; set; }
        /// <summary>
        /// 沟口扇形地变幅
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDAMPLITUDE")]
        public decimal? MIZSECTORLANDAMPLITUDE { get; set; }
        /// <summary>
        /// 沟口扇形地发展趋势
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDTRENDS")]
        public string MIZSECTORLANDTRENDS { get; set; }
        /// <summary>
        /// 沟口扇形地扇长
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDFANLONG")]
        public decimal? MIZSECTORLANDFANLONG { get; set; }
        /// <summary>
        /// 沟口扇形地扇宽
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDFANKUAN")]
        public decimal? MIZSECTORLANDFANKUAN { get; set; }
        /// <summary>
        /// 沟口扇形地扩散角
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDSPREADANGLE")]
        public decimal? MIZSECTORLANDSPREADANGLE { get; set; }
        /// <summary>
        /// 沟口扇形地挤压大河
        /// </summary>
        /// <returns></returns>
        [Column("MIZSECTORLANDEXTRUSIONRIVER")]
        public string MIZSECTORLANDEXTRUSIONRIVER { get; set; }
        /// <summary>
        /// 地质构造
        /// </summary>
        /// <returns></returns>
        [Column("GEOLOGICALSTRUCTURE")]
        public string GEOLOGICALSTRUCTURE { get; set; }
        /// <summary>
        /// 地震烈度
        /// </summary>
        /// <returns></returns>
        [Column("EARTHQUAKEINTENSITY")]
        public string EARTHQUAKEINTENSITY { get; set; }
        /// <summary>
        /// 滑坡活动程度
        /// </summary>
        /// <returns></returns>
        [Column("SCALEACTIVITYDEGREE")]
        public string SCALEACTIVITYDEGREE { get; set; }
        /// <summary>
        /// 滑坡规模
        /// </summary>
        /// <returns></returns>
        [Column("SCALEIANDSLIDE")]
        public string SCALEIANDSLIDE { get; set; }
        /// <summary>
        /// 人工弃体活动程度
        /// </summary>
        /// <returns></returns>
        [Column("ARTIFICIALABDBODYACTDEGREE")]
        public string ARTIFICIALABDBODYACTDEGREE { get; set; }
        /// <summary>
        /// 人工弃体规模
        /// </summary>
        /// <returns></returns>
        [Column("ARTIFICIALABDBODYSCALE")]
        public string ARTIFICIALABDBODYSCALE { get; set; }
        /// <summary>
        /// 自然堆积活动程度
        /// </summary>
        /// <returns></returns>
        [Column("NATURALACCACTDEGREE")]
        public string NATURALACCACTDEGREE { get; set; }
        /// <summary>
        /// 自然堆积规模
        /// </summary>
        /// <returns></returns>
        [Column("NATURALACCSCALE")]
        public string NATURALACCSCALE { get; set; }
        /// <summary>
        /// 森林
        /// </summary>
        /// <returns></returns>
        [Column("FOREST")]
        public decimal? FOREST { get; set; }
        /// <summary>
        /// 灌丛
        /// </summary>
        /// <returns></returns>
        [Column("SHRUB")]
        public decimal? SHRUB { get; set; }
        /// <summary>
        /// 草地
        /// </summary>
        /// <returns></returns>
        [Column("LAWN")]
        public decimal? LAWN { get; set; }
        /// <summary>
        /// 缓坡耕地
        /// </summary>
        /// <returns></returns>
        [Column("GENTSLOPEARALAND")]
        public decimal? GENTSLOPEARALAND { get; set; }
        /// <summary>
        /// 荒地
        /// </summary>
        /// <returns></returns>
        [Column("WASTELAND")]
        public decimal? WASTELAND { get; set; }
        /// <summary>
        /// 陡坡耕地
        /// </summary>
        /// <returns></returns>
        [Column("STEEPLAND")]
        public decimal? STEEPLAND { get; set; }
        /// <summary>
        /// 建筑用地
        /// </summary>
        /// <returns></returns>
        [Column("BUILDINGLAND")]
        public decimal? BUILDINGLAND { get; set; }
        /// <summary>
        /// 其它用地
        /// </summary>
        /// <returns></returns>
        [Column("OTHERSITES")]
        public decimal? OTHERSITES { get; set; }
        /// <summary>
        /// 防治措施现状
        /// </summary>
        /// <returns></returns>
        [Column("CONTROLMEASTATUSQ")]
        public string CONTROLMEASTATUSQ { get; set; }
        /// <summary>
        /// 防治措施类型
        /// </summary>
        /// <returns></returns>
        [Column("CONTROMEASURETYPE")]
        public string CONTROMEASURETYPE { get; set; }
        /// <summary>
        /// 监测措施
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMEASURE")]
        public string MONITORMEASURE { get; set; }
        /// <summary>
        /// 监测措施类型
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMEASURETYPE")]
        public string MONITORMEASURETYPE { get; set; }
        /// <summary>
        /// 威胁危害对象
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHARMOBJ")]
        public string THREATENHARMOBJ { get; set; }
        /// <summary>
        /// 威胁人口
        /// </summary>
        /// <returns></returns>
        [Column("THREATENPEOPLE")]
        public int? THREATENPEOPLE { get; set; }
        /// <summary>
        /// 威胁财产
        /// </summary>
        /// <returns></returns>
        [Column("THREATENASSETS")]
        public decimal? THREATENASSETS { get; set; }
        /// <summary>
        /// 险情等级
        /// </summary>
        /// <returns></returns>
        [Column("DANGERLEVEL")]
        public string DANGERLEVEL { get; set; }
        /// <summary>
        /// 灾害史发生时间1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYOCCURT1")]
        public string DISHISTORYOCCURT1 { get; set; }
        /// <summary>
        /// 灾害史死亡人口1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDEATHS1")]
        public int? DISHISTORYDEATHS1 { get; set; }
        /// <summary>
        /// 灾害史损失牲畜1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYLOSSLIVESTOCK1")]
        public int? DISHISTORYLOSSLIVESTOCK1 { get; set; }
        /// <summary>
        /// 灾害史全毁房屋1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESHOUSES1")]
        public int? DISHISTORYCOMPDESHOUSES1 { get; set; }
        /// <summary>
        /// 灾害史半毁房屋1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESHOUSES1")]
        public int? DISHISTORYSDESHOUSES1 { get; set; }
        /// <summary>
        /// 灾害史全毁农田1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESFARMLAND1")]
        public decimal? DISHISTORYCOMPDESFARMLAND1 { get; set; }
        /// <summary>
        /// 灾害史半毁农田1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESFARMLAND1")]
        public decimal? DISHISTORYSDESFARMLAND1 { get; set; }
        /// <summary>
        /// 灾害史毁坏道路1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESROAD1")]
        public decimal? DISHISTORYDESROAD1 { get; set; }
        /// <summary>
        /// 灾害史毁坏桥梁1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESBRIDGE1")]
        public int? DISHISTORYDESBRIDGE1 { get; set; }
        /// <summary>
        /// 灾害史直接损失1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDIRECTLOSS1")]
        public decimal? DISHISTORYDIRECTLOSS1 { get; set; }
        /// <summary>
        /// 灾害史灾情等级1
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDISASTERDEGREES1")]
        public string DISHISTORYDISASTERDEGREES1 { get; set; }
        /// <summary>
        /// 灾害史发生时间2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYOCCURT2")]
        public string DISHISTORYOCCURT2 { get; set; }
        /// <summary>
        /// 灾害史死亡人口2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDEATHS2")]
        public int? DISHISTORYDEATHS2 { get; set; }
        /// <summary>
        /// 灾害史损失牲畜2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYLOSSLIVESTOCK2")]
        public int? DISHISTORYLOSSLIVESTOCK2 { get; set; }
        /// <summary>
        /// 灾害史全毁房屋2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESHOUSES2")]
        public int? DISHISTORYCOMPDESHOUSES2 { get; set; }
        /// <summary>
        /// 灾害史半毁房屋2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESHOUSES2")]
        public int? DISHISTORYSDESHOUSES2 { get; set; }
        /// <summary>
        /// 灾害史全毁农田2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESFARMLAND2")]
        public decimal? DISHISTORYCOMPDESFARMLAND2 { get; set; }
        /// <summary>
        /// 灾害史半毁农田2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESFARMLAND2")]
        public decimal? DISHISTORYSDESFARMLAND2 { get; set; }
        /// <summary>
        /// 灾害史毁坏道路2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESROAD2")]
        public decimal? DISHISTORYDESROAD2 { get; set; }
        /// <summary>
        /// 灾害史毁坏桥梁2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESBRIDGE2")]
        public int? DISHISTORYDESBRIDGE2 { get; set; }
        /// <summary>
        /// 灾害史直接损失2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDIRECTLOSS2")]
        public decimal? DISHISTORYDIRECTLOSS2 { get; set; }
        /// <summary>
        /// 灾害史灾情等级2
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDISASTERDEGREES2")]
        public string DISHISTORYDISASTERDEGREES2 { get; set; }
        /// <summary>
        /// 灾害史发生时间3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYOCCURT3")]
        public string DISHISTORYOCCURT3 { get; set; }
        /// <summary>
        /// 灾害史死亡人口3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDEATHS3")]
        public int? DISHISTORYDEATHS3 { get; set; }
        /// <summary>
        /// 灾害史损失牲畜3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYLOSSLIVESTOCK3")]
        public int? DISHISTORYLOSSLIVESTOCK3 { get; set; }
        /// <summary>
        /// 灾害史全毁房屋3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESHOUSES3")]
        public int? DISHISTORYCOMPDESHOUSES3 { get; set; }
        /// <summary>
        /// 灾害史半毁房屋3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESHOUSES3")]
        public int? DISHISTORYSDESHOUSES3 { get; set; }
        /// <summary>
        /// 灾害史全毁农田3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESFARMLAND3")]
        public decimal? DISHISTORYCOMPDESFARMLAND3 { get; set; }
        /// <summary>
        /// 灾害史半毁农田3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESFARMLAND3")]
        public decimal? DISHISTORYSDESFARMLAND3 { get; set; }
        /// <summary>
        /// 灾害史毁坏道路3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESROAD3")]
        public decimal? DISHISTORYDESROAD3 { get; set; }
        /// <summary>
        /// 灾害史毁坏桥梁3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESBRIDGE3")]
        public int? DISHISTORYDESBRIDGE3 { get; set; }
        /// <summary>
        /// 灾害史直接损失3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDIRECTLOSS3")]
        public decimal? DISHISTORYDIRECTLOSS3 { get; set; }
        /// <summary>
        /// 灾害史灾情等级3
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDISASTERDEGREES3")]
        public string DISHISTORYDISASTERDEGREES3 { get; set; }
        /// <summary>
        /// 灾害史发生时间4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYOCCURT4")]
        public string DISHISTORYOCCURT4 { get; set; }
        /// <summary>
        /// 灾害史死亡人口4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDEATHS4")]
        public int? DISHISTORYDEATHS4 { get; set; }
        /// <summary>
        /// 灾害史损失牲畜4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYLOSSLIVESTOCK4")]
        public int? DISHISTORYLOSSLIVESTOCK4 { get; set; }
        /// <summary>
        /// 灾害史全毁房屋4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESHOUSES4")]
        public int? DISHISTORYCOMPDESHOUSES4 { get; set; }
        /// <summary>
        /// 灾害史半毁房屋4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESHOUSES4")]
        public int? DISHISTORYSDESHOUSES4 { get; set; }
        /// <summary>
        /// 灾害史全毁农田4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESFARMLAND4")]
        public decimal? DISHISTORYCOMPDESFARMLAND4 { get; set; }
        /// <summary>
        /// 灾害史半毁农田4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESFARMLAND4")]
        public decimal? DISHISTORYSDESFARMLAND4 { get; set; }
        /// <summary>
        /// 灾害史毁坏道路4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESROAD4")]
        public decimal? DISHISTORYDESROAD4 { get; set; }
        /// <summary>
        /// 灾害史毁坏桥梁4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESBRIDGE4")]
        public int? DISHISTORYDESBRIDGE4 { get; set; }
        /// <summary>
        /// 灾害史直接损失4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDIRECTLOSS4")]
        public decimal? DISHISTORYDIRECTLOSS4 { get; set; }
        /// <summary>
        /// 灾害史灾情等级4
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDISASTERDEGREES4")]
        public string DISHISTORYDISASTERDEGREES4 { get; set; }
        /// <summary>
        /// 灾害史发生时间5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYOCCURT5")]
        public string DISHISTORYOCCURT5 { get; set; }
        /// <summary>
        /// 灾害史死亡人口5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDEATHS5")]
        public int? DISHISTORYDEATHS5 { get; set; }
        /// <summary>
        /// 灾害史损失牲畜5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYLOSSLIVESTOCK5")]
        public int? DISHISTORYLOSSLIVESTOCK5 { get; set; }
        /// <summary>
        /// 灾害史全毁房屋5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESHOUSES5")]
        public int? DISHISTORYCOMPDESHOUSES5 { get; set; }
        /// <summary>
        /// 灾害史半毁房屋5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESHOUSES5")]
        public int? DISHISTORYSDESHOUSES5 { get; set; }
        /// <summary>
        /// 灾害史全毁农田5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYCOMPDESFARMLAND5")]
        public decimal? DISHISTORYCOMPDESFARMLAND5 { get; set; }
        /// <summary>
        /// 灾害史半毁农田5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYSDESFARMLAND5")]
        public decimal? DISHISTORYSDESFARMLAND5 { get; set; }
        /// <summary>
        /// 灾害史毁坏道路5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESROAD5")]
        public decimal? DISHISTORYDESROAD5 { get; set; }
        /// <summary>
        /// 灾害史毁坏桥梁5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDESBRIDGE5")]
        public int? DISHISTORYDESBRIDGE5 { get; set; }
        /// <summary>
        /// 灾害史直接损失5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDIRECTLOSS5")]
        public decimal? DISHISTORYDIRECTLOSS5 { get; set; }
        /// <summary>
        /// 灾害史灾情等级5
        /// </summary>
        /// <returns></returns>
        [Column("DISHISTORYDISASTERDEGREES5")]
        public string DISHISTORYDISASTERDEGREES5 { get; set; }
        /// <summary>
        /// 泥石流冲出方量
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWOUTSQUCAP")]
        public decimal? DEBRISFLOWOUTSQUCAP { get; set; }
        /// <summary>
        /// 泥石流规模等级
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWRATINGSCALE")]
        public string DEBRISFLOWRATINGSCALE { get; set; }
        /// <summary>
        /// 泥石流泥位
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWMUDPOSITION")]
        public decimal? DEBRISFLOWMUDPOSITION { get; set; }
        /// <summary>
        /// 不良地质现象
        /// </summary>
        /// <returns></returns>
        [Column("BADGEOLOGICALPHENOMENA")]
        public string BADGEOLOGICALPHENOMENA { get; set; }
        /// <summary>
        /// 补给段长度比
        /// </summary>
        /// <returns></returns>
        [Column("SUPPLYLENGTHRATIO")]
        public string SUPPLYLENGTHRATIO { get; set; }
        /// <summary>
        /// 沟口扇形地
        /// </summary>
        /// <returns></returns>
        [Column("MIZOGUCHIFAN")]
        public string MIZOGUCHIFAN { get; set; }
        /// <summary>
        /// 主沟纵坡
        /// </summary>
        /// <returns></returns>
        [Column("MCHANNELLSLOPE")]
        public string MCHANNELLSLOPE { get; set; }
        /// <summary>
        /// 新构造影响
        /// </summary>
        /// <returns></returns>
        [Column("NEWCONSTRUCTIONAFFECT")]
        public string NEWCONSTRUCTIONAFFECT { get; set; }
        /// <summary>
        /// 植被覆盖率
        /// </summary>
        /// <returns></returns>
        [Column("VEGETATIONCOVERAGE")]
        public string VEGETATIONCOVERAGE { get; set; }
        /// <summary>
        /// 冲淤变幅（米）
        /// </summary>
        /// <returns></returns>
        [Column("EROSIONAMPLITUDE")]
        public string EROSIONAMPLITUDE { get; set; }
        /// <summary>
        /// 岩性因素
        /// </summary>
        /// <returns></returns>
        [Column("ROCKFACTOR")]
        public string ROCKFACTOR { get; set; }
        /// <summary>
        /// 松散物储量(万立方米/平方公里）
        /// </summary>
        /// <returns></returns>
        [Column("LOOSEMATRESERVES")]
        public string LOOSEMATRESERVES { get; set; }
        /// <summary>
        /// 山坡坡度
        /// </summary>
        /// <returns></returns>
        [Column("MOUNTAINSLOPE")]
        public string MOUNTAINSLOPE { get; set; }
        /// <summary>
        /// 沟槽横断面
        /// </summary>
        /// <returns></returns>
        [Column("TRENCHCCROSSSECTIONAL")]
        public string TRENCHCCROSSSECTIONAL { get; set; }
        /// <summary>
        /// 松散物平均厚（米）
        /// </summary>
        /// <returns></returns>
        [Column("LOOSEMATAVERAGETHICK")]
        public string LOOSEMATAVERAGETHICK { get; set; }
        /// <summary>
        /// 流域面积（平方米）
        /// </summary>
        /// <returns></returns>
        [Column("DRAINAGESIZE")]
        public string DRAINAGESIZE { get; set; }
        /// <summary>
        /// 相对高差（米）
        /// </summary>
        /// <returns></returns>
        [Column("RELATIVEHEIGHT")]
        public string RELATIVEHEIGHT { get; set; }
        /// <summary>
        /// 堵塞程度
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKDEGREE")]
        public string BLOCKDEGREE { get; set; }
        /// <summary>
        /// 评分1
        /// </summary>
        /// <returns></returns>
        [Column("SCORE1")]
        public decimal? SCORE1 { get; set; }
        /// <summary>
        /// 评分2
        /// </summary>
        /// <returns></returns>
        [Column("SCORE2")]
        public decimal? SCORE2 { get; set; }
        /// <summary>
        /// 评分3
        /// </summary>
        /// <returns></returns>
        [Column("SCORE3")]
        public decimal? SCORE3 { get; set; }
        /// <summary>
        /// 评分4
        /// </summary>
        /// <returns></returns>
        [Column("SCORE4")]
        public decimal? SCORE4 { get; set; }
        /// <summary>
        /// 评分5
        /// </summary>
        /// <returns></returns>
        [Column("SCORE5")]
        public decimal? SCORE5 { get; set; }
        /// <summary>
        /// 评分6
        /// </summary>
        /// <returns></returns>
        [Column("SCORE6")]
        public decimal? SCORE6 { get; set; }
        /// <summary>
        /// 评分7
        /// </summary>
        /// <returns></returns>
        [Column("SCORE7")]
        public decimal? SCORE7 { get; set; }
        /// <summary>
        /// 评分8
        /// </summary>
        /// <returns></returns>
        [Column("SCORE8")]
        public decimal? SCORE8 { get; set; }
        /// <summary>
        /// 评分9
        /// </summary>
        /// <returns></returns>
        [Column("SCORE9")]
        public decimal? SCORE9 { get; set; }
        /// <summary>
        /// 评分10
        /// </summary>
        /// <returns></returns>
        [Column("SCORE10")]
        public decimal? SCORE10 { get; set; }
        /// <summary>
        /// 评分11
        /// </summary>
        /// <returns></returns>
        [Column("SCORE11")]
        public decimal? SCORE11 { get; set; }
        /// <summary>
        /// 评分12
        /// </summary>
        /// <returns></returns>
        [Column("SCORE12")]
        public decimal? SCORE12 { get; set; }
        /// <summary>
        /// 评分13
        /// </summary>
        /// <returns></returns>
        [Column("SCORE13")]
        public decimal? SCORE13 { get; set; }
        /// <summary>
        /// 评分14
        /// </summary>
        /// <returns></returns>
        [Column("SCORE14")]
        public decimal? SCORE14 { get; set; }
        /// <summary>
        /// 评分15
        /// </summary>
        /// <returns></returns>
        [Column("SCORE15")]
        public decimal? SCORE15 { get; set; }
        /// <summary>
        /// 总分
        /// </summary>
        /// <returns></returns>
        [Column("TOTAL")]
        public string TOTAL { get; set; }
        /// <summary>
        /// 易发程度
        /// </summary>
        /// <returns></returns>
        [Column("PRONEDEGREE")]
        public string PRONEDEGREE { get; set; }
        /// <summary>
        /// 泥石流类型
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWTYPE")]
        public string DEBRISFLOWTYPE { get; set; }
        /// <summary>
        /// 发展阶段
        /// </summary>
        /// <returns></returns>
        [Column("DEVELOPINGSTAGE")]
        public string DEVELOPINGSTAGE { get; set; }
        /// <summary>
        /// 监测建议
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWMONITORSUGGESTION")]
        public string DEBRISFLOWMONITORSUGGESTION { get; set; }
        /// <summary>
        /// 防治建议
        /// </summary>
        /// <returns></returns>
        [Column("TREATMENTSUGGESTION")]
        public string TREATMENTSUGGESTION { get; set; }
        /// <summary>
        /// 隐患点
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENPOINT")]
        public string HIDDENPOINT { get; set; }
        /// <summary>
        /// 防灾预案
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERPREPAREDNESS")]
        public string DISASTERPREPAREDNESS { get; set; }
        /// <summary>
        /// 群测人员
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMASS")]
        public string MONITORMASS { get; set; }
        /// <summary>
        /// 村长
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGEHEADER")]
        public string VILLAGEHEADER { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        [Column("PHONE")]
        public string PHONE { get; set; }
        /// <summary>
        /// 调查负责人
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYHEADER")]
        public string SURVEYHEADER { get; set; }
        /// <summary>
        /// 填表人
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEPEOPLE")]
        public string FILLTABLEPEOPLE { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        /// <returns></returns>
        [Column("VERIFYPEOPLE")]
        public string VERIFYPEOPLE { get; set; }
        /// <summary>
        /// 调查单位
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYDEPT")]
        public string SURVEYDEPT { get; set; }
        /// <summary>
        /// 填表日期
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEDATE")]
        public DateTime? FILLTABLEDATE { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETIME")]
        public DateTime? UPDATETIME { get; set; }
        /// <summary>
        /// 记录状态
        /// </summary>
        /// <returns></returns>
        [Column("RECORDSTATUS")]
        public string RECORDSTATUS { get; set; }
        /// <summary>
        /// 导出状态
        /// </summary>
        /// <returns></returns>
        [Column("EXPSTATUS")]
        public string EXPSTATUS { get; set; }
        /// <summary>
        /// 防灾情况
        /// </summary>
        /// <returns></returns>
        [Column("CONTROLSTATE")]
        public string CONTROLSTATE { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
        /// <returns></returns>
        [Column("CREATORUSERID")]
        public string CREATORUSERID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [Column("CREATORTIME")]
        public DateTime? CREATORTIME { get; set; }
        /// <summary>
        /// 更新者ID
        /// </summary>
        /// <returns></returns>
        [Column("UPDATEUSERID")]
        public string UPDATEUSERID { get; set; }
        /// <summary>
        /// 更新次数
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETIMES")]
        public short? UPDATETIMES { get; set; }
        /// <summary>
        /// 泥石流情况
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWDESC")]
        public string DEBRISFLOWDESC { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTID")]
        public string PROJECTID { get; set; }
        /// <summary>
        /// 图幅编号
        /// </summary>
        /// <returns></returns>
        [Column("MAPID")]
        public string MAPID { get; set; }
        /// <summary>
        /// 图幅名称
        /// </summary>
        /// <returns></returns>
        [Column("MAPNAME")]
        public string MAPNAME { get; set; }
        /// <summary>
        /// 县市编号
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYCODE")]
        public string COUNTYCODE { get; set; }
        /// <summary>
        /// 暴发频率（次/年）
        /// </summary>
        /// <returns></returns>
        [Column("OCCURREDFREQUENCY")]
        public short? OCCURREDFREQUENCY { get; set; }
        /// <summary>
        /// 死亡人口（人）
        /// </summary>
        /// <returns></returns>
        [Column("DEATHSPEOPLE")]
        public int? DEATHSPEOPLE { get; set; }
        /// <summary>
        /// 直接经济损失（万元）
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTECONOMICLOSSES")]
        public decimal? DIRECTECONOMICLOSSES { get; set; }
        /// <summary>
        /// 灾情等级
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERLEVEL")]
        public string DISASTERLEVEL { get; set; }
        /// <summary>
        /// 危害对象
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDOBJECT")]
        public string DESTROYEDOBJECT { get; set; }
        /// <summary>
        /// 遥感解译点（0：否；1：是）
        /// </summary>
        /// <returns></returns>
        [Column("ISRSPNT")]
        public string ISRSPNT { get; set; }
        /// <summary>
        /// 勘查点（0：否；1：是）
        /// </summary>
        /// <returns></returns>
        [Column("ISSURVEYPNT")]
        public string ISSURVEYPNT { get; set; }
        /// <summary>
        /// 测绘点（0：否；1：是）
        /// </summary>
        /// <returns></returns>
        [Column("ISMEASURINGPNT")]
        public string ISMEASURINGPNT { get; set; }
        /// <summary>
        /// 野外记录信息
        /// </summary>
        /// <returns></returns>
        [Column("OUTDOORRECORD")]
        public string OUTDOORRECORD { get; set; }
        /// <summary>
        /// 村
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGE")]
        public string VILLAGE { get; set; }
        /// <summary>
        /// 组
        /// </summary>
        /// <returns></returns>
        [Column("TEAM")]
        public string TEAM { get; set; }
        /// <summary>
        /// 群测群防
        /// </summary>
        /// <returns></returns>
        [Column("MASSMONITORING")]
        public string MASSMONITORING { get; set; }
        /// <summary>
        /// 搬迁避让
        /// </summary>
        /// <returns></returns>
        [Column("RELOCATION")]
        public string RELOCATION { get; set; }
        /// <summary>
        /// 专业监测
        /// </summary>
        /// <returns></returns>
        [Column("PROFESSIONMONITORING")]
        public string PROFESSIONMONITORING { get; set; }
        /// <summary>
        /// 工程治理
        /// </summary>
        /// <returns></returns>
        [Column("ENGINEERINGMANAGEMENT")]
        public string ENGINEERINGMANAGEMENT { get; set; }
        /// <summary>
        /// 其它
        /// </summary>
        /// <returns></returns>
        [Column("OTHER")]
        public string OTHER { get; set; }
        /// <summary>
        /// 威胁房屋（户）
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOME")]
        public int? THREATENHOME { get; set; }
        /// <summary>
        /// 流域
        /// </summary>
        /// <returns></returns>
        [Column("RIVERBASIN")]
        public string RIVERBASIN { get; set; }
        /// <summary>
        /// 失踪人数
        /// </summary>
        /// <returns></returns>
        [Column("MISSINGPERSON")]
        public int? MISSINGPERSON { get; set; }
        /// <summary>
        /// 受伤人数
        /// </summary>
        /// <returns></returns>
        [Column("INJUREDPERSON")]
        public int? INJUREDPERSON { get; set; }
        /// <summary>
        /// 是否治理工程
        /// </summary>
        /// <returns></returns>
        [Column("ISZLGCPNT")]
        public string ISZLGCPNT { get; set; }
        /// <summary>
        /// 是否有监测点
        /// </summary>
        /// <returns></returns>
        [Column("ISMONITORPNT")]
        public string ISMONITORPNT { get; set; }
        /// <summary>
        /// 遥感解译
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERSID")]
        public string DISASTERSID { get; set; }
        /// <summary>
        /// 更新人(最近)
        /// </summary>
        /// <returns></returns>
        [Column("UPDATEUSER")]
        public string UPDATEUSER { get; set; }
        /// <summary>
        /// 群测人ID
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMASSID")]
        public string MONITORMASSID { get; set; }
        /// <summary>
        /// 村长ID
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGEHEADERID")]
        public string VILLAGEHEADERID { get; set; }
        /// <summary>
        /// 调查负责人ID
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYHEADERID")]
        public string SURVEYHEADERID { get; set; }
        /// <summary>
        /// 填表人ID
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEPEOPLEID")]
        public string FILLTABLEPEOPLEID { get; set; }
        /// <summary>
        /// 审核人ID
        /// </summary>
        /// <returns></returns>
        [Column("VERIFYPEOPLEID")]
        public string VERIFYPEOPLEID { get; set; }
        /// <summary>
        /// 调查单位ID
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYDEPTID")]
        public string SURVEYDEPTID { get; set; }
        /// <summary>
        /// 泥石流特征容量(t/m3)
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOWCAPACITY")]
        public decimal? DEBRISFLOWCAPACITY { get; set; }
        /// <summary>
        /// 泥石流特征流量(m3/s)
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
        /// 省名称
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        /// <returns></returns>
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// 县名称
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
        /// <summary>
        /// 乡镇名称
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
        /// <summary>
        /// 是否重大隐患点
        /// </summary>
        /// <returns></returns>
        [Column("ISZDYHD")]
        public string ISZDYHD { get; set; }
        /// <summary>
        /// 数据来源
        /// </summary>
        /// <returns></returns>
        [Column("DATASOURCE")]
        public string DATASOURCE { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.UNIFIEDCODE = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.UNIFIEDCODE = keyValue;
        }
        #endregion
    }
}
