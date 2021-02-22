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
    /// 描 述：灾险情报表
    /// </summary>
    public class TBL_YJDC_DISASTERREPORTEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// 行政区划代码
        /// </summary>
        /// <returns></returns>
        [Column("DISTRICTCODE")]
        public string DISTRICTCODE { get; set; }
        /// <summary>
        /// 灾害或者险情
        /// </summary>
        /// <returns></returns>
        [Column("ISZAIQINGORXIANQING")]
        public string ISZAIQINGORXIANQING { get; set; }
        /// <summary>
        /// 接报时间
        /// </summary>
        /// <returns></returns>
        [Column("ACCESSTIME")]
        public System.DateTime? ACCESSTIME { get; set; }
        /// <summary>
        /// 灾害点名称
        /// </summary>
        /// <returns></returns>
        [Column("DISASTRENAME")]
        public string DISASTRENAME { get; set; }
        /// <summary>
        /// 发生地点
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENPLACE")]
        public string HAPPENPLACE { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENTIME")]
        public System.DateTime? HAPPENTIME { get; set; }
        /// <summary>
        /// 死亡人数(人)
        /// </summary>
        /// <returns></returns>
        [Column("DAETH")]
        public string DAETH { get; set; }
        /// <summary>
        /// 失踪人数(人)
        /// </summary>
        /// <returns></returns>
        [Column("LOSS")]
        public string LOSS { get; set; }
        /// <summary>
        /// 受伤人数(人)
        /// </summary>
        /// <returns></returns>
        [Column("HURT")]
        public string HURT { get; set; }
        /// <summary>
        /// 财产损失(万元)
        /// </summary>
        /// <returns></returns>
        [Column("CAICHANLOSS")]
        public string CAICHANLOSS { get; set; }
        /// <summary>
        /// 直接经济损失(万元)
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERECONOMICLOSS")]
        public string DISASTERECONOMICLOSS { get; set; }
        /// <summary>
        /// 威胁户数(户)
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEHOLDS")]
        public string HOUSEHOLDS { get; set; }
        /// <summary>
        /// 威胁人数(人)
        /// </summary>
        /// <returns></returns>
        [Column("THREATENPERSON")]
        public string THREATENPERSON { get; set; }
        /// <summary>
        /// 威胁房屋(个)
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOUSE")]
        public string THREATENHOUSE { get; set; }
        /// <summary>
        /// 威胁其他
        /// </summary>
        /// <returns></returns>
        [Column("THREATENOTHER")]
        public string THREATENOTHER { get; set; }
        /// <summary>
        /// 直接经济损失(万元)
        /// </summary>
        /// <returns></returns>
        [Column("MONEYLOSS")]
        public string MONEYLOSS { get; set; }
        /// <summary>
        /// 灾害类型
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        /// <summary>
        /// 灾害规模
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERSCALE")]
        public string DISASTERSCALE { get; set; }
        /// <summary>
        /// 抢救救灾情况
        /// </summary>
        /// <returns></returns>
        [Column("SAVEDISASTERSITUATION")]
        public string SAVEDISASTERSITUATION { get; set; }
        /// <summary>
        /// 诱发因素
        /// </summary>
        /// <returns></returns>
        [Column("CAUSEFACTOR")]
        public string CAUSEFACTOR { get; set; }
        /// <summary>
        /// 发展趋势
        /// </summary>
        /// <returns></returns>
        [Column("DEVELOPMENTTREND")]
        public string DEVELOPMENTTREND { get; set; }
        /// <summary>
        /// 已采取措施
        /// </summary>
        /// <returns></returns>
        [Column("MEASURE")]
        public string MEASURE { get; set; }
        /// <summary>
        /// 防治建议
        /// </summary>
        /// <returns></returns>
        [Column("SUGGEST")]
        public string SUGGEST { get; set; }
        /// <summary>
        /// 填表人
        /// </summary>
        /// <returns></returns>
        [Column("INFOMENT")]
        public string INFOMENT { get; set; }
        /// <summary>
        /// 填表单位
        /// </summary>
        /// <returns></returns>
        [Column("FILLINUNIT")]
        public string FILLINUNIT { get; set; }
        /// <summary>
        /// 接收人
        /// </summary>
        /// <returns></returns>
        [Column("ACCESSOR")]
        public string ACCESSOR { get; set; }
        /// <summary>
        /// 接收单位
        /// </summary>
        /// <returns></returns>
        [Column("ACCESSSUNIT")]
        public string ACCESSSUNIT { get; set; }
        /// <summary>
        /// 填表日期
        /// </summary>
        /// <returns></returns>
        [Column("FILLINTIME")]
        public System.DateTime? FILLINTIME { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        /// <returns></returns>
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// 县名称
        /// </summary>
        /// <returns></returns>
        [Column("COUTRYNAME")]
        public string COUTRYNAME { get; set; }
        /// <summary>
        /// 乡镇名称
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
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