using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-05-25 16:29
    /// 描 述：防治规划成果表
    /// </summary>
    public interface TBL_ACHIEVEMENT_PREPLANIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> GetList(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TBL_ACHIEVEMENT_PREPLANEntity GetEntity(string keyValue);

        IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> GetZYPageList(string queryJson, string condition);
        /// <summary>
        /// 防治规划成果统计
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <param name="CityName"></param>
        /// <param name="CountyName"></param>
        /// <param name="PREPLANYEAR"></param>
        /// <param name="PREPLANUNIT"></param>
        /// <param name="DCType"></param>
        /// <returns></returns>
        DataTable PREPLANCountStatics(string ProvinceName, string CityName, string CountyName, string PREPLANYEAR, string PREPLANUNIT, string DCType);
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
        void SaveForm(string keyValue, TBL_ACHIEVEMENT_PREPLANEntity entity);
        #endregion
    }
}
