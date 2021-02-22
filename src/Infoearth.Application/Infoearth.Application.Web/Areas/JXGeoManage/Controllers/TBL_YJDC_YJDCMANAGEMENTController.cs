using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System.Net;
using System;
using System.Net.Http;
using System.Web;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using iTelluro.Busness.WebApiProxy;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-13 13:34
    /// �� ���������ֺ�Ӧ���������ݹ���
    /// </summary>
    public class TBL_YJDC_YJDCMANAGEMENTController : MvcControllerBase
    {
        private TBL_YJDC_YJDCMANAGEMENTBLL tbl_yjdc_yjdcmanagementbll = new TBL_YJDC_YJDCMANAGEMENTBLL();

        private YJDCMANAGEMENTWS yjdcWs = new YJDCMANAGEMENTWS("");

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_YJDC_YJDCMANAGEMENTIndex()
        {
            return View();
        }
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_YJDC_YJDCMANAGEMENTViewIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_YJDC_YJDCMANAGEMENTForm()
        {
            return View();
        }
        /// <summary>
        /// ���鱨��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_YJDC_YJDCInvestigationReport()
        {
            return View();
        }
        
        /// <summary>
        /// ��Ӧ�����±�ҳ��
        /// </summary>
        /// <returns></returns>
        public ActionResult TBL_YJDC_YJDCMONTHLYReport()
        {
            return View();
        }


        #endregion

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var result = yjdcWs.GetListJson(queryJson);
            return ToJsonResult(result);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        [LogContent("Ӧ���������ݹ���", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = yjdcWs.GetPageListJson(pagination, queryJson);
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
        /// ͳ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_YJDC_YJDCMANAGEMENTStatisticIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpPost]
        [LogContent("Ӧ���������ݹ���ɾ��", OpType.Query)]
        public ActionResult EMERGENCYSURVEYApi_RemoveForm(string keyValue)
        {
            var watch = CommonHelper.TimerStart();
            var data = yjdcWs.EMERGENCYSURVEYApi_RemoveForm(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        [LogContent("Ӧ���������ݹ���ɾ��", OpType.Query)]
        public ActionResult EMERGENCYSURVEYApi_GetFormJson(string keyValue)
        {
            var watch = CommonHelper.TimerStart();
            var data = yjdcWs.GetEntity(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// �������������д��롢��ݡ��·ݻ�ȡ��Ӧ��Ӧ�����鸨���±���Ϣ
        /// </summary>
        /// <param name="districtCodes"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EMERGENCYSURVEYApi_GetFZMonthReport(string city, string year, string month)
        {

            var data = yjdcWs.EMERGENCYSURVEYApi_GetFZMonthReport(city, year, month);
            return ToJsonResult(data); ;
        }


        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult EMERGENCYSURVEYApi_SaveForm(string keyValue, TBL_YJDC_EMERGENCYSURVEYEntity entity)
        {
            var data=yjdcWs.EMERGENCYSURVEYApi_SaveForm(keyValue, entity);
            //tbl_yjdc_yjdcmanagementbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        /// <summary>
        /// ��������������ö�Ӧ��Ӧ����������
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public ActionResult GetInfoStatistics(string queryJson)
        {

            var data = yjdcWs.GetInfoStatistics(queryJson);
            return ToJsonResult(data); ;
        }



        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = tbl_yjdc_yjdcmanagementbll.GetEntity(keyValue);
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
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_yjdc_yjdcmanagementbll.RemoveForm(keyValue);
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
        public ActionResult SaveForm(string keyValue, TBL_YJDC_YJDCMANAGEMENTEntity entity)
        {
            tbl_yjdc_yjdcmanagementbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
