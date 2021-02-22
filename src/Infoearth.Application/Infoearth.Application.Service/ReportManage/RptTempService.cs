﻿using Infoearth.Application.Entity.ReportManage;
using Infoearth.Application.IService.ReportManage;
using Infoearth.Data;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Infoearth.Util;
using Infoearth.Application.Entity.AuthorizeManage;

namespace Infoearth.Application.Service.ReportManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2016.1.14 14:27
    /// 描 述：报表模板管理
    /// </summary>
    public class RptTempService : RepositoryFactory<RptTempEntity>, IRptTempService
    {
        #region 获取数据
        /// <summary>
        /// 报表模板列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RptTempEntity> GetList(string queryJson)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  r.F_TempId,
                                    r.F_EnCode ,
                                    r.F_FullName ,
                                    CASE r.F_TempType
                                      WHEN 'line' THEN '折线图'
                                      WHEN 'bar' THEN '柱形图'
                                      WHEN 'map' THEN '地图'
                                      WHEN 'pie' THEN '饼图'
                                    END AS F_TempType ,
                                    r.F_TempCategory ,
                                    r.F_Description ,
                                    r.F_CreateDate
                            FROM    Rpt_Temp r
                            WHERE   1 = 1 ");
            var parameter = new List<DbParameter>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "EnCode":            //角色编号
                        strSql.Append(" AND r.F_EnCode LIKE @keyword ");
                        parameter.Add(DbParameters.CreateDbParameter("@keyword", '%' + keyword + '%'));
                        break;
                    case "FullName":          //角色名称
                        strSql.Append(" AND r.F_FullName LIKE @keyword ");
                        parameter.Add(DbParameters.CreateDbParameter("@keyword", '%' + keyword + '%'));
                        break;
                    default:
                        break;
                }
            }
            if (!queryParam["reportCode"].IsEmpty())
            {
                strSql.Append(" AND r.F_TempCategory = @TempCategory ");
                parameter.Add(DbParameters.CreateDbParameter("@TempCategory", queryParam["reportCode"].ToString()));
            }
            return this.BaseRepository().FindList(strSql.ToString(), parameter.ToArray()).ToList();
        }
        /// <summary>
        /// 报表模板实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RptTempEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        /// <summary>
        /// 获得报表数据
        /// </summary>
        /// <param name="reportId">主键值</param>
        /// <returns></returns>
        public string GetReportData(string reportId)
        {
            RptTempEntity rpttempentity = this.BaseRepository().FindEntity(reportId);
            if (rpttempentity.F_ParamJson != null)
            {
                dynamic paramJson = rpttempentity.F_ParamJson.ToJson();
                string strSql = paramJson.sqlString;
                string strListSql = paramJson.listSqlString;
                string picTitle = paramJson.title;
                string title = rpttempentity.F_FullName;
                string tempType = rpttempentity.F_TempType;
                List<FieldList> listField = new List<FieldList>();
                DataTable picData = new DataTable();
                if (!string.IsNullOrEmpty(strSql))
                {
                    picData = this.BaseRepository().FindTable(strSql);
                }
                DataTable listData = new DataTable();
                if (!string.IsNullOrEmpty(strListSql))
                {
                    listData = this.BaseRepository().FindTable(strListSql);
                    if (listData.Columns.Count > 0)
                    {
                        for (int i = 0; i < listData.Columns.Count; i++)
                        {
                            listField.Add(new FieldList() { Field = listData.Columns[i].ColumnName });
                        }
                    }
                }
                var jsonData = new
                {
                    title = title,
                    tempType = tempType,
                    listField = listField,
                    picTitle = picTitle,
                    picData = picData,
                    listData = listData
                };
                return jsonData.ToJson();
            }
            return null;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除报表模板
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存报表模板表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="rptTempEntity">报表实体</param>
        /// <param name="moduleEntity">模块实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, RptTempEntity rptTempEntity, ModuleEntity moduleEntity)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    rptTempEntity.Modify(keyValue);
                    db.Update(rptTempEntity);
                }
                else
                {
                    rptTempEntity.Create();
                    db.Insert(rptTempEntity);
                    if (moduleEntity.F_ModuleId != null)
                    {
                        moduleEntity.F_UrlAddress = " /ReportManage/Report/ReportPreview?keyValue=" + rptTempEntity.F_TempId;
                        db.Insert(moduleEntity);
                    }
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
    class FieldList
    {
        public string Field { get; set; }
    }
}
