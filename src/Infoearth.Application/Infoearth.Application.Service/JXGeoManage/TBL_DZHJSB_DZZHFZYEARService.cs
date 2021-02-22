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
    /// 日 期：2019-05-09 14:25
    /// 描 述：TBL_DZHJSB_DZZHFZYEAR
    /// </summary>
    public class TBL_DZHJSB_DZZHFZYEARService : RepositoryFactory<TBL_DZHJSB_DZZHFZYEAREntity>, TBL_DZHJSB_DZZHFZYEARIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_DZHJSB_DZZHFZYEAREntity> GetList(string queryJson)
        {
           // var expression = LinqExtensions.True<TBL_DZHJSB_DZZHFZYEAREntity>();
            var expression = queryJsonExpression(queryJson);
            var list = this.BaseRepository().FindList(expression).Select(t => new TBL_DZHJSB_DZZHFZYEAREntity { GUID = t.GUID, DISTRICTCODE = t.DISTRICTCODE, PROVINCE = t.PROVINCE, CITY = t.CITY, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, DISASTERYEAR = t.DISASTERYEAR, BZ = t.BZ, AVOIDDISAATER = t.AVOIDDISAATER, AVOIDHURTHUMAN = t.AVOIDHURTHUMAN, DIRECTECONOMICLOSS = t.DIRECTECONOMICLOSS, CDYJCZXZ = t.CDYJCZXZ, CYYJCLDZZH = t.CYYJCLDZZH, DZZHFZXM = t.DZZHFZXM, GOVERNPROJECT = t.GOVERNPROJECT, JCYJXM = t.JCYJXM, TRFZZJ = t.TRFZZJ, REMOVALAMOUNT = t.REMOVALAMOUNT, WCDZZHWXXPGXM = t.WCDZZHWXXPGXM, HIDDENAMOUNTITOTALLY = t.HIDDENAMOUNTITOTALLY, ADDAMOUNT = t.ADDAMOUNT, CLEARAMOUNT = t.CLEARAMOUNT, BIGLARGE = t.BIGLARGE, LARGE = t.LARGE }).ToList();
            return list;
           // return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_DZHJSB_DZZHFZYEAREntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion


        System.Linq.Expressions.Expression<System.Func<TBL_DZHJSB_DZZHFZYEAREntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_DZHJSB_DZZHFZYEAREntity>();
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                var expression1 = LinqExtensions.False<TBL_DZHJSB_DZZHFZYEAREntity>();
                //年度
                string DISASTERYEAR = json.DISASTERYEAR;
                if (!string.IsNullOrEmpty(DISASTERYEAR))
                {
                    int DISASTERYEAR1 = Convert.ToInt32(DISASTERYEAR);
                    expression = expression.And(t => t.DISASTERYEAR == DISASTERYEAR1);
                }


            }
            return expression;
        }

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
        public void SaveForm(string keyValue, TBL_DZHJSB_DZZHFZYEAREntity entity)
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
