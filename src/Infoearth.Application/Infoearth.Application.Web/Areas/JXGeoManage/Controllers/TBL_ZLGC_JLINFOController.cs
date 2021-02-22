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
    /// �� �ڣ�2018-04-16 23:29
    /// �� ����������-����
    /// </summary>
    public class TBL_ZLGC_JLINFOController : MvcControllerBase
    {
        private TBL_ZLGC_JLINFOBLL tbl_zlgc_jlinfobll = new TBL_ZLGC_JLINFOBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_ZLGC_JLINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_JLINFOForm()
        {
            return View();
        }
         /// <summary>
        /// ���̼����������嵥������Ϣҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_ZLGC_JLZZQDList()
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
        [LogContent("������-����", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_zlgc_jlinfobll.GetList(queryJson);
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
            var data = tbl_zlgc_jlinfobll.GetEntity(keyValue);
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
        [LogContent("������-����", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_zlgc_jlinfobll.RemoveForm(keyValue);
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
        [LogContent("������-����", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_ZLGC_JLINFOEntity entity)
        {
            tbl_zlgc_jlinfobll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
