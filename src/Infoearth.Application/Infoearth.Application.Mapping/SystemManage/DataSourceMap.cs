using Infoearth.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.SystemManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-09-07 09:39
    /// �� ����Base_DataSource
    /// </summary>
    public class DataSourceMap : EntityTypeConfiguration<DataSourceEntity>
    {
        public DataSourceMap()
        {
            #region ������
            //��
            this.ToTable("BASE_DATASOURCE");
            //����
            this.HasKey(t => t.F_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
