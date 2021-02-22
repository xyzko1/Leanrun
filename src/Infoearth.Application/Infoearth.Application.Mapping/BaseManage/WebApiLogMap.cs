using Infoearth.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.BaseManage
{
    /// <summary>
    /// �� �� LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 
    /// �� ������������Ա
    /// �� �ڣ�2017-07-28 10:00
    /// �� ����Base_WebApiLog
    /// </summary>
    public class WebApiLogMap : EntityTypeConfiguration<WebApiLogEntity>
    {
        public WebApiLogMap()
        {
            #region ������
            //��
            this.ToTable("BASE_WEBAPILOG");//Base_WebApiLog
            //����
            this.HasKey(t => t.F_LogId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
