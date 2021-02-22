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
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-17 14:51
    /// 描 述：审核信息表
    /// </summary>
    public class TBL_AUDITINFOApiController : ApiControllerBase
    {
        private TBL_AUDITINFOBLL tbl_auditinfobll = new TBL_AUDITINFOBLL();

        #region 获取数据
        /// <summary>
        /// 分页获取提交列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
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
        /// 分页获取审核列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
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
        /// 获取待审核列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
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
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_AUDITINFOEntity GetFormJson(string keyValue)
        {
            var data = tbl_auditinfobll.GetEntity(keyValue);
            return data;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="param">主键值</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm(SingleParam param)
        {
            tbl_auditinfobll.RemoveForm(param.KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_AUDITINFOEntity entity)
        {
            tbl_auditinfobll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }

        /// <summary>
        /// 根据审核ID列表，提交审核
        /// </summary>
        /// <param name="keyValues">业务ID集合</param>
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
            return Success("提交成功。");
        }


        /// <summary>
        /// 根据审核ID列表，撤销审核
        /// </summary>
        /// <param name="keyValues">业务ID集合</param>
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
            return Success("撤销成功。");
        }

        /// <summary>
        /// 根据审核信息，审核数据
        /// </summary>
        /// <param name="infos"></param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult AuditData(AuditInfo infos)
        {
            if (infos == null)
                return Error("审核信息提交有误！");
            if (infos.keyValues != null && infos.keyValues.Count > 0)
            {
                foreach (var item in infos.keyValues)
                {
                    tbl_auditinfobll.AuditData(item, infos.state, infos.comment);
                }
            }
            return Success("审核成功。");
        }

        /// <summary>
        /// 核销数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="submitStr">提交</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult Verification(VerificationInfo info)
        {
            tbl_auditinfobll.Verification(info.BussnessKey, info.VerificationType);
            return Success("操作成功。");
        }

        #endregion
    }

    /// <summary>
    /// 审核信息
    /// </summary>
    public class AuditInfo
    {
        /// <summary>
        /// 审核业务ID主键
        /// </summary>
        public List<string> keyValues { get; set; }

        /// <summary>
        /// 审核状态（2-通过，3-不通过）
        /// </summary>
        public int state { get; set; }

        /// <summary>
        /// 审核批注
        /// </summary>
        public string comment { get; set; }
    }

    /// <summary>
    /// 核销数据信息
    /// </summary>
    public class VerificationInfo
    {
        /// <summary>
        /// 核销数据的业务主键
        /// </summary>
        public string BussnessKey { get; set; }

        /// <summary>
        /// 核销类型
        /// </summary>
        public int VerificationType { get; set; }
    }
}
