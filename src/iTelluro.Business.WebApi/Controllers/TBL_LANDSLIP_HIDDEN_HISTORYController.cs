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
    /// 创 建：超级管理员
    /// 日 期：2018-03-13 13:14
    /// 描 述：滑坡调查表
    /// </summary>
    public class TBL_LANDSLIP_HIDDEN_HISTORYApiController : ApiControllerBase
    {
        private TBL_LANDSLIP_HIDDEN_HISTORYBLL TBL_LANDSLIP_HIDDEN_HISTORYbll = new TBL_LANDSLIP_HIDDEN_HISTORYBLL();

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = TBL_LANDSLIP_HIDDEN_HISTORYbll.GetPageList(pagination, queryJson);
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

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public IEnumerable<TBL_LANDSLIP_HIDDEN_HISTORYEntity> GetListJson(string queryJson)
        {
            var data = TBL_LANDSLIP_HIDDEN_HISTORYbll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetFormJson(string keyValue)
        {
            var data = TBL_LANDSLIP_HIDDEN_HISTORYbll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">UNIFIEDCODE</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetEntityByUNIFIEDCODE(string keyValue)
        {
            var data = TBL_LANDSLIP_HIDDEN_HISTORYbll.GetEntityByUNIFIEDCODE(keyValue);
            return data;
        }
        /// <summary>
        /// 获取当前实体前最近审核通过的实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpGet]
        public TBL_LANDSLIP_HIDDEN_HISTORYEntity GetAuditFormJson(string keyValue)
        {
            return TBL_LANDSLIP_HIDDEN_HISTORYbll.GetAuditEntity(keyValue);
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
            TBL_LANDSLIP_HIDDEN_HISTORYbll.DeleteEntity(keyValue.KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_LANDSLIP_HIDDEN_HISTORYEntity entity)
        {
            TBL_LANDSLIP_HIDDEN_HISTORYbll.SaveEntity(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
