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
    /// �� �ڣ�2018-03-17 14:53
    /// �� ��������˱�
    /// </summary>
    public class TBL_AUDITORSBLL
    {
        private TBL_AUDITORSIService service = new TBL_AUDITORSService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_AUDITORSEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_AUDITORSEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_AUDITORSEntity GetEntity(string keyValue)
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
        public void SaveFormNew(string STATE, string GUIDS)
        {
            try
            {
                service.SaveFormNew(STATE, GUIDS);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void deleteNew(string GUIDS)
        {
            try
            {
                service.deleteNew(GUIDS);
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
        public void SaveForm(string keyValue, TBL_AUDITORSEntity entity)
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

        /// <summary>
        /// �����Ƿ�ʼ���
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="audit"></param>
        public void UpdateAudit(string keyValue, string audit)
        {
            TBL_AUDITORSEntity userEntity = GetEntity(keyValue);
            userEntity.ISAUDIT = audit;
            service.SaveForm(keyValue, userEntity);
        }

        /// <summary>
        /// ��������������ҵ�����Ͳ��������
        /// </summary>
        /// <param name="distinct"></param>
        /// <param name="bussnessType"></param>
        /// <returns></returns>
        public string GetAudits(string distinct,string bussnessType)
        {
            try
            {
               return service.GetAudits(distinct, bussnessType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
