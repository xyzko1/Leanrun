using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 11:13
    /// 描 述：灾害点历史信息基本表
    /// </summary>
    public class TBL_HAZARDBASICINFO_HISTORYMap : EntityTypeConfiguration<TBL_HAZARDBASICINFO_HISTORYEntity>
    {
        public TBL_HAZARDBASICINFO_HISTORYMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_HAZARDBASICINFO_HISTORY");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
