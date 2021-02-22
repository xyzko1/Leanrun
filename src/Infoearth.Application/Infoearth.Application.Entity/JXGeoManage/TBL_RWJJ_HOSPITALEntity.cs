using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-26 16:28
    /// 描 述：人文经济医院信息表
    /// </summary>
    public class TBL_RWJJ_HOSPITALEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// 医院名称
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
        /// 法人
        /// </summary>
        /// <returns></returns>
        [Column("LEGALPERSON")]
        public string LEGALPERSON { get; set; }
        /// <summary>
        /// 职工人数
        /// </summary>
        /// <returns></returns>
        [Column("HOSPITALPEOPLE")]
        public long? HOSPITALPEOPLE { get; set; }
        /// <summary>
        /// 总资产
        /// </summary>
        /// <returns></returns>
        [Column("TOTALASSETS")]
        public long? TOTALASSETS { get; set; }
        /// <summary>
        /// 占地面积
        /// </summary>
        /// <returns></returns>
        [Column("FLOORSPACE")]
        public long? FLOORSPACE { get; set; }
        /// <summary>
        /// 日就诊人
        /// </summary>
        /// <returns></returns>
        [Column("AVERAGEDAILY")]
        public long? AVERAGEDAILY { get; set; }
        /// <summary>
        /// 病床数
        /// </summary>
        /// <returns></returns>
        [Column("SICKBEDNUMBER")]
        public long? SICKBEDNUMBER { get; set; }
        /// <summary>
        /// 医护人员数
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALWORKERS")]
        public long? MEDICALWORKERS { get; set; }
        /// <summary>
        /// 救护车辆数
        /// </summary>
        /// <returns></returns>
        [Column("AMBULANCE")]
        public long? AMBULANCE { get; set; }
        /// <summary>
        /// 医院等级
        /// </summary>
        /// <returns></returns>
        [Column("HOSPITALRANK")]
        public string HOSPITALRANK { get; set; }
        /// <summary>
        /// 医院ID
        /// </summary>
        /// <returns></returns>
        [Column("NAMEID")]
        public string NAMEID { get; set; }
        /// <summary>
        /// 法人ID
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