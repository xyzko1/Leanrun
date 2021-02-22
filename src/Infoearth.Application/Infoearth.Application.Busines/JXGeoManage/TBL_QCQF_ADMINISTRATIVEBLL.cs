using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:15
    /// 描 述：群测群防行政管理体系
    /// </summary>
    public class TBL_QCQF_ADMINISTRATIVEBLL
    {
        private TBL_QCQF_ADMINISTRATIVEIService service = new TBL_QCQF_ADMINISTRATIVEService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_QCQF_ADMINISTRATIVEEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_ADMINISTRATIVEEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }       
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_ADMINISTRATIVEEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        /// <summary>
        /// 根据DISTRICTCODE获取实体
        /// </summary>
        /// <param name="DISTRICTCODE">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_AMINISTRATIVELXR GetDISTRICTCODEEntity(string DISTRICTCODE)
        {
            return service.GetDISTRICTCODEEntity(DISTRICTCODE);
        }
        public TBL_QCQF_ADMINISTRATIVEEntity GetTBL_QCQF_ADMINISTRATIVEEntity(string DISTRICTCODE)
        {
            return service.GetTBL_QCQF_ADMINISTRATIVEEntity(DISTRICTCODE);
        }
        public object PdState(string id)
        {
            return service.PdState(id);
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
        public void SaveForm(string keyValue, TBL_QCQF_ADMINISTRATIVEEntity entity)
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
        /// <summary>
        /// 根据DISTRICTCODE保存表单（新增、修改）
        /// </summary>
        /// <param name="DISTRICTCODE"></param>
        /// <param name="entity"></param>
        public void UpdateForm(string DISTRICTCODE, TBL_QCQF_ADMINISTRATIVEEntity entity)
        {
            try
            {
                service.UpdateForm(DISTRICTCODE, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
