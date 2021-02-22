using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    public class TBL_QCQF_VILLAGEINFOController : MvcControllerBase
    {
        private TBL_QCQF_VILLAGEINFOBLL tbl_qcqf_villageinfo = new TBL_QCQF_VILLAGEINFOBLL();


        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数
        /// DISTRICTCODE 行政区划代码
        /// </param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        [LogContent("群测群防行政管理体系", OpType.Query)]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_qcqf_villageinfo.GetPageList(pagination, queryJson);
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
        /// <param name="queryJson">查询参数
        /// DISTRICTCODE 行政区划代码
        /// </param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        [LogContent("群测群防行政管理体系", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_qcqf_villageinfo.GetList(queryJson);
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
            var data = tbl_qcqf_villageinfo.GetEntity(keyValue);
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
            tbl_qcqf_villageinfo.DeleteEntity(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">DISTRICTCODE 行政区划码</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("群测群防行政管理体系", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_QCQF_VILLAGEINFOEntity entity)
        {
            tbl_qcqf_villageinfo.SaveEntity(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
