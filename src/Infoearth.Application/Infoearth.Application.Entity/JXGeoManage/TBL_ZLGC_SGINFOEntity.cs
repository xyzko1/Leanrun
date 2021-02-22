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
    /// 描 述：治理工程-施工
    /// </summary>
    public class TBL_ZLGC_SGINFOEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// guid
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 治理工程编号
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCID")]
        public string ZLGCID { get; set; }
        /// <summary>
        /// 治理工程名称
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCNAME")]
        public string ZLGCNAME { get; set; }
        /// <summary>
        /// 施工单位
        /// </summary>
        /// <returns></returns>
        [Column("SGDEPT")]
        public string SGDEPT { get; set; }
        /// <summary>
        /// 合同签订日期
        /// </summary>
        /// <returns></returns>
        [Column("QDTIME")]
        public DateTime? QDTIME { get; set; }
        /// <summary>
        /// 工程内容
        /// </summary>
        /// <returns></returns>
        [Column("GCCONTENT")]
        public string GCCONTENT { get; set; }
        /// <summary>
        /// 发包形式
        /// </summary>
        /// <returns></returns>
        [Column("FBTYPE")]
        public string FBTYPE { get; set; }
        /// <summary>
        /// 发包金额(万元)
        /// </summary>
        /// <returns></returns>
        [Column("FBJE")]
        public decimal? FBJE { get; set; }
        /// <summary>
        /// 开工日期
        /// </summary>
        /// <returns></returns>
        [Column("STARTTIME")]
        public DateTime? STARTTIME { get; set; }
        /// <summary>
        /// 竣工日期
        /// </summary>
        /// <returns></returns>
        [Column("ENDTIME")]
        public DateTime? ENDTIME { get; set; }
        /// <summary>
        /// 合同地点
        /// </summary>
        /// <returns></returns>
        [Column("QDPLACE")]
        public string QDPLACE { get; set; }
        /// <summary>
        /// 招标时间
        /// </summary>
        /// <returns></returns>
        [Column("ZBTIME")]
        public DateTime? ZBTIME { get; set; }
        /// <summary>
        /// 招标地点
        /// </summary>
        /// <returns></returns>
        [Column("ZBPLACE")]
        public string ZBPLACE { get; set; }
        /// <summary>
        /// 中标时间
        /// </summary>
        /// <returns></returns>
        [Column("GETTIME")]
        public DateTime? GETTIME { get; set; }
        /// <summary>
        /// 施工标段
        /// </summary>
        /// <returns></returns>
        [Column("SGBD")]
        public string SGBD { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        /// <returns></returns>
        [Column("CONTACTPERSON")]
        public string CONTACTPERSON { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <returns></returns>
        [Column("CONTACTTEL")]
        public string CONTACTTEL { get; set; }
        /// <summary>
        /// 资质清单json(资质名称、资质等级、备注)
        /// </summary>
        /// <returns></returns>
        [Column("ZZQD")]
        public string ZZQD { get; set; }
        /// <summary>
        ///MEDIAGUID
        /// </summary>
        /// <returns></returns>
        [Column("MEDIAGUID")]
        public string MEDIAGUID { get; set; }
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