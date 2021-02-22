using Infoearth.Application.Entity.DemoManage;
using Infoearth.Application.IService.DemoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.DemoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.1.7
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-10-17 09:47
    /// �� ������������
    /// </summary>
    public class Client_OrderService : RepositoryFactory, Client_OrderIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<Client_OrderEntity> GetPageList(Pagination pagination, string queryJson)
        {
             return this.BaseRepository().FindList<Client_OrderEntity>(pagination);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public Client_OrderEntity GetEntity(string keyValue)
        {
             return this.BaseRepository().FindEntity<Client_OrderEntity>(keyValue);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<Client_OrderEntryEntity> GetDetails(string keyValue)
        {
            return this.BaseRepository().FindList<Client_OrderEntryEntity>("select * from Client_OrderEntry where F_OrderId='"+keyValue +"'");        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
             IRepository db = this.BaseRepository().BeginTrans();
             try
             {
                 db.Delete<Client_OrderEntity>(keyValue);
                 db.Delete<Client_OrderEntryEntity>(t => t.F_OrderId.Equals(keyValue));
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
        /// <param name="entryList">�ӱ�ʵ������б�</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, Client_OrderEntity entity,List<Client_OrderEntryEntity> entryList)
        {
        IRepository db = this.BaseRepository().BeginTrans();
        try
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                //����
                entity.Modify(keyValue);
                db.Update(entity);
                //��ϸ
                db.Delete<Client_OrderEntryEntity>(t => t.F_OrderId.Equals(keyValue));
                foreach (Client_OrderEntryEntity item in entryList)
                {
                    item.Create();
                    item.F_OrderId = entity.F_OrderId;
                    db.Insert(item);
                }
            }
            else
            {
                //����
                entity.Create();
                db.Insert(entity);
                //��ϸ
                foreach (Client_OrderEntryEntity item in entryList)
                {
                    item.Create();
                    item.F_OrderId = entity.F_OrderId;
                    db.Insert(item);
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
        #endregion
    }
}
