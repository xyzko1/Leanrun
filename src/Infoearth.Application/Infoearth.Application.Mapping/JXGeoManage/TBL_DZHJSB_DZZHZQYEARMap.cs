using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-08 15:58
    /// �� ����TBL_DZHJSB_DZZHZQYEAR
    /// </summary>
    public class TBL_DZHJSB_DZZHZQYEARMap : EntityTypeConfiguration<TBL_DZHJSB_DZZHZQYEAREntity>
    {
        public TBL_DZHJSB_DZZHZQYEARMap()
        {
            #region ������
            //��
            this.ToTable("TBL_DZHJSB_DZZHZQYEAR");
            //����
            this.HasKey(t => t.GUID);
            #endregion

            Property(x => x.DIRECTECONOMICLOSS).HasColumnName("DIRECTECONOMICLOSS").IsOptional().HasPrecision(10,2);
            #region ���ù�ϵ
            #endregion
        }
    }
}
