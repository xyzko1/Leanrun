using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using Infoearth.Util.Extension;
using System;
using Infoearth.Util;
using Newtonsoft.Json.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 11:39
    /// 描 述：地裂缝调查表历史表
    /// </summary>
    public class TBL_LANDCRACK_HISTORYService : RepositoryFactory<TBL_LANDCRACK_HISTORYEntity>, TBL_LANDCRACK_HISTORYIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_LANDCRACK_HISTORYEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_LANDCRACK_HISTORYEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                dynamic json = JToken.Parse(queryJson) as dynamic;
                //灾害点编号
                string unifycode = json.unifycode;
                if (!string.IsNullOrEmpty(unifycode))
                {
                    expression = expression.And(t => t.UNIFIEDCODE.Contains(unifycode));
                }

            } 
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_LANDCRACK_HISTORYEntity GetEntity(string keyValue)
        {
            //if (keyValue.Length == 12)
            //{
            //    keyValue = keyValue + " " + " " + " " + " ";
            //}
            return this.BaseRepository().FindEntity(keyValue);
        }
        public TBL_LANDCRACK_HISTORYEntity GetEntityByUNIFIEDCODE(string keyValue)
        {
            return this.BaseRepository().FindEntity(t => t.UNIFIEDCODE.Contains(keyValue));
        }
        
        /// <summary>
        /// 获取当前实体前最近审核通过的实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_LANDCRACK_HISTORYEntity GetAuditEntity(string keyValue)
        {
            var temp = GetEntity(keyValue);
            if (temp == null)
                return null;
            //获取当前实体,找到当前实体前最近审核通过的实体
            return GetWhereSubsetList(new { EndTime = temp.MODIFIEDDATE, UnifyCode = temp.UNIFIEDCODE }.ToJson()).OrderByDescending(t => t.MODIFIEDDATE).FirstOrDefault();
        }

        /// <summary>
        /// 灾害条件查询的基本条件之一
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_LANDCRACK_HISTORYEntity> GetWhereSubsetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_LANDCRACK_HISTORYEntity>();

            //必须是审计通过的数据
            expression = expression.And(t => t.AUDITSTATUS.Equals("2") || t.AUDITSTATUS.Equals("5"));

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

                #region 省市县级联条件

                var expression1 = LinqExtensions.False<TBL_LANDCRACK_HISTORYEntity>();
                //镇
                string TOWN = json.TOWN;
                string TOWNRPT = json.TOWNRPT;
                if (!string.IsNullOrEmpty(TOWN))
                {
                    foreach (var ton in TOWN.Split(','))
                    {
                        expression1 = expression1.Or(t => t.TOWN.Equals(ton));
                    }
                    expression = expression.And(expression1);


                }
                else if (!string.IsNullOrEmpty(TOWNRPT))
                {
                    foreach (var ton in TOWNRPT.Split(','))
                    {
                        expression1 = expression1.Or(t => t.TOWN.Equals(ton));
                    }
                    expression = expression.And(expression1);


                }
                else
                {
                    //县
                    string COUNTY = json.COUNTY;
                    string COUNTYRPT = json.COUNTYRPT;
                    if (!string.IsNullOrEmpty(COUNTY))
                    {
                        foreach (var ton in COUNTY.Split(','))
                        {
                            expression1 = expression1.Or(t => t.COUNTYCODE.Equals(ton));
                        }
                        expression = expression.And(expression1);


                    }
                    else if (!string.IsNullOrEmpty(COUNTYRPT))
                    {
                        foreach (var ton in COUNTYRPT.Split(','))
                        {
                            expression1 = expression1.Or(t => t.COUNTYCODE.Equals(ton));
                        }
                        expression = expression.And(expression1);


                    }
                    else
                    {
                        //市
                        string CITY = json.CITY;
                        string CITYRPT = json.CITYRPT;
                        if (!string.IsNullOrEmpty(CITY))
                        {
                            foreach (var ton in CITY.Split(','))
                            {
                                expression1 = expression1.Or(t => t.CITY.Equals(ton));
                            }
                            expression = expression.And(expression1);


                        }
                        else if (!string.IsNullOrEmpty(CITYRPT))
                        {
                            foreach (var ton in CITYRPT.Split(','))
                            {
                                expression1 = expression1.Or(t => t.CITY.Equals(ton));
                            }
                            expression = expression.And(expression1);


                        }
                        else
                        {
                            //省
                            string PROVINCE = json.PROVINCE;
                            string PROVINCERPT = json.PROVINCERPT;
                            if (!string.IsNullOrEmpty(PROVINCE))
                            {
                                foreach (var ton in PROVINCE.Split(','))
                                {
                                    expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                                }
                                expression = expression.And(expression1);


                            }
                            else if (!string.IsNullOrEmpty(PROVINCERPT))
                            {
                                foreach (var ton in PROVINCERPT.Split(','))
                                {
                                    expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                                }
                                expression = expression.And(expression1);
                            }

                        }
                    }
                }

                #endregion

                //项目类型
                string PROJECTID = json.PROJECTID;
                if (!string.IsNullOrEmpty(PROJECTID))
                {
                    expression = expression.And(t => t.PROJECTID.Equals(PROJECTID));
                }

                //操作类型
                string MODIFYTYPE = json.MODIFYTYPE;
                if (!string.IsNullOrEmpty(MODIFYTYPE))
                {
                    expression = expression.And(t => t.MODIFYTYPE.Equals(MODIFYTYPE));
                }

                //是否已经核销
                string shifouhexiao = json.shifouhexiao;
                if (!string.IsNullOrEmpty(shifouhexiao))
                {
                    expression = expression.And(t => (shifouhexiao == "1" && t.VERIFICATION != null) || (shifouhexiao == "0" && t.VERIFICATION == null));
                }

                //是否治理
                string ISZLGCPNT = json.ISZLGCPNT;
                if (!string.IsNullOrEmpty(ISZLGCPNT))
                {
                    expression = expression.And(t => ISZLGCPNT == "1" ?(t.VERIFICATION!=null&&t.VERIFICATION.Contains("1")):(t.VERIFICATION==null||!t.VERIFICATION.Contains("1")));
                }

                //是否搬迁
                string RELOCATION = json.RELOCATION;
                if (!string.IsNullOrEmpty(RELOCATION))
                {
                    expression = expression.And(t => RELOCATION == "1" ? (t.VERIFICATION != null && t.VERIFICATION.Contains("2")) : (t.VERIFICATION == null || !t.VERIFICATION.Contains("2")));
                }


                //开始时间
                string BeginTime = json.BeginTime;
                if (!string.IsNullOrEmpty(BeginTime))
                {
                    DateTime begin = Convert.ToDateTime(BeginTime);
                    expression = expression.And(t => t.MODIFIEDDATE >= begin);
                }
                //结束时间
                string EndTime = json.EndTime;
                if (!string.IsNullOrEmpty(EndTime))
                {
                    DateTime end = Convert.ToDateTime(EndTime);
                    expression = expression.And(t => t.MODIFIEDDATE < end);
                }

                //统一编号
                string UnifyCode = json.UnifyCode;
                if (!string.IsNullOrEmpty(UnifyCode))
                {
                    expression = expression.And(testc => testc.UNIFIEDCODE == UnifyCode);
                }
                //HAPPENTIME
            }
            return this.BaseRepository().FindList(expression).ToList();
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
        public string SaveForm(string keyValue, TBL_LANDCRACK_HISTORYEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
                return entity.GUID;
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
                return entity.GUID;
            }
        }
        #endregion
    }
}
