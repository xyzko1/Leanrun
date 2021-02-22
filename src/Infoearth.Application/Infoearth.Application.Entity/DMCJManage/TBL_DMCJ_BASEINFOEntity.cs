using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;
using System.Collections.Generic;

namespace Infoearth.Application.Entity.DMCJManage
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-22 12:10
    /// 描 述：地面沉降调查表
    /// </summary>
    public class TBL_DMCJ_BASEINFOEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 地面沉降编号
        /// </summary>
        /// <returns></returns>
        [Column("DMCJBH")]
        [Desc("地面沉降编号")]
        public string DMCJBH { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        /// <returns></returns>
        [Column("XMMC")]
        public string XMMC { get; set; }
        /// <summary>
        /// 调查单位
        /// </summary>
        /// <returns></returns>
        [Column("DCDW")]
        public string DCDW { get; set; }
        /// <summary>
        /// 地面沉降名称
        /// </summary>
        /// <returns></returns>
        [Column("DMCJMC")]
        [Desc("地面沉降名称")]
        public string DMCJMC { get; set; }
        /// <summary>
        /// 室内编号
        /// </summary>
        /// <returns></returns>
        [Column("INDOORCODE")]
        public string INDOORCODE { get; set; }
        /// <summary>
        /// 室外编号
        /// </summary>
        /// <returns></returns>
        [Column("OUTDOORCODE")]
        public string OUTDOORCODE { get; set; }
        /// <summary>
        /// 地理位置
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        [Desc("地理位置")]
        public string LOCATION { get; set; }
        /// <summary>
        /// 地理位置-省市县编号
        /// </summary>
        /// <returns></returns>
        [Column("AREACODE")]
        public string AREACODE { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        [Desc("经度")]
        public decimal? LONGITUDE { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        [Desc("纬度")]
        public decimal? LATITUDE { get; set; }
        /// <summary>
        /// X
        /// </summary>
        /// <returns></returns>
        [Column("X")]
        public decimal? X { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        /// <returns></returns>
        [Column("Y")]
        public decimal? Y { get; set; }
        /// <summary>
        /// 标高
        /// </summary>
        /// <returns></returns>
        [Column("ALTITUDE")]
        public decimal? ALTITUDE { get; set; }
        /// <summary>
        /// 地质环境条件-沉降历史及变化规律
        /// </summary>
        /// <returns></returns>
        [Column("DZHJTJCJLS")]
        public string DZHJTJCJLS { get; set; }
        /// <summary>
        /// 地质环境条件-地形地貌
        /// </summary>
        /// <returns></returns>
        [Column("DZHJTJDXDM")]
        public string DZHJTJDXDM { get; set; }
        /// <summary>
        /// 地质环境条件-地质构造及活动情况
        /// </summary>
        /// <returns></returns>
        [Column("DZHJTJDZGZ")]
        public string DZHJTJDZGZ { get; set; }
        /// <summary>
        /// 地质环境条件-第四纪沉积环境和沉积物工程地质特征
        /// </summary>
        /// <returns></returns>
        [Column("DZHJTJCJHJ")]
        public string DZHJTJCJHJ { get; set; }
        /// <summary>
        /// 地质环境条件-水文地质特征
        /// </summary>
        /// <returns></returns>
        [Column("DZHJTJSWDZ")]
        public string DZHJTJSWDZ { get; set; }
        /// <summary>
        /// 地面沉降现象1(建筑物破坏、地面开裂、井口抬升)
        /// </summary>
        /// <returns></returns>
        [Column("DMCJXX1")]
        public string DMCJXX1 { get; set; }
        /// <summary>
        /// 地面沉降现象2(桥洞净空减少、市政设施破坏、港口码头或堤岸失效)
        /// </summary>
        /// <returns></returns>
        [Column("DMCJXX2")]
        public string DMCJXX2 { get; set; }
        /// <summary>
        /// 地面沉降现象3(海水倒灌、洪涝灾害、其他)
        /// </summary>
        /// <returns></returns>
        [Column("DMCJXX3")]
        public string DMCJXX3 { get; set; }
        /// <summary>
        /// 地面沉降现象-灾害现象描述
        /// </summary>
        /// <returns></returns>
        [Column("DMCJXXMS1")]
        public string DMCJXXMS1 { get; set; }
        /// <summary>
        /// 地面沉降现象-灾害现象描述
        /// </summary>
        /// <returns></returns>
        [Column("DMCJXXMS2")]
        public string DMCJXXMS2 { get; set; }
        /// <summary>
        /// 地面沉降现象-灾害现象描述
        /// </summary>
        /// <returns></returns>
        [Column("DMCJXXMS3")]
        public string DMCJXXMS3 { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水开采-开采层位
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCCW")]
        public string CJQDXSKCCW { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水开采-开采时间
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCSJ")]
        public DateTime? CJQDXSKCSJ { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水开采-开采井数量(眼)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCJSL")]
        public int? CJQDXSKCJSL { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水开采-开采井深度(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCJSD")]
        public decimal? CJQDXSKCJSD { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水开采-开采量(m3/a)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCL1")]
        public decimal? CJQDXSKCL1 { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水开采-开采量(m3/d)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCL2")]
        public decimal? CJQDXSKCL2 { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水位-开采前水位(头)高程(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCQSW")]
        public decimal? CJQDXSKCQSW { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水位-漏斗中心水位(头)高程(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSLDZXSW")]
        public decimal? CJQDXSLDZXSW { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水位回灌-回灌层位
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGCW")]
        public string CJQDXSHGCW { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水位回灌-回灌时间
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGSJ")]
        public DateTime? CJQDXSHGSJ { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水位回灌-回灌井数量(眼)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGJSL")]
        public int? CJQDXSHGJSL { get; set; }
        /// <summary>
        /// 沉降区地下水开采概况-地下水位回灌-回灌井深度(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGJSD")]
        public decimal? CJQDXSHGJSD { get; set; }
        /// <summary>
        /// 沉降区人类活动特征
        /// </summary>
        /// <returns></returns>
        [Column("CJQRLHDTZ")]
        public string CJQRLHDTZ { get; set; }
        /// <summary>
        /// 沉降原因
        /// </summary>
        /// <returns></returns>
        [Column("CJYY")]
        public string CJYY { get; set; }
        /// <summary>
        /// 发展趋势
        /// </summary>
        /// <returns></returns>
        [Column("FZQS")]
        public string FZQS { get; set; }
        /// <summary>
        /// 灾害现状及预测
        /// </summary>
        /// <returns></returns>
        [Column("ZAXZJYC")]
        public string ZAXZJYC { get; set; }
        /// <summary>
        /// 防治现状及建议-已采取的防治措施及效果
        /// </summary>
        /// <returns></returns>
        [Column("YCQFZCS")]
        public string YCQFZCS { get; set; }
        /// <summary>
        /// 防治现状及建议-今后防治建议
        /// </summary>
        /// <returns></returns>
        [Column("JHFZCS")]
        public string JHFZCS { get; set; }
        /// <summary>
        /// 现场图像-平(剖)面图
        /// </summary>
        /// <returns></returns>
        [Column("PMT")]
        public string PMT { get; set; }
        /// <summary>
        /// 现场图像-图片及编号
        /// </summary>
        /// <returns></returns>
        [Column("TPBH")]
        public string TPBH { get; set; }
        /// <summary>
        /// 现场图像-影像及编号
        /// </summary>
        /// <returns></returns>
        [Column("YXBH")]
        public string YXBH { get; set; }
        /// <summary>
        /// 调查人
        /// </summary>
        /// <returns></returns>
        [Column("DCR")]
        [Desc("调查人")]
        public string DCR { get; set; }
        /// <summary>
        /// 记录人
        /// </summary>
        /// <returns></returns>
        [Column("JLR")]
        public string JLR { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        /// <returns></returns>
        [Column("SHR")]
        public string SHR { get; set; }
        /// <summary>
        /// 填表日期
        /// </summary>
        /// <returns></returns>
        [Column("TBSJ")]
        [Desc("填表日期")]
        public DateTime? TBSJ { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            //this.DMCJBH = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            //this.DMCJBH = keyValue;
        }
        #endregion
    }
    public class MasterDetailEntity
    {
        public TBL_DMCJ_BASEINFOEntity TBL_DMCJ_BASEINFOEntity { get; set; }

        public List<TBL_DMCJ_BASEINFO_SUBEntity> TBL_DMCJ_BASEINFO_SUBList { get; set; }
    }
}