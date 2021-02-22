using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Infoearth.Util.Offices;
using System.Web;
using System.Threading;
using System;
using System.IO;
using Infoearth.Application.Code;
using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Cache;
using System.Linq;
using Infoearth.Application.Entity.PublicInfoManage;
using Infoearth.Application.Busines.PublicInfoManage;
using Infoearth.Application.Entity.SystemManage;
using System.Data.Common;
using System.Reflection;
using Infoearth.Application.Entity;
using Infoearth.Application.Web.Utility;
using Infoearth.Application.Busines.AuthorizeManage;

namespace Infoearth.Application.Web.Controllers
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 
    /// 创建人：佘赐雄
    /// 编辑人：LR0101 2016:11:14 22:08
    /// 日 期：2016.2.03 10:58
    /// 描 述：公共控制器
    /// </summary>
    public class UtilityController : Controller
    {
        private ModuleBLL moduleBLL = new ModuleBLL();
        #region 验证对象值不能重复
        #endregion

        #region 导入Excel
        System_SetExcelImprotBLL templatebll = new System_SetExcelImprotBLL();
        System_SetExcelImportFiledBLL filedBll = new System_SetExcelImportFiledBLL();
        /// <summary>
        /// Excel导入弹层
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExcelImportForm()
        {
            return View();
        }
        /// <summary>
        /// 下载excel模板文件
        /// </summary>
        /// <param name="templateId"></param>
        [HttpPost]
        public void DownExcelTemplate(string templateId)
        {
            var templateInfo = templatebll.GetEntity(templateId);
            var filedsInfo = filedBll.GetList("{\"F_ImportTemplateId\":\"" + templateInfo.F_Id + "\"}");

            //设置导出格式
            ExcelConfig excelconfig = new ExcelConfig();
            excelconfig.FileName = Server.UrlDecode(templateInfo.F_Name) + ".xls";
            excelconfig.IsAllSizeColumn = true;
            excelconfig.ColumnEntity = new List<ColumnEntity>();
            //表头
            List<GridColumnModel> columnData = new List<GridColumnModel>();
            DataTable dt = new DataTable();
            foreach (var col in filedsInfo)
            {
                if (col.F_RelationType != 1 && col.F_RelationType != 4 && col.F_RelationType != 5 && col.F_RelationType != 6 && col.F_RelationType != 7)
                {
                    excelconfig.ColumnEntity.Add(new ColumnEntity()
                    {
                        Column = col.F_FliedName,
                        ExcelColumn = col.F_ColName,
                        Alignment = "center",
                    });
                    dt.Columns.Add(col.F_FliedName, typeof(string));
                }
            }
            ExcelHelper.ExcelDownload(dt, excelconfig);
        }
        /// <summary>
        /// excel文件导入（通用）
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="Filedata"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ExecuteImportExcel(string templateId, HttpPostedFileBase Filedata)
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
                string FileEextension = Path.GetExtension(Filedata.FileName);
                DataTable dt = ExcelHelper.ExcelImport(Filedata.InputStream, FileEextension);//excel导入数据
                var data = templatebll.ExcelImport(templateId, dt);

                var jsonData = new
                {
                    fileId = templateId,
                    Rows = data
                };

                return Content(jsonData.ToJson());
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        #region 导出Excel
        /// <summary>
        /// 请选择要导出的字段页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ExcelExportForm()
        {
            return View();
        }
        /// <summary>
        /// 执行导出Excel
        /// </summary>
        /// <param name="columnJson">表头</param>
        /// <param name="rowJson">数据</param>
        /// <param name="exportField">导出字段</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        [ValidateInput(false)]
        public void ExecuteExportExcel(string columnJson, string rowJson, string exportField, string filename)
        {
            //设置导出格式
            ExcelConfig excelconfig = new ExcelConfig();
            excelconfig.Title = Server.UrlDecode(filename);
            excelconfig.TitleFont = "微软雅黑";
            excelconfig.TitlePoint = 15;
            excelconfig.FileName = Server.UrlDecode(filename) + ".xls";
            excelconfig.IsAllSizeColumn = true;
            excelconfig.ColumnEntity = new List<ColumnEntity>();
            //表头
            List<GridColumnModel> columnData = columnJson.ToList<GridColumnModel>();
            //行数据
            DataTable rowData = rowJson.ToTable();
            //写入Excel表头
            string[] fieldInfo = exportField.Split(',');
            foreach (string item in fieldInfo)
            {
                var list = columnData.FindAll(t => t.name == item);
                foreach (GridColumnModel gridcolumnmodel in list)
                {
                    if (gridcolumnmodel.hidden.ToLower() == "false" && gridcolumnmodel.label != null)
                    {
                        string align = gridcolumnmodel.align;
                        excelconfig.ColumnEntity.Add(new ColumnEntity()
                        {
                            Column = gridcolumnmodel.name,
                            ExcelColumn = gridcolumnmodel.label,
                            //Width = gridcolumnmodel.width,
                            Alignment = gridcolumnmodel.align,
                        });
                    }
                }
            }
            ExcelHelper.ExcelDownload(rowData, excelconfig);
        }
        #endregion

        #region 上传文件
        private FileAnnexesBLL fileAnnexesBLL = new FileAnnexesBLL();
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="DataItemEncode"></param>
        /// <param name="DataItemName"></param>
        /// <param name="Filedata"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadifyFile(string DataItemEncode, string DataItemName, HttpPostedFileBase Filedata)
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
                string dataItemFilePath = new DataItemDetailBLL().GetDataItemList().Where(t => t.F_EnCode == DataItemEncode).First(t => t.F_ItemName == DataItemName).F_ItemValue;
                string virtualPath = string.Format("{0}/{1}/{2}/{3}{4}", dataItemFilePath, userId, uploadDate, fileGuid, FileEextension);
                //创建文件夹
                string path = Path.GetDirectoryName(virtualPath);
                Directory.CreateDirectory(path);
                FileAnnexesEntity fileAnnexesEntity = new FileAnnexesEntity();
                if (!System.IO.File.Exists(virtualPath))
                {
                    //保存文件
                    Filedata.SaveAs(virtualPath);
                    //文件信息写入数据库
                    fileAnnexesEntity.F_Id = fileGuid;
                    fileAnnexesEntity.F_FileName = Filedata.FileName;
                    fileAnnexesEntity.F_FilePath = virtualPath;
                    fileAnnexesEntity.F_FileSize = filesize.ToString();
                    fileAnnexesEntity.F_FileExtensions = FileEextension;
                    fileAnnexesEntity.F_FileType = FileEextension.Replace(".", "");
                    fileAnnexesBLL.SaveEntity(null, fileAnnexesEntity);
                }
                var data = new
                {
                    fileId = fileAnnexesEntity.F_Id
                };
                return Content(data.ToJson());
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public void DownFile(string fileId)
        {
            FileAnnexesEntity data = fileAnnexesBLL.GetEntity(fileId);
            string filename = Server.UrlDecode(data.F_FileName);//返回客户端文件名称
            string filepath = data.F_FilePath;
            if (FileDownHelper.FileExists(filepath))
            {
                FileDownHelper.DownLoadold(filepath, filename);
            }
        }
        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <param name="fileIdList"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetFiles(string fileIdList)
        {
            try
            {
                var data = fileAnnexesBLL.GetEntityList(fileIdList);
                return Content(data.ToJson());

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RemoveFile(string fileId)
        {
            try
            {
                FileAnnexesEntity fileInfoEntity = fileAnnexesBLL.GetEntity(fileId);
                fileAnnexesBLL.DeleteEntity(fileId);
                //删除文件
                if (System.IO.File.Exists(fileInfoEntity.F_FilePath))
                {
                    System.IO.File.Delete(fileInfoEntity.F_FilePath);
                }
                var data = new
                {
                    code = "1",
                };
                return Content(data.ToJson());
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
        #endregion

        #region 上传Ckeditor图片
        /// <summary>
        /// 上传Ckeditor图片
        /// </summary>
        /// <param name="upload"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadImage(string DataItemEncode, string DataItemName, HttpPostedFileBase Filedata)
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
                string dataItemFilePath = new DataItemDetailBLL().GetDataItemList().Where(t => t.F_EnCode == DataItemEncode).First(t => t.F_ItemName == DataItemName).F_ItemValue;
                string virtualPath = string.Format("{0}/{1}/{2}/{3}{4}", dataItemFilePath, userId, uploadDate, fileGuid, FileEextension);
                //创建文件夹
                string path = Path.GetDirectoryName(virtualPath);
                Directory.CreateDirectory(path);
                FileAnnexesEntity fileAnnexesEntity = new FileAnnexesEntity();
                if (!System.IO.File.Exists(virtualPath))
                {
                    //保存文件
                    Filedata.SaveAs(virtualPath);
                    //文件信息写入数据库
                    fileAnnexesEntity.F_Id = fileGuid;
                    fileAnnexesEntity.F_FileName = Filedata.FileName;
                    fileAnnexesEntity.F_FilePath = virtualPath;
                    fileAnnexesEntity.F_FileSize = filesize.ToString();
                    fileAnnexesEntity.F_FileExtensions = FileEextension;
                    fileAnnexesEntity.F_FileType = FileEextension.Replace(".", "");
                    fileAnnexesBLL.SaveEntity(null, fileAnnexesEntity);
                }
                string url = string.Format("http://{0}/Utility/DownFile?fileId={1}", Request.UrlReferrer.Authority, fileAnnexesEntity.F_Id);
                string CKEditorFuncNum = System.Web.HttpContext.Current.Request["CKEditorFuncNum"];
                //上传成功后，我们还需要通过以下的一个脚本把图片返回到第一个tab选项

                return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
        #endregion

        #region 解决打印插件跨域问题
        /// <summary>
        /// 打印页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult printIndex()
        {
            return View();
        }
        #endregion

        #region 展示系统图标
        /// <summary>
        /// 图标选择展示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult IconPreviewIndex()
        {
            return View();
        }
        #endregion

        #region 获取当前信息
        /// <summary>
        /// 图标选择展示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult getCurrentInfo()
        {
            var data = new
            {
                userId = OperatorProvider.Provider.Current().UserId,
                userName = OperatorProvider.Provider.Current().UserName,
                companyId = OperatorProvider.Provider.Current().CompanyId,
                departmentId = OperatorProvider.Provider.Current().DepartmentId,
                time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return Content(data.ToJson());
        }
        #endregion

        [HttpGet]
        public ActionResult GetLearunData()
        {
            var data = new
            {
                qty = 100,
                total = 1000

            };

            return Content(data.ToJson());
        }
        /// <summary>
        /// 获取默认行政区划
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult DefalutCode()
        {
            string code = string.Empty;
            code = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
            return Content(code);
        }

        #region 导出excel_Common
        [HttpGet]
        public ActionResult GetAllPropertys(string entityName)
        {
            IDictionary<string, string> returnValue = new Dictionary<string, string>();
            //if (entityName.ToUpper() == "TBL_QXYB_WEATHERSTATIONEntity".ToUpper())
            //{
            //    returnValue = GetAllPropertyDic<Infoearth.Application.Entity.WeatherManage.TBL_QXYB_WEATHERSTATIONEntity>();
            //}
            //else if (entityName.ToUpper() == "TBL_ZLGC_INFOEntity".ToUpper())
            //{
            //    returnValue = GetAllPropertyDic<Infoearth.Application.Entity.ZLGCManage.TBL_ZLGC_INFOEntity>();
            //}
            string strcolumns = "[";
            foreach (var item in returnValue.Keys)
            {
                strcolumns += "{value:\"" + item + "\",text:\"" + returnValue[item] + "\"},";
            }
            strcolumns = strcolumns.TrimEnd(',') + "]";

            return Content(strcolumns);
        }
        public static IDictionary<string, string> GetAllPropertyDic<T4>()
        {
            IDictionary<string, string> dicProps = new Dictionary<string, string>();
            PropertyInfo[] propertys = typeof(T4).GetProperties();
            for (int j = 0; j < propertys.Count(); j++)
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
            return dicProps;
        }
        /// <summary>
        /// 获取字典字段
        /// </summary>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        public static IDictionary<string, string> GetAllDicFiled<T4>()
        {
            IDictionary<string, string> dicProps = new Dictionary<string, string>();
            PropertyInfo[] propertys = typeof(T4).GetProperties();
            for (int j = 0; j < propertys.Count(); j++)
            {
                object[] attrs = propertys[j].GetCustomAttributes(typeof(DescAttribute), false);
                if (attrs == null || attrs.Length <= 0)
                {
                    continue;
                }
                DescAttribute attr = (DescAttribute)attrs[0];
                if (!string.IsNullOrEmpty(attr.DicName) && !dicProps.ContainsKey(attr.DicName))
                {
                    dicProps.Add(propertys[j].Name, attr.DicName);
                }
            }
            return dicProps;
        }
        /// <summary>
        /// 字典项转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="dicColumn"></param>
        public static void ConvertDicValue<T>(List<T> list)
        {
            ClientDataController cl = new ClientDataController();
            Dictionary<string, object> dicList = (Dictionary<string, object>)cl.GetDataItem();//字典项集合
            IDictionary<string, string> dicColumn = GetAllDicFiled<T>();
            PropertyInfo[] propertys = typeof(T).GetProperties();
            foreach (var entity in list)
            {
                foreach (var field in dicColumn.Keys)
                {
                    PropertyInfo p = entity.GetType().GetProperty(field);
                    string value = p.GetValue(entity, null) == null ? "" : p.GetValue(entity, null).ToString();
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        string valueName = GetDicValue(dicList, dicColumn[field], value);
                        p.SetValue(entity, valueName);//赋值

                    }

                }
            }
        }
        /// <summary>
        /// 获取字典值
        /// </summary>
        /// <param name="dicColumn"></param>
        /// <param name="dicName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDicValue(Dictionary<string, object> dicList, string dicName, string value)
        {
            string returnValue = string.Empty;
            if (!string.IsNullOrWhiteSpace(value))
            {
                foreach (var dic in dicList.Keys)
                {
                    if (dicList.ContainsKey(dicName))
                    {
                        Dictionary<string, string> list = (Dictionary<string, string>)dicList[dicName];
                        foreach (var item in list.Keys)
                        {
                            if (item == value)
                            {
                                returnValue = list[item];
                                break;
                            }
                        }
                    }

                }

            }
            return returnValue;
        }

        public static DataTable ListToDataTable<T>(List<T> entitys, List<ColumnEntity> ColumnList)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                ColumnEntity entity = ColumnList.Where(p => p.Column == entityProperties[i].Name).FirstOrDefault();
                if (entity != null)
                {
                    dt.Columns.Add(entity.ExcelColumn);
                }
            }
            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[ColumnList.Count];
                int index = 0;
                foreach (var item in entityProperties)
                {
                    if (ColumnList.Select(p => p.Column).Contains(item.Name))
                    {
                        entityValues[index] = item.GetValue(entity, null);
                        index++;
                    }
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }
        #endregion

        /// <summary>
        /// 获取系统配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetAppSetting(string key)
        {
            string code = string.Empty;
            code = System.Configuration.ConfigurationManager.AppSettings[key];
            return Content(code);
        }
        [HttpGet]
        public ActionResult InitModules()
        {
            moduleBLL.InitModules();
            return Content("初始化成功");
        }
    }
}
