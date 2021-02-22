using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Infoearth.Util;
using Infoearth.Util.Extension;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 15:53
    /// 描 述：解译工程项目基本信息表
    /// </summary>
    public class JYGC_PROJECTBASEINFOService : RepositoryFactory<JYGC_PROJECTBASEINFOEntity>, JYGC_PROJECTBASEINFOIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<JYGC_PROJECTBASEINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return this.BaseRepository().FindList(pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<JYGC_PROJECTBASEINFOEntity> GetList(string queryJson)
        {
            var experssion = LinqExtensions.True<JYGC_PROJECTBASEINFOEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                dynamic json = JToken.Parse(queryJson) as dynamic;
                string txt_Keyword = json.txt_Keyword;
                if (!string.IsNullOrEmpty(txt_Keyword))
                {
                    experssion = experssion.And(t => t.PROJECTNAME.Contains(txt_Keyword));
                }
            }
            return this.BaseRepository().FindList(experssion);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public JYGC_PROJECTBASEINFOEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        /// <summary>
        /// 获取或者创建一个项目ID
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public JYGC_PROJECTBASEINFOEntity GetOrCreateProjectId(string projectName)
        {
            var experssion = LinqExtensions.True<JYGC_PROJECTBASEINFOEntity>();
            if (!string.IsNullOrEmpty(projectName))
            {
                experssion = experssion.And(t => t.PROJECTNAME.Equals(projectName));
            }
            else
            {
                return null;
            }
            var tempResult = this.BaseRepository().FindList(experssion);
            if (tempResult != null && tempResult.Count() > 0)
            {
                return tempResult.FirstOrDefault();
            }
            else
            {
                //创建ProjectId
                JYGC_PROJECTBASEINFOEntity entity = new JYGC_PROJECTBASEINFOEntity()
                {
                    PROJECTGUID = Guid.NewGuid().ToString(),
                    PROJECTCODE = "1",
                    PROJECTTYPE = "详查",
                    PROJECTNAME = projectName,
                    TIMECREATED = DateTime.Now,
                    USERCREATED = "管理员",
                    USERMODIFIED = "管理员"
                };
                entity.Create();
                this.BaseRepository().Insert(entity);
                return entity;
            }
        }

        public List<string> GetProjectIDList(string queryJson)
        {
            List<string> list = new List<string>();
            var result = new DataTable();
            if (!string.IsNullOrEmpty(queryJson))
            {
                dynamic json = JToken.Parse(queryJson) as dynamic;
                string PROJECTTYPE = json.PROJECTTYPE;

                //                string sql = @"select * from 
                //(select * from JYGC_PROJECTBASEINFO t order by t.YEAR desc) tb where 1=1 and tb.PROJECTTYPE = '" + PROJECTTYPE + "'";
                string sql = @"select * from 
(select * from JYGC_PROJECTBASEINFO t order by t.PROJECTCODE desc) tb where 1=1 and tb.PROJECTTYPE = '" + PROJECTTYPE + "'";
                result = this.BaseRepository().FindTable(sql);
                if (result.Rows.Count > 0)
                {
                    for (int i = 0; i < result.Rows.Count; i++)
                    {
                        list.Add(result.Rows[i][0].ToString());
                    }
                }

            }

            return list;
        }
        public List<JYGC_PROJECTBASEINFOEntity> GetListByDateDiff(string queryJson)
        {
            List<JYGC_PROJECTBASEINFOEntity> returnValue = new List<JYGC_PROJECTBASEINFOEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["endYear"].IsEmpty())
            {
                int endYear = queryParam["endYear"].ToInt();
                JYGC_PROJECTBASEINFOEntity entity = this.BaseRepository().FindList(p => p.YEAR <= endYear).OrderByDescending(p => p.YEAR).FirstOrDefault();
                returnValue.Add(entity);
            }
            if (!queryParam["startYear"].IsEmpty())
            {
                int startYear = queryParam["startYear"].ToInt();
                JYGC_PROJECTBASEINFOEntity entity = this.BaseRepository().FindList(p => p.YEAR >= startYear).OrderByDescending(p => p.YEAR).FirstOrDefault();
                if (entity != null)
                {
                    if (!returnValue.Select(p => p.PROJECTGUID).Contains(entity.PROJECTGUID))
                    {
                        returnValue.Add(entity);
                    }
                }

            }
            return returnValue;
        }
        #endregion
        /// <summary>
        /// 根据查询年度获取最近一次的调查项目、排查项目
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public string GetTCYearProject(string queryJson)
        {
            var result = new DataTable();
            string value = "";
            string sqlStr = "";
            if (!string.IsNullOrEmpty(queryJson))
            {
                dynamic json = JToken.Parse(queryJson) as dynamic;
                string YEAR = json.YEAR;
                string PROJECTTYPE = json.PROJECTTYPE;
                if (!string.IsNullOrEmpty(YEAR))
                {
                    sqlStr += " and  tb.YEAR <= '" + YEAR + "'";
                }
                if (!string.IsNullOrEmpty(PROJECTTYPE))
                {
                    sqlStr += "and tb.PROJECTTYPE = '" + PROJECTTYPE + "'";
                }
                string sql = @"select * from 
(select * from JYGC_PROJECTBASEINFO t order by t.YEAR desc) tb where 1=1 " + sqlStr + "  and rownum < 2";
                result = this.BaseRepository().FindTable(sql);
                if (result.Rows.Count > 0)
                {
                    value = result.Rows[0][0].ToString();
                }

            }
            return value;
        }
        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void DeleteEntity(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, JYGC_PROJECTBASEINFOEntity entity)
        {
            UserInfo userInfo = ssoWS.GetUserInfo();
            string userName = userInfo.F_Account;
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                entity.TIMEMODIFIED = DateTime.Now;
                entity.USERMODIFIED = userName;
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                entity.TIMECREATED = DateTime.Now;
                entity.USERCREATED = userName;
                this.BaseRepository().Insert(entity);
            }
        }

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
        public void SaveForm(string keyValue, JYGC_PROJECTBASEINFOEntity entity)
        {
            UserInfo userInfo = ssoWS.GetUserInfo();
            string userName = userInfo.F_Account;
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                entity.TIMEMODIFIED = DateTime.Now;
                entity.USERMODIFIED = userName;
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                entity.TIMECREATED = DateTime.Now;
                entity.USERCREATED = userName;
                entity.USERMODIFIED = userName;
                entity.TIMEMODIFIED = DateTime.Now;
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
