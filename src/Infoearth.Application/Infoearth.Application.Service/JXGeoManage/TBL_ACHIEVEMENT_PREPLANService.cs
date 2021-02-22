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
using System.Data;
using Infoearth.Application.Common;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-05-25 16:29
    /// 描 述：防治规划成果表
    /// </summary>
    public class TBL_ACHIEVEMENT_PREPLANService : RepositoryFactory<TBL_ACHIEVEMENT_PREPLANEntity>, TBL_ACHIEVEMENT_PREPLANIService
    {
        private TBL_HAZARDBASICINFOIService hazard = new TBL_HAZARDBASICINFOService();
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_ACHIEVEMENT_PREPLANEntity>();
             return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);   
        }

        /// <summary>
        /// 把查询浏览页面上的通用json条件转换成linq语句
        /// </summary>
        /// <param name="queryJson">json参数</param>
        /// <returns></returns>
        System.Linq.Expressions.Expression<Func<TBL_ACHIEVEMENT_PREPLANEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ACHIEVEMENT_PREPLANEntity>();
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            string province = json.PROVINCE;
            string city = json.CITY;
            string county = json.COUNTY;

            #region 根据省市县编号查询
            var expression1 = LinqExtensions.False<TBL_ACHIEVEMENT_PREPLANEntity>();
            //镇
            string TOWN = json.TOWN;
            if (!string.IsNullOrEmpty(TOWN))
            {
                foreach (var ton in TOWN.Split(','))
                {
                    expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(0,9).Equals(ton));
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
                        expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(0,6).Equals(ton));
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
                            expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(0,4).Equals(ton.Substring(0,4)));
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
                                expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(0,2).Equals(ton.Substring(0,2)));
                            }
                            expression = expression.And(expression1);
                        }

                    }
                }
            }
            #endregion

            //灾害点名称筛选
            string DISASTERNAME = "";
            if (json.DISASTERNAME != "" && json.DISASTERNAME != null)
            {
                DISASTERNAME = json.DISASTERNAME;
            }
            if (!string.IsNullOrEmpty(DISASTERNAME))
            {
                expression = expression.And(t => t.DISASTERNAME.Contains(DISASTERNAME));
            }
            //成果名称筛选
            string ACHIEVEMENTNAME = "";
            if (json.ACHIEVEMENTNAME != "" && json.ACHIEVEMENTNAME != null)
            {
                ACHIEVEMENTNAME = json.ACHIEVEMENTNAME;
            }
            if (!string.IsNullOrEmpty(ACHIEVEMENTNAME))
            {
                expression = expression.And(t => t.ACHIEVEMENTNAME.Contains(ACHIEVEMENTNAME));
            }
            //编写人筛选
            string CREATENAME = "";
            if (json.CREATENAME != "" && json.CREATENAME != null)
            {
                CREATENAME = json.CREATENAME;
            }
            if (!string.IsNullOrEmpty(CREATENAME))
            {
                expression = expression.And(t => t.CREATENAME.Contains(CREATENAME));
            }
            //规划区域类型
            string AREATYPE = "";
            if (json.AREATYPE != "" && json.AREATYPE != null)
            {
                AREATYPE = json.AREATYPE;
            }
            if (!string.IsNullOrEmpty(AREATYPE))
            {
                expression = expression.And(t => t.AREATYPE.Contains(AREATYPE));
            }
            //规划时间类型
            string TIMETYPE = "";
            if (json.TIMETYPE != "" && json.TIMETYPE != null)
            {
                TIMETYPE = json.TIMETYPE;
            }
            if (!string.IsNullOrEmpty(TIMETYPE))
            {
                expression = expression.And(t => t.TIMETYPE.Contains(TIMETYPE));
            }
            //地灾防治类型
            string DISASTERTYPE = "";
            if (json.DISASTERTYPE != "" && json.DISASTERTYPE != null)
            {
                DISASTERTYPE = json.DISASTERTYPE;
            }
            if (!string.IsNullOrEmpty(DISASTERTYPE))
            {
                expression = expression.And(t => t.DISASTERTYPE.Contains(DISASTERTYPE));
            }
            //防治类容
            string PREVENTION = "";
            if (json.PREVENTION != "" && json.PREVENTION != null)
            {
                PREVENTION = json.PREVENTION;
            }
            if (!string.IsNullOrEmpty(PREVENTION))
            {
                expression = expression.And(t => t.PREVENTION.Contains(PREVENTION));
            }
            //开始结束时间
            string PREPLANSTARTTIME = "";
            string PREPLANENDTIME = "";
            if (json.PREPLANSTARTTIME != "" && json.PREPLANSTARTTIME != null)
            {
                PREPLANSTARTTIME = json.PREPLANSTARTTIME;
            }
            if (json.PREPLANENDTIME != "" && json.PREPLANENDTIME != null)
            {
                PREPLANENDTIME = json.PREPLANENDTIME;
            }
            if (!string.IsNullOrEmpty(PREPLANSTARTTIME) && !string.IsNullOrEmpty(PREPLANENDTIME))
            {
                int PREPLANSTARTTIME_T = Convert.ToInt32(PREPLANSTARTTIME);
                int PREPLANENDTIME_T = Convert.ToInt32(PREPLANENDTIME);
                string YearAll = "";
                var expression2 = LinqExtensions.False<TBL_ACHIEVEMENT_PREPLANEntity>();
                for (int i = PREPLANSTARTTIME_T; i <= PREPLANENDTIME_T; i++)
                {
                    YearAll = Convert.ToString(i);
                    expression2 = expression2.Or(t => t.WRITETIME.ToString().Contains(YearAll));
                }
                expression = expression.And(expression2);
            }
            //一个字段判断灾害点名称、成果名称
            if (json.COMPPARAM != "" && json.COMPPARAM != null)
            {
                string COMPPARAM = json.COMPPARAM;
                if (!string.IsNullOrEmpty(COMPPARAM))
                {
                    expression = expression.And(t => t.DISASTERNAME.Contains(COMPPARAM) || t.ACHIEVEMENTNAME.Contains(COMPPARAM));
                }
            }

            return expression;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> GetList(string queryJson)
        {
             var expression = LinqExtensions.True<TBL_ACHIEVEMENT_PREPLANEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_ACHIEVEMENT_PREPLANEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        /// <summary>
        /// 获取地图摘要信息查询
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回指定字段</returns>
        public IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> GetZYPageList(string queryJson, string condition)
        {

            try
            {
                var queryParam = condition.ToJObject();
                var expression = queryJsonExpression(queryJson);
                List<TBL_ACHIEVEMENT_PREPLANEntity> result = new List<TBL_ACHIEVEMENT_PREPLANEntity>();
                var list = this.BaseRepository().FindList(expression).Select(t => new TBL_ACHIEVEMENT_PREPLANEntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID }).ToList();
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
                            result.Add(item);
                        }

                    }
                    return result;
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
                            result.Add(item);
                        }

                    }
                    return result;
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
                            result.Add(item);
                        }

                    }
                    return result;
                }
                return list;
                //return this.BaseRepository().FindList(expression).Select(t => new TBL_MONITOROBJECTEntity { MONITOROBJECTID = t.MONITOROBJECTID, MONITORPOINTNAME = t.MONITORPOINTNAME, POINTTYPE = t.POINTTYPE, MEASURETYPE = t.MEASURETYPE, JCDJB = t.JCDJB, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE }).ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 防止规划统计分析
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <param name="CityName"></param>
        /// <param name="CountyName"></param>
        /// <param name="PREPLANYEAR"></param>
        /// <param name="PREPLANUNIT"></param>
        /// <param name="DCType"></param>
        /// <returns></returns>
        public DataTable PREPLANCountStatics(string ProvinceName, string CityName, string CountyName, string PREPLANYEAR, string PREPLANUNIT, string DCType)
        {
            DataTable result_query = new DataTable();
            //第一步 关于地质灾害灾害点的集合统计（带省市县）
            string chaxun = "{\"PROVINCENAME\":\"" + ProvinceName + "\",\"CITYNAME\":\"" + CityName + "\",\"COUNTYNAME\":\"" + CountyName + "\"}";
            var Hazards = hazard.GetList(chaxun);
            //第二步 关于治理工程集合统计（带省市县）
            var expression = LinqExtensions.True<TBL_ACHIEVEMENT_PREPLANEntity>();
            IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> Zlghs = this.BaseRepository().FindList(expression);
            //第三步 关于省市县集合的筛选
            #region 省市县集合--以及省市县数据筛选
            List<string> Provincename_list = new List<string>();
            List<string> Cityname_list = new List<string>();
            List<string> Countyname_list = new List<string>();
            foreach (var item in Hazards)
            {
                if (Provincename_list.Contains(item.PROVINCENAME.ToString()))
                {

                }
                else
                {
                    if (item.PROVINCENAME.ToString() == ProvinceName)
                    {
                        Provincename_list.Add(item.PROVINCENAME.ToString());
                    }

                }
                if (Cityname_list.Contains(item.CITYNAME.ToString()))
                {

                }
                else
                {
                    if (item.PROVINCENAME.ToString() == ProvinceName)
                    {
                        Cityname_list.Add(item.CITYNAME.ToString());
                    }
                }
                if (Countyname_list.Contains(item.COUNTYNAME.ToString()))
                {

                }
                else
                {
                    if (item.PROVINCENAME.ToString() == ProvinceName)
                    {
                        Countyname_list.Add(item.CITYNAME.ToString() + "," + item.COUNTYNAME.ToString());
                    }
                }
            }
            //省市县数据筛选
            if (ProvinceName != "" && ProvinceName != null)
            {
                string[] ProvinceNameS = ProvinceName.Split(',');
                List<string> DISProvinceNames_SC = new List<string>();
                for (int j = 0; j < Provincename_list.Count(); j++)
                {
                    if (ProvinceNameS.Contains(Provincename_list[j]))
                    {

                    }
                    else
                    {
                        DISProvinceNames_SC.Add(Provincename_list[j]);
                    }
                }
                for (int m = 0; m < DISProvinceNames_SC.Count(); m++)
                {
                    Provincename_list.Remove(DISProvinceNames_SC[m]);
                }
            }
            if (CityName != "" && CityName != null)
            {
                string[] CityNameS = CityName.Split(',');
                List<string> DISCityNames_SC = new List<string>();
                for (int j = 0; j < Cityname_list.Count(); j++)
                {
                    if (CityNameS.Contains(Cityname_list[j]))
                    {

                    }
                    else
                    {
                        DISCityNames_SC.Add(Cityname_list[j]);
                    }
                }
                for (int m = 0; m < DISCityNames_SC.Count(); m++)
                {
                    Cityname_list.Remove(DISCityNames_SC[m]);
                }


            }
            if (CountyName != "" && CountyName != null)
            {
                string[] CountyNameS = CountyName.Split(',');
                List<string> DISCountyNames_SC = new List<string>();
                for (int i = 0; i < Countyname_list.Count(); i++)
                {
                    if (CountyNameS.Contains(Countyname_list[i]))
                    {

                    }
                    else
                    {
                        DISCountyNames_SC.Add(CountyNameS[i]);
                    }
                }
                for (int j = 0; j < DISCountyNames_SC.Count(); j++)
                {
                    Countyname_list.Remove(DISCountyNames_SC[j]);
                }
            }
            #endregion
            //第四步 对应数据进行省市县年度的筛选（单位区分）
            if (PREPLANYEAR != "" && PREPLANYEAR != null)
            {
                if (PREPLANUNIT == "省")
                {
                    foreach (var item in Zlghs)
                    {
                        if (item.WRITETIME != null)
                        {
                            if (item.WRITETIME.ToString().Substring(0, 4) == PREPLANYEAR)
                            {

                            }
                            else
                            {
                                item.PROVINCENAME = "";
                                item.CITYNAME = "";
                                item.COUNTYNAME = "";
                            }
                        }
                        else
                        {
                            item.PROVINCENAME = "";
                            item.CITYNAME = "";
                            item.COUNTYNAME = "";
                        }
                    }
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlghs);
                }
                if (PREPLANUNIT == "市")
                {
                    foreach (var item in Zlghs)
                    {
                        if (item.WRITETIME != null)
                        {
                            if (item.WRITETIME.ToString().Substring(0, 4) == PREPLANYEAR)
                            {

                            }
                            else
                            {
                                item.PROVINCENAME = "";
                                item.CITYNAME = "";
                                item.COUNTYNAME = "";
                            }
                        }
                        else
                        {
                            item.PROVINCENAME = "";
                            item.CITYNAME = "";
                            item.COUNTYNAME = "";
                        }
                    }
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlghs);
                    result_query.Columns.Add("cityname");
                    result_query = city_func(result_query, Cityname_list, Hazards, Zlghs);
                }

                if (PREPLANUNIT == "县")
                {
                    foreach (var item in Zlghs)
                    {
                        if (item.WRITETIME != null)
                        {
                            if (item.WRITETIME.ToString().Substring(0, 4) == PREPLANYEAR)
                            {

                            }
                            else
                            {
                                item.PROVINCENAME = "";
                                item.CITYNAME = "";
                                item.COUNTYNAME = "";
                            }
                        }
                        else
                        {
                            item.PROVINCENAME = "";
                            item.CITYNAME = "";
                            item.COUNTYNAME = "";
                        }


                    }
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlghs);
                    result_query.Columns.Add("cityname");
                    result_query.Columns.Add("countyname");
                    result_query = county_func(result_query, Cityname_list, Countyname_list, Hazards, Zlghs);
                }
            }
            else
            {
                //不带年份的统计
                if (PREPLANUNIT == "省")
                {
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlghs);
                }
                if (PREPLANUNIT == "市")
                {
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlghs);
                    result_query.Columns.Add("cityname");
                    result_query = city_func(result_query, Cityname_list, Hazards, Zlghs);
                }
                if (PREPLANUNIT == "县")
                {
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlghs);
                    result_query.Columns.Add("cityname");
                    result_query.Columns.Add("countyname");
                    result_query = county_func(result_query, Cityname_list, Countyname_list, Hazards, Zlghs);
                }

            }





            return result_query;
        }

        /// <summary>
        /// 省级数据筛选
        /// </summary>
        /// <param name="result_query"></param>
        /// <param name="DISProvinceNames"></param>
        /// <param name="dyResult"></param>
        /// <param name="ZLGCResult"></param>
        /// <returns></returns>
        public DataTable province_func(DataTable result_query, List<string> DISProvinceNames, dynamic dyResult, IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> ZLGCResult)
        {
            int discount = 0;
            int montcount = 0;
            result_query.Columns.Add("provincename");
            result_query.Columns.Add("disastercount");
            result_query.Columns.Add("zlghcount");
            for (int i = 0; i < DISProvinceNames.Count(); i++)
            {
                foreach (var item in dyResult)
                {
                    if (item.PROVINCENAME == DISProvinceNames[i])
                    {
                        discount++;
                    }
                }
                foreach (var item in ZLGCResult)
                {
                    if (item.PROVINCENAME == DISProvinceNames[i])
                    {
                        montcount++;
                    }
                }
                if (i == DISProvinceNames.Count - 1)
                {
                    DataRow result_dr = result_query.NewRow();
                    result_dr["provincename"] = DISProvinceNames[i];
                    result_dr["disastercount"] = discount;
                    result_dr["zlghcount"] = montcount;
                    result_query.Rows.Add(result_dr);
                }
            }
            return result_query;
        }

        /// <summary>
        /// 市级数据筛选
        /// </summary>
        /// <param name="result_query"></param>
        /// <param name="DISCityNames"></param>
        /// <param name="dyResult"></param>
        /// <param name="MONITORPOINTResult"></param>
        /// <returns></returns>
        public DataTable city_func(DataTable result_query, List<string> DISCityNames, dynamic dyResult, IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> ZLGCResult)
        {
            for (int i = 0; i < DISCityNames.Count(); i++)
            {
                int discount_city = 0;
                int montcount_city = 0;
                foreach (var item in dyResult)
                {
                    if (item.CITYNAME == DISCityNames[i])
                    {
                        discount_city++;
                    }
                }
                foreach (var item in ZLGCResult)
                {
                    if (item.CITYNAME == DISCityNames[i])
                    {
                        montcount_city++;
                    }
                }

                DataRow result_dr = result_query.NewRow();
                result_dr["provincename"] = "";
                result_dr["cityname"] = DISCityNames[i].ToString();
                result_dr["disastercount"] = discount_city;
                result_dr["zlghcount"] = montcount_city;
                result_query.Rows.Add(result_dr);
            }
            return result_query;
        }

        /// <summary>
        /// 县级数据筛选
        /// </summary>
        /// <param name="result_query"></param>
        /// <param name="DISCityNames"></param>
        /// <param name="DISCountyNames"></param>
        /// <param name="dyResult"></param>
        /// <param name="MONITORPOINTResult"></param>
        /// <returns></returns>
        public DataTable county_func(DataTable result_query, List<string> DISCityNames, List<string> DISCountyNames, dynamic dyResult, IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> ZLGCResult)
        {
            for (int i = 0; i < DISCityNames.Count(); i++)
            {
                int discount_city = 0;
                int montcount_city = 0;
                foreach (var item in dyResult)
                {
                    if (item.CITYNAME == DISCityNames[i])
                    {
                        discount_city++;
                    }
                }
                foreach (var item in ZLGCResult)
                {
                    if (item.CITYNAME == DISCityNames[i])
                    {
                        montcount_city++;
                    }
                }
                DataRow result_dr = result_query.NewRow();
                result_dr["provincename"] = "";
                result_dr["cityname"] = DISCityNames[i].ToString();
                result_dr["disastercount"] = discount_city;
                result_dr["zlghcount"] = montcount_city;
                result_query.Rows.Add(result_dr);
                //县级名称的循环
                List<string> countyname_C = new List<string>();
                for (int j = 0; j < DISCountyNames.Count; j++)
                {
                    int discount_county = 0;
                    int montcount_county = 0;
                    foreach (var item in dyResult)
                    {
                        if (DISCityNames[i] == DISCountyNames[j].ToString().Split(',')[0].ToString() && item.CITYNAME == DISCountyNames[j].ToString().Split(',')[0].ToString() && item.COUNTYNAME == DISCountyNames[j].ToString().Split(',')[1].ToString())
                        {
                            discount_county++;
                        }
                    }
                    foreach (var item in ZLGCResult)
                    {
                        if (DISCityNames[i] == DISCountyNames[j].ToString().Split(',')[0].ToString() && item.CITYNAME == DISCountyNames[j].ToString().Split(',')[0].ToString() && item.COUNTYNAME == DISCountyNames[j].ToString().Split(',')[1].ToString())
                        {
                            montcount_county++;
                        }
                    }
                    if (DISCityNames[i] == DISCountyNames[j].ToString().Split(',')[0].ToString() && !countyname_C.Contains(DISCountyNames[j].ToString().Split(',')[1].ToString()))
                    {
                        //判断现在
                        countyname_C.Add(DISCountyNames[j].ToString().Split(',')[1].ToString());
                        DataRow result_dr_COUNTY = result_query.NewRow();
                        result_dr_COUNTY["provincename"] = "";
                        result_dr_COUNTY["cityname"] = "";
                        result_dr_COUNTY["countyname"] = DISCountyNames[j].ToString().Split(',')[1].ToString();
                        result_dr_COUNTY["disastercount"] = discount_county;
                        result_dr_COUNTY["zlghcount"] = montcount_county;
                        result_query.Rows.Add(result_dr_COUNTY);
                    }
                }
            }
            return result_query;
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
        public void SaveForm(string keyValue, TBL_ACHIEVEMENT_PREPLANEntity entity)
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
