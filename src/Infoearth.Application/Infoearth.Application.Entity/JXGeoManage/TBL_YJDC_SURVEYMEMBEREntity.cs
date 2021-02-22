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
    /// 描 述：应急调查成员表
    /// </summary>
    public class TBL_YJDC_SURVEYMEMBEREntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        [Column("NAME")]
        public string NAME { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        /// <returns></returns>
        [Column("UNIT")]
        public string UNIT { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        /// <returns></returns>
        [Column("PROFESSIONALTITLE")]
        public string PROFESSIONALTITLE { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        /// <returns></returns>
        [Column("SIGNATURE")]
        public string SIGNATURE { get; set; }
        /// <summary>
        /// 应急调查编号
        /// </summary>
        /// <returns></returns>
        [Column("YJDCGUID")]
        public string YJDCGUID { get; set; }
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