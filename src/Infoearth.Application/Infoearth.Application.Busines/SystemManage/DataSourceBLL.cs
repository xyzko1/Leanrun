using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.IService.SystemManage;
using Infoearth.Application.Service.SystemManage;
using System.Collections.Generic;
using System;
using System.Data;
using Infoearth.Util.WebControl;

namespace Infoearth.Application.Busines.SystemManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-09-07 09:39
    /// �� ����Base_DataSource
    /// </summary>
    public class DataSourceBLL
    {
        private IDataSourceService service = new DataSourceService();
        private IDataBaseLinkService dataBaseLinkService = new DataBaseLinkService();
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<DataSourceEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public DataSourceEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        /// <summary>
        /// Դ���ݹ����б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public IEnumerable<DataSourceEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DataSourceEntity entity)
        {
            try
            {
                service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region �ӿ����ݴ���
        /// <summary>
        /// ��ȡ�ӿ�����
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetData(DataSourceEntity entity , string queryJson)
        {
            try
            {
                DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(entity.F_DbId);
                if (dataBaseLinkEntity != null)
                {
                    return service.GetData(entity.F_Strsql, dataBaseLinkEntity.F_DbConnection, queryJson);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// ��ȡ���ݱ������
        /// </summary>
        /// <param name="dbLinkId"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetTableData(string dbLinkId, string tableName)
        {
            try
            {
                DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dbLinkId);
                if (dataBaseLinkEntity != null)
                {
                    string strSQL = "select * from " + tableName;
                    return service.GetData(strSQL, dataBaseLinkEntity.F_DbConnection, dataBaseLinkEntity.F_DbType);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion
    }
}
