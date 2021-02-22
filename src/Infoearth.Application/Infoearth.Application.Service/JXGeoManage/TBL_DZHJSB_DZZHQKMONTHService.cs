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
    /// 日 期：2019-05-10 09:58
    /// 描 述：TBL_DZHJSB_DZZHQKMONTH
    /// </summary>
    public class TBL_DZHJSB_DZZHQKMONTHService : RepositoryFactory<TBL_DZHJSB_DZZHQKMONTHEntity>, TBL_DZHJSB_DZZHQKMONTHIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_DZHJSB_DZZHQKMONTHEntity> GetList(string queryJson)
        {
            //var expression = LinqExtensions.True<TBL_DZHJSB_DZZHQKMONTHEntity>();
            //return this.BaseRepository().FindList(expression);

            var expression = queryJsonExpression(queryJson);
            var list = this.BaseRepository().FindList(expression).Select(t => new TBL_DZHJSB_DZZHQKMONTHEntity { GUID = t.GUID, HAPPENDATE = t.HAPPENDATE, DISTRICTCODE = t.DISTRICTCODE, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWN = t.TOWN, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, TOWNNAME = t.TOWNNAME, DISASTERTEAR = t.DISASTERTEAR, DISASTERMONTH = t.DISASTERMONTH, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, LON = t.LON, LAT = t.LAT, COURSE = t.COURSE, JTYY = t.JTYY, ZHLX = t.ZHLX, ZHDJ = t.ZHDJ, SZDX = t.SZDX, ZHGM = t.ZHGM, SZRK = t.SZRK, ZJJJSS = t.ZJJJSS, SS = t.SS, SZ = t.SZ, SW = t.SW, YWYJDCBG = t.YWYJDCBG, OCCURRENCETIME = t.OCCURRENCETIME, FILLINPERSON = t.FILLINPERSON, REVIEWPERSON = t.REVIEWPERSON, REPORTLY = t.REPORTLY, UPLOADER = t.UPLOADER, GEONO = t.GEONO }).ToList();
            return list;

        }


        System.Linq.Expressions.Expression<System.Func<TBL_DZHJSB_DZZHQKMONTHEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_DZHJSB_DZZHQKMONTHEntity>();
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                var expression1 = LinqExtensions.False<TBL_DZHJSB_DZZHQKMONTHEntity>();
                //年度
                string DISASTERTEAR = json.DISASTERYEAR;
                if (!string.IsNullOrEmpty(DISASTERTEAR))
                {
                    int DISASTERTEAR1 = Convert.ToInt32(DISASTERTEAR);
                    expression = expression.And(t => t.DISASTERTEAR == DISASTERTEAR1);
                }

                //月份
                string DISASTERMONTH = json.DISASTERMONTH;
                if (!string.IsNullOrEmpty(DISASTERMONTH))
                {
                    int DISASTERMONTH1 = Convert.ToInt32(DISASTERMONTH);
                    expression = expression.And(t => t.DISASTERMONTH == DISASTERMONTH1);
                }


            }
            return expression;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_DZHJSB_DZZHQKMONTHEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_DZHJSB_DZZHQKMONTHEntity entity)
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
