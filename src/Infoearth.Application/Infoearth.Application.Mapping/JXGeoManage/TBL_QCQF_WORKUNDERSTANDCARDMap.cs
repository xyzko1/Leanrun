using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:23
    /// �� ����Ⱥ��Ⱥ���������׿�
    /// </summary>
    public class TBL_QCQF_WORKUNDERSTANDCARDMap : EntityTypeConfiguration<TBL_QCQF_WORKUNDERSTANDCARDEntity>
    {
        public TBL_QCQF_WORKUNDERSTANDCARDMap()
        {
            #region ������
            //��
            this.ToTable("TBL_QCQF_WORKUNDERSTANDCARD");
            //����
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
