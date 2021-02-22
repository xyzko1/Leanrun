using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-26 17:14
    /// 描 述：滑坡调查表历史表
    /// </summary>
    public class TBL_LANDSLIP_HISTORYEntity : BaseEntity
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
        /// 灾害点名称
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
        /// 坡底
        /// </summary>
        /// <returns></returns>
        [Column("ALTTOP")]
        public decimal? ALTTOP { get; set; }
        /// <summary>
        /// 坡顶
        /// </summary>
        /// <returns></returns>
        [Column("ALTBOTOM")]
        public decimal? ALTBOTOM { get; set; }
        /// <summary>
        /// 滑坡年代
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPYEAR")]
        public string LANDSLIPYEAR { get; set; }
        /// <summary>
        /// 滑坡时间
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPTIME")]
        public string LANDSLIPTIME { get; set; }
        /// <summary>
        /// 滑坡类型
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPTYPE")]
        public string LANDSLIPTYPE { get; set; }
        /// <summary>
        /// 滑体性质
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPKIND")]
        public string LANDSLIPKIND { get; set; }
        /// <summary>
        /// 地层时代
        /// </summary>
        /// <returns></returns>
        [Column("STRATIGRAPHICTIME")]
        public string STRATIGRAPHICTIME { get; set; }
        /// <summary>
        /// 地层岩性
        /// </summary>
        /// <returns></returns>
        [Column("LITHOLOGY")]
        public string LITHOLOGY { get; set; }
        /// <summary>
        /// 构造部位
        /// </summary>
        /// <returns></returns>
        [Column("TECTONICREGION")]
        public string TECTONICREGION { get; set; }
        /// <summary>
        /// 地震烈度
        /// </summary>
        /// <returns></returns>
        [Column("EARTHQUAKEINTENSITY")]
        public string EARTHQUAKEINTENSITY { get; set; }
        /// <summary>
        /// 地层倾向
        /// </summary>
        /// <returns></returns>
        [Column("STRATUMDIRECTION")]
        public int? STRATUMDIRECTION { get; set; }
        /// <summary>
        /// 地层倾角
        /// </summary>
        /// <returns></returns>
        [Column("STRATUMANGLE")]
        public int? STRATUMANGLE { get; set; }
        /// <summary>
        /// 微地貌
        /// </summary>
        /// <returns></returns>
        [Column("MICROTOPOGRAPHY")]
        public string MICROTOPOGRAPHY { get; set; }
        /// <summary>
        /// 地下水类型
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATERTYPE")]
        public string GROUNDWATERTYPE { get; set; }
        /// <summary>
        /// 年均降雨量
        /// </summary>
        /// <returns></returns>
        [Column("AVERAGEYEARRAINFALL")]
        public decimal? AVERAGEYEARRAINFALL { get; set; }
        /// <summary>
        /// 日最大降雨量
        /// </summary>
        /// <returns></returns>
        [Column("MAXDAYRAINFALL")]
        public decimal? MAXDAYRAINFALL { get; set; }
        /// <summary>
        /// 时最大降雨量
        /// </summary>
        /// <returns></returns>
        [Column("MAXHOURRAINFALL")]
        public decimal? MAXHOURRAINFALL { get; set; }
        /// <summary>
        /// 洪水位
        /// </summary>
        /// <returns></returns>
        [Column("MAXWATERLEVEL")]
        public decimal? MAXWATERLEVEL { get; set; }
        /// <summary>
        /// 枯水位
        /// </summary>
        /// <returns></returns>
        [Column("MINWATERLEVEL")]
        public decimal? MINWATERLEVEL { get; set; }
        /// <summary>
        /// 相对河流位置
        /// </summary>
        /// <returns></returns>
        [Column("POSITIONTORIVER")]
        public string POSITIONTORIVER { get; set; }
        /// <summary>
        /// 原始坡高
        /// </summary>
        /// <returns></returns>
        [Column("ORIGINALSLOPEHEIGHT")]
        public decimal? ORIGINALSLOPEHEIGHT { get; set; }
        /// <summary>
        /// 原始坡度
        /// </summary>
        /// <returns></returns>
        [Column("ORIGINALSLOPEANGLE")]
        public short? ORIGINALSLOPEANGLE { get; set; }
        /// <summary>
        /// 原始坡形
        /// </summary>
        /// <returns></returns>
        [Column("ORIGINALSLOPESHAPE")]
        public string ORIGINALSLOPESHAPE { get; set; }
        /// <summary>
        /// 斜坡结构类型
        /// </summary>
        /// <returns></returns>
        [Column("SLOPEARCHTYPE")]
        public string SLOPEARCHTYPE { get; set; }
        /// <summary>
        /// 斜坡结构类型
        /// </summary>
        /// <returns></returns>
        [Column("SLOPEASPECTARCHTYPE")]
        public string SLOPEASPECTARCHTYPE { get; set; }
        /// <summary>
        /// 控滑结构面类型1
        /// </summary>
        /// <returns></returns>
        [Column("SURFACETYPE1")]
        public string SURFACETYPE1 { get; set; }
        /// <summary>
        /// 控滑结构面倾向1
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEDIRECTION1")]
        public int? SURFACEDIRECTION1 { get; set; }
        /// <summary>
        /// 控滑结构面倾角1
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEANGLE1")]
        public int? SURFACEANGLE1 { get; set; }
        /// <summary>
        /// 控滑结构面类型2
        /// </summary>
        /// <returns></returns>
        [Column("SURFACETYPE2")]
        public string SURFACETYPE2 { get; set; }
        /// <summary>
        /// 控滑结构面倾向2
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEDIRECTION2")]
        public int? SURFACEDIRECTION2 { get; set; }
        /// <summary>
        /// 控滑结构面倾角2
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEANGLE2")]
        public int? SURFACEANGLE2 { get; set; }
        /// <summary>
        /// 控滑结构面类型3
        /// </summary>
        /// <returns></returns>
        [Column("SURFACETYPE3")]
        public string SURFACETYPE3 { get; set; }
        /// <summary>
        /// 控滑结构面倾向3
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEDIRECTION3")]
        public int? SURFACEDIRECTION3 { get; set; }
        /// <summary>
        /// 控滑结构面倾角3
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEANGLE3")]
        public int? SURFACEANGLE3 { get; set; }
        /// <summary>
        /// 滑坡长度
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPLENGTH")]
        public decimal? LANDSLIPLENGTH { get; set; }
        /// <summary>
        /// 滑坡宽度
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPWIDTH")]
        public decimal? LANDSLIPWIDTH { get; set; }
        /// <summary>
        /// 滑坡厚度
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPDEPTH")]
        public decimal? LANDSLIPDEPTH { get; set; }
        /// <summary>
        /// 滑坡坡度
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPANGLE")]
        public int? LANDSLIPANGLE { get; set; }
        /// <summary>
        /// 滑坡坡向
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPDIRECTION")]
        public int? LANDSLIPDIRECTION { get; set; }
        /// <summary>
        /// 滑坡面积
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPSIZE")]
        public decimal? LANDSLIPSIZE { get; set; }
        /// <summary>
        /// 滑坡体积
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPVOLUME")]
        public decimal? LANDSLIPVOLUME { get; set; }
        /// <summary>
        /// 滑坡平面形态
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPFLATSHAPE")]
        public string LANDSLIPFLATSHAPE { get; set; }
        /// <summary>
        /// 滑坡剖面形态
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPSECTIONSHAPE")]
        public string LANDSLIPSECTIONSHAPE { get; set; }
        /// <summary>
        /// 规模等级
        /// </summary>
        /// <returns></returns>
        [Column("SCALELEVEL")]
        public string SCALELEVEL { get; set; }
        /// <summary>
        /// 滑体岩性
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPLITHOLOGY")]
        public string LANDSLIPLITHOLOGY { get; set; }
        /// <summary>
        /// 滑体结构
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPARCH")]
        public string LANDSLIPARCH { get; set; }
        /// <summary>
        /// 滑体碎石含量
        /// </summary>
        /// <returns></returns>
        [Column("GRAVELCONTENT")]
        public decimal? GRAVELCONTENT { get; set; }
        /// <summary>
        /// 滑体块度
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPBLOCKDEGREE")]
        public string LANDSLIPBLOCKDEGREE { get; set; }
        /// <summary>
        /// 滑床岩性
        /// </summary>
        /// <returns></returns>
        [Column("SLIPBEDLITHOLOGY")]
        public string SLIPBEDLITHOLOGY { get; set; }
        /// <summary>
        /// 滑床时代
        /// </summary>
        /// <returns></returns>
        [Column("SLIPBEDTIME")]
        public string SLIPBEDTIME { get; set; }
        /// <summary>
        /// 滑床倾向
        /// </summary>
        /// <returns></returns>
        [Column("SLIPBEDDIRECTION")]
        public int? SLIPBEDDIRECTION { get; set; }
        /// <summary>
        /// 滑床倾角
        /// </summary>
        /// <returns></returns>
        [Column("SLIPBEDANGLE")]
        public int? SLIPBEDANGLE { get; set; }
        /// <summary>
        /// 滑面形态
        /// </summary>
        /// <returns></returns>
        [Column("SLIPSURFACESHAPE")]
        public string SLIPSURFACESHAPE { get; set; }
        /// <summary>
        /// 滑面埋深
        /// </summary>
        /// <returns></returns>
        [Column("SLIPSURFACEDEPTH")]
        public decimal? SLIPSURFACEDEPTH { get; set; }
        /// <summary>
        /// 滑面倾向
        /// </summary>
        /// <returns></returns>
        [Column("SLIPSURFACEDIRECTION")]
        public int? SLIPSURFACEDIRECTION { get; set; }
        /// <summary>
        /// 滑面倾角
        /// </summary>
        /// <returns></returns>
        [Column("SLIPSURFACEANGLE")]
        public int? SLIPSURFACEANGLE { get; set; }
        /// <summary>
        /// 滑带厚度
        /// </summary>
        /// <returns></returns>
        [Column("SLIPZONEDEPTH")]
        public decimal? SLIPZONEDEPTH { get; set; }
        /// <summary>
        /// 滑带土名称
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPSOILNAME")]
        public string LANDSLIPSOILNAME { get; set; }
        /// <summary>
        /// 滑带土性状
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPSOILCHARACTERS")]
        public string LANDSLIPSOILCHARACTERS { get; set; }
        /// <summary>
        /// 地下水埋深
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATERDEPTH")]
        public decimal? GROUNDWATERDEPTH { get; set; }
        /// <summary>
        /// 地下水露头
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATEROUTCROP")]
        public string GROUNDWATEROUTCROP { get; set; }
        /// <summary>
        /// 地下水补给类型
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATERSUPPLYTYPE")]
        public string GROUNDWATERSUPPLYTYPE { get; set; }
        /// <summary>
        /// 土地使用
        /// </summary>
        /// <returns></returns>
        [Column("LANDUSAGE")]
        public string LANDUSAGE { get; set; }
        /// <summary>
        /// 变形迹象名称1
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN1")]
        public string DISTORTIONSIGN1 { get; set; }
        /// <summary>
        /// 变形迹象部位1
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE1")]
        public string DISTORTIONPLACE1 { get; set; }
        /// <summary>
        /// 变形迹象特征1
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER1")]
        public string DISTORTIONCHARACTER1 { get; set; }
        /// <summary>
        /// 变形迹象初现时间1
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE1")]
        public string DISTORTIONINITDATE1 { get; set; }
        /// <summary>
        /// 变形迹象名称2
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN2")]
        public string DISTORTIONSIGN2 { get; set; }
        /// <summary>
        /// 变形迹象部位2
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE2")]
        public string DISTORTIONPLACE2 { get; set; }
        /// <summary>
        /// 变形迹象特征2
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER2")]
        public string DISTORTIONCHARACTER2 { get; set; }
        /// <summary>
        /// 变形迹象初现时间2
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE2")]
        public string DISTORTIONINITDATE2 { get; set; }
        /// <summary>
        /// 变形迹象名称3
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN3")]
        public string DISTORTIONSIGN3 { get; set; }
        /// <summary>
        /// 变形迹象部位3
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE3")]
        public string DISTORTIONPLACE3 { get; set; }
        /// <summary>
        /// 变形迹象特征3
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER3")]
        public string DISTORTIONCHARACTER3 { get; set; }
        /// <summary>
        /// 变形迹象初现时间3
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE3")]
        public string DISTORTIONINITDATE3 { get; set; }
        /// <summary>
        /// 变形迹象名称4
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN4")]
        public string DISTORTIONSIGN4 { get; set; }
        /// <summary>
        /// 变形迹象部位4
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE4")]
        public string DISTORTIONPLACE4 { get; set; }
        /// <summary>
        /// 变形迹象特征4
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER4")]
        public string DISTORTIONCHARACTER4 { get; set; }
        /// <summary>
        /// 变形迹象初现时间4
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE4")]
        public string DISTORTIONINITDATE4 { get; set; }
        /// <summary>
        /// 变形迹象名称5
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN5")]
        public string DISTORTIONSIGN5 { get; set; }
        /// <summary>
        /// 变形迹象部位5
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE5")]
        public string DISTORTIONPLACE5 { get; set; }
        /// <summary>
        /// 变形迹象特征5
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER5")]
        public string DISTORTIONCHARACTER5 { get; set; }
        /// <summary>
        /// 变形迹象初现时间5
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE5")]
        public string DISTORTIONINITDATE5 { get; set; }
        /// <summary>
        /// 变形迹象名称6
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN6")]
        public string DISTORTIONSIGN6 { get; set; }
        /// <summary>
        /// 变形迹象部位6
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE6")]
        public string DISTORTIONPLACE6 { get; set; }
        /// <summary>
        /// 变形迹象特征6
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER6")]
        public string DISTORTIONCHARACTER6 { get; set; }
        /// <summary>
        /// 变形迹象初现时间6
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE6")]
        public string DISTORTIONINITDATE6 { get; set; }
        /// <summary>
        /// 变形迹象名称7
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN7")]
        public string DISTORTIONSIGN7 { get; set; }
        /// <summary>
        /// 变形迹象部位7
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE7")]
        public string DISTORTIONPLACE7 { get; set; }
        /// <summary>
        /// 变形迹象特征7
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER7")]
        public string DISTORTIONCHARACTER7 { get; set; }
        /// <summary>
        /// 变形迹象初现时间7
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE7")]
        public string DISTORTIONINITDATE7 { get; set; }
        /// <summary>
        /// 变形迹象名称8
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONSIGN8")]
        public string DISTORTIONSIGN8 { get; set; }
        /// <summary>
        /// 变形迹象部位8
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONPLACE8")]
        public string DISTORTIONPLACE8 { get; set; }
        /// <summary>
        /// 变形迹象特征8
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONCHARACTER8")]
        public string DISTORTIONCHARACTER8 { get; set; }
        /// <summary>
        /// 变形迹象初现时间8
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONINITDATE8")]
        public string DISTORTIONINITDATE8 { get; set; }
        /// <summary>
        /// 地质因素
        /// </summary>
        /// <returns></returns>
        [Column("GEOLOGICFACTOR")]
        public string GEOLOGICFACTOR { get; set; }
        /// <summary>
        /// 地貌因素
        /// </summary>
        /// <returns></returns>
        [Column("GEOMORPHICFACTOR")]
        public string GEOMORPHICFACTOR { get; set; }
        /// <summary>
        /// 物理因素
        /// </summary>
        /// <returns></returns>
        [Column("PHYSICALFACTORS")]
        public string PHYSICALFACTORS { get; set; }
        /// <summary>
        /// 人为因素
        /// </summary>
        /// <returns></returns>
        [Column("HUMANFACTOR")]
        public string HUMANFACTOR { get; set; }
        /// <summary>
        /// 主导因素
        /// </summary>
        /// <returns></returns>
        [Column("MAINFACTOR")]
        public string MAINFACTOR { get; set; }
        /// <summary>
        /// 复活诱发因素
        /// </summary>
        /// <returns></returns>
        [Column("REINDUCEDFACTOR")]
        public string REINDUCEDFACTOR { get; set; }
        /// <summary>
        /// 目前稳定状态
        /// </summary>
        /// <returns></returns>
        [Column("CURSTABLESTATUS")]
        public string CURSTABLESTATUS { get; set; }
        /// <summary>
        /// 今后变化趋势
        /// </summary>
        /// <returns></returns>
        [Column("STABLETREND")]
        public string STABLETREND { get; set; }
        /// <summary>
        /// 隐患点
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENDANGER")]
        public string HIDDENDANGER { get; set; }
        /// <summary>
        /// 毁坏房屋(户)
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOME")]
        public int? DESTROYEDHOME { get; set; }
        /// <summary>
        /// 死亡人口
        /// </summary>
        /// <returns></returns>
        [Column("DEATHSPEOPLE")]
        public int? DEATHSPEOPLE { get; set; }
        /// <summary>
        /// 直接损失
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTLOSSES")]
        public decimal? DIRECTLOSSES { get; set; }
        /// <summary>
        /// 灾情等级
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERLEVEL")]
        public string DISASTERLEVEL { get; set; }
        /// <summary>
        /// 威胁住户
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOUSEHOLD")]
        public int? THREATENHOUSEHOLD { get; set; }
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
        /// 防灾预案
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONPLAN")]
        public string PREVENTIONPLAN { get; set; }
        /// <summary>
        /// 监测建议
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPMONITORSUGGESTION")]
        public string LANDSLIPMONITORSUGGESTION { get; set; }
        /// <summary>
        /// 防治建议
        /// </summary>
        /// <returns></returns>
        [Column("TREATMENTSUGGESTION")]
        public string TREATMENTSUGGESTION { get; set; }
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
        ///   调查单位  
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
        /// 滑坡情况
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPDESC")]
        public string LANDSLIPDESC { get; set; }
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
        /// 变形活动阶段
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONACTIVITIESPROGRESS")]
        public string DISTORTIONACTIVITIESPROGRESS { get; set; }
        /// <summary>
        /// 自然诱因
        /// </summary>
        /// <returns></returns>
        [Column("NATURALFACTOR")]
        public string NATURALFACTOR { get; set; }
        /// <summary>
        /// 损坏房屋(间)
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOUSE")]
        public decimal? DESTROYEDHOUSE { get; set; }
        /// <summary>
        /// 毁路（米）
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDROAD")]
        public decimal? DESTROYEDROAD { get; set; }
        /// <summary>
        /// 毁渠（米）
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDCANAL")]
        public decimal? DESTROYEDCANAL { get; set; }
        /// <summary>
        /// 其他危害
        /// </summary>
        /// <returns></returns>
        [Column("OTHERHARM")]
        public string OTHERHARM { get; set; }
        /// <summary>
        /// 间接损失（万元）
        /// </summary>
        /// <returns></returns>
        [Column("INDIRECTLOSS")]
        public decimal? INDIRECTLOSS { get; set; }
        /// <summary>
        /// 危害对象
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDOBJECT")]
        public string DESTROYEDOBJECT { get; set; }
        /// <summary>
        /// 诱发灾害类型
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDDAMAGETYPE")]
        public string INDUCEDDAMAGETYPE { get; set; }
        /// <summary>
        /// 诱发灾害波及范围
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDDAMAGERANGE")]
        public string INDUCEDDAMAGERANGE { get; set; }
        /// <summary>
        /// 诱发灾害造成损失
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDDAMAGELOSS")]
        public string INDUCEDDAMAGELOSS { get; set; }
        /// <summary>
        /// 潜在危害威胁对象
        /// </summary>
        /// <returns></returns>
        [Column("THREATENOBJECT")]
        public string THREATENOBJECT { get; set; }
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
        /// 控滑结构面类型4
        /// </summary>
        /// <returns></returns>
        [Column("SURFACETYPE4")]
        public string SURFACETYPE4 { get; set; }
        /// <summary>
        /// 控滑结构面倾向4
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEDIRECTION4")]
        public int? SURFACEDIRECTION4 { get; set; }
        /// <summary>
        /// 控滑结构面倾角4
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEANGLE4")]
        public int? SURFACEANGLE4 { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 修改类型（I：批量导入；A：新增记录；U：修改记录；D：删除记录）
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYTYPE")]
        public string MODIFYTYPE { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        /// <returns></returns>
        [Column("MODIFIEDDATE")]
        public DateTime? MODIFIEDDATE { get; set; }
        /// <summary>
        /// 修改人，对应用户表的LOGINNAME属性
        /// </summary>
        /// <returns></returns>
        [Column("EDITOR")]
        public string EDITOR { get; set; }
        /// <summary>
        /// 状态（0-未提交 1-待审核 2-审核通过 3-审核不通过,4-已撤销,5-跳过审核）
        /// </summary>
        /// <returns></returns>
        [Column("AUDITSTATUS")]
        public string AUDITSTATUS { get; set; }
        /// <summary>
        /// 审阅人，对应用户表的LOGINNAME属性
        /// </summary>
        /// <returns></returns>
        [Column("AUDITOR")]
        public string AUDITOR { get; set; }
        /// <summary>
        /// 审阅日期
        /// </summary>
        /// <returns></returns>
        [Column("AUDITEDDATE")]
        public DateTime? AUDITEDDATE { get; set; }
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
        ///     群测人员ID  
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMASSID")]
        public string MONITORMASSID { get; set; }
        /// <summary>
        ///     村长ID    
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGEHEADERID")]
        public string VILLAGEHEADERID { get; set; }
        /// <summary>
        ///     调查负责人ID 
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYHEADERID")]
        public string SURVEYHEADERID { get; set; }
        /// <summary>
        ///     填表人ID   
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEPEOPLEID")]
        public string FILLTABLEPEOPLEID { get; set; }
        /// <summary>
        ///     审核人ID   
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
        /// 核销类型
        /// </summary>
        /// <returns></returns>
        [Column("VERIFICATION")]
        public string VERIFICATION { get; set; }
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
        /// 滑坡规模等级
        /// </summary>
        /// <returns></returns>
        [Column("HPGMDJ")]
        public string HPGMDJ { get; set; }
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
