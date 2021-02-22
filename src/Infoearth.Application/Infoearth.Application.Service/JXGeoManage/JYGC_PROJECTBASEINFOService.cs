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
using System.Data;
using Infoearth.Util;
using Infoearth.Util.Extension;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 15:53
    /// �� �������빤����Ŀ������Ϣ��
    /// </summary>
    public class JYGC_PROJECTBASEINFOService : RepositoryFactory<JYGC_PROJECTBASEINFOEntity>, JYGC_PROJECTBASEINFOIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<JYGC_PROJECTBASEINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return this.BaseRepository().FindList(pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<JYGC_PROJECTBASEINFOEntity> GetList(string queryJson)
        {
            var experssion = LinqExtensions.True<JYGC_PROJECTBASEINFOEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                dynamic json = JToken.Parse(queryJson) as dynamic;
                string txt_Keyword = json.txt_Keyword;
                if (!string.IsNullOrEmpty(txt_Keyword))
                {
                    experssion = experssion.And(t => t.PROJECTNAME.Contains(txt_Keyword));
                }
            }
            return this.BaseRepository().FindList(experssion);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public JYGC_PROJECTBASEINFOEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        /// <summary>
        /// ��ȡ���ߴ���һ����ĿID
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public JYGC_PROJECTBASEINFOEntity GetOrCreateProjectId(string projectName)
        {
            var experssion = LinqExtensions.True<JYGC_PROJECTBASEINFOEntity>();
            if (!string.IsNullOrEmpty(projectName))
            {
                experssion = experssion.And(t => t.PROJECTNAME.Equals(projectName));
            }
            else
            {
                return null;
            }
            var tempResult = this.BaseRepository().FindList(experssion);
            if (tempResult != null && tempResult.Count() > 0)
            {
                return tempResult.FirstOrDefault();
            }
            else
            {
                //����ProjectId
                JYGC_PROJECTBASEINFOEntity entity = new JYGC_PROJECTBASEINFOEntity()
                {
                    PROJECTGUID = Guid.NewGuid().ToString(),
                    PROJECTCODE = "1",
                    PROJECTTYPE = "���",
                    PROJECTNAME = projectName,
                    TIMECREATED = DateTime.Now,
                    USERCREATED = "����Ա",
                    USERMODIFIED = "����Ա"
                };
                entity.Create();
                this.BaseRepository().Insert(entity);
                return entity;
            }
        }

        public List<string> GetProjectIDList(string queryJson)
        {
            List<string> list = new List<string>();
            var result = new DataTable();
            if (!string.IsNullOrEmpty(queryJson))
            {
                dynamic json = JToken.Parse(queryJson) as dynamic;
                string PROJECTTYPE = json.PROJECTTYPE;

                //                string sql = @"select * from 
                //(select * from JYGC_PROJECTBASEINFO t order by t.YEAR desc) tb where 1=1 and tb.PROJECTTYPE = '" + PROJECTTYPE + "'";
                string sql = @"select * from 
(select * from JYGC_PROJECTBASEINFO t order by t.PROJECTCODE desc) tb where 1=1 and tb.PROJECTTYPE = '" + PROJECTTYPE + "'";
                result = this.BaseRepository().FindTable(sql);
                if (result.Rows.Count > 0)
                {
                    for (int i = 0; i < result.Rows.Count; i++)
                    {
                        list.Add(result.Rows[i][0].ToString());
                    }
                }

            }

            return list;
        }
        public List<JYGC_PROJECTBASEINFOEntity> GetListByDateDiff(string queryJson)
        {
            List<JYGC_PROJECTBASEINFOEntity> returnValue = new List<JYGC_PROJECTBASEINFOEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["endYear"].IsEmpty())
            {
                int endYear = queryParam["endYear"].ToInt();
                JYGC_PROJECTBASEINFOEntity entity = this.BaseRepository().FindList(p => p.YEAR <= endYear).OrderByDescending(p => p.YEAR).FirstOrDefault();
                returnValue.Add(entity);
            }
            if (!queryParam["startYear"].IsEmpty())
            {
                int startYear = queryParam["startYear"].ToInt();
                JYGC_PROJECTBASEINFOEntity entity = this.BaseRepository().FindList(p => p.YEAR >= startYear).OrderByDescending(p => p.YEAR).FirstOrDefault();
                if (entity != null)
                {
                    if (!returnValue.Select(p => p.PROJECTGUID).Contains(entity.PROJECTGUID))
                    {
                        returnValue.Add(entity);
                    }
                }

            }
            return returnValue;
        }
        #endregion
        /// <summary>
        /// ���ݲ�ѯ��Ȼ�ȡ���һ�εĵ�����Ŀ���Ų���Ŀ
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public string GetTCYearProject(string queryJson)
        {
            var result = new DataTable();
            string value = "";
            string sqlStr = "";
            if (!string.IsNullOrEmpty(queryJson))
            {
                dynamic json = JToken.Parse(queryJson) as dynamic;
                string YEAR = json.YEAR;
                string PROJECTTYPE = json.PROJECTTYPE;
                if (!string.IsNullOrEmpty(YEAR))
                {
                    sqlStr += " and  tb.YEAR <= '" + YEAR + "'";
                }
                if (!string.IsNullOrEmpty(PROJECTTYPE))
                {
                    sqlStr += "and tb.PROJECTTYPE = '" + PROJECTTYPE + "'";
                }
                string sql = @"select * from 
(select * from JYGC_PROJECTBASEINFO t order by t.YEAR desc) tb where 1=1 " + sqlStr + "  and rownum < 2";
                result = this.BaseRepository().FindTable(sql);
                if (result.Rows.Count > 0)
                {
                    value = result.Rows[0][0].ToString();
                }

            }
            return value;
        }
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
        public void SaveEntity(string keyValue, JYGC_PROJECTBASEINFOEntity entity)
        {
            UserInfo userInfo = ssoWS.GetUserInfo();
            string userName = userInfo.F_Account;
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                entity.TIMEMODIFIED = DateTime.Now;
                entity.USERMODIFIED = userName;
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                entity.TIMECREATED = DateTime.Now;
                entity.USERCREATED = userName;
                this.BaseRepository().Insert(entity);
            }
        }

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
        public void SaveForm(string keyValue, JYGC_PROJECTBASEINFOEntity entity)
        {
            UserInfo userInfo = ssoWS.GetUserInfo();
            string userName = userInfo.F_Account;
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                entity.TIMEMODIFIED = DateTime.Now;
                entity.USERMODIFIED = userName;
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                entity.TIMECREATED = DateTime.Now;
                entity.USERCREATED = userName;
                entity.USERMODIFIED = userName;
                entity.TIMEMODIFIED = DateTime.Now;
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
