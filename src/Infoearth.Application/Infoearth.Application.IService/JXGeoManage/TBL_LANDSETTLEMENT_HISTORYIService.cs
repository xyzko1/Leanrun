using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 11:51
    /// �� ������������������ʷ��
    /// </summary>
    public interface TBL_LANDSETTLEMENT_HISTORYIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_LANDSETTLEMENT_HISTORYEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_LANDSETTLEMENT_HISTORYEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_LANDSETTLEMENT_HISTORYEntity GetEntity(string keyValue);
        TBL_LANDSETTLEMENT_HISTORYEntity GetEntityByUNIFIEDCODE(string keyValue);
        /// <summary>
        /// ��ȡ��ǰʵ��ǰ������ͨ����ʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_LANDSETTLEMENT_HISTORYEntity GetAuditEntity(string keyValue);

        /// <summary>
        /// ��ȡ������˵�����
        /// </summary>
        /// <param name="unifycode"></param>
        /// <returns></returns>
        TBL_LANDSETTLEMENT_HISTORYEntity GetLatestEntity(string unifycode);
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        string SaveForm(string keyValue, TBL_LANDSETTLEMENT_HISTORYEntity entity);

         /// <summary>
        /// ��������
        /// </summary>
        /// <param name="entity"></param>
        void InsertEntity(TBL_LANDSETTLEMENT_HISTORYEntity entity);
        #endregion
    }
}
