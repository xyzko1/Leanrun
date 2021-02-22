using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Http;
using iTelluro.Busness.WebApi;
using System.Linq;
using Newtonsoft.Json.Linq;
using System;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-13 16:23
    /// �� ����Ⱥ��Ⱥ�������ˮ���ݱ�
    /// </summary>
    public class TBL_QCQF_POINTRECORDApiController : ApiControllerBase
    {
        private TBL_QCQF_POINTRECORDBLL tbl_qcqf_pointrecordbll = new TBL_QCQF_POINTRECORDBLL();
        private TBL_QCQF_LAYOUTPOINTINFOBLL tbl_qcqf_layoutpointinfobll = new TBL_QCQF_LAYOUTPOINTINFOBLL();
        private TBL_HAZARDBASICINFOBLL tbl_hazardbasicinfobll = new TBL_HAZARDBASICINFOBLL();
        private SSOWebApiWS ssoWS = new SSOWebApiWS(""); 
        #region ��ȡ����
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
            var data = tbl_qcqf_pointrecordbll.GetPageList(pagination, queryJson);
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
        public IEnumerable<TBL_QCQF_POINTRECORDEntity> GetListJson(string queryJson)
        {
            var data = tbl_qcqf_pointrecordbll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_QCQF_POINTRECORDEntity GetFormJson(string keyValue)
        {
            var data = tbl_qcqf_pointrecordbll.GetEntity(keyValue);
            return data;
        }
        [HttpGet]
        public TBL_QCQF_POINTRECORDEntity GetFormByMONITORPOINTGUID(string keyValue)
        {
            var data = tbl_qcqf_pointrecordbll.GetFormByMONITORPOINTGUID(keyValue);
            return data;
        }

        /// <summary>
        ///����DISASTERNAME��UPLOADNAME��ѯ�����ˮ����
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public object GetPageListJsonByCondition([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var param = new JObject();
            string strDISASTERNAME = "";
            if (queryJson.Trim('"') != "" && !queryJson.Contains("["))
            {
                param = queryJson.ToJObject();
            }
            if (Convert.ToString(param["DISASTERNAME"]) != null && Convert.ToString(param["DISASTERNAME"]) != "")
            {
                strDISASTERNAME = param["DISASTERNAME"].ToString();
                var data = from a in tbl_qcqf_pointrecordbll.GetListByUploadName(queryJson)
                           join c in tbl_qcqf_layoutpointinfobll.GetAllList("") on a.MONITORPOINTGUID equals c.GUID
                           join b in tbl_hazardbasicinfobll.GetList("").Where(t => t.DISASTERNAME.Contains(strDISASTERNAME)) on c.UNIFIEDCODE equals b.UNIFIEDCODE
                           where b.UNIFIEDCODE != null
                           select new { a.GUID, a.MONITORTIME, a.SLITWIDTH, a.TODRUMHEIGH, a.SPRINGAMOUNT, a.SPRINGVOICING, a.WELLLEVEL, a.WELLVOICING, a.UPLOADLONGITUDE, a.UPLOADLATITUDE, a.UPLOADID, a.UPLOADNAME, a.SOURCETYPE, b.DISASTERNAME, b.UNIFIEDCODE, c.MONITORPOINTCODE };
                pagination.records = data.Count();
                //��ҳ
                data = data.ToList().OrderByDescending(t => t.MONITORTIME).Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
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
            else
            {
                var data = from a in tbl_qcqf_pointrecordbll.GetListByUploadName(queryJson)
                           join c in tbl_qcqf_layoutpointinfobll.GetAllList("") on a.MONITORPOINTGUID equals c.GUID
                           join b in tbl_hazardbasicinfobll.GetList("") on c.UNIFIEDCODE equals b.UNIFIEDCODE
                           where b.UNIFIEDCODE != null
                           select new { a.GUID, a.MONITORTIME, a.SLITWIDTH, a.TODRUMHEIGH, a.SPRINGAMOUNT, a.SPRINGVOICING, a.WELLLEVEL, a.WELLVOICING, a.UPLOADLONGITUDE, a.UPLOADLATITUDE, a.UPLOADID, a.UPLOADNAME, a.SOURCETYPE, b.DISASTERNAME, b.UNIFIEDCODE, c.MONITORPOINTCODE };
                pagination.records = data.Count();
                //��ҳ
                data = data.ToList().OrderByDescending(t => t.MONITORTIME).Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
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
            tbl_qcqf_pointrecordbll.RemoveForm(param.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromBody]TBL_QCQF_POINTRECORDEntity entity)
        {
            tbl_qcqf_pointrecordbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        [HttpPost]
        public WebApiResult SaveFormByMONITORPOINTGUID(string keyValue, [FromBody]TBL_QCQF_POINTRECORDEntity entity)
        {
            tbl_qcqf_pointrecordbll.SaveFormByMONITORPOINTGUID(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
