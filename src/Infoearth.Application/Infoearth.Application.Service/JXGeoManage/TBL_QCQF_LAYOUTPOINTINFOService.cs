using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-07 17:24
    /// �� ����Ⱥ��Ⱥ��������Ϣ��
    /// </summary>
    public class TBL_QCQF_LAYOUTPOINTINFOService : RepositoryFactory<TBL_QCQF_LAYOUTPOINTINFOEntity>, TBL_QCQF_LAYOUTPOINTINFOIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_LAYOUTPOINTINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return this.BaseRepository().FindList(queryJsonExpression(queryJson), pagination);
        }
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_LAYOUTPOINTINFOEntity> GetAllList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_LAYOUTPOINTINFOEntity>();
            //���������˺�Ȩ��ɸѡ
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            //ɸѡ����ȡ��Ȩ����������
            List<string> author = ws.GetAllAuthDistricts();
            if (author != null && author.Count > 0)
            {
                var expression2 = LinqExtensions.False<TBL_QCQF_LAYOUTPOINTINFOEntity>();
                bool flag = false;
                foreach (var au in author)
                {
                    //ȫ��Ȩ��
                    if (au.EndsWith("000000") || au.Equals("0"))
                    {
                        flag = false;
                        break;
                    }
                    //ʡȨ��
                    else if (au.EndsWith("0000"))
                    {
                        expression2 = expression2.Or(testc => testc.UNIFIEDCODE.StartsWith(au.Substring(0, 2)));
                        flag = true;
                    }
                    //��Ȩ��
                    else if (au.EndsWith("00"))
                    {
                        expression2 = expression2.Or(testc => testc.UNIFIEDCODE.StartsWith(au.Substring(0, 4)));
                        flag = true;
                    }
                    //��Ȩ��
                    else
                    {
                        expression2 = expression2.Or(testc => testc.UNIFIEDCODE.StartsWith(au.Substring(0, 6)));
                        flag = true;
                    }
                }
                if (flag)
                {
                    expression = expression.And(expression2);
                }
                return this.BaseRepository().FindList(expression);
            }
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_LAYOUTPOINTINFOEntity> GetList(string queryJson)
        {
            return this.BaseRepository().FindList(queryJsonExpression(queryJson));
        }
        System.Linq.Expressions.Expression<Func<TBL_QCQF_LAYOUTPOINTINFOEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_LAYOUTPOINTINFOEntity>();
            var param = new JObject(); string[] Guids;
            if (!queryJson.Trim('"').IsEmpty() && !queryJson.Contains("["))
            {
                param = queryJson.ToJObject();
                if (!param["UNIFIEDCODE"].IsEmpty())
                {
                    string strUNIFIEDCODE = param["UNIFIEDCODE"].ToString();
                    expression = expression.And(t => t.UNIFIEDCODE.Contains(strUNIFIEDCODE));
                }
                if (!param["MONITORPOINTTYPE"].IsEmpty())
                {
                    string strMONITORPOINTTYPE = param["MONITORPOINTTYPE"].ToString();
                    expression = expression.And(t => t.MONITORPOINTCODE.Contains(strMONITORPOINTTYPE));
                }
                if (!param["MONITORPOINTPOSITION"].IsEmpty())
                {
                    string strMONITORPOINTPOSITION = param["MONITORPOINTPOSITION"].ToString();
                    expression = expression.And(t => t.MONITORPOINTPOSITION.Contains(strMONITORPOINTPOSITION));
                }
            }
            else
            {
                expression = LinqExtensions.False<TBL_QCQF_LAYOUTPOINTINFOEntity>();
                Guids = queryJson.Trim('[').Trim(']').Split(',');
                for (int i = 0; i < Guids.Count(); i++)
                {
                    string Guid = Guids[i].Trim('"');
                    expression = expression.Or(t => t.GUID == Guid);
                }
            }
            return expression;
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_LAYOUTPOINTINFOEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        public TBL_QCQF_LAYOUTPOINTINFOEntity GetMONITORPOINTTYPEByUNIFIEDCODE(string UNIFIEDCODE, string TYPE)
        {
            return this.BaseRepository().FindList(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE) && t.MONITORPOINTCODE.Contains(TYPE)).OrderByDescending(t => t.MONITORPOINTCODE).FirstOrDefault();
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
        public void SaveForm(string keyValue, TBL_QCQF_LAYOUTPOINTINFOEntity entity)
        {
            DateTime modifyTime = DateTime.Now;
            entity.MODIFYTIME = modifyTime;
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
