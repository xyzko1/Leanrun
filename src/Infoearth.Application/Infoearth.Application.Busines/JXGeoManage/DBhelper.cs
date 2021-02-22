using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Data.OracleClient;
using System.IO;
using System.Reflection;
namespace DAL
{
   public class DBhelper
    {
        //数据库连接字符串
        private static string connString = ConfigurationManager.ConnectionStrings["BMSConnectionString"].ConnectionString;
        //private static string connString2 = ConfigurationManager.ConnectionStrings["BMSConnectionString2"].ConnectionString;
        #region Sqlserver

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

        //public static DataTable ExecuteSelect2(string sql2, params SqlParameter[] para2)
        //{
        //    try
        //    {
        //        SqlDataAdapter da2 = new SqlDataAdapter(sql2, connString2);
        //        if (da2 != null)
        //        {
        //            da2.SelectCommand.Parameters.AddRange(para2);
        //        }
        //        DataTable dt = new DataTable();
        //        da2.Fill(dt);
        //        return dt;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        ////执行增、删、改的
        //public static bool ExecuteNonQuery2(string sql, SqlParameter[] para)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connString2))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(sql, conn))
        //            {
        //                if (para != null)
        //                {
        //                    cmd.Parameters.AddRange(para);
        //                }
        //                if (conn.State == ConnectionState.Closed)
        //                {
        //                    conn.Open();
        //                }
        //                int i = cmd.ExecuteNonQuery();
        //                conn.Close();
        //                return i > 0 ? true : false;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public static int Insert2(List<string> sql)
        //{
        //    int returnValue = 0;
        //    SqlConnection _conn = new SqlConnection(connString2);
        //    try
        //    {
        //        if (_conn.State == ConnectionState.Closed)
        //        {
        //            _conn.Open();
        //        }
        //        foreach (var item in sql)
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand(item, _conn);
        //                cmd.ExecuteNonQuery();
        //            }
        //            catch (Exception)
        //            {
        //                throw;
        //            }

        //        }
        //        _conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //    return returnValue;
        //}
        #endregion

               //数据库连接字符串（注意：这里的“DBConnectionString”一定要与web.config文件中connectionStrings节点值一致）
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        #region MySQL
        // 用于缓存参数的HASH表
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
 
 
        /// <summary>
        ///  给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText, CommandType cmdType = CommandType.Text, params MySqlParameter[] commandParameters)
        { 
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
 
 
        /// <summary>
        /// 用执行的数据库连接执行一个返回数据集的sql命令
        /// </summary>
        /// <remarks>
        /// 举例:
        ///  MySqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>包含结果的读取器</returns>
        public static MySqlDataReader ExecuteReader(string cmdText, CommandType cmdType = CommandType.Text, params MySqlParameter[] commandParameters)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();
            //创建一个MySqlConnection对象
            MySqlConnection conn = new MySqlConnection(connectionString);
 
 
            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
            //因此commandBehaviour.CloseConnection 就不会执行
            try
            {
                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //清除参数
                cmd.Parameters.Clear();
                return reader;
            }
            catch
            {
                //关闭连接，抛出异常
                conn.Close();
                throw;
            }
        }
 
 
        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string cmdText, CommandType cmdType = CommandType.Text, params MySqlParameter[] commandParameters)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();
            //创建一个MySqlConnection对象
            MySqlConnection conn = new MySqlConnection(connectionString);
            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
 
 
            try
            {
                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet(); 
                adapter.Fill(ds);
                //清除参数
                cmd.Parameters.Clear();
                conn.Close();
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
 
 
 
        /// <summary>
        /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        ///例如:
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
        public static object ExecuteScalar(string cmdText, CommandType cmdType = CommandType.Text, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
 
 
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
 
 
        /// <summary>
        /// 将参数集合添加到缓存
        /// </summary>
        /// <param name="cacheKey">添加到缓存的变量</param>
        /// <param name="commandParameters">一个将要添加到缓存的sql参数集合</param>
        public static void CacheParameters(string cacheKey, params MySqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }
 
 
        /// <summary>
        /// 找回缓存参数集合
        /// </summary>
        /// <param name="cacheKey">用于找回参数的关键字</param>
        /// <returns>缓存的参数集合</returns>
        public static MySqlParameter[] GetCachedParameters(string cacheKey)
        {
            MySqlParameter[] cachedParms = (MySqlParameter[])parmCache[cacheKey];
 
 
            if (cachedParms == null)
                return null;
 
 
            MySqlParameter[] clonedParms = new MySqlParameter[cachedParms.Length];
 
 
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (MySqlParameter)((ICloneable)cachedParms[i]).Clone();
 
 
            return clonedParms;
        }
 
 
        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">OleDb连接</param>
        /// <param name="trans">OleDb事务</param>
        /// <param name="cmdType">命令类型例如 存储过程或者文本</param>
        /// <param name="cmdText">命令文本,例如:Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
 
 
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
 
 
            if (trans != null)
                cmd.Transaction = trans;
 
 
            cmd.CommandType = cmdType;
 
 
            if (cmdParms != null)
            {
                foreach (MySqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
 
 
    
 
        #endregion


        #region Oracle
        ////数据库连接字符串
        //private static string connString2 = ConfigurationManager.ConnectionStrings["BaseDb"].ConnectionString;
        //数据库连接字符串  
        private readonly static string connstr = ConfigurationManager.ConnectionStrings["BaseDb"].ConnectionString;
        /// <summary>  
        /// 执行数据库查询操作,返回受影响的行数  
        /// </summary>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        /// <returns>当前查询操作影响的数据行数</returns>  
        public static int ExecuteNonQuery(string cmdText, params OracleParameter[] commandParameters)
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
        public static int ExecuteNonQuery(string con,string cmdText, params OracleParameter[] commandParameters)
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
        public static int ExecuteNonQuery(OracleTransaction transaction, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
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
        public static int ExecuteNonQuery(OracleConnection connection, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
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
        public static OracleDataReader ExecuteReader(string cmdText, params OracleParameter[] commandParameters)
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
        public static DataSet ExecuteDataSet(string cmdText, params OracleParameter[] commandParameters)
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
        public static DataSet ExecuteDataSet(string con,string cmdText, params OracleParameter[] commandParameters)
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
        public static DataSet Query(string SQLString, params OracleParameter[] cmdParms)
        {
            //OracleCommand command = new OracleCommand();
            //OracleConnection connection = new OracleConnection(connstr);
            //DataSet dataset = null;

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
        public static DataSet Query(string con,string SQLString, params OracleParameter[] cmdParms)
        {
            //OracleCommand command = new OracleCommand();
            //OracleConnection connection = new OracleConnection(con);
            //DataSet dataset = null;

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
        public static DataTable ExecuteDataTable(string cmdText, params OracleParameter[] commandParameters)
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
        public static object ExecuteScalar(string cmdText, params OracleParameter[] commandParameters)
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
        public static object ExecuteScalar(OracleTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
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
        public static object ExecuteScalar(OracleConnection connection, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
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
        private static void PrepareCommand(OracleCommand command, OracleConnection connection, OracleTransaction trans, CommandType cmdType, string cmdText, OracleParameter[] commandParameters)
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
        public static string GetOracleDateFormat(DateTime date)
        {
            return "TO_DATE('" + date.ToString("yyyy-M-dd") + "','YYYY-MM-DD')";
        }

        /// <summary>  
        /// 将.NET日期时间类型转化为Oracle兼容的日期格式字符串  
        /// </summary>  
        /// <param name="date">.NET日期时间类型对象</param>  
        /// <param name="format">Oracle日期时间类型格式化限定符</param>  
        /// <returns>Oracle兼容的日期时间格式字符串（如该字符串：TO_DATE('2007-12-1','YYYY-MM-DD')）</returns>  
        public static string GetOracleDateFormat(DateTime date, string format)
        {
            if (format == null || format.Trim() == "") format = "YYYY-MM-DD";
            return "TO_DATE('" + date.ToString("yyyy-M-dd") + "','" + format + "')";
        }

        /// <summary>  
        /// 将指定的关键字处理为模糊查询时的合法参数值  
        /// </summary>  
        /// <param name="source">待处理的查询关键字</param>  
        /// <returns>过滤后的查询关键字</returns>  
        public static string HandleLikeKey(string source)
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
        public static void WriteCLOB(string table, string where, string clobField, string content)
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
        public static void ReadCLOB(string connectionString, string table, string where, string clobField, ref string output)
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

        #region 转实体
        
        #endregion
    }
   public static class DataTableToEntity
   {
       /// <summary>
       /// 将DataTable数据源转换成实体类
       /// </summary>
       public static List<T> ConvertToModel<T>(this DataTable dt) where T : new()
       {
           List<T> ts = new List<T>();// 定义集合
           foreach (DataRow dr in dt.Rows)
           {
               T t = new T();
               PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
               foreach (PropertyInfo pi in propertys)
               {
                   if (dt.Columns.Contains(pi.Name))
                   {
                       if (!pi.CanWrite) continue;
                       var value = dr[pi.Name];
                       try
                       {
                           if (value != DBNull.Value && value != null && value.ToString() != "")
                           {
                               if (pi.PropertyType.FullName.ToUpper().Contains("DECIMAL"))
                               {
                                   pi.SetValue(t, decimal.Parse(value.ToString()), null);
                               }
                               else if (pi.PropertyType.FullName.ToUpper().Contains("DOUBLE"))
                               {
                                   pi.SetValue(t, double.Parse(value.ToString()), null);
                               }
                               else if (pi.PropertyType.FullName.ToUpper().Contains("INT32"))
                               {
                                   pi.SetValue(t, int.Parse(value.ToString()), null);
                               }
                               else if (pi.PropertyType.FullName.ToUpper().Contains("INT16"))
                               {
                                   pi.SetValue(t, short.Parse(value.ToString()), null);
                               }
                               else
                                   pi.SetValue(t, value, null);

                           }
                       }
                       catch (Exception ex)
                       {
                           //throw ex;
                       }

                   }
               }
               ts.Add(t);
           }
           return ts;
       }
   }
}
