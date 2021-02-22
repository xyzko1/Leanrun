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
    public class DataBaseTableService : RepositoryFactory, IDataBaseTableService
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
            strSql.Append(@"DECLARE @TableInfo TABLE ( name VARCHAR(50) , sumrows VARCHAR(11) , reserved VARCHAR(50) , data VARCHAR(50) , index_size VARCHAR(50) , unused VARCHAR(50) , pk VARCHAR(50) )
                            DECLARE @TableName TABLE ( name VARCHAR(50) )
                            DECLARE @name VARCHAR(50)
                            DECLARE @pk VARCHAR(50)
                            INSERT INTO @TableName ( name ) SELECT o.name FROM sysobjects o , sysindexes i WHERE o.id = i.id AND o.Xtype = 'U' AND i.indid < 2 ORDER BY i.rows DESC , o.name
                            WHILE EXISTS ( SELECT 1 FROM @TableName ) BEGIN SELECT TOP 1 @name = name FROM @TableName DELETE @TableName WHERE name = @name DECLARE @objectid INT SET @objectid = OBJECT_ID(@name) SELECT @pk = COL_NAME(@objectid, colid) FROM sysobjects AS o INNER JOIN sysindexes AS i ON i.name = o.name INNER JOIN sysindexkeys AS k ON k.indid = i.indid WHERE o.xtype = 'PK' AND parent_obj = @objectid AND k.id = @objectid INSERT INTO @TableInfo ( name , sumrows , reserved , data , index_size , unused ) EXEC sys.sp_spaceused @name UPDATE @TableInfo SET pk = @pk WHERE name = @name END
                            SELECT F.name as f_name, F.reserved  as f_reserved, F.data   as f_data, F.index_size   as f_index_size, RTRIM(F.sumrows) AS f_sumrows , F.unused as f_unused, ISNULL(p.tdescription, f.name) AS f_tdescription , F.pk as f_pk
                            FROM @TableInfo F LEFT JOIN ( SELECT name = CASE WHEN A.COLORDER = 1 THEN D.NAME ELSE '' END , tdescription = CASE WHEN A.COLORDER = 1 THEN ISNULL(F.VALUE, '') ELSE '' END FROM SYSCOLUMNS A LEFT JOIN SYSTYPES B ON A.XUSERTYPE = B.XUSERTYPE INNER JOIN SYSOBJECTS D ON A.ID = D.ID AND D.XTYPE = 'U' AND D.NAME <> 'DTPROPERTIES' LEFT JOIN sys.extended_properties F ON D.ID = F.major_id WHERE a.COLORDER = 1 AND F.minor_id = 0 ) P ON F.name = p.name
                            WHERE 1 = 1 ");
            if (!string.IsNullOrEmpty(tableName))
            {
                strSql.Append(" AND f.name='" + tableName + "'");
            }
            strSql.Append(" ORDER BY f.name");
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            string sql = "select name FROM sysobjects o where o.xtype ='V';";
            DataTable result = null;
            DataTable tmp = null; 
            if (dataBaseLinkEntity != null)
            {
                result = this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.SqlServer).FindTable(strSql.ToString());
                tmp = this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.SqlServer).FindTable(sql);
            }
            else
            {
                result= this.BaseRepository().FindTable(strSql.ToString());
                tmp = this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.SqlServer).FindTable(sql);
            }
            if(tmp!=null&&tmp.Rows.Count>0)
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
            string sql = "select name FROM sysobjects o where o.xtype ='V';";
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
            strSql.Append(@"SELECT distinct a.colorder,a.id, [f_number] = a.colorder , [f_column] = a.name , [f_datatype] = b.name , [f_length] = COLUMNPROPERTY(a.id, a.name, 'PRECISION') , [f_identity] = CASE WHEN COLUMNPROPERTY(a.id, a.name, 'IsIdentity') = 1 THEN '1' ELSE '' END , [f_key] = CASE WHEN EXISTS ( SELECT 1 FROM sysobjects WHERE xtype = 'PK' AND parent_obj = a.id AND name IN ( SELECT name FROM sysindexes WHERE indid IN ( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid ) ) ) THEN '1' ELSE '' END , [f_isnullable] = CASE WHEN a.isnullable = 1 THEN '1' ELSE '' END , [f_defaults] = ISNULL(e.text, '') , [f_remark] = ISNULL(g.[value], a.name),[f_precision] = COLUMNPROPERTY(a.id, a.name, 'PRECISION'),[f_scale] = COLUMNPROPERTY(a.id, a.name, 'SCALE')
                                FROM syscolumns a LEFT JOIN systypes b ON a.xusertype = b.xusertype INNER JOIN sysobjects d ON a.id = d.id AND (d.xtype = 'U' or d.xtype = 'V') AND d.name <> 'dtproperties' LEFT JOIN syscomments e ON a.cdefault = e.id LEFT JOIN sys.extended_properties g ON a.id = g.major_id AND a.colid = g.minor_id LEFT JOIN sys.extended_properties f ON d.id = f.major_id AND f.minor_id = 0
                                WHERE d.name = @tableName
                                ORDER BY a.id , a.colorder");
            DbParameter[] parameter = 
                {
                    DbParameters.CreateDbParameter("@tableName",tableName)
                };
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                return this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.SqlServer).FindList<DataBaseTableFieldEntity>(strSql.ToString(), parameter);
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
                        parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                        break;
                    case "NotEqual":        //不等于
                        strSql.Append(" <> ");
                        parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                        break;
                    case "Greater":         //大于
                        strSql.Append(" > ");
                        parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                        break;
                    case "GreaterThan":     //大于等于
                        strSql.Append(" >= ");
                        parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                        break;
                    case "Less":            //小于
                        strSql.Append(" < ");
                        parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                        break;
                    case "LessThan":        //小于等于
                        strSql.Append(" >= ");
                        parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                        break;
                    case "Null":            //为空
                        strSql.Append(" is null ");
                        parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                        break;
                    case "NotNull":         //不为空
                        strSql.Append(" is not null ");
                        parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                        break;
                    case "Like":            //包含
                        strSql.Append(" like ");
                        parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, '%' + keyword + '%'));
                        break;
                    default:
                        break;
                }
                strSql.Append("@" + switchWhere + "");
            }
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                return this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.SqlServer).FindTable(strSql.ToString(), parameter.ToArray(), pagination);
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
                return this.BaseRepository(dataBaseLinkEntity.F_DbConnection, DatabaseType.SqlServer).FindTable(strSql.ToString(), parameter.ToArray(), pagination);
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
            strSql.Append("if exists (select 1");
            strSql.Append("            from  sysobjects");
            strSql.Append("            where  id = object_id('" + tableName + "')");
            strSql.Append("            and   type = 'U')");
            strSql.Append("   drop table " + tableName + "");
            strSql.Append("go");

            strSql.Append("/*==============================================================*/");
            strSql.Append("/* Table: " + tableName + "                                     */");
            strSql.Append("/*==============================================================*/");
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

            //declare @CurrentUser sysname
            //select @CurrentUser = user_name()
            //execute sp_addextendedproperty 'MS_Description', 
            //   '系统日志表',
            //   'user', @CurrentUser, 'table', 'Base_Log'
            //go

            //declare @CurrentUser sysname
            //select @CurrentUser = user_name()
            //execute sp_addextendedproperty 'MS_Description', 
            //   '日志主键',
            //   'user', @CurrentUser, 'table', 'Base_Log', 'column', 'LogId'
            //go
        }
        #endregion
    }
}
