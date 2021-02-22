using Infoearth.Application.Entity.CustomerManage;
using Infoearth.Application.IService.CustomerManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using Infoearth.Util.Extension;
using Infoearth.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.CustomerManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� �����ܴ���
    /// �� �ڣ�2016-04-28 16:48
    /// �� �����ֽ����
    /// </summary>
    public class CashBalanceService : RepositoryFactory<CashBalanceEntity>, ICashBalanceService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<CashBalanceEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<CashBalanceEntity>();
            var queryParam = queryJson.ToJObject();
            //��������
            if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                DateTime startTime = queryParam["StartTime"].ToDate();
                DateTime endTime = queryParam["EndTime"].ToDate().AddDays(1);
                expression = expression.And(t => t.F_ExecutionDate >= startTime && t.F_ExecutionDate <= endTime);
            }
            return this.BaseRepository().IQueryable(expression).OrderBy(t => t.F_CreateDate).ToList();
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// �����֧���
        /// </summary>
        /// <param name="db"></param>
        /// <param name="cashBalanceEntity"></param>
        public void AddBalance(IRepository db, CashBalanceEntity cashBalanceEntity)
        {
            decimal balance = 0;
            var data = db.IQueryable<CashBalanceEntity>(t => t.F_CashAccount == cashBalanceEntity.F_CashAccount).OrderByDescending(t => t.F_CreateDate);
            if (data.Count() > 0)
            {
                balance = data.First().F_Balance.ToDecimal();
            }
            if (cashBalanceEntity.F_Receivable != null)
            {
                cashBalanceEntity.F_Balance = cashBalanceEntity.F_Receivable + balance;
            }
            if (cashBalanceEntity.F_Expenses != null)
            {
                cashBalanceEntity.F_Balance = balance - cashBalanceEntity.F_Expenses;
            }
            cashBalanceEntity.Create();
            db.Insert(cashBalanceEntity);
        }
        #endregion
    }
}
