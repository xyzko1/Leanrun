﻿using Infoearth.Application.Entity.AuthorizeManage;
using Infoearth.Application.IService.AuthorizeManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infoearth.Application.Service.BaseManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.10.27 09:16
    /// 描 述：系统功能
    /// </summary>
    public class ModuleService : RepositoryFactory<ModuleEntity>, IModuleService
    {
        #region 获取数据
        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public int GetSortCode()
        {
            int sortCode = this.BaseRepository().IQueryable().Max(t => t.F_SortCode).ToInt();
            if (!string.IsNullOrEmpty(sortCode.ToString()))
            {
                return sortCode + 1;
            }
            return 100001;
        }
        /// <summary>
        /// 功能列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM bASE_Module Order By F_SortCode");
            return this.BaseRepository().FindList(strSql.ToString());
        }
        /// <summary>
        /// 功能实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }

        /// <summary>
        /// 根据菜单Url获取菜单
        /// </summary>
        /// <param name="url">菜单Url</param>
        /// <returns></returns>
        public ModuleEntity GetModuleByUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            return this.BaseRepository().IQueryable().Where(t => t.F_UrlAddress.ToLower() == url.ToLower()).FirstOrDefault();
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 功能编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            var expression = LinqExtensions.True<ModuleEntity>();
            expression = expression.And(t => t.F_EnCode == enCode);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.F_ModuleId != keyValue);
            }
            return this.BaseRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        /// <summary>
        /// 功能名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            var expression = LinqExtensions.True<ModuleEntity>();
            expression = expression.And(t => t.F_FullName == fullName);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.F_ModuleId != keyValue);
            }
            return this.BaseRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                int count = db.IQueryable<ModuleEntity>(t => t.F_ParentId == keyValue).Count();
                if (count > 0)
                {
                    throw new Exception("当前所选数据有子节点数据！");
                }
                db.Delete<ModuleEntity>(keyValue);
                db.Delete<ModuleButtonEntity>(t => t.F_ModuleId.Equals(keyValue));
                db.Delete<ModuleColumnEntity>(t => t.F_ModuleId.Equals(keyValue));

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="moduleEntity">功能实体</param>
        /// <param name="moduleButtonList">按钮实体列表</param>
        /// <param name="moduleColumnList">视图实体列表</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ModuleEntity moduleEntity, List<ModuleButtonEntity> moduleButtonList, List<ModuleColumnEntity> moduleColumnList)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    moduleEntity.Modify(keyValue);
                    db.Update(moduleEntity);
                }
                else
                {
                    moduleEntity.Create();
                    db.Insert(moduleEntity);
                }
                db.Delete<ModuleButtonEntity>(t => t.F_ModuleId.Equals(keyValue));
                if (moduleButtonList != null)
                {
                    foreach (var item in moduleButtonList)
                    {
                        if (item.F_ModuleButtonId == null)
                        {
                            item.Create();
                        }
                        //item.Create();解决代码生成器自动生成按钮报错问题 bugatti 2017-04-11
                        item.F_ModuleId = moduleEntity.F_ModuleId;
                        db.Insert(item);
                    }
                }
                db.Delete<ModuleColumnEntity>(t => t.F_ModuleId.Equals(keyValue));
                if (moduleColumnList != null)
                {
                    db.Insert(moduleColumnList);
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
        public void InitModules()
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                var modules = db.IQueryable<ModuleEntity>().ToList();
                var moduleButtons = db.IQueryable<ModuleButtonEntity>().ToList();
                //删除数据
                string sqlDel = "delete from Base_ModuleButton";
                this.BaseRepository().ExecuteBySql(sqlDel);
                sqlDel = "delete from Base_Module";
                this.BaseRepository().ExecuteBySql(sqlDel);
                foreach (var item in modules)
                {
                    string id1 = item.F_ModuleId;
                    string id = Guid.NewGuid().ToString();
                    item.F_ModuleId = id;
                    //修改子节点父Id
                    var tmpM = modules.Where(t => t.F_ParentId == id1).ToList();
                    if (tmpM != null && tmpM.Count > 0)
                    {
                        foreach (var item1 in tmpM)
                        {
                            item1.F_ParentId = id;
                        }
                    }
                    db.Insert<ModuleEntity>(item);
                    //修改按钮
                    var tmpMB = moduleButtons.Where(t => t.F_ModuleId == id1).ToList();
                    if (tmpMB != null && tmpMB.Count > 0)
                    {
                        foreach (var item1 in tmpMB)
                        {
                            item1.F_ModuleId = id;
                            item1.F_ModuleButtonId = Guid.NewGuid().ToString();
                        }
                        db.Insert<ModuleButtonEntity>(tmpMB);
                    }
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }

        }
    }
}
