using Infoearth.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.SystemManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������С��
    /// �� �ڣ�2016-12-07 15:32
    /// �� ����System_SetExcelExport
    /// </summary>
    public class System_SetExcelExportMap : EntityTypeConfiguration<System_SetExcelExportEntity>
    {
        public System_SetExcelExportMap()
        {
            #region ������
            //��
            this.ToTable("SYSTEM_SETEXCELEXPORT");
            //����
            this.HasKey(t => t.F_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
