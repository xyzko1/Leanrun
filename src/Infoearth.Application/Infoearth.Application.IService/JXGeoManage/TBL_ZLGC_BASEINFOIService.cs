using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;
using Infoearth.Application.Entity;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:27
    /// �� ������������Ϣ��
    /// </summary>
    public interface TBL_ZLGC_BASEINFOIService
    {
        EchartEntityNEWS GetListCodes();
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetListNew(string queryJson);
        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZYList(string queryJson, string condition);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TBL_ZLGC_BASEINFOEntity GetEntity(string keyValue);
        object PdState1(string id);
        /// <summary>
        /// ������ͳ��
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <param name="CityName"></param>
        /// <param name="CountyName"></param>
        /// <param name="ZLGCYEAR"></param>
        /// <param name="ZLGCUNIT"></param>
        /// <param name="DC"></param>
        /// <returns></returns>
        DataTable ZLGCCountStatics(string ProvinceName, string CityName, string CountyName, string ZLGCYEAR, string ZLGCUNIT, string DC);
        DataTable ZLGCCountStaticsNew(string xzqhcode, string ProvinceName, string CityName, string CountyName, string ZLGCYEAR, string ZLGCUNIT);

        /// <summary>
        /// ����������ͳ�Ʒ���
        /// </summary>
        /// <param name="codeValue">������������</param>
        /// <param name="codeType">ʡ����</param>
        /// <param name="ZLGCYEAR">���</param>
        /// <param name="ZLGCUNIT">ͳ�Ƶ�λ</param>
        /// <returns></returns>
        DataTable GetDataZLGCStatics(string xzqhcode, string codeType, string ZLGCYEAR, string ZLGCUNIT);
        /// <summary>
        /// �����̲�ѯ���
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetListS(string queryJson);

        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZYPageList(string queryJson, string condition);
        TBL_ZLGC_BASEINFOEntity GetEntityByUnifycode(string keyValue, string projectid);
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        string RemoveForm(string keyValue);
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        PASTBL_ZLGC_BASEINFOEntity SaveForm(string keyValue, TBL_ZLGC_BASEINFOEntity entity);

        /// <summary>
        /// �µı��������
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        string SaveForm_New(string keyValue, TBL_ZLGC_BASEINFOEntity entity);
        /// <summary>
        /// ��ȡ������ͳ�ƽ��
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZLGTJResult(string queryJson);
        #endregion
    }
}
