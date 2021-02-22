using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System.Data;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:15
    /// �� ����Ⱥ��Ⱥ������������ϵ
    /// </summary>
    public class TBL_QCQF_ADMINISTRATIVEController : MvcControllerBase
    {
        private TBL_QCQF_ADMINISTRATIVEBLL tbl_qcqf_administrativebll = new TBL_QCQF_ADMINISTRATIVEBLL();

        #region ��ͼ����
        /// <summary>
        /// Ⱥ��Ⱥ��ͳ�Ʒ���
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_QCQF_TJFX()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_QCQF_ADMINISTRATIVE_XZZRTXFrom()
        {
            return View();
        }
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_QCQF_ADMINISTRATIVE_XZZRTX()
        {
            return View();
        }
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_YJBZ_POSITIONSelect()
        {
            return View();
        }
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_QCQF_ADMINISTRATIVEIndex()
        {
            return View();
        }
        [HttpGet]
        [Login]
        public ActionResult TBL_QCQF_ADMINISTRATIVEView()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_ADMINISTRATIVEForm()
        {
            return View();
        }
        /// <summary>
        /// ���ŷ�����ϵ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_LXRFrom()
        {
            return View();
        }
        /// <summary>
        /// ��ʱ��ϵ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_INSERT_LSLXRFrom()
        {
            return View();
        }
        /// <summary>
        /// ��������Ϣҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_ZRRINFOFrom()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TBL_QCQF_ADMINISTRATIVESearch()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult TBL_QCQF_ADMINISTRATIVEViewForm()
        {
            return View();
        }
        /// <summary>
        /// Ⱥ��Ⱥ����ѯ���
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_ADMINISTRATIVEQueryBrowse()
        {
            return View();
        }
        /// <summary>
        /// Ⱥ��Ⱥ����ѯ���
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_ResponsIndex()
        {
            return View();
        }
        /// <summary>
        /// Ⱥ��Ⱥ��ͳ�Ʒ���
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_ADMINISTRATIVETJFX()
        {
            return View();
        }
        /// <summary>
        /// ����DISTRICTCODE��ȡʵ��
        /// </summary>
        /// <param name="DISTRICTCODE">����ֵ</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDISTRICTCODEEntity(string DISTRICTCODE)
        {
            var data = tbl_qcqf_administrativebll.GetDISTRICTCODEEntity(DISTRICTCODE);
            return ToJsonResult(data);
        }
        [HttpGet]
        public ActionResult GetTBL_QCQF_ADMINISTRATIVEEntity(string DISTRICTCODE)
        {
            var data = tbl_qcqf_administrativebll.GetTBL_QCQF_ADMINISTRATIVEEntity(DISTRICTCODE);
            return ToJsonResult(data);
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
        [LogContent("Ⱥ��Ⱥ������������ϵ", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_qcqf_administrativebll.GetPageList(pagination, queryJson);
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
        [LogContent("Ⱥ��Ⱥ������������ϵ", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_qcqf_administrativebll.GetList(queryJson);
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
            var data = tbl_qcqf_administrativebll.GetEntity(keyValue);
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
        [LogContent("Ⱥ��Ⱥ������������ϵ", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_qcqf_administrativebll.RemoveForm(keyValue);
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
        [LogContent("Ⱥ��Ⱥ������������ϵ", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_QCQF_ADMINISTRATIVEEntity entity)
        {
            tbl_qcqf_administrativebll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        /// <summary>
        /// ����DISTRICTCODE��������������޸ģ�
        /// </summary>
        /// <param name="DISTRICTCODE"></param>
        /// <param name="entity"></param>
        [HttpPost]
        [AjaxOnly]
        [LogContent("Ⱥ��Ⱥ������������ϵ", OpType.Update)]
        public ActionResult UpdateForm(string DISTRICTCODE, TBL_QCQF_ADMINISTRATIVEEntity entity)
        {
            tbl_qcqf_administrativebll.UpdateForm(DISTRICTCODE, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
