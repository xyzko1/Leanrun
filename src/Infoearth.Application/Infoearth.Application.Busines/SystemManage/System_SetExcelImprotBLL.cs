using Infoearth.Application.Entity.SystemManage;
using Infoearth.Application.IService.SystemManage;
using Infoearth.Application.Service.SystemManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;

namespace Infoearth.Application.Busines.SystemManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������С��
    /// �� �ڣ�2016-12-04 14:46
    /// �� ����System_SetExcelImprot
    /// </summary>
    public class System_SetExcelImprotBLL
    {
        private System_SetExcelImprotIService service = new System_SetExcelImprotService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<System_SetExcelImprotEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<System_SetExcelImprotEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public System_SetExcelImprotEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void DeleteEntity(string keyValue)
        {
            try
            {

                service.DeleteEntity(keyValue);
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
        /// <param name="filedList">�ֶ��б�</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, System_SetExcelImprotEntity entity,List<System_SetExcelImportFiledEntity> filedList)
        {
            try
            {
                service.SaveEntity(keyValue, entity, filedList);
            }
            catch (Exception)
            {
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
                service.UpdateForm(keyValue, entity);
            }
            catch (Exception)
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
        public DataTable ExcelImport(string keyValue, DataTable dt)
        {
            try
            {
                return service.ExcelImport(keyValue,dt);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion
    }
}
