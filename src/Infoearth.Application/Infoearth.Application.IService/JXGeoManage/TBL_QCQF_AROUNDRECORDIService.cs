using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-13 16:22
    /// �� ����Ѳ���¼��
    /// </summary>
    public interface TBL_QCQF_AROUNDRECORDIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_QCQF_AROUNDRECORDEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_QCQF_AROUNDRECORDEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_QCQF_AROUNDRECORDEntity GetEntity(string keyValue);
        TBL_QCQF_AROUNDRECORDEntity GetFormJsonByUNIFIEDCODE(string keyValue);
        /// <summary>
        /// �����ϱ���������ȡ����
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<TBL_QCQF_AROUNDRECORDEntity> GetListByUploadName(string queryJson);
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        void SaveForm(string keyValue, TBL_QCQF_AROUNDRECORDEntity entity);
        void SaveFormByUNIFIEDCODE(string keyValue, TBL_QCQF_AROUNDRECORDEntity entity);
        #endregion
    }
}
