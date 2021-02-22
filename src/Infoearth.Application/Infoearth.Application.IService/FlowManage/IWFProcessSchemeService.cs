﻿using Infoearth.Application.Entity.FlowManage;
namespace Infoearth.Application.IService.FlowManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.1.7
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：陈彬彬
    /// 编辑人：LR0101 2016.10.27 10:45
    /// 日 期：2016.03.18 15:54
    /// 描 述：工作流实例模板内容表操作
    /// </summary>
    public interface IWFProcessSchemeService
    {
        #region 获取数据
        /// <summary>
        /// 获取实体对象
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        WFProcessSchemeEntity GetEntity(string keyValue);
        /// <summary>
        /// 获取实体对象根据流程模板Id
        /// </summary>
        /// <param name="schemeId"></param>
        /// <returns></returns>
        WFProcessSchemeEntity GetEntityBySchemeId(string schemeId);
        /// <summary>
        /// 获取实体对象根据功能模块Id
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        WFProcessSchemeEntity GetEntityByModuleId(string moduleId);
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存实体数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        string SaveEntity(string keyValue, WFProcessSchemeEntity entity);
        #endregion
    }
}
