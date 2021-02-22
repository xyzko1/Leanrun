using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-13 13:27
    /// 描 述：灾险情报表
    /// </summary>
    public class TBL_YJDC_DISASTERREPORTMap : EntityTypeConfiguration<TBL_YJDC_DISASTERREPORTEntity>
    {
        public TBL_YJDC_DISASTERREPORTMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_YJDC_DISASTERREPORT");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
