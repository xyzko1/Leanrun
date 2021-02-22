using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using Infoearth.Util.Extension;
using System;
using Infoearth.Util;
using Newtonsoft.Json.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 11:17
    /// �� ���������������ʷ��
    /// </summary>
    public class TBL_AVALANCHE_HISTORYService : RepositoryFactory<TBL_AVALANCHE_HISTORYEntity>, TBL_AVALANCHE_HISTORYIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_AVALANCHE_HISTORYEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_AVALANCHE_HISTORYEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                dynamic json = JToken.Parse(queryJson) as dynamic;
                //�ֺ�����
                string unifycode = json.unifycode;
                if (!string.IsNullOrEmpty(unifycode))
                {
                    expression = expression.And(t => t.UNIFIEDCODE.Contains(unifycode));
                }

            }
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_AVALANCHE_HISTORYEntity GetEntity(string keyValue)
        {
            //if (keyValue.Length == 12)
            //{
            //    keyValue = keyValue + " " + " " + " " + " ";
            //}
            return this.BaseRepository().FindEntity(keyValue);
        }
        public TBL_AVALANCHE_HISTORYEntity GetEntityByUNIFIEDCODE(string keyValue)
        {
            return this.BaseRepository().FindEntity(t=>t.UNIFIEDCODE== keyValue);
        }
        /// <summary>
        /// ��ȡ��ǰʵ��ǰ������ͨ����ʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_AVALANCHE_HISTORYEntity GetAuditEntity(string keyValue)
        {
            var temp = GetEntity(keyValue);
            if (temp == null)
                return null;
            //��ȡ��ǰʵ��,�ҵ���ǰʵ��ǰ������ͨ����ʵ��
            return GetWhereSubsetList(new { EndTime = temp.MODIFIEDDATE, UnifyCode = temp.UNIFIEDCODE }.ToJson()).OrderByDescending(t => t.MODIFIEDDATE).FirstOrDefault();
        }

        /// <summary>
        /// �ֺ�������ѯ�Ļ�������֮һ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_AVALANCHE_HISTORYEntity> GetWhereSubsetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_AVALANCHE_HISTORYEntity>();

            //���������ͨ��������
            expression = expression.And(t => t.AUDITSTATUS.Equals("2") || t.AUDITSTATUS.Equals("5"));

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

                #region ʡ���ؼ�������

                var expression1 = LinqExtensions.False<TBL_AVALANCHE_HISTORYEntity>();
                //��
                string TOWN = json.TOWN;
                string TOWNRPT = json.TOWNRPT;
                if (!string.IsNullOrEmpty(TOWN))
                {
                    foreach (var ton in TOWN.Split(','))
                    {
                        expression1 = expression1.Or(t => t.TOWN.Equals(ton));
                    }
                    expression = expression.And(expression1);


                }
                else if (!string.IsNullOrEmpty(TOWNRPT))
                {
                    foreach (var ton in TOWNRPT.Split(','))
                    {
                        expression1 = expression1.Or(t => t.TOWN.Equals(ton));
                    }
                    expression = expression.And(expression1);


                }
                else
                {
                    //��
                    string COUNTY = json.COUNTY;
                    string COUNTYRPT = json.COUNTYRPT;
                    if (!string.IsNullOrEmpty(COUNTY))
                    {
                        foreach (var ton in COUNTY.Split(','))
                        {
                            expression1 = expression1.Or(t => t.COUNTYCODE.Equals(ton));
                        }
                        expression = expression.And(expression1);


                    }
                    else if (!string.IsNullOrEmpty(COUNTYRPT))
                    {
                        foreach (var ton in COUNTYRPT.Split(','))
                        {
                            expression1 = expression1.Or(t => t.COUNTYCODE.Equals(ton));
                        }
                        expression = expression.And(expression1);


                    }
                    else
                    {
                        //��
                        string CITY = json.CITY;
                        string CITYRPT = json.CITYRPT;
                        if (!string.IsNullOrEmpty(CITY))
                        {
                            foreach (var ton in CITY.Split(','))
                            {
                                expression1 = expression1.Or(t => t.CITY.Equals(ton));
                            }
                            expression = expression.And(expression1);


                        }
                        else if (!string.IsNullOrEmpty(CITYRPT))
                        {
                            foreach (var ton in CITYRPT.Split(','))
                            {
                                expression1 = expression1.Or(t => t.CITY.Equals(ton));
                            }
                            expression = expression.And(expression1);


                        }
                        else
                        {
                            //ʡ
                            string PROVINCE = json.PROVINCE;
                            string PROVINCERPT = json.PROVINCERPT;
                            if (!string.IsNullOrEmpty(PROVINCE))
                            {
                                foreach (var ton in PROVINCE.Split(','))
                                {
                                    expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                                }
                                expression = expression.And(expression1);


                            }
                            else if (!string.IsNullOrEmpty(PROVINCERPT))
                            {
                                foreach (var ton in PROVINCERPT.Split(','))
                                {
                                    expression1 = expression1.Or(t => t.PROVINCE.Equals(ton));
                                }
                                expression = expression.And(expression1);
                            }

                        }
                    }
                }

                #endregion

                //��Ŀ����
                string PROJECTID = json.PROJECTID;
                if (!string.IsNullOrEmpty(PROJECTID))
                {
                    expression = expression.And(t => t.PROJECTID.Equals(PROJECTID));
                }

                //��������
                string MODIFYTYPE = json.MODIFYTYPE;
                if (!string.IsNullOrEmpty(MODIFYTYPE))
                {
                    expression = expression.And(t => t.MODIFYTYPE.Equals(MODIFYTYPE));
                }

                //�Ƿ��Ѿ�����
                string shifouhexiao = json.shifouhexiao;
                if (!string.IsNullOrEmpty(shifouhexiao))
                {
                    expression = expression.And(t => (shifouhexiao == "1" && t.VERIFICATION != null) || (shifouhexiao == "0" && t.VERIFICATION == null));
                }

                //�Ƿ�����
                string ISZLGCPNT = json.ISZLGCPNT;
                if (!string.IsNullOrEmpty(ISZLGCPNT))
                {
                    expression = expression.And(t => ISZLGCPNT == "1" ? (t.VERIFICATION != null && t.VERIFICATION.Contains("1")) : (t.VERIFICATION == null || !t.VERIFICATION.Contains("1")));
                }

                //�Ƿ��Ǩ
                string RELOCATION = json.RELOCATION;
                if (!string.IsNullOrEmpty(RELOCATION))
                {
                    expression = expression.And(t => RELOCATION == "1" ? (t.VERIFICATION != null && t.VERIFICATION.Contains("2")) : (t.VERIFICATION == null || !t.VERIFICATION.Contains("2")));
                }

                //��ʼʱ��
                string BeginTime = json.BeginTime;
                if (!string.IsNullOrEmpty(BeginTime))
                {
                    DateTime begin = Convert.ToDateTime(BeginTime);
                    expression = expression.And(t => t.MODIFIEDDATE >= begin);
                }
                //����ʱ��
                string EndTime = json.EndTime;
                if (!string.IsNullOrEmpty(EndTime))
                {
                    DateTime end = Convert.ToDateTime(EndTime);
                    expression = expression.And(t => t.MODIFIEDDATE < end);
                }

                //ͳһ���
                string UnifyCode = json.UnifyCode;
                if (!string.IsNullOrEmpty(UnifyCode))
                {
                    expression = expression.And(testc => testc.UNIFIEDCODE == UnifyCode);
                }
            }
            return this.BaseRepository().FindList(expression).ToList();
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
        public string SaveForm(string keyValue, TBL_AVALANCHE_HISTORYEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
                return entity.GUID;
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
                return entity.GUID;
            }
        }
        #endregion
    }
}
