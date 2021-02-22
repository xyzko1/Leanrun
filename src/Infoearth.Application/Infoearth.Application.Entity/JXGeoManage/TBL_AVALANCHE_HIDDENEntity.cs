using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-05 11:41
    /// 描 述：崩塌调查表
    /// </summary>
    public class TBL_AVALANCHE_HIDDENEntity : BaseEntity
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
        /// 地理位置
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
        /// 坡顶标高
        /// </summary>
        /// <returns></returns>
        [Column("ALTTOP")]
        public decimal? ALTTOP { get; set; }
        /// <summary>
        /// 坡脚标高
        /// </summary>
        /// <returns></returns>
        [Column("ALTBOTOM")]
        public decimal? ALTBOTOM { get; set; }
        /// <summary>
        /// 崩塌类型
        /// </summary>
        /// <returns></returns>
        [Column("AVALANCHETYPE")]
        public string AVALANCHETYPE { get; set; }
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
        public decimal? STRATUMDIRECTION { get; set; }
        /// <summary>
        /// 地层倾角
        /// </summary>
        /// <returns></returns>
        [Column("STRATUMANGLE")]
        public decimal? STRATUMANGLE { get; set; }
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
        /// 日最大降雨
        /// </summary>
        /// <returns></returns>
        [Column("MAXDAYRAINFALL")]
        public decimal? MAXDAYRAINFALL { get; set; }
        /// <summary>
        /// 时最大降雨
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
        /// 土地利用
        /// </summary>
        /// <returns></returns>
        [Column("LANDUSAGE")]
        public string LANDUSAGE { get; set; }
        /// <summary>
        /// 坡高
        /// </summary>
        /// <returns></returns>
        [Column("SLOPEHEIGHT")]
        public decimal? SLOPEHEIGHT { get; set; }
        /// <summary>
        /// 坡长
        /// </summary>
        /// <returns></returns>
        [Column("SLOPELENGTH")]
        public decimal? SLOPELENGTH { get; set; }
        /// <summary>
        /// 坡宽
        /// </summary>
        /// <returns></returns>
        [Column("SLOPEWIDTH")]
        public decimal? SLOPEWIDTH { get; set; }
        /// <summary>
        /// 体积（立方米）
        /// </summary>
        /// <returns></returns>
        [Column("SCALE")]
        public decimal? SCALE { get; set; }
        /// <summary>
        /// 规模等级
        /// </summary>
        /// <returns></returns>
        [Column("SCALELEVEL")]
        public string SCALELEVEL { get; set; }
        /// <summary>
        /// 坡度
        /// </summary>
        /// <returns></returns>
        [Column("SLOPEANGLE")]
        public int? SLOPEANGLE { get; set; }
        /// <summary>
        /// 坡向
        /// </summary>
        /// <returns></returns>
        [Column("SLOPEDIRECTION")]
        public int? SLOPEDIRECTION { get; set; }
        /// <summary>
        /// 岩体结构类型
        /// </summary>
        /// <returns></returns>
        [Column("ROCKARCHTYPE")]
        public string ROCKARCHTYPE { get; set; }
        /// <summary>
        /// 岩体厚度
        /// </summary>
        /// <returns></returns>
        [Column("ROCKDEPTH")]
        public decimal? ROCKDEPTH { get; set; }
        /// <summary>
        /// 岩体裂隙组数
        /// </summary>
        /// <returns></returns>
        [Column("FRACTUREGROUPNUM")]
        public decimal? FRACTUREGROUPNUM { get; set; }
        /// <summary>
        /// 岩体块长
        /// </summary>
        /// <returns></returns>
        [Column("ROCKLENGTH")]
        public decimal? ROCKLENGTH { get; set; }
        /// <summary>
        /// 岩体块宽
        /// </summary>
        /// <returns></returns>
        [Column("ROCKWIDTH")]
        public decimal? ROCKWIDTH { get; set; }
        /// <summary>
        /// 岩体块高
        /// </summary>
        /// <returns></returns>
        [Column("ROCKHEIGHT")]
        public decimal? ROCKHEIGHT { get; set; }
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
        /// 控制结构面类型1
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFTYPE1")]
        public string CTRLSURFTYPE1 { get; set; }
        /// <summary>
        /// 控制结构面倾向1
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFDIRECTION1")]
        public int? CTRLSURFDIRECTION1 { get; set; }
        /// <summary>
        /// 控制结构面倾角1
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFANGLE1")]
        public int? CTRLSURFANGLE1 { get; set; }
        /// <summary>
        /// 控制结构面长度1
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFLENGTH1")]
        public decimal? CTRLSURFLENGTH1 { get; set; }
        /// <summary>
        /// 控制结构面间距1
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFSPACE1")]
        public decimal? CTRLSURFSPACE1 { get; set; }
        /// <summary>
        /// 控制结构面类型2
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFTYPE2")]
        public string CTRLSURFTYPE2 { get; set; }
        /// <summary>
        /// 控制结构面倾向2
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFDIRECTION2")]
        public int? CTRLSURFDIRECTION2 { get; set; }
        /// <summary>
        /// 控制结构面倾角2
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFANGLE2")]
        public int? CTRLSURFANGLE2 { get; set; }
        /// <summary>
        /// 控制结构面长度2
        /// </summary>
        /// <returns></returns>
        [Column("COCTRLSURFLENGTH2")]
        public decimal? COCTRLSURFLENGTH2 { get; set; }
        /// <summary>
        /// 控制结构面间距2
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFSPACE2")]
        public decimal? CTRLSURFSPACE2 { get; set; }
        /// <summary>
        /// 控制结构面类型3
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFTYPE3")]
        public string CTRLSURFTYPE3 { get; set; }
        /// <summary>
        /// 控制结构面倾向3
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFDIRECTION3")]
        public int? CTRLSURFDIRECTION3 { get; set; }
        /// <summary>
        /// 控制结构面倾角3
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFANGLE3")]
        public int? CTRLSURFANGLE3 { get; set; }
        /// <summary>
        /// 控制结构面长度3
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFLENGTH3")]
        public decimal? CTRLSURFLENGTH3 { get; set; }
        /// <summary>
        /// 控制结构面间距3
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFSPACE3")]
        public decimal? CTRLSURFSPACE3 { get; set; }
        /// <summary>
        /// 全风化带深度(M)
        /// </summary>
        /// <returns></returns>
        [Column("WEATHEREDZONEDEPTH")]
        public decimal? WEATHEREDZONEDEPTH { get; set; }
        /// <summary>
        /// 卸荷裂缝深度(M)
        /// </summary>
        /// <returns></returns>
        [Column("UNLOADCRACKDEPTH")]
        public decimal? UNLOADCRACKDEPTH { get; set; }
        /// <summary>
        /// 土体名称
        /// </summary>
        /// <returns></returns>
        [Column("SOILTEXTURENAME")]
        public string SOILTEXTURENAME { get; set; }
        /// <summary>
        /// 土地密实度
        /// </summary>
        /// <returns></returns>
        [Column("SOILDENSITYDEGREE")]
        public string SOILDENSITYDEGREE { get; set; }
        /// <summary>
        /// 土地稠度
        /// </summary>
        /// <returns></returns>
        [Column("SOILCONSISTENCY")]
        public string SOILCONSISTENCY { get; set; }
        /// <summary>
        /// 下伏基岩时代
        /// </summary>
        /// <returns></returns>
        [Column("BEDROCKTIME")]
        public string BEDROCKTIME { get; set; }
        /// <summary>
        /// 下伏基岩岩性
        /// </summary>
        /// <returns></returns>
        [Column("BEDROCKLITHOLOGY")]
        public string BEDROCKLITHOLOGY { get; set; }
        /// <summary>
        /// 下伏基岩倾角
        /// </summary>
        /// <returns></returns>
        [Column("BEDROCKANGLE")]
        public decimal? BEDROCKANGLE { get; set; }
        /// <summary>
        /// 下伏基岩倾向
        /// </summary>
        /// <returns></returns>
        [Column("BEDROCKDIRECTION")]
        public decimal? BEDROCKDIRECTION { get; set; }
        /// <summary>
        /// 下伏基岩埋深(M)
        /// </summary>
        /// <returns></returns>
        [Column("BEDROCKDEPTH")]
        public decimal? BEDROCKDEPTH { get; set; }
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
        /// 危岩体可能失稳因素
        /// </summary>
        /// <returns></returns>
        [Column("DANGERROCKASTABLEFACTOR")]
        public string DANGERROCKASTABLEFACTOR { get; set; }
        /// <summary>
        /// 危岩体目前稳定程度
        /// </summary>
        /// <returns></returns>
        [Column("DANGERROCKSTABLESTATUS")]
        public string DANGERROCKSTABLESTATUS { get; set; }
        /// <summary>
        /// 危岩体今后变化趋势
        /// </summary>
        /// <returns></returns>
        [Column("DANGERROCKSTABLETREND")]
        public string DANGERROCKSTABLETREND { get; set; }
        /// <summary>
        /// 地下水埋深(M)
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
        /// 堆积体长度
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIONBODYLENGTH")]
        public decimal? ACCUMULATIONBODYLENGTH { get; set; }
        /// <summary>
        /// 堆积体宽度
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIONBODYWIDTH")]
        public decimal? ACCUMULATIONBODYWIDTH { get; set; }
        /// <summary>
        /// 堆积体厚度
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIONBODYDEPTH")]
        public decimal? ACCUMULATIONBODYDEPTH { get; set; }
        /// <summary>
        /// 堆积体体积
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIONBODYVOLUME")]
        public decimal? ACCUMULATIONBODYVOLUME { get; set; }
        /// <summary>
        /// 堆积体坡度
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIONBODYANGLE")]
        public int? ACCUMULATIONBODYANGLE { get; set; }
        /// <summary>
        /// 堆积体坡向
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIONBODYDIRECTION")]
        public int? ACCUMULATIONBODYDIRECTION { get; set; }
        /// <summary>
        /// 堆积体坡面形态
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIONBODYFLATSHAPE")]
        public string ACCUMULATIONBODYFLATSHAPE { get; set; }
        /// <summary>
        /// 堆积体稳定性
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIONBODYSTABILITY")]
        public string ACCUMULATIONBODYSTABILITY { get; set; }
        /// <summary>
        /// 堆积体可能失稳因素
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIONBODYASTABLEFACTOR")]
        public string ACCUMULATIONBODYASTABLEFACTOR { get; set; }
        /// <summary>
        /// 堆积体目前稳定状态
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIONBODYSTABLESTATUS")]
        public string ACCUMULATIONBODYSTABLESTATUS { get; set; }
        /// <summary>
        /// 堆积体今后变化趋势
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIONBODYSTABLETREND")]
        public string ACCUMULATIONBODYSTABLETREND { get; set; }
        /// <summary>
        /// 隐患点
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENDANGER")]
        public string HIDDENDANGER { get; set; }
        /// <summary>
        /// 防灾预案
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONPLAN")]
        public string PREVENTIONPLAN { get; set; }
        /// <summary>
        /// 死亡人口
        /// </summary>
        /// <returns></returns>
        [Column("DEATHSPEOPLE")]
        public int? DEATHSPEOPLE { get; set; }
        /// <summary>
        /// 毁坏房屋
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOME")]
        public int? DESTROYEDHOME { get; set; }
        /// <summary>
        /// 毁路
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDROAD")]
        public decimal? DESTROYEDROAD { get; set; }
        /// <summary>
        /// 毁渠
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDCHANNEL")]
        public decimal? DESTROYEDCHANNEL { get; set; }
        /// <summary>
        /// 其它危害
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDOTHERS")]
        public string DESTROYEDOTHERS { get; set; }
        /// <summary>
        /// 直接损失
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTLOSS")]
        public decimal? DIRECTLOSS { get; set; }
        /// <summary>
        /// 灾情等级
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERLEVEL")]
        public string DISASTERLEVEL { get; set; }
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
        /// 监测建议
        /// </summary>
        /// <returns></returns>
        [Column("MONITORSUGGESTION")]
        public string MONITORSUGGESTION { get; set; }
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
        /// 调查单位
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYDEPT")]
        public string SURVEYDEPT { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENSTIME")]
        public string HAPPENSTIME { get; set; }
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
        /// 崩塌情况
        /// </summary>
        /// <returns></returns>
        [Column("AVALANCHEDESC")]
        public string AVALANCHEDESC { get; set; }
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
        /// 分布高程（米）
        /// </summary>
        /// <returns></returns>
        [Column("DISTRIBUTEALTITUDE")]
        public decimal? DISTRIBUTEALTITUDE { get; set; }
        /// <summary>
        /// 厚度(米)
        /// </summary>
        /// <returns></returns>
        [Column("DEPTH")]
        public decimal? DEPTH { get; set; }
        /// <summary>
        /// 变形发育史形成时间
        /// </summary>
        /// <returns></returns>
        [Column("DISTORTIONFORMDATE")]
        public string DISTORTIONFORMDATE { get; set; }
        /// <summary>
        /// 发生崩塌次数
        /// </summary>
        /// <returns></returns>
        [Column("AVALANCHETIMES")]
        public short? AVALANCHETIMES { get; set; }
        /// <summary>
        /// 变形发育史序号1
        /// </summary>
        /// <returns></returns>
        [Column("AVALANCHENO1")]
        public string AVALANCHENO1 { get; set; }
        /// <summary>
        /// 发生时间1
        /// </summary>
        /// <returns></returns>
        [Column("OCCURREDTIME1")]
        public DateTime? OCCURREDTIME1 { get; set; }
        /// <summary>
        /// 崩塌规模1（立方米）
        /// </summary>
        /// <returns></returns>
        [Column("OCCURREDVOLUME1")]
        public decimal? OCCURREDVOLUME1 { get; set; }
        /// <summary>
        /// 崩塌诱发因素1
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDFACTOR1")]
        public string INDUCEDFACTOR1 { get; set; }
        /// <summary>
        /// 死亡人数1
        /// </summary>
        /// <returns></returns>
        [Column("DEATHPEOPLE1")]
        public int? DEATHPEOPLE1 { get; set; }
        /// <summary>
        /// 崩塌直接经济损失1
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTLOSS1")]
        public decimal? DIRECTLOSS1 { get; set; }
        /// <summary>
        /// 变形发育史序号2
        /// </summary>
        /// <returns></returns>
        [Column("AVALANCHENO2")]
        public string AVALANCHENO2 { get; set; }
        /// <summary>
        /// 发生时间2
        /// </summary>
        /// <returns></returns>
        [Column("OCCURREDTIME2")]
        public DateTime? OCCURREDTIME2 { get; set; }
        /// <summary>
        /// 崩塌规模2（立方米）
        /// </summary>
        /// <returns></returns>
        [Column("OCCURREDVOLUME2")]
        public decimal? OCCURREDVOLUME2 { get; set; }
        /// <summary>
        /// 崩塌诱发因素2
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDFACTOR2")]
        public string INDUCEDFACTOR2 { get; set; }
        /// <summary>
        /// 死亡人数2
        /// </summary>
        /// <returns></returns>
        [Column("DEATHPEOPLE2")]
        public int? DEATHPEOPLE2 { get; set; }
        /// <summary>
        /// 崩塌直接经济损失2
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTLOSS2")]
        public decimal? DIRECTLOSS2 { get; set; }
        /// <summary>
        /// 变形发育史序号3
        /// </summary>
        /// <returns></returns>
        [Column("AVALANCHENO3")]
        public string AVALANCHENO3 { get; set; }
        /// <summary>
        /// 发生时间3
        /// </summary>
        /// <returns></returns>
        [Column("OCCURREDTIME3")]
        public DateTime? OCCURREDTIME3 { get; set; }
        /// <summary>
        /// 崩塌规模3（立方米）
        /// </summary>
        /// <returns></returns>
        [Column("OCCURREDVOLUME3")]
        public decimal? OCCURREDVOLUME3 { get; set; }
        /// <summary>
        /// 崩塌诱发因素3
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDFACTOR3")]
        public string INDUCEDFACTOR3 { get; set; }
        /// <summary>
        /// 死亡人数3
        /// </summary>
        /// <returns></returns>
        [Column("DEATHPEOPLE3")]
        public int? DEATHPEOPLE3 { get; set; }
        /// <summary>
        /// 崩塌直接经济损失3
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTLOSS3")]
        public decimal? DIRECTLOSS3 { get; set; }
        /// <summary>
        /// 损坏房屋（间）
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOUSE")]
        public int? DESTROYEDHOUSE { get; set; }
        /// <summary>
        /// 威胁房屋（户）
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOME")]
        public int? THREATENHOME { get; set; }
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
        /// 群策群防
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
        /// 斜坡类型
        /// </summary>
        /// <returns></returns>
        [Column("SLOPETYPE")]
        public string SLOPETYPE { get; set; }
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
        /// 群测人员ID
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
        /// 调查单位ID
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYDEPTID")]
        public string SURVEYDEPTID { get; set; }
        /// <summary>
        /// CTRLSURFLENGTH2
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFLENGTH2")]
        public decimal? CTRLSURFLENGTH2 { get; set; }
        /// <summary>
        /// 坡形
        /// </summary>
        /// <returns></returns>
        [Column("SLOPESHAPE")]
        public string SLOPESHAPE { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// 地理位置老数据
        /// </summary>
        /// <returns></returns>
        [Column("LOCATIONOLD")]
        public string LOCATIONOLD { get; set; }
        /// <summary>
        /// 灾害规模等级
        /// </summary>
        /// <returns></returns>
        [Column("SCALELEVELS")]
        public string SCALELEVELS { get; set; }
        /// <summary>
        /// 填表日期
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEDATE")]
        public DateTime? FILLTABLEDATE { get; set; }
        /// <summary>
        /// 变形形成时间
        /// </summary>
        /// <returns></returns>
        [Column("CHANGEDATE")]
        public DateTime? CHANGEDATE { get; set; }
        /// <summary>
        /// 发生崩塌次数（次）
        /// </summary>
        /// <returns></returns>
        [Column("AVALANCETIMES")]
        public decimal? AVALANCETIMES { get; set; }
        /// <summary>
        /// 变形发育序号
        /// </summary>
        /// <returns></returns>
        [Column("CHANGENUMBER")]
        public decimal? CHANGENUMBER { get; set; }
        /// <summary>
        /// 变形发生时间
        /// </summary>
        /// <returns></returns>
        [Column("OCCUREDATE")]
        public DateTime? OCCUREDATE { get; set; }
        /// <summary>
        /// 变形规模（m3）
        /// </summary>
        /// <returns></returns>
        [Column("CHANGELEVEL")]
        public decimal? CHANGELEVEL { get; set; }
        /// <summary>
        /// 诱发因素
        /// </summary>
        /// <returns></returns>
        [Column("INDUCINGFACTOR")]
        public string INDUCINGFACTOR { get; set; }
        /// <summary>
        /// 失稳概率
        /// </summary>
        /// <returns></returns>
        [Column("REINDUCEDPRECENT")]
        public string REINDUCEDPRECENT { get; set; }
        /// <summary>
        /// 崩塌速度
        /// </summary>
        /// <returns></returns>
        [Column("AVALANCHESPEED")]
        public string AVALANCHESPEED { get; set; }
        /// <summary>
        /// 最大崩塌距离（m）
        /// </summary>
        /// <returns></returns>
        [Column("MAXAVALANCHEDISTANCE")]
        public decimal? MAXAVALANCHEDISTANCE { get; set; }
        /// <summary>
        /// 最大可能崩塌距离（m）
        /// </summary>
        /// <returns></returns>
        [Column("MAXCHANGEDISTANCE")]
        public decimal? MAXCHANGEDISTANCE { get; set; }
        /// <summary>
        /// 承灾体类型
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERBEARINGTYPE")]
        public string DISASTERBEARINGTYPE { get; set; }
        /// <summary>
        /// 房屋数量
        /// </summary>
        /// <returns></returns>
        [Column("HOUSENUMBER")]
        public int? HOUSENUMBER { get; set; }
        /// <summary>
        /// 房屋经济价值
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEMONEY")]
        public decimal? HOUSEMONEY { get; set; }
        /// <summary>
        /// 房屋易损性
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEDESTORY")]
        public string HOUSEDESTORY { get; set; }
        /// <summary>
        /// 道路易损性
        /// </summary>
        /// <returns></returns>
        [Column("LOADDESTORY")]
        public string LOADDESTORY { get; set; }
        /// <summary>
        /// 水渠易损性
        /// </summary>
        /// <returns></returns>
        [Column("WATERDESTORY")]
        public string WATERDESTORY { get; set; }
        /// <summary>
        /// 其他易损性
        /// </summary>
        /// <returns></returns>
        [Column("OTHERDESTORY")]
        public string OTHERDESTORY { get; set; }
        /// <summary>
        /// 道路数量
        /// </summary>
        /// <returns></returns>
        [Column("LOADNUMBER")]
        public int? LOADNUMBER { get; set; }
        /// <summary>
        /// 道路价值
        /// </summary>
        /// <returns></returns>
        [Column("LOADMONEY")]
        public decimal? LOADMONEY { get; set; }
        /// <summary>
        /// 水渠数量
        /// </summary>
        /// <returns></returns>
        [Column("WATERNUMBER")]
        public int? WATERNUMBER { get; set; }
        /// <summary>
        /// 水渠价值
        /// </summary>
        /// <returns></returns>
        [Column("WATERMONEY")]
        public decimal? WATERMONEY { get; set; }
        /// <summary>
        /// 其他数量
        /// </summary>
        /// <returns></returns>
        [Column("OTHERNUMBER")]
        public int? OTHERNUMBER { get; set; }
        /// <summary>
        /// 其他价值
        /// </summary>
        /// <returns></returns>
        [Column("OTHERMONEY")]
        public decimal? OTHERMONEY { get; set; }
        /// <summary>
        /// 人员数量
        /// </summary>
        /// <returns></returns>
        [Column("PEOPLENUMBER")]
        public int? PEOPLENUMBER { get; set; }
        /// <summary>
        /// 人员时空概率
        /// </summary>
        /// <returns></returns>
        [Column("PEOPLEPRECENT")]
        public decimal? PEOPLEPRECENT { get; set; }
        /// <summary>
        /// 人员经济价值（万元）
        /// </summary>
        /// <returns></returns>
        [Column("PEOPLEMONEY")]
        public decimal? PEOPLEMONEY { get; set; }
        /// <summary>
        /// 人员易损性
        /// </summary>
        /// <returns></returns>
        [Column("PEOLPEDESTORY")]
        public string PEOLPEDESTORY { get; set; }
        /// <summary>
        /// 交通工具数量
        /// </summary>
        /// <returns></returns>
        [Column("TOOLSNUMBER")]
        public int? TOOLSNUMBER { get; set; }
        /// <summary>
        /// 交通工具时空概率
        /// </summary>
        /// <returns></returns>
        [Column("TOOLSPRECENT")]
        public decimal? TOOLSPRECENT { get; set; }
        /// <summary>
        /// 交通工具经济价值（万元）
        /// </summary>
        /// <returns></returns>
        [Column("TOOLSMONEY")]
        public decimal? TOOLSMONEY { get; set; }
        /// <summary>
        /// 交通工具易损性
        /// </summary>
        /// <returns></returns>
        [Column("TOOLSDESTORY")]
        public string TOOLSDESTORY { get; set; }
        /// <summary>
        /// 牲畜数量
        /// </summary>
        /// <returns></returns>
        [Column("ANIMALNUMBER")]
        public int? ANIMALNUMBER { get; set; }
        /// <summary>
        /// 牲畜时空概率
        /// </summary>
        /// <returns></returns>
        [Column("ANIMALPRECENT")]
        public decimal? ANIMALPRECENT { get; set; }
        /// <summary>
        /// 牲畜经济价值（万元）
        /// </summary>
        /// <returns></returns>
        [Column("ANIMALMONEY")]
        public decimal? ANIMALMONEY { get; set; }
        /// <summary>
        /// 牲畜易损性
        /// </summary>
        /// <returns></returns>
        [Column("ANIMALDESTORY")]
        public string ANIMALDESTORY { get; set; }
        /// <summary>
        /// 其他流动承灾体数量
        /// </summary>
        /// <returns></returns>
        [Column("CHANGEOTHERNUMBER")]
        public int? CHANGEOTHERNUMBER { get; set; }
        /// <summary>
        /// 其他流动承灾体时空概率
        /// </summary>
        /// <returns></returns>
        [Column("CHANGEOTHERPRECENT")]
        public decimal? CHANGEOTHERPRECENT { get; set; }
        /// <summary>
        /// 其他流动承灾体经济价值（万元）
        /// </summary>
        /// <returns></returns>
        [Column("CHANGEOTHERMONEY")]
        public decimal? CHANGEOTHERMONEY { get; set; }
        /// <summary>
        /// 其他流动承灾体易损性
        /// </summary>
        /// <returns></returns>
        [Column("CHANGEOTHERDESTORY")]
        public string CHANGEOTHERDESTORY { get; set; }
        /// <summary>
        /// 应急排危险
        /// </summary>
        /// <returns></returns>
        [Column("YJPW")]
        public string YJPW { get; set; }
        /// <summary>
        /// 是否立警示牌
        /// </summary>
        /// <returns></returns>
        [Column("ISWARNING")]
        public string ISWARNING { get; set; }
        /// <summary>
        /// 群测群防点（0：否；1：是）
        /// </summary>
        /// <returns></returns>
        [Column("ISQCQF")]
        public string ISQCQF { get; set; }
        /// <summary>
        /// 危害评估
        /// </summary>
        /// <returns></returns>
        [Column("HAZARDASSESSMENT")]
        public string HAZARDASSESSMENT { get; set; }
        /// <summary>
        /// 承灾体结构类型
        /// </summary>
        /// <returns></returns>
        [Column("HAZARDSTRUCTURETYPE")]
        public string HAZARDSTRUCTURETYPE { get; set; }
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