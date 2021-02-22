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
    /// �� ����huangzy
    /// �� �ڣ�2019-01-22 
    /// �� �������������
    /// </summary>
    public class TBL_AVALANCHEApiController : ApiControllerBase
    {
        private TBL_AVALANCHEBLL tbl_avalanchebll = new TBL_AVALANCHEBLL();

        #region ��ȡ����
        /// <summary>
        /// ��ҳ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// queryJsonΪ�ղ�ȫ��
        /// <returns></returns>
        [HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_avalanchebll.GetPageList(pagination, queryJson);
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
        public IEnumerable<TBL_AVALANCHEEntity> GetListJson(string queryJson)
        {
            var data = tbl_avalanchebll.GetList(queryJson);
            return data;
        }

        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_AVALANCHEEntity GetFormJson(string keyValue)
        {
            var data = tbl_avalanchebll.GetEntity(keyValue);
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
        public WebApiResult RemoveForm(SingleParam keyValue)
        {
            tbl_avalanchebll.RemoveForm(keyValue.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromBody]TBL_AVALANCHEEntity entity)
        {
            tbl_avalanchebll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
