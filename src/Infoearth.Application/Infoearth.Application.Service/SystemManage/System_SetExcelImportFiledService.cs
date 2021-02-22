using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.IService.SystemManage;
using Infoearth.Data;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Infoearth.Application.Service.SystemManage
{
    /// <summary>
    /// �� �� Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������С��
    /// �� �ڣ�2016-12-04 14:46
    /// �� ����System_SetExcelImportFiled
    /// </summary>
    public class System_SetExcelImportFiledService : RepositoryFactory<System_SetExcelImportFiledEntity>, System_SetExcelImportFiledIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<System_SetExcelImportFiledEntity> GetPageList(Pagination pagination, string queryJson)
        {
             return this.BaseRepository().FindList(pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<System_SetExcelImportFiledEntity> GetList(string queryJson)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT
	                        t.F_Id,
	                        t.F_ImportTemplateId,
	                        t.F_FliedName,
	                        t.F_FiledType,
	                        t.F_ColName,
                            t.F_OnlyOne,
	                        t.F_RelationType,
	                        t.F_DataItemEncode,
	                        t.F_Value,
	                        t.F_DbId,
	                        t.F_DbTable,
	                        t.F_DbSaveFlied,
	                        t.F_DbRelationFlied,
	                        t.F_SortCode
                        FROM
	                        System_SetExcelImportFiled t
                        WHERE 1=1
                        
            ");
            var parameter = new List<DbParameter>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["F_ImportTemplateId"].IsEmpty())
            {
                strSql.Append(" AND t.F_ImportTemplateId = @F_ImportTemplateId ");
                parameter.Add(DbParameters.CreateDbParameter("@F_ImportTemplateId", queryParam["F_ImportTemplateId"].ToString()));
            }
            strSql.Append(" ORDER BY t.F_SortCode ");
            return this.BaseRepository().FindList(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public System_SetExcelImportFiledEntity GetEntity(string keyValue)
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
        public void SaveEntity(string keyValue, System_SetExcelImportFiledEntity entity)
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
    }
}
