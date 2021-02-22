using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Data;
using iTelluro.Busness.WebApiProxy;
using Infoearth.Util.Extension;
using System.Linq;
using Infoearth.Application.Entity;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    public class QCQFStatisticsClass
    {
        public string NAME { get; set; }
        public string ID { get; set; }
    }
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:19
    /// 描 述：群测群防防灾预案表
    /// </summary>
    public class TBL_QCQF_DISASTERPREVENTIONController : MvcControllerBase
    {
        private TBL_QCQF_DISASTERPREVENTIONBLL tbl_qcqf_disasterpreventionbll = new TBL_QCQF_DISASTERPREVENTIONBLL();
        private TBL_QCQF_ADMINISTRATIVEBLL tbl_qcqf_administrativebll = new TBL_QCQF_ADMINISTRATIVEBLL();
        private TBL_HAZARDBASICINFOBLL tbl_hazardbasicinfobll = new TBL_HAZARDBASICINFOBLL();
        private TBL_QCQF_VILLAGEINFOBLL tbl_qcqf_villageinfobll = new TBL_QCQF_VILLAGEINFOBLL();
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_QCQF_DISASTERPREVENTIONIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_DISASTERPREVENTIONForm()
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 行政体系责任人浏览
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetQCQFStatisticsNew(string queryJson)
        {
            List<string> tempList = new List<string>();
            SSOWebApiWS ws = new SSOWebApiWS("");
            List<TBL_HAZARDBASICINFO> results = new List<TBL_HAZARDBASICINFO>();
            var queryParam = queryJson.ToJObject();

            //查询群测群防数据
//            var sql = @"select a.UNIFIEDCODE,a.DISASTERNAME,a.DISASTERTYPE,a.LOCATION,
//a.PROVINCE,a.PROVINCENAME,a.CITY,a.CITYNAME,a.COUNTY,a.COUNTYNAME,a.TOWN,a.TOWNNAME,
//b.MONITORRESPONSIBLE,b.MONITORRESPONSIBLETEL,b.GROUPMONITORINGSTAFF,b.GROUPMONITORINGSTAFFTEL
// from tbl_hazardbasicinfo a  
//                       inner join  TBL_QCQF_DISASTERPREVENTION b 
//                       on a.unifiedcode =b.unifiedcode  ";
            var sql = @"select a.UNIFIEDCODE,a.DISASTERNAME,a.DISASTERTYPE,a.LOCATION,
a.PROVINCE,a.PROVINCENAME,a.CITY,a.CITYNAME,a.COUNTY,a.COUNTYNAME,a.TOWN,a.TOWNNAME,
b.MONITORRESPONSIBLE,b.MONITORRESPONSIBLETEL,b.GROUPMONITORINGSTAFF,b.GROUPMONITORINGSTAFFTEL,c.OBSERVATIONPEOPLE,c.CITY as OCITY,c.COUNTY as OCOUNTY,c.TOWN as OTOWN
 from tbl_hazardbasicinfo a  
                       inner join  TBL_QCQF_DISASTERPREVENTION b 
                       on a.unifiedcode =b.unifiedcode 
inner join TBL_QCQF_OBSERVATION c on a.province=trim(c.province)  ";
            results = tbl_hazardbasicinfobll.GetListJsonQCQFInfo(queryJson, "", sql).ToList();

            var result = tbl_qcqf_administrativebll.GetList("").ToList();//查询行政责任人表            
            var lstVillage = tbl_qcqf_villageinfobll.GetList(queryJson).ToList();//查询村组表

            var AreaCode = queryParam["AreaCode"].ToString();
            List<QCQFStatisticsClass> presult = new List<QCQFStatisticsClass>();
            List<QCQFStatisticsClass> ciresult = new List<QCQFStatisticsClass>();
            List<QCQFStatisticsClass> coresult = new List<QCQFStatisticsClass>();
            List<QCQFStatisticsClass> tresult = new List<QCQFStatisticsClass>();
            var ollistp = result.Where(s => !string.IsNullOrEmpty(s.NAME)).ToList().Select(s => new QCQFStatisticsClass { NAME = s.PROVINCENAME, ID = s.DISTRICTCODE.Substring(0, 2) + "0000" });
            var ollistci = result.Where(s => !string.IsNullOrEmpty(s.NAME)).ToList().Select(s => new QCQFStatisticsClass { NAME = s.CITYNAME, ID = s.DISTRICTCODE.Substring(0, 4) + "00" });
            var ollistco = result.Where(s => !string.IsNullOrEmpty(s.NAME)).ToList().Select(s => new QCQFStatisticsClass { NAME = s.COUNTYNAME, ID = s.DISTRICTCODE.Substring(0, 6) });
            var ollistt = result.Where(s => !string.IsNullOrEmpty(s.NAME)).ToList().Select(s => new QCQFStatisticsClass { NAME = s.TOWNNAME, ID = s.DISTRICTCODE });

            if (AreaCode == "0")
            {//全国
                presult = ollistp.ToList().Where((x, y) => ollistp.ToList().FindIndex(z => z.NAME == x.NAME) == y).ToList();
                ciresult = ollistci.ToList().Where((x, y) => ollistci.ToList().FindIndex(z => z.NAME == x.NAME) == y).ToList();
                coresult = ollistco.ToList().Where((x, y) => ollistco.ToList().FindIndex(z => z.NAME == x.NAME) == y).ToList();
                tresult = ollistt.ToList().Where((x, y) => ollistt.ToList().FindIndex(z => z.NAME == x.NAME) == y).ToList();
            }
            else
            {
                if (AreaCode.EndsWith("0000"))
                {
                    presult = ollistp.ToList().Where((x, y) => ollistp.ToList().FindIndex(z => z.NAME == x.NAME) == y && x.ID.Substring(0, 2) == AreaCode.Substring(0, 2)).ToList();
                    ciresult = ollistci.ToList().Where((x, y) => ollistci.ToList().FindIndex(z => z.NAME == x.NAME) == y && x.ID.Substring(0, 2) == AreaCode.Substring(0, 2)).ToList();
                    coresult = ollistco.ToList().Where((x, y) => ollistco.ToList().FindIndex(z => z.NAME == x.NAME) == y && x.ID.Substring(0, 2) == AreaCode.Substring(0, 2)).ToList();
                    tresult = ollistt.ToList().Where((x, y) => ollistt.ToList().FindIndex(z => z.NAME == x.NAME) == y && x.ID.Substring(0, 2) == AreaCode.Substring(0, 2)).ToList();
                }
                else if (AreaCode.EndsWith("00"))
                {
                    presult = ollistp.ToList().Where((x, y) => ollistp.ToList().FindIndex(z => z.NAME == x.NAME) == y && x.ID.Substring(0, 2) == AreaCode.Substring(0, 2)).ToList();
                    ciresult = ollistci.ToList().Where((x, y) => ollistci.ToList().FindIndex(z => z.NAME == x.NAME) == y && x.ID.Substring(0, 4) == AreaCode.Substring(0, 4)).ToList();
                    coresult = ollistco.ToList().Where((x, y) => ollistco.ToList().FindIndex(z => z.NAME == x.NAME) == y && x.ID.Substring(0, 4) == AreaCode.Substring(0, 4)).ToList();
                    tresult = ollistt.ToList().Where((x, y) => ollistt.ToList().FindIndex(z => z.NAME == x.NAME) == y && x.ID.Substring(0, 4) == AreaCode.Substring(0, 4)).ToList();
                }
                else
                {
                    presult = ollistp.ToList().Where((x, y) => ollistp.ToList().FindIndex(z => z.NAME == x.NAME) == y && x.ID.Substring(0, 2) == AreaCode.Substring(0, 2)).ToList();
                    ciresult = ollistci.ToList().Where((x, y) => ollistci.ToList().FindIndex(z => z.NAME == x.NAME) == y && x.ID.Substring(0, 4) == AreaCode.Substring(0, 4)).ToList();
                    coresult = ollistco.ToList().Where((x, y) => ollistco.ToList().FindIndex(z => z.NAME == x.NAME) == y && x.ID.Substring(0, 6) == AreaCode.Substring(0, 6)).ToList();
                    tresult = ollistt.ToList().Where((x, y) => ollistt.ToList().FindIndex(z => z.NAME == x.NAME) == y && x.ID.Substring(0, 6) == AreaCode.Substring(0, 6)).ToList();
                }
            }
            List<TreeQCQFNodeNEW> nodes = new List<TreeQCQFNodeNEW>();
            foreach (var dr in presult.Where(s => !string.IsNullOrEmpty(s.NAME)).ToList())
            {
                var ent = result.Where(s => s.PROVINCENAME == dr.NAME && string.IsNullOrEmpty(s.CITYNAME) && string.IsNullOrEmpty(s.COUNTYNAME) && string.IsNullOrEmpty(s.TOWNNAME)).ToList();
                bool sasd = (ciresult.Where(s => s.ID.Substring(0, 2) == dr.ID.Substring(0, 2) && !string.IsNullOrEmpty(s.NAME)).ToList().Count > 0
                    || coresult.Where(s => s.ID.Substring(0, 2) == dr.ID.Substring(0, 2) && !string.IsNullOrEmpty(s.NAME)).ToList().Count > 0
                    || tresult.Where(s => s.ID.Substring(0, 2) == dr.ID.Substring(0, 2) && !string.IsNullOrEmpty(s.NAME)).ToList().Count > 0
                    );
                //省
                TreeQCQFNodeNEW dr1 = new TreeQCQFNodeNEW()
                {
                    MONITORRESPONSIBLE = ent.Count > 0 ? ent[0].NAME : "",//责任人名称
                    MONITORRESPONSIBLETEL = ent.Count > 0 ? ent[0].PHONE : "",//责任人电弧
                    level = "0",
                    id = dr.ID,
                    code = dr.ID,
                    isLeaf = !sasd,
                    parent = "0",
                    expanded = true,
                    data = dr.NAME,
                    datas = Newtonsoft.Json.JsonConvert.SerializeObject(results.Where(p => p.PROVINCE.Contains(dr.ID)).ToList()),
                    qcqfcount = results.Where(p => p.PROVINCE.Contains(dr.ID)).ToList().GroupBy(p => p.UNIFIEDCODE).Count().ToString(),
                    count = results.Where(p => p.PROVINCE.Contains(dr.ID) && !string.IsNullOrEmpty(p.OBSERVATIONPEOPLE)).GroupBy(p=>p.OBSERVATIONPEOPLE).Count().ToString()
                };
                nodes.Add(dr1);
            }
            foreach (var dr in ciresult.Where(s => !string.IsNullOrEmpty(s.NAME)).ToList())
            {
                bool sasd = (coresult.Where(s => s.ID.Substring(0, 4) == dr.ID.Substring(0, 4) && !string.IsNullOrEmpty(s.NAME)).ToList().Count > 0
                    || tresult.Where(s => s.ID.Substring(0, 4) == dr.ID.Substring(0, 4) && !string.IsNullOrEmpty(s.NAME)).ToList().Count > 0
                    );
                var ent = result.Where(s => s.CITYNAME == dr.NAME && !string.IsNullOrEmpty(s.PROVINCENAME) && string.IsNullOrEmpty(s.COUNTYNAME) && string.IsNullOrEmpty(s.TOWNNAME)).ToList();
                //市
                TreeQCQFNodeNEW dr2 = new TreeQCQFNodeNEW()
                {
                    MONITORRESPONSIBLE = ent.Count > 0 ? ent[0].NAME : "",//责任人名称
                    MONITORRESPONSIBLETEL = ent.Count > 0 ? ent[0].PHONE : "",//责任人电弧
                    level = "1",
                    id = dr.ID,
                    code = dr.ID,
                    isLeaf = !sasd,
                    parent = dr.ID.ToString().Substring(0, 2) + "0000",
                    expanded = true,
                    data = dr.NAME,
                    datas = Newtonsoft.Json.JsonConvert.SerializeObject(results.Where(p => p.CITY.Contains(dr.ID)).ToList()),
                    qcqfcount = results.Where(p => p.CITY.Contains(dr.ID)).ToList().GroupBy(p => p.UNIFIEDCODE).Count().ToString(),
                    count = results.Where(p => p.OCITY.Contains(dr.ID) && !string.IsNullOrEmpty(p.OBSERVATIONPEOPLE)).GroupBy(p => p.OBSERVATIONPEOPLE).Count().ToString()

                    //count = results.Where(p => p.CITY.Contains(dr.ID) && !string.IsNullOrEmpty(p.GROUPMONITORINGSTAFF)).Count().ToString()
                };
                nodes.Add(dr2);
            }
            foreach (var dr in coresult.Where(s => !string.IsNullOrEmpty(s.NAME)).ToList())
            {
                bool sasd = (coresult.Where(s => s.ID.Substring(0, 6) == dr.ID.Substring(0, 6) && !string.IsNullOrEmpty(s.NAME)).ToList().Count > 0
    || tresult.Where(s => s.ID.Substring(0, 6) == dr.ID.Substring(0, 6) && !string.IsNullOrEmpty(s.NAME)).ToList().Count > 0
    );
                var ent = result.Where(s => s.COUNTYNAME == dr.NAME && !string.IsNullOrEmpty(s.PROVINCENAME) && !string.IsNullOrEmpty(s.CITYNAME) && string.IsNullOrEmpty(s.TOWNNAME)).ToList();
                //县
                TreeQCQFNodeNEW dr3 = new TreeQCQFNodeNEW()
                {
                    MONITORRESPONSIBLE = ent.Count > 0 ? ent[0].NAME : "",//责任人名称
                    MONITORRESPONSIBLETEL = ent.Count > 0 ? ent[0].PHONE : "",//责任人电弧
                    level = "2",
                    id = dr.ID,
                    code = dr.ID,
                    isLeaf = !sasd,
                    expanded = true,
                    parent = dr.ID.ToString().Substring(0, 4) + "00",
                    data = dr.NAME,
                    datas = Newtonsoft.Json.JsonConvert.SerializeObject(results.Where(p => p.COUNTY.Contains(dr.ID)).ToList()),
                    //count = results.Where(p => p.COUNTY.Contains(dr.ID)).Count().ToString(),
                    //qcqfcount = results.Where(p => p.COUNTY.Contains(dr.ID) && !string.IsNullOrEmpty(p.GROUPMONITORINGSTAFF)).Count().ToString()
                    qcqfcount = results.Where(p => p.COUNTY.Contains(dr.ID)).GroupBy(p => p.UNIFIEDCODE).ToList().Count().ToString(),
                    count = results.Where(p => p.OCOUNTY.Contains(dr.ID) && !string.IsNullOrEmpty(p.OBSERVATIONPEOPLE)).GroupBy(p => p.OBSERVATIONPEOPLE).Count().ToString()
                    //count = results.Where(p => p.COUNTY.Contains(dr.ID) && !string.IsNullOrEmpty(p.GROUPMONITORINGSTAFF)).Count().ToString()
                };
                nodes.Add(dr3);
            }
            var lstTown = results.Where(t => !string.IsNullOrEmpty(t.TOWN));
            foreach (var dr in tresult.Where(s => !string.IsNullOrEmpty(s.NAME)).ToList())
            {
                var ent = result.Where(s => s.TOWNNAME == dr.NAME && !string.IsNullOrEmpty(s.PROVINCENAME) && !string.IsNullOrEmpty(s.CITYNAME) && !string.IsNullOrEmpty(s.COUNTYNAME)).ToList();
                TreeQCQFNodeNEW dr4 = new TreeQCQFNodeNEW()
                {
                    MONITORRESPONSIBLE = ent.Count > 0 ? ent[0].NAME : "",//责任人名称
                    MONITORRESPONSIBLETEL = ent.Count > 0 ? ent[0].PHONE : "",//责任人电弧
                    level = "3",
                    id = dr.ID,
                    code = dr.ID,
                    isLeaf = true,
                    expanded = true,
                    parent = dr.ID.ToString().Substring(0, 6),
                    data = dr.NAME,
                    datas = Newtonsoft.Json.JsonConvert.SerializeObject(lstTown.Where(p => p.TOWN.Contains(dr.ID)).ToList()),
                    //count = lstTown.Where(p => p.TOWN.Contains(dr.ID)).Count().ToString(),
                    //qcqfcount = lstTown.Where(p => p.TOWN.Contains(dr.ID) && !string.IsNullOrEmpty(p.GROUPMONITORINGSTAFF)).Count().ToString()
                    qcqfcount = lstTown.Where(p => p.TOWN.Contains(dr.ID)).GroupBy(p => p.UNIFIEDCODE).ToList().Count().ToString(),
                    count = lstTown.Where(p => p.OTOWN.Contains(dr.ID) && !string.IsNullOrEmpty(p.OBSERVATIONPEOPLE)).GroupBy(p => p.OBSERVATIONPEOPLE).Count().ToString()


                };
                nodes.Add(dr4);
                int i = 0;
                List<TBL_QCQF_VILLAGEINFOLXR> village = lstVillage.Where(p => p.TOWNCODE.Equals(dr.ID)).ToList();
                foreach (var item in village)
                {
                    i++;
                    TreeQCQFNodeNEW dr5 = new TreeQCQFNodeNEW()
                    {
                        MONITORRESPONSIBLE = item.USERNAME,//责任人名称
                        MONITORRESPONSIBLETEL = item.Telephone,//责任人电弧
                        level = "4",
                        id = dr.ID + i.ToString(),
                        code = dr.ID + i.ToString(),
                        isLeaf = true,
                        expanded = false,
                        parent = dr.ID,
                        data = item.VILLAGENAME,
                        count = "0",
                        datas = "0",
                        qcqfcount = "0"

                    };
                    nodes.Add(dr5);
                }
            }


            nodes.Sort((a, b) => a.id.CompareTo(b.id));
            return ToJsonResult(nodes);
        }
        /// <summary>
        /// 群测群防统计
        /// </summary>
        /// <param name="queryJson">
        /// AreaCode 行政区划编码
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public object GetQCQFStatistics(string queryJson)
        {
            List<string> tempList = new List<string>();
            SSOWebApiWS ws = new SSOWebApiWS("");
            var queryParam = queryJson.ToJObject();
            var result = tbl_qcqf_administrativebll.GetList("").ToList();
            var AreaCode = queryParam["AreaCode"].ToString();
            List<TBL_QCQF_ADMINISTRATIVEEntity> presult = new List<TBL_QCQF_ADMINISTRATIVEEntity>();
            List<TBL_QCQF_ADMINISTRATIVEEntity> ciresult = new List<TBL_QCQF_ADMINISTRATIVEEntity>();
            List<TBL_QCQF_ADMINISTRATIVEEntity> coresult = new List<TBL_QCQF_ADMINISTRATIVEEntity>();
            List<TBL_QCQF_ADMINISTRATIVEEntity> tresult = new List<TBL_QCQF_ADMINISTRATIVEEntity>();
            int i = 0, j = 0, k = 0, l = 0;
            if (AreaCode == "0")
            {//全国
                //presult = result.Where(s => s.DISTRICTCODE.Substring(0, 2) == AreaCode.Substring(0, 2)).ToList();
            }
            else
            {
                if (AreaCode.EndsWith("0000"))
                {
                    presult = result.Where(s => s.DISTRICTCODE.Substring(0, 2) == AreaCode.Substring(0, 2)).ToList();
                    ciresult = result.Where(s => s.DISTRICTCODE.Substring(0, 4) == AreaCode.Substring(0, 4)).ToList();
                }
                else if (AreaCode.EndsWith("00"))
                {
                    presult = result.Where(s => s.DISTRICTCODE.Substring(0, 2) == AreaCode.Substring(0, 2)).ToList();
                    ciresult = result.Where(s => s.DISTRICTCODE.Substring(0, 4) == AreaCode.Substring(0, 4)).ToList();
                    coresult = result.Where(s => s.DISTRICTCODE.Substring(0, 6) == AreaCode.Substring(0, 6)).ToList();
                }
                else if (!AreaCode.EndsWith("00"))
                {
                    presult = result.Where(s => s.DISTRICTCODE.Substring(0, 2) == AreaCode.Substring(0, 2)).ToList();
                    ciresult = result.Where(s => s.DISTRICTCODE.Substring(0, 4) == AreaCode.Substring(0, 4)).ToList();
                    coresult = result.Where(s => s.DISTRICTCODE.Substring(0, 6) == AreaCode.Substring(0, 6)).ToList();
                    tresult = result.Where(s => s.DISTRICTCODE.Substring(0, 9) == AreaCode.Substring(0, 9)).ToList();
                }
            }
            List<TreeQCQFNode> nodes = new List<TreeQCQFNode>();
            foreach (var dr in result)
            {
                //省
                TreeQCQFNode dr1 = new TreeQCQFNode()
                {
                    UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
                    LONGITUDE = dr.LONGITUDE,
                    LATITUDE = dr.LATITUDE,
                    level = "0",
                    id = dr.DISTRICTCODE.ToString().Substring(0, 2) + "0000",
                    isLeaf = false,
                    parent = "0",
                    expanded = true,
                    data = dr.PROVINCENAME,
                };
                if (!tempList.Contains(dr.DISTRICTCODE.ToString().Substring(0, 2) + "00"))
                {
                    i++;
                    dr1.count = i.ToString();
                    nodes.Add(dr1);
                    tempList.Add(dr.DISTRICTCODE.ToString().Substring(0, 2) + "00");
                }
                else
                {
                    var node = nodes.Where(s => s.id.ToString() == dr.DISTRICTCODE.ToString().Substring(0, 2) + "00").ToList();
                    if (node.Count > 0)
                    {
                        //node[0].
                    }
                }
                //市
                TreeQCQFNode dr2 = new TreeQCQFNode()
                {
                    UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
                    LONGITUDE = dr.LONGITUDE,
                    LATITUDE = dr.LATITUDE,
                    level = "1",
                    id = dr.DISTRICTCODE.ToString().Substring(0, 4) + "00",
                    isLeaf = false,
                    expanded = true,
                    parent = dr.DISTRICTCODE.ToString().Substring(0, 2) + "0000",
                    data = dr.CITYNAME,
                    count = j.ToString()
                };
                if (!tempList.Contains(dr.DISTRICTCODE.ToString().Substring(0, 4) + "00"))
                {

                    nodes.Add(dr2);
                    tempList.Add(dr.DISTRICTCODE.ToString().Substring(0, 4) + "00");
                }
                //县
                TreeQCQFNode dr3 = new TreeQCQFNode()
                {
                    UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
                    LONGITUDE = dr.LONGITUDE,
                    LATITUDE = dr.LATITUDE,
                    level = "2",
                    id = dr.DISTRICTCODE.ToString().Substring(0, 6),
                    isLeaf = false,
                    expanded = true,
                    parent = dr.DISTRICTCODE.ToString().Substring(0, 4) + "00",
                    data = dr.COUNTYNAME,
                    count = k.ToString()
                };
                if (!tempList.Contains(dr.DISTRICTCODE.ToString().Substring(0, 6)))
                {
                    nodes.Add(dr3);
                    tempList.Add(dr.DISTRICTCODE.ToString().Substring(0, 6));
                }
                //TreeQCQFNode dr4 = new TreeQCQFNode()
                //{
                //    UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
                //    LONGITUDE = dr.LONGITUDE,
                //    LATITUDE = dr.LATITUDE,
                //    level = "3",
                //    id = dr.DISTRICTCODE.ToString().Substring(0, 9),
                //    isLeaf = false,
                //    expanded = true,
                //    parent = dr.DISTRICTCODE.ToString().Substring(0, 6),
                //    data = dr.TOWNNAME,
                //    count = l.ToString()
                //};
                //if (!tempList.Contains(dr.TOWNNAME.ToString()))
                //{
                //    nodes.Add(dr4);
                //    tempList.Add(dr.DISTRICTCODE.ToString());
                //}
                ////if (dr["TOWN"].ToString() != "")
                ////{
                ////    //乡镇
                ////    TreeQCQFNode dr4 = new TreeQCQFNode() { level ="3",id= dr["TOWN"].ToString(), isLeaf = false, expanded = true, parent = dr["COUNTY"].ToString(), data = dr["TOWNNAME"].ToString() };
                ////    if (!tempList.Contains(dr["COUNTYNAME"].ToString()))
                ////    {
                ////        nodes.Add(dr4);
                ////        tempList.Add(dr["COUNTYNAME"].ToString());
                ////    }
                ////    string strdata = string.Empty;
                ////    strdata += "'{";
                ////    foreach (DataColumn dc in result.Columns)
                ////    {
                ////        var dcname = dc.ColumnName;
                ////        strdata += "\"" + dcname + "\"" + ":\"" + dr[dcname].ToString() + "\",";
                ////    }
                ////    strdata = strdata.TrimEnd(',') + "}'";
                ////    //灾害点
                ////    TreeQCQFNode dr5 = new TreeQCQFNode() { level = "4", id = dr["UNIFIEDCODE"].ToString(), isLeaf = true, expanded = true, parent = dr["TOWN"].ToString(), data = strdata };
                ////    if (!tempList.Contains(dr["UNIFIEDCODE"].ToString()))
                ////    {
                ////        nodes.Add(dr5);
                ////        tempList.Add(dr["UNIFIEDCODE"].ToString());
                ////    }
                ////}
                ////else 
                ////{
                //string strdata = string.Empty;
                //strdata += "'{";
                //foreach (DataColumn dc in result.Columns)
                //{
                //    var dcname = dc.ColumnName;
                //    strdata += "\"" + dcname + "\"" + ":\"" + dr[dcname].ToString() + "\",";
                //}
                //strdata = strdata.TrimEnd(',') + "}'";
                ////灾害点
                //TreeQCQFNode dr6 = new TreeQCQFNode() { level = "3", id = dr["UNIFIEDCODE"].ToString(), isLeaf = true, expanded = true, parent = dr["UNIFIEDCODE"].ToString().Substring(0, 6), data = strdata };
                //if (!tempList.Contains(dr["UNIFIEDCODE"].ToString()))
                //{
                //    TBL_QCQF_DISASTERPREVENTIONEntity distionentity = tbl_qcqf_disasterpreventionbll.GetEntity(dr["UNIFIEDCODE"].ToString());
                //    if (distionentity != null)
                //    {
                //        if (!string.IsNullOrEmpty(distionentity.MONITORRESPONSIBLEID))
                //        {
                //            dr6.UsreInfo = ssoWS.GetUserFetchByID(distionentity.MONITORRESPONSIBLEID);
                //        }
                //    }
                //    nodes.Add(dr6);
                //    tempList.Add(dr["UNIFIEDCODE"].ToString());
                //}
                //}
            }
            //foreach (var dr in presult)
            //{
            //    i++;
            //    TreeQCQFNode dr1 = new TreeQCQFNode()
            //    {
            //        UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
            //        LONGITUDE = dr.LONGITUDE,
            //        LATITUDE = dr.LATITUDE,
            //        level = "0",
            //        id = dr.DISTRICTCODE.ToString().Substring(0, 2) + "0000",
            //        isLeaf = false,
            //        parent = "0",
            //        expanded = true,
            //        data = dr.PROVINCENAME,
            //    };
            //    if (!tempList.Contains(dr.PROVINCENAME))
            //    {
            //        nodes.Add(dr1);
            //    }
            //    else
            //    {
            //        nodes.Where(s => s.id.ToString() == dr.DISTRICTCODE.ToString().Substring(0, 2) + "0000").ToList()[0].count = i.ToString();
            //    }
            //    tempList.Add(dr.DISTRICTCODE.ToString().Substring(0, 2) + "0000");
            //}
            //foreach (var dr in ciresult)
            //{
            //    j++;
            //    TreeQCQFNode dr2 = new TreeQCQFNode()
            //    {
            //        UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
            //        LONGITUDE = dr.LONGITUDE,
            //        LATITUDE = dr.LATITUDE,
            //        level = "1",
            //        id = dr.DISTRICTCODE.ToString().Substring(0, 4) + "00",
            //        isLeaf = false,
            //        expanded = true,
            //        parent = dr.DISTRICTCODE.ToString().Substring(0, 2) + "0000",
            //        data = dr.CITYNAME,
            //        count = j.ToString()
            //    };
            //    nodes.Add(dr2);
            //}
            //foreach (var dr in coresult)
            //{
            //    k++;
            //    TreeQCQFNode dr3 = new TreeQCQFNode()
            //    {
            //        UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
            //        LONGITUDE = dr.LONGITUDE,
            //        LATITUDE = dr.LATITUDE,
            //        level = "2",
            //        id = dr.DISTRICTCODE.ToString().Substring(0, 6),
            //        isLeaf = false,
            //        expanded = true,
            //        parent = dr.DISTRICTCODE.ToString().Substring(0, 4) + "00",
            //        data = dr.COUNTYNAME,
            //        count = k.ToString()
            //    };
            //    nodes.Add(dr3);
            //}
            //foreach (var dr in tresult)
            //{
            //    l++;
            //    TreeQCQFNode dr3 = new TreeQCQFNode()
            //    {
            //        UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
            //        LONGITUDE = dr.LONGITUDE,
            //        LATITUDE = dr.LATITUDE,
            //        level = "3",
            //        id = dr.DISTRICTCODE.ToString().Substring(0, 9),
            //        isLeaf = false,
            //        expanded = true,
            //        parent = dr.DISTRICTCODE.ToString().Substring(0, 6),
            //        data = dr.TOWNNAME,
            //        count = l.ToString()
            //    };
            //    nodes.Add(dr3);
            //}
            nodes.Sort((a, b) => a.id.CompareTo(b.id));
            return ToJsonResult(nodes);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        [LogContent("群测群防防灾预案表", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_qcqf_disasterpreventionbll.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        [LogContent("群测群防防灾预案表", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_qcqf_disasterpreventionbll.GetList(queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = tbl_qcqf_disasterpreventionbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 根据行政区划编码查询所有责任人信息
        /// </summary>
        /// <param name="queryJson">
        /// AreaCode 行政区划编码
        /// </param>
        /// <returns></returns>
        public object GetQCQFZRRInfo(string queryJson)
        {
            List<string> tempList = new List<string>();
            var result = tbl_qcqf_disasterpreventionbll.GetQCQFStatistics(queryJson);
            List<string> listuserinfo = new List<string>();
            foreach (DataColumn dc in result.Columns)
            {
                dc.ColumnName = dc.ColumnName.ToUpper();
            }
            var queryParam = queryJson.ToJObject();
            string AreaCode = string.Empty;
            if (!queryParam["AreaCode"].IsEmpty())
            {
                AreaCode = queryParam["AreaCode"].ToString();
            }
            try
            {
                foreach (DataRow dr in result.Rows)
                {
                    //县
                    TreeQCQFNode dr3 = new TreeQCQFNode() { level = "2", id = dr["UNIFIEDCODE"].ToString().Substring(0, 6), isLeaf = false, expanded = true, parent = dr["UNIFIEDCODE"].ToString().Substring(0, 4) + "00", data = dr["COUNTYNAME"].ToString() };
                    if (!tempList.Contains(dr["UNIFIEDCODE"].ToString().Substring(0, 6)))
                    {
                        TBL_QCQF_AMINISTRATIVELXR entity3 = tbl_qcqf_administrativebll.GetDISTRICTCODEEntity(dr["UNIFIEDCODE"].ToString().Substring(0, 6) + "000");
                        if (entity3 != null && entity3.UsreInfo.ToString() != "null")
                        {
                            listuserinfo.Add(entity3.UsreInfo.ToString());
                        }
                        tempList.Add(dr["UNIFIEDCODE"].ToString().Substring(0, 6));
                    }
                    if (AreaCode.EndsWith("00"))
                    {
                        //市
                        TreeQCQFNode dr2 = new TreeQCQFNode() { level = "1", id = dr["UNIFIEDCODE"].ToString().Substring(0, 4) + "00", isLeaf = false, expanded = true, parent = dr["UNIFIEDCODE"].ToString().Substring(0, 2) + "0000", data = dr["CITYNAME"].ToString() };
                        if (!tempList.Contains(dr["UNIFIEDCODE"].ToString().Substring(0, 4) + "00"))
                        {
                            TBL_QCQF_AMINISTRATIVELXR entity2 = tbl_qcqf_administrativebll.GetDISTRICTCODEEntity(dr["UNIFIEDCODE"].ToString().Substring(0, 4) + "00000");
                            if (entity2.UsreInfo != null && entity2.UsreInfo.ToString() != "null")
                            {
                                listuserinfo.Add(entity2.UsreInfo.ToString());
                            }
                            tempList.Add(dr["UNIFIEDCODE"].ToString().Substring(0, 4) + "00");
                        }
                    }
                    if (AreaCode.EndsWith("0000"))
                    {
                        //省
                        TreeQCQFNode dr1 = new TreeQCQFNode() { level = "0", id = dr["UNIFIEDCODE"].ToString().Substring(0, 2) + "0000", isLeaf = false, parent = "0", expanded = true, data = dr["PROVINCENAME"].ToString() };
                        if (!tempList.Contains(dr["UNIFIEDCODE"].ToString().Substring(0, 2) + "00"))
                        {
                            TBL_QCQF_AMINISTRATIVELXR entity1 = tbl_qcqf_administrativebll.GetDISTRICTCODEEntity(dr["UNIFIEDCODE"].ToString().Substring(0, 2) + "0000000");
                            if (entity1.UsreInfo != null && entity1.UsreInfo.ToString() != "null")
                            {
                                listuserinfo.Add(entity1.UsreInfo.ToString());
                            }
                            tempList.Add(dr["UNIFIEDCODE"].ToString().Substring(0, 2) + "00");
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ToJsonResult(listuserinfo);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("群测群防防灾预案表", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_qcqf_disasterpreventionbll.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("群测群防防灾预案表", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_QCQF_DISASTERPREVENTIONEntity entity)
        {
            tbl_qcqf_disasterpreventionbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
        public class TreeQCQFNode
        {
            public string id { get; set; }
            public string level { get; set; }
            public string parent { get; set; }
            public bool expanded { get; set; }
            public bool isLeaf { get; set; }
            public object data { get; set; }
            public string count { get; set; }
            public decimal? LATITUDE { get; set; }
            public decimal? LONGITUDE { get; set; }
            public object UsreInfo { get; set; }
        }
        public class TreeQCQFNodeNEW
        {
            public string id { get; set; }
            public string code { get; set; }

            public string level { get; set; }
            public string parent { get; set; }
            public bool expanded { get; set; }
            public bool isLeaf { get; set; }
            public object data { get; set; }
            public string count { get; set; }
            public string OBSERVATIONPEOPLE { get; set; }
            public string MONITORRESPONSIBLE { get; set; }
            public string MONITORRESPONSIBLETEL { get; set; }
            public string qcqfcount { get; set; }
            //public List<TBL_QCQF_Entity> datas { get; set; }
            public string datas { get; set; }
        }
    }
}
