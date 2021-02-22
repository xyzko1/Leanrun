using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Infoearth.Application.Entity.JXGeoManage;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infoearth.Application.Entity
{
    public class TreeByBQBRTJ
    {
        public string id { get; set; }
        public string level { get; set; }
        public string parent { get; set; }
        public bool expanded { get; set; }
        public bool isLeaf { get; set; }
        public object data { get; set; }
        public string count { get; set; }
        public string LOCATION { get; set; }
        public string DISASTERTYPE { get; set; }
        public string DISASTERNAME { get; set; }
        public string HOUSEHOLDERNAME { get; set; }
        public string RESETTLEMENT { get; set; }
        public string SFWC { get; set; }
        public string SFYS { get; set; }
        public long? MOVEDECIMAL { get; set; }
        public string ZAZBTJE { get; set; }
        public string YFJE { get; set; }
        public string DFJR { get; set; }
    }
    public class tbl_bqbrnew 
    {
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 灾害点名称
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERNAME")]
        public string DISASTERNAME { get; set; }
        /// <summary>
        /// 灾害点编号
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// 省名称
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// 省编号
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        /// <returns></returns>
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// 市编号
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        /// <summary>
        /// 县名称
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
        /// <summary>
        /// 县编号
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }
        /// <summary>
        /// 乡镇名称
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
        /// <summary>
        /// 乡镇编号
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
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
        /// 地理位置
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        public string LOCATION { get; set; }
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
        /// 年度
        /// </summary>
        /// <returns></returns>
        [Column("ANNUAL")]
        public string ANNUAL { get; set; }
        /// <summary>
        /// 单户户主
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEHOLDERNAME")]
        public string HOUSEHOLDERNAME { get; set; }
        /// <summary>
        /// 安置方式
        /// </summary>
        /// <returns></returns>
        [Column("RESETTLEMENT")]
        public string RESETTLEMENT { get; set; }
        /// <summary>
        /// 单户搬迁人数
        /// </summary>
        /// <returns></returns>
        [Column("MOVEDECIMAL")]
        public long? MOVEDECIMAL { get; set; }
        /// <summary>
        /// 集中或安置分散点名称
        /// </summary>
        /// <returns></returns>
        [Column("RESETTLEMENTNAME")]
        public string RESETTLEMENTNAME { get; set; }
        /// <summary>
        /// 汛期自主安置点名称
        /// </summary>
        /// <returns></returns>
        [Column("FLOODRESETTLEMENTNAME")]
        public string FLOODRESETTLEMENTNAME { get; set; }
        /// <summary>
        /// 自主安置人住时间
        /// </summary>
        /// <returns></returns>
        [Column("RESETTLEMENTTIME")]
        public DateTime? RESETTLEMENTTIME { get; set; }
        /// <summary>
        /// 原址是否拆除
        /// </summary>
        /// <returns></returns>
        [Column("ISDEMOLITION")]
        public string ISDEMOLITION { get; set; }
        /// <summary>
        /// 旧房拆除时间
        /// </summary>
        /// <returns></returns>
        [Column("DEMOLITIONTIME")]
        public DateTime? DEMOLITIONTIME { get; set; }
        /// <summary>
        /// 集中或分散安置人住时间
        /// </summary>
        /// <returns></returns>
        [Column("SCATTEREDRESETTLEMENTTIME")]
        public DateTime? SCATTEREDRESETTLEMENTTIME { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        /// <returns></returns>
        [Column("ISCOMPLETE")]
        public string ISCOMPLETE { get; set; }
        /// <summary>
        /// 是否验收
        /// </summary>
        /// <returns></returns>
        [Column("ISACCEPTANCE")]
        public string ISACCEPTANCE { get; set; }
        /// <summary>
        /// 迁入地是否存在地灾隐患
        /// </summary>
        /// <returns></returns>
        [Column("ISHIDDENDANGER")]
        public string ISHIDDENDANGER { get; set; }
        /// <summary>
        /// 迁入地生产生活条件改善情况
        /// </summary>
        /// <returns></returns>
        [Column("SITUATION")]
        public string SITUATION { get; set; }
        /// <summary>
        /// 对搬迁工作认同情况
        /// </summary>
        /// <returns></returns>
        [Column("IDENTITY")]
        public string IDENTITY { get; set; }
        /// <summary>
        /// 认同情况原因
        /// </summary>
        /// <returns></returns>
        [Column("IDENTITYWHY")]
        public string IDENTITYWHY { get; set; }
        /// <summary>
        /// 是否公示
        /// </summary>
        /// <returns></returns>
        [Column("ISOFPUBLIC")]
        public string ISOFPUBLIC { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("NOTE")]
        public string NOTE { get; set; }
        /// <summary>
        /// 县级审核人
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYPEOPLE")]
        public string COUNTYPEOPLE { get; set; }
        /// <summary>
        /// 县级审核时间
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYTIME")]
        public DateTime? COUNTYTIME { get; set; }
        /// <summary>
        /// 县级审核意见
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYOPINION")]
        public string COUNTYOPINION { get; set; }
        /// <summary>
        /// 市级审核人
        /// </summary>
        /// <returns></returns>
        [Column("CITYPEOPLE")]
        public string CITYPEOPLE { get; set; }
        /// <summary>
        /// 市级审核时间
        /// </summary>
        /// <returns></returns>
        [Column("CITYTIME")]
        public DateTime? CITYTIME { get; set; }
        /// <summary>
        /// 市级审核意见
        /// </summary>
        /// <returns></returns>
        [Column("CITYOPINION")]
        public string CITYOPINION { get; set; }
        /// <summary>
        /// 填报人
        /// </summary>
        /// <returns></returns>
        [Column("BZ001")]
        public string BZ001 { get; set; }
        /// <summary>
        /// 填报时间
        /// </summary>
        /// <returns></returns>
        [Column("BZ002")]
        public string BZ002 { get; set; }
        /// <summary>
        /// 扩展字段3
        /// </summary>
        /// <returns></returns>
        [Column("BZ003")]
        public string BZ003 { get; set; }
        /// <summary>
        /// 扩展字段4
        /// </summary>
        /// <returns></returns>
        [Column("BZ004")]
        public string BZ004 { get; set; }
        /// <summary>
        /// 扩展字段5
        /// </summary>
        /// <returns></returns>
        [Column("BZ005")]
        public string BZ005 { get; set; }
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
        /// 搬迁户性质
        /// </summary>
        /// <returns></returns>
        [Column("MINENATURE")]
        public string MINENATURE { get; set; }
        /// <summary>
        /// 省补助金
        /// </summary>
        /// <returns></returns>
        [Column("SHENGGRANT")]
        public string SHENGGRANT { get; set; }
        /// <summary>
        /// 市补助金
        /// </summary>
        /// <returns></returns>
        [Column("SHIGRANT")]
        public string SHIGRANT { get; set; }
        /// <summary>
        /// 县补助金
        /// </summary>
        /// <returns></returns>
        [Column("XIANGRANT")]
        public string XIANGRANT { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public DateTime? CREATETIME { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        [Column("CREATEUSER")]
        public string CREATEUSER { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYTIME")]
        public DateTime? MODIFYTIME { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYUSER")]
        public string MODIFYUSER { get; set; }
        /// <summary>
        /// 灾害体类型
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }


        /// <summary>
        /// 安置点名称
        /// </summary>
        /// <returns></returns>
        [Column("AZDMC")]
        public string AZDMC { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        /// <returns></returns>
        [Column("XMMC")]
        public string XMMC { get; set; }
        /// <summary>
        /// 搬迁原因
        /// </summary>
        /// <returns></returns>
        [Column("BQYY")]
        public string BQYY { get; set; }
        /// <summary>
        /// 安置点是否存在隐患
        /// </summary>
        /// <returns></returns>
        [Column("ISYH")]
        public string ISYH { get; set; }
        /// <summary>
        /// 旧户籍地址
        /// </summary>
        /// <returns></returns>
        [Column("OLDHJDZ")]
        public string OLDHJDZ { get; set; }
        /// <summary>
        /// 旧房地址
        /// </summary>
        /// <returns></returns>
        [Column("JFDZ")]
        public string JFDZ { get; set; }
        /// <summary>
        /// 旧房面积
        /// </summary>
        /// <returns></returns>
        [Column("JFMJ")]
        public decimal? JFMJ { get; set; }
        /// <summary>
        /// 旧房经度
        /// </summary>
        /// <returns></returns>
        [Column("JFJD")]
        public decimal? JFJD { get; set; }
        /// <summary>
        /// 旧房纬度
        /// </summary>
        /// <returns></returns>
        [Column("JFWD")]
        public decimal? JFWD { get; set; }
        /// <summary>
        /// 新户籍地址
        /// </summary>
        /// <returns></returns>
        [Column("NEWHJDZ")]
        public string NEWHJDZ { get; set; }
        /// <summary>
        /// 新房地址
        /// </summary>
        /// <returns></returns>
        [Column("XFDZ")]
        public string XFDZ { get; set; }
        /// <summary>
        /// 新房面积
        /// </summary>
        /// <returns></returns>
        [Column("XFMJ")]
        public decimal? XFMJ { get; set; }
        /// <summary>
        /// 新房经度
        /// </summary>
        /// <returns></returns>
        [Column("XFJD")]
        public decimal? XFJD { get; set; }
        /// <summary>
        /// 新房纬度
        /// </summary>
        /// <returns></returns>
        [Column("XFWD")]
        public decimal? XFWD { get; set; }
        /// <summary>
        /// 新房建成时间
        /// </summary>
        /// <returns></returns>
        [Column("XFJCDATA")]
        public DateTime? XFJCDATA { get; set; }
        /// <summary>
        /// 新房迁入时间
        /// </summary>
        /// <returns></returns>
        [Column("XFQRDATA")]
        public DateTime? XFQRDATA { get; set; }
        /// <summary>
        /// 旧房拆除说明
        /// </summary>
        /// <returns></returns>
        [Column("JFCCSM")]
        public string JFCCSM { get; set; }
        /// <summary>
        /// 补助标准
        /// </summary>
        /// <returns></returns>
        [Column("BZBZ")]
        public string BZBZ { get; set; }
        /// <summary>
        /// 发放单位
        /// </summary>
        /// <returns></returns>
        [Column("FFDW")]
        public string FFDW { get; set; }
        /// <summary>
        /// 总安置补贴金额
        /// </summary>
        /// <returns></returns>
        [Column("ZAZBTJE")]
        public string ZAZBTJE { get; set; }
        /// <summary>
        /// 已发金额
        /// </summary>
        /// <returns></returns>
        [Column("YFJE")]
        public string YFJE { get; set; }
        /// <summary>
        /// 待发金额
        /// </summary>
        /// <returns></returns>
        [Column("DFJR")]
        public string DFJR { get; set; }
        /// <summary>
        /// 发放时间
        /// </summary>
        /// <returns></returns>
        [Column("FFSJ")]
        public DateTime? FFSJ { get; set; }
        /// <summary>
        /// 经手人
        /// </summary>
        /// <returns></returns>
        [Column("JSR")]
        public string JSR { get; set; }
        /// <summary>
        /// 建档立卡贫困户
        /// </summary>
        /// <returns></returns>
        [Column("JDLK")]
        public string JDLK { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        /// <returns></returns>
        [Column("SFWC")]
        public string SFWC { get; set; }
        /// <summary>
        /// 是否验收
        /// </summary>
        /// <returns></returns>
        [Column("SFYS")]
        public string SFYS { get; set; }
        /// <summary>
        /// 是否公示
        /// </summary>
        /// <returns></returns>
        [Column("SFGS")]
        public string SFGS { get; set; }
        /// <summary>
        /// 后续工作建议
        /// </summary>
        /// <returns></returns>
        [Column("HXGZJY")]
        public string HXGZJY { get; set; }
        /// <summary>
        /// 户数
        /// </summary>
        /// <returns></returns>
        ///   [Column("HS")]
        public string HS { get; set; }
        /// <summary>
        /// 灾害点名称
        /// </summary>
        /// <returns></returns>
        ///   [Column("BQRS")]
        public string BQRS { get; set; }
        /// <summary>
        /// 搬迁金额
        /// </summary>
        /// <returns></returns>
        ///   [Column("BTJR")]
        public string BTJR { get; set; }
        /// <summary>
        /// 已验收
        /// </summary>
        /// <returns></returns>
        ///   [Column("YYS")]
        public string YYS { get; set; }
        /// <summary>
        /// 已完成
        /// </summary>
        /// <returns></returns>
        ///   [Column("YWC")]
        public string YWC { get; set; }


    }
    public class QueryJsonEntity
    {
        public Pagination pagination { get; set; }
        public string queryJson { get; set; }
        public string condition { get; set; }


    }
    public class PostExcelEntity
    {
        public string queryJson { get; set; }
        public string condition { get; set; }
        public string outColumn { get; set; }

    }
    [NotMapped]
    public class NEWTBL_AVALANCHEEntity : TBL_AVALANCHEEntity
    {
        public string ISXH { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWNNAME { get; set; }
    }
    [NotMapped]
    public class NEWTBL_AVALANCHE_HIDDENEntity : TBL_AVALANCHE_HIDDENEntity
    {
        public string ISXH { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWNNAME { get; set; }
    }
    [NotMapped]
    public class NEWTBL_COLLAPSEEntity : TBL_COLLAPSEEntity
    {
        public string ISXH { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWNNAME { get; set; }
    }
    [NotMapped]
    public class NEWTBL_LANDCRACKEntity : TBL_LANDCRACKEntity
    {
        public string ISXH { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWNNAME { get; set; }
    }
    [NotMapped]
    public class NEWTBL_LANDSETTLEMENTEntity : TBL_LANDSETTLEMENTEntity
    {
        public string ISXH { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWNNAME { get; set; }
    }
    [NotMapped]
    public class NEWTBL_LANDSLIPEntity : TBL_LANDSLIPEntity
    {
        public string ISXH { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWNNAME { get; set; }
    }
    [NotMapped]
    public class NEWTBL_LANDSLIP_HIDDENEntity : TBL_LANDSLIP_HIDDENEntity
    {
        public string ISXH { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWNNAME { get; set; }
    }
    [NotMapped]
    public class NEWTBL_SENSEEntity : TBL_SENSEEntity
    {
        public string ISXH { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWNNAME { get; set; }
    }
    [NotMapped]
    public class NEWTBL_SLOPEEntity : TBL_SLOPEEntity
    {
        public string ISXH { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWNNAME { get; set; }
    }
    [NotMapped]
    public class NEWTBL_DEBRISFLOWEntity : TBL_DEBRISFLOWEntity
    {
        public string ISXH { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWNNAME { get; set; }
    }
}
