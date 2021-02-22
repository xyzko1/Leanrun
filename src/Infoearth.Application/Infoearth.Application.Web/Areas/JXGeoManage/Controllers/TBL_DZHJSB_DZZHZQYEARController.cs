using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System.Data;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using iTelluro.Busness.WebApiProxy;
using iTelluro.Busness.WebApi;
using System.Web;
using System;
using System.Collections.Generic;
using Infoearth.Application.Busines;
using System.Linq;
namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-08 15:58
    /// 描 述：TBL_DZHJSB_DZZHZQYEAR
    /// </summary>
    public class TBL_DZHJSB_DZZHZQYEARController : MvcControllerBase
    {
        private TBL_DZHJSB_DZZHZQYEARBLL tbl_dzhjsb_dzzhzqyearbll = new TBL_DZHJSB_DZZHZQYEARBLL();
        private TBL_DZHJSB_DZZHFZYEARBLL tbl_dzhjsb_dzzhfzyearbll = new TBL_DZHJSB_DZZHFZYEARBLL();
        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DZHJSB_DZZHZQYEARIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DZHJSB_DZZHZQTJHZIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DZHJSB_DZZHZQYEARForm()
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
        [LogContent("TBL_DZHJSB_DZZHZQYEAR", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_dzhjsb_dzzhzqyearbll.GetList(queryJson);
            return ToJsonResult(data);
        }

        public static List<TBL_DZHJSB_DZZHZQYEAREntity> testListDZZHZQYEAR = new List<TBL_DZHJSB_DZZHZQYEAREntity>();
        public static List<TBL_DZHJSB_DZZHFZYEAREntity> testListDZZHFZYEAR = new List<TBL_DZHJSB_DZZHFZYEAREntity>();
        public ActionResult ImportExcelDataSave(string YEAR, string BBTYPE)
        {

            if (BBTYPE == "1")
            {
                if (testListDZZHZQYEAR.Count > 0 && testListDZZHZQYEAR != null && !string.IsNullOrEmpty(YEAR))
                {
                    List<TBL_DZHJSB_DZZHZQYEAREntity> testList = new List<TBL_DZHJSB_DZZHZQYEAREntity>();
                    var oldlist = tbl_dzhjsb_dzzhzqyearbll.GetList(null);
                    foreach (var item in testListDZZHZQYEAR)
                    {
                        short y = Convert.ToInt16(YEAR);
                        var newlist = oldlist.Where(s => s.DISASTERYEAR == y && s.CITYNAME == item.CITYNAME).ToList();
                        if (newlist.Count > 0)
                        {
                            tbl_dzhjsb_dzzhfzyearbll.RemoveForm(newlist.FirstOrDefault().GUID);
                        }
                        item.DISASTERYEAR = y;
                        tbl_dzhjsb_dzzhzqyearbll.SaveForm(null, item);
                    }
                }
                return Success("操作成功。");
            }
            else if (BBTYPE == "2")
            {
                if (testListDZZHFZYEAR.Count > 0 && testListDZZHFZYEAR != null && !string.IsNullOrEmpty(YEAR))
                {
                    List<TBL_DZHJSB_DZZHFZYEAREntity> testList = new List<TBL_DZHJSB_DZZHFZYEAREntity>();
                    var oldlist = tbl_dzhjsb_dzzhfzyearbll.GetList(null);
                    foreach (var item in testListDZZHFZYEAR)
                    {
                        short y = Convert.ToInt16(YEAR);
                        var newlist = oldlist.Where(s => s.DISASTERYEAR == y && s.CITYNAME == item.CITYNAME).ToList();
                        if (newlist.Count > 0)
                        {
                            tbl_dzhjsb_dzzhfzyearbll.RemoveForm(newlist.FirstOrDefault().GUID);
                        }
                        item.DISASTERYEAR = y;
                        tbl_dzhjsb_dzzhfzyearbll.SaveForm(null, item);
                    }
                }
                return Success("操作成功。");
            }
            return Error("没有获取到excel中的数据。");
        }



        [HttpPost]
        [AjaxOnly]
        public ActionResult ImportExcelData(string YEAR, string BBTYPE)
        {
            try
            {
                System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                if (files.Count > 0)
                {
                    var file = files[0];
                    string dir = System.Web.HttpContext.Current.Server.MapPath("/Temp");
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string filePath = Path.Combine(dir, Guid.NewGuid().ToString() + file.FileName);
                    file.SaveAs(filePath);
                    DataTable data = DataTableToEntity.GetData(filePath) as DataTable;
                    DataTable newdata = new DataTable();
                    if (data.Rows.Count <= 2)
                    {
                        return ToJsonResult("无数据");
                    }
                    var type = data.Rows[1][0].ToString().Split(':');
                    if (type[1]!="年报")
                    {
                        return ToJsonResult("请选择正确的报表类型。");
                    }
                    if (BBTYPE != type[1])
                    {
                        System.IO.File.Delete(filePath);
                        return ToJsonResult(type[0]+"类型不一致。");
                    }
                    for (int i = 0; i < data.Columns.Count; i++)
                    {
                        newdata.Columns.Add(data.Rows[2][i].ToString());
                    }
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (i > 3)
                        {
                            DataRow dr = newdata.NewRow();
                            dr = data.Rows[i];
                            if (newdata.Rows.Count > 0 && newdata.Rows.Count != i + 1)
                            {
                                dr[0] = newdata.Rows[0][0].ToString();
                            }
                            newdata.Rows.Add(dr.ItemArray);
                            //newdata.ImportRow(dr);
                        }
                    }
                    System.IO.File.Delete(filePath);
                    if (newdata != null)
                    {
                        if (BBTYPE == "1")
                        {
                            testListDZZHZQYEAR = newdata.ConvertToModel<TBL_DZHJSB_DZZHZQYEAREntity>();
                            return ToJsonResult(testListDZZHZQYEAR);
                        }
                        else
                        {
                            testListDZZHFZYEAR = newdata.ConvertToModel<TBL_DZHJSB_DZZHFZYEAREntity>();
                            return ToJsonResult(testListDZZHFZYEAR);
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = tbl_dzhjsb_dzzhzqyearbll.GetEntity(keyValue);
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
        [LogContent("TBL_DZHJSB_DZZHZQYEAR", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_dzhjsb_dzzhzqyearbll.RemoveForm(keyValue);
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
        [LogContent("TBL_DZHJSB_DZZHZQYEAR", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_DZHJSB_DZZHZQYEAREntity entity)
        {
            tbl_dzhjsb_dzzhzqyearbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }

        /// <summary>
        /// 导入年报
        /// </summary>
        [HttpGet]
        public ActionResult ImportYearReport(string year, string ReportType, string FilePath)
        {

            DataTable oldTable = ExcelSheetImportToDataTable(ReportType, FilePath);
            return null;
        }

        ///// <summary>
        ///// 导出年报
        ///// </summary>
        //[HttpGet]
        //public ActionResult ExportYearReport(string year, string ReportType, string FilePath)
        //{

        //    DataTable oldTable = ExcelSheetImportToDataTable(ReportType, FilePath);
        //    return null;
        //}

        public DataTable ExcelSheetImportToDataTable(string typeName, string filePath)
        {
            DataTable dt = new DataTable();

            int takeRow = 2;//跳过的行数
            //deleted by cxy on 2018.1.17  for 地质环境监测网络情况年报表 excel文件读取失败
            //if (typeName == "地质环境监测网络情况年报表")
            //{
            //    takeRow = 3;
            //}
            //deleted end 

            //if (Path.GetExtension(filePath).ToLower() == ".xls".ToLower())
            //{
            #region .xls文件处理:HSSFWorkbook

            HSSFWorkbook hssfworkbook;

            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }

            ISheet sheet = hssfworkbook.GetSheetAt(0);
            // ISheet sheet = hssfworkbook.GetSheet(sheetName);//Sheet1"
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            HSSFRow headerRow = (HSSFRow)sheet.GetRow(takeRow);//取第二行

            //一行最后一个方格的编号 即总的列数 
            for (int j = 0; j < sheet.GetRow(0).LastCellNum; j++)
            {
                //SET EVERY COLUMN NAME
                HSSFCell cell = (HSSFCell)headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            while (rows.MoveNext())
            {
                IRow row = (HSSFRow)rows.Current;
                DataRow dr = dt.NewRow();

                if (row.RowNum < takeRow) continue;//前两行不要

                for (int i = 0; i < row.LastCellNum; i++)
                {
                    if (i >= dt.Columns.Count)
                    {
                        break;
                    }
                    ICell cell = row.GetCell(i);

                    if ((i == 0) && cell == null)//每行第一个cell为空,break
                    {
                        break;
                    }

                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }



            #endregion
            //}
            //else
            //{
            //    #region .xlsx文件处理:XSSFWorkbook

            //    XSSFWorkbook hssfworkbook;
            //    try
            //    {
            //        using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //        {
            //            hssfworkbook = new XSSFWorkbook(file);
            //        }

            //        ISheet sheet = hssfworkbook.GetSheetAt(0);
            //        // ISheet sheet = hssfworkbook.GetSheet(sheetName);
            //        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            //        XSSFRow headerRow = (XSSFRow)sheet.GetRow(takeRow);//取第二行

            //        //一行最后一个方格的编号 即总的列数 
            //        for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
            //        {
            //            //SET EVERY COLUMN NAME
            //            XSSFCell cell = (XSSFCell)headerRow.GetCell(j);
            //            dt.Columns.Add(cell.ToString());
            //        }

            //        while (rows.MoveNext())
            //        {
            //            IRow row = (XSSFRow)rows.Current;
            //            DataRow dr = dt.NewRow();

            //            if (row.RowNum < takeRow) continue;//前两行不要

            //            for (int i = 0; i < row.LastCellNum; i++)
            //            {
            //                if (i >= dt.Columns.Count)
            //                {
            //                    break;
            //                }

            //                ICell cell = row.GetCell(i);

            //                if ((i == 0) && (cell == null))//每行第一个cell为空,break
            //                {
            //                    break;
            //                }

            //                if (cell == null)
            //                {
            //                    dr[i] = null;
            //                }
            //                else
            //                {
            //                    dr[i] = cell.ToString();
            //                }
            //            }
            //            dt.Rows.Add(dr);
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show("导入数据发生错误，请联系管理员！错误信息：" + e.Message);
            //    }
            //    #endregion
            //}
            return dt;
        }
        #endregion
    }
}
