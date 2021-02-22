using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
using Infoearth.Application.Common;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.Entity;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:27
    /// �� ������������Ϣ��
    /// </summary>
    public class TBL_ZLGC_BASEINFOService : RepositoryFactory<TBL_ZLGC_BASEINFOEntity>, TBL_ZLGC_BASEINFOIService
    {
        private TBL_HAZARDBASICINFOIService hazard = new TBL_HAZARDBASICINFOService();
        private TBL_ZLGC_SGINFOIService ZLGC_SGservice = new TBL_ZLGC_SGINFOService();
        private TBL_ZLGC_YSINFOService TBL_ZLGC_YSINFO = new TBL_ZLGC_YSINFOService();
        private TBL_ZLGC_KCINFOService TBL_ZLGC_KCINFO = new TBL_ZLGC_KCINFOService();
        private TBL_ZLGC_JLINFOService TBL_ZLGC_JLINFO = new TBL_ZLGC_JLINFOService();
        private TBL_ZLGC_SJINFOService TBL_ZLGC_SJINFO = new TBL_ZLGC_SJINFOService();
        private static EchartEntityNEWS _districtsDataCount = null;
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ͼ�ۺ�
        public EchartEntityNEWS GetListCodes()
        {
            _districtsDataCount = (EchartEntityNEWS)CacheHelper.GetCache("�����̾ۺ�");
            EchartEntityNEWS returnValue = new EchartEntityNEWS();
            if (_districtsDataCount == null)
            {
                returnValue = GetListData();
            }
            else
            {
                returnValue = _districtsDataCount;
            }
            return returnValue;
        }

        public EchartEntityNEWS GetListData()
        {
            return null;
            //EchartEntityNEWS returnValue = new EchartEntityNEWS();
            ////��ȡ��ǰ�û���������
            //List<string> _codes = ssoWS.GetAllAuthDistricts();//��ȡ��ǰ�û���������            
            //IList<string> dataItemDetailList = new List<string>() { "����" };
            //if (_codes.Contains("000000"))
            //{
            //    List<ParetEntity> districts2 = ssoWS.GetDistrictByParent("0");
            //    // List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
            //    List<AreaEntity> districts = ssoWS.GetAllDistrictsToCountry().ToList();
            //    List<string> selectXZQH1 = new List<string>();
            //    List<string> selectXZQH2 = new List<string>();
            //    List<string> selectXZQH3 = new List<string>();
            //    //ʡ
            //    returnValue.proviceList = districts2.Select(p => p.DistrictCode).ToList();//������������
            //    returnValue.provicenameList = districts2.Select(p => p.DistrictName).ToList();//������������
            //    returnValue.provicelatitude = districts2.Select(p => p.F_LATITUDE).ToList();
            //    returnValue.provicelongitude = districts2.Select(p => p.F_LONGITUDE).ToList();
            //    selectXZQH1 = districts2.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
            //    string sql1 = searthsql(2, selectXZQH1);
            //    returnValue.provicecount = convertDataTable(this.BaseRepository().FindTable(sql1), dataItemDetailList);
            //    //��  
            //    var selectColumn1 = string.Empty;
            //    returnValue.citynameList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaName).ToList();
            //    returnValue.cityList = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaCode).ToList();
            //    returnValue.citylatitude = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_LATITUDE.ToString()).ToList();
            //    returnValue.citylongitude = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_LONGITUDE.ToString()).ToList();
            //    selectXZQH2 = districts.Where(p => p.F_AreaCode.Substring(4, 2).Contains("00") && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000").Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
            //    string sql2 = searthsql(4, selectXZQH2);
            //    returnValue.citycount = convertDataTable(this.BaseRepository().FindTable(sql2), dataItemDetailList);
            //    //�� 
            //    var selectColumn2 = string.Empty;
            //    returnValue.countynameList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaName).ToList();
            //    returnValue.countyList = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode).ToList();
            //    returnValue.countylatitude = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_LATITUDE.ToString()).ToList();
            //    returnValue.countylongitude = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_LONGITUDE.ToString()).ToList();
            //    selectXZQH3 = districts.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
            //    string sql3 = searthsql(6, selectXZQH3);
            //    returnValue.countycount = convertDataTable(this.BaseRepository().FindTable(sql3), dataItemDetailList);
            //}
            //else
            //{
            //    List<string> selectXZQH1 = new List<string>();
            //    List<string> selectXZQH2 = new List<string>();
            //    List<string> selectXZQH3 = new List<string>();
            //    var DefalutCode = _codes.FirstOrDefault().ToString().Substring(0, 2) + "0000";//��ȡ��ǰʡ����
            //    //ʡ           
            //    List<ParetEntity> districts = ssoWS.GetDistrictByParent("0");
            //    returnValue.proviceList = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictCode).ToList();
            //    returnValue.provicenameList = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.DistrictName).ToList();
            //    returnValue.provicelatitude = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.F_LATITUDE).ToList();
            //    returnValue.provicelongitude = districts.Where(p => p.DistrictCode == DefalutCode).Select(p => p.F_LONGITUDE).ToList();
            //    selectXZQH1 = districts.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
            //    var selectColumn = string.Empty;
            //    string sql1 = searthsql(2, selectXZQH1);
            //    returnValue.provicecount = convertDataTable(this.BaseRepository().FindTable(sql1), dataItemDetailList);
            //    //��
            //    List<ParetEntity> districts1 = ssoWS.GetDistrictByParent(DefalutCode);
            //    returnValue.cityList = districts1.Select(p => p.DistrictCode).ToList();//������������
            //    returnValue.citynameList = districts1.Select(p => p.DistrictName).ToList();//������������
            //    returnValue.citylatitude = districts1.Select(p => p.F_LATITUDE).ToList();//��������γ��
            //    returnValue.citylongitude = districts1.Select(p => p.F_LONGITUDE).ToList();//������������
            //    selectXZQH2 = districts1.Select(p => p.DistrictCode + "," + p.DistrictName).ToList();
            //    string sql2 = searthsql(4, selectXZQH2);
            //    returnValue.citycount = convertDataTable(this.BaseRepository().FindTable(sql2), dataItemDetailList);
            //    //��
            //    var DefalutCodes = _codes.FirstOrDefault().ToString().Substring(0, 2);//��ȡ��ǰʡ����ǰ��λ
            //    List<AreaEntity> districts2 = ssoWS.GetAllDistrictsToCountry().ToList();
            //    //List<AreaEntity> districts2 = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
            //    returnValue.countynameList = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_AreaName).ToList();
            //    returnValue.countyList = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_AreaCode).ToList();
            //    returnValue.countylatitude = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_LATITUDE.ToString()).ToList();
            //    returnValue.countylongitude = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6 && p.F_AreaCode.Substring(0, 2) == DefalutCodes).Select(p => p.F_LONGITUDE.ToString()).ToList();
            //    selectXZQH3 = districts2.Where(p => p.F_AreaCode.Substring(4, 2) != "00" && p.F_AreaCode.Substring(2, 4) != "0000" && p.F_AreaCode != "000000" && p.F_AreaCode.Length == 6).Select(p => p.F_AreaCode + "," + p.F_AreaName).ToList();
            //    string sql3 = searthsql(6, selectXZQH3);
            //    returnValue.countycount = convertDataTable(this.BaseRepository().FindTable(sql3), dataItemDetailList);
            //}
            //string sql = "select *  from TBL_ZLGC_BASEINFO ";
            //if (!_codes.Contains("000000"))
            //{
            //    sql += " where SUBSTR(UNIFIEDCODE,0,6)  in('" + string.Join("','", _codes.ToArray()) + "') ";
            //}
            //returnValue.data = this.BaseRepository().FindTable(sql);
            //CacheHelper.SetCache("�����̾ۺ�", returnValue);//д����
            //return returnValue;
        }
        private string searthsql(int sub, List<string> selectXZQH)
        {
            string sql = string.Empty;
            string groupBy = string.Format(" {0} ", DbSqlFunctionHelper.SubString("UNIFIEDCODE", 0, sub));
            foreach (var item in selectXZQH)
            {
                var code = item.Split(',')[0];
                var name = item.Split(',')[1];
                sql += string.Format(" ,sum(case when {1}='{0}' then 1 else 0 end) \"{2}\" ", code.Substring(0, sub), groupBy, code);
            }
            string sql2 = string.Format("select  '{0}' name {1} from  TBL_ZLGC_BASEINFO  where 1=1 ", "����", sql);
            return sql2;
        }
        private IList<dataEntity> convertDataTable(DataTable dt, IList<string> dataItemDetailList)
        {
            //���������������
            for (int i = 0; i < dataItemDetailList.Count; i++)
            {
                if (dt.Select("name ='" + dataItemDetailList[i] + "'").Count() == 0)
                {
                    DataRow addDR = dt.NewRow();
                    addDR["name"] = dataItemDetailList[i];
                    for (int columnIndex = 1; columnIndex < dt.Columns.Count; columnIndex++)
                    {
                        addDR[columnIndex] = "0";
                    }
                    dt.Rows.InsertAt(addDR, i);
                }
            }
            IList<dataEntity> list = new List<dataEntity>();
            IList<string> listRow = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                listRow.Add(dr["name"].ToString());
            }
            dt.Columns.Remove("name");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new dataEntity()
                {
                    name = listRow[i],
                    data = dt.Rows[i].ItemArray
                });
            }
            return list;
        }
        #endregion
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_BASEINFOEntity>();
            return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);
        }

        /// <summary>
        /// ��ȡ�б���Ϣ������ҳ
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetListS(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_BASEINFOEntity>();
            return this.BaseRepository().FindList(queryJsonExpression(queryJson));
        }
        /// <summary>
        /// ��ȡ��ͼժҪ��Ϣ��ѯ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>����ָ���ֶ�</returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZYPageList(string queryJson, string condition)
        {

            try
            {
                var queryParam = condition.ToJObject();
                var expression = queryJsonExpression(queryJson);
                List<TBL_ZLGC_BASEINFOEntity> result = new List<TBL_ZLGC_BASEINFOEntity>();
                var list = this.BaseRepository().FindList(expression).Select(t => new TBL_ZLGC_BASEINFOEntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID, ZLGCNAME = t.ZLGCNAME, MODIFYTIME = t.MODIFYTIME == null ? Convert.ToDateTime("1970-01-01") : t.MODIFYTIME }).ToList();
                if (!queryParam["WKTString"].IsEmpty())
                {
                    string WKTString = queryParam["WKTString"].ToString();
                    foreach (var item in list)
                    {
                        if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                        {
                            continue;
                        }

                        bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                        if (isInsert)
                        {
                            result.Add(item);
                        }

                    }
                    return result;
                }
                if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
                {
                    double x = queryParam["x"].ToDouble();
                    double y = queryParam["y"].ToDouble();
                    double radius = queryParam["radius"].ToDouble();
                    foreach (var item in list)
                    {
                        if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                        {
                            continue;
                        }

                        bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                        if (isInsert)
                        {
                            result.Add(item);
                        }

                    }
                    return result;
                }
                if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
                {
                    string polyline = queryParam["polyline"].ToString();
                    double radius = queryParam["radius"].ToDouble();
                    foreach (var item in list)
                    {
                        if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                        {
                            continue;
                        }

                        bool isInsert = SpatialQueryHelper.IsIntersects(polyline, radius, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                        if (isInsert)
                        {
                            result.Add(item);
                        }

                    }
                    return result;
                }
                return list;
                //return this.BaseRepository().FindList(expression).Select(t => new TBL_MONITOROBJECTEntity { MONITOROBJECTID = t.MONITOROBJECTID, MONITORPOINTNAME = t.MONITORPOINTNAME, POINTTYPE = t.POINTTYPE, MEASURETYPE = t.MEASURETYPE, JCDJB = t.JCDJB, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// �Ѳ�ѯ���ҳ���ϵ�ͨ��json����ת����linq���
        /// </summary>
        /// <param name="queryJson">json����</param>
        /// <returns></returns>
        System.Linq.Expressions.Expression<Func<TBL_ZLGC_BASEINFOEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_BASEINFOEntity>();
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            var expression1 = LinqExtensions.False<TBL_ZLGC_BASEINFOEntity>();
            #region ʡ���ؼ�������
            //��
            string TOWN = json.TOWN;
            string TOWNRPT = json.TOWNRPT;
            if (!string.IsNullOrEmpty(TOWN))
            {
                foreach (var ton in TOWN.Split(','))
                {
                    expression1 = expression1.Or(t => t.TOWN.Equals(ton));
                }
                expression = expression.And(expression1);
            }
            else if (!string.IsNullOrEmpty(TOWNRPT))
            {
                foreach (var ton in TOWNRPT.Split(','))
                {
                    expression1 = expression1.Or(t => t.TOWN.Equals(ton));
                }
                expression = expression.And(expression1);
            }
            else
            {
                //��
                string COUNTY = json.COUNTY;
                string COUNTYRPT = json.COUNTYRPT;
                if (!string.IsNullOrEmpty(COUNTY))
                {
                    foreach (var ton in COUNTY.Split(','))
                    {
                        expression1 = expression1.Or(t => t.COUNTY.Equals(ton));
                    }
                    expression = expression.And(expression1);
                }
                else if (!string.IsNullOrEmpty(COUNTYRPT))
                {
                    foreach (var ton in COUNTYRPT.Split(','))
                    {
                        expression1 = expression1.Or(t => t.COUNTY.Equals(ton));
                    }
                    expression = expression.And(expression1);
                }
                else
                {
                    //��
                    string CITY = json.CITY;
                    string CITYRPT = json.CITYRPT;
                    if (!string.IsNullOrEmpty(CITY))
                    {
                        foreach (var ton in CITY.Split(','))
                        {
                            expression1 = expression1.Or(t => t.CITY.Equals(ton));
                        }
                        expression = expression.And(expression1);
                    }
                    else if (!string.IsNullOrEmpty(CITYRPT))
                    {
                        foreach (var ton in CITYRPT.Split(','))
                        {
                            expression1 = expression1.Or(t => t.CITY.Equals(ton));
                        }
                        expression = expression.And(expression1);
                    }
                    else
                    {
                        //ʡ
                        string PROVINCE = json.PROVINCE;
                        string PROVINCERPT = json.PROVINCERPT;
                        if (!string.IsNullOrEmpty(PROVINCE))
                        {
                            foreach (var ton in PROVINCE.Split(','))
                            {
                                expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                            }
                            expression = expression.And(expression1);
                        }
                        else if (!string.IsNullOrEmpty(PROVINCERPT))
                        {
                            foreach (var ton in PROVINCERPT.Split(','))
                            {
                                expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                            }
                            expression = expression.And(expression1);
                        }
                    }
                }
            }



            #endregion

            #region ʡ��������ɸѡ����

            string PROVINCENAME = "";
            string CITYNAME = "";
            string COUNTYNAME = "";
            if (json.PROVINCENAME != "" && json.PROVINCENAME != null)
            {
                PROVINCENAME = json.PROVINCENAME;
            }
            if (!string.IsNullOrEmpty(PROVINCENAME))
            {
                expression = expression.And(t => t.PROVINCENAME.Contains(PROVINCENAME));
            }
            if (json.CITYNAME != "" && json.CITYNAME != null)
            {
                CITYNAME = json.CITYNAME;
            }
            if (!string.IsNullOrEmpty(CITYNAME))
            {
                expression = expression.And(t => t.CITYNAME.Contains(CITYNAME));
            }
            if (json.COUNTYNAME != "" && json.COUNTYNAME != null)
            {
                COUNTYNAME = json.COUNTYNAME;
            }
            if (!string.IsNullOrEmpty(COUNTYNAME))
            {
                expression = expression.And(t => t.COUNTYNAME.Contains(COUNTYNAME));
            }

            #endregion

            //���ݷ�ΧȨ�޹���
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000") && !_codes.Equals("0"))
            {
                expression = expression.And(t => _codes.Contains(t.COUNTY));
            }

            //��������
            string ZLGCNAME = "";
            if (json.ZLGCNAME != "" && json.ZLGCNAME != null)
            {
                ZLGCNAME = json.ZLGCNAME;
            }
            if (!string.IsNullOrEmpty(ZLGCNAME))
            {
                expression = expression.And(t => t.ZLGCNAME.Contains(ZLGCNAME));
            }
            //�ֺ�������
            string DISASTERNAME = "";
            if (json.DISASTERNAME != "" && json.DISASTERNAME != null)
            {
                DISASTERNAME = json.DISASTERNAME;
            }
            if (!string.IsNullOrEmpty(DISASTERNAME))
            {
                expression = expression.And(t => t.DISASTERNAME.Contains(DISASTERNAME));
            }

            //�ֺ�����
            string UNIFIEDCODE = "";
            if (json.UNIFIEDCODE != "" && json.UNIFIEDCODE != null)
            {
                UNIFIEDCODE = json.UNIFIEDCODE;
            }
            if (!string.IsNullOrEmpty(UNIFIEDCODE))
            {
                expression = expression.And(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE));
            }

            //�ֺ�������
            string DISASTERTYPE = "";
            if (json.DISASTERTYPE != "" && json.DISASTERTYPE != null)
            {
                DISASTERTYPE = json.DISASTERTYPE;
            }
            if (!string.IsNullOrEmpty(DISASTERTYPE))
            {
                expression = expression.And(t => t.DISASTERTYPE.Contains(DISASTERTYPE));
            }
            //��Ŀ����ʱ�䷶Χ��ѯ
            if (json.ZLGCSTARTTIME != "" && json.ZLGCSTARTTIME != null)
            {
                DateTime ZLGCSTARTTIME = json.ZLGCSTARTTIME;
                expression = expression.And(t => (t.XMJLXSJ >= ZLGCSTARTTIME));
            }
            if (json.ZLGCENDTIME != "" && json.ZLGCENDTIME != null)
            {
                DateTime ZLGCENDTIME = json.ZLGCENDTIME;
                expression = expression.And(t => (t.XMJLXSJ <= ZLGCENDTIME));
            }
            //�����������������ơ��͡��ֺ������ơ�
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {

                string NAMESS = "";
                //���̱��
                if (json.NAMESS != "" && json.NAMESS != null)
                {
                    NAMESS = json.NAMESS;
                }
                if (!string.IsNullOrEmpty(NAMESS))
                {
                    expression = expression.And(t => t.ZLGCNAME.Contains(NAMESS) || t.DISASTERNAME.Contains(NAMESS) || t.UNIFIEDCODE.Contains(NAMESS));//�ֺ����ơ��������ƺ��ֺ�����ɸѡ����
                }
            }
            //��Ŀ�׶�
            string ITEMTYPE = "";
            if (json.ITEMTYPE != "" && json.ITEMTYPE != null)
            {
                ITEMTYPE = json.ITEMTYPE;
            }
            if (!string.IsNullOrEmpty(ITEMTYPE))
            {
                expression = expression.And(t => t.ZLSTATE.Contains(ITEMTYPE));
            }
            //����λ
            string XMFZDW = "";
            if (json.XMFZDW != "" && json.XMFZDW != null)
            {
                XMFZDW = json.XMFZDW;
            }
            if (!string.IsNullOrEmpty(XMFZDW))
            {
                expression = expression.And(t => t.XMFZDW.Contains(XMFZDW));
            }
            return expression;
        }



        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_BASEINFOEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_ZLGC_BASEINFOEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }

        /// <summary>
        /// ����ͳһ��ź���Ŀid��ȡ��������Ϣ
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="projectid"></param>
        /// <returns></returns>
        public TBL_ZLGC_BASEINFOEntity GetEntityByUnifycode(string keyValue, string projectid)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_BASEINFOEntity>();
            if (!keyValue.IsEmpty() && !projectid.IsEmpty())
            {
                expression = expression.And(u => u.UNIFIEDCODE == keyValue);
            }
            else
            {
                expression = expression.And(u => 1 == 2);
            }
            return this.BaseRepository().FindList(expression).FirstOrDefault();
        }
        /// <summary>
        /// ������ͳ������Datatable
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <param name="CityName"></param>
        /// <param name="CountyName"></param>
        /// <param name="ZLGCYEAR"></param>
        /// <param name="ZLGCUNIT"></param>
        /// <param name="DC"></param>
        /// <returns></returns>
        public DataTable ZLGCCountStatics(string ProvinceName, string CityName, string CountyName, string ZLGCYEAR, string ZLGCUNIT, string DC)
        {

            DataTable result_query = new DataTable();
            //��һ�� ���ڵ����ֺ��ֺ���ļ���ͳ�ƣ���ʡ���أ�
            string chaxun = "{\"PROVINCENAME\":\"" + ProvinceName + "\",\"CITYNAME\":\"" + CityName + "\",\"COUNTYNAME\":\"" + CountyName + "\"}";
            var Hazards = hazard.GetList(chaxun);
            //�ڶ��� ���������̼���ͳ�ƣ���ʡ���أ�
            var expression = LinqExtensions.True<TBL_ZLGC_BASEINFOEntity>();
            IEnumerable<TBL_ZLGC_BASEINFOEntity> Zlgcs = this.BaseRepository().FindList(expression);
            //������ ����ʡ���ؼ��ϵ�ɸѡ
            #region ʡ���ؼ���--�Լ�ʡ��������ɸѡ
            List<string> Provincename_list = new List<string>();
            List<string> Cityname_list = new List<string>();
            List<string> Countyname_list = new List<string>();
            List<string> City_list = new List<string>();
            List<string> County_list = new List<string>();
            foreach (var item in Hazards)
            {
                if (Provincename_list.Contains(item.PROVINCENAME.ToString()))
                {

                }
                else
                {
                    if (String.IsNullOrEmpty(ProvinceName))
                    {//ȫ��
                        Provincename_list.Add(item.PROVINCENAME.ToString());
                    }
                    else
                    {
                        string[] PROVINCENAME_S = ProvinceName.Split(',');
                        for (int i = 0; i < PROVINCENAME_S.Count(); i++)
                        {
                            string ProvinceName_i = PROVINCENAME_S[i];
                            if (item.PROVINCENAME.ToString() == ProvinceName_i)
                            {
                                Provincename_list.Add(item.PROVINCENAME.ToString());
                            }
                        }

                    }


                }
                if (item.CITYNAME == null)
                {
                    item.CITYNAME = "";
                }
                if (Cityname_list.Contains(item.CITYNAME.ToString()))
                {

                }
                else
                {
                    if (String.IsNullOrEmpty(ProvinceName))
                    {
                        if (!City_list.Contains(item.CITYNAME.ToString()))
                        {
                            City_list.Add(item.CITYNAME.ToString());
                        }
                        if (!Cityname_list.Contains(item.PROVINCENAME.ToString() + "," + item.CITYNAME.ToString()))
                        {
                            Cityname_list.Add(item.PROVINCENAME.ToString() + "," + item.CITYNAME.ToString());
                        }
                    }
                    else
                    {
                        string[] PROVINCENAME_S = ProvinceName.Split(',');
                        for (int i = 0; i < PROVINCENAME_S.Count(); i++)
                        {
                            string ProvinceName_i = PROVINCENAME_S[i];
                            if (item.PROVINCENAME.ToString() == ProvinceName_i)
                            {
                                if (!City_list.Contains(item.CITYNAME.ToString()))
                                {
                                    City_list.Add(item.CITYNAME.ToString());
                                }
                                if (!Cityname_list.Contains(item.PROVINCENAME.ToString() + "," + item.CITYNAME.ToString()))
                                {
                                    Cityname_list.Add(item.PROVINCENAME.ToString() + "," + item.CITYNAME.ToString());
                                }
                            }
                        }

                    }

                }
                if (item.COUNTYNAME == null)
                {
                    item.COUNTYNAME = "";
                }
                if (Countyname_list.Contains(item.COUNTYNAME.ToString()))
                {

                }
                else
                {
                    if (String.IsNullOrEmpty(ProvinceName))
                    {
                        if (!Countyname_list.Contains(item.CITYNAME.ToString() + "," + item.COUNTYNAME.ToString()))
                        {
                            Countyname_list.Add(item.CITYNAME.ToString() + "," + item.COUNTYNAME.ToString());
                        }
                        if (!County_list.Contains(item.COUNTYNAME.ToString()))
                        {
                            County_list.Add(item.COUNTYNAME.ToString());
                        }
                    }
                    else
                    {
                        string[] PROVINCENAME_S = ProvinceName.Split(',');
                        for (int i = 0; i < PROVINCENAME_S.Count(); i++)
                        {
                            string ProvinceName_i = PROVINCENAME_S[i];
                            if (item.PROVINCENAME.ToString() == ProvinceName_i)
                            {

                                if (!Countyname_list.Contains(item.CITYNAME.ToString() + "," + item.COUNTYNAME.ToString()))
                                {
                                    Countyname_list.Add(item.CITYNAME.ToString() + "," + item.COUNTYNAME.ToString());
                                }
                                if (!County_list.Contains(item.COUNTYNAME.ToString()))
                                {
                                    County_list.Add(item.COUNTYNAME.ToString());
                                }
                            }
                        }
                    }
                }
            }
            //ʡ��������ɸѡ
            if (ProvinceName != "" && ProvinceName != null)
            {
                string[] ProvinceNameS = ProvinceName.Split(',');
                List<string> DISProvinceNames_SC = new List<string>();
                for (int j = 0; j < Provincename_list.Count(); j++)
                {
                    if (ProvinceNameS.Contains(Provincename_list[j]))
                    {

                    }
                    else
                    {
                        DISProvinceNames_SC.Add(Provincename_list[j]);
                    }
                }
                for (int m = 0; m < DISProvinceNames_SC.Count(); m++)
                {
                    Provincename_list.Remove(DISProvinceNames_SC[m]);
                }
            }
            if (CityName != "" && CityName != null)
            {
                string[] CityNameS = CityName.Split(',');
                List<string> DISCityNames_SC = new List<string>();
                for (int j = 0; j < City_list.Count(); j++)
                {
                    if (CityNameS.Contains(City_list[j]))
                    {

                    }
                    else
                    {
                        DISCityNames_SC.Add(City_list[j]);
                    }
                }
                for (int m = 0; m < DISCityNames_SC.Count(); m++)
                {
                    City_list.Remove(DISCityNames_SC[m]);
                }


            }
            if (CountyName != "" && CountyName != null)
            {
                string[] CountyNameS = CountyName.Split(',');
                List<string> DISCountyNames_SC = new List<string>();
                for (int i = 0; i < County_list.Count(); i++)
                {
                    if (CountyNameS.Contains(County_list[i]))
                    {

                    }
                    else
                    {
                        DISCountyNames_SC.Add(CountyNameS[i]);
                    }
                }
                for (int j = 0; j < DISCountyNames_SC.Count(); j++)
                {
                    County_list.Remove(DISCountyNames_SC[j]);
                }
            }
            #endregion
            //���Ĳ� ��Ӧ���ݽ���ʡ������ȵ�ɸѡ����λ���֣�
            if (ZLGCYEAR != "" && ZLGCYEAR != null)
            {
                if (ZLGCUNIT == "ʡ")
                {
                    foreach (var item in Zlgcs)
                    {
                        if (item.XMJLXSJ != null)
                        {
                            if (item.XMJLXSJ.ToString().Substring(0, 4) == ZLGCYEAR)
                            {

                            }
                            else
                            {
                                item.PROVINCENAME = "";
                                item.CITYNAME = "";
                                item.COUNTYNAME = "";
                            }
                        }
                        else
                        {
                            item.PROVINCENAME = "";
                            item.CITYNAME = "";
                            item.COUNTYNAME = "";
                        }
                    }
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlgcs);
                }
                if (ZLGCUNIT == "��")
                {
                    foreach (var item in Zlgcs)
                    {
                        if (item.XMJLXSJ != null)
                        {
                            if (item.XMJLXSJ.ToString().Substring(0, 4) == ZLGCYEAR)
                            {

                            }
                            else
                            {
                                item.PROVINCENAME = "";
                                item.CITYNAME = "";
                                item.COUNTYNAME = "";
                            }
                        }
                        else
                        {
                            item.PROVINCENAME = "";
                            item.CITYNAME = "";
                            item.COUNTYNAME = "";
                        }
                    }
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlgcs);
                    result_query.Columns.Add("cityname");
                    result_query = city_func(result_query, Provincename_list, Cityname_list, Hazards, Zlgcs);
                }

                if (ZLGCUNIT == "��")
                {
                    foreach (var item in Zlgcs)
                    {
                        if (item.XMJLXSJ != null)
                        {
                            if (item.XMJLXSJ.ToString().Substring(0, 4) == ZLGCYEAR)
                            {

                            }
                            else
                            {
                                item.PROVINCENAME = "";
                                item.CITYNAME = "";
                                item.COUNTYNAME = "";
                            }
                        }
                        else
                        {
                            item.PROVINCENAME = "";
                            item.CITYNAME = "";
                            item.COUNTYNAME = "";
                        }


                    }
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlgcs);
                    result_query.Columns.Add("cityname");
                    result_query.Columns.Add("countyname");
                    result_query = county_func(result_query, Cityname_list, Countyname_list, Hazards, Zlgcs);
                }
            }
            else
            {
                //������ݵ�ͳ��
                if (ZLGCUNIT == "ʡ")
                {
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlgcs);
                }
                if (ZLGCUNIT == "��")
                {
                    //result_query = province_func(result_query, Provincename_list, Hazards, Zlgcs);
                    result_query.Columns.Add("provincename");
                    result_query.Columns.Add("cityname");
                    result_query.Columns.Add("disastercount");
                    result_query.Columns.Add("zlgccount");
                    result_query = city_func(result_query, Provincename_list, Cityname_list, Hazards, Zlgcs);
                }
                if (ZLGCUNIT == "��")
                {
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlgcs);
                    result_query.Columns.Add("cityname");
                    result_query.Columns.Add("countyname");
                    result_query = county_func(result_query, City_list, Countyname_list, Hazards, Zlgcs);
                }

            }
            return result_query;
        }

        public DataTable ZLGCCountStaticsNew(string xzqhcode, string ProvinceName, string CityName, string CountyName, string ZLGCYEAR, string ZLGCUNIT)
        {
            //�Ѿ����³�Ϊ������ͼģʽ��ά��������ͼά��,�����ࣩ  
            //����ݵ�ͳ��ʡ����ͳ��BQBRPROVINCEBYYEARCOUNT
            var QueryStrProvinceYear = "SELECT * FROM ZLGCPROVINCEBYYEARCOUNT";
            //����ݵ�ͳ��(��)BQBRCITYBYYEARCOUNT
            var QueryStrCityYear = "SELECT * FROM ZLGCCITYBYYEARCOUNT";
            //����ݵ�ͳ��(��)zlgccountYBYYEARCOUNT
            var QueryStrCountyYear = "SELECT * FROM ZLGCCOUNTYBYYEARCOUNT";

            //������ݵ�ͳ��(ʡ)
            var QueryStrProvince = "SELECT * FROM ZLGCPROVINCECOUNT";
            //������ݵ�ͳ��(��)
            var QueryStrCity = "SELECT * FROM ZLGCCITYCOUNT";
            //������ݵ�ͳ��(��)
            var QueryStrCounty = "SELECT * FROM ZLGCCOUNTYCOUNT";
            DataTable result_Query = new DataTable();
            if (ZLGCYEAR != "" && ZLGCYEAR != null)
            {
                if (ZLGCUNIT != null && ZLGCUNIT != "")
                {
                    if (ZLGCUNIT == "ʡ")
                    {
                        string QueryYear = QueryStrProvinceYear.ToString() + " where zlgcyear ='" + ZLGCYEAR + "'";
                        string QueryXZQH = "";
                        if (ProvinceName != "")
                        {
                            string[] ProvinceNames = ProvinceName.Split(',');
                            for (int i = 0; i < ProvinceNames.Length; i++)
                            {
                                if (ProvinceNames.Length > 1)
                                {
                                    if (i == 0)
                                    {
                                        QueryXZQH += "  and(provincename in( '" + ProvinceNames[i] + "')";
                                    }
                                    else
                                    {
                                        QueryXZQH += " or provincename in( '" + ProvinceNames[i] + "')";
                                    }

                                }
                                else
                                {
                                    QueryXZQH += "  and (provincename in( '" + ProvinceNames[i] + "')";
                                }

                            }
                            QueryXZQH = QueryXZQH + ")";
                        }
                        QueryYear += QueryXZQH;
                        var queryResult = QueryYear;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                        //List<string> selectXZQH = new List<string>();
                        //selectXZQH = ssoWS.GetAreaListJson(xzqhcode).Select(p => p.F_AreaCode).ToList();
                        var codes = xzqhcode.Split(',');
                        List<AreaEntity> districts = new List<AreaEntity>();
                        if (xzqhcode == "0")
                        {
                            districts = ssoWS.GetAreaListJson(xzqhcode);
                        }
                        else if (xzqhcode.Length == 6 && xzqhcode.EndsWith("0000"))
                        {
                            districts = ssoWS.GetAreaListJson("0").Where(p => p.F_AreaCode == xzqhcode).ToList();
                        }
                        if (result_Query != null)
                        {
                            //���������������
                            for (int i = 0; i < districts.Count; i++)
                            {
                                if (result_Query.Select("provincename ='" + districts[i].F_AreaName + "'").Count() == 0)
                                {
                                    DataRow addDR = result_Query.NewRow();
                                    addDR["provincename"] = districts[i].F_AreaName;
                                    addDR["cityname"] = "";
                                    for (int columnIndex = 2; columnIndex < result_Query.Columns.Count; columnIndex++)
                                    {

                                        if (result_Query.Columns[columnIndex].ColumnName.Contains("discount"))
                                        {
                                            addDR["discount"] = 0;
                                        }
                                        if (result_Query.Columns[columnIndex].ColumnName.Contains("zlgccount"))
                                        {
                                            addDR["zlgccount"] = 0;
                                        }
                                        addDR[columnIndex] = "0";
                                    }
                                    result_Query.Rows.InsertAt(addDR, i);
                                }
                            }
                        }
                    }
                    if (ZLGCUNIT == "��")
                    {
                        string QueryYear = QueryStrCityYear.ToString() + " where zlgcyear ='" + ZLGCYEAR + "'";
                        string QueryXZQH = "";
                        if (ProvinceName != "")
                        {
                            string[] ProvinceNames = ProvinceName.Split(',');
                            for (int i = 0; i < ProvinceNames.Length; i++)
                            {

                                if (ProvinceNames.Length > 1)
                                {
                                    if (i == 0)
                                    {
                                        QueryXZQH += "  and (provincename in( '" + ProvinceNames[i] + "')";
                                    }
                                    else
                                    {
                                        QueryXZQH += " or provincename in( '" + ProvinceNames[i] + "')";
                                    }

                                }
                                else
                                {
                                    QueryXZQH += "  and (provincename in( '" + ProvinceNames[i] + "')";
                                }
                            }
                            QueryXZQH = QueryXZQH + ")";
                        }
                        if (CityName != "")
                        {
                            string[] CityNames = CityName.Split(',');
                            for (int i = 0; i < CityNames.Length; i++)
                            {
                                if (CityNames.Length > 1)
                                {
                                    if (i == 0)
                                    {
                                        QueryXZQH += "  and(cityname in( '" + CityNames[i] + "')";
                                    }
                                    else
                                    {
                                        QueryXZQH += " or cityname in( '" + CityNames[i] + "')";
                                    }

                                }
                                else
                                {
                                    QueryXZQH += "  and (cityname in( '" + CityNames[i] + "')";
                                }
                            }
                            QueryXZQH = QueryXZQH + ")";
                        }
                        QueryYear += QueryXZQH;
                        var queryResult = QueryYear;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                        DataTable result = new DataTable();
                        result.Columns.Add("provincename");
                        result.Columns.Add("cityname");
                        result.Columns.Add("discount");
                        result.Columns.Add("zlgccount");
                        result.Columns.Add("zlgcyear");
                        for (int i = 0; i < result_Query.Rows.Count; i++)
                        {
                            if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "")
                            {
                                result_Query.Rows[i]["provincename"] = "";
                            }
                            DataRow result_dr = result.NewRow();
                            result_dr["provincename"] = result_Query.Rows[i]["provincename"].ToString();
                            result_dr["cityname"] = result_Query.Rows[i]["cityname"].ToString();
                            result_dr["discount"] = result_Query.Rows[i]["discount"].ToString();
                            result_dr["zlgccount"] = result_Query.Rows[i]["zlgccount"].ToString();
                            result_dr["zlgcyear"] = result_Query.Rows[i]["zlgcyear"].ToString();
                            result.Rows.Add(result_dr);
                        }
                        List<string> selectXZQH = new List<string>();
                        selectXZQH = ssoWS.GetAreaListJson(xzqhcode).Select(p => p.F_AreaCode).ToList();
                        List<AreaEntity> districts = new List<AreaEntity>();
                        DataTable aa = result.Copy();
                        DataView dv = result.DefaultView;
                        var codes = xzqhcode.Split(',');
                        if (result != null)
                        {
                            if (xzqhcode.EndsWith("0000"))
                            {
                                for (var a = 0; a < codes.Length; a++)
                                {
                                    var SName1 = ssoWS.GetDistrctByCodes(codes[a]).Where(p => p.DistrictCode == codes[a]).ToArray();
                                    districts = ssoWS.GetAreaListJson(codes[a]);
                                    if (result.Select("provincename ='" + SName1[0].DistrictName + "'").Count() == 0)
                                    {
                                        DataRow addDR2 = result.NewRow();
                                        addDR2["provincename"] = SName1[0].DistrictName;
                                        result.Rows.InsertAt(addDR2, 0);
                                    }
                                    //���������������
                                    for (int i = 0; i < districts.Count; i++)
                                    {
                                        if (result.Select("cityname ='" + districts[i].F_AreaName + "'").Count() == 0)
                                        {
                                            DataRow addDR = result.NewRow();
                                            addDR["provincename"] = SName1[0].DistrictName;
                                            addDR["cityname"] = districts[i].F_AreaName;
                                            for (int columnIndex = 2; columnIndex < result.Columns.Count; columnIndex++)
                                            {

                                                if (result.Columns[columnIndex].ColumnName.Contains("discount"))
                                                {
                                                    addDR["discount"] = 0;
                                                }
                                                if (result.Columns[columnIndex].ColumnName.Contains("zlgccount"))
                                                {
                                                    addDR["zlgccount"] = 0;
                                                }
                                                addDR[columnIndex] = "0";
                                            }
                                            result.Rows.InsertAt(addDR, i + 2);
                                        }
                                    }
                                }
                                //}
                            }
                            else if (xzqhcode.Length == 6 && xzqhcode.EndsWith("00"))
                            {
                                districts = ssoWS.GetAreaListJson(xzqhcode.Substring(0, 2) + "0000").Where(p => p.F_AreaCode == xzqhcode).ToList();
                                //���������������
                                for (int i = 0; i < districts.Count; i++)
                                {
                                    if (result.Select("cityname ='" + districts[i].F_AreaName + "'").Count() == 0)
                                    {
                                        var SName1 = ssoWS.GetDistrctByCodes(xzqhcode.Substring(0, 2) + "0000");
                                        DataRow addDR = result.NewRow();
                                        addDR["provincename"] = SName1[0].DistrictName;
                                        addDR["cityname"] = districts[i].F_AreaName;
                                        for (int columnIndex = 2; columnIndex < result.Columns.Count; columnIndex++)
                                        {

                                            if (result.Columns[columnIndex].ColumnName.Contains("discount"))
                                            {
                                                addDR["discount"] = 0;
                                            }
                                            if (result.Columns[columnIndex].ColumnName.Contains("zlgccount"))
                                            {
                                                addDR["zlgccount"] = 0;
                                            }
                                            addDR[columnIndex] = "0";
                                        }
                                        result.Rows.InsertAt(addDR, i + result.Rows.Count);
                                    }
                                }
                            }
                        }
                        if (dv.Table.Columns.Contains("provincename"))
                        {
                            dv.Sort = "provincename desc";
                            aa = dv.ToTable();
                            result = aa;
                        }
                        for (int i = 0; i < result.Rows.Count; i++)
                        {
                            if (result.Rows[i]["provincename"].ToString() != "" && result.Rows[i]["cityname"].ToString() != "")
                            {
                                result.Rows[i]["provincename"] = "";
                            }
                        }
                        return result;
                    }
                    if (ZLGCUNIT == "��")
                    {
                        string QueryYear = QueryStrCountyYear.ToString() + " where zlgcyear ='" + ZLGCYEAR + "'";
                        string QueryXZQH = "";
                        if (ProvinceName != "")
                        {
                            string[] ProvinceNames = ProvinceName.Split(',');
                            for (int i = 0; i < ProvinceNames.Length; i++)
                            {
                                if (ProvinceNames.Length > 1)
                                {
                                    if (i == 0)
                                    {
                                        QueryXZQH += "  and(provincename in( '" + ProvinceNames[i] + "')";
                                    }
                                    else
                                    {
                                        QueryXZQH += " or provincename in( '" + ProvinceNames[i] + "')";
                                    }

                                }
                                else
                                {
                                    QueryXZQH += "  and (provincename in( '" + ProvinceNames[i] + "')";
                                }
                            }
                            QueryXZQH = QueryXZQH + ")";
                        }
                        if (CityName != "")
                        {
                            string[] CityNames = CityName.Split(',');
                            for (int i = 0; i < CityNames.Length; i++)
                            {
                                if (CityNames.Length > 1)
                                {
                                    if (i == 0)
                                    {
                                        QueryXZQH += "  and(cityname in( '" + CityNames[i] + "')";
                                    }
                                    else
                                    {
                                        QueryXZQH += " or cityname in( '" + CityNames[i] + "')";
                                    }

                                }
                                else
                                {
                                    QueryXZQH += "  and (cityname in( '" + CityNames[i] + "')";

                                }

                            }
                            QueryXZQH = QueryXZQH + ")";
                        }
                        if (CountyName != "")
                        {
                            string[] CountyNames = CountyName.Split(',');
                            for (int i = 0; i < CountyNames.Length; i++)
                            {
                                if (CountyName.Length > 1)
                                {
                                    if (i == 0)
                                    {
                                        QueryXZQH += "  and (countryname in( '" + CountyNames[i] + "')";
                                    }
                                    else
                                    {
                                        QueryXZQH += " or countryname in( '" + CountyNames[i] + "')";
                                    }

                                }
                                else
                                {
                                    QueryXZQH += "  and (countryname in( '" + CountyNames[i] + "')";
                                }
                            }
                            QueryXZQH = QueryXZQH + ")";
                        }
                        QueryYear += QueryXZQH;
                        var queryResult = QueryYear;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                        DataTable result = new DataTable();
                        result.Columns.Add("provincename");
                        result.Columns.Add("cityname");
                        result.Columns.Add("countryname");
                        result.Columns.Add("discount");
                        result.Columns.Add("zlgccount");
                        result.Columns.Add("zlgcyear");
                        for (int i = 0; i < result_Query.Rows.Count; i++)
                        {
                            //if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && result_Query.Rows[i]["countryname"].ToString() != "")
                            //{
                            //    result_Query.Rows[i]["provincename"] = "";
                            //    result_Query.Rows[i]["cityname"] = "";
                            //}
                            //if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && result_Query.Rows[i]["countryname"].ToString() == "")
                            //{
                            //    result_Query.Rows[i]["provincename"] = "";
                            //}
                            DataRow result_dr = result.NewRow();
                            result_dr["provincename"] = result_Query.Rows[i]["provincename"].ToString();
                            result_dr["cityname"] = result_Query.Rows[i]["cityname"].ToString();
                            result_dr["countryname"] = result_Query.Rows[i]["countryname"].ToString();
                            result_dr["discount"] = result_Query.Rows[i]["discount"].ToString();
                            result_dr["zlgccount"] = result_Query.Rows[i]["zlgccount"].ToString();
                            result_dr["zlgcyear"] = result_Query.Rows[i]["zlgcyear"].ToString();
                            result.Rows.Add(result_dr);
                        }
                        List<string> selectXZQH = new List<string>();
                        selectXZQH = ssoWS.GetAreaListJson(xzqhcode).Select(p => p.F_AreaCode).ToList();
                        List<AreaEntity> districts = new List<AreaEntity>(); List<AreaEntity> districts1 = new List<AreaEntity>();
                        DataTable aa = result.Copy();
                        DataView dv = result.DefaultView;
                        var codes = xzqhcode.Split(',');
                        if (result != null)
                        {
                            if (xzqhcode.EndsWith("00"))
                            {
                                for (var a = 0; a < codes.Length; a++)
                                {
                                    var SName1 = ssoWS.GetDistrctByCodes(codes[a]).Where(p => p.DistrictCode == codes[a]).ToArray();
                                    var SName2 = ssoWS.GetDistrctByCodes(codes[a].Substring(0, 2) + "0000");
                                    districts = ssoWS.GetAreaListJson(codes[a]);
                                    if (result.Select("cityname ='" + SName1[0].DistrictName + "'").Count() == 0)
                                    {
                                        DataRow addDR3 = result.NewRow();
                                        addDR3["provincename"] = SName2[0].DistrictName;
                                        addDR3["cityname"] = SName1[0].DistrictName;
                                        result.Rows.InsertAt(addDR3, 0);
                                    }
                                    //���������������
                                    for (int i = 0; i < districts.Count; i++)
                                    {
                                        if (result.Select("countryname ='" + districts[i].F_AreaName + "'").Count() == 0)
                                        {
                                            DataRow addDR = result.NewRow();
                                            addDR["provincename"] = SName2[0].DistrictName;
                                            addDR["cityname"] = SName1[0].DistrictName;
                                            addDR["countryname"] = districts[i].F_AreaName;
                                            for (int columnIndex = 3; columnIndex < result.Columns.Count; columnIndex++)
                                            {

                                                if (result.Columns[columnIndex].ColumnName.Contains("discount"))
                                                {
                                                    addDR["discount"] = 0;
                                                }
                                                if (result.Columns[columnIndex].ColumnName.Contains("zlgccount"))
                                                {
                                                    addDR["zlgccount"] = 0;
                                                }
                                                addDR[columnIndex] = "0";
                                            }
                                            result.Rows.InsertAt(addDR, i + 2);
                                        }
                                    }

                                }
                            }
                            else if (xzqhcode.Length == 6 && !xzqhcode.EndsWith("00"))
                            {
                                districts = ssoWS.GetAreaListJson(xzqhcode.Substring(0, 4) + "00").Where(p => p.F_AreaCode == xzqhcode).ToList();
                                //���������������
                                for (int i = 0; i < districts.Count; i++)
                                {
                                    if (result.Select("countryname ='" + districts[i].F_AreaName + "'").Count() == 0)
                                    {
                                        DataRow addDR = result.NewRow();
                                        var SName1 = ssoWS.GetDistrctByCodes(xzqhcode.Substring(0, 4) + "00").Where(p => p.DistrictCode == xzqhcode.Substring(0, 4) + "00").ToArray();
                                        var SName2 = ssoWS.GetDistrctByCodes(xzqhcode.Substring(0, 2) + "0000");
                                        addDR["provincename"] = SName2[0].DistrictName;
                                        addDR["cityname"] = SName1[0].DistrictName;
                                        addDR["countryname"] = districts[i].F_AreaName;
                                        for (int columnIndex = 3; columnIndex < result.Columns.Count; columnIndex++)
                                        {

                                            if (result.Columns[columnIndex].ColumnName.Contains("discount"))
                                            {
                                                addDR["discount"] = 0;
                                            }
                                            if (result.Columns[columnIndex].ColumnName.Contains("zlgccount"))
                                            {
                                                addDR["zlgccount"] = 0;
                                            }
                                            addDR[columnIndex] = "0";
                                        }
                                        result.Rows.InsertAt(addDR, i + result.Rows.Count);
                                    }
                                }
                            }
                            else if (xzqhcode.Length > 6 && !xzqhcode.EndsWith("00"))
                            {
                                for (var a = 0; a < codes.Length; a++)
                                {
                                    var SName1 = ssoWS.GetDistrctByCodes(xzqhcode.Substring(0, 4) + "00").Where(p => p.DistrictCode == xzqhcode.Substring(0, 4) + "00").ToArray();
                                    var SName2 = ssoWS.GetDistrctByCodes(xzqhcode.Substring(0, 2) + "0000");
                                    districts = ssoWS.GetAreaListJson(codes[a].Substring(0, 4) + "00").Where(p => p.F_AreaCode == codes[a]).ToList();
                                    //���������������
                                    for (int i = 0; i < districts.Count; i++)
                                    {
                                        if (result.Select("countryname ='" + districts[i].F_AreaName + "'").Count() == 0)
                                        {
                                            DataRow addDR = result.NewRow();

                                            addDR["provincename"] = SName2[0].DistrictName;
                                            addDR["cityname"] = SName1[0].DistrictName;
                                            addDR["countryname"] = districts[i].F_AreaName;
                                            for (int columnIndex = 3; columnIndex < result.Columns.Count; columnIndex++)
                                            {

                                                if (result.Columns[columnIndex].ColumnName.Contains("discount"))
                                                {
                                                    addDR["discount"] = 0;
                                                }
                                                if (result.Columns[columnIndex].ColumnName.Contains("zlgccount"))
                                                {
                                                    addDR["zlgccount"] = 0;
                                                }
                                                addDR[columnIndex] = "0";
                                            }
                                            result.Rows.InsertAt(addDR, i + result.Rows.Count);
                                        }
                                    }
                                }

                            }
                        }
                        if (dv.Table.Columns.Contains("provincename"))
                        {
                            dv.Sort = "provincename desc";
                            aa = dv.ToTable();
                            result = aa;
                        }
                        for (int i = 0; i < result.Rows.Count; i++)
                        {
                            if (result.Rows[i]["provincename"].ToString() != "" && result.Rows[i]["cityname"].ToString() != "" && result.Rows[i]["countryname"].ToString() != "" && i > 0)
                            {
                                result.Rows[i]["provincename"] = "";
                                result.Rows[i]["cityname"] = "";
                            }
                        }
                        return result;
                    }

                }

            }
            else
            {
                if (ZLGCUNIT != null && ZLGCUNIT != "")
                {
                    if (ZLGCUNIT == "ʡ")
                    {
                        string QueryDE = QueryStrProvince.ToString() + " where 1=1 ";
                        string QueryXZQH = "";
                        if (ProvinceName != "")
                        {
                            string[] ProvinceNames = ProvinceName.Split(',');
                            for (int i = 0; i < ProvinceNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and provincename in( '" + ProvinceNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or provincename in( '" + ProvinceNames[i] + "')";
                                }
                            }
                            //QueryXZQH += " and provincename = '" + ProvinceName + "'";
                        }
                        QueryDE += QueryXZQH;
                        var queryResult = QueryDE;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                        List<AreaEntity> districts = new List<AreaEntity>();

                        if (xzqhcode == "0")
                        {
                            districts = ssoWS.GetAreaListJson(xzqhcode);
                        }
                        else if (xzqhcode.Length == 6 && xzqhcode.EndsWith("0000"))
                        {
                            districts = ssoWS.GetAreaListJson("0").Where(p => p.F_AreaCode == xzqhcode).ToList();
                        }
                        if (result_Query != null)
                        {
                            //���������������
                            for (int i = 0; i < districts.Count; i++)
                            {
                                if (result_Query.Select("provincename ='" + districts[i].F_AreaName + "'").Count() == 0)
                                {
                                    DataRow addDR = result_Query.NewRow();
                                    addDR["provincename"] = districts[i].F_AreaName;
                                    addDR["cityname"] = "";
                                    for (int columnIndex = 2; columnIndex < result_Query.Columns.Count; columnIndex++)
                                    {

                                        if (result_Query.Columns[columnIndex].ColumnName.Contains("discount"))
                                        {
                                            addDR["discount"] = 0;
                                        }
                                        if (result_Query.Columns[columnIndex].ColumnName.Contains("zlgccount"))
                                        {
                                            addDR["zlgccount"] = 0;
                                        }
                                        addDR[columnIndex] = "0";
                                    }
                                    result_Query.Rows.InsertAt(addDR, i);
                                }
                            }
                        }
                    }
                    if (ZLGCUNIT == "��")
                    {
                        string QueryDE = QueryStrCity.ToString() + " where 1=1 ";
                        string QueryXZQH = "";
                        if (ProvinceName != "")
                        {
                            string[] ProvinceNames = ProvinceName.Split(',');
                            for (int i = 0; i < ProvinceNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and provincename in( '" + ProvinceNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or provincename in( '" + ProvinceNames[i] + "')";
                                }
                            }
                        }
                        //QueryDE += QueryXZQH;
                        if (CityName != "")
                        {
                            string[] CityNames = CityName.Split(',');
                            for (int i = 0; i < CityNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and cityname in( '" + CityNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or cityname in( '" + CityNames[i] + "')";
                                }
                            }

                        }
                        QueryDE += QueryXZQH;
                        var queryResult = QueryDE;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                        DataTable result = new DataTable();
                        result.Columns.Add("provincename");
                        result.Columns.Add("cityname");
                        result.Columns.Add("discount");
                        result.Columns.Add("zlgccount");
                        for (int i = 0; i < result_Query.Rows.Count; i++)
                        {
                            //if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && i != 0)
                            //{
                            //    result_Query.Rows[i]["provincename"] = "";
                            //}
                            DataRow result_dr = result.NewRow();
                            result_dr["provincename"] = result_Query.Rows[i]["provincename"].ToString();
                            result_dr["cityname"] = result_Query.Rows[i]["cityname"].ToString();
                            result_dr["discount"] = result_Query.Rows[i]["discount"].ToString();
                            result_dr["zlgccount"] = result_Query.Rows[i]["zlgccount"].ToString();
                            result.Rows.Add(result_dr);
                        }
                        //return result;
                        List<string> selectXZQH = new List<string>();
                        selectXZQH = ssoWS.GetAreaListJson(xzqhcode).Select(p => p.F_AreaCode).ToList();
                        List<AreaEntity> districts = new List<AreaEntity>();
                        DataTable aa = result.Copy();
                        DataView dv = result.DefaultView;
                        var codes = xzqhcode.Split(',');
                        if (result != null)
                        {
                            if (xzqhcode.EndsWith("0000"))
                            {
                                //if (codes.Length > 1)
                                //{
                                for (var a = 0; a < codes.Length; a++)
                                {
                                    var SName1 = ssoWS.GetDistrctByCodes(codes[a]).Where(p => p.DistrictCode == codes[a]).ToArray();
                                    districts = ssoWS.GetAreaListJson(codes[a]);
                                    if (result.Select("provincename ='" + SName1[0].DistrictName + "'").Count() == 0)
                                    {
                                        DataRow addDR2 = result.NewRow();
                                        addDR2["provincename"] = SName1[0].DistrictName;
                                        result.Rows.InsertAt(addDR2, 0);
                                    }
                                    //���������������
                                    for (int i = 0; i < districts.Count; i++)
                                    {
                                        if (result.Select("cityname ='" + districts[i].F_AreaName + "'").Count() == 0)
                                        {
                                            DataRow addDR = result.NewRow();
                                            addDR["provincename"] = SName1[0].DistrictName;
                                            addDR["cityname"] = districts[i].F_AreaName;
                                            for (int columnIndex = 2; columnIndex < result.Columns.Count; columnIndex++)
                                            {

                                                if (result.Columns[columnIndex].ColumnName.Contains("discount"))
                                                {
                                                    addDR["discount"] = 0;
                                                }
                                                if (result.Columns[columnIndex].ColumnName.Contains("zlgccount"))
                                                {
                                                    addDR["zlgccount"] = 0;
                                                }
                                                addDR[columnIndex] = "0";
                                            }
                                            result.Rows.InsertAt(addDR, i + 2);
                                        }
                                    }
                                }
                                //}
                            }
                            else if (xzqhcode.Length == 6 && xzqhcode.EndsWith("00"))
                            {
                                districts = ssoWS.GetAreaListJson(xzqhcode.Substring(0, 2) + "0000").Where(p => p.F_AreaCode == xzqhcode).ToList();
                                //���������������
                                for (int i = 0; i < districts.Count; i++)
                                {
                                    if (result.Select("cityname ='" + districts[i].F_AreaName + "'").Count() == 0)
                                    {
                                        var SName1 = ssoWS.GetDistrctByCodes(xzqhcode.Substring(0, 2) + "0000");
                                        DataRow addDR = result.NewRow();
                                        addDR["provincename"] = SName1[0].DistrictName;
                                        addDR["cityname"] = districts[i].F_AreaName;
                                        for (int columnIndex = 2; columnIndex < result.Columns.Count; columnIndex++)
                                        {

                                            if (result.Columns[columnIndex].ColumnName.Contains("discount"))
                                            {
                                                addDR["discount"] = 0;
                                            }
                                            if (result.Columns[columnIndex].ColumnName.Contains("zlgccount"))
                                            {
                                                addDR["zlgccount"] = 0;
                                            }
                                            addDR[columnIndex] = "0";
                                        }
                                        result.Rows.InsertAt(addDR, i + result.Rows.Count);
                                    }
                                }
                            }
                        }
                        if (dv.Table.Columns.Contains("provincename"))
                        {
                            dv.Sort = "provincename desc";
                            aa = dv.ToTable();
                            result = aa;
                        }
                        for (int i = 0; i < result.Rows.Count; i++)
                        {
                            if (result.Rows[i]["provincename"].ToString() != "" && result.Rows[i]["cityname"].ToString() != "")
                            {
                                result.Rows[i]["provincename"] = "";
                            }
                        }
                        return result;
                    }
                    if (ZLGCUNIT == "��")
                    {
                        string QueryDE = QueryStrCounty.ToString() + " where 1=1 ";
                        string QueryXZQH = "";
                        if (ProvinceName != "")
                        {
                            string[] ProvinceNames = ProvinceName.Split(',');
                            for (int i = 0; i < ProvinceNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and provincename in( '" + ProvinceNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or provincename in( '" + ProvinceNames[i] + "')";
                                }
                            }
                            //QueryXZQH += " and provincename = '" + ProvinceName + "'";
                        }
                        //QueryDE += QueryXZQH;
                        if (CityName != "")
                        {
                            if (ProvinceName != "")
                            {
                                QueryXZQH += " and provincename = '" + ProvinceName + "'";
                            }
                            //QueryDE += QueryXZQH;
                            string[] CityNames = CityName.Split(',');
                            for (int i = 0; i < CityNames.Length; i++)
                            {
                                if (i == 0)
                                {
                                    QueryXZQH += " and cityname in( '" + CityNames[i] + "')";
                                }
                                else
                                {
                                    QueryXZQH += " or cityname in( '" + CityNames[i] + "')";
                                }
                            }
                            if (CountyName != "")
                            {
                                string[] CountyNames = CountyName.Split(',');
                                for (int j = 0; j < CountyNames.Length; j++)
                                {
                                    if (j == 0)
                                    {
                                        QueryXZQH += " and countryname = '" + CountyNames[j] + "'";
                                    }
                                    else
                                    {
                                        QueryXZQH += " or countryname = '" + CountyNames[j] + "'";
                                    }
                                }
                            }
                        }
                        QueryDE += QueryXZQH;
                        var queryResult = QueryDE;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                        DataTable result = new DataTable();
                        result.Columns.Add("provincename");
                        result.Columns.Add("cityname");
                        result.Columns.Add("countryname");
                        result.Columns.Add("discount");
                        result.Columns.Add("zlgccount");
                        for (int i = 0; i < result_Query.Rows.Count; i++)
                        {
                            //if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && result_Query.Rows[i]["countryname"].ToString() != "" && result_Query.Rows.Count>1)
                            //{
                            //    result_Query.Rows[i]["provincename"] = "";
                            //    result_Query.Rows[i]["cityname"] = "";
                            //}
                            //if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && result_Query.Rows[i]["countryname"].ToString() == "" && i != 0)
                            //{
                            //    result_Query.Rows[i]["provincename"] = "";
                            //}
                            DataRow result_dr = result.NewRow();
                            result_dr["provincename"] = result_Query.Rows[i]["provincename"].ToString();
                            result_dr["cityname"] = result_Query.Rows[i]["cityname"].ToString();
                            result_dr["countryname"] = result_Query.Rows[i]["countryname"].ToString();
                            result_dr["discount"] = result_Query.Rows[i]["discount"].ToString();
                            result_dr["zlgccount"] = result_Query.Rows[i]["zlgccount"].ToString();
                            result.Rows.Add(result_dr);
                        }
                        //return result;
                        List<string> selectXZQH = new List<string>();
                        selectXZQH = ssoWS.GetAreaListJson(xzqhcode).Select(p => p.F_AreaCode).ToList();
                        List<AreaEntity> districts = new List<AreaEntity>(); List<AreaEntity> districts1 = new List<AreaEntity>();
                        DataTable aa = result.Copy();
                        DataView dv = result.DefaultView;
                        var codes = xzqhcode.Split(',');
                        if (result != null)
                        {
                            if (xzqhcode.EndsWith("00"))
                            {
                                //if (codes.Length > 1)
                                //{
                                for (var a = 0; a < codes.Length; a++)
                                {
                                    var SName1 = ssoWS.GetDistrctByCodes(codes[a]).Where(p => p.DistrictCode == codes[a]).ToArray();
                                    var SName2 = ssoWS.GetDistrctByCodes(codes[a].Substring(0, 2) + "0000");
                                    districts = ssoWS.GetAreaListJson(codes[a]);
                                    //districts.AddRange(districts1);
                                    //if (result.Select("provincename ='" + SName2[0].DistrictName + "'").Count() == 0)
                                    //{
                                    //    DataRow addDR2 = result.NewRow();
                                    //    addDR2["provincename"] = SName2[0].DistrictName;
                                    //    result.Rows.InsertAt(addDR2, 0);
                                    //}
                                    if (result.Select("cityname ='" + SName1[0].DistrictName + "'").Count() == 0)
                                    {
                                        DataRow addDR3 = result.NewRow();
                                        addDR3["provincename"] = SName2[0].DistrictName;
                                        addDR3["cityname"] = SName1[0].DistrictName;
                                        result.Rows.InsertAt(addDR3, 0);
                                    }
                                    //���������������
                                    for (int i = 0; i < districts.Count; i++)
                                    {
                                        if (result.Select("countryname ='" + districts[i].F_AreaName + "'").Count() == 0)
                                        {
                                            DataRow addDR = result.NewRow();
                                            addDR["provincename"] = SName2[0].DistrictName;
                                            addDR["cityname"] = SName1[0].DistrictName;
                                            addDR["countryname"] = districts[i].F_AreaName;
                                            for (int columnIndex = 3; columnIndex < result.Columns.Count; columnIndex++)
                                            {

                                                if (result.Columns[columnIndex].ColumnName.Contains("discount"))
                                                {
                                                    addDR["discount"] = 0;
                                                }
                                                if (result.Columns[columnIndex].ColumnName.Contains("zlgccount"))
                                                {
                                                    addDR["zlgccount"] = 0;
                                                }
                                                addDR[columnIndex] = "0";
                                            }
                                            result.Rows.InsertAt(addDR, i + 2);
                                        }
                                    }

                                }
                                // }
                            }
                            else if (xzqhcode.Length == 6 && !xzqhcode.EndsWith("00"))
                            {
                                districts = ssoWS.GetAreaListJson(xzqhcode.Substring(0, 4) + "00").Where(p => p.F_AreaCode == xzqhcode).ToList();
                                //���������������
                                for (int i = 0; i < districts.Count; i++)
                                {
                                    if (result.Select("countryname ='" + districts[i].F_AreaName + "'").Count() == 0)
                                    {
                                        DataRow addDR = result.NewRow();
                                        var SName1 = ssoWS.GetDistrctByCodes(xzqhcode.Substring(0, 4) + "00").Where(p => p.DistrictCode == xzqhcode.Substring(0, 4) + "00").ToArray();
                                        var SName2 = ssoWS.GetDistrctByCodes(xzqhcode.Substring(0, 2) + "0000");
                                        addDR["provincename"] = SName2[0].DistrictName;
                                        addDR["cityname"] = SName1[0].DistrictName;
                                        addDR["countryname"] = districts[i].F_AreaName;
                                        for (int columnIndex = 3; columnIndex < result.Columns.Count; columnIndex++)
                                        {

                                            if (result.Columns[columnIndex].ColumnName.Contains("discount"))
                                            {
                                                addDR["discount"] = 0;
                                            }
                                            if (result.Columns[columnIndex].ColumnName.Contains("zlgccount"))
                                            {
                                                addDR["zlgccount"] = 0;
                                            }
                                            addDR[columnIndex] = "0";
                                        }
                                        result.Rows.InsertAt(addDR, i + result.Rows.Count);
                                    }
                                }
                            }
                            else if (xzqhcode.Length > 6 && !xzqhcode.EndsWith("00"))
                            {
                                //districts = ssoWS.GetAreaListJson(xzqhcode.Substring(0, 4) + "00").Where(p => p.F_AreaCode == xzqhcode).ToList();
                                for (var a = 0; a < codes.Length; a++)
                                {
                                    //var SName1 = ssoWS.GetDistrctByCodes(codes[a]).Where(p => p.DistrictCode == codes[a]).ToArray();
                                    //var SName2 = ssoWS.GetDistrctByCodes(codes[a].Substring(0, 2) + "0000");
                                    var SName1 = ssoWS.GetDistrctByCodes(xzqhcode.Substring(0, 4) + "00").Where(p => p.DistrictCode == xzqhcode.Substring(0, 4) + "00").ToArray();
                                    var SName2 = ssoWS.GetDistrctByCodes(xzqhcode.Substring(0, 2) + "0000");
                                    districts = ssoWS.GetAreaListJson(codes[a].Substring(0, 4) + "00").Where(p => p.F_AreaCode == codes[a]).ToList();
                                    //���������������
                                    for (int i = 0; i < districts.Count; i++)
                                    {
                                        if (result.Select("countryname ='" + districts[i].F_AreaName + "'").Count() == 0)
                                        {
                                            DataRow addDR = result.NewRow();

                                            addDR["provincename"] = SName2[0].DistrictName;
                                            addDR["cityname"] = SName1[0].DistrictName;
                                            addDR["countryname"] = districts[i].F_AreaName;
                                            for (int columnIndex = 3; columnIndex < result.Columns.Count; columnIndex++)
                                            {

                                                if (result.Columns[columnIndex].ColumnName.Contains("discount"))
                                                {
                                                    addDR["discount"] = 0;
                                                }
                                                if (result.Columns[columnIndex].ColumnName.Contains("zlgccount"))
                                                {
                                                    addDR["zlgccount"] = 0;
                                                }
                                                addDR[columnIndex] = "0";
                                            }
                                            result.Rows.InsertAt(addDR, i + result.Rows.Count);
                                        }
                                    }
                                }

                            }
                        }
                        if (dv.Table.Columns.Contains("provincename"))
                        {
                            dv.Sort = "provincename desc";
                            aa = dv.ToTable();
                            result = aa;
                        }
                        for (int i = 0; i < result.Rows.Count; i++)
                        {
                            if (result.Rows[i]["provincename"].ToString() != "" && result.Rows[i]["cityname"].ToString() != "" && result.Rows[i]["countryname"].ToString() != "" && i > 0)
                            {
                                result.Rows[i]["provincename"] = "";
                                result.Rows[i]["cityname"] = "";
                            }
                        }


                        return result;
                    }

                }
            }
            return result_Query;

        }

        /// <summary>
        /// ������ͳ���·���
        /// </summary>
        /// <param name="xzqhcode">��������</param>
        /// <param name="codeType">ʡ����</param>
        /// <param name="ZLGCYEAR">���</param>
        /// <param name="ZLGCUNIT">ͳ�Ƶ�λ</param>
        /// <returns></returns>
        public DataTable GetDataZLGCStatics(string xzqhcode, string codeType, string ZLGCYEAR, string ZLGCUNIT)
        {
            string sql = "select * from";
            string where1 = "1=1 ";
            if (!String.IsNullOrWhiteSpace(ZLGCYEAR))
            {
                where1 += "and to_char(XMJLXSJ,'yyyy-mm-dd') like '%" + ZLGCYEAR + "%'";
            }
            string[] xzqhcodes = xzqhcode.Split(',');
            switch (codeType)
            {
                case "ʡ":
                    if (xzqhcodes[0] != "")
                    {
                        for (var a = 0; a < xzqhcodes.Count(); a++)
                        {
                            if (a == 0)
                            {
                                where1 += "  and(PROVINCE in( '" + xzqhcodes[a] + "')";
                            }
                            else
                            {
                                where1 += " or PROVINCE in( '" + xzqhcodes[a] + "')";
                            }
                        }
                        where1 = where1 + ")";
                    }
                    //where1 += "and PROVINCE like '%" + xzqhcode + "%'";
                    break;
                case "��":
                    if (xzqhcodes[0] != "")
                    {
                        for (var a = 0; a < xzqhcodes.Count(); a++)
                        {
                            if (a == 0)
                            {
                                where1 += "  and(CITY in( '" + xzqhcodes[a] + "')";
                            }
                            else
                            {
                                where1 += " or CITY in( '" + xzqhcodes[a] + "')";
                            }
                        }
                        where1 = where1 + ")";
                    }
                    //where1 += "and CITY like '%" + xzqhcode + "%'";
                    break;
                case "��":
                    if (xzqhcodes[0] != "")
                    {
                        for (var a = 0; a < xzqhcodes.Count(); a++)
                        {
                            if (a == 0)
                            {
                                where1 += "  and(COUNTY in( '" + xzqhcodes[a] + "')";
                            }
                            else
                            {
                                where1 += " or COUNTY in( '" + xzqhcodes[a] + "')";
                            }
                        }
                        where1 = where1 + ")";
                    }
                    //where1 += "and COUNTY like '%" + xzqhcode + "%'";
                    break;
            }
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<string> _codes2 = _codes.Where(p => p.Contains("00")).ToList();
            if (_codes2.Count > 1)
            {
                where1 += " and CITY in('" + string.Join("','", _codes2.ToArray()) + "') ";//ʡ���û�

            }
            else if (_codes2.Count == 1)
            {
                if (_codes2[0] != "000000" && !_codes2[0].Equals("0"))
                {
                    where1 += "  and COUNTY in('" + string.Join("','", _codes.ToArray()) + "') ";//�м��û�

                }
                else if (_codes2[0] == "000000")
                {
                    where1 += "  ";//ȫ���û�

                }
                else
                {
                    where1 += " ";//ʡ���û�

                }
            }
            string sql1 = String.Format("select PROVINCENAME as ʡ,CITYNAME as ��,COUNTYNAME as ��,UNIFIEDCODE as �ֺ���,XMPFZJ as �����ʽ�,  "
                       + "CASE WHEN ZLSTATE = '��Ŀ����' THEN  1 ELSE 0 END AS ��Ŀ����, CASE WHEN ZLSTATE = 'Ұ�⿱��' THEN 1 ELSE 0 END AS Ұ�⿱��, "
                       + " CASE WHEN ZLSTATE = 'ʩ�����' THEN 1 ELSE 0 END AS ʩ�����,CASE WHEN ZLSTATE = '����ʩ��' THEN 1 ELSE 0 END AS ����ʩ��,    "
                       + " CASE WHEN ZLSTATE = '���̼���' THEN 1 ELSE 0 END AS ���̼���,CASE WHEN ZLSTATE = '��Ŀ����' THEN 1 ELSE 0 END AS ��Ŀ����  "
                       + "from (select * from TBL_ZLGC_BASEINFO where {0} and  COUNTY is not null) qryTable", where1);

            string strSum = "count(DISTINCT(�ֺ���)) as  �����ֺ������, SUM(��Ŀ���� + Ұ�⿱�� + ʩ����� + ����ʩ�� + ���̼��� + ��Ŀ����) as �����̸���, SUM(��Ŀ����) AS ��Ŀ�������, SUM(Ұ�⿱��) AS Ұ�⿱�����,"
                       + " SUM(ʩ�����) AS ʩ����Ƹ���, SUM(����ʩ��) AS ����ʩ������,SUM(���̼���) AS ���̼������,SUM(��Ŀ����) AS ��Ŀ���ո���, SUM(�����ʽ�) AS �����ʽ�����  ";

            switch (ZLGCUNIT)
            {
                case "ʡ":
                    sql += "(select ʡ," + strSum + "from (" + sql1 + ") t group by  rollup(t.ʡ) ) a  order by a.ʡ ";
                    break;
                case "��":
                    sql += "(select ʡ,��," + strSum + "from (" + sql1 + ") t group by  rollup(t.ʡ,t.��) ) a  order by a.ʡ,a.�� desc";
                    break;
                case "��":
                    sql += "(select ʡ,��,��," + strSum + "from (" + sql1 + ") t group by  rollup(t.ʡ,t.��,t.��) ) a  order by a.ʡ desc,a.�� desc,a.�� desc";
                    break;
            }
            return this.BaseRepository().FindTable(sql);
        }



        public object PdState1(string id)
        {
            var ysState = "0"; var kcState = "0"; var sgState = "0"; var sjState = "0"; var jlState = "0"; var states = new object();
            string yssql = ""; DataTable ys = new DataTable();
            string kcsql = ""; DataTable kc = new DataTable();
            string sgbrsql = ""; DataTable sg = new DataTable();
            string sjgcsql = ""; DataTable sj = new DataTable();
            string jlgcsql = ""; DataTable jl = new DataTable();
            if (!String.IsNullOrWhiteSpace(id))
            {
                yssql = "select * from TBL_ZLGC_YSINFO where ZLGCID='" + id + "'";
                kcsql = "select * from TBL_ZLGC_KCINFO where ZLGCID='" + id + "'";
                sgbrsql = "select * from TBL_ZLGC_SGINFO where ZLGCID='" + id + "'";
                sjgcsql = "select * from TBL_ZLGC_SJINFO where ZLGCID='" + id + "'";
                jlgcsql = "select * from TBL_ZLGC_JLINFO where ZLGCID='" + id + "'";
            }
            ys = this.BaseRepository().FindTable(yssql);
            kc = this.BaseRepository().FindTable(kcsql);
            sg = this.BaseRepository().FindTable(sgbrsql);
            sj = this.BaseRepository().FindTable(sjgcsql);
            jl = this.BaseRepository().FindTable(jlgcsql);
            if (ys.Rows.Count > 0)
            {
                ysState = "1";
            }
            if (kc.Rows.Count > 0)
            {
                kcState = "1";
            }
            if (sg.Rows.Count > 0)
            {
                sgState = "1";
            }
            if (sj.Rows.Count > 0)
            {
                sjState = "1";
            }
            if (jl.Rows.Count > 0)
            {
                jlState = "1";
            }
            state1ss ts = new state1ss();
            ts.ysState = ysState;
            ts.kcState = kcState;
            ts.sgState = sgState;
            ts.sjState = sjState;
            ts.jlState = jlState;
            return ts;
        }
        public class state1ss
        {
            public string ysState { get; set; }
            public string kcState { get; set; }
            public string sgState { get; set; }
            public string sjState { get; set; }
            public string jlState { get; set; }
        }

        /// <summary>
        /// ��ȡ������ͳ�ƽ��
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZLGTJResult(string queryJson)
        {
            var list = GetListNew(queryJson);
            return list;
        }
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetListNew(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_BASEINFOEntity>();
            return this.BaseRepository().FindList(queryJsonExpressionNew(queryJson));
        }
        System.Linq.Expressions.Expression<Func<TBL_ZLGC_BASEINFOEntity, bool>> queryJsonExpressionNew(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_BASEINFOEntity>();
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                string AreaCode = json.AreaCode;
                if (!string.IsNullOrEmpty(AreaCode))
                {
                    if (AreaCode != "0")
                    {
                        if (AreaCode.EndsWith("0000"))
                        {
                            expression = expression.And(t => t.PROVINCE.Equals(AreaCode));
                        }
                        else if (AreaCode.EndsWith("00"))
                        {
                            expression = expression.And(t => t.CITY.Equals(AreaCode));
                        }
                        else
                        {
                            expression = expression.And(t => t.COUNTY.Equals(AreaCode));
                        }
                    }
                    //expression = expression.And(s=>s.)
                }
                if (json.COMPPARAM != "" && json.COMPPARAM != null)
                {
                    string COMPPARAM = json.COMPPARAM;
                    if (!string.IsNullOrEmpty(COMPPARAM))
                    {
                        expression = expression.And(t => t.ZLGCNAME.Contains(COMPPARAM) || t.UNIFIEDCODE.Contains(COMPPARAM) || t.DISASTERNAME.Contains(COMPPARAM) || t.DISASTERTYPE.Contains(COMPPARAM));
                    }
                }
            }
            return expression;
        }

        /// <summary>
        /// ʡ������ɸѡ
        /// </summary>
        /// <param name="result_query"></param>
        /// <param name="DISProvinceNames"></param>
        /// <param name="dyResult"></param>
        /// <param name="ZLGCResult"></param>
        /// <returns></returns>
        public DataTable province_func(DataTable result_query, List<string> DISProvinceNames, dynamic dyResult, IEnumerable<TBL_ZLGC_BASEINFOEntity> ZLGCResult)
        {
            int discount = 0;
            int montcount = 0;
            result_query.Columns.Add("provincename");
            result_query.Columns.Add("disastercount");
            result_query.Columns.Add("zlgccount");

            for (int i = 0; i < DISProvinceNames.Count(); i++)
            {
                foreach (var item in dyResult)
                {
                    if (item.PROVINCENAME == DISProvinceNames[i])
                    {
                        discount++;
                    }
                }
                foreach (var item in ZLGCResult)
                {
                    if (item.PROVINCENAME == DISProvinceNames[i])
                    {
                        montcount++;
                    }
                }
                DataRow result_dr = result_query.NewRow();
                result_dr["provincename"] = DISProvinceNames[i];
                result_dr["disastercount"] = discount;
                result_dr["zlgccount"] = montcount;
                result_query.Rows.Add(result_dr);
            }
            return result_query;
        }


        /// <summary>
        /// �м�����ɸѡ
        /// </summary>
        /// <param name="result_query"></param>
        /// <param name="DISCityNames"></param>
        /// <param name="dyResult"></param>
        /// <param name="MONITORPOINTResult"></param>
        /// <returns></returns>
        public DataTable city_func(DataTable result_query, List<string> DISProvinceNames, List<string> DISCityNames, dynamic dyResult, IEnumerable<TBL_ZLGC_BASEINFOEntity> ZLGCResult)
        {
            //for (int i = 0; i < DISCityNames.Count(); i++)
            //{
            //    int discount_city = 0;
            //    int montcount_city = 0;
            //    foreach (var item in dyResult)
            //    {
            //        if (item.CITYNAME == DISCityNames[i])
            //        {
            //            discount_city++;
            //        }
            //    }
            //    foreach (var item in ZLGCResult)
            //    {
            //        if (item.CITYNAME == DISCityNames[i])
            //        {
            //            montcount_city++;
            //        }
            //    }

            //    DataRow result_dr = result_query.NewRow();
            //    result_dr["provincename"] = "";
            //    result_dr["cityname"] = DISCityNames[i].ToString();
            //    result_dr["disastercount"] = discount_city;
            //    result_dr["zlgccount"] = montcount_city;
            //    result_query.Rows.Add(result_dr);
            //}
            //return result_query;
            for (int i = 0; i < DISProvinceNames.Count(); i++)
            {
                int discount_city = 0;
                int montcount_city = 0;
                foreach (var item in dyResult)
                {
                    if (item.PROVINCENAME == DISProvinceNames[i])
                    {
                        discount_city++;
                    }
                }
                foreach (var item in ZLGCResult)
                {
                    if (item.PROVINCENAME == DISProvinceNames[i])
                    {
                        montcount_city++;
                    }
                }
                DataRow result_dr = result_query.NewRow();
                result_dr["provincename"] = DISProvinceNames[i].ToString();
                //result_dr["cityname"] = DISCityNames[i].ToString().Split(',')[1];
                result_dr["disastercount"] = discount_city;
                result_dr["zlgccount"] = montcount_city;
                result_query.Rows.Add(result_dr);
                //�м����Ƶ�ѭ��
                List<string> cityname_C = new List<string>();
                for (int j = 0; j < DISCityNames.Count; j++)
                {
                    int discount_county = 0;
                    int montcount_county = 0;
                    foreach (var item in dyResult)
                    {
                        if (DISProvinceNames[i] == DISCityNames[j].ToString().Split(',')[0].ToString() && item.PROVINCENAME == DISCityNames[j].ToString().Split(',')[0].ToString() && item.CITYNAME == DISCityNames[j].ToString().Split(',')[1].ToString())
                        {
                            discount_county++;
                        }
                    }
                    foreach (var item in ZLGCResult)
                    {
                        if (DISProvinceNames[i] == DISCityNames[j].ToString().Split(',')[0].ToString() && item.PROVINCENAME == DISCityNames[j].ToString().Split(',')[0].ToString() && item.CITYNAME == DISCityNames[j].ToString().Split(',')[1].ToString())
                        {
                            montcount_county++;
                        }
                    }
                    if (DISProvinceNames[i] == DISCityNames[j].ToString().Split(',')[0].ToString() && !cityname_C.Contains(DISCityNames[j].ToString().Split(',')[1].ToString()))
                    {
                        //�ж�����
                        cityname_C.Add(DISCityNames[j].ToString().Split(',')[1].ToString());
                        DataRow result_dr_COUNTY = result_query.NewRow();
                        result_dr_COUNTY["provincename"] = "";
                        result_dr_COUNTY["cityname"] = DISCityNames[j].ToString().Split(',')[1].ToString();
                        result_dr_COUNTY["disastercount"] = discount_county;
                        result_dr_COUNTY["zlgccount"] = montcount_county;
                        result_query.Rows.Add(result_dr_COUNTY);
                    }
                }
            }
            return result_query;
        }


        /// <summary>
        /// �ؼ�����ɸѡ
        /// </summary>
        /// <param name="result_query"></param>
        /// <param name="DISCityNames"></param>
        /// <param name="DISCountyNames"></param>
        /// <param name="dyResult"></param>
        /// <param name="MONITORPOINTResult"></param>
        /// <returns></returns>
        public DataTable county_func(DataTable result_query, List<string> DISCityNames, List<string> DISCountyNames, dynamic dyResult, IEnumerable<TBL_ZLGC_BASEINFOEntity> ZLGCResult)
        {
            for (int i = 0; i < DISCityNames.Count(); i++)
            {
                int discount_city = 0;
                int montcount_city = 0;
                foreach (var item in dyResult)
                {
                    if (item.CITYNAME == DISCityNames[i])
                    {
                        discount_city++;
                    }
                }
                foreach (var item in ZLGCResult)
                {
                    if (item.CITYNAME == DISCityNames[i])
                    {
                        montcount_city++;
                    }
                }
                DataRow result_dr = result_query.NewRow();
                result_dr["provincename"] = "";
                result_dr["cityname"] = DISCityNames[i].ToString();
                result_dr["disastercount"] = discount_city;
                result_dr["zlgccount"] = montcount_city;
                result_query.Rows.Add(result_dr);
                //�ؼ����Ƶ�ѭ��
                List<string> countyname_C = new List<string>();
                for (int j = 0; j < DISCountyNames.Count; j++)
                {
                    int discount_county = 0;
                    int montcount_county = 0;
                    foreach (var item in dyResult)
                    {
                        if (DISCityNames[i] == DISCountyNames[j].ToString().Split(',')[0].ToString() && item.CITYNAME == DISCountyNames[j].ToString().Split(',')[0].ToString() && item.COUNTYNAME == DISCountyNames[j].ToString().Split(',')[1].ToString())
                        {
                            discount_county++;
                        }
                    }
                    foreach (var item in ZLGCResult)
                    {
                        if (DISCityNames[i] == DISCountyNames[j].ToString().Split(',')[0].ToString() && item.CITYNAME == DISCountyNames[j].ToString().Split(',')[0].ToString() && item.COUNTYNAME == DISCountyNames[j].ToString().Split(',')[1].ToString())
                        {
                            montcount_county++;
                        }
                    }
                    if (DISCityNames[i] == DISCountyNames[j].ToString().Split(',')[0].ToString() && !countyname_C.Contains(DISCountyNames[j].ToString().Split(',')[1].ToString()))
                    {
                        //�ж�����
                        countyname_C.Add(DISCountyNames[j].ToString().Split(',')[1].ToString());
                        DataRow result_dr_COUNTY = result_query.NewRow();
                        result_dr_COUNTY["provincename"] = "";
                        result_dr_COUNTY["cityname"] = "";
                        result_dr_COUNTY["countyname"] = DISCountyNames[j].ToString().Split(',')[1].ToString();
                        result_dr_COUNTY["disastercount"] = discount_county;
                        result_dr_COUNTY["zlgccount"] = montcount_county;
                        result_query.Rows.Add(result_dr_COUNTY);
                    }
                }
            }
            return result_query;
        }
        public DataTable county_func2(DataTable result_query, List<string> DISProvinceNames, List<string> DISCityNames, List<string> DISCitys, List<string> DISCountyNames, dynamic dyResult, IEnumerable<TBL_ZLGC_BASEINFOEntity> ZLGCResult)
        {
            for (int i = 0; i < DISProvinceNames.Count(); i++)
            {
                int discount_city = 0;
                int montcount_city = 0;
                foreach (var item in dyResult)
                {
                    if (item.PROVINCENAME == DISProvinceNames[i])
                    {
                        discount_city++;
                    }
                }
                foreach (var item in ZLGCResult)
                {
                    if (item.PROVINCENAME == DISProvinceNames[i])
                    {
                        montcount_city++;
                    }
                }
                DataRow result_dr = result_query.NewRow();
                result_dr["provincename"] = DISProvinceNames[i].ToString();
                //result_dr["cityname"] = DISCityNames[i].ToString().Split(',')[1];
                result_dr["disastercount"] = discount_city;
                result_dr["zlgccount"] = montcount_city;
                result_query.Rows.Add(result_dr);
                //�м����Ƶ�ѭ��
                List<string> cityname_C = new List<string>();
                for (int j = 0; j < DISCityNames.Count; j++)
                {
                    int discount_county = 0;
                    int montcount_county = 0;
                    foreach (var item in dyResult)
                    {
                        if (DISProvinceNames[i] == DISCityNames[j].ToString().Split(',')[0].ToString() && item.PROVINCENAME == DISCityNames[j].ToString().Split(',')[0].ToString() && item.CITYNAME == DISCityNames[j].ToString().Split(',')[1].ToString())
                        {
                            discount_county++;
                        }
                    }
                    foreach (var item in ZLGCResult)
                    {
                        if (DISProvinceNames[i] == DISCityNames[j].ToString().Split(',')[0].ToString() && item.PROVINCENAME == DISCityNames[j].ToString().Split(',')[0].ToString() && item.CITYNAME == DISCityNames[j].ToString().Split(',')[1].ToString())
                        {
                            montcount_county++;
                        }
                    }
                    if (DISProvinceNames[i] == DISCityNames[j].ToString().Split(',')[0].ToString() && !cityname_C.Contains(DISCityNames[j].ToString().Split(',')[1].ToString()))
                    {
                        //�ж�����
                        cityname_C.Add(DISCityNames[j].ToString().Split(',')[1].ToString());
                        DataRow result_dr_COUNTY = result_query.NewRow();
                        result_dr_COUNTY["provincename"] = "";
                        result_dr_COUNTY["cityname"] = DISCityNames[j].ToString().Split(',')[1].ToString();
                        result_dr_COUNTY["disastercount"] = discount_county;
                        result_dr_COUNTY["zlgccount"] = montcount_county;
                        result_query.Rows.Add(result_dr_COUNTY);
                    }
                    //�����Ƶ�ѭ��
                    List<string> countyname_C = new List<string>();
                    for (int K = 0; K < DISCountyNames.Count; K++)
                    {
                        foreach (var item in dyResult)
                        {
                            if (DISCitys[i] == DISCountyNames[K].ToString().Split(',')[0].ToString() && item.CITYNAME == DISCountyNames[K].ToString().Split(',')[0].ToString() && item.COUNTYNAME == DISCountyNames[K].ToString().Split(',')[1].ToString())
                            {
                                discount_county++;
                            }
                        }
                        foreach (var item in ZLGCResult)
                        {
                            if (DISCitys[i] == DISCountyNames[K].ToString().Split(',')[0].ToString() && item.CITYNAME == DISCountyNames[K].ToString().Split(',')[0].ToString() && item.COUNTYNAME == DISCountyNames[K].ToString().Split(',')[1].ToString())
                            {
                                montcount_county++;
                            }
                        }
                        if (DISCitys[i] == DISCountyNames[K].ToString().Split(',')[0].ToString() && !countyname_C.Contains(DISCountyNames[K].ToString().Split(',')[1].ToString()))
                        {
                            //�ж�����
                            countyname_C.Add(DISCountyNames[K].ToString().Split(',')[1].ToString());
                            DataRow result_dr_COUNTY = result_query.NewRow();
                            result_dr_COUNTY["provincename"] = "";
                            result_dr_COUNTY["cityname"] = "";
                            result_dr_COUNTY["countyname"] = DISCountyNames[K].ToString().Split(',')[1].ToString();
                            result_dr_COUNTY["disastercount"] = discount_county;
                            result_dr_COUNTY["zlgccount"] = montcount_county;
                            result_query.Rows.Add(result_dr_COUNTY);
                        }
                    }
                }

            }
            return result_query;
        }
        /// <summary>
        /// ��ȡ��ͼժҪ��Ϣ
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZYList(string queryJson, string condition)
        {
            var queryParam = condition.ToJObject();
            var expression = queryJsonExpression(queryJson);
            List<TBL_ZLGC_BASEINFOEntity> result = new List<TBL_ZLGC_BASEINFOEntity>();
            var list = this.BaseRepository().FindList(expression).ToList();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                foreach (var item in list)
                {
                    if (!item.LONGITUDE.HasValue || !item.LATITUDE.HasValue)
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.Value.ToString(), item.LATITUDE.Value.ToString());
                    if (isInsert)
                    {
                        result.Add(item);
                    }

                }
                return result;
            }
            if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                double x = queryParam["x"].ToDouble();
                double y = queryParam["y"].ToDouble();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (!item.LONGITUDE.HasValue || !item.LATITUDE.HasValue)
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                    if (isInsert)
                    {
                        result.Add(item);
                    }

                }
                return result;
            }
            if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                string polyline = queryParam["polyline"].ToString();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.IsIntersects(polyline, radius, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        result.Add(item);
                    }

                }
                return result;
            }
            return list;
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public string RemoveForm(string keyValue)
        {
            //this.BaseRepository().Delete(keyValue);
            try
            {
                string Result = "";
                string queryJson = "{\"ZLGCID\":\"" + keyValue + "\"}";
                //���Ȳ�ѯ��ʩ���ֱ����Ƿ���¼
                var ZLGC_SGlIST = ZLGC_SGservice.GetListByZlgcID(queryJson);
                var ZLGC_YSINFO = TBL_ZLGC_YSINFO.GetListByZlgcID(queryJson);//���ս׶α�
                var ZLGC_KCINFO = TBL_ZLGC_KCINFO.GetListByZlgcID(queryJson);//����׶α�
                var ZLGC_JLINFO = TBL_ZLGC_JLINFO.GetListByZlgcID(queryJson);//����׶α�
                var ZLGC_SJINFO = TBL_ZLGC_SJINFO.GetListByZlgcID(queryJson);//��ƽ׶α�
                if (ZLGC_KCINFO.Count() > 0)
                {
                    TBL_ZLGC_KCINFO.RemoveForm(keyValue);
                    //Result = "ɾ��ʧ�ܣ�Ұ�⿱������Ӽ�¼,����ɾ��Ұ�⿱����Ϣ��";
                }
                if (ZLGC_SGlIST.Count() > 0)
                {
                    ZLGC_SGservice.RemoveForm(keyValue);
                    //Result = "ɾ��ʧ�ܣ�ʩ����ƴ����Ӽ�¼,����ɾ��ʩ�������Ϣ��";
                }
                if (ZLGC_SJINFO.Count() > 0)
                {
                    TBL_ZLGC_SJINFO.RemoveForm(keyValue);
                    //Result = "ɾ��ʧ�ܣ�����ʩ�������Ӽ�¼,����ɾ������ʩ����Ϣ��";
                }
                if (ZLGC_JLINFO.Count() > 0)
                {
                    TBL_ZLGC_JLINFO.RemoveForm(keyValue);
                    //Result = "ɾ��ʧ�ܣ����̼�������Ӽ�¼,����ɾ�����̼�����Ϣ��";
                }
                if (ZLGC_YSINFO.Count() > 0)
                {
                    TBL_ZLGC_YSINFO.RemoveForm(keyValue);
                    //Result = "ɾ��ʧ�ܣ���Ŀ���մ����Ӽ�¼,����ɾ����Ŀ������Ϣ��";
                }
                //else
                //{
                this.BaseRepository().Delete(keyValue);
                Result = "ɾ���ɹ�";
                //}
                return Result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public PASTBL_ZLGC_BASEINFOEntity SaveForm(string keyValue, TBL_ZLGC_BASEINFOEntity entity)
        {
            PASTBL_ZLGC_BASEINFOEntity data = new PASTBL_ZLGC_BASEINFOEntity();
            if (!string.IsNullOrEmpty(keyValue))
            {
                if (this.BaseRepository().FindEntity(keyValue) == null)
                {

                    this.BaseRepository().Insert(entity);
                    data.GUID = entity.GUID;

                }
                else
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                    data.GUID = entity.GUID;

                }
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
                data.GUID = entity.GUID;

            }

            return data;
        }

        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public string SaveForm_New(string keyValue, TBL_ZLGC_BASEINFOEntity entity)
        {
            string result = "";
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
                result = entity.GUID.ToString();
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
                result = entity.GUID.ToString();
            }
            return result;
        }

        #endregion
    }
}
