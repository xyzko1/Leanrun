using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-26 16:29
    /// 描 述：人文经济学校信息表
    /// </summary>
    public class TBL_RWJJ_SCHOOLMap : EntityTypeConfiguration<TBL_RWJJ_SCHOOLEntity>
    {
        public TBL_RWJJ_SCHOOLMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_RWJJ_SCHOOL");
            //主键
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion

            #region 配置关系
            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            #endregion
        }
    }
}
