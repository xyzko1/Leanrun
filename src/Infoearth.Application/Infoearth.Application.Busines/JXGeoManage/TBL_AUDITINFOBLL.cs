using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-17 14:51
    /// �� ���������Ϣ��
    /// </summary>
    public class TBL_AUDITINFOBLL
    {
        private TBL_AUDITINFOIService service = new TBL_AUDITINFOService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�ύ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_AUDITINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// ��ȡ����б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_AUDITINFOEntity> GetPageList2(Pagination pagination, string queryJson)
        {
            return service.GetPageList2(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡδ��˵������б�
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_AUDITINFOEntity> GetPageList3(string queryJson)
        {
            return service.GetPageList3(queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_AUDITINFOEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_AUDITINFOEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
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
        public void SaveForm(string keyValue, TBL_AUDITINFOEntity entity)
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


        /// <summary>
        /// �ύ���
        /// </summary>
        /// <param name="keyValue">ҵ��ID</param>
        public void SubmitAudit(string keyValue)
        {
            try
            {
                service.SubmitAudit(keyValue);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="keyValue">ҵ��ID</param>
        public void CancelSubmit(string keyValue)
        {
            try
            {
                service.CancelSubmit(keyValue);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="keyValue">����</param>
        /// <param name="state">״̬</param>
        /// <param name="comment">��ע</param>
        public void AuditData(string keyValue, int state, string comment)
        {
            try
            {
                service.AuditData(keyValue, state, comment);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="submitStr"></param>
        public void Verification(string keyValue, int verificationType)
        {
            try
            {
                service.VerificationData(keyValue, verificationType,DateTime.Now);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
