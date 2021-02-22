using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-09 14:25
    /// �� ����TBL_DZHJSB_DZZHFZYEAR
    /// </summary>
    public class TBL_DZHJSB_DZZHFZYEARMap : EntityTypeConfiguration<TBL_DZHJSB_DZZHFZYEAREntity>
    {
        public TBL_DZHJSB_DZZHFZYEARMap()
        {
            #region ������
            //��
            this.ToTable("TBL_DZHJSB_DZZHFZYEAR");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.TRFZZJ).HasColumnName("TRFZZJ").IsOptional().HasPrecision(10,2);
            #region ���ù�ϵ
            #endregion
        }
    }
}
