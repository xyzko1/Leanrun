using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Application.Busines.MONITORPOINT;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using Infoearth.Util.Offices;
using System.Linq;
using Infoearth.Application.Web.Controllers;

namespace Infoearth.Application.Web.Areas.MONITORPOINT.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-22 18:23
    /// 描 述：地面沉降监测点信息表
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTController : MvcControllerBase
    {
        private TBL_DMCJ_MONITORPOINTBLL tbl_dmcj_monitorpointbll = new TBL_DMCJ_MONITORPOINTBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_MONITORPOINTIndex()
        {
            return View();
        }
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_MONITORIndex()
        {
            return View();
        }
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_Select()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_MONITORPOINTForm()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_MONITORForm()
        {
            return View();
        }
        /// <summary>
        /// 编码生成
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateCodeWaterIndex()
        {
            return View();
        }
        /// <summary>
        /// 监测点后四位编号生成
        /// </summary>
        /// <param name="xzqh"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetMaxCode(string xzqh)
        {
            var data = tbl_dmcj_monitorpointbll.GetMaxCode(xzqh);

            return data;
        }
        /// <summary>
        /// 监测数据填报
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_MONITORPOINTJCSJForm()
        {
            return View();
        }
        #endregion



        /// <summary>
        /// 监测点查询(导出Excel)
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="outColumn"></param>
        [HttpGet]
        public void ExcelDownload(string queryJson, string outColumn)
        {
            var list = tbl_dmcj_monitorpointbll.GetList(queryJson).ToList();

            string[] columnArr = outColumn.TrimEnd(',').Split(',');//要导出的列

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
            ExcelHelperEx<TBL_DMCJ_MONITORPOINTEntity>.ExcelDownload(list, excelConfig, true);


        }


    }
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-22 18:23
    /// 描 述：地面沉降监测点信息查询
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTSELECTController : MvcControllerBase
    {
        private TBL_DMCJ_MONITORPOINTBLL tbl_dmcj_monitorpointbll = new TBL_DMCJ_MONITORPOINTBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_MONITORPOINTIndex()
        {
            return View();
        }
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_MONITORIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_MONITORPOINTForm()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_MONITORForm()
        {
            return View();
        }
        #endregion


    }

   
}
