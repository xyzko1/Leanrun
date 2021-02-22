using iTelluro.FileImage.BusinessInfoProxy.BusinessInfoService;
using iTelluro.FileImage.FileImageInfoProxy.FileImageInfoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Threading;
using System.IO;
using Infoearth.Application.Code;
using System.Net;

namespace Infoearth.Application.Web.Areas.SystemManage.Controllers
{
    public class MultMediaController : MvcControllerBase
    {
        private BusinessInfoServiceClient _businessInfoService;
        private FileImageInfoServiceClient _fileImageInfoService;
        private string[] typeCodeList;

        public MultMediaController()
        {
            _businessInfoService = new BusinessInfoServiceClient();
            _fileImageInfoService = new FileImageInfoServiceClient();
        }

        //
        // GET: /MultMedia/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AjaxOnly]
        public string ConfirmMediaInfo(string code, string moduleid)
        {
            string moduleId = moduleid;
            BusinessFileDetailinfoDTO[] fileinfo = _businessInfoService.FindFileInfos(moduleId, code);
            if (fileinfo.Length == 0)
            {
                return "0";
            }
            else
            {
                return moduleId;
            }
        }

        /// <summary>
        /// 更新媒体信息
        /// </summary>
        /// <param name="addData">添加的多媒体信息</param>
        /// <param name="deleteData">删除的多媒体信息</param>
        /// <param name="objGuid">ID</param>
        /// <returns>"true":更新成功；"false":更新失败</returns>
        [HttpPost]
        [AjaxOnly]
        public string UpdateMediaInfo(string addData, string deleteData, string moduleID, string belongObjectGuid)
        {
            string[] codeGuid = addData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) ;
            string[] bussid = deleteData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            bool addFlag = false;
            bool deleteFlag = false;
            if (deleteData != "" && bussid != null && bussid.Length > 0)
            {
                _businessInfoService.BusinessFileinfoRemoveRelates(bussid);
                deleteFlag = true;
            }
            else
            {
                deleteFlag = true;
            }
            if (addData != "" && codeGuid != null && codeGuid.Length > 0)
            {
                _businessInfoService.BusinessFileinfoRelate(codeGuid, moduleID, belongObjectGuid);
                addFlag = true;
            }
            else
            {
                addFlag = true;
            }

            if (addFlag && deleteFlag)
            {
                return "true";
            }
            return "false";
        }

        /// <summary>
        /// 根据模块ID和guid 去找关联的附件
        /// </summary>
        /// <param name="moduleID">模块id</param>
        /// <param name="belongObjectGuid">地质遗迹或地质公园id</param>
        /// <returns>多媒体信息的json字符串</returns>
        [HttpPost]
        [AjaxOnly]
        //[HandlerLogin(LoginMode.Ignore)]
        public ActionResult FindMedInfoList(string moduleID, string belongObjectGuid)
        {
            BusinessFileDetailinfoDTO[] dto = new BusinessFileDetailinfoDTO[0];
            if (!string.IsNullOrEmpty(belongObjectGuid))
            {
               dto= _businessInfoService.FindFileInfos(moduleID, belongObjectGuid);
            }
            typeCodeList = _businessInfoService.GetTypeCodeList(moduleID);
            List<ZTreeNodeModel> treeList = new List<ZTreeNodeModel>();

            string typeCode = "";
            for (int i = 0; i < typeCodeList.Length; i++)
            {
                string[] typeInfos = typeCodeList[i].Split(',');//多媒体类型
                typeCode = typeInfos[0];
                ZTreeNodeModel node = new ZTreeNodeModel();
                node.id = typeInfos[0];
                node.name = typeInfos[1];
                node.nodetype = typeInfos[2];
                node.icon = "../../Content/images/list.png";
                treeList.Add(node);
                List<BusinessFileDetailinfoDTO> business = dto.Where(e => e.TYPECODE == typeCode).ToList();

                foreach (BusinessFileDetailinfoDTO b in business)
                {
                    ZTreeNodeModel nodeC = new ZTreeNodeModel();
                    nodeC.id = b.FILEINFOGUID;
                    nodeC.name = b.FILENAME;
                    nodeC.nodetype = "FILE";
                    nodeC.pId = node.id;
                    nodeC.businessID = b.BUSSNISSFILEINFOGUID;
                    nodeC.icon = "../../Content/images/file.png";
                    treeList.Add(nodeC);
                }
            }
            return Content(treeList.ToJson());
        }

        /// <summary>
        /// 得到多媒体列表
        /// </summary>
        /// <returns>多媒体信息的json字符串</returns>
        public List<TreeEntity> GetMediaList()
        {
            List<TreeEntity> treeList = new List<TreeEntity>();
            for (int i = 0; i < typeCodeList.Length; i++)
            {
                string[] typeInfos = typeCodeList[i].Split(',');//多媒体类型
                TreeEntity node = new TreeEntity();
                node.id = typeInfos[0];
                node.text = typeInfos[1];
                node.value = typeInfos[2];
                node.title = "";
                bool hasChildren = false;
                node.isexpand = true;
                node.complete = true;
                node.hasChildren = hasChildren;
                treeList.Add(node);
            }
            return treeList;
        }

        /// <summary>
        /// 根据文件名,文件上传时间查询 文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数据</param>
        /// <param name="type">文件类型</param>
        /// <returns>Grid数据集Json</returns>
        [HttpGet]
        public ActionResult FindFileInfos(Pagination pagination, string queryJson)
        {
            int pageIndex = 0;
            string fileName = string.Empty;
            string fileType = string.Empty;
            string userAccount = string.Empty;
            DateTime startTime = DateTime.MinValue;
            DateTime endTime = DateTime.MaxValue;
            if (pagination.page <= 1)
            {
                pageIndex = 0;
            }
            else
            {
                pageIndex = pagination.page - 1;
            }
            var queryParam = queryJson.ToJObject();
          
            if (!string.IsNullOrEmpty(queryParam["FileName"].ToString()))
            {
                fileName = queryParam["FileName"].ToString();
            }
            if (!string.IsNullOrEmpty(queryParam["FileType"].ToString()))
            {
                fileType = queryParam["FileType"].ToString();
            }

            if (!string.IsNullOrEmpty(queryParam["FileUser"].ToString()))
            {
                userAccount = queryParam["FileUser"].ToString();
            }
            //操作时间
            if (!string.IsNullOrEmpty(queryParam["StartTime"].ToString())&&!string.IsNullOrEmpty(queryParam["EndTime"].ToString()))
            {
                 startTime =DateTime.Parse( queryParam["StartTime"].ToString());
                 endTime =DateTime.Parse( queryParam["EndTime"].ToString()).AddDays(1);
            }
            FileImageInfoDTO[] list=null;

            list = _fileImageInfoService.FindFileInfosByPageTypeWithUser("", fileName, startTime, endTime, pageIndex, pagination.rows, fileType, userAccount);
            int listCount = _fileImageInfoService.FindFileInfoCountByTypeWithUser(fileName, startTime, endTime, fileType, userAccount);
            int pageCounts = listCount % pagination.rows == 0 ? listCount / pagination.rows : ((listCount / pagination.rows) + 1);
            var watch = CommonHelper.TimerStart();

            var JsonData = new
            {
                rows = list,
                total = pageCounts,
                page = pagination.page,
                records = listCount,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.ToJson());
        }

        /// <summary>
        /// 关联附件信息
        /// </summary>
        /// <param name="typeCode">附件类型编号</param>
        /// <param name="moduleID">模块ID</param>
        /// <param name="belongObjectGuid">所属对象编号</param>
        /// <param name="fileinfoGuid">附件的guid</param>
        /// <returns>true：关联成功；false:关联失败</returns>
        [HttpPost]
        [AjaxOnly]
        public object AddFileInfo(string typeCode, string moduleID, string belongObjectGuid, string fileinfoGuid)
        {
            try
            {
                bool success = _businessInfoService.AddFileInfo(typeCode, moduleID, belongObjectGuid, fileinfoGuid);
                return success;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除指定的附件
        /// </summary>
        /// <param name="id">文件GUID</param>
        /// <returns>0：成功；1：失败</returns>
        [HttpPost]
        [AjaxOnly]
        //[HandlerLogin(LoginMode.Ignore)]
        public string RemoveFileInfo(string id)
        {
            bool bState;
            try
            {
                bState = _businessInfoService.RemoveFileInfo(id);
                if (bState)
                {
                    return "0";
                }
                else
                {
                    return "1";
                }
            }
            catch
            {
                return "1";
            }
        }

        /// <summary>
        /// 删除指定的文件
        /// </summary>
        /// <param name="id">文件GUID</param>
        /// <returns>0：成功；1：失败</returns>
        [HttpPost]
        [AjaxOnly]
        public string RemoveFiles(string id)
        {
            bool bState;
            try
            {
                bState = _fileImageInfoService.RemoveFileInfo(id);
                if (bState)
                {
                    return "0";
                }
                else
                {
                    return "1";
                }
            }
            catch
            {
                return "1";
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UploadifyForm()
        {
            return View();
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="folderId">文件夹Id</param>
        /// <param name="Filedata">文件对象</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadifyFile(string folderId, HttpPostedFileBase Filedata)
        {
            try
            {
                Thread.Sleep(500);////延迟500毫秒
                //没有文件上传，直接返回
                if (Filedata == null || string.IsNullOrEmpty(Filedata.FileName) || Filedata.ContentLength == 0)
                {
                    if (Request.Files.Count > 0)
                    {
                        Filedata = Request.Files[0];
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                //获取文件完整文件名(包含绝对路径)
                //文件存放路径格式：/Resource/ResourceFile/{userId}{data}/{guid}.{后缀名}

                string userId = OperatorProvider.Provider.Current().Account;
                string token = WebHelper.GetCookie("Token");
                if (!string.IsNullOrEmpty(token))
                {
                    token = HttpUtility.UrlDecode(token);
                    if (token.Contains(','))
                    {
                        userId = token.Split(',')[1];
                    }
                }
                string fileGuid = Guid.NewGuid().ToString();
                long filesize = Filedata.ContentLength;
                string FileEextension = Path.GetExtension(Filedata.FileName);
              

                const int maxSiz = 1024 * 100; //设置每次传100k  
                Stream stream = Filedata.InputStream;    //读取本地文件
                var file = new FileImageUploadDTO
                {
                    Offset = 0,
                    CREATOR = userId,
                    FILEDESC = "多媒体附件",
                    FILENAME = Path.GetFileNameWithoutExtension(Filedata.FileName),
                    METAGUID = FileEextension,
                    FILEEXTNAME = FileEextension,
                    Length = filesize
                };//每次上传新的文件

                while (file.Length != file.Offset)  //循环的读取文件,上传，直到文件的长度等于文件的偏移量
                {
                    file.Data = new byte[file.Length - file.Offset <= maxSiz ? file.Length - file.Offset : maxSiz]; //设置传递的数据的大小
                    stream.Position = file.Offset; //设置本地文件数据的读取位置
                    stream.Read(file.Data, 0, file.Data.Length);//把数据写入到file.Data中
                    file = _fileImageInfoService.UplodaFile(file);     //上传
                }

                stream.Close();
                stream.Dispose();
                var newFile = _fileImageInfoService.doConvert(file);
                return Success("上传成功...",newFile);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 附件列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FileSelectForm()
        {
            return View();
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        public void DownloadFile(string keyValue)
        {
            FileImageInfoDTO dto = _fileImageInfoService.FindFileInfo(keyValue);
            if (dto == null)
            {
                return;
            }
            WebClient wc = new WebClient();
            wc.DownloadFileCompleted += wc_DownloadFileCompleted;
            string uploadDate = DateTime.Now.ToString("yyyyMMdd");
            string virtualPath = string.Format("~/Resource/DocumentFile/{0}/{1}/{2}{3}", dto.CREATOR, uploadDate, dto.FILENAME, dto.METAGUID.Trim());
            string fullFileName = this.Server.MapPath(virtualPath);
            //创建文件夹
            string path = Path.GetDirectoryName(fullFileName);
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string downLoadUrl = System.Configuration.ConfigurationManager.AppSettings["MediaPath"]+"/page/download.ashx?Guid=" + keyValue + "&Filename=" + dto.FILENAME;
            wc.DownloadFileAsync(new Uri(downLoadUrl), fullFileName, fullFileName);
        }
        [HttpGet]
        public ActionResult Show()
        {
            return View();
        }

        private void wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            string path = e.UserState.ToString();

            if (FileDownHelper.FileExists(path))
            {
                string filename = Server.UrlDecode(System.IO.Path.GetFileName(path));//返回客户端文件名称
                FileDownHelper.DownLoadold(path, filename);
            }
        }

        [HttpGet]
        [AjaxOnly]
        public string GetMultMediaWebPath()
        {
            return System.Configuration.ConfigurationManager.AppSettings["MediaPath"];
        }

    }


}