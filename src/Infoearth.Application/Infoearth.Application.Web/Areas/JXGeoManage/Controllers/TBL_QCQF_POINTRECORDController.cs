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
    /// �� �ڣ�2018-06-13 16:23
    /// �� ����Ⱥ��Ⱥ�������ˮ���ݱ�
    /// </summary>
    public class TBL_QCQF_POINTRECORDController : MvcControllerBase
    {
        private TBL_QCQF_POINTRECORDBLL tbl_qcqf_pointrecordbll = new TBL_QCQF_POINTRECORDBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_QCQF_POINTRECORDIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_POINTRECORDForm()
        {
            return View();
        }
        #endregion
    }
}
