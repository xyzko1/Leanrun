using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:21
    /// 描 述：群测群防避灾明白卡
    /// </summary>
    public class TBL_QCQF_ESCUNDERSTANDCARDEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
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
        /// 规模
        /// </summary>
        /// <returns></returns>
        [Column("SCALE")]
        public string SCALE { get; set; }
        /// <summary>
        /// 规模等级
        /// </summary>
        /// <returns></returns>
        [Column("SCALELEVEL")]
        public string SCALELEVEL { get; set; }
        /// <summary>
        /// 本住户注意事项
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEHOLDNOTES")]
        public string HOUSEHOLDNOTES { get; set; }
        /// <summary>
        /// 撤离路线
        /// </summary>
        /// <returns></returns>
        [Column("LEAVEROUTES")]
        public string LEAVEROUTES { get; set; }
        /// <summary>
        /// 本卡发放单位
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNIT")]
        public string CARDRELEASUNIT { get; set; }
        /// <summary>
        /// 发放单位负责人
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNITHEADER")]
        public string CARDRELEASUNITHEADER { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNITTEL")]
        public string CARDRELEASUNITTEL { get; set; }
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
        public DateTime? CREATORTIME2 { get; set; }
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
        /// 户主姓名
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEHOLDERNAME")]
        public string HOUSEHOLDERNAME { get; set; }
        /// <summary>
        /// 家庭人数
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEHOLDSIZE")]
        public short? HOUSEHOLDSIZE { get; set; }
        /// <summary>
        /// 房屋类型
        /// </summary>
        /// <returns></returns>
        [Column("HOUSINGTYPE")]
        public string HOUSINGTYPE { get; set; }
        /// <summary>
        /// 家庭住址
        /// </summary>
        /// <returns></returns>
        [Column("ADDRESS")]
        public string ADDRESS { get; set; }
        /// <summary>
        /// 姓名1
        /// </summary>
        /// <returns></returns>
        [Column("NAME1")]
        public string NAME1 { get; set; }
        /// <summary>
        /// 姓名2
        /// </summary>
        /// <returns></returns>
        [Column("NAME2")]
        public string NAME2 { get; set; }
        /// <summary>
        /// 姓名3
        /// </summary>
        /// <returns></returns>
        [Column("NAME3")]
        public string NAME3 { get; set; }
        /// <summary>
        /// 姓名4
        /// </summary>
        /// <returns></returns>
        [Column("NAME4")]
        public string NAME4 { get; set; }
        /// <summary>
        /// 姓名5
        /// </summary>
        /// <returns></returns>
        [Column("NAME5")]
        public string NAME5 { get; set; }
        /// <summary>
        /// 姓名6
        /// </summary>
        /// <returns></returns>
        [Column("NAME6")]
        public string NAME6 { get; set; }
        /// <summary>
        /// 姓名7
        /// </summary>
        /// <returns></returns>
        [Column("NAME7")]
        public string NAME7 { get; set; }
        /// <summary>
        /// 姓名8
        /// </summary>
        /// <returns></returns>
        [Column("NAME8")]
        public string NAME8 { get; set; }
        /// <summary>
        /// 性别1
        /// </summary>
        /// <returns></returns>
        [Column("SEX1")]
        public string SEX1 { get; set; }
        /// <summary>
        /// 性别2
        /// </summary>
        /// <returns></returns>
        [Column("SEX2")]
        public string SEX2 { get; set; }
        /// <summary>
        /// 性别3
        /// </summary>
        /// <returns></returns>
        [Column("SEX3")]
        public string SEX3 { get; set; }
        /// <summary>
        /// 性别4
        /// </summary>
        /// <returns></returns>
        [Column("SEX4")]
        public string SEX4 { get; set; }
        /// <summary>
        /// 性别5
        /// </summary>
        /// <returns></returns>
        [Column("SEX5")]
        public string SEX5 { get; set; }
        /// <summary>
        /// 性别6
        /// </summary>
        /// <returns></returns>
        [Column("SEX6")]
        public string SEX6 { get; set; }
        /// <summary>
        /// 性别7
        /// </summary>
        /// <returns></returns>
        [Column("SEX7")]
        public string SEX7 { get; set; }
        /// <summary>
        /// 性别8
        /// </summary>
        /// <returns></returns>
        [Column("SEX8")]
        public string SEX8 { get; set; }
        /// <summary>
        /// 出生日期1
        /// </summary>
        /// <returns></returns>
        [Column("AGE1")]
        public DateTime? AGE1 { get; set; }
        /// <summary>
        /// 出生日期2
        /// </summary>
        /// <returns></returns>
        [Column("AGE2")]
        public DateTime? AGE2 { get; set; }
        /// <summary>
        /// 出生日期3
        /// </summary>
        /// <returns></returns>
        [Column("AGE3")]
        public DateTime? AGE3 { get; set; }
        /// <summary>
        /// 出生日期4
        /// </summary>
        /// <returns></returns>
        [Column("AGE4")]
        public DateTime? AGE4 { get; set; }
        /// <summary>
        /// 出生日期5
        /// </summary>
        /// <returns></returns>
        [Column("AGE5")]
        public DateTime? AGE5 { get; set; }
        /// <summary>
        /// 出生日期6
        /// </summary>
        /// <returns></returns>
        [Column("AGE6")]
        public DateTime? AGE6 { get; set; }
        /// <summary>
        /// 出生日期7
        /// </summary>
        /// <returns></returns>
        [Column("AGE7")]
        public DateTime? AGE7 { get; set; }
        /// <summary>
        /// 出生日期8
        /// </summary>
        /// <returns></returns>
        [Column("AGE8")]
        public DateTime? AGE8 { get; set; }
        /// <summary>
        /// 本卡发放单位ID
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNITID")]
        public string CARDRELEASUNITID { get; set; }
        /// <summary>
        /// 发放单位负责人ID
        /// </summary>
        /// <returns></returns>
        [Column("CARDRELEASUNITHEADERID")]
        public string CARDRELEASUNITHEADERID { get; set; }
        /// <summary>
        /// 灾害体与本住户的位置关系
        /// </summary>
        /// <returns></returns>
        [Column("POSITIONALRELATIONSHIP")]
        public string POSITIONALRELATIONSHIP { get; set; }
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