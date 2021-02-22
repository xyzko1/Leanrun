using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-13 13:27
    /// 描 述：地质灾害危险性评估项目备案登记表
    /// </summary>
    public class TBL_YJDC_RISKASSESSMANAGEEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 项目地点
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTPLACE")]
        public string PROJECTPLACE { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// 县名称
        /// </summary>
        /// <returns></returns>
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        /// <returns></returns>
        [Column("COUNTRYNAME")]
        public string COUNTRYNAME { get; set; }
        /// <summary>
        /// 行政区划编码
        /// </summary>
        /// <returns></returns>
        [Column("DISTRICTCODE")]
        public string DISTRICTCODE { get; set; }
        /// <summary>
        /// 报表名称
        /// </summary>
        /// <returns></returns>
        [Column("REPORTNAME")]
        public string REPORTNAME { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        /// <returns></returns>
        [Column("ASSESSUNIT")]
        public string ASSESSUNIT { get; set; }
        /// <summary>
        /// 专家
        /// </summary>
        /// <returns></returns>
        [Column("ASSESSEXPERT")]
        public string ASSESSEXPERT { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        /// <returns></returns>
        [Column("RECORDTIME")]
        public System.DateTime? RECORDTIME { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        /// <returns></returns>
        [Column("ASSESSLEVEL")]
        public string ASSESSLEVEL { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        /// <returns></returns>
        [Column("ASSESSDEPARTMENT")]
        public string ASSESSDEPARTMENT { get; set; }
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