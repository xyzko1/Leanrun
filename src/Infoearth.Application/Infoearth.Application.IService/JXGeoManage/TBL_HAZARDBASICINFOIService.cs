using Infoearth.Application.Entity;
using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-14 14:58
    /// 描 述：灾害点基本表
    /// </summary>
    public interface TBL_HAZARDBASICINFOIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetList(string queryJson);
        /// <summary>
        /// 获取灾害类型统计结果
        /// </summary>
        /// <returns></returns>
        DataTable GetDicAnalyse(string enCode);
        DataTable GetListCode(string queryJson);
        EchartEntityNEW GetListCodes(string queryJson);
        EchartEntityNEWS GetListCodesNew();
        EchartEntityCJ GetListDataCJ(string queryJson);
        DataTable GetDataByQcqfReturnHazardbasicInfo(ref Pagination pagination, string queryJson);
        /// <summary>
        /// 检查查询条件语句是否正确
        /// </summary>
        /// <param name="sqlWhere">查询语句条件</param>
        /// <returns></returns>
        bool CheckExpression(string sqlWhere);
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetZYPageList(string queryJson, string condition);
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetZYPageList2(string queryJson, string condition);
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJsonQCQFSearch_Marker(Pagination pagination, string queryJson, string condition,string nsql=null);
        IEnumerable<TBL_HAZARDBASICINFO> GetPageListJsonQCQFSearch_MarkerByInfo (Pagination pagination, string queryJson, string condition,string nsql=null);

        /// <summary>
        /// 行政责任人浏览查询群测群防信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <param name="sql"></param>
        IEnumerable<TBL_HAZARDBASICINFO> GetListJsonQCQFInfo(string queryJson, string condition, string nsql = null);
        string GetWhereSql(string queryJson);
        /// <summary>
        /// 灾害点后四位编号生成
        /// </summary>
        /// <param name="xzqh"></param>
        /// <returns></returns>
        string GetMaxCode(string xzqh);
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetNoQcqfPageList(string queryJson, string condition);
        IEnumerable<PastHAZARDBASICINFO> GetPastListJson2(string queryJson);
        DataTable GetWXRKStatisticsJson(string queryJson);
        DataTable GetWXCCStatisticsJson(string queryJson);
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetZYPageList(string queryJson, string condition, Pagination pagination);
        EchartEntity GetStatisticsByZHLX(string queryJson);
        DataTable GetHistoryStatisticsZHD(string queryJson, ref EchartEntity returnValue);
        DataTable GetTypeStatistics(string queryJson);
        DataTable GetStatisticsByZHLX2(string queryJson);
        /// <summary>
        /// 灾害点统计只按灾害类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        DataTable GetHazardStatisticsJson2(string queryJson);
        int GetAllList();
        /// <summary>
        /// 获取单列数据（用于统计条件查询）
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns>返回列表Json</returns>
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetSinglePageList(Pagination pagination, string queryJson);
        EchartEntity GetStatisticsByXH(string queryJson);
        EchartEntity GetStatisticsByZHD(string queryJson);
        EchartEntity GetStatisticsByXQDJ(string queryJson);
        EchartEntity GetStatisticsByGMDJ(string queryJson);
        EchartEntity GetStatisticsByZQDJ(string queryJson);
        EchartEntity GetStatisticsByZLGC(string queryJson);
        EchartEntity GetStatisticsByBQBR(string queryJson);
        List<string> SSOGeodisaster(string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取列表分页
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJson(Pagination pagination, string queryJson);
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJson2(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取列表分页
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJsons(Pagination pagination, string queryJson, string condition);
        IEnumerable<TBL_HAZARDBASICINFOEntity> PostPageListJsonFirst(Pagination pagination, string queryJson, string condition);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TBL_HAZARDBASICINFOEntity GetEntity(string keyValue);

        /// <summary>
        /// 获取统计数据集合
        /// </summary>
        /// <param name="queryJson">统计条件</param>
        /// <param name="leixingzd">灾害类型字典</param>
        /// <param name="zaihaizd">灾害等级字典</param>
        /// <param name="xianqingzd">险情等级字典</param>
        /// <returns></returns>
        List<TBL_HAZARDBASICINFOEntity> GetCountAnalyseList(string queryJson);

        /// <summary>
        /// 根据条件统计灾害点信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        DataTable GetAnalyseList(string queryJson);
        bool ValidateSQL(string sql);

        DataTable GetZhdAndCityName();
        DataTable GetZhdAndProvinceName();
        /// <summary>
        /// 灾害点统计（按市县、灾害点总数|灾害点类型|灾情等级|险情等级 统计）
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        DataTable GetHazardStatisticsJson(string type);

        /// <summary>
        /// 获取历史数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<PastHAZARDBASICINFO> GetPastPageListJson(Pagination pagination, string queryJson);

        /// <summary>
 		/// 根据UNIFIEDCODE获取实体
        /// </summary>
        /// <param name="UNIFIEDCODE"></param>
        /// <returns></returns>
        TBL_HAZARDBASICINFOEntity GetUNIFIEDCODEEntity(string UNIFIEDCODE);
        /// <summary>        
		/// 获取历史数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<PastHAZARDBASICINFO> GetPastListJson(string queryJson, string condition);

        /// <summary>
        /// 根据灾害点查询浏览导出数据
        /// </summary>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        DataTable GetDataTableList(string queryJson);

        IEnumerable<TBL_HAZARDBASICINFOEntity> GetValue();

        /// <summary>
        /// 根据灾害点统计
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        DataTable GetDataCountTableList(string queryJson, string colum);
        DataTable GetDataCountTableListPC(string queryJson, string colum);
        DataTable GetAnalyseListPC(string queryJson);
        string GetZHDCountResult(string queryJson, int type);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void SaveForm(string keyValue, TBL_HAZARDBASICINFOEntity entity);
        void UpdateForm(string sql);
        #endregion
    }
}
