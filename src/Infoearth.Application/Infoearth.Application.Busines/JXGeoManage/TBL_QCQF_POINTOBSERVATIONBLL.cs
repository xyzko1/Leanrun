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
    /// �� �ڣ�2018-06-11 15:39
    /// �� ����Ⱥ��Ⱥ������͹۲��˹�����
    /// </summary>
    public class TBL_QCQF_POINTOBSERVATIONBLL
    {
        private TBL_QCQF_POINTOBSERVATIONIService service = new TBL_QCQF_POINTOBSERVATIONService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        public IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetListByID(string ID)
        {
            return service.GetListByID(ID);
        }
        public IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetListByUNIFIEDCODE(string UNIFIEDCODE)
        {
            return service.GetListByUNIFIEDCODE(UNIFIEDCODE);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_POINTOBSERVATIONEntity GetEntity(string keyValue)
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
        public void RemoveFormByID(string keyValue)
        {
            try
            {
                service.RemoveFormByID(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RemoveFormByUNIFIEDCODE(string keyValue)
        {
            try
            {
                service.RemoveFormByUNIFIEDCODE(keyValue);
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
        public void SaveForm(string keyValue, TBL_QCQF_POINTOBSERVATIONEntity entity)
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
        public void SaveFormByID(string ID, string UNIFIEDCODE)
        {
            try
            {
                service.SaveFormByID(ID, UNIFIEDCODE);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetDataJcd(string id)
        {
            return service.GetDataJcd(id);
        }
        public DataTable GetDataJcr(string id)
        {
            return service.GetDataJcr(id);
        }
        public void delegl(string id, string guid)
        {
            service.delegl(id,guid);
        }
        public void deleglnew(string id)
        {
            service.deleglnew(id);
        }
        public void deleglnewByqCqf(string id)
        {
            service.deleglnewByqCqf(id);
        }
        #endregion
    }
}
