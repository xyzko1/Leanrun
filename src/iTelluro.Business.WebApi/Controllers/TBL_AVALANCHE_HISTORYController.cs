using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using System.Web.Http;
using System.Collections.Generic;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 11:17
    /// �� ���������������ʷ��
    /// </summary>
    public class TBL_AVALANCHE_HISTORYApiController : ApiControllerBase
    {
        private TBL_AVALANCHE_HISTORYBLL tbl_avalanche_historybll = new TBL_AVALANCHE_HISTORYBLL();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        public IEnumerable<TBL_AVALANCHE_HISTORYEntity> GetListJson(string queryJson)
        {
            var data = tbl_avalanche_historybll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_AVALANCHE_HISTORYEntity GetFormJson(string keyValue)
        {
            var data = tbl_avalanche_historybll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">UNIFIEDCODE</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_AVALANCHE_HISTORYEntity GetEntityByUNIFIEDCODE(string keyValue)
        {
            var data = tbl_avalanche_historybll.GetEntityByUNIFIEDCODE(keyValue);
            return data;
        }
        /// <summary>
        /// ��ȡ��ǰʵ��ǰ������ͨ����ʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpGet]
        public TBL_AVALANCHE_HISTORYEntity GetAuditFormJson(string keyValue)
        {
            return tbl_avalanche_historybll.GetAuditEntity(keyValue);
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
            tbl_avalanche_historybll.RemoveForm(keyValue.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_AVALANCHE_HISTORYEntity entity)
        {
            tbl_avalanche_historybll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
