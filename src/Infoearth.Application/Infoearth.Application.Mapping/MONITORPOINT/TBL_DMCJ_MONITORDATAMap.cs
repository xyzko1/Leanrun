using Infoearth.Application.Entity.MONITORPOINT;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.MONITORPOINT
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-26 16:55
    /// 描 述：地面沉降监测数据
    /// </summary>
    public class TBL_DMCJ_MONITORDATAMap : EntityTypeConfiguration<TBL_DMCJ_MONITORDATAEntity>
    {
        public TBL_DMCJ_MONITORDATAMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_DMCJ_MONITORDATA");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
