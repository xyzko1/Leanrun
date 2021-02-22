using Infoearth.Application.Entity.DemoManage;
using Infoearth.Application.Busines.DemoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.DemoManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 
    /// �� ������������Ա
    /// �� �ڣ�2017-07-21 16:01
    /// �� �������������
    /// </summary>
    public class Base_AreaController : MvcControllerBase
    {
        private Base_AreaBLL base_areabll = new Base_AreaBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_AreaIndex()
        {
            return View();
        }

        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_AreaIndexEx()
        {
            return View();
        }
        /// <summary>
        /// ����ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_AreaForm()
        {
            return View();
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
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = base_areabll.GetPageList(pagination, queryJson);
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
        public ActionResult GetListJson(string queryJson)
        {
            var data = base_areabll.GetList(queryJson);
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
            var data = base_areabll.GetEntity(keyValue);
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
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            base_areabll.RemoveForm(keyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ����������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, Base_AreaEntity entity)
        {
            base_areabll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}