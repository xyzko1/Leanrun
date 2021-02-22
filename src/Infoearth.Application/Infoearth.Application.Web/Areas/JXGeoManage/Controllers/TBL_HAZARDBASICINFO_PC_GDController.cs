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
    /// �� �ڣ�2019-05-07 16:09
    /// �� �����Ų����ݱ�
    /// </summary>
    public class TBL_HAZARDBASICINFO_PC_GDController : MvcControllerBase
    {
        private TBL_HAZARDBASICINFO_PC_GDBLL tbl_hazardbasicinfo_pc_gdbll = new TBL_HAZARDBASICINFO_PC_GDBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_HAZARDBASICINFO_PC_GDIndex()
        {
            return View();
        }
        [HttpGet]
        [Login]
        public ActionResult StatisticeContext()
        {
            return View();
        }
        [HttpGet]
        [Login]
        public ActionResult TBL_HAZARDBASICINFO_PC_GDBrowser()
        {
            return View();
        }
        [HttpGet]
        [Login]
        public ActionResult TBL_HAZARDBASICINFO_PC_GDTJ()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_HAZARDBASICINFO_PC_GDForm()
        {
            return View();
        }
        #endregion
        #region ����excel
        [HttpGet]
        public void Exportexcel(string queryJson)
        {
            List<TBL_HAZARDBASICINFO_PC_GDEntity> list = tbl_hazardbasicinfo_pc_gdbll.GetList(queryJson).ToList();
            DataTable dt = DataHelper.ListToDataTable<TBL_HAZARDBASICINFO_PC_GDEntity>(list);
            DataTable data = new DataTable();
            #region ���ӱ�ͷ
            data.Columns.Add("�ֺ�������");
            data.Columns.Add("�Ų���");
            data.Columns.Add("ͳһ���");
            data.Columns.Add("��");
            data.Columns.Add("��");
            data.Columns.Add("�ֵ�");
            data.Columns.Add("�����������");
            data.Columns.Add("������λ��");
            data.Columns.Add("������״̬");
            data.Columns.Add("����");
            data.Columns.Add("γ��");
            data.Columns.Add("�ֺ����ģ");
            data.Columns.Add("�ȶ���");
            data.Columns.Add("Σ����");
            data.Columns.Add("��в��Ա");
            data.Columns.Add("Ǳ�ھ�����ʧ(��Ԫ)");
            data.Columns.Add("���������");
            data.Columns.Add("��ϵ�绰");
            data.Columns.Add("�ֻ�");
            data.Columns.Add("�����");
            data.Columns.Add("��ϵ�绰1");
            data.Columns.Add("�ֻ�1");
            data.Columns.Add("���ζԲ�");
            data.Columns.Add("��ûӦ��Ԥ��");
            data.Columns.Add("������ʩ");
            data.Columns.Add("��ע");
            #endregion
            #region ��ֵ
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow result = data.NewRow();
                result["�ֺ�������"] = dt.Rows[i]["DISASTERTYPE"].ToString();
                result["�Ų���"] = dt.Rows[i]["PCUNIFIEDCODE"].ToString();
                result["ͳһ���"] = dt.Rows[i]["UNIFIEDCODE"].ToString();
                result["��"] = dt.Rows[i]["CITY"].ToString();
                result["��"] = dt.Rows[i]["COUNTY"].ToString();
                result["�ֵ�"] = dt.Rows[i]["STREET"].ToString();
                result["�����������"] = dt.Rows[i]["XZQHCODE"].ToString();
                result["������λ��"] = dt.Rows[i]["LOCATION"].ToString();
                result["������״̬"] = dt.Rows[i]["YHSTATE"].ToString();
                result["����"] = dt.Rows[i]["LONGITUDE"].ToString();
                result["γ��"] = dt.Rows[i]["LATITUDE"].ToString();
                result["�ֺ����ģ"] = dt.Rows[i]["SCALE"].ToString();
                result["�ȶ���"] = dt.Rows[i]["CURSTABLESTATUS"].ToString();
                result["Σ����"] = dt.Rows[i]["DESTROYEDOBJECT"].ToString();
                result["��в��Ա"] = dt.Rows[i]["THREATENPEOPLE"].ToString();
                result["Ǳ�ھ�����ʧ(��Ԫ)"] = dt.Rows[i]["INDIRECTLOSS"].ToString();
                result["���������"] = dt.Rows[i]["MONITORINGPEOPLE"].ToString();
                result["��ϵ�绰"] = dt.Rows[i]["TELEPHONE"].ToString();
                result["�ֻ�"] = dt.Rows[i]["PHONE"].ToString();
                result["�����"] = dt.Rows[i]["JCPEOPLE"].ToString();
                result["��ϵ�绰1"] = dt.Rows[i]["TELEPHONE1"].ToString();
                result["�ֻ�1"] = dt.Rows[i]["PHONE1"].ToString();
                result["���ζԲ�"] = dt.Rows[i]["COUNTERMEASURES"].ToString();
                result["��ûӦ��Ԥ��"] = dt.Rows[i]["YJPLAN"].ToString();
                result["������ʩ"] = dt.Rows[i]["WORKMEASURES"].ToString();
                result["��ע"] = dt.Rows[i]["REMARKS"].ToString();
                data.Rows.Add(result);
            } 
            #endregion          
            ExcelHelper.ExcelDownloadOnlyDT(data, "�Ų�����", string.Format("�Ų����ݵ���{0}.xls",DateTime.Now.ToLongDateString().ToString()));
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
        [LogContent("�Ų����ݱ�", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_hazardbasicinfo_pc_gdbll.GetPageList(pagination, queryJson);
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
        [LogContent("�Ų����ݱ�", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_hazardbasicinfo_pc_gdbll.GetList(queryJson);
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
            var data = tbl_hazardbasicinfo_pc_gdbll.GetEntity(keyValue);
            return ToJsonResult(data);
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
        [LogContent("�Ų����ݱ�", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_hazardbasicinfo_pc_gdbll.RemoveForm(keyValue);
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
        [LogContent("�Ų����ݱ�", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_HAZARDBASICINFO_PC_GDEntity entity)
        {
            tbl_hazardbasicinfo_pc_gdbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion

       
    }
}
