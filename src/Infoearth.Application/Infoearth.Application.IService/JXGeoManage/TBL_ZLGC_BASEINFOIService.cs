using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;
using Infoearth.Application.Entity;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:27
    /// 描 述：治理工程信息表
    /// </summary>
    public interface TBL_ZLGC_BASEINFOIService
    {
        EchartEntityNEWS GetListCodes();
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetList(string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetListNew(string queryJson);
        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZYList(string queryJson, string condition);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TBL_ZLGC_BASEINFOEntity GetEntity(string keyValue);
        object PdState1(string id);
        /// <summary>
        /// 治理工程统计
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <param name="CityName"></param>
        /// <param name="CountyName"></param>
        /// <param name="ZLGCYEAR"></param>
        /// <param name="ZLGCUNIT"></param>
        /// <param name="DC"></param>
        /// <returns></returns>
        DataTable ZLGCCountStatics(string ProvinceName, string CityName, string CountyName, string ZLGCYEAR, string ZLGCUNIT, string DC);
        DataTable ZLGCCountStaticsNew(string xzqhcode, string ProvinceName, string CityName, string CountyName, string ZLGCYEAR, string ZLGCUNIT);

        /// <summary>
        /// 新增治理工程统计方法
        /// </summary>
        /// <param name="codeValue">行政区划代码</param>
        /// <param name="codeType">省市县</param>
        /// <param name="ZLGCYEAR">年份</param>
        /// <param name="ZLGCUNIT">统计单位</param>
        /// <returns></returns>
        DataTable GetDataZLGCStatics(string xzqhcode, string codeType, string ZLGCYEAR, string ZLGCUNIT);
        /// <summary>
        /// 治理工程查询浏览
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetListS(string queryJson);

        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZYPageList(string queryJson, string condition);
        TBL_ZLGC_BASEINFOEntity GetEntityByUnifycode(string keyValue, string projectid);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        string RemoveForm(string keyValue);
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        PASTBL_ZLGC_BASEINFOEntity SaveForm(string keyValue, TBL_ZLGC_BASEINFOEntity entity);

        /// <summary>
        /// 新的保存表单方法
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        string SaveForm_New(string keyValue, TBL_ZLGC_BASEINFOEntity entity);
        /// <summary>
        /// 获取治理工程统计结果
        /// </summary>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZLGTJResult(string queryJson);
        #endregion
    }
}
