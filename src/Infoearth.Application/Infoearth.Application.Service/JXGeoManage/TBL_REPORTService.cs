using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-28 16:05
    /// 描 述：统计公用报表
    /// </summary>
    public class TBL_REPORTService : RepositoryFactory<TBL_REPORTEntity>, TBL_REPORTIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_REPORTEntity> GetPageList(Pagination pagination, string queryJson)
        {
            System.Linq.Expressions.Expression<Func<TBL_REPORTEntity, bool>> expression = GetExpression(queryJson);
            return this.BaseRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        private Expression<Func<TBL_REPORTEntity, bool>> GetExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_REPORTEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                dynamic json = JToken.Parse(queryJson) as dynamic;

                //模块名称
                string module = json.module;
                if (!string.IsNullOrEmpty(module))
                {
                    expression = expression.And(testc => testc.MODULE == module);
                }

                //开始时间
                string beginTime = json.beginTime;
                if (!string.IsNullOrEmpty(beginTime))
                {
                    DateTime begin = DateTime.Parse(beginTime);
                    expression = expression.And(testc => testc.CREATETIME >= begin);
                }

                //结束时间
                string endTime = json.endTime;
                if (!string.IsNullOrEmpty(endTime))
                {
                    DateTime end = DateTime.Parse(endTime);
                    expression = expression.And(testc => testc.CREATETIME >= end);
                }
            }

            return expression;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_REPORTEntity> GetList(string queryJson)
        {
            return this.BaseRepository().FindList(GetExpression(queryJson)).OrderByDescending(t => t.CREATETIME);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_REPORTEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_REPORTEntity entity)
        {
            var user= ssoWS.GetUserInfo();
            entity.CREATEPEOPLE = user.F_Account;
            entity.CREATETIME = DateTime.Now;

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
