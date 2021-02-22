using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.DMCJManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-09-04 12:02
    /// 描 述：地面沉降调查表SUB
    /// </summary>
    public class TBL_DMCJ_BASEINFO_SUBEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 地面沉降编号
        /// </summary>
        /// <returns></returns>
        [Column("DMCJBH")]
        public string DMCJBH { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水开采-开采层位
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCCW")]
        public string CJQDXSKCCW { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水开采-开采时间
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCSJ")]
        public System.DateTime? CJQDXSKCSJ { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水开采-开采井数量(眼)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCJSL")]
        public decimal? CJQDXSKCJSL { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水开采-开采井深度(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCJSD")]
        public decimal? CJQDXSKCJSD { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水开采-开采量(m3/a)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCL1")]
        public decimal? CJQDXSKCL1 { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水开采-开采量(m3/d)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCL2")]
        public decimal? CJQDXSKCL2 { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水位-开采前水位(头)高程(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCQSW")]
        public decimal? CJQDXSKCQSW { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水位-漏斗中心水位(头)高程(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSLDZXSW")]
        public decimal? CJQDXSLDZXSW { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水位回灌-回灌层位
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGCW")]
        public string CJQDXSHGCW { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水位回灌-回灌时间
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGSJ")]
        public System.DateTime? CJQDXSHGSJ { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水位回灌-回灌井数量(眼)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGJSL")]
        public decimal? CJQDXSHGJSL { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水位回灌-回灌井深度(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGJSD")]
        public decimal? CJQDXSHGJSD { get; set; }
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