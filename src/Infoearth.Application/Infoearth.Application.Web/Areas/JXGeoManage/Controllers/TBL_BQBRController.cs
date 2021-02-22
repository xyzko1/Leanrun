using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using Infoearth.Util.Offices;
using System;
using System.Data;
using System.Collections.Generic;
using iTelluro.Busness.WebApiProxy;
using Infoearth.Application.Entity;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:25
    /// 描 述：搬迁避让信息表
    /// </summary>
    public class TBL_BQBRController : MvcControllerBase
    {
        private TBL_BQBRBLL tbl_bqbrbll = new TBL_BQBRBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_BQBRIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_BQBRForm()
        {
            return View();
        }
          /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_BQBRResultForm()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_BQBRHZForm()
        {
            return View();
        }
           /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_LSXQ()
        {
            return View();
        }
        /// <summary>
        /// 搬迁避让查询浏览
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_BQBRIndexQueryBrowse()
        {
            return View();
        }
        /// <summary>
        /// 搬迁避让统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_BQBRIndexCountAnalyse()
        {
            return View();
        }
        
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        [LogContent("搬迁避让信息表", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_bqbrbll.GetPageList(pagination, queryJson);
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
        [LogContent("搬迁避让信息表", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_bqbrbll.GetList(queryJson);
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
            var data = tbl_bqbrbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }


        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="queryJson"></param>
         [HttpGet]
        public void GetBQBRStaticsExcelDown(string queryJson)
        { 
            var obj = queryJson.ToJObject();
            string ProvinceName = obj.GetValue("PROVINCENAME").ToString();
            string CityName = obj.GetValue("CITYNAME").ToString();
            string CountyName = obj.GetValue("COUNTRYNAME").ToString();
            string BQBRYEAR = obj.GetValue("Static_Year").ToString();
            string BQBRUNIT = obj.GetValue("Static_Unit").ToString();
            string EXLType = "导出";
            DataTable result = tbl_bqbrbll.BQBRCountStatics(ProvinceName, CityName, CountyName, BQBRYEAR, BQBRUNIT, EXLType);
            int col_num = 0;
            if (result.Columns.Contains("provincename"))
            {
                result.Columns["provincename"].SetOrdinal(col_num);
                result.Columns["provincename"].ColumnName = "省";
                col_num++;
            }
            if (result.Columns.Contains("cityname"))
            {
                result.Columns["cityname"].SetOrdinal(col_num);
                result.Columns["cityname"].ColumnName = "市";
                col_num++;
            }
            if (result.Columns.Contains("countryname"))
            {
                result.Columns["countryname"].SetOrdinal(col_num);
                result.Columns["countryname"].ColumnName = "县";
                col_num++;
            }
            if (result.Columns.Contains("discount"))
            {
                result.Columns["discount"].SetOrdinal(col_num);
                result.Columns["discount"].ColumnName = "灾害点数";
                col_num++;
            }
            if (result.Columns.Contains("bqbrcount"))
            {
                result.Columns["bqbrcount"].SetOrdinal(col_num);
                result.Columns["bqbrcount"].ColumnName = "搬迁避让数";
                col_num++;
            }
            if (result.Columns.Contains("bqbryear"))
            {
                result.Columns["bqbryear"].SetOrdinal(col_num);
                result.Columns["bqbryear"].ColumnName = "搬迁避让年份";
                col_num++;
            } 

            ExcelHelper.ExcelDownloadOnlyDT(result, "搬迁避让数据统计导出", "搬迁避让统计.xls");
        }
         /// <summary>
         /// 关于
         /// </summary>
         /// <param name="queryJson"></param>
         [HttpGet]
         public void GetBQBRStaticsExcelDownNEW(string queryJson)
         {
             var obj = queryJson.ToJObject();
             string codeValue = obj.GetValue("codeValue").ToString();
             string codeType = obj.GetValue("codeType").ToString();
             string xmmc = obj.GetValue("xmmc").ToString();
             string static_Unit = obj.GetValue("static_Unit").ToString();
             string annual = obj.GetValue("annual").ToString();
             DataTable result = tbl_bqbrbll.GetDataBqbrTj(codeValue, codeType, xmmc, annual, static_Unit);
             if (static_Unit == "省")
             {
                 result.Rows.RemoveAt(result.Rows.Count - 1);
             }
             else
             {
                 result.Rows.RemoveAt(0);
             }
             ExcelHelper.ExcelDownloadOnlyDT(result, "搬迁避让数据统计导出", "搬迁避让统计.xls");
             //if (result.Rows.Count > 1)
             //{
             //    int aa= result.Rows.Count - 1;
             //    result.Rows[aa]["省"] = "合计";
             //}
             
         }
        /// <summary>
        /// 对应搬迁避让查询浏览数据导出
        /// </summary>
        /// <param name="queryJson"></param>
        [HttpGet]
         public void ExcelDownloadExt(string queryJson)
        {
            DataTable data = tbl_bqbrbll.GetDataTableList(queryJson);
            ExcelHelper.ExcelDownloadOnlyDT(data, "搬迁避让数据导出", "搬迁避让浏览查询.xls");
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
        [HttpGet]
        public ActionResult GetDataBqbrTj(string codeValue, string codeType, string xmmc, string annual, string static_Unit)
        {
            var data = tbl_bqbrbll.GetDataBqbrTj(codeValue, codeType, xmmc, annual, static_Unit);
            if (data.Rows.Count > 1)
            {
                if (static_Unit == "省")
                {
                    data.Rows.RemoveAt(data.Rows.Count - 1);
                }
                else
                {
                    data.Rows.RemoveAt(0);
                }
                //int a = data.Rows.Count - 1;
                //data.Rows[a]["省"] = "合计";
            }
            switch (static_Unit)
            {
          case "市":
                for (int j = 1; j < data.Rows.Count; j++)
                {
                    object obj = data.Rows[j][1];
                    if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                    {
                        data.Rows[j][0] = "";
                    }

                }
                break;
          case "县":
                for (int j = 1; j < data.Rows.Count; j++)
                {
                    object obj = data.Rows[j][2]; object obj1 = data.Rows[j][1];
                    if (obj1 != null && !string.IsNullOrEmpty(obj1.ToString()))
                    {
                        data.Rows[j][0] = "";
                    }
                    if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                    {
                        data.Rows[j][1] = "";
                        data.Rows[j][0] = "";
                    }
                }
                break;
              }
            return ToJsonResult(data);
           }


        /// <summary>
        /// 搬迁避让统计
        /// </summary>
        /// <param name="queryJson">
        /// AreaCode 行政区划编码
        /// </param>
        /// <returns></returns>
        [HttpGet]
        //public object GetBQBRStatistics(string codeValue, string codeType, string xmmc, string annual, string static_Unit)
        //{
        //    List<string> tempList = new List<string>();
        //    SSOWebApiWS ws = new SSOWebApiWS("");
        //    var queryParam = queryJson.ToJObject();
        //    var result = tbl_bqbrbll.GetDataBqbrTj(codeValue, codeType, xmmc, annual, static_Unit);

        //    int i = 0, j = 0, k = 0, l = 0;
        //    List<TreeBQBRNode> nodes = new List<TreeBQBRNode>();
        //    foreach (var dr in result)
        //    {
        //        //省
        //        TreeBQBRNode dr1 = new TreeBQBRNode()
        //        {
        //            UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
        //            LONGITUDE = dr.LONGITUDE,
        //            LATITUDE = dr.LATITUDE,
        //            level = "0",
        //            id = dr.DISTRICTCODE.ToString().Substring(0, 2) + "0000",
        //            isLeaf = false,
        //            parent = "0",
        //            expanded = true,
        //            data = dr.PROVINCENAME,
        //        };
        //        if (!tempList.Contains(dr.DISTRICTCODE.ToString().Substring(0, 2) + "00"))
        //        {
        //            i++;
        //            dr1.count = i.ToString();
        //            nodes.Add(dr1);
        //            tempList.Add(dr.DISTRICTCODE.ToString().Substring(0, 2) + "00");
        //        }
        //        else
        //        {
        //            var node = nodes.Where(s => s.id.ToString() == dr.DISTRICTCODE.ToString().Substring(0, 2) + "00").ToList();
        //        }
        //        //市
        //        TreeBQBRNode dr2 = new TreeBQBRNode()
        //        {
        //            UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
        //            LONGITUDE = dr.LONGITUDE,
        //            LATITUDE = dr.LATITUDE,
        //            level = "1",
        //            id = dr.DISTRICTCODE.ToString().Substring(0, 4) + "00",
        //            isLeaf = false,
        //            expanded = true,
        //            parent = dr.DISTRICTCODE.ToString().Substring(0, 2) + "0000",
        //            data = dr.CITYNAME,
        //            count = j.ToString()
        //        };
        //        if (!tempList.Contains(dr.DISTRICTCODE.ToString().Substring(0, 4) + "00"))
        //        {

        //            nodes.Add(dr2);
        //            tempList.Add(dr.DISTRICTCODE.ToString().Substring(0, 4) + "00");
        //        }
        //        //县
        //        TreeBQBRNode dr3 = new TreeBQBRNode()
        //        {
        //            UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
        //            LONGITUDE = dr.LONGITUDE,
        //            LATITUDE = dr.LATITUDE,
        //            level = "2",
        //            id = dr.DISTRICTCODE.ToString().Substring(0, 6),
        //            isLeaf = false,
        //            expanded = true,
        //            parent = dr.DISTRICTCODE.ToString().Substring(0, 4) + "00",
        //            data = dr.COUNTYNAME,
        //            count = k.ToString()
        //        };
        //        if (!tempList.Contains(dr.DISTRICTCODE.ToString().Substring(0, 6)))
        //        {
        //            nodes.Add(dr3);
        //            tempList.Add(dr.DISTRICTCODE.ToString().Substring(0, 6));
        //        }
               
        //    }
         
        //    nodes.Sort((a, b) => a.id.CompareTo(b.id));
        //    return ToJsonResult(nodes);
        //}
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("搬迁避让信息表", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_bqbrbll.RemoveForm(keyValue);
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
        [LogContent("搬迁避让信息表", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_BQBREntity entity)
        {
            tbl_bqbrbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
        public class TreeBQBRNode
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
    }
}
