using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 11:38
    /// �� ������ʯ���������ʷ��
    /// </summary>
    public interface TBL_DEBRISFLOW_HISTORYIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_DEBRISFLOW_HISTORYEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_DEBRISFLOW_HISTORYEntity GetEntity(string keyValue);
        TBL_DEBRISFLOW_HISTORYEntity GetEntityByUNIFIEDCODE(string keyValue);
        /// <summary>
        /// ��ȡ��ǰʵ��ǰ������ͨ����ʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_DEBRISFLOW_HISTORYEntity GetAuditEntity(string keyValue);
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
        string SaveForm(string keyValue, TBL_DEBRISFLOW_HISTORYEntity entity);
        #endregion
    }
}
