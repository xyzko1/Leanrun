using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System.Net;
using System;
using System.Net.Http;
using System.Web;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using iTelluro.Busness.WebApiProxy;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-13 13:34
    /// 描 述：地质灾害应急调查数据管理
    /// </summary>
    public class TBL_YJDC_YJDCMANAGEMENTController : MvcControllerBase
    {
        private TBL_YJDC_YJDCMANAGEMENTBLL tbl_yjdc_yjdcmanagementbll = new TBL_YJDC_YJDCMANAGEMENTBLL();

        private YJDCMANAGEMENTWS yjdcWs = new YJDCMANAGEMENTWS("");

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_YJDC_YJDCMANAGEMENTIndex()
        {
            return View();
        }
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_YJDC_YJDCMANAGEMENTViewIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_YJDC_YJDCMANAGEMENTForm()
        {
            return View();
        }
        /// <summary>
        /// 调查报告页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_YJDC_YJDCInvestigationReport()
        {
            return View();
        }
        
        /// <summary>
        /// 对应辅助月报页面
        /// </summary>
        /// <returns></returns>
        public ActionResult TBL_YJDC_YJDCMONTHLYReport()
        {
            return View();
        }


        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var result = yjdcWs.GetListJson(queryJson);
            return ToJsonResult(result);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        [LogContent("应急调查数据管理", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = yjdcWs.GetPageListJson(pagination, queryJson);
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
        /// 统计页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_YJDC_YJDCMANAGEMENTStatisticIndex()
        {
            return View();
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpPost]
        [LogContent("应急调查数据管理删除", OpType.Query)]
        public ActionResult EMERGENCYSURVEYApi_RemoveForm(string keyValue)
        {
            var watch = CommonHelper.TimerStart();
            var data = yjdcWs.EMERGENCYSURVEYApi_RemoveForm(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        [LogContent("应急调查数据管理删除", OpType.Query)]
        public ActionResult EMERGENCYSURVEYApi_GetFormJson(string keyValue)
        {
            var watch = CommonHelper.TimerStart();
            var data = yjdcWs.GetEntity(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 根据行政区划市代码、年份、月份获取对应的应急调查辅助月报信息
        /// </summary>
        /// <param name="districtCodes"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EMERGENCYSURVEYApi_GetFZMonthReport(string city, string year, string month)
        {

            var data = yjdcWs.EMERGENCYSURVEYApi_GetFZMonthReport(city, year, month);
            return ToJsonResult(data); ;
        }


        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult EMERGENCYSURVEYApi_SaveForm(string keyValue, TBL_YJDC_EMERGENCYSURVEYEntity entity)
        {
            var data=yjdcWs.EMERGENCYSURVEYApi_SaveForm(keyValue, entity);
            //tbl_yjdc_yjdcmanagementbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        /// <summary>
        /// 根据行政区划获得对应的应急调查数据
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public ActionResult GetInfoStatistics(string queryJson)
        {

            var data = yjdcWs.GetInfoStatistics(queryJson);
            return ToJsonResult(data); ;
        }



        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = tbl_yjdc_yjdcmanagementbll.GetEntity(keyValue);
            return ToJsonResult(data);
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
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_yjdc_yjdcmanagementbll.RemoveForm(keyValue);
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
        public ActionResult SaveForm(string keyValue, TBL_YJDC_YJDCMANAGEMENTEntity entity)
        {
            tbl_yjdc_yjdcmanagementbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
