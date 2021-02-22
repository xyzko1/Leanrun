using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-03-28 14:23
    /// �� ������Χ���ݱ�
    /// </summary>
    public interface TBL_SPATIALINFOIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_SPATIALINFOEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_SPATIALINFOEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_SPATIALINFOEntity GetEntity(string keyValue);

        /// <summary>
        ///  ����ͼ���š��ֺ����Ż�ȡ����
        /// </summary>
        /// <param name="layerid">ͼ����</param>
        /// <param name="subcode">�ֺ�����</param>
        /// <returns></returns>
        IEnumerable<TBL_SPATIALINFOEntity> GetDataLayer(string layerid, string subcode);
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void DeleteEntity(string keyValue);
        void DeleteEntityNew(string keyValue);
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        void SaveEntity(string keyValue, TBL_SPATIALINFOEntity entity);
        #endregion

        
    }
}
