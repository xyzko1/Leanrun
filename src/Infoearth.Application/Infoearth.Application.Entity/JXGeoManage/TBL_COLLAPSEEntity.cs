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
    /// 描 述：地面塌陷调查表
    /// </summary>
    public class TBL_COLLAPSEEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 统一编号
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// CGHMDB系统灾害体编码
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
        [Column("LONGITUDE")]
        public string LONGITUDE { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        public string LATITUDE { get; set; }
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
        /// Z
        /// </summary>
        /// <returns></returns>
        [Column("Z")]
        public decimal? Z { get; set; }
        /// <summary>
        /// 单体陷坑坑号1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCONUM1")]
        public string MONOCONUM1 { get; set; }
        /// <summary>
        /// 单体陷坑形状1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOSHAPE1")]
        public string MONOCOSHAPE1 { get; set; }
        /// <summary>
        /// 单体陷坑坑口规模1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOSCALE1")]
        public decimal? MONOCOSCALE1 { get; set; }
        /// <summary>
        /// 单体陷坑深度1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCODEPTH1")]
        public decimal? MONOCODEPTH1 { get; set; }
        /// <summary>
        /// 单体陷坑变形面积1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOAREA1")]
        public decimal? MONOCOAREA1 { get; set; }
        /// <summary>
        /// 单体陷坑规模等级1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOLEVEL1")]
        public string MONOCOLEVEL1 { get; set; }
        /// <summary>
        /// 单体陷坑长轴方向1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOAXISDIRE1")]
        public string MONOCOAXISDIRE1 { get; set; }
        /// <summary>
        /// 单体陷坑充水水位深1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOWATLEVDEPTH1")]
        public decimal? MONOCOWATLEVDEPTH1 { get; set; }
        /// <summary>
        /// 单体陷坑水位变动1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOWATLEVCHANGE1")]
        public decimal? MONOCOWATLEVCHANGE1 { get; set; }
        /// <summary>
        /// 单体陷坑发生时间1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOTIME1")]
        public string MONOCOTIME1 { get; set; }
        /// <summary>
        /// 单体陷坑发展变化1
        /// </summary>
        /// <returns></returns>
        [Column("MONOCODEVELOPCHANGE1")]
        public string MONOCODEVELOPCHANGE1 { get; set; }
        /// <summary>
        /// 单体陷坑坑号2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCONUM2")]
        public string MONOCONUM2 { get; set; }
        /// <summary>
        /// 单体陷坑形状2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOSHAPE2")]
        public string MONOCOSHAPE2 { get; set; }
        /// <summary>
        /// 单体陷坑坑口规模2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOSCALE2")]
        public decimal? MONOCOSCALE2 { get; set; }
        /// <summary>
        /// 单体陷坑深度2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCODEPTH2")]
        public decimal? MONOCODEPTH2 { get; set; }
        /// <summary>
        /// 单体陷坑变形面积2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOAREA2")]
        public decimal? MONOCOAREA2 { get; set; }
        /// <summary>
        /// 单体陷坑规模等级2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOLEVEL2")]
        public string MONOCOLEVEL2 { get; set; }
        /// <summary>
        /// 单体陷坑长轴方向2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOAXISDIRE2")]
        public string MONOCOAXISDIRE2 { get; set; }
        /// <summary>
        /// 单体陷坑充水水位深2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOWATLEVDEPTH2")]
        public decimal? MONOCOWATLEVDEPTH2 { get; set; }
        /// <summary>
        /// 单体陷坑水位变动2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOWATLEVCHANGE2")]
        public decimal? MONOCOWATLEVCHANGE2 { get; set; }
        /// <summary>
        /// 单体陷坑发生时间2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOTIME2")]
        public string MONOCOTIME2 { get; set; }
        /// <summary>
        /// 单体陷坑发展变化2
        /// </summary>
        /// <returns></returns>
        [Column("MONOCODEVELOPCHANGE2")]
        public string MONOCODEVELOPCHANGE2 { get; set; }
        /// <summary>
        /// 单体陷坑坑号3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCONUM3")]
        public string MONOCONUM3 { get; set; }
        /// <summary>
        /// 单体陷坑形状3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOSHAPE3")]
        public string MONOCOSHAPE3 { get; set; }
        /// <summary>
        /// 单体陷坑坑口规模3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOSCALE3")]
        public decimal? MONOCOSCALE3 { get; set; }
        /// <summary>
        /// 单体陷坑深度3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCODEPTH3")]
        public decimal? MONOCODEPTH3 { get; set; }
        /// <summary>
        /// 单体陷坑变形面积3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOAREA3")]
        public decimal? MONOCOAREA3 { get; set; }
        /// <summary>
        /// 单体陷坑规模等级3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOLEVEL3")]
        public string MONOCOLEVEL3 { get; set; }
        /// <summary>
        /// 单体陷坑长轴方向3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOAXISDIRE3")]
        public string MONOCOAXISDIRE3 { get; set; }
        /// <summary>
        /// 单体陷坑充水水位深3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOWATLEVDEPTH3")]
        public decimal? MONOCOWATLEVDEPTH3 { get; set; }
        /// <summary>
        /// 单体陷坑水位变动3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOWATLEVCHANGE3")]
        public decimal? MONOCOWATLEVCHANGE3 { get; set; }
        /// <summary>
        /// 单体陷坑发生时间3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCOTIME3")]
        public string MONOCOTIME3 { get; set; }
        /// <summary>
        /// 单体陷坑发展变化3
        /// </summary>
        /// <returns></returns>
        [Column("MONOCODEVELOPCHANGE3")]
        public string MONOCODEVELOPCHANGE3 { get; set; }
        /// <summary>
        /// 陷坑坑数
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSENUM")]
        public short? COLLAPSENUM { get; set; }
        /// <summary>
        /// 陷坑分布面积
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEDISTRAREA")]
        public string COLLAPSEDISTRAREA { get; set; }
        /// <summary>
        /// 排列形式
        /// </summary>
        /// <returns></returns>
        [Column("ARRFORM")]
        public string ARRFORM { get; set; }
        /// <summary>
        /// 长列方向
        /// </summary>
        /// <returns></returns>
        [Column("LONGLISTDIRE")]
        public string LONGLISTDIRE { get; set; }
        /// <summary>
        /// 最小陷坑口径
        /// </summary>
        /// <returns></returns>
        [Column("MINCOLLAPSECALIBER")]
        public decimal? MINCOLLAPSECALIBER { get; set; }
        /// <summary>
        /// 最大陷坑口径
        /// </summary>
        /// <returns></returns>
        [Column("MAXCOLLAPSECALIBER")]
        public decimal? MAXCOLLAPSECALIBER { get; set; }
        /// <summary>
        /// 最小陷坑深度
        /// </summary>
        /// <returns></returns>
        [Column("MINCOLLAPSEDEPTH")]
        public decimal? MINCOLLAPSEDEPTH { get; set; }
        /// <summary>
        /// 最大陷坑深度
        /// </summary>
        /// <returns></returns>
        [Column("MAXCOLLAPSEDEPTH")]
        public decimal? MAXCOLLAPSEDEPTH { get; set; }
        /// <summary>
        /// 始发时间
        /// </summary>
        /// <returns></returns>
        [Column("STARTTIME")]
        public string STARTTIME { get; set; }
        /// <summary>
        /// 盛发开始时间
        /// </summary>
        /// <returns></returns>
        [Column("SFSTARTTIME")]
        public string SFSTARTTIME { get; set; }
        /// <summary>
        /// 盛发截止时间
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
        [Column("DEVELOPING")]
        public string DEVELOPING { get; set; }
        /// <summary>
        /// 单缝缝号1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNUM1")]
        public string ONECRACKNUM1 { get; set; }
        /// <summary>
        /// 单缝形态1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFORM1")]
        public string ONECRACKFORM1 { get; set; }
        /// <summary>
        /// 单缝延伸方向1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDIRE1")]
        public string ONECRACKDIRE1 { get; set; }
        /// <summary>
        /// 单缝倾向1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKTENDENCY1")]
        public int? ONECRACKTENDENCY1 { get; set; }
        /// <summary>
        /// 单缝倾角1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKANGLE1")]
        public int? ONECRACKANGLE1 { get; set; }
        /// <summary>
        /// 单缝长度1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKLENGTH1")]
        public decimal? ONECRACKLENGTH1 { get; set; }
        /// <summary>
        /// 单缝宽度1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKWIDTH1")]
        public decimal? ONECRACKWIDTH1 { get; set; }
        /// <summary>
        /// 单缝深度1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDEPTH1")]
        public decimal? ONECRACKDEPTH1 { get; set; }
        /// <summary>
        /// 单缝性质1
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNATURE1")]
        public string ONECRACKNATURE1 { get; set; }
        /// <summary>
        /// 单缝缝号2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNUM2")]
        public string ONECRACKNUM2 { get; set; }
        /// <summary>
        /// 单缝形态2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFORM2")]
        public string ONECRACKFORM2 { get; set; }
        /// <summary>
        /// 单缝延伸方向2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDIRE2")]
        public string ONECRACKDIRE2 { get; set; }
        /// <summary>
        /// 单缝倾向2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKTENDENCY2")]
        public int? ONECRACKTENDENCY2 { get; set; }
        /// <summary>
        /// 单缝倾角2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKANGLE2")]
        public int? ONECRACKANGLE2 { get; set; }
        /// <summary>
        /// 单缝长度2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKLENGTH2")]
        public decimal? ONECRACKLENGTH2 { get; set; }
        /// <summary>
        /// 单缝宽度2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKWIDTH2")]
        public decimal? ONECRACKWIDTH2 { get; set; }
        /// <summary>
        /// 单缝深度2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDEPTH2")]
        public decimal? ONECRACKDEPTH2 { get; set; }
        /// <summary>
        /// 单缝性质2
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNATURE2")]
        public string ONECRACKNATURE2 { get; set; }
        /// <summary>
        /// 单缝缝号3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNUM3")]
        public string ONECRACKNUM3 { get; set; }
        /// <summary>
        /// 单缝形态3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKFORM3")]
        public string ONECRACKFORM3 { get; set; }
        /// <summary>
        /// 单缝延伸方向3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDIRE3")]
        public string ONECRACKDIRE3 { get; set; }
        /// <summary>
        /// 单缝倾向3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKTENDENCY3")]
        public int? ONECRACKTENDENCY3 { get; set; }
        /// <summary>
        /// 单缝倾角3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKANGLE3")]
        public int? ONECRACKANGLE3 { get; set; }
        /// <summary>
        /// 单缝长度3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKLENGTH3")]
        public decimal? ONECRACKLENGTH3 { get; set; }
        /// <summary>
        /// 单缝宽度3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKWIDTH3")]
        public decimal? ONECRACKWIDTH3 { get; set; }
        /// <summary>
        /// 单缝深度3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKDEPTH3")]
        public decimal? ONECRACKDEPTH3 { get; set; }
        /// <summary>
        /// 单缝性质3
        /// </summary>
        /// <returns></returns>
        [Column("ONECRACKNATURE3")]
        public string ONECRACKNATURE3 { get; set; }
        /// <summary>
        /// 缝数
        /// </summary>
        /// <returns></returns>
        [Column("CRACKNUM")]
        public int? CRACKNUM { get; set; }
        /// <summary>
        /// 裂缝分布面积
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDISTRAREA")]
        public decimal? CRACKDISTRAREA { get; set; }
        /// <summary>
        /// 裂缝间距
        /// </summary>
        /// <returns></returns>
        [Column("CRACKSPACE")]
        public decimal? CRACKSPACE { get; set; }
        /// <summary>
        /// 裂缝排列形式
        /// </summary>
        /// <returns></returns>
        [Column("CRACKARRFORM")]
        public string CRACKARRFORM { get; set; }
        /// <summary>
        /// 裂缝倾向
        /// </summary>
        /// <returns></returns>
        [Column("CRACKTENDENCY")]
        public int? CRACKTENDENCY { get; set; }
        /// <summary>
        /// 裂缝倾角
        /// </summary>
        /// <returns></returns>
        [Column("CRACKANGLE")]
        public int? CRACKANGLE { get; set; }
        /// <summary>
        /// 裂缝长MAX
        /// </summary>
        /// <returns></returns>
        [Column("CRACKLENGTHMAX")]
        public decimal? CRACKLENGTHMAX { get; set; }
        /// <summary>
        /// 裂缝长MIN
        /// </summary>
        /// <returns></returns>
        [Column("CRACKLENGTHMIN")]
        public decimal? CRACKLENGTHMIN { get; set; }
        /// <summary>
        /// 裂缝宽MAX
        /// </summary>
        /// <returns></returns>
        [Column("CRACKWIDTHMAX")]
        public decimal? CRACKWIDTHMAX { get; set; }
        /// <summary>
        /// 裂缝宽MIN
        /// </summary>
        /// <returns></returns>
        [Column("CRACKWIDTHMIN")]
        public decimal? CRACKWIDTHMIN { get; set; }
        /// <summary>
        /// 裂缝深MAX
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTHMAX")]
        public decimal? CRACKDEPTHMAX { get; set; }
        /// <summary>
        /// 裂缝深MIN
        /// </summary>
        /// <returns></returns>
        [Column("CRACKDEPTHMIN")]
        public decimal? CRACKDEPTHMIN { get; set; }
        /// <summary>
        /// 塌陷区地貌特征
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEAREATOPFEA")]
        public string COLLAPSEAREATOPFEA { get; set; }
        /// <summary>
        /// 成因类型
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEGENETICTYPE")]
        public string COLLAPSEGENETICTYPE { get; set; }
        /// <summary>
        /// 岩溶塌陷地层时代
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOSTRATIGRAPHICTIME")]
        public string KARSTCOSTRATIGRAPHICTIME { get; set; }
        /// <summary>
        /// 岩溶塌陷地层岩性
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOLITH")]
        public string KARSTCOLITH { get; set; }
        /// <summary>
        /// 岩溶塌陷岩层倾向
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOSTRATUMDIRE")]
        public int? KARSTCOSTRATUMDIRE { get; set; }
        /// <summary>
        /// 岩溶塌陷岩层倾角
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOSTRATUMANGLE")]
        public int? KARSTCOSTRATUMANGLE { get; set; }
        /// <summary>
        /// 岩溶塌陷断裂情况
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOFRACSITUATION")]
        public string KARSTCOFRACSITUATION { get; set; }
        /// <summary>
        /// 岩溶塌陷溶洞发育情况
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOCAVEDEVELOPSITUATION")]
        public string KARSTCOCAVEDEVELOPSITUATION { get; set; }
        /// <summary>
        /// 岩溶塌陷岩层发育程度
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOROCKDEVELOPDEGREE")]
        public string KARSTCOROCKDEVELOPDEGREE { get; set; }
        /// <summary>
        /// 岩溶塌陷塌顶溶洞埋深
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOROOFCAVEDEPTH")]
        public decimal? KARSTCOROOFCAVEDEPTH { get; set; }
        /// <summary>
        /// 岩溶塌陷地下水位埋深
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOGROUNDWATERDEPTH")]
        public decimal? KARSTCOGROUNDWATERDEPTH { get; set; }
        /// <summary>
        /// 岩溶塌陷诱发动力因素
        /// </summary>
        /// <returns></returns>
        [Column("KARSTCOTRIGGERSPOWER")]
        public string KARSTCOTRIGGERSPOWER { get; set; }
        /// <summary>
        /// 土洞塌陷单层土性
        /// </summary>
        /// <returns></returns>
        [Column("HOLECOSINGLESOILNATURE")]
        public string HOLECOSINGLESOILNATURE { get; set; }
        /// <summary>
        /// 土洞塌陷单层土厚
        /// </summary>
        /// <returns></returns>
        [Column("HOLECOSINGLESOILTHICK")]
        public decimal? HOLECOSINGLESOILTHICK { get; set; }
        /// <summary>
        /// 土洞塌陷双层上部土性
        /// </summary>
        /// <returns></returns>
        [Column("HOLECODOUBTOPSOILNATURE")]
        public string HOLECODOUBTOPSOILNATURE { get; set; }
        /// <summary>
        /// 土洞塌陷双层上部土厚
        /// </summary>
        /// <returns></returns>
        [Column("HOLECODOUBTOPSOILTHICK")]
        public decimal? HOLECODOUBTOPSOILTHICK { get; set; }
        /// <summary>
        /// 土洞塌陷双层下部土性
        /// </summary>
        /// <returns></returns>
        [Column("HOLECODOUBLOWERSOILNATURE")]
        public string HOLECODOUBLOWERSOILNATURE { get; set; }
        /// <summary>
        /// 土洞塌陷双层下部土厚
        /// </summary>
        /// <returns></returns>
        [Column("HOLECODOUBLOWERSOILTHICK")]
        public decimal? HOLECODOUBLOWERSOILTHICK { get; set; }
        /// <summary>
        /// 土洞塌陷下伏基岩时代
        /// </summary>
        /// <returns></returns>
        [Column("HOLECOUNDERBEDROCKTIME")]
        public string HOLECOUNDERBEDROCKTIME { get; set; }
        /// <summary>
        /// 土洞塌陷下伏基岩岩性
        /// </summary>
        /// <returns></returns>
        [Column("HOLECOUNDERBEDROCKLITH")]
        public string HOLECOUNDERBEDROCKLITH { get; set; }
        /// <summary>
        /// 土洞塌陷地下水位埋深
        /// </summary>
        /// <returns></returns>
        [Column("HOLECOGROUNDWATERDEPTH")]
        public decimal? HOLECOGROUNDWATERDEPTH { get; set; }
        /// <summary>
        /// 土洞塌陷诱发动力因素
        /// </summary>
        /// <returns></returns>
        [Column("HOLECOTRIGGERSPOWER")]
        public string HOLECOTRIGGERSPOWER { get; set; }
        /// <summary>
        /// 井位塌陷区方向
        /// </summary>
        /// <returns></returns>
        [Column("WELLPLACECOAREADIRE")]
        public string WELLPLACECOAREADIRE { get; set; }
        /// <summary>
        /// 井位塌陷区距离
        /// </summary>
        /// <returns></returns>
        [Column("WELLPLACECOAREADIST")]
        public decimal? WELLPLACECOAREADIST { get; set; }
        /// <summary>
        /// 井位塌陷区抽水降深
        /// </summary>
        /// <returns></returns>
        [Column("WELLPLACECOAREAPUMPDEPTH")]
        public decimal? WELLPLACECOAREAPUMPDEPTH { get; set; }
        /// <summary>
        /// 井位塌陷区日出水量
        /// </summary>
        /// <returns></returns>
        [Column("WELLPLACECOAREADAYPUMPVOL")]
        public decimal? WELLPLACECOAREADAYPUMPVOL { get; set; }
        /// <summary>
        /// 江河水位塌陷区方向
        /// </summary>
        /// <returns></returns>
        [Column("RIVERWATLEVCOAREADIRE")]
        public string RIVERWATLEVCOAREADIRE { get; set; }
        /// <summary>
        /// 江河水位塌陷区距离
        /// </summary>
        /// <returns></returns>
        [Column("RIVERWATLEVCOAREADIST")]
        public decimal? RIVERWATLEVCOAREADIST { get; set; }
        /// <summary>
        /// 江河水位塌陷区水位变幅
        /// </summary>
        /// <returns></returns>
        [Column("RIVERWATLEVCOAREAAMP")]
        public decimal? RIVERWATLEVCOAREAAMP { get; set; }
        /// <summary>
        /// 江河水位塌陷区变化类型
        /// </summary>
        /// <returns></returns>
        [Column("RIVERWATLEVCOAREACHANGETYPE")]
        public string RIVERWATLEVCOAREACHANGETYPE { get; set; }
        /// <summary>
        /// 冒顶塌陷土层时代
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSOILTIME")]
        public string ROOFFALLCOSOILTIME { get; set; }
        /// <summary>
        /// 冒顶塌陷土层土性
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSOILNATURE")]
        public string ROOFFALLCOSOILNATURE { get; set; }
        /// <summary>
        /// 冒顶塌陷土层厚度
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSOILTHICK")]
        public decimal? ROOFFALLCOSOILTHICK { get; set; }
        /// <summary>
        /// 冒顶塌陷岩层时代
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSTRATUMTIME")]
        public string ROOFFALLCOSTRATUMTIME { get; set; }
        /// <summary>
        /// 冒顶塌陷岩层岩性
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSTRATUMLITH")]
        public string ROOFFALLCOSTRATUMLITH { get; set; }
        /// <summary>
        /// 冒顶塌陷岩层厚度
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSTRATUMTHICK")]
        public decimal? ROOFFALLCOSTRATUMTHICK { get; set; }
        /// <summary>
        /// 冒顶塌陷地下水位埋深
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOGROUNDWATERDEPTH")]
        public decimal? ROOFFALLCOGROUNDWATERDEPTH { get; set; }
        /// <summary>
        /// 冒顶塌陷诱发动力因素
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOTRIGGERSPOWER")]
        public string ROOFFALLCOTRIGGERSPOWER { get; set; }
        /// <summary>
        /// 冒顶塌陷矿层厚度
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOSEAMTHICK")]
        public decimal? ROOFFALLCOSEAMTHICK { get; set; }
        /// <summary>
        /// 冒顶塌陷开采时间
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOMINETIME")]
        public string ROOFFALLCOMINETIME { get; set; }
        /// <summary>
        /// 冒顶塌陷开采厚度
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOMINETHICK")]
        public decimal? ROOFFALLCOMINETHICK { get; set; }
        /// <summary>
        /// 冒顶塌陷开采深度
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOMINEDEPTH")]
        public decimal? ROOFFALLCOMINEDEPTH { get; set; }
        /// <summary>
        /// 冒顶塌陷开采方法
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOMINEMETHOD")]
        public string ROOFFALLCOMINEMETHOD { get; set; }
        /// <summary>
        /// 冒顶塌陷工作面推进速度
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOWORKSURFFORWSPEED")]
        public decimal? ROOFFALLCOWORKSURFFORWSPEED { get; set; }
        /// <summary>
        /// 冒顶塌陷采出量
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOMINEVOL")]
        public decimal? ROOFFALLCOMINEVOL { get; set; }
        /// <summary>
        /// 冒顶塌陷顶板管理方法
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOROOFMANAGEMETHOD")]
        public string ROOFFALLCOROOFMANAGEMETHOD { get; set; }
        /// <summary>
        /// 冒顶塌陷重复采动
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOREPEATMINE")]
        public string ROOFFALLCOREPEATMINE { get; set; }
        /// <summary>
        /// 冒顶塌陷采空区形态
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOGOBFORM")]
        public string ROOFFALLCOGOBFORM { get; set; }
        /// <summary>
        /// 冒顶塌陷采空区规模
        /// </summary>
        /// <returns></returns>
        [Column("ROOFFALLCOGOBSCALE")]
        public string ROOFFALLCOGOBSCALE { get; set; }
        /// <summary>
        /// 毁坏田地
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDFARM")]
        public decimal? DESTROYEDFARM { get; set; }
        /// <summary>
        /// 毁坏房屋
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOME")]
        public decimal? DESTROYEDHOME { get; set; }
        /// <summary>
        /// 阻断交通
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKINGTRAFFIC")]
        public string BLOCKINGTRAFFIC { get; set; }
        /// <summary>
        /// 地下水源枯竭
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATEREXHAUSTED")]
        public string GROUNDWATEREXHAUSTED { get; set; }
        /// <summary>
        /// 地下水井突水
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATERINRUSH")]
        public string GROUNDWATERINRUSH { get; set; }
        /// <summary>
        /// 掩埋地面物资
        /// </summary>
        /// <returns></returns>
        [Column("BURYGROUNDSUBSTANCE")]
        public string BURYGROUNDSUBSTANCE { get; set; }
        /// <summary>
        /// 死亡人口
        /// </summary>
        /// <returns></returns>
        [Column("DEATHNUM")]
        public int? DEATHNUM { get; set; }
        /// <summary>
        /// 直接损失
        /// </summary>
        /// <returns></returns>
        [Column("DIRETLOSSES")]
        public decimal? DIRETLOSSES { get; set; }
        /// <summary>
        /// 灾情等级
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERLEVEL")]
        public string DISASTERLEVEL { get; set; }
        /// <summary>
        /// 新增陷坑
        /// </summary>
        /// <returns></returns>
        [Column("ADDCOLLAPSE")]
        public short? ADDCOLLAPSE { get; set; }
        /// <summary>
        /// 扩大陷区
        /// </summary>
        /// <returns></returns>
        [Column("EXPCOLLAPSEAREA")]
        public decimal? EXPCOLLAPSEAREA { get; set; }
        /// <summary>
        /// 潜在毁田
        /// </summary>
        /// <returns></returns>
        [Column("POTDESTROYEDFARM")]
        public decimal? POTDESTROYEDFARM { get; set; }
        /// <summary>
        /// 潜在毁房
        /// </summary>
        /// <returns></returns>
        [Column("POTDESTROYEDHOME")]
        public int? POTDESTROYEDHOME { get; set; }
        /// <summary>
        /// 出现新陷区
        /// </summary>
        /// <returns></returns>
        [Column("APPNEWCOLLAPSE")]
        public int? APPNEWCOLLAPSE { get; set; }
        /// <summary>
        /// 新陷区面积
        /// </summary>
        /// <returns></returns>
        [Column("NEWCOLLAPSEAREA")]
        public decimal? NEWCOLLAPSEAREA { get; set; }
        /// <summary>
        /// 断路
        /// </summary>
        /// <returns></returns>
        [Column("OPENCIRCUIT")]
        public decimal? OPENCIRCUIT { get; set; }
        /// <summary>
        /// 其他危害
        /// </summary>
        /// <returns></returns>
        [Column("OTHERHARM")]
        public string OTHERHARM { get; set; }
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
        /// 隐患点
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENPOINT")]
        public string HIDDENPOINT { get; set; }
        /// <summary>
        /// 防灾预案
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
        /// 阶步指向
        /// </summary>
        /// <returns></returns>
        [Column("HOMPOINT")]
        public string HOMPOINT { get; set; }
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
        /// 防治情况
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
        /// 地面塌陷情况
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSEDESC")]
        public string COLLAPSEDESC { get; set; }
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
        /// 阻断铁路（M)
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKINGRAILWAY")]
        public decimal? BLOCKINGRAILWAY { get; set; }
        /// <summary>
        /// 阻断公路
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKINGROAD")]
        public decimal? BLOCKINGROAD { get; set; }
        /// <summary>
        /// 阻断通讯(小时)
        /// </summary>
        /// <returns></returns>
        [Column("BLOCKINGCOMMUNICATION")]
        public decimal? BLOCKINGCOMMUNICATION { get; set; }
        /// <summary>
        /// 水量增大(立方米/秒）
        /// </summary>
        /// <returns></returns>
        [Column("WATERINCREASE")]
        public decimal? WATERINCREASE { get; set; }
        /// <summary>
        /// 成灾损失
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERLOSS")]
        public decimal? DISASTERLOSS { get; set; }
        /// <summary>
        /// 淹井损失（万元）
        /// </summary>
        /// <returns></returns>
        [Column("FLOODEDWELLLOSS")]
        public decimal? FLOODEDWELLLOSS { get; set; }
        /// <summary>
        /// 河水减少
        /// </summary>
        /// <returns></returns>
        [Column("RIVERWATERREDUCE")]
        public decimal? RIVERWATERREDUCE { get; set; }
        /// <summary>
        /// 断流(立方米/米）
        /// </summary>
        /// <returns></returns>
        [Column("INTERRUPTEDRIVERWATER")]
        public decimal? INTERRUPTEDRIVERWATER { get; set; }
        /// <summary>
        /// 井泉水流量减少
        /// </summary>
        /// <returns></returns>
        [Column("WELLWATERREDUCE")]
        public decimal? WELLWATERREDUCE { get; set; }
        /// <summary>
        /// 水位降低（米）
        /// </summary>
        /// <returns></returns>
        [Column("WATERLEVELREDUCE")]
        public decimal? WATERLEVELREDUCE { get; set; }
        /// <summary>
        /// 威胁房屋（户）
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOME")]
        public int? THREATENHOME { get; set; }
        /// <summary>
        /// 威胁对象
        /// </summary>
        /// <returns></returns>
        [Column("THREATENOBJ")]
        public string THREATENOBJ { get; set; }
        /// <summary>
        /// 危害对象
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDOBJ")]
        public string DESTROYEDOBJ { get; set; }
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
        [Column("SURVERYHEADERID")]
        public string SURVERYHEADERID { get; set; }
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
        /// 是否单层
        /// </summary>
        /// <returns></returns>
        [Column("ISHOLECOSINGLE")]
        public string ISHOLECOSINGLE { get; set; }
        /// <summary>
        /// 是否双层
        /// </summary>
        /// <returns></returns>
        [Column("ISHOLECODOUBLE")]
        public string ISHOLECODOUBLE { get; set; }
        /// <summary>
        /// 阶段指向
        /// </summary>
        /// <returns></returns>
        [Column("CRACKSTAGEPOINT")]
        public int? CRACKSTAGEPOINT { get; set; }
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
        /// 灾险情等级
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERRISKLEVEL")]
        public string DISASTERRISKLEVEL { get; set; }
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
        /// 干枯
        /// </summary>
        /// <returns></returns>
        [Column("GK")]
        public string GK { get; set; }
        /// <summary>
        /// 标高
        /// </summary>
        /// <returns></returns>
        [Column("BG")]
        public string BG { get; set; }
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
