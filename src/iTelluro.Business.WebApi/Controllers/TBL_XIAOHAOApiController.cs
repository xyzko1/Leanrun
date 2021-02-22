using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApi;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 销号表
    /// </summary>
    public class TBL_XIAOHAOApiController : ApiControllerBase
    {
        private TBL_XIAOHAOBLL tbl_xiaohaobll = new TBL_XIAOHAOBLL();


        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">
        /// DISASTERNAME 灾害点名称<br/>
        /// DISASTERTYPE 灾害点类型<br/>
        /// UNIFIEDCODE 灾害点编号<br/>
        /// OUTDOORCODE 野外编号<br/>
        /// STARTTIME 开始时间<br/>
        /// ENDTIME 结束时间
        /// </param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_xiaohaobll.GetPageList(pagination, queryJson);
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
        /// 带空间查询
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetSinglePastPageListJson([FromUri]Pagination pagination, string queryJson, string condition)
        {
            var watch = CommonHelper.TimerStart();
            IEnumerable<TBL_XIAOHAOEntity> data = null;
            if (string.IsNullOrEmpty(condition) || condition == "{}")
            {
                data = tbl_xiaohaobll.GetSinglePastPageListJson(pagination, queryJson, condition);
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
            else
            {
                data = tbl_xiaohaobll.GetHXMapList(queryJson, condition);
                pagination.records = data.Count();
                return data.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows);
            }          
        }

        /// <summary>
        /// 地图查询
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TBL_XIAOHAOEntity> GetHXMapList(string queryJson, string condition)
        {
            return tbl_xiaohaobll.GetHXMapList(queryJson, condition);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">
        /// DISASTERNAME 灾害点名称<br/>
        /// DISASTERTYPE 灾害点类型<br/>
        /// UNIFIEDCODE 灾害点编号<br/>
        /// OUTDOORCODE 野外编号<br/>
        /// STARTTIME 开始时间<br/>
        /// ENDTIME 结束时间
        /// </param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public object GetListJson(string queryJson)
        {
            var data = tbl_xiaohaobll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public object GetFormJson(string keyValue)
        {
            var data = tbl_xiaohaobll.GetEntity(keyValue);
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
        public object RemoveForm(string keyValue)
        {
            tbl_xiaohaobll.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <param name="projectid">项目id</param>
        /// <returns></returns>
        [HttpPost]
        public object SaveForm(string keyValue, TBL_XIAOHAOEntity entity)
        {
            int statusCode = 0;
            entity.XZQHCODE = entity.UNIFIEDCODE.Substring(0, 6);
            tbl_xiaohaobll.SaveForm(keyValue, entity, ref statusCode);
            if (statusCode == 0)
            {
                return Error("至少选择一种销号原因，才能销号！");
            }
            else if (statusCode == 99)
            {
                return Error("不存在搬迁避让或治理工程信息，不能销号！");
            }
            return Success("销号成功。");
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        public object DeleteHidden(string keyValue)
        {
            tbl_xiaohaobll.DeleteHidden(keyValue);
            return Success("删除成功。");
        }

        #endregion
    }
}
