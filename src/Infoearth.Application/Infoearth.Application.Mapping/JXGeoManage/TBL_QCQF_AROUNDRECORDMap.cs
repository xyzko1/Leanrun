using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-13 16:22
    /// 描 述：巡查记录表
    /// </summary>
    public class TBL_QCQF_AROUNDRECORDMap : EntityTypeConfiguration<TBL_QCQF_AROUNDRECORDEntity>
    {
        public TBL_QCQF_AROUNDRECORDMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_QCQF_AROUNDRECORD");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.UPLOADLONGITUDE).HasColumnName("UPLOADLONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.UPLOADLATITUDE).HasColumnName("UPLOADLATITUDE").IsOptional().HasPrecision(12,8);
            #region 配置关系
            #endregion
        }
    }
}
