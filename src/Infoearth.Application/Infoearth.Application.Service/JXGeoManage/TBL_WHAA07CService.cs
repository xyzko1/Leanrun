using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using Infoearth.Util.Extension;
using System;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-26 14:28
    /// 描 述：统计分析查询语句表
    /// </summary>
    public class TBL_WHAA07CService : RepositoryFactory<TBL_WHAA07CEntity>, TBL_WHAA07CIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_WHAA07CEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_WHAA07CEntity>();

             return this.BaseRepository().FindList(GetQueryJsonToLinqExtensions(queryJson), pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_WHAA07CEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_WHAA07CEntity>();


            return this.BaseRepository().FindList(GetQueryJsonToLinqExtensions(queryJson));
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_WHAA07CEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_WHAA07CEntity entity)
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

        #region 辅助函数

        System.Linq.Expressions.Expression<Func<TBL_WHAA07CEntity,bool>> GetQueryJsonToLinqExtensions(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_WHAA07CEntity>();

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

                string REPORTTYPE = json.REPORTTYPE;
                if (!string.IsNullOrEmpty(REPORTTYPE))
                {
                    expression = expression.And(t => t.REPORTTYPE.Equals(REPORTTYPE));
                }

            }

            return expression;
        }


        #endregion
    }
}
