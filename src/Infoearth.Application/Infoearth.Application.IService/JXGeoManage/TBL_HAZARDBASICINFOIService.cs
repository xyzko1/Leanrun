using Infoearth.Application.Entity;
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
    /// �� �ڣ�2018-03-14 14:58
    /// �� �����ֺ��������
    /// </summary>
    public interface TBL_HAZARDBASICINFOIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡ�ֺ�����ͳ�ƽ��
        /// </summary>
        /// <returns></returns>
        DataTable GetDicAnalyse(string enCode);
        DataTable GetListCode(string queryJson);
        EchartEntityNEW GetListCodes(string queryJson);
        EchartEntityNEWS GetListCodesNew();
        EchartEntityCJ GetListDataCJ(string queryJson);
        DataTable GetDataByQcqfReturnHazardbasicInfo(ref Pagination pagination, string queryJson);
        /// <summary>
        /// ����ѯ��������Ƿ���ȷ
        /// </summary>
        /// <param name="sqlWhere">��ѯ�������</param>
        /// <returns></returns>
        bool CheckExpression(string sqlWhere);
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetZYPageList(string queryJson, string condition);
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetZYPageList2(string queryJson, string condition);
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJsonQCQFSearch_Marker(Pagination pagination, string queryJson, string condition,string nsql=null);
        IEnumerable<TBL_HAZARDBASICINFO> GetPageListJsonQCQFSearch_MarkerByInfo (Pagination pagination, string queryJson, string condition,string nsql=null);

        /// <summary>
        /// ���������������ѯȺ��Ⱥ����Ϣ
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <param name="sql"></param>
        IEnumerable<TBL_HAZARDBASICINFO> GetListJsonQCQFInfo(string queryJson, string condition, string nsql = null);
        string GetWhereSql(string queryJson);
        /// <summary>
        /// �ֺ������λ�������
        /// </summary>
        /// <param name="xzqh"></param>
        /// <returns></returns>
        string GetMaxCode(string xzqh);
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetNoQcqfPageList(string queryJson, string condition);
        IEnumerable<PastHAZARDBASICINFO> GetPastListJson2(string queryJson);
        DataTable GetWXRKStatisticsJson(string queryJson);
        DataTable GetWXCCStatisticsJson(string queryJson);
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetZYPageList(string queryJson, string condition, Pagination pagination);
        EchartEntity GetStatisticsByZHLX(string queryJson);
        DataTable GetHistoryStatisticsZHD(string queryJson, ref EchartEntity returnValue);
        DataTable GetTypeStatistics(string queryJson);
        DataTable GetStatisticsByZHLX2(string queryJson);
        /// <summary>
        /// �ֺ���ͳ��ֻ���ֺ�����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        DataTable GetHazardStatisticsJson2(string queryJson);
        int GetAllList();
        /// <summary>
        /// ��ȡ�������ݣ�����ͳ��������ѯ��
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetSinglePageList(Pagination pagination, string queryJson);
        EchartEntity GetStatisticsByXH(string queryJson);
        EchartEntity GetStatisticsByZHD(string queryJson);
        EchartEntity GetStatisticsByXQDJ(string queryJson);
        EchartEntity GetStatisticsByGMDJ(string queryJson);
        EchartEntity GetStatisticsByZQDJ(string queryJson);
        EchartEntity GetStatisticsByZLGC(string queryJson);
        EchartEntity GetStatisticsByBQBR(string queryJson);
        List<string> SSOGeodisaster(string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// ��ȡ�б��ҳ
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJson(Pagination pagination, string queryJson);
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJson2(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б��ҳ
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_HAZARDBASICINFOEntity> GetPageListJsons(Pagination pagination, string queryJson, string condition);
        IEnumerable<TBL_HAZARDBASICINFOEntity> PostPageListJsonFirst(Pagination pagination, string queryJson, string condition);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_HAZARDBASICINFOEntity GetEntity(string keyValue);

        /// <summary>
        /// ��ȡͳ�����ݼ���
        /// </summary>
        /// <param name="queryJson">ͳ������</param>
        /// <param name="leixingzd">�ֺ������ֵ�</param>
        /// <param name="zaihaizd">�ֺ��ȼ��ֵ�</param>
        /// <param name="xianqingzd">����ȼ��ֵ�</param>
        /// <returns></returns>
        List<TBL_HAZARDBASICINFOEntity> GetCountAnalyseList(string queryJson);

        /// <summary>
        /// ��������ͳ���ֺ�����Ϣ
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        DataTable GetAnalyseList(string queryJson);
        bool ValidateSQL(string sql);

        DataTable GetZhdAndCityName();
        DataTable GetZhdAndProvinceName();
        /// <summary>
        /// �ֺ���ͳ�ƣ������ء��ֺ�������|�ֺ�������|����ȼ�|����ȼ� ͳ�ƣ�
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        DataTable GetHazardStatisticsJson(string type);

        /// <summary>
        /// ��ȡ��ʷ����
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        IEnumerable<PastHAZARDBASICINFO> GetPastPageListJson(Pagination pagination, string queryJson);

        /// <summary>
 		/// ����UNIFIEDCODE��ȡʵ��
        /// </summary>
        /// <param name="UNIFIEDCODE"></param>
        /// <returns></returns>
        TBL_HAZARDBASICINFOEntity GetUNIFIEDCODEEntity(string UNIFIEDCODE);
        /// <summary>        
		/// ��ȡ��ʷ����
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        IEnumerable<PastHAZARDBASICINFO> GetPastListJson(string queryJson, string condition);

        /// <summary>
        /// �����ֺ����ѯ�����������
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        DataTable GetDataTableList(string queryJson);

        IEnumerable<TBL_HAZARDBASICINFOEntity> GetValue();

        /// <summary>
        /// �����ֺ���ͳ��
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        DataTable GetDataCountTableList(string queryJson, string colum);
        DataTable GetDataCountTableListPC(string queryJson, string colum);
        DataTable GetAnalyseListPC(string queryJson);
        string GetZHDCountResult(string queryJson, int type);
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
        void SaveForm(string keyValue, TBL_HAZARDBASICINFOEntity entity);
        void UpdateForm(string sql);
        #endregion
    }
}
