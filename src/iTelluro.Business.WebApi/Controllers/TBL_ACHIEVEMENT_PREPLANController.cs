using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Infoearth.Application.Entity;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 关于治理工程WEBAPI接口
    /// 2018-05-30 
    /// niming
    /// </summary>
    public class TBL_ACHIEVEMENT_PREPLANController : ApiControllerBase
    {

            private TBL_ACHIEVEMENT_PREPLANBLL tbl_achievement_preplanbll = new TBL_ACHIEVEMENT_PREPLANBLL();//防治规划成果表业务层

            #region 获取数据
            /// <summary>
            /// 分页获取对应防治规划成果列表信息
            /// </summary>
            /// <param name="pagination"></param>
            /// <param name="queryJson"></param>
            /// <returns></returns>
            [HttpGet]
            public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
            {
                var watch = CommonHelper.TimerStart();
                var data = tbl_achievement_preplanbll.GetPageList(pagination, queryJson);
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
        /// 分页获取对应防治规划成果列表信息(加载框选)
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpPost]
        public object PostPageListJson(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];
            var watch = CommonHelper.TimerStart();
            var data = tbl_achievement_preplanbll.GetPageLists(entity.pagination, entity.queryJson, entity.condition);
            int count = entity.pagination.records;
            var total = count % entity.pagination.rows == 0 ? count / entity.pagination.rows : count / entity.pagination.rows + 1;
            var jsonData = new
            {
                rows = data,
                total = total,
                page = entity.pagination.page,
                records = entity.pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return jsonData;
        }
        /// <summary>
        /// 获取地图摘要信息
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <param name="condition">可选参数(可以不传)
        /// WKTString:拐点坐标 POLYGON((119.76735720875 35.15413150875,119.76735720875 36.30549869625))
        /// x:中心点横坐标
        /// y:中心点纵坐标
        /// radius:半径(米)
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public object PostZYListJson(QueryJsonEntity entity)
        {
            var data = tbl_achievement_preplanbll.GetZYPageList(entity.queryJson, entity.condition);
            return data;
        }
        /// <summary>
        /// 根据主键获取实体信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
            public object GetFormJson([FromUri]string keyValue)
            {
                var data = tbl_achievement_preplanbll.GetEntity(keyValue);
                return data;
            }


            /// <summary>
            /// 对防治规划成果统计中条件
            /// PROVINCENAME 省名称
            /// CITYNAME     市名称
            /// COUNTRYNAME  县名称
            /// Static_Year  统计年份-----暂用WRITETIME字段（方案编写时间）
            /// ZLGCUNIT     统计单位
            /// </summary>
            /// <param name="queryJson"></param>
            /// <returns></returns>
            [HttpGet]
            public object PREPLANCountStatics([FromUri]string queryJson)
            {
                var obj = queryJson.ToJObject();
                string ProvinceName = obj.GetValue("PROVINCENAME").ToString();
                string CityName = obj.GetValue("CITYNAME").ToString();
                string CountyName = obj.GetValue("COUNTRYNAME").ToString();
                string PREPLANYEAR = obj.GetValue("Static_Year").ToString();
                string PREPLANUNIT = obj.GetValue("Static_Unit").ToString();
                DataTable result = tbl_achievement_preplanbll.PREPLANCountStatics(ProvinceName, CityName, CountyName, PREPLANYEAR, PREPLANUNIT, "");
                return result;

            }

            #endregion

            #region 提交数据
            /// <summary>
            /// 防治规划成果管理删除数据
            /// </summary>
            /// <param name="keyValue">主键值</param>
            /// <returns></returns>
            [HttpPost]
            public WebApiResult RemoveForm([FromBody]string keyValue)
            {
                tbl_achievement_preplanbll.RemoveForm(keyValue);
                return Success("删除成功。");
            }

            /// <summary>
            /// 防治规划成果管理保存数据
            /// </summary>
            /// <param name="keyValue"></param>
            /// <param name="entity"></param>
            /// <returns></returns>
            [HttpPost]
            public WebApiResult SaveForm(string keyValue, TBL_ACHIEVEMENT_PREPLANEntity entity)
            {
                tbl_achievement_preplanbll.SaveForm(keyValue, entity);
                return Success("操作成功。");
            }

            #endregion


    }
}
