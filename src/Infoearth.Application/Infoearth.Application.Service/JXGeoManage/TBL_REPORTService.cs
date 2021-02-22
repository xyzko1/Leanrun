using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-28 16:05
    /// �� ����ͳ�ƹ��ñ���
    /// </summary>
    public class TBL_REPORTService : RepositoryFactory<TBL_REPORTEntity>, TBL_REPORTIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_REPORTEntity> GetPageList(Pagination pagination, string queryJson)
        {
            System.Linq.Expressions.Expression<Func<TBL_REPORTEntity, bool>> expression = GetExpression(queryJson);
            return this.BaseRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// ɸѡ����
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        private Expression<Func<TBL_REPORTEntity, bool>> GetExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_REPORTEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                dynamic json = JToken.Parse(queryJson) as dynamic;

                //ģ������
                string module = json.module;
                if (!string.IsNullOrEmpty(module))
                {
                    expression = expression.And(testc => testc.MODULE == module);
                }

                //��ʼʱ��
                string beginTime = json.beginTime;
                if (!string.IsNullOrEmpty(beginTime))
                {
                    DateTime begin = DateTime.Parse(beginTime);
                    expression = expression.And(testc => testc.CREATETIME >= begin);
                }

                //����ʱ��
                string endTime = json.endTime;
                if (!string.IsNullOrEmpty(endTime))
                {
                    DateTime end = DateTime.Parse(endTime);
                    expression = expression.And(testc => testc.CREATETIME >= end);
                }
            }

            return expression;
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_REPORTEntity> GetList(string queryJson)
        {
            return this.BaseRepository().FindList(GetExpression(queryJson)).OrderByDescending(t => t.CREATETIME);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_REPORTEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_REPORTEntity entity)
        {
            var user= ssoWS.GetUserInfo();
            entity.CREATEPEOPLE = user.F_Account;
            entity.CREATETIME = DateTime.Now;

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
    }
}
