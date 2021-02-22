using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using Infoearth.Util.Offices;
using System;
using System.Data;
using System.Collections.Generic;
using iTelluro.Busness.WebApiProxy;
using Infoearth.Application.Entity;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:25
    /// �� ������Ǩ������Ϣ��
    /// </summary>
    public class TBL_BQBRController : MvcControllerBase
    {
        private TBL_BQBRBLL tbl_bqbrbll = new TBL_BQBRBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_BQBRIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_BQBRForm()
        {
            return View();
        }
          /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_BQBRResultForm()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_BQBRHZForm()
        {
            return View();
        }
           /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_LSXQ()
        {
            return View();
        }
        /// <summary>
        /// ��Ǩ���ò�ѯ���
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_BQBRIndexQueryBrowse()
        {
            return View();
        }
        /// <summary>
        /// ��Ǩ����ͳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_BQBRIndexCountAnalyse()
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
        [LogContent("��Ǩ������Ϣ��", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_bqbrbll.GetPageList(pagination, queryJson);
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
        [LogContent("��Ǩ������Ϣ��", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_bqbrbll.GetList(queryJson);
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
            var data = tbl_bqbrbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }


        /// <summary>
        /// ����
        /// </summary>
        /// <param name="queryJson"></param>
         [HttpGet]
        public void GetBQBRStaticsExcelDown(string queryJson)
        { 
            var obj = queryJson.ToJObject();
            string ProvinceName = obj.GetValue("PROVINCENAME").ToString();
            string CityName = obj.GetValue("CITYNAME").ToString();
            string CountyName = obj.GetValue("COUNTRYNAME").ToString();
            string BQBRYEAR = obj.GetValue("Static_Year").ToString();
            string BQBRUNIT = obj.GetValue("Static_Unit").ToString();
            string EXLType = "����";
            DataTable result = tbl_bqbrbll.BQBRCountStatics(ProvinceName, CityName, CountyName, BQBRYEAR, BQBRUNIT, EXLType);
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
            if (result.Columns.Contains("countryname"))
            {
                result.Columns["countryname"].SetOrdinal(col_num);
                result.Columns["countryname"].ColumnName = "��";
                col_num++;
            }
            if (result.Columns.Contains("discount"))
            {
                result.Columns["discount"].SetOrdinal(col_num);
                result.Columns["discount"].ColumnName = "�ֺ�����";
                col_num++;
            }
            if (result.Columns.Contains("bqbrcount"))
            {
                result.Columns["bqbrcount"].SetOrdinal(col_num);
                result.Columns["bqbrcount"].ColumnName = "��Ǩ������";
                col_num++;
            }
            if (result.Columns.Contains("bqbryear"))
            {
                result.Columns["bqbryear"].SetOrdinal(col_num);
                result.Columns["bqbryear"].ColumnName = "��Ǩ�������";
                col_num++;
            } 

            ExcelHelper.ExcelDownloadOnlyDT(result, "��Ǩ��������ͳ�Ƶ���", "��Ǩ����ͳ��.xls");
        }
         /// <summary>
         /// ����
         /// </summary>
         /// <param name="queryJson"></param>
         [HttpGet]
         public void GetBQBRStaticsExcelDownNEW(string queryJson)
         {
             var obj = queryJson.ToJObject();
             string codeValue = obj.GetValue("codeValue").ToString();
             string codeType = obj.GetValue("codeType").ToString();
             string xmmc = obj.GetValue("xmmc").ToString();
             string static_Unit = obj.GetValue("static_Unit").ToString();
             string annual = obj.GetValue("annual").ToString();
             DataTable result = tbl_bqbrbll.GetDataBqbrTj(codeValue, codeType, xmmc, annual, static_Unit);
             if (static_Unit == "ʡ")
             {
                 result.Rows.RemoveAt(result.Rows.Count - 1);
             }
             else
             {
                 result.Rows.RemoveAt(0);
             }
             ExcelHelper.ExcelDownloadOnlyDT(result, "��Ǩ��������ͳ�Ƶ���", "��Ǩ����ͳ��.xls");
             //if (result.Rows.Count > 1)
             //{
             //    int aa= result.Rows.Count - 1;
             //    result.Rows[aa]["ʡ"] = "�ϼ�";
             //}
             
         }
        /// <summary>
        /// ��Ӧ��Ǩ���ò�ѯ������ݵ���
        /// </summary>
        /// <param name="queryJson"></param>
        [HttpGet]
         public void ExcelDownloadExt(string queryJson)
        {
            DataTable data = tbl_bqbrbll.GetDataTableList(queryJson);
            ExcelHelper.ExcelDownloadOnlyDT(data, "��Ǩ�������ݵ���", "��Ǩ���������ѯ.xls");
        }

          /// <summary>
          /// ��Ǩ����ͳ�Ʋ�ѯ
          /// </summary>
          /// <param name="codeValue">�����������</param>
          /// <param name="codeType">������������</param>
          /// <param name="xmmc">��Ŀ����</param>
          /// <param name="annual">��������</param>
          /// <param name="static_Unit">ͳ�Ƶ�λ</param>
          /// <returns></returns>
        [HttpGet]
        public ActionResult GetDataBqbrTj(string codeValue, string codeType, string xmmc, string annual, string static_Unit)
        {
            var data = tbl_bqbrbll.GetDataBqbrTj(codeValue, codeType, xmmc, annual, static_Unit);
            if (data.Rows.Count > 1)
            {
                if (static_Unit == "ʡ")
                {
                    data.Rows.RemoveAt(data.Rows.Count - 1);
                }
                else
                {
                    data.Rows.RemoveAt(0);
                }
                //int a = data.Rows.Count - 1;
                //data.Rows[a]["ʡ"] = "�ϼ�";
            }
            switch (static_Unit)
            {
          case "��":
                for (int j = 1; j < data.Rows.Count; j++)
                {
                    object obj = data.Rows[j][1];
                    if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                    {
                        data.Rows[j][0] = "";
                    }

                }
                break;
          case "��":
                for (int j = 1; j < data.Rows.Count; j++)
                {
                    object obj = data.Rows[j][2]; object obj1 = data.Rows[j][1];
                    if (obj1 != null && !string.IsNullOrEmpty(obj1.ToString()))
                    {
                        data.Rows[j][0] = "";
                    }
                    if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                    {
                        data.Rows[j][1] = "";
                        data.Rows[j][0] = "";
                    }
                }
                break;
              }
            return ToJsonResult(data);
           }


        /// <summary>
        /// ��Ǩ����ͳ��
        /// </summary>
        /// <param name="queryJson">
        /// AreaCode ������������
        /// </param>
        /// <returns></returns>
        [HttpGet]
        //public object GetBQBRStatistics(string codeValue, string codeType, string xmmc, string annual, string static_Unit)
        //{
        //    List<string> tempList = new List<string>();
        //    SSOWebApiWS ws = new SSOWebApiWS("");
        //    var queryParam = queryJson.ToJObject();
        //    var result = tbl_bqbrbll.GetDataBqbrTj(codeValue, codeType, xmmc, annual, static_Unit);

        //    int i = 0, j = 0, k = 0, l = 0;
        //    List<TreeBQBRNode> nodes = new List<TreeBQBRNode>();
        //    foreach (var dr in result)
        //    {
        //        //ʡ
        //        TreeBQBRNode dr1 = new TreeBQBRNode()
        //        {
        //            UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
        //            LONGITUDE = dr.LONGITUDE,
        //            LATITUDE = dr.LATITUDE,
        //            level = "0",
        //            id = dr.DISTRICTCODE.ToString().Substring(0, 2) + "0000",
        //            isLeaf = false,
        //            parent = "0",
        //            expanded = true,
        //            data = dr.PROVINCENAME,
        //        };
        //        if (!tempList.Contains(dr.DISTRICTCODE.ToString().Substring(0, 2) + "00"))
        //        {
        //            i++;
        //            dr1.count = i.ToString();
        //            nodes.Add(dr1);
        //            tempList.Add(dr.DISTRICTCODE.ToString().Substring(0, 2) + "00");
        //        }
        //        else
        //        {
        //            var node = nodes.Where(s => s.id.ToString() == dr.DISTRICTCODE.ToString().Substring(0, 2) + "00").ToList();
        //        }
        //        //��
        //        TreeBQBRNode dr2 = new TreeBQBRNode()
        //        {
        //            UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
        //            LONGITUDE = dr.LONGITUDE,
        //            LATITUDE = dr.LATITUDE,
        //            level = "1",
        //            id = dr.DISTRICTCODE.ToString().Substring(0, 4) + "00",
        //            isLeaf = false,
        //            expanded = true,
        //            parent = dr.DISTRICTCODE.ToString().Substring(0, 2) + "0000",
        //            data = dr.CITYNAME,
        //            count = j.ToString()
        //        };
        //        if (!tempList.Contains(dr.DISTRICTCODE.ToString().Substring(0, 4) + "00"))
        //        {

        //            nodes.Add(dr2);
        //            tempList.Add(dr.DISTRICTCODE.ToString().Substring(0, 4) + "00");
        //        }
        //        //��
        //        TreeBQBRNode dr3 = new TreeBQBRNode()
        //        {
        //            UsreInfo = ws.GetUserFetchByID(dr.CONTACTPEOPLEID),
        //            LONGITUDE = dr.LONGITUDE,
        //            LATITUDE = dr.LATITUDE,
        //            level = "2",
        //            id = dr.DISTRICTCODE.ToString().Substring(0, 6),
        //            isLeaf = false,
        //            expanded = true,
        //            parent = dr.DISTRICTCODE.ToString().Substring(0, 4) + "00",
        //            data = dr.COUNTYNAME,
        //            count = k.ToString()
        //        };
        //        if (!tempList.Contains(dr.DISTRICTCODE.ToString().Substring(0, 6)))
        //        {
        //            nodes.Add(dr3);
        //            tempList.Add(dr.DISTRICTCODE.ToString().Substring(0, 6));
        //        }
               
        //    }
         
        //    nodes.Sort((a, b) => a.id.CompareTo(b.id));
        //    return ToJsonResult(nodes);
        //}
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("��Ǩ������Ϣ��", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_bqbrbll.RemoveForm(keyValue);
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
        [LogContent("��Ǩ������Ϣ��", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_BQBREntity entity)
        {
            tbl_bqbrbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
        public class TreeBQBRNode
        {
            public string id { get; set; }
            public string level { get; set; }
            public string parent { get; set; }
            public bool expanded { get; set; }
            public bool isLeaf { get; set; }
            public object data { get; set; }
            public string count { get; set; }
            public decimal? LATITUDE { get; set; }
            public decimal? LONGITUDE { get; set; }
            public object UsreInfo { get; set; }
        }
    }
}
