using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using Infoearth.Util.Extension;
using System;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-26 14:28
    /// �� ����ͳ�Ʒ�����ѯ����
    /// </summary>
    public class TBL_WHAA07CService : RepositoryFactory<TBL_WHAA07CEntity>, TBL_WHAA07CIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_WHAA07CEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_WHAA07CEntity>();

             return this.BaseRepository().FindList(GetQueryJsonToLinqExtensions(queryJson), pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_WHAA07CEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_WHAA07CEntity>();


            return this.BaseRepository().FindList(GetQueryJsonToLinqExtensions(queryJson));
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_WHAA07CEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_WHAA07CEntity entity)
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
        #endregion

        #region ��������

        System.Linq.Expressions.Expression<Func<TBL_WHAA07CEntity,bool>> GetQueryJsonToLinqExtensions(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_WHAA07CEntity>();

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

                string REPORTTYPE = json.REPORTTYPE;
                if (!string.IsNullOrEmpty(REPORTTYPE))
                {
                    expression = expression.And(t => t.REPORTTYPE.Equals(REPORTTYPE));
                }

            }

            return expression;
        }


        #endregion
    }
}
