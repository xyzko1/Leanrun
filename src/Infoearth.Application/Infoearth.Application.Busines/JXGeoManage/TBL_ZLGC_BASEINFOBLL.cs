using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Application.Common;
using Infoearth.Application.Entity;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:27
    /// 描 述：治理工程信息表
    /// </summary>
    public class TBL_ZLGC_BASEINFOBLL
    {
        private TBL_ZLGC_BASEINFOIService service = new TBL_ZLGC_BASEINFOService();

        public EchartEntityNEWS GetListCodes()
        {
            return service.GetListCodes();
        }

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetPageLists(Pagination pagination, string queryJson, string condition)
        {
            var list = service.GetPageList(pagination, queryJson);
            List<TBL_ZLGC_BASEINFOEntity> result = new List<TBL_ZLGC_BASEINFOEntity>();
            var queryParam = condition.ToJObject();
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
            //  //立项阶段

            //野外勘察
            //
            return list;
        }
       
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetList(string queryJson)
        {
            return service.GetListS(queryJson);
        }
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZYPageList(string queryJson, string condition)
        {
            return service.GetZYPageList(queryJson, condition);
        }
        public object PdState1(string id)
        {
            return service.PdState1(id);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_ZLGC_BASEINFOEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public DataTable ZLGCCountStatics(string ProvinceName,string CityName,string CountyName,string ZLGCYEAR,string ZLGCUNIT, string DC)
        {
            return service.ZLGCCountStatics(ProvinceName, CityName, CountyName, ZLGCYEAR, ZLGCUNIT, DC);
        }
        public DataTable ZLGCCountStaticsNew(string xzqhcode, string ProvinceName, string CityName, string CountyName, string ZLGCYEAR, string ZLGCUNIT)
        {
            return service.ZLGCCountStaticsNew(xzqhcode,ProvinceName, CityName, CountyName, ZLGCYEAR, ZLGCUNIT);
        }
        /// <summary>
        /// 新增治理工程统计方法
        /// </summary>
        /// <param name="codeValue">行政区划代码</param>
        /// <param name="codeType">省市县</param>
        /// <param name="ZLGCYEAR">年份</param>
        /// <param name="ZLGCUNIT">统计单位</param>
        /// <returns></returns>
        public DataTable GetDataZLGCStatics(string codeValue, string codeType, string ZLGCYEAR, string ZLGCUNIT)
        {
            return service.GetDataZLGCStatics(codeValue, codeType, ZLGCYEAR, ZLGCUNIT);
        }
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZLGTJResult(string queryJson)
        {
            return service.GetZLGTJResult(queryJson);
        }
        /// <summary>
        /// 不分页查询治理工程列表信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetListS(string queryJson)
        {
            return service.GetListS(queryJson); 
        }
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZYList(string queryJson, string condition)
        {
            return service.GetZYList(queryJson, condition);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public string RemoveForm(string keyValue)
        {
            try
            {
                string result=service.RemoveForm(keyValue);
                return result;
            
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
        public PASTBL_ZLGC_BASEINFOEntity SaveForm(string keyValue, TBL_ZLGC_BASEINFOEntity entity)
        {
            try
            {
                PASTBL_ZLGC_BASEINFOEntity da = new PASTBL_ZLGC_BASEINFOEntity();
                da = service.SaveForm(keyValue, entity);
                return da;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string SaveForm_New(string keyValue, TBL_ZLGC_BASEINFOEntity entity)
        {
            try
            {
                string result=service.SaveForm_New(keyValue, entity);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
 
        }

        #endregion
    }
}
