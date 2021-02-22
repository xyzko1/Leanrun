using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 15:53
    /// �� �������빤����Ŀ������Ϣ��
    /// </summary>
    public class JYGC_PROJECTBASEINFOBLL
    {
        private JYGC_PROJECTBASEINFOIService service = new JYGC_PROJECTBASEINFOService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<JYGC_PROJECTBASEINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<JYGC_PROJECTBASEINFOEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public JYGC_PROJECTBASEINFOEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        public List<string> GetProjectIDList(string queryJson)
        {
            return service.GetProjectIDList(queryJson);
        }
        public List<JYGC_PROJECTBASEINFOEntity> GetListByDateDiff(string queryJson)
        {
            return service.GetListByDateDiff(queryJson);
        }
        /// <summary>
        /// ��ȡ���ߴ���һ����ĿID
        /// </summary>
        /// <param name="projectName">��Ŀ����</param>
        /// <returns></returns>
        public JYGC_PROJECTBASEINFOEntity GetOrCreateProjectId(string projectName)
        {
            return service.GetOrCreateProjectId(projectName);
        }
        public string GetTCYearProject(string queryJson)
        {
            return service.GetTCYearProject(queryJson);
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
        /// <returns></returns>
        public void SaveEntity(string keyValue, JYGC_PROJECTBASEINFOEntity entity)
        {
            try
            {
                service.SaveEntity(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

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
        public void SaveForm(string keyValue, JYGC_PROJECTBASEINFOEntity entity)
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
       
    }
}
