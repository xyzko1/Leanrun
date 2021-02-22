using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:19
    /// �� ����Ⱥ��Ⱥ������Ԥ����
    /// </summary>
    public class TBL_QCQF_DISASTERPREVENTIONService : RepositoryFactory<TBL_QCQF_DISASTERPREVENTIONEntity>, TBL_QCQF_DISASTERPREVENTIONIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        private string DefalutCode = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
        private string DefalutName = System.Configuration.ConfigurationManager.AppSettings["DefalutName"];
        private JYGC_PROJECTBASEINFOIService project = new JYGC_PROJECTBASEINFOService();      
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_DISASTERPREVENTIONEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_DISASTERPREVENTIONEntity>();
            return this.BaseRepository().FindList(expression, pagination);
        }
                
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_DISASTERPREVENTIONEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_DISASTERPREVENTIONEntity>();
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            //���������
            string JCpeople = json.MONITORRESPONSIBLE;
            if (!string.IsNullOrEmpty(JCpeople))
            {
                expression = expression.And(t => t.MONITORRESPONSIBLE.Contains(JCpeople));
            }
            //Ⱥ��Ⱥ����Ա
            string QCQFpeople = json.GROUPMONITORINGSTAFF;
            if (!string.IsNullOrEmpty(QCQFpeople))
            {
                expression = expression.And(t => t.GROUPMONITORINGSTAFF.Contains(QCQFpeople));
            }
            return this.BaseRepository().FindList(expression);
        }
       
        public DataTable GetAnalyseListQCQF(string queryJson)
        {
            var queryParam = new JObject();
            if (queryJson != null && queryJson != "")
            {
                queryParam = queryJson.ToJObject();
            }
            string strSql = "select t.UNIFIEDCODE,t1.disastername,t1.disastertype from TBL_QCQF_DISASTERPREVENTION t inner join tbl_hazardbasicinfo t1 on t.unifiedcode=t1.unifiedcode where 1=1";
            //��������Լ��
            if (!queryParam["COUNTY"].IsEmpty() || !queryParam["CITY"].IsEmpty() ||queryParam["PROVINCE"].ToString()!="0")
            {
                strSql += " and ( 1=2 ";
                if (!queryParam["COUNTY"].IsEmpty())
                {
                    var strCOUNTYs = queryParam["COUNTY"].ToString().Split(',');
                    var COUNTYs = "";
                   // strSql += " or substr(t.UNIFIEDCODE,0,6) in (";
                    strSql += " or "+DbSqlFunctionHelper.SubString("t.UNIFIEDCODE",0,6)+" in (";
                    foreach (string item in strCOUNTYs)
                    {
                        COUNTYs += "'" + item + "',";
                    }
                    strSql += COUNTYs.TrimEnd(',') + ")";
                }
                else if (!queryParam["CITY"].IsEmpty())
                {
                    var strCITYs = queryParam["CITY"].ToString().Split(',');
                    var CITYs = "";
                    //strSql += " or substr(t.UNIFIEDCODE,0,4) in (";
                    strSql += " or " + DbSqlFunctionHelper.SubString("t.UNIFIEDCODE", 0, 4) + " in (";
                    foreach (string item in strCITYs)
                    {
                        string itemsub = item.Substring(0, 4);
                        CITYs += "'" + itemsub + "',";
                    }
                    strSql += CITYs.TrimEnd(',') + ")";
                }
                else if (!queryParam["PROVINCE"].IsEmpty() && queryParam["PROVINCE"].ToString()!="0")
                {
                    var strPROVINCEs = queryParam["PROVINCE"].ToString().Split(',');
                    var PROVINCEs = "";
                    //strSql += " or substr(t.UNIFIEDCODE,0,2) in (";
                    strSql += " or " + DbSqlFunctionHelper.SubString("t.UNIFIEDCODE", 0, 2) + " in (";
                    foreach (string item in strPROVINCEs)
                    {
                        string itemsub = item.Substring(0, 2);
                        PROVINCEs += "'" + itemsub + "',";
                    }
                    strSql += PROVINCEs.TrimEnd(',') + ")";
                }
                else
                {
                }
                strSql += " )";
            }
            DataTable source = BaseRepository().FindTable(strSql);
            DataTable result = new DataTable();
            result.Columns.Add("province");
            result.Columns.Add("city");
            result.Columns.Add("county");
            result.Columns.Add("town");
            result.Columns.Add("count");
            //���ؼ���
            result.Columns.Add("id");
            result.Columns.Add("level");
            result.Columns.Add("parent_field");
            result.Columns.Add("isLeaf");
            result.Columns.Add("expanded");
            result.Columns.Add("area");
            result.Columns.Add("areacode");
            result.Columns.Add("disastername");
            result.Columns.Add("disastertype");
            List<string> PROs = new List<string>();
            foreach (DataRow item in source.Rows)
            {
                bool isrepeat = false;
                foreach (var pro in PROs)
                {
                    if (pro == item["UNIFIEDCODE"].ToString().Substring(0, 2))
                    {
                        isrepeat = true;
                    }
                }
                if (!isrepeat)
                {
                    PROs.Add(item["UNIFIEDCODE"].ToString().Substring(0, 2));
                }
            }
            foreach (var pro in PROs)
            {
                //setData(source, result, "ȫ��");
                setData(source, result, "ʡ",pro);
                setData(source, result, "��", pro);
                setData(source, result, "��", pro);
                setData(source, result, "��", pro);
            }
            

            DataView dv = result.DefaultView;
            dv.Sort = "areacode";
            return dv.ToTable();
        }

        public DataTable setData(DataTable data, DataTable dt, string level, string proCode)
        {
            switch (level)
            {
                case "ʡ":
                    DataRow row_pro = dt.NewRow();
                    DistrctEntity distrct2 = ssoWS.GetDistrctByCodes(proCode+"0000")[0];
                    row_pro["province"] = distrct2.DistrictName;
                    row_pro["id"] = proCode;
                    List<string> PROs = new List<string>();
                    int sumUnifiecode = 0;
                    foreach (DataRow item in data.Rows)
                    {
                        if (proCode == item["UNIFIEDCODE"].ToString().Substring(0, 2))
                        {
                            sumUnifiecode++;
                        }
                    }
                    row_pro["count"] = sumUnifiecode;
                    row_pro["area"] = distrct2.DistrictName;//DefalutCode.Substring(0, DefalutCode.Length - 1);
                    row_pro["areacode"] = proCode;
                    row_pro["parent_field"] = null;
                    row_pro["level"] = "0";
                    row_pro["isLeaf"] = "false";
                    row_pro["expanded"] = "true";
                    dt.Rows.Add(row_pro);
                    break;
                case "��":
                    List<string> CITYs = new List<string>();
                    foreach (DataRow item in data.Rows)
                    {
                        bool isrepeat = false;
                        if (proCode == item["UNIFIEDCODE"].ToString().Substring(0, 2))
                        {
                            foreach (var city in CITYs)
                            {
                            
                                    if (city == item["UNIFIEDCODE"].ToString().Substring(0, 4))
                                    {
                                        isrepeat = true;
                                    }
                                }
                            
                            if (!isrepeat)
                            {
                                CITYs.Add(item["UNIFIEDCODE"].ToString().Substring(0, 4));
                            }
                        }
                    }
                    foreach (var city in CITYs)
                    {
                        var dt_city = data.AsEnumerable().Where(u => u["UNIFIEDCODE"].ToString().Substring(0, 4) == city);
                        DistrctEntity distrct = ssoWS.GetDistrctByCodes(city + "00")[0];
                        DataRow row_city = dt.NewRow();
                        row_city["city"] = distrct.DistrictName;
                        row_city["id"] = distrct.DistrictCode;
                        row_city["count"] = dt_city.Count();
                        row_city["area"] = distrct.DistrictName;
                        row_city["areacode"] = distrct.DistrictCode;
                        row_city["parent_field"] = distrct.DistrictCode.Substring(0, 2) + "0000";
                        row_city["level"] = "1";
                        row_city["isLeaf"] = "false";
                        row_city["expanded"] = "true";
                        dt.Rows.Add(row_city);
                    }
                    break;
                case "��":

                    List<string> COUNTYs = new List<string>();
                    foreach (DataRow item in data.Rows)
                    {
                        bool isrepeat = false;
                        if (proCode == item["UNIFIEDCODE"].ToString().Substring(0, 2))
                        {
                            foreach (var county in COUNTYs)
                            {
                                if (county == item["UNIFIEDCODE"].ToString().Substring(0, 6))
                                {
                                    isrepeat = true;
                                }
                            }
                            if (!isrepeat)
                            {
                                COUNTYs.Add(item["UNIFIEDCODE"].ToString().Substring(0, 6));
                            }
                        }
                    }
                    foreach (var county in COUNTYs)
                    {
                        var dt_county = data.AsEnumerable().Where(u => u["UNIFIEDCODE"].ToString().Substring(0, 6) == county);
                        DistrctEntity distrct = ssoWS.GetDistrctByCodes(county)[0];
                        DataRow row_county = dt.NewRow();
                        row_county["county"] = distrct.DistrictName;
                        row_county["id"] = distrct.DistrictCode;
                        row_county["count"] = dt_county.Count();
                        row_county["area"] = distrct.DistrictName;
                        row_county["areacode"] = distrct.DistrictCode;
                        row_county["parent_field"] = distrct.DistrictCode.Substring(0, 4) + "00";
                        row_county["level"] = "2";
                        row_county["isLeaf"] = "false";
                        row_county["expanded"] = "true";
                        dt.Rows.Add(row_county);
                    }
                    break;
                case "��":
                    List<string> Towns = new List<string>();
                    foreach (DataRow item in data.Rows)
                    {
                        bool isrepeat = false;
                        if (proCode == item["UNIFIEDCODE"].ToString().Substring(0, 2))
                        {
                            foreach (var city in Towns)
                            {
                                if (city == item["UNIFIEDCODE"].ToString().Substring(0, 9))
                                {
                                    isrepeat = true;
                                }
                            }
                            if (!isrepeat)
                            {
                                Towns.Add(item["UNIFIEDCODE"].ToString().Substring(0, 9));
                            }
                        }
                    }
                    foreach (var town in Towns)
                    {
                        var dt_town = data.AsEnumerable().Where(u => u["UNIFIEDCODE"].ToString().Substring(0, 9) == town).ToList();
                        var ss = ssoWS.GetDistrctByCodes(town);
                        if (ss.Length != 0)
                        {
                            DistrctEntity distrct = ss[0];
                            DataRow row_town = dt.NewRow();
                            row_town["town"] = distrct.DistrictName;
                            row_town["id"] = distrct.DistrictCode;
                            row_town["count"] = dt_town.Count();
                            row_town["area"] = distrct.DistrictName;
                            row_town["areacode"] = distrct.DistrictCode;
                            row_town["parent_field"] = distrct.DistrictCode.Substring(0, 6);
                            row_town["level"] = "3";
                            row_town["isLeaf"] = "false";
                            row_town["expanded"] = "true";
                            dt.Rows.Add(row_town);
                            //����ֺ���Žڵ�
                            DataRow row_disaster = dt.NewRow();
                            row_disaster["disastername"] = dt_town[0]["disastername"];
                            row_disaster["disastertype"] = dt_town[0]["disastertype"];
                            row_disaster["id"] = dt_town[0]["unifiedcode"];
                            row_disaster["count"] = "1";
                            row_disaster["area"] = dt_town[0]["unifiedcode"];
                            row_disaster["areacode"] = dt_town[0]["unifiedcode"];
                            row_disaster["parent_field"] = distrct.DistrictCode;
                            row_disaster["level"] = "4";
                            row_disaster["isLeaf"] = "true";
                            row_disaster["expanded"] = "true";
                            dt.Rows.Add(row_disaster);
                        }
                        
                    }
                    break;
            }
            return dt;
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_DISASTERPREVENTIONEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        /// <summary>
        /// Ⱥ��Ⱥ��ͳ��
        /// </summary>
        /// <returns></returns>
        public DataTable GetQCQFStatistics(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            string projectid = project.GetTCYearProject("{}");
            string sql = string.Empty;
            //sql = "select * from TBL_HAZARDBASICINFO t where exists(select 1 from TBL_QCQF_DISASTERPREVENTION s where t.UNIFIEDCODE= s.UNIFIEDCODE) and PROJECTID = '" + projectid + "' ";
            sql = "select * from TBL_HAZARDBASICINFO t where exists(select 1 from TBL_QCQF_DISASTERPREVENTION s where t.UNIFIEDCODE= s.UNIFIEDCODE)" ;
            if (!queryParam["AreaCode"].IsEmpty())
            {
                string AreaCode = queryParam["AreaCode"].ToString();
                if (AreaCode.EndsWith("0000") & AreaCode.Length < 9)
                {
                    sql += " and t.PROVINCE like '%" + AreaCode + "%'";
                }
                else if (AreaCode.EndsWith("00") & AreaCode.Length < 9)
                {
                    sql += " and t.CITY like '%" + AreaCode + "%'";
                }
                else if (AreaCode.Length < 9)
                {
                    sql += " and t.COUNTY like '%" + AreaCode + "%'";
                }
                else
                {
                    sql += " and t.TOWN like '%" + AreaCode + "%'";
                }
            }
            //���ݷ�ΧȨ�޹���
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                sql += " and t.COUNTY in(" + string.Join("','", _codes) + ")";
            }
            return this.BaseRepository().FindTable(sql);
        }
        /// <summary>
        /// ��ȡʡ����Ⱥ��Ⱥ������
        /// </summary>
        /// <param name="xzqhcode"></param>
        /// <returns></returns>
        public DataTable GetQCQFCount(string xzqhcode)
        {
            int length = xzqhcode.Length;
            string projectid = project.GetTCYearProject("{}");
            //string sql = "select count(*) from  (select * from TBL_HAZARDBASICINFO t where exists(select 1 from TBL_QCQF_DISASTERPREVENTION s where t.UNIFIEDCODE= s.UNIFIEDCODE)) k  where substr(k.unifiedcode,0,{0})={1} and PROJECTID = '{2}' group by substr(k.unifiedcode,0,0)";
            string sql = "select count(*) from  (select * from TBL_HAZARDBASICINFO t where exists(select 1 from TBL_QCQF_DISASTERPREVENTION s where t.UNIFIEDCODE= s.UNIFIEDCODE)) k  where ";
            //sql = string.Format(sql, length, xzqhcode, projectid);
            //sql = string.Format(" {4} {0}={2} and PROJECTID = '{3}' group by {1}", DbSqlFunctionHelper.SubString("k.unifiedcode", 0, length), DbSqlFunctionHelper.SubString("k.unifiedcode", 0, 0), xzqhcode, projectid, sql);
            sql = string.Format(" {4} {0}={2}  group by {1}", DbSqlFunctionHelper.SubString("k.unifiedcode", 0, length), DbSqlFunctionHelper.SubString("k.unifiedcode", 0, 0), xzqhcode, projectid, sql);
            return this.BaseRepository().FindTable(sql);
        }
        #endregion

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
        public void  SaveForm(string keyValue, TBL_QCQF_DISASTERPREVENTIONEntity entity)
        {
            if (!string.IsNullOrEmpty(entity.UNIFIEDCODE))
            {
                keyValue = entity.UNIFIEDCODE.ToString();
                TBL_QCQF_DISASTERPREVENTIONEntity findEntity = this.BaseRepository().FindEntity(keyValue);
                if (findEntity != null)
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.GUID = Guid.NewGuid().ToString();
                    this.BaseRepository().Insert(entity);
                }
            }
           
        }
        #endregion
    }
}
