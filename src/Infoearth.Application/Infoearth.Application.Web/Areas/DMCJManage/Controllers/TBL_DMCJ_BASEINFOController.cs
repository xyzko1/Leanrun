using Infoearth.Application.Entity.DMCJManage;
using Infoearth.Application.Busines.DMCJManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System.Collections.Generic;
using Infoearth.Util.Offices;
using Infoearth.Application.Web.Controllers;
using System.Linq;
using System;

namespace Infoearth.Application.Web.Areas.DMCJManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-22 12:10
    /// 描 述：地面沉降调查表
    /// </summary>
    public class TBL_DMCJ_BASEINFOController : MvcControllerBase
    {
        private TBL_DMCJ_BASEINFOBLL tbl_dmcj_baseinfobll = new TBL_DMCJ_BASEINFOBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_BASEINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_BASEINFOForm()
        {
            return View();
        }
        #endregion



        /// <summary>
        /// 编码生成视图
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
            var data = tbl_dmcj_baseinfobll.GetMaxCode(xzqh);

            return data;
        }
        /// <summary>
        /// 地面沉降点查询（导出Excel）
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="outColumn"></param>
        [HttpGet]
        public void ExcelDownload(string queryJson, string outColumn)
        {
            var list = tbl_dmcj_baseinfobll.GetList(queryJson).ToList();

            string[] columnArr = outColumn.TrimEnd(',').Split(',');//要导出的列

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
            ExcelHelperEx<TBL_DMCJ_BASEINFOEntity>.ExcelDownload(list, excelConfig, true);


        }
    }
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息工程股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-22 12:10
    /// 描 述：地面沉降调查表查询页面
    /// </summary>
    public class TBL_DMCJ_BASESELECTController : MvcControllerBase
    {
        private TBL_DMCJ_BASEINFOBLL tbl_dmcj_baseinfobll = new TBL_DMCJ_BASEINFOBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_BASEINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_BASEINFOForm()
        {
            return View();
        }
        #endregion

       
    }
}
