using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using System.Web.Http;
using System.Collections.Generic;
using Infoearth.Util.WebControl;
using Infoearth.Util;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-13 13:14
    /// �� �������µ����
    /// </summary>
    public class TBL_LANDSLIP_HIDDEN_HISTORYApiController : ApiControllerBase
    {
        private TBL_LANDSLIP_HIDDEN_HISTORYBLL TBL_LANDSLIP_HIDDEN_HISTORYbll = new TBL_LANDSLIP_HIDDEN_HISTORYBLL();

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = TBL_LANDSLIP_HIDDEN_HISTORYbll.GetPageList(pagination, queryJson);
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

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        public IEnumerable<TBL_LANDSLIP_HIDDEN_HISTORYEntity> GetListJson(string queryJson)
        {
            var data = TBL_LANDSLIP_HIDDEN_HISTORYbll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetFormJson(string keyValue)
        {
            var data = TBL_LANDSLIP_HIDDEN_HISTORYbll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">UNIFIEDCODE</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetEntityByUNIFIEDCODE(string keyValue)
        {
            var data = TBL_LANDSLIP_HIDDEN_HISTORYbll.GetEntityByUNIFIEDCODE(keyValue);
            return data;
        }
        /// <summary>
        /// ��ȡ��ǰʵ��ǰ������ͨ����ʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpGet]
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetAuditFormJson(string keyValue)
        {
            return TBL_LANDSLIP_HIDDEN_HISTORYbll.GetAuditEntity(keyValue);
        }

        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm(SingleParam keyValue)
        {
            TBL_LANDSLIP_HIDDEN_HISTORYbll.DeleteEntity(keyValue.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_LANDSLIP_HIDDEN_HISTORYEntity entity)
        {
            TBL_LANDSLIP_HIDDEN_HISTORYbll.SaveEntity(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
