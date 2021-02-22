using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-03-31 10:30
    /// 描 述：商机信息表
    /// </summary>
    public class Client_ChanceMap : EntityTypeConfiguration<Client_ChanceEntity>
    {
        public Client_ChanceMap()
        {
            #region 表、主键
            //表
            this.ToTable("Client_Chance");
            //主键
            this.HasKey(t => t.F_ChanceId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
