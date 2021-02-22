using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Infoearth.Util.Extension;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
using Infoearth.Application.Common;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-05-25 16:29
    /// �� �������ι滮�ɹ���
    /// </summary>
    public class TBL_ACHIEVEMENT_PREPLANService : RepositoryFactory<TBL_ACHIEVEMENT_PREPLANEntity>, TBL_ACHIEVEMENT_PREPLANIService
    {
        private TBL_HAZARDBASICINFOIService hazard = new TBL_HAZARDBASICINFOService();
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_ACHIEVEMENT_PREPLANEntity>();
             return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);   
        }

        /// <summary>
        /// �Ѳ�ѯ���ҳ���ϵ�ͨ��json����ת����linq���
        /// </summary>
        /// <param name="queryJson">json����</param>
        /// <returns></returns>
        System.Linq.Expressions.Expression<Func<TBL_ACHIEVEMENT_PREPLANEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ACHIEVEMENT_PREPLANEntity>();
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            string province = json.PROVINCE;
            string city = json.CITY;
            string county = json.COUNTY;

            #region ����ʡ���ر�Ų�ѯ
            var expression1 = LinqExtensions.False<TBL_ACHIEVEMENT_PREPLANEntity>();
            //��
            string TOWN = json.TOWN;
            if (!string.IsNullOrEmpty(TOWN))
            {
                foreach (var ton in TOWN.Split(','))
                {
                    expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(0,9).Equals(ton));
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
                        expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(0,6).Equals(ton));
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
                            expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(0,4).Equals(ton.Substring(0,4)));
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
                                expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(0,2).Equals(ton.Substring(0,2)));
                            }
                            expression = expression.And(expression1);
                        }

                    }
                }
            }
            #endregion

            //�ֺ�������ɸѡ
            string DISASTERNAME = "";
            if (json.DISASTERNAME != "" && json.DISASTERNAME != null)
            {
                DISASTERNAME = json.DISASTERNAME;
            }
            if (!string.IsNullOrEmpty(DISASTERNAME))
            {
                expression = expression.And(t => t.DISASTERNAME.Contains(DISASTERNAME));
            }
            //�ɹ�����ɸѡ
            string ACHIEVEMENTNAME = "";
            if (json.ACHIEVEMENTNAME != "" && json.ACHIEVEMENTNAME != null)
            {
                ACHIEVEMENTNAME = json.ACHIEVEMENTNAME;
            }
            if (!string.IsNullOrEmpty(ACHIEVEMENTNAME))
            {
                expression = expression.And(t => t.ACHIEVEMENTNAME.Contains(ACHIEVEMENTNAME));
            }
            //��д��ɸѡ
            string CREATENAME = "";
            if (json.CREATENAME != "" && json.CREATENAME != null)
            {
                CREATENAME = json.CREATENAME;
            }
            if (!string.IsNullOrEmpty(CREATENAME))
            {
                expression = expression.And(t => t.CREATENAME.Contains(CREATENAME));
            }
            //�滮��������
            string AREATYPE = "";
            if (json.AREATYPE != "" && json.AREATYPE != null)
            {
                AREATYPE = json.AREATYPE;
            }
            if (!string.IsNullOrEmpty(AREATYPE))
            {
                expression = expression.And(t => t.AREATYPE.Contains(AREATYPE));
            }
            //�滮ʱ������
            string TIMETYPE = "";
            if (json.TIMETYPE != "" && json.TIMETYPE != null)
            {
                TIMETYPE = json.TIMETYPE;
            }
            if (!string.IsNullOrEmpty(TIMETYPE))
            {
                expression = expression.And(t => t.TIMETYPE.Contains(TIMETYPE));
            }
            //���ַ�������
            string DISASTERTYPE = "";
            if (json.DISASTERTYPE != "" && json.DISASTERTYPE != null)
            {
                DISASTERTYPE = json.DISASTERTYPE;
            }
            if (!string.IsNullOrEmpty(DISASTERTYPE))
            {
                expression = expression.And(t => t.DISASTERTYPE.Contains(DISASTERTYPE));
            }
            //��������
            string PREVENTION = "";
            if (json.PREVENTION != "" && json.PREVENTION != null)
            {
                PREVENTION = json.PREVENTION;
            }
            if (!string.IsNullOrEmpty(PREVENTION))
            {
                expression = expression.And(t => t.PREVENTION.Contains(PREVENTION));
            }
            //��ʼ����ʱ��
            string PREPLANSTARTTIME = "";
            string PREPLANENDTIME = "";
            if (json.PREPLANSTARTTIME != "" && json.PREPLANSTARTTIME != null)
            {
                PREPLANSTARTTIME = json.PREPLANSTARTTIME;
            }
            if (json.PREPLANENDTIME != "" && json.PREPLANENDTIME != null)
            {
                PREPLANENDTIME = json.PREPLANENDTIME;
            }
            if (!string.IsNullOrEmpty(PREPLANSTARTTIME) && !string.IsNullOrEmpty(PREPLANENDTIME))
            {
                int PREPLANSTARTTIME_T = Convert.ToInt32(PREPLANSTARTTIME);
                int PREPLANENDTIME_T = Convert.ToInt32(PREPLANENDTIME);
                string YearAll = "";
                var expression2 = LinqExtensions.False<TBL_ACHIEVEMENT_PREPLANEntity>();
                for (int i = PREPLANSTARTTIME_T; i <= PREPLANENDTIME_T; i++)
                {
                    YearAll = Convert.ToString(i);
                    expression2 = expression2.Or(t => t.WRITETIME.ToString().Contains(YearAll));
                }
                expression = expression.And(expression2);
            }
            //һ���ֶ��ж��ֺ������ơ��ɹ�����
            if (json.COMPPARAM != "" && json.COMPPARAM != null)
            {
                string COMPPARAM = json.COMPPARAM;
                if (!string.IsNullOrEmpty(COMPPARAM))
                {
                    expression = expression.And(t => t.DISASTERNAME.Contains(COMPPARAM) || t.ACHIEVEMENTNAME.Contains(COMPPARAM));
                }
            }

            return expression;
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> GetList(string queryJson)
        {
             var expression = LinqExtensions.True<TBL_ACHIEVEMENT_PREPLANEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_ACHIEVEMENT_PREPLANEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        /// <summary>
        /// ��ȡ��ͼժҪ��Ϣ��ѯ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>����ָ���ֶ�</returns>
        public IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> GetZYPageList(string queryJson, string condition)
        {

            try
            {
                var queryParam = condition.ToJObject();
                var expression = queryJsonExpression(queryJson);
                List<TBL_ACHIEVEMENT_PREPLANEntity> result = new List<TBL_ACHIEVEMENT_PREPLANEntity>();
                var list = this.BaseRepository().FindList(expression).Select(t => new TBL_ACHIEVEMENT_PREPLANEntity { DISASTERNAME = t.DISASTERNAME, DISASTERTYPE = t.DISASTERTYPE, UNIFIEDCODE = t.UNIFIEDCODE, PROVINCENAME = t.PROVINCENAME, CITYNAME = t.CITYNAME, COUNTYNAME = t.COUNTYNAME, TOWNNAME = t.TOWNNAME, LOCATION = t.LOCATION, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE, GUID = t.GUID }).ToList();
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
        /// ��ֹ�滮ͳ�Ʒ���
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <param name="CityName"></param>
        /// <param name="CountyName"></param>
        /// <param name="PREPLANYEAR"></param>
        /// <param name="PREPLANUNIT"></param>
        /// <param name="DCType"></param>
        /// <returns></returns>
        public DataTable PREPLANCountStatics(string ProvinceName, string CityName, string CountyName, string PREPLANYEAR, string PREPLANUNIT, string DCType)
        {
            DataTable result_query = new DataTable();
            //��һ�� ���ڵ����ֺ��ֺ���ļ���ͳ�ƣ���ʡ���أ�
            string chaxun = "{\"PROVINCENAME\":\"" + ProvinceName + "\",\"CITYNAME\":\"" + CityName + "\",\"COUNTYNAME\":\"" + CountyName + "\"}";
            var Hazards = hazard.GetList(chaxun);
            //�ڶ��� ���������̼���ͳ�ƣ���ʡ���أ�
            var expression = LinqExtensions.True<TBL_ACHIEVEMENT_PREPLANEntity>();
            IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> Zlghs = this.BaseRepository().FindList(expression);
            //������ ����ʡ���ؼ��ϵ�ɸѡ
            #region ʡ���ؼ���--�Լ�ʡ��������ɸѡ
            List<string> Provincename_list = new List<string>();
            List<string> Cityname_list = new List<string>();
            List<string> Countyname_list = new List<string>();
            foreach (var item in Hazards)
            {
                if (Provincename_list.Contains(item.PROVINCENAME.ToString()))
                {

                }
                else
                {
                    if (item.PROVINCENAME.ToString() == ProvinceName)
                    {
                        Provincename_list.Add(item.PROVINCENAME.ToString());
                    }

                }
                if (Cityname_list.Contains(item.CITYNAME.ToString()))
                {

                }
                else
                {
                    if (item.PROVINCENAME.ToString() == ProvinceName)
                    {
                        Cityname_list.Add(item.CITYNAME.ToString());
                    }
                }
                if (Countyname_list.Contains(item.COUNTYNAME.ToString()))
                {

                }
                else
                {
                    if (item.PROVINCENAME.ToString() == ProvinceName)
                    {
                        Countyname_list.Add(item.CITYNAME.ToString() + "," + item.COUNTYNAME.ToString());
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
                for (int j = 0; j < Cityname_list.Count(); j++)
                {
                    if (CityNameS.Contains(Cityname_list[j]))
                    {

                    }
                    else
                    {
                        DISCityNames_SC.Add(Cityname_list[j]);
                    }
                }
                for (int m = 0; m < DISCityNames_SC.Count(); m++)
                {
                    Cityname_list.Remove(DISCityNames_SC[m]);
                }


            }
            if (CountyName != "" && CountyName != null)
            {
                string[] CountyNameS = CountyName.Split(',');
                List<string> DISCountyNames_SC = new List<string>();
                for (int i = 0; i < Countyname_list.Count(); i++)
                {
                    if (CountyNameS.Contains(Countyname_list[i]))
                    {

                    }
                    else
                    {
                        DISCountyNames_SC.Add(CountyNameS[i]);
                    }
                }
                for (int j = 0; j < DISCountyNames_SC.Count(); j++)
                {
                    Countyname_list.Remove(DISCountyNames_SC[j]);
                }
            }
            #endregion
            //���Ĳ� ��Ӧ���ݽ���ʡ������ȵ�ɸѡ����λ���֣�
            if (PREPLANYEAR != "" && PREPLANYEAR != null)
            {
                if (PREPLANUNIT == "ʡ")
                {
                    foreach (var item in Zlghs)
                    {
                        if (item.WRITETIME != null)
                        {
                            if (item.WRITETIME.ToString().Substring(0, 4) == PREPLANYEAR)
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
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlghs);
                }
                if (PREPLANUNIT == "��")
                {
                    foreach (var item in Zlghs)
                    {
                        if (item.WRITETIME != null)
                        {
                            if (item.WRITETIME.ToString().Substring(0, 4) == PREPLANYEAR)
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
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlghs);
                    result_query.Columns.Add("cityname");
                    result_query = city_func(result_query, Cityname_list, Hazards, Zlghs);
                }

                if (PREPLANUNIT == "��")
                {
                    foreach (var item in Zlghs)
                    {
                        if (item.WRITETIME != null)
                        {
                            if (item.WRITETIME.ToString().Substring(0, 4) == PREPLANYEAR)
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
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlghs);
                    result_query.Columns.Add("cityname");
                    result_query.Columns.Add("countyname");
                    result_query = county_func(result_query, Cityname_list, Countyname_list, Hazards, Zlghs);
                }
            }
            else
            {
                //������ݵ�ͳ��
                if (PREPLANUNIT == "ʡ")
                {
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlghs);
                }
                if (PREPLANUNIT == "��")
                {
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlghs);
                    result_query.Columns.Add("cityname");
                    result_query = city_func(result_query, Cityname_list, Hazards, Zlghs);
                }
                if (PREPLANUNIT == "��")
                {
                    result_query = province_func(result_query, Provincename_list, Hazards, Zlghs);
                    result_query.Columns.Add("cityname");
                    result_query.Columns.Add("countyname");
                    result_query = county_func(result_query, Cityname_list, Countyname_list, Hazards, Zlghs);
                }

            }





            return result_query;
        }

        /// <summary>
        /// ʡ������ɸѡ
        /// </summary>
        /// <param name="result_query"></param>
        /// <param name="DISProvinceNames"></param>
        /// <param name="dyResult"></param>
        /// <param name="ZLGCResult"></param>
        /// <returns></returns>
        public DataTable province_func(DataTable result_query, List<string> DISProvinceNames, dynamic dyResult, IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> ZLGCResult)
        {
            int discount = 0;
            int montcount = 0;
            result_query.Columns.Add("provincename");
            result_query.Columns.Add("disastercount");
            result_query.Columns.Add("zlghcount");
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
                if (i == DISProvinceNames.Count - 1)
                {
                    DataRow result_dr = result_query.NewRow();
                    result_dr["provincename"] = DISProvinceNames[i];
                    result_dr["disastercount"] = discount;
                    result_dr["zlghcount"] = montcount;
                    result_query.Rows.Add(result_dr);
                }
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
        public DataTable city_func(DataTable result_query, List<string> DISCityNames, dynamic dyResult, IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> ZLGCResult)
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
                result_dr["zlghcount"] = montcount_city;
                result_query.Rows.Add(result_dr);
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
        public DataTable county_func(DataTable result_query, List<string> DISCityNames, List<string> DISCountyNames, dynamic dyResult, IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> ZLGCResult)
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
                result_dr["zlghcount"] = montcount_city;
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
                        result_dr_COUNTY["zlghcount"] = montcount_county;
                        result_query.Rows.Add(result_dr_COUNTY);
                    }
                }
            }
            return result_query;
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
        public void SaveForm(string keyValue, TBL_ACHIEVEMENT_PREPLANEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
