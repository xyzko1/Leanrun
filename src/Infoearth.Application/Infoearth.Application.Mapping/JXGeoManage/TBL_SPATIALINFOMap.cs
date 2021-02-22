using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-03-28 14:23
    /// �� ������Χ���ݱ�
    /// </summary>
    public class TBL_SPATIALINFOMap : EntityTypeConfiguration<TBL_SPATIALINFOEntity>
    {
        public TBL_SPATIALINFOMap()
        {
            #region ������
            //��
            this.ToTable("TBL_SPATIALINFO");
            //����
            this.HasKey(t => t.SPATIALID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
