using Infoearth.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.BaseManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 
    /// �� ������������Ա
    /// �� �ڣ�2017-07-27 15:01
    /// �� ����WebApiע��
    /// </summary>
    public class WebApiRegistorMap : EntityTypeConfiguration<WebApiRegistorEntity>
    {
        public WebApiRegistorMap()
        {
            #region ������
            //��
            this.ToTable("BASE_WEBAPIREGISTOR");//Base_WebApiRegistor
            //����
            this.HasKey(t => t.F_WebApiId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
