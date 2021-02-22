﻿using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.IService.SystemManage;
using Infoearth.Application.Service.SystemManage;
using Infoearth.Data;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;

namespace Infoearth.Application.Busines.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.18 11:02
    /// 描 述：数据库管理
    /// </summary>
    public class DataBaseTableBLL
    {
        private IDataBaseTableService service;
        public DataBaseTableBLL(string dataBaseLinkId)
        {
            DataBaseLinkEntity dataBaseLinkEntity = new DataBaseLinkBLL().GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                switch (dataBaseLinkEntity.F_DbType)
                {
                    case "SqlServer":
                        service = new DataBaseTableService();
                        break;
                    case "Oracle":
                        service = new DataBaseTableService_O();
                        break;
                    case "MySql":
                        service = new DataBaseTableService_M();
                        break;
                    default:
                        service = new DataBaseTableService();
                        break;
                }
            }
            else
            {
                switch (DbHelper.DbType)
                {
                    case DatabaseType.SqlServer:
                        service = new DataBaseTableService();
                        break;
                    case DatabaseType.Oracle:
                        service = new DataBaseTableService_O();
                        break;
                    case DatabaseType.MySql:
                        service = new DataBaseTableService_M();
                        break;
                    default:
                        service = new DataBaseTableService();
                        break;
                }
            }
        }
        #region 获取数据
        /// <summary>
        /// 数据表列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        public DataTable GetTableList(string dataBaseLinkId, string tableName)
        {
            return service.GetTableList(dataBaseLinkId, tableName);
        }

        /// <summary>
        /// 数据视图列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        public DataTable GetViewList(string dataBaseLinkId, string tableName)
        {
            return service.GetViewList(dataBaseLinkId, tableName);
        }
        /// <summary>
        /// 数据表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">数据库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        public IEnumerable<DataBaseTableFieldEntity> GetTableFiledList(string dataBaseLinkId, string tableName = "")
        {
            return service.GetTableFiledList(dataBaseLinkId, tableName);
        }
        /// <summary>
        /// 数据库表数据列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接</param>
        /// <param name="tableName">表明</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public DataTable GetTableDataList(string dataBaseLinkId, string tableName, string switchWhere, string logic, string keyword, Pagination pagination)
        {
            return service.GetTableDataList(dataBaseLinkId, tableName, switchWhere, logic, keyword, pagination);
        }
        /// <summary>
        /// 数据库表数据列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接</param>
        /// <param name="tableName">表明</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        ///  <param name="condition">并集、或集</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public DataTable GetTableDataListNew(string dataBaseLinkId, string tableName, string[] switchWhere, string[] logic, string[] keyword, string[] condition, Pagination pagination)
        {
            return service.GetTableDataListNew(dataBaseLinkId, tableName, switchWhere, logic, keyword, condition, pagination);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存数据库表表单（新增、修改）
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDescription">表说明</param>
        /// <param name="fieldListJson">字段列表Json</param>
        public void SaveForm(string dataBaseLinkId, string tableName, string tableDescription, string fieldListJson)
        {
            try
            {
                IEnumerable<DataBaseTableFieldEntity> fieldList = fieldListJson.ToList<DataBaseTableFieldEntity>();
                service.SaveForm(dataBaseLinkId, tableName, tableDescription, fieldList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
