using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:23
    /// 描 述：群测群防工作明白卡
    /// </summary>
    public class TBL_QCQF_WORKUNDERSTANDCARDService : RepositoryFactory<TBL_QCQF_WORKUNDERSTANDCARDEntity>, TBL_QCQF_WORKUNDERSTANDCARDIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_QCQF_WORKUNDERSTANDCARDEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_QCQF_WORKUNDERSTANDCARDEntity>();
             return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_WORKUNDERSTANDCARDEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_WORKUNDERSTANDCARDEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_WORKUNDERSTANDCARDEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_QCQF_WORKUNDERSTANDCARDEntity entity)
        {
            //判断避灾明白卡里是否含有相同编号，如果有就更新，没有就
            if (!string.IsNullOrEmpty(entity.UNIFIEDCODE))
            {
                keyValue = entity.UNIFIEDCODE;
                TBL_QCQF_WORKUNDERSTANDCARDEntity Entity = this.BaseRepository().FindEntity(keyValue);
                if (Entity != null)
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.GUID = Guid.NewGuid().ToString();
                    this.BaseRepository().Insert(entity);
                }
            }
        }
        #endregion
    }
}
