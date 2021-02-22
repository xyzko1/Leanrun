using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 11:51
    /// 描 述：地面沉降调查表历史表
    /// </summary>
    public interface TBL_LANDSETTLEMENT_HISTORYIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<TBL_LANDSETTLEMENT_HISTORYEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_LANDSETTLEMENT_HISTORYEntity> GetList(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TBL_LANDSETTLEMENT_HISTORYEntity GetEntity(string keyValue);
        TBL_LANDSETTLEMENT_HISTORYEntity GetEntityByUNIFIEDCODE(string keyValue);
        /// <summary>
        /// 获取当前实体前最近审核通过的实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TBL_LANDSETTLEMENT_HISTORYEntity GetAuditEntity(string keyValue);

        /// <summary>
        /// 获取最新审核的数据
        /// </summary>
        /// <param name="unifycode"></param>
        /// <returns></returns>
        TBL_LANDSETTLEMENT_HISTORYEntity GetLatestEntity(string unifycode);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        string SaveForm(string keyValue, TBL_LANDSETTLEMENT_HISTORYEntity entity);

         /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity"></param>
        void InsertEntity(TBL_LANDSETTLEMENT_HISTORYEntity entity);
        #endregion
    }
}
