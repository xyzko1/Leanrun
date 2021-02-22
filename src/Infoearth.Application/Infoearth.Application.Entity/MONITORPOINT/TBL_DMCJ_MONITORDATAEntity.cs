using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.MONITORPOINT
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-26 16:55
    /// 描 述：地面沉降监测数据
    /// </summary>
    public class TBL_DMCJ_MONITORDATAEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 监测点编号
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTID")]
        public string MONITORPOINTID { get; set; }
        /// <summary>
        /// 监测值(如高程)
        /// </summary>
        /// <returns></returns>
        [Column("VALUE")]
        public Decimal? VALUE { get; set; }
        /// <summary>
        /// 监测时间
        /// </summary>
        /// <returns></returns>
        [Column("MONITORTIME")]
        public System.DateTime? MONITORTIME { get; set; }
        /// <summary>
        /// 监测类别
        /// </summary>
        /// <returns></returns>
        [Column("MONITORTYPE")]
        public string MONITORTYPE { get; set; }
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
    public class TBL_DMCJ_MONITORDATAQuery
    {
        #region 实体成员
        [Desc("监测点名称")]
        public string MONITORPOINTNAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 监测点编号
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTID")]
        [Desc("监测点编号")]
        public string MONITORPOINTID { get; set; }
        /// <summary>
        /// 监测值(如高程)
        /// </summary>
        /// <returns></returns>
        [Column("VALUE")]
        [Desc("监测值")]
        public Decimal? VALUE { get; set; }
        /// <summary>
        /// 监测时间
        /// </summary>
        /// <returns></returns>
        [Column("MONITORTIME")]
        [Desc("监测时间")]
        public System.DateTime? MONITORTIME { get; set; }
        /// <summary>
        /// 监测类别
        /// </summary>
        /// <returns></returns>
        [Column("MONITORTYPE")]
        public string MONITORTYPE { get; set; }
        #endregion
    }
}