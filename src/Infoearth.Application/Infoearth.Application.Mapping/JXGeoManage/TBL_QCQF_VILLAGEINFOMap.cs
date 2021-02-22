using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-07-05 11:26
    /// 描 述：行政体系责任人村组表
    /// </summary>
    public class TBL_QCQF_VILLAGEINFOMap : EntityTypeConfiguration<TBL_QCQF_VILLAGEINFOEntity>
    {
        public TBL_QCQF_VILLAGEINFOMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_QCQF_VILLAGEINFO");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}