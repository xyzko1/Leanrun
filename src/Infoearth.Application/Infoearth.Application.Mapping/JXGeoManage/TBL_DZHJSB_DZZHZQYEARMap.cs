using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-08 15:58
    /// 描 述：TBL_DZHJSB_DZZHZQYEAR
    /// </summary>
    public class TBL_DZHJSB_DZZHZQYEARMap : EntityTypeConfiguration<TBL_DZHJSB_DZZHZQYEAREntity>
    {
        public TBL_DZHJSB_DZZHZQYEARMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_DZHJSB_DZZHZQYEAR");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.DIRECTECONOMICLOSS).HasColumnName("DIRECTECONOMICLOSS").IsOptional().HasPrecision(10,2);
            #region 配置关系
            #endregion
        }
    }
}
