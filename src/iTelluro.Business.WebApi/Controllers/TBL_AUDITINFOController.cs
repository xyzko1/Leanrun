using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApi;
using System.Web.Http;
using System.Collections.Generic;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-17 14:51
    /// �� ���������Ϣ��
    /// </summary>
    public class TBL_AUDITINFOApiController : ApiControllerBase
    {
        private TBL_AUDITINFOBLL tbl_auditinfobll = new TBL_AUDITINFOBLL();

        #region ��ȡ����
        /// <summary>
        /// ��ҳ��ȡ�ύ�б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetPageSubmitListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_auditinfobll.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }

        /// <summary>
        /// ��ҳ��ȡ����б�
        /// </summary>
        /// <param name="pagination">��ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�Json</returns>
        [HttpGet]
        public object GetPageAuditListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_auditinfobll.GetPageList2(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// ��ȡ������б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        [HttpGet]
        public object GetPageNoAuditListJson(string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_auditinfobll.GetPageList3(queryJson);
            var jsonData = new
            {
                rows = data,
            };
            return jsonData;
        }

        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public TBL_AUDITINFOEntity GetFormJson(string keyValue)
        {
            var data = tbl_auditinfobll.GetEntity(keyValue);
            return data;
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="param">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm(SingleParam param)
        {
            tbl_auditinfobll.RemoveForm(param.KeyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_AUDITINFOEntity entity)
        {
            tbl_auditinfobll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }

        /// <summary>
        /// �������ID�б��ύ���
        /// </summary>
        /// <param name="keyValues">ҵ��ID����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SubmitAudit([FromBody]List<string> keyValues)
        {
            if (keyValues != null && keyValues.Count > 0)
            {
                foreach (var item in keyValues)
                {
                    tbl_auditinfobll.SubmitAudit(item);
                }
            }
            return Success("�ύ�ɹ���");
        }


        /// <summary>
        /// �������ID�б��������
        /// </summary>
        /// <param name="keyValues">ҵ��ID����</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult CancelSubmit([FromBody]List<string> keyValues)
        {
            if (keyValues != null && keyValues.Count > 0)
            {
                foreach (var item in keyValues)
                {
                    tbl_auditinfobll.CancelSubmit(item);
                }
            }
            return Success("�����ɹ���");
        }

        /// <summary>
        /// ���������Ϣ���������
        /// </summary>
        /// <param name="infos"></param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult AuditData(AuditInfo infos)
        {
            if (infos == null)
                return Error("�����Ϣ�ύ����");
            if (infos.keyValues != null && infos.keyValues.Count > 0)
            {
                foreach (var item in infos.keyValues)
                {
                    tbl_auditinfobll.AuditData(item, infos.state, infos.comment);
                }
            }
            return Success("��˳ɹ���");
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="keyValue">����</param>
        /// <param name="submitStr">�ύ</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult Verification(VerificationInfo info)
        {
            tbl_auditinfobll.Verification(info.BussnessKey, info.VerificationType);
            return Success("�����ɹ���");
        }

        #endregion
    }

    /// <summary>
    /// �����Ϣ
    /// </summary>
    public class AuditInfo
    {
        /// <summary>
        /// ���ҵ��ID����
        /// </summary>
        public List<string> keyValues { get; set; }

        /// <summary>
        /// ���״̬��2-ͨ����3-��ͨ����
        /// </summary>
        public int state { get; set; }

        /// <summary>
        /// �����ע
        /// </summary>
        public string comment { get; set; }
    }

    /// <summary>
    /// ����������Ϣ
    /// </summary>
    public class VerificationInfo
    {
        /// <summary>
        /// �������ݵ�ҵ������
        /// </summary>
        public string BussnessKey { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public int VerificationType { get; set; }
    }
}
