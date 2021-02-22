using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-05 14:36
    /// 描 述：遥感解译表
    /// </summary>
    public class TBL_SENSE_HISTORYMap : EntityTypeConfiguration<TBL_SENSE_HISTORYEntity>
    {
        public TBL_SENSE_HISTORYMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_SENSE_HISTORY");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
