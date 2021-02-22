using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-02-14 11:13
    /// �� �����ֺ�����ʷ��Ϣ������
    /// </summary>
    public interface TBL_HAZARDBASICINFO_HISTORYIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <param name="condition">�ռ��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetPageList(Pagination pagination, string queryJson, string condition);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <param name="condition">�ռ��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetList(string queryJson,string condition);

        /// <summary>
        /// ��ѯ��������
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<TBL_HAZARDBASICINFO_HISTORYEntity> GetList(string queryJson);

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_HAZARDBASICINFO_HISTORYEntity GetEntity(string keyValue);
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
        void SaveEntity(string keyValue, TBL_HAZARDBASICINFO_HISTORYEntity entity);
        #endregion
    }
}
