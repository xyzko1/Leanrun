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
    /// 日 期：2018-06-13 16:22
    /// 描 述：巡查记录表
    /// </summary>
    public class TBL_QCQF_AROUNDRECORDService : RepositoryFactory<TBL_QCQF_AROUNDRECORDEntity>, TBL_QCQF_AROUNDRECORDIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_QCQF_AROUNDRECORDEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_QCQF_AROUNDRECORDEntity>();
             return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// 获取所有列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_AROUNDRECORDEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_AROUNDRECORDEntity>();
            return this.BaseRepository().FindList(expression);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_AROUNDRECORDEntity> GetListByUploadName(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_AROUNDRECORDEntity>();
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                //关键字
                string UPLOADNAME = json.UPLOADNAME;
                if (!string.IsNullOrEmpty(UPLOADNAME))
                {
                    expression = expression.And(t => t.UPLOADNAME.Contains(UPLOADNAME));
                }
            }
            //行政区划账号权限筛选
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            //筛选，获取授权的行政区划
            List<string> author = ws.GetAllAuthDistricts();
            if (author != null && author.Count > 0)
            {
                var expression2 = LinqExtensions.False<TBL_QCQF_AROUNDRECORDEntity>();
                bool flag = false;
                foreach (var au in author)
                {
                    //全国权限
                    if (au.EndsWith("000000") || au.Equals("0"))
                    {
                        flag = false;
                        break;
                    }
                    //省权限
                    else if (au.EndsWith("0000"))
                    {
                        expression2 = expression2.Or(testc => testc.UNIFIEDCODE.StartsWith(au.Substring(0,2)));
                        flag = true;
                    }
                    //市权限
                    else if (au.EndsWith("00"))
                    {
                        expression2 = expression2.Or(testc => testc.UNIFIEDCODE.StartsWith(au.Substring(0, 4)));
                        flag = true;
                    }
                    //县权限
                    else
                    {
                        expression2 = expression2.Or(testc => testc.UNIFIEDCODE.StartsWith(au.Substring(0, 6)));
                        flag = true;
                    }
                }
                if (flag)
                {
                    expression = expression.And(expression2);
                }
                return this.BaseRepository().FindList(expression);
            }
            return this.BaseRepository().FindList(expression);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_AROUNDRECORDEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        public TBL_QCQF_AROUNDRECORDEntity GetFormJsonByUNIFIEDCODE(string keyValue)
        {
            return this.BaseRepository().FindEntity(t=>t.UNIFIEDCODE.Contains(keyValue));
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
        public void SaveForm(string keyValue, TBL_QCQF_AROUNDRECORDEntity entity)
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
        public void SaveFormByUNIFIEDCODE(string keyValue, TBL_QCQF_AROUNDRECORDEntity entity)
        {
            TBL_QCQF_AROUNDRECORDEntity entity_his= this.BaseRepository().FindEntity(t => t.UNIFIEDCODE.Contains(keyValue));
            if (entity_his!=null)
            {
                entity.GUID = entity_his.GUID;
                entity.UNIFIEDCODE = keyValue;
                entity.MONITORTIME = entity_his.MONITORTIME;
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                entity.UNIFIEDCODE = keyValue;
                entity.MONITORTIME = DateTime.Now;
                this.BaseRepository().Insert(entity);

            }
        }
        #endregion
    }
}
