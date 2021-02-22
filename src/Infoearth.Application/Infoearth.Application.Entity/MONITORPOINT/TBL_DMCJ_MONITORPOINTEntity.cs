using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.MONITORPOINT
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-22 18:23
    /// 描 述：地面沉降监测点信息表
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 监测点编号
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTID")]
        [Desc("监测点编号")]
        public string MONITORPOINTID { get; set; }
        /// <summary>
        /// 监测点名称
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTNAME")]
        [Desc("监测点名称")]
        public string MONITORPOINTNAME { get; set; }
        /// <summary>
        /// 地面沉降名称
        /// </summary>
        /// <returns></returns>
        [Column("DMCJNAME")]
        [Desc("地面沉降名称")]
        public string DMCJNAME { get; set; }
        /// <summary>
        /// 地面沉降编号
        /// </summary>
        /// <returns></returns>
        [Column("DMCJBH")]
        [Desc("地面沉降编号")]
        public string DMCJBH { get; set; }
        /// <summary>
        /// 监测点类别
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTTYPE")]
        [Desc("监测点类别")]
        public string MONITORPOINTTYPE { get; set; }
        /// <summary>
        /// 监测点等级
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTLEVEL")]
        [Desc("监测点等级", "MONITORPOINTLEVEL")]
        public string MONITORPOINTLEVEL { get; set; }
        /// <summary>
        /// 建设单位
        /// </summary>
        /// <returns></returns>
        [Column("BUILDDEPT")]
        public string BUILDDEPT { get; set; }
        /// <summary>
        /// 建设时间
        /// </summary>
        /// <returns></returns>
        [Column("BUILDTIME")]
        public DateTime? BUILDTIME { get; set; }
        /// <summary>
        /// 监测点位置
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        public string LOCATION { get; set; }
        /// <summary>
        /// 行政区划编号
        /// </summary>
        /// <returns></returns>
        [Column("AREACODE")]
        public string AREACODE { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        public decimal? LATITUDE { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        public decimal? LONGITUDE { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            //this.MONITORPOINTID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            //this.MONITORPOINTID = keyValue;
        }
        #endregion
    }
}