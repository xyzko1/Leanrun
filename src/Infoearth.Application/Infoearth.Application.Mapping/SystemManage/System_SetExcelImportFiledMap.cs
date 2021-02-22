using Infoearth.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.SystemManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：陈小二
    /// 日 期：2016-12-04 14:46
    /// 描 述：System_SetExcelImportFiled
    /// </summary>
    public class System_SetExcelImportFiledMap : EntityTypeConfiguration<System_SetExcelImportFiledEntity>
    {
        public System_SetExcelImportFiledMap()
        {
            #region 表、主键
            //表
            this.ToTable("SYSTEM_SETEXCELIMPORTFILED");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
