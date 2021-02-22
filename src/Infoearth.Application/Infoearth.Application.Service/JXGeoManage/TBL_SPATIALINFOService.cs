using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-28 14:23
    /// 描 述：范围数据表
    /// </summary>
    public class TBL_SPATIALINFOService : RepositoryFactory<TBL_SPATIALINFOEntity>, TBL_SPATIALINFOIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_SPATIALINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
             return this.BaseRepository().FindList(pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_SPATIALINFOEntity> GetList(string queryJson)
        {
            return this.BaseRepository().IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_SPATIALINFOEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        /// <summary>
        ///  根据图层编号、灾害点编号获取数据
        /// </summary>
        /// <param name="layerid">图层编号</param>
        /// <param name="subcode">灾害点编号</param>
        /// <returns></returns>
        public IEnumerable<TBL_SPATIALINFOEntity> GetDataLayer(string layerid, string subcode)
        {
            string sql = string.Format("select * from TBL_SPATIALINFO t  where layerid = '{0}' and  subcode like  '{1}%'", layerid, subcode);
            return this.BaseRepository().FindList(sql);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void DeleteEntity(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        public void DeleteEntityNew(string keyValue)
        {
            //this.BaseRepository().Delete(keyValue);
            var parameter = new List<DbParameter>();
            string sql = "DELETE FROM TBL_SPATIALINFO where SUBCODE = '" + keyValue+"'" ;
            this.BaseRepository().ExecuteBySql(sql, parameter.ToArray());
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, TBL_SPATIALINFOEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion


       
    }
}
