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
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.Service.SystemManage;
using Infoearth.Application.IService.SystemManage;
using Infoearth.Util;
using Infoearth.Application.Common;
using Infoearth.Application.Entity;
using Infoearth.Application.Entity.SystemManage.ViewModel;
using iTelluro.SYS.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Text;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-14 14:58
    /// 描 述：灾害点基本表
    /// </summary>
    public class TBL_HAZARDBASICINFOService : RepositoryFactory<TBL_HAZARDBASICINFOEntity>, TBL_HAZARDBASICINFOIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        private JYGC_PROJECTBASEINFOIService project = new JYGC_PROJECTBASEINFOService();
        private TBL_QCQF_DISASTERPREVENTIONIService qcqf = new TBL_QCQF_DISASTERPREVENTIONService();
        private static IDataItemDetailService serviceDataItem = new DataItemDetailService();
        private static EchartEntityNEWS _districtsDataCount = null;
        private static EchartEntityCJ _districtsDataCountCJ = null;

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetList(string queryJson)
        {
            return this.BaseRepository().IQueryable(queryJsonExpression(queryJson)).ToList();
        }
        public DataTable GetListCode(string queryJson)
        {
            string strsql = "select DISASTERNAME,DISASTERTYPE,UNIFIEDCODE,THREATENPEOPLE,THREATENASSETS,DANGERLEVEL,LOCATION,LONGITUDE,LATITUDE from TBL_HAZARDBASICINFO ";
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                strsql += " where county in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            return this.BaseRepository().FindTable(strsql);
            //return this.BaseRepository().IQueryable(queryJsonExpression(queryJson)).Select(u => new { DISASTERNAME = u.DISASTERNAME, DISASTERTYPE = u.DISASTERTYPE, UNIFIEDCODE = u.UNIFIEDCODE, THREATENPEOPLE = u.THREATENPEOPLE, THREATENASSETS = u.THREATENASSETS, DANGERLEVEL = u.DANGERLEVEL, LOCATION = u.LOCATION, LONGITUDE = u.LONGITUDE, LATITUDE = u.LATITUDE });
        }
        public EchartEntityNEW GetListCodes(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            EchartEntityNEW returnValue = new EchartEntityNEW();
            List<string> selectXZQH = new List<string>();
            List<string> _codes = ssoWS.GetAllAuthDistricts();//获取当前用户行政区划
            var DefalutCode = string.Empty;
            var selectColumn = string.Empty;
            var subLength = 2;
            IList<string> dataItemDetailList = new List<string>() { "总数" };
            if (_codes.Contains("000000"))
            {

                if (queryParam["SelectXZQH"].ToString() == "省")
                {
                    List<ParetEntity> districts2 = ssoWS.GetDistrictByParent("0");
                    returnValue.areacodeList = districts2.Select(p => p.DistrictCode).ToList();//行政区划编码
                    returnValue.areanameList = districts2.Select(p => p.DistrictName).ToList();//行政区划名称
                    returnValue.latitudeList = districts2.Select(p => p.F_LATITUDE).ToList();//行政区划经度
                    returnValue.longitudeList = districts2.Select(p => p.F_LONGITUDE).ToList();//行政区划纬度
                    selectXZQH = districts2.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
                    subLength = 2;

                }
                else if (queryParam["SelectXZQH"].ToString() == "市")  //将所有市返回
                {
                    List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
                    returnValue.areanameList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaName).ToList();
                    returnValue.areacodeList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaCode).ToList();
                    returnValue.latitudeList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_LATITUDE.ToString()).ToList();
                    returnValue.longitudeList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_LONGITUDE.ToString()).ToList();
                    selectXZQH = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
                    subLength = 4;
                }
                else if (queryParam["SelectXZQH"].ToString() == "县")  //将所有县返回
                {
                    List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
                    returnValue.areanameList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaName).ToList();
                    returnValue.areacodeList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode).ToList();
                    returnValue.latitudeList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_LATITUDE.ToString()).ToList();
                    returnValue.longitudeList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_LONGITUDE.ToString()).ToList();
                    selectXZQH = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
                    subLength = 6;
                }

                string groupBy = string.Format(" {0} ", DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, subLength));
                foreach (var item in selectXZQH)
                {
                    var code = item.Split(',')[0];
                    var name = item.Split(',')[1];
                    selectColumn += string.Format(" ,sum(case when {1}='{0}' then 1 else 0 end) \"{2}\" ", code.Substring(0, subLength), groupBy, name);
                }
                string sql = string.Format("select  '{0}' name {1} from TBL_HAZARDBASICINFO where 1=1 ", "总数", selectColumn);
                returnValue.count = convertDataTable(this.BaseRepository().FindTable(sql), dataItemDetailList);
            }
            else
            {
                if (queryParam["SelectXZQH"].ToString() == "省")
                {
                    //获取省名称
                    DefalutCode = _codes.FirstOrDefault().ToString().Substring(0, 2) + "0000";//获取当前省编码
                    List<ParetEntity> districts1 = ssoWS.GetDistrictByParent("0");
                    returnValue.areacodeList = districts1.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictCode).ToList();
                    returnValue.areanameList = districts1.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictName).ToList();
                    returnValue.latitudeList = districts1.Where(p => p.DistrictCode == DefalutCode).Select(p => p.F_LATITUDE).ToList();
                    returnValue.longitudeList = districts1.Where(p => p.DistrictCode == DefalutCode).Select(p => p.F_LONGITUDE).ToList();
                    selectXZQH = districts1.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
                    subLength = 2;
                }
                else
                {
                    if (queryParam["SelectXZQH"].ToString() == "市")  //将该省所有市返回
                    {

                        DefalutCode = _codes.FirstOrDefault().ToString().Substring(0, 2) + "0000";//获取当前省编码
                        List<ParetEntity> districts = ssoWS.GetDistrictByParent(DefalutCode);
                        returnValue.areacodeList = districts.Select(p => p.DistrictCode).ToList();//行政区划编码
                        returnValue.areanameList = districts.Select(p => p.DistrictName).ToList();//行政区划名称
                        returnValue.latitudeList = districts.Select(p => p.F_LATITUDE).ToList();//行政区划经度
                        returnValue.longitudeList = districts.Select(p => p.F_LONGITUDE).ToList();//行政区划纬度
                        selectXZQH = districts.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
                        subLength = 4;

                    }
                    else if (queryParam["SelectXZQH"].ToString() == "县")  //将该省所有县返回
                    {
                        DefalutCode = _codes.FirstOrDefault().ToString().Substring(0, 2);//获取当前省编码前两位
                        List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
                        returnValue.areanameList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCode).Select(p => p.F_AreaName).ToList();
                        returnValue.areacodeList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCode).Select(p => p.F_AreaCode).ToList();
                        returnValue.latitudeList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCode).Select(p => p.F_LATITUDE.ToString()).ToList();
                        returnValue.longitudeList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCode).Select(p => p.F_LONGITUDE.ToString()).ToList();
                        selectXZQH = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
                        subLength = 6;
                    }
                    if (queryParam["SelectXZQH"].ToString() != "数据")
                    {
                        string groupBy = string.Format(" {0} ", DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, subLength));
                        foreach (var item in selectXZQH)
                        {
                            var code = item.Split(',')[0];
                            var name = item.Split(',')[1];
                            selectColumn += string.Format(" ,sum(case when {1}='{0}' then 1 else 0 end) \"{2}\" ", code.Substring(0, subLength), groupBy, name);
                        }
                        string sql = string.Format("select  '{0}' name {1} from TBL_HAZARDBASICINFO where 1=1 ", "总数", selectColumn);
                        returnValue.count = convertDataTable(this.BaseRepository().FindTable(sql), dataItemDetailList);
                    }
                }
            }
            if (queryParam["SelectXZQH"].ToString() == "数据")
            {
                string sql = "select DISASTERNAME,DISASTERTYPE,UNIFIEDCODE,THREATENPEOPLE,THREATENASSETS,DANGERLEVEL,LOCATION,LONGITUDE,LATITUDE from TBL_HAZARDBASICINFO ";
                if (!_codes.Contains("000000"))
                {
                    sql += " where county in('" + string.Join("','", _codes.ToArray()) + "') ";
                }
                returnValue.data = this.BaseRepository().FindTable(sql);
            }

            return returnValue;
        }


        public EchartEntityNEWS GetListCodesNew()
        {
            _districtsDataCount = (EchartEntityNEWS)CacheHelper.GetCache("地灾首页聚合" + Infoearth.Application.Code.OperatorProvider.Provider.Current().UserId);
            EchartEntityNEWS returnValue = new EchartEntityNEWS();
            if (_districtsDataCount == null)
            {
                returnValue = GetListDataNew();
            }
            else
            {
                returnValue = _districtsDataCount;
            }
            return returnValue;
        }

        public EchartEntityNEWS GetListData()
        {
            EchartEntityNEWS returnValue = new EchartEntityNEWS();
            //获取当前用户行政区划
            List<string> _codes = ssoWS.GetAllAuthDistricts();//获取当前用户行政区划            
            IList<string> dataItemDetailList = new List<string>() { "总数" };
            //var reList = GetList("");
            if (_codes.Contains("000000"))
            {
                List<ParetEntity> districts2 = ssoWS.GetDistrictByParent("0");
                // List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
                List<AreaEntity> districts = ssoWS.GetAllDistrictsToCountry().ToList();
                List<string> selectXZQH1 = new List<string>();
                List<string> selectXZQH2 = new List<string>();
                List<string> selectXZQH3 = new List<string>();
                //省
                returnValue.proviceList = districts2.Select(p => p.DistrictCode).ToList();//行政区划编码
                returnValue.provicenameList = districts2.Select(p => p.DistrictName).ToList();//行政区划名称
                returnValue.provicelatitude = districts2.Select(p => p.F_LATITUDE).ToList();
                returnValue.provicelongitude = districts2.Select(p => p.F_LONGITUDE).ToList();
                selectXZQH1 = districts2.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
                string sql1 = searthsql(2, selectXZQH1);
                returnValue.provicecount = convertDataTable(this.BaseRepository().FindTable(sql1), dataItemDetailList);
                //市  
                var selectColumn1 = string.Empty;
                returnValue.citynameList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaName).ToList();
                returnValue.cityList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaCode).ToList();
                returnValue.citylatitude = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_LATITUDE.ToString()).ToList();
                returnValue.citylongitude = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_LONGITUDE.ToString()).ToList();
                selectXZQH2 = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
                string sql2 = searthsql(4, selectXZQH2);
                returnValue.citycount = convertDataTable(this.BaseRepository().FindTable(sql2), dataItemDetailList);
                //县 
                var selectColumn2 = string.Empty;
                returnValue.countynameList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaName).ToList();
                returnValue.countyList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode).ToList();
                returnValue.countylatitude = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_LATITUDE.ToString()).ToList();
                returnValue.countylongitude = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_LONGITUDE.ToString()).ToList();
                selectXZQH3 = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
                string sql3 = searthsql(6, selectXZQH3);
                returnValue.countycount = convertDataTable(this.BaseRepository().FindTable(sql3), dataItemDetailList);
            }
            else
            {
                List<string> selectXZQH1 = new List<string>();
                List<string> selectXZQH2 = new List<string>();
                List<string> selectXZQH3 = new List<string>();
                var DefalutCode = _codes.FirstOrDefault().ToString().Substring(0, 2) + "0000";//获取当前省编码
                //省           
                List<ParetEntity> districts = ssoWS.GetDistrictByParent("0");
                returnValue.proviceList = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictCode).ToList();
                returnValue.provicenameList = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictName).ToList();
                returnValue.provicelatitude = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.F_LATITUDE).ToList();
                returnValue.provicelongitude = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.F_LONGITUDE).ToList();
                selectXZQH1 = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
                var selectColumn = string.Empty;
                string sql1 = searthsql(2, selectXZQH1);
                returnValue.provicecount = convertDataTable(this.BaseRepository().FindTable(sql1), dataItemDetailList);
                //市
                List<ParetEntity> districts1 = ssoWS.GetDistrictByParent(DefalutCode);
                returnValue.cityList = districts1.Select(p => p.DistrictCode).ToList();//行政区划编码
                returnValue.citynameList = districts1.Select(p => p.DistrictName).ToList();//行政区划名称
                returnValue.citylatitude = districts1.Select(p => p.F_LATITUDE).ToList();//行政区划纬度
                returnValue.citylongitude = districts1.Select(p => p.F_LONGITUDE).ToList();//行政区划经度
                selectXZQH2 = districts1.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
                string sql2 = searthsql(4, selectXZQH2);
                returnValue.citycount = convertDataTable(this.BaseRepository().FindTable(sql2), dataItemDetailList);
                //县
                var DefalutCodes = _codes.FirstOrDefault().ToString().Substring(0, 2);//获取当前省编码前两位
                List<AreaEntity> districts2 = ssoWS.GetAllDistrictsToCountry().ToList();
                //List<AreaEntity> districts2 = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
                returnValue.countynameList = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_AreaName).ToList();
                returnValue.countyList = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_AreaCode).ToList();
                returnValue.countylatitude = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_LATITUDE.ToString()).ToList();
                returnValue.countylongitude = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_LONGITUDE.ToString()).ToList();
                selectXZQH3 = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
                string sql3 = searthsql(6, selectXZQH3);
                returnValue.countycount = convertDataTable(this.BaseRepository().FindTable(sql3), dataItemDetailList);
            }
            string sql = "select DISASTERNAME,DISASTERTYPE,UNIFIEDCODE,THREATENPEOPLE,THREATENASSETS,DANGERLEVEL,LOCATION,LONGITUDE,LATITUDE from TBL_HAZARDBASICINFO ";
            if (!_codes.Contains("000000"))
            {
                sql += " where county in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            returnValue.data = this.BaseRepository().FindTable(sql);
            CacheHelper.SetCache("地灾首页聚合" + Infoearth.Application.Code.OperatorProvider.Provider.Current().UserId, returnValue);//写缓存
            return returnValue;
        }

        /// <summary>
        /// 按照行政区划聚合
        /// </summary>
        /// <returns></returns>
        private EchartEntityNEWS GetListDataNew()
        {
            EchartEntityNEWS returnValue = new EchartEntityNEWS();
            //获取当前用户行政区划
            List<string> _codes = ssoWS.GetAllAuthDistricts();//获取当前用户行政区划            
            IList<string> dataItemDetailList = new List<string>() { "总数" };

            string sql = @"select  省编码,市编码,县编码, SUM (崩塌+泥石流+滑坡+斜坡+塌陷+地面沉降+地裂缝) as 灾害总数 from(
select 省编码, 市编码, 县编码, CASE WHEN 灾害体类型 = '崩塌' THEN 1 ELSE 0 END AS 崩塌, CASE WHEN 灾害体类型 = '地面塌陷' THEN 1 ELSE 0 END AS 塌陷,
CASE WHEN 灾害体类型 = '泥石流' THEN 1 ELSE 0 END AS 泥石流, CASE WHEN 灾害体类型 = '地面沉降' THEN 1 ELSE 0 END AS 地面沉降, CASE WHEN 灾害体类型 = '地裂缝' THEN 1 ELSE 0 END AS 地裂缝,
CASE WHEN 灾害体类型 = '滑坡' THEN 1 ELSE 0 END AS 滑坡, CASE WHEN 灾害体类型 = '斜坡' THEN 1 ELSE 0 END AS 斜坡 from(
select DISASTERTYPE as 灾害体类型, PROVINCENAME as 省, PROVINCE AS 省编码,CITYNAME as 市, CITY AS 市编码, COUNTYNAME as 县, COUNTY AS 县编码  from TBL_HAZARDBASICINFO   where COUNTY is not null and DATASOURCE='综合库' ";
            if (!_codes.Contains("000000"))
            {
                sql += " and COUNTY in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            sql += ") qryTable) t group by rollup(省编码, 市编码, 县编码) order by 省编码,市编码,县编码";
            DataTable dt = this.BaseRepository().FindTable(sql);

            List<string> lstprovicnedata = new List<string>();
            List<string> lstcitydata = new List<string>();
            List<string> lstcountydata = new List<string>();

            if (_codes.Contains("000000"))
            {
                List<ParetEntity> districts2 = ssoWS.GetDistrictByParent("0");
                List<AreaEntity> districts = ssoWS.GetAllDistrictsToCountry().ToList();
                //省
                returnValue.proviceList = districts2.Select(p => p.DistrictCode).ToList();//行政区划编码
                returnValue.provicenameList = districts2.Select(p => p.DistrictName).ToList();//行政区划名称
                returnValue.provicelatitude = districts2.Select(p => p.F_LATITUDE).ToList();
                returnValue.provicelongitude = districts2.Select(p => p.F_LONGITUDE).ToList();

                //市  
                var selectColumn1 = string.Empty;
                returnValue.citynameList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaName).ToList();
                returnValue.cityList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaCode).ToList();
                returnValue.citylatitude = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_LATITUDE.ToString()).ToList();
                returnValue.citylongitude = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_LONGITUDE.ToString()).ToList();

                //县 
                var selectColumn2 = string.Empty;
                returnValue.countynameList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaName).ToList();
                returnValue.countyList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode).ToList();
                returnValue.countylatitude = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_LATITUDE.ToString()).ToList();
                returnValue.countylongitude = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_LONGITUDE.ToString()).ToList();

            }
            else
            {
                var DefalutCode = _codes.FirstOrDefault().ToString().Substring(0, 2) + "0000";//获取当前省编码

                //省           
                List<ParetEntity> districts = ssoWS.GetDistrictByParent("0");
                returnValue.proviceList = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictCode).ToList();
                returnValue.provicenameList = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictName).ToList();
                returnValue.provicelatitude = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.F_LATITUDE).ToList();
                returnValue.provicelongitude = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.F_LONGITUDE).ToList();

                //市
                List<ParetEntity> districts1 = ssoWS.GetDistrictByParent(DefalutCode);
                returnValue.cityList = districts1.Select(p => p.DistrictCode).ToList();//行政区划编码
                returnValue.citynameList = districts1.Select(p => p.DistrictName).ToList();//行政区划名称
                returnValue.citylatitude = districts1.Select(p => p.F_LATITUDE).ToList();//行政区划纬度
                returnValue.citylongitude = districts1.Select(p => p.F_LONGITUDE).ToList();//行政区划经度

                //县
                var DefalutCodes = _codes.FirstOrDefault().ToString().Substring(0, 2);//获取当前省编码前两位
                List<AreaEntity> districts2 = ssoWS.GetAllDistrictsToCountry().ToList();
                returnValue.countynameList = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_AreaName).ToList();
                returnValue.countyList = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_AreaCode).ToList();
                returnValue.countylatitude = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_LATITUDE.ToString()).ToList();
                returnValue.countylongitude = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_LONGITUDE.ToString()).ToList();

            }
            //省   
            foreach (var item in returnValue.proviceList)
            {
                DataRow[] dr = dt.Select("省编码 = '" + item + "' and  市编码 is null and 县编码 is null");
                if (dr.Length == 0)
                {
                    lstprovicnedata.Add("0");
                    continue;
                }
                lstprovicnedata.Add(dr[0][3].ToString());
            }
            List<dataEntity> deprovince = new List<dataEntity>();
            dataEntity provinceEntity = new dataEntity();
            provinceEntity.name = "总数";
            provinceEntity.data = lstprovicnedata.ToArray();
            deprovince.Add(provinceEntity);
            returnValue.provicecount = deprovince;

            //市
            foreach (var item in returnValue.cityList)
            {
                DataRow[] dr = dt.Select("市编码 = '" + item + "'  and 县编码 is null ");
                if (dr.Length == 0)
                {
                    lstcitydata.Add("0");
                    continue;
                }
                lstcitydata.Add(dr[0][3].ToString());
            }
            List<dataEntity> decities = new List<dataEntity>();
            dataEntity cityEntity = new dataEntity();
            cityEntity.name = "总数";
            cityEntity.data = lstcitydata.ToArray();
            decities.Add(cityEntity);
            returnValue.citycount = decities;

            //县
            foreach (var item in returnValue.countyList)
            {
                DataRow[] dr = dt.Select("县编码 = '" + item + "'");
                if (dr.Length == 0)
                {
                    lstcountydata.Add("0");
                    continue;
                }
                lstcountydata.Add(dr[0][3].ToString());
            }
            List<dataEntity> decounties = new List<dataEntity>();
            dataEntity dataEntity = new dataEntity();
            dataEntity.name = "总数";
            dataEntity.data = lstcountydata.ToArray();
            decounties.Add(dataEntity);
            returnValue.countycount = decounties;

            //灾害数据
            string sqldisaster = "select DISASTERNAME,DISASTERTYPE,UNIFIEDCODE,THREATENPEOPLE,THREATENASSETS,DANGERLEVEL,LOCATION,LONGITUDE,LATITUDE from TBL_HAZARDBASICINFO ";
            if (!_codes.Contains("000000"))
            {
                sqldisaster += " where county in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            returnValue.data = this.BaseRepository().FindTable(sqldisaster);
            CacheHelper.SetCache("地灾首页聚合" + Infoearth.Application.Code.OperatorProvider.Provider.Current().UserId, returnValue);//写缓存
            return returnValue;
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
            string sql2 = string.Format("select  '{0}' name {1} from TBL_HAZARDBASICINFO  where 1=1 ", "总数", sql);
            return sql2;
        }

        #region 采集聚合
        public EchartEntityCJ GetListDataCJ(string queryJson)
        {
            //_districtsDataCountCJ = (EchartEntityCJ)CacheHelper.GetCache("地灾采集聚合");
            EchartEntityCJ returnValue = new EchartEntityCJ();
            if (_districtsDataCountCJ == null)
            {
                returnValue = GetListCJ(queryJson);
            }
            else
            {
                returnValue = _districtsDataCountCJ;
            }
            return returnValue;
        }
        public EchartEntityCJ GetListCJ(string queryJson)
        {
            EchartEntityCJ returnValue = new EchartEntityCJ();
            //获取当前用户行政区划
            //List<string> _codes = ssoWS.GetAllAuthDistrictsReturnDistrictDict().ToList().Select(s => s.DistrictCode).ToList();//获取当前用户行政区划            
            List<DistrictDict> _codes = ssoWS.GetAllAuthDistrictsReturnDistrictDict().ToList();//获取当前用户行政区划            
            IList<string> dataItemDetailList = new List<string>() { "滑坡", "崩塌", "泥石流", "地面沉降", "地面塌陷", "地裂缝", "斜坡" };
            if (_codes.Select(s => s.DistrictCode).Contains("000000"))
            {
                List<ParetEntity> districts2 = ssoWS.GetDistrictByParent("0");
                // List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
                List<AreaEntity> districts = ssoWS.GetAllDistrictsToCountry().ToList();
                List<string> selectXZQH1 = new List<string>();
                List<string> selectXZQH2 = new List<string>();
                List<string> selectXZQH3 = new List<string>();
                //省
                returnValue.proviceList = districts2.Select(p => p.DistrictCode).ToList();//行政区划编码
                returnValue.provicenameList = districts2.Select(p => p.DistrictName).ToList();//行政区划名称
                returnValue.provicelatitude = districts2.Select(p => p.F_LATITUDE).ToList();
                returnValue.provicelongitude = districts2.Select(p => p.F_LONGITUDE).ToList();
                selectXZQH1 = districts2.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
                string strSql = onesql(2, dataItemDetailList, selectXZQH1);
                returnValue.provicecount = convertDataTable(this.BaseRepository().FindTable(strSql), dataItemDetailList);
                //市  
                returnValue.citynameList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaName).ToList();
                returnValue.cityList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaCode).ToList();
                returnValue.citylatitude = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_LATITUDE.ToString()).ToList();
                returnValue.citylongitude = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_LONGITUDE.ToString()).ToList();
                selectXZQH2 = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
                string strSq2 = onesql(4, dataItemDetailList, selectXZQH2);
                returnValue.citycount = convertDataTable(this.BaseRepository().FindTable(strSq2), dataItemDetailList);
                //县 
                //returnValue.countynameList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaName).ToList();
                //returnValue.countyList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode).ToList();
                //returnValue.countylatitude = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_LATITUDE.ToString()).ToList();
                //returnValue.countylongitude = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_LONGITUDE.ToString()).ToList();
                //selectXZQH3 = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
                //string strSq3 = onesql(6, dataItemDetailList, selectXZQH3);
                //returnValue.countycount = convertDataTable(this.BaseRepository().FindTable(strSq3), dataItemDetailList);
            }
            else
            {
                List<string> selectXZQH1 = new List<string>();
                List<string> selectXZQH2 = new List<string>();
                List<string> selectXZQH3 = new List<string>();
                var DefalutCode = _codes.Select(s => s.DistrictCode).FirstOrDefault().ToString().Substring(0, 2) + "0000";//获取当前省编码
                //省           
                List<ParetEntity> districts = ssoWS.GetDistrictByParent("0");
                returnValue.proviceList = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictCode).ToList();
                returnValue.provicenameList = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictName).ToList();
                returnValue.provicelatitude = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.F_LATITUDE).ToList();
                returnValue.provicelongitude = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.F_LONGITUDE).ToList();
                selectXZQH1 = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
                string strSql = onesql(2, dataItemDetailList, selectXZQH1);
                returnValue.provicecount = convertDataTable(this.BaseRepository().FindTable(strSql), dataItemDetailList);
                //市
                List<ParetEntity> districts1 = ssoWS.GetDistrictByParent(DefalutCode);
                returnValue.cityList = districts1.Select(p => p.DistrictCode).ToList();//行政区划编码
                returnValue.citynameList = districts1.Select(p => p.DistrictName).ToList();//行政区划名称
                returnValue.citylatitude = districts1.Select(p => p.F_LATITUDE).ToList();//行政区划纬度
                returnValue.citylongitude = districts1.Select(p => p.F_LONGITUDE).ToList();//行政区划经度
                selectXZQH2 = districts1.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
                string sql2 = onesql(4, dataItemDetailList, selectXZQH2);
                returnValue.citycount = convertDataTable(this.BaseRepository().FindTable(sql2), dataItemDetailList);
                //县
                // var DefalutCodes = _codes.FirstOrDefault().ToString().Substring(0, 2);//获取当前省编码前两位
                //List<AreaEntity> districts2 = ssoWS.GetAllDistrictsToCountry().ToList();
                //List<AreaEntity> districts2 = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
                //returnValue.countynameList = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_AreaName).ToList();
                //returnValue.countyList = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_AreaCode).ToList();
                //returnValue.countylatitude = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_LATITUDE.ToString()).ToList();
                //returnValue.countylongitude = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_LONGITUDE.ToString()).ToList();
                //selectXZQH3 = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
                //string sql3 = onesql(6, dataItemDetailList, selectXZQH3);
                //returnValue.countycount = convertDataTable(this.BaseRepository().FindTable(sql3), dataItemDetailList);
            }
            var list = GetList(queryJson);
            //string datasql = "select DISASTERNAME,DISASTERTYPE,UNIFIEDCODE,THREATENPEOPLE,THREATENASSETS,DANGERLEVEL,LOCATION,LONGITUDE,LATITUDE from TBL_HAZARDBASICINFO  where 1=1 ";
            if (!_codes.Select(s => s.DistrictCode).Contains("000000"))
            {
                //datasql += " AND county in('" + string.Join("','", _codes.Select(s => s.DistrictCode).ToArray()) + "') ";
                list = list.Where(s => _codes.Select(ss => ss.DistrictCode).Contains(s.COUNTY));
            }
            //List<DataTable>
            //string sqls1 = datasql + " AND  DISASTERTYPE='滑坡' ";
            //string sqls2 = datasql + " AND  DISASTERTYPE='崩塌' ";
            //string sqls3 = datasql + " AND  DISASTERTYPE='泥石流' ";
            //string sqls4 = datasql + " AND  DISASTERTYPE='地面沉降' ";
            //string sqls5 = datasql + " AND  DISASTERTYPE='地面塌陷' ";
            //string sqls6 = datasql + " AND  DISASTERTYPE='地裂缝' ";
            //string sqls7 = datasql + " AND  DISASTERTYPE='斜坡' ";
            returnValue.HPdata = list.Where(s => s.DISASTERTYPE.Equals("滑坡")).ToList();
            returnValue.BTdata = list.Where(s => s.DISASTERTYPE.Equals("崩塌")).ToList();
            returnValue.NSLdata = list.Where(s => s.DISASTERTYPE.Equals("泥石流")).ToList();
            returnValue.CJdata = list.Where(s => s.DISASTERTYPE.Equals("地面沉降")).ToList();
            returnValue.TXdata = list.Where(s => s.DISASTERTYPE.Equals("地面塌陷")).ToList();
            returnValue.LFdata = list.Where(s => s.DISASTERTYPE.Equals("地裂缝")).ToList();
            returnValue.XPdata = list.Where(s => s.DISASTERTYPE.Equals("斜坡")).ToList();
            //returnValue.HPdata = this.BaseRepository().FindTable(sqls1);
            //returnValue.BTdata = this.BaseRepository().FindTable(sqls2);
            //returnValue.NSLdata = this.BaseRepository().FindTable(sqls3);
            //returnValue.CJdata= this.BaseRepository().FindTable(sqls4);
            //returnValue.TXdata = this.BaseRepository().FindTable(sqls5);
            //returnValue.LFdata = this.BaseRepository().FindTable(sqls6);
            //returnValue.XPdata = this.BaseRepository().FindTable(sqls7);          
            //CacheHelper.SetCache("地灾采集聚合", returnValue);//写缓存
            return returnValue;
        }
        private string onesql(int subLength, IList<string> dataItemDetailList, List<string> selectXZQH)
        {
            string sql = string.Empty;
            string strSql = string.Empty;
            for (int i = 0; i < dataItemDetailList.Count; i++)
            {
                if (i == 0)
                {
                    sql = " AND DISASTERTYPE='滑坡'";
                    strSql += searthSql(subLength, dataItemDetailList[i], selectXZQH, sql);
                }
                else if (i == 1)
                {
                    sql = " AND DISASTERTYPE='崩塌' ";
                    strSql += " union all " + searthSql(subLength, dataItemDetailList[i], selectXZQH, sql);
                }
                else if (i == 2)
                {
                    sql = " AND DISASTERTYPE='泥石流' ";
                    strSql += " union all " + searthSql(subLength, dataItemDetailList[i], selectXZQH, sql);
                }
                else if (i == 3)
                {
                    sql = " AND DISASTERTYPE='地面沉降' ";
                    strSql += " union all " + searthSql(subLength, dataItemDetailList[i], selectXZQH, sql);
                }
                else if (i == 4)
                {
                    sql = " AND DISASTERTYPE='地面塌陷' ";
                    strSql += " union all " + searthSql(subLength, dataItemDetailList[i], selectXZQH, sql);
                }
                else if (i == 5)
                {
                    sql = " AND DISASTERTYPE='地裂缝' ";
                    strSql += " union all " + searthSql(subLength, dataItemDetailList[i], selectXZQH, sql);
                }
                else
                {
                    sql = " AND  DISASTERTYPE='斜坡' ";
                    strSql += " union all " + searthSql(subLength, dataItemDetailList[i], selectXZQH, sql);
                }

            }
            return strSql;
        }
        private string searthSql(int subLength, string dicName, List<string> selectXZQH, string sqlWhere)
        {
            string selectColumn = "";
            string groupBy = string.Format(" {0} ", DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, subLength));
            foreach (var item in selectXZQH)
            {
                var code = item.Split(',')[0];
                var name = item.Split(',')[1];
                selectColumn += string.Format(" ,sum(case when {1}='{0}' then 1 else 0 end) \"{2}\" ", code.Substring(0, subLength), groupBy, code);
            }
            string returnValue = string.Format("select  '{0}' name {1} from  TBL_HAZARDBASICINFO  where 1=1 and  UNIFIEDCODE is not null  {2}", dicName, selectColumn, sqlWhere);
            return returnValue;
        }
        #endregion


        /// <summary>
        /// 检查查询条件语句是否正确
        /// </summary>
        /// <param name="sqlWhere">查询语句条件</param>
        /// <returns></returns>
        public bool CheckExpression(string sqlWhere)
        {
            if (string.IsNullOrEmpty(sqlWhere))
            {
                return true;
            }
            else
            {
                try
                {
                    this.BaseRepository().FindTable(string.Format("select * from TBL_HAZARDBASICINFO t where {0}", sqlWhere));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 取消Linq查询，使用Sql返回DataTable
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetDataByQcqfReturnHazardbasicInfo(ref Pagination pagination, string queryJson)
        {
            string strsql = @"select * from (
                    select tb.*,rownum rn from tbl_hazardbasicinfo ta
                    inner join tbl_qcqf_layoutpointinfo tb on ta.UNIFIEDCODE=tb.UNIFIEDCODE
                    inner join tbl_qcqf_pointobservation tc on tb.guid=tc.unifiedcode
                    inner join tbl_qcqf_observation td on tc.id=td.id and td.id like '%%'
                    and tb.UNIFIEDCODE != null and rownum<=(1*20)  ";
            pagination.records = this.BaseRepository().FindTable(strsql + ")").Rows.Count;
            strsql += ") where rn>(0*20)";
            //List<string> _codes = ssoWS.GetAllAuthDistricts();
            //if (!_codes.Contains("000000"))
            //{
            //    strsql += " where county in('" + string.Join("','", _codes.ToArray()) + "') ";
            //}
            return this.BaseRepository().FindTable(strsql);
            //return this.BaseRepository().IQueryable(queryJsonExpression(queryJson)).Select(u => new { DISASTERNAME = u.DISASTERNAME, DISASTERTYPE = u.DISASTERTYPE, UNIFIEDCODE = u.UNIFIEDCODE, THREATENPEOPLE = u.THREATENPEOPLE, THREATENASSETS = u.THREATENASSETS, DANGERLEVEL = u.DANGERLEVEL, LOCATION = u.LOCATION, LONGITUDE = u.LONGITUDE, LATITUDE = u.LATITUDE });
        }

        /// <summary>
        /// 灾害点统计只按灾害类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetHazardStatisticsJson2(string queryJson)
        {
            string strSelect = string.Empty, strWhere = string.Empty, strGroup = string.Empty, strOrder = string.Empty;
            string strType = string.Empty, strCase = string.Empty;
            GetWhere(ref strWhere, ref strGroup, ref strOrder, ref strSelect);
            var queryParam = queryJson.ToJObject();
            string sqlBase = @"select {1} from (select {2} from tbl_hazardbasicinfo where 1=1 ";
            //sqlBase += " and to_char(SURVEYTIME,'yyyy')=" + queryParam["YEAR"];
            if (queryParam["YEAR"] != null)
            {
                sqlBase += " and " + DbSqlFunctionHelper.DateToChar("SURVEYTIME", "yyyy") + "=" + queryParam["YEAR"];
            }
            if (queryParam["SelectXZQH"] != null)
            {
                if (queryParam["SelectXZQH"].ToString() != "000000")
                {
                    if (queryParam["SelectXZQH"].ToString().EndsWith("0000"))
                    {
                        sqlBase += " and UNIFIEDCODE like '" + queryParam["SelectXZQH"].ToString().Substring(0, 2) + "%'";
                    }
                    else
                    {
                        sqlBase += " and UNIFIEDCODE like '" + queryParam["SelectXZQH"].ToString().Substring(0, 4) + "%'";
                    }
                }

            }
            sqlBase += " {3} ) hazard";
            IEnumerable<DataItemDetailEntity> ls = serviceDataItem.GetItemDetailList("HazardType");
            foreach (var v in ls)
            {
                strType += "sum(hazard." + v.F_ItemName + ") " + v.F_ItemName + ",";
                strCase += "CASE WHEN " + "DISASTERTYPE" + " = '" + v.F_ItemName + "' THEN  1  ELSE  0  END " + v.F_ItemName + ",";
            }
            strType = strType.TrimEnd(',');
            strCase = strCase.TrimEnd(',');
            string sql = string.Format(sqlBase, strSelect, strType, strCase, strWhere, strGroup, strOrder);
            return this.BaseRepository().FindTable(sql);
        }
        /// <summary>
        /// 获取地图摘要信息查询
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回指定字段</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetZYPageList(string queryJson, string condition)
        {
            try
            {
                var queryParam = condition.ToJObject();
                var expression = queryJsonExpression(queryJson);
                List<TBL_HAZARDBASICINFOEntity> result = new List<TBL_HAZARDBASICINFOEntity>();
                var list = this.BaseRepository().FindList(expression).Select(t => new TBL_HAZARDBASICINFOEntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID, PROJECTID = t.PROJECTID, DANGERLEVEL = t.DANGERLEVEL, DISASTERLEVEL = t.DISASTERLEVEL, DEATHTOLL = t.DEATHTOLL, ASSETSLOSE = t.ASSETSLOSE, MISSINGPERSON = t.MISSINGPERSON, INJUREDPERSON = t.INJUREDPERSON, THREATENPEOPLE = t.THREATENPEOPLE, THREATENASSETS = t.THREATENASSETS, MODIFYTIME = t.MODIFYTIME == null ? Convert.ToDateTime("1970-01-01") : t.MODIFYTIME }).ToList();
                // result = list;
                if (!queryParam["WKTString"].IsEmpty())
                {
                    string WKTString = queryParam["WKTString"].ToString();
                    foreach (var item in list)
                    {
                        if (item.LONGITUDE.IsEmpty() || item.LONGITUDE.IsEmpty())
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
                        if (item.LONGITUDE.IsEmpty() || item.LONGITUDE.IsEmpty())
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
                //if (!queryParam["WKTString"].IsEmpty())
                //{
                //    string WKTString = queryParam["WKTString"].ToString();
                //    return result.Where(s => SpatialQueryHelper.isContainPoint(WKTString, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
                //}
                //if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
                //{
                //    double x = queryParam["x"].ToDouble();
                //    double y = queryParam["y"].ToDouble();
                //    double radius = queryParam["radius"].ToDouble();
                //    return result.Where(s => SpatialQueryHelper.PointInCircle(s.LATITUDE.ToDouble(), s.LONGITUDE.ToDouble(), y, x, radius)).ToList();
                //}
                //if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
                //{
                //    string polyline = queryParam["polyline"].ToString();
                //    double radius = queryParam["radius"].ToDouble();
                //    return result.Where(s => SpatialQueryHelper.IsIntersects(polyline, radius, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
                //}
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取地图摘要信息查询（有防灾预案表信息的点）
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回指定字段</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetZYPageList2(string queryJson, string condition)
        {

            try
            {
                var queryParam = condition.ToJObject(); string sqlw = "where 1=1 ";
                //var expression = queryJsonExpression(queryJson);
                var strWhere = GetWhereSql(queryJson);
                var queryParam1 = queryJson.ToJObject();
                if (!queryParam1["GROUPMONITORINGSTAFF"].IsEmpty())
                {
                    string value = queryParam1["GROUPMONITORINGSTAFF"].ToString();
                    sqlw += string.Format(" and GROUPMONITORINGSTAFF like '%{0}%'", value);
                }
                List<TBL_HAZARDBASICINFOEntity> result = new List<TBL_HAZARDBASICINFOEntity>();
                //List<TBL_HAZARDBASICINFOEntity> result2 = new List<TBL_HAZARDBASICINFOEntity>();
                //var list = this.BaseRepository().FindList(expression).Select(t => new TBL_HAZARDBASICINFOEntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID, PROJECTID = t.PROJECTID, DANGERLEVEL = t.DANGERLEVEL, DISASTERLEVEL = t.DISASTERLEVEL, DEATHTOLL = t.DEATHTOLL, ASSETSLOSE = t.ASSETSLOSE, MISSINGPERSON = t.MISSINGPERSON, INJUREDPERSON = t.INJUREDPERSON, THREATENPEOPLE = t.THREATENPEOPLE, THREATENASSETS = t.THREATENASSETS, MODIFYTIME = t.MODIFYTIME == null ? Convert.ToDateTime("1970-01-01") : t.MODIFYTIME }).ToList();
                //var list2 = qcqf.GetList(queryJson);
                string sql = @"select a.* from tbl_hazardbasicinfo a  where unifiedcode in (select unifiedcode from TBL_QCQF_DISASTERPREVENTION "+sqlw+ " ) " + strWhere;
                var list = new RepositoryFactory().BaseRepository().FindList<TBL_HAZARDBASICINFOEntity>(sql).ToList();
                // result = list;
                if (!queryParam["WKTString"].IsEmpty())
                {
                    string WKTString = queryParam["WKTString"].ToString();
                    foreach (var item in list)
                    {
                        if (item.LONGITUDE.IsEmpty() || item.LONGITUDE.IsEmpty())
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
                        if (item.LONGITUDE.IsEmpty() || item.LONGITUDE.IsEmpty())
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
                //if (!queryParam["WKTString"].IsEmpty())
                //{
                //    string WKTString = queryParam["WKTString"].ToString();
                //    return result.Where(s => SpatialQueryHelper.isContainPoint(WKTString, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
                //}
                //if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
                //{
                //    double x = queryParam["x"].ToDouble();
                //    double y = queryParam["y"].ToDouble();
                //    double radius = queryParam["radius"].ToDouble();
                //    return result.Where(s => SpatialQueryHelper.PointInCircle(s.LATITUDE.ToDouble(), s.LONGITUDE.ToDouble(), y, x, radius)).ToList();
                //}
                //if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
                //{
                //    string polyline = queryParam["polyline"].ToString();
                //    double radius = queryParam["radius"].ToDouble();
                //    return result.Where(s => SpatialQueryHelper.IsIntersects(polyline, radius, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
                //}

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 灾害点后四位编号生成
        /// </summary>
        /// <param name="xzqh"></param>
        /// <returns></returns>
        public string GetMaxCode(string xzqh)
        {
            string returnValue = "";
            var expression = LinqExtensions.True<TBL_HAZARDBASICINFOEntity>();
            //expression = expression.And(t => t.UNIFIEDCODE.StartsWith(xzqh) & t.UNIFIEDCODE.Length == 12);
            expression = expression.And(t => t.UNIFIEDCODE.StartsWith(xzqh));
            TBL_HAZARDBASICINFOEntity entity = this.BaseRepository().IQueryable(expression).OrderByDescending(p => p.UNIFIEDCODE).FirstOrDefault();
            if (entity == null)
            {
                returnValue = "0001";
            }
            else
            {
                int inta = 0;
                try
                {
                    inta = Convert.ToInt32(entity.UNIFIEDCODE.Substring(entity.UNIFIEDCODE.Trim().Length - 4, 4)) + 1;
                }
                catch (System.Exception)
                {

                }
                returnValue = inta.ToString().PadLeft(4, '0');
            }
            return returnValue;
        }
        /// <summary>
        /// 获取历史数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PastHAZARDBASICINFO> GetPastListJson2(string queryJson)
        {

            //崩塌
            TBL_AVALANCHE_HISTORYService service1 = new TBL_AVALANCHE_HISTORYService();
            var benta = service1.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.GUID, UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "崩塌", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = u.DISASTERLEVEL, DANGERLEVEL = u.DANGERLEVEL, MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE });
            //地面塌陷
            TBL_COLLAPSE_HISTORYService service2 = new TBL_COLLAPSE_HISTORYService();
            var dimiantaxian = service2.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "地面塌陷", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = u.DISASTERLEVEL, DANGERLEVEL = u.DANGERLEVEL, MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE });
            //泥石流
            TBL_DEBRISFLOW_HISTORYService service3 = new TBL_DEBRISFLOW_HISTORYService();
            var nishiliu = service3.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.GUID, UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "泥石流", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = u.DISASTERLEVEL, DANGERLEVEL = u.DANGERLEVEL, MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE });
            //地裂缝
            TBL_LANDCRACK_HISTORYService service4 = new TBL_LANDCRACK_HISTORYService();
            var diliefeng = service4.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.GUID, UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "地裂缝", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = u.DISASTERLEVEL, DANGERLEVEL = u.DANGERLEVEL, MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE });
            //地面沉降
            TBL_LANDSETTLEMENT_HISTORYService service5 = new TBL_LANDSETTLEMENT_HISTORYService();
            var dimianchengjiang = service5.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.GUID, UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "地面沉降", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = "无", DANGERLEVEL = "无", MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE });
            //滑坡
            TBL_LANDSLIP_HISTORYService service6 = new TBL_LANDSLIP_HISTORYService();
            var huapo = service6.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.GUID, UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "滑坡", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = u.DISASTERLEVEL, DANGERLEVEL = u.DANGERLEVEL, MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE });
            //斜坡
            TBL_SLOPE_HISTORYService service7 = new TBL_SLOPE_HISTORYService();
            var xiepo = service7.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.GUID, UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "斜坡", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = u.DISASTERLEVEL, DANGERLEVEL = u.DANGERLEVEL, MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE });
            var data = benta.Union(dimiantaxian).Union(nishiliu).Union(diliefeng).Union(dimianchengjiang).Union(huapo).Union(xiepo).OrderByDescending(u => u.UNIFIEDCODE).ThenByDescending(u => u.MODIFIEDDATE);
            List<PastHAZARDBASICINFO> result = new List<PastHAZARDBASICINFO>();
            //行政区划账号权限筛选
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            //筛选，获取授权的行政区划
            List<string> author = ws.GetAllAuthDistricts();
            if (author != null && author.Count > 0)
            {
                var expression2 = LinqExtensions.False<TBL_HAZARDBASICINFOEntity>();
                foreach (var au in author)
                {
                    //全国权限
                    if (au.EndsWith("000000"))
                    {
                        return data;
                    }
                    //省权限
                    else if (au.EndsWith("0000"))
                    {
                        var temp = data.Where(t => t.UNIFIEDCODE.StartsWith(au.Substring(0, 2))).ToList();
                        foreach (var item in temp)
                        {
                            if (!result.Contains(item))
                            {
                                result.Add(item);
                            }
                        }
                    }
                    //市权限
                    else if (au.EndsWith("00"))
                    {
                        var temp = data.Where(t => t.UNIFIEDCODE.StartsWith(au.Substring(0, 4)) || t.UNIFIEDCODE == au.Substring(0, 2) + "0000").ToList();
                        foreach (var item in temp)
                        {
                            if (!result.Contains(item))
                            {
                                result.Add(item);
                            }
                        }
                    }
                    //县权限
                    else
                    {
                        var temp = data.Where(t => t.UNIFIEDCODE.StartsWith(au.Substring(0, 6)) || t.UNIFIEDCODE == au.Substring(0, 4) + "00" || t.UNIFIEDCODE == au.Substring(0, 2) + "0000").ToList();
                        foreach (var item in temp)
                        {
                            if (!result.Contains(item))
                            {
                                result.Add(item);
                            }
                        }
                    }
                }
                return result;
            }
            return data;
        }
        /// <summary>
        /// 获取没有两卡一表信息的灾害点
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetNoQcqfPageList(string queryJson, string condition)
        {
            try
            {
                var queryParam = condition.ToJObject();
                var expression = queryJsonExpression(queryJson);
                List<TBL_HAZARDBASICINFOEntity> result = new List<TBL_HAZARDBASICINFOEntity>();
                List<TBL_HAZARDBASICINFOEntity> result2 = new List<TBL_HAZARDBASICINFOEntity>();
                var list = this.BaseRepository().FindList(expression).Select(t => new TBL_HAZARDBASICINFOEntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID, PROJECTID = t.PROJECTID, DANGERLEVEL = t.DANGERLEVEL, DISASTERLEVEL = t.DISASTERLEVEL, DEATHTOLL = t.DEATHTOLL, ASSETSLOSE = t.ASSETSLOSE, MISSINGPERSON = t.MISSINGPERSON, INJUREDPERSON = t.INJUREDPERSON, THREATENPEOPLE = t.THREATENPEOPLE, THREATENASSETS = t.THREATENASSETS, MODIFYTIME = t.MODIFYTIME == null ? Convert.ToDateTime("1970-01-01") : t.MODIFYTIME }).ToList();
                var list2 = qcqf.GetList(queryJson);
                foreach (var item in list)
                {
                    foreach (var item2 in list2)
                    {
                        if (item2.UNIFIEDCODE != item.UNIFIEDCODE)
                        {
                            result2.Add(item);
                        }
                    }
                }
                return result2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetAllList()
        {
            int count = 0;
            string sql = "select count(1) as nums from TBL_HAZARDBASICINFO where unifiedcode is not null";
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                sql += " and county in('" + string.Join("','", _codes.ToArray()) + "') ";
            }

            DataTable counts = this.BaseRepository().FindTable(sql);
            if (counts.Rows.Count > 0)
            {
                count = counts.Rows[0]["nums"].ToInt();
            }
            return count;
        }
        /// <summary>
        /// 获取单列数据（用于统计条件查询）
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns>返回列表Json</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetSinglePageList(Pagination pagination, string queryJson)
        {
            dynamic json = JToken.Parse(queryJson) as dynamic;
            string colmn = json.colmn;
            string sql = string.Format("SELECT   DISTINCT({0})  from   TBL_HAZARDBASICINFO  t where 1=1 ", colmn);
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                sql += " AND county in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            var data = this.BaseRepository().FindTable(sql);
            List<TBL_HAZARDBASICINFOEntity> result = data.ConvertToModel<TBL_HAZARDBASICINFOEntity>();
            pagination.records = result.Count();
            return result.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJson(Pagination pagination, string queryJson)
        {
            return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);
        }
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJson2(Pagination pagination, string queryJson)
        {
            string sql = string.Format("SELECT   DISTINCT({0})  from   TBL_HAZARDBASICINFO  t where 1=1  AND {0} IS NOT NULL", queryJson);
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                sql += " AND county in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            var data = this.BaseRepository().FindTable(sql);
            List<TBL_HAZARDBASICINFOEntity> result = data.ConvertToModel<TBL_HAZARDBASICINFOEntity>();
            pagination.records = result.Count();
            return result.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJsons(Pagination pagination, string queryJson, string condition)
        {
            if (string.IsNullOrEmpty(condition) || condition == "{}")
            {
                return GetZYPageList(queryJson, condition, pagination).OrderByDescending(t => t.MODIFYTIME);
            }
            var result = GetZYPageList(queryJson, condition).OrderByDescending(t => t.MODIFYTIME);
            pagination.records = result.Count();
            return result.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
        }
        /// <summary>
        /// 获取历史数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PastHAZARDBASICINFO> GetPastListJson(string queryJson, string condition)
        {

            //崩塌
            TBL_AVALANCHE_HISTORYService service1 = new TBL_AVALANCHE_HISTORYService();
            var benta = service1.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.GUID, UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "崩塌", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = u.DISASTERLEVEL, DANGERLEVEL = u.DANGERLEVEL, MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE, FILLDATE = u.FILLTABLEDATE.ToString() });
            //地面塌陷
            TBL_COLLAPSE_HISTORYService service2 = new TBL_COLLAPSE_HISTORYService();
            var dimiantaxian = service2.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "地面塌陷", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = u.DISASTERLEVEL, DANGERLEVEL = u.DANGERLEVEL, MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE, FILLDATE = u.FILLTABLEDATE.ToString() });
            //泥石流
            TBL_DEBRISFLOW_HISTORYService service3 = new TBL_DEBRISFLOW_HISTORYService();
            var nishiliu = service3.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.GUID, UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "泥石流", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = u.DISASTERLEVEL, DANGERLEVEL = u.DANGERLEVEL, MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE, FILLDATE = u.FILLTABLEDATE.ToString() });
            //地裂缝
            TBL_LANDCRACK_HISTORYService service4 = new TBL_LANDCRACK_HISTORYService();
            var diliefeng = service4.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.GUID, UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "地裂缝", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = u.DISASTERLEVEL, DANGERLEVEL = u.DANGERLEVEL, MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE, FILLDATE = u.FILLTABLEDATE.ToString() });
            //地面沉降
            TBL_LANDSETTLEMENT_HISTORYService service5 = new TBL_LANDSETTLEMENT_HISTORYService();
            var dimianchengjiang = service5.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.GUID, UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "地面沉降", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = "无", DANGERLEVEL = "无", MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE, FILLDATE = u.FILLTABLEDATE.ToString() });
            //滑坡
            TBL_LANDSLIP_HISTORYService service6 = new TBL_LANDSLIP_HISTORYService();
            var huapo = service6.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.GUID, UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "滑坡", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = u.DISASTERLEVEL, DANGERLEVEL = u.DANGERLEVEL, MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE, FILLDATE = u.FILLTABLEDATE.ToString() });
            //斜坡
            TBL_SLOPE_HISTORYService service7 = new TBL_SLOPE_HISTORYService();
            var xiepo = service7.GetWhereSubsetList(queryJson).Select(u => new PastHAZARDBASICINFO { GUID = u.GUID, UNIFIEDCODE = u.UNIFIEDCODE, DISASTERUNITNAME = u.DISASTERUNITNAME, DISASTERTYPE = "斜坡", MODIFYTYPE = u.MODIFYTYPE, EDITOR = u.EDITOR, AUDITOR = u.AUDITOR, LOCATION = u.LOCATION, DISASTERLEVEL = u.DISASTERLEVEL, DANGERLEVEL = u.DANGERLEVEL, MODIFIEDDATE = u.MODIFIEDDATE, LATITUDE = u.LATITUDE, LONGITUDE = u.LONGITUDE, FILLDATE = u.FILLTABLEDATE.ToString() });
            var data = benta.Union(dimiantaxian).Union(nishiliu).Union(diliefeng).Union(dimianchengjiang).Union(huapo).Union(xiepo).OrderByDescending(u => u.UNIFIEDCODE).ThenByDescending(u => u.MODIFIEDDATE).ThenByDescending(u => u.FILLDATE);
            List<PastHAZARDBASICINFO> result = new List<PastHAZARDBASICINFO>();
            var queryParam = condition.ToJObject();
            // var expression = queryJsonExpression(queryJson);
            //List<TBL_HAZARDBASICINFOEntity> result = new List<TBL_HAZARDBASICINFOEntity>();
            //  var list = this.BaseRepository().FindList(expression).Select(t => new TBL_HAZARDBASICINFOEntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID, PROJECTID = t.PROJECTID, DANGERLEVEL = t.DANGERLEVEL, DISASTERLEVEL = t.DISASTERLEVEL, DEATHTOLL = t.DEATHTOLL, ASSETSLOSE = t.ASSETSLOSE, MISSINGPERSON = t.MISSINGPERSON, INJUREDPERSON = t.INJUREDPERSON, THREATENPEOPLE = t.THREATENPEOPLE, THREATENASSETS = t.THREATENASSETS, MODIFYTIME = t.MODIFYTIME == null ? Convert.ToDateTime("1970-01-01") : t.MODIFYTIME }).ToList();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                foreach (var item in data)
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
                foreach (var item in data)
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
                foreach (var item in data)
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
            //行政区划账号权限筛选
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            //筛选，获取授权的行政区划
            List<string> author = ws.GetAllAuthDistricts();
            if (author != null && author.Count > 0)
            {
                var expression2 = LinqExtensions.False<TBL_HAZARDBASICINFOEntity>();
                foreach (var au in author)
                {
                    //全国权限
                    if (au.EndsWith("000000") || au.Equals("0"))
                    {
                        return data;
                    }
                    //省权限
                    else if (au.EndsWith("0000"))
                    {
                        var temp = data.Where(t => t.UNIFIEDCODE.StartsWith(au.Substring(0, 2))).ToList();
                        foreach (var item in temp)
                        {
                            if (!result.Contains(item))
                            {
                                result.Add(item);
                            }
                        }
                    }
                    //市权限
                    else if (au.EndsWith("00"))
                    {
                        var temp = data.Where(t => t.UNIFIEDCODE.StartsWith(au.Substring(0, 4)) || t.UNIFIEDCODE == au.Substring(0, 2) + "0000").ToList();
                        foreach (var item in temp)
                        {
                            if (!result.Contains(item))
                            {
                                result.Add(item);
                            }
                        }
                    }
                    //县权限
                    else
                    {
                        var temp = data.Where(t => t.UNIFIEDCODE.StartsWith(au.Substring(0, 6)) || t.UNIFIEDCODE == au.Substring(0, 4) + "00" || t.UNIFIEDCODE == au.Substring(0, 2) + "0000").ToList();
                        foreach (var item in temp)
                        {
                            if (!result.Contains(item))
                            {
                                result.Add(item);
                            }
                        }
                    }
                }
                return result;
            }

            return data;
        }

        /// <summary>
        /// 获取历史数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<PastHAZARDBASICINFO> GetPastPageListJson(Pagination pagination, string queryJson)
        {
            var toodata = GetPastListJson(queryJson, "");
            pagination.records = toodata.Count();
            return toodata.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows).AsQueryable();
        }

        /// <summary>
        /// 根据UNIFIEDCODE获取实体
        /// </summary>
        /// <param name="UNIFIEDCODE"></param>
        /// <returns></returns>
        public TBL_HAZARDBASICINFOEntity GetUNIFIEDCODEEntity(string UNIFIEDCODE)
        {
            var experssion = LinqExtensions.True<TBL_HAZARDBASICINFOEntity>();
            experssion = experssion.And(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE));
            return this.BaseRepository().FindList(experssion).FirstOrDefault();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_HAZARDBASICINFOEntity GetEntity(string keyValue)
        {
            if (keyValue.Length > 12)
            {
                //keyValue += " " + " " + " " + " ";
                keyValue = keyValue.Substring(0, 12);
            }
            return this.BaseRepository().FindEntity(keyValue);
        }

        /// <summary>
        /// 获取统计数据
        /// </summary>
        /// <param name="queryJson">查询条件</param>
        /// <param name="queryDic">输出参数</param>
        /// <returns></returns>
        public List<TBL_HAZARDBASICINFOEntity> GetCountAnalyseList(string queryJson)
        {

            List<TBL_HAZARDBASICINFOEntity> List = new List<TBL_HAZARDBASICINFOEntity>();

            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

            var expression = LinqExtensions.True<TBL_HAZARDBASICINFOEntity>();

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {

                #region 省市县级联条件

                var expression1 = LinqExtensions.False<TBL_HAZARDBASICINFOEntity>();

                //镇
                string TOWN = json.TOWN;
                //县
                string COUNTY = json.COUNTY;
                //市
                string CITY = json.CITY;
                //省
                string PROVINCE = json.PROVINCE;

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
                string nianfen = json.nianfen;
                if (!string.IsNullOrEmpty(nianfen))
                {
                    //统计数据的年
                    expression.And(t => t.CREATETIME.ToString().StartsWith(nianfen));
                }
                List = this.BaseRepository().IQueryable(expression).ToList();
                if (List.Count() > 0)
                {//有数据才能进行下面的判断否则无法使用select方法筛选数据

                    string zuhesql = json.zuhesql;
                    if (!string.IsNullOrEmpty(zuhesql))
                    {
                        //组合sql条件
                        //读取数据转化为DataSet在通过select函数筛选组合sql条件
                        DataSet ds = ToDataSet(List);
                        DataTable dt = ds.Tables[0].Clone();
                        foreach (var item in ds.Tables[0].Select(zuhesql))
                        {
                            dt.ImportRow(item);
                        }
                        DataSet dddss = new DataSet();
                        dddss.Tables.Add(dt);
                        //组合条件筛选完成之后转换为实体集合
                        List = DataSetToList<TBL_HAZARDBASICINFOEntity>(dddss, 0);

                    }
                }
            }
            return List;
        }
        public bool ValidateSQL(string sql)
        {
            var connStr = "Server=DEDICATED;user id=P60_GDGEODISASTER;password=gd123456";
            bool bResult;
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "SET PARSEONLY ON";
                    try
                    {
                        string strParams = "@starttime";
                        cmd.CommandText = sql;
                        // cmd.Parameters.AddWithValue(strParams, "2010-01-01");
                        cmd.ExecuteNonQuery();
                        bResult = true;
                    }
                    catch (Exception ex)
                    {
                        bResult = false;
                        // LogHelper.Error("SQL语法错误" + ex);
                    }
                    finally
                    {
                        cmd.CommandText = "SET PARSEONLY OFF";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            return bResult;
        }
        /// <summary>
        /// 根据条件统计灾害点信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetAnalyseList(string queryJson)
        {

            var sqlTemp = TJSql("0");//不包含隐患点   -0:不包含  -1 :包含
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
            //是否关联项目
            string ISGLPROJECT = json.ISGLPROJECT;
            if (!String.IsNullOrEmpty(ISGLPROJECT))
            {
                sqlWhere = " and t.projectid ='" + ISGLPROJECT + "' ";
                sqlwherezhd = " and i.projectid ='" + ISGLPROJECT + "' ";

            }
            //未销号数据
            //sqlWhere += string.Format(" and t.ISXH = '{0}'", 0);
            string DISASTERTYPE = json.DISASTERTYPE;
            if (!string.IsNullOrEmpty(DISASTERTYPE))
            {
                sqlWhere += string.Format(" and t.DISASTERTYPE like '%{0}%'", DISASTERTYPE);
                sqlwherezhd += string.Format(" and i.DISASTERTYPE like '%{0}%'", DISASTERTYPE);
            }
            //险情等级
            string DANGERLEVEL1 = json.DANGERLEVEL;
            if (!string.IsNullOrEmpty(DANGERLEVEL1))
            {
                sqlWhere += string.Format(" and t.DANGERLEVEL like '%{0}%'", DANGERLEVEL1);
                sqlwherezhd += string.Format(" and i.DANGERLEVEL like '%{0}%'", DANGERLEVEL1);
            }
            //灾情等级
            string DISASTERLEVEL1 = json.DISASTERLEVEL;
            if (!string.IsNullOrEmpty(DISASTERLEVEL1))
            {
                sqlWhere += string.Format(" and t.DISASTERLEVEL like '%{0}%'", DISASTERLEVEL1);
                sqlwherezhd += string.Format(" and i.DISASTERLEVEL like '%{0}%'", DISASTERLEVEL1);
            }
            //是否隐患点
            string HIDDENDANGER = json.HIDDENDANGER;
            if (!string.IsNullOrEmpty(HIDDENDANGER))
            {
                sqlWhere += string.Format(" and t.HIDDENDANGER like '%{0}%'", HIDDENDANGER);
                sqlwherezhd += string.Format(" and i.HIDDENDANGER like '%{0}%'", HIDDENDANGER);
            }
           // 重要隐患点
            string zhlxNew = json.ZHDLX;
            if (!string.IsNullOrEmpty(zhlxNew))
            {
                if (zhlxNew.ToString() == "1")
                {
                    sqlWhere += string.Format(" and t.ISZDYHD = '1'");
                    sqlwherezhd += string.Format(" and i.ISZDYHD = '1'");
                }
                else if (zhlxNew.ToString() == "2")
                {
                    sqlWhere += string.Format(" and t.THREATENPEOPLE > '1000' and t.ISZDYHD = '1' ");
                    sqlwherezhd += string.Format(" and i.THREATENPEOPLE > '1000'  and i.ISZDYHD = '1'");
                }
            }
            //今后变化趋势
            string STABLETREND = json.STABLETREND;
            if (!string.IsNullOrEmpty(STABLETREND))
            {
                sqlWhere += string.Format(" and t.STABLETREND like '%{0}%'", STABLETREND);
                sqlwherezhd += string.Format(" and i.STABLETREND like '%{0}%'", STABLETREND);
            }
            string CURRENTSTABLESTATUS = json.CURRENTSTABLESTATUS;
            if (!string.IsNullOrEmpty(CURRENTSTABLESTATUS))
            {
                sqlWhere += string.Format(" and t.CURSTABLESTATUS like '%{0}%'", CURRENTSTABLESTATUS);
                sqlwherezhd += string.Format(" and i.CURSTABLESTATUS like '%{0}%'", CURRENTSTABLESTATUS);
            }
            string THREATENPEOPLEBEGIN = json.THREATENPEOPLEBEGIN;
            if (!string.IsNullOrEmpty(THREATENPEOPLEBEGIN))
            {
                sqlWhere += string.Format(" and t.THREATENPEOPLE >= {0}", THREATENPEOPLEBEGIN);
                sqlwherezhd += string.Format(" and i.THREATENPEOPLE >= {0}", THREATENPEOPLEBEGIN);
            }
            string THREATENPEOPLEEND = json.THREATENPEOPLEEND;
            if (!string.IsNullOrEmpty(THREATENPEOPLEEND))
            {
                sqlWhere += string.Format(" and t.THREATENPEOPLE <= {0}", THREATENPEOPLEEND);
                sqlwherezhd += string.Format(" and i.THREATENPEOPLE <= {0}", THREATENPEOPLEEND);
            }
            string ASSETSLOSEBEGIN = json.ASSETSLOSEBEGIN;
            if (!string.IsNullOrEmpty(ASSETSLOSEBEGIN))
            {
                sqlWhere += string.Format(" and t.THREATENASSETS >= {0}", ASSETSLOSEBEGIN);
                sqlwherezhd += string.Format(" and i.THREATENASSETS >= {0}", ASSETSLOSEBEGIN);
            }
            string ASSETSLOSEEND = json.ASSETSLOSEEND;
            if (!string.IsNullOrEmpty(ASSETSLOSEEND))
            {
                sqlWhere += string.Format(" and t.THREATENASSETS <= {0}", ASSETSLOSEEND);
                sqlwherezhd += string.Format(" and i.THREATENASSETS <= {0}", ASSETSLOSEEND);
            }
            string DISAATERSIZE = json.DISAATERSIZE;
            if (!string.IsNullOrEmpty(DISAATERSIZE))
            {
                sqlWhere += string.Format(" and t.SCALELEVEL like '%{0}%'", DISAATERSIZE);
                sqlwherezhd += string.Format(" and i.SCALELEVEL like '%{0}%'", DISAATERSIZE);
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

        private DataTable getProvinceStaticData(DataTable city)
        {
            var query = from t in city.AsEnumerable()
                        group t by new { t1 = t.Field<string>("province"), t2 = t.Field<string>("PROVINCENAME") } into m
                        select new
                        {
                            province = m.Key.t1,
                            provincename = m.Key.t2,
                            hp = m.Sum(n => n.Field<decimal>("hp")),
                            bt = m.Sum(n => n.Field<decimal>("bt")),
                            xp = m.Sum(n => n.Field<decimal>("xp")),
                            nsl = m.Sum(n => n.Field<decimal>("nsl")),
                            dmcj = m.Sum(n => n.Field<decimal>("dmcj")),
                            dlf = m.Sum(n => n.Field<decimal>("dlf")),
                            dmtx = m.Sum(n => n.Field<decimal>("dmtx")),
                            yhd = m.Sum(n => n.Field<decimal>("yhd")),
                            yhdhp = m.Sum(n => n.Field<decimal>("yhdhp")),
                            yhdbt = m.Sum(n => n.Field<decimal>("yhdbt")),
                            yhdnsl = m.Sum(n => n.Field<decimal>("yhdnsl")),
                            yhdxp = m.Sum(n => n.Field<decimal>("yhdxp")),
                            yhddmtx = m.Sum(n => n.Field<decimal>("yhddmtx")),
                            yhddlf = m.Sum(n => n.Field<decimal>("yhddlf")),
                            yhddmcj = m.Sum(n => n.Field<decimal>("yhddmcj")),
                            zqxx = m.Sum(n => n.Field<decimal>("zqxx")),
                            zqzx = m.Sum(n => n.Field<decimal>("zqzx")),
                            zqdx = m.Sum(n => n.Field<decimal>("zqdx")),
                            zqtdx = m.Sum(n => n.Field<decimal>("zqtdx")),
                            xqxx = m.Sum(n => n.Field<decimal>("xqxx")),
                            xqzx = m.Sum(n => n.Field<decimal>("xqzx")),
                            xqdx = m.Sum(n => n.Field<decimal>("xqdx")),
                            xqtdx = m.Sum(n => n.Field<decimal>("xqtdx")),
                            hhfw = m.Sum(n => n.Field<decimal>("hhfw")),
                            hl = m.Sum(n => n.Field<decimal>("hl")),
                            hq = m.Sum(n => n.Field<decimal>("hq")),
                            wxcc = m.Sum(n => n.Field<decimal?>("wxcc")),
                            wxrk = m.Sum(n => n.Field<decimal?>("wxrk")),
                            mqwd = m.Sum(n => n.Field<decimal>("mqwd")),
                            mqqzbwd = m.Sum(n => n.Field<decimal>("mqqzbwd")),
                            mqbwd = m.Sum(n => n.Field<decimal>("mqbwd")),
                            jhwd = m.Sum(n => n.Field<decimal>("jhwd")),
                            jhqzbwd = m.Sum(n => n.Field<decimal>("jhqzbwd")),
                            jhbwd = m.Sum(n => n.Field<decimal>("jhbwd")),
                            jcms = m.Sum(n => n.Field<decimal>("jcms")),
                            jcss = m.Sum(n => n.Field<decimal>("jcss")),
                            jcdm = m.Sum(n => n.Field<decimal>("jcdm")),
                            jcsb = m.Sum(n => n.Field<decimal>("jcsb")),
                            fzqcqf = m.Sum(n => n.Field<decimal>("fzqcqf")),
                            fzzyjc = m.Sum(n => n.Field<decimal>("fzzyjc")),
                            fzbrbq = m.Sum(n => n.Field<decimal>("fzbrbq")),
                            fzgczl = m.Sum(n => n.Field<decimal>("fzgczl")),
                            zhd = m.Sum(n => n.Field<decimal>("zhd"))
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
                            hp = m.Sum(n => n.Field<decimal>("hp")),
                            bt = m.Sum(n => n.Field<decimal>("bt")),
                            xp = m.Sum(n => n.Field<decimal>("xp")),
                            nsl = m.Sum(n => n.Field<decimal>("nsl")),
                            dmcj = m.Sum(n => n.Field<decimal>("dmcj")),
                            dlf = m.Sum(n => n.Field<decimal>("dlf")),
                            dmtx = m.Sum(n => n.Field<decimal>("dmtx")),
                            yhd = m.Sum(n => n.Field<decimal>("yhd")),
                            yhdhp = m.Sum(n => n.Field<decimal>("yhdhp")),
                            yhdbt = m.Sum(n => n.Field<decimal>("yhdbt")),
                            yhdnsl = m.Sum(n => n.Field<decimal>("yhdnsl")),
                            yhdxp = m.Sum(n => n.Field<decimal>("yhdxp")),
                            yhddmtx = m.Sum(n => n.Field<decimal>("yhddmtx")),
                            yhddlf = m.Sum(n => n.Field<decimal>("yhddlf")),
                            yhddmcj = m.Sum(n => n.Field<decimal>("yhddmcj")),
                            zqxx = m.Sum(n => n.Field<decimal>("zqxx")),
                            zqzx = m.Sum(n => n.Field<decimal>("zqzx")),
                            zqdx = m.Sum(n => n.Field<decimal>("zqdx")),
                            zqtdx = m.Sum(n => n.Field<decimal>("zqtdx")),
                            xqxx = m.Sum(n => n.Field<decimal>("xqxx")),
                            xqzx = m.Sum(n => n.Field<decimal>("xqzx")),
                            xqdx = m.Sum(n => n.Field<decimal>("xqdx")),
                            xqtdx = m.Sum(n => n.Field<decimal>("xqtdx")),
                            hhfw = m.Sum(n => n.Field<decimal>("hhfw")),
                            hl = m.Sum(n => n.Field<decimal>("hl")),
                            hq = m.Sum(n => n.Field<decimal>("hq")),
                            wxcc = m.Sum(n => n.Field<decimal?>("wxcc")),
                            wxrk = m.Sum(n => n.Field<decimal?>("wxrk")),
                            mqwd = m.Sum(n => n.Field<decimal>("mqwd")),
                            mqqzbwd = m.Sum(n => n.Field<decimal>("mqqzbwd")),
                            mqbwd = m.Sum(n => n.Field<decimal>("mqbwd")),
                            jhwd = m.Sum(n => n.Field<decimal>("jhwd")),
                            jhqzbwd = m.Sum(n => n.Field<decimal>("jhqzbwd")),
                            jhbwd = m.Sum(n => n.Field<decimal>("jhbwd")),
                            jcms = m.Sum(n => n.Field<decimal>("jcms")),
                            jcss = m.Sum(n => n.Field<decimal>("jcss")),
                            jcdm = m.Sum(n => n.Field<decimal>("jcdm")),
                            jcsb = m.Sum(n => n.Field<decimal>("jcsb")),
                            fzqcqf = m.Sum(n => n.Field<decimal>("fzqcqf")),
                            fzzyjc = m.Sum(n => n.Field<decimal>("fzzyjc")),
                            fzbrbq = m.Sum(n => n.Field<decimal>("fzbrbq")),
                            fzgczl = m.Sum(n => n.Field<decimal>("fzgczl")),
                            zhd = m.Sum(n => n.Field<decimal>("zhd"))
                        };
            return DataHelper.ListToDataTable(query.ToList());
        }

        public string TJSql(string value)
        {
            var sql = string.Empty;
            if (value == "0")
            {
                #region 统计语句

                sql = @"select k.zhd,j.*  from ( select {1},
           sum(case
                 when t.DISASTERLEVEL = 'D' then
                  1
                 else
                  0
               end) as zqxx,
           sum(case
                 when t.DISASTERLEVEL = 'C' then
                  1
                 else
                  0
               end) as zqzx,
           sum(case
                 when t.DISASTERLEVEL = 'B' then
                  1
                 else
                  0
               end) as zqdx,
           sum(case
                 when t.DISASTERLEVEL = 'A' then
                  1
                 else
                  0
               end) as zqtdx,
           sum(case
                 when t.DANGERLEVEL = 'D' then
                  1
                 else
                  0
               end) as xqxx,
           sum(case
                 when t.DANGERLEVEL = 'C' then
                  1
                 else
                  0
               end) as xqzx,
           sum(case
                 when t.DANGERLEVEL = 'B' then
                  1
                 else
                  0
               end) as xqdx,
           sum(case
                 when t.DANGERLEVEL = 'A' then
                  1
                 else
                  0
               end) as xqtdx,
           sum(case
                 when  t.HIDDENDANGER = '1' or t.disastertype like '%隐患%'  then
                  1
                 else
                  0
               end) as yhd,
           sum(case
                 when  t.disastertype LIKE '滑坡%' and  t.HIDDENDANGER = '1'  then
                  1
                 else
                  0
               end) as yhdhp,
           sum(case
                 when t.disastertype LIKE '崩塌%' and  t.HIDDENDANGER = '1'  then
                  1
                 else
                  0
               end) as yhdbt,
           sum(case
                 when t.disastertype = '斜坡' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhdxp,
           sum(case
                 when t.disastertype = '泥石流' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhdnsl,
           sum(case
                 when t.disastertype = '地面沉降' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhddmcj,
           sum(case
                 when t.disastertype = '地裂缝' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhddlf,
           sum(case
                 when t.disastertype = '地面塌陷' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhddmtx,         
           sum(case
                 when t.disastertype LIKE '滑坡%' then
                  1
                 else
                  0
               end) as hp,                         
           sum(case
                 when t.disastertype LIKE '崩塌%' then
                  1
                 else
                  0
               end) as bt,
           sum(case
                 when t.disastertype = '斜坡' then
                  1
                 else
                  0
               end) as xp,
           sum(case
                 when t.disastertype = '泥石流' then
                  1
                 else
                  0
               end) as nsl,
           sum(case
                 when t.disastertype = '地面沉降' then
                  1
                 else
                  0
               end) as dmcj,
           sum(case
                 when t.disastertype = '地裂缝' then
                  1
                 else
                  0
               end) as dlf,
           sum(case
                 when t.disastertype = '地面塌陷' then
                  1
                 else
                  0
               end) as dmtx,
           sum(case
                 when t.CURSTABLESTATUS = 'A' then
                  1
                 else
                  0
               end) as mqwd,
           sum(case
                 when t.CURSTABLESTATUS = 'B' then
                  1
                 else
                  0
               end) as mqqzbwd,
           sum(case
                 when t.CURSTABLESTATUS = 'C' then
                  1
                 else
                  0
               end) as mqbwd,
           sum(case
                 when t.STABLETREND = 'A' then
                  1
                 else
                  0
               end) as jhwd,
           sum(case
                 when t.STABLETREND = 'B' then
                  1
                 else
                  0
               end) as jhqzbwd,
           sum(case
                 when t.STABLETREND = 'C' then
                  1
                 else
                  0
               end) as jhbwd,
           sum(case
                 when t.DESTROYEDHOME is null then
                  0
                 else
                  t.DESTROYEDHOME
               end) as hhfw,
           sum(case
                 when t.DESTROYEDROAD is null then
                  0
                 else
                  t.DESTROYEDROAD
               end) as hl,
           sum(case
                 when t.DESTROYEDCANAL is null then
                  0
                 else
                 t.DESTROYEDCANAL
               end) as hq,
           sum(t.THREATENPEOPLE) as wxrk,
           sum(t.THREATENASSETS) as wxcc,
           sum(case
                 when t.MONITORSUGGESTION = 'A' then
                  1
                 else
                  0
               end) as jcms,
           sum(case
                 when t.MONITORSUGGESTION = 'B' then
                  1
                 else
                  0
               end) as jcss,
           sum(case
                 when t.MONITORSUGGESTION = 'C' then
                  1
                 else
                  0
               end) as jcdm,
           sum(case
                 when t.MONITORSUGGESTION = 'D' then
                  1
                 else
                  0
               end) as jcsb,
           sum(case
                 when t.TREATMENTSUGGESTION = 'A' then
                  1
                 else
                  0
               end) as fzqcqf,
           sum(case
                 when t.TREATMENTSUGGESTION = 'B' then
                  1
                 else
                  0
               end) as fzzyjc,
           sum(case
                 when t.TREATMENTSUGGESTION = 'C' then
                  1
                 else
                  0
               end) as fzbrbq,
           sum(case
                 when t.TREATMENTSUGGESTION = 'D' then
                  1
                 else
                  0
               end) as fzgczl
      from tbl_hazardbasicinfo t where 1=1  and PROVINCENAME is not null  and CITY is not null  {0}
     group by {1} order by {2} ) j left join  (select {4},sum(case
                 when i.unifiedcode is null then
                  0
                 else
                  1
               end) as zhd     from tbl_hazardbasicinfo i where 1=1 and PROVINCENAME is not null  and CITY is not null    {3}
     group by {4} order by {5}) k   on {6}={7} ";

                #endregion
            }
            else if (value == "1")
            {
                #region 统计语句

                sql = @"select k.zhd,j.*  from ( select {1},
           sum(case
                 when t.DISASTERLEVEL = 'A' then
                  1
                 else
                  0
               end) as zqxx,
           sum(case
                 when t.DISASTERLEVEL = 'B' then
                  1
                 else
                  0
               end) as zqzx,
           sum(case
                 when t.DISASTERLEVEL = 'C' then
                  1
                 else
                  0
               end) as zqdx,
           sum(case
                 when t.DISASTERLEVEL = 'D' then
                  1
                 else
                  0
               end) as zqtdx,
           sum(case
                 when t.DANGERLEVEL = 'A' then
                  1
                 else
                  0
               end) as xqxx,
           sum(case
                 when t.DANGERLEVEL = 'B' then
                  1
                 else
                  0
               end) as xqzx,
           sum(case
                 when t.DANGERLEVEL = 'C' then
                  1
                 else
                  0
               end) as xqdx,
           sum(case
                 when t.DANGERLEVEL = 'D' then
                  1
                 else
                  0
               end) as xqtdx,
           sum(case
                 when t.HIDDENDANGER = '1' or t.disastertype like '%隐患%' then
                  1
                 else
                  0
               end) as yhd,


sum(case
                 when  t.disastertype = '滑坡' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhdhp ,sum(case
                 when t.disastertype = '滑坡隐患点'  then
                  1
                 else
                  0
               end) as yhdhpyhd,
           sum(case
                 when t.disastertype = '崩塌' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhdbt, sum(case
                 when t.disastertype = '崩塌隐患点'  then
                  1
                 else
                  0
               end) as byhdtyhd,
           sum(case
                 when t.disastertype = '斜坡' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhdxp,
           sum(case
                 when t.disastertype = '泥石流' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhdnsl,
           sum(case
                 when t.disastertype = '地面沉降' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhddmcj,
           sum(case
                 when t.disastertype = '地裂缝' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhddlf,
           sum(case
                 when t.disastertype = '地面塌陷' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhddmtx,
           sum(case
                 when t.disastertype = '遥感解译点' then
                  1
                 else
                  0
               end) as yhdygyhd,

           sum(case
                 when t.disastertype = '滑坡' then
                  1
                 else
                  0
               end) as hp,
           sum(case
                 when t.disastertype = '滑坡隐患点'  then
                  1
                 else
                  0
               end) as hpyhd,
            sum(case
                 when t.disastertype = '崩塌隐患点'  then
                  1
                 else
                  0
               end) as btyhd,
            sum(case
                 when t.disastertype = '遥感解译点'  then
                  1
                 else
                  0
               end) as ygyhd,
           sum(case
                 when t.disastertype = '崩塌' then
                  1
                 else
                  0
               end) as bt,
           sum(case
                 when t.disastertype = '斜坡' then
                  1
                 else
                  0
               end) as xp,
           sum(case
                 when t.disastertype = '泥石流' then
                  1
                 else
                  0
               end) as nsl,
           sum(case
                 when t.disastertype = '地面沉降' then
                  1
                 else
                  0
               end) as dmcj,
           sum(case
                 when t.disastertype = '地裂缝' then
                  1
                 else
                  0
               end) as dlf,
           sum(case
                 when t.disastertype = '地面塌陷' then
                  1
                 else
                  0
               end) as dmtx,
           sum(case
                 when t.CURSTABLESTATUS = 'A' then
                  1
                 else
                  0
               end) as mqwd,
           sum(case
                 when t.CURSTABLESTATUS = 'B' then
                  1
                 else
                  0
               end) as mqqzbwd,
           sum(case
                 when t.CURSTABLESTATUS = 'C' then
                  1
                 else
                  0
               end) as mqbwd,
           sum(case
                 when t.STABLETREND = 'A' then
                  1
                 else
                  0
               end) as jhwd,
           sum(case
                 when t.STABLETREND = 'B' then
                  1
                 else
                  0
               end) as jhqzbwd,
           sum(case
                 when t.STABLETREND = 'C' then
                  1
                 else
                  0
               end) as jhbwd,
           sum(case
                 when t.DESTROYEDHOME is null then
                  0
                 else
                  t.DESTROYEDHOME
               end) as hhfw,
           sum(case
                 when t.DESTROYEDROAD is null then
                  0
                 else
                  t.DESTROYEDROAD
               end) as hl,
           sum(case
                 when t.DESTROYEDCANAL is null then
                  0
                 else
                 t.DESTROYEDCANAL
               end) as hq,
           sum(t.THREATENPEOPLE) as wxrk,
           sum(t.THREATENASSETS) as wxcc,
           sum(case
                 when t.MONITORSUGGESTION = 'A' then
                  1
                 else
                  0
               end) as jcms,
           sum(case
                 when t.MONITORSUGGESTION = 'B' then
                  1
                 else
                  0
               end) as jcss,
           sum(case
                 when t.MONITORSUGGESTION = 'C' then
                  1
                 else
                  0
               end) as jcdm,
           sum(case
                 when t.MONITORSUGGESTION = 'D' then
                  1
                 else
                  0
               end) as jcsb,
           sum(case
                 when t.TREATMENTSUGGESTION = 'A' then
                  1
                 else
                  0
               end) as fzqcqf,
           sum(case
                 when t.TREATMENTSUGGESTION = 'B' then
                  1
                 else
                  0
               end) as fzzyjc,
           sum(case
                 when t.TREATMENTSUGGESTION = 'C' then
                  1
                 else
                  0
               end) as fzbrbq,
           sum(case
                 when t.TREATMENTSUGGESTION = 'D' then
                  1
                 else
                  0
               end) as fzgczl
      from tbl_hazardbasicinfo t where 1=1 and PROVINCENAME is not null   {0}
     group by {1} order by {2} ) j left join  (select {4},sum(case
                 when i.unifiedcode is null then
                  0
                 else
                  1
               end) as zhd     from tbl_hazardbasicinfo i where 1=1   {3}
     group by {4} order by {5}) k   on {6}={7} ";

                #endregion
            }
            return sql;

        }
        public DataTable GetZhdAndCityName()
        {
            string strsql = "select cityname,count(1) as zhd from TBL_HAZARDBASICINFO group by cityname having cityname is not null";
            return this.BaseRepository().FindTable(strsql);
        }
        public DataTable GetZhdAndProvinceName()
        {
            string strsql = "select provincename,count(1) as zhd from TBL_HAZARDBASICINFO group by provincename having provincename is not null";
            return this.BaseRepository().FindTable(strsql);
        }
        /// <summary>
        /// 灾害点统计（按市县、灾害点总数|灾害点类型|灾情等级|险情等级 统计）
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetHazardStatisticsJson(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return null;
            string strSelect = string.Empty, strWhere = string.Empty, strGroup = string.Empty, strOrder = string.Empty;
            string strType = string.Empty, strCase = string.Empty;
            GetWhere(ref strWhere, ref strGroup, ref strOrder, ref strSelect);
            String sqlBase = @"select {0},{1} from (
                    select PROVINCE,CITY,COUNTY,PROVINCENAME 省,CITYNAME 市,COUNTYNAME 县, {2} from tbl_hazardbasicinfo where 1=1 {3} 
                ) hazard where 省 is not null and 市 is not null  group by {4} order by {5}";


            switch (type)
            {
                case "DISASTER":
                    strType = "sum(hazard.灾害点总数) 灾害点总数 ";
                    strCase = "CASE WHEN 1=1 THEN 1 ELSE 0 END 灾害点总数";
                    break;
                case "DISASTERTYPE":
                    IEnumerable<DataItemDetailEntity> ls = serviceDataItem.GetItemDetailList("HazardType");
                    foreach (var v in ls)
                    {
                        strType += "sum(hazard." + v.F_ItemName + ") " + v.F_ItemName + ",";
                        strCase += "CASE WHEN " + type + " = '" + v.F_ItemName + "' THEN  1  ELSE  0  END " + v.F_ItemName + ",";
                    }
                    break;
                case "DISASTERLEVEL":
                    IEnumerable<DataItemDetailEntity> ls2 = serviceDataItem.GetItemDetailList("DISASTERLEVEL");
                    foreach (var v in ls2)
                    {
                        strType += "sum(hazard." + v.F_ItemName + ") " + v.F_ItemName + ",";
                        strCase += "CASE WHEN " + type + " = '" + v.F_ItemValue + "' THEN  1  ELSE  0  END " + v.F_ItemName + ",";
                    }
                    break;
                case "DANGERLEVEL":
                    IEnumerable<DataItemDetailEntity> ls3 = serviceDataItem.GetItemDetailList("DANGERLEVEL");
                    foreach (var v in ls3)
                    {
                        strType += "sum(hazard." + v.F_ItemName + ") " + v.F_ItemName + ",";
                        strCase += "CASE WHEN " + type + " = '" + v.F_ItemValue + "' THEN  1  ELSE  0  END " + v.F_ItemName + ",";
                    }
                    break;
            }
            strType = strType.TrimEnd(',');
            strCase = strCase.TrimEnd(',');
            string sql = string.Format(sqlBase, strSelect, strType, strCase, strWhere, strGroup, strOrder);
            return this.BaseRepository().FindTable(sql);
        }

        private void GetWhere(ref string strWhere, ref string groupBy, ref string orderBy, ref string strSelect)
        {
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<string> _codes2 = _codes.Where(p => p.Contains("00")).ToList();
            if (_codes2.Count > 1)
            {
                strWhere = " and city in('" + string.Join("','", _codes2.ToArray()) + "') ";//省级用户
                groupBy = " 市 ";
                strSelect = " 市 ";
                orderBy = " 市 ";
            }
            else if (_codes2.Count == 1)
            {
                if (_codes2[0] != "000000" && !_codes2[0].Equals("0"))
                {
                    strWhere = "  and county in('" + string.Join("','", _codes.ToArray()) + "') ";//市级用户
                    groupBy = " 县 ";
                    strSelect = " 县 ";
                    orderBy = " 县 ";
                }
                else if (_codes2[0] == "000000")
                {
                    strWhere = "  ";//全国用户
                    groupBy = " 省 ";
                    strSelect = " 省 ";
                    orderBy = " 省 ";
                }
                else
                {
                    strWhere = "";//省级用户
                    groupBy = " 市 ";
                    strSelect = " 市 ";
                    orderBy = " 市 ";
                }
            }
            else
            {
                strWhere = "  and county in('" + string.Join("','", _codes.ToArray()) + "') ";//区级用户
                groupBy = " 县 ";
                strSelect = " 县 ";
                orderBy = "  县 ";
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

        /// <summary>
        /// 拷贝表格行到新的一行
        /// </summary>
        /// <param name="table"></param>
        /// <param name="row"></param>
        /// <param name="lstIgnore"></param>
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

        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetValue()
        {
            var expression = LinqExtensions.True<TBL_HAZARDBASICINFOEntity>();
            return this.BaseRepository().FindList(expression).Where(t => !string.IsNullOrWhiteSpace(t.OLDUNIFIEDCODE)).ToList();
        }

        /// <summary>
        /// 关于地质灾害查询浏览的导出Datatable
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetDataTableList(string queryJson)
        {
            var data = this.BaseRepository().FindList(queryJsonExpression(queryJson));
            DataTable result = new DataTable();
            result.Columns.Add("灾害点编号");
            result.Columns.Add("灾害点名称");
            result.Columns.Add("灾害点类型");
            result.Columns.Add("经度");
            result.Columns.Add("纬度");
            result.Columns.Add("地理位置");
            result.Columns.Add("灾情等级");
            result.Columns.Add("险情等级");
            result.Columns.Add("目前稳定程度");
            result.Columns.Add("今后变化趋势");
            result.Columns.Add("威胁人口");
            result.Columns.Add("威胁财产");
            result.Columns.Add("死亡人口");
            result.Columns.Add("财产损失");
            result.Columns.Add("防治建议");
            result.Columns.Add("隐患点");
            result.Columns.Add("监测建议");
            result.Columns.Add("修改日期");
            result.Columns.Add("省");
            result.Columns.Add("市");
            result.Columns.Add("县");
            foreach (var item in data)
            {
                DataRow result_dr = result.NewRow();
                result_dr["灾害点编号"] = item.UNIFIEDCODE;
                result_dr["灾害点名称"] = item.DISASTERNAME;
                result_dr["灾害点类型"] = item.DISASTERTYPE;
                result_dr["经度"] = item.LONGITUDE;
                result_dr["纬度"] = item.LATITUDE;
                switch (item.DISASTERLEVEL)
                {
                    case "A":
                        result_dr["灾情等级"] = "特大型";
                        break;
                    case "B":
                        result_dr["灾情等级"] = "大型";
                        break;
                    case "C":
                        result_dr["灾情等级"] = "中型";
                        break;
                    case "D":
                        result_dr["灾情等级"] = "小型";
                        break;
                    default:
                        result_dr["灾情等级"] = "";
                        break;
                }
                switch (item.DANGERLEVEL)
                {
                    case "A":
                        result_dr["险情等级"] = "特大型";
                        break;
                    case "B":
                        result_dr["险情等级"] = "大型";
                        break;
                    case "C":
                        result_dr["险情等级"] = "中型";
                        break;
                    case "D":
                        result_dr["险情等级"] = "小型";
                        break;
                    default:
                        result_dr["险情等级"] = "";
                        break;
                }
                switch (item.CURSTABLESTATUS)
                {
                    case "A":
                        result_dr["目前稳定程度"] = "稳定";
                        break;
                    case "B":
                        result_dr["目前稳定程度"] = "基本稳定";
                        break;
                    case "C":
                        result_dr["目前稳定程度"] = "潜在不稳定";
                        break;
                    case "D":
                        result_dr["目前稳定程度"] = "不稳定";
                        break;
                    default:
                        result_dr["目前稳定程度"] = "";
                        break;
                }
                switch (item.STABLETREND)
                {
                    case "A":
                        result_dr["今后变化趋势"] = "稳定";
                        break;
                    case "B":
                        result_dr["今后变化趋势"] = "基本稳定";
                        break;
                    case "C":
                        result_dr["今后变化趋势"] = "潜在不稳定";
                        break;
                    case "D":
                        result_dr["今后变化趋势"] = "不稳定";
                        break;
                    default:
                        result_dr["今后变化趋势"] = "";
                        break;
                }
                result_dr["威胁人口"] = item.THREATENPEOPLE;
                result_dr["威胁财产"] = item.THREATENASSETS;
                result_dr["死亡人口"] = item.DEATHTOLL;
                result_dr["财产损失"] = item.ASSETSLOSE;
                result_dr["防治建议"] = item.TREATMENTSUGGESTION;
                switch (item.HIDDENDANGER)
                {
                    case "1":
                        result_dr["隐患点"] = "是";
                        break;
                    case "0":
                        result_dr["隐患点"] = "否";
                        break;
                    default:
                        result_dr["隐患点"] = "";
                        break;
                }
                result_dr["监测建议"] = item.MONITORSUGGESTION;
                result_dr["修改日期"] = item.MODIFYTIME;
                result_dr["省"] = item.PROVINCENAME;
                result_dr["市"] = item.CITYNAME;
                result_dr["县"] = item.COUNTYNAME;
                result.Rows.Add(result_dr);
            }
            return result;
        }

        /// <summary>
        /// 灾害点统计导出Datatable
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        /// <summary>
        /// 灾害点统计导出Datatable
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetDataCountTableList(string queryJson, string colum)
        {

            DataTable CountDt = GetAnalyseList(queryJson);
            DataTable result = new DataTable();
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            if (json.level == "省")
            {
                result.Columns.Add("省");
            }
            if (json.level == "市")
            {
                result.Columns.Add("省");
                result.Columns.Add("市");
            }
            if (json.level == "县")
            {
                result.Columns.Add("省");
                result.Columns.Add("市");
                result.Columns.Add("县");
            }
            if (json.level == "乡镇")
            {
                result.Columns.Add("省");
                result.Columns.Add("市");
                result.Columns.Add("县");
                result.Columns.Add("乡镇");
            }
            if (colum.Contains("zhd"))
                result.Columns.Add("灾害点");
            if (colum.Contains("yhd"))
                result.Columns.Add("隐患点");
            if (colum.Contains("hp"))
                result.Columns.Add("滑坡");
            if (colum.Contains("bt"))
                result.Columns.Add("崩塌");
            if (colum.Contains("xp"))
                result.Columns.Add("斜坡");
            if (colum.Contains("nsl"))
                result.Columns.Add("泥石流");
            if (colum.Contains("dmcj"))
                result.Columns.Add("地面沉降");
            if (colum.Contains("dlf"))
                result.Columns.Add("地裂缝");
            if (colum.Contains("dmtx"))
                result.Columns.Add("地面塌陷");
            //if (colum.Contains("hpyh"))
            //    result.Columns.Add("滑坡隐患");
            //if (colum.Contains("btyh"))
            //    result.Columns.Add("崩塌隐患");
            if (colum.Contains("zqxx"))
                result.Columns.Add("灾情-小型");
            if (colum.Contains("zqzx"))
                result.Columns.Add("灾情-中型");
            if (colum.Contains("zqdx"))
                result.Columns.Add("灾情-大型");
            if (colum.Contains("zqtdx"))
                result.Columns.Add("灾情-特大型");
            if (colum.Contains("xqxx"))
                result.Columns.Add("险情-小型");
            if (colum.Contains("xqzx"))
                result.Columns.Add("险情-中型");
            if (colum.Contains("xqdx"))
                result.Columns.Add("险情-大型");
            if (colum.Contains("xqtdx"))
                result.Columns.Add("险情-特大型");
            if (colum.Contains("mqwd"))
                result.Columns.Add("目前稳定程度-稳定");
            if (colum.Contains("mqqzbwd"))
                result.Columns.Add("目前稳定程度-基本稳定");
            if (colum.Contains("mqbwd"))
                result.Columns.Add("目前稳定程度-不稳定");
            if (colum.Contains("jhwd"))
                result.Columns.Add("今后变化趋势-稳定");
            if (colum.Contains("jhqzbwd"))
                result.Columns.Add("今后变化趋势-基本稳定");
            if (colum.Contains("jhbwd"))
                result.Columns.Add("今后变化趋势-不稳定");
            if (colum.Contains("hhfw"))
                result.Columns.Add("损坏房屋");
            if (colum.Contains("hl"))
                result.Columns.Add("毁路");
            if (colum.Contains("hq"))
                result.Columns.Add("毁渠");
            if (colum.Contains("wxcc"))
                result.Columns.Add("威胁财产");
            if (colum.Contains("wxrk"))
                result.Columns.Add("威胁人口");
            for (int i = 0; i < CountDt.Rows.Count; i++)
            {
                DataRow result_dr = result.NewRow();
                if (json.level == "省")
                {
                    result_dr["省"] = CountDt.Rows[i]["provincename"].ToString();
                }
                if (json.level == "市")
                {
                    result_dr["省"] = CountDt.Rows[i]["provincename"].ToString();
                    result_dr["市"] = CountDt.Rows[i]["cityname"].ToString();
                }
                if (json.level == "县")
                {
                    result_dr["省"] = CountDt.Rows[i]["provincename"].ToString();
                    result_dr["市"] = CountDt.Rows[i]["cityname"].ToString();
                    result_dr["县"] = CountDt.Rows[i]["countyname"].ToString();
                }
                if (json.level == "乡镇")
                {
                    result_dr["省"] = CountDt.Rows[i]["provincename"].ToString();
                    result_dr["市"] = CountDt.Rows[i]["cityname"].ToString();
                    result_dr["县"] = CountDt.Rows[i]["countyname"].ToString();
                    result_dr["乡镇"] = CountDt.Rows[i]["townname"].ToString();
                }
                if (result.Columns.Contains("灾害点"))
                    result_dr["灾害点"] = CountDt.Rows[i]["zhd"].ToString();
                if (result.Columns.Contains("隐患点"))
                    result_dr["隐患点"] = CountDt.Rows[i]["yhd"].ToString();
                if (result.Columns.Contains("滑坡"))
                    result_dr["滑坡"] = CountDt.Rows[i]["hp"].ToString();
                if (result.Columns.Contains("崩塌"))
                    result_dr["崩塌"] = CountDt.Rows[i]["bt"].ToString();
                if (result.Columns.Contains("斜坡"))
                    result_dr["斜坡"] = CountDt.Rows[i]["xp"].ToString();
                if (result.Columns.Contains("泥石流"))
                    result_dr["泥石流"] = CountDt.Rows[i]["nsl"].ToString();
                if (result.Columns.Contains("地面沉降"))
                    result_dr["地面沉降"] = CountDt.Rows[i]["dmcj"].ToString();
                if (result.Columns.Contains("地裂缝"))
                    result_dr["地裂缝"] = CountDt.Rows[i]["dlf"].ToString();
                if (result.Columns.Contains("地面塌陷"))
                    result_dr["地面塌陷"] = CountDt.Rows[i]["dmtx"].ToString();
                //if (result.Columns.Contains("滑坡隐患"))
                //    result_dr["滑坡隐患"] = CountDt.Rows[i]["hpyh"].ToString();
                //if (result.Columns.Contains("崩塌隐患"))
                //    result_dr["崩塌隐患"] = CountDt.Rows[i]["btyh"].ToString();
                if (result.Columns.Contains("灾情-小型"))
                    result_dr["灾情-小型"] = CountDt.Rows[i]["zqxx"].ToString();
                if (result.Columns.Contains("灾情-中型"))
                    result_dr["灾情-中型"] = CountDt.Rows[i]["zqzx"].ToString();
                if (result.Columns.Contains("灾情-大型"))
                    result_dr["灾情-大型"] = CountDt.Rows[i]["zqdx"].ToString();
                if (result.Columns.Contains("灾情-特大型"))
                    result_dr["灾情-特大型"] = CountDt.Rows[i]["zqtdx"].ToString();
                if (result.Columns.Contains("险情-小型"))
                    result_dr["险情-小型"] = CountDt.Rows[i]["xqxx"].ToString();
                if (result.Columns.Contains("险情-中型"))
                    result_dr["险情-中型"] = CountDt.Rows[i]["xqzx"].ToString();
                if (result.Columns.Contains("险情-大型"))
                    result_dr["险情-大型"] = CountDt.Rows[i]["xqdx"].ToString();
                if (result.Columns.Contains("险情-特大型"))
                    result_dr["险情-特大型"] = CountDt.Rows[i]["xqtdx"].ToString();
                if (result.Columns.Contains("目前稳定程度-稳定"))
                    result_dr["目前稳定程度-稳定"] = CountDt.Rows[i]["mqwd"].ToString();
                if (result.Columns.Contains("目前稳定程度-基本稳定"))
                    result_dr["目前稳定程度-基本稳定"] = CountDt.Rows[i]["mqqzbwd"].ToString();
                if (result.Columns.Contains("目前稳定程度-不稳定"))
                    result_dr["目前稳定程度-不稳定"] = CountDt.Rows[i]["mqbwd"].ToString();
                if (result.Columns.Contains("今后变化趋势-稳定"))
                    result_dr["今后变化趋势-稳定"] = CountDt.Rows[i]["jhwd"].ToString();
                if (result.Columns.Contains("今后变化趋势-基本稳定"))
                    result_dr["今后变化趋势-基本稳定"] = CountDt.Rows[i]["jhqzbwd"].ToString();
                if (result.Columns.Contains("今后变化趋势-不稳定"))
                    result_dr["今后变化趋势-不稳定"] = CountDt.Rows[i]["jhbwd"].ToString();
                if (result.Columns.Contains("损坏房屋"))
                    result_dr["损坏房屋"] = CountDt.Rows[i]["hhfw"].ToString();
                if (result.Columns.Contains("毁路"))
                    result_dr["毁路"] = CountDt.Rows[i]["hl"].ToString();
                if (result.Columns.Contains("毁渠"))
                    result_dr["毁渠"] = CountDt.Rows[i]["hq"].ToString();
                if (result.Columns.Contains("威胁财产"))
                    result_dr["威胁财产"] = CountDt.Rows[i]["wxcc"].ToString();
                if (result.Columns.Contains("威胁人口"))
                    result_dr["威胁人口"] = CountDt.Rows[i]["wxrk"].ToString();
                result.Rows.Add(result_dr);
            }
            return result;
        }

        public DataTable GetDataCountTableListPC(string queryJson, string colum)
        {

            DataTable CountDt = GetAnalyseListPC(queryJson);
            DataTable result = new DataTable();
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            if (json.level == "省")
            {
                result.Columns.Add("省");
            }
            if (json.level == "市")
            {
                result.Columns.Add("省");
                result.Columns.Add("市");
            }
            if (json.level == "县")
            {
                result.Columns.Add("省");
                result.Columns.Add("市");
                result.Columns.Add("县");
            }
            if (json.level == "乡镇")
            {
                result.Columns.Add("省");
                result.Columns.Add("市");
                result.Columns.Add("县");
                result.Columns.Add("乡镇");
            }
            if (colum.Contains("zhd"))
                result.Columns.Add("灾害点");
            if (colum.Contains("yhd"))
                result.Columns.Add("隐患点");
            if (colum.Contains("hp"))
                result.Columns.Add("滑坡");
            if (colum.Contains("bt"))
                result.Columns.Add("崩塌");
            if (colum.Contains("xp"))
                result.Columns.Add("斜坡");
            if (colum.Contains("nsl"))
                result.Columns.Add("泥石流");
            if (colum.Contains("dmcj"))
                result.Columns.Add("地面沉降");
            if (colum.Contains("dlf"))
                result.Columns.Add("地裂缝");
            if (colum.Contains("dmtx"))
                result.Columns.Add("地面塌陷");
            //if (colum.Contains("hpyh"))
            //    result.Columns.Add("滑坡隐患");
            //if (colum.Contains("btyh"))
            //    result.Columns.Add("崩塌隐患");
            if (colum.Contains("zqxx"))
                result.Columns.Add("灾情-小型");
            if (colum.Contains("zqzx"))
                result.Columns.Add("灾情-中型");
            if (colum.Contains("zqdx"))
                result.Columns.Add("灾情-大型");
            if (colum.Contains("zqtdx"))
                result.Columns.Add("灾情-特大型");
            if (colum.Contains("xqxx"))
                result.Columns.Add("险情-小型");
            if (colum.Contains("xqzx"))
                result.Columns.Add("险情-中型");
            if (colum.Contains("xqdx"))
                result.Columns.Add("险情-大型");
            if (colum.Contains("xqtdx"))
                result.Columns.Add("险情-特大型");
            if (colum.Contains("mqwd"))
                result.Columns.Add("目前稳定程度-稳定");
            if (colum.Contains("mqqzbwd"))
                result.Columns.Add("目前稳定程度-基本稳定");
            if (colum.Contains("mqbwd"))
                result.Columns.Add("目前稳定程度-不稳定");
            if (colum.Contains("jhwd"))
                result.Columns.Add("今后变化趋势-稳定");
            if (colum.Contains("jhqzbwd"))
                result.Columns.Add("今后变化趋势-基本稳定");
            if (colum.Contains("jhbwd"))
                result.Columns.Add("今后变化趋势-不稳定");
            if (colum.Contains("hhfw"))
                result.Columns.Add("损坏房屋");
            if (colum.Contains("hl"))
                result.Columns.Add("毁路");
            if (colum.Contains("hq"))
                result.Columns.Add("毁渠");
            if (colum.Contains("wxcc"))
                result.Columns.Add("威胁财产");
            if (colum.Contains("wxrk"))
                result.Columns.Add("威胁人口");
            for (int i = 0; i < CountDt.Rows.Count; i++)
            {
                DataRow result_dr = result.NewRow();
                if (json.level == "省")
                {
                    result_dr["省"] = CountDt.Rows[i]["provincename"].ToString();
                }
                if (json.level == "市")
                {
                    result_dr["省"] = CountDt.Rows[i]["provincename"].ToString();
                    result_dr["市"] = CountDt.Rows[i]["cityname"].ToString();
                }
                if (json.level == "县")
                {
                    result_dr["省"] = CountDt.Rows[i]["provincename"].ToString();
                    result_dr["市"] = CountDt.Rows[i]["cityname"].ToString();
                    result_dr["县"] = CountDt.Rows[i]["countyname"].ToString();
                }
                if (json.level == "乡镇")
                {
                    result_dr["省"] = CountDt.Rows[i]["provincename"].ToString();
                    result_dr["市"] = CountDt.Rows[i]["cityname"].ToString();
                    result_dr["县"] = CountDt.Rows[i]["countyname"].ToString();
                    result_dr["乡镇"] = CountDt.Rows[i]["townname"].ToString();
                }
                if (result.Columns.Contains("灾害点"))
                    result_dr["灾害点"] = CountDt.Rows[i]["zhd"].ToString();
                if (result.Columns.Contains("隐患点"))
                    result_dr["隐患点"] = CountDt.Rows[i]["yhd"].ToString();
                if (result.Columns.Contains("滑坡"))
                    result_dr["滑坡"] = CountDt.Rows[i]["hp"].ToString();
                if (result.Columns.Contains("崩塌"))
                    result_dr["崩塌"] = CountDt.Rows[i]["bt"].ToString();
                if (result.Columns.Contains("斜坡"))
                    result_dr["斜坡"] = CountDt.Rows[i]["xp"].ToString();
                if (result.Columns.Contains("泥石流"))
                    result_dr["泥石流"] = CountDt.Rows[i]["nsl"].ToString();
                if (result.Columns.Contains("地面沉降"))
                    result_dr["地面沉降"] = CountDt.Rows[i]["dmcj"].ToString();
                if (result.Columns.Contains("地裂缝"))
                    result_dr["地裂缝"] = CountDt.Rows[i]["dlf"].ToString();
                if (result.Columns.Contains("地面塌陷"))
                    result_dr["地面塌陷"] = CountDt.Rows[i]["dmtx"].ToString();
                //if (result.Columns.Contains("滑坡隐患"))
                //    result_dr["滑坡隐患"] = CountDt.Rows[i]["hpyh"].ToString();
                //if (result.Columns.Contains("崩塌隐患"))
                //    result_dr["崩塌隐患"] = CountDt.Rows[i]["btyh"].ToString();
                if (result.Columns.Contains("灾情-小型"))
                    result_dr["灾情-小型"] = CountDt.Rows[i]["zqxx"].ToString();
                if (result.Columns.Contains("灾情-中型"))
                    result_dr["灾情-中型"] = CountDt.Rows[i]["zqzx"].ToString();
                if (result.Columns.Contains("灾情-大型"))
                    result_dr["灾情-大型"] = CountDt.Rows[i]["zqdx"].ToString();
                if (result.Columns.Contains("灾情-特大型"))
                    result_dr["灾情-特大型"] = CountDt.Rows[i]["zqtdx"].ToString();
                if (result.Columns.Contains("险情-小型"))
                    result_dr["险情-小型"] = CountDt.Rows[i]["xqxx"].ToString();
                if (result.Columns.Contains("险情-中型"))
                    result_dr["险情-中型"] = CountDt.Rows[i]["xqzx"].ToString();
                if (result.Columns.Contains("险情-大型"))
                    result_dr["险情-大型"] = CountDt.Rows[i]["xqdx"].ToString();
                if (result.Columns.Contains("险情-特大型"))
                    result_dr["险情-特大型"] = CountDt.Rows[i]["xqtdx"].ToString();
                if (result.Columns.Contains("目前稳定程度-稳定"))
                    result_dr["目前稳定程度-稳定"] = CountDt.Rows[i]["mqwd"].ToString();
                if (result.Columns.Contains("目前稳定程度-基本稳定"))
                    result_dr["目前稳定程度-基本稳定"] = CountDt.Rows[i]["mqqzbwd"].ToString();
                if (result.Columns.Contains("目前稳定程度-不稳定"))
                    result_dr["目前稳定程度-不稳定"] = CountDt.Rows[i]["mqbwd"].ToString();
                if (result.Columns.Contains("今后变化趋势-稳定"))
                    result_dr["今后变化趋势-稳定"] = CountDt.Rows[i]["jhwd"].ToString();
                if (result.Columns.Contains("今后变化趋势-基本稳定"))
                    result_dr["今后变化趋势-基本稳定"] = CountDt.Rows[i]["jhqzbwd"].ToString();
                if (result.Columns.Contains("今后变化趋势-不稳定"))
                    result_dr["今后变化趋势-不稳定"] = CountDt.Rows[i]["jhbwd"].ToString();
                if (result.Columns.Contains("损坏房屋"))
                    result_dr["损坏房屋"] = CountDt.Rows[i]["hhfw"].ToString();
                if (result.Columns.Contains("毁路"))
                    result_dr["毁路"] = CountDt.Rows[i]["hl"].ToString();
                if (result.Columns.Contains("毁渠"))
                    result_dr["毁渠"] = CountDt.Rows[i]["hq"].ToString();
                if (result.Columns.Contains("威胁财产"))
                    result_dr["威胁财产"] = CountDt.Rows[i]["wxcc"].ToString();
                if (result.Columns.Contains("威胁人口"))
                    result_dr["威胁人口"] = CountDt.Rows[i]["wxrk"].ToString();
                result.Rows.Add(result_dr);
            }
            return result;
        }

        /// <summary>
        /// 统计地灾排查数据
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetAnalyseListPC(string queryJson)
        {
            var sqlTemp = PCTJSql("0");  //0:不包含滑坡、崩塌隐患、遥感解译   1：包含

            dynamic json = JToken.Parse(queryJson) as dynamic;

            //筛选条件
            string sqlWhere = json.sqlWhere;
            string sqlwherezhd = json.sqlWhere;
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere = " and " + sqlWhere;
            }
            //string query = "{PROJECTTYPE:'排查'}";
            //List<string> projectids = project.GetProjectIDList(query);
            //if (projectids.Count > 0)
            //{
            //    sqlWhere += " and t.projectid in('" + string.Join("','", projectids.ToArray()) + "') ";
            //    sqlwherezhd = " and i.projectid in('" + string.Join("','", projectids.ToArray()) + "') ";
            //}
            string DISASTERTYPE = json.DISASTERTYPE;
            if (!string.IsNullOrEmpty(DISASTERTYPE))
            {
                //sqlWhere += string.Format(" and t.DISASTERTYPE like '%{0}%'", DISASTERTYPE);
                sqlWhere += string.Format(" and t.DISASTERTYPE in ('" + DISASTERTYPE + "')");
            }
            string DANGERLEVEL = json.DANGERLEVEL;
            if (!string.IsNullOrEmpty(DANGERLEVEL))
            {
                sqlWhere += string.Format(" and t.DANGERLEVEL in ('" + DANGERLEVEL + "')");
            }
            string DISASTERLEVEL = json.DISASTERLEVEL;
            if (!string.IsNullOrEmpty(DISASTERLEVEL))
            {
                sqlWhere += string.Format(" and t.DISASTERLEVEL in ('" + DISASTERLEVEL + "')");
            }
            //
            string HIDDENDANGER = json.HIDDENDANGER;
            if (!string.IsNullOrEmpty(HIDDENDANGER))
            {
                sqlWhere += string.Format(" and t.HIDDENDANGER like '%{0}%'", HIDDENDANGER);
            }
            string ISIMPORTANT = json.ISIMPORTANT;
            if (!string.IsNullOrEmpty(ISIMPORTANT))
            {
                sqlWhere += string.Format(" and t.ISIMPORTANT like '%{0}%'", ISIMPORTANT);
            }
            string STABLETREND = json.STABLETREND;
            if (!string.IsNullOrEmpty(STABLETREND))
            {
                sqlWhere += string.Format(" and t.STABLETREND in ('" + STABLETREND + "')");
            }
            string CURRENTSTABLESTATUS = json.CURRENTSTABLESTATUS;
            if (!string.IsNullOrEmpty(DANGERLEVEL))
            {
                sqlWhere += string.Format(" and t.CURSTABLESTATUS in ('" + CURRENTSTABLESTATUS + "')");
            }
            string THREATENPEOPLEBEGIN = json.THREATENPEOPLEBEGIN;
            if (!string.IsNullOrEmpty(THREATENPEOPLEBEGIN))
            {
                sqlWhere += string.Format(" and t.THREATENPEOPLE >= {0}", THREATENPEOPLEBEGIN);
            }
            string THREATENPEOPLEEND = json.THREATENPEOPLEEND;
            if (!string.IsNullOrEmpty(THREATENPEOPLEEND))
            {
                sqlWhere += string.Format(" and t.THREATENPEOPLE <= {0}", THREATENPEOPLEEND);
            }
            string ASSETSLOSEBEGIN = json.ASSETSLOSEBEGIN;
            if (!string.IsNullOrEmpty(ASSETSLOSEBEGIN))
            {
                sqlWhere += string.Format(" and t.THREATENASSETS >= {0}", ASSETSLOSEBEGIN);
            }
            string ASSETSLOSEEND = json.ASSETSLOSEEND;
            if (!string.IsNullOrEmpty(ASSETSLOSEEND))
            {
                sqlWhere += string.Format(" and t.THREATENASSETS <= {0}", ASSETSLOSEEND);
            }
            string DISAATERSIZE = json.DISAATERSIZE;
            if (!string.IsNullOrEmpty(DISAATERSIZE))
            {
                sqlWhere += string.Format(" and t.SCALELEVEL like '%{0}%'", DISAATERSIZE);
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
                        if (!string.IsNullOrEmpty(PROVINCE))
                        {
                            if (PROVINCE != "0" && PROVINCE != "000000")
                            {
                                sqlWhere += string.Format(" and t.PROVINCE in ({0})", Transcate(PROVINCE));
                                sqlwherezhd += string.Format(" and i.PROVINCE in ({0})", Transcate(PROVINCE));
                            }

                        }

                    }
                }
            }

            #endregion

            #region 筛选授权

            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            //筛选，获取授权的行政区划
            List<string> author = ws.GetAllAuthDistricts();
            if (author != null && author.Count > 0)
            {
                string sqlWhere1 = " and (";
                string sqlWhere2 = " and (";
                foreach (var au in author)
                {
                    //全国权限
                    if (au.EndsWith("000000") || au.Equals("0"))
                    {
                        sqlWhere1 = string.Empty;
                        sqlWhere2 = string.Empty;
                        break;
                    }
                    //省权限
                    else if (au.EndsWith("0000"))
                    {
                        sqlWhere1 += string.Format("t.PROVINCE = '{0}' or ", au);
                        sqlWhere2 += string.Format("i.PROVINCE = '{0}' or ", au);
                    }
                    //市权限
                    else if (au.EndsWith("00"))
                    {
                        sqlWhere1 += string.Format("t.CITY = '{0}' or ", au);
                        sqlWhere2 += string.Format("i.CITY = '{0}' or ", au);
                    }
                    //县权限
                    else
                    {
                        sqlWhere1 += string.Format("t.COUNTY = '{0}' or ", au);
                        sqlWhere2 += string.Format("i.COUNTY = '{0}' or ", au);
                    }
                }
                if (!string.IsNullOrEmpty(sqlWhere1))
                {
                    sqlWhere1 = sqlWhere1.Substring(0, sqlWhere1.Length - 3);
                    sqlWhere1 = sqlWhere1 + ")";

                    sqlWhere += sqlWhere1;
                    sqlWhere2 = sqlWhere2.Substring(0, sqlWhere2.Length - 3);
                    sqlWhere2 = sqlWhere2 + ")";
                    sqlwherezhd += sqlWhere2;
                }
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
                //string townSql = string.Format(sqlTemp, sqlWhere, "t.PROVINCENAME,t.CITYNAME,t.COUNTYNAME,t.TOWNNAME,t.province,t.city,t.county,t.town", "t.county", sqlwherezhd, "i.PROVINCENAME,i.CITYNAME,i.COUNTYNAME,i.TOWNNAME,i.province,i.city,i.county,i.town", "i.county", "j.COUNTYNAME", "k.COUNTYNAME");
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
        public string PCTJSql(string value)
        {
            var sql = string.Empty;
            if (value == "0")
            {
                #region 统计语句

                sql = @"select j.*,k.zhd from ( select {1},
           sum(case
                 when t.DISASTERLEVEL = 'A' then
                  1
                 else
                  0
               end) as zqxx,
           sum(case
                 when t.DISASTERLEVEL = 'B' then
                  1
                 else
                  0
               end) as zqzx,
           sum(case
                 when t.DISASTERLEVEL = 'C' then
                  1
                 else
                  0
               end) as zqdx,
           sum(case
                 when t.DISASTERLEVEL = 'D' then
                  1
                 else
                  0
               end) as zqtdx,
           sum(case
                 when t.DANGERLEVEL = 'A' then
                  1
                 else
                  0
               end) as xqxx,
           sum(case
                 when t.DANGERLEVEL = 'B' then
                  1
                 else
                  0
               end) as xqzx,
           sum(case
                 when t.DANGERLEVEL = 'C' then
                  1
                 else
                  0
               end) as xqdx,
           sum(case
                 when t.DANGERLEVEL = 'D' then
                  1
                 else
                  0
               end) as xqtdx,
           sum(case
                 when t.HIDDENDANGER = '1'  or t.disastertype like '%隐患%' then
                  1
                 else
                  0
               end) as yhd,
             sum(case
                 when  t.disastertype LIKE '滑坡%' and  t.HIDDENDANGER = '1'  then
                  1
                 else
                  0
               end) as yhdhp, 
           sum(case
                 when t.disastertype LIKE '崩塌%' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhdbt, 
           sum(case
                 when t.disastertype = '斜坡' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhdxp,
           sum(case
                 when t.disastertype = '泥石流' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhdnsl,
           sum(case
                 when t.disastertype = '地面沉降' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhddmcj,
           sum(case
                 when t.disastertype = '地裂缝' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhddlf,
           sum(case
                 when t.disastertype = '地面塌陷' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as hp1,
          sum(case
                 when t.disastertype LIKE '滑坡%' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as hp,
          sum(case
                 when t.disastertype LIKE '崩塌%' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as bt,        
           sum(case
                 when t.disastertype = '斜坡' then
                  1
                 else
                  0
               end) as xp,
           sum(case
                 when t.disastertype = '泥石流' then
                  1
                 else
                  0
               end) as nsl,
           sum(case
                 when t.disastertype = '地面沉降' then
                  1
                 else
                  0
               end) as dmcj,
           sum(case
                 when t.disastertype = '地裂缝' then
                  1
                 else
                  0
               end) as dlf,
           sum(case
                 when t.disastertype = '地面塌陷' then
                  1
                 else
                  0
               end) as dmtx,
           sum(case
                 when t.CURSTABLESTATUS = 'A' then
                  1
                 else
                  0
               end) as mqwd,
           sum(case
                 when t.CURSTABLESTATUS = 'B' then
                  1
                 else
                  0
               end) as mqqzbwd,
           sum(case
                 when t.CURSTABLESTATUS = 'C' then
                  1
                 else
                  0
               end) as mqbwd,
           sum(case
                 when t.STABLETREND = 'A' then
                  1
                 else
                  0
               end) as jhwd,
           sum(case
                 when t.STABLETREND = 'B' then
                  1
                 else
                  0
               end) as jhqzbwd,
           sum(case
                 when t.STABLETREND = 'C' then
                  1
                 else
                  0
               end) as jhbwd,
           sum(case
                 when t.DESTROYEDHOME is null then
                  0
                 else
                  t.DESTROYEDHOME
               end) as hhfw,
           sum(case
                 when t.DESTROYEDROAD is null then
                  0
                 else
                  t.DESTROYEDROAD
               end) as hl,
           sum(case
                 when t.DESTROYEDCANAL is null then
                  0
                 else
                 t.DESTROYEDCANAL
               end) as hq,
           sum(t.THREATENPEOPLE) as wxrk,
           sum(t.THREATENASSETS) as wxcc,
           sum(case
                 when t.MONITORSUGGESTION = 'A' then
                  1
                 else
                  0
               end) as jcms,
           sum(case
                 when t.MONITORSUGGESTION = 'B' then
                  1
                 else
                  0
               end) as jcss,
           sum(case
                 when t.MONITORSUGGESTION = 'C' then
                  1
                 else
                  0
               end) as jcdm,
           sum(case
                 when t.MONITORSUGGESTION = 'D' then
                  1
                 else
                  0
               end) as jcsb,
           sum(case
                 when t.TREATMENTSUGGESTION = 'A' then
                  1
                 else
                  0
               end) as fzqcqf,
           sum(case
                 when t.TREATMENTSUGGESTION = 'B' then
                  1
                 else
                  0
               end) as fzzyjc,
           sum(case
                 when t.TREATMENTSUGGESTION = 'C' then
                  1
                 else
                  0
               end) as fzbrbq,
           sum(case
                 when t.TREATMENTSUGGESTION = 'D' then
                  1
                 else
                  0
               end) as fzgczl
      from tbl_hazardbasicinfo t where 1=1   {0}
     group by {1} order by {2}  ) j left join  (select {4},sum(case
                 when i.unifiedcode is null then
                  0
                 else
                  1
               end) as zhd     from tbl_hazardbasicinfo i where 1=1   {3}
     group by {4} order by {5}) k   on {6}={7} ";

                #endregion
            }
            else if (value == "1")
            {
                #region 统计语句

                sql = @"select j.*,k.zhd from ( select {1},
           sum(case
                 when t.DISASTERLEVEL = 'A' then
                  1
                 else
                  0
               end) as zqxx,
           sum(case
                 when t.DISASTERLEVEL = 'B' then
                  1
                 else
                  0
               end) as zqzx,
           sum(case
                 when t.DISASTERLEVEL = 'C' then
                  1
                 else
                  0
               end) as zqdx,
           sum(case
                 when t.DISASTERLEVEL = 'D' then
                  1
                 else
                  0
               end) as zqtdx,
           sum(case
                 when t.DANGERLEVEL = 'A' then
                  1
                 else
                  0
               end) as xqxx,
           sum(case
                 when t.DANGERLEVEL = 'B' then
                  1
                 else
                  0
               end) as xqzx,
           sum(case
                 when t.DANGERLEVEL = 'C' then
                  1
                 else
                  0
               end) as xqdx,
           sum(case
                 when t.DANGERLEVEL = 'D' then
                  1
                 else
                  0
               end) as xqtdx,
           sum(case
                 when t.HIDDENDANGER = '1'  or t.disastertype like '%隐患%' then
                  1
                 else
                  0
               end) as yhd,

sum(case
                 when  t.disastertype = '滑坡' and  t.HIDDENDANGER = '1'  then
                  1
                 else
                  0
               end) as yhdhp, sum(case
                 when t.disastertype = '滑坡隐患点'  then
                  1
                 else
                  0
               end) as yhdhpyhd,
           sum(case
                 when t.disastertype = '崩塌' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhdbt, sum(case
                 when t.disastertype = '崩塌隐患点' then
                  1
                 else
                  0
               end) as byhdtyhd,
           sum(case
                 when t.disastertype = '斜坡' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhdxp,
           sum(case
                 when t.disastertype = '泥石流' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhdnsl,
           sum(case
                 when t.disastertype = '地面沉降' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhddmcj,
           sum(case
                 when t.disastertype = '地裂缝' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhddlf,
           sum(case
                 when t.disastertype = '地面塌陷' and  t.HIDDENDANGER = '1' then
                  1
                 else
                  0
               end) as yhddmtx,
           sum(case
                 when t.disastertype = '遥感解译点' then
                  1
                 else
                  0
               end) as yhdygyhd,


           sum(case
                 when t.disastertype = '滑坡' then
                  1
                 else
                  0
               end)+ sum(case
                 when t.disastertype = '滑坡隐患' then
                  1
                 else
                  0
               end) as hp,
           sum(case
                 when t.disastertype = '崩塌' then
                  1
                 else
                  0
               end)+ sum(case
                 when t.disastertype = '崩塌隐患' then
                  1
                 else
                  0
               end) as bt,
           sum(case
                 when t.disastertype = '斜坡' then
                  1
                 else
                  0
               end) as xp,
           sum(case
                 when t.disastertype = '泥石流' then
                  1
                 else
                  0
               end) as nsl,
           sum(case
                 when t.disastertype = '地面沉降' then
                  1
                 else
                  0
               end) as dmcj,
           sum(case
                 when t.disastertype = '地裂缝' then
                  1
                 else
                  0
               end) as dlf,
           sum(case
                 when t.disastertype = '地面塌陷' then
                  1
                 else
                  0
               end) as dmtx,
           sum(case
                 when t.CURSTABLESTATUS = 'A' then
                  1
                 else
                  0
               end) as mqwd,
           sum(case
                 when t.CURSTABLESTATUS = 'B' then
                  1
                 else
                  0
               end) as mqqzbwd,
           sum(case
                 when t.CURSTABLESTATUS = 'C' then
                  1
                 else
                  0
               end) as mqbwd,
           sum(case
                 when t.STABLETREND = 'A' then
                  1
                 else
                  0
               end) as jhwd,
           sum(case
                 when t.STABLETREND = 'B' then
                  1
                 else
                  0
               end) as jhqzbwd,
           sum(case
                 when t.STABLETREND = 'C' then
                  1
                 else
                  0
               end) as jhbwd,
           sum(case
                 when t.DESTROYEDHOME is null then
                  0
                 else
                  t.DESTROYEDHOME
               end) as hhfw,
           sum(case
                 when t.DESTROYEDROAD is null then
                  0
                 else
                  t.DESTROYEDROAD
               end) as hl,
           sum(case
                 when t.DESTROYEDCANAL is null then
                  0
                 else
                 t.DESTROYEDCANAL
               end) as hq,
           sum(t.THREATENPEOPLE) as wxrk,
           sum(t.THREATENASSETS) as wxcc,
           sum(case
                 when t.MONITORSUGGESTION = 'A' then
                  1
                 else
                  0
               end) as jcms,
           sum(case
                 when t.MONITORSUGGESTION = 'B' then
                  1
                 else
                  0
               end) as jcss,
           sum(case
                 when t.MONITORSUGGESTION = 'C' then
                  1
                 else
                  0
               end) as jcdm,
           sum(case
                 when t.MONITORSUGGESTION = 'D' then
                  1
                 else
                  0
               end) as jcsb,
           sum(case
                 when t.TREATMENTSUGGESTION = 'A' then
                  1
                 else
                  0
               end) as fzqcqf,
           sum(case
                 when t.TREATMENTSUGGESTION = 'B' then
                  1
                 else
                  0
               end) as fzzyjc,
           sum(case
                 when t.TREATMENTSUGGESTION = 'C' then
                  1
                 else
                  0
               end) as fzbrbq,
           sum(case
                 when t.TREATMENTSUGGESTION = 'D' then
                  1
                 else
                  0
               end) as fzgczl
      from tbl_hazardbasicinfo t where 1=1   {0}
     group by {1} order by {2}  ) j left join  (select {4},sum(case
                 when i.unifiedcode is null then
                  0
                 else
                  1
               end) as zhd     from tbl_hazardbasicinfo i where 1=1   {3}
     group by {4} order by {5}) k   on {6}={7} ";

                #endregion
            }
            return sql;
        }
        /// <summary>
        #endregion
        /// <summary>
        /// 灾害点统计
        /// </summary>
        /// <returns></returns>
        public EchartEntity GetStatisticsByZHD(string queryJson)
        {
            List<string> selectXZQH = new List<string>();
            string DefalutCode = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];

            string XZQHLEVEL = "省";
            int subLength = 2;
            List<AreaEntity> districts = new List<AreaEntity>();
            List<DistrictDict> _codesandname = ssoWS.GetAllAuthDistrictsReturnDistrictDict();
            List<DistrictDict> _newcodesandname = new List<DistrictDict>();
            List<string> _codes = _codesandname.Select(s => s.DistrictCode).ToList();
            if (string.IsNullOrWhiteSpace(queryJson))
            {
                queryJson = "{}";
            }
            if (!_codes.Contains("000000"))
            {
                if (_codes.Where(p => p.EndsWith("0000")).Count() > 0)
                {
                    XZQHLEVEL = "省";
                    subLength = 2;
                    selectXZQH = _codes.Where(p => p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("0000")).ToList();
                }
                if (_codes.Where(p => p.EndsWith("00")).Count() > 1)
                {
                    XZQHLEVEL = "市";
                    subLength = 4;
                    selectXZQH = _codes.Where(p => p.EndsWith("00") && !p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("00") && !s.DistrictCode.EndsWith("0000")).ToList();
                }
                else
                {
                    XZQHLEVEL = "县";
                    subLength = 6;
                    selectXZQH = _codes.Where(p => !p.EndsWith("00")).ToList();
                    _newcodesandname = _codesandname.Where(s => !s.DistrictCode.EndsWith("00")).ToList();
                }
                foreach (var item in _newcodesandname)
                {
                    AreaEntity ae = new AreaEntity();
                    ae.F_AreaName = item.DistrictName;
                    ae.F_AreaCode = item.DistrictCode;
                    districts.Add(ae);
                }
            }
            else
            {
                districts = ssoWS.GetAreaListJson(DefalutCode);
                selectXZQH = districts.Select(p => p.F_AreaCode).ToList();
            }
            var queryParam = queryJson.ToJObject();
            //选择行政区划
            if (!queryParam["SelectXZQH"].IsEmpty())
            {
                string strValue = queryParam["SelectXZQH"].ToString();
                if (strValue.EndsWith("000000"))
                {
                    XZQHLEVEL = "全国";
                    subLength = 2;
                }
                else if (strValue.EndsWith("0000"))
                {
                    XZQHLEVEL = "省";
                    subLength = 4;
                    districts = ssoWS.GetAreaListJson(strValue);
                    selectXZQH = districts.Select(p => p.F_AreaCode).ToList();
                }
                else if (strValue.EndsWith("00"))
                {
                    XZQHLEVEL = "市";
                    subLength = 6;
                    districts = ssoWS.GetAreaListJson(strValue);
                    selectXZQH = districts.Select(p => p.F_AreaCode).ToList();
                }
                else
                {
                    XZQHLEVEL = "县";
                    subLength = 9;
                    selectXZQH = new List<string> { strValue };
                }
            }
            DataItemDetailService dataItemDetail = new DataItemDetailService();
            IList<string> dataItemDetailList = new List<string>() { "行政区划" };
            //List<DistrictDict> districts = _codesandname.Where(s => selectXZQH.Contains(s.DistrictCode)).ToList();
            //List<AreaEntity> districts1 = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).Where(p => selectXZQH.Contains(p.F_AreaCode)).ToList();
            string strSql = "";
            string sqlWhere = "";
            if (!_codes.Contains("000000"))
            {
                //sqlWhere = " and substr(DISASTERCODE, 0, 6) in('" + string.Join("','", _codes.ToArray()) + "') ";
                sqlWhere = " and " + DbSqlFunctionHelper.SubString("DISASTERCODE", 0, 6) + " in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            string sqlReturnWhere = "";
            for (int i = 0; i < dataItemDetailList.Count; i++)
            {
                if (i == 0)
                {
                    //sqlReturnWhere = " and ISZAIQINGORXIANQING='1'";
                    strSql += GetSqlNew(subLength, dataItemDetailList[i], districts, sqlReturnWhere, queryJson);
                }
                else
                {
                    //sqlReturnWhere = " and ISZAIQINGORXIANQING='2'";
                    strSql += " union all " + GetSqlNew(subLength, dataItemDetailList[i], districts, sqlReturnWhere, queryJson);
                }
                //strSql += " and to_char(SURVEYTIME,'yyyy')=" + queryParam["YEAR"];
                if (queryParam["YEAR"] != null)
                {
                    strSql += " and " + DbSqlFunctionHelper.DateToChar("SURVEYTIME", "yyyy") + "=" + queryParam["YEAR"];
                }
            }
            EchartEntity returnValue = new EchartEntity();
            returnValue.AreaList = districts;
            returnValue.columnList = districts.Select(p => p.F_AreaName).ToList();//查询列名称
            returnValue.dataList = convertDataTable(this.BaseRepository().FindTable(strSql), dataItemDetailList);
            return returnValue;
        }
        /// <summary>
        /// 拟销号点统计
        /// </summary>
        /// <returns></returns>
        public EchartEntity GetStatisticsByXH(string queryJson)
        {
            List<string> selectXZQH = new List<string>();
            string DefalutCode = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];

            string XZQHLEVEL = "省";
            int subLength = 2;

            //List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<AreaEntity> districts = new List<AreaEntity>();
            List<DistrictDict> _codesandname = ssoWS.GetAllAuthDistrictsReturnDistrictDict();
            List<DistrictDict> _newcodesandname = new List<DistrictDict>();
            List<string> _codes = _codesandname.Select(s => s.DistrictCode).ToList();
            if (!_codes.Contains("000000"))
            {
                if (_codes.Where(p => p.EndsWith("0000")).Count() > 0)
                {
                    XZQHLEVEL = "省";
                    subLength = 2;
                    selectXZQH = _codes.Where(p => p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("0000")).ToList();
                }
                if (_codes.Where(p => p.EndsWith("00")).Count() > 1)
                {
                    XZQHLEVEL = "市";
                    subLength = 4;
                    selectXZQH = _codes.Where(p => p.EndsWith("00") && !p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("00") && !s.DistrictCode.EndsWith("0000")).ToList();
                }
                else
                {
                    XZQHLEVEL = "县";
                    subLength = 6;
                    selectXZQH = _codes.Where(p => !p.EndsWith("00")).ToList();
                    _newcodesandname = _codesandname.Where(s => !s.DistrictCode.EndsWith("00")).ToList();
                }
                foreach (var item in _newcodesandname)
                {
                    AreaEntity ae = new AreaEntity();
                    ae.F_AreaName = item.DistrictName;
                    ae.F_AreaCode = item.DistrictCode;
                    districts.Add(ae);
                }
            }
            else
            {
                districts = ssoWS.GetAreaListJson(DefalutCode);
                selectXZQH = districts.Select(p => p.F_AreaCode).ToList();
            }
            if (string.IsNullOrWhiteSpace(queryJson))
            {
                queryJson = "{}";
            }
            var queryParam = queryJson.ToJObject();
            //选择行政区划
            if (!queryParam["SelectXZQH"].IsEmpty())
            {
                string strValue = queryParam["SelectXZQH"].ToString();
                if (strValue.EndsWith("000000"))
                {
                    XZQHLEVEL = "全国";
                    subLength = 2;
                }
                else if (strValue.EndsWith("0000"))
                {
                    XZQHLEVEL = "省";
                    subLength = 4;
                    districts = ssoWS.GetAreaListJson(strValue);
                    selectXZQH = districts.Select(p => p.F_AreaCode).ToList();
                }
                else if (strValue.EndsWith("00"))
                {
                    XZQHLEVEL = "市";
                    subLength = 6;
                    districts = ssoWS.GetAreaListJson(strValue);
                    selectXZQH = districts.Select(p => p.F_AreaCode).ToList();
                }
                else
                {
                    XZQHLEVEL = "县";
                    subLength = 9;
                    selectXZQH = new List<string> { strValue };
                }
            }
            DataItemDetailService dataItemDetail = new DataItemDetailService();
            IList<string> dataItemDetailList = new List<string>() { "行政区划" };
            //List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).Where(p => selectXZQH.Contains(p.F_AreaCode)).ToList();
            string strSql = "";
            string sqlWhere = "";
            if (!_codes.Contains("000000"))
            {
                //sqlWhere = " and substr(UNIFIEDCODE, 0, 6) in('" + string.Join("','", _codes.ToArray()) + "') ";
                sqlWhere = " and " + DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, 6) + "  in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            string sqlReturnWhere = "";

            strSql += GetSqlNew2(subLength, dataItemDetailList[0], districts, sqlReturnWhere, "TBL_XIAOHAO", "UNIFIEDCODE");
            //strSql += " and to_char(XHSJ,'yyyy')=" + queryParam["YEAR"];
            if (queryParam["YEAR"] != null)
            {
                strSql += " and " + DbSqlFunctionHelper.DateToChar("XHSJ", "yyyy") + "=" + queryParam["YEAR"];
            }
            //var projectid = project.GetTCYearProject(queryJson);
            //strSql += "and PROJECTID = '" + projectid + "'";
            EchartEntity returnValue = new EchartEntity();
            returnValue.columnList = districts.Select(p => p.F_AreaName).ToList();//查询列名称
            returnValue.dataList = convertDataTable(this.BaseRepository().FindTable(strSql), dataItemDetailList);
            return returnValue;
        }
        /// <summary>
        /// 险情等级统计
        /// </summary>
        /// <returns></returns>
        public EchartEntity GetStatisticsByXQDJ(string queryJson)
        {
            List<string> selectXZQH = new List<string>();
            string DefalutCode = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];

            string XZQHLEVEL = "省";
            int subLength = 2;
            List<DistrictDict> _newcodesandname = new List<DistrictDict>();
            List<AreaEntity> districts = new List<AreaEntity>();
            //List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<DistrictDict> _codesandname = ssoWS.GetAllAuthDistrictsReturnDistrictDict();
            List<string> _codes = _codesandname.Select(s => s.DistrictCode).ToList();
            if (!_codes.Contains("000000"))
            {
                if (_codes.Where(p => p.EndsWith("0000")).Count() > 0)
                {
                    XZQHLEVEL = "省";
                    subLength = 2;
                    selectXZQH = _codes.Where(p => p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("0000")).ToList();
                }
                if (_codes.Where(p => p.EndsWith("00")).Count() > 1)
                {
                    XZQHLEVEL = "市";
                    subLength = 4;
                    selectXZQH = _codes.Where(p => p.EndsWith("00") && !p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("00") && !s.DistrictCode.EndsWith("0000")).ToList();
                }
                else
                {
                    XZQHLEVEL = "县";
                    subLength = 6;
                    selectXZQH = _codes.Where(p => !p.EndsWith("00")).ToList();
                    _newcodesandname = _codesandname.Where(s => !s.DistrictCode.EndsWith("00")).ToList();
                }
                foreach (var item in _newcodesandname)
                {
                    AreaEntity ae = new AreaEntity();
                    ae.F_AreaName = item.DistrictName;
                    ae.F_AreaCode = item.DistrictCode;
                    districts.Add(ae);
                }
            }
            else
            {
                districts = ssoWS.GetAreaListJson(DefalutCode);
                selectXZQH = districts.Select(p => p.F_AreaCode).ToList();
            }
            DataItemDetailService dataItemDetail = new DataItemDetailService();
            Dictionary<string, string> dicList = new Dictionary<string, string>();
            IList<DataItemDetailEntity> dicList2 = dataItemDetail.GetItemDetailList("DANGERLEVEL").ToList();//险情等级
            IList<string> dataItemDetailList = dicList2.Select(p => p.F_ItemName).ToList();
            dicList = dicList2.ToDictionary(p => p.F_ItemValue, p => p.F_ItemName);

            //List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).Where(p => selectXZQH.Contains(p.F_AreaCode)).ToList();
            //List<DistrictDict> districts = _codesandname.Where(s => selectXZQH.Contains(s.DistrictCode)).ToList();
            string strSql = "";
            string sqlWhere = "";
            if (!_codes.Contains("000000"))
            {
                // sqlWhere = " and substr(UNIFIEDCODE, 0, 6) in('" + string.Join("','", _codes.ToArray()) + "') ";
                sqlWhere = " and " + DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, 6) + "  in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            if (string.IsNullOrWhiteSpace(queryJson))
            {
                queryJson = "{}";
            }
            var queryParam = queryJson.ToJObject();
            string sqlReturnWhere = "";
            for (int i = 0; i < dicList.Count; i++)
            {
                var item = dicList.ElementAt(i);
                if (i == 0)
                {
                    sqlReturnWhere = " and DANGERLEVEL='" + item.Key + "'";
                    strSql += GetSqlNew(subLength, item.Value, districts, sqlReturnWhere, queryJson);
                }
                else
                {
                    sqlReturnWhere = " and DANGERLEVEL='" + item.Key + "'";
                    strSql += " union all " + GetSqlNew(subLength, item.Value, districts, sqlReturnWhere, queryJson);
                }
                //strSql += " and to_char(SURVEYTIME,'yyyy')=" + queryParam["YEAR"];
                if (queryParam["YEAR"] != null)
                {
                    strSql += " and " + DbSqlFunctionHelper.DateToChar("SURVEYTIME", "yyyy") + "=" + queryParam["YEAR"];
                }
            }

            EchartEntity returnValue = new EchartEntity();
            returnValue.columnList = districts.Select(p => p.F_AreaName).ToList();//查询列名称
            returnValue.dataList = convertDataTable(this.BaseRepository().FindTable(strSql), dataItemDetailList);
            return returnValue;
        }
        /// <summary>
        /// 灾害规模等级统计
        /// </summary>
        /// <returns></returns>
        public EchartEntity GetStatisticsByGMDJ(string queryJson)
        {
            List<string> selectXZQH = new List<string>();
            string DefalutCode = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];

            string XZQHLEVEL = "省";
            int subLength = 2;
            List<DistrictDict> _newcodesandname = new List<DistrictDict>();
            List<AreaEntity> districts = new List<AreaEntity>();
            //List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<DistrictDict> _codesandname = ssoWS.GetAllAuthDistrictsReturnDistrictDict();
            List<string> _codes = _codesandname.Select(s => s.DistrictCode).ToList();
            if (!_codes.Contains("000000"))
            {
                if (_codes.Where(p => p.EndsWith("0000")).Count() > 0)
                {
                    XZQHLEVEL = "省";
                    subLength = 2;
                    selectXZQH = _codes.Where(p => p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("0000")).ToList();
                }
                if (_codes.Where(p => p.EndsWith("00")).Count() > 1)
                {
                    XZQHLEVEL = "市";
                    subLength = 4;
                    selectXZQH = _codes.Where(p => p.EndsWith("00") && !p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("00") && !s.DistrictCode.EndsWith("0000")).ToList();
                }
                else
                {
                    XZQHLEVEL = "县";
                    subLength = 6;
                    selectXZQH = _codes.Where(p => !p.EndsWith("00")).ToList();
                    _newcodesandname = _codesandname.Where(s => !s.DistrictCode.EndsWith("00")).ToList();
                }
                foreach (var item in _newcodesandname)
                {
                    AreaEntity ae = new AreaEntity();
                    ae.F_AreaName = item.DistrictName;
                    ae.F_AreaCode = item.DistrictCode;
                    districts.Add(ae);
                }
            }
            else
            {
                districts = ssoWS.GetAreaListJson(DefalutCode);
                selectXZQH = districts.Select(p => p.F_AreaCode).ToList();
            }
            DataItemDetailService dataItemDetail = new DataItemDetailService();
            Dictionary<string, string> dicList = new Dictionary<string, string>();
            IList<DataItemDetailEntity> dicList2 = dataItemDetail.GetItemDetailList("DISAATERSIZE").ToList();//灾害规模
            IList<string> dataItemDetailList = dicList2.Select(p => p.F_ItemName).ToList();
            dicList = dicList2.ToDictionary(p => p.F_ItemValue, p => p.F_ItemName);
            string strSql = "";
            string sqlWhere = "";
            if (string.IsNullOrWhiteSpace(queryJson))
            {
                queryJson = "{}";
            }
            var queryParam = queryJson.ToJObject();
            if (!_codes.Contains("000000"))
            {
                //sqlWhere = " and substr(UNIFIEDCODE, 0, 6) in('" + string.Join("','", _codes.ToArray()) + "') ";
                sqlWhere = " and " + DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, 6) + "  in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            string sqlReturnWhere = "";
            for (int i = 0; i < dicList.Count; i++)
            {
                var item = dicList.ElementAt(i);
                if (i == 0)
                {
                    sqlReturnWhere = " and SCALELEVEL='" + item.Key + "'";
                    strSql += GetSqlNew(subLength, item.Value, districts, sqlReturnWhere, queryJson);
                }
                else
                {
                    sqlReturnWhere = " and SCALELEVEL='" + item.Key + "'";
                    strSql += " union all " + GetSqlNew(subLength, item.Value, districts, sqlReturnWhere, queryJson);
                }
                //strSql += " and to_char(SURVEYTIME,'yyyy')=" + queryParam["YEAR"];
                if (queryParam["YEAR"] != null)
                {
                    strSql += " and " + DbSqlFunctionHelper.DateToChar("SURVEYTIME", "yyyy") + "=" + queryParam["YEAR"];
                }
            }
            EchartEntity returnValue = new EchartEntity();
            returnValue.columnList = districts.Select(p => p.F_AreaName).ToList();//查询列名称
            returnValue.dataList = convertDataTable(this.BaseRepository().FindTable(strSql), dataItemDetailList);
            return returnValue;
        }
        /// <summary>
        /// 灾害等级统计
        /// </summary>
        /// <returns></returns>
        public EchartEntity GetStatisticsByZQDJ(string queryJson)
        {
            List<string> selectXZQH = new List<string>();
            string DefalutCode = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];

            string XZQHLEVEL = "省";
            int subLength = 2;
            List<DistrictDict> _newcodesandname = new List<DistrictDict>();
            List<AreaEntity> districts = new List<AreaEntity>();
            //List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<DistrictDict> _codesandname = ssoWS.GetAllAuthDistrictsReturnDistrictDict();
            List<string> _codes = _codesandname.Select(s => s.DistrictCode).ToList();
            if (!_codes.Contains("000000"))
            {
                if (_codes.Where(p => p.EndsWith("0000")).Count() > 0)
                {
                    XZQHLEVEL = "省";
                    subLength = 2;
                    selectXZQH = _codes.Where(p => p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("0000")).ToList();
                }
                if (_codes.Where(p => p.EndsWith("00")).Count() > 1)
                {
                    XZQHLEVEL = "市";
                    subLength = 4;
                    selectXZQH = _codes.Where(p => p.EndsWith("00") && !p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("00") && !s.DistrictCode.EndsWith("0000")).ToList();
                }
                else
                {
                    XZQHLEVEL = "县";
                    subLength = 6;
                    selectXZQH = _codes.Where(p => !p.EndsWith("00")).ToList();
                    _newcodesandname = _codesandname.Where(s => !s.DistrictCode.EndsWith("00")).ToList();
                }
                foreach (var item in _newcodesandname)
                {
                    AreaEntity ae = new AreaEntity();
                    ae.F_AreaName = item.DistrictName;
                    ae.F_AreaCode = item.DistrictCode;
                    districts.Add(ae);
                }
            }
            else
            {
                districts = ssoWS.GetAreaListJson(DefalutCode);
                selectXZQH = districts.Select(p => p.F_AreaCode).ToList();
            }
            DataItemDetailService dataItemDetail = new DataItemDetailService();
            Dictionary<string, string> dicList = new Dictionary<string, string>();
            IList<DataItemDetailEntity> dicList2 = dataItemDetail.GetItemDetailList("DISASTERLEVEL").ToList();//灾害等级
            IList<string> dataItemDetailList = dicList2.Select(p => p.F_ItemName).ToList();
            dicList = dicList2.ToDictionary(p => p.F_ItemValue, p => p.F_ItemName);
            string strSql = "";
            string sqlWhere = "";
            if (string.IsNullOrWhiteSpace(queryJson))
            {
                queryJson = "{}";
            }
            var queryParam = queryJson.ToJObject();
            if (!_codes.Contains("000000"))
            {
                // sqlWhere = " and substr(UNIFIEDCODE, 0, 6) in('" + string.Join("','", _codes.ToArray()) + "') ";
                sqlWhere = " and " + DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, 6) + "  in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            string sqlReturnWhere = "";
            for (int i = 0; i < dicList.Count; i++)
            {
                var item = dicList.ElementAt(i);
                if (i == 0)
                {
                    sqlReturnWhere = " and DISASTERLEVEL='" + item.Key + "'";
                    strSql += GetSqlNew(subLength, item.Value, districts, sqlReturnWhere, queryJson);
                }
                else
                {
                    sqlReturnWhere = " and DISASTERLEVEL='" + item.Key + "'";
                    strSql += " union all " + GetSqlNew(subLength, item.Value, districts, sqlReturnWhere, queryJson);
                }
                //strSql += " and to_char(SURVEYTIME,'yyyy')=" + queryParam["YEAR"];
                if (queryParam["YEAR"] != null)
                {
                    strSql += " and " + DbSqlFunctionHelper.DateToChar("SURVEYTIME", "yyyy") + "=" + queryParam["YEAR"];
                }
            }

            EchartEntity returnValue = new EchartEntity();
            returnValue.columnList = districts.Select(p => p.F_AreaName).ToList();//查询列名称
            returnValue.dataList = convertDataTable(this.BaseRepository().FindTable(strSql), dataItemDetailList);
            return returnValue;
        }

        /// <summary>
        /// 治理工程统计
        /// </summary>
        /// <returns></returns>
        public EchartEntity GetStatisticsByZLGC(string queryJson)
        {
            List<string> selectXZQH = new List<string>();
            string DefalutCode = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
            var queryParam = queryJson.ToJObject();
            if (!string.IsNullOrWhiteSpace(queryJson))
            {
                if (queryParam["SelectXZQH"] != null)
                {
                    if (queryParam["SelectXZQH"].ToString() == "000000")
                    {
                        DefalutCode = "0";
                    }
                    else
                    {
                        DefalutCode = queryParam["SelectXZQH"].ToString();
                    }
                }
                else
                {
                    DefalutCode = "0";
                }
            }
            string XZQHLEVEL = "省";
            int subLength = 2;
            //List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<AreaEntity> districts = new List<AreaEntity>();
            List<DistrictDict> _codesandname = ssoWS.GetAllAuthDistrictsReturnDistrictDict();
            List<DistrictDict> _newcodesandname = new List<DistrictDict>();
            List<string> _codes = _codesandname.Select(s => s.DistrictCode).ToList();

            if (!_codes.Contains("000000"))
            {
                if (_codes.Where(p => p.EndsWith("0000")).Count() > 0)
                {
                    XZQHLEVEL = "省";
                    subLength = 2;
                    selectXZQH = _codes.Where(p => p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("0000")).ToList();
                }
                if (_codes.Where(p => p.EndsWith("00")).Count() > 1)
                {
                    XZQHLEVEL = "市";
                    subLength = 4;
                    selectXZQH = _codes.Where(p => p.EndsWith("00") && !p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("00") && !s.DistrictCode.EndsWith("0000")).ToList();
                }
                else
                {
                    XZQHLEVEL = "县";
                    subLength = 6;
                    selectXZQH = _codes.Where(p => !p.EndsWith("00")).ToList();
                    _newcodesandname = _codesandname.Where(s => !s.DistrictCode.EndsWith("00")).ToList();
                }
                foreach (var item in _newcodesandname)
                {
                    AreaEntity ae = new AreaEntity();
                    ae.F_AreaName = item.DistrictName;
                    ae.F_AreaCode = item.DistrictCode;
                    districts.Add(ae);
                }
            }
            else
            {
                districts = ssoWS.GetAreaListJson(DefalutCode);
                selectXZQH = districts.Select(p => p.F_AreaCode).ToList();
            }
            DataItemDetailService dataItemDetail = new DataItemDetailService();
            IList<string> dataItemDetailList = new List<string>() { "行政区划" };
            //List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).Where(p => selectXZQH.Contains(p.F_AreaCode)).ToList();
            string strSql = "";
            string sqlWhere = "";
            if (string.IsNullOrWhiteSpace(queryJson))
            {
                queryJson = "{}";
            }
            if (!_codes.Contains("000000"))
            {
                //sqlWhere = " and substr(UNIFIEDCODE, 0, 6) in('" + string.Join("','", _codes.ToArray()) + "') ";
                sqlWhere = " and " + DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, 6) + "  in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            string sqlReturnWhere = "";

            strSql += GetSqlNew2(subLength, dataItemDetailList[0], districts, sqlReturnWhere, "TBL_ZLGC_BASEINFO", "UNIFIEDCODE");
            //strSql += " and to_char(GIVETIME,'yyyy')=" + queryParam["YEAR"];
            if (queryParam["YEAR"] != null)
            {
                strSql += " and " + DbSqlFunctionHelper.DateToChar("GIVETIME", "yyyy") + "=" + queryParam["YEAR"];
            }

            EchartEntity returnValue = new EchartEntity();
            returnValue.columnList = districts.Select(p => p.F_AreaName).ToList();//查询列名称
            returnValue.dataList = convertDataTable(this.BaseRepository().FindTable(strSql), dataItemDetailList);
            return returnValue;
        }
        /// <summary>
        /// 搬迁避让统计
        /// </summary>
        /// <returns></returns>
        public EchartEntity GetStatisticsByBQBR(string queryJson)
        {
            List<string> selectXZQH = new List<string>();
            string DefalutCode = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
            var queryParam = queryJson.ToJObject();
            if (!string.IsNullOrWhiteSpace(queryJson))
            {
                if (queryParam["SelectXZQH"] != null)
                {
                    if (queryParam["SelectXZQH"].ToString() == "000000")
                    {
                        DefalutCode = "0";
                    }
                    else
                    {
                        DefalutCode = queryParam["SelectXZQH"].ToString();
                    }
                }
                else
                {
                    DefalutCode = "0";
                }
            }
            string XZQHLEVEL = "省";
            int subLength = 2;

            //List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<AreaEntity> districts = new List<AreaEntity>();
            List<DistrictDict> _codesandname = ssoWS.GetAllAuthDistrictsReturnDistrictDict();
            List<DistrictDict> _newcodesandname = new List<DistrictDict>();
            List<string> _codes = _codesandname.Select(s => s.DistrictCode).ToList();

            if (!_codes.Contains("000000"))
            {
                if (_codes.Where(p => p.EndsWith("0000")).Count() > 0)
                {
                    XZQHLEVEL = "省";
                    subLength = 2;
                    selectXZQH = _codes.Where(p => p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("0000")).ToList();
                }
                if (_codes.Where(p => p.EndsWith("00")).Count() > 1)
                {
                    XZQHLEVEL = "市";
                    subLength = 4;
                    selectXZQH = _codes.Where(p => p.EndsWith("00") && !p.EndsWith("0000")).ToList();
                    _newcodesandname = _codesandname.Where(s => s.DistrictCode.EndsWith("00") && !s.DistrictCode.EndsWith("0000")).ToList();
                }
                else
                {
                    XZQHLEVEL = "县";
                    subLength = 6;
                    selectXZQH = _codes.Where(p => !p.EndsWith("00")).ToList();
                    _newcodesandname = _codesandname.Where(s => !s.DistrictCode.EndsWith("00")).ToList();
                }
                foreach (var item in _newcodesandname)
                {
                    AreaEntity ae = new AreaEntity();
                    ae.F_AreaName = item.DistrictName;
                    ae.F_AreaCode = item.DistrictCode;
                    districts.Add(ae);
                }
            }
            else
            {
                districts = ssoWS.GetAreaListJson(DefalutCode);
                selectXZQH = districts.Select(p => p.F_AreaCode).ToList();
            }
            DataItemDetailService dataItemDetail = new DataItemDetailService();
            IList<string> dataItemDetailList = new List<string>() { "行政区划" };
            //List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).Where(p => selectXZQH.Contains(p.F_AreaCode)).ToList();
            string strSql = "";
            string sqlWhere = "";
            if (string.IsNullOrWhiteSpace(queryJson))
            {
                queryJson = "{}";
            }
            if (!_codes.Contains("000000"))
            {
                //sqlWhere = " and substr(UNIFIEDCODE, 0, 6) in('" + string.Join("','", _codes.ToArray()) + "') ";
                sqlWhere = " and " + DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, 6) + "  in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            string sqlReturnWhere = "";

            strSql += GetSqlNew2(subLength, dataItemDetailList[0], districts, sqlReturnWhere, "TBL_BQBR", "UNIFIEDCODE");
            //strSql += " and to_char(CREATETIME,'yyyy')=" + queryParam["YEAR"];
            if (queryParam["YEAR"] != null)
            {
                strSql += " and " + DbSqlFunctionHelper.DateToChar("CREATETIME", "yyyy") + "=" + queryParam["YEAR"];
            }
            EchartEntity returnValue = new EchartEntity();
            returnValue.columnList = districts.Select(p => p.F_AreaName).ToList();//查询列名称
            returnValue.dataList = convertDataTable(this.BaseRepository().FindTable(strSql), dataItemDetailList);
            return returnValue;
        }
        public List<string> SSOGeodisaster(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            var XZQHLEVEL = string.Empty;
            int subLength = 2;
            var codes = string.Empty;
            string[] str = queryParam["SelectXZQH"].ToString().Split(',');
            if (queryParam["SelectXZQH"].ToString() == "000000" || queryParam["SelectXZQH"].ToString() == "")
            {
                queryParam["SelectXZQH"] = string.Empty;
            }
            else
            {
                codes = queryParam["SelectXZQH"].ToString();
                if (str.FirstOrDefault().ToString().Substring(2, 4) == "0000")
                {
                    XZQHLEVEL = "省";
                    subLength = 2;
                }
                else if (str.FirstOrDefault().ToString().Substring(4, 2) == "00")
                {
                    XZQHLEVEL = "市";
                    subLength = 4;
                }
                else
                {
                    XZQHLEVEL = "县";
                    subLength = 6;
                }
            }
            #region 地灾
            var dzsql = @"SELECT  COUNT(1) AS 灾害点总数,NVL(sum(case when  T.DISASTERTYPE ='崩塌' then 1 else 0 end),0) 崩塌总数,NVL(sum(case when  T.DISASTERTYPE ='斜坡' then 1 else 0 end),0) 斜坡总数,NVL(sum(case when  T.DISASTERTYPE ='泥石流' then 1 else 0 end),0) 泥石流总数,NVL(sum(case when  T.DISASTERTYPE ='地面塌陷' then 1 else 0 end),0) 地面塌陷总数,NVL(sum(case when  T.DISASTERTYPE ='地面沉降' then 1 else 0 end),0) 地面沉降总数,NVL(sum(case when  T.DISASTERTYPE ='滑坡' then 1 else 0 end),0) 滑坡总数,NVL(sum(case when  T.DISASTERTYPE ='地裂缝' then 1 else 0 end),0) 地裂缝总数 FROM  TBL_HAZARDBASICINFO  T WHERE 1=1";
            if (XZQHLEVEL == "省")
            {
                dzsql += " AND T.PROVINCE IN({0})";
            }
            else if (XZQHLEVEL == "市")
            {
                dzsql += " AND T.CITY IN({0})";
            }
            else if (XZQHLEVEL == "县")
            {
                dzsql += " AND T.COUNTY IN({0})";
            }
            var dzcount = JsonConvert.SerializeObject(this.BaseRepository().FindTable(string.Format(dzsql, codes)));
            #endregion
            #region 群测群防
            var worksql = @"select COUNT(1) AS 工作明白卡总数  from TBL_QCQF_WORKUNDERSTANDCARD t  inner join tbl_hazardbasicinfo b on t.unifiedcode=b.unifiedcode";
            var bzsql = @"select COUNT(1) AS 避灾明白卡总数  from TBL_QCQF_ESCUNDERSTANDCARD t  inner join tbl_hazardbasicinfo b on t.unifiedcode=b.unifiedcode";
            var fzsql = @"select COUNT(1) AS 防灾预案表总数  from TBL_QCQF_DISASTERPREVENTION t  inner join tbl_hazardbasicinfo b on t.unifiedcode=b.unifiedcode";
            if (queryParam["SelectXZQH"].ToString() == "000000" || queryParam["SelectXZQH"].ToString() == "")
            {

            }
            else
            {
                if (str.Count() == 1)
                {
                    worksql = string.Format("select COUNT(1) AS 工作明白卡总数  from TBL_QCQF_WORKUNDERSTANDCARD t inner join tbl_hazardbasicinfo b on t.unifiedcode=b.unifiedcode and t.unifiedcode  LIKE '{0}%'", str[0].Substring(0, subLength));
                    bzsql = string.Format("select COUNT(1) AS 避灾明白卡总数  from TBL_QCQF_ESCUNDERSTANDCARD t inner join tbl_hazardbasicinfo b on t.unifiedcode=b.unifiedcode and  t.unifiedcode  LIKE '{0}%'", str[0].Substring(0, subLength));
                    fzsql = string.Format("select COUNT(1) AS 防灾预案表总数  from TBL_QCQF_DISASTERPREVENTION t inner join tbl_hazardbasicinfo b on t.unifiedcode=b.unifiedcode and  t.unifiedcode  LIKE '{0}%'", str[0].Substring(0, subLength));
                }
                else
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (i == 0)
                        {
                            worksql += string.Format(" and  t.unifiedcode  LIKE '{0}%' ", str[i].Substring(0, subLength));
                            bzsql += string.Format(" and t.unifiedcode  LIKE '{0}%' ", str[i].Substring(0, subLength));
                            fzsql += string.Format(" and t.unifiedcode  LIKE '{0}%' ", str[i].Substring(0, subLength));
                        }
                        else
                        {
                            worksql += string.Format(" OR t.unifiedcode  LIKE '{0}%' ", str[i].Substring(0, subLength));
                            bzsql += string.Format(" OR t.unifiedcode  LIKE '{0}%' ", str[i].Substring(0, subLength));
                            fzsql += string.Format(" OR t.unifiedcode  LIKE '{0}%' ", str[i].Substring(0, subLength));
                        }

                    }
                }
            }
            //工作明白卡        
            var workcount = JsonConvert.SerializeObject(this.BaseRepository().FindTable(worksql));
            //避灾明白卡         
            var bzcount = JsonConvert.SerializeObject(this.BaseRepository().FindTable(bzsql));
            //防灾预案表         
            var fzcount = JsonConvert.SerializeObject(this.BaseRepository().FindTable(fzsql));
            #endregion
            #region 搬迁避让
            var bqbrsql = @"SELECT  COUNT(1) AS 搬迁避让总数,NVL(sum(case when  T.ISACCEPTANCE ='1' then 1 else 0 end),0) 搬迁避让完成总数,nvl(sum(case when T.ISCOMPLETE ='1' then 1 else 0 end),0) 搬迁避让验收完成总数  FROM  TBL_BQBR  T  WHERE 1=1";
            if (XZQHLEVEL == "省")
            {
                bqbrsql += " AND T.PROVINCE IN({0})";
            }
            else if (XZQHLEVEL == "市")
            {
                bqbrsql += " AND  T.CITY IN({0})";
            }
            else if (XZQHLEVEL == "县")
            {
                bqbrsql += " AND T.COUNTY IN({0})";
            }
            var bqbrcount = JsonConvert.SerializeObject(this.BaseRepository().FindTable(string.Format(bqbrsql, codes)));
            #endregion
            #region 治理工程
            //var zlgcsql = @"SELECT COUNT(1) AS 治理工程总数 FROM TBL_ZLGC_BASEINFO T  WHERE 1=1  ";
            var zlgcsql = @"    SELECT COUNT(1) AS 治理工程总数, SUM(项目立项) AS 项目立项个数, SUM(野外勘察) AS 野外勘察个数, SUM(施工设计) AS 施工设计个数, SUM(工程施工) AS 工程施工个数,SUM(工程监理) AS 工程监理个数,SUM(项目验收) AS 项目验收个数 FROM 
        ( select  PROVINCE,CITY,COUNTY,
         CASE WHEN ZLSTATE = '项目立项' THEN 1 ELSE 0 END AS 项目立项,
         CASE WHEN ZLSTATE = '野外勘察' THEN 1 ELSE 0 END AS 野外勘察,  
         CASE WHEN ZLSTATE = '施工设计' THEN 1 ELSE 0 END AS 施工设计,
         CASE WHEN ZLSTATE = '工程施工' THEN 1 ELSE 0 END AS 工程施工,    
         CASE WHEN ZLSTATE = '工程监理' THEN 1 ELSE 0 END AS 工程监理,
         CASE WHEN ZLSTATE = '项目验收' THEN 1 ELSE 0 END AS 项目验收  from TBL_ZLGC_BASEINFO T  WHERE 1=1  ";
            if (XZQHLEVEL == "省")
            {
                zlgcsql += " AND T.PROVINCE IN({0})";
            }
            else if (XZQHLEVEL == "市")
            {
                zlgcsql += " AND T.CITY IN({0})";
            }
            else if (XZQHLEVEL == "县")
            {
                zlgcsql += " AND T.COUNTY IN({0})";
            }
            zlgcsql = zlgcsql + ") TT  WHERE 1=1 ";
            var ZLGCcount = JsonConvert.SerializeObject(this.BaseRepository().FindTable(string.Format(zlgcsql, codes)));
            List<string> list = new List<string>();
            list.Add(dzcount);
            list.Add(ZLGCcount);
            list.Add(workcount);
            list.Add(bzcount);
            list.Add(fzcount);
            list.Add(bqbrcount);
            #endregion
            return list;
        }

        /// <summary>
        /// 拟销号点统计
        /// </summary>
        /// <returns></returns>

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
        private string GetSqlNew(int subLength, string dicName, List<AreaEntity> selectXZQH, string sqlWhere, string queryJson)
        {
            if (queryJson == "")
            {
                queryJson = "{}";
            }
            var projectid = project.GetTCYearProject(queryJson);
            string selectColumn = "";
            string groupBy = string.Format(" {0} ", DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, subLength));
            foreach (var item in selectXZQH)
            {
                selectColumn += string.Format(" ,sum(case when {1}='{0}' then 1 else 0 end) \"{2}\" ", item.F_AreaCode.Substring(0, subLength), groupBy, item.F_AreaName);
            }
            string returnValue = string.Format("select  '{0}' name {1} from TBL_HAZARDBASICINFO where 1=1    {2}", dicName, selectColumn, sqlWhere);
            return returnValue;
        }
        private string GetSqlHistory(int subLength, string dicName, List<ParetEntity> selectXZQH, string sqlWhere, string queryJson)//List<AreaEntity>
        {
            if (queryJson == "")
            {
                queryJson = "{}";
            }
            string selectColumn = "";
            string groupBy = string.Format(" {0} ", DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, subLength));
            foreach (var item in selectXZQH)
            {
                selectColumn += string.Format(" ,sum(case when {1}='{0}' then 1 else 0 end) \"{2}\" ", item.DistrictCode.Substring(0, subLength), groupBy, item.DistrictName);
            }
            var queryParam = queryJson.ToJObject();
            if (queryParam["YEAR"] != null)
            {
                sqlWhere += " and " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy") + "=" + queryParam["YEAR"];
            }
            string returnValue = "";
            if (queryParam["TYPE"] != null && queryParam["TYPE"].ToString() != "")
            {
                int i = selectColumn.Length - 2;
                selectColumn = selectColumn.Substring(2, i);
                if (queryParam["TYPE"].ToString() == "隐患点")
                {
                    returnValue = string.Format("select   {1} from (select  DISTINCT(UNIFIEDCODE)  from TBL_HAZARDBASICINFO_HISTORY where 1=1  {2}) t     ", dicName, selectColumn, sqlWhere);
                }
                else if (queryParam["TYPE"].ToString() == "新增点")
                {
                    returnValue = string.Format("select  {1} from  TBL_HAZARDBASICINFO_HISTORY where 1=1  {2} and MODIFYTYPE='A'", dicName, selectColumn, sqlWhere);
                }
                else if (queryParam["TYPE"].ToString() == "销号点")
                {
                    returnValue = string.Format("select  {1} from  TBL_HAZARDBASICINFO_HISTORY where 1=1  {2} ", dicName, selectColumn, sqlWhere);
                }

            }
            else
            {
                returnValue = string.Format("select  '{0}' name {1} from (select  DISTINCT(UNIFIEDCODE)  from TBL_HAZARDBASICINFO_HISTORY where 1=1  {2}) t     ", dicName, selectColumn, sqlWhere);
            }
            return returnValue;
        }
        private string GetSqls(int subLength, string dicName, List<ParetEntity> selectXZQH, string sqlWhere, string queryJson)//List<AreaEntity>
        {
            if (queryJson == "")
            {
                queryJson = "{}";
            }
            string selectColumn = "";
            string groupBy = string.Format(" {0} ", DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, subLength));
            foreach (var item in selectXZQH)
            {
                selectColumn += string.Format(" ,sum(case when {1}='{0}' then 1 else 0 end) \"{2}\" ", item.DistrictCode.Substring(0, subLength), groupBy, item.DistrictName);
            }
            var queryParam = queryJson.ToJObject();
            if (queryParam["YEAR"] != null)
            {
                sqlWhere += " and " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy") + "=" + queryParam["YEAR"];
            }
            string returnValue = "";
            returnValue = string.Format("select  '{0}' name {1} from (select  DISTINCT(UNIFIEDCODE)  from TBL_HAZARDBASICINFO where 1=1  {2}) t     ", dicName, selectColumn, sqlWhere);
            return returnValue;
        }
        private string GetSqlNew2(int subLength, string dicName, List<AreaEntity> selectXZQH, string sqlWhere, string tableName, string fieldName)
        {

            string selectColumn = "";
            string groupBy = string.Format(" {0} ", DbSqlFunctionHelper.SubString(fieldName, 0, subLength));
            foreach (var item in selectXZQH)
            {
                selectColumn += string.Format(" ,sum(case when  {1}='{0}' then 1 else 0 end) \"{2}\" ", item.F_AreaCode.Substring(0, subLength), groupBy, item.F_AreaName);
            }
            string returnValue = string.Format("select  '{0}' name {1} from {3} where 1=1  {2} ", dicName, selectColumn, sqlWhere, tableName);
            return returnValue;
        }

        /// <summary>
        /// 获取灾害类型统计结果
        /// </summary>
        /// <returns></returns>
        public DataTable GetDicAnalyse(string enCode)
        {
            //字典所对应的列名称
            Dictionary<string, string> dicCol = new Dictionary<string, string>();
            dicCol.Add("HazardType", "disastertype");
            dicCol.Add("CURRENTSTABLESTATUS", "CURSTABLESTATUS");
            dicCol.Add("STABLETREND", "STABLETREND");
            dicCol.Add("DANGERLEVELTX", "DANGERLEVEL");
            string col = string.Empty;
            if (dicCol.ContainsKey(enCode))
            {
                col = dicCol[enCode];
            }
            else
            {
                col = enCode;
            }
            //获取字典的取值范围
            IEnumerable<DataItemModel> lstDataItem = serviceDataItem.GetDataItemList(enCode);
            string sum = string.Empty;
            foreach (var item in lstDataItem)
            {
                sum += string.Format("sum(case when t.{2}='{0}' then 1 else 0 end) as {1},", enCode == "HazardType" ? item.F_ItemName : item.F_ItemValue, item.F_ItemName, col);
            }
            if (enCode == "HazardType")
                sum = sum.TrimEnd(',');
            else
                sum = sum + string.Format("sum(case when t.{0} is null then 1 else 0 end) as 未知", col);

            string sql = string.Format("select {0} from TBL_HAZARDBASICINFO t", sum);
            //获取行政区划限定条件
            List<string> author = ssoWS.GetAllAuthDistricts();
            string sqlwhere = " where";
            if (author != null && author.Count > 0)
            {
                foreach (var au in author)
                {
                    string temp = au.TrimEnd('0');
                    sqlwhere += string.Format(" t.unifiedcode like '{0}%' or", temp);
                }
                sqlwhere = sqlwhere.Substring(0, sqlwhere.Length - 2);
            }
            return this.BaseRepository().FindTable(sql + sqlwhere);
        }

        /// <summary>
        /// 威胁人口统计
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetWXRKStatisticsJson(string queryJson)
        {
            string strSelect = string.Empty, strWhere = string.Empty, strGroup = string.Empty, strOrder = string.Empty;
            string strType = string.Empty, strCase = string.Empty;
            GetWhere(ref strWhere, ref strGroup, ref strOrder, ref strSelect);
            var queryParam = queryJson.ToJObject();
            string sqlBase = @"select {1} from (select {2} from (select  distinct unifiedcode,THREATENPEOPLE   from tbl_hazardbasicinfo_history where 1=1 ";
            if (queryParam["YEAR"] != null)
            {
                sqlBase += " and " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy") + "=" + queryParam["YEAR"];
            }
            if (queryParam["SelectXZQH"] != null)
            {
                if (queryParam["SelectXZQH"].ToString() != "000000")
                {
                    if (queryParam["SelectXZQH"].ToString().EndsWith("0000"))
                    {
                        sqlBase += " and UNIFIEDCODE like '" + queryParam["SelectXZQH"].ToString().Substring(0, 2) + "%'";
                    }
                    else if (queryParam["SelectXZQH"].ToString().EndsWith("00"))
                    {
                        sqlBase += " and UNIFIEDCODE like '" + queryParam["SelectXZQH"].ToString().Substring(0, 4) + "%'";
                    }
                    else
                    {
                        sqlBase += " and UNIFIEDCODE like '" + queryParam["SelectXZQH"].ToString().Substring(0, 6) + "%'";
                    }
                }

            }
            sqlBase += " {3} ) tt) hazard";
            strType += "sum(范围1) \"<20\",sum(范围2) \"20-50\",sum(范围3) \"50-100\",sum(范围4) \">100\"";
            strCase += "CASE WHEN  THREATENPEOPLE >=0 and THREATENPEOPLE <20 THEN  1  ELSE  0  END 范围1,CASE WHEN  THREATENPEOPLE >=20 and THREATENPEOPLE <50 THEN  1  ELSE  0  END 范围2,CASE WHEN  THREATENPEOPLE >=50 and THREATENPEOPLE <100 THEN  1  ELSE  0  END 范围3,CASE WHEN  THREATENPEOPLE >=100  THEN  1  ELSE  0  END 范围4";
            strType = strType.TrimEnd(',');
            strCase = strCase.TrimEnd(',');
            string sql = string.Format(sqlBase, strSelect, strType, strCase, strWhere, strGroup, strOrder);
            return this.BaseRepository().FindTable(sql);
        }
        /// <summary>
        /// 威胁财产统计
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetWXCCStatisticsJson(string queryJson)
        {
            string strSelect = string.Empty, strWhere = string.Empty, strGroup = string.Empty, strOrder = string.Empty;
            string strType = string.Empty, strCase = string.Empty;
            GetWhere(ref strWhere, ref strGroup, ref strOrder, ref strSelect);
            var queryParam = queryJson.ToJObject();
            string sqlBase = @"select {1} from (select {2} from (select  distinct unifiedcode,THREATENASSETS   from tbl_hazardbasicinfo_history where 1=1 ";
            if (queryParam["YEAR"] != null)
            {
                sqlBase += " and " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy") + "=" + queryParam["YEAR"];
            }
            if (queryParam["SelectXZQH"] != null)
            {
                if (queryParam["SelectXZQH"].ToString() != "000000")
                {
                    if (queryParam["SelectXZQH"].ToString().EndsWith("0000"))
                    {
                        sqlBase += " and UNIFIEDCODE like '" + queryParam["SelectXZQH"].ToString().Substring(0, 2) + "%'";
                    }
                    else if (queryParam["SelectXZQH"].ToString().EndsWith("00"))
                    {
                        sqlBase += " and UNIFIEDCODE like '" + queryParam["SelectXZQH"].ToString().Substring(0, 4) + "%'";
                    }
                    else
                    {
                        sqlBase += " and UNIFIEDCODE like '" + queryParam["SelectXZQH"].ToString().Substring(0, 6) + "%'";
                    }
                }

            }
            sqlBase += " {3} ) tt) hazard";

            strType += "sum(范围1) \"<100\",sum(范围2) \"100-500\",sum(范围3) \"500-1000\",sum(范围4) \">1000\"";
            strCase += "CASE WHEN  THREATENASSETS >=0 and THREATENASSETS <100 THEN  1  ELSE  0  END 范围1,CASE WHEN  THREATENASSETS >=100 and THREATENASSETS <500 THEN  1  ELSE  0  END 范围2,CASE WHEN  THREATENASSETS >=500 and THREATENASSETS <1000 THEN  1  ELSE  0  END 范围3,CASE WHEN  THREATENASSETS >=1000  THEN  1  ELSE  0  END 范围4";
            strType = strType.TrimEnd(',');
            strCase = strCase.TrimEnd(',');
            string sql = string.Format(sqlBase, strSelect, strType, strCase, strWhere, strGroup, strOrder);
            return this.BaseRepository().FindTable(sql);
        }

        public IEnumerable<TBL_HAZARDBASICINFOEntity> PostPageListJsonFirst(Pagination pagination, string queryJson, string condition)
        {
            var result = GetZYPageList(queryJson, condition, pagination).OrderByDescending(t => t.MODIFYTIME);
            String sql = @"select count(*) as total from  tbl_hazardbasicinfo";
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                sql += " where county in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            var data = this.BaseRepository().FindTable(sql);
            pagination.records = data.Rows[0]["total"].ToInt();
            return result;
        }

        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetZYPageList(string queryJson, string condition, Pagination pagination)
        {

            try
            {
                var expression = queryJsonExpression(queryJson);
                List<TBL_HAZARDBASICINFOEntity> result = new List<TBL_HAZARDBASICINFOEntity>();
                var list = new List<TBL_HAZARDBASICINFOEntity>();
                //list = this.BaseRepository().FindList(expression, pagination).Select(t => new TBL_HAZARDBASICINFOEntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID, PROJECTID = t.PROJECTID, DANGERLEVEL = t.DANGERLEVEL, DISASTERLEVEL = t.DISASTERLEVEL, DEATHTOLL = t.DEATHTOLL, ASSETSLOSE = t.ASSETSLOSE, MISSINGPERSON = t.MISSINGPERSON, INJUREDPERSON = t.INJUREDPERSON, THREATENPEOPLE = t.THREATENPEOPLE, THREATENASSETS = t.THREATENASSETS, MODIFYTIME = t.MODIFYTIME == null ? Convert.ToDateTime("1970-01-01") : t.MODIFYTIME }).ToList();
                if (string.IsNullOrEmpty(condition) || condition == "{}")
                {
                    list = this.BaseRepository().FindList(expression, pagination).Select(t => new TBL_HAZARDBASICINFOEntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID, PROJECTID = t.PROJECTID, DANGERLEVEL = t.DANGERLEVEL, DISASTERLEVEL = t.DISASTERLEVEL, DEATHTOLL = t.DEATHTOLL, ASSETSLOSE = t.ASSETSLOSE, MISSINGPERSON = t.MISSINGPERSON, INJUREDPERSON = t.INJUREDPERSON, THREATENPEOPLE = t.THREATENPEOPLE, THREATENASSETS = t.THREATENASSETS, MODIFYTIME = t.MODIFYTIME == null ? Convert.ToDateTime("1970-01-01") : t.MODIFYTIME }).ToList();
                    return list;
                }
                //result = list;
                var queryParam = condition.ToJObject();
                if (!queryParam["WKTString"].IsEmpty())
                {
                    result = this.BaseRepository().FindList(expression, pagination).Select(t => new TBL_HAZARDBASICINFOEntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID, PROJECTID = t.PROJECTID, DANGERLEVEL = t.DANGERLEVEL, DISASTERLEVEL = t.DISASTERLEVEL, DEATHTOLL = t.DEATHTOLL, ASSETSLOSE = t.ASSETSLOSE, MISSINGPERSON = t.MISSINGPERSON, INJUREDPERSON = t.INJUREDPERSON, THREATENPEOPLE = t.THREATENPEOPLE, THREATENASSETS = t.THREATENASSETS, MODIFYTIME = t.MODIFYTIME == null ? Convert.ToDateTime("1970-01-01") : t.MODIFYTIME }).ToList();
                    string WKTString = queryParam["WKTString"].ToString();
                    return result.Where(s => SpatialQueryHelper.isContainPoint(WKTString, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
                    //foreach (var item in list)
                    //{
                    //    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    //    {
                    //        continue;
                    //    }

                    //    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    //    if (isInsert)
                    //    {
                    //        result.Add(item);
                    //    }

                    //}
                    //return result;
                }
                if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
                {
                    double x = queryParam["x"].ToDouble();
                    double y = queryParam["y"].ToDouble();
                    double radius = queryParam["radius"].ToDouble();

                    //var expression1 = LinqExtensions.True<TBL_HAZARDBASICINFOEntity>();
                    ////expression1 = expression1.And(t => t.DISASTERNAME.Contains(txt_Key) || t.UNIFIEDCODE == txt_Key || t.LOCATION.Contains(txt_Key));
                    ////double radius = Convert.ToDouble(condition.radius);
                    ////double x1 = Convert.ToDouble(condition.longitude);
                    ////double y1 = Convert.ToDouble(condition.latitude);
                    //double r = radius / 111.3195;
                    //expression1 = expression1.And<TBL_HAZARDBASICINFOEntity>(t => ((t.LONGITUDE.ToDouble() - x) * (t.LONGITUDE.ToDouble() - x)
                    //+ (t.LATITUDE.ToDouble() - y) * (t.LATITUDE.ToDouble() - y)) <= r * r);

                    //expression = expression.And(expression1);
                    result = this.BaseRepository().FindList(expression, pagination).Select(t => new TBL_HAZARDBASICINFOEntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID, PROJECTID = t.PROJECTID, DANGERLEVEL = t.DANGERLEVEL, DISASTERLEVEL = t.DISASTERLEVEL, DEATHTOLL = t.DEATHTOLL, ASSETSLOSE = t.ASSETSLOSE, MISSINGPERSON = t.MISSINGPERSON, INJUREDPERSON = t.INJUREDPERSON, THREATENPEOPLE = t.THREATENPEOPLE, THREATENASSETS = t.THREATENASSETS, MODIFYTIME = t.MODIFYTIME == null ? Convert.ToDateTime("1970-01-01") : t.MODIFYTIME }).ToList();

                    return result.Where(s => SpatialQueryHelper.PointInCircle(s.LATITUDE.ToDouble(), s.LONGITUDE.ToDouble(), y, x, radius)).ToList();
                    //foreach (var item in list)
                    //{
                    //    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    //    {
                    //        continue;
                    //    }

                    //    bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                    //    if (isInsert)
                    //    {
                    //        result.Add(item);
                    //    }

                    //}
                    //return result;
                }
                if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
                {
                    result = this.BaseRepository().FindList(expression, pagination).Select(t => new TBL_HAZARDBASICINFOEntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID, PROJECTID = t.PROJECTID, DANGERLEVEL = t.DANGERLEVEL, DISASTERLEVEL = t.DISASTERLEVEL, DEATHTOLL = t.DEATHTOLL, ASSETSLOSE = t.ASSETSLOSE, MISSINGPERSON = t.MISSINGPERSON, INJUREDPERSON = t.INJUREDPERSON, THREATENPEOPLE = t.THREATENPEOPLE, THREATENASSETS = t.THREATENASSETS, MODIFYTIME = t.MODIFYTIME == null ? Convert.ToDateTime("1970-01-01") : t.MODIFYTIME }).ToList();
                    string polyline = queryParam["polyline"].ToString();
                    double radius = queryParam["radius"].ToDouble();
                    return result.Where(s => SpatialQueryHelper.IsIntersects(polyline, radius, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
                    //foreach (var item in list)
                    //{
                    //    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    //    {
                    //        continue;
                    //    }

                    //    bool isInsert = SpatialQueryHelper.IsIntersects(polyline, radius, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    //    if (isInsert)
                    //    {
                    //        result.Add(item);
                    //    }

                    //}
                    //return result;
                }
                return list;
                //return this.BaseRepository().FindList(expression).Select(t => new TBL_MONITOROBJECTEntity { MONITOROBJECTID = t.MONITOROBJECTID, MONITORPOINTNAME = t.MONITORPOINTNAME, POINTTYPE = t.POINTTYPE, MEASURETYPE = t.MEASURETYPE, JCDJB = t.JCDJB, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<TBL_HAZARDBASICINFO> GetPageListJsonQCQFSearch_MarkerByInfo(Pagination pagination, string queryJson, string condition, string nsql = null)
        {
            var strWhere = GetWhereSql(queryJson); string sqlw = " ";
            var queryParam1 = queryJson.ToJObject();
            if (!queryParam1["GROUPMONITORINGSTAFF"].IsEmpty())
            {
                string value = queryParam1["GROUPMONITORINGSTAFF"].ToString();
                sqlw += string.Format(" and GROUPMONITORINGSTAFF like '%{0}%'", value);
            }
            List<TBL_HAZARDBASICINFO> result = new List<TBL_HAZARDBASICINFO>();
            string sql = @"select a.* from tbl_hazardbasicinfo a  where unifiedcode in (select unifiedcode from TBL_QCQF_DISASTERPREVENTION "+sqlw+" ) " + strWhere;
            if (!string.IsNullOrEmpty(nsql))
            {
                sql = nsql + strWhere + sqlw;
            }
            var list = new RepositoryFactory().BaseRepository().FindList<TBL_HAZARDBASICINFO>(sql).ToList();
            // result = list.ToList();
            if (string.IsNullOrEmpty(condition) || condition == "{}")
            {
                return list;
            }
            var queryParam = condition.ToJObject();
            //if (!queryParam["WKTString"].IsEmpty())
            //{
            //    string WKTString = queryParam["WKTString"].ToString();
            //    return result.Where(s => SpatialQueryHelper.isContainPoint(WKTString, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
            //}
            //if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            //{
            //    double x = queryParam["x"].ToDouble();
            //    double y = queryParam["y"].ToDouble();
            //    double radius = queryParam["radius"].ToDouble();
            //    return result.Where(s => SpatialQueryHelper.PointInCircle(s.LATITUDE.ToDouble(), s.LONGITUDE.ToDouble(), y, x, radius)).ToList();
            //}
            //if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
            //{
            //    string polyline = queryParam["polyline"].ToString();
            //    double radius = queryParam["radius"].ToDouble();
            //    return result.Where(s => SpatialQueryHelper.IsIntersects(polyline, radius, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
            //}
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LONGITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        result.Add(item);
                    }

                }
                pagination.records = result.Count;
                return result;
            }
            if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                double x = queryParam["x"].ToDouble();
                double y = queryParam["y"].ToDouble();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LONGITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                    if (isInsert)
                    {
                        result.Add(item);
                    }

                }
                pagination.records = result.Count;
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
                pagination.records = result.Count;
                return result;
            }
            return list;

        }

        /// <summary>
        /// 行政责任人浏览查询群测群防信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <param name="nsql"></param>
        public IEnumerable<TBL_HAZARDBASICINFO> GetListJsonQCQFInfo(string queryJson, string condition, string nsql = null)
        {
            var strWhere = GetWhereSql(queryJson);
            List<TBL_HAZARDBASICINFO> result = new List<TBL_HAZARDBASICINFO>();
            string sql = @"select a.* from tbl_hazardbasicinfo a  where unifiedcode in (select unifiedcode from TBL_QCQF_DISASTERPREVENTION) " + strWhere;
            if (!string.IsNullOrEmpty(nsql))
            {
                sql = nsql + strWhere;
            }
            var list = new RepositoryFactory().BaseRepository().FindList<TBL_HAZARDBASICINFO>(sql);
            if (string.IsNullOrEmpty(condition) || condition == "{}")
            {
                return list;
            }
            result = list.ToList();
            var queryParam = condition.ToJObject();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                return result.Where(s => SpatialQueryHelper.isContainPoint(WKTString, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
            }
            if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                double x = queryParam["x"].ToDouble();
                double y = queryParam["y"].ToDouble();
                double radius = queryParam["radius"].ToDouble();
                return result.Where(s => SpatialQueryHelper.PointInCircle(s.LATITUDE.ToDouble(), s.LONGITUDE.ToDouble(), y, x, radius)).ToList();
            }
            if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                string polyline = queryParam["polyline"].ToString();
                double radius = queryParam["radius"].ToDouble();
                return result.Where(s => SpatialQueryHelper.IsIntersects(polyline, radius, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
            }
            return list;

        }

        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJsonQCQFSearch_Marker(Pagination pagination, string queryJson, string condition, string nsql = null)
        {
            var strWhere = GetWhereSql(queryJson);
            List<TBL_HAZARDBASICINFOEntity> result = new List<TBL_HAZARDBASICINFOEntity>();
            string sql = @"select a.* from tbl_hazardbasicinfo a  where unifiedcode in (select unifiedcode from TBL_QCQF_DISASTERPREVENTION) " + strWhere;
            if (!string.IsNullOrEmpty(nsql))
            {
                sql = nsql + strWhere;
            }
            var list = new RepositoryFactory().BaseRepository().FindList<TBL_HAZARDBASICINFOEntity>(sql, pagination);
            if (string.IsNullOrEmpty(condition) || condition == "{}")
            {
                return list;
            }
            var queryParam = condition.ToJObject();
            result = list.ToList();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                return result.Where(s => SpatialQueryHelper.isContainPoint(WKTString, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
                //foreach (var item in list)
                //{
                //    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                //    {
                //        continue;
                //    }

                //    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                //    if (isInsert)
                //    {
                //        result.Add(item);
                //    }

                //}
                //return result;
            }
            if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                double x = queryParam["x"].ToDouble();
                double y = queryParam["y"].ToDouble();
                double radius = queryParam["radius"].ToDouble();
                return result.Where(s => SpatialQueryHelper.PointInCircle(s.LATITUDE.ToDouble(), s.LONGITUDE.ToDouble(), y, x, radius)).ToList();
                //foreach (var item in list)
                //{
                //    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                //    {
                //        continue;
                //    }

                //    bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                //    if (isInsert)
                //    {
                //        result.Add(item);
                //    }
                //}
                //return result;
            }
            if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                string polyline = queryParam["polyline"].ToString();
                double radius = queryParam["radius"].ToDouble();
                return result.Where(s => SpatialQueryHelper.IsIntersects(polyline, radius, s.LONGITUDE.ToString(), s.LATITUDE.ToString())).ToList();
                //foreach (var item in list)
                //{
                //    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                //    {
                //        continue;
                //    }

                //    bool isInsert = SpatialQueryHelper.IsIntersects(polyline, radius, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                //    if (isInsert)
                //    {
                //        result.Add(item);
                //    }

                //}
                //return result;
            }
            return list;

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
            // returnValue += " and a.isxh = '0' ";//默认查询没有销号的点

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
            //地理位置
            if (!queryParam["LOCATION"].IsEmpty())
            {
                string value = queryParam["LOCATION"].ToString();
                returnValue += string.Format(" and a.LOCATION like '%{0}%' ", value);
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
            //乡镇
            if (!queryParam["TOWN"].IsEmpty())
            {
                string[] value = queryParam["TOWN"].ToString().Split(',');
                returnValue += " and a.TOWN LIKE  '%" + string.Join("','", value.ToArray()) + "%'";
            }
            //数据范围权限过滤
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                returnValue += " and a.COUNTY in(" + string.Join(",", _codes) + ")";
            }
            return returnValue;
        }
        #region MyRegion
        public string GetZHDCountResult(string queryJson, int type)
        {
            var jobj = queryJson.ToJObject();
            //第一步获取行政区划
            //LocationHelper.GetDistricts();

            //第二步请求统计数据并整理成可用直接调用的数据形式
            DataTable entity = new DataTable();
            if (type == 1)
            {
                entity = GetAnalyseList(queryJson);
            }
            if (type == 2)
            {
                entity = GetAnalyseListPC(queryJson);
            }

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
            if (entity.Columns.Contains("zhd"))
            {
                if (jobj["zhd"].ToString() == "1")
                {
                    entity.Columns["zhd"].ColumnName = "灾害点总计";
                }
                else
                {
                    entity.Columns.Remove("zhd");
                }
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

            string[] strArr = new[] { "yhdzhlx", "zhlx" };
            foreach (var item in strArr)
            {
                string strName = "";
                bool flag = false;//区分灾害点和隐患点
                if (item == "yhdzhlx")
                {
                    strName = "yhd";
                    if (jobj["yhd"].ToString() == "1" && jobj["zhlx"].ToString() == "1")
                        flag = true;
                }
                else if (item == "zhlx")
                {
                    strName = "";
                    if (jobj["zhd"].ToString() == "1" && jobj["zhlx"].ToString() == "1")
                        flag = true;
                }

                if (flag)
                {
                    entity.Columns[strName + "hp"].ColumnName = "滑坡";
                    entity.Columns[strName + "bt"].ColumnName = "崩塌";
                    entity.Columns[strName + "xp"].ColumnName = "斜坡";
                    entity.Columns[strName + "nsl"].ColumnName = "泥石流";
                    entity.Columns[strName + "dmcj"].ColumnName = "地面沉降";
                    entity.Columns[strName + "dlf"].ColumnName = "地裂缝";
                    entity.Columns[strName + "dmtx"].ColumnName = "地面塌陷";
                    var disasterType = jobj["DISASTERTYPE"].ToString();
                    if (disasterType != "")
                    {
                        if ("滑坡" != disasterType)
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
                    entity.Columns.Remove(strName + "hp");
                    entity.Columns.Remove(strName + "bt");
                    entity.Columns.Remove(strName + "xp");
                    entity.Columns.Remove(strName + "nsl");
                    entity.Columns.Remove(strName + "dmcj");
                    entity.Columns.Remove(strName + "dlf");
                    entity.Columns.Remove(strName + "dmtx");
                }
            }




            if (jobj["zq"].ToString() == "1")
            {
                entity.Columns["zqxx"].ColumnName = "灾情小型";
                entity.Columns["zqzx"].ColumnName = "灾情中型";
                entity.Columns["zqdx"].ColumnName = "灾情大型";
                entity.Columns["zqtdx"].ColumnName = "灾情特大型";
                var disasterLevel = jobj["DISASTERLEVEL"].ToString();
                if (disasterLevel != "")
                {
                    if ("灾情小型" != disasterLevel)
                    {
                        entity.Columns.Remove("灾情小型");
                    }
                    if ("灾情中型" != disasterLevel)
                    {
                        entity.Columns.Remove("灾情中型");
                    }
                    if ("灾情大型" != disasterLevel)
                    {
                        entity.Columns.Remove("灾情大型");
                    }
                    if ("灾情特大型" != disasterLevel)
                    {
                        entity.Columns.Remove("灾情特大型");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("zqxx");
                entity.Columns.Remove("zqzx");
                entity.Columns.Remove("zqdx");
                entity.Columns.Remove("zqtdx");
            }

            if (jobj["xq"].ToString() == "1")
            {
                entity.Columns["xqxx"].ColumnName = "险情小型";
                entity.Columns["xqzx"].ColumnName = "险情中型";
                entity.Columns["xqdx"].ColumnName = "险情大型";
                entity.Columns["xqtdx"].ColumnName = "险情特大型";
                var dangerLevel = jobj["DANGERLEVEL"].ToString();
                if (dangerLevel != "")
                {
                    if ("险情小型" != dangerLevel)
                    {
                        entity.Columns.Remove("险情小型");
                    }
                    if ("险情中型" != dangerLevel)
                    {
                        entity.Columns.Remove("险情中型");
                    }
                    if ("险情大型" != dangerLevel)
                    {
                        entity.Columns.Remove("险情大型");
                    }
                    if ("险情特大型" != dangerLevel)
                    {
                        entity.Columns.Remove("险情特大型");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("xqxx");
                entity.Columns.Remove("xqzx");
                entity.Columns.Remove("xqdx");
                entity.Columns.Remove("xqtdx");
            }


            if (jobj["jc"].ToString() == "1")
            {
                entity.Columns["jcms"].ColumnName = "定期目视监测";
                entity.Columns["jcss"].ColumnName = "监测建议";
                entity.Columns["jcdm"].ColumnName = "地面位移监测";
                entity.Columns["jcsb"].ColumnName = "深部位移监测";
                var MONITORSUGGESTION = jobj["MONITORSUGGESTION"].ToString();
                if (MONITORSUGGESTION != "")
                {
                    if ("定期目视监测" != MONITORSUGGESTION)
                    {
                        entity.Columns.Remove("定期目视监测");
                    }
                    if ("监测建议" != MONITORSUGGESTION)
                    {
                        entity.Columns.Remove("监测建议");
                    }
                    if ("地面位移监测" != MONITORSUGGESTION)
                    {
                        entity.Columns.Remove("地面位移监测");
                    }
                    if ("深部位移监测" != MONITORSUGGESTION)
                    {
                        entity.Columns.Remove("深部位移监测");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("jcms");
                entity.Columns.Remove("jcss");
                entity.Columns.Remove("jcdm");
                entity.Columns.Remove("jcsb");
            }
            if (jobj["fz"].ToString() == "1")
            {
                entity.Columns["fzqcqf"].ColumnName = "定期目视监测";
                entity.Columns["fzzyjc"].ColumnName = "监测建议";
                entity.Columns["fzbrbq"].ColumnName = "地面位移监测";
                entity.Columns["fzgczl"].ColumnName = "深部位移监测";
                var TREATMENTSUGGESTION = jobj["TREATMENTSUGGESTION"].ToString();
                if (TREATMENTSUGGESTION != "")
                {
                    if ("群测群防" != TREATMENTSUGGESTION)
                    {
                        entity.Columns.Remove("群测群防");
                    }
                    if ("专业监测" != TREATMENTSUGGESTION)
                    {
                        entity.Columns.Remove("专业监测");
                    }
                    if ("搬迁避让" != TREATMENTSUGGESTION)
                    {
                        entity.Columns.Remove("搬迁避让");
                    }
                    if ("工程治理" != TREATMENTSUGGESTION)
                    {
                        entity.Columns.Remove("工程治理");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("fzqcqf");
                entity.Columns.Remove("fzzyjc");
                entity.Columns.Remove("fzbrbq");
                entity.Columns.Remove("fzgczl");
            }

            if (jobj["mq"].ToString() == "1")
            {
                entity.Columns["mqwd"].ColumnName = "目前稳定";
                entity.Columns["mqqzbwd"].ColumnName = "目前基本稳定";
                entity.Columns["mqbwd"].ColumnName = "目前不稳定";
                var mqStatus = jobj["CURRENTSTABLESTATUS"].ToString();
                if (mqStatus != "")
                {
                    if ("A" != mqStatus)
                    {
                        entity.Columns.Remove("目前稳定");
                    }
                    if ("B" != mqStatus)
                    {
                        entity.Columns.Remove("目前基本稳定");
                    }
                    if ("C" != mqStatus)
                    {
                        entity.Columns.Remove("目前不稳定");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("mqwd");
                entity.Columns.Remove("mqqzbwd");
                entity.Columns.Remove("mqbwd");
            }
            if (jobj["jh"].ToString() == "1")
            {
                entity.Columns["jhwd"].ColumnName = "今后稳定";
                entity.Columns["jhqzbwd"].ColumnName = "今后基本稳定";
                entity.Columns["jhbwd"].ColumnName = "今后不稳定";
                var jhStatus = jobj["STABLETREND"].ToString();
                if (jhStatus != "")
                {
                    if ("A" != jhStatus)
                    {
                        entity.Columns.Remove("目前稳定");
                    }
                    if ("B" != jhStatus)
                    {
                        entity.Columns.Remove("目前基本稳定");
                    }
                    if ("C" != jhStatus)
                    {
                        entity.Columns.Remove("目前不稳定");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("jhwd");
                entity.Columns.Remove("jhqzbwd");
                entity.Columns.Remove("jhbwd");
            }
            if (jobj["wh"].ToString() == "1")
            {
                entity.Columns["hhfw"].ColumnName = "损坏房屋";
                entity.Columns["hl"].ColumnName = "毁路";
                entity.Columns["hq"].ColumnName = "毁渠";
            }
            else
            {
                entity.Columns.Remove("hhfw");
                entity.Columns.Remove("hl");
                entity.Columns.Remove("hq");
            }
            if (jobj["wx"].ToString() == "1")
            {
                entity.Columns["wxcc"].ColumnName = "威胁财产";
                entity.Columns["wxrk"].ColumnName = "威胁人口";
            }
            else
            {
                entity.Columns.Remove("wxcc");
                entity.Columns.Remove("wxrk");
            }

            //if (entity.Columns.Contains("hpyh"))
            //{
            //    entity.Columns.Remove("hpyh");

            //}
            //if (entity.Columns.Contains("btyh"))
            //{
            //    entity.Columns.Remove("btyh");
            //}

            entity.Columns.Remove("id");
            entity.Columns.Remove("level");
            entity.Columns.Remove("parent_field");
            entity.Columns.Remove("isLeaf");
            entity.Columns.Remove("expanded");
            entity.Columns.Remove("area");

            //entity.Columns.Remove("jcms");
            //entity.Columns.Remove("jcss");
            //entity.Columns.Remove("jcdm");
            //entity.Columns.Remove("jcsb");
            //entity.Columns.Remove("fzqcqf");
            //entity.Columns.Remove("fzzyjc");
            //entity.Columns.Remove("fzbrbq");
            //entity.Columns.Remove("fzgczl");

            //if (jobj["level"].ToString() == "县")
            //{
            //    entity.Columns.Remove("市");
            //    entity.Columns.Remove("省");
            //}
            //else if (jobj["level"].ToString() == "市")
            //{
            //    entity.Columns.Remove("县");
            //    entity.Columns.Remove("省");
            //}
            //else if (jobj["level"].ToString() == "省")
            //{
            //    entity.Columns.Remove("县");
            //    entity.Columns.Remove("市");
            //}

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
        #region 获取TBL_HAZARDBASICINFO_HISTORY表数据
        public EchartEntity GetStatisticsByZHLX(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<string> selectXZQH = new List<string>();
            string DefalutCode = queryParam["SelectXZQH"].ToString();// System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
            int subLength = 2;
            if (queryParam["SelectXZQH"].ToString().EndsWith("000000"))
            {

                DefalutCode = "0";
                subLength = 2;
            }
            else if (queryParam["SelectXZQH"].ToString().EndsWith("0000"))
            {
                subLength = 4;
            }
            else if (queryParam["SelectXZQH"].ToString().EndsWith("00"))
            {
                subLength = 6;
            }
            else
            {
                subLength = 9;
            }
            DataItemDetailService dataItemDetail = new DataItemDetailService();
            Dictionary<string, string> dicList = new Dictionary<string, string>();
            IList<DataItemDetailEntity> dicList2 = serviceDataItem.GetItemDetailList("HazardType").ToList();

            IList<string> dataItemDetailList = dicList2.Select(p => p.F_ItemName).ToList();
            dicList = dicList2.ToDictionary(p => p.F_ItemValue, p => p.F_ItemName);
            List<ParetEntity> districts = ssoWS.GetDistrictByParent(DefalutCode);
            selectXZQH = districts.Select(p => p.DistrictCode).ToList();
            string strSql = "";
            if (string.IsNullOrWhiteSpace(queryJson))
            {
                queryJson = "{}";
            }
            string sqlReturnWhere = "";
            for (int i = 0; i < dicList.Count; i++)
            {
                var item = dicList.ElementAt(i);
                if (i == 0)
                {
                    sqlReturnWhere = " and DISASTERTYPE='" + item.Value + "'";
                    if (queryParam["TYPE"].ToString() == "灾害点")
                    {
                        strSql += GetSqls(subLength, item.Value, districts, sqlReturnWhere, queryJson);
                    }
                    else
                    {
                        strSql += GetSqlHistory(subLength, item.Value, districts, sqlReturnWhere, queryJson);
                    }
                }
                else
                {
                    sqlReturnWhere = " and DISASTERTYPE='" + item.Value + "'";
                    if (queryParam["TYPE"].ToString() == "灾害点")
                    {
                        strSql += " union all " + GetSqls(subLength, item.Value, districts, sqlReturnWhere, queryJson);
                    }
                    else
                    {
                        strSql += " union all " + GetSqlHistory(subLength, item.Value, districts, sqlReturnWhere, queryJson);
                    }
                }
            }

            EchartEntity returnValue = new EchartEntity();
            returnValue.columnList = districts.Select(p => p.DistrictName).ToList();//查询列名称
            returnValue.dataList = convertDataTable(this.BaseRepository().FindTable(strSql), dataItemDetailList);
            return returnValue;
        }

        public DataTable GetHistoryStatisticsZHD(string queryJson, ref EchartEntity returnValue)
        {
            var queryParam = queryJson.ToJObject();
            List<string> selectXZQH = new List<string>();
            string DefalutCode = queryParam["SelectXZQH"].ToString();// System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
            string XZQHLEVEL = "省";
            int subLength = 2;
            if (queryParam["SelectXZQH"].ToString().EndsWith("000000"))
            {
                DefalutCode = "0";
                subLength = 2;
            }
            else if (queryParam["SelectXZQH"].ToString().EndsWith("0000"))
            {
                subLength = 4;
            }
            else if (queryParam["SelectXZQH"].ToString().EndsWith("00"))
            {
                subLength = 6;
            }
            else
            {
                subLength = 9;
            }
            List<ParetEntity> districts = ssoWS.GetDistrictByParent(DefalutCode);
            selectXZQH = districts.Select(p => p.DistrictCode).ToList();
            string strSql = "";
            string sqlWhere = "";
            if (string.IsNullOrWhiteSpace(queryJson))
            {
                queryJson = "{}";
            }
            string sqlReturnWhere = "";
            strSql += GetSqlHistory(subLength, "", districts, sqlReturnWhere, queryJson);
            returnValue.columnList = districts.Select(p => p.DistrictCode).ToList();//查询列名称
            return this.BaseRepository().FindTable(strSql);
        }

        public DataTable GetTypeStatistics(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<string> selectXZQH = new List<string>();
            string DefalutCode = queryParam["SelectXZQH"].ToString();// System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
            string XZQHLEVEL = "省";
            int subLength = 2;
            if (queryParam["SelectXZQH"].ToString().EndsWith("000000"))
            {
                DefalutCode = "0";
                subLength = 2;
            }
            else if (queryParam["SelectXZQH"].ToString().EndsWith("0000"))
            {
                subLength = 4;
            }
            else if (queryParam["SelectXZQH"].ToString().EndsWith("00"))
            {
                subLength = 6;
            }
            else
            {
                subLength = 9;
            }
            selectXZQH = ssoWS.GetAreaListJson(DefalutCode).Select(p => p.F_AreaCode).ToList();
            //List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).Where(p => selectXZQH.Contains(p.F_AreaCode)).ToList();
            List<ParetEntity> districts = ssoWS.GetDistrictByParent(DefalutCode);
            selectXZQH = districts.Select(p => p.DistrictCode).ToList();
            string strSql = "";
            string sqlWhere = "";
            if (string.IsNullOrWhiteSpace(queryJson))
            {
                queryJson = "{}";
            }
            string sqlReturnWhere = "";
            sqlReturnWhere = " and MODIFYTYPE='A'";
            strSql += GetSqlHistory(subLength, "新增", districts, sqlReturnWhere, queryJson);
            sqlReturnWhere = " and MODIFYTYPE='U'";
            strSql += " union all " + GetSqlHistory(subLength, "更新", districts, sqlReturnWhere, queryJson);
            sqlReturnWhere = " and ISXH='1' and MODIFYTYPE!='R'";
            strSql += " union all " + GetSqlHistory(subLength, "销号", districts, sqlReturnWhere, queryJson);
            return this.BaseRepository().FindTable(strSql);
        }

        public DataTable GetStatisticsByZHLX2(string queryJson)
        {
            string strSelect = string.Empty, strWhere = string.Empty, strGroup = string.Empty, strOrder = string.Empty;
            string strType = string.Empty, strCase = string.Empty;
            GetWhere(ref strWhere, ref strGroup, ref strOrder, ref strSelect);
            var queryParam = queryJson.ToJObject();
            string sqlBase = @"select {1} from (select {2} from (select  distinct unifiedcode,DISASTERTYPE   from tbl_hazardbasicinfo_history where 1=1 ";
            if (queryParam["YEAR"] != null)
            {
                sqlBase += " and " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy") + "=" + queryParam["YEAR"];
            }
            if (queryParam["SelectXZQH"] != null)
            {
                if (queryParam["SelectXZQH"].ToString() != "000000")
                {
                    if (queryParam["SelectXZQH"].ToString().EndsWith("0000"))
                    {
                        sqlBase += " and UNIFIEDCODE like '" + queryParam["SelectXZQH"].ToString().Substring(0, 2) + "%'";
                    }
                    else if (queryParam["SelectXZQH"].ToString().EndsWith("00"))
                    {
                        sqlBase += " and UNIFIEDCODE like '" + queryParam["SelectXZQH"].ToString().Substring(0, 4) + "%'";
                    }
                    else
                    {
                        sqlBase += " and UNIFIEDCODE like '" + queryParam["SelectXZQH"].ToString().Substring(0, 6) + "%'";
                    }
                }

            }
            sqlBase += " {3} ) tt) hazard";
            IEnumerable<DataItemDetailEntity> ls = serviceDataItem.GetItemDetailList("HazardType");
            foreach (var v in ls)
            {
                strType += "sum(hazard." + v.F_ItemName + ") " + v.F_ItemName + ",";
                strCase += "CASE WHEN " + "DISASTERTYPE" + " = '" + v.F_ItemName + "' THEN  1  ELSE  0  END " + v.F_ItemName + ",";
            }
            strType = strType.TrimEnd(',');
            strCase = strCase.TrimEnd(',');
            string sql = string.Format(sqlBase, strSelect, strType, strCase, strWhere, strGroup, strOrder);
            return this.BaseRepository().FindTable(sql);
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
        public void SaveForm(string keyValue, TBL_HAZARDBASICINFOEntity entity)
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
        /// <summary>
        /// 根据sql语句执行更新
        /// </summary>
        /// <param name="sql"></param>
        public void UpdateForm(string sql)
        {
            IRepository db = new RepositoryFactory().BaseRepository();
            db.ExecuteBySql(sql);
        }
        #endregion

        #region 辅助函数

        /// <summary>
        /// 把查询浏览页面上的通用json条件转换成linq语句
        /// </summary>
        /// <param name="queryJson">json参数</param>
        /// <returns></returns>
        System.Linq.Expressions.Expression<Func<TBL_HAZARDBASICINFOEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_HAZARDBASICINFOEntity>();
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                var expression1 = LinqExtensions.False<TBL_HAZARDBASICINFOEntity>();
                #region 省市县级联条件
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
                            string code = string.Empty;
                            //code = json.AreaCode;
                            code = json.PROVINCE;
                            //code = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
                            if (code == "0" || code == "" || code == null)
                            {

                            }

                            else if (!string.IsNullOrEmpty(code))
                            {
                                foreach (var ton in code.Split(','))
                                {
                                    expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                                }
                                expression = expression.And(expression1);
                            }
                        }
                    }
                }
                #endregion

                #region 省市县名称筛选条件

                string PROVINCENAME = "";
                string CITYNAME = "";
                string COUNTYNAME = "";
                if (json.PROVINCENAME != "" && json.PROVINCENAME != null)
                {
                    PROVINCENAME = json.PROVINCENAME;
                }
                if (!string.IsNullOrEmpty(PROVINCENAME))
                {
                    if (PROVINCENAME.Contains(","))
                    {
                        var expressionA = LinqExtensions.False<TBL_HAZARDBASICINFOEntity>();
                        string[] PROVINCENAME_S = PROVINCENAME.Split(',');
                        for (int i = 0; i < PROVINCENAME_S.Count(); i++)
                        {
                            string PROVINCENAME_i = PROVINCENAME_S[i];
                            expressionA = expressionA.Or(t => t.PROVINCENAME.Contains(PROVINCENAME_i));
                        }
                        expression = expression.And(expressionA);

                    }
                    else
                    {
                        expression = expression.And(t => t.PROVINCENAME.Contains(PROVINCENAME));
                    }
                    //expression = expression.And(t => t.PROVINCENAME.Contains(PROVINCENAME));
                }
                if (json.CITYNAME != "" && json.CITYNAME != null)
                {
                    CITYNAME = json.CITYNAME;
                }
                if (!string.IsNullOrEmpty(CITYNAME))
                {
                    if (CITYNAME.Contains(","))
                    {
                        var expressionA = LinqExtensions.False<TBL_HAZARDBASICINFOEntity>();
                        string[] CITYNAME_S = CITYNAME.Split(',');
                        for (int i = 0; i < CITYNAME_S.Count(); i++)
                        {
                            string CITYNAME_i = CITYNAME_S[i];
                            expressionA = expressionA.Or(t => t.CITYNAME.Contains(CITYNAME_i));
                        }
                        expression = expression.And(expressionA);

                    }
                    else
                    {
                        expression = expression.And(t => t.CITYNAME.Contains(CITYNAME));
                    }

                }
                if (json.COUNTYNAME != "" && json.COUNTYNAME != null)
                {
                    COUNTYNAME = json.COUNTYNAME;
                }
                if (!string.IsNullOrEmpty(COUNTYNAME))
                {
                    if (COUNTYNAME.Contains(","))
                    {
                        var expressionB = LinqExtensions.False<TBL_HAZARDBASICINFOEntity>();
                        string[] COUNTYNAMEE_S = COUNTYNAME.Split(',');
                        for (int i = 0; i < COUNTYNAMEE_S.Count(); i++)
                        {
                            string COUNTYNAMEE_i = COUNTYNAMEE_S[i];
                            expressionB = expressionB.Or(t => t.COUNTYNAME.Contains(COUNTYNAMEE_i));
                        }
                        expression = expression.And(expressionB);
                    }
                    else
                    {
                        expression = expression.And(t => t.COUNTYNAME.Contains(COUNTYNAME));
                    }
                }

                #endregion

                //关键字
                string txt_Key = json.txt_Key;
                if (!string.IsNullOrEmpty(txt_Key))
                {
                    expression = expression.And(t => t.DISASTERNAME.Contains(txt_Key) || t.UNIFIEDCODE == txt_Key || t.LOCATION.Contains(txt_Key));
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


                //是否隐患点
                string HIDDENDANGER = json.HIDDENDANGER;
                if (!string.IsNullOrEmpty(HIDDENDANGER))
                {
                    expression = expression.And(t => t.HIDDENDANGER.Equals(HIDDENDANGER));
                }
                // 重要隐患点
                string zhlxNew = json.ZHDLX;
                if (!string.IsNullOrEmpty(zhlxNew))
                {
                    if (zhlxNew.ToString() == "1")
                    {
                        expression = expression.And(t => t.ISZDYHD.Equals(zhlxNew));
                    }
                    else if (zhlxNew.ToString() == "2")
                    {
                        var a1 = 1000;
                        expression = expression.And(t => t.THREATENPEOPLE > a1 && t.ISZDYHD == "1");
                    }
                }
                //灾害等级
                string DISASTERLEVEL = json.DISASTERLEVEL;
                if (!string.IsNullOrEmpty(DISASTERLEVEL))
                {
                    expression = expression.And(t => t.DISASTERLEVEL.Equals(DISASTERLEVEL));
                }

                //险情等级
                string DANGERLEVEL = json.DANGERLEVEL;
                if (!string.IsNullOrEmpty(DANGERLEVEL))
                {
                    expression = expression.And(t => t.DANGERLEVEL.Equals(DANGERLEVEL));
                }

                //目前稳定程度
                string CURSTABLESTATUS = json.CURSTABLESTATUS;
                if (!string.IsNullOrEmpty(CURSTABLESTATUS))
                {
                    expression = expression.And(t => t.CURSTABLESTATUS.Equals(CURSTABLESTATUS));
                }

                //今后发展趋势
                string STABLETREND = json.STABLETREND;
                if (!string.IsNullOrEmpty(STABLETREND))
                {
                    expression = expression.And(t => t.STABLETREND.Equals(STABLETREND));
                }

                //防治建议
                string TREATMENTSUGGESTION = json.TREATMENTSUGGESTION;
                if (!string.IsNullOrEmpty(TREATMENTSUGGESTION))
                {
                    expression = expression.And(t => t.TREATMENTSUGGESTION.Equals(TREATMENTSUGGESTION));
                }

                //监测建议
                string MONITORSUGGESTION = json.MONITORSUGGESTION;
                if (!string.IsNullOrEmpty(MONITORSUGGESTION))
                {
                    expression = expression.And(t => t.MONITORSUGGESTION.Equals(MONITORSUGGESTION));
                }

                //威胁人口开始
                string THREATENPEOPLEBEGIN = json.THREATENPEOPLEBEGIN;
                if (!string.IsNullOrEmpty(THREATENPEOPLEBEGIN))
                {
                    int i1 = Convert.ToInt32(THREATENPEOPLEBEGIN);
                    expression = expression.And(t => t.THREATENPEOPLE >= i1);
                }

                //威胁人口结束
                string THREATENPEOPLEEND = json.THREATENPEOPLEEND;
                if (!string.IsNullOrEmpty(THREATENPEOPLEEND))
                {
                    int i1 = Convert.ToInt32(THREATENPEOPLEEND);
                    expression = expression.And(t => t.THREATENPEOPLE <= i1);
                }

                //威胁财产开始
                string THREATENASSETSBEGIN = json.THREATENASSETSBEGIN;
                if (!string.IsNullOrEmpty(THREATENASSETSBEGIN))
                {
                    int i1 = Convert.ToInt32(THREATENASSETSBEGIN);
                    expression = expression.And(t => t.THREATENASSETS >= i1);
                }

                //威胁财产结束
                string THREATENASSETSEND = json.THREATENASSETSEND;
                if (!string.IsNullOrEmpty(THREATENASSETSEND))
                {
                    int i1 = Convert.ToInt32(THREATENASSETSEND);
                    expression = expression.And(t => t.THREATENASSETS <= i1);
                }

                //死亡人口开始
                string DEATHTOLLBEGIN = json.DEATHTOLLBEGIN;
                if (!string.IsNullOrEmpty(DEATHTOLLBEGIN))
                {
                    int i1 = Convert.ToInt32(DEATHTOLLBEGIN);
                    expression = expression.And(t => t.DEATHTOLL >= i1);
                }

                //死亡人口结束
                string DEATHTOLLEND = json.DEATHTOLLEND;
                if (!string.IsNullOrEmpty(DEATHTOLLEND))
                {
                    int i1 = Convert.ToInt32(DEATHTOLLEND);
                    expression = expression.And(t => t.DEATHTOLL <= i1);
                }
           
                //财产损失开始
                string ASSETSLOSEBEGIN = json.ASSETSLOSEBEGIN;
                if (!string.IsNullOrEmpty(ASSETSLOSEBEGIN))
                {
                    int i1 = Convert.ToInt32(ASSETSLOSEBEGIN);
                    expression = expression.And(t => t.ASSETSLOSE >= i1);
                }

                //财产损失结束
                string ASSETSLOSEEND = json.ASSETSLOSEEND;
                if (!string.IsNullOrEmpty(ASSETSLOSEEND))
                {
                    int i1 = Convert.ToInt32(ASSETSLOSEEND);
                    expression = expression.And(t => t.ASSETSLOSE <= i1);
                }
                //地理位置
                string LOCATION = json.LOCATION;
                if (!string.IsNullOrEmpty(LOCATION))
                {
                    expression = expression.And(t => t.PROVINCENAME.Contains(LOCATION) || t.LOCATION.Contains(LOCATION) || t.COUNTYNAME.Contains(LOCATION) || t.TOWNNAME.Contains(LOCATION) || t.CITYNAME.Contains(LOCATION));
                }
                //开始时间结束时间
                if (json.BQBRSTARTTIME != "" && json.BQBRSTARTTIME != null)
                {
                    DateTime BQBRSTARTTIME = json.BQBRSTARTTIME;
                    DateTime BQBRENDTIME = json.BQBRENDTIME;
                    //expression = expression.And(t => (BQBRSTARTTIME.CompareTo(t.MODIFYTIME.Value) <= 0) || (BQBRENDTIME.CompareTo(t.MODIFYTIME.Value) >= 0));
                    expression = expression.And(t => (t.MODIFYTIME >= BQBRSTARTTIME && t.MODIFYTIME <= BQBRENDTIME));
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
                //未销号数据
                //expression = expression.And(t => t.ISXH.Equals("0"));
                //行政区划账号权限筛选
                string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
                SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
                //筛选，获取授权的行政区划
                List<string> author = ws.GetAllAuthDistricts();
                if (author != null && author.Count > 0)
                {
                    var expression2 = LinqExtensions.False<TBL_HAZARDBASICINFOEntity>();
                    bool flag = false;
                    if (!author.Contains("000000"))
                    {
                        expression2 = expression2.Or(testc => author.Contains(testc.COUNTY));
                        flag = true;
                    }
                    if (flag)
                    {
                        expression = expression.And(expression2);
                    }
                }

                //新加数据规模限制bychang
                string DATASOURCE = json.DATASOURCE;
                if (!string.IsNullOrEmpty(DATASOURCE))
                {
                    expression = expression.And(t => t.DATASOURCE.Equals(DATASOURCE));
                }
            }

            return expression;
        }

        /// <summary> 
        /// 泛型集合转换DataSet 
        /// </summary> 
        /// <typeparam name="T"></typeparam> 
        /// <param name="list">泛型集合</param> 
        /// <returns></returns> 
        /// 2008-08-01 22:43 HPDV2806 
        public static DataSet ToDataSet<T>(List<T> list)
        {
            return ToDataSet<T>(list, null);
        }


        /// <summary> 
        /// 泛型集合转换DataSet,并指定需要转换的字段
        /// </summary> 
        /// <typeparam name="T"></typeparam> 
        /// <param name="p_List">泛型集合</param> 
        /// <param name="p_PropertyName">待转换属性名数组</param> 
        /// <returns></returns> 
        /// 2008-08-01 22:44 HPDV2806 
        public static DataSet ToDataSet<T>(List<T> p_List, params string[] p_PropertyName)
        {
            List<string> propertyNameList = new List<string>();
            if (p_PropertyName != null)
                propertyNameList.AddRange(p_PropertyName);

            DataSet result = new DataSet();
            DataTable _DataTable = new DataTable();
            if (p_List.Count > 0)
            {
                Type type = typeof(T);
                PropertyInfo[] propertys = type.GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        // 没有指定属性的情况下全部属性都要转换 
                        _DataTable.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                            _DataTable.Columns.Add(pi.Name, pi.PropertyType);
                    }
                }

                for (int i = 0; i < p_List.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(p_List[i], null);
                            tempList.Add(obj);
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(p_List[i], null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    _DataTable.LoadDataRow(array, true);
                }
            }
            result.Tables.Add(_DataTable);
            return result;
        }

        /// <summary> 
        /// DataSet装换为泛型集合 
        /// </summary> 
        /// <typeparam name="T"></typeparam> 
        /// <param name="p_DataSet">DataSet</param> 
        /// <param name="p_TableIndex">待转换数据表索引</param> 
        /// <returns></returns> 
        /// 2008-08-01 22:46 HPDV2806 
        public static List<T> DataSetToList<T>(DataSet p_DataSet, int p_TableIndex)
        {
            if (p_DataSet == null || p_DataSet.Tables.Count < 0)
                return null;
            if (p_TableIndex > p_DataSet.Tables.Count - 1)
                return null;
            if (p_TableIndex < 0)
                p_TableIndex = 0;

            DataTable p_Data = p_DataSet.Tables[p_TableIndex];
            // 返回值初始化 
            List<T> result = new List<T>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < p_Data.Columns.Count; i++)
                    {
                        // 属性与字段名称一致的进行赋值 
                        if (pi.Name.Equals(p_Data.Columns[i].ColumnName.ToUpper()))
                        {
                            // 数据库NULL值单独处理 
                            if (p_Data.Rows[j][i] != DBNull.Value)
                            {
                                if (p_Data.Rows[j][i].GetType().Name == "Double")
                                {
                                    pi.SetValue(_t, Convert.ToDecimal(p_Data.Rows[j][i]), null);
                                }
                                else
                                {
                                    pi.SetValue(_t, p_Data.Rows[j][i], null);
                                }
                            }
                            else
                                pi.SetValue(_t, null, null);
                            break;
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }

        /// <summary> 
        /// DataSet装换为泛型集合 
        /// </summary> 
        /// <typeparam name="T"></typeparam> 
        /// <param name="p_DataSet">DataSet</param> 
        /// <param name="p_TableName">待转换数据表名称</param> 
        /// <returns></returns> 
        /// 2008-08-01 22:47 HPDV2806 
        public static List<T> DataSetToList<T>(DataSet p_DataSet, string p_TableName)
        {
            int _TableIndex = 0;
            if (p_DataSet == null || p_DataSet.Tables.Count < 0)
                return null;
            if (string.IsNullOrEmpty(p_TableName))
                return null;
            for (int i = 0; i < p_DataSet.Tables.Count; i++)
            {
                // 获取Table名称在Tables集合中的索引值 
                if (p_DataSet.Tables[i].TableName.Equals(p_TableName))
                {
                    _TableIndex = i;
                    break;
                }
            }
            return DataSetToList<T>(p_DataSet, _TableIndex);
        }

        #endregion
    }
}
