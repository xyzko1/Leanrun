using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-03-05 14:36
    /// �� ����ң�н����
    /// </summary>
    public class TBL_SENSEMap : EntityTypeConfiguration<TBL_SENSEEntity>
    {
        public TBL_SENSEMap()
        {
            #region ������
            //��
            this.ToTable("TBL_SENSE");
            //����
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
