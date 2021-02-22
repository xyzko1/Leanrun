using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:19
    /// 描 述：群测群防防灾预案表
    /// </summary>
    public interface TBL_QCQF_DISASTERPREVENTIONIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<TBL_QCQF_DISASTERPREVENTIONEntity> GetPageList(Pagination pagination, string queryJson);     
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_QCQF_DISASTERPREVENTIONEntity> GetList(string queryJson);
       
        
        DataTable GetAnalyseListQCQF(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TBL_QCQF_DISASTERPREVENTIONEntity GetEntity(string keyValue);
        /// <summary>
        /// 群测群防统计
        /// </summary>
        /// <returns></returns>
        DataTable GetQCQFStatistics(string queryJson);
        /// <summary>
        /// 获取省市县群测群防总数
        /// </summary>
        /// <param name="xzqhcode"></param>
        /// <returns></returns>
        DataTable GetQCQFCount(string xzqhcode);
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
        void SaveForm(string keyValue, TBL_QCQF_DISASTERPREVENTIONEntity entity);
        #endregion
    }
}
