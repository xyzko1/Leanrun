using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:31
    /// �� ����������-ʩ��
    /// </summary>
    public class TBL_ZLGC_SGINFOMap : EntityTypeConfiguration<TBL_ZLGC_SGINFOEntity>
    {
        public TBL_ZLGC_SGINFOMap()
        {
            #region ������
            //��
            this.ToTable("TBL_ZLGC_SGINFO");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.FBJE).HasColumnName("FBJE").IsOptional().HasPrecision(15,2);
            #region ���ù�ϵ
            #endregion
        }
    }
}
