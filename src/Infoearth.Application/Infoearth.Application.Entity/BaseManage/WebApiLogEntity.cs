using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;
using Newtonsoft.Json;
using Infoearth.Util;

namespace Infoearth.Application.Entity.BaseManage
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 
    /// 创 建：超级管理员
    /// 日 期：2017-07-28 10:00
    /// 描 述：Base_WebApiLog
    /// </summary>
    public class WebApiLogEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// F_LogId
        /// </summary>
        /// <returns></returns>
        [Column("F_LOGID")]
        public string F_LogId { get; set; }
        /// <summary>
        /// F_WebApiUrl
        /// </summary>
        /// <returns></returns>
        [Column("F_WEBAPIURL")]
        public string F_WebApiUrl { get; set; }
        /// <summary>
        /// F_ExecuteStartTime
        /// </summary>
        /// <returns></returns>
        [Column("F_EXECUTESTARTTIME")]
        //[JsonConverter(typeof(DateTimeConverter))]
        public DateTime? F_ExecuteStartTime { get; set; }
        /// <summary>
        /// F_ExecuteEndTime
        /// </summary>
        /// <returns></returns>
        [Column("F_EXECUTEENDTIME")]
        //[JsonConverter(typeof(DateTimeConverter))]
        public DateTime? F_ExecuteEndTime { get; set; }
        /// <summary>
        /// F_MethodParam
        /// </summary>
        /// <returns></returns>
        [Column("F_METHODPARAM")]
        public string F_MethodParam { get; set; }
        /// <summary>
        /// F_ExecuteTime
        /// </summary>
        /// <returns></returns>
        [Column("F_EXECUTETIME")]
        public decimal? F_ExecuteTime { get; set; }
        /// <summary>
        /// F_HttpRequestHeaders
        /// </summary>
        /// <returns></returns>
        [Column("F_HTTPREQUESTHEADERS")]
        public string F_HttpRequestHeaders { get; set; }
        /// <summary>
        /// F_HttpMethod
        /// </summary>
        /// <returns></returns>
        [Column("F_HTTPMETHOD")]
        public string F_HttpMethod { get; set; }
        /// <summary>
        /// F_IP
        /// </summary>
        /// <returns></returns>
        [Column("F_IP")]
        public string F_IP { get; set; }
        /// <summary>
        /// F_Result
        /// </summary>
        /// <returns></returns>
        [Column("F_RESULT")]
        public string F_Result { get; set; }
        /// <summary>
        /// F_Exception
        /// </summary>
        /// <returns></returns>
        [Column("F_EXCEPTION")]
        public string F_Exception { get; set; }
        /// <summary>
        /// F_OperateUserId
        /// </summary>
        /// <returns></returns>
        [Column("F_OPERATEUSERID")]
        public string F_OperateUserId { get; set; }
        /// <summary>
        /// F_OperateAccount
        /// </summary>
        /// <returns></returns>
        [Column("F_OPERATEACCOUNT")]
        public string F_OperateAccount { get; set; }
        /// <summary>
        /// F_ExecuteCount
        /// </summary>
        /// <returns></returns>
        [Column("F_EXECUTECOUNT")]
        public decimal? F_ExecuteCount { get; set; }

        [Column("F_LOGTIME")]
        //[JsonConverter(typeof(DateTimeConverter))]
        public DateTime? F_LogTime { get; set; }

        [Column("F_FULLURL")]
        public string F_FullUrl { get; set; }
        [Column("F_STAUE")]
        public string F_STAUE { get; set; }

        /// <summary>
        /// F_SYSTEMNAME
        /// </summary>
        /// <returns></returns>
        [Column("F_SYSTEMNAME")]
        public string F_SYSTEMNAME { get; set; }

        /// <summary>
        /// F_CLASSNAME
        /// </summary>
        /// <returns></returns>
        [Column("F_CLASSNAME")]
        public string F_CLASSNAME { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.F_LogId = Guid.NewGuid().ToString();
            this.F_LogTime = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_LogId = keyValue;
        }
        #endregion
    }
}