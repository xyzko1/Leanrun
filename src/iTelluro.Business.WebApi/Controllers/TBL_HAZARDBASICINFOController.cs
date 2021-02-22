using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using Infoearth.Application.Entity.SystemManage;
using System.Linq;
using Infoearth.Application.Cache;
using Infoearth.Util.Offices;
using System;
using System.Data;
using System.Collections;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using Infoearth.Application.Entity;
using Infoearth.Data.Repository;
using System.IO;
using System.Web;
using Infoearth.Application.Entity.SystemManage.ViewModel;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 地灾调查接口  by wc 2018-4-27
    /// 用于地灾调查查询、管理
    /// 群策群防查询、管理
    /// </summary>
    public class TBL_HAZARDBASICINFOApiController : ApiControllerBase
    {
        private TBL_HAZARDBASICINFOBLL tbl_hazardbasicinfobll = new TBL_HAZARDBASICINFOBLL();

        private DataItemCache dataItemCache = new DataItemCache();
        //防灾预案表
        private TBL_QCQF_DISASTERPREVENTIONBLL tbl_qcqf_disasterpreventionbll = new TBL_QCQF_DISASTERPREVENTIONBLL();
        //避灾明白卡
        private TBL_QCQF_ESCUNDERSTANDCARDBLL tbl_qcqf_escunderstandcardbll = new TBL_QCQF_ESCUNDERSTANDCARDBLL();
        //工作明白卡
        private TBL_QCQF_WORKUNDERSTANDCARDBLL tbl_qcqf_workunderstandcardbll = new TBL_QCQF_WORKUNDERSTANDCARDBLL();
        private HarzardTrendAnalyseBLL harzardTrendAnalyseBLL = new HarzardTrendAnalyseBLL();
        //历史记录视图接口
        private TBL_HAZARDBASICINFO_HISTORYBLL tbl_hazardhistorybll = new TBL_HAZARDBASICINFO_HISTORYBLL();
        SSOWebApiWS ws = new SSOWebApiWS("");

        private Dictionary<string, string> codeNames = new Dictionary<string, string>();
        private List<string> distinctCodes = new List<string>();        
        
        #region 获取数据

        /// <summary>
        /// 根据条件查询灾害点基本信息（不分页）
        /// </summary>
        /// <param name="queryJson">
        /// 查询参数
        /// PROVINCE 省编号（'c1','c2'..）
        /// CITY  市编号
        /// COUNTY 县编号
        /// TOWN 乡镇编号
        /// PROVINCENAME 省名称 模糊匹配
        /// CITYNAME 市名称
        /// COUNTYNAME 县名称
        /// txt_Key 名称、编号、位置模糊匹配
        /// DISASTERNAME 灾害名称 
        /// UNIFIEDCODE 统一编号
        /// DISASTERTYPE 灾害类型
        /// HIDDENDANGER 是否隐患点 0-否，1-是 字典项（HIDDENDANGER）
        /// DISASTERLEVEL 灾害等级 字典项（DANGERLEVEL）
        /// DANGERLEVEL 险情等级   字典项（DISASTERLEVEL）
        /// CURSTABLESTATUS 目前稳定程度 A-稳定 B-基本稳定  C-潜在不稳定  D-不稳定(字典项CURRENTSTABLESTATUS)
        /// STABLETREND 今后发展趋势  A-稳定 B-基本稳定  C-潜在不稳定  D-不稳定 （字典项STABLETREND）
        /// TREATMENTSUGGESTION 防治建议 字典项（TREATMENTSUGGESTION）
        /// MONITORSUGGESTION监测建议 字典项（MONITORSUGGESTION）
        /// THREATENPEOPLEBEGIN 威胁人口开始 THREATENPEOPLEEND 威胁人口结束
        /// THREATENASSETSBEGIN 威胁财产开始 THREATENASSETSEND 威胁财产结束
        /// DEATHTOLLBEGIN 死亡人口开始 DEATHTOLLEND 死亡人口结束
        /// ASSETSLOSEBEGIN 财产损失开始 ASSETSLOSEEND 财产损失结束
        /// </param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        //[HttpPost]
        public object GetListJson(string queryJson)
        {
            var data = tbl_hazardbasicinfobll.GetList(queryJson);
            //return data;原始返回值
            //地图加载所有点信息字段筛选
            return data.Select(p => new { p.DISASTERNAME, p.DISASTERTYPE, p.UNIFIEDCODE, p.OUTDOORCODE, p.CITYNAME, p.COUNTYNAME, p.TOWNNAME, p.LOCATION, p.LONGITUDE, p.LATITUDE, p.DANGERLEVEL, p.THREATENPEOPLE, p.THREATENASSETS }).ToList();
        }
        /// <summary>
        /// 获取地图摘要信息
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <param name="condition">可选参数(可以不传)
        /// WKTString:拐点坐标 POLYGON((119.76735720875 35.15413150875,119.76735720875 36.30549869625))
        /// x:中心点横坐标
        /// y:中心点纵坐标
        /// radius:半径(米)
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public object PostZYListJson(QueryJsonEntity entity)
        {
            var data = tbl_hazardbasicinfobll.GetZYPageList(entity.queryJson, entity.condition);
            return data;
        }
        /// <summary>
        /// 获取地图摘要信息(有防灾预案表信息的点)
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <param name="condition">可选参数(可以不传)
        /// WKTString:拐点坐标 POLYGON((119.76735720875 35.15413150875,119.76735720875 36.30549869625))
        /// x:中心点横坐标
        /// y:中心点纵坐标
        /// radius:半径(米)
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public object PostZYListJson2(QueryJsonEntity entity)
        {
            var data = tbl_hazardbasicinfobll.GetZYPageList2(entity.queryJson, entity.condition);
            return data;
        }
        /// <summary>
        /// 灾害点后四位编号生成
        /// </summary>
        /// <param name="xzqh">行政区划6位+灾害类型2位</param>
        /// <returns></returns>
        [HttpGet]
        public string GetMaxCode(string xzqh)
        {
            return tbl_hazardbasicinfobll.GetMaxCode(xzqh);
        }
        /// <summary>
        /// 获取灾害点历史数据查询列表（不分页用于地图绑定）
        /// </summary>
        /// <param name="queryJson">
        /// 查询条件
        /// PROVINCE 省编号（'c1','c2'..）
        /// CITY  市编号
        /// COUNTY 县编号
        /// TOWN 乡镇编号
        /// PROJECTID 项目类型 字典表 JYGC_PROJECTBASEINFO-PROJECTGUID
        /// MODIFYTYPE 操作类型 U-更新 A-新增  D-核销 I-批量新增
        /// shifouhexiao 是否已经核销 0-否 1-是
        /// ISZLGCPNT 是否治理工程 0-否 1-是
        /// RELOCATION 是否搬迁避让 0-否 1-是
        /// BeginTime 开始时间
        /// EndTime 结束时间
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<PastHAZARDBASICINFO> GetPastListJson2(string queryJson)
        {
            return tbl_hazardbasicinfobll.GetPastListJson2(queryJson);
        }
        /// <summary>	 
        /// 获取没有两卡一表信息的灾害点信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetNoQcqfPageList(QueryJsonEntity entity)
        {
            var data = tbl_hazardbasicinfobll.GetNoQcqfPageList(entity.queryJson, entity.condition);
            return data;
        }
        [HttpGet]
        public DataTable GetListCodeJson(string queryJson)
        {
            var data = tbl_hazardbasicinfobll.GetListCode(queryJson);
            return data;
        }
        /// <summary>
        /// 地灾首页聚合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntityNEWS GetListCodes()
        {
            var data = tbl_hazardbasicinfobll.GetListCodesNew();
            return data;
        }
        /// <summary>
        /// 地灾采集界面聚合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntityCJ GetListDataCJ(string queryJson)
        {
            var data = tbl_hazardbasicinfobll.GetListDataCJ(queryJson);
            return data;
        }

        //加载地图新增
        [HttpGet]
        public DataTable GetListCodeJsons(string queryJson)
        {
            var data = tbl_hazardbasicinfobll.GetListCode(queryJson);
            return data;
        }
        /// <summary>
        /// 险情等级统计(最近一个项目)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByXQDJ(string queryJson = null)
        {
            if (queryJson == null)
            {
                queryJson = "";
            }
            var result = tbl_hazardbasicinfobll.GetStatisticsByXQDJ(queryJson);
            return result;
        }
        /// <summary>
        /// 灾害规模等级统计(最近一个项目)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByGMDJ(string queryJson = null)
        {
            if (queryJson == null)
            {
                queryJson = "";
            }
            var result = tbl_hazardbasicinfobll.GetStatisticsByGMDJ(queryJson);
            return result;
        }
        /// <summary>
        /// 灾情等级统计(最近一个项目)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByZQDJ(string queryJson = null)
        {
            if (queryJson == null)
            {
                queryJson = "";
            }
            var result = tbl_hazardbasicinfobll.GetStatisticsByZQDJ(queryJson);
            return result;
        }
        /// <summary>
        /// 根据条件查询灾害点基本信息（分页）
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">
        /// 查询条件
        /// PROVINCE 省编号（'c1','c2'..）
        /// CITY  市编号
        /// COUNTY 县编号
        /// TOWN 乡镇编号
        /// PROVINCENAME 省名称 模糊匹配
        /// CITYNAME 市名称
        /// COUNTYNAME 县名称
        /// txt_Key 名称、编号、位置模糊匹配
        /// DISASTERNAME 灾害名称 
        /// UNIFIEDCODE 统一编号
        /// DISASTERTYPE 灾害类型
        /// HIDDENDANGER 是否隐患点 0-否，1-是 字典项（HIDDENDANGER）
        /// DISASTERLEVEL 灾害等级 字典项（DANGERLEVEL）
        /// DANGERLEVEL 险情等级   字典项（DISASTERLEVEL）
        /// CURSTABLESTATUS 目前稳定程度 A-稳定 B-基本稳定  C-潜在不稳定  D-不稳定(字典项CURRENTSTABLESTATUS)
        /// STABLETREND 今后发展趋势  A-稳定 B-基本稳定  C-潜在不稳定  D-不稳定 （字典项STABLETREND）
        /// TREATMENTSUGGESTION 防治建议 字典项（TREATMENTSUGGESTION）
        /// MONITORSUGGESTION监测建议 字典项（MONITORSUGGESTION）
        /// THREATENPEOPLEBEGIN 威胁人口开始 THREATENPEOPLEEND 威胁人口结束
        /// THREATENASSETSBEGIN 威胁财产开始 THREATENASSETSEND 威胁财产结束
        /// DEATHTOLLBEGIN 死亡人口开始 DEATHTOLLEND 死亡人口结束
        /// ASSETSLOSEBEGIN 财产损失开始 ASSETSLOSEEND 财产损失结束
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_hazardbasicinfobll.GetPageListJson(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        ///  [HttpGet]
        //public object GetPageListJsonByZhtj([FromUri]Pagination pagination, string queryJson)
        //{
        //    var watch = CommonHelper.TimerStart();
        //    var data = tbl_hazardbasicinfobll.GetPageListJson(pagination, queryJson);
        //    if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
        //    {
        //        dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
        //        if (json.ssx == "省")
        //        {
        //            data = data.GroupBy(r => r.PROVINCENAME).Select(r => r.First());
        //        }
        //        else if (json.ssx == "市")
        //        {
        //            data = data.GroupBy(r => r.CITYNAME).Select(r => r.First());
        //        }
        //        else if (json.ssx == "县")
        //        {
        //            data = data.GroupBy(r => r.COUNTYNAME).Select(r => r.First());
        //        }
        //        else if (json.ssx == "乡镇")
        //        {
        //            data = data.GroupBy(r => r.TOWNNAME).Select(r => r.First());
        //        }
        //        string tiaojian = json.ssx;
        //        List<TBL_HAZARDBASICINFOEntity> lst = new List<TBL_HAZARDBASICINFOEntity>();
        //        switch (tiaojian)
        //        {
        //            case "灾害体名称":
        //                tiaojian = "DISASTERNAME";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.DISASTERNAME)).ToList();
        //                data = data.GroupBy(r => r.DISASTERNAME).Select(r => r.First());
        //                break;
        //            case "灾害体编号":
        //                tiaojian = "UNIFIEDCODE";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.UNIFIEDCODE)).ToList();
        //                data = data.GroupBy(r => r.UNIFIEDCODE).Select(r => r.First());
        //                break;
        //            case "省":
        //                tiaojian = "PROVINCENAME";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.PROVINCENAME)).ToList();
        //                data = data.GroupBy(r => r.PROVINCENAME).Select(r => r.First());
        //                break;
        //            case "市":
        //                tiaojian = "CITYNAME";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.CITYNAME)).ToList();
        //                data = data.GroupBy(r => r.CITYNAME).Select(r => r.First());
        //                break;
        //            case "县":
        //                tiaojian = "COUNTYNAME";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.COUNTYNAME)).ToList();
        //                data = data.GroupBy(r => r.COUNTYNAME).Select(r => r.First());
        //                break;
        //            case "乡镇":
        //                tiaojian = "TOWNNAME";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.TOWNNAME)).ToList();
        //                data = data.GroupBy(r => r.TOWNNAME).Select(r => r.First());
        //                break;
        //            case "地理位置":
        //                tiaojian = "LOCATION";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.LOCATION)).ToList();
        //                data = data.GroupBy(r => r.LOCATION).Select(r => r.First());
        //                break;
        //            case "经度":
        //                tiaojian = "LONGITUDE";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.LONGITUDE)).ToList();
        //                data = data.GroupBy(r => r.LONGITUDE).Select(r => r.First());
        //                break;
        //            case "纬度":
        //                tiaojian = "LATITUDE";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.LATITUDE)).ToList();
        //                data = data.GroupBy(r => r.LATITUDE).Select(r => r.First());
        //                break;
        //            case "野外编号":
        //                tiaojian = "OUTDOORCODE";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.OUTDOORCODE)).ToList();
        //                data = data.GroupBy(r => r.OUTDOORCODE).Select(r => r.First());
        //                break;
        //            case "室内编号":
        //                tiaojian = "INDOORCODE";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.INDOORCODE)).ToList();
        //                data = data.GroupBy(r => r.INDOORCODE).Select(r => r.First());
        //                break;
        //            case "灾害等级":
        //                tiaojian = "DISASTERLEVEL";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.DISASTERLEVEL)).ToList();
        //                //data = data.GroupBy(r => r.DISASTERLEVEL).Select(r => r.First());

        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st = { "小型", "中型", "大型", "特大型" };
        //                foreach (string s in st)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.DISASTERLEVEL = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "险情等级":
        //                tiaojian = "DANGERLEVEL";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.DANGERLEVEL)).ToList();
        //                //data = data.GroupBy(r => r.DANGERLEVEL).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st1 = { "小型", "中型", "大型", "特大型" };
        //                foreach (string s in st1)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.DANGERLEVEL = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "X":
        //                tiaojian = "X";
        //                data = data.Where(s => s.X != null).ToList();
        //                data = data.GroupBy(r => r.X).Select(r => r.First());
        //                break;
        //            case "Y":
        //                tiaojian = "Y";
        //                data = data.Where(s => s.Y != null).ToList();
        //                data = data.GroupBy(r => r.Y).Select(r => r.First());
        //                break;
        //            case "Z":
        //                tiaojian = "Z";
        //                data = data.Where(s => s.Z != null).ToList();
        //                data = data.GroupBy(r => r.Z).Select(r => r.First());
        //                break;
        //            case "地下水类型":
        //                tiaojian = "GROUNDWATERTYPE";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.GROUNDWATERTYPE)).ToList();
        //                //data = data.GroupBy(r => r.GROUNDWATERTYPE).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st5 = { "孔隙水", "裂隙水", "岩溶水", "潜水", "承压水", "上层滞水" };
        //                foreach (string s in st5)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.GROUNDWATERTYPE = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "防治建议":
        //                tiaojian = "TREATMENTSUGGESTION";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.TREATMENTSUGGESTION)).ToList();
        //                //data = data.GroupBy(r => r.TREATMENTSUGGESTION).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st2 = { "避让", "裂缝填埋", "加强监测", "地表排水", "地下排水", "削方减载", "坡面防护", "反压坡脚", "支挡", "锚固", "灌浆", "植树种草", "坡改梯", "水改旱", "减少震动"};
        //                foreach (string s in st2)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.TREATMENTSUGGESTION = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "构造部位":
        //                tiaojian = "TECTONICREGION";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.TECTONICREGION)).ToList();
        //                data = data.GroupBy(r => r.TECTONICREGION).Select(r => r.First());
        //                break;
        //            case "监测建议":
        //                tiaojian = "MONITORSUGGESTION";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.MONITORSUGGESTION)).ToList();
        //                //data = data.GroupBy(r => r.MONITORSUGGESTION).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st3 = { "定期目视巡查", "安装简易监测设施", "地面位移监测", "深部位移监测" };
        //                foreach (string s in st3)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.MONITORSUGGESTION = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "今后变化趋势":
        //                tiaojian = "STABLETREND";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.STABLETREND)).ToList();
        //                //data = data.GroupBy(r => r.STABLETREND).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st4 = { "稳定", "基本稳定", "不稳定"};
        //                foreach (string s in st4)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.STABLETREND = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "目前稳定程度":
        //                tiaojian = "CURSTABLESTATUS";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.CURSTABLESTATUS)).ToList();
        //                //data = data.GroupBy(r => r.CURSTABLESTATUS).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st6 = { "稳定", "基本稳定", "不稳定"};
        //                foreach (string s in st6)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.CURSTABLESTATUS = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "威胁财产":
        //                tiaojian = "THREATENASSETS";
        //                data = data.Where(s => s.THREATENASSETS != null).ToList();
        //                data = data.GroupBy(r => r.THREATENASSETS).Select(r => r.First()).OrderBy(r => r.THREATENASSETS);
        //                break;
        //            case "威胁人口":
        //                tiaojian = "THREATENPEOPLE";
        //                data = data.Where(s => s.THREATENPEOPLE != null).ToList();
        //                data = data.GroupBy(r => r.THREATENPEOPLE).Select(r => r.First()).OrderBy(r => r.THREATENPEOPLE);
        //                break;
        //            case "隐患点":
        //                tiaojian = "HIDDENDANGER";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.HIDDENDANGER)).ToList();
        //                //data = data.GroupBy(r => r.HIDDENDANGER).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st7 = { "是", "否" };
        //                foreach (string s in st7)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.HIDDENDANGER = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "灾害体类型":
        //                tiaojian = "DISASTERTYPE";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.DISASTERTYPE)).ToList();
        //                data = data.GroupBy(r => r.DISASTERTYPE).Select(r => r.First());
        //                break;
        //            case "毁坏房屋":
        //                tiaojian = "DESTROYEDHOME";
        //                data = data.Where(s => s.DESTROYEDHOME != null).ToList();
        //                data = data.GroupBy(r => r.DESTROYEDHOME).Select(r => r.First());
        //                break;
        //            case "毁路":
        //                tiaojian = "DESTROYEDROAD";
        //                data = data.Where(s => s.DESTROYEDROAD != null).ToList();
        //                data = data.GroupBy(r => r.DESTROYEDROAD).Select(r => r.First());
        //                break;
        //            case "毁渠":
        //                tiaojian = "DESTROYEDCANAL";
        //                data = data.Where(s => s.DESTROYEDCANAL != null).ToList();
        //                data = data.GroupBy(r => r.DESTROYEDCANAL).Select(r => r.First());
        //                break;
        //            default:
        //                tiaojian = "123";
        //                break;
        //        }
        //        if (tiaojian == null || tiaojian == "")
        //        {
        //            data = data.ToList();
        //        }
        //    }
        //    var jsonData = new
        //    {
        //        rows = data,
        //        //total = pagination.total,
        //        total = data.Count(),
        //        page = pagination.page,
        //        records = pagination.records,
        //        costtime = CommonHelper.TimerEnd(watch)
        //    };
        //    return jsonData;
        //}
        [HttpGet]
        public object GetPageListJsonByZhtj([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            List<TBL_HAZARDBASICINFOEntity> data = new List<TBL_HAZARDBASICINFOEntity>();
            List<DataItemModel> dataitem = dataItemCache.GetDataItemList().ToList();
            List<TBL_HAZARDBASICINFOEntity> list = new List<TBL_HAZARDBASICINFOEntity>();
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                string tiaojian = json.ssx;
                tiaojian = tiaojian.Trim();
                if (tiaojian == "灾害等级")
                {
                    tiaojian = "DISASTERLEVEL";
                    var a = dataitem.Where(p => p.F_EnCode == "DISASTERLEVEL").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.DISASTERLEVEL = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "险情等级")
                {
                    tiaojian = "DANGERLEVEL";
                    var a = dataitem.Where(p => p.F_EnCode == "DANGERLEVEL").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.DANGERLEVEL = item;
                        list.Add(haza);
                    }
                    data = list;

                }
                else if (tiaojian == "地下水类型")
                {
                    tiaojian = "GROUNDWATERTYPE";
                    var a = dataitem.Where(p => p.F_EnCode == "GROUNDWATERTYPEHP").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.GROUNDWATERTYPE = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "防治建议")
                {
                    tiaojian = "TREATMENTSUGGESTION";
                    var a = dataitem.Where(p => p.F_EnCode == "TREATMENTSUGGESTION").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.TREATMENTSUGGESTION = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "监测建议")
                {
                    tiaojian = "MONITORSUGGESTION";
                    var a = dataitem.Where(p => p.F_EnCode == "MONITORSUGGESTION").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.MONITORSUGGESTION = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "今后变化趋势")
                {
                    tiaojian = "STABLETREND";
                    var a = dataitem.Where(p => p.F_EnCode == "STABLETREND").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.STABLETREND = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "目前稳定程度")
                {
                    tiaojian = "CURSTABLESTATUS";
                    var a = dataitem.Where(p => p.F_EnCode == "CURRENTSTABLESTATUS").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.CURSTABLESTATUS = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "隐患点")
                {
                    tiaojian = "HIDDENDANGER";
                    var a = dataitem.Where(p => p.F_EnCode == "HIDDENDANGER").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.HIDDENDANGER = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "灾害点类型")
                {
                    tiaojian = "DISASTERTYPE";
                    var a = dataitem.Where(p => p.F_EnCode == "HazardType").Select(p => p.F_ItemName);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.DISASTERTYPE = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "省")
                {
                    tiaojian = "PROVINCENAME";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.PROVINCENAME).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "市")
                {
                    tiaojian = "CITYNAME";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.CITYNAME).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "县")
                {
                    tiaojian = "COUNTYNAME";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.COUNTYNAME).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "乡镇")
                {
                    tiaojian = "TOWNNAME";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.TOWNNAME).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "经度")
                {
                    tiaojian = "LONGITUDE";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.LONGITUDE).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "纬度")
                {
                    tiaojian = "LATITUDE";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.LATITUDE).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "野外编号")
                {
                    tiaojian = "OUTDOORCODE";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.OUTDOORCODE).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "室内编号")
                {
                    tiaojian = "INDOORCODE";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.INDOORCODE).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "X")
                {
                    tiaojian = "X";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.X).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "Y")
                {
                    tiaojian = "Y";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.Y).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "Z")
                {
                    tiaojian = "Z";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.Z).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "威胁财产")
                {
                    tiaojian = "THREATENASSETS";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.THREATENASSETS).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "威胁人口")
                {
                    tiaojian = "THREATENPEOPLE";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.THREATENPEOPLE).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "毁坏房屋")
                {
                    tiaojian = "DESTROYEDHOME";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.DESTROYEDHOME).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "毁路")
                {
                    tiaojian = "DESTROYEDROAD";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.DESTROYEDROAD).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "毁渠")
                {
                    tiaojian = "DESTROYEDCANAL";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.DESTROYEDCANAL).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "构造部位")
                {
                    tiaojian = "TECTONICREGION";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.TECTONICREGION).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "灾害点名称")
                {
                    tiaojian = "DISASTERNAME";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.DISASTERNAME).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "灾害点编号")
                {
                    tiaojian = "UNIFIEDCODE";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.UNIFIEDCODE).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "地理位置")
                {
                    tiaojian = "LOCATION";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.LOCATION).Select(r => r.FirstOrDefault()).ToList();
                }
                if (tiaojian == null || tiaojian == "")
                {
                    data = data.ToList();
                }
            }
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
      
     
        /// 根据条件统计排查数据
        /// </summary>
        /// <param name="queryJson">
        /// level -灾害点统计级数（接受传值‘省’,'市','县'，‘乡镇’）
        /// type-统计类型 （0-灾害点类型，1-灾情级别）
        /// 
        /// sqlWhere  筛选条件（sql语句）
        /// TOWN 镇   行政区划筛选（多个用逗号隔开）
        /// COUNTY 县
        /// CITY 市
        /// PROVINCE 省
        /// DISASTERTYPE 灾害类型
        /// HIDDENDANGER 是否隐患点 0-否，1-是 字典项（HIDDENDANGER）
        /// DISASTERLEVEL 灾害等级 字典项（DANGERLEVEL）
        /// DANGERLEVEL 险情等级   字典项（DISASTERLEVEL）
        /// CURSTABLESTATUS 目前稳定程度 A-稳定 B-基本稳定  C-潜在不稳定  D-不稳定(字典项CURRENTSTABLESTATUS)
        /// STABLETREND 今后发展趋势  A-稳定 B-基本稳定  C-潜在不稳定  D-不稳定 （字典项STABLETREND）
        /// THREATENPEOPLEBEGIN 威胁人口开始 THREATENPEOPLEEND 威胁人口结束
        /// THREATENASSETSBEGIN 威胁财产开始 THREATENASSETSEND 威胁财产结束
        /// HIDDENDANGER 是否隐患点 0-否，1-是 字典项（HIDDENDANGER）
        /// ISIMPORTANT 重要隐患点 0-否，1-是 字典项（ISIMPORTANT）
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetAnalyseListPC(string queryJson)
        {
            return tbl_hazardbasicinfobll.GetAnalyseListPC(queryJson);
        }
        /// <summary>
        /// 根据条件查询灾害点基本信息（分页）
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">
        /// 查询条件
        /// PROVINCE 省编号（'c1','c2'..）
        /// CITY  市编号
        /// COUNTY 县编号
        /// TOWN 乡镇编号
        /// PROVINCENAME 省名称 模糊匹配
        /// CITYNAME 市名称
        /// COUNTYNAME 县名称
        /// txt_Key 名称、编号、位置模糊匹配
        /// DISASTERNAME 灾害名称 
        /// UNIFIEDCODE 统一编号
        /// DISASTERTYPE 灾害类型
        /// HIDDENDANGER 是否隐患点 0-否，1-是 字典项（HIDDENDANGER）
        /// DISASTERLEVEL 灾害等级 字典项（DANGERLEVEL）
        /// DANGERLEVEL 险情等级   字典项（DISASTERLEVEL）
        /// CURSTABLESTATUS 目前稳定程度 A-稳定 B-基本稳定  C-潜在不稳定  D-不稳定(字典项CURRENTSTABLESTATUS)
        /// STABLETREND 今后发展趋势  A-稳定 B-基本稳定  C-潜在不稳定  D-不稳定 （字典项STABLETREND）
        /// TREATMENTSUGGESTION 防治建议 字典项（TREATMENTSUGGESTION）
        /// MONITORSUGGESTION监测建议 字典项（MONITORSUGGESTION）
        /// THREATENPEOPLEBEGIN 威胁人口开始 THREATENPEOPLEEND 威胁人口结束
        /// THREATENASSETSBEGIN 威胁财产开始 THREATENASSETSEND 威胁财产结束
        /// DEATHTOLLBEGIN 死亡人口开始 DEATHTOLLEND 死亡人口结束
        /// ASSETSLOSEBEGIN 财产损失开始 ASSETSLOSEEND 财产损失结束
        /// PROJECTID 项目编号
        /// ISXH 是否销号 0-未销号 1-销号
        /// YEAR 查询年度
        /// PROJECTTYPE 项目类型(调查、排查)
        /// </param>
        /// <param name="condition">
        /// WKTString:拐点坐标 POLYGON((119.76735720875 35.15413150875,119.76735720875 36.30549869625))
        /// x:中心点横坐标
        /// y:中心点纵坐标
        /// radius:半径(米)
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public object PostPageListJson(QueryJsonEntity entity)
        {
            if (entity.pagination == null)
            {
                entity.pagination = new Pagination();
                entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
                entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
                entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
                entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];
            }
            var watch = CommonHelper.TimerStart();

            var data = tbl_hazardbasicinfobll.GetPageListJsons(entity.pagination, entity.queryJson, entity.condition);

            if (string.IsNullOrEmpty(entity.condition) || entity.condition == "{}")
            {
                var jsonData = new
                {
                    rows = data,
                    total = entity.pagination.total,
                    page = entity.pagination.page,
                    records = entity.pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return jsonData;
            }
            int count = entity.pagination.records;
            var total = count % entity.pagination.rows == 0 ? count / entity.pagination.rows : count / entity.pagination.rows + 1;
            var jsonData1 = new
            {
                rows = data,
                total = total,
                page = entity.pagination.page,
                records = entity.pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData1;
        }
        /// <summary>
        /// 根据条件查询灾害点基本信息（无查询参数）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public object PostPageListJsonFirst(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];

            var watch = CommonHelper.TimerStart();

            var data = tbl_hazardbasicinfobll.PostPageListJsonFirst(entity.pagination, entity.queryJson, entity.condition);
            int count = entity.pagination.records;
            var total = count % entity.pagination.rows == 0 ? count / entity.pagination.rows : count / entity.pagination.rows + 1;
            var jsonData = new
            {
                rows = data,
                total = total,
                page = entity.pagination.page,
                records = entity.pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// 检查查询条件语句是否正确（用于web统计条件检测）
        /// </summary>
        /// <param name="sqlWhere">查询语句条件</param>
        /// <returns></returns>
        [HttpGet]
        public WebApiResult CheckExpression(string sqlWhere)
        {
            bool result = tbl_hazardbasicinfobll.CheckExpression(sqlWhere);
            if (result)
                return Success("语句通过!");
            else
                return Error("语句错误！");
        }

        /// <summary>
        /// 根据主键查询灾害点基本表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_HAZARDBASICINFOEntity GetFormJson(string keyValue)
        {
            var data = tbl_hazardbasicinfobll.GetEntity(keyValue);
            return data;
        }

        /// <summary>
        /// 获取单列数据（用于web统计条件查询）
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">
        /// 查询条件
        /// colmn 列名称
        /// </param>
        /// <returns>返回列表Json（只有已经传列数据，并筛选去重）</returns>
        [HttpGet]
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetSinglePageListJson([FromUri]Pagination pagination, string queryJson)
        {
            return tbl_hazardbasicinfobll.GetSinglePageList(pagination, queryJson);
        }


        /// <summary>
        /// 获取灾害点历史数据列表（分页）
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">
        /// 查询条件
        /// PROVINCE 省编号（'c1','c2'..）
        /// CITY  市编号
        /// COUNTY 县编号
        /// TOWN 乡镇编号
        /// PROJECTID 项目类型 字典表 JYGC_PROJECTBASEINFO-PROJECTGUID
        /// MODIFYTYPE 操作类型 U-更新 A-新增  D-核销 I-批量新增
        /// shifouhexiao 是否已经核销 0-否 1-是
        /// ISZLGCPNT 是否治理工程 0-否 1-是
        /// RELOCATION 是否搬迁避让 0-否 1-是
        /// BeginTime 开始时间
        /// EndTime 结束时间
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public object GetPastPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_hazardbasicinfobll.GetPastPageListJson(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }

        /// <summary>
        /// 获取灾害点历史数据查询列表（不分页用于地图绑定）
        /// </summary>
        /// <param name="queryJson">
        /// 查询条件
        /// PROVINCE 省编号（'c1','c2'..）
        /// CITY  市编号
        /// COUNTY 县编号
        /// TOWN 乡镇编号
        /// PROJECTID 项目类型 字典表 JYGC_PROJECTBASEINFO-PROJECTGUID
        /// MODIFYTYPE 操作类型 U-更新 A-新增  D-核销 I-批量新增
        /// shifouhexiao 是否已经核销 0-否 1-是
        /// ISZLGCPNT 是否治理工程 0-否 1-是
        /// RELOCATION 是否搬迁避让 0-否 1-是
        /// BeginTime 开始时间
        /// EndTime 结束时间
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<PastHAZARDBASICINFO> GetPastListJson(string queryJson, string condition)
        {
            return tbl_hazardbasicinfobll.GetPastListJson(queryJson, condition);
        }


        #region 历史数据查询接口  （2019-1-12 by wc  底层需要优化,2019-2-14 by wc 已通过视图优化，空间查询有问题）

        /// <summary>
        /// 获取最近一条灾害点历史数据列表（分页）
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">
        /// 查询条件
        /// PROVINCE 省编号（'c1','c2'..）
        /// CITY  市编号
        /// COUNTY 县编号
        /// TOWN 乡镇编号
        /// PROJECTID 项目类型 字典表 JYGC_PROJECTBASEINFO-PROJECTGUID
        /// MODIFYTYPE 操作类型 U-更新 A-新增  D-核销 I-批量新增
        /// shifouhexiao 是否已经核销 0-否 1-是
        /// ISZLGCPNT 是否治理工程 0-否 1-是
        /// RELOCATION 是否搬迁避让 0-否 1-是
        /// BeginTime 开始时间
        /// EndTime 结束时间
        /// </param>
        /// <param name="condition">空间查询条件</param>
        /// <returns></returns>
        [HttpGet]
        public object GetSinglePastPageListJson([FromUri]Pagination pagination, string queryJson, string condition)
        {
            var watch = CommonHelper.TimerStart();
            //var data = tbl_hazardhistorybll.GetPageList(pagination, queryJson, condition);
            IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> data = null;
            if (string.IsNullOrEmpty(condition) || condition == "{}")
            {
                data = tbl_hazardhistorybll.GetPageList(pagination, queryJson, condition);
                var jsonData = new
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return jsonData;
            }
            else
            {
                data = tbl_hazardhistorybll.GetList(queryJson, condition);
                pagination.records = data.Count();
                return data.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
            }
            //pagination.records = result.Count();
            //return result.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
        }

        /// <summary>
        /// 获取最近一条灾害点历史数据查询列表（不分页用于地图绑定）
        /// </summary>
        /// <param name="queryJson">
        /// 查询条件
        /// PROVINCE 省编号（'c1','c2'..）
        /// CITY  市编号
        /// COUNTY 县编号
        /// TOWN 乡镇编号
        /// PROJECTID 项目类型 字典表 JYGC_PROJECTBASEINFO-PROJECTGUID
        /// MODIFYTYPE 操作类型 U-更新 A-新增  D-核销 I-批量新增
        /// shifouhexiao 是否已经核销 0-否 1-是
        /// ISZLGCPNT 是否治理工程 0-否 1-是
        /// RELOCATION 是否搬迁避让 0-否 1-是
        /// BeginTime 开始时间
        /// EndTime 结束时间
        /// </param>
        /// <param name="condition">空间查询条件</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetSinglePastListJson(string queryJson, string condition)
        {
            return tbl_hazardhistorybll.GetList(queryJson, condition);
        }

        #endregion

        #region 根据灾害点获取历史数据的所有调查时间列表信息

        /// <summary>
        /// 获取一条历史数据的所有调查时间列表信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetSingleFillListJson(string queryJson)
        {
            return tbl_hazardhistorybll.GetList(queryJson);
        }

        #endregion

        /// <summary>
        /// 导出（？？接口有问题）...
        /// </summary>
        /// <param name="queryJson"></param>
        [HttpGet]
        public void ExcelDownloadInfo(string queryJson)
        {
            var dataCount = tbl_hazardbasicinfobll.GetCountAnalyseList(queryJson);

            ExcelHelper.ExcelDownloadOnlyDT(ToDataTable(GetContData(queryJson, dataCount)), "灾害点统计数据", "灾害点统计数据.xls");
        }
        #region 
        [HttpGet]
        public string GetZHDCountResult(string queryJson)
        {
            return tbl_hazardbasicinfobll.GetZHDCountResult(queryJson, 1);
        }
        #endregion

        ///// <summary>
        ///// 获取灾害点的统计数据
        ///// </summary>
        ///// <param name="queryJson">查询条件</param>
        ///// <returns></returns>
        //[HttpGet]
        //public List<Dictionary<string,string>> GetCountAnalyseList(string queryJson)
        //{
        //    var dataCount = tbl_hazardbasicinfobll.GetCountAnalyseList(queryJson);            

        //    return GetContData(queryJson, dataCount);
        //}

        /// <summary>
        /// 根据条件统计灾害点信息
        /// </summary>
        /// <param name="queryJson">
        /// level -灾害点统计级数（接受传值‘省’,'市','县'，‘乡镇’）
        /// type-统计类型 （0-灾害点类型，1-灾情级别）
        /// 
        /// sqlWhere  筛选条件（sql语句）
        /// TOWN 镇   行政区划筛选（多个用逗号隔开）
        /// COUNTY 县
        /// CITY 市
        /// PROVINCE 省
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetAnalyseList(string queryJson)
        {
            return tbl_hazardbasicinfobll.GetAnalyseList(queryJson);
        }
        [HttpGet]
        public DataTable GetZhdAndCityName()
        {
            return tbl_hazardbasicinfobll.GetZhdAndCityName();
        }
        [HttpGet]
        public bool ValidateSQL(string sql)
        {
            return tbl_hazardbasicinfobll.ValidateSQL(sql);
        }
        [HttpGet]
        public DataTable GetZhdAndProvinceName()
        {
            return tbl_hazardbasicinfobll.GetZhdAndProvinceName();
        }
        //[HttpGet]
        //public DataTable GetHazardCountStatics(string queryJson)
        //{
        //    var monitorpointinfo = (from p in tbl_hazardbasicinfobll.GetList(queryJson) group p by p.CITYNAME into g select new { cityname = g.Key, zhd = g.Count() }).ToList();
        //    DataTable result = new DataTable();
        //    result.Columns.Add("cityname");
        //    result.Columns.Add("zhd");
        //    var CityNames = ws.GetAllByParentCodes("360000");
        //    foreach (var item in CityNames)
        //    {
        //        DataRow row = result.NewRow();
        //        row["cityname"] = item.F_AreaName;
        //        row["zhd"] = 0;
        //        foreach (var itempoint in monitorpointinfo)
        //        {
        //            if (item.F_AreaName == itempoint.cityname)
        //            {
        //                row["zhd"] = itempoint.zhd;
        //            }
        //        }
        //        result.Rows.Add(row);
        //    }
        //    return result;
        //}
        [HttpGet]
        public DataTable GetAnalyseListQCQF(string queryJson)
        {
            return tbl_qcqf_disasterpreventionbll.GetAnalyseListQCQF(queryJson);
        }
        /// <summary>
        /// 灾害点统计（按市县、灾害点总数|灾害点类型|灾情等级|险情等级 统计）
        /// </summary>
        /// <param name="type">统计类型：<br/>
        /// DISASTER(灾害点总数)|DISASTERTYPE(灾害点类型)|DISASTERLEVEL(灾情等级)|DANGERLEVEL(险情等级)</param>
        /// <returns></returns>
        [HttpGet]
        public object GetHazardStatisticsJson(string type)
        {
            DataTable dt = tbl_hazardbasicinfobll.GetHazardStatisticsJson(type);
            string json = DataHelper.DataTableToJson("result", dt);
            return json.ToJson();
        }
        /// <summary>
        /// 统计威胁人数
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetWXRKStatisticsJson(string queryJson)
        {
            DataTable dt = tbl_hazardbasicinfobll.GetWXRKStatisticsJson(queryJson);
            string json = DataHelper.DataTableToJson("result", dt);
            return json.ToJson();
        }
        /// <summary>
        /// 威胁财产统计
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetWXCCStatisticsJson(string queryJson)
        {
            DataTable dt = tbl_hazardbasicinfobll.GetWXCCStatisticsJson(queryJson);
            string json = DataHelper.DataTableToJson("result", dt);
            return json.ToJson();
        }
        /// <summary>
        /// 年度灾害类型统计(全部区域)
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByZHLX(string queryJson)
        {
            var result = tbl_hazardbasicinfobll.GetStatisticsByZHLX(queryJson);
            return result;
        }
        /// <summary>
        /// 年度灾害点统计(隐患点/新增点/销号点)
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetHistoryStatisticsZHD(string queryJson)
        {
            EchartEntity returnValue = new EchartEntity();
            var result = tbl_hazardbasicinfobll.GetHistoryStatisticsZHD(queryJson, ref  returnValue);
            //var s=new { returnValue = returnValue, result = result };
            return new { returnValue = returnValue, result = result };
        }
        /// <summary>
        /// 操作类型统计
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetTypeStatistics(string queryJson)
        {
            var result = tbl_hazardbasicinfobll.GetTypeStatistics(queryJson);
            return result;
        }
        /// <summary>
        /// 灾害类型统计(扇形图)
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetStatisticsByZHLX2(string queryJson)
        {
            var result = tbl_hazardbasicinfobll.GetStatisticsByZHLX2(queryJson);
            return result;
        }
        /// <summary>
        /// 拟销号点统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByXH(string queryJson = null)
        {
            var result = tbl_hazardbasicinfobll.GetStatisticsByXH(queryJson);
            return result;
        }

        /// <summary>
        /// 灾害点统计(最近一个项目)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByZHD(string queryJson = null)
        {
            if (queryJson == null)
            {
                queryJson = "";
            }
            var result = tbl_hazardbasicinfobll.GetStatisticsByZHD(queryJson);
            return result;
        }

        /// <summary>
        /// 治理工程统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByZLGC(string queryJson = null)
        {
            var result = tbl_hazardbasicinfobll.GetStatisticsByZLGC(queryJson);
            return result;
        }
        /// <summary>
        /// 搬迁避让统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByBABR(string queryJson = null)
        {
            var result = tbl_hazardbasicinfobll.GetStatisticsByBQBR(queryJson);
            return result;
        }
        /// <summary>
        /// sso首页统计
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object SSOGeodisaster(string queryJson)
        {

            //灾害点总数、7个灾害类型的分别的总数
            //群测群防总数、两卡一表分别的总数
            //搬迁避让总数、搬迁完成总数、验收完成总数
            //治理工程总数
            var data = tbl_hazardbasicinfobll.SSOGeodisaster(queryJson);
            return data;
        }
        [HttpGet]
        public object QueryStatistics(string queryJson)
        {

            List<MergedRegionEntity> columnList = new List<MergedRegionEntity>();
            DataTable result = harzardTrendAnalyseBLL.QueryStatistics(queryJson, ref columnList);
            var jsonData = new
            {
                Columns = columnList,
                Data = result
            };
            return jsonData;
        }
        #region 获取统计数据并转换相对应的格式

        List<Dictionary<string, string>> GetContData(string queryJson, List<TBL_HAZARDBASICINFOEntity> dataCount)
        {
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

            List<Dictionary<string, string>> datalist = new List<Dictionary<string, string>>();

            //获取所有省级行政区划数据
            SSOWebApiWS ws = new SSOWebApiWS(null);

            var shengdata = ws.GetAreaListJson("0").Where(t => (!string.IsNullOrEmpty(Convert.ToString(json.PROVINCE)) ? ((IList)Convert.ToString(json.PROVINCE).Split(',')).Contains(t.F_AreaCode) : true));

            foreach (var shengitme in shengdata)
            {//遍历省数据

                //省一级数据加入节点
                datalist.Add(GetDictionaryData(shengitme.F_AreaName, "", "", "", dataCount.Where(t => t.PROVINCE != null && t.PROVINCE.Equals(shengitme.F_AreaCode)).ToList()));

                //获取城市数据
                var shidata = ws.GetAreaListJson(shengitme.F_AreaCode).Where(t => (!string.IsNullOrEmpty(Convert.ToString(json.CITY)) ? ((IList)Convert.ToString(json.CITY).Split(',')).Contains(t.F_AreaCode) : true));
                foreach (var shiitme in shidata)
                {//遍历市数据

                    //市一级数据加入节点
                    datalist.Add(GetDictionaryData("", shiitme.F_AreaName, "", "", dataCount.Where(t => t.CITY != null && t.CITY.Equals(shiitme.F_AreaCode)).ToList()));

                    var xiandata = ws.GetAreaListJson(shiitme.F_AreaCode).Where(t => (!string.IsNullOrEmpty(Convert.ToString(json.COUNTY)) ? ((IList)Convert.ToString(json.COUNTY).Split(',')).Contains(t.F_AreaCode) : true));
                    foreach (var xianitme in xiandata)
                    {//遍历区/县数据

                        //区/县一级数据加入节点
                        datalist.Add(GetDictionaryData("", "", xianitme.F_AreaName, "", dataCount.Where(t => t.COUNTY != null && t.COUNTY.Equals(xianitme.F_AreaCode)).ToList()));

                        if (!string.IsNullOrEmpty(Convert.ToString(json.COUNTY)))
                        {//只有当选中了区/县的时候才遍历乡镇的数据，否则数据量太大也不方便查看

                            var zhendata = ws.GetAreaListJson(xianitme.F_AreaCode).Where(t => (!string.IsNullOrEmpty(Convert.ToString(json.TOWN)) ? ((IList)Convert.ToString(json.TOWN).Split(',')).Contains(t.F_AreaCode) : true));
                            foreach (var zhenitme in zhendata)
                            {//遍历镇数据

                                //镇一级数据加入节点
                                datalist.Add(GetDictionaryData("", "", "", zhenitme.F_AreaName, dataCount.Where(t => t.TOWN != null && t.TOWN.Equals(zhenitme.F_AreaCode)).ToList()));

                            }
                        }
                    }
                }
            }

            return datalist;
        }



        /// <summary>
        /// 获取行政单位灾害相关的各类型数据统计
        /// </summary>
        /// <param name="sheng">省名称</param>
        /// <param name="shi">市名称</param>
        /// <param name="xian">区县名称</param>
        /// <param name="zhen">乡镇名称</param>
        /// <param name="shujuyuan">数据源（灾害基本信息表）</param>
        /// <returns></returns>

        Dictionary<string, string> GetDictionaryData(string sheng, string shi, string xian, string zhen, List<TBL_HAZARDBASICINFOEntity> shujuyuan)
        {

            var zidian = dataItemCache.GetDataItemList();

            //List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("省", sheng);
            data.Add("市", shi);
            data.Add("区/县", xian);
            data.Add("镇", zhen);
            data.Add("行政区划", sheng + shi + xian + zhen);

            //灾害类型----遍历灾害类型字典
            foreach (var item in zidian.Where(t => t.F_EnCode != null && t.F_EnCode.Equals("2")))
            {
                data.Add(item.F_ItemName, shujuyuan.Where(t => t.DISASTERTYPE != null && t.DISASTERTYPE.Equals(item.F_ItemName)).Count().ToString());
            }

            //隐患点
            data.Add("隐患点", shujuyuan.Where(t => t.HIDDENDANGER != null && t.HIDDENDANGER.Equals("1")).Count().ToString());

            //灾害等级----遍历灾害等级字典
            foreach (var item in zidian.Where(t => t.F_EnCode != null && t.F_EnCode.Equals("3")))
            {
                data.Add("灾害" + item.F_ItemName, shujuyuan.Where(t => t.DISASTERLEVEL != null && t.DISASTERLEVEL.Equals(item.F_ItemValue)).Count().ToString());
            }

            //险情等级----遍历险情等级字典
            foreach (var item in zidian.Where(t => t.F_EnCode != null && t.F_EnCode.Equals("4")))
            {
                data.Add("险情" + item.F_ItemName, shujuyuan.Where(t => t.DANGERLEVEL != null && t.DANGERLEVEL.Equals(item.F_ItemValue)).Count().ToString());
            }

            //稳定性----遍历稳定性字典
            foreach (var item in zidian.Where(t => t.F_EnCode != null && t.F_EnCode.Equals("6")))
            {
                data.Add("稳定程度" + item.F_ItemName, shujuyuan.Where(t => t.CURSTABLESTATUS != null && t.CURSTABLESTATUS.Equals(item.F_ItemValue)).Count().ToString());
            }

            //今后变化----遍历发展趋势字典
            foreach (var item in zidian.Where(t => t.F_EnCode != null && t.F_EnCode.Equals("7")))
            {
                data.Add("发展趋势" + item.F_ItemName, shujuyuan.Where(t => t.STABLETREND != null && t.STABLETREND.Equals(item.F_ItemValue)).Count().ToString());
            }


            //ContextD d = new ContextD();
            //d.sheng = sheng;
            //d.shi = shi;
            //d.xian = xian;
            //d.xz = zhen;
            //d.斜坡 = shujuyuan.Where(t => t.DISASTERTYPE.Equals(dt));
            //d.滑坡 = sheng;
            //d.崩塌 = sheng;
            //d.泥石流 = sheng;
            //d.地面塌陷 = sheng;
            //d.地面沉降 = sheng;
            //d.地裂缝 = sheng;
            ////d.损坏房屋 = sheng;
            ////d.毁路 = sheng;
            ////d.毁渠 = sheng;
            ////d.威胁人口 = sheng;
            ////d.威胁财产 = sheng;
            //d.目前稳定性好 = sheng;
            //d.目前稳定性较差 = sheng;
            //d.目前稳定性差 = sheng;
            //d.今后稳定性好 = sheng;
            //d.今后稳定性较差 = 0;
            //d.今后稳定性差 = 0;
            //d.隐患点 = 0;
            //d.隐患点 = 0;

            //d.小型灾情 = 0;
            //d.中型灾情 = 0;
            //d.大型灾情 = 0;
            //d.特大型灾情 = 0;
            //d.小型险情 = 0;
            //d.中型险情 = 0;
            //d.大型险情 = 0;
            //d.特大型险情 = 0;

            return data;
        }

        /// <summary>
        /// 键值集合List转换成datatable
        /// </summary>
        /// <param name="data">数据源</param>
        /// <returns></returns>
        DataTable ToDataTable(List<Dictionary<string, string>> data)
        {

            DataTable dt = new DataTable();

            foreach (var item in data[0].Keys)
            {//循环添加列
                dt.Columns.Add(new DataColumn(item));
            }
            foreach (var item in data)
            {//把数据填充到行
                DataRow dr = dt.NewRow();
                foreach (var ii in item)
                {
                    dr[ii.Key] = ii.Value;
                }
                //把数据添加到datatable
                dt.Rows.Add(dr);
            }

            return dt;
        }
        #endregion


        #region 群测群防
        /// <summary>
        /// 获取列表(判定是否存在两卡一表)
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJsonDISASTERPREVENTION([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = from a in tbl_hazardbasicinfobll.GetPageList(pagination, queryJson)
                       join b in tbl_qcqf_disasterpreventionbll.GetList("") on a.UNIFIEDCODE equals b.UNIFIEDCODE into ab
                       from abi in ab.DefaultIfEmpty()
                       //join c in tbl_qcqf_escunderstandcardbll.GetList("") on a.UNIFIEDCODE equals c.UNIFIEDCODE into abc
                       //from abci in abc.DefaultIfEmpty()
                       //join d in tbl_qcqf_workunderstandcardbll.GetList("") on a.UNIFIEDCODE equals d.UNIFIEDCODE into abcd
                       //from abcdi in abcd.DefaultIfEmpty()
                       select new
                       {
                           a.UNIFIEDCODE,
                           a.DISASTERNAME,
                           a.DISASTERTYPE,
                           a.LOCATION,
                           a.DISASTERLEVEL,
                           a.DANGERLEVEL,
                           DISASTERPREVENTION = abi == null ? string.Empty : abi.UNIFIEDCODE,
                           //ESCUNDERSTANDCARD = abci == null ? string.Empty : abci.UNIFIEDCODE,
                           //WORKUNDERSTANDCARD = abcdi == null ? string.Empty : abcdi.UNIFIEDCODE
                       };
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// 获取列表(群测群防查询浏览)
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJsonQCQFSearch([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = from a in tbl_qcqf_disasterpreventionbll.GetPageList(pagination, "")
                       join b in tbl_hazardbasicinfobll.GetList(queryJson) on a.UNIFIEDCODE equals b.UNIFIEDCODE
                       where b.UNIFIEDCODE != null
                       select b;
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// 获取列表(群测群防查询浏览)
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJsonQCQFSearchs([FromUri]Pagination pagination, string queryJson, string condition)
        {
            var watch = CommonHelper.TimerStart();

            //var data = from a in tbl_hazardbasicinfobll.GetPageList(pagination, queryJson)
            //           join b in tbl_qcqf_disasterpreventionbll.GetList("") on a.UNIFIEDCODE equals b.UNIFIEDCODE
            //           select new
            //           {
            //               a.UNIFIEDCODE,
            //               a.DISASTERNAME,
            //               a.DISASTERTYPE,
            //               a.LOCATION,
            //               a.DISASTERLEVEL,
            //               a.DANGERLEVEL,
            //               a.CITY,
            //               a.CITYNAME,
            //               a.COUNTY,
            //               a.COUNTYNAME,
            //               a.TOWN,
            //               a.TOWNNAME,

            //           };
            //var data = from a in tbl_qcqf_disasterpreventionbll.GetPageList(pagination, "")
            //           join b in tbl_hazardbasicinfobll.GetList(queryJson) on a.UNIFIEDCODE equals b.UNIFIEDCODE
            //           where b.UNIFIEDCODE != null
            //           select b;

            //dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;          
            //#endregion
            //灾害点名称
            //string DISASTERNAME = json.DISASTERNAME;
            //if (!string.IsNullOrEmpty(DISASTERNAME))
            //{
            //    data = data.Where(t => t.DISASTERNAME.Trim().Contains(DISASTERNAME.Trim()));
            //}
            ////灾害点类型
            //string DISASTERTYPE = json.DISASTERTYPE;
            //if (!string.IsNullOrEmpty(DISASTERTYPE))
            //{
            //    data = data.Where(t => t.DISASTERTYPE.Trim().Contains(DISASTERTYPE.Trim()));
            //}

            ////灾害点编号
            //string UNIFIEDCODE = json.UNIFIEDCODE;
            //if (!string.IsNullOrEmpty(UNIFIEDCODE))
            //{
            //    data = data.Where(t => t.UNIFIEDCODE.Trim().Contains(UNIFIEDCODE.Trim()));
            //}
            var data = tbl_hazardbasicinfobll.GetPageListJsonQCQFSearch(pagination, queryJson, condition);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// 获取列表(群测群防查询浏览)
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJsonQCQFSearchNew([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            List<TBL_QCQF_Entity> result = new List<TBL_QCQF_Entity>();
            //var data = from a in tbl_hazardbasicinfobll.GetList(queryJson)
            //           join b in tbl_qcqf_disasterpreventionbll.GetList(queryJson) on a.UNIFIEDCODE.Trim() equals b.UNIFIEDCODE.Trim()
            //           select new
            //           {
            //               a.UNIFIEDCODE,
            //               a.DISASTERNAME,
            //               a.DISASTERTYPE,
            //               a.LOCATION,
            //               a.PROVINCE,
            //               a.PROVINCENAME,
            //               a.CITY,
            //               a.CITYNAME,
            //               a.COUNTY,
            //               a.COUNTYNAME,
            //               a.TOWN,
            //               a.TOWNNAME,
            //               b.MONITORRESPONSIBLE,
            //               b.MONITORRESPONSIBLETEL,
            //               b.GROUPMONITORINGSTAFF,
            //               b.GROUPMONITORINGSTAFFTEL,
            //           };
            //result = data.ToList().Select(u => new TBL_QCQF_Entity { UNIFIEDCODE = u.UNIFIEDCODE, DISASTERNAME = u.DISASTERNAME, DISASTERTYPE = u.DISASTERTYPE, LOCATION = u.LOCATION, PROVINCE = u.PROVINCE, PROVINCENAME = u.PROVINCENAME, CITY = u.CITY, CITYNAME = u.CITYNAME, COUNTY = u.COUNTY, COUNTYNAME = u.COUNTYNAME, TOWN = u.TOWN, TOWNNAME = u.TOWNNAME, MONITORRESPONSIBLE = u.MONITORRESPONSIBLE, MONITORRESPONSIBLETEL = u.MONITORRESPONSIBLETEL, GROUPMONITORINGSTAFF = u.GROUPMONITORINGSTAFF, GROUPMONITORINGSTAFFTEL = u.GROUPMONITORINGSTAFFTEL }).ToList();
            ////RepositoryFactory<TBL_QCQF_Entity> s =new 
            ////var datas = s.BaseRepository().(pagination);
            //pagination.records = result.Count();
            //var datas = result.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows).AsQueryable();
            var sql = @"select a.UNIFIEDCODE,a.DISASTERNAME,a.DISASTERTYPE,a.LOCATION,
a.PROVINCE,a.PROVINCENAME,a.CITY,a.CITYNAME,a.COUNTY,a.COUNTYNAME,a.TOWN,a.TOWNNAME,
b.MONITORRESPONSIBLE,b.MONITORRESPONSIBLETEL,b.GROUPMONITORINGSTAFF,b.GROUPMONITORINGSTAFFTEL
 from tbl_hazardbasicinfo a  
                       inner join  TBL_QCQF_DISASTERPREVENTION b 
                       on a.unifiedcode =b.unifiedcode  ";
            var datas = tbl_hazardbasicinfobll.GetPageListJsonQCQFSearch_MarkerByInfo(pagination, queryJson, "", sql);
            var jsonData = new
            {
                rows = datas,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// 获取灾害点列表(群测群防监测点管理)
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJsonQCQFSearchZHD([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            //var data = from a in tbl_qcqf_disasterpreventionbll.GetPageList(pagination, queryJson)
            //           join b in tbl_hazardbasicinfobll.GetList(queryJson) on  a.UNIFIEDCODE equals b.UNIFIEDCODE
            //           //where b.UNIFIEDCODE != null
            //           select b;

            var sql = @"select a.UNIFIEDCODE,a.DISASTERNAME,a.DISASTERTYPE,a.LOCATION,
a.PROVINCE,a.PROVINCENAME,a.CITY,a.CITYNAME,a.COUNTY,a.COUNTYNAME,a.TOWN,a.TOWNNAME,a.LONGITUDE,a.LATITUDE,
b.MONITORRESPONSIBLE,b.MONITORRESPONSIBLETEL,b.GROUPMONITORINGSTAFF,b.GROUPMONITORINGSTAFFTEL
 from tbl_hazardbasicinfo a  
                       inner join  TBL_QCQF_DISASTERPREVENTION b 
                       on a.unifiedcode =b.unifiedcode  ";
            var data = tbl_hazardbasicinfobll.GetPageListJsonQCQFSearch_MarkerByInfo(pagination, queryJson, "", sql);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }


        /// <summary>
        /// 排除掉已存在群测群防数据的灾害点
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetPageListJsonNoQCQF(string queryJson, [FromUri]Pagination pagination, string condition = null)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_hazardbasicinfobll.GetPageListJsonNoQCQF(queryJson, condition, pagination);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }

        /// <summary>
        /// 根据UNIFIEDCODE查询灾害点基本表详细信息
        /// </summary>
        /// <param name="UNIFIEDCODE"></param>
        /// <returns></returns>
        [HttpGet]
        public TBL_HAZARDBASICINFOEntity GetUNIFIEDCODEEntity(string UNIFIEDCODE)
        {
            var data = tbl_hazardbasicinfobll.GetUNIFIEDCODEEntity(UNIFIEDCODE);
            return data;
        }
        /// <summary>
        /// 获取列表(群测群防查询浏览)新增地图框选
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpPost]
        public object PostPageListJsonQCQFSearch(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];
            var watch = CommonHelper.TimerStart();
            //var data = from a in tbl_qcqf_disasterpreventionbll.GetPageList(entity.pagination, "")
            //           join b in tbl_hazardbasicinfobll.GetLists(entity.queryJson, entity.condition) on a.UNIFIEDCODE equals b.UNIFIEDCODE
            //           where b.UNIFIEDCODE != null
            //           select b;
            //int count = entity.pagination.records;
            //var total = count % entity.pagination.rows == 0 ? count / entity.pagination.rows : count / entity.pagination.rows + 1;
            var data = tbl_hazardbasicinfobll.GetPageListJsonQCQFSearch(entity.pagination, entity.queryJson, entity.condition);
            var jsonData = new
            {
                rows = data,
                total = entity.pagination.total,
                page = entity.pagination.page,
                records = entity.pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// 获取列表(群测群防查询浏览)新增地图框选
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpPost]
        public object PostPageListJsonQCQFSearchNew(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];
            var watch = CommonHelper.TimerStart();
            //List<TBL_QCQF_Entity> result = new List<TBL_QCQF_Entity>();
            //var data = from a in tbl_hazardbasicinfobll.GetZYPageList(entity.queryJson, entity.condition)
            //           join b in tbl_qcqf_disasterpreventionbll.GetList(entity.queryJson) on a.UNIFIEDCODE.Trim() equals b.UNIFIEDCODE.Trim()
            //           select new
            //           {
            //               a.UNIFIEDCODE,
            //               a.DISASTERNAME,
            //               a.DISASTERTYPE,
            //               a.LOCATION,
            //               a.PROVINCE,
            //               a.PROVINCENAME,
            //               a.CITY,
            //               a.CITYNAME,
            //               a.COUNTY,
            //               a.COUNTYNAME,
            //               a.TOWN,
            //               a.TOWNNAME,
            //               b.MONITORRESPONSIBLE,
            //               b.MONITORRESPONSIBLETEL,
            //               b.GROUPMONITORINGSTAFF,
            //               b.GROUPMONITORINGSTAFFTEL,
            //           };
            //result = data.ToList().Select(u => new TBL_QCQF_Entity { UNIFIEDCODE = u.UNIFIEDCODE, DISASTERNAME = u.DISASTERNAME, DISASTERTYPE = u.DISASTERTYPE, LOCATION = u.LOCATION, PROVINCE = u.PROVINCE, PROVINCENAME = u.PROVINCENAME, CITY = u.CITY, CITYNAME = u.CITYNAME, COUNTY = u.COUNTY, COUNTYNAME = u.COUNTYNAME, TOWN = u.TOWN, TOWNNAME = u.TOWNNAME, MONITORRESPONSIBLE = u.MONITORRESPONSIBLE, MONITORRESPONSIBLETEL = u.MONITORRESPONSIBLETEL, GROUPMONITORINGSTAFF = u.GROUPMONITORINGSTAFF, GROUPMONITORINGSTAFFTEL = u.GROUPMONITORINGSTAFFTEL }).ToList();
            //entity.pagination.records = result.Count();
            //var datas = result.Skip((entity.pagination.page - 1) * entity.pagination.rows).Take(entity.pagination.rows).AsQueryable();                 
            var sql = @"select a.UNIFIEDCODE,a.DISASTERNAME,a.DISASTERTYPE,a.LOCATION,
a.PROVINCE,a.PROVINCENAME,a.CITY,a.CITYNAME,a.COUNTY,a.COUNTYNAME,a.TOWN,a.TOWNNAME,a.LONGITUDE,a.LATITUDE,
b.MONITORRESPONSIBLE,b.MONITORRESPONSIBLETEL,b.GROUPMONITORINGSTAFF,b.GROUPMONITORINGSTAFFTEL
 from tbl_hazardbasicinfo a  
                       inner join  TBL_QCQF_DISASTERPREVENTION b 
                       on a.unifiedcode =b.unifiedcode  ";
            var datas = tbl_hazardbasicinfobll.GetPageListJsonQCQFSearch_MarkerByInfo(entity.pagination, entity.queryJson, entity.condition, sql);
            var jsonData = new
            {
                rows = datas,
                total = entity.pagination.total,
                page = entity.pagination.page,
                records = entity.pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }

        /// <summary>
        /// 获取列表(群测群防查询浏览)
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetListJsonQCQFSearch(string queryJson)
        {
            var data = from a in tbl_qcqf_disasterpreventionbll.GetList("")
                       join b in tbl_hazardbasicinfobll.GetList(queryJson) on a.UNIFIEDCODE equals b.UNIFIEDCODE
                       where b.UNIFIEDCODE != null
                       select b;

            return data;
        }

        /// <summary>
        /// 删除两卡一表数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveFormTwo(SingleParam param)
        {
            tbl_qcqf_disasterpreventionbll.RemoveForm(param.KeyValue);
            tbl_qcqf_workunderstandcardbll.RemoveForm((param.KeyValue));
            var watch = CommonHelper.TimerStart();
            //通过灾害点编号查询避灾明白卡主键值进行删除(避灾明白卡一个灾害点编号对应多个guid)
            parmes P = new parmes();
            P.UNIFIEDCODE = param.KeyValue;
            string queryJson = JsonConvert.SerializeObject(P);
            var data = tbl_qcqf_escunderstandcardbll.GetEntity2(queryJson).ToList();
            foreach (var i in data)
            {
                tbl_qcqf_escunderstandcardbll.RemoveForm(i.GUID.ToString());
            }
            return Success("删除成功。");
        }
        /// <summary>
        /// 删除避灾明白卡
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveFormThree(SingleParam param)
        {
            tbl_qcqf_escunderstandcardbll.RemoveForm((param.KeyValue));
            return Success("删除成功。");
        }
        /// <summary>
        /// 避灾明白卡查询
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJsonEscunderstandcardSearch([FromUri]Pagination pagination, string queryJson)
        {
            // var obj = queryJson.ToJObject();
            //string UNIFIEDCODE = obj.GetValue("UNIFIEDCODE").ToString();//取出queryJson中的某一项值
            var watch = CommonHelper.TimerStart();
            var data = tbl_qcqf_escunderstandcardbll.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// 通过灾害点编号查询工作明白卡
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public TBL_QCQF_WORKUNDERSTANDCARDEntity WORKUNDERSTANDSearch(string keyValue)
        {
            var data = tbl_qcqf_workunderstandcardbll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// 直接操作防灾预案表和工作明白卡
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult QCQFSaveForm([FromBody] parmes par)
        {
            if (!string.IsNullOrWhiteSpace(par.entity.UNIFIEDCODE.ToString()))
            {
                tbl_qcqf_disasterpreventionbll.SaveForm(par.keyValue, par.entity);
                par.entity2.UNIFIEDCODE = par.entity.UNIFIEDCODE;
                tbl_qcqf_workunderstandcardbll.SaveForm(par.keyValue, par.entity2);
                var a = par.entity.GUID;
                var b = par.entity2.GUID;
                return Success("操作成功。", new { a, b });
            }
            else
            {
                return Success("操作失败，灾害点名称不能为空");
            }

        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// 操作避灾明白卡
        /// </summary>
        /// <param name="keyValue">主键值(GUID)</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public TBL_QCQF_ESCUNDERSTANDCARDEntity QCQFSaveForm2([FromBody] parmes par)
        {
            //DateTime dt = DateTime.Now;
            //var year = dt.Year.ToString();
            //if (par.entity3.AGE1 != null)
            //{
            //    par.entity3.AGE1 = year - par.entity3.AGE1.ToString();
            //}
            var data = tbl_qcqf_escunderstandcardbll.SaveForm(par.keyValue, par.entity3);
            // TBL_QCQF_ESCUNDERSTANDCARDEntity entites = GetFormJson3(par.entity3.GUID);
            return data;
            //return Success("操作成功。");
        }
        /// <summary>
        /// 获取防灾预案表实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_QCQF_DISASTERPREVENTIONEntity GetFormJson2(string keyValue)
        {
            var data = tbl_qcqf_disasterpreventionbll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// 获取避灾明白卡实体 
        /// </summary>
        /// <param name="keyValue">主键值(guid)</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_QCQF_ESCUNDERSTANDCARDEntity GetFormJson3(string keyValue)
        {
            var data = tbl_qcqf_escunderstandcardbll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// 避灾明白卡查询
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// 查询条件:
        /// UNIFIEDCODE 灾害点编号
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetJsonEscunderstandcardSearch(string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_qcqf_escunderstandcardbll.GetEntity2(queryJson);
            var jsonData = new
            {
                rows = data,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }

        #endregion
        #region 首页统计扩展
        /// <summary>
        /// 获取字典项统计结果
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetDicAnalyse(string enCode)
        {
            return tbl_hazardbasicinfobll.GetDicAnalyse(enCode);
        }
        #endregion
        #endregion

        #region 集成系统数量统计接口
        /// <summary>
        /// 获取灾害点总数
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetAllListJson()
        {
            var hazard = tbl_hazardbasicinfobll.GetAllList();
            return hazard;
        }
        /// <summary>
        /// 灾害点统计只按灾害类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetHazardStatisticsJson2(string queryJson)
        {
            DataTable dt = tbl_hazardbasicinfobll.GetHazardStatisticsJson2(queryJson);
            string json = DataHelper.DataTableToJson("result", dt);
            return json.ToJson();
        }
        /// <summary>
        /// 接口数量统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetAllAPIJson()
        {
            int count = 0;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type t in types)
            {
                var s = t.BaseType.ToString().Contains("ApiControllerBase");
                if (s)
                {
                    MethodInfo[] pi = t.GetMethods();
                    foreach (var p in pi)
                    {
                        if (p.GetCustomAttributes(typeof(HttpGetAttribute), true).Count() > 0 || p.GetCustomAttributes(typeof(HttpPostAttribute), true).Count() > 0)
                            count++;
                    }
                }
            }
            return count;
        }
        /// <summary>
        /// 获取地图摘要信息
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <param name="condition">可选参数(可以不传)
        /// WKTString:拐点坐标 POLYGON((119.76735720875 35.15413150875,119.76735720875 36.30549869625))
        /// x:中心点横坐标
        /// y:中心点纵坐标
        /// radius:半径(米)
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public object GetZYListJson(string queryJson, string condition = null)
        {
            var data = tbl_hazardbasicinfobll.GetZYPageList(queryJson, condition);
            return data;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="param">主键值</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm(string KeyValue)
        {
            tbl_hazardbasicinfobll.RemoveForm(KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_HAZARDBASICINFOEntity entity)
        {
            tbl_hazardbasicinfobll.SaveForm(keyValue, entity);
            return Success("操作成功。", entity.GUID);
        }

        #endregion

 #region 导入Excel数据

        /// <summary>
        /// 预览Excel数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object ViewExcelData()
        {
            try
            {
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                if (files.Count > 0)
                {
                    var file = files[0];
                    string dir = HttpContext.Current.Server.MapPath("/Temp");
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string filePath = Path.Combine(dir, Guid.NewGuid().ToString() + file.FileName);
                    file.SaveAs(filePath);
                    //读取模板文件,入库数据
                    List<string> sheetNames = ExcelReader.GetExcelSheetName(filePath);
                    DataSet ds = new DataSet();
                    for (int i = sheetNames.Count - 1; i >= 0; i--)
                    {
                        if (sheetNames[i].IndexOf("FilterDatabase") > 0)
                            continue;
                        DataTable dt = ExcelReader.GetExcelContext(filePath, sheetNames[i]);
                        dt.TableName = sheetNames[i];
                        
                        //最多显示100条
                        if (dt.Rows.Count > 100)
                        {
                            DataTable clone = dt.Clone();
                            for (int row = 0; row < 100; row++)
                            {
                                clone.Rows.Add(dt.Rows[row].ItemArray);
                            }
                            ds.Tables.Add(clone);
                        }
                        else
                        {
                            ds.Tables.Add(dt.Copy());
                        }
                    }
                    File.Delete(filePath);
                    return ds;
                }
                else
                {
                    return Error("请选择需要上传的文件！");
                }
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        /// <summary>
        /// 导入Excel模板数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult ImportExcelData()
        {
            try
            {
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                if (files.Count > 0)
                {
                    var file = files[0];
                    string dir = HttpContext.Current.Server.MapPath("/Temp");
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string filePath = Path.Combine(dir, Guid.NewGuid().ToString() + file.FileName);
                    file.SaveAs(filePath);
                    //读取模板文件,入库数据
                    string sheetName = HttpContext.Current.Request.QueryString["SheetName"];
                    DataTable dt = ExcelReader.GetExcelContext(filePath, sheetName + "$");
                    //按照统一编号排序-将有编号的提前
                    dt.DefaultView.Sort = "UNIFIEDCODE ASC";
                    dt = dt.DefaultView.ToTable();

                    if (!dt.Columns.Contains("PROVINCE"))
                    dt.Columns.Add("PROVINCE");

                    if (!dt.Columns.Contains("CITY"))
                        dt.Columns.Add("CITY");

                    if (!dt.Columns.Contains("COUNTYCODE"))
                        dt.Columns.Add("COUNTYCODE");

                    if (!dt.Columns.Contains("TOWN"))
                        dt.Columns.Add("TOWN");

                    if (!dt.Columns.Contains("LOCATION"))
                        dt.Columns.Add("LOCATION");

                    int total = dt.Rows.Count;
                    int success = 0;

                    codeNames = ws.GetCodeNames();
                    List<string> errorRow = new List<string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            SaveRowData(row);
                            success++;
                        }
                        catch (Exception ex)
                        {
                            errorRow.Add(row["NO"].ToString());
                            Logger.Error(ex.Message);
                        }
                    }
                    File.Delete(filePath);
                    return Success(string.Format("导入地质灾害{0}条数据,成功{1}条，失败{2}条。{3}", total, success, total - success, string.Join(",", errorRow)));

                }
                else
                {
                    return Error("请选择需要上传的文件！");
                }
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        /// <summary>
        /// 导入重大隐患点Excel模板数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult ImportExcelZDData()
        {
            try
            {
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                if (files.Count > 0)
                {
                    var file = files[0];
                    string dir = HttpContext.Current.Server.MapPath("/Temp");
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string filePath = Path.Combine(dir, Guid.NewGuid().ToString() + file.FileName);
                    file.SaveAs(filePath);
                    //读取模板文件,入库数据
                    string sheetName = HttpContext.Current.Request.QueryString["SheetName"];
                    DataTable dt = ExcelReader.GetExcelContext(filePath, sheetName + "$");
                    dt.Rows.RemoveAt(0);
                    //导入数据库中已存在编号的点
                    ZDYH zdyh = new ZDYH();
                    zdyh = SearchData(dt);
                    dt = zdyh.data;
                    var nullvalue = string.Join("','", zdyh.list.ToArray());
                    int count = zdyh.list.Count();
                    int total = dt.Rows.Count;
                    int success = 0;
                    List<string> errorRow = new List<string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            SaveRowData2(row);
                            success++;
                        }
                        catch (Exception ex)
                        {
                            errorRow.Add(row["UNIFIEDCODE"].ToString());
                            Logger.Error(ex.Message);
                        }
                    }
                    File.Delete(filePath);
                    return Success(string.Format("导入特大隐患点:{0}条数据,成功:{1}条，失败:{2}条。{3},未找到符合编号数据编号为:'{4}'", total, success, total - success, string.Join(",", errorRow), nullvalue));

                }
                else
                {
                    return Error("请选择需要上传的文件！");
                }
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        private T ConvertToEntity<T>(DataRow row) where T : new()
        {
            T t = new T();
            PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
            foreach (PropertyInfo pi in propertys)
            {
                if (row.Table.Columns.Contains(pi.Name))
                {
                    if (!pi.CanWrite) continue;
                    var value = row[pi.Name];
                    try
                    {
                        if (value != DBNull.Value && value != null && value.ToString() != "")
                        {

                            if (pi.PropertyType.FullName.ToUpper().Contains("DECIMAL"))
                            {
                                pi.SetValue(t, decimal.Parse(value.ToString()), null);
                            }
                            else if (pi.PropertyType.FullName.ToUpper().Contains("DOUBLE"))
                            {
                                pi.SetValue(t, double.Parse(value.ToString()), null);
                            }
                            else if (pi.PropertyType.FullName.ToUpper().Contains("INT32"))
                            {
                                //if (value.ToString().Contains("."))
                                //{

                                //}
                                //pi.SetValue(t, int.Parse(value.ToString()), null);
                                pi.SetValue(t, Convert.ToInt32(value.ToString()), null);
                            }
                            else if (pi.PropertyType.FullName.ToUpper().Contains("INT16"))
                            {
                                if (value.ToString().Contains("."))
                                {

                                }
                                pi.SetValue(t, short.Parse(value.ToString()), null);
                            }
                            else if (pi.PropertyType.FullName.ToUpper().Contains("STRING"))
                            {
                                pi.SetValue(t, value.ToString(), null);
                            }
                            else if (pi.PropertyType.FullName.ToUpper().Contains("DATETIME"))
                            {
                                pi.SetValue(t, DateTime.Parse(value.ToString()), null);
                            }
                            else
                                pi.SetValue(t, value, null);
                        }

                    }
                    catch (Exception ex)
                    {
                        //throw ex;
                    }

                }
            }
            return t;
        }

        private void CheckRow(DataRow sourceRow)
        {
            //检查行政区划编号
           
            string cityName = sourceRow["CITYNAME"].ToString();
            KeyValuePair<string, string> keyValue = codeNames.Where(t => t.Value == cityName).FirstOrDefault();
            sourceRow["CITY"] = sourceRow["CITY"].ToString()==""? keyValue.Key : sourceRow["CITY"];

            sourceRow["PROVINCE"] = sourceRow["PROVINCE"].ToString()==""? (keyValue.Key.Substring(0, 2) + "0000"): sourceRow["PROVINCE"];

            string countyName = sourceRow["COUNTYNAME"].ToString();
            KeyValuePair<string, string> keyValueCounty = codeNames.Where(t => t.Value == countyName).FirstOrDefault();
            sourceRow["COUNTYCODE"] = sourceRow["COUNTYCODE"].ToString()==""? keyValueCounty.Key: sourceRow["COUNTYCODE"];

            sourceRow["LOCATION"] = sourceRow["LOCATION"].ToString()==""?(sourceRow["PROVINCENAME"].ToString() + sourceRow["CITYNAME"].ToString() + sourceRow["COUNTYNAME"].ToString() + sourceRow["TOWNNAME"].ToString() + sourceRow["VILLAGE"].ToString()): sourceRow["LOCATION"];

            //检查统一编号
            object unifiedCode = sourceRow["UNIFIEDCODE"];
            if (unifiedCode == null || string.IsNullOrEmpty(unifiedCode.ToString()) || (unifiedCode.ToString().Length != 12 && unifiedCode.ToString().Length != 16))
            {
                unifiedCode = (keyValueCounty.Key ?? keyValue.Key) + GetTypeCode(sourceRow["DISASTERTYPE"].ToString()) + new Random().Next(1000, 9999);
                while (distinctCodes.Contains(unifiedCode.ToString()))
                {
                    unifiedCode = (keyValueCounty.Key ?? keyValue.Key) + GetTypeCode(sourceRow["DISASTERTYPE"].ToString()) + new Random().Next(1000, 9999);
                }
                sourceRow["UNIFIEDCODE"] = unifiedCode;
            }
            //16位灾害点编号
            else if (unifiedCode.ToString().Length == 16)
            {
                unifiedCode = unifiedCode.ToString().Substring(0, 6) + new Random().Next(10000, 9999) + unifiedCode.ToString().Remove(0, 14);
                while (distinctCodes.Contains(unifiedCode.ToString()))
                {
                    unifiedCode = unifiedCode.ToString().Substring(0, 6) + new Random().Next(10000, 9999) + unifiedCode.ToString().Remove(0, 14);
                }
                sourceRow["UNIFIEDCODE"] = unifiedCode;
            }
            else if (distinctCodes.Contains(unifiedCode.ToString()))
            {
                unifiedCode = unifiedCode.ToString().Substring(0, 8) + new Random().Next(1000, 9999);
                while (distinctCodes.Contains(unifiedCode.ToString()))
                {
                    unifiedCode = unifiedCode.ToString().Substring(0, 8) + new Random().Next(1000, 9999);
                }
                sourceRow["UNIFIEDCODE"] = unifiedCode;
            }
            distinctCodes.Add(unifiedCode.ToString());
        }

        private string GetTypeCode(string disasterType)
        {
            switch (disasterType)
            {
                case "崩塌":
                    return "02";
                case "地面塌陷":
                    return "05";
                case "泥石流":
                    return "03";
                case "地裂缝":
                    return "06";
                case "地面沉降":
                    return "04";
                case "滑坡":
                    return "01";
                case "斜坡":
                    return "00";
                case "滑坡隐患点":
                    return "01";
                case "崩塌隐患点":
                    return "02";
                case "遥感解译点":
                    return "07";
                default:
                    return "02";
            }
        }
        private void SaveRowData2(DataRow row)
        {
            string disasterType = row["DISASTERTYPE"].ToString().Trim();
            string OUTDOORCODE = row["OUTDOORCODE"].ToString().Trim();
            string UNIFIEDCODE = row["UNIFIEDCODE"].ToString().Trim();
            string DISASTERNAME = row["DISASTERNAME"].ToString().Trim();
            string LONGITUDE = row["LONGITUDE"].ToString().Trim();
            string LATITUDE = row["LATITUDE"].ToString().Trim();
            string THREATENPEOPLE = row["THREATENPEOPLE"].ToString().Trim();
            string THREATENASSETS = row["THREATENASSETS"].ToString().Trim();
            var str = string.Empty;
            switch (disasterType)
            {
                case "崩塌":
                    str = "TBL_AVALANCHE";
                    break;
                case "地面塌陷":
                    str = "TBL_COLLAPSE";
                    break;
                case "泥石流":
                    str = "TBL_DEBRISFLOW";
                    break;
                case "地裂缝":
                    str = "TBL_LANDCRACK";
                    break;
                case "地面沉降":
                    str = " TBL_LANDSETTLEMENT";
                    break;
                case "滑坡":
                    str = " TBL_LANDSLIP";
                    break;
                case "斜坡":
                    str = " TBL_SLOPE";
                    break;              
                default:                  
                    break;
            }
            var sql = string.Format("UPDATE  {0}   SET  OUTDOORCODE='{1}',LONGITUDE='{2}',LATITUDE='{3}',THREATENPEOPLE='{4}',THREATENASSETS='{5}'  WHERE  UNIFIEDCODE='{6}' " , str,OUTDOORCODE,LONGITUDE,LATITUDE, THREATENPEOPLE, THREATENASSETS, UNIFIEDCODE);
            //更新灾害点信息表
            var sql2 = string.Format("UPDATE  {0}  SET  OUTDOORCODE='{1}',LONGITUDE='{2}',LATITUDE='{3}',THREATENPEOPLE='{4}',THREATENASSETS='{5}',ISZDYHD='1'  WHERE  UNIFIEDCODE='{6}' ", "TBL_HAZARDBASICINFO", OUTDOORCODE, LONGITUDE, LATITUDE, THREATENPEOPLE, THREATENASSETS, UNIFIEDCODE);
            tbl_hazardbasicinfobll.UpdateForm(sql);
            tbl_hazardbasicinfobll.UpdateForm(sql2);
        }
        private void SaveRowData(DataRow row)
        {
            CheckRow(row);
            string disasterType = row["DISASTERTYPE"].ToString();
            switch (disasterType)
            {
                case "崩塌":
                    TBL_AVALANCHEBLL olBll = new TBL_AVALANCHEBLL();
                    olBll.SaveForm(string.Empty, ConvertToEntity<TBL_AVALANCHEEntity>(row));
                    break;
                case "地面塌陷":
                    TBL_COLLAPSEBLL olBll1 = new TBL_COLLAPSEBLL();
                    olBll1.SaveForm(string.Empty, ConvertToEntity<TBL_COLLAPSEEntity>(row));
                    break;
                case "泥石流":
                    TBL_DEBRISFLOWBLL olBll2 = new TBL_DEBRISFLOWBLL();
                    olBll2.SaveForm(string.Empty, ConvertToEntity<TBL_DEBRISFLOWEntity>(row));
                    break;
                case "地裂缝":
                    TBL_LANDCRACKBLL olBll3 = new TBL_LANDCRACKBLL();
                    olBll3.SaveForm(string.Empty, ConvertToEntity<TBL_LANDCRACKEntity>(row));
                    break;
                case "地面沉降":
                    TBL_LANDSETTLEMENTBLL olBll4 = new TBL_LANDSETTLEMENTBLL();
                    olBll4.SaveForm(string.Empty, ConvertToEntity<TBL_LANDSETTLEMENTEntity>(row));
                    break;
                case "滑坡":
                    TBL_LANDSLIPBLL olBll5 = new TBL_LANDSLIPBLL();
                    olBll5.SaveForm(string.Empty, ConvertToEntity<TBL_LANDSLIPEntity>(row));
                    break;
                case "斜坡":
                    TBL_SLOPEBLL olBll6 = new TBL_SLOPEBLL();
                    olBll6.SaveForm(string.Empty, ConvertToEntity<TBL_SLOPEEntity>(row));
                    break;
                case "滑坡隐患点":
                    TBL_LANDSLIP_HIDDENBLL olBll7 = new TBL_LANDSLIP_HIDDENBLL();
                    olBll7.SaveForm(string.Empty, ConvertToEntity<TBL_LANDSLIP_HIDDENEntity>(row));
                    break;
                case "崩塌隐患点":
                    TBL_AVALANCHE_HIDDENBLL olBll8 = new TBL_AVALANCHE_HIDDENBLL();
                    olBll8.SaveForm(string.Empty, ConvertToEntity<TBL_AVALANCHE_HIDDENEntity>(row));
                    break;
                case "遥感解译点":
                    TBL_SENSEBLL olBll9 = new TBL_SENSEBLL();
                    olBll9.SaveForm(string.Empty, ConvertToEntity<TBL_SENSEEntity>(row));
                    break;
                default:
                    TBL_LANDSLIPBLL olBll10 = new TBL_LANDSLIPBLL();
                    olBll10.SaveForm(string.Empty, ConvertToEntity<TBL_LANDSLIPEntity>(row));
                    break;
            }
        }

        private ZDYH SearchData(DataTable dt)
        {
            ZDYH zdyh = new ZDYH();
            DataTable data = dt.Clone();
            var tablelist = tbl_hazardbasicinfobll.GetValue().ToList();//获取库中灾害点所有数据
            List<string> list = new List<string>();
            //存在 不存在
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow result_dr = data.NewRow();
                var unicode = tablelist.Where(p => p.UNIFIEDCODE.Equals((dt.Rows[i]["UNIFIEDCODE"].ToString()))).Select(p =>p.UNIFIEDCODE).FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(unicode))
                {
                    result_dr["DISASTERTYPE"] = dt.Rows[i]["DISASTERTYPE"].ToString();
                    result_dr["UNIFIEDCODE"] = dt.Rows[i]["UNIFIEDCODE"].ToString();
                    result_dr["OUTDOORCODE"] = dt.Rows[i]["OUTDOORCODE"].ToString();
                    result_dr["DISASTERNAME"] = dt.Rows[i]["DISASTERNAME"].ToString();
                    result_dr["LONGITUDE"] = dt.Rows[i]["LONGITUDE"].ToString();
                    result_dr["LATITUDE"] = dt.Rows[i]["LATITUDE"].ToString();
                    result_dr["THREATENASSETS"] = dt.Rows[i]["THREATENASSETS"].ToString();
                    result_dr["THREATENPEOPLE"] = dt.Rows[i]["THREATENPEOPLE"].ToString();
                    data.Rows.Add(result_dr);
                }
                else
                {
                    list.Add(dt.Rows[i]["UNIFIEDCODE"].ToString());
                }
            }
            zdyh.data = data;
            zdyh.list = list;
            return zdyh;
        }
        public class ZDYH
        {
            public DataTable data { get; set; }
            public List<string> list { get; set; }
        }
        #endregion        /// <summary>
        /// 群测群防新增/修改
        /// </summary>
        public class parmes
        {
            public string keyValue { get; set; }//灾害体编号(主键)
            public string entitys { get; set; }//灾害体编号(主键)
            public string UNIFIEDCODE { get; set; }//灾害体编号(主键)
            public TBL_QCQF_DISASTERPREVENTIONEntity entity { get; set; }//防灾预案表
            public TBL_QCQF_WORKUNDERSTANDCARDEntity entity2 { get; set; }//工作明白卡
            public TBL_QCQF_ESCUNDERSTANDCARDEntity entity3 { get; set; }//避灾明白卡
        }
    }
}