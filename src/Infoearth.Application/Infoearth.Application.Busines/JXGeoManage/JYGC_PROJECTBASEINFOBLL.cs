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
    /// 日 期：2018-03-16 15:53
    /// 描 述：解译工程项目基本信息表
    /// </summary>
    public class JYGC_PROJECTBASEINFOBLL
    {
        private JYGC_PROJECTBASEINFOIService service = new JYGC_PROJECTBASEINFOService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<JYGC_PROJECTBASEINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<JYGC_PROJECTBASEINFOEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public JYGC_PROJECTBASEINFOEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        public List<string> GetProjectIDList(string queryJson)
        {
            return service.GetProjectIDList(queryJson);
        }
        public List<JYGC_PROJECTBASEINFOEntity> GetListByDateDiff(string queryJson)
        {
            return service.GetListByDateDiff(queryJson);
        }
        /// <summary>
        /// 获取或者创建一个项目ID
        /// </summary>
        /// <param name="projectName">项目名称</param>
        /// <returns></returns>
        public JYGC_PROJECTBASEINFOEntity GetOrCreateProjectId(string projectName)
        {
            return service.GetOrCreateProjectId(projectName);
        }
        public string GetTCYearProject(string queryJson)
        {
            return service.GetTCYearProject(queryJson);
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
        public void SaveEntity(string keyValue, JYGC_PROJECTBASEINFOEntity entity)
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
        public void SaveForm(string keyValue, JYGC_PROJECTBASEINFOEntity entity)
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
