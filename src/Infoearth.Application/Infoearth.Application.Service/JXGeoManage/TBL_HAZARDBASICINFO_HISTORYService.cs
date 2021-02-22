using Infoearth.Application.Common;
using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 11:13
    /// 描 述：灾害点历史信息基本表
    /// </summary>
    public class TBL_HAZARDBASICINFO_HISTORYService : RepositoryFactory<TBL_HAZARDBASICINFO_HISTORYEntity>, TBL_HAZARDBASICINFO_HISTORYIService
    {
        private JYGC_PROJECTBASEINFOIService project = new JYGC_PROJECTBASEINFOService();
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <param name="condition">空间查询条件</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetPageList(Pagination pagination, string queryJson, string condition)
        {
            //分页查询数据
            var strWhere = GetWhereSql(queryJson);
            //var linq = this.BaseRepository().IQueryable(GetLinqExpression(queryJson, condition).And(AuthAnd()));
            //var result = from t in linq
            //             group t by t.UNIFIEDCODE into g
            //             select new
            //             {
            //                 g.Key,
            //                 data = from p2 in g where p2.FILLTABLEDATE == g.Max(p3 => p3.FILLTABLEDATE) select p2
            //             };
            var sql = @"select  c.DISASTERNAME,  c.DISASTERTYPE,  c.UNIFIEDCODE, c.PROVINCENAME,  c.CITYNAME, c.COUNTYNAME,  c.PROVINCE, c.CITY, 
 c.COUNTY, c.TOWNNAME,  c.LOCATION,  c.LONGITUDE, c.LATITUDE, c.GUID, c.PROJECTID,c.DANGERLEVEL, c.DISASTERLEVEL, 
c.DEATHTOLL,  c.ASSETSLOSE,  c.MISSINGPERSON,  c.INJUREDPERSON,  c.THREATENPEOPLE,  c.THREATENASSETS,    c.MODIFYTIME
from (select a.*, row_number() over(partition by a.UNIFIEDCODE order by a.FILLTABLEDATE desc) KRN from TBL_HAZARDBASICINFO_HISTORY a where 1=1 " + strWhere + ") c where KRN = 1 ";
            var list = new RepositoryFactory().BaseRepository().FindList<TBL_HAZARDBASICINFO_HISTORYEntity>(sql, pagination);
            //pagination.records = result.Count();
            //var temp = result.OrderBy(t => t.Key).Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows).ToList();
            //var list= temp.Select(t => t.data.FirstOrDefault());
            var queryParam = condition.ToJObject();
            List<TBL_HAZARDBASICINFO_HISTORYEntity> results = new List<TBL_HAZARDBASICINFO_HISTORYEntity>();
            results = list.ToList();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                return results.Where(s => SpatialQueryHelper.isContainPoint(WKTString, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
                //foreach (var item in list)
                //{
                //    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                //    {
                //        continue;
                //    }

                //    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                //    if (isInsert)
                //    {
                //        results.Add(item);
                //    }

                //}
                //return results;
            }
            if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                double x = queryParam["x"].ToDouble();
                double y = queryParam["y"].ToDouble();
                double radius = queryParam["radius"].ToDouble();
                return results.Where(s => SpatialQueryHelper.PointInCircle(s.LATITUDE.ToDouble(), s.LONGITUDE.ToDouble(), y, x, radius)).ToList();
                //foreach (var item in list)
                //{
                //    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                //    {
                //        continue;
                //    }

                //    bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                //    if (isInsert)
                //    {
                //        results.Add(item);
                //    }

                //}
                //return results;
            }
            if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                string polyline = queryParam["polyline"].ToString();
                double radius = queryParam["radius"].ToDouble();
                return results.Where(s => SpatialQueryHelper.IsIntersects(polyline, radius, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
                //foreach (var item in list)
                //{
                //    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                //    {
                //        continue;
                //    }

                //    bool isInsert = SpatialQueryHelper.IsIntersects(polyline, radius, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                //    if (isInsert)
                //    {
                //        results.Add(item);
                //    }

                //}
                //return results;
            }
            return list;
        }

        /// <summary>
        /// 获取条件表达式
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        private System.Linq.Expressions.Expression<Func<TBL_HAZARDBASICINFO_HISTORYEntity, bool>> GetLinqExpression(string queryJson, string condition)
        {
            var expression = LinqExtensions.True<TBL_HAZARDBASICINFO_HISTORYEntity>();
            expression = expression.And(t => !t.MODIFYTYPE.Equals("R"));//不查被删除的数据

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

                #region 省市县级联条件

                var expression1 = LinqExtensions.False<TBL_HAZARDBASICINFO_HISTORYEntity>();
                //镇
                string TOWN = json.TOWN;
                string TOWNRPT = json.TOWNRPT;
                if (!string.IsNullOrEmpty(TOWN))
                {
                    foreach (var ton in TOWN.Split(','))
                    {
                        expression1 = expression1.Or(t => t.TOWN.Equals(ton));
                    }
                    expression = expression.And(expression1);


                }
                else if (!string.IsNullOrEmpty(TOWNRPT))
                {
                    foreach (var ton in TOWNRPT.Split(','))
                    {
                        expression1 = expression1.Or(t => t.TOWN.Equals(ton));
                    }
                    expression = expression.And(expression1);


                }
                else
                {
                    //县
                    string COUNTY = json.COUNTY;
                    string COUNTYRPT = json.COUNTYRPT;
                    if (!string.IsNullOrEmpty(COUNTY))
                    {
                        foreach (var ton in COUNTY.Split(','))
                        {
                            expression1 = expression1.Or(t => t.COUNTY.Equals(ton));
                        }
                        expression = expression.And(expression1);


                    }
                    else if (!string.IsNullOrEmpty(COUNTYRPT))
                    {
                        foreach (var ton in COUNTYRPT.Split(','))
                        {
                            expression1 = expression1.Or(t => t.COUNTY.Equals(ton));
                        }
                        expression = expression.And(expression1);


                    }
                    else
                    {
                        //市
                        string CITY = json.CITY;
                        string CITYRPT = json.CITYRPT;
                        if (!string.IsNullOrEmpty(CITY))
                        {
                            foreach (var ton in CITY.Split(','))
                            {
                                expression1 = expression1.Or(t => t.CITY.Equals(ton));
                            }
                            expression = expression.And(expression1);


                        }
                        else if (!string.IsNullOrEmpty(CITYRPT))
                        {
                            foreach (var ton in CITYRPT.Split(','))
                            {
                                expression1 = expression1.Or(t => t.CITY.Equals(ton));
                            }
                            expression = expression.And(expression1);


                        }
                        else
                        {
                            //省
                            string PROVINCE = json.PROVINCE;
                            string PROVINCERPT = json.PROVINCERPT;
                            if (!string.IsNullOrEmpty(PROVINCE))
                            {
                                foreach (var ton in PROVINCE.Split(','))
                                {
                                    expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                                }
                                expression = expression.And(expression1);


                            }
                            else if (!string.IsNullOrEmpty(PROVINCERPT))
                            {
                                foreach (var ton in PROVINCERPT.Split(','))
                                {
                                    expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                                }
                                expression = expression.And(expression1);
                            }

                        }
                    }
                }

                #endregion
                //关键字
                string txt_Key = json.txt_Key;
                if (!string.IsNullOrEmpty(txt_Key))
                {
                    expression = expression.And(t => t.DISASTERNAME.Contains(txt_Key) || t.UNIFIEDCODE == txt_Key || t.LOCATION.Contains(txt_Key));
                }

                //项目类型
                string PROJECTID = json.PROJECTID;
                if (!string.IsNullOrEmpty(PROJECTID))
                {
                    expression = expression.And(t => t.PROJECTID.Equals(PROJECTID));
                }
                //灾害点名称
                string DISASTERNAME = json.DISASTERNAME;
                if (!string.IsNullOrEmpty(DISASTERNAME))
                {
                    expression = expression.And(t => t.DISASTERNAME.Contains(DISASTERNAME));
                }
                //灾害点类型
                string DISASTERTYPE = json.DISASTERTYPE;
                if (!string.IsNullOrEmpty(DISASTERTYPE))
                {
                    expression = expression.And(t => DISASTERTYPE.Contains(t.DISASTERTYPE));
                }

                //灾害点编号
                string UNIFIEDCODE = json.UNIFIEDCODE;
                if (!string.IsNullOrEmpty(UNIFIEDCODE))
                {
                    expression = expression.And(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE));
                }
                //项目名称
                string PROJECTNAME = json.PROJECTNAME;
                if (!string.IsNullOrEmpty(PROJECTNAME))
                {
                    string query = "{txt_Keyword:'" + PROJECTNAME + "'}";
                    var projectids = project.GetList(query);
                    string PROJECTIDS = "";
                    if (projectids.Count() != 0)
                    {
                        foreach (var item in projectids)
                        {
                            PROJECTIDS += item.PROJECTGUID + ",";
                        }
                        expression = expression.And(t => PROJECTIDS.Contains(t.PROJECTID));
                    }
                }
                //操作类型
                string MODIFYTYPE = json.MODIFYTYPE;
                if (!string.IsNullOrEmpty(MODIFYTYPE))
                {
                    expression = expression.And(t => t.MODIFYTYPE.Equals(MODIFYTYPE));
                }

                //是否已经核销
                string shifouhexiao = json.shifouhexiao;
                if (!string.IsNullOrEmpty(shifouhexiao))
                {
                    expression = expression.And(t => (t.ISXH == shifouhexiao));
                }

                //是否治理
                string ISZLGCPNT = json.ISZLGCPNT;
                if (!string.IsNullOrEmpty(ISZLGCPNT))
                {
                    expression = expression.And(t => ISZLGCPNT == "1" ? (t.VERIFICATION != null && t.VERIFICATION.Contains("1")) : (t.VERIFICATION == null || !t.VERIFICATION.Contains("1")));
                }

                //是否搬迁
                string RELOCATION = json.RELOCATION;
                if (!string.IsNullOrEmpty(RELOCATION))
                {
                    expression = expression.And(t => RELOCATION == "1" ? (t.VERIFICATION != null && t.VERIFICATION.Contains("2")) : (t.VERIFICATION == null || !t.VERIFICATION.Contains("2")));
                }

                //开始时间
                string BeginTime = json.BeginTime;
                if (!string.IsNullOrEmpty(BeginTime))
                {
                    DateTime begin = Convert.ToDateTime(BeginTime);
                    expression = expression.And(t => t.FILLTABLEDATE >= begin);
                }
                //结束时间
                string EndTime = json.EndTime;
                if (!string.IsNullOrEmpty(EndTime))
                {
                    DateTime end = Convert.ToDateTime(EndTime);
                    expression = expression.And(t => t.FILLTABLEDATE < end);
                }

                //灾害类型
                string DisasterType = json.DisasterType;
                if (!string.IsNullOrEmpty(DisasterType))
                {
                    expression = expression.And(t => t.DISASTERTYPE == DisasterType);
                }

                //统一编号
                string UnifyCode = json.UnifyCode;
                if (!string.IsNullOrEmpty(UnifyCode))
                {
                    expression = expression.And(testc => testc.UNIFIEDCODE == UnifyCode);
                }
            }

            //var queryParam = condition.ToJObject();

            //if (!queryParam["WKTString"].IsEmpty())
            //{
            //    string WKTString = queryParam["WKTString"].ToString();
            //    foreach (var item in data)
            //    {
            //        if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
            //        {
            //            continue;
            //        }

            //        bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
            //        if (isInsert)
            //        {
            //            result.Add(item);
            //        }

            //    }
            //    return result;
            //}
            //if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            //{
            //    double x = queryParam["x"].ToDouble();
            //    double y = queryParam["y"].ToDouble();
            //    double radius = queryParam["radius"].ToDouble();
            //    foreach (var item in data)
            //    {
            //        if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
            //        {
            //            continue;
            //        }

            //        bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
            //        if (isInsert)
            //        {
            //            result.Add(item);
            //        }

            //    }
            //    return result;
            //}
            return expression;
        }

        /// <summary>
        /// 行政区划权限筛选
        /// </summary>
        /// <returns></returns>
        private System.Linq.Expressions.Expression<Func<TBL_HAZARDBASICINFO_HISTORYEntity, bool>> AuthAnd()
        {

            //行政区划账号权限筛选
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            //筛选，获取授权的行政区划
            List<string> author = ws.GetAllAuthDistricts();
            if (author != null && author.Count > 0)
            {
                var expression = LinqExtensions.False<TBL_HAZARDBASICINFO_HISTORYEntity>();
                if (!author.Contains("000000"))
                {
                    var plist1 = author.Select(au => au.EndsWith("0000")).ToList();
                    var plist = author.Where(au => au.Contains("0000")).ToList();
                    var p = string.Empty;
                    var c = string.Empty;
                    var co = string.Empty;
                    var key = string.Empty;
                    if (plist.Count > 0)
                    {
                        p = plist[0].ToString().Substring(0, 2);
                    }
                    var city = author.Where(au => au.EndsWith("00")).ToList();
                    if (city.Count > 0)
                    {
                        c = city[0].ToString().Substring(0, 4);
                    }
                    var county = author.Where(au => !au.EndsWith("00")).ToList();
                    if (county.Count > 0)
                    {
                        co = county[0].ToString();
                    }
                    //var t = author.Select(au => au.EndsWith("000000") || au.Equals("0")).ToList()[0].ToString().Substring(0, 6);
                    if (!string.IsNullOrEmpty(p))
                    {
                        key = p;
                    }
                    else if (string.IsNullOrEmpty(p) && !string.IsNullOrEmpty(c))
                    {
                           key = c;
                    }
                    else if (string.IsNullOrEmpty(p) && string.IsNullOrEmpty(c))
                    {
                        key = co;
                    }
                    //expression = expression.Or(testc => author.Contains(testc.COUNTY));
                    expression = expression.Or(testc => testc.UNIFIEDCODE.StartsWith(key));

                }
                else
                {
                    return LinqExtensions.True<TBL_HAZARDBASICINFO_HISTORYEntity>();
                }
                //foreach (var au in author)
                //{
                //    string keyword = string.Empty;
                //    //全国权限
                //    if (au.EndsWith("000000") || au.Equals("0"))
                //    {
                //        return LinqExtensions.True<TBL_HAZARDBASICINFO_HISTORYEntity>();
                //    }                   
                //    //省权限
                //    else if (au.EndsWith("0000"))
                //    {
                //        keyword = au.Substring(0, 2);
                //    }
                //    //市权限
                //    else if (au.EndsWith("00"))
                //    {
                //        keyword = au.Substring(0, 4);
                //    }
                //    //县权限
                //    else
                //    {
                //        keyword = au.Substring(0, 6);
                //    }
                //    expression = expression.Or(testc => testc.UNIFIEDCODE.StartsWith(keyword));
                //}
                return expression;
            }
            return LinqExtensions.True<TBL_HAZARDBASICINFO_HISTORYEntity>();
        }

        /// <summary>
        /// 获取条件内最新数据（只有一条）
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <param name="condition">空间查询条件</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetList(string queryJson, string condition)
        {
            //分页查询数据
            //var linq = this.BaseRepository().IQueryable(GetLinqExpression(queryJson, condition).And(AuthAnd()));

            //var result = from t in linq
            //             group t by t.UNIFIEDCODE into g
            //             select new
            //             {
            //                 g.Key,
            //                 data = from p2 in g where p2.FILLTABLEDATE == g.Max(p3 => p3.FILLTABLEDATE) select p2
            //             };

            //var temp = result.Take(1).ToList();
            //var list = result.ToList().Select(t => t.data.FirstOrDefault());
            var strWhere = GetWhereSql(queryJson);
            var sql = @"select  c.DISASTERNAME,  c.DISASTERTYPE,  c.UNIFIEDCODE, c.PROVINCENAME,  c.CITYNAME, c.COUNTYNAME,  c.PROVINCE, c.CITY, 
 c.COUNTY, c.TOWNNAME,  c.LOCATION,  c.LONGITUDE, c.LATITUDE, c.GUID, c.PROJECTID,c.DANGERLEVEL, c.DISASTERLEVEL, 
c.DEATHTOLL,  c.ASSETSLOSE,  c.MISSINGPERSON,  c.INJUREDPERSON,  c.THREATENPEOPLE,  c.THREATENASSETS,    c.MODIFYTIME  from (select a.*, row_number() over(partition by a.UNIFIEDCODE order by a.FILLTABLEDATE desc) KRN from TBL_HAZARDBASICINFO_HISTORY a where 1=1 " + strWhere + ") c where KRN = 1 ";
            var list = new RepositoryFactory().BaseRepository().FindList<TBL_HAZARDBASICINFO_HISTORYEntity>(sql);
            var queryParam = condition.ToJObject();
            List<TBL_HAZARDBASICINFO_HISTORYEntity> results = new List<TBL_HAZARDBASICINFO_HISTORYEntity>();
            if (string.IsNullOrEmpty(condition) || condition == "{}")
            {
                return list;
            }
            results = list.ToList();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                return results.Where(s => SpatialQueryHelper.isContainPoint(WKTString, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
                //foreach (var item in list)
                //{
                //    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                //    {
                //        continue;
                //    }

                //    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                //    if (isInsert)
                //    {
                //        results.Add(item);
                //    }

                //}
                //return results;
            }
            if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                double x = queryParam["x"].ToDouble();
                double y = queryParam["y"].ToDouble();
                double radius = queryParam["radius"].ToDouble();
                return results.Where(s => SpatialQueryHelper.PointInCircle(s.LATITUDE.ToDouble(), s.LONGITUDE.ToDouble(), y, x, radius)).ToList();
                //foreach (var item in list)
                //{
                //    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                //    {
                //        continue;
                //    }

                //    bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                //    if (isInsert)
                //    {
                //        results.Add(item);
                //    }

                //}
                //return results;
            }
            if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                string polyline = queryParam["polyline"].ToString();
                double radius = queryParam["radius"].ToDouble();
                return results.Where(s => SpatialQueryHelper.IsIntersects(polyline, radius, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
                //foreach (var item in list)
                //{
                //    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                //    {
                //        continue;
                //    }

                //    bool isInsert = SpatialQueryHelper.IsIntersects(polyline, radius, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                //    if (isInsert)
                //    {
                //        results.Add(item);
                //    }

                //}
                //return results;
            }
            return list;
            //return temp.Select(t => t.data.FirstOrDefault());
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetList(string queryJson)
        {
            //分页查询数据
            var linq = this.BaseRepository().IQueryable(GetLinqExpression(queryJson, null).And(AuthAnd()));

            return linq.OrderBy(t => t.MODIFYTIME).ToList();
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_HAZARDBASICINFO_HISTORYEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }

        public string GetWhereSql(string queryJson)
        {
            if (string.IsNullOrWhiteSpace(queryJson))
            {
                return string.Empty;
            }
            string returnValue = string.Empty;
            var queryParam = queryJson.ToJObject();
            //灾害点名称或者编号
            

            //灾害点名称或者编号
            if (!queryParam["txt_Key"].IsEmpty())
            {
                string value = queryParam["txt_Key"].ToString();
                returnValue += string.Format(" and a.DISASTERNAME like '%{0}%' or a.UNIFIEDCODE like '%{0}%'", value);
            }
            //灾害点名称
            if (!queryParam["DISASTERNAME"].IsEmpty())
            {
                string value = queryParam["DISASTERNAME"].ToString();
                returnValue += string.Format(" and a.DISASTERNAME like '%{0}%' ", value);
            }
            //灾害点类型
            if (!queryParam["DISASTERTYPE"].IsEmpty())
            {
                string value = queryParam["DISASTERTYPE"].ToString();
                returnValue += string.Format(" and a.DISASTERTYPE = '{0}' ", value);
            }

            //灾害点编号
            if (!queryParam["UNIFIEDCODE"].IsEmpty())
            {
                string value = queryParam["UNIFIEDCODE"].ToString();
                returnValue += string.Format(" and a.UNIFIEDCODE like '%{0}%' ", value);
            }
            //项目名称
            if (!queryParam["PROJECTNAME"].IsEmpty())
            {
                string value = queryParam["PROJECTNAME"].ToString();
                returnValue += string.Format(" and a.PROJECTID like '%{0}%' ", value);
            }
            //操作类型
            if (!queryParam["MODIFYTYPE"].IsEmpty())
            {
                string value = queryParam["MODIFYTYPE"].ToString();
                returnValue += string.Format(" and a.MODIFYTYPE = '{0}' ", value);
            }
            //是否已经核销
            if (!queryParam["shifouhexiao"].IsEmpty())
            {
                string value = queryParam["shifouhexiao"].ToString();
                returnValue += string.Format(" and a.ISXH = '{0}' ", value);
            }
            else
            {
                returnValue += " and a.isxh = '0' ";//默认查询没有销号的点
            }
            //是否治理
            if (!queryParam["ISZLGCPNT"].IsEmpty())
            {
                string value = queryParam["ISZLGCPNT"].ToString();
                if (value == "1")
                {
                    returnValue += string.Format(" and a.VERIFICATION !=null and a.VERIFICATION like '%1%' ");
                }
                else
                {
                    returnValue += string.Format(" and a.VERIFICATION =null and a.VERIFICATION <> '1' ");
                }
            }
            //是否搬迁
            if (!queryParam["RELOCATION"].IsEmpty())
            {
                string value = queryParam["RELOCATION"].ToString();
                if (value == "1")
                {
                    returnValue += string.Format(" and a.VERIFICATION !=null and a.VERIFICATION like '%2%' ");
                }
                else
                {
                    returnValue += string.Format(" and a.VERIFICATION =null and a.VERIFICATION <> '1' ");
                }
            }
        
            //地理位置
            if (!queryParam["LOCATION"].IsEmpty())
            {
                string value = queryParam["LOCATION"].ToString();
                returnValue += string.Format(" and a.LOCATION like '%{0}%' ", value);
            }
            //开始时间
            if (!queryParam["BeginTime"].IsEmpty())
            {
                string value = queryParam["BeginTime"].ToString();
                returnValue += string.Format(" and a.FILLTABLEDATE >= to_date('{0}','yyyy-mm-dd hh24:mi:ss') ", value);
            }
            //结束时间
            if (!queryParam["EndTime"].IsEmpty())
            {
                string value = queryParam["EndTime"].ToString();
                returnValue += string.Format(" and a.FILLTABLEDATE <= to_date('{0}','yyyy-mm-dd hh24:mi:ss') ", value);
            }
            //开始时间
            if (!queryParam["BQBRSTARTTIME"].IsEmpty())
            {
                string value = queryParam["BQBRSTARTTIME"].ToString();
                returnValue += string.Format(" and a.CREATETIME >= to_date('{0}','YYYY-mm-dd') ", value);
            }
            //结束时间
            if (!queryParam["BQBRENDTIME"].IsEmpty())
            {
                string value = queryParam["BQBRENDTIME"].ToString();
                returnValue += string.Format(" and a.CREATETIME <= to_date('{0}','YYYY-mm-dd') ", value);
            }
            //省
            if (!queryParam["PROVINCE"].IsEmpty())
            {
                string[] value = queryParam["PROVINCE"].ToString().Split(',');
                returnValue += " and a.PROVINCE LIKE  '%" + string.Join("','", value.ToArray()) + "%'";
            }
            //市
            if (!queryParam["CITY"].IsEmpty())
            {
                string[] value = queryParam["CITY"].ToString().Split(',');
                returnValue += " and a.CITY LIKE  '%" + string.Join("','", value.ToArray()) + "%'";
            }
            //县
            if (!queryParam["COUNTY"].IsEmpty())
            {
                string[] value = queryParam["COUNTY"].ToString().Split(',');
                returnValue += " and a.COUNTY LIKE  '%" + string.Join("','", value.ToArray()) + "%'";
            }
            //数据范围权限过滤
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                returnValue += " and a.COUNTY in(" + string.Join(",", _codes) + ")";
            }
            return returnValue;
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
        /// <summary>
        /// 保存表单（新增）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, TBL_HAZARDBASICINFO_HISTORYEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.GUID = keyValue;
            }
            else
            {
                entity.Create();             
            }
            this.BaseRepository().Insert(entity);
        }
        #endregion
    }
}
