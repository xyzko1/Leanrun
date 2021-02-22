using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;


namespace Infoearth.Application.Service.JXGeoManage
{
  public static  class Read
    {
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
