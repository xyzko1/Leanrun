using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �Ϻ�������Ϣ�������޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-05-22 10:48
    /// �� ������Ȩ���ݱ�
    /// </summary>
    public class Base_AuthorizeDataMap : EntityTypeConfiguration<Base_AuthorizeDataEntity>
    {
        public Base_AuthorizeDataMap()
        {
            #region ������
            //��
            this.ToTable("Base_AuthorizeData");
            //����
            this.HasKey(t => t.F_AuthorizeDataId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
