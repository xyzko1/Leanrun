using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-26 14:28
    /// �� ����ͳ�Ʒ�����ѯ����
    /// </summary>
    public class TBL_WHAA07CMap : EntityTypeConfiguration<TBL_WHAA07CEntity>
    {
        public TBL_WHAA07CMap()
        {
            #region ������
            //��
            this.ToTable("TBL_WHAA07C");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
