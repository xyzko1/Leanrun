using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Code;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 
    /// 创 建：陈小二
    /// 日 期：2016-12-04 09:39
    /// 描 述：excel导入配置
    /// </summary>
    public class ExcelImportTemplateController : MvcControllerBase
    {
        private System_SetExcelImprotBLL templatebll = new System_SetExcelImprotBLL();
        private System_SetExcelImportFiledBLL filedBll = new System_SetExcelImportFiledBLL();
        #region 视图功能
        /// <summary>
        /// 管理界面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
      
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// 设置字段表单
        /// </summary>
        /// <returns></returns>
        public ActionResult SetFieldForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 导入模板列表（分页）
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = templatebll.GetPageList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.ToJson());
        }
        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public ActionResult GetListJson(string queryJson)
        {
            var data = templatebll.GetList(queryJson);
            return Content(data.ToJson());
        }
        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ActionResult GetFormJson(string keyValue)
        {
            var templateInfo = templatebll.GetEntity(keyValue);
            var filedsInfo = filedBll.GetList("{\"F_ImportTemplateId\":\"" + templateInfo.F_Id + "\"}");
            var jsonData = new {
                templateInfo = templateInfo,
                filedsInfo = filedsInfo
            };
            return Content(jsonData.ToJson());
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="templateInfo">模板数据</param>
        /// <param name="filedsInfo">字段数据</param>
        /// <returns></returns>
        public ActionResult SaveForm(string keyValue, string templateInfo, string filedsInfo)
        {
            System_SetExcelImprotEntity templateInfoEntity = templateInfo.ToObject<System_SetExcelImprotEntity>();
            List<System_SetExcelImportFiledEntity> filedsInfoEntity = filedsInfo.ToObject<List<System_SetExcelImportFiledEntity>>();
            templatebll.SaveEntity(keyValue, templateInfoEntity, filedsInfoEntity);
            return Success("保存成功");
        }
        /// <summary>
        /// 删除表单数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ActionResult RemoveForm(string keyValue)
        {
            templatebll.DeleteEntity(keyValue);
            return Success("删除成功");
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">模板实例数据</param>
        /// <returns></returns>
        public ActionResult UpdateForm(string keyValue, System_SetExcelImprotEntity entity)
        {
            System_SetExcelImprotEntity entity1 = templatebll.GetEntity(keyValue);
            entity1.F_EnabledMark = entity.F_EnabledMark;
            templatebll.UpdateForm(keyValue, entity1);
            return Success("操作成功");
        }
        #endregion
    }
}