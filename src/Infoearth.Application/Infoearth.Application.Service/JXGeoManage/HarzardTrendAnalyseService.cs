using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using System;
using Infoearth.Util.Extension;
using System.Reflection;
using System.Data;
using System.Collections;
using Newtonsoft.Json.Linq;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.Service.SystemManage;
using Infoearth.Application.IService.SystemManage;
using Infoearth.Application.Common;
using Infoearth.Application.Entity;
using Infoearth.Data;

namespace Infoearth.Application.Service.JXGeoManage
{

    public class HarzardTrendAnalyseService : RepositoryFactory, HarzardTrendAnalyseIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        private static IDataItemDetailService serviceDataItem = new DataItemDetailService();
        private JYGC_PROJECTBASEINFOIService project = new JYGC_PROJECTBASEINFOService();

        #region 总趋势统计
        public DataTable QueryStatistics(string queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList, ref List<MergedRegionEntity> columnList)
        {
            var queryParam = queryJson.ToJObject();
            string baseSql = GetBaseSql(queryParam, dicList);
            baseSql += GetWhereSqlByCondition(queryParam);
            string groupSql = GetGroupSqlByCondition(queryParam, ref columnList);
            string sqlTmp = "select  {0} from( " + baseSql + ") a" + groupSql;
            string selectSql = GetSelectSql(queryParam, dicList, ref columnList);
            string sql = string.Format(sqlTmp, selectSql);

            DataTable result = this.BaseRepository().FindTable(sql);
            XZQHCL(result);
            result.TableName = "统计分析";
            return result;
        }
        private DataTable XZQHCL(DataTable result)
        {

            for (int i = 0; i < result.Rows.Count; i++)
            {
                if (result.Columns.Contains("省") && result.Rows[i]["省"].IsEmpty())
                {
                    result.Rows.RemoveAt(i);
                }
            }
            foreach (DataRow item in result.Rows)
            {
                if (result.Columns.Contains("县") && !item["县"].IsEmpty())
                {
                    item["省"] = "";
                    item["市"] = "";
                }
                else if (result.Columns.Contains("市") && !item["市"].IsEmpty())
                {
                    item["省"] = "";
                }
            }
            List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
            //行政区划替换成中文
            foreach (DataRow item in result.Rows)
            {
                string[] strArr = new string[] { "省", "市", "县" };
                foreach (string item2 in strArr)
                {
                    if (result.Columns.Contains(item2) && !item[item2].IsEmpty())
                    {
                        string value = item[item2].ToString();
                        AreaEntity entity = districts.Where(p => p.F_AreaCode == value).FirstOrDefault();
                        if (null != entity)
                        {
                            item[item2] = entity.F_AreaName;
                        }
                    }
                }
            }
            return result;
        }
        private string GetBaseSql(JObject queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList)
        {
            string baseSelectSql = "";
            string baseSqlTmp = string.Empty;
            //数据范围权限过滤
            var _codes = ssoWS.GetAllAuthDistricts();
            var sqlFrom = "(SELECT	aa.*FROM	TBL_HAZARDBASICINFO_HISTORY aa INNER JOIN (	SELECT  UNIFIEDCODE, MAX (MODIFYTIME) MODIFYTIME FROM TBL_HAZARDBASICINFO_HISTORY WHERE " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy") + " ='" + queryJson["startYear"].ToString() + "' GROUP BY UNIFIEDCODE UNION ALL SELECT UNIFIEDCODE, MAX (MODIFYTIME) MODIFYTIME	FROM TBL_HAZARDBASICINFO_HISTORY	WHERE " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy") + " ='" + queryJson["endYear"].ToString() + "' GROUP BY UNIFIEDCODE ) bb ON AA.UNIFIEDCODE = BB.UNIFIEDCODE AND AA.MODIFYTIME = BB.MODIFYTIME)"; 
            if (!_codes.Contains("000000"))
            {
                //                baseSqlTmp = @"
                //select PROVINCE, CITY,  COUNTY, PROVINCE 省, CITY 市,COUNTY 县,{0}  from (
                //select guid,substr(xzqhcode,0,2)||'0000' PROVINCE,substr(xzqhcode,0,4)||'00' CITY, xzqhcode COUNTY,PROJECTID,'1' ISXH,ISBQBR,ISZLGC,ISZRZT,'XH' typename from tbl_xiaohao where 1=1 and xzqhcode in('" + string.Join("','", _codes) + @"')
                //union all
                //select guid,substr(PROVINCE,0,2)||'0000' PROVINCE,substr(county,0,4)||'00' CITY,county,PROJECTID,ISXH,'','','','DZ' typename  from tbl_hazardbasicinfo where 1=1 and COUNTY in('" + string.Join("','", _codes) + @"')) where 1=1 ";
                //                baseSqlTmp = @"
                //select PROVINCE, CITY,  COUNTY, PROVINCE 省, CITY 市,COUNTY 县,{0}  from (
                //select guid," + DbSqlFunctionHelper.SubString("xzqhcode", 0, 2) + "||'0000' PROVINCE," + DbSqlFunctionHelper.SubString("xzqhcode", 0, 4) + "||'00' CITY, xzqhcode COUNTY,PROJECTID,'1' ISXH,ISBQBR,ISZLGC,ISZRZT,'XH' typename from tbl_xiaohao where 1=1 and xzqhcode in('" + string.Join("','", _codes) + @"')
                //union all
                //select guid," + DbSqlFunctionHelper.SubString("PROVINCE", 0, 2) + "||'0000' PROVINCE," + DbSqlFunctionHelper.SubString("county", 0, 4) + "||'00' CITY,county,PROJECTID,ISXH,'','','','DZ' typename  from tbl_hazardbasicinfo where 1=1 and COUNTY in('" + string.Join("','", _codes) + @"')) where 1=1 ";
                baseSqlTmp = @"
select PROVINCE, CITY,  COUNTY, PROVINCE 省, CITY 市,COUNTY 县,{0}  from (
select guid,{1} PROVINCE,{2} CITY, xzqhcode COUNTY,PROJECTID,'1' ISXH,ISBQBR,ISZLGC,ISZRZT,'XH' typename from tbl_xiaohao where 1=1 and xzqhcode in('" + string.Join("','", _codes) + @"')
union all
select guid,{3} PROVINCE,{4} CITY,county,PROJECTID,ISXH,'','','','DZ' typename  from "+sqlFrom+" where 1=1 and COUNTY in('" + string.Join("','", _codes) + @"')) where 1=1 ";

            }
            else
            {
                //                baseSqlTmp = @"
                //select PROVINCE, CITY,  COUNTY, PROVINCE 省, CITY 市,COUNTY 县,{0}  from (
                //select guid,substr(xzqhcode,0,2)||'0000' PROVINCE,substr(xzqhcode,0,4)||'00' CITY, xzqhcode COUNTY,PROJECTID,'1' ISXH,ISBQBR,ISZLGC,ISZRZT,'XH' typename from tbl_xiaohao where 1=1  
                //union all
                //select guid,substr(PROVINCE,0,2)||'0000' PROVINCE,substr(county,0,4)||'00' CITY,county,PROJECTID,ISXH,'','','','DZ' typename  from tbl_hazardbasicinfo where 1=1  ) where 1=1 ";
                //                baseSqlTmp = @"
                //select PROVINCE, CITY,  COUNTY, PROVINCE 省, CITY 市,COUNTY 县,{0}  from (
                //select guid," + DbSqlFunctionHelper.SubString("xzqhcode", 0, 2) + "||'0000' PROVINCE," + DbSqlFunctionHelper.SubString("xzqhcode", 0, 4) + "||'00' CITY, xzqhcode COUNTY,PROJECTID,'1' ISXH,ISBQBR,ISZLGC,ISZRZT,'XH' typename from tbl_xiaohao where 1=1  union all select guid," + DbSqlFunctionHelper.SubString("PROVINCE", 0, 2) + "||'0000' PROVINCE," + DbSqlFunctionHelper.SubString("county", 0, 4) + "||'00' CITY,county,PROJECTID,ISXH,'','','','DZ' typename  from tbl_hazardbasicinfo where 1=1  ) where 1=1 ";
                baseSqlTmp = @"
select PROVINCE, CITY,  COUNTY, PROVINCE 省, CITY 市,COUNTY 县,{0}  from (
select guid,{1} PROVINCE,{2} CITY, xzqhcode COUNTY,PROJECTID,MODIFYTIME ,'1' ISXH,ISBQBR,ISZLGC,ISZRZT,'XH' typename from tbl_xiaohao where 1=1  union all select guid,{3} PROVINCE,{4} CITY,county,PROJECTID,MODIFYTIME ,ISXH,'','','','DZ' typename  from " + sqlFrom + " where 1=1  ) where 1=1 ";
            }
            // baseSqlTmp += " AND  PROVINCE LIKE '%" + queryJson["PROVINCE"].ToString() + "%' AND CITY LIKE '%" + queryJson["CITY"].ToString() + "%' AND COUNTY LIKE '%" + queryJson["COUNTY"].ToString() + "%'";
            if (queryJson["baseSql"] != null && !string.IsNullOrWhiteSpace(queryJson["baseSql"].ToString()))
            {
                baseSqlTmp = queryJson["baseSql"].ToString();
            }
            List<KeyValuePair<bool, string>> listParam1 = new List<KeyValuePair<bool, string>>();
            List<KeyValuePair<bool, string>> listParam2 = new List<KeyValuePair<bool, string>>();
            List<KeyValuePair<bool, string>> listParam3 = new List<KeyValuePair<bool, string>>();
            List<KeyValuePair<bool, string>> listParam4 = new List<KeyValuePair<bool, string>>();
            listParam1.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("xzqhcode", 0, 2)));
            listParam1.Add(new KeyValuePair<bool, string>(false, "0000"));
            listParam2.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("xzqhcode", 0, 4)));
            listParam2.Add(new KeyValuePair<bool, string>(false, "00"));
            listParam3.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("PROVINCE", 0, 2)));
            listParam3.Add(new KeyValuePair<bool, string>(false, "0000"));
            listParam4.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("county", 0, 4)));
            listParam4.Add(new KeyValuePair<bool, string>(false, "00"));


            if (dicList != null)
            {
                foreach (var item in dicList.Keys)
                {
                    List<DataItemDetailEntity> dicData = dicList[item];
                    string strWhere = string.Empty;
                    if (item.F_Description == "灾害点数(处)")
                    {
                        strWhere = " and typename='DZ' and (ISXH != '1' or ISXH is null)  ";
                    }
                    else
                    {
                        strWhere = " and typename='XH' ";
                    }
                    foreach (var item2 in dicData)
                    {
                        //baseSelectSql += string.Format(" CASE when {0}='{3}'  {4} then {1} ELSE  0 END \"{2}\",", item.F_ItemValue, item.F_ItemDetailId, item.F_Description + item2.F_ItemName, item2.F_ItemValue, strWhere);
                        baseSelectSql += string.Format(" CASE when  {0}='{3}'  {4} then {1} ELSE  0 END \"{2}\",", item.F_ItemValue, item.F_ItemDetailId, item.F_Description + item2.F_ItemName, item2.F_ItemValue, strWhere);
                    }
                }
            }
            return string.Format(baseSqlTmp, baseSelectSql.TrimEnd(','), DbSqlFunctionHelper.Concat(listParam1), DbSqlFunctionHelper.Concat(listParam2), DbSqlFunctionHelper.Concat(listParam3), DbSqlFunctionHelper.Concat(listParam4));
            //return string.Format(baseSqlTmp, baseSelectSql.TrimEnd(','));

        }
        private string GetWhereSqlByCondition(JObject queryJson)
        {
            string where = string.Empty;
            if (!queryJson["PROVINCE"].IsEmpty())
            {
                string[] strArr = queryJson["PROVINCE"].ToString().Split(',');
                where += string.Format(" and PROVINCE in('{0}') ", string.Join("','", strArr));
            }
            if (!queryJson["CITY"].IsEmpty())
            {
                string[] strArr = queryJson["CITY"].ToString().Split(',');
                where += string.Format(" and CITY in('{0}') ", string.Join("','", strArr));
            }
            if (!queryJson["COUNTY"].IsEmpty())
            {
                string[] strArr = queryJson["COUNTY"].ToString().Split(',');
                where += string.Format(" and COUNTY in('{0}') ", string.Join("','", strArr));
            }
            return where;
        }
        private string GetGroupSqlByCondition(JObject queryJson, ref List<MergedRegionEntity> columnList)
        {
            string StatisticstLevel = queryJson["StatisticsLevel"].ToString();
            string groupBySql = string.Empty;
            string orderSql = string.Empty;
            switch (StatisticstLevel)
            {
                case "省":
                    if (DbHelper.DbType == DatabaseType.MySql)
                    {
                        groupBySql = " group by a.省,PROVINCE ";
                        orderSql = " order by a.PROVINCE asc nulls first ";
                    }
                    else if (DbHelper.DbType == DatabaseType.SqlServer)
                    {
                        groupBySql = " group by rollup((a.省,PROVINCE) ";
                        orderSql = ") order by a.PROVINCE asc nulls first ";
                    }
                    else
                    {
                        groupBySql = " group by rollup((a.省,PROVINCE) ";
                        orderSql = ") order by a.PROVINCE asc nulls first ";
                    }

                    columnList.Add(new MergedRegionEntity() { columnName = "省", columnNameReplace = "省", rowFrom = 1, rowTo = 2, colFrom = 0, colTo = 0, GroupHeaderCount = 2 });
                    break;
                case "市":
                    if (DbHelper.DbType == DatabaseType.MySql)
                    {
                        groupBySql = " group by a.省,a.市 ";
                        orderSql = " order by a.CITY asc nulls first ";
                    }
                    else if (DbHelper.DbType == DatabaseType.SqlServer)
                    {
                        groupBySql = " group by rollup((a.省,PROVINCE),(a.市,CITY) ";
                        orderSql = ") order by a.CITY asc nulls first ";
                    }
                    else
                    {
                        groupBySql = " group by rollup((a.省,PROVINCE),(a.市,CITY) ";
                        orderSql = ") order by a.CITY asc nulls first ";
                    }
                    columnList.Add(new MergedRegionEntity() { columnName = "省", columnNameReplace = "省", rowFrom = 1, rowTo = 2, colFrom = 0, colTo = 0, GroupHeaderCount = 2 });
                    columnList.Add(new MergedRegionEntity() { columnName = "市", columnNameReplace = "市", rowFrom = 1, rowTo = 2, colFrom = 1, colTo = 1, GroupHeaderCount = 2 });
                    break;
                case "县":
                    if (DbHelper.DbType == DatabaseType.MySql)
                    {
                        groupBySql = " group by a.省,a.市,a.县";
                        orderSql = " order by a.CITY asc nulls first,a.COUNTY asc nulls first  ";
                    }
                    else if (DbHelper.DbType == DatabaseType.SqlServer)
                    {
                        groupBySql = " group by rollup((a.省,PROVINCE),(a.市,CITY) ,(a.县,COUNTY  )";
                        orderSql = ") order by a.CITY asc nulls first,a.COUNTY asc nulls first  ";
                    }
                    else
                    {
                        groupBySql = " group by rollup((a.省,PROVINCE),(a.市,CITY),(a.县,COUNTY  )";
                        orderSql = ") order by a.CITY asc nulls first,a.COUNTY asc nulls first  ";
                    }
                    columnList.Add(new MergedRegionEntity() { columnName = "省", columnNameReplace = "省", rowFrom = 1, rowTo = 2, colFrom = 0, colTo = 0, GroupHeaderCount = 2 });
                    columnList.Add(new MergedRegionEntity() { columnName = "市", columnNameReplace = "市", rowFrom = 1, rowTo = 2, colFrom = 1, colTo = 1, GroupHeaderCount = 2 });
                    columnList.Add(new MergedRegionEntity() { columnName = "县", columnNameReplace = "县", rowFrom = 1, rowTo = 2, colFrom = 2, colTo = 2, GroupHeaderCount = 2 });
                    break;
            }
            return " " + groupBySql + orderSql;
        }
        private string GetSelectSql(JObject queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList, ref List<MergedRegionEntity> columnList)
        {
            string districtLevel = queryJson["StatisticsLevel"].ToString();
            string strHJ = "新增点";
            string sql = string.Empty;
            switch (districtLevel)
            {
                case "省":
                    sql += " 省,";
                    break;
                case "市":
                    sql += " 省,市,";
                    break;
                case "县":
                    sql += " 省,市,县,";
                    break;
            }
            if (dicList != null)
            {
                int infFlag = columnList.Max(p => p.colTo) + 1;
                foreach (var item in dicList.Keys)
                {
                    List<DataItemDetailEntity> dicData = dicList[item];
                    int columnCount = dicData.Count;
                    columnList.Add(new MergedRegionEntity() { columnName = item.F_Description, columnNameReplace = item.F_Description, rowFrom = 1, rowTo = 1, colFrom = infFlag, colTo = infFlag + columnCount, GroupHeaderCount = 1 });
                    foreach (var item2 in dicData)
                    {
                        sql += string.Format(" SUM(\"{0}\") \"{0}\",", item.F_Description + item2.F_ItemName);
                        columnList.Add(new MergedRegionEntity() { columnName = item.F_Description + item2.F_ItemName, columnNameReplace = item2.F_ItemName, rowFrom = 2, rowTo = 2, colFrom = infFlag, colTo = infFlag, GroupHeaderCount = 1 });
                        infFlag++;
                    }
                    //sql += string.Format(" SUM(decode({0},null,0,{0})) \"{1}\",", string.Join("-", dicData.Select(p => "\"" + item.F_Description + p.F_ItemName + "\"").ToArray()), item.F_Description + strHJ);
                    sql += string.Format(" SUM(case when {0}=null then 0 else {0} end) \"{1}\",", string.Join("-", dicData.Select(p => "\"" + item.F_Description + p.F_ItemName + "\"").ToArray()), item.F_Description + strHJ);
                    columnList.Add(new MergedRegionEntity() { columnName = item.F_Description + strHJ, columnNameReplace = strHJ, rowFrom = 2, rowTo = 2, colFrom = infFlag, colTo = infFlag, GroupHeaderCount = 1 });
                    infFlag++;
                }
            }
            return sql.TrimEnd(',');
        }
        #endregion

        #region 隐患点规模趋势
        public DataTable QueryStatistics_yhdgmqs(string queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList, ref List<MergedRegionEntity> columnList)
        {
            var queryParam = queryJson.ToJObject();
            string baseSql = GetBaseSql_yhdgmqs(queryParam, dicList);
            //baseSql += GetWhereSqlByCondition_yhdgmqs(queryParam);
            string groupSql = GetGroupSqlByCondition_yhdgmqs(queryParam, ref columnList);
            string sqlTmp = "select  {0} from( " + baseSql + ") a" + groupSql;
            string selectSql = GetSelectSql_yhdgmqs(queryParam, dicList, ref columnList);
            string sql = string.Format(sqlTmp, selectSql);

            DataTable result = this.BaseRepository().FindTable(sql);
            if (result.Rows.Count > 0)
            {
                DataRow dr = result.NewRow();
                dr.ItemArray = result.Rows[0].ItemArray;
                dr[0] = "合计（处）";
                result.Rows.RemoveAt(0);
                result.Rows.InsertAt(dr, result.Rows.Count);

                decimal total = dr[result.Columns.Count - 1].ToDecimal();
                
                DataRow addDr = result.NewRow();
                addDr[0] = "规模比例";
                for (int i = 1; i < result.Columns.Count; i++)
                {
                    if (total == 0)
                    {
                        addDr[i] = 0;
                    }
                    else {
                        addDr[i] = (dr[i].ToDecimal() / total * 100).ToDecimal(2);
                    }
                }
                result.Rows.InsertAt(addDr, result.Rows.Count);
                int infFlag = columnList.Max(p => p.colTo) + 1;
                columnList.Add(new MergedRegionEntity() { columnName = "灾害类型比例（%）", columnNameReplace = "灾害类型比例（%）", rowFrom = 1, rowTo = 2, colFrom = infFlag, colTo = infFlag, GroupHeaderCount = 2 });
                result.Columns.Add("灾害类型比例（%）");
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    if (i != result.Rows.Count - 1)
                    {
                        decimal hjColumn = result.Rows[i][result.Columns.Count - 2].ToDecimal();
                        if (total == 0)
                        {
                            result.Rows[i][result.Columns.Count - 1]= 0;
                        }
                        else
                        {
                            result.Rows[i][result.Columns.Count - 1] = (hjColumn / total * 100).ToDecimal(2);
                        }
                    }
                }
            }
            result.TableName = "统计分析";
            return result;
        }
        private string GetBaseSql_yhdgmqs(JObject queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList)
        {
            string baseSelectSql = "";
            var baseSql = GetWhereSqlByCondition(queryJson);
            string baseSqlTmp = @"select 灾害类型,type,{0} from( 
select SCALELEVEL  ,'崩塌' 灾害类型,'1' type from tbl_avalanche where 1=1 {1}
union all
select SCALELEVEL  ,'滑坡' 灾害类型,'2' type from tbl_landslip where 1=1 {1}
union all
select  DANGERLEVEL,'泥石流' 灾害类型,'3' type from tbl_debrisflow where 1=1 {1}
union all
select  SCALELEVEL,'不稳定斜坡' 灾害类型,'4' type from TBL_SLOPE where 1=1 {1}
union all
select  SCALELEVEL,'地裂缝' 灾害类型,'5' type from TBL_LANDCRACK where 1=1 {1}
union all
select DANGERLEVEL,'岩溶塌陷' 灾害类型,'6' type	 from TBL_COLLAPSE where COLLAPSEGENETICTYPE ='A' {1}
union all
select DANGERLEVEL,'采空塌陷' 灾害类型,'7' type	 from TBL_COLLAPSE where COLLAPSEGENETICTYPE ='B' {1}
)";
            if (queryJson["baseSql"] != null && !string.IsNullOrWhiteSpace(queryJson["baseSql"].ToString()))
            {
                baseSqlTmp = queryJson["baseSql"].ToString();
            }
            if (dicList != null)
            {
                foreach (var item in dicList.Keys)
                {
                    List<DataItemDetailEntity> dicData = dicList[item];
                    foreach (var item2 in dicData)
                    {
                        baseSelectSql += string.Format(" CASE when {0}='{3}' then {1} ELSE  0 END \"{2}\",", item.F_ItemValue, item.F_ItemDetailId, item.F_Description + item2.F_ItemName, item2.F_ItemValue);
                    }
                }
            }
            return string.Format(baseSqlTmp, baseSelectSql.TrimEnd(','), GetWhereSqlByCondition_yhdgmqs(queryJson)+baseSql);

        }
        private string GetWhereSqlByCondition_yhdgmqs(JObject queryJson)
        {
            string where = string.Empty;
            if (!queryJson["CITY"].IsEmpty())
            {
                string[] strArr = queryJson["CITY"].ToString().Split(',');
                where += string.Format(" and CITY in('{0}') ", string.Join("','", strArr));
            }
            if (!queryJson["COUNTY"].IsEmpty())
            {
                string[] strArr = queryJson["COUNTY"].ToString().Split(',');
                where += string.Format(" and COUNTYCODE in('{0}') ", string.Join("','", strArr));
            }
            if (!queryJson["PROJECTID"].IsEmpty())
            {
                string value = queryJson["PROJECTID"].ToString();
                where += string.Format(" and PROJECTID ='{0}' ", value);
            }
            if (!queryJson["startYear"].IsEmpty())
            {
                int startYear = queryJson["startYear"].ToInt();
                JYGC_PROJECTBASEINFOEntity entity = this.BaseRepository().FindList<JYGC_PROJECTBASEINFOEntity>(p => p.YEAR <= startYear).OrderByDescending(p => p.YEAR).FirstOrDefault();
                if (entity != null)
                {
                    where += string.Format(" and PROJECTID ='{0}' ", entity.PROJECTGUID);
                }
            }
            return where;
        }
        private string GetGroupSqlByCondition_yhdgmqs(JObject queryJson, ref List<MergedRegionEntity> columnList)
        {
            string StatisticstLevel = queryJson["StatisticsLevel"].ToString();
            //string groupBySql = " group by rollup((灾害类型,type) ";
            string groupBySql = "";
            if (DbHelper.DbType == DatabaseType.MySql)
            {
                groupBySql = " group by 灾害类型,type ";
            }
            else if (DbHelper.DbType == DatabaseType.SqlServer)
            {
                groupBySql = " group by rollup((灾害类型,type) ";
            }
            else
            {
                groupBySql = " group by rollup((灾害类型,type) ";
            }
            string orderSql = ") order by a.type asc nulls first ";
            columnList.Add(new MergedRegionEntity() { columnName = "灾害类型", columnNameReplace = "灾害类型", rowFrom = 1, rowTo = 2, colFrom = 0, colTo = 0, GroupHeaderCount = 2 });
            return " " + groupBySql + orderSql;
        }
        private string GetSelectSql_yhdgmqs(JObject queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList, ref List<MergedRegionEntity> columnList)
        {
            string strHJ = "合计";
            string sql = " 灾害类型,";
            if (dicList != null)
            {
                int infFlag = columnList.Max(p => p.colTo) + 1;
                foreach (var item in dicList.Keys)
                {
                    List<DataItemDetailEntity> dicData = dicList[item];
                    int columnCount = dicData.Count;
                    columnList.Add(new MergedRegionEntity() { columnName = item.F_Description, columnNameReplace = item.F_Description, rowFrom = 1, rowTo = 1, colFrom = infFlag, colTo = infFlag + columnCount, GroupHeaderCount = 1 });
                    foreach (var item2 in dicData)
                    {
                        sql += string.Format(" SUM(\"{0}\") \"{0}\",", item.F_Description + item2.F_ItemName);
                        columnList.Add(new MergedRegionEntity() { columnName = item.F_Description + item2.F_ItemName, columnNameReplace = item2.F_ItemName, rowFrom = 2, rowTo = 2, colFrom = infFlag, colTo = infFlag, GroupHeaderCount = 1 });
                        infFlag++;
                    }
                    //sql += string.Format(" SUM(decode({0},null,0,{0})) \"{1}\",", string.Join("+", dicData.Select(p => "\"" + item.F_Description + p.F_ItemName + "\"").ToArray()), item.F_Description + strHJ);
                    sql += string.Format(" SUM(case when {0}=null then 0 else {0} end) \"{1}\",", string.Join("+", dicData.Select(p => "\"" + item.F_Description + p.F_ItemName + "\"").ToArray()), item.F_Description + strHJ);
                    columnList.Add(new MergedRegionEntity() { columnName = item.F_Description + strHJ, columnNameReplace = strHJ, rowFrom = 2, rowTo = 2, colFrom = infFlag, colTo = infFlag, GroupHeaderCount = 1 });
                    infFlag++;
                }
            }
            return sql.TrimEnd(',');
        }
        #endregion

        #region 拟销号点
        public DataTable GetList_NXHD(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            string where = string.Empty;
            if (!queryParam["PROVINCE"].IsEmpty())
            {
                string[] strArr = queryParam["PROVINCE"].ToString().Split(',');
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("A.UNIFIEDCODE", 0, 2)));
                listParam.Add(new KeyValuePair<bool, string>(false, "0000"));
                where += string.Format("  and  {0} in('" + string.Join("','", strArr.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam));
            } if (!queryParam["CITY"].IsEmpty())
            {
                string[] strArr = queryParam["CITY"].ToString().Split(',');
                //where += string.Format(" and  concat(substr(UNIFIEDCODE,0,4),'00') in('{0}') ", string.Join("','", strArr));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("A.UNIFIEDCODE", 0, 4)));
                listParam.Add(new KeyValuePair<bool, string>(false, "00"));
                where += string.Format("  and  {0} in('" + string.Join("','", strArr.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam));
            }
            if (!queryParam["COUNTY"].IsEmpty())
            {
                string[] strArr = queryParam["COUNTY"].ToString().Split(',');
                //where += string.Format(" and  concat(substr(UNIFIEDCODE,0,6),'') in('{0}') ", string.Join("','", strArr));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("A.UNIFIEDCODE", 0, 6)));
                listParam.Add(new KeyValuePair<bool, string>(false, ""));
                where += string.Format("  and  {0} in('" + string.Join("','", strArr.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam));
            }
            if (!queryParam["startYear"].IsEmpty())
            {
                int startYear = queryParam["startYear"].ToInt();
                JYGC_PROJECTBASEINFOEntity entity = this.BaseRepository().FindList<JYGC_PROJECTBASEINFOEntity>(p => p.YEAR <= startYear).OrderByDescending(p => p.YEAR).FirstOrDefault();
                if (entity != null)
                {
                    where += string.Format(" and PROJECTID ='{0}' ", entity.PROJECTGUID);
                }
            }
            //            string sql = @"select a.DISASTERNAME,a.OUTDOORCODE,a.LOCATION,a.DISASTERTYPE,decode(ISZLGC,1,'已治理,','')||decode(ISBQBR,1,'已搬迁,','') ZLGCLY,replace(decode(ISZLGC,1,to_char(b.GIVETIME,'yyyy-MM-dd')||',','')||decode(ISBQBR,1,to_char(c.SCATTEREDRESETTLEMENTTIME,'yyyy-MM-dd')||',',''),',','') ZLGCSJ,decode(ISZLGC,1,b.ISSUEDCAPITAL,'') ZLPTZJ
            // from  tbl_xiaohao a
            //left join tbl_zlgc_baseinfo b on a.unifiedcode=b.UNIFIEDCODE left join tbl_bqbr c  on a.unifiedcode=c.UNIFIEDCODE";
            //string sql = @"select a.DISASTERNAME,a.OUTDOORCODE,a.LOCATION,a.DISASTERTYPE,decode(ISZLGC,1,'已治理,','')||decode(ISBQBR,1,'已搬迁,','') ZLGCLY,replace(decode(ISZLGC,1," + DbSqlFunctionHelper.DateToChar("b.GIVETIME", "yyyy-MM-dd") + "||',','')||decode(ISBQBR,1," + DbSqlFunctionHelper.DateToChar("c.SCATTEREDRESETTLEMENTTIME", "yyyy-MM-dd") + "||',',''),',','') ZLGCSJ,decode(ISZLGC,1,b.ISSUEDCAPITAL,'') ZLPTZJ from  tbl_xiaohao a left join tbl_zlgc_baseinfo b on a.unifiedcode=b.UNIFIEDCODE left join tbl_bqbr c  on a.unifiedcode=c.UNIFIEDCODE";
            //string sql = @"select a.DISASTERNAME,a.OUTDOORCODE,a.LOCATION,a.DISASTERTYPE,case when ISZLGC=1 then '已治理,' else '' end||case when ISBQBR=1 then '已搬迁,' else '' end ZLGCLY,replace(case when ISZLGC=1 then " + DbSqlFunctionHelper.DateToChar("b.GIVETIME", "yyyy-MM-dd") + "|| ',' ELSE '' END || CASE	WHEN ISBQBR = 1 THEN " + DbSqlFunctionHelper.DateToChar("c.SCATTEREDRESETTLEMENTTIME", "yyyy-MM-dd") + "|| ','ELSE''	END,',','') ZLGCSJ,case when ISZLGC=1 then b.ISSUEDCAPITAL else 0 end ZLPTZJ from  tbl_xiaohao a left join tbl_zlgc_baseinfo b on a.unifiedcode=b.UNIFIEDCODE left join tbl_bqbr c  on a.unifiedcode=c.UNIFIEDCODE";
            string sql = @"select a.DISASTERNAME,a.OUTDOORCODE,a.LOCATION,a.DISASTERTYPE,{0} ZLGCLY,
replace( {1}) ZLGCSJ,case when ISZLGC=1 then b.ISSUEDCAPITAL else 0 end ZLPTZJ from  tbl_xiaohao a left join tbl_zlgc_baseinfo b on a.unifiedcode=b.UNIFIEDCODE left join tbl_bqbr c  on a.unifiedcode=c.UNIFIEDCODE where 1=1 "+where;

            List<KeyValuePair<bool, string>> listParam1 = new List<KeyValuePair<bool, string>>();
            List<KeyValuePair<bool, string>> listParam2 = new List<KeyValuePair<bool, string>>();
            listParam1.Add(new KeyValuePair<bool, string>(true, " case when ISZLGC=1 then '已治理,' else '' end "));
            listParam1.Add(new KeyValuePair<bool, string>(true, " case when ISBQBR=1 then '已搬迁,' else '' end "));
            listParam2.Add(new KeyValuePair<bool, string>(true, "case when ISZLGC=1 then " + DbSqlFunctionHelper.DateToChar("b.GIVETIME", "yyyy-MM-dd")));
            listParam2.Add(new KeyValuePair<bool, string>(true, " ',' ELSE '' END "));
            listParam2.Add(new KeyValuePair<bool, string>(true, " CASE	WHEN ISBQBR = 1 THEN " + DbSqlFunctionHelper.DateToChar("c.SCATTEREDRESETTLEMENTTIME", "yyyy-MM-dd")));
            listParam2.Add(new KeyValuePair<bool, string>(true, " ','ELSE''	END,',',''"));
            sql = string.Format(sql, DbSqlFunctionHelper.Concat(listParam1), DbSqlFunctionHelper.Concat(listParam2));

            DataTable result = this.BaseRepository().FindTable(sql);
            return result;
        }
        #endregion

        #region 灾情、详情、规模等级对比
        public DataTable QueryStatistics_ZQXQGM(string queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList, ref List<MergedRegionEntity> columnList)
        {
            var queryParam = queryJson.ToJObject();
            string baseSql = GetBaseSql_ZQXQGM(queryParam, dicList);
            baseSql += GetWhereSqlByCondition_ZQXQGM(queryParam);
            string groupSql = GetGroupSqlByCondition_ZQXQGM(queryParam, ref columnList);
            //string sqlTmp = "select  {0} from( " + baseSql + ") a" + groupSql;
            string sqlTmp = string.Empty;
            string selectSql = GetSelectSql_ZQXQGM(queryParam, dicList, ref columnList);
            if (DbHelper.DbType == DatabaseType.Oracle)
            {
                sqlTmp = "select listagg(to_char(DISASTERNAME) ,',') within group (order by DISASTERNAME) DISASTERNAME,{0} from( " + baseSql + ") a" + groupSql;
            }
            else if (DbHelper.DbType == DatabaseType.SqlServer)
            {
                sqlTmp = "select stuff((select ','+ concat(DISASTERNAME,''),{0} from(" + baseSql + ") t1 where t1.UNIFIEDCODE=t2.UNIFIEDCODE for xml path('')),1,len(','),'') DISASTERNAME from (" + baseSql + ") t2 " + groupSql + "";
            }
            else if (DbHelper.DbType == DatabaseType.MySql)
            {
                sqlTmp = "select group_concat(concat(DISASTERNAME,',') separator ',') DISASTERNAME,{0} from( " + baseSql + ") a " + groupSql + "";
            }
            string sql = string.Format(sqlTmp, selectSql);

            DataTable result = this.BaseRepository().FindTable(sql);
            DataTableCL(result);
            result.TableName = "统计分析";
            return result;
        }
        private string GetBaseSql_ZQXQGM(JObject queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList)
        {
            string baseSelectSql = "";
//            string baseSqlTmp = @"select a.DISASTERNAME,a.UNIFIEDCODE,PROVINCE, CITY,  COUNTY, PROVINCENAME 省, CITYNAME 市,COUNTYNAME 县, TOWNNAME 乡镇,{0}  from  tbl_hazardbasicinfo a 
//left join tbl_xiaohao b on a.UNIFIEDCODE=b.UNIFIEDCODE
//where a.PROJECTID is not null and (a.ISXH !='1' or  a.ISXH is null) ";
            var sqlFrom = "(SELECT	aa.*FROM	TBL_HAZARDBASICINFO_HISTORY aa INNER JOIN (	SELECT  UNIFIEDCODE, MAX (MODIFYTIME) MODIFYTIME FROM TBL_HAZARDBASICINFO_HISTORY WHERE " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy") + " ='" + queryJson["startYear"].ToString() + "' GROUP BY UNIFIEDCODE UNION ALL SELECT UNIFIEDCODE, MAX (MODIFYTIME) MODIFYTIME	FROM TBL_HAZARDBASICINFO_HISTORY	WHERE " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy") + " ='" + queryJson["endYear"].ToString() + "' GROUP BY UNIFIEDCODE ) bb ON AA.UNIFIEDCODE = BB.UNIFIEDCODE AND AA.MODIFYTIME = BB.MODIFYTIME)"; 
            string baseSqlTmp = @"select a.DISASTERNAME,a.UNIFIEDCODE,PROVINCE, CITY,  COUNTY, PROVINCENAME 省, CITYNAME 市,COUNTYNAME 县, TOWNNAME 乡镇,{0}  from  "+sqlFrom+" a where 1=1 and (a.ISXH !='1' or  a.ISXH is null) ";
            baseSqlTmp += GetWhereSqlByCondition(queryJson);
            if (queryJson["baseSql"] != null && !string.IsNullOrWhiteSpace(queryJson["baseSql"].ToString()))
            {
                baseSqlTmp = queryJson["baseSql"].ToString();
            }
            if (dicList != null)
            {
                foreach (var item in dicList.Keys)
                {
                    List<DataItemDetailEntity> dicData = dicList[item];
                    foreach (var item2 in dicData)
                    {
                        //baseSelectSql += string.Format(" CASE when {0}='{3}' then {1} ELSE  '' END \"{2}\",", item.F_ItemValue, item.F_ItemDetailId, item.F_Description + item2.F_ItemName, item2.F_ItemValue);
                        baseSelectSql += string.Format(" CASE when {0}='{3}' then {1} ELSE  '' END \"{2}\",", item.F_ItemValue, item.F_ItemDetailId, item.F_Description + item2.F_ItemName, item2.F_ItemValue);
                    }
                }
            }
            return string.Format(baseSqlTmp, baseSelectSql.TrimEnd(','));

        }
        private string GetWhereSqlByCondition_ZQXQGM(JObject queryJson)
        {
            string where = string.Empty;
            if (!queryJson["CITY"].IsEmpty())
            {
                string[] strArr = queryJson["CITY"].ToString().Split(',');
                where += string.Format(" and CITY in('{0}') ", string.Join("','", strArr));
            }
            if (!queryJson["COUNTY"].IsEmpty())
            {
                string[] strArr = queryJson["COUNTY"].ToString().Split(',');
                where += string.Format(" and COUNTY in('{0}') ", string.Join("','", strArr));
            }
            return where;
        }
        private string GetGroupSqlByCondition_ZQXQGM(JObject queryJson, ref List<MergedRegionEntity> columnList)
        {
            return " group by  UNIFIEDCODE order by UNIFIEDCODE";
        }
        private string GetSelectSql_ZQXQGM(JObject queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList, ref List<MergedRegionEntity> columnList)
        {
            string sql = string.Empty;
            //sql += " listagg(to_char(DISASTERNAME) ,',') within group (order by DISASTERNAME) DISASTERNAME, ";
            columnList = new List<MergedRegionEntity>() { new MergedRegionEntity() { columnName = "disastername", columnNameReplace = "名称", rowFrom = 1, rowTo = 2, colFrom = 0, colTo = 0, GroupHeaderCount = 2 } };
            if (dicList != null)
            {
                int infFlag = columnList.Max(p => p.colTo) + 1;
                foreach (var item in dicList.Keys)
                {
                    List<DataItemDetailEntity> dicData = dicList[item];
                    int columnCount = dicData.Count - 1;
                    columnList.Add(new MergedRegionEntity() { columnName = item.F_Description, columnNameReplace = item.F_Description, rowFrom = 1, rowTo = 1, colFrom = infFlag, colTo = infFlag + columnCount, GroupHeaderCount = 2 });
                    foreach (var item2 in dicData)
                    {
                        sql += string.Format(" max(\"{0}\") \"{0}\",", item.F_Description + item2.F_ItemName);
                        columnList.Add(new MergedRegionEntity() { columnName = item.F_Description + item2.F_ItemName, columnNameReplace = item2.F_ItemName, rowFrom = 2, rowTo = 2, colFrom = infFlag, colTo = infFlag, GroupHeaderCount = 2 });
                        infFlag++;
                    }
                }
            }
            return sql.TrimEnd(',');
        }
        /// <summary>
        /// 相同名称处理
        /// </summary>
        /// <param name="result"></param>
        public void DataTableCL(DataTable result)
        {
            foreach (DataRow item in result.Rows)
            {
                if (result.Columns.Contains("DISASTERNAME") && !item["DISASTERNAME"].IsEmpty())
                {
                    string[] strArr = item["DISASTERNAME"].ToString().Split(',');
                    if (strArr.Length > 1 && strArr[0].Trim() == strArr[1].Trim())
                    {
                        item["DISASTERNAME"] = strArr[0];
                    }
                }
            }
        }
        #endregion

        #region 灾害类型及规模趋势
        public DataTable QueryStatistics_zhlxjgmqs(string queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList, ref List<MergedRegionEntity> columnList)
        {
            var queryParam = queryJson.ToJObject();
            string baseSql = GetBaseSql_zhlxjgmqs(queryParam, dicList);
            baseSql += GetWhereSqlByCondition_zhlxjgmqs(queryParam);
            baseSql += GetWhereSqlByCondition(queryParam);
            string groupSql = GetGroupSqlByCondition_zhlxjgmqs(queryParam, ref columnList);
            string sqlTmp = "select  {0} from( " + baseSql + ") a" + groupSql;
            string selectSql = GetSelectSql_zhlxjgmqs(queryParam, dicList, ref columnList);
            string sql = string.Format(sqlTmp, selectSql);

            DataTable result = this.BaseRepository().FindTable(sql);
            result = HJDataTable(result);
            result.TableName = "统计分析";
            return result;
        }
        private DataTable HJDataTable(DataTable result)
        {
            DataTable returnValue = result.Clone();
            int intCount = 0;
            Dictionary<string, int> XMData = new Dictionary<string, int>();
            foreach (DataRow item in result.Rows)
            {
                string columnValue = item[0].ToString();
                if (XMData.Keys.Count == 0)
                {
                    XMData.Add(columnValue, 0);
                }
                if (XMData.Last().Key != columnValue)
                {
                    XMData[XMData.Last().Key] = intCount;
                    XMData.Add(columnValue, 0);
                    intCount = 0;
                }
                else
                {
                    intCount += item[result.Columns.Count - 2].ToInt();
                }
            }
            foreach (DataRow item in result.Rows)
            {
                string columnValue = item[0].ToString();

                foreach (string itemKey in XMData.Keys)
                {
                    if (columnValue == itemKey)
                    {
                        item[result.Columns.Count - 1] = XMData[itemKey];
                        returnValue.Rows.Add(item.ItemArray);
                        break;
                    }
                }
            }
            return returnValue;
        }
        private string GetBaseSql_zhlxjgmqs(JObject queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList)
        {
            string baseSelectSql = "";
            //            string baseSqlTmp = @"select  decode(b.year,null,'',b.year||'年') year,PROVINCE, CITY,  COUNTY, PROVINCENAME 省, CITYNAME 市,COUNTYNAME 县, TOWNNAME 乡镇,{0}  from  tbl_hazardbasicinfo a 
            // left join JYGC_PROJECTBASEINFO b on a.projectid=b.projectguid
            //where a.PROJECTID is not null and (a.ISXH !='1' or  a.ISXH is null) ";
            //            string baseSqlTmp = @"select  case when b.year=null then'' else b.year  ||'年' end year,PROVINCE, CITY,  COUNTY, PROVINCENAME 省, CITYNAME 市,COUNTYNAME 县, TOWNNAME 乡镇,{0}  from  tbl_hazardbasicinfo a 
            // left join JYGC_PROJECTBASEINFO b on a.projectid=b.projectguid
            //where a.PROJECTID is not null and (a.ISXH !='1' or  a.ISXH is null) ";
//            string baseSqlTmp = @"select  {1},PROVINCE, CITY,  COUNTY, PROVINCENAME 省, CITYNAME 市,COUNTYNAME 县, TOWNNAME 乡镇,{0}  from  tbl_hazardbasicinfo a 
// left join JYGC_PROJECTBASEINFO b on a.projectid=b.projectguid
//where a.PROJECTID is not null and (a.ISXH !='1' or  a.ISXH is null) ";
            var sqlFrom = "(SELECT	aa.*FROM	TBL_HAZARDBASICINFO_HISTORY aa INNER JOIN (	SELECT  UNIFIEDCODE, MAX (MODIFYTIME) MODIFYTIME FROM TBL_HAZARDBASICINFO_HISTORY WHERE " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy") + " ='" + queryJson["startYear"].ToString() + "' GROUP BY UNIFIEDCODE UNION ALL SELECT UNIFIEDCODE, MAX (MODIFYTIME) MODIFYTIME	FROM TBL_HAZARDBASICINFO_HISTORY	WHERE " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy") + " ='" + queryJson["endYear"].ToString() + "' GROUP BY UNIFIEDCODE ) bb ON AA.UNIFIEDCODE = BB.UNIFIEDCODE AND AA.MODIFYTIME = BB.MODIFYTIME)"; 
            string baseSqlTmp = @"select  {1},PROVINCE, CITY,  COUNTY, PROVINCENAME 省, CITYNAME 市,COUNTYNAME 县, TOWNNAME 乡镇,{0}  from  "+sqlFrom+" a where  (a.ISXH !='1' or  a.ISXH is null) ";
            List<KeyValuePair<bool, string>> listParam1 = new List<KeyValuePair<bool, string>>();
            //listParam1.Add(new KeyValuePair<bool, string>(true, " case when b.year=null then'' else b.year "));
            listParam1.Add(new KeyValuePair<bool, string>(true, " case when " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy") + "=null then'' else " + DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy")));
            listParam1.Add(new KeyValuePair<bool, string>(true, "'年' end year"));

            if (queryJson["baseSql"] != null && !string.IsNullOrWhiteSpace(queryJson["baseSql"].ToString()))
            {
                baseSqlTmp = queryJson["baseSql"].ToString();
            }
            if (dicList != null)
            {
                foreach (var item in dicList.Keys)
                {
                    List<DataItemDetailEntity> dicData = dicList[item];
                    foreach (var item2 in dicData)
                    {
                        baseSelectSql += string.Format(" CASE when {0}='{3}' {4} then {1} ELSE  0 END \"{2}\",", item.F_ItemValue, item.F_ItemDetailId, item.F_Description + item2.F_ItemName, item2.F_ItemValue, item.F_ModifyUserName);
                    }
                }
            }
            return string.Format(baseSqlTmp, baseSelectSql.TrimEnd(','), DbSqlFunctionHelper.Concat(listParam1));

        }
        private string GetWhereSqlByCondition_zhlxjgmqs(JObject queryJson)
        {
            string where = string.Empty;
            if (!queryJson["CITY"].IsEmpty())
            {
                string[] strArr = queryJson["CITY"].ToString().Split(',');
                where += string.Format(" and CITY in('{0}') ", string.Join("','", strArr));
            }
            if (!queryJson["COUNTY"].IsEmpty())
            {
                string[] strArr = queryJson["COUNTY"].ToString().Split(',');
                where += string.Format(" and COUNTY in('{0}') ", string.Join("','", strArr));
            }
            JYGC_PROJECTBASEINFOIService projectService = new JYGC_PROJECTBASEINFOService();
            List<string> list = projectService.GetListByDateDiff(queryJson.ToJson()).Select(p => p.PROJECTGUID).ToList();
            //if (list.Count > 0)
            //{
            //    where += string.Format(" and a.PROJECTID in('{0}') ", string.Join("','", list));
            //}
            return where;
        }
        private string GetGroupSqlByCondition_zhlxjgmqs(JObject queryJson, ref List<MergedRegionEntity> columnList)
        {
            string StatisticstLevel = queryJson["StatisticsLevel"].ToString();
            string groupBySql = string.Empty;
            string orderSql = string.Empty;
            switch (StatisticstLevel)
            {
                case "省":
                    groupBySql = " group by year,(a.省,PROVINCE) ";
                    orderSql = "order by year desc,a.PROVINCE asc nulls first ";
                    columnList.Add(new MergedRegionEntity() { columnName = "year", columnNameReplace = "项目", rowFrom = 1, rowTo = 2, colFrom = 0, colTo = 0, GroupHeaderCount = 2 });
                    columnList.Add(new MergedRegionEntity() { columnName = "省", columnNameReplace = "省", rowFrom = 1, rowTo = 2, colFrom = 1, colTo = 1, GroupHeaderCount = 2 });
                    break;
                case "市":
                    groupBySql = " group by year,(a.省,PROVINCE),(a.市,CITY) ";
                    orderSql = " order by year desc,a.CITY asc nulls first  ";
                    columnList.Add(new MergedRegionEntity() { columnName = "year", columnNameReplace = "项目", rowFrom = 1, rowTo = 2, colFrom = 0, colTo = 0, GroupHeaderCount = 2 });
                    columnList.Add(new MergedRegionEntity() { columnName = "市", columnNameReplace = "市", rowFrom = 1, rowTo = 2, colFrom = 1, colTo = 1, GroupHeaderCount = 2 });
                    break;
                case "县":
                    groupBySql = " group by  year,(a.省,PROVINCE),(a.市,CITY),(a.县,COUNTY  )";
                    orderSql = " order by year desc,a.CITY asc nulls first,a.COUNTY asc nulls first  ";
                    columnList.Add(new MergedRegionEntity() { columnName = "year", columnNameReplace = "项目", rowFrom = 1, rowTo = 2, colFrom = 0, colTo = 0, GroupHeaderCount = 2 });
                    columnList.Add(new MergedRegionEntity() { columnName = "县", columnNameReplace = "县", rowFrom = 1, rowTo = 2, colFrom = 1, colTo = 1, GroupHeaderCount = 2 });
                    break;
            }
            return " " + groupBySql + orderSql;
        }
        private string GetSelectSql_zhlxjgmqs(JObject queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList, ref List<MergedRegionEntity> columnList)
        {
            string districtLevel = queryJson["StatisticsLevel"].ToString();
            string strHJ = "新增点";
            string sql = string.Empty;
            switch (districtLevel)
            {
                case "省":
                    sql += "year,省,";
                    break;
                case "市":
                    sql += " year,市,";
                    break;
                case "县":
                    sql += " year,县,";
                    break;
            }
            if (dicList != null)
            {
                string hjColumn = "";
                int infFlag = columnList.Max(p => p.colTo) + 1;
                foreach (var item in dicList.Keys)
                {
                    List<DataItemDetailEntity> dicData = dicList[item];
                    int columnCount = dicData.Count - 1;
                    columnList.Add(new MergedRegionEntity() { columnName = item.F_Description, columnNameReplace = item.F_Description, rowFrom = 1, rowTo = 1, colFrom = infFlag, colTo = infFlag + columnCount, GroupHeaderCount = 1 });
                    foreach (var item2 in dicData)
                    {
                        sql += string.Format(" SUM(\"{0}\") \"{0}\",", item.F_Description + item2.F_ItemName);
                        columnList.Add(new MergedRegionEntity() { columnName = item.F_Description + item2.F_ItemName, columnNameReplace = item2.F_ItemName, rowFrom = 2, rowTo = 2, colFrom = infFlag, colTo = infFlag, GroupHeaderCount = 1 });
                        hjColumn += string.Format(" \"{0}\" +", item.F_Description + item2.F_ItemName);
                        infFlag++;
                    }
                }
                sql += string.Format(" SUM({0}) \"{1}\",", hjColumn.TrimEnd('+'), "合计市县区");
                sql += string.Format(" '' \"{0}\",", "合计" + districtLevel + "级");
                columnList.Add(new MergedRegionEntity() { columnName = "合计", columnNameReplace = "合计", rowFrom = 1, rowTo = 1, colFrom = infFlag, colTo = infFlag + 1, GroupHeaderCount = 1 });
                columnList.Add(new MergedRegionEntity() { columnName = "合计市县区", columnNameReplace = "市县区", rowFrom = 2, rowTo = 2, colFrom = infFlag, colTo = infFlag, GroupHeaderCount = 1 });
                columnList.Add(new MergedRegionEntity() { columnName = "合计" + districtLevel + "级", columnNameReplace = districtLevel + "级", rowFrom = 2, rowTo = 2, colFrom = infFlag + 1, colTo = infFlag + 1, GroupHeaderCount = 1 });
            }
            return sql.TrimEnd(',');
        }
        #endregion
    }
}
