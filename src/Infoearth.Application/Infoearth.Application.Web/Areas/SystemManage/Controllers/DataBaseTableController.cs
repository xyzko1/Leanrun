﻿using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Code;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.CodeGenerator.Comm;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace Infoearth.Application.Web.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 
    /// 创建人：佘赐雄
    /// 日 期：2015.11.18 11:02
    /// 描 述：据库表管理
    /// </summary>
    public class DataBaseTableController : MvcControllerBase
    {
        //private DataBaseTableBLL dataBaseTableBLL = new DataBaseTableBLL("");
        private DataBaseLinkBLL databaseLinkBLL = new DataBaseLinkBLL();

        #region 视图功能
        /// <summary>
        /// 数据库管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 数据表表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// 打开表数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult TableData()
        {
            return View();
        }
        /// <summary>
        /// 数据表字段表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FieldForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 数据库表列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetTableListJson(string dataBaseLinkId, string keyword)
        {
            var data = new DataBaseTableBLL(dataBaseLinkId).GetTableList(dataBaseLinkId, keyword);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 数据库视图列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetViewListJson(string dataBaseLinkId, string keyword)
        {
            var data = new DataBaseTableBLL(dataBaseLinkId).GetViewList(dataBaseLinkId, keyword);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 数据库表字段列表 
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <param name="nameId">字段Id</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTableFiledTreeJson(string dataBaseLinkId, string tableName, string nameId,bool topCheck=false)
        {
            List<string> nameArray = new List<string>();
            if (!string.IsNullOrEmpty(nameId))
            {
                nameArray = new List<string>(nameId.Split(','));
            }
            var data = new DataBaseTableBLL(dataBaseLinkId).GetTableFiledList(dataBaseLinkId, tableName);
            var treeList = new List<TreeEntity>();
            TreeEntity tree = new TreeEntity();
            tree.id = tableName;
            tree.text = tableName;
            tree.value = tableName;
            tree.parentId = "0";
            tree.img = "fa fa-list-alt";
            tree.isexpand = true;
            tree.complete = true;
            tree.hasChildren = true;
            if (topCheck)
            {
                tree.showcheck = true;
                if (nameArray.Count == data.Count())
                {
                    tree.checkstate = 1;
                }
            }
            treeList.Add(tree);
            foreach (DataBaseTableFieldEntity item in data)
            {
                tree = new TreeEntity();
                tree.id = item.f_column;
                //解决换行符引起的树结构解析失败Bug
                if (!string.IsNullOrEmpty(item.f_remark))
                {
                    tree.text = item.f_remark.Replace("\r\n", "").Replace("\n", "").Replace("\r", "") + "（" + item.f_column + "）";
                    tree.value = item.f_remark.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
                }
                else
                {
                    tree.text = "（" + item.f_column + "）";
                    tree.value = "";
                }
                tree.parentId = tableName;
                tree.img = "fa fa-wrench";
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = nameArray.Contains(item.f_column) == true ? 1 : 0;
                tree.hasChildren = false;
                tree.Attribute = "type";
                tree.AttributeValue = CommHelper.FindModelsTypeEx(item.f_datatype);
                tree.AttributeA = "fieldlenght";
                tree.AttributeValueA = "0";
                if(item.f_length.HasValue)
                {
                    tree.AttributeValueA = item.f_length.Value.ToString();
                }
               
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 数据库表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetTableFiledListJson(string dataBaseLinkId, string tableName)
        {
            var data = new DataBaseTableBLL(dataBaseLinkId).GetTableFiledList(dataBaseLinkId, tableName);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 数据库表数据列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="condition">并集、或集</param>
        /// <param name="pagination">分页参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetTableDataListJsonNew(string dataBaseLinkId, string tableName, string switchWhere, string logic, string keyword, string condition, Pagination pagination)
        {
            var watch = CommonHelper.TimerStart();
            if (string.IsNullOrEmpty(switchWhere) || string.IsNullOrEmpty(logic) || string.IsNullOrEmpty(keyword))
            {
                var data = new DataBaseTableBLL(dataBaseLinkId).GetTableDataList(dataBaseLinkId, tableName, switchWhere, logic, keyword, pagination);
                var JsonData = new
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return ToJsonResult(JsonData);
            }
            else
            {
                string[] _switchWhere = switchWhere.Split('#');
                string[] _logic = logic.Split('#');
                string[] _keyword = keyword.Split('#');
                string[] _condition = condition.Split('#');
                var data = new DataBaseTableBLL(dataBaseLinkId).GetTableDataListNew(dataBaseLinkId, tableName, _switchWhere, _logic, _keyword, _condition, pagination);
                var JsonData = new
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return ToJsonResult(JsonData);
            }
        }
        /// <summary>
        /// 数据库表数据列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pagination">分页参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetTableDataListJson(string dataBaseLinkId, string tableName, string switchWhere, string logic, string keyword, Pagination pagination)
        {
            var watch = CommonHelper.TimerStart();
            var data = new DataBaseTableBLL(dataBaseLinkId).GetTableDataList(dataBaseLinkId, tableName, switchWhere, logic, keyword, pagination);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存数据库表表单（新增、修改）
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDescription">表说明</param>
        /// <param name="fieldListJson">字段列表Json</param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string dataBaseLinkId, string tableName, string tableDescription, string fieldListJson)
        {
            new DataBaseTableBLL(dataBaseLinkId).SaveForm(dataBaseLinkId, tableName, tableDescription, fieldListJson);
            return Success("操作成功。");
        }
        #endregion
    }
}

