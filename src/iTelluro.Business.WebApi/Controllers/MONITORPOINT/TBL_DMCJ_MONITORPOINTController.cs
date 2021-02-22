using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Application.Busines.MONITORPOINT;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using iTelluro.Busness.WebApiProxy;
using System.Linq;
using Infoearth.Application.Entity;
using Infoearth.Util.Offices;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// �������������Ϣ��
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTController : ApiControllerBase
    {
        private TBL_DMCJ_MONITORPOINTBLL tbl_dmcj_monitorpointbll = new TBL_DMCJ_MONITORPOINTBLL();
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/GetPageListJson")]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson, string condition = null)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_dmcj_monitorpointbll.GetPageList(pagination, queryJson, condition);
            int count = pagination.records;
            var total = count % pagination.rows == 0 ? count / pagination.rows : count / pagination.rows + 1;
            var jsonData = new
            {
                rows = data,
                total = total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpPost]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/PostPageListJson")]
        public object PostPageListJson(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];

            var watch = CommonHelper.TimerStart();
            var data = tbl_dmcj_monitorpointbll.GetPageList(entity.pagination, entity.queryJson, entity.condition);
            int count = entity.pagination.records;
            var total = count % entity.pagination.rows == 0 ? count / entity.pagination.rows : count / entity.pagination.rows + 1;
            var jsonData = new
            {
                rows = data,
                total = total,
                page = entity.pagination.page,
                records = entity.pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/GetListJson")]
        public object GetListJson(string queryJson, string condition = null)
        {
            var data = new List<TBL_DMCJ_MONITORPOINTEntity>();
            if (!string.IsNullOrEmpty(condition))
            {
                data = tbl_dmcj_monitorpointbll.GetZYList(queryJson, condition).ToList();
            }
            else
            {
                data = tbl_dmcj_monitorpointbll.GetList(queryJson).ToList();
            }
            return data;
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpPost]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/PostListJson")]
        public object PostListJson(QueryJsonEntity entity)
        {
            var data = new List<TBL_DMCJ_MONITORPOINTEntity>();
            if (!string.IsNullOrEmpty(entity.condition))
            {
                data = tbl_dmcj_monitorpointbll.GetZYList(entity.queryJson, entity.condition).ToList();
            }
            else
            {
                data = tbl_dmcj_monitorpointbll.GetList(entity.queryJson).ToList();
            }
            return data;
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/GetFormJson")]
        public object GetFormJson(string keyValue)
        {
            var data = tbl_dmcj_monitorpointbll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// ��ȡ��ǰ��¼�û�
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/GetUserInfo")]
        public List<string> GetUserInfo()
        {
            //���ݷ�ΧȨ�޹���
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            return _codes;
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/RemoveForm")]
        public object RemoveForm(string keyValue)
        {
            tbl_dmcj_monitorpointbll.RemoveForm(keyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/SaveForm")]
        public object SaveForm(string keyValue, TBL_DMCJ_MONITORPOINTEntity entity)
        {
            tbl_dmcj_monitorpointbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion

        #region ����excel

        /// <summary>
        /// �����ѯ(����Excel)
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="outColumn"></param>
        [HttpPost]
        public object ExcelDownload_POST(PostExcelEntity entity)
        {
            var list = new List<TBL_DMCJ_MONITORPOINTEntity>();
            if (!string.IsNullOrEmpty(entity.condition))
            {
                list = tbl_dmcj_monitorpointbll.GetZYList(entity.queryJson, entity.condition).ToList();
            }
            else
            {
                list = tbl_dmcj_monitorpointbll.GetList(entity.queryJson).ToList();
            }

            string[] columnArr = entity.outColumn.TrimEnd(',').Split(',');//Ҫ��������

            List<ColumnEntity> ColumnList = new List<ColumnEntity>();
            IDictionary<string, string> dicArr = UtilityController.GetAllPropertyDic<TBL_DMCJ_MONITORPOINTEntity>();//��ȡ�ֵ��ֶ�
            //��ʾ��
            foreach (var item in dicArr.Keys)
            {
                if (columnArr.Contains(item))
                {
                    ColumnList.Add(new ColumnEntity { Column = item, ExcelColumn = dicArr[item], Width = 30 });
                }
            }
            UtilityController.ConvertDicValue(list);//�ֵ��ֵ
            ExcelConfig excelConfig = new ExcelConfig();
            excelConfig.IsAllSizeColumn = true;
            excelConfig.ColumnEntity = ColumnList;
            excelConfig.FileName = "�����ѯ-" + DateTime.Now.ToString("yyyy.MM.dd") + ".xls";
            excelConfig.Title = "�����ѯ";
            
            string fileNameGuid = System.IO.Path.GetFileName(ExcelHelperEx<TBL_DMCJ_MONITORPOINTEntity>.ExcelCreate(list, excelConfig, true));
            var returnValue = new
            {
                fileNameGuid = fileNameGuid,
                DownFileName = excelConfig.FileName
            };
            return returnValue;

        }
        #endregion
    }
}
