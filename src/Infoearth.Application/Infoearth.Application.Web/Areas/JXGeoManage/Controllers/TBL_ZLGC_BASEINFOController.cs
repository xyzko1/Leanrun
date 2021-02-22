using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System;
using System.Data;
using Infoearth.Util.Offices;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:27
    /// 描 述：治理工程信息表
    /// </summary>
    public class TBL_ZLGC_BASEINFOController : MvcControllerBase
    {
        private TBL_ZLGC_BASEINFOBLL tbl_zlgc_baseinfobll = new TBL_ZLGC_BASEINFOBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_ZLGC_BASEINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_BASEINFOForm()
        {
            return View();
        }
        /// <summary>
        /// 添加治理工程
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ADDBASEINFO()
        {
            return View();
        }
        /// <summary>
        /// 添加治理工程查询浏览页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_BASEINFOIndexQueryBrowse()
        {
            return View();
        }
        /// <summary>
        /// 添加治理工程统计页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_BASEINFOIndexCountAnalyse()
        {
            return View();
        }
        /// <summary>
        /// 添加治理工程基础数据管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_BASICAMANAGE()
        {
            return View();
        }
        /// <summary>
        /// 查看治理工程统计信息结果
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_TJResultForm()
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
        [LogContent("治理工程信息表", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_zlgc_baseinfobll.GetPageList(pagination, queryJson);
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
        [LogContent("治理工程信息表", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_zlgc_baseinfobll.GetList(queryJson);
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
            var data = tbl_zlgc_baseinfobll.GetEntity(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 治理工程查询浏览导出功能
        /// </summary>
        /// <param name="queryJson"></param>
        public void ExcelZLGCDownloadExt(string queryJson)
        {
            var data = tbl_zlgc_baseinfobll.GetListS(queryJson);
            DataTable result = new DataTable();
            result.Columns.Add("工程名称");
            result.Columns.Add("灾害点编号");
            result.Columns.Add("灾害点名称");
            result.Columns.Add("灾害点类型");
            result.Columns.Add("经度");
            result.Columns.Add("纬度");  
            result.Columns.Add("立项时间");
            result.Columns.Add("批复资金(万元)");
            result.Columns.Add("负责单位");
            result.Columns.Add("批准部门");
            result.Columns.Add("批准文号");
            result.Columns.Add("建设单位");
            result.Columns.Add("工程地理位置");
            result.Columns.Add("省");
            result.Columns.Add("市");
            result.Columns.Add("县");
            foreach (var item in data)
            {
                DataRow result_dr = result.NewRow();
                result_dr["工程名称"] = item.ZLGCNAME;
                result_dr["灾害点编号"] = item.UNIFIEDCODE;
                result_dr["灾害点名称"] = item.DISASTERNAME;
                result_dr["灾害点类型"] = item.DISASTERTYPE;
                result_dr["经度"] = item.LONGITUDE;
                result_dr["纬度"] = item.LATITUDE;
                result_dr["立项时间"] = item.XMJLXSJ;
                result_dr["批复资金(万元)"] = item.XMPFZJ;
                result_dr["负责单位"] = item.XMFZDW;
                result_dr["批准部门"] = item.XMPZBM;
                result_dr["批准文号"] = item.XMPZWH;
                result_dr["建设单位"] = item.XMJSDW;
                result_dr["工程地理位置"] = item.LOCATION;
                result_dr["省"] = item.PROVINCENAME;
                result_dr["市"] = item.CITYNAME;
                result_dr["县"] = item.COUNTYNAME;
                result.Rows.Add(result_dr);
            }
            ExcelHelper.ExcelDownloadOnlyDT(result, "治理工程数据导出", "治理工程浏览查询.xls");
        }

        /// <summary>
        /// 关于治理工程统计导出功能
        /// </summary>
        /// <param name="queryJson"></param>
        public void ExcelZLGCCountDownloadExt(string queryJson)
        {
            var obj = queryJson.ToJObject();
            string ProvinceName = obj.GetValue("PROVINCENAME").ToString();
            string CityName = obj.GetValue("CITYNAME").ToString();
            string CountyName = obj.GetValue("COUNTRYNAME").ToString();
            string ZLGCYEAR = obj.GetValue("Static_Year").ToString();
            string ZLGCUNIT = obj.GetValue("Static_Unit").ToString();
            DataTable result = tbl_zlgc_baseinfobll.ZLGCCountStatics(ProvinceName, CityName, CountyName, ZLGCYEAR, ZLGCUNIT, "");
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
            if (result.Columns.Contains("disastercount"))
            {
                result.Columns["disastercount"].SetOrdinal(col_num);
                result.Columns["disastercount"].ColumnName = "灾害点个数";
                col_num++;
            }
            if (result.Columns.Contains("zlgccount"))
            {
                result.Columns["zlgccount"].SetOrdinal(col_num);
                result.Columns["zlgccount"].ColumnName = "治理工程个数";
                col_num++;
            }
            ExcelHelper.ExcelDownloadOnlyDT(result, "治理工程统计", "治理工程统计导出.xls");
        }
        /// <summary>
        /// 治理工程统计导出功能(新）
        /// </summary>
        /// <param name="queryJson">查询条件</param>
        public ActionResult ExcelZLGCCountDownloadExtNew(string queryJson)
        {
            var obj = queryJson.ToJObject();
            //string ProvinceName = obj.GetValue("PROVINCENAME").ToString();
            //string CityName = obj.GetValue("CITYNAME").ToString();
            //string CountyName = obj.GetValue("COUNTRYNAME").ToString();
            string ZLGCYEAR = obj.GetValue("yearZLGC").ToString();
            string ZLGCUNIT = obj.GetValue("unitZLGC").ToString();
            string xzqhcode = obj.GetValue("xzqhcode").ToString();
            string codeType = obj.GetValue("codeType").ToString();
            string ISDAOCHU = obj.GetValue("ISDAOCHU").ToString();
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
                if (ISDAOCHU == "true")
                {
                    ExcelHelper.ExcelDownloadOnlyDT(result, "治理工程统计", "治理工程统计.xls");
                }
                return ToJsonResult(true);
            }
            else
            {
                return ToJsonResult(false); ;
            }      
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
        [LogContent("治理工程信息表", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_zlgc_baseinfobll.RemoveForm(keyValue);
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
        [LogContent("治理工程信息表", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_ZLGC_BASEINFOEntity entity)
        {
            tbl_zlgc_baseinfobll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }

        /// <summary>
        /// 新的保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("治理工程信息表", OpType.Update)]
        public ActionResult SaveForm_New(string keyValue, TBL_ZLGC_BASEINFOEntity entity)
        {
            string result = tbl_zlgc_baseinfobll.SaveForm_New(keyValue, entity);
            return Success_New("操作成功," + result + "");
        }
        /// <summary>
        /// 虚方法对应修改保存方法返回参数增加GUID
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual ActionResult Success_New(string message)
        {
            string message1 = message.Split(',')[0].ToString();
            string message2 = message.Split(',')[1].ToString();
            return Content(new AjaxResult { type = ResultType.success, message = message1, resultdata = message2 }.ToJson());
        }


        #endregion
    }
}
