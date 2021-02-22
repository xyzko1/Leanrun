using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-28 13:52
    /// 描 述：范围图层管理
    /// </summary>
    public class TBL_SPATIALEDITLAYERMap : EntityTypeConfiguration<TBL_SPATIALEDITLAYEREntity>
    {
        public TBL_SPATIALEDITLAYERMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_SPATIALEDITLAYER");
            //主键
            this.HasKey(t => t.LAYERID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
