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
    /// �� �ڣ�2018-06-13 16:23
    /// �� ����Ⱥ��Ⱥ�������ˮ���ݱ�
    /// </summary>
    public class TBL_QCQF_POINTRECORDService : RepositoryFactory<TBL_QCQF_POINTRECORDEntity>, TBL_QCQF_POINTRECORDIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_POINTRECORDEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_QCQF_POINTRECORDEntity>();
             return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_POINTRECORDEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_POINTRECORDEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_POINTRECORDEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        public TBL_QCQF_POINTRECORDEntity GetFormByMONITORPOINTGUID(string keyValue)
        {
            return this.BaseRepository().FindEntity(t=>t.MONITORPOINTGUID== keyValue);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_POINTRECORDEntity> GetListByUploadName(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_POINTRECORDEntity>();
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                //�ؼ���
                string UPLOADNAME = json.UPLOADNAME;
                if (!string.IsNullOrEmpty(UPLOADNAME))
                {
                    expression = expression.And(t => t.UPLOADNAME.Contains(UPLOADNAME));
                }
            }
            return this.BaseRepository().FindList(expression);
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
        public void SaveForm(string keyValue, TBL_QCQF_POINTRECORDEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        public void SaveFormByMONITORPOINTGUID(string keyValue, TBL_QCQF_POINTRECORDEntity entity)
        {
            TBL_QCQF_POINTRECORDEntity entity_his = this.BaseRepository().FindEntity(t => t.MONITORPOINTGUID == keyValue);
            if (entity_his!=null)
            {
                entity.GUID = entity_his.GUID;
                entity.MONITORPOINTGUID = keyValue;
                entity.MONITORTIME = entity_his.MONITORTIME;
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                entity.MONITORPOINTGUID = keyValue;
                entity.MONITORTIME = DateTime.Now;
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
