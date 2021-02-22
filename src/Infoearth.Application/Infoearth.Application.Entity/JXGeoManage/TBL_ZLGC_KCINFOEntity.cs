using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:30
    /// 描 述：治理工程-野外勘察
    /// </summary>
    public class TBL_ZLGC_KCINFOEntity : BaseEntity
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
        /// 勘察单位
        /// </summary>
        /// <returns></returns>
        [Column("KCDW")]
        public string KCDW { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <returns></returns>
        [Column("LXDH")]
        public string LXDH { get; set; }
        /// <summary>
        /// 勘察费用(万元)
        /// </summary>
        /// <returns></returns>
        [Column("KCFY")]
        public decimal? KCFY { get; set; }
        /// <summary>
        /// 勘察开始时间
        /// </summary>
        /// <returns></returns>
        [Column("KCKSSJ")]
        public DateTime? KCKSSJ { get; set; }
        /// <summary>
        /// 勘察结束时间
        /// </summary>
        /// <returns></returns>
        [Column("KCJSSJ")]
        public DateTime? KCJSSJ { get; set; }
        /// <summary>
        /// 合同签订时间
        /// </summary>
        /// <returns></returns>
        [Column("HTQDSJ")]
        public DateTime? HTQDSJ { get; set; }
        /// <summary>
        /// 招标时间
        /// </summary>
        /// <returns></returns>
        [Column("ZHAOBIAOSJ")]
        public DateTime? ZHAOBIAOSJ { get; set; }
        /// <summary>
        /// 中标时间
        /// </summary>
        /// <returns></returns>
        [Column("ZHONGBIAOSJ")]
        public DateTime? ZHONGBIAOSJ { get; set; }
        /// <summary>
        /// 勘察审查专家
        /// </summary>
        /// <returns></returns>
        [Column("KCSCZJ")]
        public string KCSCZJ { get; set; }
        /// <summary>
        /// 勘察审查时间
        /// </summary>
        /// <returns></returns>
        [Column("KCSCSJ")]
        public DateTime? KCSCSJ { get; set; }
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