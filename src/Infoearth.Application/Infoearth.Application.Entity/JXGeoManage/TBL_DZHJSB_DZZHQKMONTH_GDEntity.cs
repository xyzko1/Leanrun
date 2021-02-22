using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-15 15:38
    /// 描 述：巡查隐患点灾情表
    /// </summary>
    public class TBL_DZHJSB_DZZHQKMONTH_GDEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 发生日期
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENDATE")]
        public DateTime? HAPPENDATE { get; set; }
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
        /// 县（区）
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }
        /// <summary>
        /// 乡镇
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
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
        /// 县（区）名称
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
        /// <summary>
        /// 乡镇名称
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTEAR")]
        public short? DISASTERTEAR { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERMONTH")]
        public short? DISASTERMONTH { get; set; }
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
        /// 经度（度分秒）
        /// </summary>
        /// <returns></returns>
        [Column("LON")]
        public string LON { get; set; }
        /// <summary>
        /// 纬度（度分秒）
        /// </summary>
        /// <returns></returns>
        [Column("LAT")]
        public string LAT { get; set; }
        /// <summary>
        /// 引发原因
        /// </summary>
        /// <returns></returns>
        [Column("COURSE")]
        public string COURSE { get; set; }
        /// <summary>
        /// 具体原因
        /// </summary>
        /// <returns></returns>
        [Column("JTYY")]
        public string JTYY { get; set; }
        /// <summary>
        /// 灾害类型
        /// </summary>
        /// <returns></returns>
        [Column("ZHLX")]
        public string ZHLX { get; set; }
        /// <summary>
        /// 灾害等级
        /// </summary>
        /// <returns></returns>
        [Column("ZHDJ")]
        public string ZHDJ { get; set; }
        /// <summary>
        /// 受灾对象
        /// </summary>
        /// <returns></returns>
        [Column("SZDX")]
        public string SZDX { get; set; }
        /// <summary>
        /// 受灾规模
        /// </summary>
        /// <returns></returns>
        [Column("ZHGM")]
        public decimal? ZHGM { get; set; }
        /// <summary>
        /// 受灾人口（人）
        /// </summary>
        /// <returns></returns>
        [Column("SZRK")]
        public short? SZRK { get; set; }
        /// <summary>
        /// 直接经济损失（万元）
        /// </summary>
        /// <returns></returns>
        [Column("ZJJJSS")]
        public decimal? ZJJJSS { get; set; }
        /// <summary>
        /// 受伤（人)
        /// </summary>
        /// <returns></returns>
        [Column("SS")]
        public short? SS { get; set; }
        /// <summary>
        /// 失踪（人）
        /// </summary>
        /// <returns></returns>
        [Column("SZ")]
        public short? SZ { get; set; }
        /// <summary>
        /// 死亡（人）
        /// </summary>
        /// <returns></returns>
        [Column("SW")]
        public short? SW { get; set; }
        /// <summary>
        /// 有无应急调查报告（0有，1无）
        /// </summary>
        /// <returns></returns>
        [Column("YWYJDCBG")]
        public string YWYJDCBG { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        /// <returns></returns>
        [Column("OCCURRENCETIME")]
        public string OCCURRENCETIME { get; set; }
        /// <summary>
        /// 填表人
        /// </summary>
        /// <returns></returns>
        [Column("FILLINPERSON")]
        public string FILLINPERSON { get; set; }
        /// <summary>
        /// 复核人
        /// </summary>
        /// <returns></returns>
        [Column("REVIEWPERSON")]
        public string REVIEWPERSON { get; set; }
        /// <summary>
        /// 上报来源(桌面端、移动端)（1为测绘院）
        /// </summary>
        /// <returns></returns>
        [Column("REPORTLY")]
        public string REPORTLY { get; set; }
        /// <summary>
        /// 上传人
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADER")]
        public string UPLOADER { get; set; }
        /// <summary>
        /// 排查编号
        /// </summary>
        /// <returns></returns>
        [Column("GEONO")]
        public string GEONO { get; set; }
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