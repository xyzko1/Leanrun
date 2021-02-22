using Infoearth.Application.Entity.DMCJManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.DMCJManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-22 12:10
    /// 描 述：地面沉降调查表
    /// </summary>
    public class TBL_DMCJ_BASEINFOMap : EntityTypeConfiguration<TBL_DMCJ_BASEINFOEntity>
    {
        public TBL_DMCJ_BASEINFOMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_DMCJ_BASEINFO");
            //主键
            this.HasKey(t => t.DMCJBH);
            #endregion

            #region 配置关系
            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.X).HasColumnName("X").IsOptional().HasPrecision(10,2);
            Property(x => x.Y).HasColumnName("Y").IsOptional().HasPrecision(10,2);
            Property(x => x.ALTITUDE).HasColumnName("ALTITUDE").IsOptional().HasPrecision(10,2);
            Property(x => x.CJQDXSKCJSD).HasColumnName("CJQDXSKCJSD").IsOptional().HasPrecision(10,2);
            Property(x => x.CJQDXSKCL1).HasColumnName("CJQDXSKCL1").IsOptional().HasPrecision(10,2);
            Property(x => x.CJQDXSKCL2).HasColumnName("CJQDXSKCL2").IsOptional().HasPrecision(10,2);
            Property(x => x.CJQDXSKCQSW).HasColumnName("CJQDXSKCQSW").IsOptional().HasPrecision(10,2);
            Property(x => x.CJQDXSLDZXSW).HasColumnName("CJQDXSLDZXSW").IsOptional().HasPrecision(10,2);
            Property(x => x.CJQDXSHGJSD).HasColumnName("CJQDXSHGJSD").IsOptional().HasPrecision(10,2);
            #endregion
        }
    }
}
