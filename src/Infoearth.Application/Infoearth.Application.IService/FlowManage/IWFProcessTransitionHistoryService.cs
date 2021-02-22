﻿using Infoearth.Application.Entity.FlowManage;
using System.Collections.Generic;

namespace Infoearth.Application.IService.FlowManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：陈彬彬
    /// 日 期：2016.03.18 15:54
    /// 描 述：工作流实例节点转化记录操作接口（支持：SqlServer）
    /// </summary>
    public interface IWFProcessTransitionHistoryService
    {
        #region 获取数据
        /// <summary>
        /// 获取流转实体
        /// </summary>
        /// <param name="processId">流程实例ID</param>
        /// <param name="toNodeId">流转到的节点Id</param>
        /// <returns></returns>
        WFProcessTransitionHistoryEntity GetEntity(string processId, string toNodeId);
        /// <summary>
        /// 获取节点的流转列表
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="toNodeId"></param>
        /// <returns></returns>
        IEnumerable<WFProcessTransitionHistoryEntity> GetEntityLast(string processId, string toNodeId);
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存实例
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        int SaveEntity(string keyValue, WFProcessTransitionHistoryEntity entity);
        #endregion
    }
}
