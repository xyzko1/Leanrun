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
    /// �� �ڣ�2018-03-16 11:39
    /// �� �������ѷ�������ʷ��
    /// </summary>
    public class TBL_LANDCRACK_HISTORYApiController : ApiControllerBase
    {
        private TBL_LANDCRACK_HISTORYBLL tbl_landcrack_historybll = new TBL_LANDCRACK_HISTORYBLL();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        public IEnumerable<TBL_LANDCRACK_HISTORYEntity> GetListJson(string queryJson)
        {
            var data = tbl_landcrack_historybll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_LANDCRACK_HISTORYEntity GetFormJson(string keyValue)
        {
            var data = tbl_landcrack_historybll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">UNIFIEDCODE</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_LANDCRACK_HISTORYEntity GetEntityByUNIFIEDCODE(string keyValue)
        {
            var data = tbl_landcrack_historybll.GetEntityByUNIFIEDCODE(keyValue);
            return data;
        }
        /// <summary>
        /// ��ȡ��ǰʵ��ǰ������ͨ����ʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpGet]
        public TBL_LANDCRACK_HISTORYEntity GetAuditFormJson(string keyValue)
        {
            return tbl_landcrack_historybll.GetAuditEntity(keyValue);
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
            tbl_landcrack_historybll.RemoveForm(keyValue.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_LANDCRACK_HISTORYEntity entity)
        {
            tbl_landcrack_historybll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
