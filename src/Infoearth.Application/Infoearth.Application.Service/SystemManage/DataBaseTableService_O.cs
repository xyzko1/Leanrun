using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.IService.SystemManage;
using Infoearth.Data;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Infoearth.Application.Service.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.18 11:02
    /// 描 述：数据库管理（支持：SqlServer）
    /// </summary>
    public class DataBaseTableService_O : RepositoryFactory, IDataBaseTableService
    {
        private IDataBaseLinkService dataBaseLinkService = new DataBaseLinkService();

        #region 获取数据
        /// <summary>
        /// 数据表列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        public DataTable GetTableList(string dataBaseLinkId, string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select distinct col.table_name f_name,
                                                0 f_reserved,
                                                0 f_fdata,
                                                0 f_index_size,
                                                nvl(t.num_rows, 0) f_sumrows,
                                                0 f_funused,
                                                tab.comments f_tdescription,
                                                column_name f_pk
                                  from user_cons_columns col
                                 inner join user_constraints con
                                    on con.constraint_name = col.constraint_name
                                 inner join user_tab_comments tab
                                    on tab.table_name = col.table_name
                                 inner join user_tables t
                                    on t.TABLE_NAME = col.table_name
                                 where con.constraint_type not in ('C', 'R') ");
            if (!string.IsNullOrEmpty(tableName))
            {
                strSql.Append(" AND col.table_name='" + tableName + "'");
            }
            strSql.Append(" ORDER BY col.table_name");
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            string sql = "select VIEW_NAME from User_Views";
            DataTable result = null;
            DataTable tmp = null; 
            if (dataBaseLinkEntity != null)
            {
                result= this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.Oracle).FindTable(strSql.ToString());
                tmp = this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.Oracle).FindTable(sql);
            }
            else
            {
                result= this.BaseRepository().FindTable(strSql.ToString());
                tmp = this.BaseRepository().FindTable(sql);
            }
            if (tmp != null && tmp.Rows.Count > 0)
            {
                foreach (DataRow item in tmp.Rows)
                {
                    result.Rows.Add(item.ItemArray[0], 0, 0, 0, 0, 0, "VIEW", "PK");
                }
            }
            return result;
        }

        /// <summary>
        /// 数据视图列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        public DataTable GetViewList(string dataBaseLinkId, string tableName)
        {
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            string sql = "select VIEW_NAME from User_Views;";
            DataTable result = null;
            DataTable tmp = null;
            if (dataBaseLinkEntity != null)
            {
                tmp = this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.SqlServer).FindTable(sql);
            }
            else
            {
                tmp = this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.SqlServer).FindTable(sql);
            }
            if (tmp != null && tmp.Rows.Count > 0)
            {
                result = new DataTable();
                DataColumn c1 = new DataColumn("f_name");
                result.Columns.Add(c1);
                DataColumn c2 = new DataColumn("f_reserved");
                result.Columns.Add(c2);
                DataColumn c3 = new DataColumn("f_data");
                result.Columns.Add(c3);
                DataColumn c4 = new DataColumn("f_index_size");
                result.Columns.Add(c4);
                DataColumn c5 = new DataColumn("f_sumrows");
                result.Columns.Add(c5);
                DataColumn c6 = new DataColumn("f_unused");
                result.Columns.Add(c6);
                DataColumn c7 = new DataColumn("f_tdescription");
                result.Columns.Add(c7);
                DataColumn c8 = new DataColumn("f_pk");
                result.Columns.Add(c8);
                foreach (DataRow item in tmp.Rows)
                {
                    result.Rows.Add(item.ItemArray[0], "0KB", "0KB", "0KB", 0, "0KB", "VIEW", "PK");
                }
            }

            return result;
        }

        /// <summary>
        /// 数据表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        public IEnumerable<DataBaseTableFieldEntity> GetTableFiledList(string dataBaseLinkId, string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select col.column_id  f_number,
                                       col.column_name f_column,
                                       col.data_type f_datatype,
                                       col.data_length  f_length,
                                       null f_identity,
                                       case uc.constraint_type when 'P' then 1 else null end f_key,
                                       case col.nullable when 'N' then 0 else 1 end   f_isnullable,
                                       col.data_default f_defaults,
                                       comm.comments as f_remark,
                                       col.DATA_PRECISION  f_precision,
                                       col.DATA_SCALE  f_scale
                                  from user_tab_columns col
                                   inner join user_col_comments comm
                                   on comm.TABLE_NAME = col.TABLE_NAME 
                                   and comm.COLUMN_NAME = col.COLUMN_NAME
                                  left join user_cons_columns ucc
                                    on ucc.table_name = col.table_name
                                   and ucc.column_name = col.column_name 
                                   and ucc.position=1
                                  left join user_constraints uc
                                    on uc.constraint_name = ucc.constraint_name
                                   and uc.constraint_type = 'P'
                                 where col.table_name = :tableName
                                order by col.column_id");
            DbParameter[] parameter = 
                {
                    DbParameters.CreateDbParameter(":tableName",tableName)
                };
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                return this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.Oracle).FindList<DataBaseTableFieldEntity>(strSql.ToString(), parameter);
            }
            else
            {
                return this.BaseRepository().FindList<DataBaseTableFieldEntity>(strSql.ToString(), parameter);
            }
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
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM " + tableName + " WHERE 1=1");
            if (!string.IsNullOrEmpty(keyword))
            {
                strSql.Append(" AND " + switchWhere + "");
                switch (logic)
                {
                    case "Equal":           //等于
                        strSql.Append(" = ");
                        parameter.Add(DbParameters.CreateDbParameter(":" + switchWhere, keyword));
                        break;
                    case "NotEqual":        //不等于
                        strSql.Append(" <> ");
                        parameter.Add(DbParameters.CreateDbParameter(":" + switchWhere, keyword));
                        break;
                    case "Greater":         //大于
                        strSql.Append(" > ");
                        parameter.Add(DbParameters.CreateDbParameter(":" + switchWhere, keyword));
                        break;
                    case "GreaterThan":     //大于等于
                        strSql.Append(" >= ");
                        parameter.Add(DbParameters.CreateDbParameter(":" + switchWhere, keyword));
                        break;
                    case "Less":            //小于
                        strSql.Append(" < ");
                        parameter.Add(DbParameters.CreateDbParameter(":" + switchWhere, keyword));
                        break;
                    case "LessThan":        //小于等于
                        strSql.Append(" >= ");
                        parameter.Add(DbParameters.CreateDbParameter(":" + switchWhere, keyword));
                        break;
                    case "Null":            //为空
                        strSql.Append(" is null ");
                        parameter.Add(DbParameters.CreateDbParameter(":" + switchWhere, keyword));
                        break;
                    case "NotNull":         //不为空
                        strSql.Append(" is not null ");
                        parameter.Add(DbParameters.CreateDbParameter(":" + switchWhere, keyword));
                        break;
                    case "Like":            //包含
                        strSql.Append(" like ");
                        parameter.Add(DbParameters.CreateDbParameter(":" + switchWhere, '%' + keyword + '%'));
                        break;
                    default:
                        break;
                }
                strSql.Append(":" + switchWhere + "");
            }
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                return this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.Oracle).FindTable(strSql.ToString(), parameter.ToArray(), pagination);
            }
            else
            {
                return this.BaseRepository().FindTable(strSql.ToString(), parameter.ToArray(), pagination);
            }
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
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM " + tableName + " WHERE 1=1");
            for (int i = 0; i < keyword.Length; i++)
            {
                if (!string.IsNullOrEmpty(keyword[i]))
                {

                    if (i == 0)
                    {
                        strSql.Append(" AND " + switchWhere[i] + "");
                    }
                    else
                    {
                        strSql.Append(" " + condition[i] + " " + switchWhere[i] + "");
                    }
                    switch (logic[i])
                    {
                        case "Equal":           //等于
                            strSql.Append(" = ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere[i], keyword[i]));
                            break;
                        case "NotEqual":        //不等于
                            strSql.Append(" <> ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere[i], keyword[i]));
                            break;
                        case "Greater":         //大于
                            strSql.Append(" > ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere[i], keyword[i]));
                            break;
                        case "GreaterThan":     //大于等于
                            strSql.Append(" >= ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere[i], keyword[i]));
                            break;
                        case "Less":            //小于
                            strSql.Append(" < ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere[i], keyword[i]));
                            break;
                        case "LessThan":        //小于等于
                            strSql.Append(" >= ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere[i], keyword[i]));
                            break;
                        case "Null":            //为空
                            strSql.Append(" is null ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere[i], keyword[i]));
                            break;
                        case "NotNull":         //不为空
                            strSql.Append(" is not null ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere[i], keyword[i]));
                            break;
                        case "Like":            //包含
                            strSql.Append(" like ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere[i], '%' + keyword[i] + '%'));
                            break;
                        default:
                            break;
                    }
                    strSql.Append("@" + switchWhere[i] + "");
                }
            }
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                return this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.Oracle).FindTable(strSql.ToString(), parameter.ToArray(), pagination);
            }
            else
            {
                return this.BaseRepository().FindTable(strSql.ToString(), parameter.ToArray(), pagination);
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存数据库表表单（新增、修改）
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDescription">表说明</param>
        /// <param name="fieldList">字段列表</param>
        public void SaveForm(string dataBaseLinkId, string tableName, string tableDescription, IEnumerable<DataBaseTableFieldEntity> fieldList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("declare num   number; ");
            strSql.Append(" begin ");
            strSql.Append(" select count(1) into num from user_tables where TABLE_NAME = 'EMP' ;");
            strSql.Append(" if   num=1   then ");
            strSql.Append("   drop table " + tableName + "");
            strSql.Append("end if;");
            strSql.Append("end;");
            strSql.Append("create table " + tableName + " (");


            strSql.Append("   LogId                varchar(50)        not null,");
            strSql.Append("   SourceObjectId       varchar(50)        null,");
            strSql.Append("   SourceContentJson    text               null,");
            strSql.Append("   IPAddress            varchar(50)        null,");
            strSql.Append("   IPAddressName        varchar(200)       null,");
            strSql.Append("   Category             int                null,");



            strSql.Append("   constraint PK_BASE_LOG primary key nonclustered (LogId)");
            strSql.Append(")");
            strSql.Append("go");
        }
        #endregion
    }
}