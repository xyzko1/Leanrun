using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Application.Busines.MONITORPOINT;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using iTelluro.Busness.WebApiProxy;
using System.Linq;
using Infoearth.Application.Entity;
using Infoearth.Util.Offices;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 地面沉降监测点信息表
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTController : ApiControllerBase
    {
        private TBL_DMCJ_MONITORPOINTBLL tbl_dmcj_monitorpointbll = new TBL_DMCJ_MONITORPOINTBLL();
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/GetPageListJson")]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson, string condition = null)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_dmcj_monitorpointbll.GetPageList(pagination, queryJson, condition);
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
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/PostPageListJson")]
        public object PostPageListJson(QueryJsonEntity entity)
        {
            entity.pagination = new Pagination();
            entity.pagination.page = int.Parse(System.Web.HttpContext.Current.Request.Form["page"]);
            entity.pagination.rows = int.Parse(System.Web.HttpContext.Current.Request.Form["rows"]);
            entity.pagination.sidx = System.Web.HttpContext.Current.Request.Form["sidx"];
            entity.pagination.sord = System.Web.HttpContext.Current.Request.Form["sord"];

            var watch = CommonHelper.TimerStart();
            var data = tbl_dmcj_monitorpointbll.GetPageList(entity.pagination, entity.queryJson, entity.condition);
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
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/GetListJson")]
        public object GetListJson(string queryJson, string condition = null)
        {
            var data = new List<TBL_DMCJ_MONITORPOINTEntity>();
            if (!string.IsNullOrEmpty(condition))
            {
                data = tbl_dmcj_monitorpointbll.GetZYList(queryJson, condition).ToList();
            }
            else
            {
                data = tbl_dmcj_monitorpointbll.GetList(queryJson).ToList();
            }
            return data;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpPost]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/PostListJson")]
        public object PostListJson(QueryJsonEntity entity)
        {
            var data = new List<TBL_DMCJ_MONITORPOINTEntity>();
            if (!string.IsNullOrEmpty(entity.condition))
            {
                data = tbl_dmcj_monitorpointbll.GetZYList(entity.queryJson, entity.condition).ToList();
            }
            else
            {
                data = tbl_dmcj_monitorpointbll.GetList(entity.queryJson).ToList();
            }
            return data;
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/GetFormJson")]
        public object GetFormJson(string keyValue)
        {
            var data = tbl_dmcj_monitorpointbll.GetEntity(keyValue);
            return data;
        }
        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/GetUserInfo")]
        public List<string> GetUserInfo()
        {
            //数据范围权限过滤
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            return _codes;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/RemoveForm")]
        public object RemoveForm(string keyValue)
        {
            tbl_dmcj_monitorpointbll.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/MONITORPOINT/TBL_DMCJ_MONITORPOINT/SaveForm")]
        public object SaveForm(string keyValue, TBL_DMCJ_MONITORPOINTEntity entity)
        {
            tbl_dmcj_monitorpointbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion

        #region 导出excel

        /// <summary>
        /// 监测点查询(导出Excel)
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="outColumn"></param>
        [HttpPost]
        public object ExcelDownload_POST(PostExcelEntity entity)
        {
            var list = new List<TBL_DMCJ_MONITORPOINTEntity>();
            if (!string.IsNullOrEmpty(entity.condition))
            {
                list = tbl_dmcj_monitorpointbll.GetZYList(entity.queryJson, entity.condition).ToList();
            }
            else
            {
                list = tbl_dmcj_monitorpointbll.GetList(entity.queryJson).ToList();
            }

            string[] columnArr = entity.outColumn.TrimEnd(',').Split(',');//要导出的列

            List<ColumnEntity> ColumnList = new List<ColumnEntity>();
            IDictionary<string, string> dicArr = UtilityController.GetAllPropertyDic<TBL_DMCJ_MONITORPOINTEntity>();//获取字典字段
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
            excelConfig.FileName = "监测点查询-" + DateTime.Now.ToString("yyyy.MM.dd") + ".xls";
            excelConfig.Title = "监测点查询";
            
            string fileNameGuid = System.IO.Path.GetFileName(ExcelHelperEx<TBL_DMCJ_MONITORPOINTEntity>.ExcelCreate(list, excelConfig, true));
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
