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
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Infoearth.Application.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_QCQF_ADMINISTRATIVE/TBL_QCQF_ADMINISTRATIVEQueryBro" +
        "wse.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_QCQF_ADMINISTRATIVE_TBL_QCQF_ADMINISTRATIVEQueryBrowse_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_QCQF_ADMINISTRATIVE_TBL_QCQF_ADMINISTRATIVEQueryBrowse_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_QCQF_ADMINISTRATIVE\TBL_QCQF_ADMINISTRATIVEQueryBrowse.cshtml"
  
    ViewBag.Title = "最新数据查询";
    Layout = "~/Views/Shared/_IndexMap.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(" style=\"height:100%\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(" style=\"margin:0px;height:100%\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(" style=\"height:40px;line-height:40px;background-color: rgba(236, 247, 255, 1);col" +
"or:#000\"");

WriteLiteral(">行政区划</div>\r\n            <div");

WriteLiteral(" id=\"itemTree\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" id=\"ui_center\"");

WriteLiteral(" style=\"overflow:hidden !important;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(" style=\"height: 100%;width:100%;margin-top:0px;overflow-y:hidden;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"search\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"GJCX\"");

WriteLiteral(" style=\"position:absolute;top:-120px;z-index:3;width:100%;transition:all 0.6s\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"\"");

WriteLiteral(" style=\"width: 100%;display: flex; overflow-x:auto;overflow-y:hidden; height: 40p" +
"x;background-color: rgba(255, 255, 255, 0.8);color:#000; display: flex; align-it" +
"ems: center; position: relative;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" style=\"width: 100%; height: 40px;background-color: rgba(255, 255, 255, 0.8);colo" +
"r:#000; display: flex; align-items: center; position: relative;\"");

WriteLiteral(">\r\n                            ");

WriteLiteral("\r\n                            <span");

WriteLiteral(" class=\"spansa\"");

WriteLiteral(">群测群防人:</span><input");

WriteLiteral(" id=\"GROUPMONITORINGSTAFF\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n                            <span");

WriteLiteral(" class=\"spansa\"");

WriteLiteral(">地理位置:</span><input");

WriteLiteral(" id=\"LOCATION\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"width: 200px\"");

WriteLiteral(" />\r\n                            <div");

WriteLiteral(" style=\" height: 40px;background-color: rgba(255, 255, 255, 0.8);color:#000; disp" +
"lay: flex; align-items: center; position: relative;\"");

WriteLiteral(">\r\n                                <span");

WriteLiteral(" class=\"spansa\"");

WriteLiteral(">灾害点类型:</span><div");

WriteLiteral(" id=\"DISASTERTYPE\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 200px\"");

WriteLiteral("></div>\r\n                                <span");

WriteLiteral(" class=\"spansa\"");

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" id=\"btn_Search_higher\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"cursor: pointer; color: white;padding:4px 4px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>查询</a>\r\n                                </span>\r\n                           " +
"     <div");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" id=\"btn_Reset\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"margin-bottom:0;padding:4px 4px;background:gray;border-color:gray;cursor:" +
" pointer;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i> 重置</a>&nbsp;\r\n                                </div>\r\n                     " +
"           <span");

WriteLiteral(" class=\"spansa\"");

WriteLiteral("></span><div");

WriteLiteral(" style=\"width: 200px\"");

WriteLiteral("></div>\r\n                            </div>\r\n                            ");

WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" ");

WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" id=\"DZHJManage\"");

WriteLiteral(" class=\"\"");

WriteLiteral(" style=\"width:100%;height:40px;background: rgba(236, 247, 255, 1);display:flex;al" +
"ign-items: center;position:relative;z-index:23;justify-content: start;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" style=\"width: 10%; font-weight: 900; min-width: 80px; white-space: nowrap;\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-bars\"");

WriteLiteral(" style=\"margin:0 5px;font-weight:700;\"");

WriteLiteral("></i><span>查询条件:</span>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(" id=\"filter-form\"");

WriteLiteral(" style=\"width: 40%; align-items: center; flex-wrap: nowrap;margin-top:3px;\"");

WriteLiteral(">\r\n                        <table>\r\n                            <tr>\r\n           " +
"                     <td><input");

WriteLiteral(" id=\"COMPPARAM\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入灾害点名称或灾害点编号\"");

WriteLiteral(" style=\"width: 240px;\"");

WriteLiteral(" /></td>\r\n                                <td");

WriteLiteral(" style=\"padding-left: 10px;\"");

WriteLiteral("><a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" style=\"font-size:16px; cursor:pointer;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral(" style=\"margin: -9px 10px 0px 0px\"");

WriteLiteral("></i></a></td>                              \r\n                            </tr>\r\n" +
"                        </table>\r\n                    </div>\r\n                  " +
"  <div");

WriteLiteral(" style=\"width: 90%;align-items: center;flex-wrap: nowrap;\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" id=\"serch-btn\"");

WriteLiteral(" style=\"font-size:13px;float:right;maring-right:10px;position:absolute;top:10px; " +
"right:10px;cursor:pointer\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" id=\"fontfamily\"");

WriteLiteral(" class=\"fa fa-caret-right\"");

WriteLiteral("></i>\r\n                            高级查询\r\n                        </span>\r\n       " +
"             </div>\r\n                </div>\r\n            </div>\r\n            <di" +
"v");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout2\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"ui-layout-north\"");

WriteLiteral(" id=\"ui_map\"");

WriteLiteral(" style=\"position:relative;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"mapControl\"");

WriteLiteral(" style=\"height: 350px;\"");

WriteLiteral("></div>\r\n                    <div");

WriteLiteral(" id=\"tl\"");

WriteLiteral(" style=\"position: absolute; bottom: 0%; right: 0%;\"");

WriteLiteral(">\r\n                        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 5058), Tuple.Create("\"", 5090)
, Tuple.Create(Tuple.Create("", 5064), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/七大类图例.png")
, 5064), false)
);

WriteLiteral(" />\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" id=\"ui_grid\"");

WriteLiteral(">   \r\n                    <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(" style=\"height:40px;line-height:40px\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(" style=\"color:#000\"");

WriteLiteral(" \">数据列表</span>\r\n                        <div class=\"toolbar\" style=\"float:right;h" +
"eight:40px;line-height:40px;display:flex;align-items: center;\">\r\n               " +
"             <div class=\"btn-group\">\r\n                                ");

WriteLiteral("\r\n                                <a id=\"lr-message\" onclick=\"btn_message()\" clas" +
"s=\"btn btn-default\"><i class=\"fa fa-pencil-square-o\"></i>详情</a>\r\n               " +
"                 <a id=\"lr-replace\" class=\"btn btn-default\" onclick=\"reload()\"><" +
"i class=\"fa fa-refresh\"></i>&nbsp;刷新</a>\r\n                                <a id=" +
"\"lr-colgrid\" class=\"btn btn-default\" onclick=\"ColDataGrid()\"><i class=\"fa fa-che" +
"vron-down\"></i>列表</a>\r\n                                <a id=\"lr-colmap\" class=\"" +
"btn btn-default\" onclick=\"ColMapDiv()\"><i class=\"fa fa-chevron-up\"></i>地图</a>\r\n " +
"                           </div>\r\n                        </div>\r\n             " +
"           <div style=\"clear:both\"></div>\r\n                    </div>\r\n         " +
"           <div class=\"gridPanel\">\r\n                        <table id=\"gridTable" +
"\"></table>\r\n                        <div id=\"gridPager\"></div>\r\n                " +
"    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </di" +
"v>\r\n</div>\r\n\r\n<style>\r\n    #ui_center {\r\noverflow:hidden !important;\r\n    }\r\n   " +
" .ui-th-column, .ui-jqgrid .ui-jqgrid-htable th.ui-th-column {\r\n        border-t" +
"op: 1px solid #ccc;\r\n    }\r\n\r\n    .spansa {\r\n        padding: 0 20px !important;" +
"\r\n        width: 9%;\r\n        text-align: center;\r\n        height: 28px;\r\n      " +
"  line-height: 28px;\r\n        min-width: 113px;\r\n    }\r\n\r\n    .divselect {\r\n    " +
"    width: 21%;\r\n    }\r\n\r\n    .spans {\r\n        padding: 0 10px;\r\n        width:" +
" 9%;\r\n        text-align: center;\r\n        height: 28px;\r\n        line-height: 2" +
"8px;\r\n        min-width: 100px;\r\n    }\r\n\r\n    .ui-select-text, .form-control {\r\n" +
"        border-radius: 4px;\r\n    }\r\n\r\n    .ui-layout-resizer {\r\n        backgrou" +
"nd: #f5f5f5 !important;\r\n    }\r\n\r\n    #gridTable td {\r\n        border-right: 1px" +
" solid #ccc !important;\r\n    }\r\n\r\n    .ui-jqgrid-btable tr:nth-child(odd) {\r\n   " +
"     /*background:#DCDCDC*/\r\n    }\r\n\r\n    .fa-folder-open {\r\n        color: tran" +
"sparent !important;\r\n        background: url(\"../../Content/images/zTreeStandard" +
".png\") no-repeat;\r\n        background-position: -110px -16px;\r\n        margin-ri" +
"ght: 2px;\r\n        width: 16px !important;\r\n        height: 16px !important;\r\n  " +
"  }\r\n\r\n    .fa-folder {\r\n        color: transparent !important;\r\n        backgro" +
"und: url(\"../../Content/images/zTreeStandard.png\") no-repeat;\r\n        backgroun" +
"d-position: -110px 0;\r\n        margin-right: 2px;\r\n        width: 16px !importan" +
"t;\r\n        height: 16px !important;\r\n    }\r\n\r\n    .fa-file-o {\r\n        color: " +
"transparent !important;\r\n        background: url(\"../../Content/images/zTreeStan" +
"dard.png\") no-repeat;\r\n        background-position: -110px -32px;\r\n        width" +
": 16px !important;\r\n        height: 16px !important;\r\n    }\r\n</style>\r\n\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var layout2NorthH = 1;\r\n    var authToken = getAuthorizationToken" +
"();\r\n    var AreaCode = 0, PROVINCE = \"\", CITY = \"\", COUNTY = \"\";\r\n    $(functio" +
"n () {\r\n        initControl();\r\n        InitialPage();\r\n        GetTree();\r\n    " +
"    GetMapData();\r\n        GetGrid();\r\n        BindMapMarker();\r\n        //高级查询点" +
"击事件\r\n        $(\"#btn_Search_higher\").click(function () {\r\n            SearchEven" +
"t();\r\n        });\r\n        //表格上方查询点击事件\r\n        $(\"#btn_Search\").click(function" +
" () {\r\n            SearchEvent();\r\n        });\r\n        var flag = true;\r\n      " +
"  $(\"#serch-btn\").click(function () {\r\n            if (flag) {\r\n                " +
"$(\"#GJCX\").css(\"top\", 40)\r\n                $(\"#fontfamily\").removeClass();\r\n    " +
"            $(\"#fontfamily\").addClass(\"fa fa-caret-down\")\r\n                flag " +
"= false\r\n            } else {\r\n                $(\"#GJCX\").css(\"top\", -120);\r\n   " +
"             $(\"#fontfamily\").removeClass();\r\n                $(\"#fontfamily\").a" +
"ddClass(\"fa fa-caret-right\")\r\n                flag = true\r\n            }\r\n      " +
"  });\r\n        //重置\r\n        $(\"#btn_Reset\").click(function () {\r\n            $(" +
"\"#DISASTERNAME\").val(\"\");\r\n            $(\"#UNIFIEDCODE\").val(\"\");\r\n            $" +
"(\"#LOCATION\").val(\"\");\r\n            $(\"#DISASTERTYPE\").val(\"\");\r\n            $(\"" +
"#DISASTERTYPE\").attr(\"data-value\", \"\").attr(\"data-text\", \"\");\r\n            $(\"#D" +
"ISASTERTYPE .ui-select-text\").text(\" \");\r\n        });\r\n    });\r\n    //初始化页面\r\n   " +
" function InitialPage() {\r\n        //layout布局\r\n        $(\'#layout\').layout({\r\n  " +
"          west__size: 190,\r\n            applyDemoStyles: true,\r\n            onre" +
"size: function () {\r\n                if (isResize < 10) {\r\n                    i" +
"sResize++;\r\n                }\r\n                resize();\r\n            }\r\n       " +
" });\r\n        var isResize = 0;\r\n        var count = 0;\r\n        var resized = 0" +
";\r\n        $(\'#layout2\').layout({\r\n            applyDemoStyles: true,\r\n         " +
"   onresize: function () {\r\n                resize();\r\n                if (isRes" +
"ize > 1) {\r\n                    resized = 1;\r\n                } else {\r\n        " +
"            if (count == 1 || resized == 0) {\r\n                        $(\'#layou" +
"t2 .ui-layout-center\').height($(\'#layout2 .ui-layout-center\').height() - 18);\r\n " +
"                   }\r\n                }\r\n                count++;\r\n            }" +
"\r\n        });\r\n        //resize重设布局;\r\n        $(window).resize(function (e) {\r\n " +
"           if (isResize < 10) {\r\n                isResize++;\r\n            }\r\n   " +
"         resize();\r\n            e.stopPropagation();\r\n        });\r\n        funct" +
"ion resize() {\r\n            window.setTimeout(function () {\r\n                if " +
"(mapCtlExt != null) {\r\n                    mapCtlExt.setHeight($(\'#mapControl\')." +
"parent().height() - 4);\r\n                }\r\n                $(\'#gridTable\').setG" +
"ridWidth(($(\'.gridPanel\').width()));\r\n                $(\'#layout2 .ui-layout-cen" +
"ter\').width($(\'#layout2 .ui-layout-center\').parent().width());\r\n                " +
"$(\'#layout2 .ui-layout-resizer\').width($(\'#layout2 .ui-layout-center\').parent()." +
"width());\r\n                $(\'.ui-jqgrid-bdiv\').height($(\'#layout2 .ui-layout-ce" +
"nter\').height() - 60 - 60);\r\n                $(\'#layout2 .ui-layout-center\').hei" +
"ght($(\'#layout2\').height() - $(\'#layout2 .ui-layout-north\').height() - 15);\r\n   " +
"             $(\'#gridTable\').setGridHeight($(\'#layout2 .ui-layout-center\').heigh" +
"t() - 139 + 12 - 5);\r\n                $(\'#layout2 .ui-layout-center\').css(\'overf" +
"low\', \'hidden\');\r\n                $(\"#itemTree\").height($(\'.ui-layout-west\').hei" +
"ght() - 45);\r\n            }, 200);\r\n        };\r\n        $(window).resize();\r\n   " +
"     $(\'#layout2 .ui-layout-center\').height($(\'#layout2 .ui-layout-center\').heig" +
"ht() - 18);\r\n        layout2NorthH = $(\"#layout2 .ui-layout-north\").height();\r\n\r" +
"\n    }\r\n    //加载行政区划树\r\n    function GetTree() {\r\n        var item = {\r\n         " +
"   height: $(window).height() - 52,\r\n            isAllExpand: false,\r\n          " +
"  url: \"../../Map/GetTreeJsonForMap\",\r\n            onnodeclick: function (item) " +
"{\r\n                AreaCode = item.id;\r\n                var level = item.value.s" +
"plit(\',\')[1];\r\n                if (level == -1) {\r\n                    PROVINCE " +
"= \"\";\r\n                    CITY = \"\";\r\n                    COUNTY = \"\";\r\n       " +
"         } else if (level == 1) {\r\n                    PROVINCE = item.id;\r\n    " +
"                CITY = \"\";\r\n                    COUNTY = \"\";\r\n                } " +
"else if (level == 2) {\r\n                    PROVINCE = item.id.substring(0, 2) +" +
" \"0000\";\r\n                    CITY = item.id;\r\n                    COUNTY = \"\";\r" +
"\n                } else if (level == 3) {\r\n                    PROVINCE = item.i" +
"d.substring(0, 2) + \"0000\";\r\n                    CITY = item.id.substring(0, 4) " +
"+ \"00\";\r\n                    COUNTY = item.id;\r\n                }\r\n             " +
"   var data = [{\r\n                    latitude: item.value.split(\',\')[3],\r\n     " +
"               longitude: item.value.split(\',\')[2],\r\n                    popupHt" +
"ml: \"\"\r\n                }]\r\n                mapCtlExt.addLocation(data, false, l" +
"evel);\r\n                $(\'#btn_Search_higher\').trigger(\"click\");\r\n            }" +
",\r\n        };\r\n        //初始化\r\n        $(\"#itemTree\").treeview(item);\r\n    };\r\n  " +
"  //加载地图marker\r\n    function BindMapMarker() {\r\n        var queryJson = $(\"#GJCX" +
"\").getWebControls();\r\n        queryJson[\"txt_Key\"] = $(\"#COMPPARAM\").val();\r\n   " +
"     queryJson[\"PROVINCE\"] = PROVINCE;\r\n        queryJson[\"CITY\"] = CITY;\r\n     " +
"   queryJson[\"COUNTY\"] = COUNTY;\r\n        $.ajax({\r\n            url: \"../../api/" +
"TBL_HAZARDBASICINFOApi/PostZYListJson2\",\r\n            data: { condition: JSON.st" +
"ringify(WKTString), queryJson: JSON.stringify(queryJson) },\r\n            beforeS" +
"end: function (a) {\r\n                if (authToken != null)\r\n                   " +
" a.setRequestHeader(\"Authorization\", authToken);\r\n            },\r\n            ty" +
"pe: \"Post\",\r\n            dataType: \'json\',\r\n            success: function (data)" +
" {\r\n                var returnValue = [];\r\n                var type = [];\r\n     " +
"           for (var i = 0; i < data.length; i++) {\r\n                    //详情页面\r\n" +
"                    var divhtml = \'<div style=\"font-weight: bold;\"></div>\';\r\n   " +
"                 divhtml += \'<div style=\"font-weight: bold;margin-bottom:5px;\"><" +
"span style=\"margin-left:10px;\">灾害点名称：</span><span>\' + data[i].DISASTERNAME + \'</" +
"span></div>\';\r\n                    divhtml += \'<div style=\"margin-bottom:5px;\"><" +
"span style=\"margin-left:10px;\">灾害类型：</span><span>\' + data[i].DISASTERTYPE + \'</s" +
"pan></div>\';\r\n                    divhtml += \'<div><input type=\"hidden\" id=\"keyI" +
"D\" value=\"\' + data[i].UNIFIEDCODE + \'\"/></div>\';\r\n                    divhtml +=" +
" \'<div style=\"margin-bottom:5px;\"><span style=\"margin-left:10px;\">灾害点编号：</span><" +
"span>\' + data[i].UNIFIEDCODE + \'</span></div>\';\r\n                    divhtml += " +
"\'<div style=\"margin-bottom:5px;\"><span style=\"margin-left:10px;\">地理位置：</span><sp" +
"an>\' + data[i].LOCATION + \'</span></div>\';\r\n                    divhtml += \'<spa" +
"n style=\"margin-right:20px; float:right; cursor: pointer;\"><a onclick=\"ViewMonit" +
"orDetail(\\\'\' + data[i].UNIFIEDCODE + \'\\\')\" href=\"#\" class=\"link-detail\">详细信息</a>" +
"</span>\';\r\n                    var longitude, latitude;\r\n                    if " +
"(data[i].LONGITUDE) {\r\n                        longitude = parseFloat(data[i].LO" +
"NGITUDE);\r\n                    }\r\n                    if (data[i].LATITUDE) {\r\n " +
"                       latitude = parseFloat(data[i].LATITUDE);\r\n               " +
"     }\r\n                    returnValue.push({ id: \"all\", url: \"../../Content/im" +
"ages/\" + data[i].DISASTERTYPE + \"-16.png\", location: [longitude, latitude], popu" +
"pHtml: divhtml });\r\n\r\n\r\n                }\r\n                mapCtlExt.addMarker(r" +
"eturnValue);\r\n            }, error: function (e) {\r\n            },\r\n            " +
"cache: false\r\n        });\r\n\r\n    };\r\n    var mapCtlExt = null;\r\n    function Get" +
"MapData() {\r\n        mapCtlExt = $(\"#mapControl\").mapCtl(\r\n            cfGetMapD" +
"ata({\r\n                markerDataId: \"keyID\",\r\n                getMarkerData: ge" +
"tMarkerData,\r\n                gdzbdbx: true\r\n            })\r\n        );\r\n       " +
" usercode = \"");

            
            #line 357 "..\..\Areas\JXGeoManage\Views\TBL_QCQF_ADMINISTRATIVE\TBL_QCQF_ADMINISTRATIVEQueryBrowse.cshtml"
               Write(Infoearth.Application.Code.OperatorProvider.Provider.Current().XZQHCode);

            
            #line default
            #line hidden
WriteLiteral("\";\r\n        GetAreaGeometry(usercode);\r\n    }\r\n\r\n    //加载表格\r\n    function GetGrid" +
"() {\r\n        var selectedRowIndex = 0;\r\n        var queryJson = $(\"#search\").ge" +
"tWebControls();\r\n        queryJson[\"txt_Key\"] = $(\"#COMPPARAM\").val();\r\n        " +
"var $gridTable = $(\'#gridTable\');\r\n        $gridTable.jqGrid({\r\n            auto" +
"width: true,\r\n            postData: { queryJson: JSON.stringify(queryJson) },\r\n " +
"           height: $(window).height() - 529 + 12,\r\n            url: \"../../api/T" +
"BL_HAZARDBASICINFOApi/PostPageListJsonQCQFSearchNew\",\r\n            datatype: \"js" +
"on\",\r\n            mtype: \'POST\',\r\n            loadBeforeSend: function (a) {\r\n  " +
"              if (authToken != null)\r\n                    a.setRequestHeader(\"Au" +
"thorization\", authToken);\r\n            },\r\n            colModel: [\r\n            " +
"    { label: \'灾害点编号\', name: \'UNIFIEDCODE\', index: \'UNIFIEDCODE\', width: 300, ali" +
"gn: \'left\', sortable: false },\r\n                { label: \'灾害点名称\', name: \'DISASTE" +
"RNAME\', index: \'DISASTERNAME\', width: 500, align: \'left\', sortable: false },\r\n  " +
"              { label: \'灾害点类型\', name: \'DISASTERTYPE\', index: \'DISASTERTYPE\', wid" +
"th: 200, align: \'left\', sortable: false },\r\n                { label: \'监测责任人\', na" +
"me: \'MONITORRESPONSIBLE\', index: \'MONITORRESPONSIBLE\', width: 200, align: \'left\'" +
", sortable: false },\r\n                { label: \'监测责任人电话\', name: \'MONITORRESPONSI" +
"BLETEL\', index: \'MONITORRESPONSIBLETEL\', width: 200, align: \'left\', sortable: fa" +
"lse },\r\n                { label: \'群测群防人员\', name: \'GROUPMONITORINGSTAFF\', index: " +
"\'GROUPMONITORINGSTAFF\', width: 200, align: \'left\', sortable: false },\r\n         " +
"       { label: \'群测群防人员电话\', name: \'GROUPMONITORINGSTAFFTEL\', index: \'GROUPMONITO" +
"RINGSTAFFTEL\', width: 200, align: \'left\', sortable: false },\r\n                { " +
"label: \'经度\', name: \'LONGITUDE\', index: \'LONGITUDE\', width: 100, align: \'left\', s" +
"ortable: true, hidden: true },\r\n                { label: \'纬度\', name: \'LATITUDE\'," +
" index: \'LATITUDE\', width: 100, align: \'left\', sortable: true, hidden: true },\r\n" +
"                //{ label: \'险情等级\', name: \'DANGERLEVEL\', index: \'DANGERLEVEL\', wi" +
"dth: 200, align: \'left\', sortable: false },\r\n                //{ label: \'灾害等级\', " +
"name: \'DISASTERLEVEL\', index: \'DISASTERLEVEL\', width: 200, align: \'left\', sortab" +
"le: false },\r\n                 { label: \'地理位置\', name: \'LOCATION\', index: \'LOCATI" +
"ON\', width: 500, align: \'left\', sortable: false },\r\n                { label: \'市\'" +
", name: \'CITY\', index: \'CITY\', width: 100, align: \'left\', sortable: false, hidde" +
"n: true },\r\n                { label: \'市名称\', name: \'CITYNAME\', index: \'CITYNAME\'," +
" width: 100, align: \'left\', sortable: false, hidden: true },\r\n                { " +
"label: \'县\', name: \'COUNTY\', index: \'COUNTY\', width: 100, align: \'left\', sortable" +
": false, hidden: true },\r\n                { label: \'县名称\', name: \'COUNTYNAME\', in" +
"dex: \'COUNTYNAME\', width: 100, align: \'left\', sortable: false, hidden: true },\r\n" +
"                { label: \'乡镇\', name: \'TOWN\', index: \'TOWN\', width: 100, align: \'" +
"left\', sortable: false, hidden: true },\r\n                { label: \'乡镇名称\', name: " +
"\'TOWNNAME\', index: \'TOWNNAME\', width: 100, align: \'left\', sortable: false, hidde" +
"n: true },\r\n                { label: \'目前稳定程度\', name: \'CURSTABLESTATUS\', index: \'" +
"CURSTABLESTATUS\', width: 100, align: \'left\', sortable: false, hidden: true },\r\n " +
"               { label: \'今后变化趋势\', name: \'STABLETREND\', index: \'STABLETREND\', wid" +
"th: 100, align: \'left\', sortable: false, hidden: true },\r\n                { labe" +
"l: \'威胁人口\', name: \'THREATENPEOPLE\', index: \'THREATENPEOPLE\', width: 100, align: \'" +
"left\', sortable: false, hidden: true },\r\n                { label: \'威胁财产\', name: " +
"\'THREATENASSETS\', index: \'THREATENASSETS\', width: 100, align: \'left\', sortable: " +
"false, hidden: true },\r\n                { label: \'死亡人口\', name: \'DEATHTOLL\', inde" +
"x: \'DEATHTOLL\', width: 100, align: \'left\', sortable: false, hidden: true },\r\n   " +
"             { label: \'财产损失\', name: \'ASSETSLOSE\', index: \'ASSETSLOSE\', width: 10" +
"0, align: \'left\', sortable: false, hidden: true },\r\n                { label: \'防治" +
"建议\', name: \'TREATMENTSUGGESTION\', index: \'TREATMENTSUGGESTION\', width: 100, alig" +
"n: \'left\', sortable: false, hidden: true },\r\n                { label: \'隐患点\', nam" +
"e: \'HIDDENDANGER\', index: \'HIDDENDANGER\', width: 100, align: \'left\', sortable: f" +
"alse, hidden: true },\r\n                { label: \'监测建议\', name: \'MONITORSUGGESTION" +
"\', index: \'MONITORSUGGESTION\', width: 100, align: \'left\', sortable: false, hidde" +
"n: true }\r\n\r\n            ],\r\n            viewrecords: true,\r\n            rowNum:" +
" 30,\r\n            rowList: [30, 50, 100],\r\n            pager: \"#gridPager\",\r\n   " +
"         sortname: \'UNIFIEDCODE\',\r\n            sortorder: \'desc\',\r\n            r" +
"ownumbers: true,\r\n            shrinkToFit: true,\r\n            gridview: true,\r\n " +
"           onSelectRow: function (rowId, status) {\r\n                selectedRowI" +
"ndex = $(\'#\' + this.id).getGridParam(\'selrow\');\r\n                var dt = $gridT" +
"able.jqGrid(\"getRowData\", rowId);\r\n                var data = [];\r\n             " +
"   var longitude = 0, latitude = 0;\r\n                if (dt.LONGITUDE) {\r\n      " +
"              longitude = parseFloat(dt.LONGITUDE);\r\n                }\r\n        " +
"        if (dt.LATITUDE) {\r\n                    latitude = parseFloat(dt.LATITUD" +
"E);\r\n                }\r\n                data.push({ longitude: longitude, latitu" +
"de: latitude });\r\n                if (isMarkerClick) {\r\n                    isMa" +
"rkerClick = false;\r\n                } else {\r\n                    mapCtlExt.addL" +
"ocation(data, true);\r\n                }\r\n            },\r\n            gridComplet" +
"e: function () {\r\n                $(\'#\' + this.id).setSelection(selectedRowIndex" +
", false);\r\n            }\r\n        });\r\n    }\r\n\r\n    //查询表格函数\r\n    function Searc" +
"hEvent() {\r\n        var queryJson = $(\"#GJCX\").getWebControls();\r\n        queryJ" +
"son[\"txt_Key\"] = $(\"#COMPPARAM\").val();\r\n        queryJson[\"PROVINCE\"] = PROVINC" +
"E;\r\n        queryJson[\"CITY\"] = CITY;\r\n        queryJson[\"COUNTY\"] = COUNTY;\r\n  " +
"      BindMapMarker();\r\n        $(\"#gridTable\").jqGrid(\'setGridParam\', {\r\n      " +
"      postData: { condition: JSON.stringify(WKTString), queryJson: JSON.stringif" +
"y(queryJson) },\r\n            loadBeforeSend: function (a) {\r\n                a.s" +
"etRequestHeader(\"Authorization\", authToken);\r\n            },\r\n            url: \"" +
"../../api/TBL_HAZARDBASICINFOApi/PostPageListJsonQCQFSearchNew\",\r\n            pa" +
"ge: 1,\r\n            mtype: \'Post\',\r\n        }).trigger(\'reloadGrid\');\r\n    }\r\n  " +
"  //获取点击Marker时对应的数据\r\n    var isMarkerClick = false;\r\n    function getMarkerData" +
"(UNIFIEDCODE) {\r\n        isMarkerClick = true;\r\n        var datas = $(\'#gridTabl" +
"e\').jqGrid(\"getRowData\");\r\n        var count = 0;\r\n        $.each(datas, functio" +
"n (i, e) {\r\n            if (e.UNIFIEDCODE.trim().indexOf(UNIFIEDCODE) > -1) {\r\n " +
"               count = 1;\r\n                $(\'#gridTable\').setSelection(i + 1);\r" +
"\n                $(\'#gridTable tr\').eq(i + 1).focus();\r\n            }\r\n        }" +
");\r\n        if (count == 0) {\r\n            var queryJson = {}, WKT = {};\r\n      " +
"      queryJson[\"COMPPARAM\"] = UNIFIEDCODE;\r\n            $.ajax({\r\n             " +
"   url: \"../../api/TBL_HAZARDBASICINFOApi/PostPageListJsonQCQFSearchNew\",\r\n     " +
"           beforeSend: function (request) {\r\n                    request.setRequ" +
"estHeader(\"Authorization\", authToken);\r\n                },\r\n                data" +
": { condition: JSON.stringify(WKT), queryJson: JSON.stringify(queryJson) },\r\n   " +
"             type: \"get\",\r\n                dataType: \"json\",\r\n                su" +
"ccess: function (res) {\r\n                    var rowId = datas.length + 1;\r\n    " +
"                $(\"#gridTable\").addRowData(rowId.toString(), res);\r\n            " +
"        window.setTimeout(function () { $(\'#gridTable\').setSelection(rowId); }, " +
"200);\r\n                    $(\'#gridTable tr:last\').focus();\r\n                },\r" +
"\n            });\r\n        };\r\n    };\r\n    function ColDataGrid() {\r\n        var " +
"centerHeight = $(\"#layout2\").height();\r\n        var layout2 = $(\'#layout2\').layo" +
"ut();\r\n        if ($(\"#lr-colgrid i\").hasClass(\"fa-chevron-down\")) {\r\n          " +
"  var northH = centerHeight - 90;\r\n            layout2.sizePane(\"north\", northH)" +
";\r\n            $(\"#lr-colgrid i\").removeClass(\"fa-chevron-down\");\r\n            $" +
"(\"#lr-colgrid i\").addClass(\"fa-chevron-up\");\r\n            if ($(\"#lr-colmap i\")." +
"hasClass(\"fa-chevron-down\")) {\r\n                $(\"#lr-colmap i\").removeClass(\"f" +
"a-chevron-down\");\r\n                $(\"#lr-colmap i\").addClass(\"fa-chevron-up\");\r" +
"\n            }\r\n        }\r\n        else {\r\n            layout2.sizePane(\"north\"," +
" layout2NorthH);\r\n            $(\"#lr-colgrid i\").removeClass(\"fa-chevron-up\");\r\n" +
"            $(\"#lr-colgrid i\").addClass(\"fa-chevron-down\");\r\n        }\r\n        " +
"mapCtlExt.updateSize();\r\n    }\r\n\r\n    function ColMapDiv() {\r\n        var layout" +
"2 = $(\'#layout2\').layout();\r\n        if ($(\"#lr-colmap i\").hasClass(\"fa-chevron-" +
"up\")) {\r\n            layout2.sizePane(\"north\", 1);\r\n            $(\"#lr-colmap i\"" +
").removeClass(\"fa-chevron-up\");\r\n            $(\"#lr-colmap i\").addClass(\"fa-chev" +
"ron-down\");\r\n            if ($(\"#lr-colgrid i\").hasClass(\"fa-chevron-up\")) {\r\n  " +
"              $(\"#lr-colgrid i\").removeClass(\"fa-chevron-up\");\r\n                " +
"$(\"#lr-colgrid i\").addClass(\"fa-chevron-down\");\r\n            }\r\n        }\r\n     " +
"   else {\r\n            layout2.sizePane(\"north\", layout2NorthH);\r\n            $(" +
"\"#lr-colmap i\").removeClass(\"fa-chevron-down\");\r\n            $(\"#lr-colmap i\").a" +
"ddClass(\"fa-chevron-up\");\r\n            if (mapCtlExt != null) {\r\n               " +
" mapCtlExt.setHeight($(\"#mapControl\").parent().height() - 32 - 4);\r\n            " +
"}\r\n        }\r\n        mapCtlExt.updateSize();\r\n    }\r\n    //初始化控件\r\n    function " +
"initControl() {\r\n        //灾害类型\r\n        $(\"#DISASTERTYPE\").ComboBox({\r\n        " +
"    url: \"../../SystemManage/DataItemDetail/GetDataItemTreeJson\",\r\n            p" +
"aram: { EnCode: \"HazardType\" },\r\n            id: \"text\",\r\n            text: \"tex" +
"t\",\r\n            height: \'200px\',\r\n            description: \"==请选择==\"\r\n        }" +
");\r\n    }\r\n    //点击详情按钮显示两卡一表信息\r\n    function btn_message() {\r\n        var keyVa" +
"lue = $(\"#gridTable\").jqGridRowValue(\'UNIFIEDCODE\');\r\n        if (checkedRow(key" +
"Value)) {\r\n            ViewMonitorDetail(keyValue);\r\n        }\r\n    }\r\n    funct" +
"ion ViewMonitorDetail(keyValue) {\r\n        newTabs({\r\n            id: \"DZQCQFXQ\"" +
",\r\n            url: \'/JXGeoManage/TBL_QCQF_ADMINISTRATIVE/TBL_QCQF_ADMINISTRATIV" +
"EForm?keyValue=\' + keyValue + \'&IdetIfrem=Idetnew&UNIFIEDCODE=\' + keyValue + \'&R" +
"eadonaly=01&XQing=01&details=01&callback=1\'\r\n        });\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591