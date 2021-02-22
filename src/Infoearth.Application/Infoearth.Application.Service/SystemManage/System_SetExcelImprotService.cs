using Infoearth.Application.Code;
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
using System.Globalization;
using System.Text;
//using System.Data.Common;

namespace Infoearth.Application.Service.SystemManage
{
    /// <summary>
    /// �� �� Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������С��
    /// �� �ڣ�2016-12-04 14:46
    /// �� ����System_SetExcelImprot
    /// </summary>
    public class System_SetExcelImprotService : RepositoryFactory, System_SetExcelImprotIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<System_SetExcelImprotEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            var expression = LinqExtensions.True<System_SetExcelImprotEntity>();
            if (!queryParam["Keyword"].IsEmpty())//�ؼ��ֲ�ѯ
            {
                string keyord = queryParam["Keyword"].ToString();
                expression = expression.And(t => t.F_Name.Contains(keyord) );
            }
            if (!queryParam["F_ModuleId"].IsEmpty())//ģ�����Ͳ�ѯ
            {
                string f_ModuleId = queryParam["F_ModuleId"].ToString();
                expression = expression.And(t => t.F_ModuleId == f_ModuleId);
            }
            return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<System_SetExcelImprotEntity> GetList(string queryJson)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT
	                            t.F_Id,
	                            t.F_Name,
	                            t.F_ModuleId,
	                            t.F_ModuleBtnId,
	                            t.F_DbId,
	                            t.F_DbTable,
	                            t.F_ErrorType,
	                            t.F_EnabledMark,
                                t.F_Description,
	                            t.F_CreateDate,
	                            t.F_CreateUserId,
	                            t.F_CreateUserName,
	                            t.F_ModifyDate,
	                            t.F_ModifyUserId,
	                            t.F_ModifyUserName
                            FROM
	                            System_SetExcelImprot t
                            WHERE 1=1 
            ");
            var parameter = new List<DbParameter>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["F_EnabledMark"].IsEmpty())
            {
                strSql.Append(" AND t.F_EnabledMark = @F_EnabledMark ");
                parameter.Add(DbParameters.CreateDbParameter("@F_EnabledMark", queryParam["F_EnabledMark"].ToString()));
            }
            return this.BaseRepository().FindList<System_SetExcelImprotEntity>(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public System_SetExcelImprotEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<System_SetExcelImprotEntity>(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void DeleteEntity(string keyValue)
        {
           
            var db = this.BaseRepository().BeginTrans();
            try
            {
                System_SetExcelImprotEntity entity = db.FindEntity<System_SetExcelImprotEntity>(keyValue);
                var expression = LinqExtensions.True<System_SetExcelImportFiledEntity>();
                string f_ImportTemplateId = entity.F_Id;
                expression = expression.And(t => t.F_ImportTemplateId == f_ImportTemplateId);
                db.Delete<System_SetExcelImprotEntity>(keyValue);
                db.Delete(expression);
                db.Commit();
            }
            catch (System.Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ������</param>
        /// <param name="filedList">�ֶ��б�</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, System_SetExcelImprotEntity entity,List<System_SetExcelImportFiledEntity> filedList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    db.Update(entity);
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                }

                var expression = LinqExtensions.True<System_SetExcelImportFiledEntity>();
                string f_ImportTemplateId = entity.F_Id;
                expression = expression.And(t => t.F_ImportTemplateId == f_ImportTemplateId);
                db.Delete(expression);

                foreach (var item in filedList)
                {
                    item.F_ImportTemplateId = f_ImportTemplateId;
                    item.Create();
                    db.Insert(item);
                }

                db.Commit();
            }
            catch (System.Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// ����ʵ������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        public void UpdateForm(string keyValue, System_SetExcelImprotEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
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

        #region ��չ����
        /// <summary>
        /// ִ��excelģ�����ݵ���
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable ExcelImport(string keyValue,DataTable dt)
        {
            System_SetExcelImportFiledService filedService = new System_SetExcelImportFiledService();
            DataItemDetailService dataItemService = new DataItemDetailService();
            DataBaseLinkService dbService = new DataBaseLinkService();
            try
            {
                System_SetExcelImprotEntity templateInfo = this.BaseRepository().FindEntity<System_SetExcelImprotEntity>(keyValue);
                IEnumerable<System_SetExcelImportFiledEntity> filedsInfo = filedService.GetList("{\"F_ImportTemplateId\":\"" + templateInfo.F_Id + "\"}");

                Dictionary<string, IEnumerable<DataItemDetailEntity>> dicDataItem = new Dictionary<string, IEnumerable<DataItemDetailEntity>>();
                DataBaseLinkEntity linkEntity = dbService.GetEntity(templateInfo.F_DbId);
                DatabaseType dbType = DatabaseType.SqlServer;
                if(linkEntity!=null)
                {
                    if(linkEntity.F_DbType.ToLower()=="oracle")
                    {
                        dbType = DatabaseType.Oracle;
                    }
                    else if(linkEntity.F_DbType.ToLower()=="sqlserver")
                    {
                        dbType = DatabaseType.SqlServer;
                    }
                    else if (linkEntity.F_DbType.ToLower() == "mysql")
                    {
                        dbType = DatabaseType.MySql;
                    }
                }
                string sql = " INSERT INTO " + templateInfo.F_DbTable + " (";
                string sqlValue = "(";
                bool isfirt = true;
                //��֯sql���
                //INSERT INTO table_name (��1, ��2,...) VALUES (ֵ1, ֵ2,....)
                foreach (var col in filedsInfo)
                {
                    if (!isfirt)
                    {
                        sql += ",";
                        sqlValue += ",";
                    }
                    sql += col.F_FliedName;
                    sqlValue += "@" + col.F_FliedName;
                    isfirt = false;
                }
                sql += " ) VALUES " + sqlValue + ")";

                string sqlonly = " select * from " + templateInfo.F_DbTable + " where ";

                dt.Columns.Add("learunColOk", typeof(string));
                dt.Columns.Add("learunColError", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        var parameter = new List<DbParameter>();
                        foreach (var col in filedsInfo)
                        {
                            string paramName = "@" + col.F_FliedName;
                           
                            switch (col.F_RelationType)
                            {
                                case 0://�޹���
                                    if (col.F_FiledType == "����")
                                    {
                                        string dtValue = dr[col.F_ColName].ToString();
                                        if (string.IsNullOrEmpty(dtValue))
                                        {
                                            parameter.Add(DbParameters.CreateDbParameter(paramName, dr[col.F_ColName].ToString(), dbType));
                                        }
                                        else
                                        {
                                            DateTime time = ConvrtDT(dtValue);
                                            parameter.Add(DbParameters.CreateDbParameter(paramName, time, dbType));
                                        }
                                    }
                                    else
                                    {
                                        parameter.Add(DbParameters.CreateDbParameter(paramName, dr[col.F_ColName].ToString(), dbType));
                                    }
                                    IsOnlyOne(dbService, col, sqlonly, dr[col.F_ColName].ToString(), templateInfo.F_DbId);
                                    break;
                                case 1://GUID
                                    parameter.Add(DbParameters.CreateDbParameter(paramName, Guid.NewGuid().ToString(), dbType));
                                    break;
                                case 2://�����ֵ�
                                    string dataItemName = "";
                                    if (!dicDataItem.ContainsKey(col.F_FliedName))
                                    {
                                        IEnumerable<DataItemDetailEntity> dataItemList = dataItemService.GetList(col.F_DataItemEncode);
                                        dicDataItem.Add(col.F_FliedName, dataItemList);
                                    }
                                    dataItemName = FindDataItemName(dicDataItem[col.F_FliedName], dr[col.F_ColName].ToString(), col.F_ColName);
                                    parameter.Add(DbParameters.CreateDbParameter(paramName, dataItemName, dbType));

                                    IsOnlyOne(dbService, col, sqlonly, dataItemName, templateInfo.F_DbId);
                                    break;
                                case 3://���ݱ�
                                    string v = "";
                                    try
                                    {
                                        string strSql = "select " + col.F_DbSaveFlied + " from " + col.F_DbTable + " where " + col.F_DbRelationFlied + " = @" + col.F_DbRelationFlied;
                                        var parameter2 = new List<DbParameter>();
                                        parameter2.Add(DbParameters.CreateDbParameter("@" + col.F_DbRelationFlied, dr[col.F_ColName].ToString(), dbType));
                                        DataTable dt2 = dbService.FindTable(col.F_DbId, strSql, parameter2.ToArray());
                                        v = dt2.Rows[0][0].ToString();
                                        parameter.Add(DbParameters.CreateDbParameter(paramName, dt2.Rows[0][0].ToString(), dbType));

                                        
                                    }
                                    catch (Exception)
                                    {
                                        throw (new Exception("��" + col.F_ColName + "�� �Ҳ�����Ӧ������"));
                                    }
                                    IsOnlyOne(dbService, col, sqlonly, v, templateInfo.F_DbId);
                                    break;
                                case 4://�̶�ֵ
                                    parameter.Add(DbParameters.CreateDbParameter(paramName, col.F_Value, dbType));
                                    break;
                                case 5://������ID
                                    parameter.Add(DbParameters.CreateDbParameter(paramName, OperatorProvider.Provider.Current().UserId, dbType));
                                    break;
                                case 6://����������
                                    parameter.Add(DbParameters.CreateDbParameter(paramName, OperatorProvider.Provider.Current().UserName, dbType));
                                    break;
                                case 7://����ʱ��
                                    parameter.Add(DbParameters.CreateDbParameter(paramName, DateTime.Now, dbType));
                                    break;
                            }
                        }
                        dbService.ExecuteBySql(templateInfo.F_DbId, sql, parameter.ToArray());
                        dr["learunColOk"] = "1";
                    }
                    catch(Exception ex)
                    {
                        if (templateInfo.F_ErrorType == 0)
                        {
                            break;
                        }
                        dr["learunColOk"] = "0";
                        dr["learunColError"] = ex.Message;
                    }
                }

                return dt;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        private static DateTime ConvrtDT(string value)
        {
            string[] dtFormat = new string[] { "M-d-yy", "yyyy-M-d", "yyyy��M��d��", "yyyy/M/d", "M/d/yy", "yyyy-MM-dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss", "yyyy-MM-dd" };
            DateTime resultDT = DateTime.Now;
            try
            {
                resultDT = DateTime.ParseExact(value, dtFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AllowInnerWhite);
                return resultDT;
            }
            catch
            {
                return resultDT;
            }
        }
        /// <summary>
        /// �����ֵ����name
        /// </summary>
        /// <param name="dataItemList"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        private string FindDataItemName(IEnumerable<DataItemDetailEntity> dataItemList, string itemName,string colName)
        {
            foreach (var one in dataItemList)
            {
                if (one.F_ItemName == itemName)
                {
                    return one.F_ItemValue;
                }
            }
            throw (new Exception("��" + colName + "�������ֵ��Ҳ�����Ӧֵ"));
        }
        /// <summary>
        /// �ж��Ƿ��������ظ�
        /// </summary>
        /// <param name="dbService"></param>
        /// <param name="col"></param>
        /// <param name="sqlonly"></param>
        /// <param name="value"></param>
        /// <param name="dbId"></param>
        private void IsOnlyOne(DataBaseLinkService dbService,System_SetExcelImportFiledEntity col,string sqlonly,string value,string dbId)
        {
            if (col.F_OnlyOne == 1)
            {
                var parameter = new List<DbParameter>();

                sqlonly += col.F_FliedName + " = @" + col.F_FliedName;
                parameter.Add(DbParameters.CreateDbParameter("@" + col.F_FliedName, value));

                var d = dbService.FindTable(dbId, sqlonly, parameter.ToArray());
                if (d.Rows.Count > 0)
                {
                    throw new Exception("��" + col.F_ColName + "���������ݲ����ظ�");
                }
            }
        }
        #endregion
    }
}
