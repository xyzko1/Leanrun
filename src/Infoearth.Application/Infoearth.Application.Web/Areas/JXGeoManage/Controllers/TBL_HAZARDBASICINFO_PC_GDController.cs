using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using Infoearth.Application.Entity.SystemManage;
using System.Linq;
using Infoearth.Application.Cache;
using Infoearth.Util.Offices;
using System;
using System.Data;
using System.Collections;
using Infoearth.Application.Entity;
using iTelluro.Busness.WebApi;
using Infoearth.Application.Web.Utility;
using System.IO;
using System.Web;
using Infoearth.Application.Common;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-07 16:09
    /// 描 述：排查数据表
    /// </summary>
    public class TBL_HAZARDBASICINFO_PC_GDController : MvcControllerBase
    {
        private TBL_HAZARDBASICINFO_PC_GDBLL tbl_hazardbasicinfo_pc_gdbll = new TBL_HAZARDBASICINFO_PC_GDBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_HAZARDBASICINFO_PC_GDIndex()
        {
            return View();
        }
        [HttpGet]
        [Login]
        public ActionResult StatisticeContext()
        {
            return View();
        }
        [HttpGet]
        [Login]
        public ActionResult TBL_HAZARDBASICINFO_PC_GDBrowser()
        {
            return View();
        }
        [HttpGet]
        [Login]
        public ActionResult TBL_HAZARDBASICINFO_PC_GDTJ()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_HAZARDBASICINFO_PC_GDForm()
        {
            return View();
        }
        #endregion
        #region 导出excel
        [HttpGet]
        public void Exportexcel(string queryJson)
        {
            List<TBL_HAZARDBASICINFO_PC_GDEntity> list = tbl_hazardbasicinfo_pc_gdbll.GetList(queryJson).ToList();
            DataTable dt = DataHelper.ListToDataTable<TBL_HAZARDBASICINFO_PC_GDEntity>(list);
            DataTable data = new DataTable();
            #region 增加表头
            data.Columns.Add("灾害体类型");
            data.Columns.Add("排查编号");
            data.Columns.Add("统一编号");
            data.Columns.Add("市");
            data.Columns.Add("县");
            data.Columns.Add("街道");
            data.Columns.Add("行政区划编号");
            data.Columns.Add("隐患点位置");
            data.Columns.Add("隐患点状态");
            data.Columns.Add("经度");
            data.Columns.Add("纬度");
            data.Columns.Add("灾害体规模");
            data.Columns.Add("稳定性");
            data.Columns.Add("危害性");
            data.Columns.Add("威胁人员");
            data.Columns.Add("潜在经济损失(万元)");
            data.Columns.Add("监测责任人");
            data.Columns.Add("联系电话");
            data.Columns.Add("手机");
            data.Columns.Add("监测人");
            data.Columns.Add("联系电话1");
            data.Columns.Add("手机1");
            data.Columns.Add("防治对策");
            data.Columns.Add("有没应急预案");
            data.Columns.Add("工作措施");
            data.Columns.Add("备注");
            #endregion
            #region 赋值
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow result = data.NewRow();
                result["灾害体类型"] = dt.Rows[i]["DISASTERTYPE"].ToString();
                result["排查编号"] = dt.Rows[i]["PCUNIFIEDCODE"].ToString();
                result["统一编号"] = dt.Rows[i]["UNIFIEDCODE"].ToString();
                result["市"] = dt.Rows[i]["CITY"].ToString();
                result["县"] = dt.Rows[i]["COUNTY"].ToString();
                result["街道"] = dt.Rows[i]["STREET"].ToString();
                result["行政区划编号"] = dt.Rows[i]["XZQHCODE"].ToString();
                result["隐患点位置"] = dt.Rows[i]["LOCATION"].ToString();
                result["隐患点状态"] = dt.Rows[i]["YHSTATE"].ToString();
                result["经度"] = dt.Rows[i]["LONGITUDE"].ToString();
                result["纬度"] = dt.Rows[i]["LATITUDE"].ToString();
                result["灾害体规模"] = dt.Rows[i]["SCALE"].ToString();
                result["稳定性"] = dt.Rows[i]["CURSTABLESTATUS"].ToString();
                result["危害性"] = dt.Rows[i]["DESTROYEDOBJECT"].ToString();
                result["威胁人员"] = dt.Rows[i]["THREATENPEOPLE"].ToString();
                result["潜在经济损失(万元)"] = dt.Rows[i]["INDIRECTLOSS"].ToString();
                result["监测责任人"] = dt.Rows[i]["MONITORINGPEOPLE"].ToString();
                result["联系电话"] = dt.Rows[i]["TELEPHONE"].ToString();
                result["手机"] = dt.Rows[i]["PHONE"].ToString();
                result["监测人"] = dt.Rows[i]["JCPEOPLE"].ToString();
                result["联系电话1"] = dt.Rows[i]["TELEPHONE1"].ToString();
                result["手机1"] = dt.Rows[i]["PHONE1"].ToString();
                result["防治对策"] = dt.Rows[i]["COUNTERMEASURES"].ToString();
                result["有没应急预案"] = dt.Rows[i]["YJPLAN"].ToString();
                result["工作措施"] = dt.Rows[i]["WORKMEASURES"].ToString();
                result["备注"] = dt.Rows[i]["REMARKS"].ToString();
                data.Rows.Add(result);
            } 
            #endregion          
            ExcelHelper.ExcelDownloadOnlyDT(data, "排查数据", string.Format("排查数据导出{0}.xls",DateTime.Now.ToLongDateString().ToString()));
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
        [LogContent("排查数据表", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_hazardbasicinfo_pc_gdbll.GetPageList(pagination, queryJson);
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
        [LogContent("排查数据表", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_hazardbasicinfo_pc_gdbll.GetList(queryJson);
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
            var data = tbl_hazardbasicinfo_pc_gdbll.GetEntity(keyValue);
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
        [LogContent("排查数据表", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_hazardbasicinfo_pc_gdbll.RemoveForm(keyValue);
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
        [LogContent("排查数据表", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_HAZARDBASICINFO_PC_GDEntity entity)
        {
            tbl_hazardbasicinfo_pc_gdbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion

       
    }
}
