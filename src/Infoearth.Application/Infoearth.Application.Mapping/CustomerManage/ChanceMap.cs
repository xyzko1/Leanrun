using Infoearth.Application.Entity.CustomerManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.CustomerManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� �����ܴ���
    /// �� �ڣ�2016-03-12 10:50
    /// �� �����̻���Ϣ
    /// </summary>
    public class ChanceMap : EntityTypeConfiguration<ChanceEntity>
    {
        public ChanceMap()
        {
            #region ������
            //��
            this.ToTable("CLIENT_CHANCE");//Client_Chance
            //����
            this.HasKey(t => t.F_ChanceId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
