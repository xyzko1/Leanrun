using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:29
    /// �� ����������-����
    /// </summary>
    public class TBL_ZLGC_JLINFOMap : EntityTypeConfiguration<TBL_ZLGC_JLINFOEntity>
    {
        public TBL_ZLGC_JLINFOMap()
        {
            #region ������
            //��
            this.ToTable("TBL_ZLGC_JLINFO");
            //����
            this.HasKey(t => t.ZLGCID);
            #endregion

            Property(x => x.JLCOST).HasColumnName("JLCOST").IsOptional().HasPrecision(15,2);
            #region ���ù�ϵ
            #endregion
        }
    }
}
