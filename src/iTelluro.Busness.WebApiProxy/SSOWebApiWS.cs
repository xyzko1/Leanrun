using Infoearth.Application.Entity;
using Infoearth.Application.Entity.AuthorizeManage;
using Infoearth.Application.Entity.BaseManage;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.SYS.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace iTelluro.Busness.WebApiProxy
{
    public class SSOWebApiWS
    {
        private string SSOUrl = string.Empty;
        private bool IsResultWrap = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["WebApiResultWrap"]);
        public SSOWebApiWS(string ssourl)
        {
            if (string.IsNullOrEmpty(ssourl))
            {
                SSOUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            }
            else
            {
                SSOUrl = ssourl;
            }
        }
        /// <summary>
        /// 根据主键查找用户信息
        /// </summary>
        /// <param name="contactPersonId"></param>
        /// <returns></returns>
        public string GetCurrentUserCode()
        {
            //return WebapiRequestHelp.Post(SSOUrl, "/api/UsersApi/FetchByID", contactPersonId);
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //await异步等待回应
                var response = httpClient.GetAsync("/api/AdministrativeApi/GetCurrentUserCode").Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return result;
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    return json.Result;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 根据主键查找用户信息
        /// </summary>
        /// <param name="contactPersonId"></param>
        /// <returns></returns>
        public string GetUserFetchByID(string contactPersonId)
        {
            //return WebapiRequestHelp.Post(SSOUrl, "/api/UsersApi/FetchByID", contactPersonId);
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //await异步等待回应
                var response = httpClient.PostAsync("/api/UsersApi/FetchByID?contactPersonId=" + contactPersonId, null).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return result;
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    //JArray jo = json.Result;
                    //return jo.ToString();
                    //List<UserInfo> sss = JsonConvert.DeserializeObject<List<UserInfo>>(json.Result);
                    ContactPeople sss = JsonConvert.DeserializeObject<ContactPeople>(json.Result.ToString());
                    return sss.ToJson();
                    //JArray jo = json.Result;
                    //string jos = jo.ToString();
                    //return jos;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 检查票据的有效性
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool CheckToken(string token)
        {
            string url = "api/SSOAuth/CheckTicket/" + token;
            //创建HttpClient（注意传入HttpClientHandler）
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (var http = new HttpClient(handler))
            {
                http.BaseAddress = new Uri(SSOUrl);
                //await异步等待回应
                var response = http.GetAsync(url).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                //return bool.Parse(response.Content.ReadAsStringAsync().Result);
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return bool.Parse(response.Content.ReadAsStringAsync().Result);
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    return json.Result;
                }
                else
                {
                    return false;
                }
            }
        }
        //public bool CheckToken(string token)
        //{
        //    string url = "api/SSOAuth/CheckTicket/" + token;
        //    //创建HttpClient（注意传入HttpClientHandler）
        //    var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
        //    using (var http = new HttpClient(handler))
        //    {
        //        http.BaseAddress = new Uri(SSOUrl);
        //        //await异步等待回应
        //        var response = http.GetAsync(url).Result;
        //        //确保HTTP成功状态值
        //        response.EnsureSuccessStatusCode();
        //        //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
        //        return bool.Parse(response.Content.ReadAsStringAsync().Result);
        //    }
        //}

        /// <summary>
        /// 检查票据的有效性
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public int IsOnLine(string token)
        {
            string url = "api/SSOAuth/IsOnLine/" + token;
            //创建HttpClient（注意传入HttpClientHandler）
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (var http = new HttpClient(handler))
            {
                http.BaseAddress = new Uri(SSOUrl);
                //await异步等待回应
                var response = http.GetAsync(url).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                //return int.Parse(response.Content.ReadAsStringAsync().Result);
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return int.Parse(result);
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    return int.Parse(json.Result);
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 检查地址的有效性
        /// </summary>
        /// <param name="moduleId">菜单Id</param>
        /// <param name="weburl">菜单地址</param>
        /// <param name="isFromSSO">是否从SSO获取菜单</param>
        /// <returns></returns>
        public bool CheckUrlPermission(string moduleId, string weburl, bool isFromSSO)
        {
            try
            {
                string url = "api/BusinessMenuApi/CheckUrlPermission";
                //创建HttpClient（注意传入HttpClientHandler）
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                string businessCode = System.Configuration.ConfigurationManager.AppSettings["businessCode"];
                var urlInfo = new UrlInfos { IsMeunFromSSO = isFromSSO, ModuleId = moduleId, Url = weburl, BusinessCode = businessCode };
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                using (var http = new HttpClient(handler))
                {
                    http.BaseAddress = new Uri(SSOUrl);
                    http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    //await异步等待回应 //await异步等待回应
                    var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(urlInfo), Encoding.UTF8, "application/json");

                    var response = http.PostAsync(url, content).Result;
                    //确保HTTP成功状态值
                    response.EnsureSuccessStatusCode();

                    //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                    //return bool.Parse(response.Content.ReadAsStringAsync().Result);
                    var result = response.Content.ReadAsStringAsync().Result;
                    if (!IsResultWrap)
                    {
                        return bool.Parse(response.Content.ReadAsStringAsync().Result);
                    }
                    var json = JsonConvert.DeserializeObject<dynamic>(result);
                    bool success = json.Success;
                    if (success)
                    {
                        return json.Result;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void GetXZQHDatas(string ticket, string userId)
        {
            string url = "http://localhost:4064/api/AuthDistrictZoneListApi/FetchByUserID";
            //创建HttpClient（注意传入HttpClientHandler）
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };

            using (var http = new HttpClient(handler))
            {
                http.BaseAddress = new Uri(SSOUrl);
                //await异步等待回应 //await异步等待回应
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ticket);
                var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("", userId) });
                var response = http.PostAsync(url, content).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();

                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                string result = response.Content.ReadAsStringAsync().Result;
            }
        }

        public string GetUserID(string ticket)
        {
            string url = "api/AuthDistrictZoneListApi/GetCurrentUserId";
            //创建HttpClient（注意传入HttpClientHandler）
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };

            using (var http = new HttpClient(handler))
            {
                http.BaseAddress = new Uri(SSOUrl);
                //await异步等待回应 //await异步等待回应
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ticket);
                var response = http.PostAsync(url, null).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();

                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                //return response.Content.ReadAsStringAsync().Result;
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return result;
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    return json.Result;
                }
                else
                {
                    return "";
                }
            }
        }

        public List<string> GetMenuByBusinessCodeAndUserID(string businessCode)
        {
            if (businessCode == null) throw new ArgumentNullException("businessCode");
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //await异步等待回应
                var response = httpClient.GetAsync("api/BusinessMenuApi/GetMenuByBusinessCodeAndUserID/" + businessCode).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<List<string>>(result);
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    JArray jo = json.Result;
                    string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<List<string>>(jos);

                }
                else
                {
                    return new List<string>();
                }
                //var menus = (response.Content.ReadAsStringAsync().Result);

                //return JsonConvert.DeserializeObject<List<string>>(menus);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取授权菜单按钮
        /// </summary>
        /// <param name="businessCode">业务系统Code</param>
        /// <returns></returns>
        public List<string> GetMenuButtonByBusinessCodeAndUserID(string businessCode)
        {
            if (businessCode == null) throw new ArgumentNullException("businessCode");
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //await异步等待回应
                var response = httpClient.GetAsync("api/BusinessMenuApi/GetMenuButtonByBusinessCodeAndUserID/" + businessCode).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<List<string>>(result);
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    JArray jo = json.Result;
                    string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<List<string>>(jos);
                    // return JsonConvert.DeserializeObject<List<string>>(json.Result);
                }
                else
                {
                    return new List<string>();
                }
                //var menus = (response.Content.ReadAsStringAsync().Result);

                //return JsonConvert.DeserializeObject<List<string>>(menus);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取登陆的用户信息
        /// </summary>
        /// <returns></returns>
        public UserInfo GetUserInfo()
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //await异步等待回应
                var response = httpClient.GetAsync("api/SSOAuth/GetUserInfoByTicket/" + token).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<UserInfo>(result);
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    //JArray jo = json.Result;
                    //string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<UserInfo>(json.Result.ToString());
                }
                else
                {
                    return new UserInfo();
                }
                //var result = (response.Content.ReadAsStringAsync().Result);
                //UserInfo info = JsonConvert.DeserializeObject<UserInfo>(result);
                //return info;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public class CodeByName
        {
            public string DistrictCode { get; set; }
            public string DistrictName { get; set; }
            public string AllPinYin { get; set; }
            public string FirstPinYin { get; set; }
            public string F_LONGITUDE { get; set; }
            public string F_LATITUDE { get; set; }
        }
        public CodeByName GetDistrctByCodesnew(string[] codes)
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                string json1 = Newtonsoft.Json.JsonConvert.SerializeObject(codes);
                var contentJson = new StringContent(json1, Encoding.UTF8, "application/json");
                //await异步等待回应
                var response = httpClient.PostAsync("/api/AdministrativeApi/GetDistrctByCodesExt", contentJson).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<CodeByName>(result);
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    //JObject jo = json.Result;
                    //string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<CodeByName>(result);
                }
                else
                {
                    return new CodeByName();
                }
                //var result = response.Content.ReadAsStringAsync().Result;
                //if (!IsResultWrap)
                //{
                //    return JsonConvert.DeserializeObject<List<AreaEntity>>(result);
                //}
                //var json = JsonConvert.DeserializeObject<List<CodeByName>>(result);
                //bool success = json.Success;
                //if (success)
                //{
                //    JArray jo = json.Result;
                //    string jos = jo.ToString();
                //    return JsonConvert.DeserializeObject<List<AreaEntity>>(jos);
                //}
                //else
                //{
                //    return new List<AreaEntity>();
                //}
                return json[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DistrctEntity[] GetDistrctByCodes(string districtCode)
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


                //await异步等待回应
                var response = httpClient.GetAsync("api/AdministrativeApi/GetDistrctByCodes/" + districtCode).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<DistrctEntity[]>(result);
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    JArray jo = json.Result;
                    string jos = jo.ToString();
                    // string tempResult = json.Result;
                    return JsonConvert.DeserializeObject<DistrctEntity[]>(jos);
                }
                else
                {
                    //DistrctEntity[] cd = new DistrctEntity[0];
                    return new DistrctEntity[0];
                }
                //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<DistrctEntity[]>((response.Content.ReadAsStringAsync().Result));

                //return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="ticket"></param>
        public void ClearTicket()
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                httpClient.BaseAddress = new Uri(SSOUrl);
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                //httpClient.SetBearerToken(_token);
                //await异步等待回应
                var response = httpClient.GetAsync("api/SSOAuth/ClearTicket/" + token).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = (response.Content.ReadAsStringAsync().Result);
                //var result = response.Content.ReadAsStringAsync().Result;
                //if (!IsResultWrap)
                //{
                //    return result;
                //}
                //var json = JsonConvert.DeserializeObject<dynamic>(result);
                //bool success = json.Success;
                //if (success)
                //{
                //    return json.Result;
                //}
                //else
                //{
                //    DistrctEntity[] cd = new DistrctEntity[0];
                //    //return new DistrctEntity []();
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 根据用户账户获取用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoByUserAccount(string account)
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //await异步等待回应
                var response = httpClient.GetAsync("api/SSOAuth/GetUserInfoByUserAccount/" + account).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<UserInfo>(result);
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    return JsonConvert.DeserializeObject<UserInfo>(json.Result);
                }
                else
                {
                    return new UserInfo();
                }
                //var result = (response.Content.ReadAsStringAsync().Result);
                //UserInfo info = JsonConvert.DeserializeObject<UserInfo>(result);

                //return info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AreaEntity> GetDistricts(AdministrativeEntity entity)
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                string dd = Md5Helper.MD5("0000", 32);
                if (token.Contains(','))
                {
                    token = token.Split(',')[0];
                    token = Md5Helper.MD5(token, 32);
                    token = token.ToUpper();
                }
                httpClient.BaseAddress = new Uri(SSOUrl);
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
                if (!IsResultWrap)
                {
                    List<AreaEntity> returnValue = JsonConvert.DeserializeObject<List<DistrictDicts>>(result).ToList().Select(p => new AreaEntity()
                    {
                        F_AreaCode = p.DistrictCode,
                        F_AreaName = p.DistrictName,
                        F_LONGITUDE = p.F_LONGITUDE,
                        F_LATITUDE = p.F_LATITUDE,
                    }).ToList();
                    return returnValue;
                }
                var json1 = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json1.Success;
                if (success)
                {
                    JArray jo = json1.Result;
                    string jos = jo.ToString();
                    List<AreaEntity> returnValue = JsonConvert.DeserializeObject<List<DistrictDicts>>(jos).ToList().Select(p => new AreaEntity()
                    {
                        F_AreaCode = p.DistrictCode,
                        F_AreaName = p.DistrictName,
                        F_LONGITUDE = p.F_LONGITUDE,
                        F_LATITUDE = p.F_LATITUDE,
                    }).ToList();
                    return returnValue;
                }
                else
                {
                    return new List<AreaEntity>();
                }
                //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DistrictDict>>((response.Content.ReadAsStringAsync().Result));
                //List<AreaEntity> returnValue = result.Select(p => new AreaEntity()
                //{
                //    F_AreaCode = p.DistrictCode,
                //    F_AreaName = p.DistrictName,
                //}).ToList();
                //return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<AreaEntity> GetAllDistrictsToCountry()
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //await异步等待回应
                var response = httpClient.GetAsync("api/AdministrativeApi/GetAllDistrictsToCountry").Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    List<AreaEntity> returnValue = JsonConvert.DeserializeObject<List<DistrictDictNEW>>(result).ToList().Select(p => new AreaEntity()
                    {
                        F_AreaCode = p.F_AreaCode,
                        F_AreaName = p.F_AreaName,
                        F_LONGITUDE = p.F_LONGITUDE,
                        F_LATITUDE = p.F_LATITUDE,
                    }).ToList();
                    return returnValue;
                }
                var json1 = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json1.Success;
                if (success)
                {
                    JArray jo = json1.Result;
                    string jos = jo.ToString();
                    List<AreaEntity> returnValue = JsonConvert.DeserializeObject<List<DistrictDictNEW>>(jos).ToList().Select(p => new AreaEntity()
                    {
                        F_AreaCode = p.F_AreaCode,
                        F_AreaName = p.F_AreaName,
                        F_LONGITUDE = p.F_LONGITUDE,
                        F_LATITUDE = p.F_LATITUDE,
                    }).ToList();
                    return returnValue;
                }
                else
                {
                    return new List<AreaEntity>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public List<AreaEntity> GetAreaListJson(string parentId)
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


                //await异步等待回应
                var response = httpClient.GetAsync("api/AdministrativeApi/GetAreaListJson/" + parentId).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<List<AreaEntity>>(result);
                }
                var json1 = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json1.Success;
                if (success)
                {
                    JArray jo = json1.Result;
                    string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<List<AreaEntity>>(jos);
                }
                else
                {
                    return new List<AreaEntity>();
                }
                //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AreaEntity>>((response.Content.ReadAsStringAsync().Result));

                //return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ParetEntity> GetDistrictByParent(string DefalutCode)
        {
            if (DefalutCode == null) throw new ArgumentNullException("DefalutCode");
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //await异步等待回应
                var response = httpClient.GetAsync("api/AdministrativeApi/GetDistrictByParent/" + DefalutCode).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<List<ParetEntity>>(result);
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    JArray jo = json.Result;
                    string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<List<ParetEntity>>(jos);
                }
                else
                {
                    return new List<ParetEntity>();
                }
                //var menus = (response.Content.ReadAsStringAsync().Result);

                //return JsonConvert.DeserializeObject<List<ParetEntity>>(menus);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<AreaEntity> GetAllProvinceByCodes(string provinceIds)
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


                //await异步等待回应
                var response = httpClient.GetAsync("api/AdministrativeApi/GetAllProvinceByCodes/" + provinceIds).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<List<AreaEntity>>(result);
                }
                var json1 = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json1.Success;
                if (success)
                {
                    JArray jo = json1.Result;
                    string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<List<AreaEntity>>(jos);
                }
                else
                {
                    return new List<AreaEntity>();
                }
                //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AreaEntity>>((response.Content.ReadAsStringAsync().Result));

                //return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<AreaEntity> GetAllByParentCodes(string codes)
        {
            try
            {
                if (string.IsNullOrEmpty(codes))
                {
                    return new List<AreaEntity>();
                }
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                string[] cc = codes.Split(',');
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(cc), Encoding.UTF8, "application/json");
                //await异步等待回应
                var response = httpClient.PostAsync("api/AdministrativeApi/GetAllByParentCodesExtWithAuth", content).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<List<AreaEntity>>(result);
                }
                var json1 = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json1.Success;
                if (success)
                {
                    JArray jo = json1.Result;
                    string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<List<AreaEntity>>(jos);
                }
                else
                {
                    return new List<AreaEntity>();
                }
                //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AreaEntity>>((response.Content.ReadAsStringAsync().Result));

                //return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<AreaEntity> GetAllByParentCodesNew(string codes)
        {
            try
            {
                if (string.IsNullOrEmpty(codes))
                {
                    return new List<AreaEntity>();
                }
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                string[] cc = codes.Split(',');
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(cc), Encoding.UTF8, "application/json");
                //await异步等待回应
                var response = httpClient.PostAsync("api/AdministrativeApi/GetAllByParentCodesExt", content).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<List<AreaEntity>>(result);
                }
                var json1 = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json1.Success;
                if (success)
                {
                    JArray jo = json1.Result;
                    string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<List<AreaEntity>>(jos);
                }
                else
                {
                    return new List<AreaEntity>();
                }
                //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AreaEntity>>((response.Content.ReadAsStringAsync().Result));

                //return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 获取授权的行政区划
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllAuthDistricts()
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


                //await异步等待回应
                var response = httpClient.GetAsync("api/AdministrativeApi/GetAuthDistrictData").Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<List<DistrictDict>>(result).ToList().Select(t => t.DistrictCode).ToList();
                }
                var json1 = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json1.Success;
                if (success)
                {
                    JArray jo = json1.Result;
                    string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<List<DistrictDict>>(jos).OrderBy(t => t.DistrictCode).Select(t => t.DistrictCode).ToList();
                }
                else
                {
                    return new List<string>();
                }
                //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DistrictDict>>((response.Content.ReadAsStringAsync().Result));
                //if (result == null)
                //{
                //    return new List<string>();
                //}
                //return result.Select(t => t.DistrictCode).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// 获取授权的行政区划
        /// </summary>
        /// <returns></returns>
        public List<DistrictDict> GetAllAuthDistrictsReturnDistrictDict()
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


                //await异步等待回应
                var response = httpClient.GetAsync("api/AdministrativeApi/GetAuthDistrictData").Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<List<DistrictDict>>(result);
                }
                var json1 = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json1.Success;
                if (success)
                {
                    JArray jo = json1.Result;
                    string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<List<DistrictDict>>(jos);
                }
                else
                {
                    return new List<DistrictDict>();
                }
                //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DistrictDict>>((response.Content.ReadAsStringAsync().Result));
                //if (result == null)
                //{
                //    return new List<DistrictDict>();
                //}
                //return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取授权的用户Id
        /// </summary>
        /// <returns></returns>
        public string GetAllAuthUserIds()
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


                //await异步等待回应
                var response = httpClient.GetAsync("api/BusinessMenuApi/GetAuthData").Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return result;
                }
                var json1 = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json1.Success;
                if (success)
                {
                    return json1.Result;
                }
                else
                {
                    return "";
                }
                //var result = (response.Content.ReadAsStringAsync().Result);

                //return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="log"></param>
        public void SavaLog(LogEntity log)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
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
            httpClient.BaseAddress = new Uri(SSOUrl);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            //await异步等待回应
            var response = httpClient.PostAsync("api/V1/LogApi/SaveLog", contentJson);
        }

        /// <summary>
        /// 从基础信息平台获取业务菜单
        /// </summary>
        /// <param name="businessCode"></param>
        /// <returns></returns>
        public List<ModuleEntity> GetBusinessMenuFromSSO(string businessCode)
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //await异步等待回应
                var response = httpClient.GetAsync("api/BusinessMenuApi/GetBusinessMenuFromSSO/" + businessCode).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ModuleEntity>>((response.Content.ReadAsStringAsync().Result));
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<List<ModuleEntity>>(result);
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    JArray jo = json.Result;
                    string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<List<ModuleEntity>>(jos);
                }
                else
                {
                    return new List<ModuleEntity>();
                }
                //return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 从基础信息平台获取业务菜单按钮
        /// </summary>
        /// <param name="businessCode"></param>
        /// <returns></returns>
        public List<ModuleButtonEntity> GetBusinessMenuButtonFromSSO(string businessCode)
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //await异步等待回应
                var response = httpClient.GetAsync("api/BusinessMenuApi/GetBusinessMenuButtonFromSSO/" + businessCode).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<List<ModuleButtonEntity>>(result);
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    JArray jo = json.Result;
                    string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<List<ModuleButtonEntity>>(jos);
                }
                else
                {
                    return new List<ModuleButtonEntity>();
                }
                //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ModuleButtonEntity>>((response.Content.ReadAsStringAsync().Result));

                //return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public string GetUser(Pagination pagination, string queryJson)
        {

            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            var qJson = queryJson.ToJObject();
            if (json.condition == "UserName")
            {
                var info = new
                {
                    AreaCode = json.AreaCode,
                    UserName = json.UserName,
                    PageIndex = pagination.page,
                    PageSize = pagination.rows
                };
                pagination.records = WebapiRequestHelp.PostApi<int>(SSOUrl, "/api/UsersApi/GetUserCounts", info);
                return WebapiRequestHelp.Post(SSOUrl, "/api/UsersApi/GetUsers", info);
            }
            else
            {
                var info = new
                {
                    AreaCode = json.AreaCode,
                    Account = json.UserName,
                    PageIndex = pagination.page,
                    PageSize = pagination.rows
                };
                pagination.records = WebapiRequestHelp.PostApi<int>(SSOUrl, "/api/UsersApi/GetUserCounts", info);
                if (pagination.records == 0 && qJson["AreaCode"].ToString().Substring(4, 2) != "00")
                {
                    var info1 = new
                    {
                        AreaCode = qJson["AreaCode"].ToString().Substring(0, 4) + "00",
                        Account = json.UserName,
                        PageIndex = pagination.page,
                        PageSize = pagination.rows,
                        IsIncludeSub = false
                    };
                    pagination.records = WebapiRequestHelp.PostApi<int>(SSOUrl, "/api/UsersApi/GetUserCounts", info1);
                    if (pagination.records == 0 && info1.AreaCode.Substring(4, 2) == "00")
                    {
                        var info2 = new
                        {
                            AreaCode = qJson["AreaCode"].ToString().Substring(0, 2) + "0000",
                            Account = json.UserName,
                            PageIndex = pagination.page,
                            PageSize = pagination.rows,
                            IsIncludeSub = false
                        };
                        pagination.records = WebapiRequestHelp.PostApi<int>(SSOUrl, "/api/UsersApi/GetUserCounts", info2);
                        return WebapiRequestHelp.Post(SSOUrl, "/api/UsersApi/GetUsers", info2);
                    }
                    return WebapiRequestHelp.Post(SSOUrl, "/api/UsersApi/GetUsers", info1);
                }
                else if (pagination.records == 0 && qJson["AreaCode"].ToString().Substring(4, 2) == "00" && qJson["AreaCode"].ToString().Substring(2, 4) != "0000")
                {
                    var info3 = new
                    {
                        AreaCode = qJson["AreaCode"].ToString().Substring(0, 2) + "0000",
                        Account = json.UserName,
                        PageIndex = pagination.page,
                        PageSize = pagination.rows,
                        IsIncludeSub = false
                    };
                    pagination.records = WebapiRequestHelp.PostApi<int>(SSOUrl, "/api/UsersApi/GetUserCounts", info3);
                    return WebapiRequestHelp.Post(SSOUrl, "/api/UsersApi/GetUsers", info3);
                }
                return WebapiRequestHelp.Post(SSOUrl, "/api/UsersApi/GetUsers", info);
            }
        }
        public string GetUserList()
        {
            Pagination pagination = new Pagination();
            var info = new
            {
                PageIndex = pagination.page,
                PageSize = pagination.rows
            };
            int count = WebapiRequestHelp.PostApi<int>(SSOUrl, "/api/UsersApi/GetUserCounts", info);
            pagination.records = count;
            var info1 = new
            {
                PageIndex = pagination.page,
                PageSize = count
            };
            return WebapiRequestHelp.Post(SSOUrl, "/api/UsersApi/GetUsers", info1);
        }
        /// <summary>
        /// 根据条件获取用户信息
        /// </summary>
        /// <returns></returns>
        public string FetchByColumnNameAndValue(string ColumnName, string CValue)
        {
            var info = new
            {
                ColumnName = ColumnName,
                CValue = CValue,
            };
            return WebapiRequestHelp.Post(SSOUrl, "/api/UsersApi/FetchByColumnNameAndValue", info);
        }
        public string GetDept(Pagination pagination, string queryJson)
        {
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            var info = new
            {
                DeptName = json.DeptName,
                PageIndex = pagination.page,
                PageSize = pagination.rows
            };
            pagination.records = WebapiRequestHelp.PostApi<int>(SSOUrl, "/api/DeptsApi/FetchAllRows", info);
            return WebapiRequestHelp.Post(SSOUrl, "/api/DeptsApi/GetDept", info);
        }

        public List<AreaEntity> GetTreeJsonForMap(string value, string code)
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var info = new
                {
                    value = value,
                    code = code
                };
                string json1 = Newtonsoft.Json.JsonConvert.SerializeObject(info);
                var contentJson = new StringContent(json1, Encoding.UTF8, "application/json");
                //await异步等待回应
                var response = httpClient.PostAsync("api/AdministrativeApi/GetTreeJsonForMapNew", contentJson).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    return JsonConvert.DeserializeObject<List<AreaEntity>>(result);
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    JArray jo = json.Result;
                    string jos = jo.ToString();
                    return JsonConvert.DeserializeObject<List<AreaEntity>>(jos);
                }
                else
                {
                    return new List<AreaEntity>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<string> GetTopMeunParentIds()
        {
            try
            {
                string businessCode = System.Configuration.ConfigurationManager.AppSettings["businessCode"];
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
                httpClient.BaseAddress = new Uri(SSOUrl);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //await异步等待回应
                var response = httpClient.GetAsync("api/BusinessMenuApi/GetParentIdsBySystemCode/" + businessCode).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                var result = response.Content.ReadAsStringAsync().Result;
                if (!IsResultWrap)
                {
                    var list = result.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    List<string> tmp = new List<string>();
                    foreach (var item in list)
                    {
                        tmp.Add(item.Trim('\"'));
                    }
                    return tmp;
                }
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                bool success = json.Success;
                if (success)
                {
                    string jos = json.Result.ToString();
                    return jos.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else
                {
                    return new List<string>() { "0" };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// 获取所有行政区划的数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetCodeNames()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            string responce = WebapiRequestHelp.GetApi(SSOUrl, "api/AdministrativeApi/GetAllDistrictsToCountry", string.Empty);

            dynamic json = JToken.Parse(responce) as dynamic;

            foreach (var item in json)
            {
                string code = item.F_AreaCode;
                string name = item.F_AreaName;
                result.Add(code, name);
            }

            return result;
        }
    }

    public class TreeMapInfo
    {
        public List<TreeEntity> TreeNodes { get; set; }

        public string ParentCode { get; set; }
    }
    public class ParetEntity
    {
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string AllPinYin { get; set; }
        public string FirstPinYin { get; set; }
        public string F_LONGITUDE { get; set; }
        public string F_LATITUDE { get; set; }
    }
    public class DistrictDicts : DistrictDict
    {

        public decimal? F_LONGITUDE { get; set; }
        public decimal? F_LATITUDE { get; set; }
    }
    public class DistrictDictNEW
    {
        public string F_AreaName { get; set; }
        public string F_AreaCode { get; set; }
        public decimal? F_LONGITUDE { get; set; }
        public decimal? F_LATITUDE { get; set; }
    }
    public class ContactPeople
    {
        public string ContactPeopleID { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string UserStatus { get; set; }
        public string CardID { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Qq { get; set; }
        public string Msn { get; set; }
        public string Sex { get; set; }
        public string BornDate { get; set; }
        public string Photo { get; set; }
        public string Dept { get; set; }
        public string DeptName { get; set; }
        public string Loc { get; set; }
        public string DistrictName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string DirectorLevel { get; set; }
        public string ZipCode { get; set; }
    }
}
