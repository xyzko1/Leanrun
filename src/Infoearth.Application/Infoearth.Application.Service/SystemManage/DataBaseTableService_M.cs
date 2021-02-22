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
    public class DataBaseTableService_M : RepositoryFactory, IDataBaseTableService
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
            strSql.Append(@"SELECT t1.*,
                                (select COLUMN_NAME from information_schema.`COLUMNS` where TABLE_SCHEMA=database() and  TABLE_NAME =t1.f_name and COLUMN_KEY='PRI') f_pk
                                 from (
                                SELECT TABLE_NAME f_name,0 f_reserved,0 f_data,0 f_index_size,TABLE_ROWS f_sumrows,0 f_unused, (select IF(LENGTH(TRIM(TABLE_COMMENT))<1,TABLE_NAME,TABLE_COMMENT)) f_tdescription
                                from information_schema.`TABLES` where TABLE_SCHEMA =database()
                                ) t1 where  1 = 1
                                 ");
            if (!string.IsNullOrEmpty(tableName))
            {
                strSql.Append(" AND t1.f_name='" + tableName + "'");
            }
            strSql.Append(" ORDER BY t1.f_name");
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            DataTable result = null;
            if (dataBaseLinkEntity != null)
            {
                result= this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.MySql).FindTable(strSql.ToString());
            }
            else
            {
                result= this.BaseRepository().FindTable(strSql.ToString());
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
            string sql = "select TABLE_NAME from  information_schema.`views` where TABLE_SCHEMA =database();";
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
            strSql.Append(@"select  ORDINAL_POSITION f_number, COLUMN_NAME f_column, DATA_TYPE f_datatype, if(CHARACTER_MAXIMUM_LENGTH is null,if(LOCATE('int',column_type)>0,REPLACE(REPLACE(column_type,'int(',''),')',''),0),CHARACTER_MAXIMUM_LENGTH) f_length, '' f_identity, IF(COLUMN_KEY='PRI','1','') f_key,
                                        IF(IS_NULLABLE='YES','1','') f_isnullable,COLUMN_DEFAULT f_default,case when COLUMN_COMMENT='' then COLUMN_NAME else COLUMN_COMMENT END    f_remark,NUMERIC_PRECISION f_precision,NUMERIC_SCALE f_scale  from (
                                        select  *
                                         from information_schema.`COLUMNS` t1 where TABLE_SCHEMA=database() and TABLE_NAME = @tableName 
                                        ) t2 order by f_number
                                ");
            DbParameter[] parameter = 
                {
                    DbParameters.CreateDbParameter("@tableName",tableName)
                };
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                return this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.MySql).FindList<DataBaseTableFieldEntity>(strSql.ToString(), parameter);
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
                return this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.MySql).FindTable(strSql.ToString(), parameter.ToArray(), pagination);
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
                return this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.MySql).FindTable(strSql.ToString(), parameter.ToArray(), pagination);
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
