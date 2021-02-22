using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-02-14 11:13
    /// �� �����ֺ�����ʷ��Ϣ������
    /// </summary>
    public class TBL_HAZARDBASICINFO_HISTORYMap : EntityTypeConfiguration<TBL_HAZARDBASICINFO_HISTORYEntity>
    {
        public TBL_HAZARDBASICINFO_HISTORYMap()
        {
            #region ������
            //��
            this.ToTable("TBL_HAZARDBASICINFO_HISTORY");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
