using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-11 15:39
    /// �� ����Ⱥ��Ⱥ������͹۲��˹�����
    /// </summary>
    public class TBL_QCQF_POINTOBSERVATIONMap : EntityTypeConfiguration<TBL_QCQF_POINTOBSERVATIONEntity>
    {
        public TBL_QCQF_POINTOBSERVATIONMap()
        {
            #region ������
            //��
            this.ToTable("TBL_QCQF_POINTOBSERVATION");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
