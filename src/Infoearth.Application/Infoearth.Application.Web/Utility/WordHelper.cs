using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using Infoearth.Application.Web.Areas.JXGeoManage.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Infoearth.Application.Web
{
    public class WordHelper
    {
        public const string _tempFile = @"C:\temp\";
        public const string _dotxSavePath = @"C:\TempDotxPath\";
        public const string _extDotx = ".dotx";
        public const string _extDocx = ".docx";
        public readonly string[] _imageFormat;
        public const string _warning = "下载失败,请重新下载";
        public int _Addpictures = 0;
        public string _sFileName = string.Empty;
        public string _templateName = string.Empty;
        public string _docName = string.Empty;
        public int _downLoadResult = 0;
        public string pixel = "512";

        /// <summary>
        /// 构造函数
        /// </summary>
        public WordHelper()
        {

        }

        /// <summary>
        /// 生成word
        /// </summary>
        /// <param name="sFileName">文件名</param>
        /// <param name="name">文件路径</param>
        /// <param name="unifiedCode">遗迹或公园编号</param>
        /// <param name="moduleId">模块id</param>
        /// <param name="mineType">矿山类型</param>
        /// <returns>word文件全路径</returns>
        public string WordLoadData(string sFileName, string name, string unifiedCode, string moduleId, DisasterTypeEnum DisasterType, string NewFileName = null)
        {
            try
            {
                string templateName = name;
                _sFileName = sFileName;
                _templateName = templateName;
                int subStrStart = name.LastIndexOf('\\');
                int subStrEnd = name.LastIndexOf('.');
                _docName = name.Substring(subStrStart + 1, subStrEnd - subStrStart - 1);

                if (!Directory.Exists(_dotxSavePath))
                {
                    DirectoryInfo dInfo = new DirectoryInfo(_dotxSavePath);
                    dInfo.Create();
                }

                string[] newfilepath = sFileName.Split('\\');
                string vp = "";
                for (int i = 0; i < newfilepath.Length; i++)
                {
                    if (i == 0)
                    {
                        vp += newfilepath[i];
                    }
                    else
                    {
                        vp = vp + "\\" + newfilepath[i];
                    }

                    if (!Directory.Exists(vp))
                    {
                        DirectoryInfo dInfo = new DirectoryInfo(vp);
                        dInfo.Create();
                    }
                }

                string fileName = DateTime.Now.ToFileTime().ToString();
                string tempFileFullPath = _dotxSavePath + fileName + _extDotx;
                //sFileName = sFileName + _docName + fileName;
                string sFullPathDOCX = string.Empty;
                if (!string.IsNullOrWhiteSpace(NewFileName))
                {
                    sFullPathDOCX = sFileName + NewFileName + _extDocx;
                }
                else
                {
                    sFullPathDOCX = sFileName + _docName + fileName + _extDocx;
                }

                string[] extName = this._imageFormat;

                File.Copy(templateName, tempFileFullPath);

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(tempFileFullPath, true))//将模板转换成docx
                {
                    wordDoc.ChangeDocumentType(WordprocessingDocumentType.Document);
                    _downLoadResult = FillBookmark(unifiedCode, moduleId, DisasterType, wordDoc);
                }
                File.Copy(tempFileFullPath, sFullPathDOCX);
                File.Delete(tempFileFullPath);
                return sFullPathDOCX;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 填充Word模板
        /// </summary>
        /// <param name="unifiecode">编号</param>
        /// <param name="w">word模板对象</param>
        protected virtual int FillBookmark(string unifiecode, string moudleId, DisasterTypeEnum DisasterType, WordprocessingDocument w)
        {
            return 1;
        }

        /// <summary>
        /// 异步下载文件，计数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            _Addpictures++;
        }
        public void DeleteOrDownFile(string savepath, string fileName, string browserType = "")
        {
            HttpContext context = HttpContext.Current;
            FileInfo fi = new FileInfo(@savepath);
            if (fi.Exists)
            {
                const long downLoadSize = 102400;//100K 每次读取文件，只读取100K，这样可以缓解服务器的压力
                byte[] buffer = new byte[downLoadSize];
                context.Response.Clear();
                System.IO.FileStream stream = System.IO.File.OpenRead(savepath);
                long dataLengthToRead = stream.Length;//获取下载的文件的总大小
                context.Response.ContentType = "application/octet-stream";
                if (browserType == "fireFox")
                {
                    context.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlDecode(fileName, System.Text.Encoding.UTF8) + ".docx");
                }
                else
                {
                    context.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8) + ".docx");
                }
                while (dataLengthToRead > 0 && context.Response.IsClientConnected)
                {
                    int lengthRead = stream.Read(buffer, 0, Convert.ToInt32(downLoadSize));//读取的大小
                    context.Response.OutputStream.Write(buffer, 0, lengthRead);
                    context.Response.Flush();
                    dataLengthToRead = dataLengthToRead - lengthRead;
                }
                context.Response.Close();
                stream.Close();
                stream.Dispose();
            }
            System.IO.File.Delete(savepath);
        }


    }
    public enum DisasterTypeEnum
    {
        滑坡 = 001,
        崩塌 = 002,
        泥石流 = 003,
        地面沉降 = 004,
        地面塌陷 = 005,
        地裂缝 = 006,
        斜坡 = 007,

        滑坡隐患,
        崩塌隐患
    }
    public enum ControlEnum
    {
        CheckBox,
        Text
    }
}