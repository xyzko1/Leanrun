using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-28 16:05
    /// 描 述：统计公用报表
    /// </summary>
    public class TBL_REPORTEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键ID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 报表名称
        /// </summary>
        /// <returns></returns>
        [Column("REPORTNAME")]
        public string REPORTNAME { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public DateTime? CREATETIME { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        [Column("CREATEPEOPLE")]
        public string CREATEPEOPLE { get; set; }
        /// <summary>
        /// 统计条件（后台）
        /// </summary>
        /// <returns></returns>
        [Column("QUERYSTRING")]
        public string QUERYSTRING { get; set; }
        /// <summary>
        /// 显示条件（前端）
        /// </summary>
        /// <returns></returns>
        [Column("CONDITION")]
        public string CONDITION { get; set; }
        /// <summary>
        /// 报表模块
        /// </summary>
        /// <returns></returns>
        [Column("MODULE")]
        public string MODULE { get; set; }
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