using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �Ϻ�������Ϣ�������޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-04-13 11:13
    /// �� ������������
    /// </summary>
    public class Client_OrderEntryMap : EntityTypeConfiguration<Client_OrderEntryEntity>
    {
        public Client_OrderEntryMap()
        {
            #region ������
            //��
            this.ToTable("Client_OrderEntry");
            //����
            this.HasKey(t => t.F_OrderEntryId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
