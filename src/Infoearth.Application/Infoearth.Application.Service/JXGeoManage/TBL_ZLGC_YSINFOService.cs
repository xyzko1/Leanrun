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
    /// 描 述：治理工程-验收
    /// </summary>
    public class TBL_ZLGC_YSINFOService : RepositoryFactory<TBL_ZLGC_YSINFOEntity>, TBL_ZLGC_YSINFOIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_ZLGC_YSINFOEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_YSINFOEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_ZLGC_YSINFOEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
         /// <summary>
        /// 
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_ZLGC_YSINFOEntity> GetListByZlgcID(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_YSINFOEntity>();
            return this.BaseRepository().FindList(queryJsonExpression(queryJson));
        }
        /// <summary>
        /// 把查询浏览页面上的通用json条件转换成linq语句
        /// </summary>
        /// <param name="queryJson">json参数</param>
        /// <returns></returns>
        System.Linq.Expressions.Expression<Func<TBL_ZLGC_YSINFOEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_YSINFOEntity>();

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
        public string SaveForm(string keyValue, TBL_ZLGC_YSINFOEntity entity)
        {
            string MEDIAGUID = "";
            if (!string.IsNullOrEmpty(keyValue))
            {
                if (this.BaseRepository().FindEntity(keyValue) == null)
                {
                    entity.MEDIAGUID = Guid.NewGuid().ToString();
                    this.BaseRepository().Insert(entity);
                    MEDIAGUID = entity.ZLGCID;
                }
                else
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                    MEDIAGUID = entity.ZLGCID;
                }
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);

            }
            return MEDIAGUID;
        }
        #endregion
    }
}
