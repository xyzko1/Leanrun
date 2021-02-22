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
    /// ����Ԥ����ӿ�  by huangzy 2019-1-22
    /// ���ڷ���Ԥ�����ѯ������
    /// </summary>
    public class TBL_QCQF_DISASTERPREVENTIOApiController : ApiControllerBase
    {
		private DataItemCache dataItemCache = new DataItemCache();
        //����Ԥ����
        private TBL_QCQF_DISASTERPREVENTIONBLL tbl_qcqf_disasterpreventionbll = new TBL_QCQF_DISASTERPREVENTIONBLL();
        SSOWebApiWS ws = new SSOWebApiWS("");

        #region ��ȡ����
        /// <summary>
        /// ��ҳ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_DISASTERPREVENTIONEntity> GetPageList([FromUri]Pagination pagination, string queryJson)
        {
            return tbl_qcqf_disasterpreventionbll.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_DISASTERPREVENTIONEntity> GetList(string queryJson)
        {
            return tbl_qcqf_disasterpreventionbll.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public DataTable GetAnalyseListQCQF(string queryJson)
        {
            return tbl_qcqf_disasterpreventionbll.GetAnalyseListQCQF(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_DISASTERPREVENTIONEntity GetEntity(string keyValue)
        {
            return tbl_qcqf_disasterpreventionbll.GetEntity(keyValue);
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
            tbl_qcqf_disasterpreventionbll.RemoveForm(keyValue.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromUri]TBL_QCQF_DISASTERPREVENTIONEntity entity)
        {
            tbl_qcqf_disasterpreventionbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion

    }
}