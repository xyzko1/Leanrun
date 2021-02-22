﻿using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Code;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 
    /// 创建人：佘赐雄
    /// 日 期：2015.11.18 11:02
    /// 描 述：数据库连接管理
    /// </summary>
    public class DataBaseLinkController : MvcControllerBase
    {
        private DataBaseLinkBLL databaseLinkBLL = new DataBaseLinkBLL();

        #region 视图功能
        /// <summary>
        /// 库连接管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 库连接表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 库连接列表 
        /// </summary>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson(string keyword)
        {
            var data = databaseLinkBLL.GetList();
            var dataIp = data.Distinct(new Comparint<DataBaseLinkEntity>("ServerAddress"));
            var treeList = new List<TreeEntity>();
            foreach (DataBaseLinkEntity item in dataIp)
            {
                TreeEntity tree = new TreeEntity();
                tree.id = item.F_ServerAddress;
                tree.text = item.F_ServerAddress;
                tree.value = item.F_ServerAddress;
                tree.parentId = "0";
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = true;
                if (!treeList.Exists(t => t.id == tree.id))
                {
                    treeList.Add(tree);
                }
                
            }
            foreach (DataBaseLinkEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                tree.id = item.F_DatabaseLinkId;
                tree.text = item.F_DBAlias;
                tree.value = item.F_DatabaseLinkId;
                tree.title = item.F_DBName;
                tree.parentId = item.F_ServerAddress;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = false;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 库连接列表
        /// </summary>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string keyword)
        {
            var data = databaseLinkBLL.GetList();
            return ToJsonResult(data);
        }
        /// <summary>
        /// 库连接实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = databaseLinkBLL.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除库连接
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RemoveForm(string keyValue)
        {
            databaseLinkBLL.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存库连接表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="databaseLinkEntity">库连接实体</param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, DataBaseLinkEntity databaseLinkEntity)
        {
            databaseLinkBLL.SaveForm(keyValue, databaseLinkEntity);
            return Success("操作成功。");
        }
        /// <summary>
        /// 测试连接字符串是否成功
        /// </summary>
        /// <param name="databaseLinkEntity"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult TestConnection(DataBaseLinkEntity databaseLinkEntity)
        {
            databaseLinkBLL.TestConnection(databaseLinkEntity);
            return Success("测试连接成功。");
        }
        #endregion
    }
}
