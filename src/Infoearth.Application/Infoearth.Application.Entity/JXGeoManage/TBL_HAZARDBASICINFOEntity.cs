using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-14 11:42
    /// 描 述：灾害点基本表
    /// </summary>
    public class TBL_HAZARDBASICINFOEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 灾害体类型
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        [Column("OLDUNIFIEDCODE")]
        public string OLDUNIFIEDCODE { get; set; }
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
        /// 组
        /// </summary>
        /// <returns></returns>
        [Column("TEAM")]
        public string TEAM { get; set; }
        /// <summary>
        /// 村
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGE")]
        public string VILLAGE { get; set; }
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
        /// 坡顶/最大标高
        /// </summary>
        /// <returns></returns>
        [Column("ALTTOP")]
        public decimal? ALTTOP { get; set; }
        /// <summary>
        /// 坡底/最小标高
        /// </summary>
        /// <returns></returns>
        [Column("ALTBOTOM")]
        public decimal? ALTBOTOM { get; set; }
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
        /// 隐患点
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
        [Column("DESTROYEDCANAL")]
        public decimal? DESTROYEDCANAL { get; set; }
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
        public DateTime? SURVEYTIME { get; set; }
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
        /// 死亡人口
        /// </summary>
        /// <returns></returns>
        [Column("DEATHTOLL")]
        public decimal? DEATHTOLL { get; set; }
        /// <summary>
        /// 财产损失
        /// </summary>
        /// <returns></returns>
        [Column("ASSETSLOSE")]
        public decimal? ASSETSLOSE { get; set; }
        /// <summary>
        /// 失踪人数
        /// </summary>
        /// <returns></returns>
        [Column("MISSINGPERSON")]
        public decimal? MISSINGPERSON { get; set; }
        /// <summary>
        /// 受伤人数
        /// </summary>
        /// <returns></returns>
        [Column("INJUREDPERSON")]
        public decimal? INJUREDPERSON { get; set; }
        /// <summary>
        /// 是否核销
        /// </summary>
        /// <returns></returns>
        [Column("ISXH")]
        public string ISXH { get; set; }
        /// <summary>
        /// 是否重大隐患点
        /// </summary>
        /// <returns></returns>
        [Column("ISZDYHD")]
        public string ISZDYHD { get; set; }
        /// <summary>
        /// 数据类型
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

    /// <summary>
    /// 灾害点历史数据类
    /// </summary>
    public class PastHAZARDBASICINFO
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string GUID { get; set; }
        /// <summary>
        /// 统一灾害编号
        /// </summary>
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// 灾害点名称
        /// </summary>
        public string DISASTERUNITNAME { get; set; }
        /// <summary>
        /// 灾害点类型
        /// </summary>
        public string DISASTERTYPE { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public string MODIFYTYPE { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string EDITOR { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string AUDITOR { get; set; }
        /// <summary>
        /// 地理位置
        /// </summary>
        public string LOCATION { get; set; }
        /// <summary>
        /// 灾情等级
        /// </summary>
        public string DISASTERLEVEL { get; set; }
        /// <summary>
        /// 险情等级
        /// </summary>
        public string DANGERLEVEL { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? MODIFIEDDATE { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        /// <returns></returns>
        public string LONGITUDE { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        /// <returns></returns>
        public string LATITUDE { get; set; }

        /// <summary>
        /// 填表日期
        /// </summary>
        public string FILLDATE { get; set; }

    }
}