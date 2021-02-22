using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Infoearth.Util;
using Infoearth.Util.Extension;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-07-05 11:26
    /// 描 述：行政体系责任人村组表
    /// </summary>
    public class TBL_QCQF_VILLAGEINFOService : RepositoryFactory<TBL_QCQF_VILLAGEINFOEntity>, TBL_QCQF_VILLAGEINFOIService
    {
        SSOWebApiWS ws = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_QCQF_VILLAGEINFOLXR> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_VILLAGEINFOEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["DISTRICTCODE"].IsEmpty())
            {
                string TOWNCODE = queryParam["DISTRICTCODE"].ToString();
                expression = expression.And(t => t.TOWNCODE.Equals(TOWNCODE));
            }
            var data = this.BaseRepository().FindList(expression, pagination);
            List<TBL_QCQF_VILLAGEINFOLXR> result = new List<TBL_QCQF_VILLAGEINFOLXR>();
            foreach (TBL_QCQF_VILLAGEINFOEntity entity in data)
            {
                TBL_QCQF_VILLAGEINFOLXR entity2 = new TBL_QCQF_VILLAGEINFOLXR();
                entity2.GUID = entity.GUID;
                entity2.VILLAGENAME = entity.VILLAGENAME;
                entity2.MEMO = entity.MEMO;
                entity2.TOWNCODE = entity.TOWNCODE;
                entity2.Telephone = entity.Telephone;
                entity2.USERNAME = entity.USERNAME;
                result.Add(entity2);
            }
            return result;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_VILLAGEINFOLXR> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_VILLAGEINFOEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["DISTRICTCODE"].IsEmpty())
            {
                string TOWNCODE = queryParam["DISTRICTCODE"].ToString();
                expression = expression.And(t => t.TOWNCODE.Equals(TOWNCODE));
            }
            var data = this.BaseRepository().FindList(expression);
            List<TBL_QCQF_VILLAGEINFOLXR> result = new List<TBL_QCQF_VILLAGEINFOLXR>();
            foreach (TBL_QCQF_VILLAGEINFOEntity entity in data)
            {
                TBL_QCQF_VILLAGEINFOLXR entity2 = new TBL_QCQF_VILLAGEINFOLXR();
                entity2.GUID = entity.GUID;
                entity2.VILLAGENAME = entity.VILLAGENAME;
                entity2.MEMO = entity.MEMO;
                entity2.TOWNCODE = entity.TOWNCODE;
                entity2.USERNAME = entity.USERNAME;
                entity2.Telephone = entity.Telephone;
                entity2.CONTACTPEOPLEID = entity.CONTACTPEOPLEID;
                if (entity.CONTACTPEOPLEID != "" & entity.CONTACTPEOPLEID != null)
                    entity2.UserInfo = ws.GetUserFetchByID(entity.CONTACTPEOPLEID);
                result.Add(entity2);
            }
            return result;
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_VILLAGEINFOLXR GetEntity(string keyValue)
        {
            TBL_QCQF_VILLAGEINFOEntity entity = this.BaseRepository().FindEntity(keyValue);
            TBL_QCQF_VILLAGEINFOLXR entity2 = new TBL_QCQF_VILLAGEINFOLXR();
            if (entity == null)
                return null;
            entity2.GUID = entity.GUID;
            entity2.VILLAGENAME = entity.VILLAGENAME;
            entity2.MEMO = entity.MEMO;
            entity2.TOWNCODE = entity.TOWNCODE;
            entity2.CONTACTPEOPLEID = entity.CONTACTPEOPLEID;
            entity2.Telephone = entity.Telephone;
            entity2.USERNAME = entity.USERNAME;
            return entity2;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void DeleteEntity(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, TBL_QCQF_VILLAGEINFOEntity entity)
        {
            if (keyValue =="undefined")
            {
                keyValue = "";
            }
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
    }
}
