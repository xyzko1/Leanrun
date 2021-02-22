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
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-05-25 16:29
    /// �� �������ι滮�ɹ���
    /// </summary>
    public class TBL_ACHIEVEMENT_PREPLANController : MvcControllerBase
    {
        private TBL_ACHIEVEMENT_PREPLANBLL tbl_achievement_preplanbll = new TBL_ACHIEVEMENT_PREPLANBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_ACHIEVEMENT_PREPLANIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ACHIEVEMENT_PREPLANForm()
        {
            return View();
        }
        /// <summary>
        /// ��ѯ���
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ACHIEVEMENT_PREPLANQueryBrowse()
        {
            return View();
        }
        /// <summary>
        /// ͳ�Ʒ���
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ACHIEVEMENT_PREPLANAnalyse()
        {
            return View();
        }
        /// <summary>
        /// �ɹ��ļ�
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_PREPLANMultiMedia()
        {
            return View();
        }
        
        #endregion

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        [LogContent("���ι滮�ɹ���", OpType.Query)]
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
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        [LogContent("���ι滮�ɹ���", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_achievement_preplanbll.GetList(queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = tbl_achievement_preplanbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// ���ڷ��ι滮ͳ�Ƶ�������
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
                result.Columns["provincename"].ColumnName = "ʡ";
                col_num++;
            }
            if (result.Columns.Contains("cityname"))
            {
                result.Columns["cityname"].SetOrdinal(col_num);
                result.Columns["cityname"].ColumnName = "��";
                col_num++;
            }
            if (result.Columns.Contains("countyname"))
            {
                result.Columns["countyname"].SetOrdinal(col_num);
                result.Columns["countyname"].ColumnName = "��";
                col_num++;
            }
            if (result.Columns.Contains("disastercount"))
            {
                result.Columns["disastercount"].SetOrdinal(col_num);
                result.Columns["disastercount"].ColumnName = "�ֺ������";
                col_num++;
            }
            if (result.Columns.Contains("zlghcount"))
            {
                result.Columns["zlghcount"].SetOrdinal(col_num);
                result.Columns["zlghcount"].ColumnName = "���ι滮����";
                col_num++;
            }
            ExcelHelper.ExcelDownloadOnlyDT(result, "���ι滮ͳ��", "���ι滮ͳ�Ƶ���.xls");
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
                string tablename = context.Request.Params["uploadType"];  //�ϴ��ļ�����

                Exportword = new Word_ACHIEVEMENT_PREPLAN();
                templatePath = @"\���ι滮�ɹ���.dotx";

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
                        const long ChunkSize = 102400;//100K ÿ�ζ�ȡ�ļ���ֻ��ȡ100K���������Ի����������ѹ��
                        byte[] buffer = new byte[ChunkSize];
                        context.Response.Clear();
                        System.IO.FileStream iStream = System.IO.File.OpenRead(savepath);
                        long dataLengthToRead = iStream.Length;//��ȡ���ص��ļ��ܴ�С
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
                            int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//��ȡ�Ĵ�С
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
                byte[] b = System.Text.Encoding.UTF8.GetBytes("����ʧ�ܣ�\nException��" + ex.Message);
                return File(b, "text/plain");
            }
            finally
            {
                //ɾ���������ļ�
                //if (Directory.Exists(path))
                //{
                //    Directory.Delete(path, true);
                //}
            }
        }

        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("���ι滮�ɹ���", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_achievement_preplanbll.RemoveForm(keyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("���ι滮�ɹ���", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_ACHIEVEMENT_PREPLANEntity entity)
        {
            tbl_achievement_preplanbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
