using Infoearth.Application.Entity.CustomerManage;
using Infoearth.Application.IService.CustomerManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
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
    /// �� �ڣ�2016-04-20 11:23
    /// �� ��������֧��
    /// </summary>
    public class ExpensesService : RepositoryFactory<ExpensesEntity>, IExpensesService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<ExpensesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<ExpensesEntity>();
            var queryParam = queryJson.ToJObject();
            //֧������
            if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                DateTime startTime = queryParam["StartTime"].ToDate();
                DateTime endTime = queryParam["EndTime"].ToDate().AddDays(1);
                expression = expression.And(t => t.F_ExpensesDate >= startTime && t.F_ExpensesDate <= endTime);
            }
            //֧������
            if (!queryParam["ExpensesType"].IsEmpty())
            {
                string CustomerName = queryParam["ExpensesType"].ToString();
                expression = expression.And(t => t.F_ExpensesType.Equals(CustomerName));
            }
            //������
            if (!queryParam["Managers"].IsEmpty())
            {
                string SellerName = queryParam["Managers"].ToString();
                expression = expression.And(t => t.F_Managers.Contains(SellerName));
            }
            return this.BaseRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<ExpensesEntity> GetList(string queryJson)
        {
            return this.BaseRepository().IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public ExpensesEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// �������������
        /// </summary>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(ExpensesEntity entity)
        {
            ICashBalanceService icashbalanceservice = new CashBalanceService();

            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                //֧��
                entity.Create();
                db.Insert(entity);


                //����˻����
                icashbalanceservice.AddBalance(db, new CashBalanceEntity
                {
                    F_ObjectId = entity.F_ExpensesId,
                    F_ExecutionDate = entity.F_ExpensesDate,
                    F_CashAccount = entity.F_ExpensesAccount,
                    F_Expenses = entity.F_ExpensesPrice,
                    F_Abstract = entity.F_ExpensesAbstract
                });

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
