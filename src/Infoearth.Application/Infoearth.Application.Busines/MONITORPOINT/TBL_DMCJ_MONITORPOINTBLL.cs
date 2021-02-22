using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Application.IService.MONITORPOINT;
using Infoearth.Application.Service.MONITORPOINT;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;

namespace Infoearth.Application.Busines.MONITORPOINT
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-22 18:23
    /// 描 述：地面沉降监测点信息表
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTBLL
    {
        private TBL_DMCJ_MONITORPOINTIService service = new TBL_DMCJ_MONITORPOINTService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_DMCJ_MONITORPOINTEntity> GetPageList(Pagination pagination, string queryJson, string condition)
        {
            return service.GetPageList(pagination, queryJson,condition);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_DMCJ_MONITORPOINTEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }

        public IEnumerable<TBL_DMCJ_MONITORPOINTEntity> GetZYList(string queryJson, string condition) {
            return service.GetZYList(queryJson,condition);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_DMCJ_MONITORPOINTEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
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
        public void SaveForm(string keyValue, TBL_DMCJ_MONITORPOINTEntity entity)
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
        public string GetMaxCode(string xzqh)
        {
            return service.GetMaxCode(xzqh);
        }
    }
}
