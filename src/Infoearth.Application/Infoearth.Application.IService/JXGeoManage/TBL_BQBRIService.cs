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
    /// �� �ڣ�2018-04-16 23:25
    /// �� ������Ǩ������Ϣ��
    /// </summary>
    public interface TBL_BQBRIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_BQBREntity> GetPageList(Pagination pagination, string queryJson);
        IEnumerable<TBL_BQBREntity> GetEntityByUnifycodeNEW(Pagination pagination, string keyValue);
        IEnumerable<TBL_BQBREntity> GetZYPageList(string queryJson, string condition);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_BQBREntity> GetList(string queryJson);
        IEnumerable<tbl_bqbrnew> GetPageListNEW(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_BQBREntity GetEntity(string keyValue);
        TBL_BQBREntity GetEntityByUnifycode(string keyValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <param name="CityName"></param>
        /// <param name="CountyName"></param>
        /// <param name="BQBRYEAR"></param>
        /// <param name="BQBRUNIT"></param>
        /// <param name="EXLType"></param>
        /// <returns></returns>
        DataTable BQBRCountStatics(string ProvinceName, string CityName, string CountyName, string BQBRYEAR, string BQBRUNIT, string EXLType);
        EchartEntityNEWS GetListCodes();
        DataTable GetDataTableList(string queryJson);
        IEnumerable<TBL_BQBREntity> GetZYList(string queryJson, string condition);
        /// <summary>
        /// ��Ǩ����ͳ�Ʋ�ѯ
        /// </summary>
        /// <param name="codeValue">�����������</param>
        /// <param name="codeType">������������</param>
        /// <param name="xmmc">��Ŀ����</param>
        /// <param name="annual">��������</param>
        /// <param name="static_Unit">ͳ�Ƶ�λ</param>
        /// <returns></returns>
        DataTable GetDataBqbrTj(string codeValue, string codeType, string xmmc, string annual, string static_Unit);


        IEnumerable<TreeByBQBRTJ> GetTJ(string queryJson);
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
        string SaveForm(string keyValue, TBL_BQBREntity entity);
        #endregion
    }
}
