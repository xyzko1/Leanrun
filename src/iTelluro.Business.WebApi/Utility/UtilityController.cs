using System.Collections.Generic;
using System.Data;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Infoearth.Util.Offices;
using System.Web;
using System.Threading;
using System;
using System.IO;
using Infoearth.Application.Busines.SystemManage;
using System.Linq;
using Infoearth.Application.Entity.PublicInfoManage;
using Infoearth.Application.Busines.PublicInfoManage;
using Infoearth.Application.Entity.SystemManage;
using System.Data.Common;
using System.Reflection;
using Infoearth.Application.Entity;
using System.Web.Http;
using Infoearth.Application.Entity.DMCJManage;

namespace iTelluro.Busness.WebApi
{
   /// <summary>
    /// 公共控制器
   /// </summary>
    public class UtilityController : ApiControllerBase
    {
        [HttpGet]
        [Route("api/Utility/GetAllPropertys")]
        public object GetAllPropertys(string entityName)
        {
            IDictionary<string, string> returnValue = new Dictionary<string, string>();
            if (entityName.ToUpper() == "TBL_DMCJ_BASEINFOEntity".ToUpper())
            {
                returnValue = GetAllPropertyDic<TBL_DMCJ_BASEINFOEntity>();
            }

            string strcolumns = "[";
            foreach (var item in returnValue.Keys)
            {
                strcolumns += "{value:\"" + item + "\",text:\"" + returnValue[item] + "\"},";
            }
            strcolumns = strcolumns.TrimEnd(',') + "]";

            return strcolumns.ToJson();
        }
        public static IDictionary<string, string> GetAllPropertyDic<T4>()
        {
            IDictionary<string, string> dicProps = new Dictionary<string, string>();
            PropertyInfo[] propertys = typeof(T4).GetProperties();
            for (int j = 0; j < propertys.Count(); j++)
            {
                object[] attrs = propertys[j].GetCustomAttributes(typeof(DescAttribute), false);
                if (attrs == null || attrs.Length <= 0)
                {
                    continue;
                }
                DescAttribute attr = (DescAttribute)attrs[0];
                if (attr != null && !attr.IsExport)
                    continue;
                if (attr == null || string.IsNullOrEmpty(attr.Name))
                    dicProps.Add(propertys[j].Name, propertys[j].Name);
                else
                    dicProps.Add(propertys[j].Name, attr.Name);
            }
            return dicProps;
        }

        /// <summary>
        /// 字典项转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="dicColumn"></param>
        public static void ConvertDicValue<T>(List<T> list)
        {
            ClientDataController cl = new ClientDataController();
            Dictionary<string, object> dicList = (Dictionary<string, object>)cl.GetDataItem();//字典项集合
            IDictionary<string, string> dicColumn = GetAllDicFiled<T>();
            PropertyInfo[] propertys = typeof(T).GetProperties();
            foreach (var entity in list)
            {
                foreach (var field in dicColumn.Keys)
                {
                    PropertyInfo p = entity.GetType().GetProperty(field);
                    string value = p.GetValue(entity, null) == null ? "" : p.GetValue(entity, null).ToString();
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        string valueName = GetDicValue(dicList, dicColumn[field], value);
                        p.SetValue(entity, valueName);//赋值

                    }

                }
            }
        }
        /// <summary>
        /// 获取字典字段
        /// </summary>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        public static IDictionary<string, string> GetAllDicFiled<T4>()
        {
            IDictionary<string, string> dicProps = new Dictionary<string, string>();
            PropertyInfo[] propertys = typeof(T4).GetProperties();
            for (int j = 0; j < propertys.Count(); j++)
            {
                object[] attrs = propertys[j].GetCustomAttributes(typeof(DescAttribute), false);
                if (attrs == null || attrs.Length <= 0)
                {
                    continue;
                }
                DescAttribute attr = (DescAttribute)attrs[0];
                if (!string.IsNullOrEmpty(attr.DicName) && !dicProps.ContainsKey(attr.DicName))
                {
                    dicProps.Add(propertys[j].Name, attr.DicName);
                }
            }
            return dicProps;
        }
        /// <summary>
        /// 获取字典值
        /// </summary>
        /// <param name="dicColumn"></param>
        /// <param name="dicName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDicValue(Dictionary<string, object> dicList, string dicName, string value)
        {
            string returnValue = string.Empty;
            if (!string.IsNullOrWhiteSpace(value))
            {
                foreach (var dic in dicList.Keys)
                {
                    if (dicList.ContainsKey(dicName))
                    {
                        Dictionary<string, string> list = (Dictionary<string, string>)dicList[dicName];
                        foreach (var item in list.Keys)
                        {
                            if (item == value)
                            {
                                returnValue = list[item];
                                break;
                            }
                        }
                    }

                }

            }
            return returnValue;
        }

    }
}
