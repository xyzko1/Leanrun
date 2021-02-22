using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infoearth.Application.Web
{
    /// <summary>
    /// 日志记录的辅助特行
    /// </summary>
    public class LogContentAttribute : Attribute
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OpType OpType { get; set; }

        /// <summary>
        /// 日志记录的辅助信息
        /// </summary>
        /// <param name="Content">内容</param>
        /// <param name="ModuleName">模块名称</param>
        /// <param name="OpType">操作类型</param>
        public LogContentAttribute(string ModuleName, OpType OpType)
        {
            this.ModuleName = ModuleName;
            this.OpType = OpType;
        }
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OpType
    {
        /// <summary>
        /// 查询操作
        /// </summary>
        Query,
        /// <summary>
        /// 删除操作
        /// </summary>
        Delete,
        /// <summary>
        /// 更新操作
        /// </summary>
        Update,
        /// <summary>
        /// 查看详情
        /// </summary>
        Details
    }
}