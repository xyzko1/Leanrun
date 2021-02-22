using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Http;
using iTelluro.Busness.WebApi;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-07 17:19
    /// �� ����Ⱥ��Ⱥ���۲�����Ϣ��
    /// </summary>
    public class TBL_QCQF_OBSERVATIONApiController : ApiControllerBase
    {
        private TBL_QCQF_OBSERVATIONBLL tbl_qcqf_observationbll = new TBL_QCQF_OBSERVATIONBLL();

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
            var data = tbl_qcqf_observationbll.GetPageList(pagination, queryJson);
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
        public object GetListJson(string queryJson)
        {
            var data = tbl_qcqf_observationbll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_QCQF_OBSERVATIONEntity GetFormJson(string keyValue)
        {
            var data = tbl_qcqf_observationbll.GetEntity(keyValue);
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
            tbl_qcqf_observationbll.RemoveForm(param.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromBody]TBL_QCQF_OBSERVATIONEntity entity)
        {
            tbl_qcqf_observationbll.SaveForm(keyValue, entity);
            string result = "�����ɹ���";
            var  GUID = entity.GUID;
            return Success(result, new { GUID });
        }

        /// <summary>
        /// ��������۲��˹��� �������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        //public WebApiResult SaveForm(string keyValue, [FromUri]TBL_QCQF_OBSERVATIONEntity entity)����[FromUri]��ȡ��������
        public WebApiResult SaveFormGcr(string keyValue, TBL_QCQF_OBSERVATIONEntity entity)
        {
            tbl_qcqf_observationbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
