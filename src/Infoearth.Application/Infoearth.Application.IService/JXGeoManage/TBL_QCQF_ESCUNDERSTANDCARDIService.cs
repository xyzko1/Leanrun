using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:21
    /// �� ����Ⱥ��Ⱥ���������׿�
    /// </summary>
    public interface TBL_QCQF_ESCUNDERSTANDCARDIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">�ֺ�����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetEntity2(string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_QCQF_ESCUNDERSTANDCARDEntity GetEntity(string keyValue);
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// ����������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        TBL_QCQF_ESCUNDERSTANDCARDEntity SaveForm(string keyValue, TBL_QCQF_ESCUNDERSTANDCARDEntity entity);
        #endregion
    }
}