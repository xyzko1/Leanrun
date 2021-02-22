using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-10 09:57
    /// 描 述：TBL_DZHJSB_CGBRDZZHQKMONTH
    /// </summary>
    public class TBL_DZHJSB_CGBRDZZHQKMONTHEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 发出预报日期
        /// </summary>
        /// <returns></returns>
        [Column("SENDDATE")]
        public DateTime? SENDDATE { get; set; }
        /// <summary>
        /// 预报时间
        /// </summary>
        /// <returns></returns>
        [Column("YBTIME")]
        public string YBTIME { get; set; }
        /// <summary>
        /// 灾害发生日期
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENDATE")]
        public DateTime? HAPPENDATE { get; set; }
        /// <summary>
        /// 灾害发生时间
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENTIME")]
        public string HAPPENTIME { get; set; }
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
        /// 县（区)
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
        /// 村组及具体地点
        /// </summary>
        /// <returns></returns>
        [Column("SPECIFICLOCATION")]
        public string SPECIFICLOCATION { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERYEAR")]
        public short? DISASTERYEAR { get; set; }
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
        /// 预报方法和避灾措施
        /// </summary>
        /// <returns></returns>
        [Column("YBFFHBZCS")]
        public string YBFFHBZCS { get; set; }
        /// <summary>
        /// 灾害类型
        /// </summary>
        /// <returns></returns>
        [Column("ZHLX")]
        public string ZHLX { get; set; }
        /// <summary>
        /// 灾害规模
        /// </summary>
        /// <returns></returns>
        [Column("ZHGM")]
        public short? ZHGM { get; set; }
        /// <summary>
        /// 紧急转移人口（人）
        /// </summary>
        /// <returns></returns>
        [Column("JJZYRK")]
        public short? JJZYRK { get; set; }
        /// <summary>
        /// 避免经济损失（万元）
        /// </summary>
        /// <returns></returns>
        [Column("BMJJSS")]
        public decimal? BMJJSS { get; set; }
        /// <summary>
        /// 避免伤亡人口（人）
        /// </summary>
        /// <returns></returns>
        [Column("BMSWRK")]
        public short? BMSWRK { get; set; }
        /// <summary>
        /// 预报人或单位
        /// </summary>
        /// <returns></returns>
        [Column("FORECASTUNIT")]
        public string FORECASTUNIT { get; set; }
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