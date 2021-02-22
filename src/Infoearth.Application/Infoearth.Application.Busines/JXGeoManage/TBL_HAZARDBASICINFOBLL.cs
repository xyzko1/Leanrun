using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;
using System.Reflection;
using Infoearth.Application.Busines.SystemManage;
using System.Linq;
using Infoearth.Util.Extension;
using Infoearth.Util;
using Infoearth.Application.Common;
using Infoearth.Application.Entity;
using Infoearth.Data.Repository;
using iTelluro.Busness.WebApiProxy;
namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-14 11:42
    /// 描 述：灾害点基本表
    /// </summary>
    public class TBL_HAZARDBASICINFOBLL
    {
        private TBL_HAZARDBASICINFOIService service = new TBL_HAZARDBASICINFOService();

        private DataSourceBLL datasourcebll = new DataSourceBLL();

		private JYGC_PROJECTBASEINFOBLL project = new JYGC_PROJECTBASEINFOBLL();

        private SSOWebApiWS ssoWS = new SSOWebApiWS("");

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        public EchartEntity GetStatisticsByXH(string queryJson)
        {
            return service.GetStatisticsByXH(queryJson);
        }
        public EchartEntity GetStatisticsByZHD(string queryJson = null)
        {
            return service.GetStatisticsByZHD(queryJson); 
        }
        public EchartEntity GetStatisticsByXQDJ(string queryJson)
        {
            return service.GetStatisticsByXQDJ(queryJson);
        }
        public EchartEntity GetStatisticsByGMDJ(string queryJson)
        {
            return service.GetStatisticsByGMDJ(queryJson);
        }
        public EchartEntity GetStatisticsByZQDJ(string queryJson)
        {
            return service.GetStatisticsByZQDJ(queryJson);
        }
        public EchartEntity GetStatisticsByZLGC(string queryJson)
        {
            return service.GetStatisticsByZLGC(queryJson);
        }
        public EchartEntity GetStatisticsByBQBR(string queryJson)
        {
            return service.GetStatisticsByBQBR(queryJson);
        }
        public List<string> SSOGeodisaster(string queryJson)
        {
            return service.SSOGeodisaster(queryJson);
        }

        /// <summary>
        /// 检查查询条件语句是否正确
        /// </summary>
        /// <param name="sqlWhere">查询语句条件</param>
        /// <returns></returns>
        public bool CheckExpression(string sqlWhere)
        {
            return service.CheckExpression(sqlWhere);
        }
        /// <summary>
        /// 灾害点后四位编号生成
        /// </summary>
        /// <param name="xzqh"></param>
        /// <returns></returns>
        public string GetMaxCode(string xzqh)
        {
            return service.GetMaxCode(xzqh);
        }
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetZYPageList(string queryJson, string condition)
        {
            return service.GetZYPageList(queryJson, condition);
        }
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetZYPageList2(string queryJson, string condition)
        {
            return service.GetZYPageList2(queryJson, condition);
        }
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetNoQcqfPageList(string queryJson, string condition)
        {
            return service.GetNoQcqfPageList(queryJson, condition);
        }
        public DataTable GetHazardStatisticsJson2(string queryJson)
        {
            return service.GetHazardStatisticsJson2(queryJson);
        }
        /// <summary>
        /// 灾害点统计只按灾害类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetAllList()
        {
            return service.GetAllList();
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJson(Pagination pagination, string queryJson)
        {
            return service.GetPageListJson(pagination, queryJson);
        }
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJson2(Pagination pagination, string queryJson)
        {
            return service.GetPageListJson2(pagination, queryJson);
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJsons(Pagination pagination, string queryJson, string condition)
        {
            return service.GetPageListJsons(pagination, queryJson, condition);
        }
        public IEnumerable<TBL_HAZARDBASICINFOEntity> PostPageListJsonFirst(Pagination pagination, string queryJson, string condition)
        {
            return service.PostPageListJsonFirst(pagination, queryJson, condition);
        }
        /// <summary>
        /// 获取单列数据（用于统计条件查询）
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns>返回列表Json</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetSinglePageList(Pagination pagination, string queryJson)
        {
            return service.GetSinglePageList(pagination, queryJson);
        }


        /// <summary>
        /// 获取历史分页列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<PastHAZARDBASICINFO> GetPastPageListJson(Pagination pagination, string queryJson)
        {
            return service.GetPastPageListJson(pagination, queryJson);
        }

        /// <summary>
        /// 获取历史信息列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<PastHAZARDBASICINFO> GetPastListJson(string queryJson, string condition)
        {
            return service.GetPastListJson(queryJson, condition);
        }
        /// <summary>
        /// 获取历史信息列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<PastHAZARDBASICINFO> GetPastListJson2(string queryJson)
        {
            return service.GetPastListJson2(queryJson);
        }

        #region 获取最近一条历史表数据 by wc 2019-1-12

        /// <summary>
        /// 获取最近一条历史数据的所有列表信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<PastHAZARDBASICINFO> GetSinglePastListJson(string queryJson, string condition)
        {
            return service.GetPastListJson(queryJson, condition).Distinct(new PastHAZARDBASICINFOComparer());
        }

        /// <summary>
        /// 获取最近一条历史数据的分页列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<PastHAZARDBASICINFO> GetSinglePastPageListJson(Pagination pagination, string queryJson, string condition)
        {
            var toodata = GetPastListJson(queryJson, condition).Distinct(new PastHAZARDBASICINFOComparer());
            pagination.records = toodata.Count();
            return toodata.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows).AsQueryable();
        }


        public class PastHAZARDBASICINFOComparer : IEqualityComparer<PastHAZARDBASICINFO>
        {
            public bool Equals(PastHAZARDBASICINFO x, PastHAZARDBASICINFO y)
            {
                if (Object.ReferenceEquals(x, y)) return true;
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;
                return x.UNIFIEDCODE == y.UNIFIEDCODE;
            }

            public int GetHashCode(PastHAZARDBASICINFO hazard)
            {
                if (Object.ReferenceEquals(hazard, null)) return 0;
                return hazard.UNIFIEDCODE == null ? 0 : hazard.UNIFIEDCODE.GetHashCode();
            }
        }

        #endregion

        #region 获取灾害点数据的调查时间轴数据

        /// <summary>
        /// 获取一条历史数据的所有调查时间列表信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<PastHAZARDBASICINFO> GetSingleFillListJson(string queryJson, string condition)
        {
            return service.GetPastListJson(queryJson, condition).Distinct(new FillHAZARDBASICINFOComparer());
        }

        public class FillHAZARDBASICINFOComparer : IEqualityComparer<PastHAZARDBASICINFO>
        {
            public bool Equals(PastHAZARDBASICINFO x, PastHAZARDBASICINFO y)
            {
                if (Object.ReferenceEquals(x, y)) return true;
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;
                return x.UNIFIEDCODE == y.UNIFIEDCODE && x.FILLDATE == y.FILLDATE;
            }

            public int GetHashCode(PastHAZARDBASICINFO hazard)
            {
                if (Object.ReferenceEquals(hazard, null)) return 0;
                var a = hazard.UNIFIEDCODE == null ? 0 : hazard.UNIFIEDCODE.GetHashCode();
                var b = hazard.FILLDATE == null ? 0 : hazard.FILLDATE.GetHashCode();
                return a ^ b;
            }
        }

        #endregion

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// 获取灾害类型统计结果
        /// </summary>
        /// <returns></returns>
        public DataTable GetDicAnalyse(string enCode)
        {
            return service.GetDicAnalyse(enCode);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetLists(string queryJson, string condition)
        {

            var list = service.GetList(queryJson);
            var queryParam = condition.ToJObject();
            List<TBL_HAZARDBASICINFOEntity> result = new List<TBL_HAZARDBASICINFOEntity>();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
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
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
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
        }

		/// <summary>
        /// 排除掉已存在群测群防数据的灾害点
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJsonNoQCQF(string queryJson, string condition, Pagination pagination)
        {
            var queryParam = condition.ToJObject();
            var strWhere = service.GetWhereSql(queryJson);
            List<TBL_HAZARDBASICINFOEntity> result = new List<TBL_HAZARDBASICINFOEntity>();
            string sql = @"select a.* from tbl_hazardbasicinfo a  where unifiedcode not in (select unifiedcode from TBL_QCQF_DISASTERPREVENTION) " + strWhere;
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            var list = db.FindList<TBL_HAZARDBASICINFOEntity>(sql, pagination);
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
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
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
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

        }
        /// <summary>
        /// 根据UNIFIEDCODE获取实体
        /// </summary>
        /// <param name="UNIFIEDCODE"></param>
        /// <returns></returns>
        public TBL_HAZARDBASICINFOEntity GetUNIFIEDCODEEntity(string UNIFIEDCODE)
        {
            return service.GetUNIFIEDCODEEntity(UNIFIEDCODE);
        }
        public IEnumerable<TBL_HAZARDBASICINFO> GetPageListJsonQCQFSearch_MarkerByInfo(Pagination pagination, string queryJson, string condition, string sql = null)
        {
            var result = service.GetPageListJsonQCQFSearch_MarkerByInfo(pagination, queryJson, condition, sql).OrderByDescending(t => t.MODIFYTIME);
            return result;
            //pagination.records = result.Count();
            //return result.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
        }
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJsonQCQFSearch(Pagination pagination, string queryJson, string condition,string sql=null)
        {
            var result = service.GetPageListJsonQCQFSearch_Marker(pagination, queryJson, condition,sql).OrderByDescending(t => t.MODIFYTIME);
            return result;
            //pagination.records = result.Count();
            //return result.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
        }

        /// <summary>
        /// 行政责任人浏览查询群测群防信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IEnumerable<TBL_HAZARDBASICINFO> GetListJsonQCQFInfo(string queryJson, string condition, string sql = null)
        {
            var result = service.GetListJsonQCQFInfo(queryJson, condition, sql).OrderByDescending(t => t.MODIFYTIME);
            return result;
        }

        public DataTable GetListCode(string queryJson)
        {
            return service.GetListCode(queryJson);
        }
       public EchartEntityNEW GetListCodes(string queryJson)
        {
            return service.GetListCodes(queryJson);
        }
        public EchartEntityNEWS GetListCodesNew()
        {
            return service.GetListCodesNew();
        }
        public EchartEntityCJ GetListDataCJ(string queryJson)
        {
            return service.GetListDataCJ(queryJson);
        }
        
    /// <summary>
    /// 获取实体
    /// </summary>
    /// <param name="keyValue">主键值</param>
    /// <returns></returns>
    public TBL_HAZARDBASICINFOEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<TBL_HAZARDBASICINFOEntity> GetCountAnalyseList(string queryJson)
        {
            return service.GetCountAnalyseList(queryJson);
        }
        public  bool ValidateSQL(string sql)
        {
            return service.ValidateSQL(sql);
        }
        /// <summary>
        /// 根据条件统计灾害点信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetAnalyseList(string queryJson)
        {
            return service.GetAnalyseList(queryJson);
        }
        public DataTable GetZhdAndCityName()
        {
            return service.GetZhdAndCityName();
        }
        public DataTable GetZhdAndProvinceName()
        {
            return service.GetZhdAndProvinceName();
        }
        /// <summary>
        /// 灾害点统计（按市县、灾害点总数|灾害点类型|灾情等级|险情等级 统计）
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetHazardStatisticsJson(string type)
        {
            return service.GetHazardStatisticsJson(type);
        }
        public DataTable GetWXRKStatisticsJson(string queryJson)
        {
            return service.GetWXRKStatisticsJson(queryJson);
        }
        public DataTable GetWXCCStatisticsJson(string queryJson)
        {
            return service.GetWXCCStatisticsJson(queryJson);
        }

        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetZYPageList(string queryJson, string condition, Pagination pagination)
        {
            return service.GetZYPageList(queryJson, condition, pagination);
        }
        public EchartEntity GetStatisticsByZHLX(string queryJson)
        {
            return service.GetStatisticsByZHLX(queryJson);
        }
        public DataTable GetHistoryStatisticsZHD(string queryJson, ref EchartEntity returnValue)
        {
            return service.GetHistoryStatisticsZHD(queryJson, ref  returnValue);
        }
        public DataTable GetTypeStatistics(string queryJson)
        {
            return service.GetTypeStatistics(queryJson);
        }
        public DataTable GetStatisticsByZHLX2(string queryJson)
        {
            return service.GetStatisticsByZHLX2(queryJson);
        }
        /// <summary>
        /// 灾害点查询浏览生生Datatable返回信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetDataTableList(string queryJson)
        {
            return service.GetDataTableList(queryJson);
        }

        public DataTable GetDataCountTableList(string queryJson, string colum)
        {
            return service.GetDataCountTableList(queryJson, colum);
        }
        /// <summary>
        /// 根据灾害点统计排查
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetDataCountTableListPC(string queryJson, string colum)
        {
            return service.GetDataCountTableListPC(queryJson, colum);
        }
        public DataTable GetAnalyseListPC(string queryJson)
        {
            return service.GetAnalyseListPC(queryJson);
        }
        public string GetZHDCountResult(string queryJson, int type)
        {
            return service.GetZHDCountResult(queryJson,type);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TBL_HAZARDBASICINFOEntity entity)
        {
            try
            {
                service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateForm(string sql)
        {
            try
            {
                service.UpdateForm(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<TBL_HAZARDBASICINFOEntity> GetValue()
        {
           return service.GetValue();
        }
        #endregion


    }
}
