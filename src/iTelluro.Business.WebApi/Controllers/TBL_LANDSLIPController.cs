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
    /// �� �������µ����
    /// </summary>
    public class TBL_LANDSLIPApiController : ApiControllerBase
    {
        private TBL_LANDSLIPBLL TBL_LANDSLIPbll = new TBL_LANDSLIPBLL();

       
        #region ��ȡ����

        /// <summary>
        /// ��ҳ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = TBL_LANDSLIPbll.GetPageList(pagination, queryJson);
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
        public IEnumerable<TBL_LANDSLIPEntity> GetListJson(string queryJson)
        {
            var data = TBL_LANDSLIPbll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_LANDSLIPEntity GetFormJson(string keyValue)
        {
            var data = TBL_LANDSLIPbll.GetEntity(keyValue);
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
            TBL_LANDSLIPbll.RemoveForm(keyValue.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromBody]TBL_LANDSLIPEntity entity)
        {
            TBL_LANDSLIPbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
