using Infoearth.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infoearth.Util;
using Infoearth.Util.Extension;
using System.Xml;
using iTelluro.Busness.WebApiProxy;
using System.Web.UI.WebControls;
using Infoearth.Application.Entity;
using Infoearth.Application.Entity.SystemManage;
using System.Net;
using iTelluroLib.Ini.Config;
using System.IO;
using System.Text;
using Infoearth.Application.Web.Utility;
using System.Configuration;

namespace Infoearth.Application.Web.Controllers
{
    public class MapController : MvcControllerBase
    {
        [HttpGet]
        public ActionResult GetMapDatas()
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
                        //标注
                        XmlNodeList vectorNodes = item.SelectNodes("VectorLayer");
                        if (vectorNodes.Count > 0)
                        {
                            ginfoBaseBZ.url = vectorNodes[0].Attributes["url"].Value;
                            ginfoBaseBZ.tilesize = int.Parse(vectorNodes[0].Attributes["tilesize"].Value);
                            ginfoBaseBZ.dataserverkey = vectorNodes[0].Attributes["dataserverkey"].Value;
                            ginfoBaseBZ.zerolevelsize = double.Parse(vectorNodes[0].Attributes["zerolevelsize"].Value);
                            ginfoBaseBZ.zoomlevel = int.Parse(vectorNodes[0].Attributes["zoomlevel"].Value);
                        }
                    }
                    else if (item.Attributes["name"].Value == "影像地图")
                    {
                        ginfoBaseW.url = item.Attributes["url"].Value;
                        ginfoBaseW.tilesize = int.Parse(item.Attributes["tilesize"].Value);
                        ginfoBaseW.dataserverkey = item.Attributes["dataserverkey"].Value;
                        ginfoBaseW.zerolevelsize = double.Parse(item.Attributes["zerolevelsize"].Value);
                        ginfoBaseW.zoomlevel = int.Parse(item.Attributes["zoomlevel"].Value);
                        //标注
                        XmlNodeList vectorNodes = item.SelectNodes("VectorLayer");
                        if (vectorNodes.Count > 0)
                        {
                            ginfoBaseBZW.url = vectorNodes[0].Attributes["url"].Value;
                            ginfoBaseBZW.tilesize = int.Parse(vectorNodes[0].Attributes["tilesize"].Value);
                            ginfoBaseBZW.dataserverkey = vectorNodes[0].Attributes["dataserverkey"].Value;
                            ginfoBaseBZW.zerolevelsize = double.Parse(vectorNodes[0].Attributes["zerolevelsize"].Value);
                            ginfoBaseBZW.zoomlevel = int.Parse(vectorNodes[0].Attributes["zoomlevel"].Value);
                        }
                    }
                    else
                    {
                        proviceMap.url = item.Attributes["url"].Value;
                        proviceMap.tilesize = int.Parse(item.Attributes["tilesize"].Value);
                        proviceMap.dataserverkey = item.Attributes["dataserverkey"].Value;
                        proviceMap.zerolevelsize = double.Parse(item.Attributes["zerolevelsize"].Value);
                        proviceMap.zoomlevel = int.Parse(item.Attributes["zoomlevel"].Value);
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
                return ToJsonResult(info);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult GetAllDistricts(string value)
        {
            string code = string.Empty;
            code = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            List<TreeEntity> data = new List<TreeEntity>();
            TreeEntity data_province = new TreeEntity();
            data_province.id = code;
            data_province.parentId = "0";
            data_province.Level = 1;
            data_province.text = ws.GetDistrctByCodes(code).FirstOrDefault().DistrictName;
            data_province.hasChildren = true;
            data_province.complete = true;
            data.Add(data_province);
            //市
            List<AreaEntity> citys = ws.GetAreaListJson(code);
            foreach (var item_city in citys)
            {
                TreeEntity data_city = new TreeEntity();
                data_city.id = item_city.F_AreaId;
                data_city.parentId = code;
                data_city.Level = 2;
                data_city.text = item_city.F_AreaName;
                data_city.complete = true;
                data_city.hasChildren = true;
                //县
                List<AreaEntity> countys = ws.GetAreaListJson(item_city.F_AreaId);
                foreach (var item_county in countys)
                {
                    TreeEntity data_county = new TreeEntity();
                    data_county.id = item_county.F_AreaId;
                    data_county.parentId = item_city.F_AreaId;
                    data_county.Level = 3;
                    data_county.text = item_county.F_AreaName;
                    data_county.complete = true;
                    data_county.hasChildren = true;
                    //乡
                    List<AreaEntity> towns = ws.GetAreaListJson(item_county.F_AreaId);
                    foreach (var item_town in towns)
                    {
                        TreeEntity data_town = new TreeEntity();
                        data_town.id = item_town.F_AreaId;
                        data_town.parentId = item_county.F_AreaId;
                        data_town.Level = 4;
                        data_town.text = item_town.F_AreaName;
                        data_town.hasChildren = false;
                        data_town.complete = true;
                        data.Add(data_town);
                    }
                    data.Add(data_county);
                }
                data.Add(data_city);
            }
            return Content(data.TreeToJsonForMap());
        }
        [HttpGet]
        public ActionResult GetDistrctByCodes(string value)
        {
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            return Content(ws.GetDistrctByCodes(value).FirstOrDefault().DistrictName);
        }
        [HttpGet]
        public ActionResult GetCurrentUserCode()
        {
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);

            return Content(ws.GetCurrentUserCode());
        }
        /// <summary>
        /// 区域列表 
        /// </summary>
        /// <param name="value">当前主键</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJsonForMap(string value)
        {
            string code = string.Empty;
            code = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
            if (string.IsNullOrEmpty(code))
            {
                code = "0";
            }
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            List<AreaEntity> result = ws.GetTreeJsonForMap(value, code);
            string parentId = "0";
            if (!string.IsNullOrEmpty(value))
            {
                parentId = HttpUtility.UrlDecode(value).Split(',')[0];
            }
            string[] pidsT = code.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<TreeEntity> nodes = new List<TreeEntity>();
            List<string> codes = result.Select(t => t.F_AreaCode).ToList();
            List<string> pids = new List<string>();
            foreach (var item in pidsT)
            {
                if (codes.Contains(item))
                {
                    pids.Add(item);
                }
            }
            //构建树
            foreach (var item in result)
            {
                TreeEntity node = new TreeEntity();
                node.isexpand = false;

                if (pids.Count <= 1)
                {
                    for (int i = 0; i < pids.Count; i++)
                    {
                        if (pids[i] == item.F_AreaCode)
                        {
                            node.isexpand = true;
                        }
                    }
                }

                if (item.F_AreaCode == "0")
                {
                    parentId = "-1";
                    node.isexpand = true;
                }

                node.id = item.F_AreaCode;
                node.text = item.F_AreaName;
                node.value = item.F_AreaCode + "," + item.F_Layer;
                if (item.F_LONGITUDE.HasValue && item.F_LATITUDE.HasValue)
                {
                    node.value += "," + item.F_LONGITUDE.Value + "," + item.F_LATITUDE.Value;
                }

                node.complete = false;
                if (item.F_Layer == 3)
                {
                    node.hasChildren = false;
                }
                else
                {
                    node.hasChildren = true;
                }
                node.parentId = item.F_ParentId;
                nodes.Add(node);
            }
            return Content(nodes.TreeToJsonForMap(parentId));
        }
        /// <summary>
        /// 区域列表 
        /// </summary>
        /// <param name="value">当前主键</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJsonForMaps(string value)
        {
            string code = string.Empty;
            code = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
            if (string.IsNullOrEmpty(code))
            {
                code = "0";
            }
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            List<AreaEntity> result = ws.GetTreeJsonForMap(value, code);
            string parentId = "0";
            if (!string.IsNullOrEmpty(value))
            {
                parentId = HttpUtility.UrlDecode(value).Split(',')[0];
            }
            string[] pidsT = code.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<TreeEntity> nodes = new List<TreeEntity>();
            List<string> codes = result.Select(t => t.F_AreaCode).ToList();
            List<string> pids = new List<string>();
            foreach (var item in pidsT)
            {
                if (codes.Contains(item))
                {
                    pids.Add(item);
                }
            }
            //构建树
            foreach (var item in result)
            {
                TreeEntity node = new TreeEntity();
                node.isexpand = false;

                if (pids.Count <= 1)
                {
                    for (int i = 0; i < pids.Count; i++)
                    {
                        if (pids[i] == item.F_AreaCode)
                        {
                            node.isexpand = true;
                        }
                    }
                }

                if (item.F_AreaCode == "0")
                {
                    parentId = "-1";
                    node.isexpand = true;
                }

                node.id = item.F_AreaCode;
                node.text = item.F_AreaName;
                node.value = item.F_AreaCode + "," + item.F_Layer;
                if (item.F_LONGITUDE.HasValue && item.F_LATITUDE.HasValue)
                {
                    node.value += "," + item.F_LONGITUDE.Value + "," + item.F_LATITUDE.Value;
                }

                node.complete = false;
                if (item.F_Layer == 4)
                {
                    node.hasChildren = false;
                }
                else
                {
                    node.hasChildren = true;
                }
                node.parentId = item.F_ParentId;
                nodes.Add(node);
            }
            return Content(nodes.TreeToJsonForMap(parentId));
        }
        /// <summary>
        /// 行政区划树(省市县乡四级)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTreeTownJson(string value)
        {
            string code = string.Empty;
            code = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
            if (string.IsNullOrEmpty(code))
            {
                code = "0";
            }
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            //string parentId = "0";
            //if (!string.IsNullOrEmpty(value))
            //{
            //    parentId = HttpUtility.UrlDecode(value).Split(',')[0];
            //}
            //string[] pidsT = code.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //List<TreeEntity> nodes = new List<TreeEntity>();
            //List<string> codes = result.Select(t => t.F_AreaCode).ToList();
            //List<string> pids = new List<string>();
            //foreach (var item in pidsT)
            //{
            //    if (codes.Contains(item))
            //    {
            //        pids.Add(item);
            //    }
            //}
            ////构建树
            //foreach (var item in result)
            //{
            //    TreeEntity node = new TreeEntity();
            //    node.isexpand = false;

            //    if (pids.Count <= 1)
            //    {
            //        for (int i = 0; i < pids.Count; i++)
            //        {
            //            if (pids[i] == item.F_AreaCode)
            //            {
            //                node.isexpand = true;
            //            }
            //        }
            //    }

            //    if (item.F_AreaCode == "0")
            //    {
            //        parentId = "-1";
            //        node.isexpand = true;
            //    }

            //    node.id = item.F_AreaCode;
            //    node.text = item.F_AreaName;
            //    node.value = item.F_AreaCode + "," + item.F_Layer;
            //    if (item.F_LONGITUDE.HasValue && item.F_LATITUDE.HasValue)
            //    {
            //        node.value += "," + item.F_LONGITUDE.Value + "," + item.F_LATITUDE.Value;
            //    }

            //    node.complete = false;
            //    if (item.F_Layer == 3)
            //    {
            //        node.hasChildren = false;
            //    }
            //    else
            //    {
            //        node.hasChildren = true;
            //    }
            //    node.parentId = item.F_ParentId;
            //    nodes.Add(node);
            //}
            //return Content(nodes.TreeToJsonForMap(parentId));

            List<Treenode2> nodeList = new List<Treenode2>();
            //string code = string.Empty;
            //code = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
            //string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            //SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            //List<AreaEntity> xzqh = new List<AreaEntity>();
            ////数据范围权限过滤
            //List<string> _codes = ws.GetAllAuthDistricts();
            //if (!_codes.Contains("000000"))
            //{
            //    if (_codes.Count == 1)
            //    {
            //        for (int i = 0; i < _codes.Count; i++)
            //        {
            //            _codes.Add(_codes[i].Substring(0, 4) + "00");
            //            _codes.Add(_codes[i].Substring(0, 2) + "0000");
            //            break;
            //        }

            //    }
            //    else if (!_codes.Contains(code))
            //    {
            //        _codes.Add(code);
            //    }
            //    xzqh = ws.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).Where(t => _codes.Contains(t.F_AreaCode.Substring(0, 6))).ToList();
            //}
            //else
            //{
            //    xzqh = ws.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList(); ;
            //}
            List<AreaEntity> xzqh = ws.GetTreeJsonForMap(value, code);
            if (xzqh != null && xzqh.Count > 0)
            {
                //foreach (var dto in xzqh)
                //{
                //    Treenode2 td = new Treenode2();
                //    td.id = dto.F_AreaCode;
                //    td.parentId = "0";
                //    td.complete = true;
                //    td.hasChildren = true;
                //    td.text = dto.F_AreaName;
                //    td.isexpand = true;
                //    td.showcheck = false;
                //    td.value = dto.F_AreaCode + "," + "1," + dto.F_LONGITUDE + "," + dto.F_LATITUDE;
                //}
                foreach (var dto in xzqh)
                {
                    Treenode2 td = new Treenode2();
                    if (!dto.F_AreaCode.Contains("000000"))//不要全国
                    {
                        if (dto.F_AreaCode.EndsWith("0000") & dto.F_AreaCode.Length < 9)
                        {//省
                            td.id = dto.F_AreaCode;
                            td.parentId = "0";
                            td.complete = true;
                            td.hasChildren = true;
                            td.text = dto.F_AreaName;
                            td.isexpand = true;
                            td.showcheck = false;
                            td.value = dto.F_AreaCode + "," + "1," + dto.F_LONGITUDE + "," + dto.F_LATITUDE;
                        }
                        else if (dto.F_AreaCode == "0")
                        {

                        }
                        else if (dto.F_AreaCode.EndsWith("00") & dto.F_AreaCode.Length < 9 & !dto.F_AreaCode.EndsWith("0000"))//市
                        {
                            td.id = dto.F_AreaCode;
                            td.parentId = dto.F_AreaCode.Substring(0, 2) + "0000";
                            td.complete = true;
                            td.hasChildren = true;
                            td.text = dto.F_AreaName;
                            td.isexpand = false;
                            td.showcheck = false;
                            td.value = dto.F_AreaCode + "," + "2," + dto.F_LONGITUDE + "," + dto.F_LATITUDE;
                        }
                        else if (dto.F_AreaCode.Length < 9 & !dto.F_AreaCode.EndsWith("0000") & !dto.F_AreaCode.EndsWith("00"))
                        {//县
                            td.id = dto.F_AreaCode;
                            td.parentId = dto.F_AreaCode.Substring(0, 4) + "00";
                            td.complete = true;
                            td.hasChildren = true;
                            td.text = dto.F_AreaName;
                            td.isexpand = false;
                            td.showcheck = false;
                            td.value = dto.F_AreaCode + "," + "3," + dto.F_LONGITUDE + "," + dto.F_LATITUDE;
                        }
                        else if (!dto.F_AreaCode.Substring(0, 6).EndsWith("0000") & !dto.F_AreaCode.EndsWith("00") & dto.F_AreaCode.Length == 9)
                        {
                            //乡镇
                            td.id = dto.F_AreaCode;
                            td.parentId = dto.F_AreaCode.Substring(0, 6);
                            td.complete = true;
                            td.hasChildren = false;
                            td.text = dto.F_AreaName;
                            td.isexpand = false;
                            td.showcheck = false;
                            td.value = dto.F_AreaCode + "," + "4," + dto.F_LONGITUDE + "," + dto.F_LATITUDE;
                        }
                        nodeList.Add(td);
                    }
                }
            }


            return Content(getpartree(nodeList).ToJson());
        }
        #region private 获取乡镇
        private List<Treenode2> getpartree(List<Treenode2> nodeList)
        {
            List<Treenode2> tree1list = new List<Treenode2>();
            foreach (Treenode2 tree in nodeList)
            {
                if (tree.parentId == "0")
                {
                    tree.ChildNodes = getchildtree(tree, nodeList);
                    tree1list.Add(tree);
                }
            }
            return tree1list;
        }
        private List<Treenode2> getchildtree(Treenode2 node, List<Treenode2> nodeList)
        {
            List<Treenode2> tree2list = new List<Treenode2>();
            foreach (Treenode2 tree2 in nodeList)
            {
                if (node.id == tree2.parentId)
                {
                    tree2list.Add(tree2);
                    tree2.ChildNodes = getchildtree(tree2, nodeList);
                }
            }
            return tree2list;
        }

        #endregion
        /// <summary>
        /// zTree格式的公用行政区划树(省市县三级)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTreeJson(string value)
        {
            List<TreeEntity> nodeList = new List<TreeEntity>();
            string code = string.Empty;
            code = System.Configuration.ConfigurationManager.AppSettings["DefalutCode"];
            string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
            SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
            var districts = ws.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 });
            var xzqh = districts.Where(t => t.F_AreaCode.Length == 6 && t.F_AreaCode.StartsWith(code.Substring(0, 2))).ToList();
            if (xzqh != null && xzqh.Count > 0)
            {
                foreach (var dto in xzqh)
                {
                    TreeEntity td = new TreeEntity();
                    if (!dto.F_AreaCode.Contains("000000") && !dto.F_AreaCode.Equals("0"))//不要全国
                    {
                        if (dto.F_AreaCode.EndsWith("0000"))
                        {//省
                            td.id = dto.F_AreaCode;
                            td.value = dto.F_AreaCode;
                            td.text = dto.F_AreaName;
                            td.parentId = "0";
                            td.Level = 1;
                            td.hasChildren = true;
                            td.complete = true;
                        }
                        else if (dto.F_AreaCode.EndsWith("00"))//市
                        {
                            td.id = dto.F_AreaCode;
                            td.value = dto.F_AreaCode;
                            td.text = dto.F_AreaName;
                            td.parentId = dto.F_AreaCode.Substring(0, 2) + "0000";
                            td.Level = 2;
                            td.hasChildren = true;
                            td.complete = true;
                        }
                        else
                        {//县
                            td.id = dto.F_AreaCode;
                            td.value = dto.F_AreaCode;
                            td.text = dto.F_AreaName;
                            td.parentId = dto.F_AreaCode.Substring(0, 4) + "00";
                            td.Level = 3;
                            td.hasChildren = false;
                            td.complete = true;
                        }
                        nodeList.Add(td);
                    }
                }
            }


            return Content(nodeList.ToJson());
        }
        #region GIS图层相关
        /// <summary>
        /// 获取GIS图层树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetGISLayerTree()
        {
            string xmlPath = ConfigurationManager.AppSettings.Get("GISLayer");
            if (string.IsNullOrEmpty(xmlPath))
            {
                return null;
            }
            string appPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"iTelluro.GlobeEngine.ini");
            if (System.IO.File.Exists(appPath))
                System.IO.File.Delete(appPath);
            try
            {
                HttpWebRequest oHttp_Web_Req = (HttpWebRequest)WebRequest.Create(xmlPath);
                Stream oStream = oHttp_Web_Req.GetResponse().GetResponseStream();
                using (StreamReader respStreamReader = new StreamReader(oStream, Encoding.UTF8))
                {
                    string line = string.Empty;
                    while ((line = respStreamReader.ReadLine()) != null)
                    {
                        UTF8Encoding utf8 = new UTF8Encoding(false);
                        //写txt文件  
                        using (StreamWriter sw = new StreamWriter(appPath, true, utf8))
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            IConfigSource pConfigSource = null;

            if (System.IO.File.Exists(appPath))
            {
                pConfigSource = new IniConfigSource(appPath);
            }
            IConfig icDataLayers = pConfigSource.Configs["DataLayers"];
            List<GISLayer> dataLayers = new List<GISLayer>();
            StringBuilder sbTree = new StringBuilder();
            string msg = string.Empty;
            if (icDataLayers != null)
            {
                foreach (string key in icDataLayers.GetKeys())
                {
                    try
                    {
                        GISLayer globe = new GISLayer();
                        string[] properties = null;
                        properties = icDataLayers.GetString(key).Split(',');
                        globe.LayerName = key.Trim();
                        globe.LayerUrl = properties[0].Trim();
                        globe.LayerService = properties[2].Trim();
                        globe.Coordinate = UtilityConvert.StringToDecimal(properties[3].Trim());
                        globe.Level = UtilityConvert.StringToInt(properties[4].Trim());
                        globe.IsChecked = Convert.ToBoolean(properties[10].Trim());
                        globe.GroupType = properties[11].Trim();
                        if (properties.Length > 14)
                        {
                            globe.Legend = properties[14].Trim();
                        }
                        else
                        {
                            globe.Legend = string.Empty;
                        }
                        globe.MinX = properties[5].Trim();
                        globe.MinY = properties[6].Trim();
                        globe.MaxX = properties[7].Trim();
                        globe.MaxY = properties[8].Trim();
                        globe.FileExt = properties[9].Trim();
                        globe.BdUrl = properties[1].Trim();
                        dataLayers.Add(globe);
                    }
                    catch (Exception ex)
                    {
                        msg += key + ":" + ex.Message + ",";
                    }
                }
            }
            msg = msg.TrimEnd(',');
            CNode rootNode = CreateTree(dataLayers);
            string nodestring = "[";
            int count = 0;
            foreach (CNode node in rootNode.Nodes)
            {
                nodestring += node.ToJsonString(count.ToString()) + ",";
                count++;
            }
            nodestring = nodestring.TrimEnd(',');
            nodestring += "]";

            object v = new { TreeJson = nodestring, Layers = dataLayers, Msg = msg };
            return ToJsonResult(v);
        }

        private CNode CreateTree(List<GISLayer> dataLayers)
        {
            CNode node = new CNode("根节点", "根节点");
            try
            {
                foreach (GISLayer entity in dataLayers)
                {
                    string[] groups = entity.GroupType.Split(new char[] { '\\', '/' });
                    CNode tempNode = node;
                    int i = 0;
                    foreach (string group in groups)
                    {
                        string key = GetKey(i, groups);
                        if (!tempNode.IsExisitKey(key))
                        {
                            CNode newNode = new CNode(key, group);
                            tempNode.Nodes.Add(newNode);
                            tempNode = newNode;
                        }
                        else
                        {
                            tempNode = tempNode.GetNode(key);
                        }
                        i++;
                        if (groups.Length == i)
                        {
                            if (!tempNode.IsExisitKey(entity.LayerService))
                            {
                                CNode newNode = new CNode(entity.LayerService, entity.LayerName);
                                newNode.Tag = entity;
                                tempNode.Nodes.Add(newNode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return node;
        }

        private string GetKey(int index, string[] values)
        {
            string key = string.Empty;
            if (values != null)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    key += values[i] + "#";

                    if (i == index)
                    {
                        break;
                    }
                }
            }
            return key.TrimEnd(',');
        }

        #endregion
    }
    public class Treenode2
    {
        public bool complete { get; set; }
        public bool hasChildren { get; set; }
        public string id { get; set; }
        public bool isexpand { get; set; }
        public string parentId { get; set; }
        public bool showcheck { get; set; }
        public string text { get; set; }
        public string value { get; set; }
        public object ChildNodes { get; set; }
    }
    public class GisInfo
    {
        public GisBaseInfo baseMap { get; set; }

        public GisBaseInfo statelliteMap { get; set; }

        public GisLayerInfo proviceMap { get; set; }

        public string gisLayer { get; set; }
        public List<MapRangeInfo> mapRanges { get; set; }
    }

    public class GisBaseInfo
    {
        public GisLayerInfo map { get; set; }

        public GisLayerInfo note { get; set; }
    }

    public class GisLayerInfo
    {
        public int zoomlevel { get; set; }

        public string url { get; set; }

        public string dataserverkey { get; set; }

        public int tilesize { get; set; }

        public int ischecked { get; set; }

        public double zerolevelsize { get; set; }

        public double opacity { get; set; }

        public override string ToString()
        {
            return "{" + string.Format("'zoomlevel':{0},'url':'{1}','dataserverkey':'{2}','tilesize':{3},'ischecked':{4},'zerolevelsize':{5}", zoomlevel, url, dataserverkey, tilesize, ischecked, zerolevelsize) + "}";
        }
    }

    #region GIS图层相关
    /// <summary>
    /// GIS图层属性类
    /// </summary>
    public class GISLayer
    {

        private string _layerName;
        private string _layerUrl;
        private string _layerService;
        private decimal? _coordinate;
        private int? _level;
        private bool _isChecked;
        private string _groupType;
        private string _legend;
        private string _minX;
        /// <summary>
        /// 最小X
        /// </summary>
        public string MinX
        {
            get { return _minX; }
            set { _minX = value; }
        }
        private string _minY;
        /// <summary>
        /// 最小Y
        /// </summary>
        public string MinY
        {
            get { return _minY; }
            set { _minY = value; }
        }
        private string _maxX;
        /// <summary>
        /// 最大X
        /// </summary>
        public string MaxX
        {
            get { return _maxX; }
            set { _maxX = value; }
        }
        private string _maxY;
        /// <summary>
        /// 最大Y
        /// </summary>
        public string MaxY
        {
            get { return _maxY; }
            set { _maxY = value; }
        }
        private string _bdUrl;
        /// <summary>
        /// 本地路径
        /// </summary>
        public string BdUrl
        {
            get { return _bdUrl; }
            set { _bdUrl = value; }
        }
        private string _fileExt;
        /// <summary>
        /// 后缀名
        /// </summary>
        public string FileExt
        {
            get { return _fileExt; }
            set { _fileExt = value; }
        }


        /// <summary>
        /// 图例
        /// </summary>
        public string Legend
        {
            get { return _legend; }
            set { _legend = value; }
        }


        /// <summary>
        /// 类别
        /// </summary>
        public string GroupType
        {
            get { return _groupType; }
            set { _groupType = value; }
        }

        /// <summary>
        /// 是否初始化显示
        /// </summary>
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }

        /// <summary>
        /// 数据集总级数
        /// </summary>
        public int? Level
        {
            get { return _level; }
            set { _level = value; }
        }

        /// <summary>
        /// 零级大小
        /// </summary>
        public decimal? Coordinate
        {
            get { return _coordinate; }
            set { _coordinate = value; }
        }

        /// <summary>
        /// 图层服务Key
        /// </summary>
        public string LayerService
        {
            get { return _layerService; }
            set { _layerService = value; }
        }

        /// <summary>
        /// 图层URL
        /// </summary>
        public string LayerUrl
        {
            get { return _layerUrl; }
            set { _layerUrl = value; }
        }

        /// <summary>
        /// 图层显示名称
        /// </summary>
        public string LayerName
        {
            get { return _layerName; }
            set { _layerName = value; }
        }
    }

    #endregion
    /// <summary>
    /// 范围信息
    /// </summary>
    public class MapRangeInfo
    {
        /// <summary>
        /// 最低值
        /// </summary>
        public double RangeLow { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public double RangeHigh { get; set; }

        /// <summary>
        /// 范围名称
        /// </summary>
        public string RangeName { get; set; }
    }
}