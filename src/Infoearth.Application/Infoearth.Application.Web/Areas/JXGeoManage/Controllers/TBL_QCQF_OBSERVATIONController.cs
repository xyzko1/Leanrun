using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-07 17:19
    /// �� ����Ⱥ��Ⱥ���۲�����Ϣ��
    /// </summary>
    public class TBL_QCQF_OBSERVATIONController : MvcControllerBase
    {
        private TBL_QCQF_OBSERVATIONBLL tbl_qcqf_observationbll = new TBL_QCQF_OBSERVATIONBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_OBSERVATIONIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_OBSERVATIONForm()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TBL_QCQF_OBSERVATIONsearch()
        {
            return View();
        }
        
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_ResponsForm()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult TBL_QCQF_OBForm()
        {
            return View();
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GLJCD()
        {
            return View();
        }
        #endregion

    }
}
