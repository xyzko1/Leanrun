using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-13 16:22
    /// 描 述：巡查记录表
    /// </summary>
    public class TBL_QCQF_AROUNDRECORDEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 上报时间
        /// </summary>
        /// <returns></returns>
        [Column("MONITORTIME")]
        public DateTime? MONITORTIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// 新裂缝（1:表示有;0:表示无）
        /// </summary>
        /// <returns></returns>
        [Column("NEWSLIT")]
        public string NEWSLIT { get; set; }
        /// <summary>
        /// 新地鼓（1:表示有;0:表示无）
        /// </summary>
        /// <returns></returns>
        [Column("NEWTODRUM")]
        public string NEWTODRUM { get; set; }
        /// <summary>
        /// 地面塌陷（1:表示有;0:表示无）
        /// </summary>
        /// <returns></returns>
        [Column("NEWSUBSIDE")]
        public string NEWSUBSIDE { get; set; }
        /// <summary>
        /// 小型崩塌（1:表示有;0:表示无）
        /// </summary>
        /// <returns></returns>
        [Column("SMALLCOLLAPSES")]
        public string SMALLCOLLAPSES { get; set; }
        /// <summary>
        /// 房屋变形（1:表示有;0:表示无）
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEDEFORMATION")]
        public string HOUSEDEFORMATION { get; set; }
        /// <summary>
        /// 新泉水及湿地（1:表示有;0:表示无）
        /// </summary>
        /// <returns></returns>
        [Column("NEWSPRING")]
        public string NEWSPRING { get; set; }
        /// <summary>
        /// 井塘漏水（1:表示有;0:表示无）
        /// </summary>
        /// <returns></returns>
        [Column("WELLLEAK")]
        public string WELLLEAK { get; set; }
        /// <summary>
        /// 树形歪斜（1:表示有;0:表示无）
        /// </summary>
        /// <returns></returns>
        [Column("TREESSKEW")]
        public string TREESSKEW { get; set; }
        /// <summary>
        /// 地声（1:表示有;0:表示无）
        /// </summary>
        /// <returns></returns>
        [Column("UNDEDERVOICE")]
        public string UNDEDERVOICE { get; set; }
        /// <summary>
        /// 动物异常（1:表示有;0:表示无）
        /// </summary>
        /// <returns></returns>
        [Column("ANIMALSABNORMAL")]
        public string ANIMALSABNORMAL { get; set; }
        /// <summary>
        /// 备注（1:表示有;0:表示无）
        /// </summary>
        /// <returns></returns>
        [Column("REMARK")]
        public string REMARK { get; set; }
        /// <summary>
        /// 观测人ID（1:表示有;0:表示无）
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// 上传经度
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADLONGITUDE")]
        public decimal? UPLOADLONGITUDE { get; set; }
        /// <summary>
        /// 上传纬度
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADLATITUDE")]
        public decimal? UPLOADLATITUDE { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        /// <returns></returns>
        [Column("SOURCETYPE")]
        public string SOURCETYPE { get; set; }
        /// <summary>
        /// 上传人ID
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADID")]
        public string UPLOADID { get; set; }
        /// <summary>
        /// 上传人姓名
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADNAME")]
        public string UPLOADNAME { get; set; }
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