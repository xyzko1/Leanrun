using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-07 17:24
    /// 描 述：群测群防监测点信息表
    /// </summary>
    public class TBL_QCQF_LAYOUTPOINTINFOEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 灾害点编号
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// 监测类型编号（DG:地鼓;DL:地裂;QL:墙裂;JS:井水;QS:泉水;+两位顺序号）
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTCODE")]
        public string MONITORPOINTCODE { get; set; }
        /// <summary>
        /// 监测部位
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTPOSITION")]
        public string MONITORPOINTPOSITION { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        /// <returns></returns>
        [Column("LON")]
        public decimal? LON { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        /// <returns></returns>
        [Column("LAT")]
        public decimal? LAT { get; set; }
        /// <summary>
        /// 责任人姓名
        /// </summary>
        /// <returns></returns>
        [Column("ZRRNAME")]
        public string ZRRNAME { get; set; }
        /// <summary>
        /// 责任人电话
        /// </summary>
        /// <returns></returns>
        [Column("ZRRPHONE")]
        public string ZRRPHONE { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYTIME")]
        public DateTime? MODIFYTIME { get; set; }
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