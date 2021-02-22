using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-03-28 14:24
    /// �� ������Χͼ����ʽ��
    /// </summary>
    public class TBL_SPATIALRENDERSTYLEMap : EntityTypeConfiguration<TBL_SPATIALRENDERSTYLEEntity>
    {
        public TBL_SPATIALRENDERSTYLEMap()
        {
            #region ������
            //��
            this.ToTable("TBL_SPATIALRENDERSTYLE");
            //����
            this.HasKey(t => t.STYLEID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
