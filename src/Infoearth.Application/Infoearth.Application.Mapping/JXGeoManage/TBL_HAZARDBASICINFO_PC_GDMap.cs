using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-07 16:09
    /// 描 述：排查数据表
    /// </summary>
    public class TBL_HAZARDBASICINFO_PC_GDMap : EntityTypeConfiguration<TBL_HAZARDBASICINFO_PC_GDEntity>
    {
        public TBL_HAZARDBASICINFO_PC_GDMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_HAZARDBASICINFO_PC_GD");
            //主键
            this.HasKey(t => t.PCUNIFIEDCODE);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            #region 配置关系
            #endregion
        }
    }
}
