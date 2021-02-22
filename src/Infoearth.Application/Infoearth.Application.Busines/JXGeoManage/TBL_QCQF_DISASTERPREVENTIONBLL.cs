using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:19
    /// 描 述：群测群防防灾预案表
    /// </summary>
    public class TBL_QCQF_DISASTERPREVENTIONBLL
    {
        private TBL_QCQF_DISASTERPREVENTIONIService service = new TBL_QCQF_DISASTERPREVENTIONService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_QCQF_DISASTERPREVENTIONEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }      
        /// <summary>
        /// 群测群防统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetQCQFStatistics(string queryJson)
        {
            return service.GetQCQFStatistics(queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_DISASTERPREVENTIONEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
       
        
        public DataTable GetAnalyseListQCQF(string queryJson) {
            return service.GetAnalyseListQCQF(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_DISASTERPREVENTIONEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        /// <summary>
        /// 获取省市县群测群防总数
        /// </summary>
        /// <param name="xzqhcode"></param>
        /// <returns></returns>
        public DataTable GetQCQFCount(string xzqhcode)
        {
            return service.GetQCQFCount(xzqhcode);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TBL_QCQF_DISASTERPREVENTIONEntity entity)
        {
            try
            {
                service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
