using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-13 13:27
    /// �� ���������鱨��
    /// </summary>
    public class TBL_YJDC_DISASTERREPORTMap : EntityTypeConfiguration<TBL_YJDC_DISASTERREPORTEntity>
    {
        public TBL_YJDC_DISASTERREPORTMap()
        {
            #region ������
            //��
            this.ToTable("TBL_YJDC_DISASTERREPORT");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
