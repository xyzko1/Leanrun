using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-13 16:23
    /// 描 述：群测群防监测流水数据表
    /// </summary>
    public class TBL_QCQF_POINTRECORDService : RepositoryFactory<TBL_QCQF_POINTRECORDEntity>, TBL_QCQF_POINTRECORDIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_QCQF_POINTRECORDEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_QCQF_POINTRECORDEntity>();
             return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_POINTRECORDEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_POINTRECORDEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_POINTRECORDEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        public TBL_QCQF_POINTRECORDEntity GetFormByMONITORPOINTGUID(string keyValue)
        {
            return this.BaseRepository().FindEntity(t=>t.MONITORPOINTGUID== keyValue);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_POINTRECORDEntity> GetListByUploadName(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_POINTRECORDEntity>();
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                //关键字
                string UPLOADNAME = json.UPLOADNAME;
                if (!string.IsNullOrEmpty(UPLOADNAME))
                {
                    expression = expression.And(t => t.UPLOADNAME.Contains(UPLOADNAME));
                }
            }
            return this.BaseRepository().FindList(expression);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TBL_QCQF_POINTRECORDEntity entity)
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
        public void SaveFormByMONITORPOINTGUID(string keyValue, TBL_QCQF_POINTRECORDEntity entity)
        {
            TBL_QCQF_POINTRECORDEntity entity_his = this.BaseRepository().FindEntity(t => t.MONITORPOINTGUID == keyValue);
            if (entity_his!=null)
            {
                entity.GUID = entity_his.GUID;
                entity.MONITORPOINTGUID = keyValue;
                entity.MONITORTIME = entity_his.MONITORTIME;
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                entity.MONITORPOINTGUID = keyValue;
                entity.MONITORTIME = DateTime.Now;
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
