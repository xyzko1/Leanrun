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
    /// �� �ڣ�2018-04-16 23:19
    /// �� ����Ⱥ��Ⱥ������Ԥ����
    /// </summary>
    public interface TBL_QCQF_DISASTERPREVENTIONIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_QCQF_DISASTERPREVENTIONEntity> GetPageList(Pagination pagination, string queryJson);     
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_QCQF_DISASTERPREVENTIONEntity> GetList(string queryJson);
       
        
        DataTable GetAnalyseListQCQF(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_QCQF_DISASTERPREVENTIONEntity GetEntity(string keyValue);
        /// <summary>
        /// Ⱥ��Ⱥ��ͳ��
        /// </summary>
        /// <returns></returns>
        DataTable GetQCQFStatistics(string queryJson);
        /// <summary>
        /// ��ȡʡ����Ⱥ��Ⱥ������
        /// </summary>
        /// <param name="xzqhcode"></param>
        /// <returns></returns>
        DataTable GetQCQFCount(string xzqhcode);
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
        void SaveForm(string keyValue, TBL_QCQF_DISASTERPREVENTIONEntity entity);
        #endregion
    }
}
