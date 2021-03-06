using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Http;
using iTelluro.Busness.WebApi;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-11 15:39
    /// 描 述：群测群防监测点和观测人关联表
    /// </summary>
    public class TBL_QCQF_POINTOBSERVATIONApiController : ApiControllerBase
    {
        private TBL_QCQF_POINTOBSERVATIONBLL tbl_qcqf_pointobservationbll = new TBL_QCQF_POINTOBSERVATIONBLL();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_qcqf_pointobservationbll.GetPageList(pagination, queryJson);
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
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public object GetListJson(string queryJson)
        {
            var data = tbl_qcqf_pointobservationbll.GetList(queryJson);
            return data;
        }
        [HttpGet]
        public object GetListByID(string ID)
        {
            var data = tbl_qcqf_pointobservationbll.GetListByID(ID);
            return data;
        }
        [HttpGet]
        public object GetListByUNIFIEDCODE(string UNIFIEDCODE)
        {
            var data = tbl_qcqf_pointobservationbll.GetListByUNIFIEDCODE(UNIFIEDCODE);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_QCQF_POINTOBSERVATIONEntity GetFormJson(string keyValue)
        {
            var data = tbl_qcqf_pointobservationbll.GetEntity(keyValue);
            return data;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm(SingleParam param)
        {
            tbl_qcqf_pointobservationbll.RemoveForm(param.KeyValue);
            return Success("删除成功。");
        }
        public WebApiResult RemoveFormByID(SingleParam param)
        {
            tbl_qcqf_pointobservationbll.RemoveFormByID(param.KeyValue);
            return Success("删除成功。");
        }
        public WebApiResult RemoveFormByUNIFIEDCODE(SingleParam param)
        {
            tbl_qcqf_pointobservationbll.RemoveFormByUNIFIEDCODE(param.KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromUri]TBL_QCQF_POINTOBSERVATIONEntity entity)
        {
            tbl_qcqf_pointobservationbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
       
    }
}
