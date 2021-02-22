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
    /// 日 期：2018-03-14 14:58
    /// 描 述：灾害点基本表
    /// </summary>
    public class TBL_HAZARDBASICINFOController : MvcControllerBase
    {
        private TBL_HAZARDBASICINFOBLL TBL_HazardBaseicainfoBLL = new TBL_HAZARDBASICINFOBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOIndex()
        {
            return View();
        }


        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_LSXQIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOForm()
        {
            return View();
        }
        /// <summary>
        /// 查询浏览页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult ZHDCXLL()
        {
            return View();
        }
        /// <summary>
        /// 查询浏览页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult ZHDCXLL_HISTORY()
        {
            return View();
        }
        /// <summary>
        /// 查询浏览页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult DZPC_SELECT()
        {
            return View();
        }
        /// <summary>
        /// 查询浏览页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult ZYYHD_SELECT()
        {
            return View();
        }
        /// <summary>
        /// 生成灾害点新
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult CreateCodeWaterIndexNew()
        {
            return View();
        }
        /// <summary>
        /// 查看浏览灾害点
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult CreateCodeWaterIndex()
        {
            return View();
        }
        /// <summary>
        /// 生成编码
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_LANDSLIP_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// 生成编码
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_AVALANCHE_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// 生成编码
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_DEBRISFLOW_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// 生成编码
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_LANDSETTLEMENT_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// 生成编码
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_COLLAPSE_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// 生成编码
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult DETAIL()
        {
            return View();
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_LANDCRACK_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// 核销点查询界面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOQueryHXBrowse()
        {
            return View();
        }
        [Login]
        public ActionResult TBL_HAZARDBASICINFOHXQuery()
        {
            return View();
        }
        /// <summary>
        /// 最新数据查询
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOQueryBrowse()
        {
            return View();
        }
        /// <summary>
        /// 历史数据查询
        /// </summary>
        /// <returns></returns>
        public ActionResult TBL_HAZARDBASICINFOQueryBhistory()
        {
            return View();
        }
        /// <summary>
        /// 生成编码
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_SLOPE_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// 生成编码
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TJSH()
        {
            return View();
        }
        /// <summary>
        /// 统计灾害点
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOCountAnalyse()
        {
            return View();
        }
        /// <summary>
        /// 统计灾害点
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOCountAnalysePC()
        {
            return View();
        }
        /// <summary>
        /// 统计灾害点
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_ZYYHDTJ()
        {
            return View();
        }
        /// <summary>
        ///对比详情
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult HisComparer()
        {
            return View();
        }
        /// <summary>
        /// 选择灾害点信息
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult HAZARDBASCOMMONIndex()
        {
            return View();
        }
        /// <summary>
        /// 选择灾害点信息
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult QCQFZHD()
        {
            return View();
        }

        /// <summary>
        /// 核销
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult DeleteInfo()
        {
            return View();
        }
        /// <summary>
        /// 对比
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult CompareRead()
        {
            return View();
        }
        /// <summary>
        /// 组合统计内容
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult StatisticeContext()
        {
            return View();
        }
        /// <summary>
        /// 组合统计内容
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult StatisticeContextNew()
        {
            return View();
        }

        /// <summary>
        /// 组合统计条件
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult StatisticeCondition()
        {
            return View();
        }

        /// <summary>
        /// 组合统计条件
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult HarzardCompare()
        {
            return View();
        }

        /// <summary>
        /// 排查列表页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOIndexPC()
        {
            return View();
        }
        /// <summary>
        /// 排查表单页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOFormPC()
        {
            return View();
        }
        /// <summary>
        /// 排查表单页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult HarzardTrendAnalyse()
        {
            return View();
        }
        /// <summary>
        /// 常用统计图表页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult Statistics()
        {
            return View();
        }
        /// <summary>
        /// 详查常用统计图表页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult StatisticsXC()
        {
            return View();
        }
        /// <summary>
        /// 查询统计分析（20190227重做）
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult selectTJ()
        {
            return View();
        }
        /// <summary>
        /// 历史数据对比表
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_LSSJIndex()
        {
            return View();
        }
        /// <summary>
        /// 调查的页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult DETAIL_DIAOCHA()
        {
            return View();
        }
        /// <summary>
        /// 调查的页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_ZLGCINDEX()
        {
            return View();
        }
        /// <summary>
        /// 组合统计条件
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult ComStatisticeContext()
        {
            return View();
        }
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_SPATIAL()
        {
            return View();
        }

        /// <summary>
        /// 导入Excel
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult ImportExcelForm()
        {
            return View();
        }

        /// <summary>
        /// 调查表
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOIndex_10()
        {
            return View();
        }

        /// <summary>
        /// 详查库
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOIndex_5W()
        {
            return View();
        }
        #endregion

        #region 导出功能
        /// <summary>
        /// 对应地质灾害基本信息查询浏览数据导出
        /// </summary>
        /// <param name="queryJson"></param>
        [HttpGet]
        public void ExcelDownloadExt(string queryJson)
        {
            DataTable data = TBL_HazardBaseicainfoBLL.GetDataTableList(queryJson);
            for (var a = 0; a < data.Rows.Count; a++)
            {
                data.Rows[a]["监测建议"] = data.Rows[a]["监测建议"].ToString().Replace("A", "定期目视巡查");
                data.Rows[a]["监测建议"] = data.Rows[a]["监测建议"].ToString().Replace("B", "安装简易监测设施");
                data.Rows[a]["监测建议"] = data.Rows[a]["监测建议"].ToString().Replace("C", "地面位移监测");
                data.Rows[a]["监测建议"] = data.Rows[a]["监测建议"].ToString().Replace("D", "深部位移监测");
                data.Rows[a]["防治建议"] = data.Rows[a]["防治建议"].ToString().Replace("E", "应急排危险");
                data.Rows[a]["防治建议"] = data.Rows[a]["防治建议"].ToString().Replace("F", "立警示牌");
                data.Rows[a]["防治建议"] = data.Rows[a]["防治建议"].ToString().Replace("A", "群测群防");
                data.Rows[a]["防治建议"] = data.Rows[a]["防治建议"].ToString().Replace("B", "专业监测");
                data.Rows[a]["防治建议"] = data.Rows[a]["防治建议"].ToString().Replace("C", "搬迁避让");
                data.Rows[a]["防治建议"] = data.Rows[a]["防治建议"].ToString().Replace("D", "治理工程");
            }
                ExcelHelper.ExcelDownloadOnlyDT(data, "灾害点数据导出", "灾害点浏览查询.xls");
        }

        /// <summary>
        /// 对应地质灾害基本信息查询浏览数据导出
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        [HttpGet]
        public void ExcelDownload(string queryJson, string condition = null)
        {
            List<TBL_HAZARDBASICINFOEntity> data = TBL_HazardBaseicainfoBLL.GetZYPageList(queryJson, condition).ToList();
            DataTable dt = DataHelper.ListToDataTable<TBL_HAZARDBASICINFOEntity>(data);
            ExcelHelper.ExcelDownloadOnlyDT(dt, "灾害点数据导出", "灾害点浏览查询.xls");
        }

        /// <summary>
        /// 详查对应地质灾害基本信息统计中数据导出
        /// </summary>
        /// <param name="queryJson"></param>
        public void GetHazardbasiciStaticsExcelDown(string queryJson, string colum)
        {
            DataTable data = TBL_HazardBaseicainfoBLL.GetDataCountTableList(queryJson, colum);
            ExcelHelper.ExcelDownloadOnlyDT(data, "灾害点统计分析详查", "灾害点统计分析详查.xls");
        }
        /// <summary>
        /// 排查对应地质灾害基本信息统计中数据导出
        /// </summary>
        /// <param name="queryJson"></param>
        public void GetHazardbasiciStaticsExcelDownPC(string queryJson, string colum)
        {
            DataTable data = TBL_HazardBaseicainfoBLL.GetDataCountTableListPC(queryJson, colum);
            ExcelHelper.ExcelDownloadOnlyDT(data, "灾害点统计分析排查", "灾害点统计分析排查.xls");
        }
        /// <summary>
        /// 重要隐患点统计
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="colum"></param>
        public void GetHazardbasiciStaticsExcelDownPC2(string queryJson, string colum)
        {
            DataTable data = TBL_HazardBaseicainfoBLL.GetDataCountTableListPC(queryJson, colum);
            foreach (DataColumn dc in data.Columns)
            {
                if (dc.ColumnName == "隐患点")
                {
                    dc.ColumnName = "灾害点";
                }
            }
            ExcelHelper.ExcelDownloadOnlyDT(data, "重要隐患点统计", "重要隐患点统计.xls");
        }

        public void ExcelDownloadQueryStatistics(string queryJson)
        {
            try
            {
                //HarzardTrendAnalyseBLL harzardTrendAnalyseBLL = new HarzardTrendAnalyseBLL();
                //List<MergedRegionEntity> columnList = new List<MergedRegionEntity>();
                //DataTable result = harzardTrendAnalyseBLL.QueryStatistics(queryJson, ref  columnList);
                //string Name = GetName(queryJson);
                //result.TableName = Name;
                //string fileName = Name + "-" + DateTime.Now.ToString("yyyy.MM.dd") + ".xls";
                //ExcelHelperEx.ExcelDownloadOnlyDT(result, Name, fileName, columnList);
            }
            catch
            {

            }
        }
        private string GetName(string queryJson)
        {
            string returnValue = string.Empty;
            var queryParam = queryJson.ToJObject();
            string value = queryParam["Type"].ToString();
            switch (value.ToLower())
            {
                case "zqs"://总趋势
                    returnValue = "总趋势";
                    break;
                case "yhdgmqs"://隐患点规模趋势
                    returnValue = "隐患点规模趋势";
                    break;
                case "zhlxjgmqs"://灾害类型及规模趋势
                    returnValue = "灾害类型及规模趋势";
                    break;
                case "nxhqs"://拟销号趋势
                    returnValue = "拟销号趋势";
                    break;
                case "nxhd"://拟销号点
                    returnValue = "拟销号点";
                    break;
                case "gmdjdb"://灾情、险情、规模等级对比
                    returnValue = "灾情、险情、规模等级对比";
                    break;
                default:
                    returnValue = "总趋势";
                    break;
            }
            return returnValue;
        }
        #endregion

        #region 导出word
        public FileResult ExportWord(string filename, string queryJson)
        {
            string path = string.Empty;
            try
            {
                path = this.Server.MapPath("~/") + "WordFile/" + DateTime.Now.ToString("yyyy.MM.dd HH-mm-ss.fff") + "/";
                string filePath = path + filename + "/";
                if (!System.IO.File.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                var queryParam = queryJson.ToJObject();
                if (!queryParam["GUID"].IsEmpty() && !queryParam["moduleId"].IsEmpty())
                {
                    string GUID = queryParam["GUID"].ToString();
                    string moduleId = queryParam["moduleId"].ToString();
                    if (!queryParam["DISASTERTYPE"].IsEmpty())
                    {
                        WordExport(queryParam["DISASTERTYPE"].ToString(), GUID, moduleId, filename, filePath, "false", filename);
                    }
                    //DataTable dtResult = TBL_HazardBaseicainfoBLL.GetWordDataTable(GUID);//获取地灾关联信息
                    //foreach (DataRow item in dtResult.Rows)
                    //{
                    //    WordExport(item["type"].ToString(), item["guid"].ToString(), "", filename, filePath, "false", item["filename"].ToString());
                    //}
                }
                List<FileInfo> fileList = new List<FileInfo>();
                GetFiles(path, fileList);
                string downFileName = filename + ".zip";//下载文件名称
                string downFilePath = path + filename + ".zip";//下载文件路径
                string downType = "application/zip";//下载类型
                if (fileList.Count == 1)//只有一个文件时
                {
                    downFileName = Path.GetFileName(fileList[0].FullName);
                    downFilePath = fileList[0].FullName;
                    downType = "application/octet-stream";
                }
                else
                {
                    System.IO.Compression.ZipFile.CreateFromDirectory(filePath, downFilePath);
                }
                FileStream fs = new FileStream(downFilePath, FileMode.Open, FileAccess.Read);
                string fileFullName = HttpUtility.UrlEncode(downFileName, System.Text.Encoding.UTF8);
                byte[] buffur = new byte[fs.Length];
                fs.Read(buffur, 0, (int)fs.Length);
                fs.Flush();
                fs.Close();

                return File(buffur, downType, downFileName);


            }
            catch (Exception ex)
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes("导出失败！\nException：" + ex.Message);
                return File(b, "text/plain");
            }
            finally
            {
                //删除服务器文件
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
        }
        public void WordExport(string type, string keyValue, string moduleId, string fileName, string docxSavePath, string IsdownLoad, string NewFileName = null)
        {
            string templatePath = string.Empty;
            //string docxSavePath = @"C:\TempDocxPath\";//保存路径
            if (string.IsNullOrWhiteSpace(docxSavePath))
            {
                docxSavePath = @"C:\TempDocxPath\";//保存路径
            }
            DisasterTypeEnum typeEnum = (DisasterTypeEnum)Enum.Parse(typeof(DisasterTypeEnum), type);
            switch (typeEnum)
            {
                case DisasterTypeEnum.滑坡:
                    templatePath = @"\滑坡调查表.dotx";
                    break;
                case DisasterTypeEnum.滑坡隐患:
                    templatePath = @"\滑坡调查表.dotx";
                    break;
                case DisasterTypeEnum.崩塌:
                    templatePath = @"\崩塌调查表.dotx";
                    break;
                case DisasterTypeEnum.崩塌隐患:
                    templatePath = @"\崩塌调查表.dotx";
                    break;
                case DisasterTypeEnum.泥石流:
                    templatePath = @"\泥石流调查表.dotx";
                    break;
                case DisasterTypeEnum.地面沉降:
                    templatePath = @"\地面沉降调查表.dotx";
                    break;
                case DisasterTypeEnum.地面塌陷:
                    templatePath = @"\地面塌陷调查表.dotx";
                    break;
                case DisasterTypeEnum.地裂缝:
                    templatePath = @"\地裂缝调查表.dotx";
                    break;
                case DisasterTypeEnum.斜坡:
                    templatePath = @"\不稳定斜坡调查表.dotx";
                    break;
            }
            WordHelper ExportWord = null;
            ExportWord = new WordExportData();
            int subStrStart = templatePath.LastIndexOf("\\");
            int subStrEnd = templatePath.LastIndexOf('.');
            string _docName = templatePath.Substring(subStrStart + 1, subStrEnd - subStrStart - 1);
            string tempath = System.Web.HttpContext.Current.Server.MapPath("/Template").ToString();
            string savepath = ExportWord.WordLoadData(docxSavePath, tempath + templatePath, keyValue, moduleId, typeEnum, NewFileName);
            if (ExportWord._downLoadResult == -1 || ExportWord._downLoadResult == 0)
            {
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(IsdownLoad))
                {
                    ExportWord.DeleteOrDownFile(savepath, fileName);
                }
            }
        }
        #endregion
        /// <summary>
        ///  地质灾害点生成统计图
        /// </summary>
        /// <param name="queryJson"></param>
        /// /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetZHDCountResult(string queryJson, int type)
        {
            var jobj = queryJson.ToJObject();

            //第一步获取行政区划
            //LocationHelper.GetDistricts();

            //第二步请求统计数据并整理成可用直接调用的数据形式
            DataTable entity = new DataTable();
            if (type == 1)
            {
                entity = TBL_HazardBaseicainfoBLL.GetAnalyseList(queryJson);
            }
            if (type == 2)
            {
                entity = TBL_HazardBaseicainfoBLL.GetAnalyseListPC(queryJson);
            }

            if (entity == null || entity.Rows.Count == 0) return null;
            for (int i = 0; i < entity.Rows.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(entity.Rows[i]["area"].ToString())
                    || (entity.Columns.Contains("town") && !string.IsNullOrWhiteSpace(entity.Rows[i]["town"].ToString())))
                {
                    entity.Rows[i].Delete();
                    i--;
                }
            }
            if (entity.Columns.Contains("town"))
            {
                entity.Columns.Remove("townname");
                entity.Columns.Remove("town");
            }
            if (entity.Columns.Contains("provincename"))
            {
                entity.Columns.Remove("province");
                entity.Columns["provincename"].ColumnName = "省";
            }
            if (entity.Columns.Contains("cityname"))
            {
                entity.Columns.Remove("city");
                entity.Columns["cityname"].ColumnName = "市";
            }
            if (entity.Columns.Contains("countyname"))
            {
                entity.Columns.Remove("county");
                entity.Columns["countyname"].ColumnName = "县";
            }
            if (entity.Columns.Contains("zhd"))
            {
                if (jobj["zhd"].ToString() == "1")
                {
                    entity.Columns["zhd"].ColumnName = "灾害点总计";
                }
                else
                {
                    entity.Columns.Remove("zhd");
                }
            }

            if (entity.Columns.Contains("yhd"))
            {
                if (jobj["yhd"].ToString() == "1")
                {
                    entity.Columns["yhd"].ColumnName = "隐患点总计";
                }
                else
                {
                    entity.Columns.Remove("yhd");
                }
            }

            string[] strArr = new[] { "yhdzhlx", "zhlx" };
            foreach (var item in strArr)
            {
                string strName = "";
                bool flag = false;//区分灾害点和隐患点
                if (item == "yhdzhlx")
                {
                    strName = "yhd";
                    if (jobj["yhd"].ToString() == "1" && jobj["zhlx"].ToString() == "1")
                        flag = true;
                }
                else if (item == "zhlx")
                {
                    strName = "";
                    if (jobj["zhd"].ToString() == "1" && jobj["zhlx"].ToString() == "1")
                        flag = true;
                }

                if (flag)
                {
                    entity.Columns[strName + "hp"].ColumnName = "滑坡";
                    entity.Columns[strName + "bt"].ColumnName = "崩塌";
                    entity.Columns[strName + "xp"].ColumnName = "斜坡";
                    entity.Columns[strName + "nsl"].ColumnName = "泥石流";
                    entity.Columns[strName + "dmcj"].ColumnName = "地面沉降";
                    entity.Columns[strName + "dlf"].ColumnName = "地裂缝";
                    entity.Columns[strName + "dmtx"].ColumnName = "地面塌陷";
                    var disasterType = jobj["DISASTERTYPE"].ToString();
                    if (disasterType != "")
                    {
                        if ("滑坡" != disasterType)
                        {
                            entity.Columns.Remove("滑坡");
                        }
                        if ("崩塌" != disasterType)
                        {
                            entity.Columns.Remove("崩塌");
                        }
                        if ("斜坡" != disasterType)
                        {
                            entity.Columns.Remove("斜坡");
                        }
                        if ("泥石流" != disasterType)
                        {
                            entity.Columns.Remove("泥石流");
                        }
                        if ("地面沉降" != disasterType)
                        {
                            entity.Columns.Remove("地面沉降");
                        }
                        if ("地裂缝" != disasterType)
                        {
                            entity.Columns.Remove("地裂缝");
                        }
                        if ("地面塌陷" != disasterType)
                        {
                            entity.Columns.Remove("地面塌陷");
                        }
                    }
                }
                else
                {
                    entity.Columns.Remove(strName + "hp");
                    entity.Columns.Remove(strName + "bt");
                    entity.Columns.Remove(strName + "xp");
                    entity.Columns.Remove(strName + "nsl");
                    entity.Columns.Remove(strName + "dmcj");
                    entity.Columns.Remove(strName + "dlf");
                    entity.Columns.Remove(strName + "dmtx");
                }
            }




            if (jobj["zq"].ToString() == "1")
            {
                entity.Columns["zqxx"].ColumnName = "灾情小型";
                entity.Columns["zqzx"].ColumnName = "灾情中型";
                entity.Columns["zqdx"].ColumnName = "灾情大型";
                entity.Columns["zqtdx"].ColumnName = "灾情特大型";
                var disasterLevel = jobj["DISASTERLEVEL"].ToString();
                if (disasterLevel != "")
                {
                    if ("灾情小型" != disasterLevel)
                    {
                        entity.Columns.Remove("灾情小型");
                    }
                    if ("灾情中型" != disasterLevel)
                    {
                        entity.Columns.Remove("灾情中型");
                    }
                    if ("灾情大型" != disasterLevel)
                    {
                        entity.Columns.Remove("灾情大型");
                    }
                    if ("灾情特大型" != disasterLevel)
                    {
                        entity.Columns.Remove("灾情特大型");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("zqxx");
                entity.Columns.Remove("zqzx");
                entity.Columns.Remove("zqdx");
                entity.Columns.Remove("zqtdx");
            }

            if (jobj["xq"].ToString() == "1")
            {
                entity.Columns["xqxx"].ColumnName = "险情小型";
                entity.Columns["xqzx"].ColumnName = "险情中型";
                entity.Columns["xqdx"].ColumnName = "险情大型";
                entity.Columns["xqtdx"].ColumnName = "险情特大型";
                var dangerLevel = jobj["DANGERLEVEL"].ToString();
                if (dangerLevel != "")
                {
                    if ("险情小型" != dangerLevel)
                    {
                        entity.Columns.Remove("险情小型");
                    }
                    if ("险情中型" != dangerLevel)
                    {
                        entity.Columns.Remove("险情中型");
                    }
                    if ("险情大型" != dangerLevel)
                    {
                        entity.Columns.Remove("险情大型");
                    }
                    if ("险情特大型" != dangerLevel)
                    {
                        entity.Columns.Remove("险情特大型");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("xqxx");
                entity.Columns.Remove("xqzx");
                entity.Columns.Remove("xqdx");
                entity.Columns.Remove("xqtdx");
            }


            if (jobj["jc"].ToString() == "1")
            {
                entity.Columns["jcms"].ColumnName = "定期目视监测";
                entity.Columns["jcss"].ColumnName = "监测建议";
                entity.Columns["jcdm"].ColumnName = "地面位移监测";
                entity.Columns["jcsb"].ColumnName = "深部位移监测";
                var MONITORSUGGESTION = jobj["MONITORSUGGESTION"].ToString();
                if (MONITORSUGGESTION != "")
                {
                    if ("定期目视监测" != MONITORSUGGESTION)
                    {
                        entity.Columns.Remove("定期目视监测");
                    }
                    if ("监测建议" != MONITORSUGGESTION)
                    {
                        entity.Columns.Remove("监测建议");
                    }
                    if ("地面位移监测" != MONITORSUGGESTION)
                    {
                        entity.Columns.Remove("地面位移监测");
                    }
                    if ("深部位移监测" != MONITORSUGGESTION)
                    {
                        entity.Columns.Remove("深部位移监测");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("jcms");
                entity.Columns.Remove("jcss");
                entity.Columns.Remove("jcdm");
                entity.Columns.Remove("jcsb");
            }
            if (jobj["fz"].ToString() == "1")
            {
                entity.Columns["fzqcqf"].ColumnName = "定期目视监测";
                entity.Columns["fzzyjc"].ColumnName = "监测建议";
                entity.Columns["fzbrbq"].ColumnName = "地面位移监测";
                entity.Columns["fzgczl"].ColumnName = "深部位移监测";
                var TREATMENTSUGGESTION = jobj["TREATMENTSUGGESTION"].ToString();
                if (TREATMENTSUGGESTION != "")
                {
                    if ("群测群防" != TREATMENTSUGGESTION)
                    {
                        entity.Columns.Remove("群测群防");
                    }
                    if ("专业监测" != TREATMENTSUGGESTION)
                    {
                        entity.Columns.Remove("专业监测");
                    }
                    if ("搬迁避让" != TREATMENTSUGGESTION)
                    {
                        entity.Columns.Remove("搬迁避让");
                    }
                    if ("工程治理" != TREATMENTSUGGESTION)
                    {
                        entity.Columns.Remove("工程治理");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("fzqcqf");
                entity.Columns.Remove("fzzyjc");
                entity.Columns.Remove("fzbrbq");
                entity.Columns.Remove("fzgczl");
            }

            if (jobj["mq"].ToString() == "1")
            {
                entity.Columns["mqwd"].ColumnName = "目前稳定";
                entity.Columns["mqqzbwd"].ColumnName = "目前基本稳定";
                entity.Columns["mqbwd"].ColumnName = "目前不稳定";
                var mqStatus = jobj["CURRENTSTABLESTATUS"].ToString();
                if (mqStatus != "")
                {
                    if ("A" != mqStatus)
                    {
                        entity.Columns.Remove("目前稳定");
                    }
                    if ("B" != mqStatus)
                    {
                        entity.Columns.Remove("目前基本稳定");
                    }
                    if ("C" != mqStatus)
                    {
                        entity.Columns.Remove("目前不稳定");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("mqwd");
                entity.Columns.Remove("mqqzbwd");
                entity.Columns.Remove("mqbwd");
            }
            if (jobj["jh"].ToString() == "1")
            {
                entity.Columns["jhwd"].ColumnName = "今后稳定";
                entity.Columns["jhqzbwd"].ColumnName = "今后基本稳定";
                entity.Columns["jhbwd"].ColumnName = "今后不稳定";
                var jhStatus = jobj["STABLETREND"].ToString();
                if (jhStatus != "")
                {
                    if ("A" != jhStatus)
                    {
                        entity.Columns.Remove("目前稳定");
                    }
                    if ("B" != jhStatus)
                    {
                        entity.Columns.Remove("目前基本稳定");
                    }
                    if ("C" != jhStatus)
                    {
                        entity.Columns.Remove("目前不稳定");
                    }
                }
            }
            else
            {
                entity.Columns.Remove("jhwd");
                entity.Columns.Remove("jhqzbwd");
                entity.Columns.Remove("jhbwd");
            }
            if (jobj["wh"].ToString() == "1")
            {
                entity.Columns["hhfw"].ColumnName = "损坏房屋";
                entity.Columns["hl"].ColumnName = "毁路";
                entity.Columns["hq"].ColumnName = "毁渠";
            }
            else
            {
                entity.Columns.Remove("hhfw");
                entity.Columns.Remove("hl");
                entity.Columns.Remove("hq");
            }
            if (jobj["wx"].ToString() == "1")
            {
                entity.Columns["wxcc"].ColumnName = "威胁财产";
                entity.Columns["wxrk"].ColumnName = "威胁人口";
            }
            else
            {
                entity.Columns.Remove("wxcc");
                entity.Columns.Remove("wxrk");
            }

            //if (entity.Columns.Contains("hpyh"))
            //{
            //    entity.Columns.Remove("hpyh");

            //}
            //if (entity.Columns.Contains("btyh"))
            //{
            //    entity.Columns.Remove("btyh");
            //}

            entity.Columns.Remove("id");
            entity.Columns.Remove("level");
            entity.Columns.Remove("parent_field");
            entity.Columns.Remove("isLeaf");
            entity.Columns.Remove("expanded");
            entity.Columns.Remove("area");

            //entity.Columns.Remove("jcms");
            //entity.Columns.Remove("jcss");
            //entity.Columns.Remove("jcdm");
            //entity.Columns.Remove("jcsb");
            //entity.Columns.Remove("fzqcqf");
            //entity.Columns.Remove("fzzyjc");
            //entity.Columns.Remove("fzbrbq");
            //entity.Columns.Remove("fzgczl");

            //if (jobj["level"].ToString() == "县")
            //{
            //    entity.Columns.Remove("市");
            //    entity.Columns.Remove("省");
            //}
            //else if (jobj["level"].ToString() == "市")
            //{
            //    entity.Columns.Remove("县");
            //    entity.Columns.Remove("省");
            //}
            //else if (jobj["level"].ToString() == "省")
            //{
            //    entity.Columns.Remove("县");
            //    entity.Columns.Remove("市");
            //}

            //第三步合并坐标到统计数据中，同时生成统计图片
            try
            {
                return LocationHelper.GetLocationByName(entity);
            }
            catch (Exception)
            {
            }
            return null;

        }

        //#region 导出word
        //public FileResult ExportWord(string filename, string queryJson)
        //{
        //    string path = string.Empty;
        //    try
        //    {
        //        path = this.Server.MapPath("~/") + "WordFile/" + DateTime.Now.ToString("yyyy.MM.dd HH-mm-ss.fff") + "/";
        //        string filePath = path + filename + "/";
        //        if (!System.IO.File.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }
        //        var queryParam = queryJson.ToJObject();
        //        if (!queryParam["GUID"].IsEmpty() && !queryParam["moduleId"].IsEmpty())
        //        {
        //            string GUID = queryParam["GUID"].ToString();
        //            string moduleId = queryParam["moduleId"].ToString();
        //            if (!queryParam["DISASTERTYPE"].IsEmpty())
        //            {
        //                WordExport(queryParam["DISASTERTYPE"].ToString(), GUID, moduleId, filename, filePath, "false", filename);
        //            }
        //            //DataTable dtResult = TBL_HazardBaseicainfoBLL.GetWordDataTable(GUID);//获取地灾关联信息
        //            //foreach (DataRow item in dtResult.Rows)
        //            //{
        //            //    WordExport(item["type"].ToString(), item["guid"].ToString(), "", filename, filePath, "false", item["filename"].ToString());
        //            //}
        //        }
        //        List<FileInfo> fileList = new List<FileInfo>();
        //        GetFiles(path, fileList);
        //        string downFileName = filename + ".zip";//下载文件名称
        //        string downFilePath = path + filename + ".zip";//下载文件路径
        //        string downType = "application/zip";//下载类型
        //        if (fileList.Count==1)//只有一个文件时
        //        {
        //            downFileName = Path.GetFileName(fileList[0].FullName);
        //            downFilePath = fileList[0].FullName;
        //            downType = "application/octet-stream";
        //        }
        //        else
        //        {
        //            System.IO.Compression.ZipFile.CreateFromDirectory(filePath, downFilePath);
        //        }
        //        FileStream fs = new FileStream(downFilePath, FileMode.Open, FileAccess.Read);
        //        string fileFullName = HttpUtility.UrlEncode(downFileName, System.Text.Encoding.UTF8);
        //        byte[] buffur = new byte[fs.Length];
        //        fs.Read(buffur, 0, (int)fs.Length);
        //        fs.Flush();
        //        fs.Close();

        //        return File(buffur, downType, downFileName);


        //    }
        //    catch (Exception ex)
        //    {
        //        byte[] b = System.Text.Encoding.UTF8.GetBytes("导出失败！\nException：" + ex.Message);
        //        return File(b, "text/plain");
        //    }
        //    finally
        //    {
        //        //删除服务器文件
        //        if (Directory.Exists(path))
        //        {
        //            Directory.Delete(path, true);
        //        }
        //    }
        //}
        //public void WordExport_(string type, string keyValue, string moduleId, string fileName, string docxSavePath, string IsdownLoad, string NewFileName = null)
        //{
        //    //string templatePath = string.Empty;
        //    ////string docxSavePath = @"C:\TempDocxPath\";//保存路径
        //    //if (string.IsNullOrWhiteSpace(docxSavePath))
        //    //{
        //    //    docxSavePath = @"C:\TempDocxPath\";//保存路径
        //    //}
        //    //DisasterTypeEnum typeEnum = (DisasterTypeEnum)Enum.Parse(typeof(DisasterTypeEnum), type);
        //    //switch (typeEnum)
        //    //{
        //    //    case DisasterTypeEnum.滑坡:
        //    //        templatePath = @"\滑坡调查表.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.滑坡隐患:
        //    //        templatePath = @"\滑坡调查表.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.崩塌:
        //    //        templatePath = @"\崩塌调查表.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.崩塌隐患:
        //    //        templatePath = @"\崩塌调查表.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.泥石流:
        //    //        templatePath = @"\泥石流调查表.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.地面沉降:
        //    //        templatePath = @"\地面沉降调查表.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.地面塌陷:
        //    //        templatePath = @"\地面塌陷调查表.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.地裂缝:
        //    //        templatePath = @"\地裂缝调查表.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.斜坡:
        //    //        templatePath = @"\不稳定斜坡调查表.dotx";
        //    //        break;
        //    //}
        //    //WordHelper ExportWord = null;
        //    //ExportWord = new WordExportData();
        //    //int subStrStart = templatePath.LastIndexOf("\\");
        //    //int subStrEnd = templatePath.LastIndexOf('.');
        //    //string _docName = templatePath.Substring(subStrStart + 1, subStrEnd - subStrStart - 1);
        //    //string tempath = System.Web.HttpContext.Current.Server.MapPath("/Template").ToString();
        //    //string savepath = ExportWord.WordLoadData(docxSavePath, tempath + templatePath, keyValue, moduleId, typeEnum, NewFileName);
        //    //if (ExportWord._downLoadResult == -1 || ExportWord._downLoadResult == 0)
        //    //{
        //    //    return;
        //    //}
        //    //else
        //    //{
        //    //    if (string.IsNullOrWhiteSpace(IsdownLoad))
        //    //    {
        //    //        ExportWord.DeleteOrDownFile(savepath, fileName);
        //    //    }
        //    //}
        //}
        //#endregion
        /// <summary>
        /// 递归获取所有文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileList"></param>
        public void GetFiles(string path, List<FileInfo> fileList)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] filesChiled = root.GetFiles();
            foreach (FileInfo item in filesChiled)
            {
                fileList.Add(item);
            }
            DirectoryInfo[] directoryInfo = root.GetDirectories();
            foreach (DirectoryInfo item in directoryInfo)
            {
                GetFiles(item.FullName, fileList);
            }
        }
        LonChange s = new LonChange();
        [HttpGet]
        public object btnBLtoXY(string _lat, string _lon, string csStr, string numberNameStr)
        {
            if (!_lat.IsEmpty() && !_lon.IsEmpty())
            {
                var result = s.btnBLtoXY_Click(_lat, _lon, csStr, numberNameStr);
                return ToJsonResult(result);
            }
            return null;
        }
        [HttpGet]
        public object btnXYtoBL(string _x, string _y, string csStr, string numberNameStr)
        {
            if (!_x.IsEmpty() && !_y.IsEmpty())
            {
                var result = s.btnXYtoBL_Click(_x, _y, csStr, numberNameStr);
                return ToJsonResult(result);
            }
            return null;
        }
    }


}