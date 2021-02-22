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
    /// �� �ڣ�2018-06-11 15:39
    /// �� ����Ⱥ��Ⱥ������͹۲��˹�����
    /// </summary>
    public class TBL_QCQF_POINTOBSERVATIONController : MvcControllerBase
    {
        private TBL_QCQF_POINTOBSERVATIONBLL tbl_qcqf_pointobservationbll = new TBL_QCQF_POINTOBSERVATIONBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_QCQF_POINTOBSERVATIONIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_POINTOBSERVATIONForm()
        {
            return View();
        }
        #endregion
        [HttpPost]
        public ActionResult SaveFormByID(string ID,string UNIFIEDCODE)
        {
            tbl_qcqf_pointobservationbll.SaveFormByID(ID, UNIFIEDCODE);
            return Success("�����ɹ���");
        }
        [HttpGet]
        public ActionResult GetDataJcd(string id)
        {
            var data = tbl_qcqf_pointobservationbll.GetDataJcd(id);
            data.Columns[0].ColumnName = "GUID";
            data.Columns[1].ColumnName = "MONITORPOINTCODE";
            data.Columns[2].ColumnName = "MONITORPOINTPOSITION";
            data.Columns[3].ColumnName = "UNIFIEDCODE";
            data.Columns[4].ColumnName = "DISASTERNAME";
            data.Columns[5].ColumnName = "LOCATION";
            return ToJsonResult(data);
        }
        [HttpGet]
        public ActionResult GetDataJcr(string id)
        {
            var data = tbl_qcqf_pointobservationbll.GetDataJcr(id);
            data.Columns[0].ColumnName = "OBSERVATIONPEOPLE";
            data.Columns[1].ColumnName = "OBSERVATIONPHONE";
            data.Columns[2].ColumnName = "GUID";
            return ToJsonResult(data);
        }
        [HttpGet]
        public ActionResult  delegl(string id, string guid)
        {
            tbl_qcqf_pointobservationbll.delegl(id,guid);
            return Success("ɾ���ɹ���");
        }
        [HttpGet]
        public ActionResult deleglnew(string id)
        {
            tbl_qcqf_pointobservationbll.deleglnew(id);
            return Success("ɾ���ɹ���");
        }
        [HttpGet]
        public ActionResult deleglnewByqCqf(string id)
        {
            tbl_qcqf_pointobservationbll.deleglnewByqCqf(id);
            return Success("ɾ���ɹ���");
        }
    }
}
