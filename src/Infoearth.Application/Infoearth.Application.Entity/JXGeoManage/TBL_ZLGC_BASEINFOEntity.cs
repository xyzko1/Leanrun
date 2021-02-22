using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-05-09 14:53
    /// 描 述：治理工程信息表
    /// </summary>
    public class TBL_ZLGC_BASEINFOEntity : BaseEntity
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
        /// 灾害点名称
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERNAME")]
        public string DISASTERNAME { get; set; }
        /// <summary>
        /// 治理工程名称
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCNAME")]
        public string ZLGCNAME { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// 省编号
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        /// <summary>
        /// 市（州）
        /// </summary>
        /// <returns></returns>
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// 市（州）编号
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        /// <summary>
        /// 区（县）
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
        /// <summary>
        /// 区（县）编号
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }
        /// <summary>
        /// 乡镇
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
        /// <summary>
        /// 乡镇编号
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
        /// <summary>
        /// 村
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGE")]
        public string VILLAGE { get; set; }
        /// <summary>
        /// 组
        /// </summary>
        /// <returns></returns>
        [Column("TEAM")]
        public string TEAM { get; set; }
        /// <summary>
        /// 工程地理位置
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
        /// 灾害点治理期数
        /// </summary>
        /// <returns></returns>
        [Column("ZHDZLQS")]
        public string ZHDZLQS { get; set; }
        /// <summary>
        /// 施工图设计开始时间
        /// </summary>
        /// <returns></returns>
        [Column("DESIGNSTARTTIME")]
        public DateTime? DESIGNSTARTTIME { get; set; }
        /// <summary>
        /// 施工图设计结束时间
        /// </summary>
        /// <returns></returns>
        [Column("DESIGNENDTIME")]
        public DateTime? DESIGNENDTIME { get; set; }
        /// <summary>
        /// 招标阶段开始时间
        /// </summary>
        /// <returns></returns>
        [Column("TENDERSTARTTIME")]
        public DateTime? TENDERSTARTTIME { get; set; }
        /// <summary>
        /// 招标阶段结束时间
        /// </summary>
        /// <returns></returns>
        [Column("TENDERENDTIME")]
        public DateTime? TENDERENDTIME { get; set; }
        /// <summary>
        /// 施工阶段开始时间
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONSTARTTIME")]
        public DateTime? CONSTRUCTIONSTARTTIME { get; set; }
        /// <summary>
        /// 施工阶段结束时间
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONENDTIME")]
        public DateTime? CONSTRUCTIONENDTIME { get; set; }
        /// <summary>
        /// 初验时间
        /// </summary>
        /// <returns></returns>
        [Column("BEGINNINGTIME")]
        public DateTime? BEGINNINGTIME { get; set; }
        /// <summary>
        /// 终验申请时间
        /// </summary>
        /// <returns></returns>
        [Column("APPLYTIME")]
        public DateTime? APPLYTIME { get; set; }
        /// <summary>
        /// 终验结束时间
        /// </summary>
        /// <returns></returns>
        [Column("ACCEPTANCETIME")]
        public DateTime? ACCEPTANCETIME { get; set; }
        /// <summary>
        /// 项目监管单位
        /// </summary>
        /// <returns></returns>
        [Column("REGULATORS")]
        public string REGULATORS { get; set; }
        /// <summary>
        /// 项目实施单位
        /// </summary>
        /// <returns></returns>
        [Column("IMPLEMENTATION")]
        public string IMPLEMENTATION { get; set; }
        /// <summary>
        /// 工程主要建设内容
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONCONTENT")]
        public string CONSTRUCTIONCONTENT { get; set; }
        /// <summary>
        /// 项目下达时间
        /// </summary>
        /// <returns></returns>
        [Column("GIVETIME")]
        public DateTime? GIVETIME { get; set; }
        /// <summary>
        /// 项目任务下达文号
        /// </summary>
        /// <returns></returns>
        [Column("GIVENUMBER")]
        public string GIVENUMBER { get; set; }
        /// <summary>
        /// 预计完工时间
        /// </summary>
        /// <returns></returns>
        [Column("COMPLETIONTIME")]
        public DateTime? COMPLETIONTIME { get; set; }
        /// <summary>
        /// 勘查单位
        /// </summary>
        /// <returns></returns>
        [Column("PROSPECTING")]
        public string PROSPECTING { get; set; }
        /// <summary>
        /// 设计单位
        /// </summary>
        /// <returns></returns>
        [Column("DESIGN")]
        public string DESIGN { get; set; }
        /// <summary>
        /// 监理单位
        /// </summary>
        /// <returns></returns>
        [Column("SUPERVISION")]
        public string SUPERVISION { get; set; }
        /// <summary>
        /// 监理方现场负责人
        /// </summary>
        /// <returns></returns>
        [Column("SUPERVISIONPEOPLEP")]
        public string SUPERVISIONPEOPLEP { get; set; }
        /// <summary>
        /// 监理方现场负责人电话
        /// </summary>
        /// <returns></returns>
        [Column("SUPERVISIONPHONE")]
        public string SUPERVISIONPHONE { get; set; }
        /// <summary>
        /// 施工单位
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTION")]
        public string CONSTRUCTION { get; set; }
        /// <summary>
        /// 施工方现场负责人
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONPEOPLE")]
        public string CONSTRUCTIONPEOPLE { get; set; }
        /// <summary>
        /// 监理方现场负责人电话
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONPHONE")]
        public string CONSTRUCTIONPHONE { get; set; }
        /// <summary>
        /// 预算资金（万元）
        /// </summary>
        /// <returns></returns>
        [Column("BUDGET")]
        public decimal? BUDGET { get; set; }
        /// <summary>
        /// 下达资金（万元）
        /// </summary>
        /// <returns></returns>
        [Column("ISSUEDCAPITAL")]
        public decimal? ISSUEDCAPITAL { get; set; }
        /// <summary>
        /// 中央财政资金（万元）
        /// </summary>
        /// <returns></returns>
        [Column("CENTRALFUNDS")]
        public decimal? CENTRALFUNDS { get; set; }
        /// <summary>
        /// 决算资金（万元）
        /// </summary>
        /// <returns></returns>
        [Column("FINALMONEY")]
        public decimal? FINALMONEY { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("NOTE")]
        public string NOTE { get; set; }
        /// <summary>
        /// 县级审核人
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYPEOPLE")]
        public string COUNTYPEOPLE { get; set; }
        /// <summary>
        /// 县级审核时间
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYTIME")]
        public DateTime? COUNTYTIME { get; set; }
        /// <summary>
        /// 县级审核意见
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYOPINION")]
        public string COUNTYOPINION { get; set; }
        /// <summary>
        /// 市级审核人
        /// </summary>
        /// <returns></returns>
        [Column("CITYPEOPLE")]
        public string CITYPEOPLE { get; set; }
        /// <summary>
        /// 市级审核时间
        /// </summary>
        /// <returns></returns>
        [Column("CITYTIME")]
        public DateTime? CITYTIME { get; set; }
        /// <summary>
        /// 市级审核意见
        /// </summary>
        /// <returns></returns>
        [Column("CITYOPINION")]
        public string CITYOPINION { get; set; }
        /// <summary>
        /// 备注1
        /// </summary>
        /// <returns></returns>
        [Column("BZ")]
        public string BZ { get; set; }
        /// <summary>
        /// 原编号
        /// </summary>
        /// <returns></returns>
        [Column("OLDUNIFIEDCODE")]
        public string OLDUNIFIEDCODE { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public DateTime? CREATETIME { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        [Column("CREATEUSER")]
        public string CREATEUSER { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYTIME")]
        public DateTime? MODIFYTIME { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYUSER")]
        public string MODIFYUSER { get; set; }
        /// <summary>
        /// 项目批准部门
        /// </summary>
        /// <returns></returns>
        [Column("XMPZBM")]
        public string XMPZBM { get; set; }
        /// <summary>
        /// 灾害体类型
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        /// <summary>
        /// 项目批准文号
        /// </summary>
        /// <returns></returns>
        [Column("XMPZWH")]
        public string XMPZWH { get; set; }
        /// <summary>
        /// 项目建设单位
        /// </summary>
        /// <returns></returns>
        [Column("XMJSDW")]
        public string XMJSDW { get; set; }
        /// <summary>
        /// 项目立项时间
        /// </summary>
        /// <returns></returns>
        [Column("XMJLXSJ")]
        public DateTime? XMJLXSJ { get; set; }
        /// <summary>
        /// 项目批复资金（万元）
        /// </summary>
        /// <returns></returns>
        [Column("XMPFZJ")]
        public decimal? XMPFZJ { get; set; }
        /// <summary>
        /// 项目负责单位
        /// </summary>
        /// <returns></returns>
        [Column("XMFZDW")]
        public string XMFZDW { get; set; }
        /// <summary>
        /// 项目任务
        /// </summary>
        /// <returns></returns>
        [Column("XMXMRW")]
        public string XMXMRW { get; set; }
        /// <summary>
        /// 项目阶段
        /// </summary>
        [Column("ZLSTATE")]
        public string ZLSTATE { get; set; }
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
    public class PASTBL_ZLGC_BASEINFOEntity
    {
        public string MEDIAGUID { get; set; }
        public string GUID { get; set; }
    }
}