using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-07 17:19
    /// 描 述：群测群防观测人信息表
    /// </summary>
    public class TBL_QCQF_OBSERVATIONEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 观测人电话
        /// </summary>
        /// <returns></returns>
        [Column("OBSERVATIONPHONE")]
        public string OBSERVATIONPHONE { get; set; }
        /// <summary>
        /// 观测人姓名
        /// </summary>
        /// <returns></returns>
        [Column("OBSERVATIONPEOPLE")]
        public string OBSERVATIONPEOPLE { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        /// <returns></returns>
        [Column("LOGINPASSWORD")]
        public string LOGINPASSWORD { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETIME")]
        public DateTime? UPDATETIME { get; set; }
        /// <summary>
        /// 是否限制范围
        /// </summary>
        /// <returns></returns>
        [Column("ISLIMITED")]
        public string ISLIMITED { get; set; }
        /// <summary>
        /// 范围值
        /// </summary>
        /// <returns></returns>
        [Column("FWZ")]
        public string FWZ { get; set; }
        /// <summary>
        /// 是否观测人
        /// </summary>
        /// <returns></returns>
        [Column("ISGCR")]
        public string ISGCR { get; set; }
        /// <summary>
        /// 省名称
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// 省编码
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        /// <summary>
        /// 市编码
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
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
        [Column("COUNTRYNAME")]
        public string COUNTRYNAME { get; set; }
        /// <summary>
        /// 县编码
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }
        /// <summary>
        /// 乡名称
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
        /// <summary>
        /// 乡编码
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
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