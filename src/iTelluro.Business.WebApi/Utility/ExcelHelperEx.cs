using Infoearth.Application.Entity;
using Infoearth.Util.Offices;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Web;

namespace iTelluro.Busness.WebApi
{
    public class ExcelHelperEx : ExcelHelper
    {
        /// <summary>
        /// Excel导出下载（只需DataTable）
        /// </summary>
        /// <param name="dtSource">DataTable数据源</param>
        /// <param name="excelConfig">导出设置包含文件名、标题、列设置</param>
        public static void ExcelDownloadOnlyDT(DataTable dtSource, string strHeaderText, string fileName, List<MergedRegionEntity> listMerged = null)
        {
            HttpContext curContext = HttpContext.Current;
            // 设置编码和附件格式
            curContext.Response.ContentType = "application/ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
            //调用导出具体方法Export()
            curContext.Response.BinaryWrite(ExportDT(dtSource, strHeaderText, listMerged).GetBuffer());
            curContext.Response.End();
        }
        public static string ExcelCreate(DataTable dtSource, string strHeaderText, string fileName, List<MergedRegionEntity> listMerged = null)
        {
            try
            {
                byte[] myByte = ExportDT(dtSource, strHeaderText, listMerged).GetBuffer();

                string strPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ExcelFileDown\\");
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                string filePath = strPath + System.Guid.NewGuid() + Path.GetExtension(fileName);
                using (FileStream fsWrite = new FileStream(filePath, FileMode.Create))
                {
                    fsWrite.Write(myByte, 0, myByte.Length);
                }
                return filePath;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        private static MemoryStream ExportDT(DataTable dtSource, string strHeaderText, List<MergedRegionEntity> listMerged = null, ExcelConfig excelConfig = null)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "NPOI";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "文件作者信息"; //填加xls文件作者信息
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
                si.Comments = "作者信息"; //填加xls文件作者信息
                si.Title = "标题信息"; //填加xls文件标题信息
                si.Subject = "主题信息";//填加文件主题信息
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd H:mm:ss");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    if (dtSource.Rows[i][j] == null)
                    {
                        continue;
                    }
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = (HSSFSheet)workbook.CreateSheet();
                    }

                    #region 表头及样式
                    {
                        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                        HSSFFont font = (HSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new NPOI.SS.Util.Region(0, 0, 0, dtSource.Columns.Count - 1));
                        //headerRow.Dispose();
                    }
                    #endregion


                    #region 列头及样式
                    {
                        HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                        headStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                        HSSFFont font = (HSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        if (listMerged != null)
                        {
                            headStyle.WrapText = true;//自动换行
                            int startRow = 1;
                            listMerged = listMerged.OrderBy(p => p.rowFrom).ToList();
                            HSSFRow headerRow2 = (HSSFRow)sheet.CreateRow(startRow);
                            foreach (var item in listMerged)
                            {
                                if (item.rowFrom != startRow)
                                {
                                    startRow = item.rowFrom;
                                    headerRow2 = (HSSFRow)sheet.CreateRow(startRow);
                                }
                                string columnName = !string.IsNullOrWhiteSpace(item.columnNameReplace) ? item.columnNameReplace : item.columnName;
                                headerRow2.CreateCell(item.colFrom).SetCellValue(columnName);
                                headerRow2.GetCell(item.colFrom).CellStyle = headStyle;
                                sheet.AddMergedRegion(new NPOI.SS.Util.Region(item.rowFrom, item.colFrom, item.rowTo, item.colTo));
                            }
                            if (!string.IsNullOrWhiteSpace(listMerged.FirstOrDefault().GroupHeaderCount.ToString()))
                            {
                                rowIndex = listMerged.FirstOrDefault().GroupHeaderCount + 1;
                            }
                            else
                            {
                                rowIndex = 3;
                            }

                        }
                        else
                        {
                            rowIndex = 2;
                        }
                        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(rowIndex - 1);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            if (listMerged != null)
                            {
                                //MergedRegionEntity entity = listMerged.Where(p => column.ColumnName.Contains(p.columnName)).FirstOrDefault();
                                MergedRegionEntity entity = listMerged.Where(p => p.columnName == column.ColumnName).FirstOrDefault();
                                if (entity != null)
                                {
                                    headerRow.CreateCell(column.Ordinal).SetCellValue(entity.columnNameReplace);
                                }
                                else
                                {
                                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                }
                            }
                            else
                            {
                                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            }
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            if ((arrColWidth[column.Ordinal] + 1) * 256 >= 10000)
                            {
                                sheet.SetColumnWidth(column.Ordinal, 10000);
                            }
                            else
                            {
                                //设置列宽
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                            }
                        }
                        //headerRow.Dispose();
                    }
                    #endregion

                    //rowIndex = 2;
                }
                #endregion


                #region 填充内容
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            if (string.IsNullOrWhiteSpace(drValue))
                            {
                                newCell.SetCellValue("");
                            }
                            else
                            {
                                DateTime dateV;
                                DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV);

                                newCell.CellStyle = dateStyle;//格式化显示
                            }
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            if (!string.IsNullOrEmpty(drValue))
                            {
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                            }
                            else
                                newCell.SetCellValue(drValue);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("drValue");
                            break;
                        default:
                            newCell.SetCellValue(drValue);
                            break;
                    }

                }
                #endregion
                rowIndex++;
            }
            MemoryStream ms = new MemoryStream();

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            return ms;
        }

        /// <summary>
        /// Excel导出下载（只需DataTable）
        /// </summary>
        /// <param name="dtSource">DataTable数据源</param>
        /// <param name="excelConfig">导出设置包含文件名、标题、列设置</param>
        public static void ExcelDownloadOnlyDT(List<DataTable> dtSource, string fileName, Dictionary<string, List<MergedRegionEntity>> listMerged = null)
        {
            HttpContext curContext = HttpContext.Current;
            // 设置编码和附件格式
            curContext.Response.ContentType = "application/ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
            //调用导出具体方法Export()
            curContext.Response.BinaryWrite(ExportDT(dtSource, listMerged).GetBuffer());
            curContext.Response.End();
        }

        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        private static MemoryStream ExportDT(List<DataTable> dtSourceList, Dictionary<string, List<MergedRegionEntity>> listMerged = null)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "NPOI";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "文件作者信息"; //填加xls文件作者信息
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
                si.Comments = "作者信息"; //填加xls文件作者信息
                si.Title = "标题信息"; //填加xls文件标题信息
                si.Subject = "主题信息";//填加文件主题信息
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion
            HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            foreach (DataTable dtSource in dtSourceList)
            {
                int hbRow = 0;
                foreach (DataRow row in dtSource.Rows)
                {
                    if (row[0].ToString().Contains("小计"))
                    {
                        hbRow = 1;
                        break;
                    }
                }

                HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(dtSource.TableName);

                //取得列宽
                int[] arrColWidth = new int[dtSource.Columns.Count + hbRow];
                foreach (DataColumn item in dtSource.Columns)
                {
                    arrColWidth[item.Ordinal + hbRow] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                }
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    for (int j = 0; j < dtSource.Columns.Count; j++)
                    {
                        if (dtSource.Rows[i][j] == null)
                        {
                            continue;
                        }
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }

                int rowIndex = 0; int startNum = 1; int hbNum = 1;
                foreach (DataRow row in dtSource.Rows)
                {
                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        if (rowIndex != 0)
                        {
                            sheet = (HSSFSheet)workbook.CreateSheet();
                        }

                        #region 表头及样式
                        {
                            HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
                            headerRow.HeightInPoints = 25;
                            headerRow.CreateCell(0).SetCellValue(dtSource.TableName);

                            HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                            HSSFFont font = (HSSFFont)workbook.CreateFont();
                            font.FontHeightInPoints = 20;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            headerRow.GetCell(0).CellStyle = headStyle;
                            sheet.AddMergedRegion(new NPOI.SS.Util.Region(0, 0, 0, dtSource.Columns.Count - 1 + hbRow));
                            //headerRow.Dispose();
                        }
                        #endregion


                        #region 列头及样式
                        {

                            HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                            headStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                            HSSFFont font = (HSSFFont)workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            if (listMerged != null && listMerged.ContainsKey(dtSource.TableName))
                            {
                                HSSFRow headerRow2 = (HSSFRow)sheet.CreateRow(1);
                                foreach (var item in listMerged[dtSource.TableName])
                                {
                                    if (!item.isNoMerged)
                                    {
                                        headerRow2.CreateCell(item.colFrom + hbRow).SetCellValue(item.columnName);
                                        headerRow2.GetCell(item.colFrom).CellStyle = headStyle;
                                        sheet.AddMergedRegion(new NPOI.SS.Util.Region(item.rowFrom, item.colFrom, item.rowTo, item.colTo));
                                    }
                                }
                                rowIndex = 3;
                            }
                            else
                            {
                                rowIndex = 2;
                            }
                            HSSFRow headerRow = (HSSFRow)sheet.CreateRow(rowIndex - 1);
                            foreach (DataColumn column in dtSource.Columns)
                            {
                                if (listMerged != null && listMerged.ContainsKey(dtSource.TableName))
                                {
                                    MergedRegionEntity entity = listMerged[dtSource.TableName].Where(p => column.ColumnName.StartsWith(p.columnName) && p.columnName.Length != column.ColumnName.Length).FirstOrDefault();
                                    if (entity != null)
                                    {
                                        headerRow.CreateCell(column.Ordinal + hbRow).SetCellValue(column.ColumnName.Substring(entity.columnName.Length, column.ColumnName.Length - entity.columnName.Length));
                                    }
                                    else
                                    {
                                        headerRow.CreateCell(column.Ordinal + hbRow).SetCellValue(column.ColumnName);
                                    }
                                }
                                else
                                {
                                    headerRow.CreateCell(column.Ordinal + hbRow).SetCellValue(column.ColumnName);
                                }
                                headerRow.GetCell(column.Ordinal + hbRow).CellStyle = headStyle;

                                if ((arrColWidth[column.Ordinal + hbRow] + 1) * 256 >= 10000)
                                {
                                    sheet.SetColumnWidth(column.Ordinal + hbRow, 10000);
                                }
                                else
                                {
                                    //设置列宽
                                    sheet.SetColumnWidth(column.Ordinal + hbRow, (arrColWidth[column.Ordinal + hbRow] + 1) * 256);
                                }
                            }
                            //headerRow.Dispose();

                        }
                        #endregion

                        //rowIndex = 2;
                    }
                    #endregion


                    #region 填充内容
                    HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                    foreach (DataColumn column in dtSource.Columns)
                    {
                        HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal + hbRow);

                        string drValue = row[column].ToString();
                        if (hbRow == 1 && column.Ordinal == 0 && drValue.Contains("小计"))
                        {
                            drValue = "小计";
                        }
                        switch (column.DataType.ToString())
                        {
                            case "System.String"://字符串类型
                                newCell.SetCellValue(drValue);
                                break;
                            case "System.DateTime"://日期类型
                                DateTime dateV;
                                if (!string.IsNullOrWhiteSpace(drValue))
                                {
                                    DateTime.TryParse(drValue, out dateV);
                                    newCell.SetCellValue(dateV);
                                    newCell.CellStyle = dateStyle;//格式化显示
                                }
                                break;
                            case "System.Boolean"://布尔型
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                break;
                            case "System.Decimal"://浮点型
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }

                    }
                    #endregion
                    if (hbRow == 1)
                    {
                        HSSFCell newCell = (HSSFCell)dataRow.CreateCell(0);
                        if (row[0].ToString().Contains("小计"))
                        {
                            HSSFRow rowCell = (HSSFRow)sheet.GetRow(startNum + 1);
                            HSSFCell hbCell = (HSSFCell)rowCell.GetCell(0);
                            hbCell.SetCellValue(row[0].ToString().Replace("小计", ""));
                            sheet.AddMergedRegion(new NPOI.SS.Util.Region(startNum + 1, 0, startNum + hbNum, 0));
                            startNum += hbNum;
                            hbNum = 0;
                        }
                        hbNum++;
                    }
                    rowIndex++;
                }
            }
            MemoryStream ms = new MemoryStream();

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            return ms;
        }

        #region 数据加信息描述
        public static void TableToExcel_Common(string tabName, DataTable dt, string fileName, string extName, string[] propertyName, Dictionary<string, IList<HeartClass>> dicHeadTitle, List<ExcelType> entity, bool isWrite = false)
        {
            try
            {
                if (extName.Equals(".xls"))  //.xls
                {
                    if (_workbook == null) _workbook = new HSSFWorkbook();
                    TableToExcelHSSF_Common(_workbook, dt, tabName, dicHeadTitle, entity);
                }
                else  //.xlsx
                {
                    if (_workbook == null) _workbook = new XSSFWorkbook();
                    TableToExcelXSSF_Common(_workbook, dt, tabName, dicHeadTitle, entity);
                }
                if (isWrite)
                {
                    MemoryStream stream = new MemoryStream();
                    _workbook.Write(stream);
                    _workbook = null;
                    WriteExcel(fileName, extName, stream.ToArray());
                }
            }
            catch
            {
                _workbook = null;
            }
        }
        private static void TableToExcelHSSF_Common(IWorkbook hssfworkBook, DataTable dt, string tabName, Dictionary<string, IList<HeartClass>> dicHeadTitle, List<ExcelType> entity)
        {
            if (string.IsNullOrWhiteSpace(tabName))
            {
                tabName = "sheet1";
            }
            ISheet sheet = hssfworkBook.CreateSheet(tabName);

            //设置表头样式
            ICellStyle headStyle = hssfworkBook.CreateCellStyle();
            headStyle.Alignment = HorizontalAlignment.Center;
            headStyle.VerticalAlignment = VerticalAlignment.Center;
            headStyle.WrapText = true;
            //向Sheet填充数据
            SetSheetDataByDataTable_Common(ref sheet, headStyle, dt, dicHeadTitle, entity);

        }

        private static void TableToExcelXSSF_Common(IWorkbook xssfworkbook, DataTable dt, string tabName, Dictionary<string, IList<HeartClass>> dicHeadTitle, List<ExcelType> entity)
        {
            if (string.IsNullOrWhiteSpace(tabName))
            {
                tabName = "sheet1";
            }
            ISheet sheet = xssfworkbook.CreateSheet(tabName);

            //设置表头样式
            XSSFCellStyle xssfStyle = ((XSSFCellStyle)xssfworkbook.CreateCellStyle());
            xssfStyle.Alignment = HorizontalAlignment.Center;
            xssfStyle.VerticalAlignment = VerticalAlignment.Center;
            xssfStyle.WrapText = true;
            //向sheet填充数据
            try
            {
                SetSheetDataByDataTable_Common(ref sheet, xssfStyle, dt, dicHeadTitle, entity);
            }
            catch (Exception ex)
            {

            }

            //转换为字节数组
            //MemoryStream stream = new MemoryStream();
            //xssfworkbook.Write(stream);
            //return stream.ToArray();

        }

        private static IWorkbook _workbook = null;
        /// <summary>
        /// 导出Excel 由controller层多次调用,导出包含多个Tab页的Excel文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tabName"></param>
        /// <param name="list"></param>
        /// <param name="fileName"></param>
        /// <param name="extName"></param>
        /// <param name="propertyName"></param>
        /// <param name="isWrite">是否输出Excel文件 最后一次调用时参数设为true</param>
        public static void ListToExcelTabs<T>(string tabName, IList<T> list, string fileName, string extName, string[] propertyName, bool isWrite = false)
        {
            try
            {
                if (extName.Equals(".xls"))  //.xls
                {
                    if (_workbook == null) _workbook = new HSSFWorkbook();
                    ListToExcelHSSFTabs<T>(_workbook, tabName, propertyName, list);
                }
                else  //.xlsx
                {
                    if (_workbook == null) _workbook = new XSSFWorkbook();
                    ListToExcelXSSFTabs<T>(_workbook, tabName, propertyName, list);
                }
                if (isWrite)
                {
                    MemoryStream stream = new MemoryStream();
                    _workbook.Write(stream);
                    _workbook = null;
                    WriteExcel(fileName, extName, stream.ToArray());
                }
            }
            catch
            {
                _workbook = null;
            }
        }

        /// <summary>
        /// 向浏览器输出Excel文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="extName"></param>
        /// <param name="bytes"></param>
        private static void WriteExcel(string fileName, string extName, byte[] bytes)
        {
            HttpResponse resp = HttpContext.Current.Response;
            resp.Clear();
            resp.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            resp.Charset = "gb2312"; //uft8 IE下中文文件名乱码
            try
            {
                string fileFullName = HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8) + extName;
                resp.AddHeader("Content-Disposition", "attachment; filename=" + fileFullName);
                if (extName.Equals(".xls"))  //.xls
                {
                    resp.ContentType = "application/vnd.ms-excel";
                }
                else  //.xlsx
                {
                    resp.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                }
                resp.BinaryWrite(bytes);
            }
            catch
            {
                //resp.Write(bytes);
            }
            finally
            {
                resp.Flush();
                resp.Close();
            }
        }
        private static void ListToExcelHSSFTabs<T7>(IWorkbook hssfworkBook, string tabName, string[] propertyNames, IList<T7> list)
        {
            ISheet sheet = hssfworkBook.CreateSheet(tabName);

            PropertyInfo[] propertys = new PropertyInfo[] { };
            List<string> propertyNameList = new List<string>();
            GetPorpertys<T7>(ref propertys, ref propertyNameList, propertyNames);

            //设置表头样式
            ICellStyle headStyle = hssfworkBook.CreateCellStyle();
            headStyle.FillBackgroundColor = HSSFColor.Grey25Percent.Index;
            headStyle.FillForegroundColor = HSSFColor.Grey25Percent.Index;
            headStyle.FillPattern = FillPattern.SolidForeground;
            headStyle.VerticalAlignment = VerticalAlignment.Center;
            IFont font = hssfworkBook.CreateFont();
            font.FontHeight = 17 * 17;
            headStyle.SetFont(font);
            //向Sheet填充数据
            SetSheetDataByTist(ref sheet, headStyle, list, propertys, propertyNameList);
        }

        private static void ListToExcelXSSFTabs<T6>(IWorkbook xssfworkbook, string tabName, string[] propertyNames, IList<T6> list)
        {
            ISheet sheet = xssfworkbook.CreateSheet(tabName);
            PropertyInfo[] propertys = new PropertyInfo[] { };
            List<string> propertyNameList = new List<string>();
            GetPorpertys<T6>(ref propertys, ref propertyNameList, propertyNames);

            //设置表头样式
            XSSFCellStyle xssfStyle = ((XSSFCellStyle)xssfworkbook.CreateCellStyle());
            xssfStyle.SetFillBackgroundColor(new XSSFColor(System.Drawing.Color.LightGray));
            xssfStyle.SetFillForegroundColor(new XSSFColor(System.Drawing.Color.LightGray));
            xssfStyle.FillPattern = FillPattern.SolidForeground;
            xssfStyle.VerticalAlignment = VerticalAlignment.Center;
            IFont font = xssfworkbook.CreateFont();
            font.FontHeight = 17 * 17;
            xssfStyle.SetFont(font);

            //向Sheet填充数据
            SetSheetDataByTist(ref sheet, xssfStyle, list, propertys, propertyNameList);
        }

        private static void SetSheetDataByTist<T2>(ref ISheet sheet, ICellStyle headStyle, IList<T2> list, PropertyInfo[] propertys, List<string> propertyNameList)
        {
            //生成excel的表头标题
            IRow headRow = sheet.CreateRow(0);
            headRow.HeightInPoints = 20; //行高
            IDictionary<string, string> dicProps = GetPropertyDic<T2>(propertyNameList);
            int colIndex_head = 0;
            foreach (var kv in dicProps)
            {
                ICell cell = headRow.CreateCell(colIndex_head);
                cell.SetCellValue(kv.Value);
                //if (headStyle != null)
                //    cell.CellStyle = headStyle;
                colIndex_head++;
            }
            //生成excel的行集数据
            for (int i = 0; i < list.Count; i++)
            {
                IRow dataRow = sheet.CreateRow(i + 1);
                int colIndex_data = 0;
                for (int j = 0; j < propertys.Count(); j++)
                {
                    if (propertyNameList.Contains(propertys[j].Name))
                    {
                        object obj = propertys[j].GetValue(list[i], null);
                        ICell cell = dataRow.CreateCell(colIndex_data);
                        if (obj == null)
                            cell.SetCellValue("");
                        else
                            cell.SetCellValue(obj.ToString());
                        //sheet.AutoSizeColumn(colIndex_data);
                        colIndex_data++;
                    }
                }
            }
            //自适应宽度
            for (int i = 0; i < colIndex_head; i++)
            {
                sheet.AutoSizeColumn(i);
            }
        }

        private static void GetPorpertys<T3>(ref PropertyInfo[] propertys, ref List<string> propertyNameList, params string[] propertyName)
        {
            //通过反射得到对象的属性集合
            propertys = typeof(T3).GetProperties();
            propertyNameList = new List<string>();
            if (propertyName != null && propertyName.Length > 0)
                propertyNameList.AddRange(propertyName);
            else
            {
                foreach (var v in propertys)
                {
                    object[] attrs = v.GetCustomAttributes(typeof(DescAttribute), false);
                    if (attrs == null || attrs.Length <= 0)
                    {
                        continue;
                    }
                    DescAttribute attr = (DescAttribute)attrs[0];
                    if (attr == null || !attr.IsExport)
                        continue;
                    propertyNameList.Add(v.Name);
                }
            }
        }
        public static IDictionary<string, string> GetPropertyDic<T3>(List<string> propertyNameList)
        {
            IDictionary<string, string> dicProps = new Dictionary<string, string>();
            PropertyInfo[] propertys = typeof(T3).GetProperties();
            for (int j = 0; j < propertys.Count(); j++)
            {
                if (propertyNameList.Contains(propertys[j].Name))
                {
                    object[] attrs = propertys[j].GetCustomAttributes(typeof(DescAttribute), false);
                    if (attrs == null || attrs.Length <= 0)
                    {
                        continue;
                    }
                    DescAttribute attr = (DescAttribute)attrs[0];
                    if (attr != null && !attr.IsExport)
                        continue;
                    if (attr == null || string.IsNullOrEmpty(attr.Name))
                        dicProps.Add(propertys[j].Name, propertys[j].Name);
                    else
                        dicProps.Add(propertys[j].Name, attr.Name);
                }
            }
            return dicProps;
        }
        private static void SetSheetDataByDataTable_Common(ref ISheet sheet, ICellStyle headStyle, DataTable dt, Dictionary<string, IList<HeartClass>> dicHeadTitle, List<ExcelType> entity)
        {
            //生成excel的表头标题
            int maxColumn = 0;
            int rowIndex_head = 0;

            if (dicHeadTitle != null)
            {

                foreach (var kv in dicHeadTitle)
                {
                    IRow headRow = sheet.CreateRow(rowIndex_head);
                    headRow.HeightInPoints = 20; //行高
                    IList<HeartClass> headList = kv.Value;
                    for (int i = 0; i < headList.Count; i++)
                    {
                        ICell cell = headRow.CreateCell(headList[i].indexColumn);
                        cell.SetCellValue(headList[i].title);
                        //合并单元格
                        if (dicHeadTitle.Keys.Max() != kv.Key)
                        {
                            int firstRow = rowIndex_head;
                            int lastRow = rowIndex_head;
                            if (headList[i].rowNum != 0)
                            {
                                lastRow = rowIndex_head + headList[i].rowNum - 1;
                            }
                            int firstCol = headList[i].indexColumn;
                            int lastCol = headList[i].indexColumn;
                            if (headList[i].columnNum != 0)
                            {
                                lastCol = headList[i].indexColumn + headList[i].columnNum - 1;
                            }
                            sheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, firstCol, lastCol));
                        }
                        if (headStyle != null)
                            cell.CellStyle = headStyle;
                    }
                    rowIndex_head++;
                }
            }
            else
            {
                if (entity != null)
                {
                    int maxRow = entity.Max(p => p.RowIndex);
                    for (int i = 0; i < maxRow; i++)
                    {
                        IRow headRowContent = sheet.CreateRow(i);
                        List<ExcelType> list = entity.Where(p => p.RowIndex == i + 1).ToList();
                        foreach (var item in list)
                        {
                            ICell cell = headRowContent.CreateCell(item.CellIndex - 1);
                            cell.SetCellValue(item.FiledValue);
                            //if (item.CellStyle == "right")
                            //{
                            //    headStyle.Alignment = HorizontalAlignment.Right;
                            //}
                            //else
                            //{
                            //    headStyle.Alignment = HorizontalAlignment.Left;
                            //}
                            //cell.CellStyle = headStyle;
                            sheet.AddMergedRegion(new CellRangeAddress(i, i, item.CellIndex - 1, item.CellIndex + item.MergeCount - 1));
                        }
                        rowIndex_head++;
                    }

                }
                //标题
                IRow headRow = sheet.CreateRow(rowIndex_head);
                headRow.HeightInPoints = 20;//行高 
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = headRow.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ToString());
                }
            }
            rowIndex_head++;
            //生成Excel行集数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow dataRow = sheet.CreateRow(i + rowIndex_head);
                int colIndex_data = 0;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object obj = dt.Rows[i][j];
                    ICell cell = dataRow.CreateCell(colIndex_data);
                    if (obj == null)
                    { cell.SetCellValue(""); }
                    else
                    {
                        cell.SetCellValue(obj.ToString());
                        colIndex_data++;
                    }
                };
            };
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sheet.AutoSizeColumn(i);
            }
            for (int columnNum = 0; columnNum < dt.Columns.Count; columnNum++)
            {
                int columnWidth = sheet.GetColumnWidth(columnNum) / 256;
                for (int rowNum = 1; rowNum < sheet.LastRowNum; rowNum++)
                {
                    IRow currentRow;
                    //当前行未被使用过
                    if (sheet.GetRow(rowNum) == null)
                    {
                        currentRow = sheet.CreateRow(rowNum);
                    }
                    else
                    {
                        currentRow = sheet.GetRow(rowNum);
                    }
                    if (currentRow.GetCell(columnNum) != null)
                    {
                        ICell currentCell = currentRow.GetCell(columnNum);
                        int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                        if (columnWidth < length)
                        {
                            columnWidth = length;
                        }
                        if (columnWidth > 80)
                        {
                            columnWidth = 80;
                        }
                        if (columnWidth < 10)
                        {
                            columnWidth = 10;
                        }
                    }
                }
                sheet.SetColumnWidth(columnNum, columnWidth * 256);
            }
        }
        #endregion

    }
}