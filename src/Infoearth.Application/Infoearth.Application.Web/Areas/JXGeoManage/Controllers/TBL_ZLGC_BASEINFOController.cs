using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System;
using System.Data;
using Infoearth.Util.Offices;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:27
    /// �� ������������Ϣ��
    /// </summary>
    public class TBL_ZLGC_BASEINFOController : MvcControllerBase
    {
        private TBL_ZLGC_BASEINFOBLL tbl_zlgc_baseinfobll = new TBL_ZLGC_BASEINFOBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_ZLGC_BASEINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_BASEINFOForm()
        {
            return View();
        }
        /// <summary>
        /// ���������
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ADDBASEINFO()
        {
            return View();
        }
        /// <summary>
        /// ��������̲�ѯ���ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_BASEINFOIndexQueryBrowse()
        {
            return View();
        }
        /// <summary>
        /// ���������ͳ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_BASEINFOIndexCountAnalyse()
        {
            return View();
        }
        /// <summary>
        /// ��������̻������ݹ���
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_BASICAMANAGE()
        {
            return View();
        }
        /// <summary>
        /// �鿴������ͳ����Ϣ���
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_TJResultForm()
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
        [LogContent("��������Ϣ��", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_zlgc_baseinfobll.GetPageList(pagination, queryJson);
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
        [LogContent("��������Ϣ��", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_zlgc_baseinfobll.GetList(queryJson);
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
            var data = tbl_zlgc_baseinfobll.GetEntity(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// �����̲�ѯ�����������
        /// </summary>
        /// <param name="queryJson"></param>
        public void ExcelZLGCDownloadExt(string queryJson)
        {
            var data = tbl_zlgc_baseinfobll.GetListS(queryJson);
            DataTable result = new DataTable();
            result.Columns.Add("��������");
            result.Columns.Add("�ֺ�����");
            result.Columns.Add("�ֺ�������");
            result.Columns.Add("�ֺ�������");
            result.Columns.Add("����");
            result.Columns.Add("γ��");  
            result.Columns.Add("����ʱ��");
            result.Columns.Add("�����ʽ�(��Ԫ)");
            result.Columns.Add("����λ");
            result.Columns.Add("��׼����");
            result.Columns.Add("��׼�ĺ�");
            result.Columns.Add("���赥λ");
            result.Columns.Add("���̵���λ��");
            result.Columns.Add("ʡ");
            result.Columns.Add("��");
            result.Columns.Add("��");
            foreach (var item in data)
            {
                DataRow result_dr = result.NewRow();
                result_dr["��������"] = item.ZLGCNAME;
                result_dr["�ֺ�����"] = item.UNIFIEDCODE;
                result_dr["�ֺ�������"] = item.DISASTERNAME;
                result_dr["�ֺ�������"] = item.DISASTERTYPE;
                result_dr["����"] = item.LONGITUDE;
                result_dr["γ��"] = item.LATITUDE;
                result_dr["����ʱ��"] = item.XMJLXSJ;
                result_dr["�����ʽ�(��Ԫ)"] = item.XMPFZJ;
                result_dr["����λ"] = item.XMFZDW;
                result_dr["��׼����"] = item.XMPZBM;
                result_dr["��׼�ĺ�"] = item.XMPZWH;
                result_dr["���赥λ"] = item.XMJSDW;
                result_dr["���̵���λ��"] = item.LOCATION;
                result_dr["ʡ"] = item.PROVINCENAME;
                result_dr["��"] = item.CITYNAME;
                result_dr["��"] = item.COUNTYNAME;
                result.Rows.Add(result_dr);
            }
            ExcelHelper.ExcelDownloadOnlyDT(result, "���������ݵ���", "�����������ѯ.xls");
        }

        /// <summary>
        /// ����������ͳ�Ƶ�������
        /// </summary>
        /// <param name="queryJson"></param>
        public void ExcelZLGCCountDownloadExt(string queryJson)
        {
            var obj = queryJson.ToJObject();
            string ProvinceName = obj.GetValue("PROVINCENAME").ToString();
            string CityName = obj.GetValue("CITYNAME").ToString();
            string CountyName = obj.GetValue("COUNTRYNAME").ToString();
            string ZLGCYEAR = obj.GetValue("Static_Year").ToString();
            string ZLGCUNIT = obj.GetValue("Static_Unit").ToString();
            DataTable result = tbl_zlgc_baseinfobll.ZLGCCountStatics(ProvinceName, CityName, CountyName, ZLGCYEAR, ZLGCUNIT, "");
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
            if (result.Columns.Contains("disastercount"))
            {
                result.Columns["disastercount"].SetOrdinal(col_num);
                result.Columns["disastercount"].ColumnName = "�ֺ������";
                col_num++;
            }
            if (result.Columns.Contains("zlgccount"))
            {
                result.Columns["zlgccount"].SetOrdinal(col_num);
                result.Columns["zlgccount"].ColumnName = "�����̸���";
                col_num++;
            }
            ExcelHelper.ExcelDownloadOnlyDT(result, "������ͳ��", "������ͳ�Ƶ���.xls");
        }
        /// <summary>
        /// ������ͳ�Ƶ�������(�£�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        public ActionResult ExcelZLGCCountDownloadExtNew(string queryJson)
        {
            var obj = queryJson.ToJObject();
            //string ProvinceName = obj.GetValue("PROVINCENAME").ToString();
            //string CityName = obj.GetValue("CITYNAME").ToString();
            //string CountyName = obj.GetValue("COUNTRYNAME").ToString();
            string ZLGCYEAR = obj.GetValue("yearZLGC").ToString();
            string ZLGCUNIT = obj.GetValue("unitZLGC").ToString();
            string xzqhcode = obj.GetValue("xzqhcode").ToString();
            string codeType = obj.GetValue("codeType").ToString();
            string ISDAOCHU = obj.GetValue("ISDAOCHU").ToString();
            DataTable result = tbl_zlgc_baseinfobll.GetDataZLGCStatics(xzqhcode, codeType, ZLGCYEAR, ZLGCUNIT);
            if (result.Rows.Count > 1)
            {
                if (ZLGCUNIT == "ʡ" || ZLGCUNIT == "��")
                {
                    result.Rows.RemoveAt(result.Rows.Count - 1);
                }
                else
                {
                    result.Rows.RemoveAt(0);
                }
                if (ISDAOCHU == "true")
                {
                    ExcelHelper.ExcelDownloadOnlyDT(result, "������ͳ��", "������ͳ��.xls");
                }
                return ToJsonResult(true);
            }
            else
            {
                return ToJsonResult(false); ;
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
        [LogContent("��������Ϣ��", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_zlgc_baseinfobll.RemoveForm(keyValue);
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
        [LogContent("��������Ϣ��", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_ZLGC_BASEINFOEntity entity)
        {
            tbl_zlgc_baseinfobll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }

        /// <summary>
        /// �µı�������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("��������Ϣ��", OpType.Update)]
        public ActionResult SaveForm_New(string keyValue, TBL_ZLGC_BASEINFOEntity entity)
        {
            string result = tbl_zlgc_baseinfobll.SaveForm_New(keyValue, entity);
            return Success_New("�����ɹ�," + result + "");
        }
        /// <summary>
        /// �鷽����Ӧ�޸ı��淽�����ز�������GUID
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual ActionResult Success_New(string message)
        {
            string message1 = message.Split(',')[0].ToString();
            string message2 = message.Split(',')[1].ToString();
            return Content(new AjaxResult { type = ResultType.success, message = message1, resultdata = message2 }.ToJson());
        }


        #endregion
    }
}
