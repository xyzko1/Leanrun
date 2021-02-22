using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System.Data;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-04-16 23:15
    /// 描 述：群测群防行政管理体系
    /// </summary>
    public class TBL_QCQF_ADMINISTRATIVEController : MvcControllerBase
    {
        private TBL_QCQF_ADMINISTRATIVEBLL tbl_qcqf_administrativebll = new TBL_QCQF_ADMINISTRATIVEBLL();

        #region 视图功能
        /// <summary>
        /// 群测群防统计分析
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_QCQF_TJFX()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_QCQF_ADMINISTRATIVE_XZZRTXFrom()
        {
            return View();
        }
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_QCQF_ADMINISTRATIVE_XZZRTX()
        {
            return View();
        }
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [Login]
        public ActionResult TBL_YJBZ_POSITIONSelect()
        {
            return View();
        }
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_QCQF_ADMINISTRATIVEIndex()
        {
            return View();
        }
        [HttpGet]
        [Login]
        public ActionResult TBL_QCQF_ADMINISTRATIVEView()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_ADMINISTRATIVEForm()
        {
            return View();
        }
        /// <summary>
        /// 短信发送联系人页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_LXRFrom()
        {
            return View();
        }
        /// <summary>
        /// 临时联系人页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_INSERT_LSLXRFrom()
        {
            return View();
        }
        /// <summary>
        /// 责任人信息页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_ZRRINFOFrom()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TBL_QCQF_ADMINISTRATIVESearch()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult TBL_QCQF_ADMINISTRATIVEViewForm()
        {
            return View();
        }
        /// <summary>
        /// 群测群防查询浏览
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_ADMINISTRATIVEQueryBrowse()
        {
            return View();
        }
        /// <summary>
        /// 群测群防查询浏览
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_ResponsIndex()
        {
            return View();
        }
        /// <summary>
        /// 群测群防统计分析
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_ADMINISTRATIVETJFX()
        {
            return View();
        }
        /// <summary>
        /// 根据DISTRICTCODE获取实体
        /// </summary>
        /// <param name="DISTRICTCODE">主键值</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDISTRICTCODEEntity(string DISTRICTCODE)
        {
            var data = tbl_qcqf_administrativebll.GetDISTRICTCODEEntity(DISTRICTCODE);
            return ToJsonResult(data);
        }
        [HttpGet]
        public ActionResult GetTBL_QCQF_ADMINISTRATIVEEntity(string DISTRICTCODE)
        {
            var data = tbl_qcqf_administrativebll.GetTBL_QCQF_ADMINISTRATIVEEntity(DISTRICTCODE);
            return ToJsonResult(data);
        }
        
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        [LogContent("群测群防行政管理体系", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_qcqf_administrativebll.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        [LogContent("群测群防行政管理体系", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_qcqf_administrativebll.GetList(queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = tbl_qcqf_administrativebll.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("群测群防行政管理体系", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_qcqf_administrativebll.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("群测群防行政管理体系", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_QCQF_ADMINISTRATIVEEntity entity)
        {
            tbl_qcqf_administrativebll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        /// <summary>
        /// 根据DISTRICTCODE保存表单（新增、修改）
        /// </summary>
        /// <param name="DISTRICTCODE"></param>
        /// <param name="entity"></param>
        [HttpPost]
        [AjaxOnly]
        [LogContent("群测群防行政管理体系", OpType.Update)]
        public ActionResult UpdateForm(string DISTRICTCODE, TBL_QCQF_ADMINISTRATIVEEntity entity)
        {
            tbl_qcqf_administrativebll.UpdateForm(DISTRICTCODE, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
