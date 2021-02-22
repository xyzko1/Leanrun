using Infoearth.Application.Entity.DemoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.DemoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 
    /// 创 建：超级管理员
    /// 日 期：2017-07-21 16:01
    /// 描 述：行政区域表
    /// </summary>
    public interface Base_AreaIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<Base_AreaEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<Base_AreaEntity> GetList(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        Base_AreaEntity GetEntity(string keyValue);
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
        void SaveForm(string keyValue, Base_AreaEntity entity);
        #endregion
    }
}
