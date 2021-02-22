using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-25 16:13
    /// 描 述：人文经济政府信息表
    /// </summary>
    public class TBL_RWJJ_GOVERNMENTEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        /// <returns></returns>
        [Column("NAME")]
        public string NAME { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        /// <returns></returns>
        [Column("CARDID")]
        public string CARDID { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        [Column("PHONE")]
        public string PHONE { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        /// <returns></returns>
        [Column("MOBILE")]
        public string MOBILE { get; set; }
        /// <summary>
        /// 区县
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        /// <summary>
        /// 乡镇
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
        /// <summary>
        /// 村组
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGE")]
        public string VILLAGE { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        public decimal? LONGITUDE { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        public decimal? LATITUDE { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        /// <returns></returns>
        [Column("CONTACTPERSON")]
        public string CONTACTPERSON { get; set; }
        /// <summary>
        /// 机构级别
        /// </summary>
        /// <returns></returns>
        [Column("ORGANIZATIONLEVEL")]
        public string ORGANIZATIONLEVEL { get; set; }
        /// <summary>
        /// 政府ID
        /// </summary>
        /// <returns></returns>
        [Column("NAMEID")]
        public string NAMEID { get; set; }
        /// <summary>
        /// 联系人编号
        /// </summary>
        /// <returns></returns>
        [Column("CONTACTPERSONID")]
        public string CONTACTPERSONID { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.UNIFIEDCODE = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.UNIFIEDCODE = keyValue;
        }
        #endregion
    }
}