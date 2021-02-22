using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Application.IService.MONITORPOINT;
using Infoearth.Application.Service.MONITORPOINT;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;

namespace Infoearth.Application.Busines.MONITORPOINT
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-22 18:23
    /// �� �����������������Ϣ��
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTBLL
    {
        private TBL_DMCJ_MONITORPOINTIService service = new TBL_DMCJ_MONITORPOINTService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_DMCJ_MONITORPOINTEntity> GetPageList(Pagination pagination, string queryJson, string condition)
        {
            return service.GetPageList(pagination, queryJson,condition);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_DMCJ_MONITORPOINTEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }

        public IEnumerable<TBL_DMCJ_MONITORPOINTEntity> GetZYList(string queryJson, string condition) {
            return service.GetZYList(queryJson,condition);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_DMCJ_MONITORPOINTEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
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
        public void SaveForm(string keyValue, TBL_DMCJ_MONITORPOINTEntity entity)
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
        public string GetMaxCode(string xzqh)
        {
            return service.GetMaxCode(xzqh);
        }
    }
}
