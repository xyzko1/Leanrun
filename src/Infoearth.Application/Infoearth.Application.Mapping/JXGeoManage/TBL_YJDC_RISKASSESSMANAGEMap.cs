using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-13 13:27
    /// �� ���������ֺ�Σ����������Ŀ�����ǼǱ�
    /// </summary>
    public class TBL_YJDC_RISKASSESSMANAGEMap : EntityTypeConfiguration<TBL_YJDC_RISKASSESSMANAGEEntity>
    {
        public TBL_YJDC_RISKASSESSMANAGEMap()
        {
            #region ������
            //��
            this.ToTable("TBL_YJDC_RISKASSESSMANAGE");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
