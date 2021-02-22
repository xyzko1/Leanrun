using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 15:53
    /// 描 述：解译工程项目基本信息表
    /// </summary>
    public class JYGC_PROJECTBASEINFOMap : EntityTypeConfiguration<JYGC_PROJECTBASEINFOEntity>
    {
        public JYGC_PROJECTBASEINFOMap()
        {
            #region 表、主键
            //表
            this.ToTable("JYGC_PROJECTBASEINFO");
            //主键
            this.HasKey(t => t.PROJECTGUID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
