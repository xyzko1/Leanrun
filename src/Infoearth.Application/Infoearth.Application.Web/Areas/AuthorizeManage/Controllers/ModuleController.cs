﻿using Infoearth.Application.Busines.AuthorizeManage;
using Infoearth.Application.Code;
using Infoearth.Application.Entity.AuthorizeManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.AuthorizeManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 
    /// 创建人：佘赐雄
    /// 日 期：2015.10.27 09:16
    /// 描 述：系统功能
    /// </summary>
    public class ModuleController : MvcControllerBase
    {
        private ModuleBLL moduleBLL = new ModuleBLL();

        #region 视图功能
        /// <summary>
        /// 功能管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 功能表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            ViewBag.ModuleId = Request["keyValue"];
            return View();
        }
        /// <summary>
        /// 功能图标
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Icon()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 功能列表 
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="target">目标</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson(string keyword, string target)
        {
            var data = moduleBLL.GetList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.F_FullName.Contains(keyword), "F_ModuleId");
            }
            if (!string.IsNullOrEmpty(target))
            {
                data = data.TreeWhere(t => t.F_Target.Contains(target), "F_ModuleId");
            }
            var treeList = new List<TreeEntity>();
            foreach (ModuleEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_ModuleId) == 0 ? false : true;
                tree.id = item.F_ModuleId;
                tree.text = item.F_FullName;
                tree.value = item.F_ModuleId;
                tree.isexpand = item.F_AllowExpand == 0?false:true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.F_ParentId;
                tree.img = item.F_Icon;
                tree.Attribute = "F_Target";
                tree.AttributeValue = item.F_Target;
                treeList.Add(tree);
            }

            string treeJson = treeList.TreeToJson();
            return Content(treeJson);
        }

        /// <summary>
        /// 功能列表 
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="target">目标</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJsonExt(string keyword, string target)
        {
            var data = moduleBLL.GetList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.F_FullName.Contains(keyword), "F_ModuleId");
            }
            if (!string.IsNullOrEmpty(target))
            {
                data = data.TreeWhere(t => t.F_Target.Contains(target), "F_ModuleId");
            }
            var treeList = new List<TreeEntity>();

            TreeEntity treeT = new TreeEntity();
            treeT.id = "0";
            treeT.text = "系统目录";
            treeT.value = "0";
            treeT.isexpand = true;
            treeT.complete = true;
            treeT.hasChildren = true;
            treeT.parentId = "-1";
            treeT.img = "fa fa-navicon";
            treeT.Attribute = "F_Target";

            treeList.Add(treeT);

            foreach (ModuleEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_ModuleId) == 0 ? false : true;
                tree.id = item.F_ModuleId;
                tree.text = item.F_FullName;
                tree.value = item.F_ModuleId;
                tree.isexpand = item.F_AllowExpand == 0 ? false : true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.F_ParentId;
                tree.img = item.F_Icon;
                tree.Attribute = "F_Target";
                tree.AttributeValue = item.F_Target;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson("-1"));
        }

        /// <summary>
        /// 获取目录级功能列表 
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetCatalogTreeJson(string keyword)
        {
            var data = moduleBLL.GetList();
            data = data.FindAll(t => t.F_IsMenu != 1);
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.F_FullName.Contains(keyword), "");
            }
            var treeList = new List<TreeEntity>();
            foreach (ModuleEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_ModuleId) == 0 ? false : true;
                tree.id = item.F_ModuleId;
                tree.text = item.F_FullName;
                tree.value = item.F_ModuleId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.F_ParentId;
                tree.img = item.F_Icon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 功能列表 
        /// </summary>
        /// <param name="parentid">节点Id</param>
        /// <param name="condition">查询条件</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        [LogContent("菜单", OpType.Query)]
        public ActionResult GetListJson(string parentid, string condition, string keyword)
        {
            var data = moduleBLL.GetList(parentid);
            if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(keyword))
            {
                #region 多条件查询
                switch (condition)
                {
                    case "EnCode":    //编号
                        data = data.FindAll(t => t.F_EnCode.Contains(keyword));
                        break;
                    case "FullName":      //名称
                        data = data.FindAll(t => t.F_FullName.Contains(keyword));
                        break;
                    case "UrlAddress":   //地址
                        data = data.FindAll(t => t.F_UrlAddress.Contains(keyword));
                        break;
                    default:
                        break;
                }
                #endregion
            }
            return Content(data.ToJson());
        }
        /// <summary>
        /// 功能实体 返回对象Json
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = moduleBLL.GetEntity(keyValue);
            return Content(data.ToJson());
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 功能编号不能重复
        /// </summary>
        /// <param name="EnCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistEnCode(string EnCode, string keyValue)
        {
            bool IsOk = moduleBLL.ExistEnCode(EnCode, keyValue);
            return Content(IsOk.ToString());
        }
        /// <summary>
        /// 功能名称不能重复
        /// </summary>
        /// <param name="FullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistFullName(string FullName, string keyValue)
        {
            bool IsOk = moduleBLL.ExistFullName(FullName, keyValue);
            return Content(IsOk.ToString());
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        //[HandlerAuthorize(PermissionMode.Enforce)]
        [LogContent("菜单", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            moduleBLL.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存功能表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="moduleEntity">功能实体</param>
        /// <param name="moduleButtonListJson">按钮实体列表</param>
        /// <param name="moduleColumnListJson">视图实体列表</param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        [LogContent("菜单", OpType.Update)]
        public ActionResult SaveForm(string keyValue, ModuleEntity moduleEntity, string moduleButtonListJson, string moduleColumnListJson)
        {
            moduleBLL.SaveForm(keyValue, moduleEntity, moduleButtonListJson, moduleColumnListJson);
            return Success("保存成功。");
        }
        #endregion
    }
}
