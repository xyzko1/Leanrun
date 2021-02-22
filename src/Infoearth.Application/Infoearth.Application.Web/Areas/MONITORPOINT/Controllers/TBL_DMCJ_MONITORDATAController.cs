using Infoearth.Application.Busines.MONITORPOINT;
using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Util.Offices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infoearth.Application.Web.Controllers;

namespace Infoearth.Application.Web.Areas.MONITORPOINT.Controllers
{
    public class TBL_DMCJ_MONITORDATAController : MvcControllerBase
    {
        private TBL_DMCJ_MONITORDATABLL tbl_dmcj_monitorpointbll = new TBL_DMCJ_MONITORDATABLL();
        #region 视图功能
        /// <summary>
        /// 监测数据统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult MonitorDataStatistics()
        {
            return View();
        }
        #endregion
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("地面沉降监测点信息表", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_DMCJ_MONITORDATAEntity entity)
        {
            tbl_dmcj_monitorpointbll.SaveEntity(keyValue, entity);
            return Success("操作成功。");
        }
        [HttpGet]
        [AjaxOnly]
        [LogContent("监测数据统计", OpType.Query)]
        public ActionResult GetQueryList(string queryJson)
        {
            try
            {
                string guid = string.Empty;
                List<string> columns = new List<string>();
                string json = string.Empty;
                DataTable result = tbl_dmcj_monitorpointbll.GetQueryList(queryJson);
                foreach (DataColumn item in result.Columns)
                {
                    columns.Add(item.ColumnName);
                }
                var jsonData = new
                {
                    Columns = columns,
                    Data = result
                };
                return ToJsonResult(jsonData);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="tybh"></param>
        [HttpGet]
        public void ExcelDownload(string queryJson)
        {
            try
            {

                DataTable result = tbl_dmcj_monitorpointbll.GetQueryList(queryJson);
                string Name = "监测数据统计";
                result.TableName = Name;

                string fileName = Name + "-" + DateTime.Now.ToString("yyyy.MM.dd") + ".xls";
                ExcelHelper.ExcelDownloadOnlyDT(result, Name, fileName);
            }
            catch
            {

            }
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="tybh"></param>
        [HttpGet]
        public void ExcelDownloadByMonitorPoint(string queryJson)
        {
            try
            {

                DataTable result = tbl_dmcj_monitorpointbll.GetQueryListByMonitorPoint(queryJson);
                string Name = "监测数据";
                result.TableName = Name;

                string fileName = Name + "-" + DateTime.Now.ToString("yyyy.MM.dd") + ".xls";
                ExcelHelper.ExcelDownloadOnlyDT(result, Name, fileName);
            }
            catch
            {

            }
        }
          /// <summary>
        /// 监测数据(导出Excel)
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="outColumn"></param>
        [HttpGet]
        public void ExcelDownload_Data(string queryJson, string outColumn)
        {
            var list = tbl_dmcj_monitorpointbll.GetList(queryJson).ToList();

            string[] columnArr = outColumn.TrimEnd(',').Split(',');//要导出的列

            List<ColumnEntity> ColumnList = new List<ColumnEntity>();
            IDictionary<string, string> dicArr = UtilityController.GetAllPropertyDic<TBL_DMCJ_MONITORDATAQuery>();//获取字典字段
            //显示列
            foreach (var item in dicArr.Keys)
            {
                if (columnArr.Contains(item))
                {
                    ColumnList.Add(new ColumnEntity { Column = item, ExcelColumn = dicArr[item], Width = 30 });
                }
            }
            UtilityController.ConvertDicValue(list);//字典项赋值
            ExcelConfig excelConfig = new ExcelConfig();
            excelConfig.IsAllSizeColumn = true;
            excelConfig.ColumnEntity = ColumnList;
            excelConfig.FileName = "监测点查询-" + DateTime.Now.ToString("yyyy.MM.dd") + ".xls";
            excelConfig.Title = "监测点查询";
            ExcelHelperEx<TBL_DMCJ_MONITORDATAQuery>.ExcelDownload(list, excelConfig, true);


        }
    }
}