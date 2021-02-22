using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Application.IService.MONITORPOINT;
using Infoearth.Application.Service.MONITORPOINT;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;
using Infoearth.Application.Entity;

namespace Infoearth.Application.Busines.MONITORPOINT
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-26 16:55
    /// 描 述：地面沉降监测数据
    /// </summary>
    public class TBL_DMCJ_MONITORDATABLL
    {
        private TBL_DMCJ_MONITORDATAIService service = new TBL_DMCJ_MONITORDATAService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_DMCJ_MONITORDATAQuery> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_DMCJ_MONITORDATAQuery> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_DMCJ_MONITORDATAEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                service.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, TBL_DMCJ_MONITORDATAEntity entity)
        {
            try
            {
                service.SaveEntity(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        /// <summary>
        /// 监测数据统计
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetQueryList(string queryJson) 
       {
           return service.GetQueryList(queryJson);
       }
        /// <summary>
        /// 根据监测点统计数据
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetQueryListByMonitorPoint(string queryJson)
        {
            return service.GetQueryListByMonitorPoint(queryJson);
        }
        /// <summary>
        /// 地面沉降水位线
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetQueryList_Contour(string queryJson) 
        {
            return service.GetQueryList_Contour(queryJson);
        }
    }
}
