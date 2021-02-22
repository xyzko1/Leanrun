using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using System;
using Infoearth.Util.Extension;
using Newtonsoft.Json.Linq;
using Infoearth.Util;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 11:51
    /// �� �������µ������ʷ��
    /// </summary>
    public class TBL_LANDSLIP_HIDDEN_HISTORYService : RepositoryFactory<TBL_LANDSLIP_HIDDEN_HISTORYEntity>, TBL_LANDSLIP_HIDDEN_HISTORYIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_LANDSLIP_HIDDEN_HISTORYEntity> GetPageList(Pagination pagination, string queryJson)
        {
             return this.BaseRepository().FindList(pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_LANDSLIP_HIDDEN_HISTORYEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_LANDSLIP_HIDDEN_HISTORYEntity>();

            if (!string.IsNullOrEmpty(queryJson))
            {
                dynamic json = JToken.Parse(queryJson) as dynamic;

                //ͨ������
                string audited = json.audited;
                if (!string.IsNullOrEmpty(audited))
                {
                    expression = expression.And(t => t.AUDITSTATUS == "1" || t.AUDITSTATUS == "5");
                }

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
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetEntity(string keyValue)
        {
            //if (keyValue.Length == 12)
            //{
            //    keyValue = keyValue + " " + " " + " " + " ";
            //}
            return this.BaseRepository().FindEntity(keyValue);
        }
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetEntityByUNIFIEDCODE(string keyValue)
        {
            return this.BaseRepository().FindEntity(t=>t.UNIFIEDCODE.Contains(keyValue));
        }
        /// <summary>
        /// ��ȡ��ǰʵ��ǰ������ͨ����ʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetAuditEntity(string keyValue)
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
        public IEnumerable<TBL_LANDSLIP_HIDDEN_HISTORYEntity> GetWhereSubsetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_LANDSLIP_HIDDEN_HISTORYEntity>();

            //���������ͨ��������
            expression = expression.And(t => t.AUDITSTATUS.Equals("2") || t.AUDITSTATUS.Equals("5"));

            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;

                #region ʡ���ؼ�������

                var expression1 = LinqExtensions.False<TBL_LANDSLIP_HIDDEN_HISTORYEntity>();
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
                    expression = expression.And(t => ISZLGCPNT == "1" ?(t.VERIFICATION!=null&&t.VERIFICATION.Contains("1")):(t.VERIFICATION==null||!t.VERIFICATION.Contains("1")));
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
                //HAPPENTIME
            }
            return this.BaseRepository().FindList(expression).ToList();
        }

        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void DeleteEntity(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, TBL_LANDSLIP_HIDDEN_HISTORYEntity entity)
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


        /// <summary>
        /// ��ȡ������˵�����
        /// </summary>
        /// <param name="unifycode"></param>
        /// <returns></returns>
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetLatestEntity(string unifycode)
        {
            var expression = LinqExtensions.True<TBL_LANDSLIP_HIDDEN_HISTORYEntity>();
            expression = expression.And(t => t.AUDITSTATUS == "1" || t.AUDITSTATUS == "5");
            expression = expression.And(t => t.UNIFIEDCODE == unifycode);

            var result = this.BaseRepository().FindList(expression).OrderBy(t => t.MODIFIEDDATE).ToList();
            if (result.Count > 0)
                return result[result.Count - 1];
            return null;
        }

        /// <summary>
        /// ����һ����¼
        /// </summary>
        /// <param name="entity"></param>
        public void InsertEntity(TBL_LANDSLIP_HIDDEN_HISTORYEntity entity)
        {
            this.BaseRepository().Insert(entity);
        }
    }
}
