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
using Infoearth.Data.Repository;
using System.Collections.Generic;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-07 17:24
    /// �� ����Ⱥ��Ⱥ��������Ϣ��
    /// </summary>
    public class TBL_QCQF_LAYOUTPOINTINFOApiController : ApiControllerBase
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        private TBL_QCQF_LAYOUTPOINTINFOBLL tbl_qcqf_layoutpointinfobll = new TBL_QCQF_LAYOUTPOINTINFOBLL();
        private TBL_HAZARDBASICINFOBLL tbl_hazardbasicinfobll = new TBL_HAZARDBASICINFOBLL();
        private TBL_QCQF_POINTOBSERVATIONBLL tbl_qcqf_pointobservationbll = new TBL_QCQF_POINTOBSERVATIONBLL();
        private TBL_QCQF_OBSERVATIONBLL tbl_qcqf_observationbll = new TBL_QCQF_OBSERVATIONBLL();
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        //[HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var param = new JObject();
            List<string> _codes = ssoWS.GetAllAuthDistricts();//��ȡ��ǰ�û���������
            string arecode = ""; string str = "where 1=1 ";
            if (queryJson.Trim('"') != "" && !queryJson.Contains("["))
            {
                param = queryJson.ToJObject();
                if (param["DISASTERNAME"].ToString() != "")
                {
                    str += " and B.DISASTERNAME LIKE '%" + param["DISASTERNAME"] + "%'";
                }
                if (param["MONITORPOINTCODE"].ToString() != "")
                {
                    str += " and A.MONITORPOINTCODE LIKE '%" + param["MONITORPOINTCODE"] + "%'";
                }
                if (param["MONITORPOINTPOSITION"].ToString() != "")
                {
                    str += " and A.MONITORPOINTPOSITION LIKE '%" + param["MONITORPOINTPOSITION"] + "%'";
                }
                if (param["areecode"] != null)
                {
                    if (param["areecode"].ToString() != "")
                    {
                        var arecode1 = param["areecode"].ToString();
                        if (arecode1.EndsWith("0000") && arecode1.Length == 6)
                        {
                            arecode1 = arecode1.Substring(0, 2);
                        }
                        else if (arecode1.EndsWith("00") && arecode1.Length==6)
                        {
                            arecode1 = arecode1.Substring(0, 4);
                        }
                        else
                        {
                            arecode1 = arecode1.Substring(0, 6);
                        }
                        str += " and A.UNIFIEDCODE LIKE '" + arecode1 + "%'";
                    }
                }
            }
            if (!_codes.Contains("000000"))
            {
                if (_codes[0].EndsWith("0000"))
                {
                    arecode = _codes[0].Substring(0, 2);
                }
                else if (_codes[0].EndsWith("00"))
                {
                    arecode = _codes[0].Substring(0, 4);
                }
                else
                {
                    arecode = _codes[0].Substring(0, 6);
                }
                str += " and A.UNIFIEDCODE LIKE '" + arecode + "%'";
            }
           
            //if (Convert.ToString(param["DISASTERNAME"]) != null && Convert.ToString(param["DISASTERNAME"]) != "")
            //{
            //    strDISASTERNAME = param["DISASTERNAME"].ToString();
            //    var data = from a in tbl_qcqf_layoutpointinfobll.GetList(queryJson)
            //               join b in tbl_hazardbasicinfobll.GetList("").Where(t => t.DISASTERNAME.Contains(strDISASTERNAME)) on a.UNIFIEDCODE equals b.UNIFIEDCODE
            //              // where b.UNIFIEDCODE != null
            //               select new { a.GUID, a.MONITORPOINTCODE, a.MONITORPOINTPOSITION, a.UNIFIEDCODE, b.DISASTERNAME, b.LOCATION };

            //    pagination.records = data.Count();
            //    //��ҳ
            //    data = data.ToList().Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
            //    var jsonData = new
            //    {
            //        rows = data,
            //        total = pagination.total,
            //        page = pagination.page,
            //        records = pagination.records,
            //        costtime = CommonHelper.TimerEnd(watch)
            //    };
            //    return jsonData;
            //}
            //else
            //{
                //var data = from a in tbl_qcqf_layoutpointinfobll.GetList(queryJson)
                //           join b in tbl_hazardbasicinfobll.GetList(queryJson) on a.UNIFIEDCODE equals b.UNIFIEDCODE
                //           //where b.UNIFIEDCODE != null
                //           select new { a.GUID, a.MONITORPOINTCODE, a.MONITORPOINTPOSITION, a.UNIFIEDCODE, b.DISASTERNAME, b.LOCATION };


            string sql = "select A.GUID,A.MODIFYTIME,A.MONITORPOINTCODE,A.MONITORPOINTPOSITION,B.UNIFIEDCODE,B.DISASTERNAME,B.LOCATION FROM TBL_QCQF_LAYOUTPOINTINFO A INNER JOIN TBL_HAZARDBASICINFO B ON SUBSTR(A.UNIFIEDCODE,0,12)= SUBSTR(B.UNIFIEDCODE,0,12) " + str;
                var data = new RepositoryFactory().BaseRepository().FindList<TBL_LAYOUT>(sql);
                pagination.records = data.Count();
                //��ҳ
                data = data.ToList().OrderByDescending(d=>d.MODIFYTIME).Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
                var jsonData = new
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return jsonData;
            //}
        }
        public class TBL_LAYOUT
        {
            public string GUID { get; set; }
            public string MONITORPOINTCODE { get; set; }
            public string MONITORPOINTPOSITION { get; set; }
            public string UNIFIEDCODE { get; set; }
            public string DISASTERNAME { get; set; }
            public string LOCATION { get; set; }
            public DateTime? MODIFYTIME { get; set; }
        }
        //��ȡȺ��Ⱥ�������ϱ��ֺ�������
        public object GetSJSBPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            //��ȡ��ǰ�û�ID
            UserInfo userInfo = ssoWS.GetUserInfo();
            string F_UserId = userInfo.F_UserId;
            //var param = new JObject();
            //string strDISASTERNAME = "";
            //if (queryJson.Trim('"') != "" && !queryJson.Contains("["))
            //{
            //    param = queryJson.ToJObject();
            //}
            //if (Convert.ToString(param["DISASTERNAME"]) != null && Convert.ToString(param["DISASTERNAME"]) != "")
            //{
            //    strDISASTERNAME = param["DISASTERNAME"].ToString();
            //    var list = from b in tbl_hazardbasicinfobll.GetList("").Where(t => t.DISASTERNAME.Contains(strDISASTERNAME))
            //               join a in tbl_qcqf_layoutpointinfobll.GetList(queryJson) on b.UNIFIEDCODE equals a.UNIFIEDCODE
            //               join c in tbl_qcqf_pointobservationbll.GetList("") on a.GUID equals c.UNIFIEDCODE
            //               join d in tbl_qcqf_observationbll.GetList("").Where(t => t.ID.Contains(F_UserId)) on c.ID equals d.ID
            //               where b.UNIFIEDCODE != null
            //               select a.UNIFIEDCODE;
            //    var data = from c in tbl_hazardbasicinfobll.GetList("")
            //               where list.Contains(c.UNIFIEDCODE)
            //               select c;
            //    //��ҳ
            //    data = data.ToList().Skip((pagination.page-1)*pagination.rows).Take(pagination.rows);
            //    pagination.records = data.Count();
            //    var jsonData = new
            //    {
            //        rows = data,
            //        total = pagination.total,
            //        page = pagination.page,
            //        records = pagination.records,
            //        costtime = CommonHelper.TimerEnd(watch)
            //    };
            //    return jsonData;
            //}
            //else
            //{

            //    var list = from b in tbl_hazardbasicinfobll.GetList("")
            //               join a in tbl_qcqf_layoutpointinfobll.GetList(queryJson) on b.UNIFIEDCODE equals a.UNIFIEDCODE
            //               join c in tbl_qcqf_pointobservationbll.GetList("") on a.GUID equals c.UNIFIEDCODE
            //               join d in tbl_qcqf_observationbll.GetList("").Where(t => t.ID.Contains(F_UserId)) on c.ID equals d.ID
            //               where b.UNIFIEDCODE != null
            //               select a.UNIFIEDCODE;
            //    var data = from c in tbl_hazardbasicinfobll.GetList( "")
            //               where list.Contains(c.UNIFIEDCODE)
            //               select c;
            //    pagination.records = data.Count();
            //    //��ҳ
            //    data = data.ToList().Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
            //    var jsonData = new
            //    {
            //        rows = data,
            //        total = pagination.total,
            //        page = pagination.page,
            //        records = pagination.records,
            //        costtime = CommonHelper.TimerEnd(watch)
            //    };
            //    return jsonData;
            //}
            //var data = from b in tbl_hazardbasicinfobll.GetList(queryJson)
            //           join a in tbl_qcqf_layoutpointinfobll.GetList("") on b.UNIFIEDCODE equals a.UNIFIEDCODE
            //           join c in tbl_qcqf_pointobservationbll.GetList("") on a.GUID equals c.UNIFIEDCODE
            //           join d in tbl_qcqf_observationbll.GetList("").Where(t => t.ID.Contains(F_UserId)) on c.ID equals d.ID
            //           where b.UNIFIEDCODE != null
            //           select b;
            var data = from b in tbl_qcqf_layoutpointinfobll.GetList("")
                       //join a in tbl_qcqf_layoutpointinfobll.GetList("") on b.UNIFIEDCODE equals a.UNIFIEDCODE
                       join c in tbl_qcqf_pointobservationbll.GetList("") on b.GUID equals c.UNIFIEDCODE
                       join d in tbl_qcqf_observationbll.GetList("").Where(t => t.ID.Contains(F_UserId)) on c.ID equals d.ID
                       where b.UNIFIEDCODE != null
                       select b;
            //var data1 = tbl_hazardbasicinfobll.GetDataByQcqfReturnHazardbasicInfo( ref pagination, queryJson);
            //var data = from c in tbl_hazardbasicinfobll.GetList("")
            //           where list.Contains(c.UNIFIEDCODE)
            //           select c;
            //pagination.records = data.Count();
            //��ҳ
            //data = data.ToList().Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
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
        [HttpGet]
        public object GetListByUNIFIEDCODE(string UNIFIEDCODE)
        {
            var queryJson = new
            {
                UNIFIEDCODE = UNIFIEDCODE
            };
            var data = tbl_qcqf_layoutpointinfobll.GetList(queryJson.ToJson());
            return data;
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        public object GetListJson(string queryJson)
        {
            var data = tbl_qcqf_layoutpointinfobll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public object GetFormJson(string keyValue)
        {
            var data = tbl_qcqf_layoutpointinfobll.GetEntity(keyValue);
            string strUNIFIEDCODE = data.UNIFIEDCODE;
            //TBL_HAZARDBASICINFOEntity hazard = (from a in tbl_hazardbasicinfobll.GetList("") where a.UNIFIEDCODE== strUNIFIEDCODE
            //             select a).FirstOrDefault();
            TBL_HAZARDBASICINFOEntity hazard = tbl_hazardbasicinfobll.GetEntity(strUNIFIEDCODE);
            var result = new
            {
                GUID = data.GUID,
                MONITORPOINTCODE = data.MONITORPOINTCODE,
                MONITORPOINTPOSITION = data.MONITORPOINTPOSITION,
                UNIFIEDCODE = data.UNIFIEDCODE,
                DISASTERNAME = hazard.DISASTERNAME,
                LOCATION = hazard.LOCATION,
                LAT = data.LAT,
                LON = data.LON,
                ZRRNAME = data.ZRRNAME,
                ZRRPHONE = data.ZRRPHONE
            };
            return result;
        }
        //��ȡ�ֺ����������¼�����ͱ��
        public TBL_QCQF_LAYOUTPOINTINFOEntity GetMONITORPOINTTYPEByUNIFIEDCODE([FromUri]string UNIFIEDCODE, string TYPE)
        {
            var data = tbl_qcqf_layoutpointinfobll.GetMONITORPOINTTYPEByUNIFIEDCODE(UNIFIEDCODE, TYPE);
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
            tbl_qcqf_layoutpointinfobll.RemoveForm(param.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromUri]TBL_QCQF_LAYOUTPOINTINFOEntity entity)
        {
            tbl_qcqf_layoutpointinfobll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveFormQcqf(string keyValue, TBL_QCQF_LAYOUTPOINTINFOEntity entity)
        {
            tbl_qcqf_layoutpointinfobll.SaveForm(keyValue, entity);
            string result = "�����ɹ���";
            return Success(result, new { entity.GUID });
        }
        #endregion
    }
}
