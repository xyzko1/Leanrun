using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-07-05 11:26
    /// 描 述：行政体系责任人村组表
    /// </summary>
    public class TBL_QCQF_VILLAGEINFOEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 村名
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGENAME")]
        public string VILLAGENAME { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("MEMO")]
        public string MEMO { get; set; }
        /// <summary>
        /// 乡镇代码
        /// </summary>
        /// <returns></returns>
        [Column("TOWNCODE")]
        public string TOWNCODE { get; set; }
        /// <summary>
        /// 联系人ID
        /// </summary>
        /// <returns></returns>
        [Column("CONTACTPEOPLEID")]
        public string CONTACTPEOPLEID { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("Telephone")]
        public string Telephone { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("USERNAME")]
        public string USERNAME { get; set; }

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

    public class TBL_QCQF_VILLAGEINFOLXR
    {
        public string GUID { get; set; }

        public string VILLAGENAME { get; set; }
        public string MEMO { get; set; }
        public string TOWNCODE { get; set; }
        public string CONTACTPEOPLEID { get; set; }
        public string Telephone { get; set; }
        public string USERNAME { get; set; }
        public object UserInfo { get; set; }
    }
}