using Infoearth.Application.Code;
using Infoearth.Application.Entity.CustomerManage;
using Infoearth.Application.IService.CustomerManage;
using Infoearth.Application.IService.SystemManage;
using Infoearth.Application.Service.SystemManage;
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
    /// �� �ڣ�2016-03-12 10:50
    /// �� �����̻���Ϣ
    /// </summary>
    public class ChanceService : RepositoryFactory<ChanceEntity>, IChanceService
    {
        private ICodeRuleService coderuleService = new CodeRuleService();
        private ITrailRecordService trailRecordService = new TrailRecordService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<ChanceEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<ChanceEntity>();
            var queryParam = queryJson.ToJObject();
            //��ѯ����
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "EnCode":              //�̻����
                        expression = expression.And(t => t.F_EnCode.Contains(keyword));
                        break;
                    case "FullName":            //�̻�����
                        expression = expression.And(t => t.F_FullName.Contains(keyword));
                        break;
                    case "Contacts":            //��ϵ��
                        expression = expression.And(t => t.F_Contacts.Contains(keyword));
                        break;
                    case "Mobile":              //�ֻ�
                        expression = expression.And(t => t.F_Mobile.Contains(keyword));
                        break;
                    case "Tel":                 //�绰
                        expression = expression.And(t => t.F_Tel.Contains(keyword));
                        break;
                    case "QQ":                  //QQ
                        expression = expression.And(t => t.F_QQ.Contains(keyword));
                        break;
                    case "Wechat":              //΢��
                        expression = expression.And(t => t.F_Wechat.Contains(keyword));
                        break;
                    case "All":
                        expression = expression.And(t => t.F_FullName.Contains(keyword) 
                            || t.F_Contacts.Contains(keyword)
                            || t.F_Mobile.Contains(keyword) 
                            || t.F_Tel.Contains(keyword)
                            || t.F_QQ.Contains(keyword)
                            || t.F_Wechat.Contains(keyword)
                            || t.F_CompanyName.Contains(keyword)
                            || t.F_Contacts.Contains(keyword)
                            || t.F_City.Contains(keyword)
                            );
                        break;
                    default:
                        break;
                }
            }
            //expression = expression.And(t => t.IsToCustom != 1);
            return this.BaseRepository().FindList(expression, pagination).ToAuthorizeData();
        } 
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public ChanceEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region ��֤����
        /// <summary>
        /// �̻����Ʋ����ظ�
        /// </summary>
        /// <param name="fullName">����</param>
        /// <param name="keyValue">����</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            var expression = LinqExtensions.True<ChanceEntity>();
            expression = expression.And(t => t.F_FullName == fullName);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.F_ChanceId != keyValue);
            }
            return this.BaseRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                db.Delete<ChanceEntity>(keyValue);
                db.Delete<TrailRecordEntity>(t => t.F_ObjectId.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ChanceEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
                try
                {
                    entity.Create();
                    db.Insert(entity);
                    //ռ�õ��ݺ�
                    coderuleService.UseRuleSeed(entity.F_CreateUserId, SystemInfo.CurrentModuleId, "", db);
                    db.Commit();
                }
                catch (Exception)
                {
                    db.Rollback();
                    throw;
                }
            }
        }
        /// <summary>
        /// �̻�����
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        public void Invalid(string keyValue)
        {
            ChanceEntity entity = new ChanceEntity();
            entity.Modify(keyValue);
            entity.F_ChanceState = 0;
            this.BaseRepository().Update(entity);
        }
        /// <summary>
        /// �̻�ת���ͻ�
        /// </summary>
        /// <param name="keyValue">����</param>
        public void ToCustomer(string keyValue)
        {
            ChanceEntity chanceEntity = this.GetEntity(keyValue);
            IEnumerable<TrailRecordEntity> trailRecordList = trailRecordService.GetList(keyValue);
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                chanceEntity.Modify(keyValue);
                chanceEntity.F_IsToCustom = 1;
                db.Update<ChanceEntity>(chanceEntity);

                CustomerEntity customerEntity = new CustomerEntity();
                customerEntity.Create();
                customerEntity.F_EnCode = coderuleService.SetBillCode(customerEntity.F_CreateUserId, "", ((int)CodeRuleEnum.Customer_CustomerCode).ToString(), db);
                customerEntity.F_FullName = chanceEntity.F_CompanyName;
                customerEntity.F_TraceUserId = chanceEntity.F_TraceUserId;
                customerEntity.F_TraceUserName = chanceEntity.F_TraceUserName;
                customerEntity.F_CustIndustryId = chanceEntity.F_CompanyNatureId;
                customerEntity.F_CompanySite = chanceEntity.F_CompanySite;
                customerEntity.F_CompanyDesc = chanceEntity.F_CompanyDesc;
                customerEntity.F_CompanyAddress = chanceEntity.F_CompanyAddress;
                customerEntity.F_Province = chanceEntity.F_Province;
                customerEntity.F_City = chanceEntity.F_City;
                customerEntity.F_Contact = chanceEntity.F_Contacts;
                customerEntity.F_Mobile = chanceEntity.F_Mobile;
                customerEntity.F_Tel = chanceEntity.F_Tel;
                customerEntity.F_Fax = chanceEntity.F_Fax;
                customerEntity.F_QQ = chanceEntity.F_QQ;
                customerEntity.F_Email = chanceEntity.F_Email;
                customerEntity.F_Wechat = chanceEntity.F_Wechat;
                customerEntity.F_Hobby = chanceEntity.F_Hobby;
                customerEntity.F_Description = chanceEntity.F_Description;
                customerEntity.F_CustLevelId = "C";
                customerEntity.F_CustDegreeId = "�����ͻ�";
                db.Insert<CustomerEntity>(customerEntity);

                foreach (TrailRecordEntity item in trailRecordList)
                {
                    item.F_TrailId = Guid.NewGuid().ToString();
                    item.F_ObjectId = customerEntity.F_CustomerId;
                    item.F_ObjectSort = 2;
                    db.Insert<TrailRecordEntity>(item);
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
    }
}
