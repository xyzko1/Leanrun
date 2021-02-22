using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:19
    /// �� ����Ⱥ��Ⱥ������Ԥ����
    /// </summary>
    public class TBL_QCQF_DISASTERPREVENTIONBLL
    {
        private TBL_QCQF_DISASTERPREVENTIONIService service = new TBL_QCQF_DISASTERPREVENTIONService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_DISASTERPREVENTIONEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }      
        /// <summary>
        /// Ⱥ��Ⱥ��ͳ��
        /// </summary>
        /// <returns></returns>
        public DataTable GetQCQFStatistics(string queryJson)
        {
            return service.GetQCQFStatistics(queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_DISASTERPREVENTIONEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
       
        
        public DataTable GetAnalyseListQCQF(string queryJson) {
            return service.GetAnalyseListQCQF(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_DISASTERPREVENTIONEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        /// <summary>
        /// ��ȡʡ����Ⱥ��Ⱥ������
        /// </summary>
        /// <param name="xzqhcode"></param>
        /// <returns></returns>
        public DataTable GetQCQFCount(string xzqhcode)
        {
            return service.GetQCQFCount(xzqhcode);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TBL_QCQF_DISASTERPREVENTIONEntity entity)
        {
            try
            {
                service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
