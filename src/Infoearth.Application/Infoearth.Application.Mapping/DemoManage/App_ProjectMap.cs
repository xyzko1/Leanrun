using LeaRun.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.DemoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �Ϻ�������Ϣ�������޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-04-18 16:34
    /// �� ����App_Project
    /// </summary>
    public class App_ProjectMap : EntityTypeConfiguration<App_ProjectEntity>
    {
        public App_ProjectMap()
        {
            #region ������
            //��
            this.ToTable("App_Project");
            //����
            this.HasKey(t => t.F_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
