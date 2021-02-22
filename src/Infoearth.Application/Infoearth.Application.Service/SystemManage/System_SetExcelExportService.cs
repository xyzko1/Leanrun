using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.IService.SystemManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using Infoearth.Util;
using Infoearth.Util.Extension;
using System.Data.Common;
using Infoearth.Data;
using System.Text;
using System;

namespace Infoearth.Application.Service.SystemManage
{
    /// <summary>
    /// �� �� Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������С��
    /// �� �ڣ�2016-12-07 15:32
    /// �� ����System_SetExcelExport
    /// </summary>
    public class System_SetExcelExportService : RepositoryFactory<System_SetExcelExportEntity>, System_SetExcelExportIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<System_SetExcelExportEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            var expression = LinqExtensions.True<System_SetExcelExportEntity>();
            if (!queryParam["Keyword"].IsEmpty())//�ؼ��ֲ�ѯ
            {
                string keyord = queryParam["Keyword"].ToString();
                expression = expression.And(t => t.F_Name.Contains(keyord));
            }
            if (!queryParam["F_ModuleId"].IsEmpty())//ģ�����Ͳ�ѯ
            {
                string f_ModuleId = queryParam["F_ModuleId"].ToString();
                expression = expression.And(t => t.F_ModuleId == f_ModuleId);
            }
            return this.BaseRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<System_SetExcelExportEntity> GetList(string queryJson)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT
	                            t.F_Id,
	                            t.F_Name,
	                            t.F_GridId,
	                            t.F_ModuleId,
	                            t.F_ModuleBtnId,
	                            t.F_EnabledMark,
	                            t.F_CreateDate,
	                            t.F_CreateUserId,
	                            t.F_CreateUserName,
	                            t.F_ModifyDate,
	                            t.F_ModifyUserId,
	                            t.F_ModifyUserName
                            FROM
	                            System_SetExcelExport t
                            WHERE
	                            1 = 1
            ");
            var parameter = new List<DbParameter>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["F_EnabledMark"].IsEmpty())
            {
                strSql.Append(" AND t.F_EnabledMark = @F_EnabledMark ");
                parameter.Add(DbParameters.CreateDbParameter("@F_EnabledMark", queryParam["F_EnabledMark"].ToString()));
            }
            return this.BaseRepository().FindList(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public System_SetExcelExportEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void DeleteEntity(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, System_SetExcelExportEntity entity)
        {
            var expression = LinqExtensions.True<System_SetExcelExportEntity>();


            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.F_ModuleBtnId == entity.F_ModuleBtnId && t.F_Id == keyValue);
                System_SetExcelExportEntity data = this.BaseRepository().FindEntity(expression);
                if (data != null)
                {
                    throw new Exception("һ����ťֻ�ܰ�һ��");
                }
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                expression = expression.And(t => t.F_ModuleBtnId == entity.F_ModuleBtnId);
                System_SetExcelExportEntity data = this.BaseRepository().FindEntity(expression);
                if (data != null)
                {
                    throw new Exception("һ����ťֻ�ܰ�һ��");
                }
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        /// <summary>
        /// ����ʵ������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        public void UpdateForm(string keyValue, System_SetExcelExportEntity entity)
        {
            try
            {
                var expression = LinqExtensions.True<System_SetExcelExportEntity>();
                if (!string.IsNullOrEmpty(keyValue))
                {
                    expression = expression.And(t => t.F_ModuleBtnId == entity.F_ModuleBtnId && t.F_Id == keyValue);
                    System_SetExcelExportEntity data = this.BaseRepository().FindEntity(expression);
                    if (data != null)
                    {
                        throw new Exception("һ����ťֻ�ܰ�һ��");
                    }
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    throw new System.Exception("�Ҳ�����Ҫ���µ�����");
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
