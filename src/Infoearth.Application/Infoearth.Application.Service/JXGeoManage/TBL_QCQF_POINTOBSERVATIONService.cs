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
using System.Data;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-11 15:39
    /// �� ����Ⱥ��Ⱥ������͹۲��˹�����
    /// </summary>
    public class TBL_QCQF_POINTOBSERVATIONService : RepositoryFactory<TBL_QCQF_POINTOBSERVATIONEntity>, TBL_QCQF_POINTOBSERVATIONIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetPageList(Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TBL_QCQF_POINTOBSERVATIONEntity>();
             return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_QCQF_POINTOBSERVATIONEntity>();
            return this.BaseRepository().FindList(expression);
        }
        public IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetListByID(string ID)
        {
            return this.BaseRepository().FindList(t => t.ID.Contains(ID));
        }
        public IEnumerable<TBL_QCQF_POINTOBSERVATIONEntity> GetListByUNIFIEDCODE(string UNIFIEDCODE)
        {
            return this.BaseRepository().FindList(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE));
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_QCQF_POINTOBSERVATIONEntity GetEntity(string keyValue)
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
        public void RemoveFormByID(string keyValue)
        {
            this.BaseRepository().Delete(t=>t.ID== keyValue);
        }
        public void RemoveFormByUNIFIEDCODE(string keyValue)
        {
            this.BaseRepository().Delete(t => t.UNIFIEDCODE == keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TBL_QCQF_POINTOBSERVATIONEntity entity)
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
        public void SaveFormByID(string ID, string UNIFIEDCODE)
        {
            if (UNIFIEDCODE == null || ID == null)
            {
                return;
            }
            if (ID.Trim('[').Trim(']').IsEmpty() || UNIFIEDCODE.Trim('[').Trim(']').IsEmpty())
            {
                return;
            }
            if (ID.Contains("["))
            {
                this.BaseRepository().Delete(t => t.UNIFIEDCODE == UNIFIEDCODE);//��ɾ��
                var expression = LinqExtensions.True<TBL_QCQF_POINTOBSERVATIONEntity>();
                string[] Guids; string[] UNIFIEDCODEs;
                Guids = ID.Trim('[').Trim(']').Split(','); UNIFIEDCODEs = UNIFIEDCODE.Trim('[').Trim(']').Split(',');
                for (int i = 0; i < Guids.Count(); i++)
                {
                    TBL_QCQF_POINTOBSERVATIONEntity entity = new TBL_QCQF_POINTOBSERVATIONEntity();
                    entity.ID = Guids[i].Trim('"');
                    entity.UNIFIEDCODE = UNIFIEDCODEs[i].Trim('"');
                    entity.GUID = Guid.NewGuid().ToString();
                    this.BaseRepository().Insert(entity);
                }
            }
            else
            {
                this.BaseRepository().Delete(t => t.ID == ID);//��ɾ��
                var expression = LinqExtensions.True<TBL_QCQF_POINTOBSERVATIONEntity>();
                string[] Guids;
                Guids = UNIFIEDCODE.Trim('[').Trim(']').Split(',');
                for (int i = 0; i < Guids.Count(); i++)
                {
                    TBL_QCQF_POINTOBSERVATIONEntity entity = new TBL_QCQF_POINTOBSERVATIONEntity();
                    entity.ID = ID;
                    entity.UNIFIEDCODE = Guids[i].Trim('"');
                    entity.GUID = Guid.NewGuid().ToString();
                    this.BaseRepository().Insert(entity);
                }
            }
        }

        public DataTable GetDataJcd(string id)
        {
            string sql = ""; string where1 = "where 1=1 ";
            if (!String.IsNullOrWhiteSpace(id))
            {
                where1 += "and p.ID = '" + id + "'";
                sql = "select A.GUID as GUID ,A.MONITORPOINTCODE as MONITORPOINTCODE,A.MONITORPOINTPOSITION as MONITORPOINTPOSITION,B.UNIFIEDCODE as UNIFIEDCODE,B.DISASTERNAME as DISASTERNAME,B.LOCATION as LOCATION from TBL_QCQF_POINTOBSERVATION p left join TBL_QCQF_LAYOUTPOINTINFO A on  A.GUID = p.UNIFIEDCODE left join TBL_HAZARDBASICINFO B on B.UNIFIEDCODE = A.UNIFIEDCODE  " + where1;
            }
            else
            {
                sql = "select * from TBL_QCQF_LAYOUTPOINTINFO where 1=2";
            }
            return this.BaseRepository().FindTable(sql);
        }
        public DataTable GetDataJcr(string id)
        {
            string sql = ""; string where1 = "where 1=1 ";
            if (!String.IsNullOrWhiteSpace(id))
            {
                where1 += "and a.UNIFIEDCODE = '" + id + "'";
                sql = "SELECT b.OBSERVATIONPEOPLE,b.OBSERVATIONPHONE,b.GUID from TBL_QCQF_POINTOBSERVATION a inner join TBL_QCQF_OBSERVATION b on a.ID=b.GUID  " + where1;
                //sql = "SELECT b.OBSERVATIONPEOPLE,b.OBSERVATIONPHONE,b.GUID from TBL_QCQF_POINTOBSERVATION a inner join TBL_QCQF_OBSERVATION b on a.UNIFIEDCODE=b.GUID  " + where1;
            }
            else
            {
                sql = "select * from TBL_QCQF_OBSERVATION where 1=2";
            }
            return this.BaseRepository().FindTable(sql);
        }
        public void delegl(string id, string guid)
        {
            if (!String.IsNullOrWhiteSpace(id) && !String.IsNullOrWhiteSpace(id))
            {
                string sql = "DELETE  TBL_QCQF_POINTOBSERVATION where UNIFIEDCODE='" + id + "' AND ID='" + guid + "'";
                this.BaseRepository().FindTable(sql);
            }
            else
            {
                return;
            } 
        }
        public void deleglnew( string id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                string sql = "DELETE  TBL_QCQF_POINTOBSERVATION where UNIFIEDCODE='" + id + "'";
                this.BaseRepository().FindTable(sql);
            }
            else
            {
                return;
            }
        }
        public void deleglnewByqCqf(string id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                string sql = "DELETE  TBL_QCQF_POINTOBSERVATION where ID='" + id + "'";
                this.BaseRepository().FindTable(sql);
            }
            else
            {
                return;
            }
        }
        #endregion
    }
}
