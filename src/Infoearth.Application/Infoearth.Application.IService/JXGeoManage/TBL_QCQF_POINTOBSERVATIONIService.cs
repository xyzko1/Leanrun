using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-11 15:39
    /// �� ����Ⱥ��Ⱥ������͹۲��˹�����
    /// </summary>
    public interface TBL_QCQF_POINTOBSERVATIONIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetList(string queryJson);
        IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetListByID(string ID);
        IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetListByUNIFIEDCODE(string UNIFIEDCODE);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_QCQF_POINTOBSERVATIONEntity GetEntity(string keyValue);
        #endregion
        
        DataTable GetDataJcd(string id);
        DataTable GetDataJcr(string id);
        void delegl(string id, string guid);
        void deleglnew(string id);
        void deleglnewByqCqf(string id);
        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void RemoveForm(string keyValue);
        void RemoveFormByID(string keyValue);
        void RemoveFormByUNIFIEDCODE(string keyValue);
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        void SaveForm(string keyValue, TBL_QCQF_POINTOBSERVATIONEntity entity);
        void SaveFormByID(string ID, string UNIFIEDCODE);
        #endregion
    }
}
