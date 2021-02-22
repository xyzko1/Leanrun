using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Application.IService.MONITORPOINT;
using Infoearth.Application.Service.MONITORPOINT;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;
using Infoearth.Application.Entity;

namespace Infoearth.Application.Busines.MONITORPOINT
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-26 16:55
    /// �� ������������������
    /// </summary>
    public class TBL_DMCJ_MONITORDATABLL
    {
        private TBL_DMCJ_MONITORDATAIService service = new TBL_DMCJ_MONITORDATAService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_DMCJ_MONITORDATAQuery> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_DMCJ_MONITORDATAQuery> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_DMCJ_MONITORDATAEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                service.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, TBL_DMCJ_MONITORDATAEntity entity)
        {
            try
            {
                service.SaveEntity(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        /// <summary>
        /// �������ͳ��
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetQueryList(string queryJson) 
       {
           return service.GetQueryList(queryJson);
       }
        /// <summary>
        /// ���ݼ���ͳ������
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetQueryListByMonitorPoint(string queryJson)
        {
            return service.GetQueryListByMonitorPoint(queryJson);
        }
        /// <summary>
        /// �������ˮλ��
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetQueryList_Contour(string queryJson) 
        {
            return service.GetQueryList_Contour(queryJson);
        }
    }
}
