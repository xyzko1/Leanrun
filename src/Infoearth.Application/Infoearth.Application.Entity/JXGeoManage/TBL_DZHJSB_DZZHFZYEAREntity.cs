using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-09 14:25
    /// 描 述：TBL_DZHJSB_DZZHFZYEAR
    /// </summary>
    public class TBL_DZHJSB_DZZHFZYEAREntity : BaseEntity
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
      //  public short? DISASTERYEAR { get; set; }
        public short? DISASTERYEAR { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("BZ")]
        public string BZ { get; set; }
        /// <summary>
        /// 01_成功避让地质灾害
        /// </summary>
        /// <returns></returns>
        [Column("AVOIDDISAATER")]
        public short? AVOIDDISAATER { get; set; }
        /// <summary>
        /// 02_避免伤亡人员
        /// </summary>
        /// <returns></returns>
        [Column("AVOIDHURTHUMAN")]
        public short? AVOIDHURTHUMAN { get; set; }
        /// <summary>
        /// 03_避免直接经济损失
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTECONOMICLOSS")]
        public short? DIRECTECONOMICLOSS { get; set; }
        /// <summary>
        /// 04_出动应急处置小组
        /// </summary>
        /// <returns></returns>
        [Column("CDYJCZXZ")]
        public short? CDYJCZXZ { get; set; }
        /// <summary>
        /// 05_参与应急处置地质灾害
        /// </summary>
        /// <returns></returns>
        [Column("CYYJCLDZZH")]
        public short? CYYJCLDZZH { get; set; }
        /// <summary>
        /// 06_地质灾害防治项目
        /// </summary>
        /// <returns></returns>
        [Column("DZZHFZXM")]
        public short? DZZHFZXM { get; set; }
        /// <summary>
        /// 07_治理项目
        /// </summary>
        /// <returns></returns>
        [Column("GOVERNPROJECT")]
        public short? GOVERNPROJECT { get; set; }
        /// <summary>
        /// 08_监测预警项目
        /// </summary>
        /// <returns></returns>
        [Column("JCYJXM")]
        public short? JCYJXM { get; set; }
        /// <summary>
        /// 09_投入防治资金
        /// </summary>
        /// <returns></returns>
        [Column("TRFZZJ")]
        public decimal? TRFZZJ { get; set; }
        /// <summary>
        /// 10_搬迁人数
        /// </summary>
        /// <returns></returns>
        [Column("REMOVALAMOUNT")]
        public short? REMOVALAMOUNT { get; set; }
        /// <summary>
        /// 11_完成地质灾害危险性评估项目
        /// </summary>
        /// <returns></returns>
        [Column("WCDZZHWXXPGXM")]
        public short? WCDZZHWXXPGXM { get; set; }
        /// <summary>
        /// 12_地质灾害隐患点总数
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENAMOUNTITOTALLY")]
        public short? HIDDENAMOUNTITOTALLY { get; set; }
        /// <summary>
        /// 13_新增数量
        /// </summary>
        /// <returns></returns>
        [Column("ADDAMOUNT")]
        public short? ADDAMOUNT { get; set; }
        /// <summary>
        /// 14_清除数量
        /// </summary>
        /// <returns></returns>
        [Column("CLEARAMOUNT")]
        public short? CLEARAMOUNT { get; set; }
        /// <summary>
        /// 15_特大型
        /// </summary>
        /// <returns></returns>
        [Column("BIGLARGE")]
        public short? BIGLARGE { get; set; }
        /// <summary>
        /// 16_大型
        /// </summary>
        /// <returns></returns>
        [Column("LARGE")]
        public short? LARGE { get; set; }
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