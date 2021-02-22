using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Application.IService.MONITORPOINT;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Application.Entity;
using iTelluro.Busness.WebApiProxy;
using System;
using Infoearth.Data.Extension;
using Infoearth.Data;

namespace Infoearth.Application.Service.MONITORPOINT
{
    /// <summary>
    /// �� �� Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-26 16:55
    /// �� ������������������
    /// </summary>
    public class TBL_DMCJ_MONITORDATAService : RepositoryFactory<TBL_DMCJ_MONITORDATAEntity>, TBL_DMCJ_MONITORDATAIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_DMCJ_MONITORDATAQuery> GetPageList(Pagination pagination, string queryJson)
        {
            string sql = @"select b.monitorpointname,a.* from tbl_dmcj_monitordata a
left join TBL_DMCJ_MONITORPOINT b on a.monitorpointid=b.monitorpointid where 1=1 " + GetWhere(queryJson);
            return new RepositoryFactory().BaseRepository().FindList<TBL_DMCJ_MONITORDATAQuery>(sql, pagination);
        }
        private string GetWhere(string queryJson)
        {
            StringBuilder sbWhere = new StringBuilder();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["MIXTURE"].IsEmpty())
            {
                string value = queryParam["MIXTURE"].ToString();
                sbWhere.AppendFormat("and (b.MONITORPOINTNAME like '%{0}%' or b.MONITORPOINTID like '%{0}%') ", value);
            }
            //���ʱ��starttime
            if (!queryParam["STARTTIME"].IsEmpty())
            {
                string value = queryParam["STARTTIME"].ToString();
                sbWhere.AppendFormat("and extract (YEAR from monitortime) = '{0}'", value);
            }
            //if (!queryParam["ENDTIME"].IsEmpty())
            //{
            //    DateTime value = queryParam["ENDTIME"].ToDate().AddHours(23).AddMinutes(59).AddSeconds(59);
            //    sbWhere.AppendFormat("and a.MONITORTIME <= {0}", DbTimeType.DateTimeToDbTimeType(value, DbHelper.DbType));
            //}
            //��������
            if (!queryParam["COUNTY"].IsEmpty())
            {
                string[] strArr = queryParam["COUNTY"].ToString().Split(',');
                //sbWhere.AppendFormat("  and  concat(substr(b.AREACODE,0,6),'') in('{0}') ", string.Join("','", strArr.ToArray()));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("b.AREACODE", 0, 6)));
                listParam.Add(new KeyValuePair<bool, string>(false, ""));
                sbWhere.Append(string.Format("  and  {0} in('" + string.Join("','", strArr.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam)));
            }
            else if (!queryParam["CITY"].IsEmpty())
            {
                string[] strArr = queryParam["CITY"].ToString().Split(',');
                //sbWhere.AppendFormat("  and  concat(substr(b.AREACODE,0,4),'00') in('{0}') ", string.Join("','", strArr.ToArray()));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("b.AREACODE", 0, 4)));
                listParam.Add(new KeyValuePair<bool, string>(false, "00"));
                sbWhere.Append(string.Format("  and  {0} in('" + string.Join("','", strArr.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam)));
            }
            else if (!queryParam["PROVINCE"].IsEmpty())
            {
                string[] strArr = queryParam["PROVINCE"].ToString().Split(',');
                //sbWhere.AppendFormat("  and  concat(substr(b.AREACODE,0,2),'0000') in('{0}') ", string.Join("','", strArr.ToArray()));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("b.AREACODE", 0, 2)));
                listParam.Add(new KeyValuePair<bool, string>(false, "0000"));
                sbWhere.Append(string.Format("  and  {0} in('" + string.Join("','", strArr.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam)));
            }
            return sbWhere.ToString();
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_DMCJ_MONITORDATAQuery> GetList(string queryJson)
        {
            string sql=@"select b.monitorpointname,a.* from tbl_dmcj_monitordata a
left join TBL_DMCJ_MONITORPOINT b on a.monitorpointid=b.monitorpointid where 1=1 " + GetWhere(queryJson);
            return new RepositoryFactory().BaseRepository().FindList<TBL_DMCJ_MONITORDATAQuery>(sql);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_DMCJ_MONITORDATAEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void DeleteEntity(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, TBL_DMCJ_MONITORDATAEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion

        /// <summary>
        /// �������ͳ��
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetQueryList(string queryJson)
        {
            DataTable returnValue = new DataTable();
            var queryParam = queryJson.ToJObject();
            StringBuilder sbWhere = new StringBuilder();
            StringBuilder selectColumn = new StringBuilder();
            StringBuilder sumColumn = new StringBuilder();
            //��������
            if (!queryParam["COUNTY"].IsEmpty())
            {
                string[] strArr = queryParam["COUNTY"].ToString().Split(',');
                //sbWhere.AppendFormat("  and  concat(substr(a.AREACODE,0,6),'') in('{0}') ", string.Join("','", strArr.ToArray()));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("a.AREACODE", 0, 6)));
                listParam.Add(new KeyValuePair<bool, string>(false, ""));
                sbWhere.Append(string.Format("  and  {0} in('" + string.Join("','", strArr.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam)));
            }
            else if (!queryParam["CITY"].IsEmpty())
            {
                string[] strArr = queryParam["CITY"].ToString().Split(',');
                //sbWhere.AppendFormat("  and  concat(substr(a.AREACODE,0,4),'00') in('{0}') ", string.Join("','", strArr.ToArray()));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("a.AREACODE", 0, 4)));
                listParam.Add(new KeyValuePair<bool, string>(false, "00"));
                sbWhere.Append(string.Format("  and  {0} in('" + string.Join("','", strArr.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam)));
            }
            else if (!queryParam["PROVINCE"].IsEmpty())
            {
                string[] strArr = queryParam["PROVINCE"].ToString().Split(',');
                //sbWhere.AppendFormat("  and  concat(substr(a.AREACODE,0,2),'0000') in('{0}') ", string.Join("','", strArr.ToArray()));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("a.AREACODE", 0, 2)));
                listParam.Add(new KeyValuePair<bool, string>(false, "0000"));
                sbWhere.Append(string.Format("  and  {0} in('" + string.Join("','", strArr.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam)));
            }
            //���ݷ�ΧȨ�޹���
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                //sbWhere.AppendFormat("  and  concat(substr(a.AREACODE,0,2),'0000') in('{0}') ", string.Join("','", _codes.ToArray()));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("a.AREACODE", 0, 2)));
                listParam.Add(new KeyValuePair<bool, string>(false, "0000"));
                sbWhere.Append(string.Format("  and  {0} in('" + string.Join("','", _codes.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam)));
            }
            //ͳ����ȷ�Χ
            if (queryParam["STARTYEAR"].IsEmpty() || queryParam["ENDYEAR"].IsEmpty())
            {
                return returnValue;
            }
            int startYear = queryParam["STARTYEAR"].ToInt();
            int endYear = queryParam["ENDYEAR"].ToInt();
            //sbWhere.AppendFormat(" and to_char(b.monitortime,'yyyy')  between '{0}' and '{1}' ", startYear, endYear);
            sbWhere.AppendFormat(" and "+DbSqlFunctionHelper.DateToChar("b.monitortime","yyyy")+" between '{0}' and '{1}' ", startYear, endYear);
            for (int i = startYear; i <= endYear; i++)
            {
                //selectColumn.AppendFormat(" ,sum(decode (to_char(b.monitortime,'yyyy'),'{0}',value,0)) \"{0}\"", i);
                //selectColumn.AppendFormat(" ,sum(decode (" + DbSqlFunctionHelper.DateToChar("b.monitortime", "yyyy") + ",'{0}',value,0)) \"{0}\"", i);
                selectColumn.AppendFormat(" ,sum(case when " + DbSqlFunctionHelper.DateToChar("b.monitortime", "yyyy") + "='{0}' then value else 0 end) \"{0}\"", i);
                sumColumn.AppendFormat(", sum(\"{0}\") \"{0}\"", i);
            }
//            string sql = "select t.monitorpointid \"���\",t.monitorpointname \"����\" {2},sum(\"�ۼƳ�����\") \"�ۼƳ�����\" from ( " +
//                "select b.monitorpointid ,a.monitorpointname {0},sum(value) \"�ۼƳ�����\" from tbl_dmcj_monitorpoint a," +
//                "(select * from  tbl_dmcj_monitordata t where   not exists( select 1 from  tbl_dmcj_monitordata where monitorpointid=t.monitorpointid and t.monitortime<monitortime and to_char(monitortime, 'yyyy')=to_char(monitortime, 'yyyy')  ))b " +
//" where a.monitorpointid=b.monitorpointid {1}  group by b.monitorpointid,a.monitorpointname,to_char(b.monitortime,'yyyy') " +
//" ) t group by monitorpointid,monitorpointname "; 
            string sql = "select t.monitorpointid \"���\",t.monitorpointname \"����\" {2},sum(\"�ۼƳ�����\") \"�ۼƳ�����\" from ( " +
                 "select b.monitorpointid ,a.monitorpointname {0},sum(value) \"�ۼƳ�����\" from tbl_dmcj_monitorpoint a," +
                 "(select * from  tbl_dmcj_monitordata t where   not exists( select 1 from  tbl_dmcj_monitordata where monitorpointid=t.monitorpointid and t.monitortime<monitortime and " + DbSqlFunctionHelper.DateToChar("monitortime", "yyyy") + "=" + DbSqlFunctionHelper.DateToChar("t.monitortime", "yyyy") + "  ))b " +
 " where a.monitorpointid=b.monitorpointid {1}  group by b.monitorpointid,a.monitorpointname," + DbSqlFunctionHelper.DateToChar("b.monitortime", "yyyy") + " " +
 " ) t group by monitorpointid,monitorpointname ";
            sql = string.Format(sql, selectColumn.ToString(), sbWhere.ToString(), sumColumn.ToString());

            return this.BaseRepository().FindTable(sql);
        }
        /// <summary>
        /// ���ݼ���ͳ������
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetQueryListByMonitorPoint(string queryJson)
        {
            DataTable returnValue = new DataTable();
            var queryParam = queryJson.ToJObject();
            StringBuilder sbWhere = new StringBuilder();
            StringBuilder selectColumn = new StringBuilder();
            StringBuilder sumColumn = new StringBuilder();

            if (!queryParam["MONITORPOINTIDS"].IsEmpty())
            {
                string[] strArr = queryParam["MONITORPOINTIDS"].ToString().Split(',');
                sbWhere.AppendFormat("  and  a.monitorpointid in('{0}') ", string.Join("','", strArr.ToArray()));
            }
            //���ݷ�ΧȨ�޹���
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                //sbWhere.AppendFormat("  and  concat(substr(a.AREACODE,0,2),'0000') in('{0}') ", string.Join("','", _codes.ToArray()));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("a.AREACODE", 0, 2)));
                listParam.Add(new KeyValuePair<bool, string>(false, "0000"));
                sbWhere.Append(string.Format("  and  {0} in('" + string.Join("','", _codes.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam)));
            }
            //ͳ����ȷ�Χ
            if (queryParam["STARTYEAR"].IsEmpty() || queryParam["ENDYEAR"].IsEmpty())
            {
                return returnValue;
            }
            int startYear = queryParam["STARTYEAR"].ToInt();
            int endYear = queryParam["ENDYEAR"].ToInt();
            //sbWhere.AppendFormat(" and to_char(b.monitortime,'yyyy')  between '{0}' and '{1}' ", startYear, endYear);
            sbWhere.AppendFormat(" and " + DbSqlFunctionHelper.DateToChar("b.monitortime", "yyyy") + " between '{0}' and '{1}' ", startYear, endYear);
            for (int i = startYear; i <= endYear; i++)
            {
                //selectColumn.AppendFormat(" ,sum(decode (to_char(b.monitortime,'yyyy'),'{0}',value,0)) \"{0}\"", i);
                //selectColumn.AppendFormat(" ,sum(decode (" + DbSqlFunctionHelper.DateToChar("b.monitortime", "yyyy") + ",'{0}',value,0)) \"{0}\"", i);
                selectColumn.AppendFormat(" ,sum(case when " + DbSqlFunctionHelper.DateToChar("b.monitortime", "yyyy") + "='{0}' then value else 0 end) \"{0}\"", i);
                sumColumn.AppendFormat(", sum(\"{0}\") \"{0}\"", i);
            }

//            string sql = "select t.monitorpointid \"������\",t.monitorpointname \"��������\" {2},sum(\"�ۼƳ�����\") \"�ۼƳ�����\" from ( " +
//                "select b.monitorpointid ,a.monitorpointname {0},sum(value) \"�ۼƳ�����\" from tbl_dmcj_monitorpoint a," +
//                "(select * from  tbl_dmcj_monitordata t where   not exists( select 1 from  tbl_dmcj_monitordata where monitorpointid=t.monitorpointid and t.monitortime<monitortime and to_char(monitortime, 'yyyy')=to_char(t.monitortime, 'yyyy')  ))b " +
//" where a.monitorpointid=b.monitorpointid {1}  group by b.monitorpointid,a.monitorpointname,to_char(b.monitortime,'yyyy') " +
//" ) t group by monitorpointid,monitorpointname ";
            string sql = "select t.monitorpointid \"������\",t.monitorpointname \"��������\" {2},sum(\"�ۼƳ�����\") \"�ۼƳ�����\" from ( " +
               "select b.monitorpointid ,a.monitorpointname {0},sum(value) \"�ۼƳ�����\" from tbl_dmcj_monitorpoint a," +
               "(select * from  tbl_dmcj_monitordata t where   not exists( select 1 from  tbl_dmcj_monitordata where monitorpointid=t.monitorpointid and t.monitortime<monitortime and " + DbSqlFunctionHelper.DateToChar("monitortime", "yyyy") + "=" + DbSqlFunctionHelper.DateToChar("t.monitortime", "yyyy") + "  ))b " +
" where a.monitorpointid=b.monitorpointid {1}  group by b.monitorpointid,a.monitorpointname," + DbSqlFunctionHelper.DateToChar("b.monitortime", "yyyy") + " " +
" ) t group by monitorpointid,monitorpointname ";

            sql = string.Format(sql, selectColumn.ToString(), sbWhere.ToString(), sumColumn.ToString());
            return this.BaseRepository().FindTable(sql);
        }

        /// <summary>
        /// �������ˮλ��
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetQueryList_Contour(string queryJson)
        {
            DataTable returnValue = new DataTable();
            var queryParam = queryJson.ToJObject();
            StringBuilder sbWhere = new StringBuilder();
            StringBuilder selectColumn = new StringBuilder();
            StringBuilder sumColumn = new StringBuilder();
            //��������
            if (!queryParam["COUNTY"].IsEmpty())
            {
                string[] strArr = queryParam["COUNTY"].ToString().Split(',');
                //sbWhere.AppendFormat("  and  concat(substr(a.AREACODE,0,6),'') in('{0}') ", string.Join("','", strArr.ToArray()));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("a.AREACODE", 0, 6)));
                listParam.Add(new KeyValuePair<bool, string>(false, ""));
                sbWhere.Append(string.Format("  and  {0} in('" + string.Join("','", strArr.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam)));
            }
            else if (!queryParam["CITY"].IsEmpty())
            {
                string[] strArr = queryParam["CITY"].ToString().Split(',');
                //sbWhere.AppendFormat("  and  concat(substr(a.AREACODE,0,4),'00') in('{0}') ", string.Join("','", strArr.ToArray()));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("a.AREACODE", 0, 4)));
                listParam.Add(new KeyValuePair<bool, string>(false, "00"));
                sbWhere.Append(string.Format("  and  {0} in('" + string.Join("','", strArr.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam)));
            }
            else if (!queryParam["PROVINCE"].IsEmpty())
            {
                string[] strArr = queryParam["PROVINCE"].ToString().Split(',');
                //sbWhere.AppendFormat("  and  concat(substr(a.AREACODE,0,2),'0000') in('{0}') ", string.Join("','", strArr.ToArray()));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("a.AREACODE", 0, 2)));
                listParam.Add(new KeyValuePair<bool, string>(false, "0000"));
                sbWhere.Append(string.Format("  and  {0} in('" + string.Join("','", strArr.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam)));
            }
            //���ݷ�ΧȨ�޹���
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                //sbWhere.AppendFormat("  and  concat(substr(a.AREACODE,0,2),'0000') in('{0}') ", string.Join("','", _codes.ToArray()));
                List<KeyValuePair<bool, string>> listParam = new List<KeyValuePair<bool, string>>();
                listParam.Add(new KeyValuePair<bool, string>(true, DbSqlFunctionHelper.SubString("a.AREACODE", 0, 2)));
                listParam.Add(new KeyValuePair<bool, string>(false, "0000"));
                sbWhere.Append(string.Format("  and  {0} in('" + string.Join("','", _codes.ToArray()) + "') ", DbSqlFunctionHelper.Concat(listParam)));
            }
            //ͳ����ȷ�Χ
            if (queryParam["STARTYEAR"].IsEmpty() || queryParam["ENDYEAR"].IsEmpty())
            {
                return returnValue;
            }
            int startYear = queryParam["STARTYEAR"].ToInt();
            int endYear = queryParam["ENDYEAR"].ToInt();
//            string sql =
//                "select b.monitorpointid ,a.monitorpointname ,latitude ,longitude , (c.value-b.value) DMCJVALUE from tbl_dmcj_monitorpoint a" +
//                "  left join   (select *  from tbl_dmcj_monitordata t where not exists (select 1 from tbl_dmcj_monitordata  where monitorpointid = t.monitorpointid and t.monitortime < monitortime and to_char(monitortime, 'yyyy') =to_char(t.monitortime, 'yyyy')) and to_char(t.monitortime, 'yyyy')='{0}' ) b on a.monitorpointid = b.monitorpointid " +
//                " left join   (select *  from tbl_dmcj_monitordata t where not exists (select 1 from tbl_dmcj_monitordata  where monitorpointid = t.monitorpointid and t.monitortime < monitortime and to_char(monitortime, 'yyyy') =to_char(t.monitortime, 'yyyy')) and to_char(t.monitortime, 'yyyy')='{1}' ) c on a.monitorpointid = c.monitorpointid " +
//" where  c.value is not null and b.value is not null {2}  ";
     string sql =
                "select b.monitorpointid ,a.monitorpointname ,latitude ,longitude , (c.value-b.value) DMCJVALUE from tbl_dmcj_monitorpoint a" +
                "  left join   (select *  from tbl_dmcj_monitordata t where not exists (select 1 from tbl_dmcj_monitordata  where monitorpointid = t.monitorpointid and t.monitortime < monitortime and " + DbSqlFunctionHelper.DateToChar("monitortime", "yyyy") + " =" + DbSqlFunctionHelper.DateToChar("t.monitortime", "yyyy") + ") and " + DbSqlFunctionHelper.DateToChar("t.monitortime", "yyyy") + "='{0}' ) b on a.monitorpointid = b.monitorpointid " +
                " left join   (select *  from tbl_dmcj_monitordata t where not exists (select 1 from tbl_dmcj_monitordata  where monitorpointid = t.monitorpointid and t.monitortime < monitortime and " + DbSqlFunctionHelper.DateToChar("monitortime", "yyyy") + " =" + DbSqlFunctionHelper.DateToChar("t.monitortime", "yyyy") + ") and " + DbSqlFunctionHelper.DateToChar("t.monitortime", "yyyy") + "='{1}' ) c on a.monitorpointid = c.monitorpointid " +
" where  c.value is not null and b.value is not null {2}  ";
            sql = string.Format(sql, startYear, endYear, sbWhere.ToString());

            return this.BaseRepository().FindTable(sql);
        }
    }
}
