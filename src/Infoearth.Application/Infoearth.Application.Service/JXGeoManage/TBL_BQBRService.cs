using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
using Infoearth.Application.Common;
using Infoearth.Application.Entity;
using Infoearth.Application.Entity.SystemManage;
using Newtonsoft.Json.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:25
    /// 描 述：搬迁避让信息表
    /// </summary>
    public class TBL_BQBRService : RepositoryFactory<TBL_BQBREntity>, TBL_BQBRIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        private static EchartEntityNEWS _districtsDataCount = null;
        #region 地图聚合
        public EchartEntityNEWS GetListCodes()
        {
            _districtsDataCount = (EchartEntityNEWS)CacheHelper.GetCache("搬迁避让聚合");
            EchartEntityNEWS returnValue = new EchartEntityNEWS();
            if (_districtsDataCount == null)
            {
                returnValue = GetListData();
            }
            else
            {
                returnValue = _districtsDataCount;
            }
            return returnValue;
        }

        public EchartEntityNEWS GetListData()
        {
            return null;
            //EchartEntityNEWS returnValue = new EchartEntityNEWS();
            ////获取当前用户行政区划
            //List<string> _codes = ssoWS.GetAllAuthDistricts();//获取当前用户行政区划            
            //IList<string> dataItemDetailList = new List<string>() { "总数" };
            //if (_codes.Contains("000000"))
            //{
            //    List<ParetEntity> districts2 = ssoWS.GetDistrictByParent("0");
            //    // List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
            //    List<AreaEntity> districts = ssoWS.GetAllDistrictsToCountry().ToList();
            //    List<string> selectXZQH1 = new List<string>();
            //    List<string> selectXZQH2 = new List<string>();
            //    List<string> selectXZQH3 = new List<string>();
            //    //省
            //    returnValue.proviceList = districts2.Select(p => p.DistrictCode).ToList();//行政区划编码
            //    returnValue.provicenameList = districts2.Select(p => p.DistrictName).ToList();//行政区划名称
            //    returnValue.provicelatitude = districts2.Select(p => p.F_LATITUDE).ToList();
            //    returnValue.provicelongitude = districts2.Select(p => p.F_LONGITUDE).ToList();
            //    selectXZQH1 = districts2.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
            //    string sql1 = searthsql(2, selectXZQH1);
            //    returnValue.provicecount = convertDataTable(this.BaseRepository().FindTable(sql1), dataItemDetailList);
            //    //市  
            //    var selectColumn1 = string.Empty;
            //    returnValue.citynameList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaName).ToList();
            //    returnValue.cityList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaCode).ToList();
            //    returnValue.citylatitude = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_LATITUDE.ToString()).ToList();
            //    returnValue.citylongitude = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_LONGITUDE.ToString()).ToList();
            //    selectXZQH2 = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
            //    string sql2 = searthsql(4, selectXZQH2);
            //    returnValue.citycount = convertDataTable(this.BaseRepository().FindTable(sql2), dataItemDetailList);
            //    //县 
            //    var selectColumn2 = string.Empty;
            //    returnValue.countynameList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaName).ToList();
            //    returnValue.countyList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode).ToList();
            //    returnValue.countylatitude = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_LATITUDE.ToString()).ToList();
            //    returnValue.countylongitude = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_LONGITUDE.ToString()).ToList();
            //    selectXZQH3 = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
            //    string sql3 = searthsql(6, selectXZQH3);
            //    returnValue.countycount = convertDataTable(this.BaseRepository().FindTable(sql3), dataItemDetailList);
            //}
            //else
            //{
            //    List<string> selectXZQH1 = new List<string>();
            //    List<string> selectXZQH2 = new List<string>();
            //    List<string> selectXZQH3 = new List<string>();
            //    var DefalutCode = _codes.FirstOrDefault().ToString().Substring(0, 2) + "0000";//获取当前省编码
            //    //省           
            //    List<ParetEntity> districts = ssoWS.GetDistrictByParent("0");
            //    returnValue.proviceList = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictCode).ToList();
            //    returnValue.provicenameList = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictName).ToList();
            //    returnValue.provicelatitude = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.F_LATITUDE).ToList();
            //    returnValue.provicelongitude = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.F_LONGITUDE).ToList();
            //    selectXZQH1 = districts.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
            //    var selectColumn = string.Empty;
            //    string sql1 = searthsql(2, selectXZQH1);
            //    returnValue.provicecount = convertDataTable(this.BaseRepository().FindTable(sql1), dataItemDetailList);
            //    //市
            //    List<ParetEntity> districts1 = ssoWS.GetDistrictByParent(DefalutCode);
            //    returnValue.cityList = districts1.Select(p => p.DistrictCode).ToList();//行政区划编码
            //    returnValue.citynameList = districts1.Select(p => p.DistrictName).ToList();//行政区划名称
            //    returnValue.citylatitude = districts1.Select(p => p.F_LATITUDE).ToList();//行政区划纬度
            //    returnValue.citylongitude = districts1.Select(p => p.F_LONGITUDE).ToList();//行政区划经度
            //    selectXZQH2 = districts1.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
            //    string sql2 = searthsql(4, selectXZQH2);
            //    returnValue.citycount = convertDataTable(this.BaseRepository().FindTable(sql2), dataItemDetailList);
            //    //县
            //    var DefalutCodes = _codes.FirstOrDefault().ToString().Substring(0, 2);//获取当前省编码前两位
            //    List<AreaEntity> districts2 = ssoWS.GetAllDistrictsToCountry().ToList();
            //    //List<AreaEntity> districts2 = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
            //    returnValue.countynameList = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_AreaName).ToList();
            //    returnValue.countyList = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_AreaCode).ToList();
            //    returnValue.countylatitude = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_LATITUDE.ToString()).ToList();
            //    returnValue.countylongitude = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_LONGITUDE.ToString()).ToList();
            //    selectXZQH3 = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
            //    string sql3 = searthsql(6, selectXZQH3);
            //    returnValue.countycount = convertDataTable(this.BaseRepository().FindTable(sql3), dataItemDetailList);
            //}
            //string sql = "select *  from TBL_BQBR ";
            //if (!_codes.Contains("000000"))
            //{
            //    sql += " where SUBSTR(UNIFIEDCODE,0,6)  in('" + string.Join("','", _codes.ToArray()) + "') ";
            //}
            //returnValue.data = this.BaseRepository().FindTable(sql);
            //CacheHelper.SetCache("搬迁避让聚合", returnValue);//写缓存
            //return returnValue;
        }
        private string searthsql(int sub, List<string> selectXZQH)
        {
            string sql = string.Empty;
            string groupBy = string.Format(" {0} ", DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, sub));
            foreach (var item in selectXZQH)
            {
                var code = item.Split(',')[0];
                var name = item.Split(',')[1];
                sql += string.Format(" ,sum(case when {1}='{0}' then 1 else 0 end) \"{2}\" ", code.Substring(0, sub), groupBy, code);
            }
            string sql2 = string.Format("select  '{0}' name {1} from  TBL_BQBR  where 1=1 ", "总数", sql);
            return sql2;
        }
        private IList<dataEntity> convertDataTable(DataTable dt, IList<string> dataItemDetailList)
        {
            //不存在数据添加行
            for (int i = 0; i < dataItemDetailList.Count; i++)
            {
                if (dt.Select("name ='" + dataItemDetailList[i] + "'").Count() == 0)
                {
                    DataRow addDR = dt.NewRow();
                    addDR["name"] = dataItemDetailList[i];
                    for (int columnIndex = 1; columnIndex < dt.Columns.Count; columnIndex++)
                    {
                        addDR[columnIndex] = "0";
                    }
                    dt.Rows.InsertAt(addDR, i);
                }
            }
            IList<dataEntity> list = new List<dataEntity>();
            IList<string> listRow = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                listRow.Add(dr["name"].ToString());
            }
            dt.Columns.Remove("name");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new dataEntity()
                {
                    name = listRow[i],
                    data = dt.Rows[i].ItemArray
                });
            }
            return list;
        }
        #endregion
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_BQBREntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<TBL_BQBREntity>();
            return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);
        }
        public IEnumerable<tbl_bqbrnew> GetPageListNEW(Pagination pagination, string queryJson)
        {

            dynamic json = JToken.Parse(queryJson) as dynamic;
            //筛选条件
            string sqlWhere = "where 1=1"; string sqlWhere1 = "where 1=1";
            //项目名称
            string XMMC = json.XMMC;
            if (!string.IsNullOrEmpty(XMMC))
            {
                sqlWhere += string.Format(" and t.XMMC like '%{0}%'", XMMC);
            }
            //地理位置
            string LOCATION = json.LOCATION;
            if (!string.IsNullOrEmpty(LOCATION))
            {
                sqlWhere += string.Format(" and t.LOCATION like '%{0}%'", LOCATION);
            }
            //灾害类型
            string DISASTERTYPE = json.DISASTERTYPE;
            if (!string.IsNullOrEmpty(DISASTERTYPE))
            {
                sqlWhere += string.Format(" and t.DISASTERTYPE = '{0}'", DISASTERTYPE);
            }
            //搬迁户数
            string BQHS1 = json.bqhs1; string BQHS2 = json.bqhs2;
            if (!string.IsNullOrEmpty(BQHS1) && !string.IsNullOrEmpty(BQHS2))
            {
                sqlWhere1 += string.Format(" and s.HS >= {0}", BQHS1);
                sqlWhere1 += string.Format(" and s.HS <= {0}", BQHS2);
            }
            else if (!string.IsNullOrEmpty(BQHS1))
            {
                sqlWhere1 += string.Format(" and s.HS = {0}", BQHS1);
            }
            else if (!string.IsNullOrEmpty(BQHS2))
            {
                sqlWhere1 += string.Format(" and s.HS = {0}", BQHS2);
            }
            //行政区划
            string AreaCode = json.AreaCode;
            if (AreaCode != "0")
            {
                if (AreaCode.EndsWith("0000"))
                {
                    AreaCode = AreaCode.Substring(0, 2);
                }
                else if (AreaCode.EndsWith("00"))
                {
                    AreaCode = AreaCode.Substring(0, 4);
                }
                if (!string.IsNullOrEmpty(AreaCode))
                {
                    sqlWhere += string.Format(" and t.UNIFIEDCODE like  '{0}%'", AreaCode);
                }
            }
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<string> _codes2 = _codes.Where(p => p.Contains("00")).ToList();
            if (_codes2.Count > 1)
            {
                sqlWhere += " and CITY in('" + string.Join("','", _codes2.ToArray()) + "') ";//省级用户

            }
            else if (_codes2.Count == 1)
            {
                if (_codes2[0] != "000000" && !_codes2[0].Equals("0"))
                {
                    sqlWhere += "  and COUNTY in('" + string.Join("','", _codes.ToArray()) + "') ";//市级用户

                }
                else if (_codes2[0] == "000000")
                {
                    sqlWhere += "  ";//全国用户

                }
                else
                {
                    sqlWhere += " ";//省级用户

                }
            }
            else
            {
                sqlWhere += "  and COUNTY in('" + string.Join("','", _codes.ToArray()) + "') ";//区级用户

            }
            //开始时间
            string BQBRSTARTTIME = json.BQBRSTARTTIME; string BQBRENDTIME = json.BQBRENDTIME;
            if (!string.IsNullOrEmpty(BQBRSTARTTIME))
            {
                BQBRSTARTTIME = BQBRSTARTTIME.Substring(0, 4);
                sqlWhere += string.Format(" and t.ANNUAL >= '{0}' ", BQBRSTARTTIME);
            }
            //结束时间
            if (!string.IsNullOrEmpty(BQBRENDTIME))
            {
                BQBRENDTIME = BQBRENDTIME.Substring(0, 4);
                sqlWhere += string.Format(" and t.ANNUAL <= '{0}' ", BQBRENDTIME);
            }
            //一个字段判断灾害点名称、灾害点编号
            if (json.COMPPARAM != "" && json.COMPPARAM != null)
            {
                string COMPPARAM = json.COMPPARAM;
                if (!string.IsNullOrEmpty(COMPPARAM))
                {
                    sqlWhere += string.Format(" and ( t.DISASTERNAME like  '%" + COMPPARAM + "%' or  t.UNIFIEDCODE =  '" + COMPPARAM + "' or t.XMMC like  '%" + COMPPARAM + "%') ");
                }
            }
            string strsql = "select * from (select UNIFIEDCODE,DISASTERNAME ,LOCATION,DISASTERTYPE,LATITUDE,LONGITUDE,count(UNIFIEDCODE) HS,sum(MOVEDECIMAL) BQRS,sum(ZAZBTJE) BTJR,sum(case when SFYS=1 then 1 else 0 end) YYS ,sum(case when SFWC=1 then 1 else 0 end) YWC  from TBL_BQBR t  " + sqlWhere + " group by  UNIFIEDCODE,DISASTERNAME,LOCATION,DISASTERTYPE,LATITUDE,LONGITUDE) s " + sqlWhere1;
            RepositoryFactory<tbl_bqbrnew> d = new RepositoryFactory<tbl_bqbrnew>();
            return d.BaseRepository().FindList(strsql, pagination);
            //return this.BaseRepository().
        }
        /// <summary>
        /// 获取地图摘要信息查询
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回指定字段</returns>
        public IEnumerable<TBL_BQBREntity> GetZYPageList(string queryJson, string condition)
        {

            try
            {
                var queryParam = condition.ToJObject();
                var expression = queryJsonExpression(queryJson);
                List<TBL_BQBREntity> result = new List<TBL_BQBREntity>();
                var list = this.BaseRepository().FindList(expression).Select(t => new TBL_BQBREntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID, MODIFYTIME = t.MODIFYTIME == null ? Convert.ToDateTime("1970-01-01") : t.MODIFYTIME }).ToList();
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
        /// 把查询浏览页面上的通用json条件转换成linq语句
        /// </summary>
        /// <param name="queryJson">json参数</param>
        /// <returns></returns>
        System.Linq.Expressions.Expression<Func<TBL_BQBREntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_BQBREntity>();

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

                string DISASTERNAME = "";
                string UNIFIEDCODE = "";
                string XMMC = "";
                string DISASTERTYPE = "";
                string ISCOMPLETE = "";
                string ISACCEPTANCE = "";
                string BQBRSTARTTIME = "";
                string BQBRENDTIME = "";
                string LOCATION = "";

                if (json.SELECTQUERYTYPE == "DISASTERNAME")
                {
                    DISASTERNAME = json.SELECTQUERYCONTENT;
                }
                if (json.SELECTQUERYTYPE == "UNIFIEDCODE")
                {
                    UNIFIEDCODE = json.SELECTQUERYCONTENT;
                }
                if (json.SELECTQUERYTYPE == "DISASTERTYPE")
                {
                    DISASTERTYPE = json.SELECTQUERYCONTENT;
                }
                if (json.SELECTQUERYTYPE == "ISCOMPLETE")
                {
                    ISCOMPLETE = json.SELECTQUERYCONTENT;
                }
                if (json.SELECTQUERYTYPE == "ISACCEPTANCE")
                {
                    ISACCEPTANCE = json.SELECTQUERYCONTENT;
                }
                if (json.SELECTQUERYTYPE == "LOCATION")
                {
                    LOCATION = json.SELECTQUERYTYPE;
                }
                var expression1 = LinqExtensions.False<TBL_BQBREntity>();
                #region 单选省市级联
                //镇
                string TOWN_RPT = json.TOWNRPT;
                if (!string.IsNullOrEmpty(TOWN_RPT))
                {
                    foreach (var ton in TOWN_RPT.Split(','))
                    {
                        expression1 = expression1.Or(t => t.TOWN.Equals(ton));
                    }
                    expression = expression.And(expression1);
                }
                else
                {
                    //县
                    string COUNTY = json.COUNTYRPT;
                    if (!string.IsNullOrEmpty(COUNTY))
                    {
                        foreach (var ton in COUNTY.Split(','))
                        {
                            expression1 = expression1.Or(t => t.COUNTY.Equals(ton));
                        }
                        expression = expression.And(expression1);
                    }
                    else
                    {
                        //市
                        string CITY = json.CITYRPT;
                        if (!string.IsNullOrEmpty(CITY))
                        {
                            foreach (var ton in CITY.Split(','))
                            {
                                expression1 = expression1.Or(t => t.CITY.Equals(ton));
                            }
                            expression = expression.And(expression1);
                        }
                        else
                        {
                            //省
                            string PROVINCE = json.PROVINCERPT;
                            if (!string.IsNullOrEmpty(PROVINCE))
                            {
                                foreach (var ton in PROVINCE.Split(','))
                                {
                                    expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                                }
                                expression = expression.And(expression1);
                            }

                        }
                    }
                }
                #endregion
                #region 省市县级联条件
                //镇
                string TOWN = json.TOWN;
                if (!string.IsNullOrEmpty(TOWN))
                {
                    foreach (var ton in TOWN.Split(','))
                    {
                        expression1 = expression1.Or(t => t.TOWN.Equals(ton));
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
                            expression1 = expression1.Or(t => t.COUNTY.Equals(ton));
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
                                expression1 = expression1.Or(t => t.CITY.Equals(ton));
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
                                    expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                                }
                                expression = expression.And(expression1);
                            }

                        }
                    }
                }
                #endregion
                //数据范围权限过滤
                List<string> _codes = ssoWS.GetAllAuthDistricts();
                if (!_codes.Contains("000000") && !_codes.Equals("0"))
                {
                    expression = expression.And(t => _codes.Contains(t.COUNTY));
                }
                //灾害点名称
                if (json.XMMC != "" && json.XMMC != null)
                {
                    XMMC = json.XMMC;
                }
                if (!string.IsNullOrEmpty(XMMC))
                {
                    expression = expression.And(t => t.XMMC.Contains(XMMC));
                }
                //灾害点名称
                if (json.DISASTERNAME != "" && json.DISASTERNAME != null)
                {
                    DISASTERNAME = json.DISASTERNAME;
                }
                if (!string.IsNullOrEmpty(DISASTERNAME))
                {
                    expression = expression.And(t => t.DISASTERNAME.Contains(DISASTERNAME));
                }
                //灾害点编号
                if (json.UNIFIEDCODE != "" && json.UNIFIEDCODE != null)
                {
                    UNIFIEDCODE = json.UNIFIEDCODE;
                }
                if (!string.IsNullOrEmpty(UNIFIEDCODE))
                {
                    expression = expression.And(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE));
                }
                //地理位置
                if (json.LOCATION != "" && json.LOCATION != null)
                {
                    LOCATION = json.LOCATION;
                }
                if (!string.IsNullOrEmpty(LOCATION))
                {
                    expression = expression.And(t => t.LOCATION.Contains(LOCATION));
                }
                //灾害类型
                if (json.DISASTERTYPE != "" && json.DISASTERTYPE != null)
                {
                    DISASTERTYPE = json.DISASTERTYPE;
                }
                if (!string.IsNullOrEmpty(DISASTERTYPE))
                {
                    expression = expression.And(t => t.DISASTERTYPE.Contains(DISASTERTYPE));
                }
                //是否完成
                if (json.ISCOMPLETE != "" && json.ISCOMPLETE != null)
                {
                    ISCOMPLETE = json.ISCOMPLETE;
                }
                if (!string.IsNullOrEmpty(ISCOMPLETE))
                {
                    if (ISCOMPLETE == "1")//已完成
                    {
                        ISCOMPLETE = "1";
                    }
                    if (ISCOMPLETE == "0")//未完成
                    {
                        ISCOMPLETE = "0";
                    }
                    expression = expression.And(t => t.ISCOMPLETE.Contains(ISCOMPLETE));
                }
                //是否验收
                if (json.ISACCEPTANCE != "" && json.ISACCEPTANCE != null)
                {
                    ISACCEPTANCE = json.ISACCEPTANCE;
                }
                if (!string.IsNullOrEmpty(ISACCEPTANCE))
                {
                    if (ISACCEPTANCE == "1")//是
                    {
                        ISACCEPTANCE = "1";
                    }
                    if (ISACCEPTANCE == "0")//否
                    {
                        ISACCEPTANCE = "0";
                    }
                    expression = expression.And(t => t.ISACCEPTANCE.Contains(ISACCEPTANCE));
                }
                //开始结束时间

                if (json.BQBRSTARTTIME != "" && json.BQBRSTARTTIME != null)
                {
                    BQBRSTARTTIME = json.BQBRSTARTTIME;
                }
                if (json.BQBRENDTIME != "" && json.BQBRENDTIME != null)
                {
                    BQBRENDTIME = json.BQBRENDTIME;
                }
                if (!string.IsNullOrEmpty(BQBRSTARTTIME) && !string.IsNullOrEmpty(BQBRENDTIME))
                {
                    int BQBRSTARTTIME_T = Convert.ToInt32(BQBRSTARTTIME);
                    int BQBRENDTIME_T = Convert.ToInt32(BQBRENDTIME);
                    string YearAll = "";
                    var expression2 = LinqExtensions.False<TBL_BQBREntity>();
                    for (int i = BQBRSTARTTIME_T; i <= BQBRENDTIME_T; i++)
                    {
                        YearAll = Convert.ToString(i);
                        expression2 = expression2.Or(t => t.ANNUAL.Contains(YearAll));
                    }
                    expression = expression.And(expression2);
                }
                string AreaCode = json.AreaCode;
                if (!string.IsNullOrEmpty(AreaCode))
                {
                    if (AreaCode != "0")
                    {
                        if (AreaCode.EndsWith("0000"))
                        {
                            expression = expression.And(t => t.PROVINCE.Equals(AreaCode));
                        }
                        else if (AreaCode.EndsWith("00"))
                        {
                            expression = expression.And(t => t.CITY.Equals(AreaCode));
                        }
                        else
                        {
                            expression = expression.And(t => t.COUNTY.Equals(AreaCode));
                        }
                    }
                    //expression = expression.And(s=>s.)
                }
                //一个字段判断灾害点名称、灾害点编号
                if (json.COMPPARAM != "" && json.COMPPARAM != null)
                {
                    string COMPPARAM = json.COMPPARAM;
                    if (!string.IsNullOrEmpty(COMPPARAM))
                    {
                        expression = expression.And(t => t.DISASTERNAME.Contains(COMPPARAM) || t.UNIFIEDCODE.Contains(COMPPARAM) || t.LOCATION.Contains(COMPPARAM) || t.XMMC.Contains(COMPPARAM));
                    }
                }
            }

            return expression;
        }
        public IEnumerable<tbl_bqbrnew> GetPageListNEW1(string queryJson)
        {

            dynamic json = JToken.Parse(queryJson) as dynamic;
            //筛选条件
            string sqlWhere = "where 1=1"; string sqlWhere1 = "where 1=1";
            //项目名称
            string XMMC = json.XMMC;
            if (!string.IsNullOrEmpty(XMMC))
            {
                sqlWhere += string.Format(" and t.XMMC like '%{0}%'", XMMC);
            }
            //地理位置
            string LOCATION = json.LOCATION;
            if (!string.IsNullOrEmpty(LOCATION))
            {
                sqlWhere += string.Format(" and t.LOCATION like '%{0}%'", LOCATION);
            }
            //灾害类型
            string DISASTERTYPE = json.DISASTERTYPE;
            if (!string.IsNullOrEmpty(DISASTERTYPE))
            {
                sqlWhere += string.Format(" and t.DISASTERTYPE = '{0}'", DISASTERTYPE);
            }
            //搬迁户数
            string BQHS1 = json.bqhs1; string BQHS2 = json.bqhs2;
            if (!string.IsNullOrEmpty(BQHS1) && !string.IsNullOrEmpty(BQHS2))
            {
                sqlWhere1 += string.Format(" and s.HS >= {0}", BQHS1);
                sqlWhere1 += string.Format(" and s.HS <= {0}", BQHS2);
            }
            else if (!string.IsNullOrEmpty(BQHS1))
            {
                sqlWhere1 += string.Format(" and s.HS = {0}", BQHS1);
            }
            else if (!string.IsNullOrEmpty(BQHS2))
            {
                sqlWhere1 += string.Format(" and s.HS = {0}", BQHS2);
            }
            //行政区划
            string AreaCode = json.AreaCode;
            if (AreaCode != "0")
            {
                if (AreaCode.EndsWith("0000"))
                {
                    AreaCode = AreaCode.Substring(0, 2);
                }
                else if (AreaCode.EndsWith("00"))
                {
                    AreaCode = AreaCode.Substring(0, 4);
                }
                if (!string.IsNullOrEmpty(AreaCode))
                {
                    sqlWhere += string.Format(" and t.UNIFIEDCODE like  '{0}%'", AreaCode);
                }
            }
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<string> _codes2 = _codes.Where(p => p.Contains("00")).ToList();
            if (_codes2.Count > 1)
            {
                sqlWhere += " and CITY in('" + string.Join("','", _codes2.ToArray()) + "') ";//省级用户

            }
            else if (_codes2.Count == 1)
            {
                if (_codes2[0] != "000000" && !_codes2[0].Equals("0"))
                {
                    sqlWhere += "  and COUNTY in('" + string.Join("','", _codes.ToArray()) + "') ";//市级用户

                }
                else if (_codes2[0] == "000000")
                {
                    sqlWhere += "  ";//全国用户

                }
                else
                {
                    sqlWhere += " ";//省级用户

                }
            }
            else
            {
                sqlWhere += "  and COUNTY in('" + string.Join("','", _codes.ToArray()) + "') ";//区级用户

            }
            //开始时间
            string BQBRSTARTTIME = json.BQBRSTARTTIME; string BQBRENDTIME = json.BQBRENDTIME;
            if (!string.IsNullOrEmpty(BQBRSTARTTIME))
            {
                BQBRSTARTTIME = BQBRSTARTTIME.Substring(0, 4);
                sqlWhere += string.Format(" and t.ANNUAL >= '{0}' ", BQBRSTARTTIME);
            }
            //结束时间
            if (!string.IsNullOrEmpty(BQBRENDTIME))
            {
                BQBRENDTIME = BQBRENDTIME.Substring(0, 4);
                sqlWhere += string.Format(" and t.ANNUAL <= '{0}' ", BQBRENDTIME);
            }
            //一个字段判断灾害点名称、灾害点编号
            if (json.COMPPARAM != "" && json.COMPPARAM != null)
            {
                string COMPPARAM = json.COMPPARAM;
                if (!string.IsNullOrEmpty(COMPPARAM))
                {
                    sqlWhere += string.Format(" and t.DISASTERNAME like  '%" + COMPPARAM + "%' or  t.UNIFIEDCODE =  '" + COMPPARAM + "' or t.XMMC like  '%" + COMPPARAM + "%' ");
                }
            }
            string strsql = "select * from (select UNIFIEDCODE,DISASTERNAME ,LOCATION,DISASTERTYPE,LATITUDE,LONGITUDE,count(UNIFIEDCODE) HS,sum(MOVEDECIMAL) BQRS,sum(ZAZBTJE) BTJR,sum(case when SFYS=1 then 1 else 0 end) YYS ,sum(case when SFWC=1 then 1 else 0 end) YWC  from TBL_BQBR t  " + sqlWhere + " group by  UNIFIEDCODE,DISASTERNAME,LOCATION,DISASTERTYPE,LATITUDE,LONGITUDE) s " + sqlWhere1;
            RepositoryFactory<tbl_bqbrnew> d = new RepositoryFactory<tbl_bqbrnew>();
            return d.BaseRepository().FindList(strsql);
            //return this.BaseRepository().
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetDataTableList(string queryJson)
        {
            var data = this.BaseRepository().FindList(queryJsonExpression(queryJson));
            // var data = GetPageListNEW1(queryJson);
            DataTable result = new DataTable();

            result.Columns.Add("灾害点名称");
            result.Columns.Add("灾害点编号");
            result.Columns.Add("灾害点类型");
            result.Columns.Add("经度");
            result.Columns.Add("纬度");
            result.Columns.Add("搬迁年度");
            result.Columns.Add("单户户主");
            result.Columns.Add("单户搬迁人数");
            result.Columns.Add("安置方式");
            result.Columns.Add("是否拆除");
            result.Columns.Add("是否完成");
            result.Columns.Add("是否验收");
            result.Columns.Add("是否公示");
            result.Columns.Add("搬迁户性质");
            result.Columns.Add("地理位置");
            result.Columns.Add("省");
            result.Columns.Add("市");
            result.Columns.Add("县");
            foreach (var item in data)
            {
                DataRow result_dr = result.NewRow();
                result_dr["灾害点名称"] = item.DISASTERNAME;
                result_dr["灾害点类型"] = item.DISASTERTYPE;
                result_dr["灾害点编号"] = item.UNIFIEDCODE;
                result_dr["经度"] = item.LATITUDE;
                result_dr["纬度"] = item.LONGITUDE;
                result_dr["搬迁年度"] = item.ANNUAL;
                result_dr["单户户主"] = item.HOUSEHOLDERNAME;
                result_dr["单户搬迁人数"] = item.MOVEDECIMAL;
                result_dr["安置方式"] = item.RESETTLEMENT;
                if (item.ISDEMOLITION == "1")
                {
                    result_dr["是否拆除"] = "是";
                }
                if (item.ISDEMOLITION == "0")
                {
                    result_dr["是否拆除"] = "否";
                }
                if (item.SFWC == "1")
                {
                    result_dr["是否完成"] = "是";
                }
                if (item.SFWC == "0")
                {
                    result_dr["是否完成"] = "否";
                }
                if (item.SFYS == "1")
                {
                    result_dr["是否验收"] = "是";
                }
                if (item.SFYS == "0")
                {
                    result_dr["是否验收"] = "否";
                }
                if (item.SFGS == "1")
                {
                    result_dr["是否公示"] = "是";
                }
                if (item.SFGS == "0")
                {
                    result_dr["是否公示"] = "否";
                }
                result_dr["搬迁户性质"] = item.MINENATURE;
                result_dr["地理位置"] = item.LOCATION;
                result_dr["省"] = item.PROVINCENAME;
                result_dr["市"] = item.CITYNAME;
                result_dr["县"] = item.COUNTYNAME;
                result.Rows.Add(result_dr);
            }
            return result;
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_BQBREntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_BQBREntity>();
            return this.BaseRepository().FindList(queryJsonExpression(queryJson));
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_BQBREntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        public TBL_BQBREntity GetEntityByUnifycode(string keyValue)
        {
            var expression = LinqExtensions.True<TBL_BQBREntity>();
            if (!keyValue.IsEmpty())
            {
                expression = expression.And(u => u.UNIFIEDCODE == keyValue);
            }
            else
            {
                expression = expression.And(u => 1 == 2);
            }
            return this.BaseRepository().FindList(expression).FirstOrDefault();
        }
        public IEnumerable<TBL_BQBREntity> GetEntityByUnifycodeNEW(Pagination pagination, string keyValue)
        {
            var expression = LinqExtensions.True<TBL_BQBREntity>();
            if (!keyValue.IsEmpty())
            {
                expression = expression.And(u => u.UNIFIEDCODE == keyValue);
            }
            else
            {
                expression = expression.And(u => 1 == 2);
            }
            return this.BaseRepository().FindList(expression).Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <param name="CityName"></param>
        /// <param name="CountyName"></param>
        /// <param name="BQBRYEAR"></param>
        /// <param name="BQBRUNIT"></param>
        /// <param name="EXLType"></param>
        /// <returns></returns>
        public DataTable BQBRCountStatics(string ProvinceName, string CityName, string CountyName, string BQBRYEAR, string BQBRUNIT, string EXLType)
        {
            //已经更新成为最新视图模式（维护采用视图维护,方便简洁）  
            //带年份的统计省级别统计BQBRPROVINCEBYYEARCOUNT
            var QueryStrProvinceYear = "SELECT * FROM BQBRPROVINCEBYYEARCOUNT";
            //带年份的统计(市)BQBRCITYBYYEARCOUNT
            var QueryStrCityYear = "SELECT * FROM BQBRCITYBYYEARCOUNT";
            //带年份的统计(县)BQBRCOUNTYBYYEARCOUNT
            var QueryStrCountyYear = "SELECT * FROM BQBRCOUNTYBYYEARCOUNT";

            //不带年份的统计(省)
            var QueryStrProvince = "SELECT * FROM BQBRPROVINCECOUNT";
            //不带年份的统计(市)
            var QueryStrCity = "SELECT * FROM BQBRCITYCOUNT";
            //不带年份的统计(县)
            var QueryStrCounty = "SELECT * FROM BQBRCOUNTYCOUNT";
            DataTable result_Query = new DataTable();
            if (BQBRYEAR != "" && BQBRYEAR != null)
            {
                if (BQBRUNIT != null && BQBRUNIT != "")
                {
                    if (BQBRUNIT == "省")
                    {
                        string QueryYear = QueryStrProvinceYear.ToString() + " where bqbryear ='" + BQBRYEAR + "'";
                        string QueryXZQH = "";
                        if (ProvinceName != "")
                        {
                            string[] ProvinceNames = ProvinceName.Split(',');
                            for (int i = 0; i < ProvinceNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and provincename in( '" + ProvinceNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or provincename in( '" + ProvinceNames[i] + "')";
                                }
                            }
                            //QueryXZQH += " and provincename = '" + ProvinceName + "'";
                        }
                        QueryYear += QueryXZQH;
                        var queryResult = QueryYear;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                    }
                    if (BQBRUNIT == "市")
                    {
                        string QueryYear = QueryStrCityYear.ToString() + " where bqbryear ='" + BQBRYEAR + "'";
                        string QueryXZQH = "";
                        if (ProvinceName != "")
                        {
                            string[] ProvinceNames = ProvinceName.Split(',');
                            for (int i = 0; i < ProvinceNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and provincename in( '" + ProvinceNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or provincename in( '" + ProvinceNames[i] + "')";
                                }
                            }
                            //QueryXZQH += " and provincename = '" + ProvinceName + "'";
                        }
                        QueryYear += QueryXZQH;
                        if (CityName != "")
                        {
                            string[] CityNames = CityName.Split(',');
                            for (int i = 0; i < CityNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and cityname in( '" + CityNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or cityname in( '" + CityNames[i] + "')";
                                }
                            }

                        }
                        QueryYear += QueryXZQH;
                        var queryResult = QueryYear;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                        DataTable result = new DataTable();
                        result.Columns.Add("provincename");
                        result.Columns.Add("cityname");
                        result.Columns.Add("discount");
                        result.Columns.Add("bqbrcount");
                        result.Columns.Add("bqbryear");
                        for (int i = 0; i < result_Query.Rows.Count; i++)
                        {
                            if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "")
                            {
                                result_Query.Rows[i]["provincename"] = "";
                            }
                            DataRow result_dr = result.NewRow();
                            result_dr["provincename"] = result_Query.Rows[i]["provincename"].ToString();
                            result_dr["cityname"] = result_Query.Rows[i]["cityname"].ToString();
                            result_dr["discount"] = result_Query.Rows[i]["discount"].ToString();
                            result_dr["bqbrcount"] = result_Query.Rows[i]["bqbrcount"].ToString();
                            result_dr["bqbryear"] = result_Query.Rows[i]["bqbryear"].ToString();
                            result.Rows.Add(result_dr);
                        }
                        return result;
                    }
                    if (BQBRUNIT == "县")
                    {
                        string QueryYear = QueryStrCountyYear.ToString() + " where bqbryear ='" + BQBRYEAR + "'";
                        string QueryXZQH = "";
                        if (ProvinceName != "")
                        {
                            string[] ProvinceNames = ProvinceName.Split(',');
                            for (int i = 0; i < ProvinceNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and provincename in( '" + ProvinceNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or provincename in( '" + ProvinceNames[i] + "')";
                                }
                            }
                            //QueryXZQH += " and provincename = '" + ProvinceName + "'";
                        }
                        QueryYear += QueryXZQH;
                        if (CityName != "")
                        {
                            string[] CityNames = CityName.Split(',');
                            for (int i = 0; i < CityNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and cityname in( '" + CityNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or cityname in( '" + CityNames[i] + "')";
                                }
                            }
                            if (CountyName != "")
                            {
                                string[] CountyNames = CountyName.Split(',');
                                for (int j = 0; j < CountyNames.Length; j++)
                                {
                                    if (j == 0)
                                    {
                                        QueryXZQH += " and countryname = '" + CountyNames[j] + "'";
                                    }
                                    else
                                    {
                                        QueryXZQH += " or countryname = '" + CountyNames[j] + "'";
                                    }
                                }
                            }
                        }
                        QueryYear += QueryXZQH;
                        var queryResult = QueryYear;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                        DataTable result = new DataTable();
                        result.Columns.Add("provincename");
                        result.Columns.Add("cityname");
                        result.Columns.Add("countryname");
                        result.Columns.Add("discount");
                        result.Columns.Add("bqbrcount");
                        result.Columns.Add("bqbryear");
                        for (int i = 0; i < result_Query.Rows.Count; i++)
                        {
                            if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && result_Query.Rows[i]["countryname"].ToString() != "")
                            {
                                result_Query.Rows[i]["provincename"] = "";
                                result_Query.Rows[i]["cityname"] = "";
                            }
                            if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && result_Query.Rows[i]["countryname"].ToString() == "")
                            {
                                result_Query.Rows[i]["provincename"] = "";
                            }
                            DataRow result_dr = result.NewRow();
                            result_dr["provincename"] = result_Query.Rows[i]["provincename"].ToString();
                            result_dr["cityname"] = result_Query.Rows[i]["cityname"].ToString();
                            result_dr["countryname"] = result_Query.Rows[i]["countryname"].ToString();
                            result_dr["discount"] = result_Query.Rows[i]["discount"].ToString();
                            result_dr["bqbrcount"] = result_Query.Rows[i]["bqbrcount"].ToString();
                            result_dr["bqbryear"] = result_Query.Rows[i]["bqbryear"].ToString();
                            result.Rows.Add(result_dr);
                        }
                        return result;
                    }

                }

            }
            else
            {
                if (BQBRUNIT != null && BQBRUNIT != "")
                {
                    if (BQBRUNIT == "省")
                    {
                        string QueryDE = QueryStrProvince.ToString() + " where 1=1 ";
                        string QueryXZQH = "";
                        if (ProvinceName != "")
                        {
                            string[] ProvinceNames = ProvinceName.Split(',');
                            for (int i = 0; i < ProvinceNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and provincename in( '" + ProvinceNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or provincename in( '" + ProvinceNames[i] + "')";
                                }
                            }
                            //QueryXZQH += " and provincename = '" + ProvinceName + "'";
                        }
                        QueryDE += QueryXZQH;
                        var queryResult = QueryDE;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                    }
                    if (BQBRUNIT == "市")
                    {
                        string QueryDE = QueryStrCity.ToString() + " where 1=1 ";
                        string QueryXZQH = "";
                        if (ProvinceName != "")
                        {
                            string[] ProvinceNames = ProvinceName.Split(',');
                            for (int i = 0; i < ProvinceNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and provincename in( '" + ProvinceNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or provincename in( '" + ProvinceNames[i] + "')";
                                }
                            }
                        }
                        //QueryDE += QueryXZQH;
                        if (CityName != "")
                        {
                            string[] CityNames = CityName.Split(',');
                            for (int i = 0; i < CityNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and cityname in( '" + CityNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or cityname in( '" + CityNames[i] + "')";
                                }
                            }

                        }
                        QueryDE += QueryXZQH;
                        var queryResult = QueryDE;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                        DataTable result = new DataTable();
                        result.Columns.Add("provincename");
                        result.Columns.Add("cityname");
                        result.Columns.Add("discount");
                        result.Columns.Add("bqbrcount");
                        for (int i = 0; i < result_Query.Rows.Count; i++)
                        {
                            if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && i != 0)
                            {
                                result_Query.Rows[i]["provincename"] = "";
                            }
                            DataRow result_dr = result.NewRow();
                            result_dr["provincename"] = result_Query.Rows[i]["provincename"].ToString();
                            result_dr["cityname"] = result_Query.Rows[i]["cityname"].ToString();
                            result_dr["discount"] = result_Query.Rows[i]["discount"].ToString();
                            result_dr["bqbrcount"] = result_Query.Rows[i]["bqbrcount"].ToString();
                            result.Rows.Add(result_dr);
                        }
                        return result;
                    }
                    if (BQBRUNIT == "县")
                    {
                        string QueryDE = QueryStrCounty.ToString() + " where 1=1 ";
                        string QueryXZQH = "";
                        if (ProvinceName != "")
                        {
                            string[] ProvinceNames = ProvinceName.Split(',');
                            for (int i = 0; i < ProvinceNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and provincename in( '" + ProvinceNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or provincename in( '" + ProvinceNames[i] + "')";
                                }
                            }
                            //QueryXZQH += " and provincename = '" + ProvinceName + "'";
                        }
                        //QueryDE += QueryXZQH;
                        if (CityName != "")
                        {
                            if (ProvinceName != "")
                            {
                                QueryXZQH += " and provincename = '" + ProvinceName + "'";
                            }
                            //QueryDE += QueryXZQH;
                            string[] CityNames = CityName.Split(',');
                            for (int i = 0; i < CityNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and cityname in( '" + CityNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or cityname in( '" + CityNames[i] + "')";
                                }
                            }
                            if (CountyName != "")
                            {
                                string[] CountyNames = CountyName.Split(',');
                                for (int j = 0; j < CountyNames.Length; j++)
                                {
                                    if (j == 0)
                                    {
                                        QueryXZQH += " and countryname = '" + CountyNames[j] + "'";
                                    }
                                    else
                                    {
                                        QueryXZQH += " or countryname = '" + CountyNames[j] + "'";
                                    }
                                }
                            }
                        }
                        QueryDE += QueryXZQH;
                        var queryResult = QueryDE;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                        DataTable result = new DataTable();
                        result.Columns.Add("provincename");
                        result.Columns.Add("cityname");
                        result.Columns.Add("countryname");
                        result.Columns.Add("discount");
                        result.Columns.Add("bqbrcount");
                        for (int i = 0; i < result_Query.Rows.Count; i++)
                        {
                            if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && result_Query.Rows[i]["countryname"].ToString() != "")
                            {
                                result_Query.Rows[i]["provincename"] = "";
                                result_Query.Rows[i]["cityname"] = "";
                            }
                            if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && result_Query.Rows[i]["countryname"].ToString() == "" && i != 0)
                            {
                                result_Query.Rows[i]["provincename"] = "";
                            }
                            DataRow result_dr = result.NewRow();
                            result_dr["provincename"] = result_Query.Rows[i]["provincename"].ToString();
                            result_dr["cityname"] = result_Query.Rows[i]["cityname"].ToString();
                            result_dr["countryname"] = result_Query.Rows[i]["countryname"].ToString();
                            result_dr["discount"] = result_Query.Rows[i]["discount"].ToString();
                            result_dr["bqbrcount"] = result_Query.Rows[i]["bqbrcount"].ToString();
                            result.Rows.Add(result_dr);
                        }
                        return result;
                    }

                }
            }
            return result_Query;

        }
        /// <summary>
        /// 获取地图摘要信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<TBL_BQBREntity> GetZYList(string queryJson, string condition)
        {
            var queryParam = queryJson.ToJObject();
            var expression = LinqExtensions.True<TBL_BQBREntity>();
            //灾害点名称、灾害点编号、地理位置
            if (!queryParam["COMPPARAM"].IsEmpty())
            {
                string COMPPARAM = queryParam["COMPPARAM"].ToString();
                expression = expression.And(t => t.DISASTERNAME.Contains(COMPPARAM) | t.UNIFIEDCODE.Contains(COMPPARAM) | t.XMMC.Contains(COMPPARAM));
            }
            //灾害点名称
            if (!queryParam["DISASTERNAME"].IsEmpty())
            {
                string DISASTERNAME = queryParam["DISASTERNAME"].ToString();
                expression = expression.And(t => t.DISASTERNAME.Contains(DISASTERNAME));
            }
            if (!queryParam["XMMC"].IsEmpty())
            {
                string XMMC = queryParam["XMMC"].ToString();
                expression = expression.And(t => t.XMMC.Contains(XMMC));
            }
            //县 
            if (!queryParam["COUNTY"].IsEmpty())
            {
                string COUNTY = queryParam["COUNTY"].ToString();
                expression = expression.And(t => t.COUNTY.Contains(COUNTY));
            }
            //市 
            if (!queryParam["CITY"].IsEmpty())
            {
                string CITY = queryParam["CITY"].ToString();
                expression = expression.And(t => t.CITY.Contains(CITY));
            }
            //省 
            if (!queryParam["PROVINCE"].IsEmpty())
            {
                string PROVINCE = queryParam["PROVINCE"].ToString();
                expression = expression.And(t => t.PROVINCE.Contains(PROVINCE));
            }
            //灾害点编号
            if (!queryParam["UNIFIEDCODE"].IsEmpty())
            {
                string UNIFIEDCODE = queryParam["UNIFIEDCODE"].ToString();
                expression = expression.And(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE));
            }
            //灾害类型
            if (!queryParam["DISASTERTYPE"].IsEmpty())
            {
                string DISASTERTYPE = queryParam["DISASTERTYPE"].ToString();
                expression = expression.And(t => t.DISASTERTYPE.Contains(DISASTERTYPE));
            }
            //是否完成
            if (!queryParam["ISCOMPLETE"].IsEmpty())
            {
                string ISCOMPLETE = queryParam["ISCOMPLETE"].ToString();
                expression = expression.And(t => t.ISCOMPLETE.Contains(ISCOMPLETE));
            }
            //是否验收
            if (!queryParam["ISACCEPTANCE"].IsEmpty())
            {
                string ISACCEPTANCE = queryParam["ISACCEPTANCE"].ToString();
                expression = expression.And(t => t.ISACCEPTANCE.Contains(ISACCEPTANCE));
            }
            int startyear = 1900;
            int endyear = DateTime.Now.Year;
            //开始时间
            if (!queryParam["BQBRSTARTTIME"].IsEmpty())
            {
                string BQBRSTARTTIME = queryParam["BQBRSTARTTIME"].ToString();
                BQBRSTARTTIME = BQBRSTARTTIME.Substring(0, 4);
                startyear = Convert.ToInt32(BQBRSTARTTIME);
            }
            //结束时间
            if (!queryParam["BQBRENDTIME"].IsEmpty())
            {
                string BQBRENDTIME = queryParam["BQBRENDTIME"].ToString();
                BQBRENDTIME = BQBRENDTIME.Substring(0, 4);
                endyear = Convert.ToInt32(BQBRENDTIME);
            }
            List<string> yearlist = new List<string>();
            for (int i = startyear; i <= endyear; i++)
            {
                yearlist.Add(startyear.ToString());
            }
            if (!queryParam["BQBRENDTIME"].IsEmpty() || !queryParam["BQBRENDTIME"].IsEmpty())
            {
                expression = expression.And(t => yearlist.Contains(t.ANNUAL));
            }
            //数据范围权限过滤
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000") && !_codes.Equals("0"))
            {
                expression = expression.And(t => _codes.Contains(t.COUNTY));
            }
            //var expression = queryJsonExpression(queryJson);
            List<TBL_BQBREntity> result = new List<TBL_BQBREntity>();
            var list = this.BaseRepository().FindList(expression).ToList();
            if (!condition.IsEmpty())
            {
                var queryParam_Condition = condition.ToJObject();
                if (!queryParam_Condition["WKTString"].IsEmpty())
                {
                    string WKTString = queryParam_Condition["WKTString"].ToString();
                    foreach (var item in list)
                    {
                        if (!item.LONGITUDE.HasValue || !item.LATITUDE.HasValue)
                        {
                            continue;
                        }

                        bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.Value.ToString(), item.LATITUDE.Value.ToString());
                        if (isInsert)
                        {
                            result.Add(item);
                        }

                    }
                    return result;
                }
                if (!queryParam_Condition["x"].IsEmpty() && !queryParam_Condition["y"].IsEmpty() && !queryParam_Condition["radius"].IsEmpty())
                {
                    double x = queryParam_Condition["x"].ToDouble();
                    double y = queryParam_Condition["y"].ToDouble();
                    double radius = queryParam_Condition["radius"].ToDouble();
                    foreach (var item in list)
                    {
                        if (!item.LONGITUDE.HasValue || !item.LATITUDE.HasValue)
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
                if (!queryParam_Condition["polyline"].IsEmpty() && !queryParam_Condition["radius"].IsEmpty())
                {
                    string polyline = queryParam_Condition["polyline"].ToString();
                    double radius = queryParam_Condition["radius"].ToDouble();
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
            }


            return list;
        }

        /// <summary>
        /// 搬迁避让统计查询
        /// </summary>
        /// <param name="codeValue">行政区划编号</param>
        /// <param name="codeType">行政区划级别</param>
        /// <param name="xmmc">项目名称</param>
        /// <param name="annual">立项数据</param>
        /// <param name="static_Unit">统计单位</param>
        /// <returns></returns>
        public DataTable GetDataBqbrTj(string codeValue, string codeType, string xmmc, string annual, string static_Unit)
        {
            string sql = "select * from";
            string where1 = "1=1 ";
            if (!String.IsNullOrWhiteSpace(xmmc))
            {
                where1 += "and XMMC like '%" + xmmc + "%'";
            }
            if (!String.IsNullOrWhiteSpace(annual))
            {
                where1 += "and ANNUAL like '%" + annual + "%'";
            }
            string[] xzqhcodes = codeValue.Split(',');
            switch (codeType)
            {
                case "省":
                    if (xzqhcodes[0] != "")
                    {
                        for (var a = 0; a < xzqhcodes.Count(); a++)
                        {
                            if (a == 0)
                            {
                                where1 += "  and(PROVINCE in( '" + xzqhcodes[a] + "')";
                            }
                            else
                            {
                                where1 += " or PROVINCE in( '" + xzqhcodes[a] + "')";
                            }
                        }
                        where1 = where1 + ")";
                    }
                    // where1 += "and PROVINCE like '%" + codeValue + "%'";
                    break;
                case "市":
                    if (xzqhcodes[0] != "")
                    {
                        for (var a = 0; a < xzqhcodes.Count(); a++)
                        {
                            if (a == 0)
                            {
                                where1 += "  and(CITY in( '" + xzqhcodes[a] + "')";
                            }
                            else
                            {
                                where1 += " or CITY in( '" + xzqhcodes[a] + "')";
                            }
                        }
                        where1 = where1 + ")";
                    }
                    //where1 += "and CITY like '%" + codeValue + "%'";
                    break;
                case "县":
                    if (xzqhcodes[0] != "")
                    {
                        for (var a = 0; a < xzqhcodes.Count(); a++)
                        {
                            if (a == 0)
                            {
                                where1 += "  and(COUNTY in( '" + xzqhcodes[a] + "')";
                            }
                            else
                            {
                                where1 += " or COUNTY in( '" + xzqhcodes[a] + "')";
                            }
                        }
                        where1 = where1 + ")";
                    }
                    //where1 += "and COUNTY like '%" + codeValue + "%'";
                    break;
            }
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<string> _codes2 = _codes.Where(p => p.Contains("00")).ToList();
            if (_codes2.Count > 1)
            {
                where1 += " and CITY in('" + string.Join("','", _codes2.ToArray()) + "') ";//省级用户

            }
            else if (_codes2.Count == 1)
            {
                if (_codes2[0] != "000000" && !_codes2[0].Equals("0"))
                {
                    where1 += "  and COUNTY in('" + string.Join("','", _codes.ToArray()) + "') ";//市级用户

                }
                else if (_codes2[0] == "000000")
                {
                    where1 += "  ";//全国用户

                }
                else
                {
                    where1 += " ";//省级用户

                }
            }
            string sql1 = String.Format("select PROVINCENAME as 省,CITYNAME as 市,COUNTYNAME as 县,UNIFIEDCODE as 灾害点,MOVEDECIMAL as 搬迁人数,  "
                   + "ZAZBTJE as 总安置补贴金额,CASE WHEN SFWC = '1' THEN  1 ELSE 0 END AS 已完成, CASE WHEN SFYS = '1' THEN 1 ELSE 0 END AS 已验收, "
                   + " CASE WHEN RESETTLEMENT = '1' THEN 1 ELSE 0 END AS 集中安置,CASE WHEN RESETTLEMENT = '2' THEN 1 ELSE 0 END AS 分散安置,    "
                   + " CASE WHEN RESETTLEMENT = '3' THEN 1 ELSE 0 END AS 购房安置,CASE WHEN RESETTLEMENT = '4' THEN 1 ELSE 0 END AS 其它安置  "
                   + "from (select * from TBL_BQBR where {0} and  COUNTY is not null) qryTable", where1);

            string strSum = "count(DISTINCT(灾害点)) as  灾害点个数, SUM(集中安置 + 分散安置 + 购房安置 + 其它安置) as 搬迁户数, SUM(搬迁人数) AS 搬迁人数, SUM(集中安置) AS 集中安置个数,"
                       + " SUM(分散安置) AS 分散安置个数, SUM(购房安置) AS 购房安置个数,SUM(其它安置) AS 其它安置个数,SUM(已完成) AS 已完成个数, SUM(已验收) AS 已验收个数,SUM(总安置补贴金额) as 总安置补贴金额 ";

            switch (static_Unit)
            {
                case "省":
                    sql += "(select 省," + strSum + "from (" + sql1 + ") t group by  rollup(t.省) ) a  order by a.省  ";
                    break;
                case "市":
                    sql += "(select 省,市," + strSum + "from (" + sql1 + ") t group by  rollup(t.省,t.市) ) a  order by a.省 desc,a.市 desc";
                    break;
                case "县":
                    sql += "(select 省,市,县," + strSum + "from (" + sql1 + ") t group by  rollup(t.省,t.市,t.县) ) a  order by a.省 desc,a.市 desc,a.县 desc";
                    break;
            }
            return this.BaseRepository().FindTable(sql);
        }
        #endregion

        public IEnumerable<TreeByBQBRTJ> GetTJ(string queryJson)
        {
            var list = GetList(queryJson);
            var listcol = list.Where((x, i) => list.ToList().FindIndex(z => z.UNIFIEDCODE == x.UNIFIEDCODE && z.DISASTERNAME == x.DISASTERNAME && z.DISASTERTYPE == x.DISASTERTYPE) == i).ToList();
            List<TreeByBQBRTJ> newlist = new List<TreeByBQBRTJ>();
            foreach (var item in listcol)
            {
                TreeByBQBRTJ t = new TreeByBQBRTJ();
                t.id = item.UNIFIEDCODE;
                t.parent = "";
                t.DISASTERNAME = item.DISASTERNAME;
                t.DISASTERTYPE = item.DISASTERTYPE;
                t.LOCATION = item.LOCATION;
                t.level = "0";
                t.isLeaf = false;
                newlist.Add(t);
            }
            foreach (var item in list)
            {
                TreeByBQBRTJ t = new TreeByBQBRTJ();
                t.id = item.GUID;
                t.level = "1";
                t.parent = item.UNIFIEDCODE;
                t.HOUSEHOLDERNAME = item.HOUSEHOLDERNAME;
                t.RESETTLEMENT = item.RESETTLEMENT;
                t.SFWC = item.SFWC;
                t.SFYS = item.SFYS;

                t.MOVEDECIMAL = item.MOVEDECIMAL;
                t.ZAZBTJE = item.ZAZBTJE;
                t.YFJE = item.YFJE;
                t.DFJR = item.DFJR;

                newlist.Add(t);
                //t.data = new { GUID = item.GUID, UNIFIEDCODE = item.UNIFIEDCODE, HOUSEHOLDERNAME = item.HOUSEHOLDERNAME, RESETTLEMENT = item.RESETTLEMENT };
            }
            foreach (var item in newlist)
            {
                if (newlist.Where(s => s.id == item.parent).ToList().Count > 0)
                {
                    item.expanded = true;
                }
            }
            return newlist;
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
        public string SaveForm(string keyValue, TBL_BQBREntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                DateTime modifyTime = DateTime.Now;//当前时间
                UserInfo userInfo = ssoWS.GetUserInfo();
                string userName = userInfo.F_Account;//用户信息
                entity.CREATETIME = modifyTime;
                entity.CREATEUSER = userName;
                this.BaseRepository().Update(entity);
                return entity.GUID;
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
                return entity.GUID;
            }
        }
        #endregion


    }
}
