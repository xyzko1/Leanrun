using Infoearth.Application.Entity.DMCJManage;
using Infoearth.Application.IService.DMCJManage;
using Infoearth.Application.Service.DMCJManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using Infoearth.Application.Entity;
using System.Data;

namespace Infoearth.Application.Busines.DMCJManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-22 12:10
    /// �� ����������������
    /// </summary>
    public class TBL_DMCJ_BASEINFOBLL
    {
        private TBL_DMCJ_BASEINFOIService service = new TBL_DMCJ_BASEINFOService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_DMCJ_BASEINFOEntity> GetPageList(Pagination pagination, string queryJson,string condition)
        {
            return service.GetPageList(pagination, queryJson,condition);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_DMCJ_BASEINFOEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        public IEnumerable<TBL_DMCJ_BASEINFOEntity> GetZYList(string queryJson, string condition) {
            return service.GetZYList(queryJson, condition);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_DMCJ_BASEINFOEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }

        /// <summary>
        /// ȡ���������ֶε�ֵ�б�
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<string> GetValueList(string queryJson)
        {
            return service.GetValueList(queryJson);
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
        public void SaveForm(string keyValue, MasterDetailEntity entity)
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

        public EchartEntity GetStatisticsByDmcj() {
            return service.GetStatisticsByDmcj();
        }
        public DataTable GetStatisticsByDmcjPie() {
            return service.GetStatisticsByDmcjPie();
        }
        public string GetMaxCode(string xzqh)
        {
            return service.GetMaxCode(xzqh);
        }
    }
}
