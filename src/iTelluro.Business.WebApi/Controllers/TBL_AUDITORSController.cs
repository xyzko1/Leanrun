using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApi;
using System.Web.Http;
using System.Collections.Generic;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-17 14:53
    /// �� ��������˱�
    /// </summary>
    public class TBL_AUDITORSApiController : ApiControllerBase
    {
        private TBL_AUDITORSBLL tbl_auditorsbll = new TBL_AUDITORSBLL();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_auditorsbll.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        public IEnumerable<TBL_AUDITORSEntity> GetListJson(string queryJson)
        {
            var data = tbl_auditorsbll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_AUDITORSEntity GetFormJson(string keyValue)
        {
            var data = tbl_auditorsbll.GetEntity(keyValue);
            return data;
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm(SingleParam param)
        {
            tbl_auditorsbll.RemoveForm(param.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_AUDITORSEntity entity)
        {
            tbl_auditorsbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }

        #endregion


        #region ��˿���

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult DisabledAudit(SingleParam param)
        {
            tbl_auditorsbll.UpdateAudit(param.KeyValue, "1");
            return Success("�����ɹ���");
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult EnabledAudit(SingleParam param)
        {
            tbl_auditorsbll.UpdateAudit(param.KeyValue, "0");
            return Success("�����ɹ���");
        }
        [HttpPost]
        public WebApiResult SaveFormNew(string STATE, string GUIDS)
        {
            tbl_auditorsbll.SaveFormNew(STATE,GUIDS);
            return Success("�����ɹ���");
        }
        [HttpPost]
        public WebApiResult deleteNew(string GUIDS)
        {
            tbl_auditorsbll.deleteNew(GUIDS);
            return Success("�����ɹ���");
        }
        #endregion

    }
}
