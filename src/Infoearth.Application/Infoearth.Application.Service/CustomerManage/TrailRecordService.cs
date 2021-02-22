﻿using Infoearth.Application.Entity.CustomerManage;
using Infoearth.Application.IService.CustomerManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.CustomerManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：佘赐雄
    /// 日 期：2016-03-21 16:10
    /// 描 述：跟进记录
    /// </summary>
    public class TrailRecordService : RepositoryFactory<TrailRecordEntity>, ITrailRecordService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TrailRecordEntity> GetList(string objectId)
        {
            return this.BaseRepository().IQueryable(t => t.F_ObjectId.Equals(objectId)).OrderByDescending(t => t.F_CreateDate).ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TrailRecordEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TrailRecordEntity entity)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                switch (entity.F_ObjectSort)
                {
                    case 1:         //商机
                        ChanceEntity chanceEntity = new ChanceEntity();
                        chanceEntity.Modify(entity.F_ObjectId);
                        db.Update<ChanceEntity>(chanceEntity);
                        break;
                    case 2:         //客户
                        CustomerEntity customerEntity = new CustomerEntity();
                        customerEntity.Modify(entity.F_ObjectId);
                        db.Update<CustomerEntity>(customerEntity);
                        break;
                    default:
                        break;
                }
                entity.Create();
                db.Insert(entity);

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}