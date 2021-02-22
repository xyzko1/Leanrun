using Infoearth.Application.Entity.DMCJManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.DMCJManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-09-04 12:02
    /// �� ����������������SUB
    /// </summary>
    public class TBL_DMCJ_BASEINFO_SUBMap : EntityTypeConfiguration<TBL_DMCJ_BASEINFO_SUBEntity>
    {
        public TBL_DMCJ_BASEINFO_SUBMap()
        {
            #region ������
            //��
            this.ToTable("TBL_DMCJ_BASEINFO_SUB");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
