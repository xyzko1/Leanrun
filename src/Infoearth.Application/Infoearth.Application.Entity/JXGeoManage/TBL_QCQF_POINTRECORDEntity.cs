using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-13 16:23
    /// 描 述：群测群防监测流水数据表
    /// </summary>
    public class TBL_QCQF_POINTRECORDEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 群测群防监测点GUID
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTGUID")]
        public string MONITORPOINTGUID { get; set; }
        /// <summary>
        /// 上报时间
        /// </summary>
        /// <returns></returns>
        [Column("MONITORTIME")]
        public DateTime? MONITORTIME { get; set; }
        /// <summary>
        /// 缝宽（米）
        /// </summary>
        /// <returns></returns>
        [Column("SLITWIDTH")]
        public decimal? SLITWIDTH { get; set; }
        /// <summary>
        /// 地鼓高度（米）
        /// </summary>
        /// <returns></returns>
        [Column("TODRUMHEIGH")]
        public decimal? TODRUMHEIGH { get; set; }
        /// <summary>
        /// 泉水水量（米）
        /// </summary>
        /// <returns></returns>
        [Column("SPRINGAMOUNT")]
        public decimal? SPRINGAMOUNT { get; set; }
        /// <summary>
        /// 泉水清浊度（米）
        /// </summary>
        /// <returns></returns>
        [Column("SPRINGVOICING")]
        public string SPRINGVOICING { get; set; }
        /// <summary>
        /// 井水水量（米）
        /// </summary>
        /// <returns></returns>
        [Column("WELLLEVEL")]
        public decimal? WELLLEVEL { get; set; }
        /// <summary>
        /// 井水清浊度（米）
        /// </summary>
        /// <returns></returns>
        [Column("WELLVOICING")]
        public string WELLVOICING { get; set; }
        /// <summary>
        /// 观测人ID
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