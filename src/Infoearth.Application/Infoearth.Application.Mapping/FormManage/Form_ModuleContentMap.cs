using Infoearth.Application.Entity.FormManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.FormManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-12-14 05:56
    /// �� ����Form_ModuleContent
    /// </summary>
    public class Form_ModuleContentMap : EntityTypeConfiguration<Form_ModuleContentEntity>
    {
        public Form_ModuleContentMap()
        {
            #region ������
            //��
            this.ToTable("Form_ModuleContent");
            //����
            this.HasKey(t => t.F_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
