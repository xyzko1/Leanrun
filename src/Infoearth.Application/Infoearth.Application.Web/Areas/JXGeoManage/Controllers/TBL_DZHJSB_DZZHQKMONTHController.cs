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
    /// �� �ڣ�2019-05-10 09:58
    /// �� ����TBL_DZHJSB_DZZHQKMONTH
    /// </summary>
    public class TBL_DZHJSB_DZZHQKMONTHController : MvcControllerBase
    {
        private TBL_DZHJSB_DZZHQKMONTHBLL tbl_dzhjsb_dzzhqkmonthbll = new TBL_DZHJSB_DZZHQKMONTHBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DZHJSB_DZZHQKMONTHIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DZHJSB_DZZHQKMONTHForm()
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
        [LogContent("TBL_DZHJSB_DZZHQKMONTH", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_dzhjsb_dzzhqkmonthbll.GetList(queryJson);
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
            var data = tbl_dzhjsb_dzzhqkmonthbll.GetEntity(keyValue);
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
        [LogContent("TBL_DZHJSB_DZZHQKMONTH", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_dzhjsb_dzzhqkmonthbll.RemoveForm(keyValue);
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
        [LogContent("TBL_DZHJSB_DZZHQKMONTH", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_DZHJSB_DZZHQKMONTHEntity entity)
        {
            tbl_dzhjsb_dzzhqkmonthbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
