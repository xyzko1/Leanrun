using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-07 17:19
    /// 描 述：群测群防观测人信息表
    /// </summary>
    public class TBL_QCQF_OBSERVATIONService : RepositoryFactory<TBL_QCQF_OBSERVATIONEntity>, TBL_QCQF_OBSERVATIONIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_QCQF_OBSERVATIONEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_QCQF_OBSERVATIONEntity>();
             var param = new JObject(); string[] Guids; string PROVINCE = ""; string CITY = ""; string COUNTY = "";
            List<string> _codes = ssoWS.GetAllAuthDistricts();//获取当前用户行政区划
            if (!_codes.Contains("000000"))
            {
                if (_codes[0].EndsWith("0000"))
                {
                    PROVINCE = _codes[0].ToString();
                }
                else if (_codes[0].EndsWith("00"))
                {
                    CITY = _codes[0].ToString();
                }
                else
                {
                    COUNTY = _codes[0].ToString();
                }
            }
            if (!queryJson.Contains("["))
            {
                if (queryJson.ToJObject().ToString() != "{}")
                {
                    param = queryJson.ToJObject();
                    if (!param["OBSERVATIONPEOPLE"].IsEmpty())
                    {
                        string strOBSERVATIONPEOPLE = param["OBSERVATIONPEOPLE"].ToString();
                        expression = expression.And(t => t.OBSERVATIONPEOPLE.Contains(strOBSERVATIONPEOPLE));
                    }
                    if (!param["OBSERVATIONPHONE"].IsEmpty())
                    {
                        string strOBSERVATIONPHONE = param["OBSERVATIONPHONE"].ToString();
                        expression = expression.And(t => t.OBSERVATIONPHONE.Contains(strOBSERVATIONPHONE));
                    }
                    if (!param["ISGCR"].IsEmpty())
                    {
                        string ISGCR = param["ISGCR"].ToString();
                        expression = expression.And(t => t.ISGCR.Contains(ISGCR));
                    }
                    if (!param["PROVINCE"].IsEmpty())
                    {
                        PROVINCE = param["PROVINCE"].ToString();
                        //expression = expression.And(t => t.PROVINCE.Contains(PROVINCE));
                    }
                    if (!param["CITY"].IsEmpty())
                    {
                        CITY = param["CITY"].ToString();
                        //expression = expression.And(t => t.CITY.Contains(CITY));
                    }

                    if (!param["COUNTY"].IsEmpty())
                    {
                        COUNTY = param["COUNTY"].ToString();
                       // expression = expression.And(t => t.COUNTY.Contains(COUNTY));
                    }


                }
            }

            else
            {
                expression = LinqExtensions.False<TBL_QCQF_OBSERVATIONEntity>();
                Guids = queryJson.Trim('[').Trim(']').Split(',');
                for (int i = 0; i < Guids.Count(); i++)
                {
                    string Guid = Guids[i].Trim('"');
                    expression = expression.Or(t => t.ID == Guid);
                }
            }
            if (!PROVINCE.IsEmpty())
            {
                expression = expression.And(t => t.PROVINCE.Contains(PROVINCE));
            }
            if (!CITY.IsEmpty())
            {
                expression = expression.And(t => t.CITY.Contains(CITY));
            }
            if (!COUNTY.IsEmpty())
            {
                expression = expression.And(t => t.COUNTY.Contains(COUNTY));
            }
            return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_QCQF_OBSERVATIONEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_OBSERVATIONEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_QCQF_OBSERVATIONEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_QCQF_OBSERVATIONEntity entity)
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
