using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:23
    /// 描 述：群测群防工作明白卡
    /// </summary>
    public class TBL_QCQF_WORKUNDERSTANDCARDEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 灾害点编号
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// CGH灾害点编号
        /// </summary>
        /// <returns></returns>
        [Column("CGHUNIFIEDCODE")]
        public string CGHUNIFIEDCODE { get; set; }
        /// <summary>
        /// 类型及规模
        /// </summary>
        /// <returns></returns>
        [Column("TYPEANDSIZE")]
        public string TYPEANDSIZE { get; set; }
        /// <summary>
        /// 监测负责人
        /// </summary>
        /// <returns></returns>
        [Column("MONITORHEADER")]
        public string MONITORHEADER { get; set; }
        /// <summary>
        /// 负责人联系电话
        /// </summary>
        /// <returns></returns>
        [Column("MONITORHEADERTEL")]
        public string MONITORHEADERTEL { get; set; }
        /// <summary>
        /// 主要迹象
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMAJORSIGNS")]
        public string MONITORMAJORSIGNS { get; set; }
        /// <summary>
        /// 主要手段和方法
        /// </summary>
        /// <returns></returns>
        [Column("MONITORMEANSMETHODS")]
        public string MONITORMEANSMETHODS { get; set; }
        /// <summary>
        /// 疏散命令发布人
        /// </summary>
        /// <returns></returns>
        [Column("EVACUATIONCOMMANDPUBLISHER")]
        public string EVACUATIONCOMMANDPUBLISHER { get; set; }
        /// <summary>
        /// 疏散值班电话
        /// </summary>
        /// <returns></returns>
        [Column("EVACUATIONDUTYPHONE")]
        public string EVACUATIONDUTYPHONE { get; set; }
        /// <summary>
        /// 抢排险单位负责人
        /// </summary>
        /// <returns></returns>
        [Column("RISKUNITANDHEADER")]
        public string RISKUNITANDHEADER { get; set; }
        /// <summary>
        /// 抢排线值班电话
        /// </summary>
        /// <returns></returns>
        [Column("RISKDUTYPHONE")]
        public string RISKDUTYPHONE { get; set; }
        /// <summary>
        /// 治安保卫单位负责人
        /// </summary>
        /// <returns></returns>
        [Column("PUBLICSECURITYUNITANDHEADER")]
        public string PUBLICSECURITYUNITANDHEADER { get; set; }
        /// <summary>
        /// 治安保卫值班电话
        /// </summary>
        /// <returns></returns>
        [Column("PUBLICSECURITYDUTYPHONE")]
        public string PUBLICSECURITYDUTYPHONE { get; set; }
        /// <summary>
        /// 医疗救护单位负责人
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALCAREUNITHEADER")]
        public string MEDICALCAREUNITHEADER { get; set; }
        /// <summary>
        /// 医疗救护值班电话
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALCAREDUTYPHONE")]
        public string MEDICALCAREDUTYPHONE { get; set; }
        /// <summary>
        /// 本卡发放单位
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNIT")]
        public string CARDRELEASUNIT { get; set; }
        /// <summary>
        /// 发放单位联系电话
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNITTEL")]
        public string CARDRELEASUNITTEL { get; set; }
        /// <summary>
        /// 发放日期
        /// </summary>
        /// <returns></returns>
        [Column("RELEASEDATE")]
        public string RELEASEDATE { get; set; }
        /// <summary>
        /// 持卡单位或个人
        /// </summary>
        /// <returns></returns>
        [Column("CARDUNITSINDIVIDUALS")]
        public string CARDUNITSINDIVIDUALS { get; set; }
        /// <summary>
        /// 持卡单位或个人联系电话
        /// </summary>
        /// <returns></returns>
        [Column("CARDUNITSINDIVIDUALSTEL")]
        public string CARDUNITSINDIVIDUALSTEL { get; set; }
        /// <summary>
        /// 持卡日期
        /// </summary>
        /// <returns></returns>
        [Column("DATECARD")]
        public string DATECARD { get; set; }
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
        /// 监测负责人ID
        /// </summary>
        /// <returns></returns>
        [Column("MONITORHEADERID")]
        public string MONITORHEADERID { get; set; }
        /// <summary>
        /// 疏散命令发布人ID
        /// </summary>
        /// <returns></returns>
        [Column("EVACUATIONCOMMANDPUBLISHERID")]
        public string EVACUATIONCOMMANDPUBLISHERID { get; set; }
        /// <summary>
        /// 抢排险单位负责人ID
        /// </summary>
        /// <returns></returns>
        [Column("RISKUNITANDHEADERID")]
        public string RISKUNITANDHEADERID { get; set; }
        /// <summary>
        /// 治安保卫单位负责人ID
        /// </summary>
        /// <returns></returns>
        [Column("PUBLICSECURITYUNITANDHEADERID")]
        public string PUBLICSECURITYUNITANDHEADERID { get; set; }
        /// <summary>
        /// 医疗救护单位负责人ID
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALCAREUNITHEADERID")]
        public string MEDICALCAREUNITHEADERID { get; set; }
        /// <summary>
        /// 本卡发放单位ID
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNITID")]
        public string CARDRELEASUNITID { get; set; }
        /// <summary>
        /// 抢排险单位
        /// </summary>
        /// <returns></returns>
        [Column("RISKUNIT")]
        public string RISKUNIT { get; set; }
        /// <summary>
        /// 抢排险单位ID
        /// </summary>
        /// <returns></returns>
        [Column("RISKUNITID")]
        public string RISKUNITID { get; set; }
        /// <summary>
        /// 治安保卫单位
        /// </summary>
        /// <returns></returns>
        [Column("PUBLICSECURITYUNIT")]
        public string PUBLICSECURITYUNIT { get; set; }
        /// <summary>
        /// 治安保卫单位ID
        /// </summary>
        /// <returns></returns>
        [Column("PUBLICSECURITYUNITID")]
        public string PUBLICSECURITYUNITID { get; set; }
        /// <summary>
        /// 医疗救护单位
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALCAREUNIT")]
        public string MEDICALCAREUNIT { get; set; }
        /// <summary>
        /// 医疗救护单位ID
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALCAREUNITID")]
        public string MEDICALCAREUNITID { get; set; }
        /// <summary>
        /// 保存多媒体使用
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
}