using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-28 14:23
    /// 描 述：范围数据表
    /// </summary>
    public class TBL_SPATIALINFOEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("SPATIALID")]
        public string SPATIALID { get; set; }
        /// <summary>
        /// 图层名称
        /// </summary>
        /// <returns></returns>
        [Column("SPATIALNAME")]
        public string SPATIALNAME { get; set; }
        /// <summary>
        ///  拐点坐标
        /// </summary>
        /// <returns></returns>
        [Column("BOUNDARY")]
        public string BOUNDARY { get; set; }
        /// <summary>
        /// 图层ID
        /// </summary>
        /// <returns></returns>
        [Column("LAYERID")]
        public string LAYERID { get; set; }
        /// <summary>
        ///  样式ID
        /// </summary>
        /// <returns></returns>
        [Column("STYLEID")]
        public string STYLEID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        /// <returns></returns>
        [Column("DESCRIBE")]
        public string DESCRIBE { get; set; }
        /// <summary>
        /// 灾害点ID
        /// </summary>
        /// <returns></returns>
        [Column("SUBCODE")]
        public string SUBCODE { get; set; }
        /// <summary>
        /// 类型（GeoDisaster）
        /// </summary>
        /// <returns></returns>
        [Column("SUBTYPE")]
        public string SUBTYPE { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.SPATIALID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.SPATIALID = keyValue;
        }
        #endregion
    }
}