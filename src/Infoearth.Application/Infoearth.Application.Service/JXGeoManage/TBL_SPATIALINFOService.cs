using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� Infoearth ADMS6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-03-28 14:23
    /// �� ������Χ���ݱ�
    /// </summary>
    public class TBL_SPATIALINFOService : RepositoryFactory<TBL_SPATIALINFOEntity>, TBL_SPATIALINFOIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_SPATIALINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
             return this.BaseRepository().FindList(pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_SPATIALINFOEntity> GetList(string queryJson)
        {
            return this.BaseRepository().IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_SPATIALINFOEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        /// <summary>
        ///  ����ͼ���š��ֺ����Ż�ȡ����
        /// </summary>
        /// <param name="layerid">ͼ����</param>
        /// <param name="subcode">�ֺ�����</param>
        /// <returns></returns>
        public IEnumerable<TBL_SPATIALINFOEntity> GetDataLayer(string layerid, string subcode)
        {
            string sql = string.Format("select * from TBL_SPATIALINFO t  where layerid = '{0}' and  subcode like  '{1}%'", layerid, subcode);
            return this.BaseRepository().FindList(sql);
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
        public void DeleteEntityNew(string keyValue)
        {
            //this.BaseRepository().Delete(keyValue);
            var parameter = new List<DbParameter>();
            string sql = "DELETE FROM TBL_SPATIALINFO where SUBCODE = '" + keyValue+"'" ;
            this.BaseRepository().ExecuteBySql(sql, parameter.ToArray());
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, TBL_SPATIALINFOEntity entity)
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
