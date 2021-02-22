using Infoearth.Application.Entity.CustomerManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.CustomerManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-04-01 14:33
    /// �� ������Ʊ��Ϣ
    /// </summary>
    public class InvoiceMap : EntityTypeConfiguration<InvoiceEntity>
    {
        public InvoiceMap()
        {
            #region ������
            //��
            this.ToTable("CLIENT_INVOICE");//Client_Invoice
            //����
            this.HasKey(t => t.F_InvoiceId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
