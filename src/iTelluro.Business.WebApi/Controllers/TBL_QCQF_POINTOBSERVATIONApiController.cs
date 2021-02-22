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
    /// �� �ڣ�2018-06-11 15:39
    /// �� ����Ⱥ��Ⱥ������͹۲��˹�����
    /// </summary>
    public class TBL_QCQF_POINTOBSERVATIONApiController : ApiControllerBase
    {
        private TBL_QCQF_POINTOBSERVATIONBLL tbl_qcqf_pointobservationbll = new TBL_QCQF_POINTOBSERVATIONBLL();

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
            var data = tbl_qcqf_pointobservationbll.GetPageList(pagination, queryJson);
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
            var data = tbl_qcqf_pointobservationbll.GetList(queryJson);
            return data;
        }
        [HttpGet]
        public object GetListByID(string ID)
        {
            var data = tbl_qcqf_pointobservationbll.GetListByID(ID);
            return data;
        }
        [HttpGet]
        public object GetListByUNIFIEDCODE(string UNIFIEDCODE)
        {
            var data = tbl_qcqf_pointobservationbll.GetListByUNIFIEDCODE(UNIFIEDCODE);
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_QCQF_POINTOBSERVATIONEntity GetFormJson(string keyValue)
        {
            var data = tbl_qcqf_pointobservationbll.GetEntity(keyValue);
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
            tbl_qcqf_pointobservationbll.RemoveForm(param.KeyValue);
            return Success("ɾ���ɹ���");
        }
        public WebApiResult RemoveFormByID(SingleParam param)
        {
            tbl_qcqf_pointobservationbll.RemoveFormByID(param.KeyValue);
            return Success("ɾ���ɹ���");
        }
        public WebApiResult RemoveFormByUNIFIEDCODE(SingleParam param)
        {
            tbl_qcqf_pointobservationbll.RemoveFormByUNIFIEDCODE(param.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromUri]TBL_QCQF_POINTOBSERVATIONEntity entity)
        {
            tbl_qcqf_pointobservationbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
       
    }
}
