using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Infoearth.Util.Extension;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-25 16:13
    /// �� �������ľ���������Ϣ��
    /// </summary>
    public class TBL_RWJJ_GOVERNMENTService : RepositoryFactory<TBL_RWJJ_GOVERNMENTEntity>, TBL_RWJJ_GOVERNMENTIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_RWJJ_GOVERNMENTEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<TBL_RWJJ_GOVERNMENTEntity>();
            return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);
        }
        /// <summary>
        /// �Ѳ�ѯ���ҳ���ϵ�ͨ��json����ת����linq���
        /// </summary>
        /// <param name="queryJson">json����</param>
        /// <returns></returns>
        System.Linq.Expressions.Expression<Func<TBL_RWJJ_GOVERNMENTEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_RWJJ_GOVERNMENTEntity>();
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            string province = json.PROVINCE;
            string city = json.CITY;
            string county = json.COUNTY;

            #region ����ʡ���ر�Ų�ѯ
            var expression1 = LinqExtensions.False<TBL_RWJJ_GOVERNMENTEntity>();
            //��
            string TOWN = json.TOWN;
            if (!string.IsNullOrEmpty(TOWN))
            {
                foreach (var ton in TOWN.Split(','))
                {
                    expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(2, 9).Equals(ton));
                }
                expression = expression.And(expression1);
            }
            else
            {
                //��
                string COUNTY = json.COUNTY;
                if (!string.IsNullOrEmpty(COUNTY))
                {
                    foreach (var ton in COUNTY.Split(','))
                    {
                        expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(2, 6).Equals(ton));
                    }
                    expression = expression.And(expression1);
                }
                else
                {
                    //��
                    string CITY = json.CITY;
                    if (!string.IsNullOrEmpty(CITY))
                    {
                        foreach (var ton in CITY.Split(','))
                        {
                            expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(2, 4).Equals(ton.Substring(0, 4)));
                        }
                        expression = expression.And(expression1);
                    }
                    else
                    {
                        //ʡ
                        string PROVINCE = json.PROVINCE;
                        if (!string.IsNullOrEmpty(PROVINCE))
                        {
                            foreach (var ton in PROVINCE.Split(','))
                            {
                                expression1 = expression1.Or(t => t.UNIFIEDCODE.Substring(2, 2).Equals(ton.Substring(0, 2)));
                            }
                            expression = expression.And(expression1);
                        }

                    }
                }
            }
            #endregion

            //��λ����ɸѡ
            string NAME = "";
            if (json.NAME != "" && json.NAME != null)
            {
                NAME = json.NAME;
            }
            if (!string.IsNullOrEmpty(NAME))
            {
                expression = expression.And(t => t.NAME.Contains(NAME));
            }
            return expression;
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_RWJJ_GOVERNMENTEntity> GetList(string queryJson)
        {
             var expression = LinqExtensions.True<TBL_RWJJ_GOVERNMENTEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_RWJJ_GOVERNMENTEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_RWJJ_GOVERNMENTEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                //entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
