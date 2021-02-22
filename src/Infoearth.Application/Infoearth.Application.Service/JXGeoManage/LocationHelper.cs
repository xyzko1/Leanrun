using Infoearth.Application.Entity;
using Infoearth.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Infoearth.Application.Service.JXGeoManage
{
    public class LocationHelper
    {
        private static DataTable _districtsData = null;
        private static string _unit;

        /// <summary>
        /// 根据省市县名称返回经纬度，返回JSON串
        /// </summary>
        /// <returns></returns>
        public static string GetLocationByName(DataTable dt)
        {
            _districtsData = (DataTable)CacheHelper.GetCache("_districtsData");
            if (_districtsData == null)
            {
                GetDistricts();
            }

            if (dt.Columns.Contains("县"))
            {
                if (dt.Columns.Contains("省"))
                {
                    dt.Columns.Remove("省");
                }
                if (dt.Columns.Contains("市"))
                {
                    dt.Columns.Remove("市");
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(dt.Rows[i]["县"].ToString()))
                    {
                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            else if (dt.Columns.Contains("市"))
            {
                if (dt.Columns.Contains("省"))
                {
                    dt.Columns.Remove("省");
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(dt.Rows[i]["市"].ToString()))
                    {
                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }

            _unit = dt.Columns.IndexOf("县") != -1 ? "县" : dt.Columns.IndexOf("市") != -1 ? "市" : "省";

            //加表头
            dt.Columns.Add("LONGITUDE");
            dt.Columns.Add("LATITUDE");

            try
            {
                int count1 = dt.Rows.Count;
                int count2 = _districtsData.Rows.Count;
                for (int i = 0; i < count1; i++)
                {
                    string s = dt.Rows[i][_unit].ToString();
                    for (int j = 0; j < count2; j++)
                    {
                        string strs = _districtsData.Rows[j]["DistrictName"].ToString();
                        if (strs == s)
                        {
                            dt.Rows[i]["LONGITUDE"] = _districtsData.Rows[j]["F_LONGITUDE"];
                            dt.Rows[i]["LATITUDE"] = _districtsData.Rows[j]["F_LATITUDE"];
                        }
                    }
                }
                return "{\"data\":" + dt.ToJson() + "}";//返回JSON
            }
            catch (Exception ex)
            {
                return "{\"data\":" + dt.ToJson() + "}";//返回JSON
            }
        }
        public static string GetLocationByName2(DataTable dt)
        {          
            if (dt.Columns.Contains("县"))
            {
                if (dt.Columns.Contains("省"))
                {
                    dt.Columns.Remove("省");
                }
                if (dt.Columns.Contains("市"))
                {
                    dt.Columns.Remove("市");
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(dt.Rows[i]["县"].ToString()))
                    {
                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            else if (dt.Columns.Contains("市"))
            {
                if (dt.Columns.Contains("省"))
                {
                    dt.Columns.Remove("省");
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(dt.Rows[i]["市"].ToString()))
                    {
                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }

            _unit = dt.Columns.IndexOf("县") != -1 ? "县" : dt.Columns.IndexOf("市") != -1 ? "市" : "省";

            //加表头
            dt.Columns.Add("LONGITUDE");
            dt.Columns.Add("LATITUDE");

            try
            {
                int count1 = dt.Rows.Count;
                int count2 = _districtsData.Rows.Count;
                for (int i = 0; i < count1; i++)
                {
                    string s = dt.Rows[i][_unit].ToString();
                    for (int j = 0; j < count2; j++)
                    {
                        string strs = _districtsData.Rows[j]["DistrictName"].ToString();
                        if (strs == s)
                        {
                            dt.Rows[i]["LONGITUDE"] = _districtsData.Rows[j]["F_LONGITUDE"];
                            dt.Rows[i]["LATITUDE"] = _districtsData.Rows[j]["F_LATITUDE"];
                        }
                    }
                }
                return "{\"data\":" + dt.ToJson() + "}";//返回JSON
            }
            catch (Exception ex)
            {
                return "{\"data\":" + dt.ToJson() + "}";//返回JSON
            }
        }
        private static void GetDistrictsold()
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                string uri = ConfigurationManager.AppSettings["SSOUrl"];
                httpClient.BaseAddress = new Uri(uri);
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                string DefalutCode = ConfigurationManager.AppSettings["DefalutCode"];
                if (String.IsNullOrEmpty(DefalutCode.Trim())) { DefalutCode = ""; }
                string json = "{\"DistrictName\":\"\",\"DistrictCode\":" + DefalutCode + ",\"PageIndex\":1,\"PageSize\": 10000}";
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                //await异步等待回应
                var response = httpClient.PostAsync("api/AdministrativeApi/GetDistricts", contentJson).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                string result = response.Content.ReadAsStringAsync().Result;
                _districtsData = result.ToObject<DataTable>();
                for (int i = 0; i < _districtsData.Rows.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(_districtsData.Rows[i]["F_LONGITUDE"].ToString()))
                    {
                        _districtsData.Rows[i].Delete();
                        i--;
                    }
                }
                CacheHelper.SetCache("_districtsData", _districtsData, 1);//写缓存
            }
            catch (Exception)
            {
            }
        }
        private static void GetDistricts()
        {
            try
            {
                AdministrativeEntity entity = new AdministrativeEntity();
                entity.PageIndex = 1;
                entity.PageSize = 100000;
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                string uri = ConfigurationManager.AppSettings["SSOUrl"];
                string dd = Md5Helper.MD5("0000", 32);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                httpClient.BaseAddress = new Uri(uri);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(entity);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //var content = new FormUrlEncodedContent(new Dictionary<string, string>() { 
                //    {"DistrictName",entity.DistrictName},
                //    {"PageIndex",entity.PageIndex.ToString()},
                //    {"PageSize",entity.PageSize.ToString()},
                //    {"sidx","F_AreaCode desc"},
                //});
                //await异步等待回应
                var response = httpClient.PostAsync("api/AdministrativeApi/GetDistricts", content).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                var json1 = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json1.Success;
                if (success)
                {
                    JArray jo = json1.Result;
                    string jos = jo.ToString();
                    _districtsData = jos.ToObject<DataTable>();
                    for (int i = 0; i < _districtsData.Rows.Count; i++)
                    {
                        if (string.IsNullOrWhiteSpace(_districtsData.Rows[i]["F_LONGITUDE"].ToString()))
                        {
                            //_districtsData.Rows[i].Delete();
                            // i--;
                        }
                    }
                    CacheHelper.SetCache("_districtsData", _districtsData, 1);//写缓存
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}