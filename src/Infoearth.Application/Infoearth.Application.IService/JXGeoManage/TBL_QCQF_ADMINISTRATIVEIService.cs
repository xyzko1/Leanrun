using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:15
    /// 描 述：群测群防行政管理体系
    /// </summary>
    public interface TBL_QCQF_ADMINISTRATIVEIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<TBL_QCQF_ADMINISTRATIVEEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_QCQF_ADMINISTRATIVEEntity> GetList(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TBL_QCQF_ADMINISTRATIVEEntity GetEntity(string keyValue);
        /// <summary>
        /// 根据DISTRICTCODE获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TBL_QCQF_AMINISTRATIVELXR GetDISTRICTCODEEntity(string DISTRICTCODE);
        TBL_QCQF_ADMINISTRATIVEEntity GetTBL_QCQF_ADMINISTRATIVEEntity(string DISTRICTCODE);
        
        #endregion
        object PdState(string id);
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
        void SaveForm(string keyValue, TBL_QCQF_ADMINISTRATIVEEntity entity);
        /// <summary>
        /// 根据DISTRICTCODE保存表单（新增、修改）
        /// </summary>
        /// <param name="DISTRICTCODE"></param>
        /// <param name="entity"></param>
        void UpdateForm(string DISTRICTCODE, TBL_QCQF_ADMINISTRATIVEEntity entity);
        #endregion
    }
}
