using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:31
    /// �� ����������-���
    /// </summary>
    public class TBL_ZLGC_SJINFOMap : EntityTypeConfiguration<TBL_ZLGC_SJINFOEntity>
    {
        public TBL_ZLGC_SJINFOMap()
        {
            #region ������
            //��
            this.ToTable("TBL_ZLGC_SJINFO");
            //����
            this.HasKey(t => t.ZLGCID);
            #endregion

            Property(x => x.DESIGNCOST).HasColumnName("DESIGNCOST").IsOptional().HasPrecision(15,2);
            #region ���ù�ϵ
            #endregion
        }
    }
}
