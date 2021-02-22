using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-07 17:19
    /// �� ����Ⱥ��Ⱥ���۲�����Ϣ��
    /// </summary>
    public class TBL_QCQF_OBSERVATIONService : RepositoryFactory<TBL_QCQF_OBSERVATIONEntity>, TBL_QCQF_OBSERVATIONIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_OBSERVATIONEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_QCQF_OBSERVATIONEntity>();
             var param = new JObject(); string[] Guids; string PROVINCE = ""; string CITY = ""; string COUNTY = "";
            List<string> _codes = ssoWS.GetAllAuthDistricts();//��ȡ��ǰ�û���������
            if (!_codes.Contains("000000"))
            {
                if (_codes[0].EndsWith("0000"))
                {
                    PROVINCE = _codes[0].ToString();
                }
                else if (_codes[0].EndsWith("00"))
                {
                    CITY = _codes[0].ToString();
                }
                else
                {
                    COUNTY = _codes[0].ToString();
                }
            }
            if (!queryJson.Contains("["))
            {
                if (queryJson.ToJObject().ToString() != "{}")
                {
                    param = queryJson.ToJObject();
                    if (!param["OBSERVATIONPEOPLE"].IsEmpty())
                    {
                        string strOBSERVATIONPEOPLE = param["OBSERVATIONPEOPLE"].ToString();
                        expression = expression.And(t => t.OBSERVATIONPEOPLE.Contains(strOBSERVATIONPEOPLE));
                    }
                    if (!param["OBSERVATIONPHONE"].IsEmpty())
                    {
                        string strOBSERVATIONPHONE = param["OBSERVATIONPHONE"].ToString();
                        expression = expression.And(t => t.OBSERVATIONPHONE.Contains(strOBSERVATIONPHONE));
                    }
                    if (!param["ISGCR"].IsEmpty())
                    {
                        string ISGCR = param["ISGCR"].ToString();
                        expression = expression.And(t => t.ISGCR.Contains(ISGCR));
                    }
                    if (!param["PROVINCE"].IsEmpty())
                    {
                        PROVINCE = param["PROVINCE"].ToString();
                        //expression = expression.And(t => t.PROVINCE.Contains(PROVINCE));
                    }
                    if (!param["CITY"].IsEmpty())
                    {
                        CITY = param["CITY"].ToString();
                        //expression = expression.And(t => t.CITY.Contains(CITY));
                    }

                    if (!param["COUNTY"].IsEmpty())
                    {
                        COUNTY = param["COUNTY"].ToString();
                       // expression = expression.And(t => t.COUNTY.Contains(COUNTY));
                    }


                }
            }

            else
            {
                expression = LinqExtensions.False<TBL_QCQF_OBSERVATIONEntity>();
                Guids = queryJson.Trim('[').Trim(']').Split(',');
                for (int i = 0; i < Guids.Count(); i++)
                {
                    string Guid = Guids[i].Trim('"');
                    expression = expression.Or(t => t.ID == Guid);
                }
            }
            if (!PROVINCE.IsEmpty())
            {
                expression = expression.And(t => t.PROVINCE.Contains(PROVINCE));
            }
            if (!CITY.IsEmpty())
            {
                expression = expression.And(t => t.CITY.Contains(CITY));
            }
            if (!COUNTY.IsEmpty())
            {
                expression = expression.And(t => t.COUNTY.Contains(COUNTY));
            }
            return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_OBSERVATIONEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_OBSERVATIONEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_OBSERVATIONEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_QCQF_OBSERVATIONEntity entity)
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
    }
}
