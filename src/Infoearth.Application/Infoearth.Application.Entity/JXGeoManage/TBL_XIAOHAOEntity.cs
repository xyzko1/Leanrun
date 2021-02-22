using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    public class TBL_XIAOHAOEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 统一编号
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// 灾害点名称
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERNAME")]
        public string DISASTERNAME { get; set; }
        /// <summary>
        /// 野外编号
        /// </summary>
        /// <returns></returns>
        [Column("OUTDOORCODE")]
        public string OUTDOORCODE { get; set; }
        /// <summary>
        /// 灾害点类型
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        /// <summary>
        /// 地理位置
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        public string LOCATION { get; set; }
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
        /// 销号时间
        /// </summary>
        /// <returns></returns>
        [Column("XHSJ")]
        public DateTime? XHSJ { get; set; }
        /// <summary>
        /// 销号点情况
        /// </summary>
        /// <returns></returns>
        [Column("XHQK")]
        public string XHQK { get; set; }
        /// <summary>
        /// 防治工程等级/工程投资
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCQK")]
        public string ZLGCQK { get; set; }
        /// <summary>
        /// 主要防治措施
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCQK2")]
        public string ZLGCQK2 { get; set; }
        /// <summary>
        /// 工程竣工时间与竣工验收情况
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCQK3")]
        public string ZLGCQK3 { get; set; }
        /// <summary>
        /// 治理效果和监测情况
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCQK4")]
        public string ZLGCQK4 { get; set; }
        /// <summary>
        /// 现场核实治理工程变形情况、损毁、完整性、稳定性情况
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCQK5")]
        public string ZLGCQK5 { get; set; }
        /// <summary>
        /// 搬迁户数/人数
        /// </summary>
        /// <returns></returns>
        [Column("BQBQQK")]
        public string BQBQQK { get; set; }
        /// <summary>
        /// 搬迁避让项目实施部门
        /// </summary>
        /// <returns></returns>
        [Column("BQBQQK2")]
        public string BQBQQK2 { get; set; }
        /// <summary>
        /// 是否全部实施搬迁
        /// </summary>
        /// <returns></returns>
        [Column("BQBQQK3")]
        public string BQBQQK3 { get; set; }
        /// <summary>
        /// 影响范围内有无耕地以外的其他保护对象
        /// </summary>
        /// <returns></returns>
        [Column("BQBQQK4")]
        public string BQBQQK4 { get; set; }
        /// <summary>
        /// 搬迁后房屋是否全部拆除、居民有无回流可能
        /// </summary>
        /// <returns></returns>
        [Column("BQBQQK5")]
        public string BQBQQK5 { get; set; }
        /// <summary>
        /// 搬迁地质灾害点是否已设置警示标志
        /// </summary>
        /// <returns></returns>
        [Column("BQBQQK6")]
        public string BQBQQK6 { get; set; }
        /// <summary>
        /// 责任主体明确情况
        /// </summary>
        /// <returns></returns>
        [Column("ZRZTQK")]
        public string ZRZTQK { get; set; }
        /// <summary>
        /// 灾害点现状
        /// </summary>
        /// <returns></returns>
        [Column("ZHDXZ")]
        public string ZHDXZ { get; set; }
        /// <summary>
        /// 是否完成工程治理(1完成 0未完成)
        /// </summary>
        /// <returns></returns>
        [Column("ISZLGC")]
        public string ISZLGC { get; set; }
        /// <summary>
        /// 是否完成搬迁避让(1完成 0未完成)
        /// </summary>
        /// <returns></returns>
        [Column("ISBQBR")]
        public string ISBQBR { get; set; }
        /// <summary>
        /// 同意销号意见
        /// </summary>
        /// <returns></returns>
        [Column("BZ")]
        public string BZ { get; set; }
        /// <summary>
        /// 填表人
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEPEOPLE")]
        public string FILLTABLEPEOPLE { get; set; }
        /// <summary>
        /// 复核人
        /// </summary>
        /// <returns></returns>
        [Column("VERIFYPEOPLE")]
        public string VERIFYPEOPLE { get; set; }
        /// <summary>
        /// 填表日期
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEDATE")]
        public DateTime? FILLTABLEDATE { get; set; }
        /// <summary>
        /// 填表单位
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEUNIT")]
        public string FILLTABLEUNIT { get; set; }

        /// <summary>
        /// 是否有责任主体
        /// </summary>
        /// <returns></returns>
        [Column("ISZRZT")]
        public string ISZRZT { get; set; }

        /// <summary>
        /// 工程编号
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTID")]
        public string PROJECTID { get; set; }
        /// <summary>
        /// 原始经度
        /// </summary>
        [Column("YSJD")]
        public string YSJD { get; set; }
        /// <summary>
        /// 原始纬度
        /// </summary>
        [Column("YSWD")]
        public string YSWD { get; set; }
        /// <summary>
        ///新增时间
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public DateTime? CREATETIME { get; set; }
        /// <summary>
        ///修改时间
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYTIME")]
        public DateTime? MODIFYTIME { get; set; }
        /// <summary>
        /// 行政区划编码
        /// </summary>
        /// <returns></returns>
        [Column("XZQHCODE")]
        public string XZQHCODE { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.GUID = Guid.NewGuid().ToString();
            this.CREATETIME = DateTime.Now;
            this.MODIFYTIME = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.GUID = keyValue;
            this.MODIFYTIME = DateTime.Now;
        }
        #endregion
    }
}
