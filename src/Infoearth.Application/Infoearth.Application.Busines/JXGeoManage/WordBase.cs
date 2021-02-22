using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using iTelluro.Explorer.Client.SeedWork;
using iTelluro.FileImage.BusinessInfoProxy.BusinessInfoService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Busines.JXGeoManage
{
    public class WordBase : IDisposable
    {
        private BusinessInfoServiceClient _pBusinessInfo = null;
        public Dictionary<BusinessFileDetailinfoDTO, string> _gdownload;
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
        /// 构造函数创建多媒体服务
        /// </summary>
        public WordBase()
        {
            _pBusinessInfo = new BusinessInfoServiceClient();
            _imageFormat = System.Configuration.ConfigurationManager.AppSettings["imageExt"].ToString().Split(',');
            System.ServiceModel.Description.IEndpointBehavior item = new AttachSSOInfoBehavior();
            if (!_pBusinessInfo.Endpoint.Behaviors.Contains(item))
            {
                _pBusinessInfo.Endpoint.Behaviors.Add(item);
            }
        }

        ~WordBase()
        {
            Dispose();
        }

        /// <summary>
        /// 生成Word
        /// </summary>
        /// <param name="sFileName">模板生成的新Docx</param>
        /// <param name="name">模板路径</param>
        /// <param name="unifiedCode"></param>
        /// <param name="moudleId"></param>
        public string WordLoadDataOne(string sFileName, string name, string unifiedCode, string moudleId)//用于单条记录
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
                sFileName = sFileName + _docName + fileName;
                string sFullPathDOCX = sFileName + _extDocx;
                string[] extName = this._imageFormat;

                if (name.Substring(name.LastIndexOf('\\') + 1) != "避灾明白卡.dotx")
                {
                    File.Copy(templateName, tempFileFullPath);

                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(tempFileFullPath, true))//将模板转换成docx
                    {
                        wordDoc.ChangeDocumentType(WordprocessingDocumentType.Document);
                        BusinessFileDetailinfoDTO[] lstPic = _pBusinessInfo.GetFileInfos(moudleId, unifiedCode, extName);
                        _downLoadResult = FillBookmark(unifiedCode, wordDoc, lstPic);
                    }
                    if (_downLoadResult != -1)
                    {
                        File.Copy(tempFileFullPath, sFullPathDOCX);
                        File.Delete(tempFileFullPath);
                        return sFullPathDOCX;
                    }
                    return string.Empty;
                }
                else
                {
                    BusinessFileDetailinfoDTO[] lstPic = _pBusinessInfo.GetFileInfos(moudleId, unifiedCode, extName);
                    _downLoadResult = FillBookmark(unifiedCode, null, lstPic);
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 填充Word模板,-1表示DTO为NULL，0表示图片下载失败,1表示图片下载成功(包括没图片的)
        /// </summary>
        /// <param name="unifiecode">编号</param>
        /// <param name="w">word模板对象</param>
        /// <param name="lstPic">图片</param>
        protected virtual int FillBookmark(string unifiecode, WordprocessingDocument w, BusinessFileDetailinfoDTO[] lstPic)
        {
            return 1;
        }

        #region IDisposable 成员
        public void Dispose()
        {

        }
        #endregion

        /// <summary>
        /// 下载所需要的图片
        /// </summary>
        /// <param name="picturels">多媒体文件集合</param>
        /// <param name="pictureTypeCode">需要下载文件类型</param>
        public void DownloadImage(BusinessFileDetailinfoDTO[] picturels, string[][] pictureTypeCode)
        {
            Dictionary<BusinessFileDetailinfoDTO, string> download = new Dictionary<BusinessFileDetailinfoDTO, string>();
            if (pictureTypeCode != null)
            {
                foreach (BusinessFileDetailinfoDTO item in picturels)
                {
                    for (int i = 0; i < pictureTypeCode.Length; i++)
                    {
                        if (item.TYPECODE == pictureTypeCode[i][1])
                        {
                            download.Add(item, pictureTypeCode[i][1]);
                        }
                    }
                }
            }
            else
            {
                foreach (BusinessFileDetailinfoDTO item in picturels)
                {
                    download.Add(item, item.TYPECODE);
                }
            }

            _gdownload = download;

            foreach (BusinessFileDetailinfoDTO item in download.Keys)
            {
                //http://192.168.100.55/multimediawebsite/page/download.ashx?Guid=7a3f4e27-8e21-49bb-8447-3151cb476eda&Filename=桌面截图&Thumbnail=1024
                WebClient client = new WebClient();
                client.DownloadFileCompleted += client_DownloadFileCompleted;
                string url = System.Configuration.ConfigurationManager.AppSettings["MultiMediaUrl"] + "/page/download.ashx";
                string filename = item.FILEINFOGUID + item.ExtName;
                string filepath = _tempFile + filename;

                if (!Directory.Exists(_tempFile))
                {
                    Directory.CreateDirectory(_tempFile);
                }

                if (File.Exists(filepath))
                {
                    _Addpictures++;
                }
                else
                {
                    client.DownloadFileAsync(new Uri(url + "?Guid=" + item.FILEINFOGUID + "&Filename=" + item.FILENAME + "&Thumbnail" + pixel), filepath, item);
                }
            }
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
    }
}
