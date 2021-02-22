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
    /// �� �ڣ�2018-04-16 23:31
    /// �� ������������-ʩ��
    /// </summary>
    public class TBL_ZLGC_SGINFOBLL
    {
        private TBL_ZLGC_SGINFOIService service = new TBL_ZLGC_SGINFOService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_ZLGC_SGINFOEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_ZLGC_SGINFOEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        /// <summary>
        /// ���ݹ��̱�Ż�ȡ��Ӧ����ʩ���б���Ϣ
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_ZLGC_SGINFOEntity> GetListByZLGCID(Pagination pagination, string queryJson) 
        {
            return service.GetListByZLGCID(pagination, queryJson);
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
        /// ����������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public string SaveForm(string keyValue, TBL_ZLGC_SGINFOEntity entity)
        {
            try
            {
                if (entity.MEDIAGUID == null || entity.MEDIAGUID == "")
                {
                    entity.MEDIAGUID = Guid.NewGuid().ToString();
                }
                service.SaveForm(keyValue, entity);
                return entity.MEDIAGUID;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}