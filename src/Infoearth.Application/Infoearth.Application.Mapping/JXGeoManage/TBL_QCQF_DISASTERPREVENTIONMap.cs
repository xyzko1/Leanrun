using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:19
    /// �� ����Ⱥ��Ⱥ������Ԥ����
    /// </summary>
    public class TBL_QCQF_DISASTERPREVENTIONMap : EntityTypeConfiguration<TBL_QCQF_DISASTERPREVENTIONEntity>
    {
        public TBL_QCQF_DISASTERPREVENTIONMap()
        {
            #region ������
            //��
            this.ToTable("TBL_QCQF_DISASTERPREVENTION");
            //����
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
