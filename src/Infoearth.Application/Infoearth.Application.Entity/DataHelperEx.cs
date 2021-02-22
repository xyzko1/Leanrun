using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infoearth.Util
{
    /// <summary>
    /// 数据源转换
    /// </summary>
    public class DataHelperEx : DataHelper
    {
        #region dataTable转换成Json格式
        /// <summary>
        /// Msdn
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            if (dt == null)
                return string.Empty;
            StringBuilder Json = new StringBuilder();
            Json.Append("[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString() + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]");
            return Json.ToString();
        }

        #endregion
        
        #region DataTable行列转换
        /// <summary>
        /// DataTable行列转换
        /// </summary>
        /// <param name="scr">要转换的DataTable</param>
        /// <param name="columnIndex">要作为Column的那列</param>
        /// <returns></returns>
        public static DataTable DataTableColToRow(DataTable src,int columnIndex)
        {
            DataTable result = new DataTable();
            DataColumn column = src.Columns[columnIndex];
            result.Columns.Add(column.ColumnName);
            for (int i = 0; i < src.Rows.Count; i++)
            {
                result.Columns.Add(src.Rows[i][column].ToString());
            }

            foreach (DataColumn col in src.Columns)
            {
                if(col==column)
                {
                    continue;
                }

                object[] newRow = new object[src.Rows.Count + 1];
                newRow[0] = col.ColumnName;
                for (int i = 0; i < src.Rows.Count; i++)
                {
                    newRow[i + 1] = src.Rows[i][col];
                }
                result.Rows.Add(newRow);
            }
            return result;
        }

        /// <summary>
        ///  DataTable行列转换
        /// </summary>
        /// <param name="src">要转换的DataTable</param>
        /// <param name="columnName">要作为Column的那列</param>
        /// <returns></returns>
        public static DataTable DataTableColToRow(DataTable src,string columnName)
        {
            for (int i = 0; i < src.Columns.Count; i++)
            {
                if(src.Columns[i].ColumnName.ToUpper()==columnName.ToUpper())
                {
                    return DataTableColToRow(src, i);
                }
            }
            return new DataTable();
        }

        #endregion

        #region 两个结构不同的DataTable合并
        /// <summary>    
        /// 将两个列不同的DataTable合并成一个新的DataTable    
        /// </summary>    
        /// <param name="dt1">Table表1</param>    
        /// <param name="dt2">Table表2</param>    
        /// <param name="DTName">合并后新的表名</param>    
        /// <returns></returns>   
        public static DataTable UniteDataTable(DataTable dt1, DataTable dt2, string DTName)
        {
            DataTable dt3 = dt1.Clone();
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                dt3.Columns.Add(dt2.Columns[i].ColumnName);
            }
            object[] obj = new object[dt3.Columns.Count];

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt1.Rows[i].ItemArray.CopyTo(obj, 0);
                dt3.Rows.Add(obj);
            }

            if (dt1.Rows.Count >= dt2.Rows.Count)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        dt3.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                    }
                }
            }
            else
            {
                DataRow dr3;
                for (int i = 0; i < dt2.Rows.Count - dt1.Rows.Count; i++)
                {
                    dr3 = dt3.NewRow();
                    dt3.Rows.Add(dr3);
                }
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        dt3.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                    }
                }
            }
            dt3.TableName = DTName;
            return dt3;
        }
        #endregion
    }
}
