using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Infoearth.Application.Entity;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 关于治理工程WEBAPI接口
    /// 2018-05-12 
    /// niming
    /// </summary>
    public class TBL_ZLGCController : ApiControllerBase
    {
       
        private TBL_ZLGC_BASEINFOBLL tbl_zlgc_baseinfobll = new TBL_ZLGC_BASEINFOBLL();//治理工程基本信息（立项）
        private TBL_ZLGC_KCINFOBLL tbl_zlgc_kcinfobll = new TBL_ZLGC_KCINFOBLL();//治理工程野外勘察
        private TBL_ZLGC_SJINFOBLL tbl_zlgc_sjinfobll = new TBL_ZLGC_SJINFOBLL();//治理工程施工设计
        private TBL_ZLGC_SGINFOBLL tbl_zlgc_sginfobll = new TBL_ZLGC_SGINFOBLL();//治理工程工程施工
        private TBL_ZLGC_JLINFOBLL tbl_zlgc_jlinfobll = new TBL_ZLGC_JLINFOBLL();//治理工程工程监理
        private TBL_ZLGC_YSINFOBLL tbl_zlgc_ysinfobll = new TBL_ZLGC_YSINFOBLL();//治理工程项目验收
        #region 地图聚合
        //[HttpGet]
        //public EchartEntityNEWS GetListCodes()
        //{
        //    var data = tbl_zlgc_baseinfobll.GetListCodes();
        //    return data;
        //}
        #endregion
        #region 获取数据
        /// <summary>
        /// 查询治理工程基本信息列表
        /// 说明queryJson：
        /// NAMESS包含字段:ZLGCNAME--治理工程名称和DISASTERNAME--地质灾害名称
        /// 省市县查询方式：
        /// PROVINCE 省编号（'c1','c2'..）
        /// CITY  市编号
        /// COUNTY 县编号
        /// TOWN 乡镇编号
        /// PROVINCENAME 省名称 模糊匹配
        /// CITYNAME 市名称
        /// COUNTYNAME 县名称
        /// 
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var pa = queryJson.ToJObject();
            var watch = CommonHelper.TimerStart();
           var data = tbl_zlgc_baseinfobll.GetPageList(pagination, queryJson);
           if (pa["zhd"] != null)
           {
               if (pa["zhd"].ToString() == "zhd")
               {
                   data = data.GroupBy(r => r.UNIFIEDCODE).Select(r => r.First());
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
        /// <summary>
        /// 查询治理工程基本信息列表
        /// 说明queryJson：
        /// NAMESS包含字段:ZLGCNAME--治理工程名称和DISASTERNAME--地质灾害名称（新加地图框选）
        /// 省市县查询方式：
        /// PROVINCE 省编号（'c1','c2'..）
        /// CITY  市编号
        /// COUNTY 县编号
        /// TOWN 乡镇编号
        /// PROVINCENAME 省名称 模糊匹配
        /// CITYNAME 市名称
        /// COUNTYNAME 县名称
        /// 
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpPost]
        public object PostPageListJson(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];
            var watch = CommonHelper.TimerStart();
            var data = tbl_zlgc_baseinfobll.GetPageLists(entity.pagination, entity.queryJson, entity.condition);
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
        /// 查询治理工程基本信息列表
        /// 说明queryJson：
        /// NAMESS包含字段:ZLGCNAME--治理工程名称和DISASTERNAME--地质灾害名称（新加地图框选）
        /// 省市县查询方式：
        /// PROVINCE 省编号（'c1','c2'..）
        /// CITY  市编号
        /// COUNTY 县编号
        /// TOWN 乡镇编号
        /// PROVINCENAME 省名称 模糊匹配
        /// CITYNAME 市名称
        /// COUNTYNAME 县名称
        /// 
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpPost]
        public object PostPageListJsonNEW(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];
            var watch = CommonHelper.TimerStart();
            var data = tbl_zlgc_baseinfobll.GetPageLists(entity.pagination, entity.queryJson, entity.condition);          
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
            var data = tbl_zlgc_baseinfobll.GetZYPageList(entity.queryJson, entity.condition);
            var aa = entity.queryJson.ToJObject();
            if (aa["zhd"] != null)
            {
                if (aa["zhd"].ToString() == "zhd")
                {
                    data = data.GroupBy(r => r.UNIFIEDCODE).Select(r => r.First());
                }
            }
            return data;
        }
        ///治理工程不分页
        ///销号用的查询判断
        ///勿动勿动 
        /// <param name="queryJson">查询参数</param>
        [HttpGet]
        public object GetListJson([FromUri]string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_zlgc_baseinfobll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// 获取对应治理工程立项实体信息 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public object GetXMLX([FromUri]string keyValue)
        {
            var data = tbl_zlgc_baseinfobll.GetEntity(keyValue);
            return data;
        }

        /// <summary>
        /// 获取对应治理工程野外勘察实体信息 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public object GetYWKC([FromUri]string keyValue)
        {
            var data = tbl_zlgc_kcinfobll.GetEntity(keyValue);
            return data;
        }
        [HttpGet]
        public object PdState1(string id)
        {
            return tbl_zlgc_baseinfobll.PdState1(id);
        }
        /// <summary>
        /// 获取对应治理工程施工设计实体信息 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public object GetSGSJ([FromUri]string keyValue)
        {
            var data = tbl_zlgc_sjinfobll.GetEntity(keyValue);
            return data;
        }

        /// <summary>
        /// 获取对应治理工程工程监理实体信息 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public object GetGCJL([FromUri]string keyValue)
        {
            var data = tbl_zlgc_jlinfobll.GetEntity(keyValue);
            return data;
        }

        /// <summary>
        /// 获取对应治理工程工程项目验收
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public object GetGCYS([FromUri]string keyValue)
        {
            var data = tbl_zlgc_ysinfobll.GetEntity(keyValue);
            return data;
        }

        /// <summary>
        /// 获取对应治理工程施工设计实体信息中资质清单字段信息列表 
        /// </summary>
        /// <param name="keyValue">主键值工程ID</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public object SGSJ_GetZZQDList([FromUri]string keyValue)
        {
            var data = tbl_zlgc_sjinfobll.GetEntity(keyValue);
            if (data == null)
            {
                return null;
            }
            else
            {
                var ListZZQD = data.ZZQD.ToList<SGSJ_ZZQD>();
                return ListZZQD;
            }
        }

        /// <summary>
        /// 获取对应治理工程施工设计实体信息中区域划分单字段信息列表 
        /// </summary>
        /// <param name="keyValue">主键值工程ID</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public object SGSJ_GetQQHFList([FromUri]string keyValue)
        {
            var data = tbl_zlgc_sjinfobll.GetEntity(keyValue);
            if (data == null)
            {
                return null;
            }
            else
            {
                var ListQYHF = data.ZLQY.ToList<SGSJ_QYHF>();
                return ListQYHF;
            }
        }

        /// <summary>
        /// 获取对应治理工程中工程监理中资质清单信息列表
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public object GCJL_GetZZQDList([FromUri]string keyValue)
        {
            var data = tbl_zlgc_jlinfobll.GetEntity(keyValue);
            if (data == null)
            {
                return null;
            }
            else
            {
                var ListGCJL_ZZQD = data.ZZQD.ToList<GCJL_ZZQD>();
                return ListGCJL_ZZQD;
            }
        }

                
        /// <summary>
        /// 获取对应治理工程施工设计中资质清单单独行信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public object GetZZQDForm([FromUri]string queryJson)
        {
            var obj = queryJson.ToJObject();
            string keyValue = obj.GetValue("keyValue").ToString();
            string ZLGCID = obj.GetValue("ZLGCID").ToString();
            var data = tbl_zlgc_sjinfobll.GetEntity(ZLGCID);
            var ListZZQD = data.ZZQD.ToList<SGSJ_ZZQD>();
            SGSJ_ZZQD Entity = new SGSJ_ZZQD();
            foreach (var item in ListZZQD)
            {
                if (item.ZZQDID == keyValue)
                {
                    Entity = item;
                }
            }
            var ZZQDInfo = Entity;
            return ZZQDInfo;
        }
        
        /// <summary>
        /// 获取对应治理工程施工设计中区域划分单独行信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public object GetQYHFForm([FromUri]string queryJson)
        {
            var obj = queryJson.ToJObject();
            string keyValue = obj.GetValue("keyValue").ToString();
            string ZLGCID = obj.GetValue("ZLGCID").ToString();
            var data = tbl_zlgc_sjinfobll.GetEntity(ZLGCID);
            var ListQYHF = data.ZLQY.ToList<SGSJ_QYHF>();
            SGSJ_QYHF Entity = new SGSJ_QYHF();
            foreach (var item in ListQYHF)
            {
                if (item.QYHFID == keyValue)
                {
                    Entity = item;
                }
            }
            var ZZQDInfo = Entity;
            return ZZQDInfo;
        }

        /// <summary>
        /// 根据工程编号获取工程施工信息列表
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetGCSGPageListJson([FromUri]Pagination pagination,string queryJson)
        {
            //定时器（避免超时）
            var watch = CommonHelper.TimerStart();
            var data = tbl_zlgc_sginfobll.GetListByZLGCID(pagination,queryJson);
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
        /// 获取对应治理工程工程施工实体信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public object GetGCSG([FromUri]string keyValue)
        {
            var data = tbl_zlgc_sginfobll.GetEntity(keyValue);
            return data;
        }

        /// <summary>
        /// 对治理工程应统计中条件
        /// PROVINCENAME 省名称
        /// CITYNAME     市名称
        /// COUNTRYNAME  县名称
        /// Static_Year  统计年份-----暂用XMJLXSJ字段（项目立项时间）
        /// ZLGCUNIT     统计单位
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object ZLGCCountStatics([FromUri]string queryJson)
        {
            var obj = queryJson.ToJObject();
            string ProvinceName = obj.GetValue("PROVINCENAME").ToString();
            string CityName = obj.GetValue("CITYNAME").ToString();
            string CountyName = obj.GetValue("COUNTRYNAME").ToString();
            string ZLGCYEAR = obj.GetValue("Static_Year").ToString();
            string ZLGCUNIT = obj.GetValue("Static_Unit").ToString();
            DataTable result = tbl_zlgc_baseinfobll.ZLGCCountStatics(ProvinceName, CityName, CountyName, ZLGCYEAR, ZLGCUNIT, "");
            return result;
        
        }
        /// <summary>
        /// 对治理工程应统计中条件
        /// PROVINCENAME 省名称
        /// CITYNAME     市名称
        /// COUNTRYNAME  县名称
        /// Static_Year  统计年份-----暂用XMJLXSJ字段（项目立项时间）
        /// ZLGCUNIT     统计单位
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object ZLGCCountStaticsNew([FromUri]string queryJson)
        {
            var obj = queryJson.ToJObject();
            string ProvinceName = obj.GetValue("PROVINCENAME").ToString();
            string CityName = obj.GetValue("CITYNAME").ToString();
            string CountyName = obj.GetValue("COUNTRYNAME").ToString();
            string ZLGCYEAR = obj.GetValue("Static_Year").ToString();
            string ZLGCUNIT = obj.GetValue("Static_Unit").ToString();
            string xzqhcode = obj.GetValue("xzqhcode").ToString();
            DataTable result = tbl_zlgc_baseinfobll.ZLGCCountStaticsNew(xzqhcode,ProvinceName, CityName, CountyName, ZLGCYEAR, ZLGCUNIT);
            return result;
        }
        /// <summary>
        /// 新增治理工程统计方法
        /// </summary>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        [HttpGet]
        public object GetDataZLGCStatics([FromUri]string queryJson)
        {
            var obj = queryJson.ToJObject();
            string ProvinceName = obj.GetValue("PROVINCENAME").ToString();
            string CityName = obj.GetValue("CITYNAME").ToString();
            string CountyName = obj.GetValue("COUNTRYNAME").ToString();
            string ZLGCYEAR = obj.GetValue("Static_Year").ToString();
            string ZLGCUNIT = obj.GetValue("Static_Unit").ToString();
            string xzqhcode = obj.GetValue("xzqhcode").ToString();
            string codeType = obj.GetValue("codeType").ToString();
            DataTable result = tbl_zlgc_baseinfobll.GetDataZLGCStatics(xzqhcode, codeType, ZLGCYEAR, ZLGCUNIT);
            if (result.Rows.Count > 1)
            {
                if (ZLGCUNIT == "省" || ZLGCUNIT == "市")
                {
                    result.Rows.RemoveAt(result.Rows.Count - 1);
                }
                else
                {
                    result.Rows.RemoveAt(0);
                }
                //int a = result.Rows.Count - 1;
                //result.Rows[a]["省"] = "合计";
            }
            switch (ZLGCUNIT)
            {
                case "市":
                    for (int j = 1; j < result.Rows.Count; j++)
                    {
                        object dto = result.Rows[j][1];
                        if (dto != null && !string.IsNullOrEmpty(dto.ToString()))
                        {
                            result.Rows[j][0] = "";
                        }
                    }
                    break;
                case "县":
                    for (int j = 1; j < result.Rows.Count; j++)
                    {
                        object dto = result.Rows[j][2]; object dto1 = result.Rows[j][1];
                        if (dto1 != null && !string.IsNullOrEmpty(dto1.ToString()))
                        {
                            result.Rows[j][0] = "";
                        }
                        if (dto != null && !string.IsNullOrEmpty(dto.ToString()))
                        {
                            result.Rows[j][1] = "";
                            result.Rows[j][0] = "";
                        }
                    }
                    break;
            }
            //return ToJsonResult(result);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetZLGTJResult(string queryJson)
        {
            return tbl_zlgc_baseinfobll.GetZLGTJResult(queryJson);
        }
        //public object GetDataZLGCStatics(string codeValue, string codeType, string ZLGCYEAR, string ZLGCUNIT)
        //{
        //    var data = tbl_zlgc_baseinfobll.GetDataZLGCStatics(codeValue, codeType, ZLGCYEAR, ZLGCUNIT);
        //    if (data.Rows.Count > 1)
        //    {
        //        int a = data.Rows.Count - 1;
        //        data.Rows[a]["省"] = "合计";
        //    }
        //    return ToJsonResult(data);
        //}


        #endregion

        #region 数据提交
        /// <summary>
        /// 工程项目立项主表删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm([FromBody]string keyValue)
        {
           string result= tbl_zlgc_baseinfobll.RemoveForm(keyValue);
           return Success(result);
        }

        /// <summary>
        /// 保存表单（新增、修改）
        /// 治理工程 
        /// </summary>
        /// <param name="keyValue">主键值(GUID)</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm_ZLGC([FromBody] parmesssss par)
        {
            if (par.entityXMLX.XMFZDW != null)//勘察单位不为空
            {
                par.entityXMLX.ZLSTATE = "项目立项";
            }
            if (par.entityYWKC.KCDW != null)//勘察单位不为空
            {
                par.entityXMLX.ZLSTATE = "野外勘察";
            }
            if (par.entitySGSJ.DESIGNDEPT != null)
            {
                par.entityXMLX.ZLSTATE = "施工设计";
            }
            if (par.entityGCJL.JLDEPT != null)
            {
                par.entityXMLX.ZLSTATE = "工程监理";
            }
            if (par.entityGCSG.SGDEPT != null)
            {
                par.entityXMLX.ZLSTATE = "工程施工";
            }
            if (par.entityGCYS.CYDEPT != null)
            {
                par.entityXMLX.ZLSTATE = "项目验收";
            }
            //var aa = tbl_zlgc_baseinfobll.PdState1(par.entityXMLX);
            PASTBL_ZLGC_BASEINFOEntity da = new PASTBL_ZLGC_BASEINFOEntity();
            da = tbl_zlgc_baseinfobll.SaveForm(par.keyValue, par.entityXMLX);//基本信息立项
            var guid = da.GUID;
            string MEDIAGUID = guid;
            string MEDIAGUID2 = string.Empty;
            string MEDIAGUID3 = string.Empty;
            string MEDIAGUID4 = string.Empty;
            string MEDIAGUID5 = string.Empty;
            string MEDIAGUID6 = string.Empty;
            if (par.entityYWKC.KCDW != null)//勘察单位不为空
            {
                par.entityYWKC.ZLGCID = guid;
                par.entityYWKC.ZLGCNAME = par.entityXMLX.ZLGCNAME;
                MEDIAGUID2 = tbl_zlgc_kcinfobll.SaveForm(par.entityYWKC.ZLGCID, par.entityYWKC);  //野外勘察
            }
            if (par.entitySGSJ.DESIGNDEPT != null)
            {
                par.entitySGSJ.ZLGCID = guid;
                par.entitySGSJ.ZLGCNAME = par.entityXMLX.ZLGCNAME;
                MEDIAGUID3 = tbl_zlgc_sjinfobll.SaveForm(par.entitySGSJ.ZLGCID, par.entitySGSJ);//施工设计
            }
            if (par.entityGCJL.JLDEPT != null)
            {
                par.entityGCJL.ZLGCID = guid;
                par.entityGCJL.ZLGCNAME = par.entityXMLX.ZLGCNAME;
                MEDIAGUID4 = tbl_zlgc_jlinfobll.SaveForm(par.entityGCJL.ZLGCID, par.entityGCJL);//工程监理
            }
            //if (par.entityGCSG.SGDEPT != null)
            //{
            //    par.entityGCSG.ZLGCID = guid;
            //    par.entityGCSG.ZLGCNAME = par.entityXMLX.ZLGCNAME;
            //    MEDIAGUID6 = tbl_zlgc_sginfobll.SaveForm(par.keyValue, par.entityGCSG);//工程监理
            //}
            if (par.entityGCYS.CYDEPT != null)
            {
                par.entityGCYS.ZLGCID = guid;
                par.entityGCYS.ZLGCNAME = par.entityXMLX.ZLGCNAME;
                MEDIAGUID5 = tbl_zlgc_ysinfobll.SaveForm(par.entityGCYS.ZLGCID, par.entityGCYS);  //项目验收
            }

            string result = "";
            if (par.keyValue != "" || par.keyValue != null)
            {
                result = "编辑成功。";
            }
            else
            {
                result = "新增成功。";
            }
            return Success(result, new { MEDIAGUID, MEDIAGUID2, MEDIAGUID3, MEDIAGUID4, MEDIAGUID5, MEDIAGUID6 });
        }

        /// <summary>
        /// 工程施工-保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult GCSG_SaveForm([FromBody] GCSGEntity par)
        {
           var MEDIAGUID= tbl_zlgc_sginfobll.SaveForm(par.entityGCSG.GUID, par.entityGCSG);
           var result = "保存成功";
           return Success(result, new { MEDIAGUID});
        }

        /// <summary>
        /// 工程施工-删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult GCSG_RemoveForm([FromBody]string keyValue)
        {
            tbl_zlgc_sginfobll.RemoveForm(keyValue);
            return Success("删除成功。");
        }

        #endregion
        //治理工程所包含的实体列表    
        public class parmesssss
        {
            public string keyValue { get; set; }//灾害体编号(主键)
            public TBL_ZLGC_BASEINFOEntity entityXMLX { get; set; }//治理工程基本信息表（暂时拟定立项表）
            public TBL_ZLGC_JLINFOEntity entityGCJL { get; set; } //治理工程监理信息表
            public TBL_ZLGC_KCINFOEntity entityYWKC { get; set; }  //治理工程野外勘察
            public TBL_ZLGC_SGINFOEntity entityGCSG { get; set; }  //治理工程工程施工
            public TBL_ZLGC_SJINFOEntity entitySGSJ { get; set; }  //治理工程工程施工设计
            public TBL_ZLGC_YSINFOEntity entityGCYS { get; set; }  //治理工程工程验收
           
        }
        //治理工程施工设计：资质清单
        public class SGSJ_ZZQD {
            public string ZZQDID { get; set; }
            public string NAME { get; set; }
            public string ZZLEVE { get; set; }
            public string BZ { get; set; }
        }
        //治理工程施工设计：治理区域划分
        public class SGSJ_QYHF {
            public string QYHFID { get; set; }
            public string QYHFNAME { get; set; }
            public string LONGITUDE { get; set; }
            public string LATITUDE { get; set; }
            public string ZLAREA { get; set; }
        }
        //治理工程工程监理：资质清单
        public class GCJL_ZZQD
        {
            public string JLZZQDID { get; set; }
            public string JLZZNAME { get; set; }
            public string JLZZLEVE { get; set; }
            public string JLBZ { get; set; }
        }
        public class GCSGEntity {
            public string keyValue { get; set; }//灾害体编号(主键)
            public TBL_ZLGC_SGINFOEntity entityGCSG { get; set; }//治理工程工程施工表（暂时拟定立项表）
        }
    }
}
