using Infoearth.Application.Entity.JXGeoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.JXGeoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:23
    /// 描 述：群测群防工作明白卡
    /// </summary>
    public class TBL_QCQF_WORKUNDERSTANDCARDMap : EntityTypeConfiguration<TBL_QCQF_WORKUNDERSTANDCARDEntity>
    {
        public TBL_QCQF_WORKUNDERSTANDCARDMap()
        {
            #region 表、主键
            //表
            this.ToTable("TBL_QCQF_WORKUNDERSTANDCARD");
            //主键
            this.HasKey(t => t.UNIFIEDCODE);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
