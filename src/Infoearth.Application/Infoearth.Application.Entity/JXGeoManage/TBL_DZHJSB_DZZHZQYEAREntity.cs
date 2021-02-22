using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-08 15:58
    /// 描 述：TBL_DZHJSB_DZZHZQYEAR
    /// </summary>
    public class TBL_DZHJSB_DZZHZQYEAREntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 行政区划编号
        /// </summary>
        /// <returns></returns>
        [Column("DISTRICTCODE")]
        public string DISTRICTCODE { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
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
        /// 年份
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERYEAR")]
        public short? DISASTERYEAR { get; set; }
     //   public string DISASTERYEAR { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("BZ")]
        public string BZ { get; set; }
        /// <summary>
        /// 01 地址灾害数量
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERAMOUNT")]
        public short? DISASTERAMOUNT { get; set; }
        /// <summary>
        /// 02 自然因素
        /// </summary>
        /// <returns></returns>
        [Column("NATURALELENT")]
        public short? NATURALELENT { get; set; }
        /// <summary>
        /// 03 认为因素
        /// </summary>
        /// <returns></returns>
        [Column("HUMANFACTORS")]
        public short? HUMANFACTORS { get; set; }
        /// <summary>
        /// 04地质灾害数量
        /// </summary>
        /// <returns></returns>
        [Column("QUANTITY")]
        public short? QUANTITY { get; set; }
        /// <summary>
        /// 05 崩塌
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSE")]
        public short? COLLAPSE { get; set; }
        /// <summary>
        /// 06 滑坡
        /// </summary>
        /// <returns></returns>
        [Column("COAST")]
        public short? COAST { get; set; }
        /// <summary>
        /// 07 泥石流
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOW")]
        public short? DEBRISFLOW { get; set; }
        /// <summary>
        /// 08 地面塌陷
        /// </summary>
        /// <returns></returns>
        [Column("SURFACECOLLAPSE")]
        public short? SURFACECOLLAPSE { get; set; }
        /// <summary>
        /// 09 地裂缝
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEFRACTURE")]
        public short? SURFACEFRACTURE { get; set; }
        /// <summary>
        /// 10 地面沉降
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEFALL")]
        public short? SURFACEFALL { get; set; }
        /// <summary>
        /// 17造成伤亡人数
        /// </summary>
        /// <returns></returns>
        [Column("CAUSEDEATHTOLL")]
        public short? CAUSEDEATHTOLL { get; set; }
        /// <summary>
        /// 12 死亡人数
        /// </summary>
        /// <returns></returns>
        [Column("DEADAMOUNT")]
        public short? DEADAMOUNT { get; set; }
        /// <summary>
        /// 13 失踪人数
        /// </summary>
        /// <returns></returns>
        [Column("LOSTAMOUNT")]
        public short? LOSTAMOUNT { get; set; }
        /// <summary>
        /// 14 受伤人数
        /// </summary>
        /// <returns></returns>
        [Column("HURTAMOUNT")]
        public short? HURTAMOUNT { get; set; }
        /// <summary>
        /// 15 直接经济损失
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTECONOMICLOSS")]
        public decimal? DIRECTECONOMICLOSS { get; set; }
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