using Infoearth.Application.Code;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infoearth.Application.Entity.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.12 16:40
    /// 描 述：区域管理
    /// </summary>
    public class DistrctEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 区域编号
        /// </summary>
        /// <returns></returns>
        [Column("DistrictCode")]
        public string DistrictCode { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        /// <returns></returns>
        [Column("DistrictName")]
        public string DistrictName { get; set; }
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        [Column("AllPinYin")]
        public string AllPinYin { get; set; }
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        [Column("FirstPinYin")]
        public string FirstPinYin { get; set; }
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        [Column("F_LONGITUDE")]
        public decimal? F_LONGITUDE { get; set; }
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        [Column("F_LATITUDE")]
        public decimal? F_LATITUDE { get; set; }
        #endregion
    }
}
