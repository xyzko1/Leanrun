using Infoearth.Application.Common;
using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-07 16:09
    /// 描 述：排查数据表
    /// </summary>
    public class TBL_HAZARDBASICINFO_PC_GDService : RepositoryFactory<TBL_HAZARDBASICINFO_PC_GDEntity>, TBL_HAZARDBASICINFO_PC_GDIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFO_PC_GDEntity> GetPageList(Pagination pagination, string queryJson)
        {
            //var expression = LinqExtensions.True<TBL_HAZARDBASICINFO_PC_GDEntity>();
            var expression = queryJsonExpression(queryJson);
            return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// 带分页的空间查询
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<TBL_HAZARDBASICINFO_PC_GDEntity> GetSinglePastPageListJson(Pagination pagination, string queryJson, string condition)
        {
            var list = GetPageList(pagination, queryJson).ToList();
            List<TBL_HAZARDBASICINFO_PC_GDEntity> results = new List<TBL_HAZARDBASICINFO_PC_GDEntity>();
            var queryParam = condition.ToJObject();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        results.Add(item);
                    }

                }
                return results;
            }
            if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                double x = queryParam["x"].ToDouble();
                double y = queryParam["y"].ToDouble();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                    if (isInsert)
                    {
                        results.Add(item);
                    }

                }
                return results;
            }
            if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                string polyline = queryParam["polyline"].ToString();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.IsIntersects(polyline, radius, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        results.Add(item);
                    }

                }
                return results;
            }
            return list;

        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFO_PC_GDEntity> GetList(string queryJson)
        {
            //var expression = LinqExtensions.True<TBL_HAZARDBASICINFO_PC_GDEntity>();
            var expression = queryJsonExpression(queryJson);
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_HAZARDBASICINFO_PC_GDEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        public IEnumerable<TBL_HAZARDBASICINFO_PC_GDEntity> GetHXMapList(string queryJson, string condition)
        {
            var list = GetList(queryJson).ToList();
            List<TBL_HAZARDBASICINFO_PC_GDEntity> results = new List<TBL_HAZARDBASICINFO_PC_GDEntity>();
            var queryParam = condition.ToJObject();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        results.Add(item);
                    }

                }
                return results;
            }
            if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                double x = queryParam["x"].ToDouble();
                double y = queryParam["y"].ToDouble();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                    if (isInsert)
                    {
                        results.Add(item);
                    }

                }
                return results;
            }
            if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                string polyline = queryParam["polyline"].ToString();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.IsIntersects(polyline, radius, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        results.Add(item);
                    }

                }
                return results;
            }
            return list;

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
        public void SaveForm(string keyValue, TBL_HAZARDBASICINFO_PC_GDEntity entity)
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
        #region 统计
        public DataTable GetAnalyseList(string queryJson)
        {
            var sqlTemp = TJSql();//不包含隐患点   -0:不包含  -1 :包含
            dynamic json = JToken.Parse(queryJson) as dynamic;
            //筛选条件
            string sqlWhere = json.sqlWhere;
            string sqlwherezhd = json.sqlWhere;
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere = " and " + sqlWhere;
                sqlwherezhd = " and " + sqlwherezhd;
            }
            if (json.UnionStatisticsSql != null)
            {
                string Tiaojian = json.UnionStatisticsSql;
                //灾害体编号
                if (!string.IsNullOrEmpty(Tiaojian))
                {
                    sqlWhere = " and " + Tiaojian;
                    sqlwherezhd = " and " + Tiaojian;
                }
            }
            //威胁人口
            string THREATENPEOPLE = json.THREATENPEOPLE;
            if (!string.IsNullOrEmpty(THREATENPEOPLE))
            {
                sqlWhere += string.Format(" and t.THREATENPEOPLE  >=  '{0}'", THREATENPEOPLE);
                sqlwherezhd += string.Format(" and i.THREATENPEOPLE  >=  '{0}'", THREATENPEOPLE);
            }
            //威胁财产
            string INDIRECTLOSS = json.INDIRECTLOSS;
            if (!string.IsNullOrEmpty(INDIRECTLOSS))
            {
                sqlWhere += string.Format(" and t.INDIRECTLOSS  >= '{0}'", INDIRECTLOSS);
                sqlwherezhd += string.Format(" and i.INDIRECTLOSS  >= '{0}'", INDIRECTLOSS);
            }
            //隐患点状态
            string YHSTATE = json.YHSTATE;
            if (!string.IsNullOrEmpty(YHSTATE))
            {
                switch (YHSTATE)
                {
                    case "xyyhd":
                    YHSTATE = "现有隐患点";
                    break;
                    case "zrxh":
                        YHSTATE = "自然消亡";
                        break;
                    case "yzl":
                        YHSTATE = "已治理";
                        break;
                    case "ybq":
                        YHSTATE = "已搬迁";
                        break;
                    default:
                        break;
                }
                sqlWhere += string.Format(" and t.YHSTATE  = '{0}'", YHSTATE);
                sqlwherezhd += string.Format(" and i.YHSTATE  = '{0}'", YHSTATE);
            }
            #region 行政区划筛选
            //镇
            string TOWN = json.TOWN;
            if (!string.IsNullOrEmpty(TOWN))
            {
                sqlWhere += string.Format(" and t.TOWN in ({0})", Transcate(TOWN));
                sqlwherezhd += string.Format(" and i.TOWN in ({0})", Transcate(TOWN));
            }
            else
            {
                //县
                string COUNTY = json.COUNTY;
                if (!string.IsNullOrEmpty(COUNTY))
                {
                    sqlWhere += string.Format(" and t.COUNTY in ({0})", Transcate(COUNTY));
                    sqlwherezhd += string.Format(" and i.COUNTY in ({0})", Transcate(COUNTY));
                }
                else
                {
                    //市
                    string CITY = json.CITY;
                    if (!string.IsNullOrEmpty(CITY))
                    {
                        sqlWhere += string.Format(" and t.CITY in ({0})", Transcate(CITY));
                        sqlwherezhd += string.Format(" and i.CITY in ({0})", Transcate(CITY));
                    }
                    else
                    {
                        //省
                        string PROVINCE = json.PROVINCE;
                        if (PROVINCE != "0" && !String.IsNullOrEmpty(PROVINCE))
                        {
                            sqlWhere += string.Format(" and t.PROVINCE in ({0})", Transcate(PROVINCE));
                            sqlwherezhd += string.Format(" and i.PROVINCE in ({0})", Transcate(PROVINCE));
                        }

                    }
                }
            }
            #endregion

            #region 筛选授权
            SSOWebApiWS ws = new SSOWebApiWS("");
            //筛选，获取授权的行政区划
            List<string> author = ws.GetAllAuthDistricts();
            if (!author.Contains("000000") && !author.Equals("0"))
            {
                sqlWhere += string.Format(" and t.COUNTY in ('{0}') ", String.Join("','", author));
                sqlwherezhd += string.Format(" and i.COUNTY in ('{0}') ", String.Join("','", author));
            }
            #endregion

            List<string> content = new List<string>();
            //统计内容筛选条件,0-灾害类型，1-灾情等级
            string type = json.type;

            if (!string.IsNullOrEmpty(type))
            {
                if (type == "0")
                {
                    content.AddRange(new List<string>() { "hp", "bt", "xp", "nsl", "dmcj", "dlf", "dmtx" });
                }
                else if (type == "1")
                {
                    content.AddRange(new List<string>() { "zqxx", "zqzx", "zqdx", "zqtdx" });
                }
            }

            DataTable result = null;
            //行政区划级别
            string level = json.level;
            if (!string.IsNullOrEmpty(level))
            {
                string proSql = string.Format(sqlTemp, sqlWhere, "t.PROVINCENAME,t.province", "t.province", sqlwherezhd, "i.PROVINCENAME,i.province", "i.province", "j.PROVINCENAME", "k.PROVINCENAME");
                string citySql = string.Format(sqlTemp, sqlWhere, "t.PROVINCENAME,t.province,t.CITYNAME,t.city", "t.city", sqlwherezhd, "i.PROVINCENAME,i.province,i.CITYNAME,i.city", "i.city", "j.CITYNAME", "k.CITYNAME");
                string countySql = string.Format(sqlTemp, sqlWhere, "t.PROVINCENAME,t.CITYNAME,t.COUNTYNAME,t.province,t.city,t.county", "t.county", sqlwherezhd, "i.PROVINCENAME,i.CITYNAME,i.COUNTYNAME,i.province,i.city,i.county", "i.county", "j.COUNTYNAME", "k.COUNTYNAME");
                string townSql = string.Format(sqlTemp, sqlWhere, "t.PROVINCENAME,t.CITYNAME,t.COUNTYNAME,t.TOWNNAME,t.province,t.city,t.county,t.town", "t.county", sqlwherezhd, "i.PROVINCENAME,i.CITYNAME,i.COUNTYNAME,i.TOWNNAME,i.province,i.city,i.county,i.town", "i.county", "j.COUNTYNAME", "k.COUNTYNAME");

                DataTable province = null;
                DataTable city = null;
                DataTable county = null;
                switch (level)
                {
                    case "省":
                        province = this.BaseRepository().FindTable(proSql);
                        result = province.Clone();
                        if (province.Rows.Count < 1) return result;
                        break;
                    case "市":
                        city = this.BaseRepository().FindTable(citySql);
                        result = city.Clone();
                        if (city.Rows.Count < 1) return result;
                        break;
                    case "县":
                        county = this.BaseRepository().FindTable(countySql);
                        result = county.Clone();
                        if (county.Rows.Count < 1) return result;
                        break;
                }

                //DataTable province = this.BaseRepository().FindTable(proSql);
                //DataTable city = this.BaseRepository().FindTable(citySql);
                //DataTable county = this.BaseRepository().FindTable(countySql);
                //DataTable town = this.BaseRepository().FindTable(townSql);
                //result = town.Clone();
                //if (content != null && content.Count > 0)
                //{
                //    result = new DataTable();
                //    foreach (var item in content)
                //    {
                //        result.Columns.Add(item);
                //    }
                //}
                //树控件列
                result.Columns.Add("id");
                result.Columns.Add("level");
                result.Columns.Add("parent_field");
                result.Columns.Add("isLeaf");
                result.Columns.Add("expanded");
                result.Columns.Add("area");

                string pid = Guid.NewGuid().ToString();
                switch (level)
                {
                    case "省":
                        if (content != null && content.Count > 0)
                        {
                            result.Columns.Add("provincename");
                        }
                        foreach (DataRow pro in province.Rows)
                        {
                            CopyRow(result, pro, null, 0, pid, true);
                        }
                        break;
                    case "市":
                        if (content != null && content.Count > 0)
                        {
                            result.Columns.Add("provincename");
                            result.Columns.Add("cityname");
                        }
                        province = getProvinceStaticData(city);
                        foreach (DataRow pro in province.Rows)
                        {
                            CopyRow(result, pro, null, 0, pid, false);
                            foreach (DataRow ci in city.Rows)
                            {
                                if (ci["provincename"].ToString() == pro["provincename"].ToString())
                                {
                                    CopyRow(result, ci, new List<string>() { "provincename" }, 1, ci["provincename"].ToString(), true);
                                }
                            }
                        }
                        break;
                    case "县":
                        if (content != null && content.Count > 0)
                        {
                            result.Columns.Add("provincename");
                            result.Columns.Add("cityname");
                            result.Columns.Add("countyname");
                        }
                        province = getProvinceStaticData(county);
                        city = getCityStaticData(county);
                        foreach (DataRow pro in province.Rows)
                        {
                            CopyRow(result, pro, null, 0, pid, false);
                            foreach (DataRow ci in city.Rows)
                            {
                                if (ci["provincename"].ToString() == pro["provincename"].ToString())
                                {
                                    CopyRow(result, ci, new List<string>() { "provincename" }, 1, ci["provincename"].ToString(), false);
                                    foreach (DataRow cou in county.Rows)
                                    {
                                        if (cou["cityname"].ToString() == ci["cityname"].ToString())
                                        {
                                            CopyRow(result, cou, new List<string>() { "provincename", "cityname" }, 2, cou["cityname"].ToString(), true);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
        #endregion
        #region 统计语句
        public string TJSql()
        {
            var sql = string.Empty;
            #region 统计语句
            sql = @"select k.yhd,j.*  from ( select {1},
           sum(case
                 when t.YHSTATE = '现有隐患点' then
                  1
                 else
                  0
               end) as ztxy,
           sum(case
                 when t.YHSTATE = '已治理' then
                  1
                 else
                  0
               end) as ztyzl,
           sum(case
                 when t.YHSTATE = '已搬迁' then
                  1
                 else
                  0
               end) as ztybq,
           sum(case
                 when t.YHSTATE = '自然消亡' then
                  1
                 else
                  0
               end) as ztzrxw,
           sum(case
                 when t.DISASTERTYPE = '滑坡' then
                  1
                 else
                  0
               end) as yhdhp,
           sum(case
                 when t.DISASTERTYPE = '崩塌' then
                  1
                 else
                  0
               end) as yhdbt,
           sum(case
                 when t.DISASTERTYPE = '斜坡' then
                  1
                 else
                  0
               end) as yhdxp,
           sum(case
                 when t.DISASTERTYPE = '泥石流' then
                  1
                 else
                  0
               end) as yhdnsl,
                sum(case
                 when t.DISASTERTYPE = '地面沉降' then
                  1
                 else
                  0
               end) as yhddmcj,
           sum(case
                 when t.DISASTERTYPE = '地裂缝' then
                  1
                 else
                  0
               end) as yhddlf,
           sum(case
                 when t.DISASTERTYPE = '地面塌陷' then
                  1
                 else
                  0
               end) as yhddmtx,
           sum(case
                 when t.SCALE = '小型' then
                  1
                 else
                  0
               end) as gmdjxx,
           sum(case
                 when t.SCALE = '中型' then
                  1
                 else
                  0
               end) as gmdjzx,
           sum(case
                 when t.SCALE = '大型' then
                  1
                 else
                  0
               end) as gmdjdx,
           sum(case
                 when t.SCALE = '特大型' then
                  1
                 else
                  0
               end) as gmdjtdx,
           sum(case
                 when t.CURSTABLESTATUS = '好' then
                  1
                 else
                  0
               end) as wdxh,
               sum(case
                 when t.CURSTABLESTATUS = '差' then
                  1
                 else
                  0
               end) as wdxc,
           sum(case
                 when t.CURSTABLESTATUS = '较差' then
                  1
                 else
                  0
               end) as wdxjc,
           sum(case
                 when t.DESTROYEDOBJECT = '大' then
                  1
                 else
                  0
               end) as whxd,
           sum(case
                 when t.DESTROYEDOBJECT = '中' then
                  1
                 else
                  0
               end) as whxz,
           sum(case
                 when t.DESTROYEDOBJECT = '小' then
                  1
                 else
                  0
               end) as whxx,
           sum(case
                 when t.YHSTATE = '已治理' then
                  1
                 else
                  0
               end) as yxczl,
           sum(case
                 when t.YHSTATE = '已搬迁' then
                  1
                 else
                  0
               end) as yxcbq,
           sum(case
                 when t.YHSTATE = '自然消亡' then
                  1
                 else
                  0
               end) as yxcxw,
               sum(t.THREATENPEOPLE) as yxcrk,
               sum(t.INDIRECTLOSS) as yxccc,
               sum(t.INDIRECTLOSS) as qzwxcc, 
               sum(t.THREATENPEOPLE) as qzwxccrk
      from TBL_HAZARDBASICINFO_PC_GD t where 1=1   and  PROVINCENAME is not null  {0}
     group by {1} order by {2} ) j left join  (select {4},sum(case
                 when i.PCUNIFIEDCODE is null then
                  0
                 else
                  1
               end) as yhd  from TBL_HAZARDBASICINFO_PC_GD i where 1=1   {3}
     group by {4} order by {5}) k   on {6}={7} ";
            #endregion
            return sql;
        }
        private void CopyRow(DataTable table, DataRow row, List<string> lstIgnore, int level, string parent_field, bool isLeaf)
        {
            DataRow temp = table.Rows.Add();
            temp.SetField("level", level);
            switch (level)
            {
                case 0:
                    temp.SetField("area", row["provincename"].ToString());
                    temp.SetField("id", row["provincename"].ToString());
                    break;
                case 1:
                    temp.SetField("area", row["cityname"].ToString());
                    temp.SetField("id", row["cityname"].ToString());
                    break;
                case 2:
                    temp.SetField("area", row["countyname"].ToString());
                    temp.SetField("id", row["countyname"].ToString());
                    break;
                case 3:
                    temp.SetField("area", row["townname"].ToString());
                    temp.SetField("id", row["townname"].ToString());
                    break;
                default:
                    break;
            }

            temp.SetField("parent_field", parent_field);
            temp.SetField("isLeaf", isLeaf ? "true" : "false");
            temp.SetField("expanded", "true");
            foreach (DataColumn item in row.Table.Columns)
            {
                if (lstIgnore != null && lstIgnore.Contains(item.ColumnName))
                    continue;
                if (table.Columns.Contains(item.ColumnName))
                    temp.SetField(item.ColumnName, row[item.ColumnName]);
            }
        }
        private string Transcate(string source)
        {
            if (!string.IsNullOrEmpty(source))
            {
                List<string> result = new List<string>();
                string[] arr = source.Split(',');
                Array.ForEach(arr, t =>
                {
                    result.Add(string.Format("'{0}'", t));
                });
                return String.Join(",", result);
            }
            return source;
        }
        private DataTable getProvinceStaticData(DataTable city)
        {
            var query = from t in city.AsEnumerable()
                        group t by new { t1 = t.Field<string>("province"), t2 = t.Field<string>("PROVINCENAME") } into m
                        select new
                        {
                            province = m.Key.t1,
                            provincename = m.Key.t2,
                            yhd = m.Sum(n => n.Field<decimal?>("yhd")),
                            yhdhp = m.Sum(n => n.Field<decimal?>("yhdhp")),
                            yhdbt = m.Sum(n => n.Field<decimal?>("yhdbt")),
                            yhdnsl = m.Sum(n => n.Field<decimal?>("yhdnsl")),
                            yhdxp = m.Sum(n => n.Field<decimal?>("yhdxp")),
                            yhddmtx = m.Sum(n => n.Field<decimal?>("yhddmtx")),
                            yhddlf = m.Sum(n => n.Field<decimal?>("yhddlf")),
                            yhddmcj = m.Sum(n => n.Field<decimal?>("yhddmcj")),
                            ztxy = m.Sum(n => n.Field<decimal?>("ztxy")),
                            ztyzl = m.Sum(n => n.Field<decimal?>("ztyzl")),
                            ztybq = m.Sum(n => n.Field<decimal?>("ztybq")),
                            ztzrxw = m.Sum(n => n.Field<decimal?>("ztzrxw")),
                            qzwxcc = m.Sum(n => n.Field<decimal?>("qzwxcc")),
                            qzwxccrk = m.Sum(n => n.Field<decimal?>("qzwxccrk")),
                            gmdjxx = m.Sum(n => n.Field<decimal?>("gmdjxx")),
                            gmdjzx = m.Sum(n => n.Field<decimal?>("gmdjzx")),
                            gmdjdx = m.Sum(n => n.Field<decimal?>("gmdjdx")),
                            gmdjtdx = m.Sum(n => n.Field<decimal?>("gmdjtdx")),
                            wdxh = m.Sum(n => n.Field<decimal?>("wdxh")),
                            wdxc = m.Sum(n => n.Field<decimal?>("wdxc")),
                            wdxjc = m.Sum(n => n.Field<decimal?>("wdxjc")),
                            whxd = m.Sum(n => n.Field<decimal?>("whxd")),
                            whxz = m.Sum(n => n.Field<decimal?>("whxz")),
                            whxx = m.Sum(n => n.Field<decimal?>("whxx")),
                            yxczl = m.Sum(n => n.Field<decimal?>("yxczl")),
                            yxcbq = m.Sum(n => n.Field<decimal?>("yxcbq")),
                            yxcxw = m.Sum(n => n.Field<decimal?>("yxcxw")),
                            yxcrk = m.Sum(n => n.Field<decimal?>("yxcrk")),
                            yxccc = m.Sum(n => n.Field<decimal?>("yxccc"))
                        };
            return DataHelper.ListToDataTable(query.ToList());
        }
        private DataTable getCityStaticData(DataTable county)
        {
            var query = from t in county.AsEnumerable()
                        group t by new { t1 = t.Field<string>("city"), t2 = t.Field<string>("CITYNAME"), t3 = t.Field<string>("province"), t4 = t.Field<string>("PROVINCENAME") } into m
                        select new
                        {
                            city = m.Key.t1,
                            cityname = m.Key.t2,
                            province = m.Key.t3,
                            provincename = m.Key.t4,
                            yhd = m.Sum(n => n.Field<decimal?>("yhd")),
                            yhdhp = m.Sum(n => n.Field<decimal?>("yhdhp")),
                            yhdbt = m.Sum(n => n.Field<decimal?>("yhdbt")),
                            yhdnsl = m.Sum(n => n.Field<decimal?>("yhdnsl")),
                            yhdxp = m.Sum(n => n.Field<decimal?>("yhdxp")),
                            yhddmtx = m.Sum(n => n.Field<decimal?>("yhddmtx")),
                            yhddlf = m.Sum(n => n.Field<decimal?>("yhddlf")),
                            yhddmcj = m.Sum(n => n.Field<decimal?>("yhddmcj")),
                            ztxy = m.Sum(n => n.Field<decimal?>("ztxy")),
                            ztyzl = m.Sum(n => n.Field<decimal?>("ztyzl")),
                            ztybq = m.Sum(n => n.Field<decimal?>("ztybq")),
                            ztzrxw = m.Sum(n => n.Field<decimal?>("ztzrxw")),
                            qzwxcc = m.Sum(n => n.Field<decimal?>("qzwxcc")),
                            qzwxccrk = m.Sum(n => n.Field<decimal?>("qzwxccrk")),
                            gmdjxx = m.Sum(n => n.Field<decimal?>("gmdjxx")),
                            gmdjzx = m.Sum(n => n.Field<decimal?>("gmdjzx")),
                            gmdjdx = m.Sum(n => n.Field<decimal?>("gmdjdx")),
                            gmdjtdx = m.Sum(n => n.Field<decimal?>("gmdjtdx")),
                            wdxh = m.Sum(n => n.Field<decimal?>("wdxh")),
                            wdxc = m.Sum(n => n.Field<decimal?>("wdxc")),
                            wdxjc = m.Sum(n => n.Field<decimal?>("wdxjc")),
                            whxd = m.Sum(n => n.Field<decimal?>("whxd")),
                            whxz = m.Sum(n => n.Field<decimal?>("whxz")),
                            whxx = m.Sum(n => n.Field<decimal?>("whxx")),
                            yxczl = m.Sum(n => n.Field<decimal?>("yxczl")),
                            yxcbq = m.Sum(n => n.Field<decimal?>("yxcbq")),
                            yxcxw = m.Sum(n => n.Field<decimal?>("yxcxw")),
                            yxcrk = m.Sum(n => n.Field<decimal?>("yxcrk")),
                            yxccc = m.Sum(n => n.Field<decimal?>("yxccc"))
                        };
            return DataHelper.ListToDataTable(query.ToList());
        }
        #endregion
        #region 地图加载柱状图
        public string GetZHDCountResult(string queryJson)
        {
            var jobj = queryJson.ToJObject();
            //第一步获取行政区划
            //LocationHelper.GetDistricts();

            //第二步请求统计数据并整理成可用直接调用的数据形式
            DataTable entity = new DataTable();
            entity = GetAnalyseList(queryJson);

            if (entity == null || entity.Rows.Count == 0) return null;
            for (int i = 0; i < entity.Rows.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(entity.Rows[i]["area"].ToString())
                    || (entity.Columns.Contains("town") && !string.IsNullOrWhiteSpace(entity.Rows[i]["town"].ToString())))
                {
                    entity.Rows[i].Delete();
                    i--;
                }
            }
            if (entity.Columns.Contains("town"))
            {
                entity.Columns.Remove("townname");
                entity.Columns.Remove("town");
            }
            if (entity.Columns.Contains("provincename"))
            {
                entity.Columns.Remove("province");
                entity.Columns["provincename"].ColumnName = "省";
            }
            if (entity.Columns.Contains("cityname"))
            {
                entity.Columns.Remove("city");
                entity.Columns["cityname"].ColumnName = "市";
            }
            if (entity.Columns.Contains("countyname"))
            {
                entity.Columns.Remove("county");
                entity.Columns["countyname"].ColumnName = "县";
            }
            
            if (entity.Columns.Contains("yhd"))
            {
                if (jobj["yhd"].ToString() == "1")
                {
                    entity.Columns["yhd"].ColumnName = "隐患点总计";
                }
                else
                {
                    entity.Columns.Remove("yhd");
                }
            }
            #region 灾害类型
            if (jobj["yhdzhlx"].ToString() == "1")
            {
                entity.Columns["yhdhp"].ColumnName = "滑坡";
                entity.Columns["yhdbt"].ColumnName = "崩塌";
                entity.Columns["yhdxp"].ColumnName = "斜坡";
                entity.Columns["yhdnsl"].ColumnName = "泥石流";
                entity.Columns["yhddmcj"].ColumnName = "地面沉降";
                entity.Columns["yhddlf"].ColumnName = "地裂缝";
                entity.Columns["yhddmtx"].ColumnName = "地面塌陷";
                var disasterType = jobj["DISASTERTYPE"].ToString();
                if (disasterType != "")
                {
                    {
                        entity.Columns.Remove("滑坡");
                    }
                    if ("崩塌" != disasterType)
                    {
                        entity.Columns.Remove("崩塌");
                    }
                    if ("斜坡" != disasterType)
                    {
                        entity.Columns.Remove("斜坡");
                    }
                    if ("泥石流" != disasterType)
                    {
                        entity.Columns.Remove("泥石流");
                    }
                    if ("地面沉降" != disasterType)
                    {
                        entity.Columns.Remove("地面沉降");
                    }
                    if ("地裂缝" != disasterType)
                    {
                        entity.Columns.Remove("地裂缝");
                    }
                    if ("地面塌陷" != disasterType)
                    {
                        entity.Columns.Remove("地面塌陷");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("yhdhp");
                entity.Columns.Remove("yhdbt");
                entity.Columns.Remove("yhdxp");
                entity.Columns.Remove("yhdnsl");
                entity.Columns.Remove("yhddmcj");
                entity.Columns.Remove("yhddlf");
                entity.Columns.Remove("yhddmtx");
            }
            #endregion
            #region 数据状态
            if (jobj["zt"].ToString() == "1")
            {
                entity.Columns["ztxy"].ColumnName = "现有隐患点";
                entity.Columns["ztyzl"].ColumnName = "已治理";
                entity.Columns["ztybq"].ColumnName = "已搬迁";
                entity.Columns["ztzrxw"].ColumnName = "自然消亡";
                var disasterLevel = jobj["DISASTERLEVEL"].ToString();
                if (disasterLevel != "")
                {
                    if ("现有隐患点" != disasterLevel)
                    {
                        entity.Columns.Remove("现有隐患点");
                    }
                    if ("已治理" != disasterLevel)
                    {
                        entity.Columns.Remove("已治理");
                    }
                    if ("已搬迁" != disasterLevel)
                    {
                        entity.Columns.Remove("已搬迁");
                    }
                    if ("自然消亡" != disasterLevel)
                    {
                        entity.Columns.Remove("自然消亡");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("ztxy");
                entity.Columns.Remove("ztyzl");
                entity.Columns.Remove("ztybq");
                entity.Columns.Remove("ztzrxw");
            }
            #endregion
            #region 潜在威胁
            if (jobj["qzwx"].ToString() == "1")
            {
                entity.Columns["qzwxcc"].ColumnName = "威胁财产/（万元）";
                entity.Columns["qzwxccrk"].ColumnName = "威胁人口/（人）";                
                var disasterLevel = jobj["DISASTERLEVEL"].ToString();
                if (disasterLevel != "")
                {
                    if ("威胁财产/（万元）" != disasterLevel)
                    {
                        entity.Columns.Remove("威胁财产/（万元）");
                    }
                    if ("威胁人口/（人）" != disasterLevel)
                    {
                        entity.Columns.Remove("威胁人口/（人）");
                    }                  
                }
            }
            else
            {
                entity.Columns.Remove("qzwxcc");
                entity.Columns.Remove("qzwxccrk");              
            }
            #endregion
            #region 规模等级
            if (jobj["gmdj"].ToString() == "1")
            {
                entity.Columns["gmdjxx"].ColumnName = "小型";
                entity.Columns["gmdjzx"].ColumnName = "中型";
                entity.Columns["gmdjdx"].ColumnName = "大型";
                entity.Columns["gmdjtdx"].ColumnName = "特大型";
                var disasterLevel = jobj["DISASTERLEVEL"].ToString();
                if (disasterLevel != "")
                {
                    if ("小型" != disasterLevel)
                    {
                        entity.Columns.Remove("小型");
                    }
                    if ("中型" != disasterLevel)
                    {
                        entity.Columns.Remove("中型");
                    }
                    if ("大型" != disasterLevel)
                    {
                        entity.Columns.Remove("大型");
                    }
                    if ("特大型" != disasterLevel)
                    {
                        entity.Columns.Remove("特大型");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("gmdjxx");
                entity.Columns.Remove("gmdjzx");
                entity.Columns.Remove("gmdjdx");
                entity.Columns.Remove("gmdjtdx");
            }
            #endregion
            #region 稳定性
            if (jobj["wdx"].ToString() == "1")
            {
                entity.Columns["wdxh"].ColumnName = "稳定性好";
                entity.Columns["wdxc"].ColumnName = "稳定性较差";
                entity.Columns["wdxjc"].ColumnName = "稳定性差";              
                var disasterLevel = jobj["DISASTERLEVEL"].ToString();
                if (disasterLevel != "")
                {
                    if ("稳定性好" != disasterLevel)
                    {
                        entity.Columns.Remove("稳定性好");
                    }
                    if ("稳定性较差" != disasterLevel)
                    {
                        entity.Columns.Remove("稳定性较差");
                    }
                    if ("稳定性差" != disasterLevel)
                    {
                        entity.Columns.Remove("稳定性差");
                    }                   
                }
            }
            else
            {
                entity.Columns.Remove("wdxh");
                entity.Columns.Remove("wdxc");
                entity.Columns.Remove("wdxjc");
            }
            #endregion
            #region 危害性
            if (jobj["whx"].ToString() == "1")
            {
                entity.Columns["whxd"].ColumnName = "危害性大";
                entity.Columns["whxz"].ColumnName = "危害性中";
                entity.Columns["whxx"].ColumnName = "危害性小";
                var disasterLevel = jobj["DISASTERLEVEL"].ToString();
                if (disasterLevel != "")
                {
                    if ("危害性大" != disasterLevel)
                    {
                        entity.Columns.Remove("危害性大");
                    }
                    if ("危害性中" != disasterLevel)
                    {
                        entity.Columns.Remove("危害性中");
                    }
                    if ("危害性小" != disasterLevel)
                    {
                        entity.Columns.Remove("危害性小");
                    }                  
                }
            }
            else
            {
                entity.Columns.Remove("whxd");
                entity.Columns.Remove("whxz");
                entity.Columns.Remove("whxx");
            }
            #endregion
            #region 已消除
            if (jobj["yxc"].ToString() == "1")
            {
                entity.Columns["yxczl"].ColumnName = "已治理";
                entity.Columns["yxcbq"].ColumnName = "已搬迁";
                entity.Columns["yxcxw"].ColumnName = "自然消亡";
                entity.Columns["yxcrk"].ColumnName = "威胁人口";
                entity.Columns["yxccc"].ColumnName = "威胁财产";
                var disasterLevel = jobj["DISASTERLEVEL"].ToString();
                if (disasterLevel != "")
                {
                    if ("已治理" != disasterLevel)
                    {
                        entity.Columns.Remove("已治理");
                    }
                    if ("已搬迁" != disasterLevel)
                    {
                        entity.Columns.Remove("已搬迁");
                    }
                    if ("自然消亡" != disasterLevel)
                    {
                        entity.Columns.Remove("自然消亡");
                    }
                    if ("威胁人口" != disasterLevel)
                    {
                        entity.Columns.Remove("威胁人口");
                    }
                    if ("威胁财产" != disasterLevel)
                    {
                        entity.Columns.Remove("威胁财产");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("yxczl");
                entity.Columns.Remove("yxcbq");
                entity.Columns.Remove("yxcxw");
                entity.Columns.Remove("yxcrk");
                entity.Columns.Remove("yxccc");
            }
            #endregion
            entity.Columns.Remove("id");
            entity.Columns.Remove("level");
            entity.Columns.Remove("parent_field");
            entity.Columns.Remove("isLeaf");
            entity.Columns.Remove("expanded");
            entity.Columns.Remove("area");

           
            //第三步合并坐标到统计数据中，同时生成统计图片
            try
            {
                return LocationHelper.GetLocationByName(entity);
            }
            catch (Exception)
            {
            }
            return null;

        }
        #endregion
        #region List实体转Datatable
        /// 将list集合转换成datatable
        /// </summary>增加类型为Nullable<>时的判断
        /// <param name="list"></param>
        /// <returns></returns>
        public static System.Data.DataTable ListToDataTable(IList list)
        {
            System.Data.DataTable result = new System.Data.DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    //获取类型
                    Type colType = pi.PropertyType;
                    //当类型为Nullable<>时
                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        colType = colType.GetGenericArguments()[0];
                    }
                    result.Columns.Add(pi.Name, colType);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
        #endregion
        #region 筛选条件
        System.Linq.Expressions.Expression<Func<TBL_HAZARDBASICINFO_PC_GDEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_HAZARDBASICINFO_PC_GDEntity>();
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                //关键字灾害点名称或者编号或地理位置
                string txt_Key = json.txt_Key;
                if (!string.IsNullOrEmpty(txt_Key))
                {
                    expression = expression.And(t => t.PCUNIFIEDCODE.Contains(txt_Key) || t.UNIFIEDCODE == txt_Key || t.LOCATION.Contains(txt_Key));
                }
                //灾害体规模
                string SCALE = json.SCALE;
                if (!string.IsNullOrEmpty(SCALE))
                {
                    expression = expression.And(t => t.SCALE.Contains(SCALE));
                }
                //稳定性
                string CURSTABLESTATUS = json.CURSTABLESTATUS;
                if (!string.IsNullOrEmpty(CURSTABLESTATUS))
                {
                    expression = expression.And(t => t.CURSTABLESTATUS.Contains(CURSTABLESTATUS));
                }
                //隐患点状态
                string YHSTATE = json.YHSTATE;
                if (YHSTATE==null)
                {
                    YHSTATE = "现有隐患点";
                    expression = expression.And(t => t.YHSTATE.Contains(YHSTATE));
                }
                if (!string.IsNullOrEmpty(YHSTATE))
                {
                    expression = expression.And(t => t.YHSTATE.Contains(YHSTATE));
                }
                //灾害点类型
                string DISASTERTYPE = json.DISASTERTYPE;
                if (!string.IsNullOrEmpty(DISASTERTYPE))
                {
                    expression = expression.And(t => t.DISASTERTYPE.Equals(DISASTERTYPE));
                }
                //统一编号
                string UNIFIEDCODE = json.UNIFIEDCODE;
                if (!string.IsNullOrEmpty(UNIFIEDCODE))
                {
                    expression = expression.And(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE));
                }
                //排查编号
                string PCUNIFIEDCODE = json.PCUNIFIEDCODE;
                if (!string.IsNullOrEmpty(PCUNIFIEDCODE))
                {
                    expression = expression.And(t => t.PCUNIFIEDCODE.Contains(PCUNIFIEDCODE));
                }
               
                //行政区划
                string AreaCode = json.AreaCode;
                if (!string.IsNullOrEmpty(AreaCode))
                {
                    if (AreaCode !="0")
                    {
                        if (AreaCode.EndsWith("0000"))
                        {
                            expression = expression.And(t => t.COUNTY.Contains(AreaCode.Substring(0, 2)));
                        }
                        else if (AreaCode.EndsWith("00"))
                        {
                            expression = expression.And(t => t.COUNTY.Contains(AreaCode.Substring(0, 4)));
                        }
                        else
                        {
                            expression = expression.And(t => t.COUNTY.Contains(AreaCode.Substring(0, 6)));
                        }
                    }
                   
                }
                //数据范围权限过滤
                List<string> _codes = ssoWS.GetAllAuthDistricts();
                if (!_codes.Contains("000000") && !_codes.Equals("0"))
                {
                    expression = expression.And(t => _codes.Contains(t.COUNTY));
                }              
                return expression;
            }
            return expression;
        }
        #endregion


        #region 省地市编码转换
        private Expression<Func<TBL_HAZARDBASICINFO_PC_GDEntity, bool>> GetRegionExpression(JObject queryParam)
        {
            Expression<Func<TBL_HAZARDBASICINFO_PC_GDEntity, bool>> exp = LinqExtensions.True<TBL_HAZARDBASICINFO_PC_GDEntity>();
            if (!queryParam["PROVINCE"].IsEmpty())
            {
                if (!queryParam["CITY"].IsEmpty())
                {
                    if (!queryParam["COUNTY"].IsEmpty())
                    {
                        string[] strArr = queryParam["COUNTY"].ToString().Split(',');
                        exp = exp.And(GetLamdaList(strArr));
                    }
                    else
                    {
                        string[] strArr = queryParam["CITY"].ToString().Split(',');
                        exp = exp.And(GetLamdaList(strArr));
                    }
                }
                else
                {
                    string[] strArr = queryParam["PROVINCE"].ToString().Split(',');
                    exp = exp.And(GetLamdaList(strArr));
                }
            }
            return exp;
        }


        private Expression<Func<TBL_HAZARDBASICINFO_PC_GDEntity, bool>> GetLamdaList(string[] codeArr)
        {
            Expression<Func<TBL_HAZARDBASICINFO_PC_GDEntity, bool>> exp = LinqExtensions.True<TBL_HAZARDBASICINFO_PC_GDEntity>();
            for (int i = 0; i < codeArr.Length; i++)
            {
                var lamda = GetLamda(codeArr[i]);
                if (i == 0)
                {
                    exp = exp.And(lamda);
                }
                else
                {
                    exp = exp.Or(lamda);
                }
            }
            return exp;
        }

        private System.Linq.Expressions.Expression<Func<TBL_HAZARDBASICINFO_PC_GDEntity, bool>> GetLamda(string code)
        {
            System.Linq.Expressions.Expression<Func<TBL_HAZARDBASICINFO_PC_GDEntity, bool>> exp = LinqExtensions.True<TBL_HAZARDBASICINFO_PC_GDEntity>();
            if (code.Length == 9)
            {
                exp = s => s.UNIFIEDCODE.StartsWith(code);
            }
            else
            {
                if (code.EndsWith("0000"))
                {
                    string value = code.Substring(0, 2);
                    exp = s => s.UNIFIEDCODE.Substring(0, 2) == value;
                }
                else
                {
                    if (code.EndsWith("00"))
                    {
                        exp = s => s.UNIFIEDCODE.Substring(0, 4) == code.Substring(0, 4);
                    }
                    else
                    {
                        exp = s => s.UNIFIEDCODE.Substring(0, 6) == code;
                    }
                }
            }
            return exp;
        }
        #endregion
    }
}
