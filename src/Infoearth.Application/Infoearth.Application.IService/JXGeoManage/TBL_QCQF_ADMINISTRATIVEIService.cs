using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:15
    /// �� ����Ⱥ��Ⱥ������������ϵ
    /// </summary>
    public interface TBL_QCQF_ADMINISTRATIVEIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_QCQF_ADMINISTRATIVEEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_QCQF_ADMINISTRATIVEEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_QCQF_ADMINISTRATIVEEntity GetEntity(string keyValue);
        /// <summary>
        /// ����DISTRICTCODE��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_QCQF_AMINISTRATIVELXR GetDISTRICTCODEEntity(string DISTRICTCODE);
        TBL_QCQF_ADMINISTRATIVEEntity GetTBL_QCQF_ADMINISTRATIVEEntity(string DISTRICTCODE);
        
        #endregion
        object PdState(string id);
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
        void SaveForm(string keyValue, TBL_QCQF_ADMINISTRATIVEEntity entity);
        /// <summary>
        /// ����DISTRICTCODE��������������޸ģ�
        /// </summary>
        /// <param name="DISTRICTCODE"></param>
        /// <param name="entity"></param>
        void UpdateForm(string DISTRICTCODE, TBL_QCQF_ADMINISTRATIVEEntity entity);
        #endregion
    }
}
