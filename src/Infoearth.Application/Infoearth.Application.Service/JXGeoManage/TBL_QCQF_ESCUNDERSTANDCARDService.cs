using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using System;
using Infoearth.Util.Extension;
using System.Reflection;
using System.Data;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:21
    /// �� ����Ⱥ��Ⱥ���������׿�
    /// </summary>
    public class TBL_QCQF_ESCUNDERSTANDCARDService : RepositoryFactory<TBL_QCQF_ESCUNDERSTANDCARDEntity>, TBL_QCQF_ESCUNDERSTANDCARDIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetPageList(Pagination pagination, string queryJson)
        {
            //var expression = LinqExtensions.True<TBL_QCQF_ESCUNDERSTANDCARDEntity>();
            //return this.BaseRepository().FindList(expression,pagination);
            return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_ESCUNDERSTANDCARDEntity>();
            return this.BaseRepository().FindList(expression);

        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_ESCUNDERSTANDCARDEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<TBL_QCQF_ESCUNDERSTANDCARDEntity> GetEntity2(string queryJson)
        {
            return this.BaseRepository().FindList(queryJsonExpression(queryJson));
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
        public TBL_QCQF_ESCUNDERSTANDCARDEntity  SaveForm(string keyValue, TBL_QCQF_ESCUNDERSTANDCARDEntity entity)
        {         
            if (!string.IsNullOrEmpty(entity.GUID))
            {
                entity.Modify(entity.GUID);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.GUID = Guid.NewGuid().ToString();
                // entity.Create();
                this.BaseRepository().Insert(entity);
            }
             var data =  GetEntity(entity.GUID);
            return data;
        }
        /// <summary>
        /// �����ֺ����Ų�ѯ�������׿�����
        /// </summary>
        /// <param name="queryJson">json����</param>
        /// <returns></returns>
        System.Linq.Expressions.Expression<Func<TBL_QCQF_ESCUNDERSTANDCARDEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_ESCUNDERSTANDCARDEntity>();

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

                var expression1 = LinqExtensions.False<TBL_QCQF_ESCUNDERSTANDCARDEntity>();

                //�ֺ�����
                string UNIFIEDCODE = json.UNIFIEDCODE;
                if (!string.IsNullOrEmpty(UNIFIEDCODE))
                {
                    expression = expression.And(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE));
                }
            }

            return expression;
        }
        #endregion
    }
}
