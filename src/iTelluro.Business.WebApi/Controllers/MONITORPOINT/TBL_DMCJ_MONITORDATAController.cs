using Infoearth.Application.Busines.MONITORPOINT;
using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace iTelluro.Busness.WebApi.Controllers.MONITORPOINT
{
    /// <summary>
    /// 地面沉降监测数据
    /// </summary>
    public class TBL_DMCJ_MONITORDATAController : ApiControllerBase
    {
        private TBL_DMCJ_MONITORDATABLL tbl_dmcj_monitorpointbll = new TBL_DMCJ_MONITORDATABLL();

        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORDATA/SaveForm")]
        public object SaveForm(string keyValue, TBL_DMCJ_MONITORDATAEntity entity)
        {
            tbl_dmcj_monitorpointbll.SaveEntity(keyValue, entity);
            return Success("操作成功。");
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="queryJson">{STARTYEAR:'2015',ENDYEAR:'2018',COUNTY:'370101,370201',CITY:'370100,370200',PROVINCE:'370000'}<</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORDATA/GetQueryList")]
        public object GetQueryList(string queryJson)
        {
            try
            {
                string guid = string.Empty;
                List<string> columns = new List<string>();
                string json = string.Empty;
                DataTable result = tbl_dmcj_monitorpointbll.GetQueryList(queryJson);
                foreach (DataColumn item in result.Columns)
                {
                    columns.Add(item.ColumnName);
                }
                var jsonData = new
                {
                    Columns = columns,
                    Data = result
                };
                return ToJsonResult(jsonData);
            }
            catch (Exception ex)
            {
                return ToJsonResult(ex.Message);
            }

        }
        /// <summary>
        /// 根据监测点统计数据
        /// </summary>
        /// <param name="queryJson">{STARTYEAR:'2015',ENDYEAR:'2018',
        /// MONITORPOINTIDS:'3701020001,3701020003'}</param>
        /// <returns></returns>
         [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORDATA/GetQueryListByMonitorPoint")]
        public object GetQueryListByMonitorPoint(string queryJson)
        {
            try
            {
                string guid = string.Empty;
                List<string> columns = new List<string>();
                string json = string.Empty;
                DataTable result = tbl_dmcj_monitorpointbll.GetQueryListByMonitorPoint(queryJson);
                foreach (DataColumn item in result.Columns)
                {
                    columns.Add(item.ColumnName);
                }
                var jsonData = new
                {
                    Columns = columns,
                    Data = result
                };
                return ToJsonResult(jsonData);
            }
            catch (Exception ex)
            {
                return ToJsonResult(ex.Message);
            }

        }

         /// <summary>
         /// 获取列表
         /// </summary>
         /// <param name="pagination">分页参数</param>
         /// <param name="queryJson">查询参数</param>
         /// <returns>返回分页列表Json</returns>
         [HttpGet]
         [Route("api/MONITORPOINT/TBL_DMCJ_MONITORDATA/GetPageListJson")]
         public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
         {
             var watch = CommonHelper.TimerStart();
             var data = tbl_dmcj_monitorpointbll.GetPageList(pagination, queryJson);
             int count = pagination.records;
             var total = count % pagination.rows == 0 ? count / pagination.rows : count / pagination.rows + 1;
             var jsonData = new
             {
                 rows = data,
                 total = total,
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
         [Route("api/MONITORPOINT/TBL_DMCJ_MONITORDATA/GetListJson")]
         public object GetListJson(string queryJson)
         {
             var data = tbl_dmcj_monitorpointbll.GetList(queryJson).ToList();
             return data;
         }
    }
}
