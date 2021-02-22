using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-26 14:28
    /// 描 述：统计分析查询语句表
    /// </summary>
    public class TBL_WHAA07CEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 自增长ID
        /// </summary>
        /// <returns></returns>
        [Column("SUMTYPE")]
        public string SUMTYPE { get; set; }
        /// <summary>
        /// 查询的表名称
        /// </summary>
        /// <returns></returns>
        [Column("TABLENAME")]
        public string TABLENAME { get; set; }
        /// <summary>
        /// 统计字段名称
        /// </summary>
        /// <returns></returns>
        [Column("REPORTFIELD")]
        public string REPORTFIELD { get; set; }
        /// <summary>
        /// 统计内容
        /// </summary>
        /// <returns></returns>
        [Column("REPORTTYPE")]
        public string REPORTTYPE { get; set; }
        /// <summary>
        /// 求合语句2
        /// </summary>
        /// <returns></returns>
        [Column("REPORTCLASS")]
        public string REPORTCLASS { get; set; }
        /// <summary>
        /// 统计语句
        /// </summary>
        /// <returns></returns>
        [Column("REPORTVALUE")]
        public string REPORTVALUE { get; set; }
        /// <summary>
        /// 其中灾害类型的求合语句
        /// </summary>
        /// <returns></returns>
        [Column("RPCAPTION")]
        public string RPCAPTION { get; set; }
        /// <summary>
        /// 求合语句1
        /// </summary>
        /// <returns></returns>
        [Column("MEASURE")]
        public string MEASURE { get; set; }
        /// <summary>
        /// 个数
        /// </summary>
        /// <returns></returns>
        [Column("WIDTH")]
        public int? WIDTH { get; set; }
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