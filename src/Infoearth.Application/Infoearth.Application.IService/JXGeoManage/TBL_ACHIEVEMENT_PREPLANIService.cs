using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-05-25 16:29
    /// �� �������ι滮�ɹ���
    /// </summary>
    public interface TBL_ACHIEVEMENT_PREPLANIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_ACHIEVEMENT_PREPLANEntity GetEntity(string keyValue);

        IEnumerable<TBL_ACHIEVEMENT_PREPLANEntity> GetZYPageList(string queryJson, string condition);
        /// <summary>
        /// ���ι滮�ɹ�ͳ��
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <param name="CityName"></param>
        /// <param name="CountyName"></param>
        /// <param name="PREPLANYEAR"></param>
        /// <param name="PREPLANUNIT"></param>
        /// <param name="DCType"></param>
        /// <returns></returns>
        DataTable PREPLANCountStatics(string ProvinceName, string CityName, string CountyName, string PREPLANYEAR, string PREPLANUNIT, string DCType);
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
        void SaveForm(string keyValue, TBL_ACHIEVEMENT_PREPLANEntity entity);
        #endregion
    }
}
