using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infoearth.Application.Entity.MessageManage
{
	/// <summary>
    /// 即时消息表
	/// <author>
    ///		<name>she</name>
    ///		<date>2015.08.01 14:00</date>
    /// </author>
    /// </summary>
    public class IMContentEntity : BaseEntity
	{
        #region 实体成员
        /// <summary>
        /// 消息主键
        /// </summary>
        /// <returns></returns>
        [Column("F_CONTENTID")]
        public string F_ContentId { get; set; }
        /// <summary>
        /// 是否群组消息
        /// </summary>
        /// <returns></returns>
        [Column("F_ISGROUP")]
        public int? F_IsGroup { get; set; }
        /// <summary>
        /// 发送者ID
        /// </summary>
        /// <returns></returns>
        [Column("F_SENDID")]
        public string F_SendId { get; set; }
        /// <summary>
        /// 接收者ID
        /// </summary>
        /// <returns></returns>
        [Column("F_TOID")]
        public string F_ToId { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        /// <returns></returns>
        [Column("F_MSGCONTENT")]
        public string F_MsgContent { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 消息标题
        /// </summary>
        /// <returns></returns>
        [Column("F_MSGTITLE")]
        public string F_MSGTITLE { get; set; }
        /// <summary>
        /// 跳转路径
        /// </summary>
        /// <returns></returns>
        [Column("F_MSGURL")]
        public string F_MSGURL { get; set; }
        #endregion
   		
   		#region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.F_ContentId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_ContentId = keyValue;
        }
        #endregion
	}
}