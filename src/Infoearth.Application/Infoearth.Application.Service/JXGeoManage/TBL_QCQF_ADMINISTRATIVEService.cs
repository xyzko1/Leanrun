using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using Infoearth.Util;
using System;
using System.Data;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:15
    /// 描 述：群测群防行政管理体系
    /// </summary>
    public class TBL_QCQF_ADMINISTRATIVEService : RepositoryFactory<TBL_QCQF_ADMINISTRATIVEEntity>, TBL_QCQF_ADMINISTRATIVEIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>

        public IEnumerable<TBL_QCQF_ADMINISTRATIVEEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);
        }
        System.Linq.Expressions.Expression<Func<TBL_QCQF_ADMINISTRATIVEEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_ADMINISTRATIVEEntity>();
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                var expression1 = LinqExtensions.False<TBL_QCQF_ADMINISTRATIVEEntity>();
                //关键字
                string txt_Key = json.txt_Key;
                if (!string.IsNullOrEmpty(txt_Key))
                {
                    expression = expression.And(t => t.DEPTNAME.Contains(txt_Key) || t.TELPHONE == txt_Key || t.NAME.Contains(txt_Key));
                }

                //省名称
                string PROVINCENAME = json.PROVINCENAME;
                if (!string.IsNullOrEmpty(PROVINCENAME))
                {
                    expression = expression.And(t => t.PROVINCENAME.Contains(PROVINCENAME));
                }

                string CITYNAME = json.CITYNAME;
                if (!string.IsNullOrEmpty(CITYNAME))
                {
                    expression = expression.And(t => CITYNAME.Contains(t.CITYNAME));
                }
                string COUNTYNAME = json.COUNTYNAME;
                if (!string.IsNullOrEmpty(COUNTYNAME))
                {
                    expression = expression.And(t => t.COUNTYNAME.Contains(COUNTYNAME));
                }
                string TOWNNAME = json.TOWNNAME;
                if (!string.IsNullOrEmpty(TOWNNAME))
                {
                    expression = expression.And(t => t.TOWNNAME.Equals(TOWNNAME));
                }
                string PHONE = json.PHONE;
                if (!string.IsNullOrEmpty(PHONE))
                {
                    expression = expression.And(t => t.PHONE.Equals(PHONE));
                }

                string NAME = json.NAME;
                if (!string.IsNullOrEmpty(NAME))
                {
                    expression = expression.And(t => t.NAME.Contains(NAME));
                }

                string TELPHONE = json.TELPHONE;
                if (!string.IsNullOrEmpty(TELPHONE))
                {
                    expression = expression.And(t => t.TELPHONE.Equals(TELPHONE));
                }
                //行政区划账号权限筛选
                string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
                SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
                //筛选，获取授权的行政区划
                List<string> author = ws.GetAllAuthDistricts();
                if (author != null && author.Count > 0)
                {
                    var expression2 = LinqExtensions.False<TBL_QCQF_ADMINISTRATIVEEntity>();
                    bool flag = false;
                    if (!author.Contains("000000"))
                    {
                        expression2 = expression2.Or(testc => author.Contains(testc.DISTRICTCODE.Substring(0, 6)));
                        flag = true;
                    }
                    if (flag)
                    {
                        expression = expression.And(expression2);
                    }
                }
            }
            return expression;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_ADMINISTRATIVEEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_ADMINISTRATIVEEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_ADMINISTRATIVEEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        public TBL_QCQF_ADMINISTRATIVEEntity GetTBL_QCQF_ADMINISTRATIVEEntity(string DISTRICTCODE)
        {
            var expression = LinqExtensions.True<TBL_QCQF_ADMINISTRATIVEEntity>();
            if (DISTRICTCODE != "")
            {
                expression = expression.And(t => t.DISTRICTCODE.Trim().Equals(DISTRICTCODE));
            }
            TBL_QCQF_ADMINISTRATIVEEntity entity = this.BaseRepository().FindList(expression).FirstOrDefault();
            return entity;
        }
        /// <summary>
        /// 根据DISTRICTCODE获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_AMINISTRATIVELXR GetDISTRICTCODEEntity(string DISTRICTCODE)
        {
            var expression = LinqExtensions.True<TBL_QCQF_ADMINISTRATIVEEntity>();
            if (DISTRICTCODE != "")
            {
                expression = expression.And(t => t.DISTRICTCODE.Trim().Equals(DISTRICTCODE));
            }
            TBL_QCQF_ADMINISTRATIVEEntity entity = this.BaseRepository().FindList(expression).FirstOrDefault();
            if (entity == null)
                return null;
            TBL_QCQF_AMINISTRATIVELXR entity2 = new TBL_QCQF_AMINISTRATIVELXR();
            entity2.GUID = entity.GUID;
            entity2.PROVINCENAME = entity.PROVINCENAME;
            entity2.CITYNAME = entity.CITYNAME;
            entity2.COUNTYNAME = entity.COUNTYNAME;
            entity2.TOWNNAME = entity.TOWNNAME;
            entity2.VILLAGENAME = entity.VILLAGENAME;
            entity2.DISTRICTCODE = entity.DISTRICTCODE;
            entity2.CONTACTPEOPLEID = entity.CONTACTPEOPLEID;
            entity2.CONTACTDEPTID = entity.CONTACTDEPTID;
            entity2.LATITUDE = entity.LATITUDE;
            entity2.LONGITUDE = entity.LONGITUDE;
            if (entity.CONTACTPEOPLEID != "" & entity.CONTACTPEOPLEID != null)
                entity2.UsreInfo = ssoWS.GetUserFetchByID(entity.CONTACTPEOPLEID);
            return entity2;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TBL_QCQF_ADMINISTRATIVEEntity entity)
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
        /// <summary>
        /// 根据DISTRICTCODE保存表单（新增、修改）
        /// </summary>
        /// <param name="DISTRICTCODE"></param>
        /// <param name="entity"></param>
        public void UpdateForm(string DISTRICTCODE, TBL_QCQF_ADMINISTRATIVEEntity entity)
        {
            var expression = LinqExtensions.True<TBL_QCQF_ADMINISTRATIVEEntity>();
            if (!string.IsNullOrEmpty(entity.DISTRICTCODE))
            {
                expression = expression.And(t => t.DISTRICTCODE.Equals(DISTRICTCODE));
                List<TBL_QCQF_ADMINISTRATIVEEntity> entitys = this.BaseRepository().FindList(expression).ToList();
                if (entitys.Count() > 0)
                {
                    entity.GUID = entitys.FirstOrDefault().GUID;
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }

            }
        }
        public object PdState(string id)
        {
            var qcqfState = "0"; var bqbrState = "0"; var zlgcState = "0"; var lsState = "0"; var states = new object();
            string qcqfsql = ""; DataTable qcqf = new DataTable();
            string bqbrsql = ""; DataTable bqbr = new DataTable();
            string zlgcsql = ""; DataTable zlgc = new DataTable();
            string lssql = ""; DataTable ls = new DataTable();
            if (!String.IsNullOrWhiteSpace(id))
            {
                qcqfsql = "SELECT * from TBL_QCQF_DISASTERPREVENTION where UNIFIEDCODE='" + id + "'";
                lssql = "select * from TBL_HAZARDBASICINFO_HISTORY where UNIFIEDCODE='" + id + "' ";
                bqbrsql = "SELECT * from TBL_BQBR where UNIFIEDCODE='" + id + "'";
                zlgcsql = "SELECT * from TBL_ZLGC_BASEINFO where UNIFIEDCODE='" + id + "'";
            }
            qcqf = this.BaseRepository().FindTable(qcqfsql);
            bqbr = this.BaseRepository().FindTable(bqbrsql);
            zlgc = this.BaseRepository().FindTable(zlgcsql);
            ls = this.BaseRepository().FindTable(lssql);
            if (qcqf.Rows.Count > 0)
            {
                qcqfState = "1";
            }
            if (bqbr.Rows.Count > 0)
            {
                bqbrState = "1";
            }
            if (zlgc.Rows.Count > 0)
            {
                zlgcState = "1";
            }
            if (ls.Rows.Count > 0)
            {
                lsState = "1";
            }
            state1s ts = new state1s();
            ts.qcqfState = qcqfState;
            ts.bqbrState = bqbrState;
            ts.zlgcState = zlgcState;
            ts.lsState = lsState;
            return ts;
        }
        public class state1s
        {
            public string qcqfState { get; set; }
            public string bqbrState { get; set; }
            public string zlgcState { get; set; }
            public string lsState { get; set; }
        }
        #endregion
    }
}
