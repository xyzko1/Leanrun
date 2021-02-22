using Infoearth.Application.Entity.DemoManage;
using Infoearth.Application.IService.DemoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Infoearth.Util.Extension;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.DemoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-01-09 16:18
    /// 描 述：用户信息表
    /// </summary>
    public class Base_UserService : RepositoryFactory<Base_UserEntity>, Base_UserIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<Base_UserEntity> GetPageList(Pagination pagination, string queryJson)
        {
               var expression = LinqExtensions.True<Base_UserEntity>();
             return this.BaseRepository("LeaRunFramework_Base_2016","SqlServer").FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<Base_UserEntity> GetList(string queryJson)
        {
            return this.BaseRepository("LeaRunFramework_Base_2016","SqlServer").IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Base_UserEntity GetEntity(string keyValue)
        {
            return this.BaseRepository("LeaRunFramework_Base_2016","SqlServer").FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository("LeaRunFramework_Base_2016","SqlServer").Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, Base_UserEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository("LeaRunFramework_Base_2016","SqlServer").Update(entity);
            }
            else
            {
                entity.Create();
               this.BaseRepository("LeaRunFramework_Base_2016","SqlServer").Insert(entity);
            }
        }
        #endregion
    }
}
