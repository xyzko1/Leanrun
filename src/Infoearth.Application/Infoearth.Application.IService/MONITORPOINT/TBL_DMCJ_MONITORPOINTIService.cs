using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.MONITORPOINT
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-22 18:23
    /// 描 述：地面沉降监测点信息表
    /// </summary>
    public interface TBL_DMCJ_MONITORPOINTIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<TBL_DMCJ_MONITORPOINTEntity> GetPageList(Pagination pagination, string queryJson,string condition);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_DMCJ_MONITORPOINTEntity> GetList(string queryJson);
        IEnumerable<TBL_DMCJ_MONITORPOINTEntity> GetZYList(string queryJson, string condition);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TBL_DMCJ_MONITORPOINTEntity GetEntity(string keyValue);
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
        void SaveForm(string keyValue, TBL_DMCJ_MONITORPOINTEntity entity);
        #endregion
        string GetMaxCode(string xzqh);
    }
}
