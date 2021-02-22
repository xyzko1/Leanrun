using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 11:13
    /// 描 述：灾害点历史信息基本表
    /// </summary>
    public class TBL_HAZARDBASICINFO_HISTORYEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 灾害体类型
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        /// <summary>
        /// 灾害体编号
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// 灾害体名称
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERNAME")]
        public string DISASTERNAME { get; set; }
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
        /// 省名称
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        /// <returns></returns>
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// 乡镇
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
        /// <summary>
        /// 乡镇名称
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
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
        public string X { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        /// <returns></returns>
        [Column("Y")]
        public string Y { get; set; }
        /// <summary>
        /// Z
        /// </summary>
        /// <returns></returns>
        [Column("Z")]
        public string Z { get; set; }
        /// <summary>
        /// 坡顶/最大标高
        /// </summary>
        /// <returns></returns>
        [Column("ALTTOP")]
        public string ALTTOP { get; set; }
        /// <summary>
        /// 坡底/最小标高
        /// </summary>
        /// <returns></returns>
        [Column("ALTBOTOM")]
        public string ALTBOTOM { get; set; }
        /// <summary>
        /// 治理情况
        /// </summary>
        /// <returns></returns>
        [Column("CONTROLSTATE")]
        public string CONTROLSTATE { get; set; }
        /// <summary>
        /// 地下水类型
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATERTYPE")]
        public string GROUNDWATERTYPE { get; set; }
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
        /// 目前稳定程度
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
        /// 灾害等级
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
        /// 防治建议
        /// </summary>
        /// <returns></returns>
        [Column("TREATMENTSUGGESTION")]
        public string TREATMENTSUGGESTION { get; set; }
        /// <summary>
        /// 隐患点（是，否）
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENDANGER")]
        public string HIDDENDANGER { get; set; }
        /// <summary>
        /// 监测建议
        /// </summary>
        /// <returns></returns>
        [Column("MONITORSUGGESTION")]
        public string MONITORSUGGESTION { get; set; }
        /// <summary>
        /// 毁坏房屋
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOME")]
        public string DESTROYEDHOME { get; set; }
        /// <summary>
        /// 毁路
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDROAD")]
        public string DESTROYEDROAD { get; set; }
        /// <summary>
        /// 毁渠
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDCANAL")]
        public string DESTROYEDCANAL { get; set; }
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 工程编号
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTID")]
        public string PROJECTID { get; set; }
        /// <summary>
        /// 县
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }
        /// <summary>
        /// 县名称
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
        /// <summary>
        /// 调查类型(详查、巡查、排查)
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYTYPE")]
        public string SURVEYTYPE { get; set; }
        /// <summary>
        /// 调查时间
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYTIME")]
        public System.DateTime? SURVEYTIME { get; set; }
        /// <summary>
        /// 是否为重要灾害点
        /// </summary>
        /// <returns></returns>
        [Column("ISIMPORTANT")]
        public string ISIMPORTANT { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public System.DateTime? CREATETIME { get; set; }
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
        public System.DateTime? MODIFYTIME { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYUSER")]
        public string MODIFYUSER { get; set; }
        /// <summary>
        /// 灾害体编号bak
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODEBAK")]
        public string UNIFIEDCODEBAK { get; set; }
        /// <summary>
        /// 死亡人口
        /// </summary>
        /// <returns></returns>
        [Column("DEATHTOLL")]
        public string DEATHTOLL { get; set; }
        /// <summary>
        /// 财产损失
        /// </summary>
        /// <returns></returns>
        [Column("ASSETSLOSE")]
        public string ASSETSLOSE { get; set; }
        /// <summary>
        /// 失踪人数
        /// </summary>
        /// <returns></returns>
        [Column("MISSINGPERSON")]
        public string MISSINGPERSON { get; set; }
        /// <summary>
        /// 受伤人数
        /// </summary>
        /// <returns></returns>
        [Column("INJUREDPERSON")]
        public string INJUREDPERSON { get; set; }
        /// <summary>
        /// 1
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE1")]
        public string LONGITUDE1 { get; set; }
        /// <summary>
        /// 2
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE1")]
        public string LATITUDE1 { get; set; }
        /// <summary>
        /// 老表外键1
        /// </summary>
        /// <returns></returns>
        [Column("PHYGEODISASTERID")]
        public string PHYGEODISASTERID { get; set; }
        /// <summary>
        /// 老表外键
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// 是否销号：0未销号 1销号
        /// </summary>
        /// <returns></returns>
        [Column("ISXH")]
        public string ISXH { get; set; }
        /// <summary>
        /// 规模等级
        /// </summary>
        /// <returns></returns>
        [Column("SCALELEVEL")]
        public string SCALELEVEL { get; set; }
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
        public System.DateTime? AUDITEDDATE { get; set; }
        /// <summary>
        /// 修改类型（I：批量导入；A：新增记录；U：修改记录；D：删除记录）
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYTYPE")]
        public string MODIFYTYPE { get; set; }
        /// <summary>
        /// 核销类型（1-治理工程，2-搬迁避让，3-人工核定）
        /// </summary>
        /// <returns></returns>
        [Column("VERIFICATION")]
        public string VERIFICATION { get; set; }

        /// <summary>
        /// 填表日期
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEDATE")]
        public DateTime? FILLTABLEDATE { get; set; }
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