using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using Infoearth.Application.Entity.SystemManage;
using System.Linq;
using Infoearth.Application.Cache;
using Infoearth.Util.Offices;
using System;
using System.Data;
using System.Collections;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using Infoearth.Application.Entity;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// �������׿��ӿ�  by huangzy 2019-1-22
    /// ���ڱ������׿���ѯ������
    /// </summary>
    public class TBL_QCQF_ESCUNDERSTANDCARDApiController : ApiControllerBase
    {
		private DataItemCache dataItemCache = new DataItemCache();
        //�������׿�
        private TBL_QCQF_ESCUNDERSTANDCARDBLL tbl_qcqf_escunderstandcardbll = new TBL_QCQF_ESCUNDERSTANDCARDBLL();
        SSOWebApiWS ws = new SSOWebApiWS("");

        #region ��ȡ����
        /// <summary>
        /// ��ҳ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetPageList([FromUri]Pagination pagination, string queryJson)
        {
            return tbl_qcqf_escunderstandcardbll.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetList(string queryJson)
        {
            return tbl_qcqf_escunderstandcardbll.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_ESCUNDERSTANDCARDEntity GetEntity(string keyValue)
        {
            return tbl_qcqf_escunderstandcardbll.GetEntity(keyValue);
        }
        /// <summary>
        /// �����ֺ����Ż�ȡ
        /// </summary>
        /// <param name="keyValue">�ֺ�����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetEntity2(string queryJson)
        {
            return tbl_qcqf_escunderstandcardbll.GetEntity2(queryJson);
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
            tbl_qcqf_escunderstandcardbll.RemoveForm(keyValue.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromUri]TBL_QCQF_ESCUNDERSTANDCARDEntity entity)
        {
            tbl_qcqf_escunderstandcardbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion

    }
}