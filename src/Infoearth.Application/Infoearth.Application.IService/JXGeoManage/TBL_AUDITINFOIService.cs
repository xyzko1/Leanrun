using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-17 14:51
    /// �� ���������Ϣ��
    /// </summary>
    public interface TBL_AUDITINFOIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�ύ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_AUDITINFOEntity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// ��ȡ����б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_AUDITINFOEntity> GetPageList2(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡδ��˵������б�
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<TBL_AUDITINFOEntity> GetPageList3(string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_AUDITINFOEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_AUDITINFOEntity GetEntity(string keyValue);
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
        void SaveForm(string keyValue, TBL_AUDITINFOEntity entity);

        /// <summary>
        /// �ύ���
        /// </summary>
        /// <param name="keyValue">ҵ��ID</param>
        void SubmitAudit(string keyValue);

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="keyValue">ҵ��ID</param>
        void CancelSubmit(string keyValue);

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="keyValue">����</param>
        /// <param name="state">״̬</param>
        /// <param name="comment">��ע</param>
        void AuditData(string keyValue, int state, string comment);

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="unifycode">�ֺ�����</param>
        /// <param name="verification">��������</param>
        void VerificationData(string unifycode, int verification, DateTime fillTableDate);

        #endregion
    }
}
