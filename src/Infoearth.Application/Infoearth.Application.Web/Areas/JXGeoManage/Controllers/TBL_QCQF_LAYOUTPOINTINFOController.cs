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
    /// �� �ڣ�2018-06-07 17:24
    /// �� ����Ⱥ��Ⱥ��������Ϣ��
    /// </summary>
    public class TBL_QCQF_LAYOUTPOINTINFOController : MvcControllerBase
    {
        private TBL_QCQF_LAYOUTPOINTINFOBLL tbl_qcqf_layoutpointinfobll = new TBL_QCQF_LAYOUTPOINTINFOBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_LAYOUTPOINTINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_LAYOUTPOINTINFOForm()
        {
            return View();
        }
        /// <summary>
        /// �����ϱ�
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_LAYOUTPOINTINFOSJSB()
        {
            return View();
        }
        /// <summary>
        /// ѡ���ֺ���
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult XZZHD()
        {
            return View();
        }
        /// <summary>
        /// �����۲���
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GLGCR()
        {
            return View();
        }
        /// <summary>
        /// ���Ѳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_AROUNDRECORDForm()
        {
            return View();
        }
        /// <summary>
        /// ���������ϱ�
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_POINTRECORDForm()
        {
            return View();
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult JCDXQ()
        {
            return View();
        }
        #endregion
    }
}
