using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-03-28 13:52
    /// �� ������Χͼ�����
    /// </summary>
    public class TBL_SPATIALEDITLAYERMap : EntityTypeConfiguration<TBL_SPATIALEDITLAYEREntity>
    {
        public TBL_SPATIALEDITLAYERMap()
        {
            #region ������
            //��
            this.ToTable("TBL_SPATIALEDITLAYER");
            //����
            this.HasKey(t => t.LAYERID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
