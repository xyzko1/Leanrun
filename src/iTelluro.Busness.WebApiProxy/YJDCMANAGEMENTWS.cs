using Infoearth.Application.Entity.AuthorizeManage;
using Infoearth.Application.Entity.BaseManage;
using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.SYS.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace iTelluro.Busness.WebApiProxy
{
    public class YJDCMANAGEMENTWS
    {
        private string YJDZUrl = string.Empty;

        public YJDCMANAGEMENTWS(string yjzhurl)
        {
            if (string.IsNullOrEmpty(yjzhurl))
            {
                YJDZUrl = System.Configuration.ConfigurationManager.AppSettings["YJDCUrl"];
            }
            else
            {
                YJDZUrl = yjzhurl;
            }
        }

        public List<TBL_YJDC_EMERGENCYSURVEYEntity> GetListJson(string queryJson)
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                httpClient.BaseAddress = new Uri(YJDZUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(queryJson);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                //await异步等待回应
                var response = httpClient.PostAsync("api/EMERGENCYSURVEYApi/GetListJson", contentJson).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TBL_YJDC_EMERGENCYSURVEYEntity>>((response.Content.ReadAsStringAsync().Result));

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetInfoStatistics(string queryJson)
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                httpClient.BaseAddress = new Uri(YJDZUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(queryJson);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                //await异步等待回应
                var response = httpClient.PostAsync("api/EMERGENCYSURVEYApi/GetInfoStatistics", contentJson).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>((response.Content.ReadAsStringAsync().Result));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 根据主键删除对应应急调查表对应数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public string EMERGENCYSURVEYApi_RemoveForm(string keyValue)
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                httpClient.BaseAddress = new Uri("http://localhost:4076/");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var info = new
                {
                    queryJson = keyValue
                };
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(info);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

                //await异步等待回应
                var response = httpClient.PostAsync("api/EMERGENCYSURVEYApi/EMERGENCYSURVEYApi_RemoveForm", contentJson).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var menus = (response.Content.ReadAsStringAsync().Result);
                return JsonConvert.DeserializeObject<string>(menus);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// 根据实体主键获取实体信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_YJDC_EMERGENCYSURVEYEntity GetEntity(string keyValue)
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                httpClient.BaseAddress = new Uri(YJDZUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var info = new
                {
                    queryJson = keyValue
                };
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(info);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

                //await异步等待回应
                var response = httpClient.PostAsync("api/EMERGENCYSURVEYApi/GetEntity", contentJson).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var menus = (response.Content.ReadAsStringAsync().Result);
                return JsonConvert.DeserializeObject<TBL_YJDC_EMERGENCYSURVEYEntity>(menus);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string EMERGENCYSURVEYApi_SaveForm(string keyValue, TBL_YJDC_EMERGENCYSURVEYEntity entity)
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                httpClient.BaseAddress = new Uri(YJDZUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var info = new
                {
                    entity = entity,
                    queryJson = keyValue
                };
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(info);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

                //await异步等待回应
                var response = httpClient.PostAsync("api/EMERGENCYSURVEYApi/EMERGENCYSURVEYApi_SaveForm", contentJson).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var menus = (response.Content.ReadAsStringAsync().Result);
                return JsonConvert.DeserializeObject<string>(menus);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 根据《pagination》分页信息和参数《queryJson》API方式得到对应应急调查数据列表信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<TBL_YJDC_EMERGENCYSURVEYEntity> GetPageListJson(Pagination pagination, string queryJson)
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                httpClient.BaseAddress = new Uri(YJDZUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var info = new
                {
                    pagination = pagination,
                    queryJson = queryJson
                };
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(info);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

                //await异步等待回应
                var response = httpClient.PostAsync("api/EMERGENCYSURVEYApi/GetPageListJson", contentJson).Result;
                //var response = httpClient.PostAsync("api/EMERGENCYSURVEYApi/GetPageListJson", contentJson).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var menus = (response.Content.ReadAsStringAsync().Result);

                return JsonConvert.DeserializeObject<List<TBL_YJDC_EMERGENCYSURVEYEntity>>(menus);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 根据市、年、月生成月报
        /// </summary>
        /// <param name="city"></param>
        /// <param name="year"></param>
        ///<param name="month"></param>
        /// <returns></returns>
        public object EMERGENCYSURVEYApi_GetFZMonthReport(string city, string year, string month)
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                httpClient.BaseAddress = new Uri(YJDZUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var info = new
                {
                    city = city,
                    year = year,
                    month = month
                };
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(info);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                //await异步等待回应
                var response = httpClient.PostAsync("api/EMERGENCYSURVEYApi/EMERGENCYSURVEYApi_GetFZMonthReport", contentJson).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var menus = (response.Content.ReadAsStringAsync().Result);
                return JsonConvert.DeserializeObject<object>(menus);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }




        /// <summary>
        /// 记录操作日志(事例学习)
        /// </summary>
        /// <param name="log"></param>
        public TreeMapInfo SavaLog(string querystring)
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                httpClient.BaseAddress = new Uri(YJDZUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var info = new
                {
                    querystring = querystring
                };
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(info);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                //await异步等待回应
                var response = httpClient.PostAsync("api/AdministrativeApi/GetTreeJsonForMap", contentJson).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<TreeMapInfo>((response.Content.ReadAsStringAsync().Result));

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
      