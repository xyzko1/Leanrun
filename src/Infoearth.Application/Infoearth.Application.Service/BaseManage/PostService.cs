﻿using Infoearth.Application.Entity.BaseManage;
using Infoearth.Application.IService.AuthorizeManage;
using Infoearth.Application.IService.BaseManage;
using Infoearth.Application.Service.AuthorizeManage;
using Infoearth.Data;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Infoearth.Application.Service.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.4 14:31
    /// 描 述：岗位管理
    /// </summary>
    public class PostService : RepositoryFactory<RoleEntity>, IPostService
    {
        private IAuthorizeService<RoleEntity> iauthorizeservice = new AuthorizeService<RoleEntity>();

        #region 获取数据
        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList()
        {
            var expression = LinqExtensions.True<RoleEntity>();
            expression = expression.And(t => t.F_Category == 2).And(t => t.F_EnabledMark == 1).And(t => t.F_DeleteMark == 0);
            return this.BaseRepository().IQueryable(expression).OrderByDescending(t => t.F_CreateDate).ToList();
        }
        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<RoleEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "EnCode":            //岗位编号
                        expression = expression.And(t => t.F_EnCode.Contains(keyword));
                        break;
                    case "FullName":          //岗位名称
                        expression = expression.And(t => t.F_FullName.Contains(keyword));
                        break;
                    default:
                        break;
                }
            }
            expression = expression.And(t => t.F_Category == 2);
            return this.BaseRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// 岗位列表(ALL)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  r.F_RoleId ,
				                    o.F_FullName AS F_OrganizeId ,
				                    r.F_Category ,
				                    r.F_EnCode ,
				                    r.F_FullName ,
				                    r.F_SortCode ,
				                    r.F_EnabledMark ,
				                    r.F_Description ,
				                    r.F_CreateDate
                    FROM    Base_Role r
				                    LEFT JOIN Base_Organize o ON o.F_OrganizeId = r.F_OrganizeId
                    WHERE   o.F_FullName is not null and r.F_Category = 2 and r.F_EnabledMark =1
                    ORDER BY o.F_FullName, r.F_SortCode");
            return this.BaseRepository().FindList(strSql.ToString());
        }
        /// <summary>
        /// 岗位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 岗位编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            var expression = LinqExtensions.True<RoleEntity>();
            expression = expression.And(t => t.F_EnCode == enCode).And(t => t.F_Category == 2);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.F_RoleId != keyValue);
            }
            return this.BaseRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        /// <summary>
        /// 岗位名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            var expression = LinqExtensions.True<RoleEntity>();
            expression = expression.And(t => t.F_FullName == fullName).And(t => t.F_Category == 2);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.F_RoleId != keyValue);
            }
            return this.BaseRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存岗位表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="postEntity">岗位实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, RoleEntity postEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                postEntity.Modify(keyValue);
                this.BaseRepository().Update(postEntity);
            }
            else
            {
                postEntity.Create();
                postEntity.F_Category = 2;
                this.BaseRepository().Insert(postEntity);
            }
        }
        #endregion
    }
}
