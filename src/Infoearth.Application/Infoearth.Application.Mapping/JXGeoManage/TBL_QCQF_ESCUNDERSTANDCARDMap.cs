using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:21
    /// �� ����Ⱥ��Ⱥ���������׿�
    /// </summary>
    public class TBL_QCQF_ESCUNDERSTANDCARDMap : EntityTypeConfiguration<TBL_QCQF_ESCUNDERSTANDCARDEntity>
    {
        public TBL_QCQF_ESCUNDERSTANDCARDMap()
        {
            #region ������
            //��
            this.ToTable("TBL_QCQF_ESCUNDERSTANDCARD");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
