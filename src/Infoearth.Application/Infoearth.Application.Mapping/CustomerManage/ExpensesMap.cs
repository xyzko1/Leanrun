using Infoearth.Application.Entity.CustomerManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.CustomerManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� �����ܴ���
    /// �� �ڣ�2016-04-20 11:23
    /// �� ��������֧��
    /// </summary>
    public class ExpensesMap : EntityTypeConfiguration<ExpensesEntity>
    {
        public ExpensesMap()
        {
            #region ������
            //��
            this.ToTable("CLIENT_EXPENSES");//Client_Expenses
            //����
            this.HasKey(t => t.F_ExpensesId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
