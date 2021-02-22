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
    /// �� �ڣ�2018-06-13 16:22
    /// �� ����Ѳ���¼��
    /// </summary>
    public class TBL_QCQF_AROUNDRECORDService : RepositoryFactory<TBL_QCQF_AROUNDRECORDEntity>, TBL_QCQF_AROUNDRECORDIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_AROUNDRECORDEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_QCQF_AROUNDRECORDEntity>();
             return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_AROUNDRECORDEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_AROUNDRECORDEntity>();
            return this.BaseRepository().FindList(expression);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_AROUNDRECORDEntity> GetListByUploadName(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_AROUNDRECORDEntity>();
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
            //���������˺�Ȩ��ɸѡ
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            //ɸѡ����ȡ��Ȩ����������
            List<string> author = ws.GetAllAuthDistricts();
            if (author != null && author.Count > 0)
            {
                var expression2 = LinqExtensions.False<TBL_QCQF_AROUNDRECORDEntity>();
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
                        expression2 = expression2.Or(testc => testc.UNIFIEDCODE.StartsWith(au.Substring(0,2)));
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
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_AROUNDRECORDEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        public TBL_QCQF_AROUNDRECORDEntity GetFormJsonByUNIFIEDCODE(string keyValue)
        {
            return this.BaseRepository().FindEntity(t=>t.UNIFIEDCODE.Contains(keyValue));
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
        public void SaveForm(string keyValue, TBL_QCQF_AROUNDRECORDEntity entity)
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
        public void SaveFormByUNIFIEDCODE(string keyValue, TBL_QCQF_AROUNDRECORDEntity entity)
        {
            TBL_QCQF_AROUNDRECORDEntity entity_his= this.BaseRepository().FindEntity(t => t.UNIFIEDCODE.Contains(keyValue));
            if (entity_his!=null)
            {
                entity.GUID = entity_his.GUID;
                entity.UNIFIEDCODE = keyValue;
                entity.MONITORTIME = entity_his.MONITORTIME;
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                entity.UNIFIEDCODE = keyValue;
                entity.MONITORTIME = DateTime.Now;
                this.BaseRepository().Insert(entity);

            }
        }
        #endregion
    }
}
