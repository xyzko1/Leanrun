using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.Busines.SystemManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.SystemManage.Controllers
{
    /// <summary>
    /// �� �� LearunADMS V6.1.1.7
    /// Copyright (c) 2013-2016 
    /// �� ������������Ա
    /// �� ����LR0101
    /// �� �ڣ�2016-09-07 09:39
    /// �� ����Base_DataSource
    /// </summary>
    public class DataSourceController : MvcControllerBase
    {
        private DataSourceBLL datasourcebll = new DataSourceBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// Ԥ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PreviewForm()
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
        public ActionResult GetListJson(string queryJson)
        {
            var data = datasourcebll.GetList(queryJson);
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
            var data = datasourcebll.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        /// <summary>
        /// Դ���ݹ����б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = datasourcebll.GetPageList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.ToJson());
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
            datasourcebll.RemoveForm(keyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, DataSourceEntity entity)
        {
            datasourcebll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion

        #region �ӿ����ݴ���
        /// <summary>
        /// ��ȡ�ӿ�����
        /// </summary>
        /// <param name="strEntity"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult TestData(string strEntity, string queryJson)
        {
            DataSourceEntity entyity = strEntity.ToObject<DataSourceEntity>();
            var data = datasourcebll.GetData(entyity, queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// ��ȡ���ݱ������
        /// </summary>
        /// <param name="dbLinkId"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTableData(string dbLinkId, string tableName)
        {
            var data = datasourcebll.GetTableData(dbLinkId, tableName);
            return ToJsonResult(data);
        }

        #endregion
    }
}
