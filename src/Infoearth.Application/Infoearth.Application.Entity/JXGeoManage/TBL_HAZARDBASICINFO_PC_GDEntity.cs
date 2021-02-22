using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-07 16:09
    /// 描 述：排查数据表
    /// </summary>
    public class TBL_HAZARDBASICINFO_PC_GDEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 灾害体类型
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        [Column("TOWN")]
        public string TOWN { get; set; }
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }             
        /// <summary>
        /// 排查编号
        /// </summary>
        /// <returns></returns>
        [Column("PCUNIFIEDCODE")]
        public string PCUNIFIEDCODE { get; set; }
        /// <summary>
        /// 统一编号
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// 县/区
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
        /// <summary>
        /// 隐患点位置
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        public string LOCATION { get; set; }
        /// <summary>
        /// 隐患点状态
        /// </summary>
        /// <returns></returns>
        [Column("YHSTATE")]
        public string YHSTATE { get; set; }
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
        /// 灾害体规模
        /// </summary>
        /// <returns></returns>
        [Column("SCALE")]
        public string SCALE { get; set; }
        /// <summary>
        /// 稳定性
        /// </summary>
        /// <returns></returns>
        [Column("CURSTABLESTATUS")]
        public string CURSTABLESTATUS { get; set; }
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
        /// 潜在经济损失/万元
        /// </summary>
        /// <returns></returns>
        [Column("INDIRECTLOSS")]
        public string INDIRECTLOSS { get; set; }
        /// <summary>
        /// 监测责任人
        /// </summary>
        /// <returns></returns>
        [Column("MONITORINGPEOPLE")]
        public string MONITORINGPEOPLE { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE")]
        public string TELEPHONE { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        /// <returns></returns>
        [Column("PHONE")]
        public string PHONE { get; set; }
        /// <summary>
        /// 监测人
        /// </summary>
        /// <returns></returns>
        [Column("JCPEOPLE")]
        public string JCPEOPLE { get; set; }
        /// <summary>
        /// 联系电话1
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE1")]
        public string TELEPHONE1 { get; set; }
        /// <summary>
        /// 手机1
        /// </summary>
        /// <returns></returns>
        [Column("PHONE1")]
        public string PHONE1 { get; set; }
        /// <summary>
        /// 防治对策
        /// </summary>
        /// <returns></returns>
        [Column("COUNTERMEASURES")]
        public string COUNTERMEASURES { get; set; }
        /// <summary>
        /// 有没应急预案
        /// </summary>
        /// <returns></returns>
        [Column("YJPLAN")]
        public string YJPLAN { get; set; }
        /// <summary>
        /// 工作措施
        /// </summary>
        /// <returns></returns>
        [Column("WORKMEASURES")]
        public string WORKMEASURES { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("REMARKS")]
        public string REMARKS { get; set; }
        /// <summary>
        /// 街道/镇
        /// </summary>
        /// <returns></returns>
        [Column("STREET")]
        public string STREET { get; set; }
        /// <summary>
        /// 危害性
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDOBJECT")]
        public string DESTROYEDOBJECT { get; set; }
        /// <summary>
        /// 威胁人员
        /// </summary>
        /// <returns></returns>
        [Column("THREATENPEOPLE")]
        public string THREATENPEOPLE { get; set; }
        /// <summary>
        /// 上报来源（1为手机端）
        /// </summary>
        /// <returns></returns>
        [Column("REPORTLY")]
        public string REPORTLY { get; set; }
        /// <summary>
        /// 上传人
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADER")]
        public string UPLOADER { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENDATE")]
        public DateTime? HAPPENDATE { get; set; }
        /// <summary>
        /// 排查时间
        /// </summary>
        /// <returns></returns>
        [Column("PCTIME")]
        public DateTime? PCTIME { get; set; }
        /// <summary>
        /// 填报时间
        /// </summary>
        /// <returns></returns>
        [Column("FILETIME")]
        public DateTime? FILETIME { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        /// <returns></returns>
        [Column("SHTIME")]
        public DateTime? SHTIME { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        /// <returns></returns>
        [Column("VERIFYPEOPLE")]
        public string VERIFYPEOPLE { get; set; }
        /// <summary>
        /// 审核意见
        /// </summary>
        /// <returns></returns>
        [Column("SHOPINION")]
        public string SHOPINION { get; set; }
        /// <summary>
        /// 发现时间
        /// </summary>
        /// <returns></returns>
        [Column("OCCURREDTIME")]
        public DateTime? OCCURREDTIME { get; set; }
        /// <summary>
        /// 填报人
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEPEOPLE")]
        public string FILLTABLEPEOPLE { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.PCUNIFIEDCODE = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.PCUNIFIEDCODE = keyValue;
        }
        #endregion
    }
}