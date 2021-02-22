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
    public class TBL_SENSE_HISTORYMap : EntityTypeConfiguration<TBL_SENSE_HISTORYEntity>
    {
        public TBL_SENSE_HISTORYMap()
        {
            #region ������
            //��
            this.ToTable("TBL_SENSE_HISTORY");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
