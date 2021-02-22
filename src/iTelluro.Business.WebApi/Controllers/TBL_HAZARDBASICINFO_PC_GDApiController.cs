using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using System.Web.Http;
using System.Collections.Generic;
using Infoearth.Util.WebControl;
using Infoearth.Util;
using System.Linq;
using System;
using System.Collections;
using System.Reflection;
using System.Data;
using Infoearth.Util.Offices;

namespace iTelluro.Busness.WebApi.Controllers
{
    public class TBL_HAZARDBASICINFO_PC_GDApiController : ApiControllerBase
    {
        private TBL_HAZARDBASICINFO_PC_GDBLL tbl_hazardbasicinfo_pc_gdbll = new TBL_HAZARDBASICINFO_PC_GDBLL();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">
        /// DISASTERTYPE 灾害点类型<br/>
        /// UNIFIEDCODE 灾害点编号<br/>  
        /// </param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public object GetPageListJson([FromUri]Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = tbl_hazardbasicinfo_pc_gdbll.GetPageList(pagination, queryJson);
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
            IEnumerable<TBL_HAZARDBASICINFO_PC_GDEntity> data = null;
            if (string.IsNullOrEmpty(condition) || condition == "{}")
            {
                data = tbl_hazardbasicinfo_pc_gdbll.GetSinglePastPageListJson(pagination, queryJson, condition);
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
                data = tbl_hazardbasicinfo_pc_gdbll.GetHXMapList(queryJson, condition);
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
        public IEnumerable<TBL_HAZARDBASICINFO_PC_GDEntity> GetHXMapList(string queryJson, string condition)
        {
            return tbl_hazardbasicinfo_pc_gdbll.GetHXMapList(queryJson, condition);
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
            var data = tbl_hazardbasicinfo_pc_gdbll.GetList(queryJson);
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
            var data = tbl_hazardbasicinfo_pc_gdbll.GetEntity(keyValue);
            return data;
        }
        #endregion
        #region 导出excel
        [HttpGet]
        public void  Exportexcel(string queryJson)
        {
            List<TBL_HAZARDBASICINFO_PC_GDEntity> list = tbl_hazardbasicinfo_pc_gdbll.GetList(queryJson).ToList();
            DataTable dt = DataHelper.ListToDataTable<TBL_HAZARDBASICINFO_PC_GDEntity>(list);
            DataTable data = new DataTable();
            #region 增加表头
            data.Columns.Add("灾害体类型");
            data.Columns.Add("排查编号");
            data.Columns.Add("统一编号");
            data.Columns.Add("市");
            data.Columns.Add("县");
            data.Columns.Add("街道");
            data.Columns.Add("行政区划编号");
            data.Columns.Add("隐患点位置");
            data.Columns.Add("隐患点状态");
            data.Columns.Add("经度");
            data.Columns.Add("纬度");
            data.Columns.Add("灾害体规模");
            data.Columns.Add("稳定性");
            data.Columns.Add("危害性");
            data.Columns.Add("威胁人员");
            data.Columns.Add("潜在经济损失(万元)");
            data.Columns.Add("监测责任人");
            data.Columns.Add("联系电话");
            data.Columns.Add("手机");
            data.Columns.Add("监测人");
            data.Columns.Add("联系电话1");
            data.Columns.Add("手机1");
            data.Columns.Add("防治对策");
            data.Columns.Add("有没应急预案");
            data.Columns.Add("工作措施");
            data.Columns.Add("备注");          
            #endregion

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow result = data.NewRow();              
                result["灾害体类型"] = dt.Rows[i]["DISASTERTYPE"].ToString();
                result["排查编号"] = dt.Rows[i]["PCUNIFIEDCODE"].ToString();
                result["统一编号"] = dt.Rows[i]["UNIFIEDCODE"].ToString();
                result["市"] = dt.Rows[i]["CITY"].ToString();
                result["县"] = dt.Rows[i]["COUNTY"].ToString();
                result["街道"] = dt.Rows[i]["STREET"].ToString();
                result["行政区划编号"] = dt.Rows[i]["XZQHCODE"].ToString();
                result["隐患点位置"] = dt.Rows[i]["LOCATION"].ToString();
                result["隐患点状态"] = dt.Rows[i]["YHSTATE"].ToString();
                result["经度"] = dt.Rows[i]["LONGITUDE"].ToString();
                result["纬度"] = dt.Rows[i]["LATITUDE"].ToString();
                result["灾害体规模"] = dt.Rows[i]["SCALE"].ToString();
                result["稳定性"] = dt.Rows[i]["CURSTABLESTATUS"].ToString();
                result["危害性"] = dt.Rows[i]["DESTROYEDOBJECT"].ToString();
                result["威胁人员"] = dt.Rows[i]["THREATENPEOPLE"].ToString();
                result["潜在经济损失(万元)"] = dt.Rows[i]["INDIRECTLOSS"].ToString();
                result["监测责任人"] = dt.Rows[i]["MONITORINGPEOPLE"].ToString();
                result["联系电话"] = dt.Rows[i]["TELEPHONE"].ToString();
                result["手机"] = dt.Rows[i]["PHONE"].ToString();
                result["监测人"] = dt.Rows[i]["JCPEOPLE"].ToString();
                result["联系电话1"] = dt.Rows[i]["TELEPHONE1"].ToString();
                result["手机1"] = dt.Rows[i]["PHONE1"].ToString();
                result["防治对策"] = dt.Rows[i]["COUNTERMEASURES"].ToString();
                result["有没应急预案"] = dt.Rows[i]["YJPLAN"].ToString();
                result["工作措施"] = dt.Rows[i]["WORKMEASURES"].ToString();
                result["备注"] = dt.Rows[i]["REMARKS"].ToString();
                data.Rows.Add(result);
            }
            ExcelHelper.ExcelDownloadOnlyDT(data, "排查数据导出", "排查数据导出.xls");           
        }

        #endregion
        #region 统计
        [HttpGet]
        public DataTable GetAnalyseList(string queryJson)
        {
            return tbl_hazardbasicinfo_pc_gdbll.GetAnalyseList(queryJson);
        }
        /// <summary>
        /// 地图上加载柱状图
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetZHDCountResult(string queryJson)
        {
            return tbl_hazardbasicinfo_pc_gdbll.GetZHDCountResult(queryJson);
        }
        #endregion
    }
}
