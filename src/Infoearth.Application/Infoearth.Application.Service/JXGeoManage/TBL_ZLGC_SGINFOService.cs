using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;


namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:31
    /// 描 述：治理工程-施工
    /// </summary>
    public class TBL_ZLGC_SGINFOService : RepositoryFactory<TBL_ZLGC_SGINFOEntity>, TBL_ZLGC_SGINFOIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_ZLGC_SGINFOEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_SGINFOEntity>();
            return this.BaseRepository().FindList(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_ZLGC_SGINFOEntity> GetListByZlgcID(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_SGINFOEntity>();
            return this.BaseRepository().FindList(queryJsonExpression(queryJson));
        }

        /// <summary>
        /// 根据治理工程编号获取对应的工程施工列表信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public IEnumerable<TBL_ZLGC_SGINFOEntity> GetListByZLGCID(Pagination pagination, string queryJson)
        { 
            //ZLGCID
            var expression = LinqExtensions.True<TBL_ZLGC_SGINFOEntity>();
          
        
            return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);
        }

        /// <summary>
        /// 把查询浏览页面上的通用json条件转换成linq语句
        /// </summary>
        /// <param name="queryJson">json参数</param>
        /// <returns></returns>
        System.Linq.Expressions.Expression<Func<TBL_ZLGC_SGINFOEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_SGINFOEntity>();

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                string ZLGCID = "";
                //工程编号
                if (json.ZLGCID != "" && json.ZLGCID != null)
                {
                    ZLGCID = json.ZLGCID;
                }
                else
                {
                    ZLGCID = "空";
                }
                if (!string.IsNullOrEmpty(ZLGCID))
                {
                    expression = expression.And(t => t.ZLGCID.Contains(ZLGCID));
                }
            }
            return expression;
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_ZLGC_SGINFOEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
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
        public string SaveForm(string keyValue, TBL_ZLGC_SGINFOEntity entity)
        {
                string MEDIAGUID = "";
                if (this.BaseRepository().FindEntity(keyValue) == null)
                {
                    entity.GUID = Guid.NewGuid().ToString();
                    this.BaseRepository().Insert(entity);
                    MEDIAGUID = entity.ZLGCID;
                }
                else
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                    MEDIAGUID = entity.ZLGCID;
                }
               return MEDIAGUID;
        }
        #endregion
    }
}
