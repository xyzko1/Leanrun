using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-07 16:09
    /// �� �����Ų����ݱ�
    /// </summary>
    public class TBL_HAZARDBASICINFO_PC_GDBLL
    {
        private TBL_HAZARDBASICINFO_PC_GDIService service = new TBL_HAZARDBASICINFO_PC_GDService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_HAZARDBASICINFO_PC_GDEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ����ҳ�Ŀռ��ѯ
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<TBL_HAZARDBASICINFO_PC_GDEntity> GetSinglePastPageListJson(Pagination pagination, string queryJson, string condition)
        {
            return service.GetSinglePastPageListJson(pagination, queryJson, condition);
        }
        public IEnumerable<TBL_HAZARDBASICINFO_PC_GDEntity> GetHXMapList(string queryJson, string condition)
        {
            return service.GetHXMapList(queryJson, condition);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_HAZARDBASICINFO_PC_GDEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_HAZARDBASICINFO_PC_GDEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion
        #region ͳ��
        public DataTable GetAnalyseList(string queryJson)
        {
            return service.GetAnalyseList(queryJson);
        }
        public string GetZHDCountResult(string queryJson)
        {
            return service.GetZHDCountResult(queryJson);
        }
        

        #endregion
        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TBL_HAZARDBASICINFO_PC_GDEntity entity)
        {
            try
            {
                service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
