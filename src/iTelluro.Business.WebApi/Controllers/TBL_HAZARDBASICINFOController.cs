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
using Infoearth.Data.Repository;
using System.IO;
using System.Web;
using Infoearth.Application.Entity.SystemManage.ViewModel;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// ���ֵ���ӿ�  by wc 2018-4-27
    /// ���ڵ��ֵ����ѯ������
    /// Ⱥ��Ⱥ����ѯ������
    /// </summary>
    public class TBL_HAZARDBASICINFOApiController : ApiControllerBase
    {
        private TBL_HAZARDBASICINFOBLL tbl_hazardbasicinfobll = new TBL_HAZARDBASICINFOBLL();

        private DataItemCache dataItemCache = new DataItemCache();
        //����Ԥ����
        private TBL_QCQF_DISASTERPREVENTIONBLL tbl_qcqf_disasterpreventionbll = new TBL_QCQF_DISASTERPREVENTIONBLL();
        //�������׿�
        private TBL_QCQF_ESCUNDERSTANDCARDBLL tbl_qcqf_escunderstandcardbll = new TBL_QCQF_ESCUNDERSTANDCARDBLL();
        //�������׿�
        private TBL_QCQF_WORKUNDERSTANDCARDBLL tbl_qcqf_workunderstandcardbll = new TBL_QCQF_WORKUNDERSTANDCARDBLL();
        private HarzardTrendAnalyseBLL harzardTrendAnalyseBLL = new HarzardTrendAnalyseBLL();
        //��ʷ��¼��ͼ�ӿ�
        private TBL_HAZARDBASICINFO_HISTORYBLL tbl_hazardhistorybll = new TBL_HAZARDBASICINFO_HISTORYBLL();
        SSOWebApiWS ws = new SSOWebApiWS("");

        private Dictionary<string, string> codeNames = new Dictionary<string, string>();
        private List<string> distinctCodes = new List<string>();        
        
        #region ��ȡ����

        /// <summary>
        /// ����������ѯ�ֺ��������Ϣ������ҳ��
        /// </summary>
        /// <param name="queryJson">
        /// ��ѯ����
        /// PROVINCE ʡ��ţ�'c1','c2'..��
        /// CITY  �б��
        /// COUNTY �ر��
        /// TOWN ������
        /// PROVINCENAME ʡ���� ģ��ƥ��
        /// CITYNAME ������
        /// COUNTYNAME ������
        /// txt_Key ���ơ���š�λ��ģ��ƥ��
        /// DISASTERNAME �ֺ����� 
        /// UNIFIEDCODE ͳһ���
        /// DISASTERTYPE �ֺ�����
        /// HIDDENDANGER �Ƿ������� 0-��1-�� �ֵ��HIDDENDANGER��
        /// DISASTERLEVEL �ֺ��ȼ� �ֵ��DANGERLEVEL��
        /// DANGERLEVEL ����ȼ�   �ֵ��DISASTERLEVEL��
        /// CURSTABLESTATUS Ŀǰ�ȶ��̶� A-�ȶ� B-�����ȶ�  C-Ǳ�ڲ��ȶ�  D-���ȶ�(�ֵ���CURRENTSTABLESTATUS)
        /// STABLETREND ���չ����  A-�ȶ� B-�����ȶ�  C-Ǳ�ڲ��ȶ�  D-���ȶ� ���ֵ���STABLETREND��
        /// TREATMENTSUGGESTION ���ν��� �ֵ��TREATMENTSUGGESTION��
        /// MONITORSUGGESTION��⽨�� �ֵ��MONITORSUGGESTION��
        /// THREATENPEOPLEBEGIN ��в�˿ڿ�ʼ THREATENPEOPLEEND ��в�˿ڽ���
        /// THREATENASSETSBEGIN ��в�Ʋ���ʼ THREATENASSETSEND ��в�Ʋ�����
        /// DEATHTOLLBEGIN �����˿ڿ�ʼ DEATHTOLLEND �����˿ڽ���
        /// ASSETSLOSEBEGIN �Ʋ���ʧ��ʼ ASSETSLOSEEND �Ʋ���ʧ����
        /// </param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        //[HttpPost]
        public object GetListJson(string queryJson)
        {
            var data = tbl_hazardbasicinfobll.GetList(queryJson);
            //return data;ԭʼ����ֵ
            //��ͼ�������е���Ϣ�ֶ�ɸѡ
            return data.Select(p => new { p.DISASTERNAME, p.DISASTERTYPE, p.UNIFIEDCODE, p.OUTDOORCODE, p.CITYNAME, p.COUNTYNAME, p.TOWNNAME, p.LOCATION, p.LONGITUDE, p.LATITUDE, p.DANGERLEVEL, p.THREATENPEOPLE, p.THREATENASSETS }).ToList();
        }
        /// <summary>
        /// ��ȡ��ͼժҪ��Ϣ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <param name="condition">��ѡ����(���Բ���)
        /// WKTString:�յ����� POLYGON((119.76735720875 35.15413150875,119.76735720875 36.30549869625))
        /// x:���ĵ������
        /// y:���ĵ�������
        /// radius:�뾶(��)
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public object PostZYListJson(QueryJsonEntity entity)
        {
            var data = tbl_hazardbasicinfobll.GetZYPageList(entity.queryJson, entity.condition);
            return data;
        }
        /// <summary>
        /// ��ȡ��ͼժҪ��Ϣ(�з���Ԥ������Ϣ�ĵ�)
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <param name="condition">��ѡ����(���Բ���)
        /// WKTString:�յ����� POLYGON((119.76735720875 35.15413150875,119.76735720875 36.30549869625))
        /// x:���ĵ������
        /// y:���ĵ�������
        /// radius:�뾶(��)
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public object PostZYListJson2(QueryJsonEntity entity)
        {
            var data = tbl_hazardbasicinfobll.GetZYPageList2(entity.queryJson, entity.condition);
            return data;
        }
        /// <summary>
        /// �ֺ������λ�������
        /// </summary>
        /// <param name="xzqh">��������6λ+�ֺ�����2λ</param>
        /// <returns></returns>
        [HttpGet]
        public string GetMaxCode(string xzqh)
        {
            return tbl_hazardbasicinfobll.GetMaxCode(xzqh);
        }
        /// <summary>
        /// ��ȡ�ֺ�����ʷ���ݲ�ѯ�б�����ҳ���ڵ�ͼ�󶨣�
        /// </summary>
        /// <param name="queryJson">
        /// ��ѯ����
        /// PROVINCE ʡ��ţ�'c1','c2'..��
        /// CITY  �б��
        /// COUNTY �ر��
        /// TOWN ������
        /// PROJECTID ��Ŀ���� �ֵ�� JYGC_PROJECTBASEINFO-PROJECTGUID
        /// MODIFYTYPE �������� U-���� A-����  D-���� I-��������
        /// shifouhexiao �Ƿ��Ѿ����� 0-�� 1-��
        /// ISZLGCPNT �Ƿ������� 0-�� 1-��
        /// RELOCATION �Ƿ��Ǩ���� 0-�� 1-��
        /// BeginTime ��ʼʱ��
        /// EndTime ����ʱ��
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<PastHAZARDBASICINFO> GetPastListJson2(string queryJson)
        {
            return tbl_hazardbasicinfobll.GetPastListJson2(queryJson);
        }
        /// <summary>	 
        /// ��ȡû������һ����Ϣ���ֺ�����Ϣ
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetNoQcqfPageList(QueryJsonEntity entity)
        {
            var data = tbl_hazardbasicinfobll.GetNoQcqfPageList(entity.queryJson, entity.condition);
            return data;
        }
        [HttpGet]
        public DataTable GetListCodeJson(string queryJson)
        {
            var data = tbl_hazardbasicinfobll.GetListCode(queryJson);
            return data;
        }
        /// <summary>
        /// ������ҳ�ۺ�
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntityNEWS GetListCodes()
        {
            var data = tbl_hazardbasicinfobll.GetListCodesNew();
            return data;
        }
        /// <summary>
        /// ���ֲɼ�����ۺ�
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntityCJ GetListDataCJ(string queryJson)
        {
            var data = tbl_hazardbasicinfobll.GetListDataCJ(queryJson);
            return data;
        }

        //���ص�ͼ����
        [HttpGet]
        public DataTable GetListCodeJsons(string queryJson)
        {
            var data = tbl_hazardbasicinfobll.GetListCode(queryJson);
            return data;
        }
        /// <summary>
        /// ����ȼ�ͳ��(���һ����Ŀ)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByXQDJ(string queryJson = null)
        {
            if (queryJson == null)
            {
                queryJson = "";
            }
            var result = tbl_hazardbasicinfobll.GetStatisticsByXQDJ(queryJson);
            return result;
        }
        /// <summary>
        /// �ֺ���ģ�ȼ�ͳ��(���һ����Ŀ)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByGMDJ(string queryJson = null)
        {
            if (queryJson == null)
            {
                queryJson = "";
            }
            var result = tbl_hazardbasicinfobll.GetStatisticsByGMDJ(queryJson);
            return result;
        }
        /// <summary>
        /// ����ȼ�ͳ��(���һ����Ŀ)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByZQDJ(string queryJson = null)
        {
            if (queryJson == null)
            {
                queryJson = "";
            }
            var result = tbl_hazardbasicinfobll.GetStatisticsByZQDJ(queryJson);
            return result;
        }
        /// <summary>
        /// ����������ѯ�ֺ��������Ϣ����ҳ��
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">
        /// ��ѯ����
        /// PROVINCE ʡ��ţ�'c1','c2'..��
        /// CITY  �б��
        /// COUNTY �ر��
        /// TOWN ������
        /// PROVINCENAME ʡ���� ģ��ƥ��
        /// CITYNAME ������
        /// COUNTYNAME ������
        /// txt_Key ���ơ���š�λ��ģ��ƥ��
        /// DISASTERNAME �ֺ����� 
        /// UNIFIEDCODE ͳһ���
        /// DISASTERTYPE �ֺ�����
        /// HIDDENDANGER �Ƿ������� 0-��1-�� �ֵ��HIDDENDANGER��
        /// DISASTERLEVEL �ֺ��ȼ� �ֵ��DANGERLEVEL��
        /// DANGERLEVEL ����ȼ�   �ֵ��DISASTERLEVEL��
        /// CURSTABLESTATUS Ŀǰ�ȶ��̶� A-�ȶ� B-�����ȶ�  C-Ǳ�ڲ��ȶ�  D-���ȶ�(�ֵ���CURRENTSTABLESTATUS)
        /// STABLETREND ���չ����  A-�ȶ� B-�����ȶ�  C-Ǳ�ڲ��ȶ�  D-���ȶ� ���ֵ���STABLETREND��
        /// TREATMENTSUGGESTION ���ν��� �ֵ��TREATMENTSUGGESTION��
        /// MONITORSUGGESTION��⽨�� �ֵ��MONITORSUGGESTION��
        /// THREATENPEOPLEBEGIN ��в�˿ڿ�ʼ THREATENPEOPLEEND ��в�˿ڽ���
        /// THREATENASSETSBEGIN ��в�Ʋ���ʼ THREATENASSETSEND ��в�Ʋ�����
        /// DEATHTOLLBEGIN �����˿ڿ�ʼ DEATHTOLLEND �����˿ڽ���
        /// ASSETSLOSEBEGIN �Ʋ���ʧ��ʼ ASSETSLOSEEND �Ʋ���ʧ����
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_hazardbasicinfobll.GetPageListJson(pagination, queryJson);
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
        ///  [HttpGet]
        //public object GetPageListJsonByZhtj([FromUri]Pagination pagination, string queryJson)
        //{
        //    var watch = CommonHelper.TimerStart();
        //    var data = tbl_hazardbasicinfobll.GetPageListJson(pagination, queryJson);
        //    if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
        //    {
        //        dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
        //        if (json.ssx == "ʡ")
        //        {
        //            data = data.GroupBy(r => r.PROVINCENAME).Select(r => r.First());
        //        }
        //        else if (json.ssx == "��")
        //        {
        //            data = data.GroupBy(r => r.CITYNAME).Select(r => r.First());
        //        }
        //        else if (json.ssx == "��")
        //        {
        //            data = data.GroupBy(r => r.COUNTYNAME).Select(r => r.First());
        //        }
        //        else if (json.ssx == "����")
        //        {
        //            data = data.GroupBy(r => r.TOWNNAME).Select(r => r.First());
        //        }
        //        string tiaojian = json.ssx;
        //        List<TBL_HAZARDBASICINFOEntity> lst = new List<TBL_HAZARDBASICINFOEntity>();
        //        switch (tiaojian)
        //        {
        //            case "�ֺ�������":
        //                tiaojian = "DISASTERNAME";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.DISASTERNAME)).ToList();
        //                data = data.GroupBy(r => r.DISASTERNAME).Select(r => r.First());
        //                break;
        //            case "�ֺ�����":
        //                tiaojian = "UNIFIEDCODE";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.UNIFIEDCODE)).ToList();
        //                data = data.GroupBy(r => r.UNIFIEDCODE).Select(r => r.First());
        //                break;
        //            case "ʡ":
        //                tiaojian = "PROVINCENAME";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.PROVINCENAME)).ToList();
        //                data = data.GroupBy(r => r.PROVINCENAME).Select(r => r.First());
        //                break;
        //            case "��":
        //                tiaojian = "CITYNAME";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.CITYNAME)).ToList();
        //                data = data.GroupBy(r => r.CITYNAME).Select(r => r.First());
        //                break;
        //            case "��":
        //                tiaojian = "COUNTYNAME";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.COUNTYNAME)).ToList();
        //                data = data.GroupBy(r => r.COUNTYNAME).Select(r => r.First());
        //                break;
        //            case "����":
        //                tiaojian = "TOWNNAME";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.TOWNNAME)).ToList();
        //                data = data.GroupBy(r => r.TOWNNAME).Select(r => r.First());
        //                break;
        //            case "����λ��":
        //                tiaojian = "LOCATION";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.LOCATION)).ToList();
        //                data = data.GroupBy(r => r.LOCATION).Select(r => r.First());
        //                break;
        //            case "����":
        //                tiaojian = "LONGITUDE";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.LONGITUDE)).ToList();
        //                data = data.GroupBy(r => r.LONGITUDE).Select(r => r.First());
        //                break;
        //            case "γ��":
        //                tiaojian = "LATITUDE";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.LATITUDE)).ToList();
        //                data = data.GroupBy(r => r.LATITUDE).Select(r => r.First());
        //                break;
        //            case "Ұ����":
        //                tiaojian = "OUTDOORCODE";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.OUTDOORCODE)).ToList();
        //                data = data.GroupBy(r => r.OUTDOORCODE).Select(r => r.First());
        //                break;
        //            case "���ڱ��":
        //                tiaojian = "INDOORCODE";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.INDOORCODE)).ToList();
        //                data = data.GroupBy(r => r.INDOORCODE).Select(r => r.First());
        //                break;
        //            case "�ֺ��ȼ�":
        //                tiaojian = "DISASTERLEVEL";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.DISASTERLEVEL)).ToList();
        //                //data = data.GroupBy(r => r.DISASTERLEVEL).Select(r => r.First());

        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st = { "С��", "����", "����", "�ش���" };
        //                foreach (string s in st)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.DISASTERLEVEL = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "����ȼ�":
        //                tiaojian = "DANGERLEVEL";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.DANGERLEVEL)).ToList();
        //                //data = data.GroupBy(r => r.DANGERLEVEL).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st1 = { "С��", "����", "����", "�ش���" };
        //                foreach (string s in st1)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.DANGERLEVEL = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "X":
        //                tiaojian = "X";
        //                data = data.Where(s => s.X != null).ToList();
        //                data = data.GroupBy(r => r.X).Select(r => r.First());
        //                break;
        //            case "Y":
        //                tiaojian = "Y";
        //                data = data.Where(s => s.Y != null).ToList();
        //                data = data.GroupBy(r => r.Y).Select(r => r.First());
        //                break;
        //            case "Z":
        //                tiaojian = "Z";
        //                data = data.Where(s => s.Z != null).ToList();
        //                data = data.GroupBy(r => r.Z).Select(r => r.First());
        //                break;
        //            case "����ˮ����":
        //                tiaojian = "GROUNDWATERTYPE";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.GROUNDWATERTYPE)).ToList();
        //                //data = data.GroupBy(r => r.GROUNDWATERTYPE).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st5 = { "��϶ˮ", "��϶ˮ", "����ˮ", "Ǳˮ", "��ѹˮ", "�ϲ���ˮ" };
        //                foreach (string s in st5)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.GROUNDWATERTYPE = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "���ν���":
        //                tiaojian = "TREATMENTSUGGESTION";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.TREATMENTSUGGESTION)).ToList();
        //                //data = data.GroupBy(r => r.TREATMENTSUGGESTION).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st2 = { "����", "�ѷ�����", "��ǿ���", "�ر���ˮ", "������ˮ", "��������", "�������", "��ѹ�½�", "֧��", "ê��", "�ཬ", "ֲ���ֲ�", "�¸���", "ˮ�ĺ�", "������"};
        //                foreach (string s in st2)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.TREATMENTSUGGESTION = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "���첿λ":
        //                tiaojian = "TECTONICREGION";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.TECTONICREGION)).ToList();
        //                data = data.GroupBy(r => r.TECTONICREGION).Select(r => r.First());
        //                break;
        //            case "��⽨��":
        //                tiaojian = "MONITORSUGGESTION";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.MONITORSUGGESTION)).ToList();
        //                //data = data.GroupBy(r => r.MONITORSUGGESTION).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st3 = { "����Ŀ��Ѳ��", "��װ���׼����ʩ", "����λ�Ƽ��", "�λ�Ƽ��" };
        //                foreach (string s in st3)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.MONITORSUGGESTION = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "���仯����":
        //                tiaojian = "STABLETREND";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.STABLETREND)).ToList();
        //                //data = data.GroupBy(r => r.STABLETREND).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st4 = { "�ȶ�", "�����ȶ�", "���ȶ�"};
        //                foreach (string s in st4)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.STABLETREND = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "Ŀǰ�ȶ��̶�":
        //                tiaojian = "CURSTABLESTATUS";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.CURSTABLESTATUS)).ToList();
        //                //data = data.GroupBy(r => r.CURSTABLESTATUS).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st6 = { "�ȶ�", "�����ȶ�", "���ȶ�"};
        //                foreach (string s in st6)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.CURSTABLESTATUS = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "��в�Ʋ�":
        //                tiaojian = "THREATENASSETS";
        //                data = data.Where(s => s.THREATENASSETS != null).ToList();
        //                data = data.GroupBy(r => r.THREATENASSETS).Select(r => r.First()).OrderBy(r => r.THREATENASSETS);
        //                break;
        //            case "��в�˿�":
        //                tiaojian = "THREATENPEOPLE";
        //                data = data.Where(s => s.THREATENPEOPLE != null).ToList();
        //                data = data.GroupBy(r => r.THREATENPEOPLE).Select(r => r.First()).OrderBy(r => r.THREATENPEOPLE);
        //                break;
        //            case "������":
        //                tiaojian = "HIDDENDANGER";
        //                //data = data.Where(s => !string.IsNullOrEmpty(s.HIDDENDANGER)).ToList();
        //                //data = data.GroupBy(r => r.HIDDENDANGER).Select(r => r.First());
        //                lst = new List<TBL_HAZARDBASICINFOEntity>();
        //                string[] st7 = { "��", "��" };
        //                foreach (string s in st7)
        //                {
        //                    TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
        //                    haza.HIDDENDANGER = s;
        //                    lst.Add(haza);

        //                }
        //                data = lst;
        //                break;
        //            case "�ֺ�������":
        //                tiaojian = "DISASTERTYPE";
        //                data = data.Where(s => !string.IsNullOrEmpty(s.DISASTERTYPE)).ToList();
        //                data = data.GroupBy(r => r.DISASTERTYPE).Select(r => r.First());
        //                break;
        //            case "�ٻ�����":
        //                tiaojian = "DESTROYEDHOME";
        //                data = data.Where(s => s.DESTROYEDHOME != null).ToList();
        //                data = data.GroupBy(r => r.DESTROYEDHOME).Select(r => r.First());
        //                break;
        //            case "��·":
        //                tiaojian = "DESTROYEDROAD";
        //                data = data.Where(s => s.DESTROYEDROAD != null).ToList();
        //                data = data.GroupBy(r => r.DESTROYEDROAD).Select(r => r.First());
        //                break;
        //            case "����":
        //                tiaojian = "DESTROYEDCANAL";
        //                data = data.Where(s => s.DESTROYEDCANAL != null).ToList();
        //                data = data.GroupBy(r => r.DESTROYEDCANAL).Select(r => r.First());
        //                break;
        //            default:
        //                tiaojian = "123";
        //                break;
        //        }
        //        if (tiaojian == null || tiaojian == "")
        //        {
        //            data = data.ToList();
        //        }
        //    }
        //    var jsonData = new
        //    {
        //        rows = data,
        //        //total = pagination.total,
        //        total = data.Count(),
        //        page = pagination.page,
        //        records = pagination.records,
        //        costtime = CommonHelper.TimerEnd(watch)
        //    };
        //    return jsonData;
        //}
        [HttpGet]
        public object GetPageListJsonByZhtj([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            List<TBL_HAZARDBASICINFOEntity> data = new List<TBL_HAZARDBASICINFOEntity>();
            List<DataItemModel> dataitem = dataItemCache.GetDataItemList().ToList();
            List<TBL_HAZARDBASICINFOEntity> list = new List<TBL_HAZARDBASICINFOEntity>();
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                string tiaojian = json.ssx;
                tiaojian = tiaojian.Trim();
                if (tiaojian == "�ֺ��ȼ�")
                {
                    tiaojian = "DISASTERLEVEL";
                    var a = dataitem.Where(p => p.F_EnCode == "DISASTERLEVEL").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.DISASTERLEVEL = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "����ȼ�")
                {
                    tiaojian = "DANGERLEVEL";
                    var a = dataitem.Where(p => p.F_EnCode == "DANGERLEVEL").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.DANGERLEVEL = item;
                        list.Add(haza);
                    }
                    data = list;

                }
                else if (tiaojian == "����ˮ����")
                {
                    tiaojian = "GROUNDWATERTYPE";
                    var a = dataitem.Where(p => p.F_EnCode == "GROUNDWATERTYPEHP").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.GROUNDWATERTYPE = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "���ν���")
                {
                    tiaojian = "TREATMENTSUGGESTION";
                    var a = dataitem.Where(p => p.F_EnCode == "TREATMENTSUGGESTION").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.TREATMENTSUGGESTION = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "��⽨��")
                {
                    tiaojian = "MONITORSUGGESTION";
                    var a = dataitem.Where(p => p.F_EnCode == "MONITORSUGGESTION").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.MONITORSUGGESTION = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "���仯����")
                {
                    tiaojian = "STABLETREND";
                    var a = dataitem.Where(p => p.F_EnCode == "STABLETREND").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.STABLETREND = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "Ŀǰ�ȶ��̶�")
                {
                    tiaojian = "CURSTABLESTATUS";
                    var a = dataitem.Where(p => p.F_EnCode == "CURRENTSTABLESTATUS").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.CURSTABLESTATUS = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "������")
                {
                    tiaojian = "HIDDENDANGER";
                    var a = dataitem.Where(p => p.F_EnCode == "HIDDENDANGER").Select(p => p.F_ItemName + "--" + p.F_ItemValue);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.HIDDENDANGER = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "�ֺ�������")
                {
                    tiaojian = "DISASTERTYPE";
                    var a = dataitem.Where(p => p.F_EnCode == "HazardType").Select(p => p.F_ItemName);
                    foreach (var item in a)
                    {
                        TBL_HAZARDBASICINFOEntity haza = new TBL_HAZARDBASICINFOEntity();
                        haza.DISASTERTYPE = item;
                        list.Add(haza);
                    }
                    data = list;
                }
                else if (tiaojian == "ʡ")
                {
                    tiaojian = "PROVINCENAME";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.PROVINCENAME).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "��")
                {
                    tiaojian = "CITYNAME";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.CITYNAME).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "��")
                {
                    tiaojian = "COUNTYNAME";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.COUNTYNAME).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "����")
                {
                    tiaojian = "TOWNNAME";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.TOWNNAME).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "����")
                {
                    tiaojian = "LONGITUDE";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.LONGITUDE).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "γ��")
                {
                    tiaojian = "LATITUDE";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.LATITUDE).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "Ұ����")
                {
                    tiaojian = "OUTDOORCODE";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.OUTDOORCODE).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "���ڱ��")
                {
                    tiaojian = "INDOORCODE";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.INDOORCODE).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "X")
                {
                    tiaojian = "X";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.X).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "Y")
                {
                    tiaojian = "Y";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.Y).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "Z")
                {
                    tiaojian = "Z";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.Z).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "��в�Ʋ�")
                {
                    tiaojian = "THREATENASSETS";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.THREATENASSETS).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "��в�˿�")
                {
                    tiaojian = "THREATENPEOPLE";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.THREATENPEOPLE).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "�ٻ�����")
                {
                    tiaojian = "DESTROYEDHOME";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.DESTROYEDHOME).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "��·")
                {
                    tiaojian = "DESTROYEDROAD";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.DESTROYEDROAD).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "����")
                {
                    tiaojian = "DESTROYEDCANAL";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.DESTROYEDCANAL).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "���첿λ")
                {
                    tiaojian = "TECTONICREGION";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.TECTONICREGION).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "�ֺ�������")
                {
                    tiaojian = "DISASTERNAME";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.DISASTERNAME).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "�ֺ�����")
                {
                    tiaojian = "UNIFIEDCODE";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.UNIFIEDCODE).Select(r => r.FirstOrDefault()).ToList();
                }
                else if (tiaojian == "����λ��")
                {
                    tiaojian = "LOCATION";
                    data = tbl_hazardbasicinfobll.GetPageListJson2(pagination, tiaojian).ToList();
                    data = data.GroupBy(r => r.LOCATION).Select(r => r.FirstOrDefault()).ToList();
                }
                if (tiaojian == null || tiaojian == "")
                {
                    data = data.ToList();
                }
            }
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
      
     
        /// ��������ͳ���Ų�����
        /// </summary>
        /// <param name="queryJson">
        /// level -�ֺ���ͳ�Ƽ��������ܴ�ֵ��ʡ��,'��','��'�������򡯣�
        /// type-ͳ������ ��0-�ֺ������ͣ�1-���鼶��
        /// 
        /// sqlWhere  ɸѡ������sql��䣩
        /// TOWN ��   ��������ɸѡ������ö��Ÿ�����
        /// COUNTY ��
        /// CITY ��
        /// PROVINCE ʡ
        /// DISASTERTYPE �ֺ�����
        /// HIDDENDANGER �Ƿ������� 0-��1-�� �ֵ��HIDDENDANGER��
        /// DISASTERLEVEL �ֺ��ȼ� �ֵ��DANGERLEVEL��
        /// DANGERLEVEL ����ȼ�   �ֵ��DISASTERLEVEL��
        /// CURSTABLESTATUS Ŀǰ�ȶ��̶� A-�ȶ� B-�����ȶ�  C-Ǳ�ڲ��ȶ�  D-���ȶ�(�ֵ���CURRENTSTABLESTATUS)
        /// STABLETREND ���չ����  A-�ȶ� B-�����ȶ�  C-Ǳ�ڲ��ȶ�  D-���ȶ� ���ֵ���STABLETREND��
        /// THREATENPEOPLEBEGIN ��в�˿ڿ�ʼ THREATENPEOPLEEND ��в�˿ڽ���
        /// THREATENASSETSBEGIN ��в�Ʋ���ʼ THREATENASSETSEND ��в�Ʋ�����
        /// HIDDENDANGER �Ƿ������� 0-��1-�� �ֵ��HIDDENDANGER��
        /// ISIMPORTANT ��Ҫ������ 0-��1-�� �ֵ��ISIMPORTANT��
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetAnalyseListPC(string queryJson)
        {
            return tbl_hazardbasicinfobll.GetAnalyseListPC(queryJson);
        }
        /// <summary>
        /// ����������ѯ�ֺ��������Ϣ����ҳ��
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">
        /// ��ѯ����
        /// PROVINCE ʡ��ţ�'c1','c2'..��
        /// CITY  �б��
        /// COUNTY �ر��
        /// TOWN ������
        /// PROVINCENAME ʡ���� ģ��ƥ��
        /// CITYNAME ������
        /// COUNTYNAME ������
        /// txt_Key ���ơ���š�λ��ģ��ƥ��
        /// DISASTERNAME �ֺ����� 
        /// UNIFIEDCODE ͳһ���
        /// DISASTERTYPE �ֺ�����
        /// HIDDENDANGER �Ƿ������� 0-��1-�� �ֵ��HIDDENDANGER��
        /// DISASTERLEVEL �ֺ��ȼ� �ֵ��DANGERLEVEL��
        /// DANGERLEVEL ����ȼ�   �ֵ��DISASTERLEVEL��
        /// CURSTABLESTATUS Ŀǰ�ȶ��̶� A-�ȶ� B-�����ȶ�  C-Ǳ�ڲ��ȶ�  D-���ȶ�(�ֵ���CURRENTSTABLESTATUS)
        /// STABLETREND ���չ����  A-�ȶ� B-�����ȶ�  C-Ǳ�ڲ��ȶ�  D-���ȶ� ���ֵ���STABLETREND��
        /// TREATMENTSUGGESTION ���ν��� �ֵ��TREATMENTSUGGESTION��
        /// MONITORSUGGESTION��⽨�� �ֵ��MONITORSUGGESTION��
        /// THREATENPEOPLEBEGIN ��в�˿ڿ�ʼ THREATENPEOPLEEND ��в�˿ڽ���
        /// THREATENASSETSBEGIN ��в�Ʋ���ʼ THREATENASSETSEND ��в�Ʋ�����
        /// DEATHTOLLBEGIN �����˿ڿ�ʼ DEATHTOLLEND �����˿ڽ���
        /// ASSETSLOSEBEGIN �Ʋ���ʧ��ʼ ASSETSLOSEEND �Ʋ���ʧ����
        /// PROJECTID ��Ŀ���
        /// ISXH �Ƿ����� 0-δ���� 1-����
        /// YEAR ��ѯ���
        /// PROJECTTYPE ��Ŀ����(���顢�Ų�)
        /// </param>
        /// <param name="condition">
        /// WKTString:�յ����� POLYGON((119.76735720875 35.15413150875,119.76735720875 36.30549869625))
        /// x:���ĵ������
        /// y:���ĵ�������
        /// radius:�뾶(��)
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public object PostPageListJson(QueryJsonEntity entity)
        {
            if (entity.pagination == null)
            {
                entity.pagination = new Pagination();
                entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
                entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
                entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
                entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];
            }
            var watch = CommonHelper.TimerStart();

            var data = tbl_hazardbasicinfobll.GetPageListJsons(entity.pagination, entity.queryJson, entity.condition);

            if (string.IsNullOrEmpty(entity.condition) || entity.condition == "{}")
            {
                var jsonData = new
                {
                    rows = data,
                    total = entity.pagination.total,
                    page = entity.pagination.page,
                    records = entity.pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return jsonData;
            }
            int count = entity.pagination.records;
            var total = count % entity.pagination.rows == 0 ? count / entity.pagination.rows : count / entity.pagination.rows + 1;
            var jsonData1 = new
            {
                rows = data,
                total = total,
                page = entity.pagination.page,
                records = entity.pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData1;
        }
        /// <summary>
        /// ����������ѯ�ֺ��������Ϣ���޲�ѯ������
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public object PostPageListJsonFirst(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];

            var watch = CommonHelper.TimerStart();

            var data = tbl_hazardbasicinfobll.PostPageListJsonFirst(entity.pagination, entity.queryJson, entity.condition);
            int count = entity.pagination.records;
            var total = count % entity.pagination.rows == 0 ? count / entity.pagination.rows : count / entity.pagination.rows + 1;
            var jsonData = new
            {
                rows = data,
                total = total,
                page = entity.pagination.page,
                records = entity.pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// ����ѯ��������Ƿ���ȷ������webͳ��������⣩
        /// </summary>
        /// <param name="sqlWhere">��ѯ�������</param>
        /// <returns></returns>
        [HttpGet]
        public WebApiResult CheckExpression(string sqlWhere)
        {
            bool result = tbl_hazardbasicinfobll.CheckExpression(sqlWhere);
            if (result)
                return Success("���ͨ��!");
            else
                return Error("������");
        }

        /// <summary>
        /// ����������ѯ�ֺ����������ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_HAZARDBASICINFOEntity GetFormJson(string keyValue)
        {
            var data = tbl_hazardbasicinfobll.GetEntity(keyValue);
            return data;
        }

        /// <summary>
        /// ��ȡ�������ݣ�����webͳ��������ѯ��
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">
        /// ��ѯ����
        /// colmn ������
        /// </param>
        /// <returns>�����б�Json��ֻ���Ѿ��������ݣ���ɸѡȥ�أ�</returns>
        [HttpGet]
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetSinglePageListJson([FromUri]Pagination pagination, string queryJson)
        {
            return tbl_hazardbasicinfobll.GetSinglePageList(pagination, queryJson);
        }


        /// <summary>
        /// ��ȡ�ֺ�����ʷ�����б���ҳ��
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">
        /// ��ѯ����
        /// PROVINCE ʡ��ţ�'c1','c2'..��
        /// CITY  �б��
        /// COUNTY �ر��
        /// TOWN ������
        /// PROJECTID ��Ŀ���� �ֵ�� JYGC_PROJECTBASEINFO-PROJECTGUID
        /// MODIFYTYPE �������� U-���� A-����  D-���� I-��������
        /// shifouhexiao �Ƿ��Ѿ����� 0-�� 1-��
        /// ISZLGCPNT �Ƿ������� 0-�� 1-��
        /// RELOCATION �Ƿ��Ǩ���� 0-�� 1-��
        /// BeginTime ��ʼʱ��
        /// EndTime ����ʱ��
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public object GetPastPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_hazardbasicinfobll.GetPastPageListJson(pagination, queryJson);
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
        /// ��ȡ�ֺ�����ʷ���ݲ�ѯ�б�����ҳ���ڵ�ͼ�󶨣�
        /// </summary>
        /// <param name="queryJson">
        /// ��ѯ����
        /// PROVINCE ʡ��ţ�'c1','c2'..��
        /// CITY  �б��
        /// COUNTY �ر��
        /// TOWN ������
        /// PROJECTID ��Ŀ���� �ֵ�� JYGC_PROJECTBASEINFO-PROJECTGUID
        /// MODIFYTYPE �������� U-���� A-����  D-���� I-��������
        /// shifouhexiao �Ƿ��Ѿ����� 0-�� 1-��
        /// ISZLGCPNT �Ƿ������� 0-�� 1-��
        /// RELOCATION �Ƿ��Ǩ���� 0-�� 1-��
        /// BeginTime ��ʼʱ��
        /// EndTime ����ʱ��
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<PastHAZARDBASICINFO> GetPastListJson(string queryJson, string condition)
        {
            return tbl_hazardbasicinfobll.GetPastListJson(queryJson, condition);
        }


        #region ��ʷ���ݲ�ѯ�ӿ�  ��2019-1-12 by wc  �ײ���Ҫ�Ż�,2019-2-14 by wc ��ͨ����ͼ�Ż����ռ��ѯ�����⣩

        /// <summary>
        /// ��ȡ���һ���ֺ�����ʷ�����б���ҳ��
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">
        /// ��ѯ����
        /// PROVINCE ʡ��ţ�'c1','c2'..��
        /// CITY  �б��
        /// COUNTY �ر��
        /// TOWN ������
        /// PROJECTID ��Ŀ���� �ֵ�� JYGC_PROJECTBASEINFO-PROJECTGUID
        /// MODIFYTYPE �������� U-���� A-����  D-���� I-��������
        /// shifouhexiao �Ƿ��Ѿ����� 0-�� 1-��
        /// ISZLGCPNT �Ƿ������� 0-�� 1-��
        /// RELOCATION �Ƿ��Ǩ���� 0-�� 1-��
        /// BeginTime ��ʼʱ��
        /// EndTime ����ʱ��
        /// </param>
        /// <param name="condition">�ռ��ѯ����</param>
        /// <returns></returns>
        [HttpGet]
        public object GetSinglePastPageListJson([FromUri]Pagination pagination, string queryJson, string condition)
        {
            var watch = CommonHelper.TimerStart();
            //var data = tbl_hazardhistorybll.GetPageList(pagination, queryJson, condition);
            IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> data = null;
            if (string.IsNullOrEmpty(condition) || condition == "{}")
            {
                data = tbl_hazardhistorybll.GetPageList(pagination, queryJson, condition);
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
                data = tbl_hazardhistorybll.GetList(queryJson, condition);
                pagination.records = data.Count();
                return data.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
            }
            //pagination.records = result.Count();
            //return result.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
        }

        /// <summary>
        /// ��ȡ���һ���ֺ�����ʷ���ݲ�ѯ�б�����ҳ���ڵ�ͼ�󶨣�
        /// </summary>
        /// <param name="queryJson">
        /// ��ѯ����
        /// PROVINCE ʡ��ţ�'c1','c2'..��
        /// CITY  �б��
        /// COUNTY �ر��
        /// TOWN ������
        /// PROJECTID ��Ŀ���� �ֵ�� JYGC_PROJECTBASEINFO-PROJECTGUID
        /// MODIFYTYPE �������� U-���� A-����  D-���� I-��������
        /// shifouhexiao �Ƿ��Ѿ����� 0-�� 1-��
        /// ISZLGCPNT �Ƿ������� 0-�� 1-��
        /// RELOCATION �Ƿ��Ǩ���� 0-�� 1-��
        /// BeginTime ��ʼʱ��
        /// EndTime ����ʱ��
        /// </param>
        /// <param name="condition">�ռ��ѯ����</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetSinglePastListJson(string queryJson, string condition)
        {
            return tbl_hazardhistorybll.GetList(queryJson, condition);
        }

        #endregion

        #region �����ֺ����ȡ��ʷ���ݵ����е���ʱ���б���Ϣ

        /// <summary>
        /// ��ȡһ����ʷ���ݵ����е���ʱ���б���Ϣ
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetSingleFillListJson(string queryJson)
        {
            return tbl_hazardhistorybll.GetList(queryJson);
        }

        #endregion

        /// <summary>
        /// �����������ӿ������⣩...
        /// </summary>
        /// <param name="queryJson"></param>
        [HttpGet]
        public void ExcelDownloadInfo(string queryJson)
        {
            var dataCount = tbl_hazardbasicinfobll.GetCountAnalyseList(queryJson);

            ExcelHelper.ExcelDownloadOnlyDT(ToDataTable(GetContData(queryJson, dataCount)), "�ֺ���ͳ������", "�ֺ���ͳ������.xls");
        }
        #region 
        [HttpGet]
        public string GetZHDCountResult(string queryJson)
        {
            return tbl_hazardbasicinfobll.GetZHDCountResult(queryJson, 1);
        }
        #endregion

        ///// <summary>
        ///// ��ȡ�ֺ����ͳ������
        ///// </summary>
        ///// <param name="queryJson">��ѯ����</param>
        ///// <returns></returns>
        //[HttpGet]
        //public List<Dictionary<string,string>> GetCountAnalyseList(string queryJson)
        //{
        //    var dataCount = tbl_hazardbasicinfobll.GetCountAnalyseList(queryJson);            

        //    return GetContData(queryJson, dataCount);
        //}

        /// <summary>
        /// ��������ͳ���ֺ�����Ϣ
        /// </summary>
        /// <param name="queryJson">
        /// level -�ֺ���ͳ�Ƽ��������ܴ�ֵ��ʡ��,'��','��'�������򡯣�
        /// type-ͳ������ ��0-�ֺ������ͣ�1-���鼶��
        /// 
        /// sqlWhere  ɸѡ������sql��䣩
        /// TOWN ��   ��������ɸѡ������ö��Ÿ�����
        /// COUNTY ��
        /// CITY ��
        /// PROVINCE ʡ
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetAnalyseList(string queryJson)
        {
            return tbl_hazardbasicinfobll.GetAnalyseList(queryJson);
        }
        [HttpGet]
        public DataTable GetZhdAndCityName()
        {
            return tbl_hazardbasicinfobll.GetZhdAndCityName();
        }
        [HttpGet]
        public bool ValidateSQL(string sql)
        {
            return tbl_hazardbasicinfobll.ValidateSQL(sql);
        }
        [HttpGet]
        public DataTable GetZhdAndProvinceName()
        {
            return tbl_hazardbasicinfobll.GetZhdAndProvinceName();
        }
        //[HttpGet]
        //public DataTable GetHazardCountStatics(string queryJson)
        //{
        //    var monitorpointinfo = (from p in tbl_hazardbasicinfobll.GetList(queryJson) group p by p.CITYNAME into g select new { cityname = g.Key, zhd = g.Count() }).ToList();
        //    DataTable result = new DataTable();
        //    result.Columns.Add("cityname");
        //    result.Columns.Add("zhd");
        //    var CityNames = ws.GetAllByParentCodes("360000");
        //    foreach (var item in CityNames)
        //    {
        //        DataRow row = result.NewRow();
        //        row["cityname"] = item.F_AreaName;
        //        row["zhd"] = 0;
        //        foreach (var itempoint in monitorpointinfo)
        //        {
        //            if (item.F_AreaName == itempoint.cityname)
        //            {
        //                row["zhd"] = itempoint.zhd;
        //            }
        //        }
        //        result.Rows.Add(row);
        //    }
        //    return result;
        //}
        [HttpGet]
        public DataTable GetAnalyseListQCQF(string queryJson)
        {
            return tbl_qcqf_disasterpreventionbll.GetAnalyseListQCQF(queryJson);
        }
        /// <summary>
        /// �ֺ���ͳ�ƣ������ء��ֺ�������|�ֺ�������|����ȼ�|����ȼ� ͳ�ƣ�
        /// </summary>
        /// <param name="type">ͳ�����ͣ�<br/>
        /// DISASTER(�ֺ�������)|DISASTERTYPE(�ֺ�������)|DISASTERLEVEL(����ȼ�)|DANGERLEVEL(����ȼ�)</param>
        /// <returns></returns>
        [HttpGet]
        public object GetHazardStatisticsJson(string type)
        {
            DataTable dt = tbl_hazardbasicinfobll.GetHazardStatisticsJson(type);
            string json = DataHelper.DataTableToJson("result", dt);
            return json.ToJson();
        }
        /// <summary>
        /// ͳ����в����
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetWXRKStatisticsJson(string queryJson)
        {
            DataTable dt = tbl_hazardbasicinfobll.GetWXRKStatisticsJson(queryJson);
            string json = DataHelper.DataTableToJson("result", dt);
            return json.ToJson();
        }
        /// <summary>
        /// ��в�Ʋ�ͳ��
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetWXCCStatisticsJson(string queryJson)
        {
            DataTable dt = tbl_hazardbasicinfobll.GetWXCCStatisticsJson(queryJson);
            string json = DataHelper.DataTableToJson("result", dt);
            return json.ToJson();
        }
        /// <summary>
        /// ����ֺ�����ͳ��(ȫ������)
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByZHLX(string queryJson)
        {
            var result = tbl_hazardbasicinfobll.GetStatisticsByZHLX(queryJson);
            return result;
        }
        /// <summary>
        /// ����ֺ���ͳ��(������/������/���ŵ�)
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetHistoryStatisticsZHD(string queryJson)
        {
            EchartEntity returnValue = new EchartEntity();
            var result = tbl_hazardbasicinfobll.GetHistoryStatisticsZHD(queryJson, ref  returnValue);
            //var s=new { returnValue = returnValue, result = result };
            return new { returnValue = returnValue, result = result };
        }
        /// <summary>
        /// ��������ͳ��
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetTypeStatistics(string queryJson)
        {
            var result = tbl_hazardbasicinfobll.GetTypeStatistics(queryJson);
            return result;
        }
        /// <summary>
        /// �ֺ�����ͳ��(����ͼ)
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetStatisticsByZHLX2(string queryJson)
        {
            var result = tbl_hazardbasicinfobll.GetStatisticsByZHLX2(queryJson);
            return result;
        }
        /// <summary>
        /// �����ŵ�ͳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByXH(string queryJson = null)
        {
            var result = tbl_hazardbasicinfobll.GetStatisticsByXH(queryJson);
            return result;
        }

        /// <summary>
        /// �ֺ���ͳ��(���һ����Ŀ)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByZHD(string queryJson = null)
        {
            if (queryJson == null)
            {
                queryJson = "";
            }
            var result = tbl_hazardbasicinfobll.GetStatisticsByZHD(queryJson);
            return result;
        }

        /// <summary>
        /// ������ͳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByZLGC(string queryJson = null)
        {
            var result = tbl_hazardbasicinfobll.GetStatisticsByZLGC(queryJson);
            return result;
        }
        /// <summary>
        /// ��Ǩ����ͳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EchartEntity GetStatisticsByBABR(string queryJson = null)
        {
            var result = tbl_hazardbasicinfobll.GetStatisticsByBQBR(queryJson);
            return result;
        }
        /// <summary>
        /// sso��ҳͳ��
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object SSOGeodisaster(string queryJson)
        {

            //�ֺ���������7���ֺ����͵ķֱ������
            //Ⱥ��Ⱥ������������һ��ֱ������
            //��Ǩ������������Ǩ��������������������
            //����������
            var data = tbl_hazardbasicinfobll.SSOGeodisaster(queryJson);
            return data;
        }
        [HttpGet]
        public object QueryStatistics(string queryJson)
        {

            List<MergedRegionEntity> columnList = new List<MergedRegionEntity>();
            DataTable result = harzardTrendAnalyseBLL.QueryStatistics(queryJson, ref columnList);
            var jsonData = new
            {
                Columns = columnList,
                Data = result
            };
            return jsonData;
        }
        #region ��ȡͳ�����ݲ�ת�����Ӧ�ĸ�ʽ

        List<Dictionary<string, string>> GetContData(string queryJson, List<TBL_HAZARDBASICINFOEntity> dataCount)
        {
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

            List<Dictionary<string, string>> datalist = new List<Dictionary<string, string>>();

            //��ȡ����ʡ��������������
            SSOWebApiWS ws = new SSOWebApiWS(null);

            var shengdata = ws.GetAreaListJson("0").Where(t => (!string.IsNullOrEmpty(Convert.ToString(json.PROVINCE)) ? ((IList)Convert.ToString(json.PROVINCE).Split(',')).Contains(t.F_AreaCode) : true));

            foreach (var shengitme in shengdata)
            {//����ʡ����

                //ʡһ�����ݼ���ڵ�
                datalist.Add(GetDictionaryData(shengitme.F_AreaName, "", "", "", dataCount.Where(t => t.PROVINCE != null && t.PROVINCE.Equals(shengitme.F_AreaCode)).ToList()));

                //��ȡ��������
                var shidata = ws.GetAreaListJson(shengitme.F_AreaCode).Where(t => (!string.IsNullOrEmpty(Convert.ToString(json.CITY)) ? ((IList)Convert.ToString(json.CITY).Split(',')).Contains(t.F_AreaCode) : true));
                foreach (var shiitme in shidata)
                {//����������

                    //��һ�����ݼ���ڵ�
                    datalist.Add(GetDictionaryData("", shiitme.F_AreaName, "", "", dataCount.Where(t => t.CITY != null && t.CITY.Equals(shiitme.F_AreaCode)).ToList()));

                    var xiandata = ws.GetAreaListJson(shiitme.F_AreaCode).Where(t => (!string.IsNullOrEmpty(Convert.ToString(json.COUNTY)) ? ((IList)Convert.ToString(json.COUNTY).Split(',')).Contains(t.F_AreaCode) : true));
                    foreach (var xianitme in xiandata)
                    {//������/������

                        //��/��һ�����ݼ���ڵ�
                        datalist.Add(GetDictionaryData("", "", xianitme.F_AreaName, "", dataCount.Where(t => t.COUNTY != null && t.COUNTY.Equals(xianitme.F_AreaCode)).ToList()));

                        if (!string.IsNullOrEmpty(Convert.ToString(json.COUNTY)))
                        {//ֻ�е�ѡ������/�ص�ʱ��ű�����������ݣ�����������̫��Ҳ������鿴

                            var zhendata = ws.GetAreaListJson(xianitme.F_AreaCode).Where(t => (!string.IsNullOrEmpty(Convert.ToString(json.TOWN)) ? ((IList)Convert.ToString(json.TOWN).Split(',')).Contains(t.F_AreaCode) : true));
                            foreach (var zhenitme in zhendata)
                            {//����������

                                //��һ�����ݼ���ڵ�
                                datalist.Add(GetDictionaryData("", "", "", zhenitme.F_AreaName, dataCount.Where(t => t.TOWN != null && t.TOWN.Equals(zhenitme.F_AreaCode)).ToList()));

                            }
                        }
                    }
                }
            }

            return datalist;
        }



        /// <summary>
        /// ��ȡ������λ�ֺ���صĸ���������ͳ��
        /// </summary>
        /// <param name="sheng">ʡ����</param>
        /// <param name="shi">������</param>
        /// <param name="xian">��������</param>
        /// <param name="zhen">��������</param>
        /// <param name="shujuyuan">����Դ���ֺ�������Ϣ��</param>
        /// <returns></returns>

        Dictionary<string, string> GetDictionaryData(string sheng, string shi, string xian, string zhen, List<TBL_HAZARDBASICINFOEntity> shujuyuan)
        {

            var zidian = dataItemCache.GetDataItemList();

            //List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("ʡ", sheng);
            data.Add("��", shi);
            data.Add("��/��", xian);
            data.Add("��", zhen);
            data.Add("��������", sheng + shi + xian + zhen);

            //�ֺ�����----�����ֺ������ֵ�
            foreach (var item in zidian.Where(t => t.F_EnCode != null && t.F_EnCode.Equals("2")))
            {
                data.Add(item.F_ItemName, shujuyuan.Where(t => t.DISASTERTYPE != null && t.DISASTERTYPE.Equals(item.F_ItemName)).Count().ToString());
            }

            //������
            data.Add("������", shujuyuan.Where(t => t.HIDDENDANGER != null && t.HIDDENDANGER.Equals("1")).Count().ToString());

            //�ֺ��ȼ�----�����ֺ��ȼ��ֵ�
            foreach (var item in zidian.Where(t => t.F_EnCode != null && t.F_EnCode.Equals("3")))
            {
                data.Add("�ֺ�" + item.F_ItemName, shujuyuan.Where(t => t.DISASTERLEVEL != null && t.DISASTERLEVEL.Equals(item.F_ItemValue)).Count().ToString());
            }

            //����ȼ�----��������ȼ��ֵ�
            foreach (var item in zidian.Where(t => t.F_EnCode != null && t.F_EnCode.Equals("4")))
            {
                data.Add("����" + item.F_ItemName, shujuyuan.Where(t => t.DANGERLEVEL != null && t.DANGERLEVEL.Equals(item.F_ItemValue)).Count().ToString());
            }

            //�ȶ���----�����ȶ����ֵ�
            foreach (var item in zidian.Where(t => t.F_EnCode != null && t.F_EnCode.Equals("6")))
            {
                data.Add("�ȶ��̶�" + item.F_ItemName, shujuyuan.Where(t => t.CURSTABLESTATUS != null && t.CURSTABLESTATUS.Equals(item.F_ItemValue)).Count().ToString());
            }

            //���仯----������չ�����ֵ�
            foreach (var item in zidian.Where(t => t.F_EnCode != null && t.F_EnCode.Equals("7")))
            {
                data.Add("��չ����" + item.F_ItemName, shujuyuan.Where(t => t.STABLETREND != null && t.STABLETREND.Equals(item.F_ItemValue)).Count().ToString());
            }


            //ContextD d = new ContextD();
            //d.sheng = sheng;
            //d.shi = shi;
            //d.xian = xian;
            //d.xz = zhen;
            //d.б�� = shujuyuan.Where(t => t.DISASTERTYPE.Equals(dt));
            //d.���� = sheng;
            //d.���� = sheng;
            //d.��ʯ�� = sheng;
            //d.�������� = sheng;
            //d.������� = sheng;
            //d.���ѷ� = sheng;
            ////d.�𻵷��� = sheng;
            ////d.��· = sheng;
            ////d.���� = sheng;
            ////d.��в�˿� = sheng;
            ////d.��в�Ʋ� = sheng;
            //d.Ŀǰ�ȶ��Ժ� = sheng;
            //d.Ŀǰ�ȶ��Խϲ� = sheng;
            //d.Ŀǰ�ȶ��Բ� = sheng;
            //d.����ȶ��Ժ� = sheng;
            //d.����ȶ��Խϲ� = 0;
            //d.����ȶ��Բ� = 0;
            //d.������ = 0;
            //d.������ = 0;

            //d.С������ = 0;
            //d.�������� = 0;
            //d.�������� = 0;
            //d.�ش������� = 0;
            //d.С������ = 0;
            //d.�������� = 0;
            //d.�������� = 0;
            //d.�ش������� = 0;

            return data;
        }

        /// <summary>
        /// ��ֵ����Listת����datatable
        /// </summary>
        /// <param name="data">����Դ</param>
        /// <returns></returns>
        DataTable ToDataTable(List<Dictionary<string, string>> data)
        {

            DataTable dt = new DataTable();

            foreach (var item in data[0].Keys)
            {//ѭ�������
                dt.Columns.Add(new DataColumn(item));
            }
            foreach (var item in data)
            {//��������䵽��
                DataRow dr = dt.NewRow();
                foreach (var ii in item)
                {
                    dr[ii.Key] = ii.Value;
                }
                //��������ӵ�datatable
                dt.Rows.Add(dr);
            }

            return dt;
        }
        #endregion


        #region Ⱥ��Ⱥ��
        /// <summary>
        /// ��ȡ�б�(�ж��Ƿ��������һ��)
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetPageListJsonDISASTERPREVENTION([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = from a in tbl_hazardbasicinfobll.GetPageList(pagination, queryJson)
                       join b in tbl_qcqf_disasterpreventionbll.GetList("") on a.UNIFIEDCODE equals b.UNIFIEDCODE into ab
                       from abi in ab.DefaultIfEmpty()
                       //join c in tbl_qcqf_escunderstandcardbll.GetList("") on a.UNIFIEDCODE equals c.UNIFIEDCODE into abc
                       //from abci in abc.DefaultIfEmpty()
                       //join d in tbl_qcqf_workunderstandcardbll.GetList("") on a.UNIFIEDCODE equals d.UNIFIEDCODE into abcd
                       //from abcdi in abcd.DefaultIfEmpty()
                       select new
                       {
                           a.UNIFIEDCODE,
                           a.DISASTERNAME,
                           a.DISASTERTYPE,
                           a.LOCATION,
                           a.DISASTERLEVEL,
                           a.DANGERLEVEL,
                           DISASTERPREVENTION = abi == null ? string.Empty : abi.UNIFIEDCODE,
                           //ESCUNDERSTANDCARD = abci == null ? string.Empty : abci.UNIFIEDCODE,
                           //WORKUNDERSTANDCARD = abcdi == null ? string.Empty : abcdi.UNIFIEDCODE
                       };
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
        /// ��ȡ�б�(Ⱥ��Ⱥ����ѯ���)
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetPageListJsonQCQFSearch([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = from a in tbl_qcqf_disasterpreventionbll.GetPageList(pagination, "")
                       join b in tbl_hazardbasicinfobll.GetList(queryJson) on a.UNIFIEDCODE equals b.UNIFIEDCODE
                       where b.UNIFIEDCODE != null
                       select b;
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
        /// ��ȡ�б�(Ⱥ��Ⱥ����ѯ���)
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetPageListJsonQCQFSearchs([FromUri]Pagination pagination, string queryJson, string condition)
        {
            var watch = CommonHelper.TimerStart();

            //var data = from a in tbl_hazardbasicinfobll.GetPageList(pagination, queryJson)
            //           join b in tbl_qcqf_disasterpreventionbll.GetList("") on a.UNIFIEDCODE equals b.UNIFIEDCODE
            //           select new
            //           {
            //               a.UNIFIEDCODE,
            //               a.DISASTERNAME,
            //               a.DISASTERTYPE,
            //               a.LOCATION,
            //               a.DISASTERLEVEL,
            //               a.DANGERLEVEL,
            //               a.CITY,
            //               a.CITYNAME,
            //               a.COUNTY,
            //               a.COUNTYNAME,
            //               a.TOWN,
            //               a.TOWNNAME,

            //           };
            //var data = from a in tbl_qcqf_disasterpreventionbll.GetPageList(pagination, "")
            //           join b in tbl_hazardbasicinfobll.GetList(queryJson) on a.UNIFIEDCODE equals b.UNIFIEDCODE
            //           where b.UNIFIEDCODE != null
            //           select b;

            //dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;          
            //#endregion
            //�ֺ�������
            //string DISASTERNAME = json.DISASTERNAME;
            //if (!string.IsNullOrEmpty(DISASTERNAME))
            //{
            //    data = data.Where(t => t.DISASTERNAME.Trim().Contains(DISASTERNAME.Trim()));
            //}
            ////�ֺ�������
            //string DISASTERTYPE = json.DISASTERTYPE;
            //if (!string.IsNullOrEmpty(DISASTERTYPE))
            //{
            //    data = data.Where(t => t.DISASTERTYPE.Trim().Contains(DISASTERTYPE.Trim()));
            //}

            ////�ֺ�����
            //string UNIFIEDCODE = json.UNIFIEDCODE;
            //if (!string.IsNullOrEmpty(UNIFIEDCODE))
            //{
            //    data = data.Where(t => t.UNIFIEDCODE.Trim().Contains(UNIFIEDCODE.Trim()));
            //}
            var data = tbl_hazardbasicinfobll.GetPageListJsonQCQFSearch(pagination, queryJson, condition);
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
        /// ��ȡ�б�(Ⱥ��Ⱥ����ѯ���)
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetPageListJsonQCQFSearchNew([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            List<TBL_QCQF_Entity> result = new List<TBL_QCQF_Entity>();
            //var data = from a in tbl_hazardbasicinfobll.GetList(queryJson)
            //           join b in tbl_qcqf_disasterpreventionbll.GetList(queryJson) on a.UNIFIEDCODE.Trim() equals b.UNIFIEDCODE.Trim()
            //           select new
            //           {
            //               a.UNIFIEDCODE,
            //               a.DISASTERNAME,
            //               a.DISASTERTYPE,
            //               a.LOCATION,
            //               a.PROVINCE,
            //               a.PROVINCENAME,
            //               a.CITY,
            //               a.CITYNAME,
            //               a.COUNTY,
            //               a.COUNTYNAME,
            //               a.TOWN,
            //               a.TOWNNAME,
            //               b.MONITORRESPONSIBLE,
            //               b.MONITORRESPONSIBLETEL,
            //               b.GROUPMONITORINGSTAFF,
            //               b.GROUPMONITORINGSTAFFTEL,
            //           };
            //result = data.ToList().Select(u => new TBL_QCQF_Entity { UNIFIEDCODE = u.UNIFIEDCODE, DISASTERNAME = u.DISASTERNAME, DISASTERTYPE = u.DISASTERTYPE, LOCATION = u.LOCATION, PROVINCE = u.PROVINCE, PROVINCENAME = u.PROVINCENAME, CITY = u.CITY, CITYNAME = u.CITYNAME, COUNTY = u.COUNTY, COUNTYNAME = u.COUNTYNAME, TOWN = u.TOWN, TOWNNAME = u.TOWNNAME, MONITORRESPONSIBLE = u.MONITORRESPONSIBLE, MONITORRESPONSIBLETEL = u.MONITORRESPONSIBLETEL, GROUPMONITORINGSTAFF = u.GROUPMONITORINGSTAFF, GROUPMONITORINGSTAFFTEL = u.GROUPMONITORINGSTAFFTEL }).ToList();
            ////RepositoryFactory<TBL_QCQF_Entity> s =new 
            ////var datas = s.BaseRepository().(pagination);
            //pagination.records = result.Count();
            //var datas = result.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows).AsQueryable();
            var sql = @"select a.UNIFIEDCODE,a.DISASTERNAME,a.DISASTERTYPE,a.LOCATION,
a.PROVINCE,a.PROVINCENAME,a.CITY,a.CITYNAME,a.COUNTY,a.COUNTYNAME,a.TOWN,a.TOWNNAME,
b.MONITORRESPONSIBLE,b.MONITORRESPONSIBLETEL,b.GROUPMONITORINGSTAFF,b.GROUPMONITORINGSTAFFTEL
 from tbl_hazardbasicinfo a  
                       inner join  TBL_QCQF_DISASTERPREVENTION b 
                       on a.unifiedcode =b.unifiedcode  ";
            var datas = tbl_hazardbasicinfobll.GetPageListJsonQCQFSearch_MarkerByInfo(pagination, queryJson, "", sql);
            var jsonData = new
            {
                rows = datas,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// ��ȡ�ֺ����б�(Ⱥ��Ⱥ���������)
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetPageListJsonQCQFSearchZHD([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            //var data = from a in tbl_qcqf_disasterpreventionbll.GetPageList(pagination, queryJson)
            //           join b in tbl_hazardbasicinfobll.GetList(queryJson) on  a.UNIFIEDCODE equals b.UNIFIEDCODE
            //           //where b.UNIFIEDCODE != null
            //           select b;

            var sql = @"select a.UNIFIEDCODE,a.DISASTERNAME,a.DISASTERTYPE,a.LOCATION,
a.PROVINCE,a.PROVINCENAME,a.CITY,a.CITYNAME,a.COUNTY,a.COUNTYNAME,a.TOWN,a.TOWNNAME,a.LONGITUDE,a.LATITUDE,
b.MONITORRESPONSIBLE,b.MONITORRESPONSIBLETEL,b.GROUPMONITORINGSTAFF,b.GROUPMONITORINGSTAFFTEL
 from tbl_hazardbasicinfo a  
                       inner join  TBL_QCQF_DISASTERPREVENTION b 
                       on a.unifiedcode =b.unifiedcode  ";
            var data = tbl_hazardbasicinfobll.GetPageListJsonQCQFSearch_MarkerByInfo(pagination, queryJson, "", sql);
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
        /// �ų����Ѵ���Ⱥ��Ⱥ�����ݵ��ֺ���
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetPageListJsonNoQCQF(string queryJson, [FromUri]Pagination pagination, string condition = null)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_hazardbasicinfobll.GetPageListJsonNoQCQF(queryJson, condition, pagination);
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
        /// ����UNIFIEDCODE��ѯ�ֺ����������ϸ��Ϣ
        /// </summary>
        /// <param name="UNIFIEDCODE"></param>
        /// <returns></returns>
        [HttpGet]
        public TBL_HAZARDBASICINFOEntity GetUNIFIEDCODEEntity(string UNIFIEDCODE)
        {
            var data = tbl_hazardbasicinfobll.GetUNIFIEDCODEEntity(UNIFIEDCODE);
            return data;
        }
        /// <summary>
        /// ��ȡ�б�(Ⱥ��Ⱥ����ѯ���)������ͼ��ѡ
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpPost]
        public object PostPageListJsonQCQFSearch(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];
            var watch = CommonHelper.TimerStart();
            //var data = from a in tbl_qcqf_disasterpreventionbll.GetPageList(entity.pagination, "")
            //           join b in tbl_hazardbasicinfobll.GetLists(entity.queryJson, entity.condition) on a.UNIFIEDCODE equals b.UNIFIEDCODE
            //           where b.UNIFIEDCODE != null
            //           select b;
            //int count = entity.pagination.records;
            //var total = count % entity.pagination.rows == 0 ? count / entity.pagination.rows : count / entity.pagination.rows + 1;
            var data = tbl_hazardbasicinfobll.GetPageListJsonQCQFSearch(entity.pagination, entity.queryJson, entity.condition);
            var jsonData = new
            {
                rows = data,
                total = entity.pagination.total,
                page = entity.pagination.page,
                records = entity.pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// ��ȡ�б�(Ⱥ��Ⱥ����ѯ���)������ͼ��ѡ
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpPost]
        public object PostPageListJsonQCQFSearchNew(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];
            var watch = CommonHelper.TimerStart();
            //List<TBL_QCQF_Entity> result = new List<TBL_QCQF_Entity>();
            //var data = from a in tbl_hazardbasicinfobll.GetZYPageList(entity.queryJson, entity.condition)
            //           join b in tbl_qcqf_disasterpreventionbll.GetList(entity.queryJson) on a.UNIFIEDCODE.Trim() equals b.UNIFIEDCODE.Trim()
            //           select new
            //           {
            //               a.UNIFIEDCODE,
            //               a.DISASTERNAME,
            //               a.DISASTERTYPE,
            //               a.LOCATION,
            //               a.PROVINCE,
            //               a.PROVINCENAME,
            //               a.CITY,
            //               a.CITYNAME,
            //               a.COUNTY,
            //               a.COUNTYNAME,
            //               a.TOWN,
            //               a.TOWNNAME,
            //               b.MONITORRESPONSIBLE,
            //               b.MONITORRESPONSIBLETEL,
            //               b.GROUPMONITORINGSTAFF,
            //               b.GROUPMONITORINGSTAFFTEL,
            //           };
            //result = data.ToList().Select(u => new TBL_QCQF_Entity { UNIFIEDCODE = u.UNIFIEDCODE, DISASTERNAME = u.DISASTERNAME, DISASTERTYPE = u.DISASTERTYPE, LOCATION = u.LOCATION, PROVINCE = u.PROVINCE, PROVINCENAME = u.PROVINCENAME, CITY = u.CITY, CITYNAME = u.CITYNAME, COUNTY = u.COUNTY, COUNTYNAME = u.COUNTYNAME, TOWN = u.TOWN, TOWNNAME = u.TOWNNAME, MONITORRESPONSIBLE = u.MONITORRESPONSIBLE, MONITORRESPONSIBLETEL = u.MONITORRESPONSIBLETEL, GROUPMONITORINGSTAFF = u.GROUPMONITORINGSTAFF, GROUPMONITORINGSTAFFTEL = u.GROUPMONITORINGSTAFFTEL }).ToList();
            //entity.pagination.records = result.Count();
            //var datas = result.Skip((entity.pagination.page - 1) * entity.pagination.rows).Take(entity.pagination.rows).AsQueryable();                 
            var sql = @"select a.UNIFIEDCODE,a.DISASTERNAME,a.DISASTERTYPE,a.LOCATION,
a.PROVINCE,a.PROVINCENAME,a.CITY,a.CITYNAME,a.COUNTY,a.COUNTYNAME,a.TOWN,a.TOWNNAME,a.LONGITUDE,a.LATITUDE,
b.MONITORRESPONSIBLE,b.MONITORRESPONSIBLETEL,b.GROUPMONITORINGSTAFF,b.GROUPMONITORINGSTAFFTEL
 from tbl_hazardbasicinfo a  
                       inner join  TBL_QCQF_DISASTERPREVENTION b 
                       on a.unifiedcode =b.unifiedcode  ";
            var datas = tbl_hazardbasicinfobll.GetPageListJsonQCQFSearch_MarkerByInfo(entity.pagination, entity.queryJson, entity.condition, sql);
            var jsonData = new
            {
                rows = datas,
                total = entity.pagination.total,
                page = entity.pagination.page,
                records = entity.pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }

        /// <summary>
        /// ��ȡ�б�(Ⱥ��Ⱥ����ѯ���)
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetListJsonQCQFSearch(string queryJson)
        {
            var data = from a in tbl_qcqf_disasterpreventionbll.GetList("")
                       join b in tbl_hazardbasicinfobll.GetList(queryJson) on a.UNIFIEDCODE equals b.UNIFIEDCODE
                       where b.UNIFIEDCODE != null
                       select b;

            return data;
        }

        /// <summary>
        /// ɾ������һ������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveFormTwo(SingleParam param)
        {
            tbl_qcqf_disasterpreventionbll.RemoveForm(param.KeyValue);
            tbl_qcqf_workunderstandcardbll.RemoveForm((param.KeyValue));
            var watch = CommonHelper.TimerStart();
            //ͨ���ֺ����Ų�ѯ�������׿�����ֵ����ɾ��(�������׿�һ���ֺ����Ŷ�Ӧ���guid)
            parmes P = new parmes();
            P.UNIFIEDCODE = param.KeyValue;
            string queryJson = JsonConvert.SerializeObject(P);
            var data = tbl_qcqf_escunderstandcardbll.GetEntity2(queryJson).ToList();
            foreach (var i in data)
            {
                tbl_qcqf_escunderstandcardbll.RemoveForm(i.GUID.ToString());
            }
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ɾ���������׿�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveFormThree(SingleParam param)
        {
            tbl_qcqf_escunderstandcardbll.RemoveForm((param.KeyValue));
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// �������׿���ѯ
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetPageListJsonEscunderstandcardSearch([FromUri]Pagination pagination, string queryJson)
        {
            // var obj = queryJson.ToJObject();
            //string UNIFIEDCODE = obj.GetValue("UNIFIEDCODE").ToString();//ȡ��queryJson�е�ĳһ��ֵ
            var watch = CommonHelper.TimerStart();
            var data = tbl_qcqf_escunderstandcardbll.GetPageList(pagination, queryJson);
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
        /// ͨ���ֺ����Ų�ѯ�������׿�
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public TBL_QCQF_WORKUNDERSTANDCARDEntity WORKUNDERSTANDSearch(string keyValue)
        {
            var data = tbl_qcqf_workunderstandcardbll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// ��������������޸ģ�
        /// ֱ�Ӳ�������Ԥ����͹������׿�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult QCQFSaveForm([FromBody] parmes par)
        {
            if (!string.IsNullOrWhiteSpace(par.entity.UNIFIEDCODE.ToString()))
            {
                tbl_qcqf_disasterpreventionbll.SaveForm(par.keyValue, par.entity);
                par.entity2.UNIFIEDCODE = par.entity.UNIFIEDCODE;
                tbl_qcqf_workunderstandcardbll.SaveForm(par.keyValue, par.entity2);
                var a = par.entity.GUID;
                var b = par.entity2.GUID;
                return Success("�����ɹ���", new { a, b });
            }
            else
            {
                return Success("����ʧ�ܣ��ֺ������Ʋ���Ϊ��");
            }

        }
        /// <summary>
        /// ��������������޸ģ�
        /// �����������׿�
        /// </summary>
        /// <param name="keyValue">����ֵ(GUID)</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public TBL_QCQF_ESCUNDERSTANDCARDEntity QCQFSaveForm2([FromBody] parmes par)
        {
            //DateTime dt = DateTime.Now;
            //var year = dt.Year.ToString();
            //if (par.entity3.AGE1 != null)
            //{
            //    par.entity3.AGE1 = year - par.entity3.AGE1.ToString();
            //}
            var data = tbl_qcqf_escunderstandcardbll.SaveForm(par.keyValue, par.entity3);
            // TBL_QCQF_ESCUNDERSTANDCARDEntity entites = GetFormJson3(par.entity3.GUID);
            return data;
            //return Success("�����ɹ���");
        }
        /// <summary>
        /// ��ȡ����Ԥ����ʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_QCQF_DISASTERPREVENTIONEntity GetFormJson2(string keyValue)
        {
            var data = tbl_qcqf_disasterpreventionbll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// ��ȡ�������׿�ʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ(guid)</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_QCQF_ESCUNDERSTANDCARDEntity GetFormJson3(string keyValue)
        {
            var data = tbl_qcqf_escunderstandcardbll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// �������׿���ѯ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// ��ѯ����:
        /// UNIFIEDCODE �ֺ�����
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetJsonEscunderstandcardSearch(string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_qcqf_escunderstandcardbll.GetEntity2(queryJson);
            var jsonData = new
            {
                rows = data,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }

        #endregion
        #region ��ҳͳ����չ
        /// <summary>
        /// ��ȡ�ֵ���ͳ�ƽ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetDicAnalyse(string enCode)
        {
            return tbl_hazardbasicinfobll.GetDicAnalyse(enCode);
        }
        #endregion
        #endregion

        #region ����ϵͳ����ͳ�ƽӿ�
        /// <summary>
        /// ��ȡ�ֺ�������
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetAllListJson()
        {
            var hazard = tbl_hazardbasicinfobll.GetAllList();
            return hazard;
        }
        /// <summary>
        /// �ֺ���ͳ��ֻ���ֺ�����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetHazardStatisticsJson2(string queryJson)
        {
            DataTable dt = tbl_hazardbasicinfobll.GetHazardStatisticsJson2(queryJson);
            string json = DataHelper.DataTableToJson("result", dt);
            return json.ToJson();
        }
        /// <summary>
        /// �ӿ�����ͳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetAllAPIJson()
        {
            int count = 0;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type t in types)
            {
                var s = t.BaseType.ToString().Contains("ApiControllerBase");
                if (s)
                {
                    MethodInfo[] pi = t.GetMethods();
                    foreach (var p in pi)
                    {
                        if (p.GetCustomAttributes(typeof(HttpGetAttribute), true).Count() > 0 || p.GetCustomAttributes(typeof(HttpPostAttribute), true).Count() > 0)
                            count++;
                    }
                }
            }
            return count;
        }
        /// <summary>
        /// ��ȡ��ͼժҪ��Ϣ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <param name="condition">��ѡ����(���Բ���)
        /// WKTString:�յ����� POLYGON((119.76735720875 35.15413150875,119.76735720875 36.30549869625))
        /// x:���ĵ������
        /// y:���ĵ�������
        /// radius:�뾶(��)
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public object GetZYListJson(string queryJson, string condition = null)
        {
            var data = tbl_hazardbasicinfobll.GetZYPageList(queryJson, condition);
            return data;
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="param">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm(string KeyValue)
        {
            tbl_hazardbasicinfobll.RemoveForm(KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_HAZARDBASICINFOEntity entity)
        {
            tbl_hazardbasicinfobll.SaveForm(keyValue, entity);
            return Success("�����ɹ���", entity.GUID);
        }

        #endregion

 #region ����Excel����

        /// <summary>
        /// Ԥ��Excel����
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object ViewExcelData()
        {
            try
            {
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                if (files.Count > 0)
                {
                    var file = files[0];
                    string dir = HttpContext.Current.Server.MapPath("/Temp");
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string filePath = Path.Combine(dir, Guid.NewGuid().ToString() + file.FileName);
                    file.SaveAs(filePath);
                    //��ȡģ���ļ�,�������
                    List<string> sheetNames = ExcelReader.GetExcelSheetName(filePath);
                    DataSet ds = new DataSet();
                    for (int i = sheetNames.Count - 1; i >= 0; i--)
                    {
                        if (sheetNames[i].IndexOf("FilterDatabase") > 0)
                            continue;
                        DataTable dt = ExcelReader.GetExcelContext(filePath, sheetNames[i]);
                        dt.TableName = sheetNames[i];
                        
                        //�����ʾ100��
                        if (dt.Rows.Count > 100)
                        {
                            DataTable clone = dt.Clone();
                            for (int row = 0; row < 100; row++)
                            {
                                clone.Rows.Add(dt.Rows[row].ItemArray);
                            }
                            ds.Tables.Add(clone);
                        }
                        else
                        {
                            ds.Tables.Add(dt.Copy());
                        }
                    }
                    File.Delete(filePath);
                    return ds;
                }
                else
                {
                    return Error("��ѡ����Ҫ�ϴ����ļ���");
                }
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        /// <summary>
        /// ����Excelģ������
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult ImportExcelData()
        {
            try
            {
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                if (files.Count > 0)
                {
                    var file = files[0];
                    string dir = HttpContext.Current.Server.MapPath("/Temp");
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string filePath = Path.Combine(dir, Guid.NewGuid().ToString() + file.FileName);
                    file.SaveAs(filePath);
                    //��ȡģ���ļ�,�������
                    string sheetName = HttpContext.Current.Request.QueryString["SheetName"];
                    DataTable dt = ExcelReader.GetExcelContext(filePath, sheetName + "$");
                    //����ͳһ�������-���б�ŵ���ǰ
                    dt.DefaultView.Sort = "UNIFIEDCODE ASC";
                    dt = dt.DefaultView.ToTable();

                    if (!dt.Columns.Contains("PROVINCE"))
                    dt.Columns.Add("PROVINCE");

                    if (!dt.Columns.Contains("CITY"))
                        dt.Columns.Add("CITY");

                    if (!dt.Columns.Contains("COUNTYCODE"))
                        dt.Columns.Add("COUNTYCODE");

                    if (!dt.Columns.Contains("TOWN"))
                        dt.Columns.Add("TOWN");

                    if (!dt.Columns.Contains("LOCATION"))
                        dt.Columns.Add("LOCATION");

                    int total = dt.Rows.Count;
                    int success = 0;

                    codeNames = ws.GetCodeNames();
                    List<string> errorRow = new List<string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            SaveRowData(row);
                            success++;
                        }
                        catch (Exception ex)
                        {
                            errorRow.Add(row["NO"].ToString());
                            Logger.Error(ex.Message);
                        }
                    }
                    File.Delete(filePath);
                    return Success(string.Format("��������ֺ�{0}������,�ɹ�{1}����ʧ��{2}����{3}", total, success, total - success, string.Join(",", errorRow)));

                }
                else
                {
                    return Error("��ѡ����Ҫ�ϴ����ļ���");
                }
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        /// <summary>
        /// �����ش�������Excelģ������
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult ImportExcelZDData()
        {
            try
            {
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                if (files.Count > 0)
                {
                    var file = files[0];
                    string dir = HttpContext.Current.Server.MapPath("/Temp");
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string filePath = Path.Combine(dir, Guid.NewGuid().ToString() + file.FileName);
                    file.SaveAs(filePath);
                    //��ȡģ���ļ�,�������
                    string sheetName = HttpContext.Current.Request.QueryString["SheetName"];
                    DataTable dt = ExcelReader.GetExcelContext(filePath, sheetName + "$");
                    dt.Rows.RemoveAt(0);
                    //�������ݿ����Ѵ��ڱ�ŵĵ�
                    ZDYH zdyh = new ZDYH();
                    zdyh = SearchData(dt);
                    dt = zdyh.data;
                    var nullvalue = string.Join("','", zdyh.list.ToArray());
                    int count = zdyh.list.Count();
                    int total = dt.Rows.Count;
                    int success = 0;
                    List<string> errorRow = new List<string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            SaveRowData2(row);
                            success++;
                        }
                        catch (Exception ex)
                        {
                            errorRow.Add(row["UNIFIEDCODE"].ToString());
                            Logger.Error(ex.Message);
                        }
                    }
                    File.Delete(filePath);
                    return Success(string.Format("�����ش�������:{0}������,�ɹ�:{1}����ʧ��:{2}����{3},δ�ҵ����ϱ�����ݱ��Ϊ:'{4}'", total, success, total - success, string.Join(",", errorRow), nullvalue));

                }
                else
                {
                    return Error("��ѡ����Ҫ�ϴ����ļ���");
                }
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        private T ConvertToEntity<T>(DataRow row) where T : new()
        {
            T t = new T();
            PropertyInfo[] propertys = t.GetType().GetProperties();// ��ô�ģ�͵Ĺ�������
            foreach (PropertyInfo pi in propertys)
            {
                if (row.Table.Columns.Contains(pi.Name))
                {
                    if (!pi.CanWrite) continue;
                    var value = row[pi.Name];
                    try
                    {
                        if (value != DBNull.Value && value != null && value.ToString() != "")
                        {

                            if (pi.PropertyType.FullName.ToUpper().Contains("DECIMAL"))
                            {
                                pi.SetValue(t, decimal.Parse(value.ToString()), null);
                            }
                            else if (pi.PropertyType.FullName.ToUpper().Contains("DOUBLE"))
                            {
                                pi.SetValue(t, double.Parse(value.ToString()), null);
                            }
                            else if (pi.PropertyType.FullName.ToUpper().Contains("INT32"))
                            {
                                //if (value.ToString().Contains("."))
                                //{

                                //}
                                //pi.SetValue(t, int.Parse(value.ToString()), null);
                                pi.SetValue(t, Convert.ToInt32(value.ToString()), null);
                            }
                            else if (pi.PropertyType.FullName.ToUpper().Contains("INT16"))
                            {
                                if (value.ToString().Contains("."))
                                {

                                }
                                pi.SetValue(t, short.Parse(value.ToString()), null);
                            }
                            else if (pi.PropertyType.FullName.ToUpper().Contains("STRING"))
                            {
                                pi.SetValue(t, value.ToString(), null);
                            }
                            else if (pi.PropertyType.FullName.ToUpper().Contains("DATETIME"))
                            {
                                pi.SetValue(t, DateTime.Parse(value.ToString()), null);
                            }
                            else
                                pi.SetValue(t, value, null);
                        }

                    }
                    catch (Exception ex)
                    {
                        //throw ex;
                    }

                }
            }
            return t;
        }

        private void CheckRow(DataRow sourceRow)
        {
            //��������������
           
            string cityName = sourceRow["CITYNAME"].ToString();
            KeyValuePair<string, string> keyValue = codeNames.Where(t => t.Value == cityName).FirstOrDefault();
            sourceRow["CITY"] = sourceRow["CITY"].ToString()==""? keyValue.Key : sourceRow["CITY"];

            sourceRow["PROVINCE"] = sourceRow["PROVINCE"].ToString()==""? (keyValue.Key.Substring(0, 2) + "0000"): sourceRow["PROVINCE"];

            string countyName = sourceRow["COUNTYNAME"].ToString();
            KeyValuePair<string, string> keyValueCounty = codeNames.Where(t => t.Value == countyName).FirstOrDefault();
            sourceRow["COUNTYCODE"] = sourceRow["COUNTYCODE"].ToString()==""? keyValueCounty.Key: sourceRow["COUNTYCODE"];

            sourceRow["LOCATION"] = sourceRow["LOCATION"].ToString()==""?(sourceRow["PROVINCENAME"].ToString() + sourceRow["CITYNAME"].ToString() + sourceRow["COUNTYNAME"].ToString() + sourceRow["TOWNNAME"].ToString() + sourceRow["VILLAGE"].ToString()): sourceRow["LOCATION"];

            //���ͳһ���
            object unifiedCode = sourceRow["UNIFIEDCODE"];
            if (unifiedCode == null || string.IsNullOrEmpty(unifiedCode.ToString()) || (unifiedCode.ToString().Length != 12 && unifiedCode.ToString().Length != 16))
            {
                unifiedCode = (keyValueCounty.Key ?? keyValue.Key) + GetTypeCode(sourceRow["DISASTERTYPE"].ToString()) + new Random().Next(1000, 9999);
                while (distinctCodes.Contains(unifiedCode.ToString()))
                {
                    unifiedCode = (keyValueCounty.Key ?? keyValue.Key) + GetTypeCode(sourceRow["DISASTERTYPE"].ToString()) + new Random().Next(1000, 9999);
                }
                sourceRow["UNIFIEDCODE"] = unifiedCode;
            }
            //16λ�ֺ�����
            else if (unifiedCode.ToString().Length == 16)
            {
                unifiedCode = unifiedCode.ToString().Substring(0, 6) + new Random().Next(10000, 9999) + unifiedCode.ToString().Remove(0, 14);
                while (distinctCodes.Contains(unifiedCode.ToString()))
                {
                    unifiedCode = unifiedCode.ToString().Substring(0, 6) + new Random().Next(10000, 9999) + unifiedCode.ToString().Remove(0, 14);
                }
                sourceRow["UNIFIEDCODE"] = unifiedCode;
            }
            else if (distinctCodes.Contains(unifiedCode.ToString()))
            {
                unifiedCode = unifiedCode.ToString().Substring(0, 8) + new Random().Next(1000, 9999);
                while (distinctCodes.Contains(unifiedCode.ToString()))
                {
                    unifiedCode = unifiedCode.ToString().Substring(0, 8) + new Random().Next(1000, 9999);
                }
                sourceRow["UNIFIEDCODE"] = unifiedCode;
            }
            distinctCodes.Add(unifiedCode.ToString());
        }

        private string GetTypeCode(string disasterType)
        {
            switch (disasterType)
            {
                case "����":
                    return "02";
                case "��������":
                    return "05";
                case "��ʯ��":
                    return "03";
                case "���ѷ�":
                    return "06";
                case "�������":
                    return "04";
                case "����":
                    return "01";
                case "б��":
                    return "00";
                case "����������":
                    return "01";
                case "����������":
                    return "02";
                case "ң�н����":
                    return "07";
                default:
                    return "02";
            }
        }
        private void SaveRowData2(DataRow row)
        {
            string disasterType = row["DISASTERTYPE"].ToString().Trim();
            string OUTDOORCODE = row["OUTDOORCODE"].ToString().Trim();
            string UNIFIEDCODE = row["UNIFIEDCODE"].ToString().Trim();
            string DISASTERNAME = row["DISASTERNAME"].ToString().Trim();
            string LONGITUDE = row["LONGITUDE"].ToString().Trim();
            string LATITUDE = row["LATITUDE"].ToString().Trim();
            string THREATENPEOPLE = row["THREATENPEOPLE"].ToString().Trim();
            string THREATENASSETS = row["THREATENASSETS"].ToString().Trim();
            var str = string.Empty;
            switch (disasterType)
            {
                case "����":
                    str = "TBL_AVALANCHE";
                    break;
                case "��������":
                    str = "TBL_COLLAPSE";
                    break;
                case "��ʯ��":
                    str = "TBL_DEBRISFLOW";
                    break;
                case "���ѷ�":
                    str = "TBL_LANDCRACK";
                    break;
                case "�������":
                    str = " TBL_LANDSETTLEMENT";
                    break;
                case "����":
                    str = " TBL_LANDSLIP";
                    break;
                case "б��":
                    str = " TBL_SLOPE";
                    break;              
                default:                  
                    break;
            }
            var sql = string.Format("UPDATE  {0}   SET  OUTDOORCODE='{1}',LONGITUDE='{2}',LATITUDE='{3}',THREATENPEOPLE='{4}',THREATENASSETS='{5}'  WHERE  UNIFIEDCODE='{6}' " , str,OUTDOORCODE,LONGITUDE,LATITUDE, THREATENPEOPLE, THREATENASSETS, UNIFIEDCODE);
            //�����ֺ�����Ϣ��
            var sql2 = string.Format("UPDATE  {0}  SET  OUTDOORCODE='{1}',LONGITUDE='{2}',LATITUDE='{3}',THREATENPEOPLE='{4}',THREATENASSETS='{5}',ISZDYHD='1'  WHERE  UNIFIEDCODE='{6}' ", "TBL_HAZARDBASICINFO", OUTDOORCODE, LONGITUDE, LATITUDE, THREATENPEOPLE, THREATENASSETS, UNIFIEDCODE);
            tbl_hazardbasicinfobll.UpdateForm(sql);
            tbl_hazardbasicinfobll.UpdateForm(sql2);
        }
        private void SaveRowData(DataRow row)
        {
            CheckRow(row);
            string disasterType = row["DISASTERTYPE"].ToString();
            switch (disasterType)
            {
                case "����":
                    TBL_AVALANCHEBLL olBll = new TBL_AVALANCHEBLL();
                    olBll.SaveForm(string.Empty, ConvertToEntity<TBL_AVALANCHEEntity>(row));
                    break;
                case "��������":
                    TBL_COLLAPSEBLL olBll1 = new TBL_COLLAPSEBLL();
                    olBll1.SaveForm(string.Empty, ConvertToEntity<TBL_COLLAPSEEntity>(row));
                    break;
                case "��ʯ��":
                    TBL_DEBRISFLOWBLL olBll2 = new TBL_DEBRISFLOWBLL();
                    olBll2.SaveForm(string.Empty, ConvertToEntity<TBL_DEBRISFLOWEntity>(row));
                    break;
                case "���ѷ�":
                    TBL_LANDCRACKBLL olBll3 = new TBL_LANDCRACKBLL();
                    olBll3.SaveForm(string.Empty, ConvertToEntity<TBL_LANDCRACKEntity>(row));
                    break;
                case "�������":
                    TBL_LANDSETTLEMENTBLL olBll4 = new TBL_LANDSETTLEMENTBLL();
                    olBll4.SaveForm(string.Empty, ConvertToEntity<TBL_LANDSETTLEMENTEntity>(row));
                    break;
                case "����":
                    TBL_LANDSLIPBLL olBll5 = new TBL_LANDSLIPBLL();
                    olBll5.SaveForm(string.Empty, ConvertToEntity<TBL_LANDSLIPEntity>(row));
                    break;
                case "б��":
                    TBL_SLOPEBLL olBll6 = new TBL_SLOPEBLL();
                    olBll6.SaveForm(string.Empty, ConvertToEntity<TBL_SLOPEEntity>(row));
                    break;
                case "����������":
                    TBL_LANDSLIP_HIDDENBLL olBll7 = new TBL_LANDSLIP_HIDDENBLL();
                    olBll7.SaveForm(string.Empty, ConvertToEntity<TBL_LANDSLIP_HIDDENEntity>(row));
                    break;
                case "����������":
                    TBL_AVALANCHE_HIDDENBLL olBll8 = new TBL_AVALANCHE_HIDDENBLL();
                    olBll8.SaveForm(string.Empty, ConvertToEntity<TBL_AVALANCHE_HIDDENEntity>(row));
                    break;
                case "ң�н����":
                    TBL_SENSEBLL olBll9 = new TBL_SENSEBLL();
                    olBll9.SaveForm(string.Empty, ConvertToEntity<TBL_SENSEEntity>(row));
                    break;
                default:
                    TBL_LANDSLIPBLL olBll10 = new TBL_LANDSLIPBLL();
                    olBll10.SaveForm(string.Empty, ConvertToEntity<TBL_LANDSLIPEntity>(row));
                    break;
            }
        }

        private ZDYH SearchData(DataTable dt)
        {
            ZDYH zdyh = new ZDYH();
            DataTable data = dt.Clone();
            var tablelist = tbl_hazardbasicinfobll.GetValue().ToList();//��ȡ�����ֺ�����������
            List<string> list = new List<string>();
            //���� ������
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow result_dr = data.NewRow();
                var unicode = tablelist.Where(p => p.UNIFIEDCODE.Equals((dt.Rows[i]["UNIFIEDCODE"].ToString()))).Select(p =>p.UNIFIEDCODE).FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(unicode))
                {
                    result_dr["DISASTERTYPE"] = dt.Rows[i]["DISASTERTYPE"].ToString();
                    result_dr["UNIFIEDCODE"] = dt.Rows[i]["UNIFIEDCODE"].ToString();
                    result_dr["OUTDOORCODE"] = dt.Rows[i]["OUTDOORCODE"].ToString();
                    result_dr["DISASTERNAME"] = dt.Rows[i]["DISASTERNAME"].ToString();
                    result_dr["LONGITUDE"] = dt.Rows[i]["LONGITUDE"].ToString();
                    result_dr["LATITUDE"] = dt.Rows[i]["LATITUDE"].ToString();
                    result_dr["THREATENASSETS"] = dt.Rows[i]["THREATENASSETS"].ToString();
                    result_dr["THREATENPEOPLE"] = dt.Rows[i]["THREATENPEOPLE"].ToString();
                    data.Rows.Add(result_dr);
                }
                else
                {
                    list.Add(dt.Rows[i]["UNIFIEDCODE"].ToString());
                }
            }
            zdyh.data = data;
            zdyh.list = list;
            return zdyh;
        }
        public class ZDYH
        {
            public DataTable data { get; set; }
            public List<string> list { get; set; }
        }
        #endregion        /// <summary>
        /// Ⱥ��Ⱥ������/�޸�
        /// </summary>
        public class parmes
        {
            public string keyValue { get; set; }//�ֺ�����(����)
            public string entitys { get; set; }//�ֺ�����(����)
            public string UNIFIEDCODE { get; set; }//�ֺ�����(����)
            public TBL_QCQF_DISASTERPREVENTIONEntity entity { get; set; }//����Ԥ����
            public TBL_QCQF_WORKUNDERSTANDCARDEntity entity2 { get; set; }//�������׿�
            public TBL_QCQF_ESCUNDERSTANDCARDEntity entity3 { get; set; }//�������׿�
        }
    }
}