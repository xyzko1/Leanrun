using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 15:53
    /// 描 述：解译工程项目基本信息表
    /// </summary>
    public class JYGC_PROJECTBASEINFOEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 项目GUID
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTGUID")]
        public string PROJECTGUID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTNAME")]
        public string PROJECTNAME { get; set; }
        /// <summary>
        /// 项目代码
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTCODE")]
        public string PROJECTCODE { get; set; }
        /// <summary>
        /// 项目类型
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTTYPE")]
        public string PROJECTTYPE { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        /// <returns></returns>
        [Column("YEAR")]
        public int YEAR { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [Column("TIMECREATED")]
        public System.DateTime? TIMECREATED { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        [Column("USERCREATED")]
        public string USERCREATED { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        /// <returns></returns>
        [Column("TIMEMODIFIED")]
        public System.DateTime? TIMEMODIFIED { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        /// <returns></returns>
        [Column("USERMODIFIED")]
        public string USERMODIFIED { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.PROJECTGUID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.PROJECTGUID = keyValue;
        }
        #endregion
    }
}