using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-17 14:52
    /// �� ������������
    /// </summary>
    public class TBL_AUDITAREAMap : EntityTypeConfiguration<TBL_AUDITAREAEntity>
    {
        public TBL_AUDITAREAMap()
        {
            #region ������
            //��
            this.ToTable("TBL_AUDITAREA");
            //����
            this.HasKey(t => t.DISTRICTCODE);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
