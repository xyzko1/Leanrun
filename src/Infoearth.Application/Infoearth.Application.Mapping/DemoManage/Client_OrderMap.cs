using Infoearth.Application.Entity.DemoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.DemoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-10-17 09:47
    /// �� ������������
    /// </summary>
    public class Client_OrderMap : EntityTypeConfiguration<Client_OrderEntity>
    {
        public Client_OrderMap()
        {
            #region ������
            //��
            this.ToTable("Client_Order");
            //����
            this.HasKey(t => t.F_OrderId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
