﻿using Infoearth.Application.Entity.SystemManage;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Infoearth.Application.IService.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.18 11:02
    /// 描 述：数据库连接管理
    /// </summary>
    public interface IDataBaseLinkService
    {
        #region 获取数据
        /// <summary>
        /// 库连接列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<DataBaseLinkEntity> GetList();
        /// <summary>
        /// 库连接实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        DataBaseLinkEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除库连接
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存库连接表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="databaseLinkEntity">库连接实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, DataBaseLinkEntity databaseLinkEntity);
         /// <summary>
        /// 测试连接字符串是否成功
        /// </summary>
        /// <param name="databaseLinkEntity"></param>
        void TestConnection(DataBaseLinkEntity databaseLinkEntity);
        #endregion

        #region 扩展方法
        /// <summary>
        /// 根据数据库ID执行sql语句
        /// </summary>
        /// <param name="dbId"></param>
        /// <param name="sql"></param>
        void ExecuteBySql(string dbId, string sql);
        /// <summary>
        /// 根据数据库ID执行sql语句
        /// </summary>
        /// <param name="dbId"></param>
        /// <param name="sql"></param>
        /// <param name="dbParameter"></param>
        void ExecuteBySql(string dbId, string sql, params DbParameter[] dbParameter);
        /// <summary>
        /// 根据数据库ID执行sql语句,查询数据->datatable
        /// </summary>
        /// <param name="dbId"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataTable FindTable(string dbId, string sql);
        /// <summary>
        /// 根据数据库ID执行sql语句,查询数据->datatable
        /// </summary>
        /// <param name="dbId"></param>
        /// <param name="sql"></param>
        /// <param name="dbParameter"></param>
        /// <returns></returns>
        DataTable FindTable(string dbId, string sql, params DbParameter[] dbParameter);
        #endregion
    }
}
