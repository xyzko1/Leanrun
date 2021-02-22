using Infoearth.Application.Entity.DMCJManage;
using Infoearth.Application.IService.DMCJManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Infoearth.Util.Extension;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Infoearth.Data.Extension;
using Newtonsoft.Json.Linq;
using System.Data;
using Infoearth.Application.Entity;
using Infoearth.Application.Service.SystemManage;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.Common;


namespace Infoearth.Application.Service.DMCJManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-22 12:10
    /// �� ����������������
    /// </summary>
    public class TBL_DMCJ_BASEINFOService : RepositoryFactory<TBL_DMCJ_BASEINFOEntity>, TBL_DMCJ_BASEINFOIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_DMCJ_BASEINFOEntity> GetPageList(Pagination pagination, string queryJson, string condition)
        {

            try
            {
                var result = GetZYList(queryJson, condition).OrderByDescending(t => t.DMCJMC);
                pagination.records = result.Count();
                return result.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_DMCJ_BASEINFOEntity> GetList(string queryJson)
        {
             var expression = LinqExtensions.True<TBL_DMCJ_BASEINFOEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// ��ȡ��ͼժҪ��Ϣ
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_DMCJ_BASEINFOEntity> GetZYList(string queryJson, string condition)
        {
            var queryParam = condition.ToJObject();
            try
            {
                var expression = GetMonitorExpression(queryJson);
                List<TBL_DMCJ_BASEINFOEntity> result = new List<TBL_DMCJ_BASEINFOEntity>();
                var list = this.BaseRepository().FindList(expression).ToList();
                if (!queryParam["WKTString"].IsEmpty())
                {
                    string WKTString = queryParam["WKTString"].ToString();
                    foreach (var item in list)
                    {
                        if (!item.LONGITUDE.HasValue || !item.LATITUDE.HasValue)
                        {
                            continue;
                        }

                        bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.Value.ToString(), item.LATITUDE.Value.ToString());
                        if (isInsert)
                        {
                            result.Add(item);
                        }

                    }
                    return result;
                }
                if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
                {
                    double x = queryParam["x"].ToDouble();
                    double y = queryParam["y"].ToDouble();
                    double radius = queryParam["radius"].ToDouble();
                    foreach (var item in list)
                    {
                        if (!item.LONGITUDE.HasValue || !item.LATITUDE.HasValue)
                        {
                            continue;
                        }

                        bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                        if (isInsert)
                        {
                            result.Add(item);
                        }

                    }
                    return result;
                }
                if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
                {
                    string polyline = queryParam["polyline"].ToString();
                    double radius = queryParam["radius"].ToDouble();
                    foreach (var item in list)
                    {
                        if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                        {
                            continue;
                        }

                      bool isInsert = SpatialQueryHelper.IsIntersects(polyline, radius, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                        if (isInsert)
                        {
                            result.Add(item);
                        }

                    }
                    return result;
                }
                return list;
                //return this.BaseRepository().FindList(expression).Select(t => new TBL_MONITOROBJECTEntity { MONITOROBJECTID = t.MONITOROBJECTID, MONITORPOINTNAME = t.MONITORPOINTNAME, POINTTYPE = t.POINTTYPE, MEASURETYPE = t.MEASURETYPE, JCDJB = t.JCDJB, LONGITUDE = t.LONGITUDE, LATITUDE = t.LATITUDE }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_DMCJ_BASEINFOEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }

        /// <summary>
        /// ȡ���������ֶε�ֵ�б�
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<string> GetValueList(string queryJson)
        {
            List<string> list = new List<string>();
            if (string.IsNullOrWhiteSpace(queryJson))
                return list;
            var queryParam = queryJson.ToJObject();
            string FIELDNAME = queryParam["FIELDNAME"].ToString();
            string TABLENAME = queryParam["TABLENAME"].ToString();
            string sql = string.Format("select distinct {0} from {1}", FIELDNAME, TABLENAME);
            DataTable result = this.BaseRepository().FindTable(sql);
            foreach (DataRow row in result.Rows)
            {
                list.Add(row[0].ToString());
            }
            return list;
        }


        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            new RepositoryFactory().BaseRepository().Delete<TBL_DMCJ_BASEINFO_SUBEntity>(p => p.DMCJBH == keyValue);
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, MasterDetailEntity entity)
        {
            TBL_DMCJ_BASEINFOEntity masterEntity = entity.TBL_DMCJ_BASEINFOEntity;
            if (!string.IsNullOrEmpty(keyValue))
            {
                masterEntity.Modify(keyValue);
                this.BaseRepository().Update(masterEntity);
            }
            else
            {
                masterEntity.Create();
                this.BaseRepository().Insert(masterEntity);
            }
            if (entity.TBL_DMCJ_BASEINFO_SUBList != null)
            {
                List<TBL_DMCJ_BASEINFO_SUBEntity> listentity = entity.TBL_DMCJ_BASEINFO_SUBList;
                foreach (TBL_DMCJ_BASEINFO_SUBEntity item in listentity)
                {
                    item.DMCJBH = masterEntity.DMCJBH;
                    if (!string.IsNullOrEmpty(item.GUID))
                    {
                        item.Modify(keyValue);
                        new RepositoryFactory().BaseRepository().Update<TBL_DMCJ_BASEINFO_SUBEntity>(item);
                    }
                    else
                    {
                        item.Create();
                        new RepositoryFactory().BaseRepository().Insert<TBL_DMCJ_BASEINFO_SUBEntity>(item);
                    }
                }
            }
        }
        #endregion

        #region ��ҳͳ��ͼ��
        /// <summary>
        /// ���������ͳ��
        /// </summary>
        /// <returns></returns>
        public EchartEntity GetStatisticsByDmcj()
        {
            List<string> selectXZQH = new List<string>();
            string DefalutCode = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];

            string XZQHLEVEL = "��";
            int subLength = 4;

            List<string> _codes = ssoWS.GetAllAuthDistricts();

            if (!_codes.Contains("000000"))
            {
                //if (_codes.Where(p => p.EndsWith("0000")).Count() > 0)
                //{
                //    XZQHLEVEL = "ʡ";
                //    subLength = 2;
                //    selectXZQH = _codes.Where(p => p.EndsWith("0000")).ToList();
                //}
                if (_codes.Where(p => p.EndsWith("00")).Count() > 1)
                {
                    XZQHLEVEL = "��";
                    subLength = 4;
                    selectXZQH = _codes.Where(p => p.EndsWith("00") && !p.EndsWith("0000")).ToList();
                }
                else
                {
                    XZQHLEVEL = "��";
                    subLength = 6;
                    selectXZQH = _codes.Where(p => !p.EndsWith("00")).ToList();
                }
            }
            else
            {
                selectXZQH = ssoWS.GetAreaListJson(DefalutCode).Select(p => p.F_AreaCode).ToList();
            }
            DataItemDetailService dataItemDetail = new DataItemDetailService();
            IList<string> dataItemDetailList = new List<string>() { "��������" };
            List<AreaEntity> districts = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).Where(p => selectXZQH.Contains(p.F_AreaCode)).ToList();
            string strSql = "";
            string sqlWhere = "";
            if (!_codes.Contains("000000"))
            {
                //sqlWhere = " and substr(AREACODE, 0, 6) in('" + string.Join("','", _codes.ToArray()) + "') ";
                sqlWhere = " and " + DbSqlFunctionHelper.SubString("AREACODE", 0, 6) + " in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
            string sqlReturnWhere = "";
            for (int i = 0; i < dataItemDetailList.Count; i++)
            {

                if (i == 0)
                {
                    //sqlReturnWhere = " and ISZAIQINGORXIANQING='1'";
                    strSql += GetSqlNew(subLength, dataItemDetailList[i], districts, sqlReturnWhere, "TBL_DMCJ_BASEINFO");

                }
                else
                {
                    //sqlReturnWhere = " and ISZAIQINGORXIANQING='2'";
                    strSql += " union all " + GetSqlNew(subLength, dataItemDetailList[i], districts, sqlReturnWhere, "TBL_DMCJ_BASEINFO");

                }
            }

            EchartEntity returnValue = new EchartEntity();
            returnValue.columnList = districts.Select(p => p.F_AreaName).ToList();//��ѯ������
            returnValue.dataList = convertDataTable(this.BaseRepository().FindTable(strSql), dataItemDetailList);
            return returnValue;
        }
        /// <summary>
        /// �����������ͳ��
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatisticsByDmcjPie()
        {
            string strWhere = "";
            GetWhereByCode(ref strWhere);
            var result = new DataTable();
            var sql = @"select SUM(���Ҽ�) ���Ҽ�,SUM(ʡ��) ʡ��,SUM(�м�) �м�,SUM(������) ������,SUM(����) ���� from 
(select CASE  WHEN MONITORPOINTLEVEL = '01' THEN  1  ELSE  0  END ���Ҽ�,CASE  WHEN MONITORPOINTLEVEL = '02' THEN  1  ELSE  0  END ʡ��,CASE  WHEN MONITORPOINTLEVEL = '03' THEN  1  ELSE  0  END �м�,CASE  WHEN MONITORPOINTLEVEL = '04' THEN  1  ELSE  0  END ������,CASE  WHEN MONITORPOINTLEVEL = '05' THEN  1  ELSE  0  END ����
 from TBL_DMCJ_MONITORPOINT where 1=1 {0})";
            result = this.BaseRepository().FindTable(string.Format(sql, strWhere));
            return result;
        }
        private IList<dataEntity> convertDataTable(DataTable dt, IList<string> dataItemDetailList)
        {
            //���������������
            for (int i = 0; i < dataItemDetailList.Count; i++)
            {
                if (dt.Select("name ='" + dataItemDetailList[i] + "'").Count() == 0)
                {
                    DataRow addDR = dt.NewRow();
                    addDR["name"] = dataItemDetailList[i];
                    for (int columnIndex = 1; columnIndex < dt.Columns.Count; columnIndex++)
                    {
                        addDR[columnIndex] = "0";
                    }
                    dt.Rows.InsertAt(addDR, i);
                }
            }
            IList<dataEntity> list = new List<dataEntity>();
            IList<string> listRow = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                listRow.Add(dr["name"].ToString());
            }
            dt.Columns.Remove("name");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new dataEntity()
                {
                    name = listRow[i],
                    data = dt.Rows[i].ItemArray
                });
            }
            return list;
        }
        private string GetSqlNew(int subLength, string dicName, List<AreaEntity> selectXZQH, string sqlWhere, string tableName)
        {
            string selectColumn = "";
            //string groupBy = string.Format(" substr(AREACODE,0,{0}) ", subLength);
            string groupBy = string.Format(" {0} ", DbSqlFunctionHelper.SubString("AREACODE", 0, subLength));
            foreach (var item in selectXZQH)
            {
                //selectColumn += string.Format(" ,sum(decode( {1}, '{0}', 1, 0)) \"{2}\" ", item.F_AreaCode.Substring(0, subLength), groupBy, item.F_AreaName);
                selectColumn += string.Format(" ,sum(case when  {1}='{0}' then  1 else  0 end) \"{2}\" ", item.F_AreaCode.Substring(0, subLength), groupBy, item.F_AreaName);
            }
            string returnValue = string.Format("select  '{0}' name {1} from {3} where 1=1  {2}", dicName, selectColumn, sqlWhere, tableName);
            return returnValue;
        }
        private void GetWhereByCode(ref string strWhere)
        {
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            List<string> _codes2 = _codes.Where(p => p.Contains("00")).ToList();
            if (_codes2.Count > 1)
            {
                //strWhere = " and substr(DISASTERCODE,0,6) in('" + string.Join("','", _codes2.ToArray()) + "') ";//ʡ���û�
                strWhere = " and " + DbSqlFunctionHelper.SubString("DISASTERCODE", 0, 6) + " in('" + string.Join("','", _codes2.ToArray()) + "') ";
            }
            else if (_codes2.Count == 1)
            {
                if (_codes2[0] != "000000")
                {
                    //strWhere = "  and substr(DISASTERCODE,0,6) in('" + string.Join("','", _codes.ToArray()) + "') ";//�м��û�
                    strWhere = " and " + DbSqlFunctionHelper.SubString("DISASTERCODE", 0, 6) + " in('" + string.Join("','", _codes.ToArray()) + "') ";
                }
                else
                {
                    strWhere = "";//ʡ���û�
                }
            }
            else
            {
                //strWhere = "  and substr(DISASTERCODE,0,6) in('" + string.Join("','", _codes.ToArray()) + "') ";//�����û�
                strWhere = " and " + DbSqlFunctionHelper.SubString("DISASTERCODE", 0, 6) + " in('" + string.Join("','", _codes.ToArray()) + "') ";
            }
        } 
        #endregion

        #region ��ѯ����˽�з���
        private Expression<Func<TBL_DMCJ_BASEINFOEntity, bool>> GetMonitorExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_DMCJ_BASEINFOEntity>();
            var queryParam = queryJson.ToJObject();
            //���Ʊ��
            if (!queryParam["MONITOROBJECTMH"].IsEmpty())
            {
                string MONITOROBJECTMH = queryParam["MONITOROBJECTMH"].ToString();
                expression = expression.And(t => t.DMCJBH.Contains(MONITOROBJECTMH));
                expression = expression.Or(t => t.DMCJMC.Contains(MONITOROBJECTMH));
            }
            //����
            if (!queryParam["DMCJMC"].IsEmpty())
            {
                string DMCJMC = queryParam["DMCJMC"].ToString();
                expression = expression.And(t => t.DMCJMC.Contains(DMCJMC));
            }
            //���
            if (!queryParam["DMCJBH"].IsEmpty())
            {
                string DMCJBH = queryParam["DMCJBH"].ToString();
                expression = expression.And(t => t.DMCJBH.Contains(DMCJBH));
            }
            //������
            if (!queryParam["DCR"].IsEmpty())
            {
                string DCR = queryParam["DCR"].ToString();
                expression = expression.And(t => t.DCR.Contains(DCR));
            }
            //��ʼʱ��(ƥ��"����ʱ��")
            if (!queryParam["starttime"].IsEmpty())
            {
                string starttime = queryParam["starttime"].ToString();
                DateTime time1 = Convert.ToDateTime(starttime);
                expression = expression.And(t => t.TBSJ >= time1);
            }
            //����ʱ��(ƥ��"����ʱ��")
            if (!queryParam["enddtime"].IsEmpty())
            {
                string enddtime = queryParam["enddtime"].ToString();
                DateTime time2 = Convert.ToDateTime(enddtime);
                expression = expression.And(t => t.TBSJ <= time2);
            }
            //ʡ���С�������ɸѡ
            expression = expression.And(GetRegionExpression(queryParam));
            //��������
            if (!queryParam["AreaCode"].IsEmpty())
            {
                string DISTRICTCODE = queryParam["AreaCode"].ToString();
                expression = expression.And(t => t.AREACODE.Contains(DISTRICTCODE));
            }
            //����λ��
            if (!queryParam["LOCATION"].IsEmpty())
            {
                string LOCATION = queryParam["LOCATION"].ToString();
                expression = expression.And(t => t.LOCATION.Contains(LOCATION));
            }
            //���ݷ�ΧȨ�޹���
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                expression = expression.And(t => _codes.Contains(t.AREACODE.Substring(0, 6)));
            }
            return expression;
        }
        #endregion

        #region ʡ���б���ת��
        private Expression<Func<TBL_DMCJ_BASEINFOEntity, bool>> GetRegionExpression(JObject queryParam)
        {
            Expression<Func<TBL_DMCJ_BASEINFOEntity, bool>> exp = LinqExtensions.True<TBL_DMCJ_BASEINFOEntity>();
            if (!queryParam["PROVINCE"].IsEmpty())
            {
                if (!queryParam["CITY"].IsEmpty())
                {
                    if (!queryParam["COUNTY"].IsEmpty())
                    {
                        string[] strArr = queryParam["COUNTY"].ToString().Split(',');
                        exp = exp.And(GetLamdaList(strArr));
                    }
                    else
                    {
                        string[] strArr = queryParam["CITY"].ToString().Split(',');
                        exp = exp.And(GetLamdaList(strArr));
                    }
                }
                else
                {
                    string[] strArr = queryParam["PROVINCE"].ToString().Split(',');
                    exp = exp.And(GetLamdaList(strArr));
                }
            }
            return exp;
        }


        private Expression<Func<TBL_DMCJ_BASEINFOEntity, bool>> GetLamdaList(string[] codeArr)
        {
            Expression<Func<TBL_DMCJ_BASEINFOEntity, bool>> exp = LinqExtensions.True<TBL_DMCJ_BASEINFOEntity>();
            for (int i = 0; i < codeArr.Length; i++)
            {
                var lamda = GetLamda(codeArr[i]);
                if (i == 0)
                {
                    exp = exp.And(lamda);
                }
                else
                {
                    exp = exp.Or(lamda);
                }
            }
            return exp;
        }

        private System.Linq.Expressions.Expression<Func<TBL_DMCJ_BASEINFOEntity, bool>> GetLamda(string code)
        {
            System.Linq.Expressions.Expression<Func<TBL_DMCJ_BASEINFOEntity, bool>> exp = LinqExtensions.True<TBL_DMCJ_BASEINFOEntity>();
            if (code.Length == 9)
            {
                exp = s => s.AREACODE.StartsWith(code);
            }
            else
            {
                if (code.EndsWith("0000"))
                {
                    string value = code.Substring(0, 2);
                    exp = s => s.AREACODE.Substring(0, 2) == value;
                }
                else
                {
                    if (code.EndsWith("00"))
                    {
                        exp = s => s.AREACODE.Substring(0, 4) == code.Substring(0, 4);
                    }
                    else
                    {
                        exp = s => s.AREACODE.Substring(0, 6) == code;
                    }
                }
            }
            return exp;
        }
        #endregion
        /// <summary>
        /// ����ĺ���λ�������
        /// </summary>
        /// <param name="xzqh"></param>
        /// <returns></returns>
        public string GetMaxCode(string xzqh)
        {
            string returnValue = "";
            var expression = LinqExtensions.True<TBL_DMCJ_BASEINFOEntity>();
            expression = expression.And(t => t.DMCJBH.StartsWith(xzqh));
            TBL_DMCJ_BASEINFOEntity entity = this.BaseRepository().IQueryable(expression).OrderByDescending(p => p.DMCJBH).FirstOrDefault();
            if (entity == null)
            {
                returnValue = "0001";
            }
            else
            {
                int inta = 0;
                try
                {
                    inta = Convert.ToInt32(entity.DMCJBH.Substring(entity.DMCJBH.Length - 4, 4)) + 1;
                }
                catch (System.Exception)
                {

                }
                returnValue = inta.ToString().PadLeft(4, '0');
            }
            return returnValue;
        }
        
    }
}
