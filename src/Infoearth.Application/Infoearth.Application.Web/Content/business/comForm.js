var accesscode = GetConfig("DefalutCode"), SSOURL = GetConfig("SSOWWUrl");
//获取配置文件
var DefalutCode = accesscode;
var DefalutName = GetConfig("DefalutName");
var WebApiResultWrap = GetConfig("WebApiResultWrap");
var code = accesscode;
var DefalutAreaName = GetConfig("DefalutAreaName");
function GetConfig(keyvalue) {
    var returnValue;
    var globalConfig = getInfoTop().learun.data.get(["globalConfig"]);
    if (globalConfig) {
        returnValue = globalConfig[keyvalue];
    } else {
        $.ajax({
            url: "/Utility/GetAppSetting",
            async: false, //同步请求
            data: { key: keyvalue },
            type: "GET",
            success: function (data) {
                returnValue = data;
            }
        });
    }
    return returnValue;
}
//读取cookies
function getCookie(name) {
    var strCookie = document.cookie;
    var cookieArray = strCookie.split('; ');
    for (var i = 0; i < cookieArray.length; i++) {
        var key = cookieArray[i].split('=')[0];
        var value = cookieArray[i].split('=')[1];
        if (key == name) {
            return unescape(value);
        }
    }
    return null;
}

//读取
function getAuthorizationToken() {
    var strCookie = document.cookie;
    var cookieArray = strCookie.split('; ');
    for (var i = 0; i < cookieArray.length; i++) {
        var key = cookieArray[i].split('=')[0];
        var value = cookieArray[i].split('=')[1];
        if (key == 'Token') {
            value = unescape(value);
            //去掉逗号、用户名
            value = value.split(',')[0];
            //md5加密、转大写
            value = $.md5(value).toUpperCase();
            return value;
        }
    }
    return null;
}
//获取当前登录用户的行政区划 省
function usercodes1() {
    var a = "[0]";
    a =JSON.stringify(a);
    var usercode = { provinceId: '', selectCityId: '' };
    if (sessionStorage.getItem(Account)) {
        usercode = JSON.parse(sessionStorage.getItem(Account));
    } else {
        $.ajax({
            //url: SSOURL + "api/AdministrativeApi/GetAuthDistrictData",
            url: SSOURL + "api/AdministrativeApi/GetAreaListJsonWithAuth/0",
            type: 'GET',
            beforeSend: function (request) {
                request.setRequestHeader("Authorization", authToken);
            },
            async: false,
            success: function (data) {
                if (WebApiResultWrap) {
                    data = data.Result;
                }
                var dataList = learun.jsonWhere(data, function (item) {
                    if (item.DistrictCode.substr(2, 4) == "0000") {
                        return true
                    }
                })
                var dataList2 = learun.jsonWhere(data, function (item) {
                    if (item.DistrictCode.substr(4, 2) == "00") {
                        return true
                    }
                })
                for (i in dataList) {
                    usercode.provinceId += dataList[i].DistrictCode + ',';
                }
                usercode.provinceId = usercode.provinceId.substr(0, usercode.provinceId.length - 1);
                if (dataList2.length == 1 && dataList2[0].DistrictCode.substr(0, 2) != "00") {
                    usercode.provinceId = dataList2[0].DistrictCode.substr(0, 2) + "0000"
                    usercode.selectCityId = dataList2[0].DistrictCode;
                }
            }
        })
        if (usercode.provinceId == "000000") {
            usercode.provinceId = "";
        }
        sessionStorage.setItem(Account, JSON.stringify(usercode));
    }
    return usercode;
}
function usercodes() {
    if (XZQHCode.substr(2, 4) == "0000") {
        XZQHCode = "0";
    }else if (XZQHCode.substr(4, 2) == "00") {
        XZQHCode = XZQHCode.substr(0,2)+"0000";
    }else {
        XZQHCode = XZQHCode.substr(0, 4) + "00";
    }
    var usercode = { provinceId: '', selectCityId: '', selectCounty: '' };
    if (sessionStorage.getItem(Account)) {
        usercode = JSON.parse(sessionStorage.getItem(Account));
    } else {
        $.ajax({
            url: SSOURL + "api/AdministrativeApi/GetAreaListJsonWithAuth/" + XZQHCode,
            type: 'GET',
            beforeSend: function (request) {
                request.setRequestHeader("Authorization", authToken);
            },
            async: false,
            success: function (data) {
                if (WebApiResultWrap) {
                    data = data.Result;
                }
                var dataList = learun.jsonWhere(data, function (item) {
                    if (item.F_AreaCode.substr(2, 4) == "0000") {
                        return true
                    }
                })
                var dataList2 = learun.jsonWhere(data, function (item) {
                    if (item.F_AreaCode.substr(4, 2) == "00" && item.F_AreaCode.substr(2, 4) != "0000") {
                        return true
                    }
                });
                var dataList3 = learun.jsonWhere(data, function (item) {
                    if (item.F_AreaCode.substr(4, 2) != "00") {
                        return true
                    }
                })
                for (i in dataList) {
                    usercode.provinceId += dataList[i].F_AreaCode + ',';
                }
                usercode.provinceId = usercode.provinceId.substr(0, usercode.provinceId.length - 1);
                if (dataList2.length == 1 && dataList2[0].F_AreaCode.substr(0, 2) != "00") {
                    usercode.provinceId = dataList2[0].F_AreaCode.substr(0, 2) + "0000";
                    usercode.selectCityId = dataList2[0].F_AreaCode.substr(0, 4) + "00";
                }
                if (dataList2.length == 0 && dataList.length == 0) {
                    if (dataList3.length == 1 && dataList3[0].F_AreaCode.substr(4, 2) != "00") {
                        usercode.provinceId = dataList3[0].F_AreaCode.substr(0, 2) + "0000";
                        usercode.selectCityId = dataList3[0].F_AreaCode.substr(0, 4) + "00";
                        usercode.selectCounty = dataList3[0].F_AreaCode.substr(0, 6);
                    } else {
                        usercode.provinceId = data[0].F_AreaCode.substr(0, 2) + "0000";
                        usercode.selectCityId = data[0].F_AreaCode.substr(0, 4) + "00";
                    }
                }
                if (dataList.length == 34) {
                    usercode.provinceId = 0;
                }
            }
        })
        //if (usercode.provinceId == "000000") {
        //    usercode.provinceId = "";
        //}
       
        sessionStorage.setItem(Account, JSON.stringify(usercode));
    }
    return usercode;
}
//统一编号控件调用
function cfBtn_select(callFunc) {
    dialogOpen({
        id: 'Form2',
        title: '获取统一编号',
        url: '/KSCJ/SelectKS',
        width: '900px',
        height: '460px',
        isClose: true,
        callBack: function (iframeId) {
            var selectedRowIndex = getInfoTop().frames[iframeId].$('#gridTable').getGridParam('selrow');
            var dt = getInfoTop().frames[iframeId].$('#gridTable').jqGrid("getRowData", selectedRowIndex);
            $("#TYBH").val(dt.TYBH);
            $("#KSMC").val(dt.KQKM);
            $("#KQYW").val(dt.KQYW);
            if (callFunc) {
                callFunc(dt);
            }
        }
    });
}


function cfInitComboBox(comboId, url) {
    $("#" + comboId).ComboBox({
        url: url,
        id: "value",
        text: "text",
        height: '200px'
    });
}
//判断必填项是否为空，requiredIdLst：是必填项ID数组
function cfJudgeRequired(requiredIdLst, postData) {
    for (var i in requiredIdLst) {
        var item = requiredIdLst[i];
        if (postData[item] == "") {
            alert("有星号内空没有填");
            return false;
        }
    }
    return true;
}


//合计功能，idLst: 要算合计的id数据，sumId：合计放入的input框ID
function cfSumInputChange(idLst, sumId) {
    for (var i in idLst) {
        $("#" + idLst[i]).change(function () {
            var hj = 0;
            for (var i in idLst) {
                var s = $("#" + idLst[i]).val();
                if (s && s != "") {
                    hj += parseFloat(s);
                }
            }
            $("#" + sumId).val(hj);
        });
    }
}

//根据字典项，动态生成radio 或check  button代码
function cfInitControlRadioOrCheck(id, dicCode, type, addBr, html, index, indexBr) {
    $.ajax({
        url: "../../SystemManage/DataItemDetail/GetDataItemTreeJson?EnCode=" + dicCode,
        async: false,
        success: function (data) {
            var dataDMLX = eval(data);
            if (addBr) {
                var last = dataDMLX.length - 1;
                for (var i = 0; i < last; i++) {
                    $("#" + id).append("<label><input  type=\"" + type + "\" name=\"" + id + "\" value=\"" + dataDMLX[i].value + "\" />" + dataDMLX[i].text + "</label><Br />");
                }
                $("#" + id).append("<label><input  type=\"" + type + "\" name=\"" + id + "\" value=\"" + dataDMLX[last].value + "\" />" + dataDMLX[last].text + "</label>");
            }
            else if (html) {
                for (var i = 0; i < dataDMLX.length; i++) {
                    if (index && index - 1 == i) {
                        $("#" + id).append("<label><input  type=\"" + type + "\" name=\"" + id + "\" value=\"" + dataDMLX[i].value + "\" />" + dataDMLX[i].text + "</label>");
                        $("#" + id).append(html);
                    } else if (!index && i == dataDMLX.length - 1) {
                        $("#" + id).append("<label><input  type=\"" + type + "\" name=\"" + id + "\" value=\"" + dataDMLX[i].value + "\" />" + dataDMLX[i].text + "</label>");
                        $("#" + id).append(html);
                    }
                    else {
                        $("#" + id).append("<label><input  type=\"" + type + "\" name=\"" + id + "\" value=\"" + dataDMLX[i].value + "\" />" + dataDMLX[i].text + "</label>");
                    }

                    if (indexBr && indexBr == i) {
                        $("#" + id).append("<Br />");
                    }

                }
            }
            else {
                for (var i = 0; i < dataDMLX.length; i++) {
                    $("#" + id).append("<label><input  type=\"" + type + "\" name=\"" + id + "\" value=\"" + dataDMLX[i].value + "\" />" + dataDMLX[i].text + "</label>");
                }
            }
        }, error: function (e) {
        },
        cache: false
    });
}

//列表中，取字段对应的字典中文名
function cfDicFormat(cellvalue, options, rowObject, dicCode) {
    var _value = [];
    if (cellvalue) {
        var array = cellvalue.split(",");
        for (var i = 0; i < array.length; i++) {
            var item = array[i];
            _value.push(getInfoTop().learun.data.get(["dataItem", dicCode, item]))
        }
    }
    return String(_value)
}
//回车查询
function KeyDown(id) {
    if (event.keyCode == 13) {
        event.returnValue = false;
        event.cancel = true;
        $("#" + id).click();
    }
}
var modeId_MonitorObject = "86343CDB-BCA2-4083-87A6-6E6AD38CCC5E";//监测点

//初始化多媒体页
function cfInitMultiMedia(mediaId, modeId, belongId) {
    var height = $(window).height() - 60;
    var url = "/SystemManage/MultMedia/Index?SaveIsHidden=true&moduleID=" + modeId + "&belongObjectGuid=" + belongId;
    $("#" + mediaId).html("<iframe frameborder='0' id ='frmMultimedia' scrolling='no' src='" + url + "'style='width:100%;height:" + height + "px;'><iframe>");
}
//初始化多媒体页
function cfInitMultiMedias(mediaId, modeId, belongId, details) {
    var height = $(window).height() - 60;
    var url = "/SystemManage/MultMedia/Index?SaveIsHidden=true&moduleID=" + modeId + "&belongObjectGuid=" + belongId + "&details=" + details;
    $("#" + mediaId).html("<iframe frameborder='0' id ='frmMultimedia' scrolling='no' src='" + url + "'style='width:100%;height:" + height + "px;'><iframe>");
}

////////////////////////////////////////////////////////////////////////照片记录 遥感影像记录
var modeId_Question = "fddeed1c-d4f8-438a-98be-28cbca206671";//矿山问题
var modeId_BaseInfo = "fddeed1c-d4f8-438a-98be-28cbca206671";//矿山基本信息
var modeId_Avalanche = "b33b8ef2-cdb8-5e3a-951b-f73125ba1c13";//崩塌（应急预案）
var modeId_Landslip = "13b9c8c0-039c-bfe7-f631-b97dda76c56d";//滑坡
var modeId_Debrisflow = "7EA5B92C-7D80-49E4-84E6-9634D7C268F5";//泥石流
var modeId_CollapseandLandcrack = "2419D71A-98DA-4351-AA5C-C1CF5F6F9B96";//地面塌陷,地裂缝
var modeId_AquiferInfo = "35E9271A-98DA-4351-AA5C-C1CF5F6F9B96";//地下含水层影响破坏
var modeId_TerrainInfo = "7F18E51B-98DA-4351-AA5C-C1CF5F6F9B96";//地形地貌景观破坏
var modeId_WasteInfo = "6EB1831B-98DA-4351-AA5C-C1CF5F6F9B96";//废水废液固液
var modeId_WasteGather = "90E2F8E2-98DA-4351-AA5C-C1CF5F6F9B96";//水质样品
var modeId_SoilGather = "2419D71A-98DA-4351-AA5C-C1CF5F6F9B96";//土壤样品
var modeId_KJInfo = "83C7F5B8-5C73-48cc-9B90-449D947FD98F";//矿井
var modeId_ZLGCInfo = "7761ab3a-1cda-4fbb-3923-c87399c17626";//治理工程
var modeId_CKQInfo = "78DC9B1A-870D-47F4-B7EB-083212890E4E";//采空区
var modeId_Dzqunce = "28faccd1-4d78-4caf-b904-df74e772e076"//地灾群测群防
var modeId_FZGHInfo = "78DC9B1A-AABC-47F4-B7EB-083212890E4E";
var moduledClassZP = "790C8F14-DB5A-4706-9ED7-E2278BDF5BF7";
var moduledClassYGXY = "790C8F14-DB5A-4706-9ED7-E2278BDF5BF8";
var moduledClassPouM = "47EAFD4B-7832-403D-B201-7FC8194E6547";//剖面
var moduledClassPingM = "4C2BF8BD-FD31-46C8-A6BA-8704582C5D7B";//平面
function cfUPfile(divId, moduledClassID) {
    learun.dialogOpen({
        id: "FileSelectForm",
        title: '附件列表',
        url: '/SystemManage/MultMedia/FileSelectForm?folderId=' + moduledClassID,
        width: "800px",
        height: "600px",
        isClose: true,
        callBack: function (iframeId) {
            var rowData = getInfoTop().frames[iframeId].selectFileData;
            if (rowData.length) {
                for (var i = 0; i < rowData.length; i++) {
                    var fileGuid = rowData[i].GUID;
                    var fileName = rowData[i].FILENAME;
                    var node = moduledClassID + "#" + fileGuid;
                    var index = $("#frmMultimedia")[0].contentWindow.addFiles.indexOf(node);
                    var index1 = $("#frmMultimedia")[0].contentWindow.existFiles.indexOf(node);
                    if (index <= -1 && index1 <= -1) {
                        $("#frmMultimedia")[0].contentWindow.addFiles.push(node);
                        var html = getUPHTML(fileGuid, fileName, moduledClassID);
                        $("#" + divId).append(html);
                    }
                }
            }
            return true;
        }
    });
}
function getUPHTML(fileGuid, fileName, moduledClassID, businessID) {
    //var html = "<sapn><a class='btn btn-default' onclick=\"ShowPIC('" + fileGuid + "','" + fileName + "')\"'>" + fileName + "</a><a  class='btn btn-default' value='" + fileGuid + "'  moduledClassID='" + moduledClassID + "' onclick='delFile(this)'><i class=\"fa fa-trash-o\"></i>删除</a></span>";
    var html = "";
    if (businessID) {
        html = " <div style=\"float:left;margin-left:10px;margin-top:5px;\"> <div style=\"float:left;cursor:pointer;\" onclick=\"ShowPIC('" + fileGuid + "','" + fileName + "')\">" + fileName + "</div><div class=\"div_close\" value='" + fileGuid + "'  moduledClassID='" + moduledClassID + "' businessID='" + businessID + "'  onclick='delFile(this)'></div></div>";
    }
    else {
        html = " <div style=\"float:left;margin-left:10px;margin-top:5px;\"> <div style=\"float:left;cursor:pointer;\" onclick=\"ShowPIC('" + fileGuid + "','" + fileName + "')\">" + fileName + "</div><div class=\"div_close\" value='" + fileGuid + "'  moduledClassID='" + moduledClassID + "'  onclick='delFile(this)'></div></div>";
    }
    return html;
}
function delFile(obj) {
    var fileGuid = $(obj).attr("value");
    var moduledClassID = $(obj).attr("moduledClassID");
    var node = moduledClassID + "#" + fileGuid;
    var businessID = $(obj).attr("businessID");
    if (businessID) {
        $("#frmMultimedia")[0].contentWindow.deleteFiles.push(businessID);
    }
    $("#frmMultimedia")[0].contentWindow.addFiles.remove(node);
    $(obj).parent().remove();

}
function showMedia(divId, ClassID, moduleID, belongGuid) {
    if ($("#" + divId).length = 0) {
        return;
    }
    $.ajax({
        url: "/SystemManage/MultMedia/FindMedInfoListAndClassID",
        async: false,
        type: "POST",
        data: {
            moduleID: moduleID,
            belongObjectGuid: belongGuid,
            ClassID: ClassID
        },
        success: function (data) {
            $("#" + divId).empty();
            var dataList = JSON.parse(data);
            for (var i = 0; i < dataList.length; i++) {
                var html = getUPHTML(dataList[i].FILEINFOGUID, dataList[i].FILENAME, ClassID, dataList[i].BUSSNISSFILEINFOGUID);
                $("#" + divId).append(html);
            }
        }, error: function (e) {
        },
        cache: false
    });
}
function ShowPIC(Guid, fileName) {
    learun.dialogOpen({
        id: 'FileSelectForm',
        title: '预览',
        url: '/SystemManage/MultMedia/Show?fileGuid=' + escape(Guid) + '&fileName=' + escape(fileName),
        width: "90%",
        height: "100%",
        btn: null
    });
}
function cfupfile(id) {
    if (id == "divZPJL") {
        cfUPfile(id, moduledClassZP);
    }
    else if (id == "divYGYXJL") {
        cfUPfile(id, moduledClassYGXY);
    }
    else if (id == "divPoumian") {
        cfUPfile(id, moduledClassPouM);
    }
    else if (id == "divPingmian") {
        cfUPfile(id, moduledClassPingM);
    } else if (id == "TPBH") {
        cfUPfile(id, moduledClassZP);
    }
    else if (id == "YXBH") {
        cfUPfile(id, moduledClassYGXY);
    }
    else if (id == "divPoumian") {
        cfUPfile(id, moduledClassPouM);
    }
    else if (id == "PMT") {
        cfUPfile(id, moduledClassPingM);
    }
}
//删除关联多媒体信息
function cfRemoveMediaInfo(moduleID, belongGuid, parmData) {
    if (parmData) {
        $.ajax({
            url: '../../MineMonitorManage/TBL_MINE_BASEINFO/RemoveMediaInfo',
            data: parmData,
            type: "post",
            async: false,
            success: function (data) {

            }, error: function (e) {
            },
            cache: false
        })
    } else {
        $.ajax({
            url: "../../SystemManage/MultMedia/RemoveMediaInfo",
            data: { "moduleID": moduleID, "belongObjectGuid": belongGuid },
            type: "post",
            async: false,
            success: function (data) {

            }, error: function (e) {
            },
            cache: false
        })
    }

}
////////////////////////////////////////////////////////////////////////
//取拐点的第一个点的坐标
function cfGDZBFirstDot(gdzb) {
    var dot = [];
    if (!gdzb) return null;
    var dot = gdzb.split(";")[0];
    dot = dot.split(":")[1];
    if (!dot) return null;
    dot = dot.split(",");
    if (!dot || dot.length != 2) return null;
    dot[0] = parseFloat(dot[0]);
    dot[1] = parseFloat(dot[1]);
    return dot;
}

//在地图上显示拐点图形
function cfShowGDZBArea(gdzb, mapCtlExt, popHtml) {
    if (!gdzb) return;
    var polygon = [];
    var dots = gdzb.split(";");

    for (var i = 0; i < dots.length; i++) {
        var pt = dots[i].split(":")[1];
        if (pt) {
            pt = pt.split(",");
            var lon = parseFloat(pt[0]);
            var lat = parseFloat(pt[1]);
            polygon.push([lon, lat]);
        }
    }
    mapCtlExt.addTagging("MultiPolygon", polygon, popHtml);
}
function cfShowGDZBAreaArr(GDZBArr, mapCtlExt) {
    if (!GDZBArr) return;
    for (var GD = 0; GD < GDZBArr.length; GD++) {
        var dots = GDZBArr[GD].coordinates.split(";");
        var polygon = [];
        for (var i = 0; i < dots.length; i++) {
            var pt = dots[i].split(":")[1];
            if (pt) {
                pt = pt.split(",");
                if (pt.length > 1) {
                    try {
                        var lon = parseFloat(pt[0]);
                        var lat = parseFloat(pt[1]);
                        if (lon && lat) {
                            polygon.push([lon, lat]);
                        }
                    } catch (e) {
                        console.log(e.message);
                    }
                }
            }
        }
        GDZBArr[GD].coordinates = polygon;
    }
    mapCtlExt.addTaggingArr(GDZBArr);
}
function cfShowGDZBAreaArr2(GDZBArr, mapCtlExt) {
    if (!GDZBArr) return;
    for (var GD = 0; GD < GDZBArr.length; GD++) {
        var dots = GDZBArr[GD].coordinates.split(",");
        var polygon = [];
        for (var i = 0; i < dots.length; i++) {
            var pt = dots[i];
            if (pt) {
                pt = pt.split(" ");
                if (pt.length > 1) {
                    try {
                        var lon = parseFloat(pt[0]);
                        var lat = parseFloat(pt[1]);
                        if (lon && lat) {
                           polygon.push([lon, lat]);
                        }
                    } catch (e) {
                        console.log(e.message);
                    }
                }
            }
        }
        GDZBArr[GD].coordinates = polygon;
    }
    mapCtlExt.addTaggingArr(GDZBArr);
}
function setCenterByGDZB(gdzb) {
    try {
        if (!gdzb) return;
        var polygon = [];
        var dots = gdzb.split(";");

        for (var i = 0; i < dots.length; i++) {
            var pt = dots[i].split(":")[1];
            if (pt) {
                pt = pt.split(",");
                var lon = parseFloat(pt[0]);
                var lat = parseFloat(pt[1]);
                polygon.push([lon, lat]);
            }
        }
        if (map.getView().getZoom() < 8) {
            map.getView().setZoom(8);
        }
        map.getView().setCenter([polygon[0][0], polygon[0][1]]);
    } catch (e) {

    }
}

//拐点坐标转wkt字符串
function GDZB2Wkt(gdzb) {
    var wkt = "POLYGON ((";
    var dots = gdzb.split(";");

    for (var i = 0; i < dots.length; i++) {
        var pt = dots[i].split(":")[1];
        if (pt) {
            pt = pt.split(",");
            var lon = parseFloat(pt[0]);
            var lat = parseFloat(pt[1]);
            wkt += lon + " " + lat + ",";
        }
    }
    wkt = wkt.substr(0, wkt.length - 1);
    wkt += "))";
    if (wkt.length < 30)
        return "";
    return wkt;
}

function cfGetDicData(dicCode) {
    var returnValue;
    $.ajax({
        url: "../../SystemManage/DataItemDetail/GetDataItemTreeJson?EnCode=" + dicCode,
        async: false,
        success: function (data) {
            returnValue = eval(data);

        }, error: function (e) {
        },
        cache: false
    });
    return returnValue;
}

//---------------------地质环境问题页面新增传参
function GetKSInfoByTYBH(keyValue) {
    var cfRequestData = [];
    $.ajax({
        url: "../../MineMonitorManage/TBL_MINE_BASEINFO/GetFormJson",
        data: { keyValue: keyValue },
        async: false,
        type: "get",
        dataType: "json",
        cache: false,
        success: function (obj) {
            cfRequestData["TYBH"] = obj.TYBH;//统一编号
            cfRequestData["KSMC"] = obj.KQKM;//矿山名称
            cfRequestData["YWBH"] = obj.KQYW;//野外编号
            cfRequestData["KQYW"] = obj.KQYW;
            cfRequestData["DCDW"] = obj.KQTCDW;//调查单位
            cfRequestData["DCR"] = obj.KQDCR;//调查人
            cfRequestData["KQDCR"] = obj.KQDCR;
            cfRequestData["TRQYR"] = obj.KQDCR;
            cfRequestData["SZQYR"] = obj.KQDCR;
            cfRequestData["JLR"] = obj.KQJLR;//记录人
            cfRequestData["KQJLR"] = obj.KQJLR;
            cfRequestData["TRJLR"] = obj.KQJLR;
            cfRequestData["SZJLR"] = obj.KQJLR;
            cfRequestData["SHR"] = obj.KQSHR;//审核人
            cfRequestData["KQSHR"] = obj.KQSHR;
            cfRequestData["TBRQ"] = obj.KQDCSJ;//调表日期
            cfRequestData["KQDCSJ"] = obj.KQDCSJ;
            cfRequestData["FGBH"] = obj.FGBH;
        }
    });
    return cfRequestData;
}
////////////////////////////////矿种矿类多选
function cfInitComboBoxKZKL(KLid, KZid, height, width) {
    if (!height)
        height = 100;
    if (!width) {
        width = 240;
    }
    $("#" + KLid).ComboBox({
        url: "../../SystemManage/DataItemDetail/GetDataItemListJsonByParentId?EnCode=KZKL&parentId=0",
        id: "F_ItemValue",
        text: "F_ItemName",
        height: height + "px",
        width: width + "px"
    }).bind("change", function () {
        var value = $(this).attr('data-value');
        $("#" + KZid)[0].innerHTML = "请选择";
        $("#" + KZid).attr('data-value', '');
        $("#" + KZid).ComboBox({
            url: "../../SystemManage/DataItemDetail/GetDataItemListJsonByParentId",
            param: { EnCode: "KZKL", parentId: value },
            id: "F_ItemValue",
            text: "F_ItemName",
            height: height + "px",
            width: width + "px"
        });
    });
    $("#" + KZid).ComboBox({
        url: "../../SystemManage/DataItemDetail/GetDataItemListJsonByParentId",
        param: { EnCode: "KZKL", parentId: $("#" + KLid).attr('data-value') },
        id: "F_ItemValue",
        text: "F_ItemName",
        height: height + "px",
        width: width + "px"
    });
}

//---------------------------------------------度分秒转换start
//经纬度格式D.DD、DMS.S、DMS.S2:度分秒带符号
var lonlatFormat = 'DMS.S2';

///<summary>将度转换成为度分秒</summary>  
function formatDegree(value, type) {
    if (type) {
        lonlatFormat = type;
    }
    if (value.indexOf("°") != -1) {
        if (lonlatFormat == "DMS.S2" || lonlatFormat == "D°M′S″") {
            return value;
        }
        else {
            //value = value.replace("°", "").replace("′", "").replace("'", "").replace("″", "").replace('"', "");
            value = DegreeConvertBack(value);
        }
    }
    if (value > 360) {
        var du; var fen; var miao;
        if (value.indexOf('.') != -1) {
            miao = Math.abs(value.substr(value.indexOf('.') - 2, value.length - value.indexOf('.') + 2));
            fen = Math.abs(value.substr(value.indexOf('.') - 4, 2));
            du = Math.abs(value.substr(0, value.indexOf('.') - 4));
        }
        else {
            miao = Math.abs(value.substr(value.length - 2, 2));//秒  
            fen = Math.abs(value.substr(value.length - 4, 2));//分  
            du = Math.abs(value.substr(0, value.length - 4));//度 
        }
        if (lonlatFormat == "DMS.S") {
            return Math.abs(du + '' + addZero(fen) + '' + addZero(miao) + '');
        } else if (lonlatFormat == "DMS.S2" || lonlatFormat == "D°M′S″") {
            return Math.abs(du) + '°' + addZero(Math.abs(fen)) + '′' + addZero(Math.abs(miao)) + '″';
        }
        else if (lonlatFormat == "D.DD") {
            return DegreeConvertBack(value);
        }
    } else {
        value = Math.abs(value);
        var v1 = Math.floor(value);//度  
        var v2 = Math.floor(parseFloat((value - v1).toFixed(8)) * 60);//分  
        var v3 = parseFloat(parseFloat(value - v1).toFixed(8) * 3600 % 60).toFixed(2);//秒  
        if (lonlatFormat == "DMS.S") {
            return Math.abs(v1 + '' + addZero(v2) + '' + addZero(v3) + '');
        } else if (lonlatFormat == "DMS.S2" || lonlatFormat == "D°M′S″") {
            return Math.abs(v1) + '°' + addZero(Math.abs(v2)) + '′' + addZero(Math.abs(v3)) + '″';
        }
        else if (lonlatFormat == "D.DD") {
            return value;
        }
        //else {
        //    return Math.abs(v1 + '' + addZero(v2) + '' + addZero(v3) + '');
        //}
    }
};
function addZero(value) {
    if (value <= 9) {
        return '0' + value;
    }
    return value;
}
//判断输入的字符是否为双精度 double
function isDouble(obj) {
    if (obj.length != 0) {
        reg = /^[-\+]?\d+(\.\d+)?$/;
        if (!reg.test(obj)) {
            return false;
        }
        else {
            return true;
        }
    }
}
//验证数据有效性
function cfValidJWD(latitude, longitude) {
    if (!isDouble(latitude) || !isDouble(longitude)) {
        return "数据有误";
    }
    var returnValue = "";
    if (latitude < 34.38277 || latitude > 38.208611) {
        returnValue += "数据有误：";
        returnValue += "纬度范围：34°22′58″~38°12′31″；";
    }

    if (longitude < 114.8 || longitude > 122.672222) {
        returnValue += "经度范围：114°48′00″~122°40′20″；";
    }
    return returnValue;
}
//保存度分秒赋值
function cfDegreeConvert(latitude, longitude, yswd, ysjd) {
    var returnValue = "";
    var convertLatitude = $("#" + yswd).val();
    if (convertLatitude) {
        if ($("#" + yswd).val().indexOf("°") != -1) {
            convertLatitude = DegreeConvertBack($("#" + yswd).val());
        }
        else if ($("#" + yswd).val() > 180) {
            convertLatitude = DegreeConvertBack($("#" + yswd).val());
        }

        if (convertLatitude >= 34.38277 && convertLatitude <= 38.208611) {
            $("#" + latitude).val(convertLatitude);
        }
        else {
            returnValue += "矿山中心坐标数据有误：";
            returnValue += "纬度范围：34°22′58″~38°12′31″；";
        }
    }

    var convertLongitude = $("#" + ysjd).val();
    if (convertLongitude) {
        if ($("#" + ysjd).val().indexOf("°") != -1) {
            convertLongitude = DegreeConvertBack($("#" + ysjd).val());
        }
        else if ($("#" + ysjd).val() > 180) {
            convertLongitude = DegreeConvertBack($("#" + ysjd).val());
        }
        if (convertLongitude >= 114.8 && convertLongitude <= 122.672222) {
            $("#" + longitude).val(convertLongitude);
        }
        else {
            returnValue += "经度范围：114°48′00″~122°40′20″；";
        }
    }

    return returnValue;
}
function DegreeConvertBack(value) { ///<summary>度分秒转换成为度</summary>
    value = $.trim(value);
    var du; var fen; var miao;
    if (value.indexOf("°") != -1) {
        value = value.replace("'", "′").replace('"', '″');
        return DegreeConvertBack2(value);
    }
    else {
        if (value > 180) {
            if (value.indexOf('.') != -1) {
                miao = value.substr(value.indexOf('.') - 2, value.length - value.indexOf('.') + 2);
                fen = value.substr(value.indexOf('.') - 4, 2);
                du = value.substr(0, value.indexOf('.') - 4);
            }
            else {
                miao = value.substr(value.length - 2, 2);
                fen = value.substr(value.length - 4, 2);
                du = value.substr(0, value.length - 4);
            }
            return Math.abs(parseFloat((Math.abs(du) + Math.abs(fen) / 60 + Math.abs(miao) / 3600)).toFixed(8));
        }
        else {
            return value;
        }
    }
}
function DegreeConvertBack2(value) { ///<summary>度分秒转换成为度</summary>
    var du = value.split("°")[0];
    var fen = value.split("°")[1].split("′")[0];
    var miao = value.split("°")[1].split("′")[1].split('″')[0];

    return Math.abs(parseFloat((Math.abs(du) + Math.abs(fen) / 60 + Math.abs(miao) / 3600)).toFixed(8));

}
/////////////////////////////////////////////度分秒转换end
///////------------------------------------------增加标签页start
/**
* 增加标签页
3  */
function addTabs(options) {

    //option:
    //tabMainName:tab标签页所在的容器
    //tabName:当前tab的名称
    //tabTitle:当前tab的标题
    //tabUrl:当前tab所指向的URL地址
    var exists = checkTabIsExists(options.tabMainName, options.tabName);
    if (exists) {
        $("#tab_a_" + options.tabName).click();
    } else {
        $("#" + options.tabMainName).append('<li id="tab_li_' + options.tabName + '"><a href="#tab_content_' + options.tabName + '" data-toggle="tab" id="tab_a_' + options.tabName + '"><button class="close closeTab" type="button" onclick="closeTab(this);">×</button>' + options.tabTitle + '</a></li>');
        //固定TAB中IFRAME高度
        mainHeight = $(document.body).height() - 5;

        var content = '';
        if (options.content) {
            content = options.content;
        } else {
            content = '<iframe src="' + options.tabUrl + '" width="100%" height="' + mainHeight + 'px" frameborder="no" border="0" marginwidth="0" marginheight="0" scrolling="yes" allowtransparency="yes"></iframe>';
        }
        $("#" + options.tabContentMainName).append('<div id="tab_content_' + options.tabName + '" role="tabpanel" class="tab-pane" id="' + options.tabName + '">' + content + '</div>');
        $("#tab_a_" + options.tabName).click();
    }
}


/**
32  * 关闭标签页
33  *   */
function closeTab(button) {
    //通过该button找到对应li标签的id
    var li_id = $(button).parent().parent().attr('id');
    var id = li_id.replace("tab_li_", "");

    //如果关闭的是当前激活的TAB，激活他的前一个TAB
    if ($("li.active").attr('id') == li_id) {
        $("li.active").prev().find("a").click();
    }

    //关闭TAB
    $("#" + li_id).remove();
    $("#tab_content_" + id).remove();
    //移除导出excel数据
    if (excelArr) {
        for (var i = 0; i < excelArr.length; i++) {
            if (excelArr[i].id == id) {
                excelArr.splice(i, 1);
            }
        }
    }
};
function closeTabByID(tabID) {

    //通过该tabID找到对应li标签的id
    var li_id = tabID;
    var id = li_id.replace("tab_li_", "");

    //如果关闭的是当前激活的TAB，激活他的前一个TAB
    if ($("li.active").attr('id') == li_id) {
        $("li.active").prev().find("a").click();
    }

    //关闭TAB
    $("#" + li_id).remove();
    $("#tab_content_" + id).remove();
};
/**
* 判断是否存在指定的标签页
*  tabMainName
* param tabName
* returns {Boolean}
*/ function checkTabIsExists(tabMainName, tabName) {
    var tab = $("#" + tabMainName + " > #tab_li_" + tabName);
    //console.log(tab.length)
    return tab.length > 0;
}

function pageInit(id, colModel, mydata, hbCol, hbColName, type) {
    $("#" + id).jqGrid(
        {
            datatype: "local",
            shrinkToFit: false,
            colModel: colModel,
            gridComplete: function () {
                if (hbColName) {
                    if (type) {
                        MergerStatistics2(id, hbColName, mydata.length);
                    }
                    else {
                        MergerStatistics(id, hbColName, mydata.length);
                    }

                }
            }
        });
    for (var i = 0; i <= mydata.length; i++) {
        $("#" + id).jqGrid('addRowData', i + 1, mydata[i]);
    }
    if (hbCol) {
        $("#" + id).jqGrid('setGroupHeaders', {
            useColSpanStyle: true,
            groupHeaders: hbCol
        });
    }
    if (mydata.length > 0) {
        $(".unwritten").hide();
    }
}
//含有小计合并
function MergerStatistics(gridName, CellName, dataCount) {
    //得到显示到界面的id集合
    var mya = $("#" + gridName + "").getDataIDs();
    //当前显示多少条
    var length = mya.length;
    var rowSpanTaxCount = 1; var startRow = 0;
    if (length < dataCount) {
        return;
    }
    for (var i = 0; i < length; i++) {
        //从上到下获取一条信息
        var cellValue = $("#" + gridName + "").jqGrid('getRowData', mya[i]);

        if (startRow != i) {
            $("#" + gridName + "").setCell(mya[i], CellName, '', { display: 'none' });
        }
        if (cellValue[CellName] && cellValue[CellName].indexOf("小计") != -1) {
            $("#" + gridName + "MergerRow" + (startRow + 1) + "").attr("rowspan", rowSpanTaxCount);//最后合并需要合并的行与合并的行数
            $("#" + gridName + "MergerRow" + (startRow + 1) + "").text(cellValue[CellName].replace("小计", "").replace("(", "").replace(")", ""));
            startRow += rowSpanTaxCount;
            rowSpanTaxCount = 1;
        }
        else if (cellValue[CellName] && cellValue[CellName].indexOf("合计") != -1) {
            $("#" + gridName + "MergerRow" + (startRow + 1) + "").attr("rowspan", rowSpanTaxCount);//最后合并需要合并的行与合并的行数
            $("#" + gridName + "MergerRow" + (startRow + 1) + "").text("总计");
            startRow += rowSpanTaxCount;
            rowSpanTaxCount = 1;
        }
        else {
            rowSpanTaxCount++;
        }

    }
    $("#" + gridName + "").jqGrid('setLabel', CellName, '&nbsp;', { 'text-align': 'left' }, "");
    //$("#" + gridName + "").trigger("reloadGrid");
}
function MergerStatistics2(gridName, CellName, dataCount) {
    //得到显示到界面的id集合
    var mya = $("#" + gridName + "").getDataIDs();
    //当前显示多少条
    var length = mya.length;
    var rowSpanTaxCount = 1; var startRow = 0;
    if (length < dataCount) {
        return;
    }
    for (var i = 0; i < length; i++) {
        //从上到下获取一条信息
        var startCellValue = $("#" + gridName + "").jqGrid('getRowData', mya[i]);
        for (var j = i + 1; j <= length; j++) {
            var endCellValue = $("#" + gridName + "").jqGrid('getRowData', mya[j]);
            if (startCellValue[CellName] == endCellValue[CellName]) {
                rowSpanTaxCount++;
                $("#" + gridName + "").setCell(mya[j], CellName, '', { display: 'none' });
            }
            else {
                $("#" + gridName + "MergerRow" + (i + 1) + "").attr("rowspan", rowSpanTaxCount);//最后合并需要合并的行与合并的行数
                i = j - 1;
                rowSpanTaxCount = 1;
                break;
            }

        }
    }
    $("#" + gridName + "").jqGrid('setLabel', CellName, '&nbsp;', { 'text-align': 'left' }, "");
    //$("#" + gridName + "").trigger("reloadGrid");
}
//------------------------------------------增加标签页end
//------------------------------------------字符串处理start
function cfStringValue(obj) {
    var returnValue = "";
    if (obj) {
        returnValue = obj;
    }
    return returnValue;
}
//------------------------------------------字符串处理end
//------------------------------------------提示信息start
function cfInitPopOver(data) {
    var html = '<a class="fa fa-question" rel="question"></a>';
    $(".formTitle,.formValue").each(function () {
        var fileName = $(this).text().replace("*", "").replace(/\s/g, "");//去掉空格
        for (var i = 0; i < data.length; i++) {
            if (fileName == data[i].title) {
                $(this).append(html);
                break;
            }
        }
    });
    $("[rel=question]").each(function () {
        var fileName = $(this).parent().text().replace("*", "").replace(/\s/g, "");//去掉空格
        for (var i = 0; i < data.length; i++) {
            if (fileName == data[i].title) {
                cfMyPopOver(this, data[i]);
                break;
            }
        }
    });
}

function cfMyPopOver(obj, dataObj) {
    var type = "right";
    if ($(obj).offset().left + dataObj.width > $(document.body).width()) {
        type = "left";
    }
    dataObj.title = dataObj.title.replace("km2", "km<sup>2</sup>");
    $(obj).popover({
        trigger: 'manual',
        placement: type,
        title: '<div style="text-align:center; font-size:14px;">' + dataObj.title + '</div>',
        html: 'true',
        content: '<div style="width:' + dataObj.width + 'px">' + dataObj.content + '</div>',
        animation: false
    }).on("mouseenter", function () {
        var _this = this;
        $(this).popover("show");
        $(this).siblings(".popover").on("mouseleave", function () {
            $(_this).popover('hide');
        });
    }).on("mouseleave", function () {
        var _this = this;
        setTimeout(function () {
            if (!$(".popover:hover").length) {
                $(_this).popover("hide")
            }
        }, 100);
    });
}
//------------------------------------------提示信息end
//------------------------------------------一次加载jqGrid表start
function cfjqGridInit(obj) {
    $("#" + obj.id).jqGrid(
        {
            autowidth: true,
            width: obj.width ? obj.width : "100%",
            height: obj.heigth ? obj.heigth : "200px",
            postData: { queryJson: obj.queryJson },
            url: obj.url,
            datatype: "json",
            mtype: obj.type ? obj.type : "GET",
            shrinkToFit: false,
            colModel: obj.colModel,
            viewrecords: true,
            rowNum: 30,
            rowList: [30, 50, 100],
            pager: obj.gridPager,
            sortname: obj.sortname,
            rownumbers: true,
            shrinkToFit: true,
            gridview: true,
            altRows: true,
            onSelectRow: function (rowId, status) {

            },
            gridComplete: function () {
            },
            loadError: function (xhr, status, error) {
                alert("loadError: " + status);

            },
            loadComplete: function (xhr) {

            }
        });


}
//------------------------------------------一次加载jqGrid表end
//------------------------------------------回车切换到下一文本框start
function cfEnterEvent() {
    $('input:visible,textarea').keydown(function (event) {
        if (event.keyCode == 13) {
            var inputs = $("input:visible,textarea");

            for (var i = 0; i < inputs.length; i++) {
                if (i == (inputs.length - 1)) {
                    inputs[0].focus();
                    break;
                } else if (this == inputs[i]) {
                    inputs[i + 1].focus();
                    break;
                }
            }
        }
    });
}
//------------------------------------------回车切换到下一文本框end
//------------------------------------------字段添加验证start
function cfvalidatorControl(dataTable) {
    $("input[type='text']").each(function (index) {
        for (var i = 0; i < dataTable.length; i++) {
            if ($(this).attr("id") == dataTable[i].column_name) {
                if ($(this).attr("isvalid") != "yes") {
                    if (dataTable[i].data_type == "NVARCHAR2" || dataTable[i].data_type == "VARCHAR2") {
                        $(this).attr("isvalid", "yes").attr("checkexpession", "LenStrOrNull").attr("length", dataTable[i].data_length);
                    }
                    else if (dataTable[i].data_type == "NUMBER") {
                        if (dataTable[i].data_scale) {
                            $(this).attr("isvalid", "yes").attr("checkexpession", "LenDoubleOrNull").attr("length", (dataTable[i].data_precision - dataTable[i].data_scale) + "," + dataTable[i].data_scale);
                        }
                        else {
                            $(this).attr("isvalid", "yes").attr("checkexpession", "LenNumOrNull").attr("length", dataTable[i].data_precision);
                        }
                    }
                }
                break;
            }

        }
    });
}
//------------------------------------------字段添加验证end
//------------------获取日期
function cfGetDateStr(AddDayCount) {
    var dd = new Date();
    dd.setDate(dd.getDate() + AddDayCount);//获取AddDayCount天后的日期
    return learun.formatDate(dd, 'yyyy-MM-dd');
}
function cfGetDateTimeStr(strDateTime, AddDayCount) {
    var dd = new Date(strDateTime);
    dd.setDate(dd.getDate() + AddDayCount);//获取AddDayCount天后的日期
    return learun.formatDate(dd, 'yyyy-MM-dd hh:mm:ss');
}
//------------------获取日期

function resize(panelTitleHeight) {
    window.setTimeout(function () {
        if (mapCtlExt != null) {
            if (panelTitleHeight == undefined || panelTitleHeight == null) {
                panelTitleHeight = 0;
            }
            mapCtlExt.setHeight($('#mapControl').parent().height() - 6 - panelTitleHeight);//地图高度
        }
        $('.center-Panel').height($('#layout').parent().height() - 5);
        $('#gridTable').setGridWidth(($('.gridPanel').width()));//表格宽度
        $('#layout2 .ui-layout-center').width($('#layout2 .ui-layout-center').parent().width());//表格和查询宽度
        $('#layout2 .ui-layout-center').height($('#layout2').height() - $('#layout2 .ui-layout-north').height() - 15);//表格和查询高度
        $('#gridTable').setGridHeight($('#layout2 .ui-layout-center').height() - 105);//表格高度
    }, 200);
};
//判断整数
function numValidator(id, bigId) {
    var text = $('#' + id).val();
    var reg = /^\d+$/;//^[0-9]*[1-9][0-9]*$
    if (reg.test(text) || !text) {
    } else {
        dialogAlert('输入有误',0);
    }
}
//判断小数
function numFloatValidator(id) {
    var text = $('#' + id).val();
    var reg = /^\d+(\.\d+)?$/;
    if (reg.test(text) || !text) {
        //alert('输入类型有误');
    } else {
        dialogAlert('输入有误',0);
    }
}
//iframe新增
function newTab(item) {
    var dataId = item.id;
    var dataUrl = item.url;
    if (!dataUrl) {
        return false;
    }
    dataUrl = contentPath + dataUrl;
    var str = '<iframe class="LRADMS_iframe" id="iframe' + dataId + '" name="iframe' + dataId + '"  width="100%" height="100%" src="' + dataUrl + '" frameborder="0" data-id="' + dataUrl + '" seamless  allowfullscreen></iframe>';
    $(window.parent.document).find('#layout').hide();
    if ($(window.parent.document).find('#iframe' + dataId).length > 0) {
        $(window.parent.document).find('#iframe' + dataId).attr('src', dataUrl);
    } else {
        $(window.parent.document).find('body').append(str);
    }
}
//同页面新增
function newTabs(item) {
    var dataId = item.id;
    var dataUrl = item.url;
    if (!dataUrl) {
        return false;
    }
    dataUrl = contentPath + dataUrl;
    var str = '<iframe class="LRADMS_iframe" id="' + dataId + '" name="' + dataId + '"  width="100%" height="100%" src="' + dataUrl + '" frameborder="0" data-id="' + dataUrl + '" seamless  allowfullscreen></iframe>';
    window.setTimeout(function () {
        $('#layout').hide();
    }, 200);
    if ($('#' + dataId).length > 0) {
        $('#' + dataId).attr('src', dataUrl);
    } else {
        $('body').append(str);
    }
   
}
function thisClose(id) {
    var layout = parent.window.document.getElementById("layout");
    var Tiframe = parent.window.document.getElementById("iframe" + id);
    layout.style.display = "block";
    if (Tiframe) {
        Tiframe.remove();
    }
}
function initMonitorChart(el, data) {


    option = {
        title: {
            text: data.title,
            left: 'left',
            top: 8,
            textStyle: {
                color: '#008cee',
                fontSize: 16,
                fontStyle: 'normal',
                fontWeight: 'normal',
                //align:'center'
            },
            //left:0
        },
        legend: {
            data: data.legend,
            right: 70
        },
        tooltip: {
            show: true,
            trigger: 'axis',
            axisPointer: {
                type: 'cross',
                animation: false
            }
        },
        //dataZoom: {
        //    show: true,
        //    realtime: true,
        //    start: 0,
        //    end: 100
        //},
        color: data.color,
        toolbox: {
            feature: {
                saveAsImage: {}
            }
        },
        xAxis: {
            type: 'category',
            name: "",
            data: data.xAxis.data,
            splitNumber: 20,
            axisTick: {
                alignWithLabel: true
            },
            splitLine: {
                show: true
            },
            axisLabel: {
                interval: 0,
                rotate: 45,
                show: true,
                //splitNumber: 15,
                textStyle: {
                    fontSize: 14,
                    //color: '#008cee'
                }
            }
        },
        yAxis: data.yAxis,
        series: data.series,
        grid: {
            //left: 100,
            right: 50
        }
    };



    var mycharts = echarts.init(document.getElementById(el));
    if (option.series.length > 0) {
        mycharts.setOption(option, true);
        window.onresize = mycharts.resize;
    } else {
        mycharts.clear;
    }
    return mycharts;
}
/////////////////////////////////// 图表公共方法 END //////////////////////////////


function initChart(el, data) {


    option = {
        title: {
            text: data.title,
            x: 'center',
            textStyle: {
                color: '#3185c7',
                fontSize: 20,
                //align:'center'
            },
            //left:0
        },
        legend: {
            data: data.legend,
            right: 200,
        },
        notMerge: true,
        toolbox: data.toolbox,
        color: data.color,
        tooltip: {
            show: true,
            trigger: 'axis',
            axisPointer: {
                type: 'cross',
                animation: false
            }
        },
        calculable: data.calculable,
        xAxis: data.xAxis,
        yAxis: data.yAxis,
        series: data.series,
    };
    var mycharts = echarts.init(document.getElementById(el));
    if (option.series.length > 0) {
        mycharts.clear();
        mycharts.setOption(option);
        window.onresize = mycharts.resize;
    } else {
        mycharts.clear;
    }

}
//加载地图方法
function cfGetMapData(settings) {
    var returnValue;
    var centerJWD = GetConfig("center");
    var centerJWDArr = centerJWD.split(",");
    var center = [parseFloat(centerJWDArr[0]), parseFloat(centerJWDArr[1])];
    var zoom = parseInt(centerJWDArr[2]);
    var config = getInfoTop().learun.data.get(["globalConfig"]);
    if (config) {
        returnValue = config.mapData;
    } else {
        $.ajax({
            url: contentPath + '/Map/GetMapDatas',
            async: false,
            type: "GET",
            success: function (data) {
                returnValue = JSON.parse(data);
            }, error: function (e) {
            },
            cache: false
        });
    }
    var defaluts = {
        mapwidth: 1500,
        isFrame: true,
        dataset: returnValue,
        center: center,
        zoom: zoom,
        isCluster: true, //取消聚合
        isShowGisLayer: true
    };
    $.extend(defaluts, settings);
    return defaluts;
};
//加载边界线
function GetAreaGeometry(areaCode) {
    if (areaCode == '000000') {//全国单独放的json文件在map文件夹下面
        function areaLineStyle(feature) {
            var style = new ol.style.Style({
                stroke: new ol.style.Stroke({
                    color: '#32CD32',
                    width: 4
                })
            })
            return style;
        }
        var geoJsonInfos = [{ geoJsonStyle: areaLineStyle, geoJsonUrl: '../../Content/scripts/plugins/map/000000.json'}];
        mapCtlExt.loadGeoJsonFile(geoJsonInfos)

    } else {
        //
        $.ajax({
            type: "get",
            async: true,
            url: SSOURL + "api/AdministrativeApi/GetAreaGeometry/" + areaCode,
            beforeSend: function (XHR) {
                //发送ajax请求之前向http的head里面加入验证信息
                XHR.setRequestHeader('Authorization', getAuthorizationToken());
            },
            success: function (data) {
                //显示边界
                var wkt = data.Result;
                if (!wkt) {
                    return;
                }
                var reader = new jsts.io.WKTReader();
                var parser = new jsts.io.OL3Parser();
                var geometries = [reader.read(wkt)];

                var features = geometries.map(function (g, i) {
                    var f = new ol.Feature({
                        geometry: parser.write(g)
                    });
                    return f
                })
                var color ='#32CD32'
                if (areaCode.includes('0000')) {
                    //省
                    color = '#5071FC'
                } else if (areaCode.includes('00')) {
                    //市
                    color = '#15B5A9'
                } else {
                    //区
                    color = '#FE9B46'
                }
                mapCtlExt.addAreaGeometry(features, color);
            },
            error: function (e) {
            },
            complete: function () {
            }
        });
    }
}