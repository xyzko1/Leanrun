using Infoearth.Application.Entity.DMCJManage;
using Infoearth.Application.IService.DMCJManage;
using Infoearth.Application.Service.DMCJManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;

namespace Infoearth.Application.Busines.DMCJManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-09-04 12:02
    /// �� ����������������SUB
    /// </summary>
    public class TBL_DMCJ_BASEINFO_SUBBLL
    {
        private TBL_DMCJ_BASEINFO_SUBIService service = new TBL_DMCJ_BASEINFO_SUBService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_DMCJ_BASEINFO_SUBEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_DMCJ_BASEINFO_SUBEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_DMCJ_BASEINFO_SUBEntity GetEntity(string keyValue)
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
        public void SaveEntity(string keyValue, TBL_DMCJ_BASEINFO_SUBEntity entity)
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
    }
}
