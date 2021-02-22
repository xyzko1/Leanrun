using Infoearth.Application.Entity.DMCJManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.DMCJManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-22 12:10
    /// �� ����������������
    /// </summary>
    public class TBL_DMCJ_BASEINFOMap : EntityTypeConfiguration<TBL_DMCJ_BASEINFOEntity>
    {
        public TBL_DMCJ_BASEINFOMap()
        {
            #region ������
            //��
            this.ToTable("TBL_DMCJ_BASEINFO");
            //����
            this.HasKey(t => t.DMCJBH);
            #endregion

            #region ���ù�ϵ
            Property(x => x.LONGITUDE).HasColumnName("LONGITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.LATITUDE).HasColumnName("LATITUDE").IsOptional().HasPrecision(12,8);
            Property(x => x.X).HasColumnName("X").IsOptional().HasPrecision(10,2);
            Property(x => x.Y).HasColumnName("Y").IsOptional().HasPrecision(10,2);
            Property(x => x.ALTITUDE).HasColumnName("ALTITUDE").IsOptional().HasPrecision(10,2);
            Property(x => x.CJQDXSKCJSD).HasColumnName("CJQDXSKCJSD").IsOptional().HasPrecision(10,2);
            Property(x => x.CJQDXSKCL1).HasColumnName("CJQDXSKCL1").IsOptional().HasPrecision(10,2);
            Property(x => x.CJQDXSKCL2).HasColumnName("CJQDXSKCL2").IsOptional().HasPrecision(10,2);
            Property(x => x.CJQDXSKCQSW).HasColumnName("CJQDXSKCQSW").IsOptional().HasPrecision(10,2);
            Property(x => x.CJQDXSLDZXSW).HasColumnName("CJQDXSLDZXSW").IsOptional().HasPrecision(10,2);
            Property(x => x.CJQDXSHGJSD).HasColumnName("CJQDXSHGJSD").IsOptional().HasPrecision(10,2);
            #endregion
        }
    }
}
