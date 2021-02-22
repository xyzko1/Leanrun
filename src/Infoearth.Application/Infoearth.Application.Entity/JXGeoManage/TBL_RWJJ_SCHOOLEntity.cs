using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-26 16:29
    /// 描 述：人文经济学校信息表
    /// </summary>
    public class TBL_RWJJ_SCHOOLEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// 学校名称
        /// </summary>
        /// <returns></returns>
        [Column("NAME")]
        public string NAME { get; set; }
        /// <summary>
        /// 身份证号
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
        /// 修建时间
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public DateTime? CREATETIME { get; set; }
        /// <summary>
        /// 建筑面积
        /// </summary>
        /// <returns></returns>
        [Column("AREASTRUCTURE")]
        public int? AREASTRUCTURE { get; set; }
        /// <summary>
        /// 结构类型
        /// </summary>
        /// <returns></returns>
        [Column("STRUCTURETYPE")]
        public string STRUCTURETYPE { get; set; }
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
        /// 责任人
        /// </summary>
        /// <returns></returns>
        [Column("LEGALPERSON")]
        public string LEGALPERSON { get; set; }
        /// <summary>
        /// 学校人数
        /// </summary>
        /// <returns></returns>
        [Column("SCHOOLPEOPLE")]
        public long? SCHOOLPEOPLE { get; set; }
        /// <summary>
        /// 住校人数
        /// </summary>
        /// <returns></returns>
        [Column("RESIDENCENUM")]
        public long? RESIDENCENUM { get; set; }
        /// <summary>
        /// 学校总资产
        /// </summary>
        /// <returns></returns>
        [Column("TOTALASSETS")]
        public long? TOTALASSETS { get; set; }
        /// <summary>
        /// 占地面积
        /// </summary>
        /// <returns></returns>
        [Column("FLOORSPACE")]
        public short? FLOORSPACE { get; set; }
        /// <summary>
        /// 学校ID
        /// </summary>
        /// <returns></returns>
        [Column("NAMEID")]
        public string NAMEID { get; set; }
        /// <summary>
        /// 责任人ID
        /// </summary>
        /// <returns></returns>
        [Column("LEGALPERSONID")]
        public string LEGALPERSONID { get; set; }
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