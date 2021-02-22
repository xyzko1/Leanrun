using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using System;
using Infoearth.Util.Extension;
using Newtonsoft.Json.Linq;
using Infoearth.Util;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 11:51
    /// 描 述：滑坡调查表历史表
    /// </summary>
    public class TBL_LANDSLIP_HIDDEN_HISTORYService : RepositoryFactory<TBL_LANDSLIP_HIDDEN_HISTORYEntity>, TBL_LANDSLIP_HIDDEN_HISTORYIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_LANDSLIP_HIDDEN_HISTORYEntity> GetPageList(Pagination pagination, string queryJson)
        {
             return this.BaseRepository().FindList(pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_LANDSLIP_HIDDEN_HISTORYEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_LANDSLIP_HIDDEN_HISTORYEntity>();

            if (!string.IsNullOrEmpty(queryJson))
            {
                dynamic json = JToken.Parse(queryJson) as dynamic;

                //通过数据
                string audited = json.audited;
                if (!string.IsNullOrEmpty(audited))
                {
                    expression = expression.And(t => t.AUDITSTATUS == "1" || t.AUDITSTATUS == "5");
                }

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
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetEntity(string keyValue)
        {
            //if (keyValue.Length == 12)
            //{
            //    keyValue = keyValue + " " + " " + " " + " ";
            //}
            return this.BaseRepository().FindEntity(keyValue);
        }
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetEntityByUNIFIEDCODE(string keyValue)
        {
            return this.BaseRepository().FindEntity(t=>t.UNIFIEDCODE.Contains(keyValue));
        }
        /// <summary>
        /// 获取当前实体前最近审核通过的实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetAuditEntity(string keyValue)
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
        public IEnumerable<TBL_LANDSLIP_HIDDEN_HISTORYEntity> GetWhereSubsetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_LANDSLIP_HIDDEN_HISTORYEntity>();

            //必须是审计通过的数据
            expression = expression.And(t => t.AUDITSTATUS.Equals("2") || t.AUDITSTATUS.Equals("5"));

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

                #region 省市县级联条件

                var expression1 = LinqExtensions.False<TBL_LANDSLIP_HIDDEN_HISTORYEntity>();
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
        public void SaveEntity(string keyValue, TBL_LANDSLIP_HIDDEN_HISTORYEntity entity)
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


        /// <summary>
        /// 获取最新审核的数据
        /// </summary>
        /// <param name="unifycode"></param>
        /// <returns></returns>
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetLatestEntity(string unifycode)
        {
            var expression = LinqExtensions.True<TBL_LANDSLIP_HIDDEN_HISTORYEntity>();
            expression = expression.And(t => t.AUDITSTATUS == "1" || t.AUDITSTATUS == "5");
            expression = expression.And(t => t.UNIFIEDCODE == unifycode);

            var result = this.BaseRepository().FindList(expression).OrderBy(t => t.MODIFIEDDATE).ToList();
            if (result.Count > 0)
                return result[result.Count - 1];
            return null;
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="entity"></param>
        public void InsertEntity(TBL_LANDSLIP_HIDDEN_HISTORYEntity entity)
        {
            this.BaseRepository().Insert(entity);
        }
    }
}
