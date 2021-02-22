using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using System.Web.Http;
using System.Collections.Generic;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 11:37
    /// 描 述：地面塌陷调查表历史表
    /// </summary>
    public class TBL_COLLAPSE_HISTORYApiController : ApiControllerBase
    {
        private TBL_COLLAPSE_HISTORYBLL tbl_collapse_historybll = new TBL_COLLAPSE_HISTORYBLL();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public IEnumerable<TBL_COLLAPSE_HISTORYEntity> GetListJson(string queryJson)
        {
            var data = tbl_collapse_historybll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_COLLAPSE_HISTORYEntity GetFormJson(string keyValue)
        {
            var data = tbl_collapse_historybll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">UNIFIEDCODE</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_COLLAPSE_HISTORYEntity GetEntityByUNIFIEDCODE(string keyValue)
        {
            var data = tbl_collapse_historybll.GetEntityByUNIFIEDCODE(keyValue);
            return data;
        }
        /// <summary>
        /// 获取当前实体前最近审核通过的实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpGet]
        public TBL_COLLAPSE_HISTORYEntity GetAuditFormJson(string keyValue)
        {
            return tbl_collapse_historybll.GetAuditEntity(keyValue);
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
            tbl_collapse_historybll.RemoveForm(keyValue.KeyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_COLLAPSE_HISTORYEntity entity)
        {
            tbl_collapse_historybll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
