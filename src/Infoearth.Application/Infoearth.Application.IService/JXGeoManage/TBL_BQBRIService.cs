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
    /// 日 期：2018-04-16 23:25
    /// 描 述：搬迁避让信息表
    /// </summary>
    public interface TBL_BQBRIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<TBL_BQBREntity> GetPageList(Pagination pagination, string queryJson);
        IEnumerable<TBL_BQBREntity> GetEntityByUnifycodeNEW(Pagination pagination, string keyValue);
        IEnumerable<TBL_BQBREntity> GetZYPageList(string queryJson, string condition);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TBL_BQBREntity> GetList(string queryJson);
        IEnumerable<tbl_bqbrnew> GetPageListNEW(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TBL_BQBREntity GetEntity(string keyValue);
        TBL_BQBREntity GetEntityByUnifycode(string keyValue);
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
        DataTable BQBRCountStatics(string ProvinceName, string CityName, string CountyName, string BQBRYEAR, string BQBRUNIT, string EXLType);
        EchartEntityNEWS GetListCodes();
        DataTable GetDataTableList(string queryJson);
        IEnumerable<TBL_BQBREntity> GetZYList(string queryJson, string condition);
        /// <summary>
        /// 搬迁避让统计查询
        /// </summary>
        /// <param name="codeValue">行政区划编号</param>
        /// <param name="codeType">行政区划级别</param>
        /// <param name="xmmc">项目名称</param>
        /// <param name="annual">立项数据</param>
        /// <param name="static_Unit">统计单位</param>
        /// <returns></returns>
        DataTable GetDataBqbrTj(string codeValue, string codeType, string xmmc, string annual, string static_Unit);


        IEnumerable<TreeByBQBRTJ> GetTJ(string queryJson);
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
        string SaveForm(string keyValue, TBL_BQBREntity entity);
        #endregion
    }
}
