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
    /// 日 期：2018-03-17 14:51
    /// 描 述：审核信息表
    /// </summary>
    public class TBL_AUDITINFOBLL
    {
        private TBL_AUDITINFOIService service = new TBL_AUDITINFOService();

        #region 获取数据
        /// <summary>
        /// 获取提交列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_AUDITINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// 获取审核列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_AUDITINFOEntity> GetPageList2(Pagination pagination, string queryJson)
        {
            return service.GetPageList2(pagination, queryJson);
        }
        /// <summary>
        /// 获取未审核的数据列表
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_AUDITINFOEntity> GetPageList3(string queryJson)
        {
            return service.GetPageList3(queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_AUDITINFOEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_AUDITINFOEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_AUDITINFOEntity entity)
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


        /// <summary>
        /// 提交审核
        /// </summary>
        /// <param name="keyValue">业务ID</param>
        public void SubmitAudit(string keyValue)
        {
            try
            {
                service.SubmitAudit(keyValue);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// 撤销审核
        /// </summary>
        /// <param name="keyValue">业务ID</param>
        public void CancelSubmit(string keyValue)
        {
            try
            {
                service.CancelSubmit(keyValue);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// 审核数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="state">状态</param>
        /// <param name="comment">备注</param>
        public void AuditData(string keyValue, int state, string comment)
        {
            try
            {
                service.AuditData(keyValue, state, comment);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 核销数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="submitStr"></param>
        public void Verification(string keyValue, int verificationType)
        {
            try
            {
                service.VerificationData(keyValue, verificationType,DateTime.Now);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
