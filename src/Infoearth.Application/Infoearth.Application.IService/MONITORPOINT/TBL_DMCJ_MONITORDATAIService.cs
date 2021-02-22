using Infoearth.Application.Entity;
using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace Infoearth.Application.IService.MONITORPOINT
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-26 16:55
    /// �� ������������������
    /// </summary>
    public interface TBL_DMCJ_MONITORDATAIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_DMCJ_MONITORDATAQuery> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_DMCJ_MONITORDATAQuery> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_DMCJ_MONITORDATAEntity GetEntity(string keyValue);
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
        void SaveEntity(string keyValue, TBL_DMCJ_MONITORDATAEntity entity);
        #endregion
          /// <summary>
        /// �������ͳ��
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        DataTable GetQueryList(string queryJson);
           /// <summary>
        /// ���ݼ���ͳ������
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        DataTable GetQueryListByMonitorPoint(string queryJson);
         /// <summary>
        /// �������ˮλ��
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        DataTable GetQueryList_Contour(string queryJson);
    }
}
