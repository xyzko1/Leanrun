using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-07 17:19
    /// �� ����Ⱥ��Ⱥ���۲�����Ϣ��
    /// </summary>
    public class TBL_QCQF_OBSERVATIONMap : EntityTypeConfiguration<TBL_QCQF_OBSERVATIONEntity>
    {
        public TBL_QCQF_OBSERVATIONMap()
        {
            #region ������
            //��
            this.ToTable("TBL_QCQF_OBSERVATION");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
