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
    /// �� �ڣ�2018-03-17 14:51
    /// �� ���������Ϣ��
    /// </summary>
    public class TBL_AUDITINFOController : MvcControllerBase
    {
        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_AUDITINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// �ύ����б�ҳ
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_AUDITINFOSubmitIndex()
        {
            return View();
        }

        /// <summary>
        /// ����б�ҳ
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_AUDITINFOForm()
        {
            return View();
        }

        /// <summary>
        /// �����Ϣҳ
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AuditInfoForm()
        {
            return View();
        }
        #endregion
    }
}
