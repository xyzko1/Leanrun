using Infoearth.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Service
{
    /// <summary>
    /// 数据库函数适配类
    /// </summary>
    public class DbSqlFunctionHelper
    {
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="subStr">需要截取的字符串(必须是数据库字段)</param>
        /// <param name="startIndex">截取的开始位置</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public static string SubString(string subStr, int startIndex, int length)
        {
            string result = string.Empty;
            switch (DbHelper.DbType)
            {
                case DatabaseType.SqlServer:
                case DatabaseType.MySql:
                    startIndex = startIndex == 0 ? 1 : startIndex;
                    result = string.Format("substring({0},{1},{2})", subStr, startIndex, length);
                    break;
                case DatabaseType.Oracle:
                    result = string.Format("substr({0},{1},{2})", subStr, startIndex, length);
                    break;
                default:
                    throw new Exception("数据库类型目前不支持！");
            }
            return result;
        }

        /// <summary>
        /// 查找字符串
        /// </summary>
        /// <param name="findStr">需要查找的字符串</param>
        /// <param name="targetStr">被查找的字符串(必须是数据库字段)</param>
        /// <param name="startIndex">开始查找的位置</param>
        /// <returns></returns>
        public static string InStr(string findStr, string targetStr, int startIndex = 0)
        {
            string result = string.Empty;
            switch (DbHelper.DbType)
            {
                case DatabaseType.SqlServer:
                    result = string.Format("charindex('{0}',{1},{2})", findStr, targetStr, startIndex);
                    break;
                case DatabaseType.MySql:
                    result = string.Format("instr({1},'{0}')", targetStr, findStr);
                    break;
                case DatabaseType.Oracle:
                    result = string.Format("instr('{0}',{1},{2})", findStr, targetStr, startIndex);
                    break;
                default:
                    throw new Exception("数据库类型目前不支持！");
            }
            return result;
        }

        /// <summary>
        /// 日期格式转换
        /// </summary>
        /// <param name="dateTime">需要转换的日期</param>
        /// <param name="format">转换格式</param>
        /// <returns></returns>
        public static string DateFormat(DateTime dateTime, string format)
        {
            string result = string.Empty;
            switch (DbHelper.DbType)
            {
                case DatabaseType.SqlServer:
                case DatabaseType.MySql:
                    result = string.Format("'{0}'", dateTime.ToString(format.ToLower().Replace("/", "-").Replace("hh24", "HH").Replace("-mm-", "-MM-").Replace("mi", "mm")));
                    break;
                case DatabaseType.Oracle:
                    result = string.Format("to_date('{0}','{1}')", dateTime.ToString(format.ToLower().Replace("/", "-").Replace("hh24", "HH").Replace("-mm-", "-MM-").Replace("mi", "mm")), format);
                    break;
                default:
                    throw new Exception("数据库类型目前不支持！");
            }
            return result;
        }

        /// <summary>
        /// 拼接字符串
        /// </summary>
        /// <param name="list">需要拼接的字符串</param>
        /// <returns></returns>
        public static string Concat(List<KeyValuePair<bool, string>> list)
        {
            string result = string.Empty;
            switch (DbHelper.DbType)
            {
                case DatabaseType.SqlServer:
                case DatabaseType.MySql:
                    result += "concat(";
                    foreach (var item in list)
                    {
                        if (item.Key)
                        {
                            result += string.Format("{0},", item.Value);
                        }
                        else
                        {
                            result += string.Format("'{0}',", item.Value);
                        }
                    }
                    result = result.TrimEnd(',');
                    result += ")";
                    break;
                case DatabaseType.Oracle:
                    foreach (var item in list)
                    {
                        if (item.Key)
                        {
                            result += string.Format("{0}||", item.Value);
                        }
                        else
                        {
                            result += string.Format("'{0}'||", item.Value);
                        }
                    }
                    result = result.TrimEnd('|');
                    break;
                default:
                    throw new Exception("数据库类型目前不支持！");
            }
            return result;
        }

        /// <summary>
        /// 获取记录行号
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <returns></returns>
        public static string GetRowNum(string fieldName)
        {
            string result = string.Empty;
            switch (DbHelper.DbType)
            {
                case DatabaseType.SqlServer:
                    result = string.Format("row_number() over(order by {0}) as rownum", fieldName);
                    break;
                case DatabaseType.MySql:
                    result = string.Format("@rownum := @rownum + 1 as rownum");
                    break;
                case DatabaseType.Oracle:
                    result = string.Format("rownum");
                    break;
                default:
                    throw new Exception("数据库类型目前不支持！");
            }
            return result;
        }

        /// <summary>
        /// 获取记录行号(mysql处理表名)
        /// </summary>
        /// <param name="tableName">字段名称</param>
        /// <returns></returns>
        public static string GetRowNum2(string tableName)
        {
            string result = string.Empty;
            switch (DbHelper.DbType)
            {
                case DatabaseType.MySql:
                    result = string.Format("(select @rownum := 0) r,{0}", tableName);
                    break;
                case DatabaseType.SqlServer:
                case DatabaseType.Oracle:
                    result = string.Format("{0}", tableName);
                    break;
                default:
                    throw new Exception("数据库类型目前不支持！");
            }
            return result;
        }

        /// <summary>
        /// 去字符串首尾空格
        /// </summary>
        /// <param name="fieldName">需要处理的字段</param>
        /// <returns></returns>
        public static string Trim(string fieldName)
        {
            string result = string.Empty;
            switch (DbHelper.DbType)
            {
                case DatabaseType.MySql:
                case DatabaseType.Oracle:
                    result = string.Format("trim({0})", fieldName);
                    break;
                case DatabaseType.SqlServer:
                    result = string.Format("ltrim(rtrim({0}))", fieldName);
                    break;
                default:
                    throw new Exception("数据库类型目前不支持！");
            }
            return result;
        }

        /// <summary>
        /// 日期字段转换字符串
        /// </summary>
        /// <param name="fieldName">需要转换的字段</param>
        /// <param name="format">转换格式</param>
        /// <returns></returns>
        public static string DateToChar(string fieldName, string format)
        {
            string result = string.Empty;
            switch (DbHelper.DbType)
            {
                case DatabaseType.SqlServer:
                    format = format.ToLower().Replace("/", "-");
                    if (format == "yyyy")
                    {
                        result = string.Format("concat(datename(year,{0}),'')", fieldName);
                    }
                    else if (format == "mm")
                    {
                        result = string.Format("concat(datename(month,{0}),'')", fieldName);
                    }
                    else if (format == "dd")
                    {
                        result = string.Format("concat(datename(day,{0}),'')", fieldName);
                    }
                    else if (format == "yyyy-mm")
                    {
                        result = string.Format("concat(datename(year,{0}),'-',datename(month,{0}))", fieldName);
                    }
                    else if (format == "yyyy-mm-dd")
                    {
                        result = string.Format("concat(datename(year,{0}),'-',datename(month,{0}),'-',datename(day,{0}))", fieldName);
                    }
                    else if (format == "yyyy-mm-dd hh24")
                    {
                        result = string.Format("concat(datename(year,{0}),'-',datename(month,{0}),'-',datename(day,{0}),' ',datename(hour,{0}))", fieldName);
                    }
                    else if (format == "mm-dd hh24:mi")
                    {
                        result = string.Format("concat(datename(month,{0}),'-',datename(day,{0}),' ',datename(hour,{0}),':',datename(minute,{0}))", fieldName);
                    }
                    else if (format == "yyyy-mm-dd hh24:mi")
                    {
                        result = string.Format("concat(datename(year,{0}),'-',datename(month,{0}),'-',datename(day,{0}),' ',datename(hour,{0}),':',datename(minute,{0}))", fieldName);
                    }
                    else if (format == "yyyy-mm-dd hh24:mi:ss")
                    {
                        result = string.Format("concat(datename(year,{0}),'-',datename(month,{0}),'-',datename(day,{0}),' ',datename(hour,{0}),':',datename(minute,{0}),':',datename(second,{0}))", fieldName);
                    }
                    break;
                case DatabaseType.MySql:
                    format = format.ToLower().Replace("/", "-");
                    if (format == "yyyy")
                    {
                        result = string.Format("date_format({0},'{1}')", fieldName, "%Y");
                    }
                    else if (format == "mm")
                    {
                        result = string.Format("date_format({0},'{1}')", fieldName, "%m");
                    }
                    else if (format == "dd")
                    {
                        result = string.Format("date_format({0},'{1}')", fieldName, "%d");
                    }
                    else if (format == "yyyy-mm")
                    {
                        result = string.Format("date_format({0},'{1}')", fieldName, "%Y-%m");
                    }
                    else if (format == "yyyy-mm-dd")
                    {
                        result = string.Format("date_format({0},'{1}')", fieldName, "%Y-%m-%d");
                    }
                    else if (format == "yyyy-mm-dd hh24")
                    {
                        result = string.Format("date_format({0},'{1}')", fieldName, "%Y-%m-%d %H");
                    }
                    else if (format == "mm-dd hh24:mi")
                    {
                        result = string.Format("date_format({0},'{1}')", fieldName, "%m-%d %H:%i");
                    }
                    else if (format == "yyyy-mm-dd hh24:mi")
                    {
                        result = string.Format("date_format({0},'{1}')", fieldName, "%Y-%m-%d %H:%i");
                    }
                    else if (format == "yyyy-mm-dd hh24:mi:ss")
                    {
                        result = string.Format("date_format({0},'{1}')", fieldName, "%Y-%m-%d %H:%i:%S");
                    }
                    break;
                case DatabaseType.Oracle:
                    result = string.Format("to_char({0},'{1}')", fieldName, format);
                    break;
                default:
                    throw new Exception("数据库类型目前不支持！");
            }
            return result;
        }

        /// <summary>
        /// 判断字段是否为Null
        /// </summary>
        /// <param name="fieldName">需要判断的字段</param>
        /// <param name="value">为Null后的值</param>
        /// <returns></returns>
        public static string IsNull(string fieldName, string value)
        {
            string result = string.Empty;
            switch (DbHelper.DbType)
            {
                case DatabaseType.SqlServer:
                    result = string.Format("isnull({0},{1})", fieldName, value);
                    break;
                case DatabaseType.MySql:
                    result = string.Format("ifnull({0},{1})", fieldName, value);
                    break;
                case DatabaseType.Oracle:
                    result = string.Format("nvl({0},{1})", fieldName, value);
                    break;
                default:
                    throw new Exception("数据库类型目前不支持！");
            }
            return result;
        }

        /// <summary>
        /// 字符串转数字
        /// </summary>
        /// <param name="fieldName">需要转换的字段</param>
        /// <returns></returns>
        public static string ToNumber(string fieldName)
        {
            string result = string.Empty;
            switch (DbHelper.DbType)
            {
                case DatabaseType.SqlServer:
                    result = string.Format("cast({0} as int)", fieldName);
                    break;
                case DatabaseType.MySql:
                    result = string.Format("cast({0} as signed int)", fieldName);
                    break;
                case DatabaseType.Oracle:
                    result = string.Format("to_number({0})", fieldName);
                    break;
                default:
                    throw new Exception("数据库类型目前不支持！");
            }
            return result;
        }
    }
}
