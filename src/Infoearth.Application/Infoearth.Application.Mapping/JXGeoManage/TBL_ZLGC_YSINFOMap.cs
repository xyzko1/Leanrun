using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:31
    /// �� ����������-����
    /// </summary>
    public class TBL_ZLGC_YSINFOMap : EntityTypeConfiguration<TBL_ZLGC_YSINFOEntity>
    {
        public TBL_ZLGC_YSINFOMap()
        {
            #region ������
            //��
            this.ToTable("TBL_ZLGC_YSINFO");
            //����
            this.HasKey(t => t.ZLGCID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
