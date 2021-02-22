using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-13 13:27
    /// 描 述：地质灾害危险性评估项目备案登记表
    /// </summary>
    public class TBL_YJDC_RISKASSESSMANAGEMap : EntityTypeConfiguration<TBL_YJDC_RISKASSESSMANAGEEntity>
    {
        public TBL_YJDC_RISKASSESSMANAGEMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_YJDC_RISKASSESSMANAGE");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
