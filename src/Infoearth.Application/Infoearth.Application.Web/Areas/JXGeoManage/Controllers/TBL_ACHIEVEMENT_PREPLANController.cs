using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System;
using System.Web;
using System.Data;
using Infoearth.Util.Offices;
using System.IO;
using Infoearth.Util.Extension;

using System.Collections.Generic;


namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-05-25 16:29
    /// 描 述：防治规划成果表
    /// </summary>
    public class TBL_ACHIEVEMENT_PREPLANController : MvcControllerBase
    {
        private TBL_ACHIEVEMENT_PREPLANBLL tbl_achievement_preplanbll = new TBL_ACHIEVEMENT_PREPLANBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_ACHIEVEMENT_PREPLANIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ACHIEVEMENT_PREPLANForm()
        {
            return View();
        }
        /// <summary>
        /// 查询浏览
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ACHIEVEMENT_PREPLANQueryBrowse()
        {
            return View();
        }
        /// <summary>
        /// 统计分析
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ACHIEVEMENT_PREPLANAnalyse()
        {
            return View();
        }
        /// <summary>
        /// 成果文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_PREPLANMultiMedia()
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
        [LogContent("防治规划成果表", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_achievement_preplanbll.GetPageList(pagination, queryJson);
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
        [LogContent("防治规划成果表", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_achievement_preplanbll.GetList(queryJson);
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
            var data = tbl_achievement_preplanbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 关于防治规划统计导出功能
        /// </summary>
        /// <param name="queryJson"></param>
        public void ExcelZLGHCountDownloadExt(string queryJson)
        {
            var obj = queryJson.ToJObject();
            string ProvinceName = obj.GetValue("PROVINCENAME").ToString();
            string CityName = obj.GetValue("CITYNAME").ToString();
            string CountyName = obj.GetValue("COUNTRYNAME").ToString();
            string ZLGHYEAR = obj.GetValue("Static_Year").ToString();
            string ZLGHUNIT = obj.GetValue("Static_Unit").ToString();
            DataTable result = tbl_achievement_preplanbll.PREPLANCountStatics(ProvinceName, CityName, CountyName, ZLGHYEAR, ZLGHUNIT, "");
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
            if (result.Columns.Contains("countyname"))
            {
                result.Columns["countyname"].SetOrdinal(col_num);
                result.Columns["countyname"].ColumnName = "县";
                col_num++;
            }
            if (result.Columns.Contains("disastercount"))
            {
                result.Columns["disastercount"].SetOrdinal(col_num);
                result.Columns["disastercount"].ColumnName = "灾害点个数";
                col_num++;
            }
            if (result.Columns.Contains("zlghcount"))
            {
                result.Columns["zlghcount"].SetOrdinal(col_num);
                result.Columns["zlghcount"].ColumnName = "防治规划个数";
                col_num++;
            }
            ExcelHelper.ExcelDownloadOnlyDT(result, "防治规划统计", "防治规划统计导出.xls");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public FileResult ExportWord(string filename, string queryJson)
        {
            try
            {
                var queryParam = queryJson.ToJObject();
                string GUID = "";
                if (!queryParam["GUID"].IsEmpty())
                {
                     GUID = queryParam["GUID"].ToString();
                }
                HttpContext context = System.Web.HttpContext.Current;
                WordBase Exportword = null;
                context.Response.ContentType = "text/plain";
                string docxSavePath = @"C:\TempDocxPath\";
                string fileName = DateTime.Now.ToFileTime().ToString();
                string unifiedCode = GUID;
                string moudleID = context.Request.QueryString.Get("moudleId");
                string imageThumbnail = context.Request.QueryString.Get("imageThumbnail");
                string browserType = context.Request.QueryString.Get("browserType");
                string templatePath = string.Empty;
                string tablename = context.Request.Params["uploadType"];  //上传文件类型

                Exportword = new Word_ACHIEVEMENT_PREPLAN();
                templatePath = @"\防治规划成果表.dotx";

                Exportword.pixel = imageThumbnail;
                int subStrStart = templatePath.LastIndexOf('\\');
                int subStrEnd = templatePath.LastIndexOf('.');
                string _docName = templatePath.Substring(subStrStart + 1, subStrEnd - subStrStart - 1);
                string tempath = context.Server.MapPath("../Template").ToString();
                string savepath = Exportword.WordLoadDataOne(docxSavePath, tempath + templatePath, unifiedCode, moudleID);


                if (Exportword._downLoadResult == -1 || Exportword._downLoadResult == 0)
                {
                    return null;
                }
                else
                {
                    FileInfo f = new FileInfo(@savepath);
                    if (f.Exists == true)
                    {
                        const long ChunkSize = 102400;//100K 每次读取文件，只读取100K，这样可以缓解服务器的压力
                        byte[] buffer = new byte[ChunkSize];
                        context.Response.Clear();
                        System.IO.FileStream iStream = System.IO.File.OpenRead(savepath);
                        long dataLengthToRead = iStream.Length;//获取下载的文件总大小
                        context.Response.ContentType = "application/octet-stream";
                        if (browserType == "fireFox")
                        {
                            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlDecode(_docName + fileName, System.Text.Encoding.UTF8) + ".docx");
                        }
                        else
                        {
                            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(_docName + fileName, System.Text.Encoding.UTF8) + ".docx");
                        }
                        while (dataLengthToRead > 0 && context.Response.IsClientConnected)
                        {
                            int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小
                            context.Response.OutputStream.Write(buffer, 0, lengthRead);
                            context.Response.Flush();
                            dataLengthToRead = dataLengthToRead - lengthRead;
                        }
                        context.Response.Close();
                        iStream.Close();
                        iStream.Dispose();
                    }
                   //File.Delete(savepath);
                }
                byte[] buffur = new byte[255];
                return File(buffur, "application/zip", filename + ".zip");
            }
            catch (Exception ex)
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes("导出失败！\nException：" + ex.Message);
                return File(b, "text/plain");
            }
            finally
            {
                //删除服务器文件
                //if (Directory.Exists(path))
                //{
                //    Directory.Delete(path, true);
                //}
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
        [LogContent("防治规划成果表", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_achievement_preplanbll.RemoveForm(keyValue);
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
        [LogContent("防治规划成果表", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_ACHIEVEMENT_PREPLANEntity entity)
        {
            tbl_achievement_preplanbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
