﻿using Infoearth.Application.Entity.CustomerManage;
using Infoearth.Application.Entity.CustomerManage.ViewModel;
using Infoearth.Application.IService.CustomerManage;
using Infoearth.Data;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Infoearth.Application.Service.CustomerManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：佘赐雄
    /// 日 期：2016-04-19 17:40
    /// 描 述：应收账款报表
    /// </summary>
    public class ReceivableReportService : RepositoryFactory, IReceivableReportService
    {
        /// <summary>
        /// 获取收款列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<ReceivableReportModel> GetList(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  r.F_ReceivableId ,
                                    o.F_OrderId ,
                                    o.F_OrderCode ,
                                    c.F_CustomerId ,
                                    c.F_EnCode AS F_CustomerCode ,
                                    c.F_FullName AS F_CustomerName ,
                                    r.F_PaymentTime ,
                                    r.F_PaymentPrice ,
                                    r.F_PaymentMode ,
                                    r.F_PaymentAccount ,
                                    r.F_Description ,
                                    r.F_CreateDate ,
                                    r.F_CreateUserName
                            FROM    Client_Receivable r
                                    LEFT JOIN Client_Order o ON o.F_OrderId = r.F_OrderId
                                    LEFT JOIN Client_Customer c ON c.F_CustomerId = o.F_CustomerId
                            WHERE   1 = 1");
            //收款日期
            if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                strSql.Append(" AND r.F_PaymentTime Between @StartTime AND @EndTime ");
                parameter.Add(DbParameters.CreateDbParameter("@StartTime", (queryParam["StartTime"].ToString() + " 00:00").ToDate()));
                parameter.Add(DbParameters.CreateDbParameter("@EndTime", (queryParam["EndTime"].ToString() + " 23:59").ToDate()));
            }
            //订单单号
            if (!queryParam["OrderCode"].IsEmpty())
            {
                strSql.Append(" AND o.F_OrderCode like @OrderCode");
                parameter.Add(DbParameters.CreateDbParameter("@OrderCode", '%' + queryParam["OrderCode"].ToString() + '%'));
            }
            //客户编号
            if (!queryParam["CustomerCode"].IsEmpty())
            {
                strSql.Append(" AND c.F_CustomerCode like @CustomerCode");
                parameter.Add(DbParameters.CreateDbParameter("@CustomerCode", '%' + queryParam["CustomerCode"].ToString() + '%'));
            }
            //客户名称
            if (!queryParam["CustomerName"].IsEmpty())
            {
                strSql.Append(" AND c.F_CustomerName like @CustomerName");
                parameter.Add(DbParameters.CreateDbParameter("@CustomerName", '%' + queryParam["CustomerName"].ToString() + '%'));
            }
            strSql.Append(" ORDER BY r.F_PaymentTime DESC");
            return this.BaseRepository().FindList<ReceivableReportModel>(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<ReceivableReportModel> GetPageList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT TOP(100) PERCENT
                                    r.F_ReceivableId ,
                                    o.F_OrderId ,
                                    o.F_OrderCode ,
                                    c.F_CustomerId ,
                                    c.F_EnCode AS F_CustomerCode ,
                                    c.F_FullName AS F_CustomerName ,
                                    r.F_PaymentTime ,
                                    r.F_PaymentPrice ,
                                    r.F_PaymentMode ,
                                    r.F_PaymentAccount ,
                                    r.F_Description ,
                                    r.F_CreateDate ,
                                    r.F_CreateUserName
                            FROM    Client_Receivable r
                                    LEFT JOIN Client_Order o ON o.F_OrderId = r.F_OrderId
                                    LEFT JOIN Client_Customer c ON c.F_CustomerId = o.F_CustomerId
                            WHERE   1 = 1");
            //收款日期
            if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                strSql.Append(" AND r.F_PaymentTime Between @StartTime AND @EndTime ");
                parameter.Add(DbParameters.CreateDbParameter("@StartTime", (queryParam["StartTime"].ToString() + " 00:00").ToDate()));
                parameter.Add(DbParameters.CreateDbParameter("@EndTime", (queryParam["EndTime"].ToString() + " 23:59").ToDate()));
            }
            //订单单号
            if (!queryParam["OrderCode"].IsEmpty())
            {
                strSql.Append(" AND o.F_OrderCode like @OrderCode");
                parameter.Add(DbParameters.CreateDbParameter("@OrderCode", '%' + queryParam["OrderCode"].ToString() + '%'));
            }
            //客户编号
            if (!queryParam["CustomerCode"].IsEmpty())
            {
                strSql.Append(" AND c.F_CustomerCode like @CustomerCode");
                parameter.Add(DbParameters.CreateDbParameter("@CustomerCode", '%' + queryParam["CustomerCode"].ToString() + '%'));
            }
            //客户名称
            if (!queryParam["CustomerName"].IsEmpty())
            {
                strSql.Append(" AND c.F_CustomerName like @CustomerName");
                parameter.Add(DbParameters.CreateDbParameter("@CustomerName", '%' + queryParam["CustomerName"].ToString() + '%'));
            }
            strSql.Append(" ORDER BY r.F_PaymentTime DESC");
            return this.BaseRepository().FindList<ReceivableReportModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}