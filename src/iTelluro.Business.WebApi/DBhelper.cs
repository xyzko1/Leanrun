﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Data.OracleClient;
using System.IO;
using System.Reflection;
namespace DAL
{
    public class DBhelper
    {

        #region Sqlserver
        //public string connString = ConfigurationManager.ConnectionStrings["AHBaseDb"].ConnectionString;
        private static string connString = ConfigurationManager.ConnectionStrings["AHBaseDbBySql"].ConnectionString;
        public static DataTable ExecuteSelect(string sql, params SqlParameter[] para)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, connString);
                if (da != null)
                {
                    da.SelectCommand.Parameters.AddRange(para);
                }
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //执行增、删、改的
        public static bool ExecuteNonQuery(string sql, SqlParameter[] para)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (para != null)
                        {
                            cmd.Parameters.AddRange(para);
                        }
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        int i = cmd.ExecuteNonQuery();
                        conn.Close();
                        return i > 0 ? true : false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Insert(List<string> sql)
        {
            int returnValue = 0;
            SqlConnection _conn = new SqlConnection(connString);
            try
            {
                if (_conn.State == ConnectionState.Closed)
                {
                    _conn.Open();
                }
                foreach (var item in sql)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand(item, _conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return returnValue;
        }
        #endregion
        #region Oracle
        ////数据库连接字符串
        //public  string connString2 = ConfigurationManager.ConnectionStrings["BaseDb"].ConnectionString;
        //数据库连接字符串  
        public readonly string connstr = ConfigurationManager.ConnectionStrings["AHBaseDb"].ConnectionString;
        /// <summary>  
        /// 执行数据库查询操作,返回受影响的行数  
        /// </summary>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        /// <returns>当前查询操作影响的数据行数</returns>  
        public int ExecuteNonQuery(string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(connstr);
            int result = 0;

            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return result;
        }
        public int ExecuteNonQuery(string con, string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(con);
            int result = 0;

            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return result;
        }

        /// <summary>  
        /// 执行数据库事务查询操作,返回受影响的行数  
        /// </summary>  
        /// <param name="transaction">数据库事务对象</param>  
        /// <param name="cmdType">Command类型</param>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        /// <returns>当前事务查询操作影响的数据行数</returns>  
        public int ExecuteNonQuery(OracleTransaction transaction, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = transaction.Connection;
            int result = 0;

            try
            {
                PrepareCommand(command, connection, transaction, cmdType, cmdText, commandParameters);
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                transaction.Dispose();
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return result;
        }

        /// <summary>  
        /// 执行数据库查询操作,返回受影响的行数  
        /// </summary>  
        /// <param name="connection">Oracle数据库连接对象</param>  
        /// <param name="cmdType">Command类型</param>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        /// <returns>当前查询操作影响的数据行数</returns>  
        public int ExecuteNonQuery(OracleConnection connection, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("当前数据库连接不存在");
            OracleCommand command = new OracleCommand();
            int result = 0;

            try
            {
                PrepareCommand(command, connection, null, cmdType, cmdText, commandParameters);
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return result;
        }

        /// <summary>  
        /// 执行数据库查询操作,返回OracleDataReader类型的内存结果集  
        /// </summary>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        /// <returns>当前查询操作返回的OracleDataReader类型的内存结果集</returns>  
        public OracleDataReader ExecuteReader(string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(connstr);
            OracleDataReader reader = null;

            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();
                return reader;
            }
            catch
            {
                command.Dispose();
                connection.Close();
                throw;
            }
        }

        /// <summary>  
        /// 执行数据库查询操作,返回DataSet类型的结果集  
        /// </summary>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        /// <returns>当前查询操作返回的DataSet类型的结果集</returns>  
        public DataSet ExecuteDataSet(string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(connstr);
            DataSet dataset = null;

            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = command;
                dataset = new DataSet();
                adapter.Fill(dataset);
                command.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return dataset;
        }
        public DataSet ExecuteDataSet(string con, string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(con);
            DataSet dataset = null;

            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = command;
                dataset = new DataSet();
                adapter.Fill(dataset);
                command.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return dataset;
        }
        public DataSet Query(string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(connstr))
            {
                OracleCommand cmd = new OracleCommand();
                //PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                PrepareCommand(cmd, connection, null, CommandType.Text, SQLString, cmdParms);
                using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.OracleClient.OracleException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (connection.State != ConnectionState.Closed)
                        {
                            connection.Close();
                        }
                    }
                    return ds;
                }
            }
        }
        public DataSet Query(string con, string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(con))
            {
                OracleCommand cmd = new OracleCommand();
                //PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                PrepareCommand(cmd, connection, null, CommandType.Text, SQLString, cmdParms);
                using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.OracleClient.OracleException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (connection.State != ConnectionState.Closed)
                        {
                            connection.Close();
                        }
                    }
                    return ds;
                }
            }
        }

        /// <summary>  
        /// 执行数据库查询操作,返回DataTable类型的结果集  
        /// </summary>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        /// <returns>当前查询操作返回的DataTable类型的结果集</returns>  
        public DataTable ExecuteDataTable(string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(connstr);
            DataTable table = null;

            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = command;
                table = new DataTable();
                adapter.Fill(table);
                command.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return table;
        }

        /// <summary>  
        /// 执行数据库查询操作,返回结果集中位于第一行第一列的Object类型的值  
        /// </summary>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        /// <returns>当前查询操作返回的结果集中位于第一行第一列的Object类型的值</returns>  
        public object ExecuteScalar(string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(connstr);
            object result = null;

            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                result = command.ExecuteScalar();
                command.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return result;
        }

        ///    <summary>  
        ///    执行数据库事务查询操作,返回结果集中位于第一行第一列的Object类型的值  
        ///    </summary>  
        ///    <param name="transaction">一个已存在的数据库事务对象</param>  
        ///    <param name="commandType">命令类型</param>  
        ///    <param name="commandText">Oracle存储过程名称或PL/SQL命令</param>  
        ///    <param name="commandParameters">命令参数集合</param>  
        ///    <returns>当前事务查询操作返回的结果集中位于第一行第一列的Object类型的值</returns>  
        public object ExecuteScalar(OracleTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("当前数据库事务不存在");
            OracleConnection connection = transaction.Connection;
            if (connection == null) throw new ArgumentException("当前事务所在的数据库连接不存在");

            OracleCommand command = new OracleCommand();
            object result = null;

            try
            {
                PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters);
                result = command.ExecuteScalar();
                command.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                transaction.Dispose();
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return result;
        }

        /// <summary>  
        /// 执行数据库查询操作,返回结果集中位于第一行第一列的Object类型的值  
        /// </summary>  
        /// <param name="connection">数据库连接对象</param>  
        /// <param name="cmdType">Command类型</param>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        /// <returns>当前查询操作返回的结果集中位于第一行第一列的Object类型的值</returns>  
        public object ExecuteScalar(OracleConnection connection, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentException("当前数据库连接不存在");
            OracleCommand command = new OracleCommand();
            object result = null;

            try
            {
                PrepareCommand(command, connection, null, cmdType, cmdText, commandParameters);
                result = command.ExecuteScalar();
                command.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return result;
        }

        /// <summary>  
        /// 执行数据库命令前的准备工作  
        /// </summary>  
        /// <param name="command">Command对象</param>  
        /// <param name="connection">数据库连接对象</param>  
        /// <param name="trans">事务对象</param>  
        /// <param name="cmdType">Command类型</param>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        public void PrepareCommand(OracleCommand command, OracleConnection connection, OracleTransaction trans, CommandType cmdType, string cmdText, OracleParameter[] commandParameters)
        {
            if (connection.State != ConnectionState.Open) connection.Open();

            command.Connection = connection;
            command.CommandText = cmdText;
            command.CommandType = cmdType;

            if (trans != null) command.Transaction = trans;

            if (commandParameters != null)
            {
                foreach (OracleParameter parm in commandParameters)
                    command.Parameters.Add(parm);
            }
        }

        /// <summary>  
        /// 将.NET日期时间类型转化为Oracle兼容的日期时间格式字符串  
        /// </summary>  
        /// <param name="date">.NET日期时间类型对象</param>  
        /// <returns>Oracle兼容的日期时间格式字符串（如该字符串：TO_DATE('2007-12-1','YYYY-MM-DD')）</returns>  
        public string GetOracleDateFormat(DateTime date)
        {
            return "TO_DATE('" + date.ToString("yyyy-M-dd") + "','YYYY-MM-DD')";
        }

        /// <summary>  
        /// 将.NET日期时间类型转化为Oracle兼容的日期格式字符串  
        /// </summary>  
        /// <param name="date">.NET日期时间类型对象</param>  
        /// <param name="format">Oracle日期时间类型格式化限定符</param>  
        /// <returns>Oracle兼容的日期时间格式字符串（如该字符串：TO_DATE('2007-12-1','YYYY-MM-DD')）</returns>  
        public string GetOracleDateFormat(DateTime date, string format)
        {
            if (format == null || format.Trim() == "") format = "YYYY-MM-DD";
            return "TO_DATE('" + date.ToString("yyyy-M-dd") + "','" + format + "')";
        }

        /// <summary>  
        /// 将指定的关键字处理为模糊查询时的合法参数值  
        /// </summary>  
        /// <param name="source">待处理的查询关键字</param>  
        /// <returns>过滤后的查询关键字</returns>  
        public string HandleLikeKey(string source)
        {
            if (source == null || source.Trim() == "") return null;

            source = source.Replace("[", "[]]");
            source = source.Replace("_", "[_]");
            source = source.Replace("%", "[%]");

            return ("%" + source + "%");
        }

        /// <summary>  
        /// 将文本内容写入到数据库的CLOB字段中（不可用：报连接被关闭的异常）  
        /// </summary>  
        /// <param name="connectionString">数据库连接字符串</param>  
        /// <param name="table">数据库表名称</param>  
        /// <param name="where">指定的WHERE条件语句</param>  
        /// <param name="clobField">CLOB字段的名称</param>  
        /// <param name="content">要写入的文本内容</param>  
        public void WriteCLOB(string table, string where, string clobField, string content)
        {
            if (String.IsNullOrEmpty(connstr) || String.IsNullOrEmpty(table) || String.IsNullOrEmpty(clobField)) return;

            using (OracleConnection connection = new OracleConnection(connstr))
            {
                OracleCommand command = null;

                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "SELECT " + clobField + " FROM " + table + " WHERE " + where + " FOR UPDATE";
                    OracleDataReader reader = command.ExecuteReader();

                    if (reader != null && reader.HasRows)
                    {
                        reader.Read();
                        command.Transaction = command.Connection.BeginTransaction();

                        OracleLob lob = reader.GetOracleLob(0);
                        byte[] buffer = Encoding.Unicode.GetBytes(content);
                        if (lob != OracleLob.Null) lob.Erase();
                        lob.Write(buffer, 0, ((buffer.Length % 2 == 0) ? buffer.Length : (buffer.Length - 1)));

                        command.Transaction.Commit();
                        reader.Close();
                    }
                }
                catch
                {
                    command.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>  
        /// 从数据库中读取CLOB字段的内容并进行输出  
        /// </summary>  
        /// <param name="connectionString">数据库连接字符串</param>  
        /// <param name="table">数据库表名称</param>  
        /// <param name="where">指定的WHERE条件语句</param>  
        /// <param name="clobField">CLOB字段的名称</param>  
        /// <param name="output">保存内容输出的字符串变量</param>  
        public void ReadCLOB(string connectionString, string table, string where, string clobField, ref string output)
        {
            if (String.IsNullOrEmpty(connectionString) || String.IsNullOrEmpty(table) || String.IsNullOrEmpty(clobField)) return;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = null;
                StreamReader stream = null;

                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "SELECT " + clobField + " FROM " + table + " WHERE " + where;
                    OracleDataReader reader = command.ExecuteReader();

                    if (reader != null && reader.HasRows)
                    {
                        reader.Read();
                        command.Transaction = command.Connection.BeginTransaction();

                        OracleLob lob = reader.GetOracleLob(0);
                        if (lob != OracleLob.Null)
                        {
                            stream = new StreamReader(lob, Encoding.Unicode);
                            output = stream.ReadToEnd().Trim();
                            command.Transaction.Commit();
                            reader.Close();
                        }
                    }
                }
                catch
                {
                    command.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    stream.Close();
                    command.Dispose();
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        #endregion
    }
}
