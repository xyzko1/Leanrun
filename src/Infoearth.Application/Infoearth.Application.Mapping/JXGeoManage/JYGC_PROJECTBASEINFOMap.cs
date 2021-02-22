using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 15:53
    /// �� �������빤����Ŀ������Ϣ��
    /// </summary>
    public class JYGC_PROJECTBASEINFOMap : EntityTypeConfiguration<JYGC_PROJECTBASEINFOEntity>
    {
        public JYGC_PROJECTBASEINFOMap()
        {
            #region ������
            //��
            this.ToTable("JYGC_PROJECTBASEINFO");
            //����
            this.HasKey(t => t.PROJECTGUID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
