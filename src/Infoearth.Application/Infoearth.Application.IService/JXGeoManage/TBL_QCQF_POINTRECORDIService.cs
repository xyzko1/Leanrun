using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-13 16:23
    /// 描 述：群测群防监测流水数据表
    /// </summary>
    public interface TBL_QCQF_POINTRECORDIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<TBL_QCQF_POINTRECORDEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_QCQF_POINTRECORDEntity> GetList(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TBL_QCQF_POINTRECORDEntity GetEntity(string keyValue);
        TBL_QCQF_POINTRECORDEntity GetFormByMONITORPOINTGUID(string keyValue);
        IEnumerable<TBL_QCQF_POINTRECORDEntity> GetListByUploadName(string queryJson);
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
        void SaveForm(string keyValue, TBL_QCQF_POINTRECORDEntity entity);
        void SaveFormByMONITORPOINTGUID(string keyValue, TBL_QCQF_POINTRECORDEntity entity);
        #endregion
    }
}
