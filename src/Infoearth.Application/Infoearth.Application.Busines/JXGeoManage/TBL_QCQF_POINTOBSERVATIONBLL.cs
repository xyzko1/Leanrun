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
    /// 日 期：2018-06-11 15:39
    /// 描 述：群测群防监测点和观测人关联表
    /// </summary>
    public class TBL_QCQF_POINTOBSERVATIONBLL
    {
        private TBL_QCQF_POINTOBSERVATIONIService service = new TBL_QCQF_POINTOBSERVATIONService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        public IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetListByID(string ID)
        {
            return service.GetListByID(ID);
        }
        public IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetListByUNIFIEDCODE(string UNIFIEDCODE)
        {
            return service.GetListByUNIFIEDCODE(UNIFIEDCODE);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_POINTOBSERVATIONEntity GetEntity(string keyValue)
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
        public void RemoveFormByID(string keyValue)
        {
            try
            {
                service.RemoveFormByID(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RemoveFormByUNIFIEDCODE(string keyValue)
        {
            try
            {
                service.RemoveFormByUNIFIEDCODE(keyValue);
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
        public void SaveForm(string keyValue, TBL_QCQF_POINTOBSERVATIONEntity entity)
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
        public void SaveFormByID(string ID, string UNIFIEDCODE)
        {
            try
            {
                service.SaveFormByID(ID, UNIFIEDCODE);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetDataJcd(string id)
        {
            return service.GetDataJcd(id);
        }
        public DataTable GetDataJcr(string id)
        {
            return service.GetDataJcr(id);
        }
        public void delegl(string id, string guid)
        {
            service.delegl(id,guid);
        }
        public void deleglnew(string id)
        {
            service.deleglnew(id);
        }
        public void deleglnewByqCqf(string id)
        {
            service.deleglnewByqCqf(id);
        }
        #endregion
    }
}
