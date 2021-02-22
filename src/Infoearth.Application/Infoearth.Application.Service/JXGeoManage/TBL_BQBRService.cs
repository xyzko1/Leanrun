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
using Infoearth.Application.Entity;
using Infoearth.Application.Entity.SystemManage;
using Newtonsoft.Json.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:25
    /// �� ������Ǩ������Ϣ��
    /// </summary>
    public class TBL_BQBRService : RepositoryFactory<TBL_BQBREntity>, TBL_BQBRIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        private static EchartEntityNEWS _districtsDataCount = null;
        #region ��ͼ�ۺ�
        public EchartEntityNEWS GetListCodes()
        {
            _districtsDataCount = (EchartEntityNEWS)CacheHelper.GetCache("��Ǩ���þۺ�");
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
            //string sql = "select *  from TBL_BQBR ";
            //if (!_codes.Contains("000000"))
            //{
            //    sql += " where SUBSTR(UNIFIEDCODE,0,6)  in('" + string.Join("','", _codes.ToArray()) + "') ";
            //}
            //returnValue.data = this.BaseRepository().FindTable(sql);
            //CacheHelper.SetCache("��Ǩ���þۺ�", returnValue);//д����
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
            string sql2 = string.Format("select  '{0}' name {1} from  TBL_BQBR  where 1=1 ", "����", sql);
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
        public IEnumerable<TBL_BQBREntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<TBL_BQBREntity>();
            return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);
        }
        public IEnumerable<tbl_bqbrnew> GetPageListNEW(Pagination pagination, string queryJson)
        {

            dynamic json = JToken.Parse(queryJson) as dynamic;
            //ɸѡ����
            string sqlWhere = "where 1=1"; string sqlWhere1 = "where 1=1";
            //��Ŀ����
            string XMMC = json.XMMC;
            if (!string.IsNullOrEmpty(XMMC))
            {
                sqlWhere += string.Format(" and t.XMMC like '%{0}%'", XMMC);
            }
            //����λ��
            string LOCATION = json.LOCATION;
            if (!string.IsNullOrEmpty(LOCATION))
            {
                sqlWhere += string.Format(" and t.LOCATION like '%{0}%'", LOCATION);
            }
            //�ֺ�����
            string DISASTERTYPE = json.DISASTERTYPE;
            if (!string.IsNullOrEmpty(DISASTERTYPE))
            {
                sqlWhere += string.Format(" and t.DISASTERTYPE = '{0}'", DISASTERTYPE);
            }
            //��Ǩ����
            string BQHS1 = json.bqhs1; string BQHS2 = json.bqhs2;
            if (!string.IsNullOrEmpty(BQHS1) && !string.IsNullOrEmpty(BQHS2))
            {
                sqlWhere1 += string.Format(" and s.HS >= {0}", BQHS1);
                sqlWhere1 += string.Format(" and s.HS <= {0}", BQHS2);
            }
            else if (!string.IsNullOrEmpty(BQHS1))
            {
                sqlWhere1 += string.Format(" and s.HS = {0}", BQHS1);
            }
            else if (!string.IsNullOrEmpty(BQHS2))
            {
                sqlWhere1 += string.Format(" and s.HS = {0}", BQHS2);
            }
            //��������
            string AreaCode = json.AreaCode;
            if (AreaCode != "0")
            {
                if (AreaCode.EndsWith("0000"))
                {
                    AreaCode = AreaCode.Substring(0, 2);
                }
                else if (AreaCode.EndsWith("00"))
                {
                    AreaCode = AreaCode.Substring(0, 4);
                }
                if (!string.IsNullOrEmpty(AreaCode))
                {
                    sqlWhere += string.Format(" and t.UNIFIEDCODE like  '{0}%'", AreaCode);
                }
            }
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<string> _codes2 = _codes.Where(p => p.Contains("00")).ToList();
            if (_codes2.Count > 1)
            {
                sqlWhere += " and CITY in('" + string.Join("','", _codes2.ToArray()) + "') ";//ʡ���û�

            }
            else if (_codes2.Count == 1)
            {
                if (_codes2[0] != "000000" && !_codes2[0].Equals("0"))
                {
                    sqlWhere += "  and COUNTY in('" + string.Join("','", _codes.ToArray()) + "') ";//�м��û�

                }
                else if (_codes2[0] == "000000")
                {
                    sqlWhere += "  ";//ȫ���û�

                }
                else
                {
                    sqlWhere += " ";//ʡ���û�

                }
            }
            else
            {
                sqlWhere += "  and COUNTY in('" + string.Join("','", _codes.ToArray()) + "') ";//�����û�

            }
            //��ʼʱ��
            string BQBRSTARTTIME = json.BQBRSTARTTIME; string BQBRENDTIME = json.BQBRENDTIME;
            if (!string.IsNullOrEmpty(BQBRSTARTTIME))
            {
                BQBRSTARTTIME = BQBRSTARTTIME.Substring(0, 4);
                sqlWhere += string.Format(" and t.ANNUAL >= '{0}' ", BQBRSTARTTIME);
            }
            //����ʱ��
            if (!string.IsNullOrEmpty(BQBRENDTIME))
            {
                BQBRENDTIME = BQBRENDTIME.Substring(0, 4);
                sqlWhere += string.Format(" and t.ANNUAL <= '{0}' ", BQBRENDTIME);
            }
            //һ���ֶ��ж��ֺ������ơ��ֺ�����
            if (json.COMPPARAM != "" && json.COMPPARAM != null)
            {
                string COMPPARAM = json.COMPPARAM;
                if (!string.IsNullOrEmpty(COMPPARAM))
                {
                    sqlWhere += string.Format(" and ( t.DISASTERNAME like  '%" + COMPPARAM + "%' or  t.UNIFIEDCODE =  '" + COMPPARAM + "' or t.XMMC like  '%" + COMPPARAM + "%') ");
                }
            }
            string strsql = "select * from (select UNIFIEDCODE,DISASTERNAME ,LOCATION,DISASTERTYPE,LATITUDE,LONGITUDE,count(UNIFIEDCODE) HS,sum(MOVEDECIMAL) BQRS,sum(ZAZBTJE) BTJR,sum(case when SFYS=1 then 1 else 0 end) YYS ,sum(case when SFWC=1 then 1 else 0 end) YWC  from TBL_BQBR t  " + sqlWhere + " group by  UNIFIEDCODE,DISASTERNAME,LOCATION,DISASTERTYPE,LATITUDE,LONGITUDE) s " + sqlWhere1;
            RepositoryFactory<tbl_bqbrnew> d = new RepositoryFactory<tbl_bqbrnew>();
            return d.BaseRepository().FindList(strsql, pagination);
            //return this.BaseRepository().
        }
        /// <summary>
        /// ��ȡ��ͼժҪ��Ϣ��ѯ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>����ָ���ֶ�</returns>
        public IEnumerable<TBL_BQBREntity> GetZYPageList(string queryJson, string condition)
        {

            try
            {
                var queryParam = condition.ToJObject();
                var expression = queryJsonExpression(queryJson);
                List<TBL_BQBREntity> result = new List<TBL_BQBREntity>();
                var list = this.BaseRepository().FindList(expression).Select(t => new TBL_BQBREntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, PROVINCE = t.PROVINCE, CITY = t.CITY, COUNTY = t.COUNTY, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID, MODIFYTIME = t.MODIFYTIME == null ? Convert.ToDateTime("1970-01-01") : t.MODIFYTIME }).ToList();
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
        System.Linq.Expressions.Expression<Func<TBL_BQBREntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_BQBREntity>();

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

                string DISASTERNAME = "";
                string UNIFIEDCODE = "";
                string XMMC = "";
                string DISASTERTYPE = "";
                string ISCOMPLETE = "";
                string ISACCEPTANCE = "";
                string BQBRSTARTTIME = "";
                string BQBRENDTIME = "";
                string LOCATION = "";

                if (json.SELECTQUERYTYPE == "DISASTERNAME")
                {
                    DISASTERNAME = json.SELECTQUERYCONTENT;
                }
                if (json.SELECTQUERYTYPE == "UNIFIEDCODE")
                {
                    UNIFIEDCODE = json.SELECTQUERYCONTENT;
                }
                if (json.SELECTQUERYTYPE == "DISASTERTYPE")
                {
                    DISASTERTYPE = json.SELECTQUERYCONTENT;
                }
                if (json.SELECTQUERYTYPE == "ISCOMPLETE")
                {
                    ISCOMPLETE = json.SELECTQUERYCONTENT;
                }
                if (json.SELECTQUERYTYPE == "ISACCEPTANCE")
                {
                    ISACCEPTANCE = json.SELECTQUERYCONTENT;
                }
                if (json.SELECTQUERYTYPE == "LOCATION")
                {
                    LOCATION = json.SELECTQUERYTYPE;
                }
                var expression1 = LinqExtensions.False<TBL_BQBREntity>();
                #region ��ѡʡ�м���
                //��
                string TOWN_RPT = json.TOWNRPT;
                if (!string.IsNullOrEmpty(TOWN_RPT))
                {
                    foreach (var ton in TOWN_RPT.Split(','))
                    {
                        expression1 = expression1.Or(t => t.TOWN.Equals(ton));
                    }
                    expression = expression.And(expression1);
                }
                else
                {
                    //��
                    string COUNTY = json.COUNTYRPT;
                    if (!string.IsNullOrEmpty(COUNTY))
                    {
                        foreach (var ton in COUNTY.Split(','))
                        {
                            expression1 = expression1.Or(t => t.COUNTY.Equals(ton));
                        }
                        expression = expression.And(expression1);
                    }
                    else
                    {
                        //��
                        string CITY = json.CITYRPT;
                        if (!string.IsNullOrEmpty(CITY))
                        {
                            foreach (var ton in CITY.Split(','))
                            {
                                expression1 = expression1.Or(t => t.CITY.Equals(ton));
                            }
                            expression = expression.And(expression1);
                        }
                        else
                        {
                            //ʡ
                            string PROVINCE = json.PROVINCERPT;
                            if (!string.IsNullOrEmpty(PROVINCE))
                            {
                                foreach (var ton in PROVINCE.Split(','))
                                {
                                    expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                                }
                                expression = expression.And(expression1);
                            }

                        }
                    }
                }
                #endregion
                #region ʡ���ؼ�������
                //��
                string TOWN = json.TOWN;
                if (!string.IsNullOrEmpty(TOWN))
                {
                    foreach (var ton in TOWN.Split(','))
                    {
                        expression1 = expression1.Or(t => t.TOWN.Equals(ton));
                    }
                    expression = expression.And(expression1);
                }
                else
                {
                    //��
                    string COUNTY = json.COUNTY;
                    if (!string.IsNullOrEmpty(COUNTY))
                    {
                        foreach (var ton in COUNTY.Split(','))
                        {
                            expression1 = expression1.Or(t => t.COUNTY.Equals(ton));
                        }
                        expression = expression.And(expression1);
                    }
                    else
                    {
                        //��
                        string CITY = json.CITY;
                        if (!string.IsNullOrEmpty(CITY))
                        {
                            foreach (var ton in CITY.Split(','))
                            {
                                expression1 = expression1.Or(t => t.CITY.Equals(ton));
                            }
                            expression = expression.And(expression1);
                        }
                        else
                        {
                            //ʡ
                            string PROVINCE = json.PROVINCE;
                            if (!string.IsNullOrEmpty(PROVINCE))
                            {
                                foreach (var ton in PROVINCE.Split(','))
                                {
                                    expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                                }
                                expression = expression.And(expression1);
                            }

                        }
                    }
                }
                #endregion
                //���ݷ�ΧȨ�޹���
                List<string> _codes = ssoWS.GetAllAuthDistricts();
                if (!_codes.Contains("000000") && !_codes.Equals("0"))
                {
                    expression = expression.And(t => _codes.Contains(t.COUNTY));
                }
                //�ֺ�������
                if (json.XMMC != "" && json.XMMC != null)
                {
                    XMMC = json.XMMC;
                }
                if (!string.IsNullOrEmpty(XMMC))
                {
                    expression = expression.And(t => t.XMMC.Contains(XMMC));
                }
                //�ֺ�������
                if (json.DISASTERNAME != "" && json.DISASTERNAME != null)
                {
                    DISASTERNAME = json.DISASTERNAME;
                }
                if (!string.IsNullOrEmpty(DISASTERNAME))
                {
                    expression = expression.And(t => t.DISASTERNAME.Contains(DISASTERNAME));
                }
                //�ֺ�����
                if (json.UNIFIEDCODE != "" && json.UNIFIEDCODE != null)
                {
                    UNIFIEDCODE = json.UNIFIEDCODE;
                }
                if (!string.IsNullOrEmpty(UNIFIEDCODE))
                {
                    expression = expression.And(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE));
                }
                //����λ��
                if (json.LOCATION != "" && json.LOCATION != null)
                {
                    LOCATION = json.LOCATION;
                }
                if (!string.IsNullOrEmpty(LOCATION))
                {
                    expression = expression.And(t => t.LOCATION.Contains(LOCATION));
                }
                //�ֺ�����
                if (json.DISASTERTYPE != "" && json.DISASTERTYPE != null)
                {
                    DISASTERTYPE = json.DISASTERTYPE;
                }
                if (!string.IsNullOrEmpty(DISASTERTYPE))
                {
                    expression = expression.And(t => t.DISASTERTYPE.Contains(DISASTERTYPE));
                }
                //�Ƿ����
                if (json.ISCOMPLETE != "" && json.ISCOMPLETE != null)
                {
                    ISCOMPLETE = json.ISCOMPLETE;
                }
                if (!string.IsNullOrEmpty(ISCOMPLETE))
                {
                    if (ISCOMPLETE == "1")//�����
                    {
                        ISCOMPLETE = "1";
                    }
                    if (ISCOMPLETE == "0")//δ���
                    {
                        ISCOMPLETE = "0";
                    }
                    expression = expression.And(t => t.ISCOMPLETE.Contains(ISCOMPLETE));
                }
                //�Ƿ�����
                if (json.ISACCEPTANCE != "" && json.ISACCEPTANCE != null)
                {
                    ISACCEPTANCE = json.ISACCEPTANCE;
                }
                if (!string.IsNullOrEmpty(ISACCEPTANCE))
                {
                    if (ISACCEPTANCE == "1")//��
                    {
                        ISACCEPTANCE = "1";
                    }
                    if (ISACCEPTANCE == "0")//��
                    {
                        ISACCEPTANCE = "0";
                    }
                    expression = expression.And(t => t.ISACCEPTANCE.Contains(ISACCEPTANCE));
                }
                //��ʼ����ʱ��

                if (json.BQBRSTARTTIME != "" && json.BQBRSTARTTIME != null)
                {
                    BQBRSTARTTIME = json.BQBRSTARTTIME;
                }
                if (json.BQBRENDTIME != "" && json.BQBRENDTIME != null)
                {
                    BQBRENDTIME = json.BQBRENDTIME;
                }
                if (!string.IsNullOrEmpty(BQBRSTARTTIME) && !string.IsNullOrEmpty(BQBRENDTIME))
                {
                    int BQBRSTARTTIME_T = Convert.ToInt32(BQBRSTARTTIME);
                    int BQBRENDTIME_T = Convert.ToInt32(BQBRENDTIME);
                    string YearAll = "";
                    var expression2 = LinqExtensions.False<TBL_BQBREntity>();
                    for (int i = BQBRSTARTTIME_T; i <= BQBRENDTIME_T; i++)
                    {
                        YearAll = Convert.ToString(i);
                        expression2 = expression2.Or(t => t.ANNUAL.Contains(YearAll));
                    }
                    expression = expression.And(expression2);
                }
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
                //һ���ֶ��ж��ֺ������ơ��ֺ�����
                if (json.COMPPARAM != "" && json.COMPPARAM != null)
                {
                    string COMPPARAM = json.COMPPARAM;
                    if (!string.IsNullOrEmpty(COMPPARAM))
                    {
                        expression = expression.And(t => t.DISASTERNAME.Contains(COMPPARAM) || t.UNIFIEDCODE.Contains(COMPPARAM) || t.LOCATION.Contains(COMPPARAM) || t.XMMC.Contains(COMPPARAM));
                    }
                }
            }

            return expression;
        }
        public IEnumerable<tbl_bqbrnew> GetPageListNEW1(string queryJson)
        {

            dynamic json = JToken.Parse(queryJson) as dynamic;
            //ɸѡ����
            string sqlWhere = "where 1=1"; string sqlWhere1 = "where 1=1";
            //��Ŀ����
            string XMMC = json.XMMC;
            if (!string.IsNullOrEmpty(XMMC))
            {
                sqlWhere += string.Format(" and t.XMMC like '%{0}%'", XMMC);
            }
            //����λ��
            string LOCATION = json.LOCATION;
            if (!string.IsNullOrEmpty(LOCATION))
            {
                sqlWhere += string.Format(" and t.LOCATION like '%{0}%'", LOCATION);
            }
            //�ֺ�����
            string DISASTERTYPE = json.DISASTERTYPE;
            if (!string.IsNullOrEmpty(DISASTERTYPE))
            {
                sqlWhere += string.Format(" and t.DISASTERTYPE = '{0}'", DISASTERTYPE);
            }
            //��Ǩ����
            string BQHS1 = json.bqhs1; string BQHS2 = json.bqhs2;
            if (!string.IsNullOrEmpty(BQHS1) && !string.IsNullOrEmpty(BQHS2))
            {
                sqlWhere1 += string.Format(" and s.HS >= {0}", BQHS1);
                sqlWhere1 += string.Format(" and s.HS <= {0}", BQHS2);
            }
            else if (!string.IsNullOrEmpty(BQHS1))
            {
                sqlWhere1 += string.Format(" and s.HS = {0}", BQHS1);
            }
            else if (!string.IsNullOrEmpty(BQHS2))
            {
                sqlWhere1 += string.Format(" and s.HS = {0}", BQHS2);
            }
            //��������
            string AreaCode = json.AreaCode;
            if (AreaCode != "0")
            {
                if (AreaCode.EndsWith("0000"))
                {
                    AreaCode = AreaCode.Substring(0, 2);
                }
                else if (AreaCode.EndsWith("00"))
                {
                    AreaCode = AreaCode.Substring(0, 4);
                }
                if (!string.IsNullOrEmpty(AreaCode))
                {
                    sqlWhere += string.Format(" and t.UNIFIEDCODE like  '{0}%'", AreaCode);
                }
            }
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<string> _codes2 = _codes.Where(p => p.Contains("00")).ToList();
            if (_codes2.Count > 1)
            {
                sqlWhere += " and CITY in('" + string.Join("','", _codes2.ToArray()) + "') ";//ʡ���û�

            }
            else if (_codes2.Count == 1)
            {
                if (_codes2[0] != "000000" && !_codes2[0].Equals("0"))
                {
                    sqlWhere += "  and COUNTY in('" + string.Join("','", _codes.ToArray()) + "') ";//�м��û�

                }
                else if (_codes2[0] == "000000")
                {
                    sqlWhere += "  ";//ȫ���û�

                }
                else
                {
                    sqlWhere += " ";//ʡ���û�

                }
            }
            else
            {
                sqlWhere += "  and COUNTY in('" + string.Join("','", _codes.ToArray()) + "') ";//�����û�

            }
            //��ʼʱ��
            string BQBRSTARTTIME = json.BQBRSTARTTIME; string BQBRENDTIME = json.BQBRENDTIME;
            if (!string.IsNullOrEmpty(BQBRSTARTTIME))
            {
                BQBRSTARTTIME = BQBRSTARTTIME.Substring(0, 4);
                sqlWhere += string.Format(" and t.ANNUAL >= '{0}' ", BQBRSTARTTIME);
            }
            //����ʱ��
            if (!string.IsNullOrEmpty(BQBRENDTIME))
            {
                BQBRENDTIME = BQBRENDTIME.Substring(0, 4);
                sqlWhere += string.Format(" and t.ANNUAL <= '{0}' ", BQBRENDTIME);
            }
            //һ���ֶ��ж��ֺ������ơ��ֺ�����
            if (json.COMPPARAM != "" && json.COMPPARAM != null)
            {
                string COMPPARAM = json.COMPPARAM;
                if (!string.IsNullOrEmpty(COMPPARAM))
                {
                    sqlWhere += string.Format(" and t.DISASTERNAME like  '%" + COMPPARAM + "%' or  t.UNIFIEDCODE =  '" + COMPPARAM + "' or t.XMMC like  '%" + COMPPARAM + "%' ");
                }
            }
            string strsql = "select * from (select UNIFIEDCODE,DISASTERNAME ,LOCATION,DISASTERTYPE,LATITUDE,LONGITUDE,count(UNIFIEDCODE) HS,sum(MOVEDECIMAL) BQRS,sum(ZAZBTJE) BTJR,sum(case when SFYS=1 then 1 else 0 end) YYS ,sum(case when SFWC=1 then 1 else 0 end) YWC  from TBL_BQBR t  " + sqlWhere + " group by  UNIFIEDCODE,DISASTERNAME,LOCATION,DISASTERTYPE,LATITUDE,LONGITUDE) s " + sqlWhere1;
            RepositoryFactory<tbl_bqbrnew> d = new RepositoryFactory<tbl_bqbrnew>();
            return d.BaseRepository().FindList(strsql);
            //return this.BaseRepository().
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetDataTableList(string queryJson)
        {
            var data = this.BaseRepository().FindList(queryJsonExpression(queryJson));
            // var data = GetPageListNEW1(queryJson);
            DataTable result = new DataTable();

            result.Columns.Add("�ֺ�������");
            result.Columns.Add("�ֺ�����");
            result.Columns.Add("�ֺ�������");
            result.Columns.Add("����");
            result.Columns.Add("γ��");
            result.Columns.Add("��Ǩ���");
            result.Columns.Add("��������");
            result.Columns.Add("������Ǩ����");
            result.Columns.Add("���÷�ʽ");
            result.Columns.Add("�Ƿ���");
            result.Columns.Add("�Ƿ����");
            result.Columns.Add("�Ƿ�����");
            result.Columns.Add("�Ƿ�ʾ");
            result.Columns.Add("��Ǩ������");
            result.Columns.Add("����λ��");
            result.Columns.Add("ʡ");
            result.Columns.Add("��");
            result.Columns.Add("��");
            foreach (var item in data)
            {
                DataRow result_dr = result.NewRow();
                result_dr["�ֺ�������"] = item.DISASTERNAME;
                result_dr["�ֺ�������"] = item.DISASTERTYPE;
                result_dr["�ֺ�����"] = item.UNIFIEDCODE;
                result_dr["����"] = item.LATITUDE;
                result_dr["γ��"] = item.LONGITUDE;
                result_dr["��Ǩ���"] = item.ANNUAL;
                result_dr["��������"] = item.HOUSEHOLDERNAME;
                result_dr["������Ǩ����"] = item.MOVEDECIMAL;
                result_dr["���÷�ʽ"] = item.RESETTLEMENT;
                if (item.ISDEMOLITION == "1")
                {
                    result_dr["�Ƿ���"] = "��";
                }
                if (item.ISDEMOLITION == "0")
                {
                    result_dr["�Ƿ���"] = "��";
                }
                if (item.SFWC == "1")
                {
                    result_dr["�Ƿ����"] = "��";
                }
                if (item.SFWC == "0")
                {
                    result_dr["�Ƿ����"] = "��";
                }
                if (item.SFYS == "1")
                {
                    result_dr["�Ƿ�����"] = "��";
                }
                if (item.SFYS == "0")
                {
                    result_dr["�Ƿ�����"] = "��";
                }
                if (item.SFGS == "1")
                {
                    result_dr["�Ƿ�ʾ"] = "��";
                }
                if (item.SFGS == "0")
                {
                    result_dr["�Ƿ�ʾ"] = "��";
                }
                result_dr["��Ǩ������"] = item.MINENATURE;
                result_dr["����λ��"] = item.LOCATION;
                result_dr["ʡ"] = item.PROVINCENAME;
                result_dr["��"] = item.CITYNAME;
                result_dr["��"] = item.COUNTYNAME;
                result.Rows.Add(result_dr);
            }
            return result;
        }


        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_BQBREntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_BQBREntity>();
            return this.BaseRepository().FindList(queryJsonExpression(queryJson));
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_BQBREntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        public TBL_BQBREntity GetEntityByUnifycode(string keyValue)
        {
            var expression = LinqExtensions.True<TBL_BQBREntity>();
            if (!keyValue.IsEmpty())
            {
                expression = expression.And(u => u.UNIFIEDCODE == keyValue);
            }
            else
            {
                expression = expression.And(u => 1 == 2);
            }
            return this.BaseRepository().FindList(expression).FirstOrDefault();
        }
        public IEnumerable<TBL_BQBREntity> GetEntityByUnifycodeNEW(Pagination pagination, string keyValue)
        {
            var expression = LinqExtensions.True<TBL_BQBREntity>();
            if (!keyValue.IsEmpty())
            {
                expression = expression.And(u => u.UNIFIEDCODE == keyValue);
            }
            else
            {
                expression = expression.And(u => 1 == 2);
            }
            return this.BaseRepository().FindList(expression).Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <param name="CityName"></param>
        /// <param name="CountyName"></param>
        /// <param name="BQBRYEAR"></param>
        /// <param name="BQBRUNIT"></param>
        /// <param name="EXLType"></param>
        /// <returns></returns>
        public DataTable BQBRCountStatics(string ProvinceName, string CityName, string CountyName, string BQBRYEAR, string BQBRUNIT, string EXLType)
        {
            //�Ѿ����³�Ϊ������ͼģʽ��ά��������ͼά��,�����ࣩ  
            //����ݵ�ͳ��ʡ����ͳ��BQBRPROVINCEBYYEARCOUNT
            var QueryStrProvinceYear = "SELECT * FROM BQBRPROVINCEBYYEARCOUNT";
            //����ݵ�ͳ��(��)BQBRCITYBYYEARCOUNT
            var QueryStrCityYear = "SELECT * FROM BQBRCITYBYYEARCOUNT";
            //����ݵ�ͳ��(��)BQBRCOUNTYBYYEARCOUNT
            var QueryStrCountyYear = "SELECT * FROM BQBRCOUNTYBYYEARCOUNT";

            //������ݵ�ͳ��(ʡ)
            var QueryStrProvince = "SELECT * FROM BQBRPROVINCECOUNT";
            //������ݵ�ͳ��(��)
            var QueryStrCity = "SELECT * FROM BQBRCITYCOUNT";
            //������ݵ�ͳ��(��)
            var QueryStrCounty = "SELECT * FROM BQBRCOUNTYCOUNT";
            DataTable result_Query = new DataTable();
            if (BQBRYEAR != "" && BQBRYEAR != null)
            {
                if (BQBRUNIT != null && BQBRUNIT != "")
                {
                    if (BQBRUNIT == "ʡ")
                    {
                        string QueryYear = QueryStrProvinceYear.ToString() + " where bqbryear ='" + BQBRYEAR + "'";
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
                        QueryYear += QueryXZQH;
                        var queryResult = QueryYear;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                    }
                    if (BQBRUNIT == "��")
                    {
                        string QueryYear = QueryStrCityYear.ToString() + " where bqbryear ='" + BQBRYEAR + "'";
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
                        QueryYear += QueryXZQH;
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
                        QueryYear += QueryXZQH;
                        var queryResult = QueryYear;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                        DataTable result = new DataTable();
                        result.Columns.Add("provincename");
                        result.Columns.Add("cityname");
                        result.Columns.Add("discount");
                        result.Columns.Add("bqbrcount");
                        result.Columns.Add("bqbryear");
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
                            result_dr["bqbrcount"] = result_Query.Rows[i]["bqbrcount"].ToString();
                            result_dr["bqbryear"] = result_Query.Rows[i]["bqbryear"].ToString();
                            result.Rows.Add(result_dr);
                        }
                        return result;
                    }
                    if (BQBRUNIT == "��")
                    {
                        string QueryYear = QueryStrCountyYear.ToString() + " where bqbryear ='" + BQBRYEAR + "'";
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
                        QueryYear += QueryXZQH;
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
                        QueryYear += QueryXZQH;
                        var queryResult = QueryYear;
                        result_Query = this.BaseRepository().FindTable(queryResult);
                        DataTable result = new DataTable();
                        result.Columns.Add("provincename");
                        result.Columns.Add("cityname");
                        result.Columns.Add("countryname");
                        result.Columns.Add("discount");
                        result.Columns.Add("bqbrcount");
                        result.Columns.Add("bqbryear");
                        for (int i = 0; i < result_Query.Rows.Count; i++)
                        {
                            if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && result_Query.Rows[i]["countryname"].ToString() != "")
                            {
                                result_Query.Rows[i]["provincename"] = "";
                                result_Query.Rows[i]["cityname"] = "";
                            }
                            if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && result_Query.Rows[i]["countryname"].ToString() == "")
                            {
                                result_Query.Rows[i]["provincename"] = "";
                            }
                            DataRow result_dr = result.NewRow();
                            result_dr["provincename"] = result_Query.Rows[i]["provincename"].ToString();
                            result_dr["cityname"] = result_Query.Rows[i]["cityname"].ToString();
                            result_dr["countryname"] = result_Query.Rows[i]["countryname"].ToString();
                            result_dr["discount"] = result_Query.Rows[i]["discount"].ToString();
                            result_dr["bqbrcount"] = result_Query.Rows[i]["bqbrcount"].ToString();
                            result_dr["bqbryear"] = result_Query.Rows[i]["bqbryear"].ToString();
                            result.Rows.Add(result_dr);
                        }
                        return result;
                    }

                }

            }
            else
            {
                if (BQBRUNIT != null && BQBRUNIT != "")
                {
                    if (BQBRUNIT == "ʡ")
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
                    }
                    if (BQBRUNIT == "��")
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
                        result.Columns.Add("bqbrcount");
                        for (int i = 0; i < result_Query.Rows.Count; i++)
                        {
                            if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && i != 0)
                            {
                                result_Query.Rows[i]["provincename"] = "";
                            }
                            DataRow result_dr = result.NewRow();
                            result_dr["provincename"] = result_Query.Rows[i]["provincename"].ToString();
                            result_dr["cityname"] = result_Query.Rows[i]["cityname"].ToString();
                            result_dr["discount"] = result_Query.Rows[i]["discount"].ToString();
                            result_dr["bqbrcount"] = result_Query.Rows[i]["bqbrcount"].ToString();
                            result.Rows.Add(result_dr);
                        }
                        return result;
                    }
                    if (BQBRUNIT == "��")
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
                        result.Columns.Add("bqbrcount");
                        for (int i = 0; i < result_Query.Rows.Count; i++)
                        {
                            if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && result_Query.Rows[i]["countryname"].ToString() != "")
                            {
                                result_Query.Rows[i]["provincename"] = "";
                                result_Query.Rows[i]["cityname"] = "";
                            }
                            if (result_Query.Rows[i]["provincename"].ToString() != "" && result_Query.Rows[i]["cityname"].ToString() != "" && result_Query.Rows[i]["countryname"].ToString() == "" && i != 0)
                            {
                                result_Query.Rows[i]["provincename"] = "";
                            }
                            DataRow result_dr = result.NewRow();
                            result_dr["provincename"] = result_Query.Rows[i]["provincename"].ToString();
                            result_dr["cityname"] = result_Query.Rows[i]["cityname"].ToString();
                            result_dr["countryname"] = result_Query.Rows[i]["countryname"].ToString();
                            result_dr["discount"] = result_Query.Rows[i]["discount"].ToString();
                            result_dr["bqbrcount"] = result_Query.Rows[i]["bqbrcount"].ToString();
                            result.Rows.Add(result_dr);
                        }
                        return result;
                    }

                }
            }
            return result_Query;

        }
        /// <summary>
        /// ��ȡ��ͼժҪ��Ϣ
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<TBL_BQBREntity> GetZYList(string queryJson, string condition)
        {
            var queryParam = queryJson.ToJObject();
            var expression = LinqExtensions.True<TBL_BQBREntity>();
            //�ֺ������ơ��ֺ����š�����λ��
            if (!queryParam["COMPPARAM"].IsEmpty())
            {
                string COMPPARAM = queryParam["COMPPARAM"].ToString();
                expression = expression.And(t => t.DISASTERNAME.Contains(COMPPARAM) | t.UNIFIEDCODE.Contains(COMPPARAM) | t.XMMC.Contains(COMPPARAM));
            }
            //�ֺ�������
            if (!queryParam["DISASTERNAME"].IsEmpty())
            {
                string DISASTERNAME = queryParam["DISASTERNAME"].ToString();
                expression = expression.And(t => t.DISASTERNAME.Contains(DISASTERNAME));
            }
            if (!queryParam["XMMC"].IsEmpty())
            {
                string XMMC = queryParam["XMMC"].ToString();
                expression = expression.And(t => t.XMMC.Contains(XMMC));
            }
            //�� 
            if (!queryParam["COUNTY"].IsEmpty())
            {
                string COUNTY = queryParam["COUNTY"].ToString();
                expression = expression.And(t => t.COUNTY.Contains(COUNTY));
            }
            //�� 
            if (!queryParam["CITY"].IsEmpty())
            {
                string CITY = queryParam["CITY"].ToString();
                expression = expression.And(t => t.CITY.Contains(CITY));
            }
            //ʡ 
            if (!queryParam["PROVINCE"].IsEmpty())
            {
                string PROVINCE = queryParam["PROVINCE"].ToString();
                expression = expression.And(t => t.PROVINCE.Contains(PROVINCE));
            }
            //�ֺ�����
            if (!queryParam["UNIFIEDCODE"].IsEmpty())
            {
                string UNIFIEDCODE = queryParam["UNIFIEDCODE"].ToString();
                expression = expression.And(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE));
            }
            //�ֺ�����
            if (!queryParam["DISASTERTYPE"].IsEmpty())
            {
                string DISASTERTYPE = queryParam["DISASTERTYPE"].ToString();
                expression = expression.And(t => t.DISASTERTYPE.Contains(DISASTERTYPE));
            }
            //�Ƿ����
            if (!queryParam["ISCOMPLETE"].IsEmpty())
            {
                string ISCOMPLETE = queryParam["ISCOMPLETE"].ToString();
                expression = expression.And(t => t.ISCOMPLETE.Contains(ISCOMPLETE));
            }
            //�Ƿ�����
            if (!queryParam["ISACCEPTANCE"].IsEmpty())
            {
                string ISACCEPTANCE = queryParam["ISACCEPTANCE"].ToString();
                expression = expression.And(t => t.ISACCEPTANCE.Contains(ISACCEPTANCE));
            }
            int startyear = 1900;
            int endyear = DateTime.Now.Year;
            //��ʼʱ��
            if (!queryParam["BQBRSTARTTIME"].IsEmpty())
            {
                string BQBRSTARTTIME = queryParam["BQBRSTARTTIME"].ToString();
                BQBRSTARTTIME = BQBRSTARTTIME.Substring(0, 4);
                startyear = Convert.ToInt32(BQBRSTARTTIME);
            }
            //����ʱ��
            if (!queryParam["BQBRENDTIME"].IsEmpty())
            {
                string BQBRENDTIME = queryParam["BQBRENDTIME"].ToString();
                BQBRENDTIME = BQBRENDTIME.Substring(0, 4);
                endyear = Convert.ToInt32(BQBRENDTIME);
            }
            List<string> yearlist = new List<string>();
            for (int i = startyear; i <= endyear; i++)
            {
                yearlist.Add(startyear.ToString());
            }
            if (!queryParam["BQBRENDTIME"].IsEmpty() || !queryParam["BQBRENDTIME"].IsEmpty())
            {
                expression = expression.And(t => yearlist.Contains(t.ANNUAL));
            }
            //���ݷ�ΧȨ�޹���
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000") && !_codes.Equals("0"))
            {
                expression = expression.And(t => _codes.Contains(t.COUNTY));
            }
            //var expression = queryJsonExpression(queryJson);
            List<TBL_BQBREntity> result = new List<TBL_BQBREntity>();
            var list = this.BaseRepository().FindList(expression).ToList();
            if (!condition.IsEmpty())
            {
                var queryParam_Condition = condition.ToJObject();
                if (!queryParam_Condition["WKTString"].IsEmpty())
                {
                    string WKTString = queryParam_Condition["WKTString"].ToString();
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
                if (!queryParam_Condition["x"].IsEmpty() && !queryParam_Condition["y"].IsEmpty() && !queryParam_Condition["radius"].IsEmpty())
                {
                    double x = queryParam_Condition["x"].ToDouble();
                    double y = queryParam_Condition["y"].ToDouble();
                    double radius = queryParam_Condition["radius"].ToDouble();
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
                if (!queryParam_Condition["polyline"].IsEmpty() && !queryParam_Condition["radius"].IsEmpty())
                {
                    string polyline = queryParam_Condition["polyline"].ToString();
                    double radius = queryParam_Condition["radius"].ToDouble();
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
            }


            return list;
        }

        /// <summary>
        /// ��Ǩ����ͳ�Ʋ�ѯ
        /// </summary>
        /// <param name="codeValue">�����������</param>
        /// <param name="codeType">������������</param>
        /// <param name="xmmc">��Ŀ����</param>
        /// <param name="annual">��������</param>
        /// <param name="static_Unit">ͳ�Ƶ�λ</param>
        /// <returns></returns>
        public DataTable GetDataBqbrTj(string codeValue, string codeType, string xmmc, string annual, string static_Unit)
        {
            string sql = "select * from";
            string where1 = "1=1 ";
            if (!String.IsNullOrWhiteSpace(xmmc))
            {
                where1 += "and XMMC like '%" + xmmc + "%'";
            }
            if (!String.IsNullOrWhiteSpace(annual))
            {
                where1 += "and ANNUAL like '%" + annual + "%'";
            }
            string[] xzqhcodes = codeValue.Split(',');
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
                    // where1 += "and PROVINCE like '%" + codeValue + "%'";
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
                    //where1 += "and CITY like '%" + codeValue + "%'";
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
                    //where1 += "and COUNTY like '%" + codeValue + "%'";
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
            string sql1 = String.Format("select PROVINCENAME as ʡ,CITYNAME as ��,COUNTYNAME as ��,UNIFIEDCODE as �ֺ���,MOVEDECIMAL as ��Ǩ����,  "
                   + "ZAZBTJE as �ܰ��ò������,CASE WHEN SFWC = '1' THEN  1 ELSE 0 END AS �����, CASE WHEN SFYS = '1' THEN 1 ELSE 0 END AS ������, "
                   + " CASE WHEN RESETTLEMENT = '1' THEN 1 ELSE 0 END AS ���а���,CASE WHEN RESETTLEMENT = '2' THEN 1 ELSE 0 END AS ��ɢ����,    "
                   + " CASE WHEN RESETTLEMENT = '3' THEN 1 ELSE 0 END AS ��������,CASE WHEN RESETTLEMENT = '4' THEN 1 ELSE 0 END AS ��������  "
                   + "from (select * from TBL_BQBR where {0} and  COUNTY is not null) qryTable", where1);

            string strSum = "count(DISTINCT(�ֺ���)) as  �ֺ������, SUM(���а��� + ��ɢ���� + �������� + ��������) as ��Ǩ����, SUM(��Ǩ����) AS ��Ǩ����, SUM(���а���) AS ���а��ø���,"
                       + " SUM(��ɢ����) AS ��ɢ���ø���, SUM(��������) AS �������ø���,SUM(��������) AS �������ø���,SUM(�����) AS ����ɸ���, SUM(������) AS �����ո���,SUM(�ܰ��ò������) as �ܰ��ò������ ";

            switch (static_Unit)
            {
                case "ʡ":
                    sql += "(select ʡ," + strSum + "from (" + sql1 + ") t group by  rollup(t.ʡ) ) a  order by a.ʡ  ";
                    break;
                case "��":
                    sql += "(select ʡ,��," + strSum + "from (" + sql1 + ") t group by  rollup(t.ʡ,t.��) ) a  order by a.ʡ desc,a.�� desc";
                    break;
                case "��":
                    sql += "(select ʡ,��,��," + strSum + "from (" + sql1 + ") t group by  rollup(t.ʡ,t.��,t.��) ) a  order by a.ʡ desc,a.�� desc,a.�� desc";
                    break;
            }
            return this.BaseRepository().FindTable(sql);
        }
        #endregion

        public IEnumerable<TreeByBQBRTJ> GetTJ(string queryJson)
        {
            var list = GetList(queryJson);
            var listcol = list.Where((x, i) => list.ToList().FindIndex(z => z.UNIFIEDCODE == x.UNIFIEDCODE && z.DISASTERNAME == x.DISASTERNAME && z.DISASTERTYPE == x.DISASTERTYPE) == i).ToList();
            List<TreeByBQBRTJ> newlist = new List<TreeByBQBRTJ>();
            foreach (var item in listcol)
            {
                TreeByBQBRTJ t = new TreeByBQBRTJ();
                t.id = item.UNIFIEDCODE;
                t.parent = "";
                t.DISASTERNAME = item.DISASTERNAME;
                t.DISASTERTYPE = item.DISASTERTYPE;
                t.LOCATION = item.LOCATION;
                t.level = "0";
                t.isLeaf = false;
                newlist.Add(t);
            }
            foreach (var item in list)
            {
                TreeByBQBRTJ t = new TreeByBQBRTJ();
                t.id = item.GUID;
                t.level = "1";
                t.parent = item.UNIFIEDCODE;
                t.HOUSEHOLDERNAME = item.HOUSEHOLDERNAME;
                t.RESETTLEMENT = item.RESETTLEMENT;
                t.SFWC = item.SFWC;
                t.SFYS = item.SFYS;

                t.MOVEDECIMAL = item.MOVEDECIMAL;
                t.ZAZBTJE = item.ZAZBTJE;
                t.YFJE = item.YFJE;
                t.DFJR = item.DFJR;

                newlist.Add(t);
                //t.data = new { GUID = item.GUID, UNIFIEDCODE = item.UNIFIEDCODE, HOUSEHOLDERNAME = item.HOUSEHOLDERNAME, RESETTLEMENT = item.RESETTLEMENT };
            }
            foreach (var item in newlist)
            {
                if (newlist.Where(s => s.id == item.parent).ToList().Count > 0)
                {
                    item.expanded = true;
                }
            }
            return newlist;
        }
        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public string SaveForm(string keyValue, TBL_BQBREntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                DateTime modifyTime = DateTime.Now;//��ǰʱ��
                UserInfo userInfo = ssoWS.GetUserInfo();
                string userName = userInfo.F_Account;//�û���Ϣ
                entity.CREATETIME = modifyTime;
                entity.CREATEUSER = userName;
                this.BaseRepository().Update(entity);
                return entity.GUID;
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
                return entity.GUID;
            }
        }
        #endregion


    }
}
