using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:30
    /// �� ����������-Ұ�⿱��
    /// </summary>
    public class TBL_ZLGC_KCINFOMap : EntityTypeConfiguration<TBL_ZLGC_KCINFOEntity>
    {
        public TBL_ZLGC_KCINFOMap()
        {
            #region ������
            //��
            this.ToTable("TBL_ZLGC_KCINFO");
            //����
            this.HasKey(t => t.ZLGCID);
            #endregion

            Property(x => x.KCFY).HasColumnName("KCFY").IsOptional().HasPrecision(15,4);
            #region ���ù�ϵ
            #endregion
        }
    }
}
