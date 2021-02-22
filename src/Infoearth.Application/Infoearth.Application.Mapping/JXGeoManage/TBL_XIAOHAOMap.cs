using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    public class TBL_XIAOHAOMap : EntityTypeConfiguration<TBL_XIAOHAOEntity>
    {
        public TBL_XIAOHAOMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_XIAOHAO");
            //主键
            this.HasKey(t => t.GUID);
            #endregion

            #region 配置关系
            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12, 8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12, 8);
            #endregion
        }
    }
}
