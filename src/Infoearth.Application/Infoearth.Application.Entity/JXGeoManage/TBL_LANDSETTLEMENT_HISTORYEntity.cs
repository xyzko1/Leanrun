using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-25 11:19
    /// 描 述：地面沉降调查表历史表
    /// </summary>
    public class TBL_LANDSETTLEMENT_HISTORYEntity : BaseEntity
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
        /// Z坐标
        /// </summary>
        /// <returns></returns>
        [Column("Z")]
        public decimal? Z { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENTIME")]
        public string HAPPENTIME { get; set; }
        /// <summary>
        /// 沉降类型
        /// </summary>
        /// <returns></returns>
        [Column("SETTLEMENTTYPE")]
        public string SETTLEMENTTYPE { get; set; }
        /// <summary>
        /// 沉降中心位置
        /// </summary>
        /// <returns></returns>
        [Column("SETTLEMENTCENTERLOCATION")]
        public string SETTLEMENTCENTERLOCATION { get; set; }
        /// <summary>
        /// 沉降中心经度
        /// </summary>
        /// <returns></returns>
        [Column("SETTLEMENTCENTERLONGITUDE")]
        public decimal? SETTLEMENTCENTERLONGITUDE { get; set; }
        /// <summary>
        /// 沉降中心纬度
        /// </summary>
        /// <returns></returns>
        [Column("SETTLEMENTCENTERLATITUDE")]
        public decimal? SETTLEMENTCENTERLATITUDE { get; set; }
        /// <summary>
        /// 沉降区面积
        /// </summary>
        /// <returns></returns>
        [Column("SETTLEMENTAREA")]
        public decimal? SETTLEMENTAREA { get; set; }
        /// <summary>
        /// 年平均沉降量
        /// </summary>
        /// <returns></returns>
        [Column("AVERAGEYEARSETTLEMENTVOLUME")]
        public decimal? AVERAGEYEARSETTLEMENTVOLUME { get; set; }
        /// <summary>
        /// 历年累计沉降量
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMULATIVESETTLEMENTVOLUME")]
        public decimal? ACCUMULATIVESETTLEMENTVOLUME { get; set; }
        /// <summary>
        /// 平均沉降速率
        /// </summary>
        /// <returns></returns>
        [Column("AVERAGESETTLEMENTRATE")]
        public decimal? AVERAGESETTLEMENTRATE { get; set; }
        /// <summary>
        /// 地形地貌
        /// </summary>
        /// <returns></returns>
        [Column("TOPOGRAPHY")]
        public string TOPOGRAPHY { get; set; }
        /// <summary>
        /// 地质构造及活动情况
        /// </summary>
        /// <returns></returns>
        [Column("GEOLOGICALSTRUCTURE")]
        public string GEOLOGICALSTRUCTURE { get; set; }
        /// <summary>
        /// 岩性
        /// </summary>
        /// <returns></returns>
        [Column("LITH")]
        public string LITH { get; set; }
        /// <summary>
        /// 厚度
        /// </summary>
        /// <returns></returns>
        [Column("DEPTH")]
        public string DEPTH { get; set; }
        /// <summary>
        /// 结构
        /// </summary>
        /// <returns></returns>
        [Column("ARCH")]
        public string ARCH { get; set; }
        /// <summary>
        /// 空间变化规律
        /// </summary>
        /// <returns></returns>
        [Column("SPACECHANGELAW")]
        public string SPACECHANGELAW { get; set; }
        /// <summary>
        /// 水文地质特征
        /// </summary>
        /// <returns></returns>
        [Column("HYDROLOGYGEOLOGYFEATURE")]
        public string HYDROLOGYGEOLOGYFEATURE { get; set; }
        /// <summary>
        /// 主要沉降层位
        /// </summary>
        /// <returns></returns>
        [Column("MAINSETTLEMENTLOCATION")]
        public string MAINSETTLEMENTLOCATION { get; set; }
        /// <summary>
        /// 年开采量
        /// </summary>
        /// <returns></returns>
        [Column("YEARMININGVOLUME")]
        public decimal? YEARMININGVOLUME { get; set; }
        /// <summary>
        /// 年补给量
        /// </summary>
        /// <returns></returns>
        [Column("YEARSUPPLYVOLUME")]
        public decimal? YEARSUPPLYVOLUME { get; set; }
        /// <summary>
        /// 地下水埋深
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATERDEPTH")]
        public decimal? GROUNDWATERDEPTH { get; set; }
        /// <summary>
        /// 年水位变化幅度
        /// </summary>
        /// <returns></returns>
        [Column("YEARWATLEVCHANGEMARGIN")]
        public decimal? YEARWATLEVCHANGEMARGIN { get; set; }
        /// <summary>
        /// 其它
        /// </summary>
        /// <returns></returns>
        [Column("OTHER")]
        public string OTHER { get; set; }
        /// <summary>
        /// 诱发沉降原因
        /// </summary>
        /// <returns></returns>
        [Column("INDUCEDSUBSIDENCECAUSES")]
        public string INDUCEDSUBSIDENCECAUSES { get; set; }
        /// <summary>
        /// 变化规律
        /// </summary>
        /// <returns></returns>
        [Column("CHANGELAW")]
        public string CHANGELAW { get; set; }
        /// <summary>
        /// 沉降现状
        /// </summary>
        /// <returns></returns>
        [Column("SETTLEMENTCURRENTSITUATION")]
        public string SETTLEMENTCURRENTSITUATION { get; set; }
        /// <summary>
        /// 发展趋势
        /// </summary>
        /// <returns></returns>
        [Column("DEVELOPMENTTREND")]
        public string DEVELOPMENTTREND { get; set; }
        /// <summary>
        /// 主要危害
        /// </summary>
        /// <returns></returns>
        [Column("MAINHARM")]
        public string MAINHARM { get; set; }
        /// <summary>
        /// 经济损失
        /// </summary>
        /// <returns></returns>
        [Column("ECONOMICLOSSES")]
        public decimal? ECONOMICLOSSES { get; set; }
        /// <summary>
        /// 治理措施
        /// </summary>
        /// <returns></returns>
        [Column("CONTROLMEASURES")]
        public string CONTROLMEASURES { get; set; }
        /// <summary>
        /// 治理效果
        /// </summary>
        /// <returns></returns>
        [Column("CONTROLEFFECT")]
        public string CONTROLEFFECT { get; set; }
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
        /// 防灾预案
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTIONPLAN")]
        public string PREVENTIONPLAN { get; set; }
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
        /// 是否隐患点（0：否；1：是）
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENDANGER")]
        public string HIDDENDANGER { get; set; }
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
        /// 死亡人数（人）
        /// </summary>
        /// <returns></returns>
        [Column("DEATHSPEOPLE")]
        public int? DEATHSPEOPLE { get; set; }
        /// <summary>
        /// 直接损失（万元）
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTLOSS")]
        public decimal? DIRECTLOSS { get; set; }
        /// <summary>
        /// 威胁房屋（户）
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOME")]
        public int? THREATENHOME { get; set; }
        /// <summary>
        /// 威胁人数（人）
        /// </summary>
        /// <returns></returns>
        [Column("THREATENPEOPLE")]
        public int? THREATENPEOPLE { get; set; }
        /// <summary>
        /// 威胁财产（万元）
        /// </summary>
        /// <returns></returns>
        [Column("THREATENASSETS")]
        public decimal? THREATENASSETS { get; set; }
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
        /// 野外编号
        /// </summary>
        /// <returns></returns>
        [Column("OUTDOORRECORD")]
        public string OUTDOORRECORD { get; set; }
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
        /// 调查单位ID  
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYDEPTID")]
        public string SURVEYDEPTID { get; set; }
        /// <summary>
        /// 核销类型（1-治理工程，2-搬迁避让，3-人工核定）
        /// </summary>
        /// <returns></returns>
        [Column("VERIFICATION")]
        public string VERIFICATION { get; set; }
        /// <summary>
        /// 灾情等级
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERLEVEL")]
        public string DISASTERLEVEL { get; set; }
        /// <summary>
        /// 险情等级
        /// </summary>
        /// <returns></returns>
        [Column("DANGERLEVEL")]
        public string DANGERLEVEL { get; set; }
        /// <summary>
        /// 灾险情等级
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERRISKLEVEL")]
        public string DISASTERRISKLEVEL { get; set; }
        /// <summary>
        /// 目前稳定状态
        /// </summary>
        /// <returns></returns>
        [Column("CURSTABLESTATUS")]
        public string CURSTABLESTATUS { get; set; }
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