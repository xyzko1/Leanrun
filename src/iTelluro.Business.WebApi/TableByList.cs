using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Read
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
