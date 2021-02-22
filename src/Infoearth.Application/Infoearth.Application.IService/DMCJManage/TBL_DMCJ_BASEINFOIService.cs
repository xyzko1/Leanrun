using Infoearth.Application.Entity;
using Infoearth.Application.Entity.DMCJManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace Infoearth.Application.IService.DMCJManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-22 12:10
    /// �� ����������������
    /// </summary>
    public interface TBL_DMCJ_BASEINFOIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_DMCJ_BASEINFOEntity> GetPageList(Pagination pagination, string queryJson, string condition);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_DMCJ_BASEINFOEntity> GetList(string queryJson);
        IEnumerable<TBL_DMCJ_BASEINFOEntity> GetZYList(string queryJson, string condition);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_DMCJ_BASEINFOEntity GetEntity(string keyValue);

        /// <summary>
        /// ȡ���������ֶε�ֵ�б�
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        List<string> GetValueList(string queryJson);
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
        void SaveForm(string keyValue, MasterDetailEntity entity);
        #endregion

        EchartEntity GetStatisticsByDmcj();
        DataTable GetStatisticsByDmcjPie();
        string GetMaxCode(string xzqh);
    }
}
