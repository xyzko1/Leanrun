﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_ZLGC_BASEINFO/TBL_ZLGC_BASEINFOIndex.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_ZLGC_BASEINFO_TBL_ZLGC_BASEINFOIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_ZLGC_BASEINFO_TBL_ZLGC_BASEINFOIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_ZLGC_BASEINFO\TBL_ZLGC_BASEINFOIndex.cshtml"
  
    ViewBag.Title = "列表页面";
    Layout = "~/Views/Shared/_IndexMap.cshtml";

            
            #line default
            #line hidden
WriteLiteral(@"
 <style>
     .ui-layout-center {
         overflow-x: hidden !important;
     }

     .ui-layout-resizer {
         background-color: #f0f3f4 !important;
     }

     #gridTable td {
         border-right: 1px solid #ccc !important;
     }

     .ui-jqgrid-btable tr:nth-child(odd) {
         /*background:#DCDCDC*/
     }

     .fa-folder-open {
         color: transparent !important;
         background: url(""../../Content/images/zTreeStandard.png"") no-repeat;
         background-position: -110px -16px;
         margin-right: 2px;
         width: 16px !important;
         height: 16px !important;
     }

     .fa-folder {
         color: transparent !important;
         background: url(""../../Content/images/zTreeStandard.png"") no-repeat;
         background-position: -110px 0;
         margin-right: 2px;
         width: 16px !important;
         height: 16px !important;
     }

     .fa-file-o {
         color: transparent !important;
         background: url(""../../Content/images/zTreeStandard.png"") no-repeat;
         background-position: -110px -32px;
         width: 16px !important;
         height: 16px !important;
     }
 </style>
<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(" style=\"height: 100%\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(" style=\"margin: 0px; height: 100%\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(" style=\"height: 40px; line-height: 40px; background-color: rgba(236, 247, 255, 1)" +
"; color: #000\"");

WriteLiteral(">行政区划</div>\r\n            <div");

WriteLiteral(" id=\"itemTree\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" id=\"ui_center\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(" style=\"height: 100%; width: 100%; margin-top: 0px; overflow-y: hidden;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout2\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"ui-layout-north\"");

WriteLiteral(" id=\"ui_map\"");

WriteLiteral(" style=\"height: 350px;position:relative;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"mapControl\"");

WriteLiteral(" style=\"height: 350px;\"");

WriteLiteral("></div>\r\n                    <div");

WriteLiteral(" id=\"tl\"");

WriteLiteral(" style=\"position: absolute; bottom: 0%; right: 0%;\"");

WriteLiteral(">\r\n                        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 2220), Tuple.Create("\"", 2252)
, Tuple.Create(Tuple.Create("", 2226), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/七大类图例.png")
, 2226), false)
);

WriteLiteral(" />\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" id=\"ui_grid\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(" style=\"height: 40px; line-height: 40px\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(" id=\"filter-form\"");

WriteLiteral(" style=\"height: 40px; line-height: 40px\"");

WriteLiteral(">\r\n                            <table>\r\n                                <tr>\r\n   " +
"                                 <td>\r\n                                        <" +
"input");

WriteLiteral(" id=\"NAMESS\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"工程名称、灾害名称\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(" />\r\n                                    </td>\r\n                                 " +
"   <td");

WriteLiteral(" style=\"padding-left: 5px;\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"margin-bottom: 6px\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>查询</a>\r\n                                    </td>\r\n                         " +
"       </tr>\r\n                            </table>\r\n                        </di" +
"v>\r\n                        <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(" style=\"height: 40px; line-height: 40px\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(" style=\"margin-bottom: 3px\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"reload()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>刷新</a>\r\n                                <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_add()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>新增</a>\r\n                                <a");

WriteLiteral(" id=\"lr-edit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_edit()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pencil-square-o\"");

WriteLiteral("></i>编辑</a>\r\n                                <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_delete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>删除</a>\r\n                                <a");

WriteLiteral(" id=\"lr-colgrid\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"ColDataGrid()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-chevron-down\"");

WriteLiteral("></i>列表</a>\r\n                                <a");

WriteLiteral(" id=\"lr-colmap\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"ColMapDiv()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-chevron-up\"");

WriteLiteral("></i>地图</a>\r\n                            </div> \r\n                        </div>\r" +
"\n                        <div");

WriteLiteral(" style=\"clear: both;\"");

WriteLiteral("></div>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n                        <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n                        <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n" +
"        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var layout2NorthH = 1;\r\n    var authToken = getAuthorizationToken" +
"();\r\n    var AreaCode = DefalutCode, PROVINCE = \"\", CITY = \"\", COUNTY = \"\";\r\n   " +
" $(function () {\r\n        InitialPage();\r\n        GetMapData();\r\n        GetTree" +
"();\r\n        GetGrid();\r\n        BindMapMarker();\r\n    });\r\n    //查询事件\r\n    $(\"#" +
"btn_Search\").click(function () {\r\n        SearchEvent();\r\n    });\r\n    //初始化页面\r\n" +
"    function InitialPage() {\r\n        var isResize = 0;\r\n        var count = 0;\r" +
"\n        var resized = 0;\r\n        //layout布局\r\n        $(\'#layout\').layout({\r\n  " +
"          west__size: 190,\r\n            applyDemoStyles: true,\r\n            onre" +
"size: function () {\r\n                if (isResize < 10) {\r\n                    i" +
"sResize++;\r\n                }\r\n                resize();\r\n            }\r\n       " +
" });\r\n        $(\'#layout2\').layout({\r\n            applyDemoStyles: true,\r\n      " +
"      onresize: function () {\r\n                resize();\r\n                if (is" +
"Resize > 1) {\r\n                    resized = 1;\r\n                } else {\r\n     " +
"               if (count == 1 || resized == 0) {\r\n                        $(\'#la" +
"yout2 .ui-layout-center\').height($(\'#layout2 .ui-layout-center\').height() - 18 +" +
" 9);\r\n                    }\r\n                }\r\n                count++;\r\n      " +
"      }\r\n        });\r\n        //resize重设布局;\r\n        $(window).resize(function (" +
"e) {\r\n            if (isResize < 10) {\r\n                isResize++;\r\n           " +
" }\r\n            resize();\r\n            e.stopPropagation();\r\n        });\r\n      " +
"  function resize() {\r\n            window.setTimeout(function () {\r\n            " +
"    if (mapCtlExt != null) {\r\n                    mapCtlExt.setHeight($(\'#mapCon" +
"trol\').parent().height() - 4);\r\n                }\r\n                $(\'#gridTable" +
"\').setGridWidth(($(\'.gridPanel\').width()));\r\n                $(\'#layout2 .ui-lay" +
"out-center\').width($(\'#layout2 .ui-layout-center\').parent().width() - 10);\r\n    " +
"            $(\'#layout2 .ui-layout-resizer\').width($(\'#layout2 .ui-layout-center" +
"\').parent().width() - 10);\r\n                $(\'.ui-jqgrid-bdiv\').height($(\'#layo" +
"ut2 .ui-layout-center\').height() - 60 - 60);\r\n                $(\'#layout2 .ui-la" +
"yout-center\').height($(\'#layout2\').height() - $(\'#layout2 .ui-layout-north\').hei" +
"ght() - 15 + 9);\r\n                $(\'#gridTable\').setGridHeight($(\'#layout2 .ui-" +
"layout-center\').height() - 107 + 11 - 6);\r\n                $(\'#layout2 .ui-layou" +
"t-center\').css(\'overflow\', \'hidden\');\r\n                $(\"#itemTree\").height($(\'" +
".ui-layout-west\').height() - 45);\r\n            }, 200);\r\n        };\r\n        $(w" +
"indow).resize();\r\n        $(\'#layout2 .ui-layout-center\').height($(\'#layout2 .ui" +
"-layout-center\').height() - 18);\r\n        layout2NorthH = $(\"#layout2 .ui-layout" +
"-north\").height();\r\n    }\r\n    //加载行政区划树\r\n    function GetTree() {\r\n        var " +
"item = {\r\n            height: $(window).height() - 52,\r\n            isAllExpand:" +
" false,\r\n            url: \"../../Map/GetTreeJsonForMap\",\r\n            onnodeclic" +
"k: function (item) {\r\n                AreaCode = item.id;\r\n                var l" +
"evel = item.value.split(\',\')[1];\r\n                if (level == -1) {\r\n          " +
"          PROVINCE = \"\";\r\n                    CITY = \"\";\r\n                    CO" +
"UNTY = \"\";\r\n                } else if (level == 1) {\r\n                    PROVIN" +
"CE = item.id;\r\n                    CITY = \"\";\r\n                    COUNTY = \"\";\r" +
"\n                } else if (level == 2) {\r\n                    PROVINCE = item.i" +
"d.substring(0, 2) + \"0000\";\r\n                    CITY = item.id;\r\n              " +
"      COUNTY = \"\";\r\n                } else if (level == 3) {\r\n                  " +
"  PROVINCE = item.id.substring(0, 2) + \"0000\";\r\n                    CITY = item." +
"id.substring(0, 4) + \"00\";\r\n                    COUNTY = item.id;\r\n             " +
"   }\r\n                var data = [{\r\n                    latitude: item.value.sp" +
"lit(\',\')[3],\r\n                    longitude: item.value.split(\',\')[2],\r\n        " +
"            popupHtml: \"\"\r\n                }]\r\n                $(\'#btn_Search\')." +
"trigger(\"click\");\r\n                mapCtlExt.addLocation(data, false, level);\r\n " +
"           },\r\n        };\r\n        //初始化\r\n        $(\"#itemTree\").treeview(item);" +
"\r\n    };\r\n    var mapCtlExt = null;\r\n    function GetMapData() {\r\n        mapCtl" +
"Ext = $(\"#mapControl\").mapCtl(\r\n            cfGetMapData({\r\n                mark" +
"erDataId: \"keyID\",\r\n                getMarkerData: getMarkerData\r\n            })" +
"\r\n            );\r\n        usercode = \"");

            
            #line 222 "..\..\Areas\JXGeoManage\Views\TBL_ZLGC_BASEINFO\TBL_ZLGC_BASEINFOIndex.cshtml"
               Write(Infoearth.Application.Code.OperatorProvider.Provider.Current().XZQHCode);

            
            #line default
            #line hidden
WriteLiteral("\";\r\n        GetAreaGeometry(usercode);\r\n    };\r\n    //加载表格\r\n    function GetGrid(" +
") {\r\n        var selectedRowIndex = 0;\r\n        var queryJson = $(\"#filter-form\"" +
").getWebControls();\r\n        var $gridTable = $(\'#gridTable\');\r\n        $gridTab" +
"le.jqGrid({\r\n            autowidth: true,\r\n            loadBeforeSend: function " +
"(a) {\r\n                a.setRequestHeader(\"Authorization\", authToken);\r\n        " +
"    },\r\n            postData: { queryJson: JSON.stringify(queryJson) },\r\n       " +
"     height: $(window).height() - 551,\r\n            //url: \"../../JXGeoManage/TB" +
"L_ZLGC_BASEINFO/GetPageListJson\",\r\n            url: \"../../api/TBL_ZLGC/GetPageL" +
"istJson\",\r\n            datatype: \"json\",\r\n            colModel: [\r\n             " +
"   { label: \'GUID\', name: \'GUID\', index: \'GUID\', width: 100, align: \'left\', sort" +
"able: true, hidden: true },\r\n                { label: \'治理工程名称\', name: \'ZLGCNAME\'" +
", index: \'ZLGCNAME\', width: 250, align: \'left\', sortable: true },\r\n             " +
"   { label: \'灾害点名称\', name: \'DISASTERNAME\', index: \'DISASTERNAME\', width: 250, al" +
"ign: \'left\', sortable: true },\r\n                { label: \'灾害点编号\', name: \'UNIFIED" +
"CODE\', index: \'UNIFIEDCODE\', width: 200, align: \'left\', sortable: true, hidden: " +
"true },\r\n                { label: \'灾害点类型\', name: \'DISASTERTYPE\', index: \'DISASTE" +
"RTYPE\', width: 100, align: \'left\', sortable: true },\r\n                { label: \'" +
"项目阶段\', name: \'ZLSTATE\', index: \'ZLSTATE\', width: 100, align: \'left\', sortable: t" +
"rue },\r\n                { label: \'负责单位\', name: \'XMFZDW\', index: \'XMFZDW\', width:" +
" 200, align: \'left\', sortable: true },\r\n                { label: \'批复资金(万元)\', nam" +
"e: \'XMPFZJ\', index: \'XMPFZJ\', width: 100, align: \'left\', sortable: true },\r\n    " +
"            {\r\n                    label: \'立项时间\', name: \'XMJLXSJ\', index: \'XMJLX" +
"SJ\', width: 100, align: \'left\', sortable: true,\r\n                    formatter: " +
"function (cellvalue, options, rowObject) {\r\n                        if (cellvalu" +
"e) {\r\n                            cellvalue = cellvalue.replace(\"T00:00:00\", \" \"" +
");\r\n                        } else {\r\n                            cellvalue = \"\"" +
";\r\n                        }\r\n                        return cellvalue;\r\n       " +
"             }\r\n                },\r\n                { label: \'工程地理位置\', name: \'LO" +
"CATION\', index: \'LOCATION\', width: 300, align: \'left\', sortable: true },\r\n      " +
"          { label: \'经度\', name: \'LONGITUDE\', index: \'LONGITUDE\', width: 100, alig" +
"n: \'left\', sortable: true, hidden: true, },\r\n                { label: \'纬度\', name" +
": \'LATITUDE\', index: \'LATITUDE\', width: 100, align: \'left\', sortable: true, hidd" +
"en: true, },\r\n            ],\r\n            viewrecords: true,\r\n            rowNum" +
": 30,\r\n            rowList: [30, 50, 100],\r\n            pager: \"#gridPager\",\r\n  " +
"          sortname: \'GUID\',\r\n            sortorder: \'desc\',\r\n            rownumb" +
"ers: true,\r\n            shrinkToFit: false,\r\n            gridview: true,\r\n      " +
"      onSelectRow: function (rowId, status) {\r\n                selectedRowIndex " +
"= $(\'#\' + this.id).getGridParam(\'selrow\');\r\n                var dt = $gridTable." +
"jqGrid(\"getRowData\", rowId);\r\n                var data = [];\r\n                va" +
"r longitude = 0, latitude = 0;\r\n                if (dt.LONGITUDE) {\r\n           " +
"         longitude = parseFloat(dt.LONGITUDE);\r\n                }\r\n             " +
"   if (dt.LATITUDE) {\r\n                    latitude = parseFloat(dt.LATITUDE);\r\n" +
"                }\r\n                data.push({ longitude: longitude, latitude: l" +
"atitude });\r\n                if (isMarkerClick) {\r\n                    isMarkerC" +
"lick = false;\r\n                } else {\r\n                    mapCtlExt.addLocati" +
"on(data, true);\r\n                }\r\n            },\r\n            gridComplete: fu" +
"nction () {\r\n                $(\'#\' + this.id).setSelection(selectedRowIndex, fal" +
"se);\r\n            }\r\n        });\r\n    }\r\n    //获取点击Marker时对应的数据\r\n    var isMarke" +
"rClick = false;\r\n    function getMarkerData(UNIFIEDCODE) {\r\n        isMarkerClic" +
"k = true;\r\n        var datas = $(\'#gridTable\').jqGrid(\"getRowData\");\r\n        va" +
"r count = 0;\r\n        $.each(datas, function (i, e) {\r\n            if (e.UNIFIED" +
"CODE.trim().indexOf(UNIFIEDCODE) > -1) {\r\n                count = 1;\r\n          " +
"      $(\'#gridTable\').setSelection(i + 1);\r\n                $(\'#gridTable tr\').e" +
"q(i + 1).focus();\r\n            }\r\n        });\r\n    };\r\n    //加载地图marker\r\n    fun" +
"ction BindMapMarker() {\r\n        var queryJson = $(\"#DZHJManage\").getWebControls" +
"();\r\n        queryJson[\"PROVINCE\"] = PROVINCE;\r\n        queryJson[\"CITY\"] = CITY" +
";\r\n        queryJson[\"COUNTY\"] = COUNTY;\r\n        queryJson[\"zhd\"] = \"zhd\";\r\n   " +
"     $.ajax({\r\n            url: contentPath + \"/api/TBL_ZLGC/GetPageListJson\",\r\n" +
"            beforeSend: function (a) {\r\n                if (authToken != null)\r\n" +
"                    a.setRequestHeader(\"Authorization\", authToken);\r\n           " +
" },\r\n            datatype: \'json\',\r\n            data: { queryJson: JSON.stringif" +
"y(queryJson) },\r\n            async: true,\r\n            cache: false,\r\n          " +
"  type: \"GET\",\r\n            success: function (dataList) {\r\n                var " +
"data = dataList.rows;\r\n                var returnValue = [];\r\n                va" +
"r type = [];\r\n                for (var i = 0; i < data.length; i++) {\r\n         " +
"           //详情页面\r\n                    var divhtml = \'<div style=\"font-weight: b" +
"old;\"></div>\';\r\n                    divhtml += \'<div style=\"font-weight: bold;ma" +
"rgin-bottom:5px;\"><span style=\"margin-left:10px;\">灾害点编号：</span><span>\' + data[i]" +
".UNIFIEDCODE + \'</span></div>\';\r\n                    divhtml += \'<div style=\"mar" +
"gin-bottom:5px;\"><span style=\"margin-left:10px;\">灾害点名称：</span><span>\' + data[i]." +
"DISASTERNAME + \'</span></div>\';\r\n                    divhtml += \'<div><input typ" +
"e=\"hidden\" id=\"keyID\" value=\"\' + data[i].UNIFIEDCODE + \'\"/></div>\';\r\n           " +
"         divhtml += \'<div style=\"margin-bottom:5px;\"><span style=\"margin-left:10" +
"px;\">灾害点类型：</span><span>\' + data[i].DISASTERTYPE + \'</span></div>\';\r\n           " +
"         divhtml += \'<div style=\"margin-bottom:5px;\"><span style=\"margin-left:10" +
"px;\">地 理 位 置：</span><span>\' + data[i].LOCATION + \'</span></div>\';\r\n             " +
"       //预留 divhtml += \'<span style=\"margin-right:20px; float:right; cursor: poi" +
"nter;\"><a onclick=\"ViewDetail(\\\'\' + data[i].UNIFIEDCODE + \'\\\')\" href=\"#\" class=\"" +
"link-detail\">详细信息</a></span>\';\r\n\r\n                    var longitude, latitude;\r\n" +
"                    if (data[i].LONGITUDE != \'\' && data[i].LONGITUDE != null && " +
"data[i].LONGITUDE != undefined) {\r\n                        longitude = parseFloa" +
"t(data[i].LONGITUDE);\r\n                    }\r\n                    if (data[i].LA" +
"TITUDE != \'\' && data[i].LATITUDE != null && data[i].LATITUDE != undefined) {\r\n  " +
"                      latitude = parseFloat(data[i].LATITUDE);\r\n                " +
"    }\r\n                    returnValue.push({ id: \"all\", url: contentPath + \"/Co" +
"ntent/images/\" + data[i].DISASTERTYPE + \"-16.png\", location: [longitude, latitud" +
"e], popupHtml: divhtml });\r\n\r\n                }\r\n                mapCtlExt.addMa" +
"rker(returnValue);\r\n            }, error: function (e) {\r\n            },\r\n      " +
"      cache: false\r\n        });\r\n    };\r\n\r\n    //新增\r\n    function btn_add() {\r\n " +
"       dialogOpen({\r\n            id: \'Form\',\r\n            title: \'添加治理工程信息表\',\r\n " +
"           url: \'/JXGeoManage/TBL_ZLGC_BASEINFO/TBL_ZLGC_BASICAMANAGE\',\r\n       " +
"     width: \'1300px\',\r\n            height: \'700px\',\r\n            callBack: funct" +
"ion (iframeId) {\r\n                getInfoTop().frames[iframeId].AcceptClick();\r\n" +
"                BindMapMarker();\r\n            }\r\n        });\r\n    }\r\n\r\n    //编辑\r" +
"\n    function btn_edit() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowValu" +
"e(\'GUID\');\r\n        if (checkedRow(keyValue)) {\r\n            dialogOpen({\r\n     " +
"           id: \'FormZLGCLIST\',\r\n                title: \'编辑治理工程信息表\',\r\n           " +
"     url: \'/JXGeoManage/TBL_ZLGC_BASEINFO/TBL_ZLGC_BASICAMANAGE?&keyValue=\' + ke" +
"yValue,\r\n                width: \'1300px\',\r\n                height: \'700px\',\r\n   " +
"             callBack: function (iframeId) {\r\n                    getInfoTop().f" +
"rames[iframeId].AcceptClick();\r\n                }\r\n            })\r\n        }\r\n  " +
"  }\r\n    //删除\r\n    function btn_delete() {\r\n        var keyValue = $(\"#gridTable" +
"\").jqGridRowValue(\'GUID\');\r\n        if (keyValue) {\r\n            //dialogMsg(\'此操" +
"作将删除该项目下关联的各阶段信息，是否确认删除？\');\r\n            $.RemoveForm1({\r\n                url: \'" +
"../../api/TBL_ZLGC/RemoveForm\',\r\n                param: { \"\": keyValue },\r\n     " +
"           authToken: authToken,\r\n                success: function (data) {\r\n  " +
"                  //alert(data.message);\r\n                    $(\'#gridTable\').tr" +
"igger(\'reloadGrid\');\r\n                }\r\n            })\r\n        } else {\r\n     " +
"       dialogMsg(\'请选择需要删除的治理工程信息表！\', 0);\r\n        }\r\n    }\r\n    //查询表格函数\r\n    fu" +
"nction SearchEvent() {\r\n        var queryJson = $(\"#filter-form\").getWebControls" +
"();\r\n        queryJson[\"PROVINCE\"] = PROVINCE;\r\n        queryJson[\"CITY\"] = CITY" +
";\r\n        queryJson[\"COUNTY\"] = COUNTY;\r\n        $(\"#gridTable\").jqGrid(\'setGri" +
"dParam\', {\r\n            loadBeforeSend: function (a) {\r\n                a.setReq" +
"uestHeader(\"Authorization\", authToken);\r\n            },\r\n            postData: {" +
" queryJson: JSON.stringify(queryJson) },\r\n            url: \"../../api/TBL_ZLGC/G" +
"etPageListJson\",\r\n            page: 1\r\n        }).trigger(\'reloadGrid\');\r\n      " +
"  BindMapMarker();\r\n    }\r\n\r\n    function ColDataGrid() {\r\n        var centerHei" +
"ght = $(\"#layout2\").height();\r\n        var layout2 = $(\'#layout2\').layout();\r\n  " +
"      if ($(\"#lr-colgrid i\").hasClass(\"fa-chevron-down\")) {\r\n            var nor" +
"thH = centerHeight - 45;\r\n            layout2.sizePane(\"north\", northH);\r\n      " +
"      $(\"#lr-colgrid i\").removeClass(\"fa-chevron-down\");\r\n            $(\"#lr-col" +
"grid i\").addClass(\"fa-chevron-up\");\r\n            if ($(\"#lr-colmap i\").hasClass(" +
"\"fa-chevron-down\")) {\r\n                $(\"#lr-colmap i\").removeClass(\"fa-chevron" +
"-down\");\r\n                $(\"#lr-colmap i\").addClass(\"fa-chevron-up\");\r\n        " +
"    }\r\n        }\r\n        else {\r\n            layout2.sizePane(\"north\", layout2N" +
"orthH);\r\n            $(\"#lr-colgrid i\").removeClass(\"fa-chevron-up\");\r\n         " +
"   $(\"#lr-colgrid i\").addClass(\"fa-chevron-down\");\r\n        }\r\n        mapCtlExt" +
".updateSize();\r\n    }\r\n    function ColMapDiv() {\r\n        var layout2 = $(\'#lay" +
"out2\').layout();\r\n        if ($(\"#lr-colmap i\").hasClass(\"fa-chevron-up\")) {\r\n  " +
"          layout2.sizePane(\"north\", 1);\r\n            $(\"#lr-colmap i\").removeCla" +
"ss(\"fa-chevron-up\");\r\n            $(\"#lr-colmap i\").addClass(\"fa-chevron-down\");" +
"\r\n            if ($(\"#lr-colgrid i\").hasClass(\"fa-chevron-up\")) {\r\n             " +
"   $(\"#lr-colgrid i\").removeClass(\"fa-chevron-up\");\r\n                $(\"#lr-colg" +
"rid i\").addClass(\"fa-chevron-down\");\r\n            }\r\n        }\r\n        else {\r\n" +
"            layout2.sizePane(\"north\", layout2NorthH);\r\n            $(\"#lr-colmap" +
" i\").removeClass(\"fa-chevron-down\");\r\n            $(\"#lr-colmap i\").addClass(\"fa" +
"-chevron-up\");\r\n            if (mapCtlExt != null) {\r\n                mapCtlExt." +
"setHeight($(\"#mapControl\").parent().height() - 32 - 4);\r\n            }\r\n        " +
"}\r\n        mapCtlExt.updateSize();\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
