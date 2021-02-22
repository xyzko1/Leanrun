using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-28 14:24
    /// 描 述：范围图层样式表
    /// </summary>
    public class TBL_SPATIALRENDERSTYLEEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("STYLEID")]
        public string STYLEID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("LINEWIDTH")]
        public string LINEWIDTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("LINECOLOR")]
        public string LINECOLOR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("LINETRANSPARENCY")]
        public string LINETRANSPARENCY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("FILLCOLOR")]
        public string FILLCOLOR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("ISFILL")]
        public string ISFILL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("FILLTRANSPARENCY")]
        public string FILLTRANSPARENCY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("ISLINEFRAME")]
        public string ISLINEFRAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("REMARKS")]
        public string REMARKS { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.STYLEID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.STYLEID = keyValue;
        }
        #endregion
    }
}