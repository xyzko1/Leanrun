using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-09 14:25
    /// 描 述：TBL_DZHJSB_DZZHFZYEAR
    /// </summary>
    public class TBL_DZHJSB_DZZHFZYEARMap : EntityTypeConfiguration<TBL_DZHJSB_DZZHFZYEAREntity>
    {
        public TBL_DZHJSB_DZZHFZYEARMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_DZHJSB_DZZHFZYEAR");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.TRFZZJ).HasColumnName("TRFZZJ").IsOptional().HasPrecision(10,2);
            #region 配置关系
            #endregion
        }
    }
}
