using Infoearth.Application.Entity.MONITORPOINT;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.MONITORPOINT
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-26 16:55
    /// �� ������������������
    /// </summary>
    public class TBL_DMCJ_MONITORDATAMap : EntityTypeConfiguration<TBL_DMCJ_MONITORDATAEntity>
    {
        public TBL_DMCJ_MONITORDATAMap()
        {
            #region ������
            //��
            this.ToTable("TBL_DMCJ_MONITORDATA");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
