using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 11:13
    /// 描 述：灾害点历史信息基本表
    /// </summary>
    public class TBL_HAZARDBASICINFO_HISTORYBLL
    {
        private TBL_HAZARDBASICINFO_HISTORYIService service = new TBL_HAZARDBASICINFO_HISTORYService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <param name="condition">空间查询条件</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetPageList(Pagination pagination, string queryJson,string condition)
        {
            return service.GetPageList(pagination, queryJson, condition);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <param name="condition">空间查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetList(string queryJson,string condition)
        {
            return service.GetList(queryJson, condition);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_HAZARDBASICINFO_HISTORYEntity GetEntity(string keyValue)
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
        public void SaveEntity(string keyValue, TBL_HAZARDBASICINFO_HISTORYEntity entity)
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
    }
}
