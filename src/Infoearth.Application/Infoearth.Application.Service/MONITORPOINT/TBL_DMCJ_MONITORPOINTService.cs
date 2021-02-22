using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Application.IService.MONITORPOINT;
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
using Infoearth.Application.Common;

namespace Infoearth.Application.Service.MONITORPOINT
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-22 18:23
    /// 描 述：地面沉降监测点信息表
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTService : RepositoryFactory<TBL_DMCJ_MONITORPOINTEntity>, TBL_DMCJ_MONITORPOINTIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_DMCJ_MONITORPOINTEntity> GetPageList(Pagination pagination, string queryJson,string condition)
        {
             //var expression = LinqExtensions.True<TBL_DMCJ_MONITORPOINTEntity>();
             //return this.BaseRepository().FindList(expression,pagination);
            var result = GetZYList(queryJson, condition).OrderByDescending(t => t.DMCJNAME);
            pagination.records = result.Count();
            return result.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);

        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_DMCJ_MONITORPOINTEntity> GetList(string queryJson)
        {
             var expression = LinqExtensions.True<TBL_DMCJ_MONITORPOINTEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取地图摘要信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<TBL_DMCJ_MONITORPOINTEntity> GetZYList(string queryJson, string condition)
        {
            var queryParam = condition.ToJObject();
            try
            {
                var expression = GetMonitorExpression(queryJson);
                List<TBL_DMCJ_MONITORPOINTEntity> result = new List<TBL_DMCJ_MONITORPOINTEntity>();
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
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_DMCJ_MONITORPOINTEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TBL_DMCJ_MONITORPOINTEntity entity)
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

        #region 查询条件私有方法
        private Expression<Func<TBL_DMCJ_MONITORPOINTEntity, bool>> GetMonitorExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_DMCJ_MONITORPOINTEntity>();
            var queryParam = queryJson.ToJObject();
            //名称编号
            if (!queryParam["MONITOROBJECTMH"].IsEmpty())
            {
                string MONITOROBJECTMH = queryParam["MONITOROBJECTMH"].ToString();
                expression = expression.And(t => t.MONITORPOINTID.Contains(MONITOROBJECTMH));
                expression = expression.Or(t => t.DMCJNAME.Contains(MONITOROBJECTMH));
            }
            //名称
            if (!queryParam["MONITORPOINTNAME"].IsEmpty())
            {
                string MONITORPOINTNAME = queryParam["MONITORPOINTNAME"].ToString();
                expression = expression.And(t => t.DMCJNAME.Contains(MONITORPOINTNAME));
            }
            //编号
            if (!queryParam["MONITORPOINTID"].IsEmpty())
            {
                string MONITORPOINTID = queryParam["MONITORPOINTID"].ToString();
                expression = expression.And(t => t.DMCJBH.Contains(MONITORPOINTID));
            }
            //监测点类别
            if (!queryParam["MONITORPOINTTYPE"].IsEmpty())
            {
                string MONITORPOINTTYPE = queryParam["MONITORPOINTTYPE"].ToString();
                expression = expression.And(t => t.MONITORPOINTTYPE.Contains(MONITORPOINTTYPE));
            }
            //监测点等级
            if (!queryParam["MONITORPOINTLEVEL"].IsEmpty())
            {
                string MONITORPOINTLEVEL = queryParam["MONITORPOINTLEVEL"].ToString();
                expression = expression.And(t => t.MONITORPOINTLEVEL.Contains(MONITORPOINTLEVEL));
            }
            //地理位置
            if (!queryParam["LOCATION"].IsEmpty())
            {
                string LOCATION = queryParam["LOCATION"].ToString();
                expression = expression.And(t => t.LOCATION.Contains(LOCATION));
            }
            //建设单位
            if (!queryParam["BUILDDEPT"].IsEmpty())
            {
                string BUILDDEPT = queryParam["BUILDDEPT"].ToString();
                expression = expression.And(t => t.BUILDDEPT.Contains(BUILDDEPT));
            }
            //开始时间(匹配"建点时间")
            if (!queryParam["starttime"].IsEmpty())
            {
                string starttime = queryParam["starttime"].ToString();
                DateTime time1 = Convert.ToDateTime(starttime);
                expression = expression.And(t => t.BUILDTIME >= time1);
            }
            //结束时间(匹配"建点时间")
            if (!queryParam["enddtime"].IsEmpty())
            {
                string enddtime = queryParam["enddtime"].ToString();
                DateTime time2 = Convert.ToDateTime(enddtime);
                expression = expression.And(t => t.BUILDTIME <= time2);
            }
            //省、市、县条件筛选
            expression = expression.And(GetRegionExpression(queryParam));
            //行政编码
            if (!queryParam["AreaCode"].IsEmpty())
            {
                string DISTRICTCODE = queryParam["AreaCode"].ToString();
                expression = expression.And(t => t.AREACODE.Contains(DISTRICTCODE));
            }
            //数据范围权限过滤
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000"))
            {
                expression = expression.And(t => _codes.Contains(t.AREACODE.Substring(0, 6)));
            }
            return expression;
        }
        #endregion

        #region 省地市编码转换
        private Expression<Func<TBL_DMCJ_MONITORPOINTEntity, bool>> GetRegionExpression(JObject queryParam)
        {
            Expression<Func<TBL_DMCJ_MONITORPOINTEntity, bool>> exp = LinqExtensions.True<TBL_DMCJ_MONITORPOINTEntity>();
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


        private Expression<Func<TBL_DMCJ_MONITORPOINTEntity, bool>> GetLamdaList(string[] codeArr)
        {
            Expression<Func<TBL_DMCJ_MONITORPOINTEntity, bool>> exp = LinqExtensions.True<TBL_DMCJ_MONITORPOINTEntity>();
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

        private System.Linq.Expressions.Expression<Func<TBL_DMCJ_MONITORPOINTEntity, bool>> GetLamda(string code)
        {
            System.Linq.Expressions.Expression<Func<TBL_DMCJ_MONITORPOINTEntity, bool>> exp = LinqExtensions.True<TBL_DMCJ_MONITORPOINTEntity>();
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
        /// 监测点的后四位编号生成
        /// </summary>
        /// <param name="xzqh"></param>
        /// <returns></returns>
        public string GetMaxCode(string xzqh)
        {
            string returnValue = "";
            var expression = LinqExtensions.True<TBL_DMCJ_MONITORPOINTEntity>();
            expression = expression.And(t => t.MONITORPOINTID.Contains(xzqh));

            TBL_DMCJ_MONITORPOINTEntity entity = this.BaseRepository().IQueryable(expression).OrderByDescending(p => p.MONITORPOINTID).FirstOrDefault();
            if (entity == null)
            {
                returnValue = "0001";
            }
            else
            {
                int inta = 0;
                try
                {
                    inta = Convert.ToInt32(entity.MONITORPOINTID.Substring(entity.MONITORPOINTID.Length - 4, 4)) + 1;
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
