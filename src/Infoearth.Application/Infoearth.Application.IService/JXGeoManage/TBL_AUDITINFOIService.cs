using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-17 14:51
    /// 描 述：审核信息表
    /// </summary>
    public interface TBL_AUDITINFOIService
    {
        #region 获取数据
        /// <summary>
        /// 获取提交列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<TBL_AUDITINFOEntity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取审核列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<TBL_AUDITINFOEntity> GetPageList2(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取未审核的数据列表
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<TBL_AUDITINFOEntity> GetPageList3(string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_AUDITINFOEntity> GetList(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TBL_AUDITINFOEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void SaveForm(string keyValue, TBL_AUDITINFOEntity entity);

        /// <summary>
        /// 提交审核
        /// </summary>
        /// <param name="keyValue">业务ID</param>
        void SubmitAudit(string keyValue);

        /// <summary>
        /// 撤销审核
        /// </summary>
        /// <param name="keyValue">业务ID</param>
        void CancelSubmit(string keyValue);

        /// <summary>
        /// 审核数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="state">状态</param>
        /// <param name="comment">备注</param>
        void AuditData(string keyValue, int state, string comment);

        /// <summary>
        /// 核销数据
        /// </summary>
        /// <param name="unifycode">灾害点编号</param>
        /// <param name="verification">核销类型</param>
        void VerificationData(string unifycode, int verification, DateTime fillTableDate);

        #endregion
    }
}
