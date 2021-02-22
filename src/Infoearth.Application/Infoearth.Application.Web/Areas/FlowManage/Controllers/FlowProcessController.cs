﻿using Infoearth.Application.Busines.FormManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;


namespace Infoearth.Application.Web.Areas.FlowManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 
    /// 创建人：陈彬彬
    /// 日 期：2016.03.19 13:57
    /// 描 述:流程实例公用处理方法
    /// </summary>
    public class FlowProcessController : MvcControllerBase
    {
        private WFProcessBLL wfProcessBll = new WFProcessBLL();
        #region 视图功能
        /// <summary>
        /// 流程监控
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MonitoringIndex()
        {
            return View();
        }
        /// <summary>
        /// 流程指派
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DesignationIndex()
        {
            return View();
        }
        /// <summary>
        /// 流程进度查看
        /// </summary>
        /// <returns></returns>\
        [HttpGet]
        public ActionResult ProcessLookFrom()
        {
            return View();
        }
        /// <summary>
        /// 流程指派
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProcessDesignate()
        {
            return View();
        }
        #endregion

        #region 获取数据(公用)
        /// <summary>
        /// 工作流列表,流程监控用(分页)
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetProcessPageListJson(Pagination pagination, string queryJson)
        {
            var data = wfProcessBll.GetPageList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
            };
            return Content(JsonData.ToJson());
        }
        /// <summary>
        /// 获取进程模板Json
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetProcessSchemeJson(string keyValue)
        {
            var data = wfProcessBll.GetProcessSchemeEntity(keyValue);
            return Content(data.ToJson());
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除工作流实例进程
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult DeleteProcess(string keyValue)
        {
            wfProcessBll.DeleteProcess(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 改变流程实例状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult OperateProcess(string keyValue,int state)
        {
            wfProcessBll.OperateVirtualProcess(keyValue, state);
            return Success("操作成功。");
        }
        /// <summary>
        /// 指派流程
        /// </summary>
        /// <param name="processId">工作流实例主键Id</param>
        /// <param name="processId">审核数据</param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult DesignateProcess(string processId, string makeLists)
        {
            wfProcessBll.DesignateProcess(processId, makeLists);
            return Success("指派成功。");
        }
        #endregion
    }
}
