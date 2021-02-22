﻿using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Entity.SystemManage;
using Nancy.Responses.Negotiation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infoearth.Application.AppSerivce.Modules
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：陈彬彬
    /// 日 期：2016.05.19 13:57
    /// 描 述：获取行政区域信息
    /// </summary>
    public class AreaModule : BaseModule
    {
        private AreaBLL areaBLL = new AreaBLL();
        public AreaModule()
            : base("/learun/api")
        {
            Post["/area/list"] = List;
        }
        /// <summary>
        /// 获取区域行政列表列表（省分和城市）
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator List(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = areaBLL.GetAreaList("0");
                    Dictionary<string, AreaInfo> dAreaName = new Dictionary<string, AreaInfo>();
                    foreach (var item in data)
                    {
                        AreaInfo areaInfoitem = new AreaInfo();
                        areaInfoitem.areaName = item.F_AreaName;
                        areaInfoitem.children = new Dictionary<string, string>();
                        var itemData = areaBLL.GetAreaList(item.F_AreaCode);
                        foreach (var item1 in itemData)
                        {
                            if (!areaInfoitem.children.ContainsKey(item1.F_AreaCode))
                            {
                                areaInfoitem.children.Add(item1.F_AreaCode, item1.F_AreaName);
                            }
                        }
                        if (!dAreaName.ContainsKey(item.F_AreaCode))
                        {
                            dAreaName.Add(item.F_AreaCode, areaInfoitem);
                        }
                    }
                    return this.SendData<Dictionary<string, AreaInfo>>(dAreaName, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }
    }

    public class AreaInfo {
        /// <summary>
        /// 名称
        /// </summary>
        public string areaName { get; set; }

        public Dictionary<string, string> children { get; set; }
    
    }
}