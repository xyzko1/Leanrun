using Infoearth.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.DemoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-09-20 17:48
    /// �� ����ϵͳ���ܱ�
    /// </summary>
    public class Base_ModuleMap : EntityTypeConfiguration<Base_ModuleEntity>
    {
        public Base_ModuleMap()
        {
            #region ������
            //��
            this.ToTable("Base_Module");
            //����
            this.HasKey(t => t.F_ModuleId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
