using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System;
using System.Data;
using System.IO;
using System.Web;
using System;
using System.Collections.Generic;
using Infoearth.Application.Busines;
using System.Linq;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-10 09:57
    /// 描 述：TBL_DZHJSB_CGBRDZZHQKMONTH
    /// </summary>
    public class TBL_DZHJSB_CGBRDZZHQKMONTHController : MvcControllerBase
    {
        private TBL_DZHJSB_CGBRDZZHQKMONTHBLL tbl_dzhjsb_cgbrdzzhqkmonthbll = new TBL_DZHJSB_CGBRDZZHQKMONTHBLL();
        private TBL_DZHJSB_DZZHQKMONTHBLL tbl_dzhjsb_dzzhqkmonthbll = new TBL_DZHJSB_DZZHQKMONTHBLL();
        
        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DZHJSB_CGBRDZZHQKMONTHIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DZHJSB_CGBRDZZHQKMONTHForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        [LogContent("TBL_DZHJSB_CGBRDZZHQKMONTH", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_dzhjsb_cgbrdzzhqkmonthbll.GetList(queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = tbl_dzhjsb_cgbrdzzhqkmonthbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 导入相关方法
        public static List<TBL_DZHJSB_CGBRDZZHQKMONTHEntity> testListCGBRDZZHQKMONTH = new List<TBL_DZHJSB_CGBRDZZHQKMONTHEntity>();
        public static List<TBL_DZHJSB_DZZHQKMONTHEntity> testListDZZHQKMONTH = new List<TBL_DZHJSB_DZZHQKMONTHEntity>();
        public ActionResult ImportExcelDataSave(string year, string month, string bbtype)
        {
            if (bbtype == "2")
            {
                if (testListCGBRDZZHQKMONTH.Count > 0 && testListCGBRDZZHQKMONTH != null && !string.IsNullOrEmpty(year))
                {
                    List<TBL_DZHJSB_CGBRDZZHQKMONTHEntity> testList = new List<TBL_DZHJSB_CGBRDZZHQKMONTHEntity>();
                    var oldlist = tbl_dzhjsb_cgbrdzzhqkmonthbll.GetList(null);
                    foreach (var item in testListCGBRDZZHQKMONTH)
                    {
                        short y = Convert.ToInt16(year);
                        short m = Convert.ToInt16(month);
                        var newlist = oldlist.Where(s => s.DISASTERYEAR == y && s.DISASTERMONTH == m && s.CITYNAME == item.CITYNAME).ToList();
                        if (newlist.Count > 0)
                        {
                            tbl_dzhjsb_cgbrdzzhqkmonthbll.RemoveForm(newlist.FirstOrDefault().GUID);
                        }
                        item.DISASTERYEAR = y;
                        item.DISASTERMONTH = m;
                        tbl_dzhjsb_cgbrdzzhqkmonthbll.SaveForm(null, item);
                    }
                }
                return Success("操作成功。");
            }
            else if (bbtype == "1")
            {
                if (testListDZZHQKMONTH.Count > 0 && testListDZZHQKMONTH != null && !string.IsNullOrEmpty(year))
                {
                    List<TBL_DZHJSB_DZZHQKMONTHEntity> testList = new List<TBL_DZHJSB_DZZHQKMONTHEntity>();
                    var oldlist = tbl_dzhjsb_dzzhqkmonthbll.GetList(null);
                    foreach (var item in testListDZZHQKMONTH)
                    {
                        short y = Convert.ToInt16(year);
                        short m = Convert.ToInt16(month);
                        var newlist = oldlist.Where(s => s.DISASTERTEAR == y && s.DISASTERMONTH == m && s.CITYNAME == item.CITYNAME).ToList();
                        if (newlist.Count > 0)
                        {
                            tbl_dzhjsb_dzzhqkmonthbll.RemoveForm(newlist.FirstOrDefault().GUID);
                        }
                        item.DISASTERTEAR = y;
                        item.DISASTERMONTH = m;
                        tbl_dzhjsb_dzzhqkmonthbll.SaveForm(null, item);
                    }
                }
                return Success("操作成功。");
            }
            return Error("没有获取到excel中的数据。");
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult ImportExcelData(string year, string month, string bbtype)
        {
            try
            {
                System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                if (files.Count > 0)
                {
                    var file = files[0];
                    string dir = System.Web.HttpContext.Current.Server.MapPath("/Temp");
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string filePath = Path.Combine(dir, Guid.NewGuid().ToString() + file.FileName);
                    file.SaveAs(filePath);
                    DataTable data = DataTableToEntity.GetData(filePath) as DataTable;
                    DataTable newdata = new DataTable();
                    if (data.Rows.Count <= 2)
                    {
                        return ToJsonResult("无数据");
                    }
                    var type = data.Rows[0][0].ToString().Split(':');
                    if (type[1] != "月报")
                    {
                        return ToJsonResult("请选择正确的报表类型。");
                    }
                    if (bbtype != type[1])
                    {
                        System.IO.File.Delete(filePath);
                        return ToJsonResult(type[0] + "类型不一致。");
                    }
                    //if (bbtype != data.Rows[0][0].ToString().Split(':')[1])
                    //{
                    //    System.IO.File.Delete(filePath);
                    //    return ToJsonResult("1");
                    //}
                    for (int i = 0; i < data.Columns.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(data.Rows[1][i].ToString()))
                        {
                            newdata.Columns.Add(data.Rows[1][i].ToString());
                        }
                    }
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (i > 3)
                        {
                            DataRow dr = newdata.NewRow();
                            dr = data.Rows[i];
                            if (newdata.Rows.Count > 0 && newdata.Rows.Count != i + 1)
                            {
                                dr[0] = newdata.Rows[0][0].ToString();
                            }
                            newdata.Rows.Add(dr.ItemArray);
                            //newdata.ImportRow(dr);
                        }
                    }
                    System.IO.File.Delete(filePath);
                    if (newdata != null)
                    {
                        if (bbtype == "2")
                        {
                            testListCGBRDZZHQKMONTH = newdata.ConvertToModel<TBL_DZHJSB_CGBRDZZHQKMONTHEntity>();
                            return ToJsonResult(testListCGBRDZZHQKMONTH);
                        }
                        else
                        {
                            testListDZZHQKMONTH = newdata.ConvertToModel<TBL_DZHJSB_DZZHQKMONTHEntity>();
                            return ToJsonResult(testListDZZHQKMONTH);
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("TBL_DZHJSB_CGBRDZZHQKMONTH", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_dzhjsb_cgbrdzzhqkmonthbll.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("TBL_DZHJSB_CGBRDZZHQKMONTH", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_DZHJSB_CGBRDZZHQKMONTHEntity entity)
        {
            tbl_dzhjsb_cgbrdzzhqkmonthbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
