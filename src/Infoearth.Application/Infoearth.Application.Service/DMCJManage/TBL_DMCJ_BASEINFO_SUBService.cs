using Infoearth.Application.Entity.DMCJManage;
using Infoearth.Application.IService.DMCJManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using Infoearth.Util;

namespace Infoearth.Application.Service.DMCJManage
{
    /// <summary>
    /// 版 本 Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-09-04 12:02
    /// 描 述：地面沉降调查表SUB
    /// </summary>
    public class TBL_DMCJ_BASEINFO_SUBService : RepositoryFactory<TBL_DMCJ_BASEINFO_SUBEntity>, TBL_DMCJ_BASEINFO_SUBIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_DMCJ_BASEINFO_SUBEntity> GetPageList(Pagination pagination, string queryJson)
        {
             return this.BaseRepository().FindList(pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_DMCJ_BASEINFO_SUBEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_DMCJ_BASEINFO_SUBEntity>();
            var queryParam = queryJson.ToJObject();
            //地面沉降编号
            if (!queryParam["DMCJBH"].IsEmpty())
            {
                string value = queryParam["DMCJBH"].ToString();
                expression = expression.And(t => t.DMCJBH.Equals(value));
            }
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_DMCJ_BASEINFO_SUBEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
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
        public void SaveEntity(string keyValue, TBL_DMCJ_BASEINFO_SUBEntity entity)
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
    }
}
