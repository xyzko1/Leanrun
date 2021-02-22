using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:23
    /// �� ����Ⱥ��Ⱥ���������׿�
    /// </summary>
    public class TBL_QCQF_WORKUNDERSTANDCARDService : RepositoryFactory<TBL_QCQF_WORKUNDERSTANDCARDEntity>, TBL_QCQF_WORKUNDERSTANDCARDIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_WORKUNDERSTANDCARDEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_QCQF_WORKUNDERSTANDCARDEntity>();
             return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_WORKUNDERSTANDCARDEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_WORKUNDERSTANDCARDEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_WORKUNDERSTANDCARDEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TBL_QCQF_WORKUNDERSTANDCARDEntity entity)
        {
            //�жϱ������׿����Ƿ�����ͬ��ţ�����о͸��£�û�о�
            if (!string.IsNullOrEmpty(entity.UNIFIEDCODE))
            {
                keyValue = entity.UNIFIEDCODE;
                TBL_QCQF_WORKUNDERSTANDCARDEntity Entity = this.BaseRepository().FindEntity(keyValue);
                if (Entity != null)
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.GUID = Guid.NewGuid().ToString();
                    this.BaseRepository().Insert(entity);
                }
            }
        }
        #endregion
    }
}
