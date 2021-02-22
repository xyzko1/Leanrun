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
    /// �� �ڣ�2019-05-15 15:38
    /// �� ����Ѳ�������������
    /// </summary>
    public class TBL_DZHJSB_DZZHQKMONTH_GDController : MvcControllerBase
    {
        private TBL_DZHJSB_DZZHQKMONTH_GDBLL tbl_dzhjsb_dzzhqkmonth_gdbll = new TBL_DZHJSB_DZZHQKMONTH_GDBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DZHJSB_DZZHQKMONTH_GDIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DZHJSB_DZZHQKMONTH_GDForm()
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
        [LogContent("Ѳ�������������", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_dzhjsb_dzzhqkmonth_gdbll.GetList(queryJson);
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
            var data = tbl_dzhjsb_dzzhqkmonth_gdbll.GetEntity(keyValue);
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
        [LogContent("Ѳ�������������", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_dzhjsb_dzzhqkmonth_gdbll.RemoveForm(keyValue);
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
        [LogContent("Ѳ�������������", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_DZHJSB_DZZHQKMONTH_GDEntity entity)
        {
            tbl_dzhjsb_dzzhqkmonth_gdbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
