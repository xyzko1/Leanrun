using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-05-25 16:29
    /// 描 述：防治规划成果表
    /// </summary>
    public class TBL_ACHIEVEMENT_PREPLANEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 成果名称
        /// </summary>
        /// <returns></returns>
        [Column("ACHIEVEMENTNAME")]
        public string ACHIEVEMENTNAME { get; set; }
        /// <summary>
        /// 规划区域类型（A-国家规划B-地区规划C-流域规划）
        /// </summary>
        /// <returns></returns>
        [Column("AREATYPE")]
        public string AREATYPE { get; set; }
        /// <summary>
        /// 规划时间类型（A-超长期规划B-长期规划C-中期规划D-短期规划）
        /// </summary>
        /// <returns></returns>
        [Column("TIMETYPE")]
        public string TIMETYPE { get; set; }
        /// <summary>
        /// 地质灾害类型（A-单类地质灾害防治规划B-综合地质灾害防治规划）
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        /// <summary>
        /// 防治内容
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTION")]
        public string PREVENTION { get; set; }
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
        /// 防治原则和目标
        /// </summary>
        /// <returns></returns>
        [Column("PRINCIPLEGOAL")]
        public string PRINCIPLEGOAL { get; set; }
        /// <summary>
        /// 总体部署和主要任务
        /// </summary>
        /// <returns></returns>
        [Column("MAINTAST")]
        public string MAINTAST { get; set; }
        /// <summary>
        /// 防治预期效果
        /// </summary>
        /// <returns></returns>
        [Column("DESIREDRESULT")]
        public string DESIREDRESULT { get; set; }
        /// <summary>
        /// 易发区域
        /// </summary>
        /// <returns></returns>
        [Column("PRONEAREA")]
        public string PRONEAREA { get; set; }
        /// <summary>
        /// 重点防治区域
        /// </summary>
        /// <returns></returns>
        [Column("MAINPREVENTAREA")]
        public string MAINPREVENTAREA { get; set; }
        /// <summary>
        /// 灾害点名称
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERNAME")]
        public string DISASTERNAME { get; set; }
        /// <summary>
        /// 方案编写人
        /// </summary>
        /// <returns></returns>
        [Column("WRITENAME")]
        public string WRITENAME { get; set; }
        /// <summary>
        /// 方案录入人
        /// </summary>
        /// <returns></returns>
        [Column("CREATENAME")]
        public string CREATENAME { get; set; }
        /// <summary>
        /// 方案编写日期
        /// </summary>
        /// <returns></returns>
        [Column("WRITETIME")]
        public DateTime? WRITETIME { get; set; }
        /// <summary>
        /// 方案录入日期
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public DateTime? CREATETIME { get; set; }
        /// <summary>
        /// 方案版本号
        /// </summary>
        /// <returns></returns>
        [Column("VESION")]
        public string VESION { get; set; }
        /// <summary>
        /// 灾害点编号
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
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
        /// 乡镇名称
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
        /// <summary>
        /// 县名称
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
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