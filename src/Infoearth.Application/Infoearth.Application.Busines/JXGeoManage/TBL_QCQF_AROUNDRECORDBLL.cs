using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-13 16:22
    /// �� ����Ѳ���¼��
    /// </summary>
    public class TBL_QCQF_AROUNDRECORDBLL
    {
        private TBL_QCQF_AROUNDRECORDIService service = new TBL_QCQF_AROUNDRECORDService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_AROUNDRECORDEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_AROUNDRECORDEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_AROUNDRECORDEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        public TBL_QCQF_AROUNDRECORDEntity GetFormJsonByUNIFIEDCODE(string keyValue)
        {
            return service.GetFormJsonByUNIFIEDCODE(keyValue);
        }
        public IEnumerable<TBL_QCQF_AROUNDRECORDEntity> GetListByUploadName(string queryJson)
        {
            return service.GetListByUploadName(queryJson);
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
        public void SaveForm(string keyValue, TBL_QCQF_AROUNDRECORDEntity entity)
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
        public void SaveFormByUNIFIEDCODE(string keyValue, TBL_QCQF_AROUNDRECORDEntity entity)
        {
            try
            {
                service.SaveFormByUNIFIEDCODE(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
