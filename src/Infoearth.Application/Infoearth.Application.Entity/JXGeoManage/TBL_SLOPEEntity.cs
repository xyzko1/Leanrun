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
    /// 描 述：斜坡调查表
    /// </summary>
    public class TBL_SLOPEEntity : BaseEntity
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
        /// 纬度
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        public string LATITUDE { get; set; }
        /// <summary>
        /// 经度
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
        /// 坡顶
        /// </summary>
        /// <returns></returns>
        [Column("ALTTOP")]
        public decimal? ALTTOP { get; set; }
        /// <summary>
        /// 坡底
        /// </summary>
        /// <returns></returns>
        [Column("ALTBOTOM")]
        public decimal? ALTBOTOM { get; set; }
        /// <summary>
        /// 斜坡类型
        /// </summary>
        /// <returns></returns>
        [Column("SLOPETYPE")]
        public string SLOPETYPE { get; set; }
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
        /// 年降雨量
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
        /// 丰水位
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
        /// 土地使用
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
        /// 坡形
        /// </summary>
        /// <returns></returns>
        [Column("SLOPESHAPE")]
        public string SLOPESHAPE { get; set; }
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
        public short? FRACTUREGROUPNUM { get; set; }
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
        /// 控制面结构类型1
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFTYPE1")]
        public string CTRLSURFTYPE1 { get; set; }
        /// <summary>
        /// 控制面结构倾向1
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFDIRECTION1")]
        public int? CTRLSURFDIRECTION1 { get; set; }
        /// <summary>
        /// 控制面结构倾角1
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFANGLE1")]
        public int? CTRLSURFANGLE1 { get; set; }
        /// <summary>
        /// 控制面结构长度1(M)
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFLENGTH1")]
        public decimal? CTRLSURFLENGTH1 { get; set; }
        /// <summary>
        /// 控制面结构间距1(M)
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFSPACE1")]
        public decimal? CTRLSURFSPACE1 { get; set; }
        /// <summary>
        /// 控制面结构类型2
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFTYPE2")]
        public string CTRLSURFTYPE2 { get; set; }
        /// <summary>
        /// 控制面结构倾向2
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFDIRECTION2")]
        public int? CTRLSURFDIRECTION2 { get; set; }
        /// <summary>
        /// 控制面结构倾角2
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFANGLE2")]
        public int? CTRLSURFANGLE2 { get; set; }
        /// <summary>
        /// 控制面结构长度2(M)
        /// </summary>
        /// <returns></returns>
        [Column("COCTRLSURFLENGTH2")]
        public decimal? COCTRLSURFLENGTH2 { get; set; }
        /// <summary>
        /// 控制面结构间距(2)
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFSPACE2")]
        public decimal? CTRLSURFSPACE2 { get; set; }
        /// <summary>
        /// 控制面结构类型3
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFTYPE3")]
        public string CTRLSURFTYPE3 { get; set; }
        /// <summary>
        /// 控制面结构倾向3
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFDIRECTION3")]
        public int? CTRLSURFDIRECTION3 { get; set; }
        /// <summary>
        /// 控制面结构倾角3
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFANGLE3")]
        public int? CTRLSURFANGLE3 { get; set; }
        /// <summary>
        /// 控制面结构长度3
        /// </summary>
        /// <returns></returns>
        [Column("CTRLSURFLENGTH3")]
        public decimal? CTRLSURFLENGTH3 { get; set; }
        /// <summary>
        /// 控制面结构间距3
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
        /// 土体密实度
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
        public int? BEDROCKANGLE { get; set; }
        /// <summary>
        /// 下伏基岩倾向
        /// </summary>
        /// <returns></returns>
        [Column("BEDROCKDIRECTION")]
        public int? BEDROCKDIRECTION { get; set; }
        /// <summary>
        /// 下伏基岩埋深(M)
        /// </summary>
        /// <returns></returns>
        [Column("BEDROCKDEPTH")]
        public decimal? BEDROCKDEPTH { get; set; }
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
        /// 可能失稳因素
        /// </summary>
        /// <returns></returns>
        [Column("ASTABLEFACTOR")]
        public string ASTABLEFACTOR { get; set; }
        /// <summary>
        /// 目前稳定程度
        /// </summary>
        /// <returns></returns>
        [Column("CURRENTSTABLESTATUS")]
        public string CURRENTSTABLESTATUS { get; set; }
        /// <summary>
        /// 今后变化趋势
        /// </summary>
        /// <returns></returns>
        [Column("STABLETREND")]
        public string STABLETREND { get; set; }
        /// <summary>
        /// 毁坏房屋(户)
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOME")]
        public int? DESTROYEDHOME { get; set; }
        /// <summary>
        /// 毁路(M)
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDROAD")]
        public decimal? DESTROYEDROAD { get; set; }
        /// <summary>
        /// 毁渠(M)
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDCANAL")]
        public decimal? DESTROYEDCANAL { get; set; }
        /// <summary>
        /// 其它危害
        /// </summary>
        /// <returns></returns>
        [Column("OTHERHARM")]
        public string OTHERHARM { get; set; }
        /// <summary>
        /// 直接损失(万元)
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
        [Column("SLOPEMONITORSUGGESTION")]
        public string SLOPEMONITORSUGGESTION { get; set; }
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
        /// 防灾预案
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONPLAN")]
        public string PREVENTIONPLAN { get; set; }
        /// <summary>
        /// 隐患点
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENDANGER")]
        public string HIDDENDANGER { get; set; }
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
        /// 调查单位ID
        /// </summary>
        /// <returns></returns>
        [Column("CONTACTDEPTID")]
        public string CONTACTDEPTID { get; set; }
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
        /// 更新时间
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
        /// 损坏房屋(间)
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOUSE")]
        public int? DESTROYEDHOUSE { get; set; }
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
        /// 斜坡变形趋势
        /// </summary>
        /// <returns></returns>
        [Column("SLOPEDISTORTIONTREND")]
        public string SLOPEDISTORTIONTREND { get; set; }
        /// <summary>
        /// 预测体积
        /// </summary>
        /// <returns></returns>
        [Column("PREDICTIVEVOLUME")]
        public decimal? PREDICTIVEVOLUME { get; set; }
        /// <summary>
        /// 预测规模等级
        /// </summary>
        /// <returns></returns>
        [Column("PREDICTIVESCALELEVEL")]
        public string PREDICTIVESCALELEVEL { get; set; }
        /// <summary>
        /// 斜坡厚度
        /// </summary>
        /// <returns></returns>
        [Column("SLOPEDEPTH")]
        public decimal? SLOPEDEPTH { get; set; }
        /// <summary>
        /// 威胁对象
        /// </summary>
        /// <returns></returns>
        [Column("THREATENOBJECT")]
        public string THREATENOBJECT { get; set; }
        /// <summary>
        /// 威胁房屋（户）
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOME")]
        public int? THREATENHOME { get; set; }
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
        /// 调查单位
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYDEPT")]
        public string SURVEYDEPT { get; set; }
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
        /// 死亡人口
        /// </summary>
        /// <returns></returns>
        [Column("DEATHSPEOPLE")]
        public int? DEATHSPEOPLE { get; set; }
       
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 灾害规模等级
        /// </summary>
        [Column("SCALELEVEL")]
        public string SCALELEVEL { get; set; }
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
