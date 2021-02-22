using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using System;
using Infoearth.Util.Extension;
using System.Reflection;
using System.Data;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:21
    /// 描 述：群测群防避灾明白卡
    /// </summary>
    public class TBL_QCQF_ESCUNDERSTANDCARDService : RepositoryFactory<TBL_QCQF_ESCUNDERSTANDCARDEntity>, TBL_QCQF_ESCUNDERSTANDCARDIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetPageList(Pagination pagination, string queryJson)
        {
            //var expression = LinqExtensions.True<TBL_QCQF_ESCUNDERSTANDCARDEntity>();
            //return this.BaseRepository().FindList(expression,pagination);
            return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_ESCUNDERSTANDCARDEntity>();
            return this.BaseRepository().FindList(expression);

        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_ESCUNDERSTANDCARDEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetEntity2(string queryJson)
        {
            return this.BaseRepository().FindList(queryJsonExpression(queryJson));
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
        public TBL_QCQF_ESCUNDERSTANDCARDEntity  SaveForm(string keyValue, TBL_QCQF_ESCUNDERSTANDCARDEntity entity)
        {         
            if (!string.IsNullOrEmpty(entity.GUID))
            {
                entity.Modify(entity.GUID);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.GUID = Guid.NewGuid().ToString();
                // entity.Create();
                this.BaseRepository().Insert(entity);
            }
             var data =  GetEntity(entity.GUID);
            return data;
        }
        /// <summary>
        /// 根据灾害点编号查询避灾明白卡数据
        /// </summary>
        /// <param name="queryJson">json参数</param>
        /// <returns></returns>
        System.Linq.Expressions.Expression<Func<TBL_QCQF_ESCUNDERSTANDCARDEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_ESCUNDERSTANDCARDEntity>();

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

                var expression1 = LinqExtensions.False<TBL_QCQF_ESCUNDERSTANDCARDEntity>();

                //灾害点编号
                string UNIFIEDCODE = json.UNIFIEDCODE;
                if (!string.IsNullOrEmpty(UNIFIEDCODE))
                {
                    expression = expression.And(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE));
                }
            }

            return expression;
        }
        #endregion
    }
}
