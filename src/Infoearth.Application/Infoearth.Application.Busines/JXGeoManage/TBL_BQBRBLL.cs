using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;
using Infoearth.Util;
using Infoearth.Application.Common;
using Infoearth.Util.Extension;
using Infoearth.Application.Entity;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:25
    /// 描 述：搬迁避让信息表
    /// </summary>
    public class TBL_BQBRBLL
    {
        private TBL_BQBRIService service = new TBL_BQBRService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_BQBREntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        public IEnumerable<TBL_BQBREntity> GetZYPageList(string queryJson, string condition)
        {
            return service.GetZYPageList(queryJson, condition);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<tbl_bqbrnew> GetPageLists(Pagination pagination, string queryJson, string condition)
        {

            //var list = service.GetPageList(pagination, queryJson);
            var list = service.GetPageListNEW(pagination, queryJson);
            List<tbl_bqbrnew> result = new List<tbl_bqbrnew>();
            var queryParam = condition.ToJObject();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                foreach (var item in list)
                {
                    if (!item.LONGITUDE.HasValue || !item.LATITUDE.HasValue)
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        result.Add(item);
                    }

                }
                pagination.records = result.Count;
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
                pagination.records = result.Count;
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
                pagination.records = result.Count;
                return result;
            }
            return list;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_BQBREntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_BQBREntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        public TBL_BQBREntity GetEntityByUnifycode(string keyValue)
        {
            return service.GetEntityByUnifycode(keyValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <param name="CityName"></param>
        /// <param name="CountyName"></param>
        /// <param name="BQBRYEAR"></param>
        /// <param name="BQBRUNIT"></param>
        /// <param name="EXLType"></param>
        /// <returns></returns>
        public DataTable BQBRCountStatics(string ProvinceName, string CityName, string CountyName, string BQBRYEAR, string BQBRUNIT, string EXLType)
        {
            return service.BQBRCountStatics(ProvinceName, CityName, CountyName, BQBRYEAR, BQBRUNIT, EXLType);
        }
        public EchartEntityNEWS GetListCodes()
        {
            return service.GetListCodes();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetDataTableList(string queryJson)
        {
            return service.GetDataTableList(queryJson);
        }
        public IEnumerable<TBL_BQBREntity> GetZYList(string queryJson, string condition)
        {
            return service.GetZYList(queryJson, condition);
        }

        /// <summary>
        /// 搬迁避让统计查询
        /// </summary>
        /// <param name="codeValue">行政区划编号</param>
        /// <param name="codeType">行政区划级别</param>
        /// <param name="xmmc">项目名称</param>
        /// <param name="annual">立项数据</param>
        /// <param name="static_Unit">统计单位</param>
        /// <returns></returns>
        public DataTable GetDataBqbrTj(string codeValue, string codeType, string xmmc, string annual, string static_Unit)
        {
            return service.GetDataBqbrTj(codeValue, codeType, xmmc, annual, static_Unit);
        }
        #endregion

        public IEnumerable<TreeByBQBRTJ> GetTJ(string queryJson)
        {
            return service.GetTJ(queryJson);
        }
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
        public string SaveForm(string keyValue, TBL_BQBREntity entity)
        {
            try
            {
                string SuccessGuid = service.SaveForm(keyValue, entity);
                return SuccessGuid;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
