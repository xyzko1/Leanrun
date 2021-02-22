using Infoearth.Application.Busines.DMCJManage;
using Infoearth.Application.Busines.MONITORPOINT;
using Infoearth.Application.Entity;
using Infoearth.Application.Entity.DMCJManage;
using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Util;
using Infoearth.Util.Offices;
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
    /// 地面沉降点
    /// </summary>
    public class TBL_DMCJ_BASEINFOController : ApiControllerBase
    {
        private TBL_DMCJ_BASEINFOBLL tbl_dmcj_baseinfobll = new TBL_DMCJ_BASEINFOBLL();
        private TBL_DMCJ_BASEINFO_SUBBLL tbl_dmcj_baseinfo_Subbll = new TBL_DMCJ_BASEINFO_SUBBLL();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_BASEINFO/GetPageListJson")]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson, string condition = null)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_dmcj_baseinfobll.GetPageList(pagination, queryJson,condition);
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
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpPost]
        [Route("api/MONITORPOINT/TBL_DMCJ_BASEINFO/PostPageListJson")]
        public object GetPageListJson(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];

            var watch = CommonHelper.TimerStart();
            var data = tbl_dmcj_baseinfobll.GetPageList(entity.pagination, entity.queryJson, entity.condition);
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
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_BASEINFO/GetListJson")]
        public object GetListJson(string queryJson, string condition = null)
        {
            var data = new List<TBL_DMCJ_BASEINFOEntity>();
            if (!string.IsNullOrEmpty(condition))
            {
                data = tbl_dmcj_baseinfobll.GetZYList(queryJson, condition).ToList();
            }
            else
            {
                data = tbl_dmcj_baseinfobll.GetList(queryJson).ToList();
            }
            return data;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpPost]
        [Route("api/MONITORPOINT/TBL_DMCJ_BASEINFO/PostListJson")]
        public object PostListJson(QueryJsonEntity entity)
        {
            var data = new List<TBL_DMCJ_BASEINFOEntity>();
            if (!string.IsNullOrEmpty(entity.condition))
            {
                data = tbl_dmcj_baseinfobll.GetZYList(entity.queryJson, entity.condition).ToList();
            }
            else
            {
                data = tbl_dmcj_baseinfobll.GetList(entity.queryJson).ToList();
            }
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_BASEINFO/GetFormJson")]
        public object GetFormJson(string keyValue)
        {
            var data = tbl_dmcj_baseinfobll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="queryJson">{DMCJBH:"地面沉降编号"}</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_BASEINFO/GetSubList")]
        public object GetSubList(string queryJson)
        {
            var data = tbl_dmcj_baseinfo_Subbll.GetList(queryJson);
            return data;
        }
        /// <summary>
        /// 取所有输入字段的值列表
        /// </summary>
        /// <param name="queryJson">
        /// FIELDNAME:字段名<br/>
        /// TABLENAME:表名
        /// </param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_BASEINFO/GetValueList")]
        public object GetValueList(string queryJson)
        {
            var data = tbl_dmcj_baseinfobll.GetValueList(queryJson);
            return data;
        }

        #endregion
        /// <summary>
        /// 地面沉降点统计(按行政区划)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_BASEINFO/GetStatisticsByDmcj")]
        public object GetStatisticsByDmcj() {
            var data = tbl_dmcj_baseinfobll.GetStatisticsByDmcj();
            return data;
        }
        /// <summary>
        /// 地面沉降监测点统计(按监测点等级)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_BASEINFO/GetStatisticsByDmcjPie")]
        public object GetStatisticsByDmcjPie()
        {
            var result = tbl_dmcj_baseinfobll.GetStatisticsByDmcjPie();
            List<string> columns = new List<string>();
            foreach (DataColumn item in result.Columns)
            {
                columns.Add(item.ColumnName);
            }
            string json = DataHelperEx.DataTableToJson(result);
            var jsonData = new
            {
                seriesData = json,
                legendData = columns
            };
            return jsonData;
        }
        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/MONITORPOINT/TBL_DMCJ_BASEINFO/RemoveForm")]
        public object RemoveForm(string keyValue)
        {
            tbl_dmcj_baseinfobll.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/MONITORPOINT/TBL_DMCJ_BASEINFO/SaveForm")]
        public object SaveForm(string keyValue, MasterDetailEntity entity)
        {
            //var DATA = entity.strEntity.ToObject<TBL_DMCJ_BASEINFOEntity>();
            //var childEntitys = entity.strChildEntitys.ToList<TBL_DMCJ_BASEINFO_SUBEntity>();
            tbl_dmcj_baseinfobll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion 

        #region 导出excel
        /// <summary>
        /// 地面沉降点查询（导出Excel）
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="outColumn"></param>
        [HttpPost]
        public object ExcelDownload_POST(PostExcelEntity entity)
        {
            List<TBL_DMCJ_BASEINFOEntity> list = new List<TBL_DMCJ_BASEINFOEntity>();
            if (!string.IsNullOrEmpty(entity.condition))
            {
                list = tbl_dmcj_baseinfobll.GetZYList(entity.queryJson, entity.condition).ToList();
            }
            else
            {
                list = tbl_dmcj_baseinfobll.GetList(entity.queryJson).ToList();
            }
            string[] columnArr = entity.outColumn.TrimEnd(',').Split(',');//要导出的列

            List<ColumnEntity> ColumnList = new List<ColumnEntity>();
            IDictionary<string, string> dicArr = UtilityController.GetAllPropertyDic<TBL_DMCJ_BASEINFOEntity>();//获取字典字段
            //显示列
            foreach (var item in dicArr.Keys)
            {
                if (columnArr.Contains(item))
                {
                    ColumnList.Add(new ColumnEntity { Column = item, ExcelColumn = dicArr[item], Width = 30 });
                }
            }
            UtilityController.ConvertDicValue(list);//字典项赋值
            ExcelConfig excelConfig = new ExcelConfig();
            excelConfig.IsAllSizeColumn = true;
            excelConfig.ColumnEntity = ColumnList;
            excelConfig.FileName = "地面沉降点查询-" + DateTime.Now.ToString("yyyy.MM.dd") + ".xls";
            excelConfig.Title = "地面沉降点查询";

            string fileNameGuid = System.IO.Path.GetFileName( ExcelHelperEx<TBL_DMCJ_BASEINFOEntity>.ExcelCreate(list, excelConfig, true));
            var returnValue = new
            {
                fileNameGuid = fileNameGuid,
                DownFileName = excelConfig.FileName
            };
            return returnValue;
        }
        #endregion
    }

}
