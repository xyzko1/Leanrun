using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Infoearth.Util.Extension;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-26 16:29
    /// 描 述：人文经济学校信息表
    /// </summary>
    public class TBL_RWJJ_SCHOOLService : RepositoryFactory<TBL_RWJJ_SCHOOLEntity>, TBL_RWJJ_SCHOOLIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_RWJJ_SCHOOLEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<TBL_RWJJ_SCHOOLEntity>();
            return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);
        }
        /// <summary>
        /// 把查询浏览页面上的通用json条件转换成linq语句
        /// </summary>
        /// <param name="queryJson">json参数</param>
        /// <returns></returns>
        System.Linq.Expressions.Expression<Func<TBL_RWJJ_SCHOOLEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_RWJJ_SCHOOLEntity>();
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            string province = json.PROVINCE;
            string city = json.CITY;
            string county = json.COUNTY;

            #region 根据省市县编号查询
            var expression1 = LinqExtensions.False<TBL_RWJJ_SCHOOLEntity>();
            //镇
            string TOWN = json.TOWN;
            if (!string.IsNullOrEmpty(TOWN))
            {
                foreach (var ton in TOWN.Split(','))
                {
                    expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(2, 9).Equals(ton));
                }
                expression = expression.And(expression1);
            }
            else
            {
                //县
                string COUNTY = json.COUNTY;
                if (!string.IsNullOrEmpty(COUNTY))
                {
                    foreach (var ton in COUNTY.Split(','))
                    {
                        expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(2, 6).Equals(ton));
                    }
                    expression = expression.And(expression1);
                }
                else
                {
                    //市
                    string CITY = json.CITY;
                    if (!string.IsNullOrEmpty(CITY))
                    {
                        foreach (var ton in CITY.Split(','))
                        {
                            expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(2, 4).Equals(ton.Substring(0, 4)));
                        }
                        expression = expression.And(expression1);
                    }
                    else
                    {
                        //省
                        string PROVINCE = json.PROVINCE;
                        if (!string.IsNullOrEmpty(PROVINCE))
                        {
                            foreach (var ton in PROVINCE.Split(','))
                            {
                                expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(2, 2).Equals(ton.Substring(0, 2)));
                            }
                            expression = expression.And(expression1);
                        }

                    }
                }
            }
            #endregion

            //单位名称筛选
            string NAME = "";
            if (json.NAME != "" && json.NAME != null)
            {
                NAME = json.NAME;
            }
            if (!string.IsNullOrEmpty(NAME))
            {
                expression = expression.And(t => t.NAME.Contains(NAME));
            }
            return expression;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_RWJJ_SCHOOLEntity> GetList(string queryJson)
        {
             var expression = LinqExtensions.True<TBL_RWJJ_SCHOOLEntity>();
             return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_RWJJ_SCHOOLEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_RWJJ_SCHOOLEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                //entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
