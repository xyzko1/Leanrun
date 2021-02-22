using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:29
    /// �� ����������-����
    /// </summary>
    public class TBL_ZLGC_JLINFOService : RepositoryFactory<TBL_ZLGC_JLINFOEntity>, TBL_ZLGC_JLINFOIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_ZLGC_JLINFOEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_JLINFOEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_ZLGC_JLINFOEntity> GetListByZlgcID(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_JLINFOEntity>();
            return this.BaseRepository().FindList(queryJsonExpression(queryJson));
        }
        /// <summary>
        /// �Ѳ�ѯ���ҳ���ϵ�ͨ��json����ת����linq���
        /// </summary>
        /// <param name="queryJson">json����</param>
        /// <returns></returns>
        System.Linq.Expressions.Expression<Func<TBL_ZLGC_JLINFOEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_ZLGC_JLINFOEntity>();

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                string ZLGCID = "";
                //���̱��
                if (json.ZLGCID != "" && json.ZLGCID != null)
                {
                    ZLGCID = json.ZLGCID;
                }
                else
                {
                    ZLGCID = "��";
                }
                if (!string.IsNullOrEmpty(ZLGCID))
                {
                    expression = expression.And(t => t.ZLGCID.Contains(ZLGCID));
                }
            }
            return expression;
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_ZLGC_JLINFOEntity GetEntity(string keyValue)
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
        public string SaveForm(string keyValue, TBL_ZLGC_JLINFOEntity entity)
        {
            string MEDIAGUID = "";
            if (!string.IsNullOrEmpty(keyValue))
            {
                if (this.BaseRepository().FindEntity(keyValue) == null)
                {
                    this.BaseRepository().Insert(entity);
                    MEDIAGUID = entity.ZLGCID;
                }
                else
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                    MEDIAGUID = entity.ZLGCID;
                }
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);

            }
            return MEDIAGUID;
        }
        #endregion
    }
}
