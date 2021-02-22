using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-17 14:51
    /// 描 述：审核信息表
    /// </summary>
    public class TBL_AUDITINFOEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 业务ID
        /// </summary>
        /// <returns></returns>
        [Column("BUSINESSID")]
        public string BUSINESSID { get; set; }
        /// <summary>
        /// 消息流ID
        /// </summary>
        /// <returns></returns>
        [Column("MSGFLOWID")]
        public string MSGFLOWID { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        /// <returns></returns>
        [Column("UPDATEUSER")]
        public string UPDATEUSER { get; set; }
        /// <summary>
        /// 修改类型（I：批量导入；A：新增记录；U：修改记录；D：删除记录）
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETYPE")]
        public string UPDATETYPE { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETIME")]
        public DateTime? UPDATETIME { get; set; }
        /// <summary>
        /// 状态（0-未提交 1-待审核 2-审核通过 3-审核不通过）
        /// </summary>
        /// <returns></returns>
        [Column("STATUS")]
        public string STATUS { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        /// <returns></returns>
        [Column("AUDITOR")]
        public string AUDITOR { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        /// <returns></returns>
        [Column("AUDITTIME")]
        public DateTime? AUDITTIME { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("REMARK")]
        public string REMARK { get; set; }
        /// <summary>
        /// 匹配字段（表名称）
        /// </summary>
        /// <returns></returns>
        [Column("BASICINFO")]
        public string BASICINFO { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        /// <returns></returns>
        [Column("BUSSNESSTYPE")]
        public string BUSSNESSTYPE { get; set; }

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