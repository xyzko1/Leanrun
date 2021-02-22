using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;
 
namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-05 09:47
    /// 描 述：滑坡隐患点调查历史表
    /// </summary>
    public class TBL_LANDSLIP_HIDDEN_HISTORYEntity : BaseEntity
    {
        #region 实体成员
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
        /// 审计状态（1：待审计；2：审计通过；3：审计不通过；4：撤销；5：跳过验证）
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
        /// 核销类型（1-治理工程，2-搬迁避让，3-人工核定）
        /// </summary>
        /// <returns></returns>
        [Column("VERIFICATION")]
        public string VERIFICATION { get; set; }
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
        /// 滑坡类型
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPTYPE")]
        public string LANDSLIPTYPE { get; set; }
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
        /// 滑坡剖面形态
        /// </summary>
        /// <returns></returns>
        [Column("LANDSLIPSECTIONSHAPE")]
        public string LANDSLIPSECTIONSHAPE { get; set; }
        /// <summary>
        /// 预测规模等级
        /// </summary>
        /// <returns></returns>
        [Column("SCALELEVEL")]
        public string SCALELEVEL { get; set; }
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
        /// 可能失稳概率
        /// </summary>
        /// <returns></returns>
        [Column("REINDUCEDPRECENT")]
        public string REINDUCEDPRECENT { get; set; }
        /// <summary>
        /// 推测运动特性
        /// </summary>
        /// <returns></returns>
        [Column("MOTIONCHARATERISTISCS")]
        public string MOTIONCHARATERISTISCS { get; set; }
        /// <summary>
        /// 最大滑移距离（m）
        /// </summary>
        /// <returns></returns>
        [Column("MAXSLPOELENGTH")]
        public int? MAXSLPOELENGTH { get; set; }
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
        /// 危害等级
        /// </summary>
        /// <returns></returns>
        [Column("DANGERLEVEL")]
        public string DANGERLEVEL { get; set; }
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
        /// 危害评估
        /// </summary>
        /// <returns></returns>
        [Column("HAZARDASSESSMENT")]
        public string HAZARDASSESSMENT { get; set; }
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
        /// 应急排危险
        /// </summary>
        /// <returns></returns>
        [Column("YJPW")]
        public string YJPW { get; set; }
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
        /// 更新人(最近)
        /// </summary>
        /// <returns></returns>
        [Column("UPDATEUSER")]
        public string UPDATEUSER { get; set; }
        /// <summary>
        /// "   填表人ID   "
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEPEOPLEID")]
        public string FILLTABLEPEOPLEID { get; set; }
        /// <summary>
        /// "   审核人ID   "
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
        /// 地理位置老数据
        /// </summary>
        /// <returns></returns>
        [Column("LOCATIONOLD")]
        public string LOCATIONOLD { get; set; }
        /// <summary>
        /// 斜坡类型
        /// </summary>
        /// <returns></returns>
        [Column("SLOPETYPE")]
        public string SLOPETYPE { get; set; }
        /// <summary>
        /// 岩体结构类型
        /// </summary>
        /// <returns></returns>
        [Column("ROCKSTRUCTURETYPETYPE")]
        public string ROCKSTRUCTURETYPETYPE { get; set; }
        /// <summary>
        /// 岩体结构厚度
        /// </summary>
        /// <returns></returns>
        [Column("ROCKSTRUCTURETHICKNESS")]
        public int? ROCKSTRUCTURETHICKNESS { get; set; }
        /// <summary>
        /// 裂隙组数
        /// </summary>
        /// <returns></returns>
        [Column("CRACKNUMBER")]
        public int? CRACKNUMBER { get; set; }
        /// <summary>
        /// 岩体结构块度（m3）
        /// </summary>
        /// <returns></returns>
        [Column("ROCKFRACTION")]
        public int? ROCKFRACTION { get; set; }
        /// <summary>
        /// 控制面结构类型
        /// </summary>
        /// <returns></returns>
        [Column("CONTROLSURFACETYPE")]
        public string CONTROLSURFACETYPE { get; set; }
        /// <summary>
        /// 产状1
        /// </summary>
        /// <returns></returns>
        [Column("OCCURRENCE1")]
        public string OCCURRENCE1 { get; set; }
        /// <summary>
        /// 产状2
        /// </summary>
        /// <returns></returns>
        [Column("OCCURRENCE2")]
        public string OCCURRENCE2 { get; set; }
        /// <summary>
        /// 产状3
        /// </summary>
        /// <returns></returns>
        [Column("OCCURRENCE3")]
        public string OCCURRENCE3 { get; set; }
        /// <summary>
        /// 长度1
        /// </summary>
        /// <returns></returns>
        [Column("LONG1")]
        public int? LONG1 { get; set; }
        /// <summary>
        /// 长度2
        /// </summary>
        /// <returns></returns>
        [Column("LONG2")]
        public int? LONG2 { get; set; }
        /// <summary>
        /// 长度3
        /// </summary>
        /// <returns></returns>
        [Column("LONG3")]
        public int? LONG3 { get; set; }
        /// <summary>
        /// 间距1
        /// </summary>
        /// <returns></returns>
        [Column("SPACING1")]
        public int? SPACING1 { get; set; }
        /// <summary>
        /// 间距2
        /// </summary>
        /// <returns></returns>
        [Column("SPACING2")]
        public int? SPACING2 { get; set; }
        /// <summary>
        /// 间距3
        /// </summary>
        /// <returns></returns>
        [Column("SPACING3")]
        public int? SPACING3 { get; set; }
        /// <summary>
        /// 全风化带深度（m）
        /// </summary>
        /// <returns></returns>
        [Column("WINDDEPTH1")]
        public int? WINDDEPTH1 { get; set; }
        /// <summary>
        /// 卸荷裂缝深度（m）
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTH1")]
        public int? CRACKDEPTH1 { get; set; }
        /// <summary>
        /// 全风化带深度（m）
        /// </summary>
        /// <returns></returns>
        [Column("WINDDEPTH2")]
        public int? WINDDEPTH2 { get; set; }
        /// <summary>
        /// 全风化带深度（m）
        /// </summary>
        /// <returns></returns>
        [Column("WINDDEPTH3")]
        public int? WINDDEPTH3 { get; set; }
        /// <summary>
        /// 卸荷裂缝深度（m）
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTH2")]
        public int? CRACKDEPTH2 { get; set; }
        /// <summary>
        /// 卸荷裂缝深度（m）
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTH3")]
        public int? CRACKDEPTH3 { get; set; }
        /// <summary>
        /// 土质名称
        /// </summary>
        /// <returns></returns>
        [Column("SOILNAME")]
        public string SOILNAME { get; set; }
        /// <summary>
        /// 土质密实度
        /// </summary>
        /// <returns></returns>
        [Column("SOILTYPE")]
        public string SOILTYPE { get; set; }
        /// <summary>
        /// 土质稠度
        /// </summary>
        /// <returns></returns>
        [Column("SOILCONSISTENCY")]
        public string SOILCONSISTENCY { get; set; }
        /// <summary>
        /// 下伏岩性
        /// </summary>
        /// <returns></returns>
        [Column("UNDERLYINGCRACK")]
        public string UNDERLYINGCRACK { get; set; }
        /// <summary>
        /// 下伏时代
        /// </summary>
        /// <returns></returns>
        [Column("UNDERLYINGTIMES")]
        public string UNDERLYINGTIMES { get; set; }
        /// <summary>
        /// 下伏产状
        /// </summary>
        /// <returns></returns>
        [Column("UNDERLYINGOCCURRENCE")]
        public string UNDERLYINGOCCURRENCE { get; set; }
        /// <summary>
        /// 下伏埋深（m）
        /// </summary>
        /// <returns></returns>
        [Column("UNDERLYINGDEPTH")]
        public int? UNDERLYINGDEPTH { get; set; }
        /// <summary>
        /// 最大可能滑移距离（m）
        /// </summary>
        /// <returns></returns>
        [Column("MAXCHANGELENGTH")]
        public int? MAXCHANGELENGTH { get; set; }
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
        /// 群测群防点（0：否；1：是）
        /// </summary>
        /// <returns></returns>
        [Column("ISQCQF")]
        public string ISQCQF { get; set; }
        /// <summary>
        /// 是否立警示牌
        /// </summary>
        /// <returns></returns>
        [Column("ISWARNING")]
        public string ISWARNING { get; set; }
        /// <summary>
        /// 承灾体结构类型
        /// </summary>
        /// <returns></returns>
        [Column("HAZARDSTRUCTURETYPE")]
        public string HAZARDSTRUCTURETYPE { get; set; }
        /// <summary>
        /// 可能失稳因素
        /// </summary>
        /// <returns></returns>
        [Column("REINDUCEDFACTOR")]
        public string REINDUCEDFACTOR { get; set; }
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
