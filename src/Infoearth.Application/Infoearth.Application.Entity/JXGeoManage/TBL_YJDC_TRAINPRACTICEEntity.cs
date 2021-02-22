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
    /// 描 述：应急演练表
    /// </summary>
    public class TBL_YJDC_TRAINPRACTICEEntity : BaseEntity
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
        /// 演练地点
        /// </summary>
        /// <returns></returns>
        [Column("TRAINPLACE")]
        public string TRAINPLACE { get; set; }
        /// <summary>
        /// 灾害模拟
        /// </summary>
        /// <returns></returns>
        [Column("SIMULATEDISASTER")]
        public string SIMULATEDISASTER { get; set; }
        /// <summary>
        /// 演练时间
        /// </summary>
        /// <returns></returns>
        [Column("TRAINTIME")]
        public System.DateTime? TRAINTIME { get; set; }
        /// <summary>
        /// 参加人数
        /// </summary>
        /// <returns></returns>
        [Column("ATTENDPEOPLE")]
        public string ATTENDPEOPLE { get; set; }
        /// <summary>
        /// 组织人
        /// </summary>
        /// <returns></returns>
        [Column("ACCESSOR")]
        public string ACCESSOR { get; set; }
        /// <summary>
        /// 组织单位
        /// </summary>
        /// <returns></returns>
        [Column("ACCESSUNIT")]
        public string ACCESSUNIT { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        /// <returns></returns>
        [Column("REPORTTIME")]
        public System.DateTime? REPORTTIME { get; set; }
        /// <summary>
        /// 行政区划
        /// </summary>
        /// <returns></returns>
        [Column("ORGANIZATION")]
        public string ORGANIZATION { get; set; }
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