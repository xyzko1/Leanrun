using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Application.Entity.JXGeoManage;
using iTelluro.Busness.WebApi;
using System.Web.Http;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using Infoearth.Application.Entity.SystemManage;
using System.Linq;
using System.Data;
using Newtonsoft.Json;
using System;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:15
    /// 描 述：群测群防行政管理体系
    /// </summary>
    public class TBL_QCQF_ADMINISTRATIVEApiController : ApiControllerBase
    {
        private TBL_QCQF_ADMINISTRATIVEBLL tbl_qcqf_administrativebll = new TBL_QCQF_ADMINISTRATIVEBLL();
        [HttpGet]
        public object GetPageListJsonnew([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_qcqf_administrativebll.GetPageList(pagination, queryJson);
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
        #region 获取数据
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var dt = tbl_qcqf_administrativebll.GetPageList(pagination, queryJson);
            DataTable data = new DataTable();
            data.Columns.Add("GUID");
            data.Columns.Add("PROVINCENAME");
            data.Columns.Add("CITYNAME");
            data.Columns.Add("COUNTYNAME");
            data.Columns.Add("TOWNNAME");
            data.Columns.Add("VILLAGENAME");
            data.Columns.Add("DISTRICTCODE");
            data.Columns.Add("CONTACTPEOPLENAME");
            data.Columns.Add("Mobile");
            data.Columns.Add("CONTACTPEOPLEID");
            data.Columns.Add("CONTACTDEPTID");
            data.Columns.Add("LATITUDE");
            data.Columns.Add("LONGITUDE");
            data.Columns.Add("NAME");
            data.Columns.Add("TELPHONE");
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);

            //var a = ws.GetUserList();
            //var ceshi = (Newtonsoft.Json.Linq.JArray)(a.ToJson());
            //User user = new User();
            //foreach (var item in ceshi)
            //{
            //    user = JsonConvert.DeserializeObject<User>(item.ToString());
            //}
            foreach (var item in dt)
            {
                Pagination pagination1 = new Pagination();
                DataRow row = data.NewRow();
                row["GUID"] = item.GUID;
                row["PROVINCENAME"] = item.PROVINCENAME;
                row["CITYNAME"] = item.CITYNAME;
                row["COUNTYNAME"] = item.COUNTYNAME;
                row["TOWNNAME"] = item.TOWNNAME;
                row["VILLAGENAME"] = item.VILLAGENAME;
                row["DISTRICTCODE"] = item.DISTRICTCODE;
                row["NAME"] = item.NAME;
                row["TELPHONE"] = item.TELPHONE;
                User user = JsonConvert.DeserializeObject<User>(ws.FetchByColumnNameAndValue("F_UserId", item.CONTACTPEOPLEID).Trim('[').Trim(']'));
                if (user != null)
                {
                    row["CONTACTPEOPLENAME"] = user.UserName;
                    row["Mobile"] = user.Mobile;
                    row["CONTACTPEOPLEID"] = item.CONTACTPEOPLEID;
                    row["CONTACTDEPTID"] = item.CONTACTDEPTID;
                    row["LATITUDE"] = item.LATITUDE;
                    row["LONGITUDE"] = item.LONGITUDE;
                }
                data.Rows.Add(row);
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
        public object GetUserName( string keyValue)
        {
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            User user = JsonConvert.DeserializeObject<User>(ws.FetchByColumnNameAndValue("F_UserId", keyValue).Trim('[').Trim(']'));
            return user.UserName; 
        }
        public object GetDeptName(string keyValue)
        {
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            User user = JsonConvert.DeserializeObject<User>(ws.FetchByColumnNameAndValue("F_UserId", keyValue).Trim('[').Trim(']'));
            return user.DeptName;
        }
        [HttpGet]
        public object GetListJson(string queryJson)
        {
            var data = tbl_qcqf_administrativebll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_QCQF_ADMINISTRATIVEEntity GetFormJson(string keyValue)
        {
            var data = tbl_qcqf_administrativebll.GetEntity(keyValue);
            return data;
        }
        [HttpGet]
        public object PdState(string id)
        {
            var data = tbl_qcqf_administrativebll.PdState(id);
            return data;
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm(SingleParam param)
        {
            tbl_qcqf_administrativebll.RemoveForm(param.KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_QCQF_ADMINISTRATIVEEntity entity)
        {
            tbl_qcqf_administrativebll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
        public class User
        {
            public string LoginName { get; set; }
            public string ContactPeopleID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string CardID { get; set; }
            public string Mobile { get; set; }
            public string Telephone { get; set; }
            public string Qq { get; set; }
            public string Msn { get; set; }
            public string Sex { get; set; }
            public string BornDate { get; set; }
            public string Photo { get; set; }
            public string UserStatus { get; set; }
            public string LoginStatus { get; set; }
            public string Dept { get; set; }
            public string DeptName { get; set; }
            public string Loc { get; set; }
            public string DistrictName { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string DirectorLevel { get; set; }
            public string Zipcode { get; set; }
        }
    }
}
