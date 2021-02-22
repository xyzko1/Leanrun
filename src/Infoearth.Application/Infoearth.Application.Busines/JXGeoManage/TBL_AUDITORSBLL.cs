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
    /// 日 期：2018-03-17 14:53
    /// 描 述：审计人表
    /// </summary>
    public class TBL_AUDITORSBLL
    {
        private TBL_AUDITORSIService service = new TBL_AUDITORSService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_AUDITORSEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_AUDITORSEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_AUDITORSEntity GetEntity(string keyValue)
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
        public void SaveFormNew(string STATE, string GUIDS)
        {
            try
            {
                service.SaveFormNew(STATE, GUIDS);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void deleteNew(string GUIDS)
        {
            try
            {
                service.deleteNew(GUIDS);
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
        public void SaveForm(string keyValue, TBL_AUDITORSEntity entity)
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
        /// 更新是否开始审核
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="audit"></param>
        public void UpdateAudit(string keyValue, string audit)
        {
            TBL_AUDITORSEntity userEntity = GetEntity(keyValue);
            userEntity.ISAUDIT = audit;
            service.SaveForm(keyValue, userEntity);
        }

        /// <summary>
        /// 根据行政区划和业务类型查找审核人
        /// </summary>
        /// <param name="distinct"></param>
        /// <param name="bussnessType"></param>
        /// <returns></returns>
        public string GetAudits(string distinct,string bussnessType)
        {
            try
            {
               return service.GetAudits(distinct, bussnessType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
