using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;

namespace Infoearth.Application.Busines
{
    /// <summary>
    /// 将DataTable数据源转换成实体类
    /// </summary>
    /// <typeparam name="T">实体</typeparam>
    public static class ToModel<T> where T : new()
    {
        /// <summary>
        /// 将DataTable数据源转换成实体类
        /// </summary>
        public static List<T> ConvertToModel(DataTable dt)
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
                        if (value != DBNull.Value)
                        {
                            switch (pi.PropertyType.FullName)
                            {
                                case "System.Decimal":
                                    pi.SetValue(t, decimal.Parse(value.ToString()), null);
                                    break;
                                case "System.String":
                                    pi.SetValue(t, value.ToString(), null);
                                    break;
                                case "System.Int32":
                                    pi.SetValue(t, int.Parse(value.ToString()), null);
                                    break;
                                default:
                                    //pi.PropertyType.GetType
                                    if (pi.PropertyType.Name=="Nullable`1")
                                    {
                                        pi.SetValue(t, "", null);
                                    }
                                    else
                                    {
                                        pi.SetValue(t, value, null);
                                    }
                                    break;
                            }
                        }
                    }
                }
                ts.Add(t);
            }
            return ts;
        }


        /// <summary>
        /// 将DataRow转换成实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T GetItem<T>(DataRow dr)
        {
            try
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name.ToLower() == column.ColumnName.ToLower())
                        {
                            if (dr[column.ColumnName] == DBNull.Value)
                            {
                                pro.SetValue(obj, " ", null);
                                break;
                            }
                            else
                            {
                                pro.SetValue(obj, dr[column.ColumnName], null);
                                break;
                            }
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


    public static class DataTableToEntity
    {
        //public static string strConn = "";
        public static object GetData(string paths)
        {
            //获取选中文件的路径
            string path = paths;
            //获取文件后缀名 
            //if (System.IO.Path.GetExtension(path).ToLower() == ".xls")
            //{
            //    //如果是07以下（.xls）的版本的Excel文件就使用这条连接字符串
            //    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0;";
            //}
            //else
            //{
            //如果是07以上(.xlsx)的版本的Excel文件就使用这条连接字符串
            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + path + ";Extended Properties='Excel 12.0; HDR=YES; IMEX=1'"; //此連接可以操作.xls與.xlsx文件
            //}
            if (System.IO.Path.GetExtension(path).ToLower().Contains(".xls"))
            {
                //打开Excel的连接，设置连接对象
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                DataTable sheetNames = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                //OleDbConnection conn = new OleDbConnection(strConn);
                //当前选中的工作表前几行数据，获取数据列
                OleDbDataAdapter oada = new OleDbDataAdapter("select  * from [Sheet1$]", strConn);
                DataTable dt = new DataTable();
                oada.Fill(dt);
                conn.Close();
                return dt;
                //var tablelist = tbl_hazardbasicinfobll.GetValue().ToList();//获取库中灾害点所有数据
                //List<string> list = new List<string>();
                //DataTable data = dt.Clone();
                //存在 不存在
                //int count = data.Rows.Count;
                //ExcelHelper.ExcelDownloadOnlyDT(data, "排查数据", string.Format("排查数据导出{0}.xls", DateTime.Now.ToLongDateString().ToString()));
            }
            return null;
        }
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
                                    //if (value.ToString().Contains("."))
                                    //{

                                    //}
                                    //pi.SetValue(t, int.Parse(value.ToString()), null);
                                    pi.SetValue(t, Convert.ToInt32(value.ToString()), null);
                                }
                                else if (pi.PropertyType.FullName.ToUpper().Contains("INT16"))
                                {
                                    if (value.ToString().Contains("."))
                                    {
                                        
                                    }
                                    pi.SetValue(t, short.Parse(value.ToString()), null);
                                }
                                else if (pi.PropertyType.FullName.ToUpper().Contains("STRING"))
                                {
                                    pi.SetValue(t, value.ToString(), null);
                                }
                                else if (pi.PropertyType.FullName.ToUpper().Contains("DATETIME"))
                                {
                                    pi.SetValue(t, DateTime.Parse(value.ToString()), null);
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
