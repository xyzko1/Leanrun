using Infoearth.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.PublicInfoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� �����ܴ���
    /// �� �ڣ�2016-04-25 10:45
    /// �� �����ճ̹���
    /// </summary>
    public class ScheduleMap : EntityTypeConfiguration<ScheduleEntity>
    {
        public ScheduleMap()
        {
            #region ������
            //��
            this.ToTable("BASE_SCHEDULE");//Base_Schedule
            //����
            this.HasKey(t => t.F_ScheduleId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
