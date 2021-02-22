using Infoearth.Application.Common.Entitys;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Infoearth.Util;
using Infoearth.Application.Common;
using Infoearth.Application.Common.Dtos;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.Code;
using Infoearth.Application.Busines.SystemManage;

namespace Infoearth.Application.Web.Areas.DemoManage.Controllers
{
    public class KneecoordinateController : MvcControllerBase
    {
        
        [HttpPost]
        public ActionResult UploadifyFileToServer(string DataItemEncode, string DataItemName, HttpPostedFileBase Filedata)
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
                string userId = OperatorProvider.Provider.Current().UserId;
                string fileGuid = Guid.NewGuid().ToString();
                long filesize = Filedata.ContentLength;
                string FileEextension = Path.GetExtension(Filedata.FileName);
                string uploadDate = DateTime.Now.ToString("yyyyMMdd");//
                string dataItemFilePath = @"C:/DemoFilePath";
                string virtualPath = string.Format("{0}/{1}/{2}/{3}{4}", dataItemFilePath, userId, uploadDate, fileGuid, FileEextension);
                //创建文件夹
                string path = Path.GetDirectoryName(virtualPath);
                Directory.CreateDirectory(path);
                FileAnnexesEntity fileAnnexesEntity = new FileAnnexesEntity();
                if (!System.IO.File.Exists(virtualPath))
                {
                    //virtualPath += Filedata.FileName;
                    //保存文件
                    Filedata.SaveAs(virtualPath);
                }
                string str = string.Empty;
                List<KneeCoordinateExModal> list = new List<KneeCoordinateExModal>();
                using (FileStream f = new FileStream(virtualPath, FileMode.Open, FileAccess.Read))
                {
                    HSSFWorkbook workbook = new HSSFWorkbook(f);
                    ISheet sheet = workbook.GetSheetAt(0);
                    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                    {
                        HSSFRow r = (HSSFRow)sheet.GetRow(i);
                        string item = (i + 1).ToString() + ":" + Convert.ToDouble(r.GetCell(0).ToString()) + "," + Convert.ToDouble(r.GetCell(1).ToString()) + ";";
                        str += item;
                    }
                    f.Close();
                }
                List<string> lstStr = new List<string>();
                lstStr.Add(str);
                Directory.Delete(path,true);
                return Content(lstStr.ToJson());
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult KneecoordinateOutput(string coordinate, string CoordSys, bool IsProjectiveGeo)
        {
            if (!string.IsNullOrEmpty(coordinate))
            {
                IKneeCoordinateAppService kneecoorService = new KneeCoordinateAppService();
                List<KneeCoordinateModal> lst = new List<KneeCoordinateModal>();
                string[] coordinateArr = coordinate.Split(';');
                foreach (var item in coordinateArr)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        string[] xyArr = item.Split(',');
                        if (xyArr.Length > 0)
                        {
                            string[] xArr = xyArr[0].Split(':');
                            KneeCoordinateModal modal = new KneeCoordinateModal();
                            modal.CoordinateX = Convert.ToDouble(xArr[1]);
                            modal.CoordinateY = Convert.ToDouble(xyArr[1]);
                            lst.Add(modal);
                        }
                    }
                }
                KneeCoordinateInput input = new KneeCoordinateInput();
                input.CoordSys = CoordSys;
                input.InitialData = lst;
                input.IsProjectiveGeo = IsProjectiveGeo;
                var outputCoordinate = kneecoorService.GeoCoordinateList(input);
                return Content(outputCoordinate.data.ToJson());
            }
            return null;
        }

        [HttpGet]
        public ActionResult ConvertKneecoordinate(string strJson)
        {
            List<KneeCoordinateExModal> lst = new List<KneeCoordinateExModal>();
            if (!string.IsNullOrEmpty(strJson))
            {
                string[] coordinateArr = strJson.Split(';');
                for (int item = 0; item < coordinateArr.Length;item++ )
                {
                    if (!string.IsNullOrEmpty(coordinateArr[item]))
                    {
                        string[] xyArr = coordinateArr[item].Split(',');
                        if (xyArr.Length > 0)
                        {
                            string[] xArr = xyArr[0].Split(':');
                            KneeCoordinateExModal modal = new KneeCoordinateExModal();
                            modal.SerialNum = (item + 1).ToString();
                            modal.CoordinateX = Convert.ToDouble(xArr[1]);
                            modal.CoordinateY = Convert.ToDouble(xyArr[1]);
                            lst.Add(modal);
                        }
                    }
                }
            }
            if (lst.Count < 3)
            {
                for (int i = 0; i < (3 - lst.Count); i++)
                {
                    KneeCoordinateExModal modal = new KneeCoordinateExModal();
                    modal.SerialNum = (lst.Count + i + 1).ToString();
                    modal.CoordinateX = Convert.ToDouble(0);
                    modal.CoordinateY = Convert.ToDouble(0);
                    lst.Add(modal);
                }
            }
            return Content(lst.ToJson());
        }
        [HttpGet]
        public ActionResult AddKneecoordinate(string strJson)
        {
            List<KneeCoordinateExModal> lst = new List<KneeCoordinateExModal>();
            if (!string.IsNullOrEmpty(strJson))
            {
                string[] coordinateArr = strJson.Split(';');
                for (int item = 0; item < coordinateArr.Length; item++)
                {
                    if (!string.IsNullOrEmpty(coordinateArr[item]))
                    {
                        string[] xyArr = coordinateArr[item].Split(',');
                        if (xyArr.Length > 0)
                        {
                            string[] xArr = xyArr[0].Split(':');
                            KneeCoordinateExModal modal = new KneeCoordinateExModal();
                            modal.SerialNum = (item + 1).ToString();
                            modal.CoordinateX = Convert.ToDouble(xArr[1]);
                            modal.CoordinateY = Convert.ToDouble(xyArr[1]);
                            lst.Add(modal);
                        }
                    }
                }
            }
            KneeCoordinateExModal addModal = new KneeCoordinateExModal();
            addModal.SerialNum = (lst.Count + 1).ToString();
            addModal.CoordinateX = 0;
            addModal.CoordinateY = 0;
            lst.Add(addModal);
            return Content(lst.ToJson());
        }

        [HttpGet]
        public ActionResult SaveForm()
        {
            return Success("成功");
        }
    }
}