using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:31
    /// 描 述：治理工程-验收
    /// </summary>
    public class TBL_ZLGC_YSINFOEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 治理工程编号
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCID")]
        public string ZLGCID { get; set; }
        [Column("MEDIAGUID")]
        public string MEDIAGUID { get; set; }
        /// <summary>
        /// 治理工程名称
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCNAME")]
        public string ZLGCNAME { get; set; }
        /// <summary>
        /// 初验验收单位
        /// </summary>
        /// <returns></returns>
        [Column("CYDEPT")]
        public string CYDEPT { get; set; }
        /// <summary>
        /// 初验验收时间
        /// </summary>
        /// <returns></returns>
        [Column("CYTIME")]
        public DateTime? CYTIME { get; set; }
        /// <summary>
        /// 初验验收地点
        /// </summary>
        /// <returns></returns>
        [Column("CYPLACE")]
        public string CYPLACE { get; set; }
        /// <summary>
        /// 初验验收专家
        /// </summary>
        /// <returns></returns>
        [Column("CYZJ")]
        public string CYZJ { get; set; }
        /// <summary>
        /// 初验验收批文
        /// </summary>
        /// <returns></returns>
        [Column("CYPW")]
        public string CYPW { get; set; }
        /// <summary>
        /// 终验验收单位
        /// </summary>
        /// <returns></returns>
        [Column("ZYDEPT")]
        public string ZYDEPT { get; set; }
        /// <summary>
        /// 终验验收时间
        /// </summary>
        /// <returns></returns>
        [Column("ZYTIME")]
        public DateTime? ZYTIME { get; set; }
        /// <summary>
        /// 终验验收地点
        /// </summary>
        /// <returns></returns>
        [Column("ZYPLACE")]
        public string ZYPLACE { get; set; }
        /// <summary>
        /// 终验验收专家
        /// </summary>
        /// <returns></returns>
        [Column("ZYZJ")]
        public string ZYZJ { get; set; }
        /// <summary>
        /// 终验验收批文
        /// </summary>
        /// <returns></returns>
        [Column("ZYPW")]
        public string ZYPW { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ZLGCID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ZLGCID = keyValue;
        }
        #endregion
    }
}