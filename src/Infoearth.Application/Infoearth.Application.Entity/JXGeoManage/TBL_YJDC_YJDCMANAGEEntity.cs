using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-13 13:27
    /// 描 述：应急调查报告表
    /// </summary>
    public class TBL_YJDC_YJDCMANAGEEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 省名称
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        /// <returns></returns>
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// 县名称
        /// </summary>
        /// <returns></returns>
        [Column("COUTRYNAME")]
        public string COUTRYNAME { get; set; }
        /// <summary>
        /// 乡镇名称
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
        /// <summary>
        /// 报表名称
        /// </summary>
        /// <returns></returns>
        [Column("REPORTNAME")]
        public string REPORTNAME { get; set; }
        /// <summary>
        /// 上传人
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADPEOPLE")]
        public string UPLOADPEOPLE { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADTIME")]
        public System.DateTime? UPLOADTIME { get; set; }
        /// <summary>
        /// 行政区划编码
        /// </summary>
        /// <returns></returns>
        [Column("DISTRICTCODE")]
        public string DISTRICTCODE { get; set; }
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