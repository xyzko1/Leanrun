using Infoearth.Application.Entity.DemoManage;
using Infoearth.Application.IService.DemoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.DemoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 
    /// �� ������������Ա
    /// �� �ڣ�2017-07-21 16:01
    /// �� �������������
    /// </summary>
    public class Base_AreaService : RepositoryFactory<Base_AreaEntity>, Base_AreaIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<Base_AreaEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<Base_AreaEntity>();
            //var queryParam = queryJson.ToJObject();
            //queryParam.g

            //for (int i = 0; i < queryParam.Count; i++)
            //{
            //   var  ss= queryParam[i];
            //}
            //��־����
            //if (!queryParam["Category"].IsEmpty())
            //{
            //    int categoryId = queryParam["CategoryId"].ToInt();
     
            //    expression = expression.And(t => t.F_CategoryId == categoryId);
            //}
            ////����ʱ��
            //if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            //{
            //    DateTime startTime = queryParam["StartTime"].ToDate();
            //    DateTime endTime = queryParam["EndTime"].ToDate().AddDays(1);
            //    expression = expression.And(t => t.F_OperateTime >= startTime && t.F_OperateTime <= endTime);
            //}
            string sql = "select * from Base_Area where 1=1";
            List<string> xzqucodes = ssoWS.GetAllAuthDistricts();
            string userIds = ssoWS.GetAllAuthUserIds();
            if (!xzqucodes.Contains("000000") && !xzqucodes.Equals("0"))
            {
                string xzqhstr = "";
                foreach (var item in xzqucodes)
                {
                    xzqhstr += "'" + item + "',";
                }
                xzqhstr = xzqhstr.TrimEnd(',');
                sql+=" and "+" in("+xzqhstr+") ";
                expression = expression.And(t => xzqucodes.Contains(t.F_AreaCode));
            }

            if(userIds.Trim('"').ToLower()!="system")
            {
                userIds = userIds.TrimEnd(',').Replace(",", "','");
                sql += " and " + " in('" + userIds + "') ";
            }
            //expression = expression.And(t => userIds.Contains(t.F_AreaCode));

           
            return this.BaseRepository().FindList(sql, pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<Base_AreaEntity> GetList(string queryJson)
        {
            return this.BaseRepository().IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public Base_AreaEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, Base_AreaEntity entity)
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
