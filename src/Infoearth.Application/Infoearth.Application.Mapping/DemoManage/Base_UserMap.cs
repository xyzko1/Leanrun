using Infoearth.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.DemoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-01-09 16:18
    /// �� �����û���Ϣ��
    /// </summary>
    public class Base_UserMap : EntityTypeConfiguration<Base_UserEntity>
    {
        public Base_UserMap()
        {
            #region ������
            //��
            this.ToTable("Base_User");
            //����
            this.HasKey(t => t.F_UserId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
