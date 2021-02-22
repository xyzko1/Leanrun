using Infoearth.Application.Entity.DMCJManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.DMCJManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-09-04 12:02
    /// 描 述：地面沉降调查表SUB
    /// </summary>
    public class TBL_DMCJ_BASEINFO_SUBMap : EntityTypeConfiguration<TBL_DMCJ_BASEINFO_SUBEntity>
    {
        public TBL_DMCJ_BASEINFO_SUBMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_DMCJ_BASEINFO_SUB");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
