using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.IService.SystemManage;
using Infoearth.Data;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;

namespace Infoearth.Application.Service.SystemManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-09-07 09:39
    /// �� ����Base_DataSource
    /// </summary>
    public class DataSourceService : RepositoryFactory<DataSourceEntity>, IDataSourceService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<DataSourceEntity> GetList(string queryJson)
        {
            return this.BaseRepository().IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public DataSourceEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        /// <summary>
        /// Դ���ݹ����б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public IEnumerable<DataSourceEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<DataSourceEntity>();
            var queryParam = queryJson.ToJObject();
            //��ѯ����
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyord = queryParam["keyword"].ToString();
                expression = expression.And(t => t.F_Name.Contains(keyord));
            }
            return this.BaseRepository().FindList(expression, pagination);
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
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DataSourceEntity entity)
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

        #region �ӿ����ݴ���
        /// <summary>
        /// ��ȡ�ӿ�����
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dbConnection"></param>
        /// <param name="dbType"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetData(string strSql, string dbConnection, string dbType, string queryJson = "{}")
        {
            try
            {
                var parameter = new List<DbParameter>();
                var queryParam = queryJson.ToJObject();
                Regex myReg = new Regex("&.*\\b");
                var parameterNames = myReg.Matches(strSql);
                foreach (var item in parameterNames)
                {
                    string strItem = item.ToString().Replace("&","");
                    if (!queryParam[strItem].IsEmpty())
                    {
                        parameter.Add(DbParameters.CreateDbParameter("@" + strItem, queryParam[strItem].ToString()));
                    }
                }
                string resStrSql = strSql.Replace("&","@");
                return this.BaseRepository(dbConnection).FindTable(resStrSql, parameter.ToArray());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
