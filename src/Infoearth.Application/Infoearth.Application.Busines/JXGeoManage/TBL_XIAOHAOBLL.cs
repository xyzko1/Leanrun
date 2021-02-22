using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;

namespace Infoearth.Application.Busines.JXGeoManage
{
    public class TBL_XIAOHAOBLL
    {
        private TBL_XIAOHAOIService service = new TBL_XIAOHAOService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_XIAOHAOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        public IEnumerable<TBL_XIAOHAOEntity> GetSinglePastPageListJson(Pagination pagination, string queryJson, string condition)
        {
            return service.GetSinglePastPageListJson(pagination, queryJson, condition);
        }
        public IEnumerable<TBL_XIAOHAOEntity> GetHXMapList(string queryJson, string condition)
        {
            return service.GetHXMapList(queryJson, condition);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_XIAOHAOEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_XIAOHAOEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_XIAOHAOEntity entity, ref int statusCode)
        {
            try
            {
                service.SaveForm(keyValue, entity, ref statusCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除隐患点
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteHidden(string keyValue)
        {
            try
            {
                service.DeleteHidden(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
