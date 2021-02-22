using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-28 13:52
    /// 描 述：范围图层管理
    /// </summary>
    public class TBL_SPATIALEDITLAYEREntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 图层ID
        /// </summary>
        /// <returns></returns>
        [Column("LAYERID")]
        public string LAYERID { get; set; }
        /// <summary>
        /// 图层名称
        /// </summary>
        /// <returns></returns>
        [Column("LAYERNAME")]
        public string LAYERNAME { get; set; }
        /// <summary>
        /// 范围名称
        /// </summary>
        /// <returns></returns>
        [Column("DESCRIBE")]
        public string DESCRIBE { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        /// <returns></returns>
        [Column("MOUDLEID")]
        public string MOUDLEID { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.LAYERID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.LAYERID = keyValue;
        }
        #endregion
    }
}