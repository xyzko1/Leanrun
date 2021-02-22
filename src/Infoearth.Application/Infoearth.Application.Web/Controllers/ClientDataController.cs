using Infoearth.Application.Cache;
using Infoearth.Application.Entity.SystemManage.ViewModel;
using Infoearth.Util;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Infoearth.Application.Entity.BaseManage;
using Infoearth.Application.Busines.AuthorizeManage;
using Infoearth.Application.Code;
using Infoearth.Application.Entity.AuthorizeManage;
using Infoearth.Application.Busines.FormManage;
using Infoearth.Application.Entity.FormManage;
using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Entity.SystemManage;
using System;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Web;
using iTelluro.Busness.WebApiProxy;
using System.Configuration;
using Infoearth.Util.WebControl;
using System.Xml;

namespace Infoearth.Application.Web.Controllers
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 
    /// 创建人：佘赐雄
    /// 日 期：2015.09.01 13:32
    /// 描 述：客户端数据
    /// </summary>
    //[HandlerLogin(LoginMode.Ignore)]
    public class ClientDataController : MvcControllerBase
    {
        private DataItemCache dataItemCache = new DataItemCache();
        private OrganizeCache organizeCache = new OrganizeCache();
        private DepartmentCache departmentCache = new DepartmentCache();
        private PostCache postCache = new PostCache();
        private RoleCache roleCache = new RoleCache();
        private UserGroupCache userGroupCache = new UserGroupCache();
        private UserCache userCache = new UserCache();
        private AuthorizeBLL authorizeBLL = new AuthorizeBLL();
        private FormModuleBLL fromModuleBLL = new FormModuleBLL();
        private System_SetExcelImprotBLL excelBll = new System_SetExcelImprotBLL();
        private System_SetExcelExportBLL excelBll2 = new System_SetExcelExportBLL();

        private string webUrl = System.Configuration.ConfigurationManager.AppSettings["WebBusinessUrl"];
        private string SSOUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
        private string SSOWWUrl = System.Configuration.ConfigurationManager.AppSettings["SSOWWUrl"];
        private string ZJJCURL = System.Configuration.ConfigurationManager.AppSettings["ZJJCURL"];
        private SSOWebApiWS _ssoWS = null;

        private string _busniessCode = System.Configuration.ConfigurationManager.AppSettings["businessCode"];

        private string _meunFrom = System.Configuration.ConfigurationManager.AppSettings["MeunFrom"];
        private string _menuParentId = System.Configuration.ConfigurationManager.AppSettings["MeunParentId"];

        public ClientDataController()
        {
            _ssoWS = new SSOWebApiWS(SSOUrl);
        }
        static ClientDataController()
        {
            SSOWebApiWS sso = new SSOWebApiWS(string.Empty);
            Infoearth.Util.WebHelper.TopMeunParentIds = sso.GetTopMeunParentIds();
        }

        #region 获取数据
        /// <summary>
        /// 批量加载数据给客户端（把常用数据全部加载到浏览器中 这样能够减少数据库交互）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetClientDataJson()
        {
            //var dat= _ssoWS.GetAllAuthDistricts();

            var jsonData = new
            {
                //organize = this.GetOrganizeData(),                              //公司
                //department = this.GetDepartmentData(),                          //部门
                //post = this.GetPostData(),                                      //岗位
                //role = this.GetRoleData(),                                      //角色
                //userGroup = this.GetUserGroupData(),                            //用户组
                //user = this.GetUserData(),                                      //用户
                authorizeMenu = this.GetModuleData(),                           //导航菜单
                menuParentId = _menuParentId,                                   //导航菜单的父级菜单ModuleId
                authorizeButton = this.GetALLModuleButtonData(),                   //功能按钮
                // authorizeColumn = this.GetModuleColumnData(),                   //功能视图
                menu = this.GetALLModuleData(),                                 //所有功能
                button = this.GetALLModuleButtonData(),                         //所有功能按钮
                dataItem = this.GetDataItem(),                                  //字典
                //formPropertyExpansion = this.GetEntityListByRelation(),         //表单扩展属性
                excelImportTemplate = this.GetExcelImportModuleList(),          //excel导入模板
                excelExportTemplate = this.GetExcelExportModuleList(),           //excel导出模板
                topMeunParentIds = Infoearth.Util.WebHelper.TopMeunParentIds,
                globalConfig = GetGlobalConfig()                                //全局配置变量
            };
            return ToJsonResult(jsonData);
        }
        #endregion

        #region 处理基础数据
        /// <summary>
        /// 获取公司数据
        /// </summary>
        /// <returns></returns>
        private object GetOrganizeData()
        {
            var data = organizeCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (OrganizeEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.F_EnCode,
                    FullName = item.F_FullName
                };
                dictionary.Add(item.F_OrganizeId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取部门数据
        /// </summary>
        /// <returns></returns>
        private object GetDepartmentData()
        {
            var data = departmentCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (DepartmentEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.F_EnCode,
                    FullName = item.F_FullName,
                    OrganizeId = item.F_OrganizeId
                };
                dictionary.Add(item.F_DepartmentId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取岗位数据
        /// </summary>
        /// <returns></returns>
        private object GetUserGroupData()
        {
            var data = userGroupCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.F_EnCode,
                    FullName = item.F_FullName
                };
                dictionary.Add(item.F_RoleId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取岗位数据
        /// </summary>
        /// <returns></returns>
        private object GetPostData()
        {
            var data = postCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.F_EnCode,
                    FullName = item.F_FullName
                };
                dictionary.Add(item.F_RoleId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取角色数据
        /// </summary>
        /// <returns></returns>
        private object GetRoleData()
        {
            var data = roleCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.F_EnCode,
                    FullName = item.F_FullName
                };
                dictionary.Add(item.F_RoleId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        private object GetUserData()
        {
            var data = userCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (UserEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.F_EnCode,
                    Account = item.F_Account,
                    RealName = item.F_RealName,
                    OrganizeId = item.F_OrganizeId,
                    DepartmentId = item.F_DepartmentId
                };
                dictionary.Add(item.F_UserId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <returns></returns>
        public object GetDataItem()
        {
            var dataList = dataItemCache.GetDataItemList().Where(t => !string.IsNullOrEmpty(t.F_EnCode)); ;
            var dataSort = dataList.Distinct(new Comparint<DataItemModel>("F_EnCode"));
            Dictionary<string, object> dictionarySort = new Dictionary<string, object>();
            foreach (DataItemModel itemSort in dataSort)
            {
                var dataItemList = dataList.Where(t => t.F_EnCode.Equals(itemSort.F_EnCode));
                Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();
                foreach (DataItemModel itemList in dataItemList)
                {
                    if (!dictionaryItemList.ContainsKey(itemList.F_ItemValue))
                    {
                        dictionaryItemList.Add(itemList.F_ItemValue, itemList.F_ItemName);
                    }
                }
                foreach (DataItemModel itemList in dataItemList)
                {
                    if (!dictionaryItemList.ContainsKey(itemList.F_ItemDetailId))
                    {
                        dictionaryItemList.Add(itemList.F_ItemDetailId, itemList.F_ItemName);
                    }
                }
                dictionarySort.Add(itemSort.F_EnCode, dictionaryItemList);
            }
            return dictionarySort;
        }
        /// <summary>
        /// 获取所有功能数据
        /// </summary>
        /// <returns></returns>
        private object GetALLModuleData()
        {
            IEnumerable<ModuleEntity> data = null;
            if (string.IsNullOrEmpty(_meunFrom) || _meunFrom == "0")
            {
                data = authorizeBLL.GetALLModuleList();
            }
            else
            {
                data = GetModuleListFromBase();
            }
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (var item in data)
            {
                dictionary.Add(item.F_ModuleId, item);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取功能按钮数据
        /// </summary>
        /// <returns></returns>
        private object GetALLModuleButtonData()
        {
            IEnumerable<ModuleButtonEntity> data = null;
            if (string.IsNullOrEmpty(_meunFrom) || _meunFrom == "0")
            {
                data = authorizeBLL.GetALLModuleButtonList();
            }
            else
            {
                data = GetModuleButtonListFromBase();
            }

            List<ModuleButtonEntity> list = new List<ModuleButtonEntity>();
            list = data.ToList();
            string token = WebHelper.GetCookie("Token");
            token = HttpUtility.UrlDecode(token);
            if (token.Contains(','))
            {
                string userName = token.Split(',')[1];
                if (userName.ToLower() != "system")
                {
                    list.Clear();
                    List<string> mlist = _ssoWS.GetMenuButtonByBusinessCodeAndUserID(_busniessCode);
                    foreach (var item in data)
                    {
                        if (mlist.Contains(item.F_ModuleButtonId))
                        {
                            list.Add(item);
                        }
                    }
                }
            }

            var dataModule = list.Distinct(new Comparint<ModuleButtonEntity>("F_ModuleId"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (ModuleButtonEntity item in dataModule)
            {
                var buttonList = list.Where(t => t.F_ModuleId.Equals(item.F_ModuleId));
                dictionary.Add(item.F_ModuleId, buttonList);
            }
            return dictionary;
        }
        #endregion

        #region 处理授权数据
        /// <summary>
        /// 获取功能数据
        /// </summary>
        /// <returns></returns>
        private object GetModuleData()
        {
            try
            {
                IEnumerable<ModuleEntity> menus = null;
                if (string.IsNullOrEmpty(_meunFrom) || _meunFrom == "0")
                {
                    menus = authorizeBLL.GetALLModuleList();
                }
                else
                {
                    menus = GetModuleListFromBase();
                }
                List<ModuleEntity> list = new List<ModuleEntity>();

                string token = WebHelper.GetCookie("Token");
                token = HttpUtility.UrlDecode(token);
                if (token.Contains(','))
                {
                    string userName = token.Split(',')[1];
                    if (userName.ToLower() == "system")
                    {
                        foreach (var item in menus)
                        {
                            var module = ConvertMenuUrl(item);
                            list.Add(module);
                        }
                        return list;
                    }
                }
                List<string> mlist = _ssoWS.GetMenuByBusinessCodeAndUserID(_busniessCode);
                foreach (var item in menus)
                {
                    if (mlist.Contains(item.F_ModuleId))
                    {
                        var module = ConvertMenuUrl(item);
                        list.Add(module);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取功能按钮数据
        /// </summary>
        /// <returns></returns>
        private object GetModuleButtonData()
        {
            var data = authorizeBLL.GetModuleButtonList(SystemInfo.CurrentUserId);
            var dataModule = data.Distinct(new Comparint<ModuleButtonEntity>("F_ModuleId"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (ModuleButtonEntity item in dataModule)
            {
                var buttonList = data.Where(t => t.F_ModuleId.Equals(item.F_ModuleId));
                dictionary.Add(item.F_ModuleId, buttonList);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取功能视图数据
        /// </summary>
        /// <returns></returns>
        private object GetModuleColumnData()
        {
            var data = authorizeBLL.GetModuleColumnList(SystemInfo.CurrentUserId);
            var dataModule = data.Distinct(new Comparint<ModuleColumnEntity>("F_ModuleId"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (ModuleColumnEntity item in dataModule)
            {
                var columnList = data.Where(t => t.F_ModuleId.Equals(item.F_ModuleId));
                dictionary.Add(item.F_ModuleId, columnList);
            }
            return dictionary;
        }

        /// <summary>
        /// 转换菜单的Url
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        private ModuleEntity ConvertMenuUrl(ModuleEntity module)
        {
            if (module == null || string.IsNullOrWhiteSpace(module.F_UrlAddress))
                return module;
            string businessName = string.Empty;
            string url = string.Empty;
            if (module.F_UrlAddress.Contains("{sddmcj}"))
            {
                businessName = "{sddmcj}";
                url = webUrl;
            }

            if (businessName == string.Empty || url == string.Empty)
                return module;
            if (module.F_UrlAddress.Contains("}/") && url.EndsWith("/"))
                module.F_UrlAddress = module.F_UrlAddress.Replace(businessName + "/", url);
            else
                module.F_UrlAddress = module.F_UrlAddress.Replace(businessName, url);
            return module;
        }
        #endregion

        #region 扩展属性数据
        /// <summary>
        /// 获取扩展属性表单的对应模块数据
        /// </summary>
        /// <returns></returns>
        private object GetEntityListByRelation()
        {
            var data = fromModuleBLL.GetEntityListByRelation("{\"F_FrmKind\":\"1\"}");
            Dictionary<string, List<FormModuleEntity>> dictionary = new Dictionary<string, List<FormModuleEntity>>();
            foreach (var item in data)
            {
                if (!dictionary.ContainsKey(item.F_ObjectId))
                {
                    List<FormModuleEntity> list = new List<FormModuleEntity>();
                    list.Add(item);
                    dictionary.Add(item.F_ObjectId, list);
                }
                else
                {
                    dictionary[item.F_ObjectId].Add(item);
                }
            }
            return dictionary;
        }
        #endregion

        #region Excel导入导出
        /// <summary>
        /// 获取模块绑定的导入模板
        /// </summary>
        /// <returns></returns>
        private object GetExcelImportModuleList()
        {
            var data = excelBll.GetList("{\"F_EnabledMark\":\"1\"}");
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            foreach (var item in data)
            {
                try
                {
                    if (string.IsNullOrEmpty(item.F_ModuleId))
                    {
                        continue;
                    }
                    if (!dictionary.ContainsKey(item.F_ModuleId))
                    {
                        List<string> list = new List<string>();
                        list.Add(item.F_Id);
                        dictionary.Add(item.F_ModuleId, list);
                    }
                    else
                    {
                        dictionary[item.F_ModuleId].Add(item.F_Id);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return dictionary;
        }
        /// <summary>
        /// 获取模块绑定的导出模板
        /// </summary>
        /// <returns></returns>
        private object GetExcelExportModuleList()
        {
            var data = excelBll2.GetList("{\"F_EnabledMark\":\"1\"}");
            Dictionary<string, List<object>> dictionary = new Dictionary<string, List<object>>();
            foreach (var item in data)
            {
                if (string.IsNullOrEmpty(item.F_ModuleId))
                {
                    continue;
                }
                if (!dictionary.ContainsKey(item.F_ModuleId))
                {
                    List<object> list = new List<object>();
                    list.Add(item);
                    dictionary.Add(item.F_ModuleId, list);
                }
                else
                {
                    dictionary[item.F_ModuleId].Add(item);
                }
            }
            return dictionary;
        }
        #endregion

        #region 额外新增

        /// <summary>
        /// 从基础信息平台获取菜单
        /// </summary>
        /// <returns></returns>
        public List<ModuleEntity> GetModuleListFromBase()
        {
            List<ModuleEntity> list = _ssoWS.GetBusinessMenuFromSSO(_busniessCode);
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.F_UrlAddress))
                {
                    if (item.F_UrlAddress.Contains('{') && item.F_UrlAddress.Contains('}'))
                    {
                        var tmp = item.F_UrlAddress.Split(new char[] { '}' }, StringSplitOptions.RemoveEmptyEntries);
                        if (tmp != null && tmp.Length > 1)
                        {
                            item.F_UrlAddress = tmp[1];
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 从基础信息平台获取菜单按钮
        /// </summary>
        /// <returns></returns>
        public List<ModuleButtonEntity> GetModuleButtonListFromBase()
        {
            List<ModuleButtonEntity> list = _ssoWS.GetBusinessMenuButtonFromSSO(_busniessCode);
            return list;
        }

        #endregion


        #region 获取全局配置
        public object GetGlobalConfig()
        {
            Dictionary<string, object> config = new Dictionary<string, object>();
            //SSO地址
            config.Add("SSOUrl", SSOUrl);
            config.Add("SSOWWUrl", SSOWWUrl);
            config.Add("ZJJCURL", ZJJCURL);
            //地图数据
            config.Add("mapData", GetMapDatas());
            //初始化地图位置(经,纬,级数)
            config.Add("center", System.Configuration.ConfigurationManager.AppSettings["center"]);
            //默认的行政区划
            config.Add("DefalutCode", System.Configuration.ConfigurationManager.AppSettings["DefalutCode"]);
            config.Add("DefalutAreaName", System.Configuration.ConfigurationManager.AppSettings["DefalutAreaName"]);
            config.Add("WebBusinessUrl", System.Configuration.ConfigurationManager.AppSettings["WebBusinessUrl"]);
            config.Add("WebGeoDisasterUrl", System.Configuration.ConfigurationManager.AppSettings["WebGeoDisasterUrl"]);
            config.Add("businessCode", System.Configuration.ConfigurationManager.AppSettings["businessCode"]);
            config.Add("MeunFrom", System.Configuration.ConfigurationManager.AppSettings["MeunFrom"]);
            config.Add("WebApiResultWrap", System.Configuration.ConfigurationManager.AppSettings["WebApiResultWrap"]);
            return config;
        }
        #endregion
        #region 地图
        /// <summary>
        /// 获取地图数据
        /// </summary>
        /// <returns></returns>
        private object GetMapDatas()
        {
            try
            {
                string mapDataXmlFilePath = HttpContext.Server.MapPath("~/XmlConfig/GeoMap.xml");
                List<TreeEntity> treeList = new List<TreeEntity>();
                XmlDocument doc = new XmlDocument();
                if (!System.IO.File.Exists(mapDataXmlFilePath))
                {
                    return Content("");
                }
                doc.Load(mapDataXmlFilePath);
                # region 二维地图
                GisLayerInfo ginfoBase = new GisLayerInfo();
                //标注
                GisLayerInfo ginfoBaseBZ = new GisLayerInfo();
                #endregion

                #region 卫星地图
                GisLayerInfo ginfoBaseW = new GisLayerInfo();
                //标注
                GisLayerInfo ginfoBaseBZW = new GisLayerInfo();
                #endregion

                GisLayerInfo proviceMap = new GisLayerInfo();

                //获取底图
                XmlNodeList nodeList = doc.SelectNodes("mapData/baseLayer");
                foreach (XmlNode item in nodeList)
                {
                    if (item.Attributes["name"].Value == "二维地图")
                    {
                        ginfoBase.url = item.Attributes["url"].Value;
                        ginfoBase.tilesize = int.Parse(item.Attributes["tilesize"].Value);
                        ginfoBase.dataserverkey = item.Attributes["dataserverkey"].Value;
                        ginfoBase.zerolevelsize = double.Parse(item.Attributes["zerolevelsize"].Value);
                        ginfoBase.zoomlevel = int.Parse(item.Attributes["zoomlevel"].Value);
                        ginfoBase.opacity = double.Parse(item.Attributes["opacity"].Value);
                        //标注
                        XmlNodeList vectorNodes = item.SelectNodes("VectorLayer");
                        if (vectorNodes.Count > 0)
                        {
                            ginfoBaseBZ.url = vectorNodes[0].Attributes["url"].Value;
                            ginfoBaseBZ.tilesize = int.Parse(vectorNodes[0].Attributes["tilesize"].Value);
                            ginfoBaseBZ.dataserverkey = vectorNodes[0].Attributes["dataserverkey"].Value;
                            ginfoBaseBZ.zerolevelsize = double.Parse(vectorNodes[0].Attributes["zerolevelsize"].Value);
                            ginfoBaseBZ.zoomlevel = int.Parse(vectorNodes[0].Attributes["zoomlevel"].Value);
                            ginfoBaseBZ.opacity = double.Parse(vectorNodes[0].Attributes["opacity"].Value);
                        }
                    }
                    else if (item.Attributes["name"].Value == "卫星地图")
                    {
                        ginfoBaseW.url = item.Attributes["url"].Value;
                        ginfoBaseW.tilesize = int.Parse(item.Attributes["tilesize"].Value);
                        ginfoBaseW.dataserverkey = item.Attributes["dataserverkey"].Value;
                        ginfoBaseW.zerolevelsize = double.Parse(item.Attributes["zerolevelsize"].Value);
                        ginfoBaseW.zoomlevel = int.Parse(item.Attributes["zoomlevel"].Value);
                        ginfoBaseW.opacity = double.Parse(item.Attributes["opacity"].Value);
                        //标注
                        XmlNodeList vectorNodes = item.SelectNodes("VectorLayer");
                        if (vectorNodes.Count > 0)
                        {
                            ginfoBaseBZW.url = vectorNodes[0].Attributes["url"].Value;
                            ginfoBaseBZW.tilesize = int.Parse(vectorNodes[0].Attributes["tilesize"].Value);
                            ginfoBaseBZW.dataserverkey = vectorNodes[0].Attributes["dataserverkey"].Value;
                            ginfoBaseBZW.zerolevelsize = double.Parse(vectorNodes[0].Attributes["zerolevelsize"].Value);
                            ginfoBaseBZW.zoomlevel = int.Parse(vectorNodes[0].Attributes["zoomlevel"].Value);
                            ginfoBaseBZW.opacity = double.Parse(vectorNodes[0].Attributes["opacity"].Value);
                        }
                    }
                    else
                    {
                        proviceMap.url = item.Attributes["url"].Value;
                        proviceMap.tilesize = int.Parse(item.Attributes["tilesize"].Value);
                        proviceMap.dataserverkey = item.Attributes["dataserverkey"].Value;
                        proviceMap.zerolevelsize = double.Parse(item.Attributes["zerolevelsize"].Value);
                        proviceMap.zoomlevel = int.Parse(item.Attributes["zoomlevel"].Value);
                        proviceMap.opacity = double.Parse(item.Attributes["opacity"].Value);
                    }
                }
                //获取Gis图层(树节点)
                nodeList = doc.SelectNodes("mapData/layerNodes");
                foreach (XmlNode item in nodeList)
                {
                    string nameText = item.Attributes["name"].Value;
                    XmlNodeList nodeListChilds = item.SelectNodes("layer");
                    TreeEntity treeNode = new TreeEntity();
                    treeNode.id = nameText;
                    treeNode.parentId = "0000";
                    treeNode.text = nameText;
                    GisLayerInfo ginfo = new GisLayerInfo();
                    ginfo.url = "#";
                    ginfo.tilesize = 512;
                    ginfo.dataserverkey = "#";
                    ginfo.zerolevelsize = 72;
                    ginfo.zoomlevel = 1;
                    treeNode.value = ginfo.ToString();
                    treeNode.showcheck = false;
                    treeNode.isexpand = true;
                    treeNode.complete = true;
                    treeNode.hasChildren = nodeListChilds.Count > 0 ? true : false;
                    treeNode.img = "fa fa-navicon";
                    treeList.Add(treeNode);
                    foreach (XmlNode node in nodeListChilds)
                    {
                        TreeEntity treeNodeC = new TreeEntity();
                        string nameC = node.Attributes["name"].Value;
                        treeNodeC.id = Guid.NewGuid().ToString();
                        treeNodeC.parentId = nameText;
                        treeNodeC.text = nameC;
                        GisLayerInfo ginfoC = new GisLayerInfo();
                        ginfoC.url = node.Attributes["url"].Value;
                        ginfoC.tilesize = int.Parse(node.Attributes["tilesize"].Value);
                        ginfoC.dataserverkey = node.Attributes["dataserverkey"].Value;
                        ginfoC.zerolevelsize = double.Parse(node.Attributes["zerolevelsize"].Value);
                        ginfoC.zoomlevel = int.Parse(node.Attributes["zoomlevel"].Value);
                        ginfoC.ischecked = bool.Parse(node.Attributes["checked"].Value) ? 1 : 0;
                        ginfoC.opacity = double.Parse(node.Attributes["opacity"].Value);
                        treeNodeC.value = ginfoC.ToString();
                        treeNodeC.showcheck = true;
                        treeNodeC.checkstate = bool.Parse(node.Attributes["checked"].Value) ? 1 : 0;
                        treeNodeC.isexpand = false;
                        treeNodeC.complete = true;
                        treeNodeC.hasChildren = false;
                        treeNodeC.img = "fa fa-navicon";
                        treeList.Add(treeNodeC);
                    }
                }
                string treeJson = treeList.TreeToJson("0000");

                GisInfo info = new GisInfo();
                info.baseMap = new GisBaseInfo() { map = ginfoBase, note = ginfoBaseBZ };
                info.statelliteMap = new GisBaseInfo() { map = ginfoBaseW, note = ginfoBaseBZW };
                info.gisLayer = treeJson;
                info.proviceMap = proviceMap;
                //范围信息  
                string mapRangeFilePath = HttpContext.Server.MapPath("~/XmlConfig/MapRange.txt");
                if (System.IO.File.Exists(mapRangeFilePath))
                {
                    List<MapRangeInfo> mapRanges = new List<MapRangeInfo>();
                    string[] lines = System.IO.File.ReadAllLines(mapRangeFilePath);
                    if (lines != null && lines.Length > 0)
                    {
                        for (int i = 0; i < lines.Length; i++)
                        {
                            string[] ranges = lines[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (ranges == null || ranges.Length < 3)
                            {
                                continue;
                            }
                            MapRangeInfo rangeInfo = new MapRangeInfo();
                            rangeInfo.RangeLow = double.Parse(ranges[0]);
                            rangeInfo.RangeHigh = double.Parse(ranges[1]);
                            rangeInfo.RangeName = ranges[2];
                            mapRanges.Add(rangeInfo);
                        }
                        info.mapRanges = mapRanges;
                    }
                }
                return info;
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion
    }
}
