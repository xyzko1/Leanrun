using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 15:53
    /// 描 述：解译工程项目基本信息表
    /// </summary>
    public interface JYGC_PROJECTBASEINFOIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<JYGC_PROJECTBASEINFOEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<JYGC_PROJECTBASEINFOEntity> GetList(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        JYGC_PROJECTBASEINFOEntity GetEntity(string keyValue);
        /// <summary>
        /// 获取或者创建一个项目ID
        /// </summary>
        /// <param name="projectName">项目名称</param>
        /// <returns></returns>
        JYGC_PROJECTBASEINFOEntity GetOrCreateProjectId(string projectName);
        List<string> GetProjectIDList(string queryJson);
        List<JYGC_PROJECTBASEINFOEntity> GetListByDateDiff(string queryJson);
        #endregion

        string GetTCYearProject(string queryJson);
        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void SaveEntity(string keyValue, JYGC_PROJECTBASEINFOEntity entity);

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
        void SaveForm(string keyValue, JYGC_PROJECTBASEINFOEntity entity);
        #endregion
        
    }
}
