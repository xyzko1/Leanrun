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
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-14 14:58
    /// �� �����ֺ��������
    /// </summary>
    public class TBL_HAZARDBASICINFOController : MvcControllerBase
    {
        private TBL_HAZARDBASICINFOBLL TBL_HazardBaseicainfoBLL = new TBL_HAZARDBASICINFOBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOIndex()
        {
            return View();
        }


        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_LSXQIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOForm()
        {
            return View();
        }
        /// <summary>
        /// ��ѯ���ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult ZHDCXLL()
        {
            return View();
        }
        /// <summary>
        /// ��ѯ���ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult ZHDCXLL_HISTORY()
        {
            return View();
        }
        /// <summary>
        /// ��ѯ���ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult DZPC_SELECT()
        {
            return View();
        }
        /// <summary>
        /// ��ѯ���ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult ZYYHD_SELECT()
        {
            return View();
        }
        /// <summary>
        /// �����ֺ�����
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult CreateCodeWaterIndexNew()
        {
            return View();
        }
        /// <summary>
        /// �鿴����ֺ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult CreateCodeWaterIndex()
        {
            return View();
        }
        /// <summary>
        /// ���ɱ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_LANDSLIP_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// ���ɱ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_AVALANCHE_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// ���ɱ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_DEBRISFLOW_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// ���ɱ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_LANDSETTLEMENT_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// ���ɱ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_COLLAPSE_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// ���ɱ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult DETAIL()
        {
            return View();
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_LANDCRACK_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// �������ѯ����
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
        /// �������ݲ�ѯ
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOQueryBrowse()
        {
            return View();
        }
        /// <summary>
        /// ��ʷ���ݲ�ѯ
        /// </summary>
        /// <returns></returns>
        public ActionResult TBL_HAZARDBASICINFOQueryBhistory()
        {
            return View();
        }
        /// <summary>
        /// ���ɱ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_SLOPE_HISTORYIndex()
        {
            return View();
        }
        /// <summary>
        /// ���ɱ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TJSH()
        {
            return View();
        }
        /// <summary>
        /// ͳ���ֺ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOCountAnalyse()
        {
            return View();
        }
        /// <summary>
        /// ͳ���ֺ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOCountAnalysePC()
        {
            return View();
        }
        /// <summary>
        /// ͳ���ֺ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_ZYYHDTJ()
        {
            return View();
        }
        /// <summary>
        ///�Ա�����
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult HisComparer()
        {
            return View();
        }
        /// <summary>
        /// ѡ���ֺ�����Ϣ
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult HAZARDBASCOMMONIndex()
        {
            return View();
        }
        /// <summary>
        /// ѡ���ֺ�����Ϣ
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult QCQFZHD()
        {
            return View();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult DeleteInfo()
        {
            return View();
        }
        /// <summary>
        /// �Ա�
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult CompareRead()
        {
            return View();
        }
        /// <summary>
        /// ���ͳ������
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult StatisticeContext()
        {
            return View();
        }
        /// <summary>
        /// ���ͳ������
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult StatisticeContextNew()
        {
            return View();
        }

        /// <summary>
        /// ���ͳ������
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult StatisticeCondition()
        {
            return View();
        }

        /// <summary>
        /// ���ͳ������
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult HarzardCompare()
        {
            return View();
        }

        /// <summary>
        /// �Ų��б�ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOIndexPC()
        {
            return View();
        }
        /// <summary>
        /// �Ų��ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOFormPC()
        {
            return View();
        }
        /// <summary>
        /// �Ų��ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult HarzardTrendAnalyse()
        {
            return View();
        }
        /// <summary>
        /// ����ͳ��ͼ��ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult Statistics()
        {
            return View();
        }
        /// <summary>
        /// ��鳣��ͳ��ͼ��ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult StatisticsXC()
        {
            return View();
        }
        /// <summary>
        /// ��ѯͳ�Ʒ�����20190227������
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult selectTJ()
        {
            return View();
        }
        /// <summary>
        /// ��ʷ���ݶԱȱ�
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_LSSJIndex()
        {
            return View();
        }
        /// <summary>
        /// �����ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult DETAIL_DIAOCHA()
        {
            return View();
        }
        /// <summary>
        /// �����ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_ZLGCINDEX()
        {
            return View();
        }
        /// <summary>
        /// ���ͳ������
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult ComStatisticeContext()
        {
            return View();
        }
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_SPATIAL()
        {
            return View();
        }

        /// <summary>
        /// ����Excel
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult ImportExcelForm()
        {
            return View();
        }

        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOIndex_10()
        {
            return View();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_HAZARDBASICINFOIndex_5W()
        {
            return View();
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��Ӧ�����ֺ�������Ϣ��ѯ������ݵ���
        /// </summary>
        /// <param name="queryJson"></param>
        [HttpGet]
        public void ExcelDownloadExt(string queryJson)
        {
            DataTable data = TBL_HazardBaseicainfoBLL.GetDataTableList(queryJson);
            for (var a = 0; a < data.Rows.Count; a++)
            {
                data.Rows[a]["��⽨��"] = data.Rows[a]["��⽨��"].ToString().Replace("A", "����Ŀ��Ѳ��");
                data.Rows[a]["��⽨��"] = data.Rows[a]["��⽨��"].ToString().Replace("B", "��װ���׼����ʩ");
                data.Rows[a]["��⽨��"] = data.Rows[a]["��⽨��"].ToString().Replace("C", "����λ�Ƽ��");
                data.Rows[a]["��⽨��"] = data.Rows[a]["��⽨��"].ToString().Replace("D", "�λ�Ƽ��");
                data.Rows[a]["���ν���"] = data.Rows[a]["���ν���"].ToString().Replace("E", "Ӧ����Σ��");
                data.Rows[a]["���ν���"] = data.Rows[a]["���ν���"].ToString().Replace("F", "����ʾ��");
                data.Rows[a]["���ν���"] = data.Rows[a]["���ν���"].ToString().Replace("A", "Ⱥ��Ⱥ��");
                data.Rows[a]["���ν���"] = data.Rows[a]["���ν���"].ToString().Replace("B", "רҵ���");
                data.Rows[a]["���ν���"] = data.Rows[a]["���ν���"].ToString().Replace("C", "��Ǩ����");
                data.Rows[a]["���ν���"] = data.Rows[a]["���ν���"].ToString().Replace("D", "������");
            }
                ExcelHelper.ExcelDownloadOnlyDT(data, "�ֺ������ݵ���", "�ֺ��������ѯ.xls");
        }

        /// <summary>
        /// ��Ӧ�����ֺ�������Ϣ��ѯ������ݵ���
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        [HttpGet]
        public void ExcelDownload(string queryJson, string condition = null)
        {
            List<TBL_HAZARDBASICINFOEntity> data = TBL_HazardBaseicainfoBLL.GetZYPageList(queryJson, condition).ToList();
            DataTable dt = DataHelper.ListToDataTable<TBL_HAZARDBASICINFOEntity>(data);
            ExcelHelper.ExcelDownloadOnlyDT(dt, "�ֺ������ݵ���", "�ֺ��������ѯ.xls");
        }

        /// <summary>
        /// ����Ӧ�����ֺ�������Ϣͳ�������ݵ���
        /// </summary>
        /// <param name="queryJson"></param>
        public void GetHazardbasiciStaticsExcelDown(string queryJson, string colum)
        {
            DataTable data = TBL_HazardBaseicainfoBLL.GetDataCountTableList(queryJson, colum);
            ExcelHelper.ExcelDownloadOnlyDT(data, "�ֺ���ͳ�Ʒ������", "�ֺ���ͳ�Ʒ������.xls");
        }
        /// <summary>
        /// �Ų��Ӧ�����ֺ�������Ϣͳ�������ݵ���
        /// </summary>
        /// <param name="queryJson"></param>
        public void GetHazardbasiciStaticsExcelDownPC(string queryJson, string colum)
        {
            DataTable data = TBL_HazardBaseicainfoBLL.GetDataCountTableListPC(queryJson, colum);
            ExcelHelper.ExcelDownloadOnlyDT(data, "�ֺ���ͳ�Ʒ����Ų�", "�ֺ���ͳ�Ʒ����Ų�.xls");
        }
        /// <summary>
        /// ��Ҫ������ͳ��
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="colum"></param>
        public void GetHazardbasiciStaticsExcelDownPC2(string queryJson, string colum)
        {
            DataTable data = TBL_HazardBaseicainfoBLL.GetDataCountTableListPC(queryJson, colum);
            foreach (DataColumn dc in data.Columns)
            {
                if (dc.ColumnName == "������")
                {
                    dc.ColumnName = "�ֺ���";
                }
            }
            ExcelHelper.ExcelDownloadOnlyDT(data, "��Ҫ������ͳ��", "��Ҫ������ͳ��.xls");
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
                case "zqs"://������
                    returnValue = "������";
                    break;
                case "yhdgmqs"://�������ģ����
                    returnValue = "�������ģ����";
                    break;
                case "zhlxjgmqs"://�ֺ����ͼ���ģ����
                    returnValue = "�ֺ����ͼ���ģ����";
                    break;
                case "nxhqs"://����������
                    returnValue = "����������";
                    break;
                case "nxhd"://�����ŵ�
                    returnValue = "�����ŵ�";
                    break;
                case "gmdjdb"://���顢���顢��ģ�ȼ��Ա�
                    returnValue = "���顢���顢��ģ�ȼ��Ա�";
                    break;
                default:
                    returnValue = "������";
                    break;
            }
            return returnValue;
        }
        #endregion

        #region ����word
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
                    //DataTable dtResult = TBL_HazardBaseicainfoBLL.GetWordDataTable(GUID);//��ȡ���ֹ�����Ϣ
                    //foreach (DataRow item in dtResult.Rows)
                    //{
                    //    WordExport(item["type"].ToString(), item["guid"].ToString(), "", filename, filePath, "false", item["filename"].ToString());
                    //}
                }
                List<FileInfo> fileList = new List<FileInfo>();
                GetFiles(path, fileList);
                string downFileName = filename + ".zip";//�����ļ�����
                string downFilePath = path + filename + ".zip";//�����ļ�·��
                string downType = "application/zip";//��������
                if (fileList.Count == 1)//ֻ��һ���ļ�ʱ
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
                byte[] b = System.Text.Encoding.UTF8.GetBytes("����ʧ�ܣ�\nException��" + ex.Message);
                return File(b, "text/plain");
            }
            finally
            {
                //ɾ���������ļ�
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
        }
        public void WordExport(string type, string keyValue, string moduleId, string fileName, string docxSavePath, string IsdownLoad, string NewFileName = null)
        {
            string templatePath = string.Empty;
            //string docxSavePath = @"C:\TempDocxPath\";//����·��
            if (string.IsNullOrWhiteSpace(docxSavePath))
            {
                docxSavePath = @"C:\TempDocxPath\";//����·��
            }
            DisasterTypeEnum typeEnum = (DisasterTypeEnum)Enum.Parse(typeof(DisasterTypeEnum), type);
            switch (typeEnum)
            {
                case DisasterTypeEnum.����:
                    templatePath = @"\���µ����.dotx";
                    break;
                case DisasterTypeEnum.��������:
                    templatePath = @"\���µ����.dotx";
                    break;
                case DisasterTypeEnum.����:
                    templatePath = @"\���������.dotx";
                    break;
                case DisasterTypeEnum.��������:
                    templatePath = @"\���������.dotx";
                    break;
                case DisasterTypeEnum.��ʯ��:
                    templatePath = @"\��ʯ�������.dotx";
                    break;
                case DisasterTypeEnum.�������:
                    templatePath = @"\������������.dotx";
                    break;
                case DisasterTypeEnum.��������:
                    templatePath = @"\�������ݵ����.dotx";
                    break;
                case DisasterTypeEnum.���ѷ�:
                    templatePath = @"\���ѷ�����.dotx";
                    break;
                case DisasterTypeEnum.б��:
                    templatePath = @"\���ȶ�б�µ����.dotx";
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
        ///  �����ֺ�������ͳ��ͼ
        /// </summary>
        /// <param name="queryJson"></param>
        /// /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetZHDCountResult(string queryJson, int type)
        {
            var jobj = queryJson.ToJObject();

            //��һ����ȡ��������
            //LocationHelper.GetDistricts();

            //�ڶ�������ͳ�����ݲ�����ɿ���ֱ�ӵ��õ�������ʽ
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
                entity.Columns["provincename"].ColumnName = "ʡ";
            }
            if (entity.Columns.Contains("cityname"))
            {
                entity.Columns.Remove("city");
                entity.Columns["cityname"].ColumnName = "��";
            }
            if (entity.Columns.Contains("countyname"))
            {
                entity.Columns.Remove("county");
                entity.Columns["countyname"].ColumnName = "��";
            }
            if (entity.Columns.Contains("zhd"))
            {
                if (jobj["zhd"].ToString() == "1")
                {
                    entity.Columns["zhd"].ColumnName = "�ֺ����ܼ�";
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
                    entity.Columns["yhd"].ColumnName = "�������ܼ�";
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
                bool flag = false;//�����ֺ����������
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
                    entity.Columns[strName + "hp"].ColumnName = "����";
                    entity.Columns[strName + "bt"].ColumnName = "����";
                    entity.Columns[strName + "xp"].ColumnName = "б��";
                    entity.Columns[strName + "nsl"].ColumnName = "��ʯ��";
                    entity.Columns[strName + "dmcj"].ColumnName = "�������";
                    entity.Columns[strName + "dlf"].ColumnName = "���ѷ�";
                    entity.Columns[strName + "dmtx"].ColumnName = "��������";
                    var disasterType = jobj["DISASTERTYPE"].ToString();
                    if (disasterType != "")
                    {
                        if ("����" != disasterType)
                        {
                            entity.Columns.Remove("����");
                        }
                        if ("����" != disasterType)
                        {
                            entity.Columns.Remove("����");
                        }
                        if ("б��" != disasterType)
                        {
                            entity.Columns.Remove("б��");
                        }
                        if ("��ʯ��" != disasterType)
                        {
                            entity.Columns.Remove("��ʯ��");
                        }
                        if ("�������" != disasterType)
                        {
                            entity.Columns.Remove("�������");
                        }
                        if ("���ѷ�" != disasterType)
                        {
                            entity.Columns.Remove("���ѷ�");
                        }
                        if ("��������" != disasterType)
                        {
                            entity.Columns.Remove("��������");
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
                entity.Columns["zqxx"].ColumnName = "����С��";
                entity.Columns["zqzx"].ColumnName = "��������";
                entity.Columns["zqdx"].ColumnName = "�������";
                entity.Columns["zqtdx"].ColumnName = "�����ش���";
                var disasterLevel = jobj["DISASTERLEVEL"].ToString();
                if (disasterLevel != "")
                {
                    if ("����С��" != disasterLevel)
                    {
                        entity.Columns.Remove("����С��");
                    }
                    if ("��������" != disasterLevel)
                    {
                        entity.Columns.Remove("��������");
                    }
                    if ("�������" != disasterLevel)
                    {
                        entity.Columns.Remove("�������");
                    }
                    if ("�����ش���" != disasterLevel)
                    {
                        entity.Columns.Remove("�����ش���");
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
                entity.Columns["xqxx"].ColumnName = "����С��";
                entity.Columns["xqzx"].ColumnName = "��������";
                entity.Columns["xqdx"].ColumnName = "�������";
                entity.Columns["xqtdx"].ColumnName = "�����ش���";
                var dangerLevel = jobj["DANGERLEVEL"].ToString();
                if (dangerLevel != "")
                {
                    if ("����С��" != dangerLevel)
                    {
                        entity.Columns.Remove("����С��");
                    }
                    if ("��������" != dangerLevel)
                    {
                        entity.Columns.Remove("��������");
                    }
                    if ("�������" != dangerLevel)
                    {
                        entity.Columns.Remove("�������");
                    }
                    if ("�����ش���" != dangerLevel)
                    {
                        entity.Columns.Remove("�����ش���");
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
                entity.Columns["jcms"].ColumnName = "����Ŀ�Ӽ��";
                entity.Columns["jcss"].ColumnName = "��⽨��";
                entity.Columns["jcdm"].ColumnName = "����λ�Ƽ��";
                entity.Columns["jcsb"].ColumnName = "�λ�Ƽ��";
                var MONITORSUGGESTION = jobj["MONITORSUGGESTION"].ToString();
                if (MONITORSUGGESTION != "")
                {
                    if ("����Ŀ�Ӽ��" != MONITORSUGGESTION)
                    {
                        entity.Columns.Remove("����Ŀ�Ӽ��");
                    }
                    if ("��⽨��" != MONITORSUGGESTION)
                    {
                        entity.Columns.Remove("��⽨��");
                    }
                    if ("����λ�Ƽ��" != MONITORSUGGESTION)
                    {
                        entity.Columns.Remove("����λ�Ƽ��");
                    }
                    if ("�λ�Ƽ��" != MONITORSUGGESTION)
                    {
                        entity.Columns.Remove("�λ�Ƽ��");
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
                entity.Columns["fzqcqf"].ColumnName = "����Ŀ�Ӽ��";
                entity.Columns["fzzyjc"].ColumnName = "��⽨��";
                entity.Columns["fzbrbq"].ColumnName = "����λ�Ƽ��";
                entity.Columns["fzgczl"].ColumnName = "�λ�Ƽ��";
                var TREATMENTSUGGESTION = jobj["TREATMENTSUGGESTION"].ToString();
                if (TREATMENTSUGGESTION != "")
                {
                    if ("Ⱥ��Ⱥ��" != TREATMENTSUGGESTION)
                    {
                        entity.Columns.Remove("Ⱥ��Ⱥ��");
                    }
                    if ("רҵ���" != TREATMENTSUGGESTION)
                    {
                        entity.Columns.Remove("רҵ���");
                    }
                    if ("��Ǩ����" != TREATMENTSUGGESTION)
                    {
                        entity.Columns.Remove("��Ǩ����");
                    }
                    if ("��������" != TREATMENTSUGGESTION)
                    {
                        entity.Columns.Remove("��������");
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
                entity.Columns["mqwd"].ColumnName = "Ŀǰ�ȶ�";
                entity.Columns["mqqzbwd"].ColumnName = "Ŀǰ�����ȶ�";
                entity.Columns["mqbwd"].ColumnName = "Ŀǰ���ȶ�";
                var mqStatus = jobj["CURRENTSTABLESTATUS"].ToString();
                if (mqStatus != "")
                {
                    if ("A" != mqStatus)
                    {
                        entity.Columns.Remove("Ŀǰ�ȶ�");
                    }
                    if ("B" != mqStatus)
                    {
                        entity.Columns.Remove("Ŀǰ�����ȶ�");
                    }
                    if ("C" != mqStatus)
                    {
                        entity.Columns.Remove("Ŀǰ���ȶ�");
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
                entity.Columns["jhwd"].ColumnName = "����ȶ�";
                entity.Columns["jhqzbwd"].ColumnName = "�������ȶ�";
                entity.Columns["jhbwd"].ColumnName = "����ȶ�";
                var jhStatus = jobj["STABLETREND"].ToString();
                if (jhStatus != "")
                {
                    if ("A" != jhStatus)
                    {
                        entity.Columns.Remove("Ŀǰ�ȶ�");
                    }
                    if ("B" != jhStatus)
                    {
                        entity.Columns.Remove("Ŀǰ�����ȶ�");
                    }
                    if ("C" != jhStatus)
                    {
                        entity.Columns.Remove("Ŀǰ���ȶ�");
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
                entity.Columns["hhfw"].ColumnName = "�𻵷���";
                entity.Columns["hl"].ColumnName = "��·";
                entity.Columns["hq"].ColumnName = "����";
            }
            else
            {
                entity.Columns.Remove("hhfw");
                entity.Columns.Remove("hl");
                entity.Columns.Remove("hq");
            }
            if (jobj["wx"].ToString() == "1")
            {
                entity.Columns["wxcc"].ColumnName = "��в�Ʋ�";
                entity.Columns["wxrk"].ColumnName = "��в�˿�";
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

            //if (jobj["level"].ToString() == "��")
            //{
            //    entity.Columns.Remove("��");
            //    entity.Columns.Remove("ʡ");
            //}
            //else if (jobj["level"].ToString() == "��")
            //{
            //    entity.Columns.Remove("��");
            //    entity.Columns.Remove("ʡ");
            //}
            //else if (jobj["level"].ToString() == "ʡ")
            //{
            //    entity.Columns.Remove("��");
            //    entity.Columns.Remove("��");
            //}

            //�������ϲ����굽ͳ�������У�ͬʱ����ͳ��ͼƬ
            try
            {
                return LocationHelper.GetLocationByName(entity);
            }
            catch (Exception)
            {
            }
            return null;

        }

        //#region ����word
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
        //            //DataTable dtResult = TBL_HazardBaseicainfoBLL.GetWordDataTable(GUID);//��ȡ���ֹ�����Ϣ
        //            //foreach (DataRow item in dtResult.Rows)
        //            //{
        //            //    WordExport(item["type"].ToString(), item["guid"].ToString(), "", filename, filePath, "false", item["filename"].ToString());
        //            //}
        //        }
        //        List<FileInfo> fileList = new List<FileInfo>();
        //        GetFiles(path, fileList);
        //        string downFileName = filename + ".zip";//�����ļ�����
        //        string downFilePath = path + filename + ".zip";//�����ļ�·��
        //        string downType = "application/zip";//��������
        //        if (fileList.Count==1)//ֻ��һ���ļ�ʱ
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
        //        byte[] b = System.Text.Encoding.UTF8.GetBytes("����ʧ�ܣ�\nException��" + ex.Message);
        //        return File(b, "text/plain");
        //    }
        //    finally
        //    {
        //        //ɾ���������ļ�
        //        if (Directory.Exists(path))
        //        {
        //            Directory.Delete(path, true);
        //        }
        //    }
        //}
        //public void WordExport_(string type, string keyValue, string moduleId, string fileName, string docxSavePath, string IsdownLoad, string NewFileName = null)
        //{
        //    //string templatePath = string.Empty;
        //    ////string docxSavePath = @"C:\TempDocxPath\";//����·��
        //    //if (string.IsNullOrWhiteSpace(docxSavePath))
        //    //{
        //    //    docxSavePath = @"C:\TempDocxPath\";//����·��
        //    //}
        //    //DisasterTypeEnum typeEnum = (DisasterTypeEnum)Enum.Parse(typeof(DisasterTypeEnum), type);
        //    //switch (typeEnum)
        //    //{
        //    //    case DisasterTypeEnum.����:
        //    //        templatePath = @"\���µ����.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.��������:
        //    //        templatePath = @"\���µ����.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.����:
        //    //        templatePath = @"\���������.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.��������:
        //    //        templatePath = @"\���������.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.��ʯ��:
        //    //        templatePath = @"\��ʯ�������.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.�������:
        //    //        templatePath = @"\������������.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.��������:
        //    //        templatePath = @"\�������ݵ����.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.���ѷ�:
        //    //        templatePath = @"\���ѷ�����.dotx";
        //    //        break;
        //    //    case DisasterTypeEnum.б��:
        //    //        templatePath = @"\���ȶ�б�µ����.dotx";
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
        /// �ݹ��ȡ�����ļ�
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