﻿using Infoearth.Application.Entity.CustomerManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.CustomerManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：佘赐雄
    /// 日 期：2016-03-21 16:10
    /// 描 述：商机跟进记录
    /// </summary>
    public class TrailRecordMap : EntityTypeConfiguration<TrailRecordEntity>
    {
        public TrailRecordMap()
        {
            #region 表、主键
            //表
            this.ToTable("CLIENT_TRAILRECORD");//Client_TrailRecord
            //主键
            this.HasKey(t => t.F_TrailId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}