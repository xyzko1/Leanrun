using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 11:39
    /// 描 述：地裂缝调查表历史表
    /// </summary>
    public class TBL_LANDCRACK_HISTORYEntity : BaseEntity
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
        /// 市(县)
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
        /// 村组
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        public string LOCATION { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        public string LONGITUDE { get; set; }
        /// <summary>
        /// 纬度
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
        /// 单缝体缝号1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNUM1")]
        public decimal? ONECRACKNUM1 { get; set; }
        /// <summary>
        /// 单缝体形态1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFORM1")]
        public string ONECRACKFORM1 { get; set; }
        /// <summary>
        /// 单缝体延伸方向1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDIRE1")]
        public string ONECRACKDIRE1 { get; set; }
        /// <summary>
        /// 单缝体倾向1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKTENDENCY1")]
        public int? ONECRACKTENDENCY1 { get; set; }
        /// <summary>
        /// 单缝体倾角1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKANGLE1")]
        public int? ONECRACKANGLE1 { get; set; }
        /// <summary>
        /// 单缝体长度（米）1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKLENGTH1")]
        public string ONECRACKLENGTH1 { get; set; }
        /// <summary>
        /// 单缝体宽度（米）1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKWIDTH1")]
        public string ONECRACKWIDTH1 { get; set; }
        /// <summary>
        /// 单缝体深度（米）1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDEPTH1")]
        public string ONECRACKDEPTH1 { get; set; }
        /// <summary>
        /// 单缝体规模等级1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKSCALELEVEL1")]
        public string ONECRACKSCALELEVEL1 { get; set; }
        /// <summary>
        /// 单缝体性质1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNATURE1")]
        public string ONECRACKNATURE1 { get; set; }
        /// <summary>
        /// 单缝体位移方向1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDISPDIRE1")]
        public string ONECRACKDISPDIRE1 { get; set; }
        /// <summary>
        /// 单缝体位移距离1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDISPDIST1")]
        public string ONECRACKDISPDIST1 { get; set; }
        /// <summary>
        /// 单缝体填充物1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFILLER1")]
        public string ONECRACKFILLER1 { get; set; }
        /// <summary>
        /// 单缝体出现时间1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKAPPTIME1")]
        public string ONECRACKAPPTIME1 { get; set; }
        /// <summary>
        /// 单缝体活动性1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKACTIVITY1")]
        public string ONECRACKACTIVITY1 { get; set; }
        /// <summary>
        /// 单缝体缝号2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNUM2")]
        public decimal? ONECRACKNUM2 { get; set; }
        /// <summary>
        /// 单缝体形态2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFORM2")]
        public string ONECRACKFORM2 { get; set; }
        /// <summary>
        /// 单缝体延伸方向2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDIRE2")]
        public string ONECRACKDIRE2 { get; set; }
        /// <summary>
        /// 单缝体倾向2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKTENDENCY2")]
        public int? ONECRACKTENDENCY2 { get; set; }
        /// <summary>
        /// 单缝体倾角2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKANGLE2")]
        public int? ONECRACKANGLE2 { get; set; }
        /// <summary>
        /// 单缝体长度2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKLENGTH2")]
        public string ONECRACKLENGTH2 { get; set; }
        /// <summary>
        /// 单缝体宽度2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKWIDTH2")]
        public string ONECRACKWIDTH2 { get; set; }
        /// <summary>
        /// 单缝体深度2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDEPTH2")]
        public string ONECRACKDEPTH2 { get; set; }
        /// <summary>
        /// 单缝体规模2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKSCALELEVEL2")]
        public string ONECRACKSCALELEVEL2 { get; set; }
        /// <summary>
        /// 单缝体性质2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNATURE2")]
        public string ONECRACKNATURE2 { get; set; }
        /// <summary>
        /// 单缝体位移方向2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDISPDIRE2")]
        public string ONECRACKDISPDIRE2 { get; set; }
        /// <summary>
        /// 单缝体位移距离2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDISPDIST2")]
        public string ONECRACKDISPDIST2 { get; set; }
        /// <summary>
        /// 单缝体填充物2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFILLER2")]
        public string ONECRACKFILLER2 { get; set; }
        /// <summary>
        /// 单缝体出现时间2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKAPPTIME2")]
        public string ONECRACKAPPTIME2 { get; set; }
        /// <summary>
        /// 单缝体活动性2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKACTIVITY2")]
        public string ONECRACKACTIVITY2 { get; set; }
        /// <summary>
        /// 单缝体缝号3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNUM3")]
        public decimal? ONECRACKNUM3 { get; set; }
        /// <summary>
        /// 单缝体形态3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFORM3")]
        public string ONECRACKFORM3 { get; set; }
        /// <summary>
        /// 单缝体延伸方向3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDIRE3")]
        public string ONECRACKDIRE3 { get; set; }
        /// <summary>
        /// 单缝体倾向3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKTENDENCY3")]
        public int? ONECRACKTENDENCY3 { get; set; }
        /// <summary>
        /// 单缝体倾角3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKANGLE3")]
        public int? ONECRACKANGLE3 { get; set; }
        /// <summary>
        /// 单缝体长度3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKLENGTH3")]
        public string ONECRACKLENGTH3 { get; set; }
        /// <summary>
        /// 单缝体宽度3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKWIDTH3")]
        public string ONECRACKWIDTH3 { get; set; }
        /// <summary>
        /// 单缝体深度3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDEPTH3")]
        public string ONECRACKDEPTH3 { get; set; }
        /// <summary>
        /// 单缝体规模3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKSCALELEVEL3")]
        public string ONECRACKSCALELEVEL3 { get; set; }
        /// <summary>
        /// 单缝体性质3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNATURE3")]
        public string ONECRACKNATURE3 { get; set; }
        /// <summary>
        /// 单缝体位移方向3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDISPDIRE3")]
        public string ONECRACKDISPDIRE3 { get; set; }
        /// <summary>
        /// 单缝体位移距离3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDISPDIST3")]
        public string ONECRACKDISPDIST3 { get; set; }
        /// <summary>
        /// 单缝体填充物3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFILLER3")]
        public string ONECRACKFILLER3 { get; set; }
        /// <summary>
        /// 单缝体出现时间3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKAPPTIME3")]
        public string ONECRACKAPPTIME3 { get; set; }
        /// <summary>
        /// 单缝体活动性3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKACTIVITY3")]
        public string ONECRACKACTIVITY3 { get; set; }
        /// <summary>
        /// 缝群缝数
        /// </summary>
        /// <returns></returns>
        [Column("GROUPCRACKNUM")]
        public short? GROUPCRACKNUM { get; set; }
        /// <summary>
        /// 缝群面积（平方米）
        /// </summary>
        /// <returns></returns>
        [Column("GROUPCRACKDISTRAREA")]
        public decimal? GROUPCRACKDISTRAREA { get; set; }
        /// <summary>
        /// 缝群间距（毫米）
        /// </summary>
        /// <returns></returns>
        [Column("GROUPCRACKDEVELOPSPA")]
        public decimal? GROUPCRACKDEVELOPSPA { get; set; }
        /// <summary>
        /// 群峰排列形式
        /// </summary>
        /// <returns></returns>
        [Column("GROUPCRACKARRFORM")]
        public string GROUPCRACKARRFORM { get; set; }
        /// <summary>
        /// 最大缝长（米）
        /// </summary>
        /// <returns></returns>
        [Column("CRACKLENGTHMAX")]
        public decimal? CRACKLENGTHMAX { get; set; }
        /// <summary>
        /// 最小缝长（米）
        /// </summary>
        /// <returns></returns>
        [Column("CRACKLENGTHMIN")]
        public decimal? CRACKLENGTHMIN { get; set; }
        /// <summary>
        /// 最大缝宽（米）
        /// </summary>
        /// <returns></returns>
        [Column("CRACKWIDTHMAX")]
        public decimal? CRACKWIDTHMAX { get; set; }
        /// <summary>
        /// 最小缝宽（米）
        /// </summary>
        /// <returns></returns>
        [Column("CRACKWIDTHMIN")]
        public decimal? CRACKWIDTHMIN { get; set; }
        /// <summary>
        /// 最大缝深（米）
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTHMAX")]
        public decimal? CRACKDEPTHMAX { get; set; }
        /// <summary>
        /// 最小缝深（米）
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTHMIN")]
        public decimal? CRACKDEPTHMIN { get; set; }
        /// <summary>
        /// 始发时间
        /// </summary>
        /// <returns></returns>
        [Column("STARTTIME")]
        public string STARTTIME { get; set; }
        /// <summary>
        /// 盛发起始时间
        /// </summary>
        /// <returns></returns>
        [Column("SFSTARTTIME")]
        public string SFSTARTTIME { get; set; }
        /// <summary>
        /// 盛发结束时间
        /// </summary>
        /// <returns></returns>
        [Column("SFENDTIME")]
        public string SFENDTIME { get; set; }
        /// <summary>
        /// 停止时间
        /// </summary>
        /// <returns></returns>
        [Column("ENDTIME")]
        public string ENDTIME { get; set; }
        /// <summary>
        /// 尚在发展
        /// </summary>
        /// <returns></returns>
        [Column("CURDEVELOPSITUATION")]
        public string CURDEVELOPSITUATION { get; set; }
        /// <summary>
        /// 规模等级
        /// </summary>
        /// <returns></returns>
        [Column("SCALELEVEL")]
        public string SCALELEVEL { get; set; }
        /// <summary>
        /// 成因类型
        /// </summary>
        /// <returns></returns>
        [Column("LANDCRACKGENETICTYPE")]
        public string LANDCRACKGENETICTYPE { get; set; }
        /// <summary>
        /// 裂缝去地貌特征
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREATOPFEA")]
        public string CRACKAREATOPFEA { get; set; }
        /// <summary>
        /// 裂缝与山脊、山坡、山脚或平原土坎的走向关系
        /// </summary>
        /// <returns></returns>
        [Column("CRACKTOPTRENDRELA")]
        public string CRACKTOPTRENDRELA { get; set; }
        /// <summary>
        /// 裂缝（受裂）巨岩土层时代
        /// </summary>
        /// <returns></returns>
        [Column("CRACKROCKSOILTIME")]
        public string CRACKROCKSOILTIME { get; set; }
        /// <summary>
        /// 裂缝（受裂）巨岩土层岩性
        /// </summary>
        /// <returns></returns>
        [Column("CRACKROCKSOILLITH")]
        public string CRACKROCKSOILLITH { get; set; }
        /// <summary>
        /// 受裂土层时间
        /// </summary>
        /// <returns></returns>
        [Column("SPLITSOILTIME")]
        public string SPLITSOILTIME { get; set; }
        /// <summary>
        /// 受裂土层土性
        /// </summary>
        /// <returns></returns>
        [Column("SPLITSOILNATURE")]
        public string SPLITSOILNATURE { get; set; }
        /// <summary>
        /// 下伏层时间
        /// </summary>
        /// <returns></returns>
        [Column("SPLITSOILUNDERLAYERTIME")]
        public string SPLITSOILUNDERLAYERTIME { get; set; }
        /// <summary>
        /// 下伏层岩性
        /// </summary>
        /// <returns></returns>
        [Column("SPLITSOILUNDERLAYERLITH")]
        public string SPLITSOILUNDERLAYERLITH { get; set; }
        /// <summary>
        /// 受裂岩土层时代
        /// </summary>
        /// <returns></returns>
        [Column("SPLITROCKSOILTIME")]
        public string SPLITROCKSOILTIME { get; set; }
        /// <summary>
        /// 受裂岩土层岩性
        /// </summary>
        /// <returns></returns>
        [Column("SPLITROCKSOILLITH")]
        public string SPLITROCKSOILLITH { get; set; }
        /// <summary>
        /// 胀缩土特征
        /// </summary>
        /// <returns></returns>
        [Column("EXPCONTSOILFEA")]
        public string EXPCONTSOILFEA { get; set; }
        /// <summary>
        /// 胀缩土膨胀性
        /// </summary>
        /// <returns></returns>
        [Column("EXPCONTSOILEXPANSION")]
        public string EXPCONTSOILEXPANSION { get; set; }
        /// <summary>
        /// 胀缩土含水量(%)
        /// </summary>
        /// <returns></returns>
        [Column("EXPCONTSOILMOICONT")]
        public decimal? EXPCONTSOILMOICONT { get; set; }
        /// <summary>
        /// 裂缝区构造断裂1组走向
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREASTRUFAULTTREND1")]
        public string CRACKAREASTRUFAULTTREND1 { get; set; }
        /// <summary>
        /// 裂缝区构造断裂1组倾向
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREASTRUFAULTDIRE1")]
        public int? CRACKAREASTRUFAULTDIRE1 { get; set; }
        /// <summary>
        /// 裂缝区构造断裂1组倾角
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREASTRUFAULTANGLE1")]
        public int? CRACKAREASTRUFAULTANGLE1 { get; set; }
        /// <summary>
        /// 裂缝区构造断裂2组走向
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREASTRUFAULTTREND2")]
        public string CRACKAREASTRUFAULTTREND2 { get; set; }
        /// <summary>
        /// 裂缝区构造断裂2组倾向
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREASTRUFAULTDIRE2")]
        public int? CRACKAREASTRUFAULTDIRE2 { get; set; }
        /// <summary>
        /// 裂缝区构造断裂2组倾角
        /// </summary>
        /// <returns></returns>
        [Column("CRACKAREASTRUFAULTANGLE2")]
        public int? CRACKAREASTRUFAULTANGLE2 { get; set; }
        /// <summary>
        /// 岩层中的主要断裂倾向
        /// </summary>
        /// <returns></returns>
        [Column("ROCKFRACDIRE")]
        public int? ROCKFRACDIRE { get; set; }
        /// <summary>
        /// 岩层中的主要断裂倾角
        /// </summary>
        /// <returns></returns>
        [Column("ROCKFRACANGLE")]
        public int? ROCKFRACANGLE { get; set; }
        /// <summary>
        /// 土层中有无新断裂
        /// </summary>
        /// <returns></returns>
        [Column("SOILNEWFRAC")]
        public string SOILNEWFRAC { get; set; }
        /// <summary>
        /// 土层中新断裂倾向
        /// </summary>
        /// <returns></returns>
        [Column("SOILNEWFRACDIRE")]
        public int? SOILNEWFRACDIRE { get; set; }
        /// <summary>
        /// 土层中新断裂倾角
        /// </summary>
        /// <returns></returns>
        [Column("SOILNEWFRACANGLE")]
        public int? SOILNEWFRACANGLE { get; set; }
        /// <summary>
        /// 主要构造断裂1组走向
        /// </summary>
        /// <returns></returns>
        [Column("MAINSTRUFRACTREND1")]
        public string MAINSTRUFRACTREND1 { get; set; }
        /// <summary>
        /// 主要构造断裂1组倾向
        /// </summary>
        /// <returns></returns>
        [Column("MAINSTRUFRACDIRE1")]
        public int? MAINSTRUFRACDIRE1 { get; set; }
        /// <summary>
        /// 主要构造断裂1组倾角
        /// </summary>
        /// <returns></returns>
        [Column("MAINSTRUFRACANGLE1")]
        public int? MAINSTRUFRACANGLE1 { get; set; }
        /// <summary>
        /// 主要构造断裂2组走向
        /// </summary>
        /// <returns></returns>
        [Column("MAINSTRUFRACTREND2")]
        public string MAINSTRUFRACTREND2 { get; set; }
        /// <summary>
        /// 主要构造断裂2组倾向
        /// </summary>
        /// <returns></returns>
        [Column("MAINSTRUFRACDIRE2")]
        public int? MAINSTRUFRACDIRE2 { get; set; }
        /// <summary>
        /// 主要构造断裂2组倾角
        /// </summary>
        /// <returns></returns>
        [Column("MAINSTRUFRACANGLE2")]
        public int? MAINSTRUFRACANGLE2 { get; set; }
        /// <summary>
        /// 有无新的构造断裂
        /// </summary>
        /// <returns></returns>
        [Column("EXPCONTSOILNEWFRAC")]
        public string EXPCONTSOILNEWFRAC { get; set; }
        /// <summary>
        /// 新的构造断裂倾向
        /// </summary>
        /// <returns></returns>
        [Column("EXPCONTSOILNEWFRACDIRE")]
        public int? EXPCONTSOILNEWFRACDIRE { get; set; }
        /// <summary>
        /// 新的构造断裂倾角
        /// </summary>
        /// <returns></returns>
        [Column("EXPCONTSOILNEWFRACANGLE")]
        public int? EXPCONTSOILNEWFRACANGLE { get; set; }
        /// <summary>
        /// 洞室埋深（米）
        /// </summary>
        /// <returns></returns>
        [Column("CAVEDEPTH")]
        public decimal? CAVEDEPTH { get; set; }
        /// <summary>
        /// 洞室规模
        /// </summary>
        /// <returns></returns>
        [Column("CAVESCALE")]
        public string CAVESCALE { get; set; }
        /// <summary>
        /// 洞室长（米）
        /// </summary>
        /// <returns></returns>
        [Column("CAVELENGTH")]
        public decimal? CAVELENGTH { get; set; }
        /// <summary>
        /// 洞室款（米）
        /// </summary>
        /// <returns></returns>
        [Column("CAVEWIDTH")]
        public decimal? CAVEWIDTH { get; set; }
        /// <summary>
        /// 洞室高（米）
        /// </summary>
        /// <returns></returns>
        [Column("CAVEHIGH")]
        public decimal? CAVEHIGH { get; set; }
        /// <summary>
        /// 与裂缝区位置关系
        /// </summary>
        /// <returns></returns>
        [Column("CAVECRACKSPACERELA")]
        public string CAVECRACKSPACERELA { get; set; }
        /// <summary>
        /// 开挖时间
        /// </summary>
        /// <returns></returns>
        [Column("CAVEEXCATIME")]
        public string CAVEEXCATIME { get; set; }
        /// <summary>
        /// 开挖方式
        /// </summary>
        /// <returns></returns>
        [Column("CAVEEXCAMANNER")]
        public string CAVEEXCAMANNER { get; set; }
        /// <summary>
        /// 开挖强度
        /// </summary>
        /// <returns></returns>
        [Column("CAVEEXCASTRENGTH")]
        public string CAVEEXCASTRENGTH { get; set; }
        /// <summary>
        /// 抽排地下水类型
        /// </summary>
        /// <returns></returns>
        [Column("DRAGROUNDWATERTYPE")]
        public string DRAGROUNDWATERTYPE { get; set; }
        /// <summary>
        /// 井深或坑道埋深(M)
        /// </summary>
        /// <returns></returns>
        [Column("DRAWELLDEPTH")]
        public decimal? DRAWELLDEPTH { get; set; }
        /// <summary>
        /// 水位水量
        /// </summary>
        /// <returns></returns>
        [Column("DRAWATLEVVOL")]
        public decimal? DRAWATLEVVOL { get; set; }
        /// <summary>
        /// 日出水量
        /// </summary>
        /// <returns></returns>
        [Column("DRADAYPUMPVOL")]
        public decimal? DRADAYPUMPVOL { get; set; }
        /// <summary>
        /// 抽排水起始时间
        /// </summary>
        /// <returns></returns>
        [Column("DRASTARTTIME")]
        public string DRASTARTTIME { get; set; }
        /// <summary>
        /// 抽排水结束时间
        /// </summary>
        /// <returns></returns>
        [Column("DRAENDTIME")]
        public string DRAENDTIME { get; set; }
        /// <summary>
        /// 抽排水是否仍在继续
        /// </summary>
        /// <returns></returns>
        [Column("DRASTATUS")]
        public string DRASTATUS { get; set; }
        /// <summary>
        /// 地震烈度
        /// </summary>
        /// <returns></returns>
        [Column("EARTHQUAKEINTENSITY")]
        public string EARTHQUAKEINTENSITY { get; set; }
        /// <summary>
        /// 地震发生时间
        /// </summary>
        /// <returns></returns>
        [Column("EARTHQUAKETIME")]
        public string EARTHQUAKETIME { get; set; }
        /// <summary>
        /// 活动断层的位置
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTSPACE")]
        public string ACTFAULTSPACE { get; set; }
        /// <summary>
        /// 活动断层倾向
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTDIRE")]
        public decimal? ACTFAULTDIRE { get; set; }
        /// <summary>
        /// 活动断层倾角
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTANGLE")]
        public decimal? ACTFAULTANGLE { get; set; }
        /// <summary>
        /// 活动断层长度
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTLENGTH")]
        public decimal? ACTFAULTLENGTH { get; set; }
        /// <summary>
        /// 活动断层性质
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTNATURE")]
        public string ACTFAULTNATURE { get; set; }
        /// <summary>
        /// 活动断层活动时间
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTTIME")]
        public string ACTFAULTTIME { get; set; }
        /// <summary>
        /// 活动断层活动速率
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTACTRATE")]
        public string ACTFAULTACTRATE { get; set; }
        /// <summary>
        /// 活动断层断距
        /// </summary>
        /// <returns></returns>
        [Column("ACTFAULTBREAKAWAY")]
        public string ACTFAULTBREAKAWAY { get; set; }
        /// <summary>
        /// 水理作用来源
        /// </summary>
        /// <returns></returns>
        [Column("WATROLEWATER")]
        public string WATROLEWATER { get; set; }
        /// <summary>
        /// 水理作用时间
        /// </summary>
        /// <returns></returns>
        [Column("WATROLETIME")]
        public string WATROLETIME { get; set; }
        /// <summary>
        /// 水理作用水质（PH)
        /// </summary>
        /// <returns></returns>
        [Column("WATROLEWATERQUA")]
        public string WATROLEWATERQUA { get; set; }
        /// <summary>
        /// 开挖卸荷作用
        /// </summary>
        /// <returns></returns>
        [Column("WATROLETYPE")]
        public string WATROLETYPE { get; set; }
        /// <summary>
        /// 开挖卸荷开挖时间
        /// </summary>
        /// <returns></returns>
        [Column("WATROLEEXCATIME")]
        public string WATROLEEXCATIME { get; set; }
        /// <summary>
        /// 开挖卸荷方式
        /// </summary>
        /// <returns></returns>
        [Column("WATROLEEXCAMANNER")]
        public string WATROLEEXCAMANNER { get; set; }
        /// <summary>
        /// 开挖卸荷深度
        /// </summary>
        /// <returns></returns>
        [Column("WATROLEEXCADEPTH")]
        public decimal? WATROLEEXCADEPTH { get; set; }
        /// <summary>
        /// 毁坏房屋(户)
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOME")]
        public int? DESTROYEDHOME { get; set; }
        /// <summary>
        /// 阻断交通（处）
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKINGTRAFFIC")]
        public int? BLOCKINGTRAFFIC { get; set; }
        /// <summary>
        /// 死亡人口（人）
        /// </summary>
        /// <returns></returns>
        [Column("DEATHNUM")]
        public int? DEATHNUM { get; set; }
        /// <summary>
        /// 直接损失（万元）
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
        /// 隐患点
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENPOINT")]
        public string HIDDENPOINT { get; set; }
        /// <summary>
        /// 潜在威胁房屋（户）
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOME")]
        public int? THREATENHOME { get; set; }
        /// <summary>
        /// 潜在威胁阻断交通（处）
        /// </summary>
        /// <returns></returns>
        [Column("TRAFFICHAZARDS")]
        public int? TRAFFICHAZARDS { get; set; }
        /// <summary>
        /// 潜在灾害威胁人口（人）
        /// </summary>
        /// <returns></returns>
        [Column("THREATENPEOPLE")]
        public int? THREATENPEOPLE { get; set; }
        /// <summary>
        /// 潜在灾害威胁财产（万元）
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
        /// 裂缝发展预测
        /// </summary>
        /// <returns></returns>
        [Column("DEVELOPFORECAST")]
        public string DEVELOPFORECAST { get; set; }
        /// <summary>
        /// 是否有防灾预案/群测群防点
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONPLAN")]
        public string PREVENTIONPLAN { get; set; }
        /// <summary>
        /// 防治措施
        /// </summary>
        /// <returns></returns>
        [Column("TREATMENTMEASURE")]
        public string TREATMENTMEASURE { get; set; }
        /// <summary>
        /// 防治建议
        /// </summary>
        /// <returns></returns>
        [Column("TREATMENTSUGGESTION")]
        public string TREATMENTSUGGESTION { get; set; }
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
        /// 抽排地下水与裂缝区的位置关系
        /// </summary>
        /// <returns></returns>
        [Column("DRAWATERSPACERELA")]
        public string DRAWATERSPACERELA { get; set; }
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
        /// 平行群缝倾向
        /// </summary>
        /// <returns></returns>
        [Column("PARADIR")]
        public int? PARADIR { get; set; }
        /// <summary>
        /// 平行群缝倾角
        /// </summary>
        /// <returns></returns>
        [Column("PARAANGLE")]
        public int? PARAANGLE { get; set; }
        /// <summary>
        /// 平行群缝阶步指向
        /// </summary>
        /// <returns></returns>
        [Column("PARASTEPFORWARD")]
        public string PARASTEPFORWARD { get; set; }
        /// <summary>
        /// 斜列群缝倾向
        /// </summary>
        /// <returns></returns>
        [Column("INCLINEDDIR")]
        public int? INCLINEDDIR { get; set; }
        /// <summary>
        /// 斜列群缝倾角
        /// </summary>
        /// <returns></returns>
        [Column("INCLINEDANGLE")]
        public int? INCLINEDANGLE { get; set; }
        /// <summary>
        /// 斜列群缝阶步指向
        /// </summary>
        /// <returns></returns>
        [Column("INCLINEDSTEPFORWARD")]
        public string INCLINEDSTEPFORWARD { get; set; }
        /// <summary>
        /// 环围群缝圆心位置经度
        /// </summary>
        /// <returns></returns>
        [Column("ARROUNDCIRCLEPOSITIONLONGITUDE")]
        public decimal? ARROUNDCIRCLEPOSITIONLONGITUDE { get; set; }
        /// <summary>
        /// 环围群缝圆心位置纬度
        /// </summary>
        /// <returns></returns>
        [Column("ARROUNDCIRCLEPOSITIONLATITUDE")]
        public decimal? ARROUNDCIRCLEPOSITIONLATITUDE { get; set; }
        /// <summary>
        /// 是否有断层活动
        /// </summary>
        /// <returns></returns>
        [Column("ISFRACTUREACTIVITY")]
        public string ISFRACTUREACTIVITY { get; set; }
        /// <summary>
        /// 阻断交通(小时)
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKTRAFFHOURS")]
        public short? BLOCKTRAFFHOURS { get; set; }
        /// <summary>
        /// 地裂缝引发动力因素
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDFACTORS")]
        public string INDUCEDFACTORS { get; set; }
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
        /// 危害对象
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDOBJECT")]
        public string DESTROYEDOBJECT { get; set; }
        /// <summary>
        /// 威胁对象
        /// </summary>
        /// <returns></returns>
        [Column("THREATENOBJECT")]
        public string THREATENOBJECT { get; set; }
        /// <summary>
        /// 潜在威胁房屋（间）
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOUSE")]
        public int? THREATENHOUSE { get; set; }
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
        /// 审计状态（0：待审计；1：审计通过；2：审计不通过）
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
        ///   调查负责人ID  
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYHEADERID")]
        public string SURVEYHEADERID { get; set; }
        /// <summary>
        ///   填表人ID  
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEPEOPLEID")]
        public string FILLTABLEPEOPLEID { get; set; }
        /// <summary>
        ///   审核人ID  
        /// </summary>
        /// <returns></returns>
        [Column("VERIFYPEOPLEID")]
        public string VERIFYPEOPLEID { get; set; }
        /// <summary>
        ///   调查单位ID  
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
        /// 标高
        /// </summary>
        [Column("ELEVATION")]
        public decimal? ELEVATION { get; set; }
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
        /// 其他作用引起的干湿变化
        /// </summary>
        /// <returns></returns>
        [Column("QTZYYQGSBH")]
        public string QTZYYQGSBH { get; set; }
        /// <summary>
        /// 杂乱无章
        /// </summary>
        /// <returns></returns>
        [Column("ZLWZ")]
        public string ZLWZ { get; set; }
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