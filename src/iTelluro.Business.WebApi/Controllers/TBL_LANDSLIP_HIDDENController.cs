using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using System.Web.Http;
using System.Collections.Generic;
using Infoearth.Util.WebControl;
using Infoearth.Util;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：huangzy
    /// 日 期：2019-01-22 
    /// 描 述：滑坡调查表
    /// </summary>
    public class TBL_LANDSLIP_HIDDENApiController : ApiControllerBase
    {
        private TBL_LANDSLIP_HIDDENBLL TBL_LANDSLIP_HIDDENbll = new TBL_LANDSLIP_HIDDENBLL();

       
        #region 获取数据

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = TBL_LANDSLIP_HIDDENbll.GetPageList(pagination, queryJson);
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
        public IEnumerable<TBL_LANDSLIP_HIDDENEntity> GetListJson(string queryJson)
        {
            var data = TBL_LANDSLIP_HIDDENbll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_LANDSLIP_HIDDENEntity GetFormJson(string keyValue)
        {
            var data = TBL_LANDSLIP_HIDDENbll.GetEntity(keyValue);
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
        public WebApiResult RemoveForm(SingleParam keyValue)
        {
            TBL_LANDSLIP_HIDDENbll.RemoveForm(keyValue.KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, [FromBody]TBL_LANDSLIP_HIDDENEntity entity)
        {
            TBL_LANDSLIP_HIDDENbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
