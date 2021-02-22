using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-10 09:57
    /// 描 述：TBL_DZHJSB_CGBRDZZHQKMONTH
    /// </summary>
    public class TBL_DZHJSB_CGBRDZZHQKMONTHMap : EntityTypeConfiguration<TBL_DZHJSB_CGBRDZZHQKMONTHEntity>
    {
        public TBL_DZHJSB_CGBRDZZHQKMONTHMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_DZHJSB_CGBRDZZHQKMONTH");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.BMJJSS).HasColumnName("BMJJSS").IsOptional().HasPrecision(10,2);
            #region 配置关系
            #endregion
        }
    }
}
