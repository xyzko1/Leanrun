using Infoearth.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.DemoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 
    /// �� ������������Ա
    /// �� �ڣ�2017-07-21 14:05
    /// �� �������������
    /// </summary>
    public class Base_AreaMap : EntityTypeConfiguration<Base_AreaEntity>
    {
        public Base_AreaMap()
        {
            #region ������
            //��
            this.ToTable("Base_Area");
            //����
            this.HasKey(t => t.F_AreaId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
