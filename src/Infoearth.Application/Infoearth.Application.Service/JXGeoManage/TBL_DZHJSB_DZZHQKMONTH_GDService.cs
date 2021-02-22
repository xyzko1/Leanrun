using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-15 15:38
    /// �� ����Ѳ�������������
    /// </summary>
    public class TBL_DZHJSB_DZZHQKMONTH_GDService : RepositoryFactory<TBL_DZHJSB_DZZHQKMONTH_GDEntity>, TBL_DZHJSB_DZZHQKMONTH_GDIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_DZHJSB_DZZHQKMONTH_GDEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_DZHJSB_DZZHQKMONTH_GDEntity>();
            return this.BaseRepository().FindList(expression);
        }
        public DataTable Getdata(string queryJson)
        {
            int Year = 0;
            int Month = 12;
            int StartMonth = 1;
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            int.TryParse(json.Year.ToString(), out Year);
            int.TryParse(json.EndMonth.ToString(), out Month);
            int.TryParse(json.StartMonth.ToString(), out StartMonth);                 
            DataTable dt = new DataTable();
            #region ���ӱ�ͷ
            dt.Columns.Add("��");
            dt.Columns.Add("������������");
            dt.Columns.Add("��Ȼ");
            dt.Columns.Add("��Ϊ");
            dt.Columns.Add("�ش���");
            dt.Columns.Add("����");
            dt.Columns.Add("����");
            dt.Columns.Add("�ﵽͳ�Ʊ�׼");
            dt.Columns.Add("δ�ﵽͳ�Ʊ�׼");
            dt.Columns.Add("����");
            dt.Columns.Add("����");
            dt.Columns.Add("��ʯ��");
            dt.Columns.Add("��������");
            dt.Columns.Add("���ѷ�");
            dt.Columns.Add("�������");
            dt.Columns.Add("����");
            dt.Columns.Add("ʧ��");
            dt.Columns.Add("����");
            dt.Columns.Add("������ʧ����Ԫ��");
            dt.Columns.Add("��ע");
            #endregion
            //������ѯ�·ݣ��·ݴ�1�¿�ʼ��
            for (int i = StartMonth; i <= Month; i++)
            {
                var dtoArr = GetListentity(Year, i, i);
                var dr = dt.NewRow();
                dr["��"] = i;
                dr["������������"] = dtoArr.Count();
                dr["��Ȼ"] = dtoArr.Count(t => t.COURSE.Contains("��Ȼ"));
                dr["��Ϊ"] = dtoArr.Count(t => t.COURSE.Contains("��Ϊ"));
                dr["�ش���"] = dtoArr.Count(t => t.ZHDJ == "�ش���");
                dr["����"] = dtoArr.Count(t => t.ZHDJ == "����");
                dr["����"] = dtoArr.Count(t => t.ZHDJ == "����");
                dr["�ﵽͳ�Ʊ�׼"] = dtoArr.Count(t => t.ZHDJ == "С��");
                dr["δ�ﵽͳ�Ʊ�׼"] = 0;
                dr["����"] = dtoArr.Count(t => t.ZHLX.Contains("����"));
                dr["����"] = dtoArr.Count(t => t.ZHLX.Contains("����"));
                dr["��ʯ��"] = dtoArr.Count(t => t.ZHLX.Contains("��ʯ��"));
                dr["��������"] = dtoArr.Count(t => t.ZHLX.Contains("��������"));
                dr["���ѷ�"] = dtoArr.Count(t => t.ZHLX.Contains("���ѷ�"));
                dr["�������"] = dtoArr.Count(t => t.ZHLX.Contains("�������"));
                dr["����"] = dtoArr.Sum(t => t.SW);
                dr["ʧ��"] = dtoArr.Sum(t => t.SZ);
                dr["����"] = dtoArr.Sum(t => t.SS);
                dr["������ʧ����Ԫ��"] = dtoArr.Sum(t => t.ZJJJSS);
                dr["��ע"] ="";
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public IEnumerable<TBL_DZHJSB_DZZHQKMONTH_GDEntity> GetListentity(int Year, int StartMonth, int EndMonth)
        {
            var expression = queryJsonExpression(Year,StartMonth,EndMonth);
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_DZHJSB_DZZHQKMONTH_GDEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_DZHJSB_DZZHQKMONTH_GDEntity entity)
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

        #region ɸѡ����
        System.Linq.Expressions.Expression<Func<TBL_DZHJSB_DZZHQKMONTH_GDEntity, bool>> queryJsonExpression(int Year, int StartMonth, int EndMonth)
        {
            var expression = LinqExtensions.True<TBL_DZHJSB_DZZHQKMONTH_GDEntity>();
            expression = expression.And(t => t.HAPPENDATE.Value.Year == Year && t.HAPPENDATE.Value.Month >= StartMonth && t.HAPPENDATE.Value.Month <= EndMonth);
            return expression;
        }
        #endregion
    }
}
