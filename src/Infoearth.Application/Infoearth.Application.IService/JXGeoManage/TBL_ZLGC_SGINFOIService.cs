using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:31
    /// �� ����������-ʩ��
    /// </summary>
    public interface TBL_ZLGC_SGINFOIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_ZLGC_SGINFOEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_ZLGC_SGINFOEntity GetEntity(string keyValue);
        /// <summary>
        /// ���ݹ��̱�Ż�ȡ��Ӧʩ����Ϣ�б�
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<TBL_ZLGC_SGINFOEntity> GetListByZLGCID(Pagination pagination, string queryJson);

        /// <summary>
        /// ���ݹ��̱�Ż�ȡ��Ӧʩ����Ϣ�б����б���Ϣ
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<TBL_ZLGC_SGINFOEntity> GetListByZlgcID(string queryJson);
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
        string SaveForm(string keyValue, TBL_ZLGC_SGINFOEntity entity);
        #endregion
    }
}
