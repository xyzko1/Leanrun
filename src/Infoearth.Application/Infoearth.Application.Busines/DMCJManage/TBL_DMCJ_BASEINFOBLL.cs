using Infoearth.Application.Entity.DMCJManage;
using Infoearth.Application.IService.DMCJManage;
using Infoearth.Application.Service.DMCJManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using Infoearth.Application.Entity;
using System.Data;

namespace Infoearth.Application.Busines.DMCJManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-22 12:10
    /// 描 述：地面沉降调查表
    /// </summary>
    public class TBL_DMCJ_BASEINFOBLL
    {
        private TBL_DMCJ_BASEINFOIService service = new TBL_DMCJ_BASEINFOService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_DMCJ_BASEINFOEntity> GetPageList(Pagination pagination, string queryJson,string condition)
        {
            return service.GetPageList(pagination, queryJson,condition);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_DMCJ_BASEINFOEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        public IEnumerable<TBL_DMCJ_BASEINFOEntity> GetZYList(string queryJson, string condition) {
            return service.GetZYList(queryJson, condition);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_DMCJ_BASEINFOEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }

        /// <summary>
        /// 取所有输入字段的值列表
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<string> GetValueList(string queryJson)
        {
            return service.GetValueList(queryJson);
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
        public void SaveForm(string keyValue, MasterDetailEntity entity)
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

        public EchartEntity GetStatisticsByDmcj() {
            return service.GetStatisticsByDmcj();
        }
        public DataTable GetStatisticsByDmcjPie() {
            return service.GetStatisticsByDmcjPie();
        }
        public string GetMaxCode(string xzqh)
        {
            return service.GetMaxCode(xzqh);
        }
    }
}
