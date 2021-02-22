using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Application.Entity;
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
namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 关于搬迁避让WEBAPI接口
    /// </summary>
    public class TBL_BQBRApiController:ApiControllerBase
    {
        private TBL_BQBRBLL tbl_bqbrbll = new TBL_BQBRBLL();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// pagination分页信息
        /// queryJson包含：
        /// 1、DISASTERNAME-灾害点名称
        /// 2、UNIFIEDCODE-灾害点编号
        /// 3、DISASTERTYPE-灾害类型
        /// 4、ISCOMPLETE-是否完成
        /// 5、ISACCEPTANCE-是否验收
        /// 6、省市县级联查询
        /// 7、BQBRSTARTTIME-查询浏览页面中开始时间
        /// 8、BQBRENDTIME-查询浏览页面中开始时
        /// 9、COMPPARAM综合DISASTERNAME灾害名称和UNIFIEDCODE灾害编号的字段模糊查询
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var pa = queryJson.ToJObject();
            var watch = CommonHelper.TimerStart();
            var data = tbl_bqbrbll.GetPageList(pagination, queryJson);
            if (pa["zhd"] != null)
            {
                if (pa["zhd"].ToString() == "zhd")
                {
                    data = data.GroupBy(r => r.UNIFIEDCODE).Select(r => r.First());
                }
            }
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
        /// pagination分页信息(增加地图框选)
        /// queryJson包含：
        /// 1、DISASTERNAME-灾害点名称
        /// 2、UNIFIEDCODE-灾害点编号
        /// 3、DISASTERTYPE-灾害类型
        /// 4、ISCOMPLETE-是否完成
        /// 5、ISACCEPTANCE-是否验收
        /// 6、省市县级联查询
        /// 7、BQBRSTARTTIME-查询浏览页面中开始时间
        /// 8、BQBRENDTIME-查询浏览页面中开始时
        /// 9、COMPPARAM综合DISASTERNAME灾害名称和UNIFIEDCODE灾害编号的字段模糊查询
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpPost]
        public object PostPageListJson(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];
            var watch = CommonHelper.TimerStart();
            var data = tbl_bqbrbll.GetPageLists(entity.pagination, entity.queryJson, entity.condition);
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
      
        ///BQBR不分页
        ///销号用的查询判断
        ///勿动勿动 
        [HttpGet]
        public object GetListJson([FromUri]string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_bqbrbll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// 获取所有搬迁避让信息
        /// 不带参数直接查询所有搬迁避让信息列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetPageList([FromUri]string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_bqbrbll.GetList(queryJson);
            return data;
        }


        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_BQBREntity GetFormJson(string keyValue)
        {
            var data = tbl_bqbrbll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public TBL_BQBREntity GetFormJsonByUnifycode(string keyValue)
        {
            var data = tbl_bqbrbll.GetEntityByUnifycode(keyValue);
            return data;
        }
        /// <summary>
        /// 统计搬迁避让信息
        /// queryJson包含字段信息：
        /// 1、行政区划信息
        /// 2、Static_Year统计年度
        /// 3、Static_Unit统计单位
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public object BQBRCountStatics([FromUri]string queryJson)
        {
            var obj = queryJson.ToJObject();
            string ProvinceName = obj.GetValue("PROVINCENAME").ToString();
            string CityName = obj.GetValue("CITYNAME").ToString();
            string CountyName = obj.GetValue("COUNTRYNAME").ToString();
            string BQBRYEAR = obj.GetValue("Static_Year").ToString();
            string BQBRUNIT = obj.GetValue("Static_Unit").ToString(); 
            DataTable result = tbl_bqbrbll.BQBRCountStatics(ProvinceName, CityName, CountyName, BQBRYEAR, BQBRUNIT, "");
            return result;

        }


        /// <summary>
        /// 获取地图摘要信息(框选)
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <param name="condition">
        /// WKTString:拐点坐标 POLYGON((119.76735720875 35.15413150875,119.76735720875 36.30549869625))
        /// x:中心点横坐标
        /// y:中心点纵坐标
        /// radius:半径(米)
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public object GetZYListJson(string queryJson, string condition = null)
        {
            var data = tbl_bqbrbll.GetZYList(queryJson, condition);
            return data;

        }

        /// <summary>
        /// 获取地图摘要信息(框选)
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <param name="condition">
        /// WKTString:拐点坐标 POLYGON((119.76735720875 35.15413150875,119.76735720875 36.30549869625))
        /// x:中心点横坐标
        /// y:中心点纵坐标
        /// radius:半径(米)
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public object PostZYListJson(QueryJsonEntity entity)
        {
            var data = tbl_bqbrbll.GetZYList(entity.queryJson, entity.condition);
            var aa = entity.queryJson.ToJObject();
            if (aa["zhd"] != null)
            {
                if (aa["zhd"].ToString() == "zhd")
                {
                    data = data.GroupBy(r => r.UNIFIEDCODE).Select(r => r.First());
                }
            }
            return data;
        }

        #endregion

        #region 数据提交
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult RemoveForm([FromBody]string keyValue)
        {
            tbl_bqbrbll.RemoveForm(keyValue);
            return Success("删除成功。");
        }


        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        public WebApiResult SaveForm(string keyValue, TBL_BQBREntity entity)
        {
            string SuccessGuid=tbl_bqbrbll.SaveForm(keyValue, entity);
            return Success("操作成功。", SuccessGuid);
        }
        #endregion

        #region 地图聚合
        [HttpGet]
        public EchartEntityNEWS GetListCodes()
        {
            var data = tbl_bqbrbll.GetListCodes();
            return data;
        }
        #endregion
        [HttpGet]
        public object GetTJ(string queryJson)
        {
            return tbl_bqbrbll.GetTJ(queryJson);
        }


    }
}
