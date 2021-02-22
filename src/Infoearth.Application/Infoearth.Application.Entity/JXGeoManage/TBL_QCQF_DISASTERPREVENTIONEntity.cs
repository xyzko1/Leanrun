using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:19
    /// 描 述：群测群防防灾预案表
    /// </summary>
    public class TBL_QCQF_DISASTERPREVENTIONEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 灾害点编号
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// 曾经发生灾害时间
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTIME")]
        public string DISASTERTIME { get; set; }
        /// <summary>
        /// 地质环境条件
        /// </summary>
        /// <returns></returns>
        [Column("GEOLOGICALENVIRONMENT")]
        public string GEOLOGICALENVIRONMENT { get; set; }
        /// <summary>
        /// 变形特征及历史活动情况
        /// </summary>
        /// <returns></returns>
        [Column("DEFORMATIONHISTORICALE")]
        public string DEFORMATIONHISTORICALE { get; set; }
        /// <summary>
        /// 稳定性分析
        /// </summary>
        /// <returns></returns>
        [Column("STABILITYANALYSIS")]
        public string STABILITYANALYSIS { get; set; }
        /// <summary>
        /// 引发因素
        /// </summary>
        /// <returns></returns>
        [Column("TRIGGERFACTORS")]
        public string TRIGGERFACTORS { get; set; }
        /// <summary>
        /// 潜在危害
        /// </summary>
        /// <returns></returns>
        [Column("POTENTIALHAZARDS")]
        public string POTENTIALHAZARDS { get; set; }
        /// <summary>
        /// 临灾状态预测
        /// </summary>
        /// <returns></returns>
        [Column("STATEPREDICTION")]
        public string STATEPREDICTION { get; set; }
        /// <summary>
        /// 监测方法
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMETHOD")]
        public string MONITORMETHOD { get; set; }
        /// <summary>
        /// 监测周期
        /// </summary>
        /// <returns></returns>
        [Column("MONITORCYCLE")]
        public string MONITORCYCLE { get; set; }
        /// <summary>
        /// 监测责任人
        /// </summary>
        /// <returns></returns>
        [Column("MONITORRESPONSIBLE")]
        public string MONITORRESPONSIBLE { get; set; }
        /// <summary>
        /// 监测责任人电话
        /// </summary>
        /// <returns></returns>
        [Column("MONITORRESPONSIBLETEL")]
        public string MONITORRESPONSIBLETEL { get; set; }
        /// <summary>
        /// 群测群防人员
        /// </summary>
        /// <returns></returns>
        [Column("GROUPMONITORINGSTAFF")]
        public string GROUPMONITORINGSTAFF { get; set; }
        /// <summary>
        /// 群测群防人员电话
        /// </summary>
        /// <returns></returns>
        [Column("GROUPMONITORINGSTAFFTEL")]
        public string GROUPMONITORINGSTAFFTEL { get; set; }
        /// <summary>
        /// 报警方法
        /// </summary>
        /// <returns></returns>
        [Column("ALARMMETHOD")]
        public string ALARMMETHOD { get; set; }
        /// <summary>
        /// 报警信号
        /// </summary>
        /// <returns></returns>
        [Column("ALARMSIGNAL")]
        public string ALARMSIGNAL { get; set; }
        /// <summary>
        /// 报警人
        /// </summary>
        /// <returns></returns>
        [Column("ALARMPEOPLE")]
        public string ALARMPEOPLE { get; set; }
        /// <summary>
        /// 报警人电话
        /// </summary>
        /// <returns></returns>
        [Column("ALARMTEL")]
        public string ALARMTEL { get; set; }
        /// <summary>
        /// 预定避灾地点
        /// </summary>
        /// <returns></returns>
        [Column("BOOKESCAPINGLOCATION")]
        public string BOOKESCAPINGLOCATION { get; set; }
        /// <summary>
        /// 人员撤离路线
        /// </summary>
        /// <returns></returns>
        [Column("EVACUATIONROUTES")]
        public string EVACUATIONROUTES { get; set; }
        /// <summary>
        /// 防治建议
        /// </summary>
        /// <returns></returns>
        [Column("TREATMENTSUGGESTION")]
        public string TREATMENTSUGGESTION { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETIME")]
        public DateTime? UPDATETIME1 { get; set; }
        /// <summary>
        /// 记录状态
        /// </summary>
        /// <returns></returns>
        [Column("RECORDSTATUS")]
        public string RECORDSTATUS1 { get; set; }
        /// <summary>
        /// 导出状态
        /// </summary>
        /// <returns></returns>
        [Column("EXPSTATUS")]
        public string EXPSTATUS1 { get; set; }
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
        public DateTime? CREATORTIME1 { get; set; }
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
        /// 人员撤离路线示意图
        /// </summary>
        /// <returns></returns>
        [Column("EVACUATIONROUTESPIC")]
        public string EVACUATIONROUTESPIC { get; set; }
        /// <summary>
        /// 隐患点类型
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENPOINTTYPE")]
        public string HIDDENPOINTTYPE { get; set; }
        /// <summary>
        /// 监测责任人ID
        /// </summary>
        /// <returns></returns>
        [Column("MONITORRESPONSIBLEID")]
        public string MONITORRESPONSIBLEID { get; set; }
        /// <summary>
        /// 群测群防人员ID
        /// </summary>
        /// <returns></returns>
        [Column("GROUPMONITORINGSTAFFID")]
        public string GROUPMONITORINGSTAFFID { get; set; }
        /// <summary>
        /// 报警人ID
        /// </summary>
        /// <returns></returns>
        [Column("ALARMPEOPLEID")]
        public string ALARMPEOPLEID { get; set; }
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
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
    public class TBL_QCQF_Entity
    {
        public string UNIFIEDCODE { get; set; }
        public string DISASTERNAME { get; set; }
        public string LOCATION { get; set; }
        public string PROVINCE { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITY { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTY { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWN { get; set; }
        public string TOWNNAME { get; set; }
        public string DISASTERTYPE { get; set; }
        public string GROUPMONITORINGSTAFF { get; set; }
        public string GROUPMONITORINGSTAFFTEL { get; set; }
        public string MONITORRESPONSIBLE { get; set; }
        public string MONITORRESPONSIBLETEL { get; set; }
        public string GROUPMONITORINGSTAFFID { get; set; }
    }
}