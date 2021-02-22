using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApi;
using System.Web.Http;
using System.Collections.Generic;
using Infoearth.Application.Entity;
using System.Data;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 16:41
    /// �� �������빤����Ŀ������Ϣ��
    /// </summary>
    public class JYGC_PROJECTBASEINFOApiController : ApiControllerBase
    {
        private JYGC_PROJECTBASEINFOBLL jygc_projectbaseinfobll = new JYGC_PROJECTBASEINFOBLL();
        private HarzardTrendAnalyseBLL harzardTrendAnalyseBLL = new HarzardTrendAnalyseBLL();
        #region ��ȡ����
        /// <summary>
        /// ��ȡ���������б�
        /// </summary>
        /// <param name="queryJson">
        /// ��ѯ����
        /// txt_keyword ģ��ƥ�乤���ļ���
        /// </param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        public IEnumerable<JYGC_PROJECTBASEINFOEntity> GetListJson(string queryJson)
        {
            return jygc_projectbaseinfobll.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public JYGC_PROJECTBASEINFOEntity GetFormJson(string keyValue)
        {
            var data = jygc_projectbaseinfobll.GetEntity(keyValue);
            return data;
        }

        /// <summary>
        /// ��ȡ���еĵ�����Ŀ���Ų���Ŀ
        /// </summary>
        /// <param name="queryJson">
        /// PROJECTTYPE ��Ŀ����(���顢�Ų�)
        /// </param>
        /// <returns></returns>
        [HttpGet]

        public object GetProjectIDList(string queryJson)
        {
            var data = jygc_projectbaseinfobll.GetProjectIDList(queryJson);
            return data;
        }
        /// <summary>
        /// ��ȡ���ߴ���һ����ĿID
        /// </summary>
        /// <param name="projectName">��Ŀ����</param>
        /// <returns></returns>
        [HttpGet]
        public JYGC_PROJECTBASEINFOEntity GetOrCreateProjectId(string projectName)
        {
            return jygc_projectbaseinfobll.GetOrCreateProjectId(projectName);
        }
        /// <summary>
        /// ��ȡ���ڷ�Χ��Ŀ
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetListByDateDiff(string queryJson)
        {
            return jygc_projectbaseinfobll.GetListByDateDiff(queryJson);
        }
        [HttpGet]
        public object QueryStatistics(string queryJson)
        {

            List<MergedRegionEntity> columnList = new List<MergedRegionEntity>();
            DataTable result = harzardTrendAnalyseBLL.QueryStatistics(queryJson, ref columnList);
            var jsonData = new
            {
                Columns = columnList,
                Data = result
            };
            return jsonData;
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm(SingleParam keyValue)
        {
            jygc_projectbaseinfobll.RemoveForm(keyValue.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, JYGC_PROJECTBASEINFOEntity entity)
        {
            jygc_projectbaseinfobll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
