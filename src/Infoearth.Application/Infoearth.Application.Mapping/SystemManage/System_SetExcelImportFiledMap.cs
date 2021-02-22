using Infoearth.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.SystemManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������С��
    /// �� �ڣ�2016-12-04 14:46
    /// �� ����System_SetExcelImportFiled
    /// </summary>
    public class System_SetExcelImportFiledMap : EntityTypeConfiguration<System_SetExcelImportFiledEntity>
    {
        public System_SetExcelImportFiledMap()
        {
            #region ������
            //��
            this.ToTable("SYSTEM_SETEXCELIMPORTFILED");
            //����
            this.HasKey(t => t.F_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
