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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_ACHIEVEMENT_PREPLAN/TBL_ACHIEVEMENT_PREPLANQueryBro" +
        "wse.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_ACHIEVEMENT_PREPLAN_TBL_ACHIEVEMENT_PREPLANQueryBrowse_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_ACHIEVEMENT_PREPLAN_TBL_ACHIEVEMENT_PREPLANQueryBrowse_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_ACHIEVEMENT_PREPLAN\TBL_ACHIEVEMENT_PREPLANQueryBrowse.cshtml"
  
    ViewBag.Title = "防治规划查询浏览列表页面";
    Layout = "~/Views/Shared/_IndexMap.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n <style>\r\n    .ui-layout-center {\r\n       overflow-x: hidden !important;\r\n    }" +
"\r\n    .ui-layout-resizer {\r\n        background-color:#f0f3f4 !important;\r\n    }\r" +
"\n     .fa-folder-open {\r\n         color: transparent !important;\r\n         backg" +
"round: url(\"../../Content/images/zTreeStandard.png\") no-repeat;\r\n         backgr" +
"ound-position: -110px -16px;\r\n         margin-right: 2px;\r\n         width: 16px " +
"!important;\r\n         height: 16px !important;\r\n     }\r\n\r\n     .fa-folder {\r\n   " +
"      color: transparent !important;\r\n         background: url(\"../../Content/im" +
"ages/zTreeStandard.png\") no-repeat;\r\n         background-position: -110px 0;\r\n  " +
"       margin-right: 2px;\r\n         width: 16px !important;\r\n         height: 16" +
"px !important;\r\n     }\r\n\r\n     .fa-file-o {\r\n         color: transparent !import" +
"ant;\r\n         background: url(\"../../Content/images/zTreeStandard.png\") no-repe" +
"at;\r\n         background-position: -110px -32px;\r\n         width: 16px !importan" +
"t;\r\n         height: 16px !important;\r\n     }\r\n     .titleserch {\r\n        color" +
":#000;\r\n        width:100%;\r\n        height:40px;\r\n        background-color: rgb" +
"a(236, 247, 255, 1);\r\n        display:flex;\r\n        align-items: center;\r\n     " +
"   position:relative;\r\n        z-index:23;\r\n        justify-content: start;\r\n   " +
"     font-size:14px\r\n     }\r\n    .spans {\r\n        padding: 0 20px !important;\r\n" +
"        width:9%;\r\n        text-align:center;\r\n        height:28px;\r\n        lin" +
"e-height:28px;\r\n        min-width:100px;\r\n        white-space: nowrap;\r\n    }\r\n " +
"    .spansa {\r\n        padding: 0 20px !important;\r\n        width:9%;\r\n        t" +
"ext-align:center;\r\n        height:28px;\r\n        line-height:28px;\r\n        min-" +
"width:113px;\r\n        white-space: nowrap;\r\n     }\r\n     .form-control, .ui-sele" +
"ct, .ui-select-text {\r\n         border-radius: 3px;\r\n     }\r\n</style>\r\n<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(" style=\"margin:0\"");

WriteLiteral(">\r\n             <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">行政区划信息</div>\r\n             <div");

WriteLiteral(" id=\"itemTree\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" id=\"ui_center\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(" style=\"height: 100%;margin:0\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" id=\"GJCX\"");

WriteLiteral(" style=\"position:absolute;top:-120px;z-index:3;width:100%;transition:all 0.6s\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"\"");

WriteLiteral(" style=\"width: 100%; height: 40px;background-color: rgba(255, 255, 255, 0.8);colo" +
"r:#000; display: flex; align-items: center; position: relative;\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">成果名称:</span><input");

WriteLiteral(" id=\"ACHIEVEMENTNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral(" />\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">灾害点名称:</span><input");

WriteLiteral(" id=\"DISASTERNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral(" />\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">编写人:</span><input");

WriteLiteral(" id=\"CREATENAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  style=\"width: 16%\"");

WriteLiteral("/>\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">规划区域类型:</span><div");

WriteLiteral(" id=\"AREATYPE\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n                    </div>\r\n                    <div");

WriteLiteral(" id=\"\"");

WriteLiteral(" style=\"width: 100%; height: 40px;background-color: rgba(255, 255, 255, 0.8);colo" +
"r:#000; display: flex; align-items: center; position: relative;\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">规划时间类型:</span><div");

WriteLiteral(" id=\"TIMETYPE\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">地灾防治类型:</span><div");

WriteLiteral(" id=\"DISASTERTYPE\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">防治类容:</span><input");

WriteLiteral(" id=\"PREVENTION\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  style=\"width: 16%\"");

WriteLiteral("/>\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">开始时间:</span><input");

WriteLiteral(" id=\"PREPLANSTARTTIME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({ dateFmt: \'yyyy\' })\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral(" />\r\n                    </div>\r\n                    <div");

WriteLiteral(" id=\"\"");

WriteLiteral(" style=\"width: 100%; height: 40px;background-color: rgba(255, 255, 255, 0.8);colo" +
"r:#000; display: flex; align-items: center; position: relative;\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">结束时间:</span><input");

WriteLiteral(" id=\"PREPLANENDTIME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({ dateFmt: \'yyyy\' })\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral(" />\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" id=\"btn_Search_higher\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"cursor: pointer; color: white;padding:4px 4px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>查询</a>\r\n                        </span>\r\n                        <div");

WriteLiteral(" style=\"width:16%\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" id=\"btn_Reset\"");

WriteLiteral(" style=\"background:gray;border-color:gray;height:28px;padding:4px 12px; color: wh" +
"ite; cursor: pointer;\"");

WriteLiteral(">重置</a>\r\n                        </div>\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral("></span><div");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral("></span><div");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n                    </div>\r\n                </div>\r\n        <div");

WriteLiteral(" class=\"titleserch\"");

WriteLiteral(" id=\"easySeach\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" style=\"width: 8%; min-width: 80px; white-space: nowrap;\"");

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-bars\"");

WriteLiteral(" style=\"margin:0 5px;font-weight:900\"");

WriteLiteral("></i><span>查询条件:</span>\r\n            </div>\r\n            <div");

WriteLiteral(" style=\"width:83%;height:100%;display:flex;align-items: center;\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"COMPPARAM\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"灾害点名称、成果名称\"");

WriteLiteral(" style=\"width: 240px;\"");

WriteLiteral(" />\r\n                <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" style=\"font-size:16px; cursor:pointer;margin-left:20px\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral(" style=\"margin: -9px 10px 0px 0px\"");

WriteLiteral("></i></a>\r\n            </div>\r\n            <div");

WriteLiteral(" style=\"width: 9%;display:flex;align-items: center;flex-wrap: nowrap;justify-cont" +
"ent: flex-end;\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" id=\"serch-btn\"");

WriteLiteral(" style=\"font-size:13px;float:right;margin-right:10px;cursor:pointer\"");

WriteLiteral("><i");

WriteLiteral(" id=\"fontfamily\"");

WriteLiteral(" class=\"fa fa-caret-right\"");

WriteLiteral(" style=\"padding-right: 3px;display:inline-block;width:7px;height:7px\"");

WriteLiteral("></i>高级查询</span>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout2\"");

WriteLiteral(" style=\"height: calc(100% - 40px); width: 100%;\"");

WriteLiteral(">\r\n           <div");

WriteLiteral(" class=\"ui-layout-north\"");

WriteLiteral(" id=\"ui_map\"");

WriteLiteral(" style=\"height: 350px;\"");

WriteLiteral(">\r\n                  <div");

WriteLiteral(" id=\"mapControl\"");

WriteLiteral(" style=\"height:350px;\"");

WriteLiteral("></div>\r\n          </div>\r\n          <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" id=\"ui_grid\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(" style=\"height:40px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(" id=\"DZHJManage\"");

WriteLiteral(" style=\"height: 40px; line-height: 40px; width: 100%\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(" style=\"color:#000;margin-right:10px;\"");

WriteLiteral(">数据列表</span>\r\n                            ");

WriteLiteral("\r\n                            <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(" style=\"float: right; height: 100%; display: flex; align-items: center;margin-rig" +
"ht:23px\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"reload()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>刷新</a>\r\n                                <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_Word()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>下载成果</a>\r\n                                <a");

WriteLiteral(" id=\"lr-message\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_message()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pencil-square-o\"");

WriteLiteral("></i>详情</a>\r\n                                <a");

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

WriteLiteral("></i>地图</a>\r\n                            </div>\r\n                        </div>\r\n" +
"                        <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n                    </div>\r\n                  <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n                      <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n                    <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n                   </div>\r\n              </div>\r\n          </div>\r\n     " +
"  </div>\r\n    </div>\r\n </div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var layout2NorthH = 1;\r\n    var authToken = getAuthorizationToken" +
"();\r\n    $(function () {\r\n        mapshow = true;\r\n        InitialPage();\r\n     " +
"   GetTree();\r\n        GetMapData();\r\n        GetGrid();\r\n        BindMapMarker(" +
");\r\n        //查询点击事件\r\n        $(\"#btn_Search\").click(function () {\r\n            " +
"SearchEvent();\r\n        });\r\n        //高级查询点击事件\r\n        $(\"#btn_Search_higher\")" +
".click(function () {\r\n            SearchEvent_higher();\r\n        })\r\n        var" +
" flag = true;\r\n        $(\"#serch-btn\").click(function () {\r\n            if (flag" +
") {\r\n                $(\"#GJCX\").css(\"top\", 40)\r\n                $(\"#fontfamily\")" +
".removeClass();\r\n                $(\"#fontfamily\").addClass(\"fa fa-caret-down\")\r\n" +
"                flag = false\r\n            } else {\r\n                $(\"#GJCX\").c" +
"ss(\"top\", -120)\r\n                $(\"#fontfamily\").removeClass();\r\n              " +
"  $(\"#fontfamily\").addClass(\"fa fa-caret-right\")\r\n                flag = true\r\n " +
"           }\r\n        })\r\n        $(\"#AREATYPE\").comboBox({\r\n            EnCode:" +
" \"AREATYPE\",\r\n            id: \"value\",\r\n            text: \"text\",\r\n            h" +
"eight: \"130px\"\r\n        })\r\n        $(\"#TIMETYPE\").comboBox({\r\n            EnCod" +
"e: \"TIMETYPE\",\r\n            id: \"value\",\r\n            text: \"text\",\r\n           " +
" height: \"130px\"\r\n        })\r\n        $(\"#DISASTERTYPE\").comboBox({\r\n           " +
" EnCode: \"DISASTERTYPE\",\r\n            id: \"value\",\r\n            text: \"text\",\r\n " +
"           height: \"130px\"\r\n        })\r\n    });\r\n    //初始化页面\r\n    function Initi" +
"alPage() {\r\n        //layout布局\r\n        $(\'#layout\').layout({\r\n                w" +
"est__size: 190,\r\n                applyDemoStyles: true,\r\n                onresiz" +
"e: function () {\r\n                if (isResize < 10) {\r\n                    isRe" +
"size++;\r\n                }\r\n                resize();\r\n             }\r\n         " +
"});\r\n        var isResize = 0;\r\n        var count = 0;\r\n        var resized = 0;" +
"\r\n        $(\'#layout2\').layout({\r\n            applyDemoStyles: true,\r\n          " +
"  onresize: function () {\r\n                resize();\r\n                if (isResi" +
"ze > 1) {\r\n                resized = 1;\r\n                 } else {\r\n            " +
"        if (count == 1 || resized == 0) {\r\n                        $(\'#layout2 ." +
"ui-layout-center\').height($(\'#layout2 .ui-layout-center\').height() - 18);\r\n     " +
"               }\r\n                 }\r\n                  count++;\r\n             }" +
"\r\n         });\r\n          //resize重设布局;\r\n         $(window).resize(function (e) " +
"{\r\n              if (isResize<10) {\r\n                 isResize ++;\r\n            " +
"  }\r\n              resize();\r\n              e.stopPropagation();\r\n         });\r\n" +
"         function resize() {\r\n              window.setTimeout(function () {\r\n   " +
"               if (mapCtlExt != null) {\r\n                        mapCtlExt.setHe" +
"ight($(\'#mapControl\').parent().height() - 4);\r\n                  }\r\n            " +
"      $(\'.center-Panel\').height($(\'#layout\').parent().height() - 2);\r\n          " +
"        $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').width()));\r\n              " +
"    $(\'#layout2 .ui-layout-center\').width($(\'#layout2 .ui-layout-center\').parent" +
"().width() - 10);\r\n                  $(\'#layout2 .ui-layout-resizer\').width($(\'#" +
"layout2 .ui-layout-center\').parent().width() - 10);\r\n                  $(\'#gridT" +
"able\').setGridHeight($(window).height() - $(\'#mapControl\').height() - $(\'.panel-" +
"Title\').height());\r\n                  $(\'#gridTable\').setGridHeight($(\'#layout2 " +
".ui-layout-center\').height() - 60 - 60);\r\n                  $(\'.ui-jqgrid-bdiv\')" +
".height($(\'#layout2 .ui-layout-center\').height() - 60 - 60);\r\n                  " +
"$(\'#itemTree\').setTreeHeight($(window).height() - 52);\r\n                  $(\'#la" +
"yout2 .ui-layout-center\').height($(\'#layout2\').height() - $(\'#layout2 .ui-layout" +
"-north\').height() - 5);\r\n                  $(\'#gridTable\').setGridHeight($(\'#lay" +
"out2 .ui-layout-center\').height() - 105 + 8);\r\n                  $(\'#layout2 .ui" +
"-layout-center\').css(\'overflow\', \'hidden\');\r\n              }, 200);\r\n           " +
"};\r\n           $(window).resize();\r\n           $(\'#layout2 .ui-layout-center\').h" +
"eight($(\'#layout2 .ui-layout-center\').height() - 18);\r\n           layout2NorthH " +
"= $(\"#layout2 .ui-layout-north\").height();\r\n     }\r\n    //加载行政区划树\r\n    var AreaC" +
"ode = 0, PROVINCE = \"\", CITY = \"\", COUNTY = \"\";\r\n    function GetTree() {\r\n     " +
"   var item = {\r\n            height: $(window).height() - 52,\r\n            isAll" +
"Expand: false,\r\n            url: \"../../Map/GetTreeJsonForMap\",\r\n            onn" +
"odeclick: function (item) {\r\n                AreaCode = item.id;\r\n              " +
"  var level = item.value.split(\',\')[1];\r\n                if (level == 1) {\r\n    " +
"                PROVINCE = item.id;\r\n                    CITY = \"\";\r\n           " +
"         COUNTY = \"\";\r\n                } else if (level == 2) {\r\n               " +
"     PROVINCE = item.id.substring(0, 2) + \"0000\";\r\n                    CITY = it" +
"em.id;\r\n                    COUNTY = \"\";\r\n                } else if (level == 3)" +
" {\r\n                    PROVINCE = item.id.substring(0, 2) + \"0000\";\r\n          " +
"          CITY = item.id.substring(0, 4) + \"00\";\r\n                    COUNTY = i" +
"tem.id;\r\n                }\r\n                var data = [{\r\n                    l" +
"atitude: item.value.split(\',\')[3],\r\n                    longitude: item.value.sp" +
"lit(\',\')[2],\r\n                    popupHtml: \"\"\r\n                }]\r\n           " +
"     mapCtlExt.addLocation(data,false,level);\r\n                $(\'#btn_Search\')." +
"trigger(\"click\");\r\n            },\r\n        };\r\n        //初始化\r\n        $(\"#itemTr" +
"ee\").treeview(item);\r\n    };\r\n    //加载地图\r\n    var mapCtlExt = null;\r\n    functio" +
"n GetMapData() {\r\n          $.ajax({\r\n             url: \'../../Map/GetMapDatas\'," +
"\r\n             async: false,\r\n             type: \"GET\",\r\n             success: f" +
"unction (data) {\r\n                       var dataSet = JSON.parse(data);\r\n      " +
"                  mapCtlExt= $(\"#mapControl\").mapCtl({\r\n                        " +
"        mapwidth: 1500,\r\n                                isShowGisLayer:false,\r\n" +
"                                isFrame:true,\r\n                                d" +
"ataset: dataSet,\r\n                                zoom: center.split(\',\')[2],\r\n " +
"                               center: [center.split(\',\')[0], center.split(\',\')[" +
"1]],\r\n                                isCluster: true\r\n                         " +
"    });\r\n                        }, error: function (e) {\r\n                    }" +
",\r\n             cache: false\r\n         });\r\n    };\r\n\r\n    //加载地图marker\r\n    func" +
"tion BindMapMarker() {\r\n        var queryJson = $.extend($(\"#filter-form\").getWe" +
"bControls(), $(\"#easySeach\").getWebControls(), $(\"#GJCX\").getWebControls());\r\n  " +
"      $.ajax({\r\n            url: contentPath + \"/api/TBL_ACHIEVEMENT_PREPLAN/Pos" +
"tZYListJson\",\r\n            beforeSend: function (a) {\r\n                if (authT" +
"oken != null)\r\n                    a.setRequestHeader(\"Authorization\", authToken" +
");\r\n            },\r\n            datatype: \'json\',\r\n            data: { condition" +
": JSON.stringify(WKTString), queryJson: JSON.stringify(queryJson) },\r\n          " +
"  async: true,\r\n            cache: false,\r\n            type: \"Post\",\r\n          " +
"  success: function (dataList) {\r\n                var data = eval(dataList);\r\n  " +
"              var returnValue = [];\r\n                var type = [];\r\n           " +
"     for (var i = 0; i < data.length; i++) {\r\n                    //详情页面\r\n      " +
"              var divhtml = \'<div style=\"font-weight: bold;\"></div>\';\r\n         " +
"           divhtml += \'<div style=\"font-weight: bold;margin-bottom:5px;\"><span s" +
"tyle=\"margin-left:10px;\">治理工程名称：</span><span>\' + data[i].ACHIEVEMENTNAME + \'</sp" +
"an></div>\';\r\n                    divhtml += \'<div style=\"margin-bottom:5px;\"><sp" +
"an style=\"margin-left:10px;\">灾害点名称：</span><span>\' + data[i].DISASTERNAME + \'</sp" +
"an></div>\';\r\n                    divhtml += \'<div style=\"margin-bottom:5px;\"><sp" +
"an style=\"margin-left:10px;\">灾害点类型：</span><span>\' + data[i].DISASTERTYPE + \'</sp" +
"an></div>\';\r\n                    divhtml += \'<div style=\"margin-bottom:5px;\"><sp" +
"an style=\"margin-left:10px;\">成果地理位置：</span><span>\' + data[i].LOCATION + \'</span>" +
"</div>\';\r\n                   \r\n                    var longitude, latitude;\r\n   " +
"                 if (data[i].LONGITUDE) {\r\n                        longitude = p" +
"arseFloat(DFMZH(data[i].LONGITUDE));\r\n                    }\r\n                   " +
" if (data[i].LATITUDE) {\r\n                        latitude = parseFloat(DFMZH(da" +
"ta[i].LATITUDE));\r\n                    }\r\n                    returnValue.push({" +
" id: \"all\", url: contentPath + \"/Content/images/规划成果.png\", location: [longitude," +
" latitude], popupHtml: divhtml });\r\n\r\n                }\r\n                mapCtlE" +
"xt.addMarker(returnValue);\r\n            }, error: function (e) {\r\n            }," +
"\r\n            cache: false\r\n        });\r\n    };\r\n\r\n\r\n    //加载表格\r\n    function Ge" +
"tGrid() {\r\n        var selectedRowIndex = 0;\r\n        var queryJson = $.extend($" +
"(\"#filter-form\").getWebControls(), $(\"#easySeach\").getWebControls(), $(\"#GJCX\")." +
"getWebControls());\r\n        queryJson[\"AreaCode\"] = AreaCode;\r\n        var $grid" +
"Table = $(\'#gridTable\');\r\n        $gridTable.jqGrid({\r\n            autowidth: tr" +
"ue,\r\n            loadBeforeSend: function (a) {\r\n                a.setRequestHea" +
"der(\"Authorization\", authToken);\r\n            },\r\n            postData: { queryJ" +
"son: JSON.stringify(queryJson) },\r\n            height: $(window).height() - 560 " +
"+ 8,\r\n            url: \"../../api/TBL_ACHIEVEMENT_PREPLAN/PostPageListJson\",\r\n  " +
"          datatype: \"json\",\r\n            mtype:\'Post\',\r\n            colModel: [\r" +
"\n                { label: \'主键\', name: \'GUID\', index: \'GUID\', width: 100, align: " +
"\'left\', sortable: true, hidden: true },\r\n                { label: \'成果名称\', name: " +
"\'ACHIEVEMENTNAME\', index: \'ACHIEVEMENTNAME\', width: 200, align: \'left\', sortable" +
": true },\r\n                { label: \'灾害点名称\', name: \'DISASTERNAME\', index: \'DISAS" +
"TERNAME\', width: 250, align: \'left\', sortable: true },\r\n                {\r\n     " +
"               label: \'规划区域类型\', name: \'AREATYPE\', index: \'AREATYPE\', width: 150," +
" align: \'left\', sortable: true,\r\n                    formatter: function (cellva" +
"lue, options, rowObject) {\r\n                        if (cellvalue == \"A\") {\r\n   " +
"                         return \'国家规划\';\r\n                        }\r\n            " +
"            else if (cellvalue == \"B\") {\r\n                            return \'地区" +
"规划\';\r\n                        }\r\n                        else if (cellvalue == \"" +
"C\") {\r\n                            return \'流域规划\';\r\n                        }\r\n  " +
"                      else\r\n                            return \"\";\r\n            " +
"        }\r\n\r\n                },\r\n                {\r\n                    label: \'" +
"规划时间类型\', name: \'TIMETYPE\', index: \'TIMETYPE\', width: 150, align: \'left\', sortabl" +
"e: true,\r\n                    formatter: function (cellvalue, options, rowObject" +
") {\r\n                        if (cellvalue == \"A\") {\r\n                          " +
"  return \'超长期规划\';\r\n                        }\r\n                        else if (c" +
"ellvalue == \"B\") {\r\n                            return \'长期规划\';\r\n                " +
"        }\r\n                        else if (cellvalue == \"C\") {\r\n               " +
"             return \'中期规划\';\r\n                        }\r\n                        " +
"else if (cellvalue == \"D\") {\r\n                            return \'短期规划\';\r\n      " +
"                  }\r\n                        else\r\n                            r" +
"eturn \"\";\r\n                    }\r\n                },\r\n                {\r\n       " +
"             label: \'地质灾害类型\', name: \'DISASTERTYPE\', index: \'DISASTERTYPE\', width" +
": 150, align: \'left\', sortable: true,\r\n                    formatter: function (" +
"cellvalue, options, rowObject) {\r\n                        if (cellvalue == \"A\") " +
"{\r\n                            return \'单类地质灾害防治规划\';\r\n                        }\r\n" +
"                        else if (cellvalue == \"B\") {\r\n                          " +
"  return \'综合地质灾害防治规划\';\r\n                        }\r\n                        else\r" +
"\n                            return \"\";\r\n                    }\r\n                " +
"},\r\n                { label: \'方案编写人\', name: \'WRITENAME\', index: \'WRITENAME\', wid" +
"th: 100, align: \'left\', sortable: true },\r\n                { label: \'方案编写日期\', na" +
"me: \'WRITETIME\', index: \'WRITETIME\', width: 150, align: \'left\', sortable: true }" +
",\r\n                { label: \'方案版本号\', name: \'VESION\', index: \'VESION\', width: 150" +
", align: \'left\', sortable: true },\r\n                {\r\n                    label" +
": \'成果文件\', name: \'DOWNLOAD\', index: \'DOWNLOAD\', width: 100, align: \'left\', sortab" +
"le: true,\r\n                    formatter: function (cellvalue, options, rowObjec" +
"t) {\r\n                        return \"<a class=\\\"label-success btn\\\" onclick=\\\"M" +
"ultiMediaView(\'\" + rowObject.GUID + \"\')\\\"><i class=\'fa fa-smile-o\'></i>&nbsp;查看<" +
"/a>\";\r\n                    }\r\n                },\r\n                { label: \'防治内容" +
"\', name: \'PREVENTION\', index: \'PREVENTION\', width: 100, align: \'left\', sortable:" +
" true, hidden: true },\r\n                { label: \'目前稳定程度\', name: \'CURSTABLESTATU" +
"S\', index: \'CURSTABLESTATUS\', width: 100, align: \'left\', sortable: true, hidden:" +
" true },\r\n                { label: \'今后变化趋势\', name: \'STABLETREND\', index: \'STABLE" +
"TREND\', width: 100, align: \'left\', sortable: true, hidden: true },\r\n            " +
"    { label: \'防治原则和目标\', name: \'PRINCIPLEGOAL\', index: \'PRINCIPLEGOAL\', width: 10" +
"0, align: \'left\', sortable: true, hidden: true },\r\n                { label: \'总体部" +
"署和主要任务\', name: \'MAINTAST\', index: \'MAINTAST\', width: 100, align: \'left\', sortabl" +
"e: true, hidden: true },\r\n                { label: \'防治预期效果\', name: \'DESIREDRESUL" +
"T\', index: \'DESIREDRESULT\', width: 100, align: \'left\', sortable: true, hidden: t" +
"rue },\r\n                { label: \'易发区域\', name: \'PRONEAREA\', index: \'PRONEAREA\', " +
"width: 100, align: \'left\', sortable: true, hidden: true },\r\n                { la" +
"bel: \'重点防治区域\', name: \'MAINPREVENTAREA\', index: \'MAINPREVENTAREA\', width: 100, al" +
"ign: \'left\', sortable: true, hidden: true },\r\n                { label: \'方案录入人\', " +
"name: \'CREATENAME\', index: \'CREATENAME\', width: 100, align: \'left\', sortable: tr" +
"ue, hidden: true },\r\n                { label: \'方案录入日期\', name: \'CREATETIME\', inde" +
"x: \'CREATETIME\', width: 100, align: \'left\', sortable: true, hidden: true },\r\n   " +
"             { label: \'灾害点编号\', name: \'UNIFIEDCODE\', index: \'UNIFIEDCODE\', width:" +
" 100, align: \'left\', sortable: true, hidden: true },\r\n                { label: \'" +
"地理位置\', name: \'LOCATION\', index: \'LOCATION\', width: 100, align: \'left\', sortable:" +
" true, hidden: true },\r\n                { label: \'经度\', name: \'LONGITUDE\', index:" +
" \'LONGITUDE\', width: 100, align: \'left\', sortable: true, hidden: true },\r\n      " +
"          { label: \'纬度\', name: \'LATITUDE\', index: \'LATITUDE\', width: 100, align:" +
" \'left\', sortable: true, hidden: true },\r\n                { label: \'省名称\', name: " +
"\'PROVINCENAME\', index: \'PROVINCENAME\', width: 100, align: \'left\', sortable: true" +
", hidden: true },\r\n                { label: \'市名称\', name: \'CITYNAME\', index: \'CIT" +
"YNAME\', width: 100, align: \'left\', sortable: true, hidden: true },\r\n            " +
"    { label: \'乡镇名称\', name: \'TOWNNAME\', index: \'TOWNNAME\', width: 100, align: \'le" +
"ft\', sortable: true, hidden: true },\r\n                { label: \'县名称\', name: \'COU" +
"NTYNAME\', index: \'COUNTYNAME\', width: 100, align: \'left\', sortable: true, hidden" +
": true },\r\n            ],\r\n            viewrecords: true,\r\n            rowNum: 3" +
"0,\r\n            rowList: [30, 50, 100],\r\n            pager: \"#gridPager\",\r\n     " +
"       sortname: \'GUID\',\r\n            sortorder: \'desc\',\r\n            rownumbers" +
": true,\r\n            shrinkToFit: false,\r\n            gridview: true,\r\n         " +
"   onSelectRow:  function(rowId, status) {\r\n                selectedRowIndex = $" +
"(\'#\' + this.id).getGridParam(\'selrow\');\r\n                var dt = $gridTable.jqG" +
"rid(\"getRowData\", rowId);\r\n                var data = [];\r\n                var l" +
"ongitude = 0, latitude = 0;\r\n                if (dt.LONGITUDE) {\r\n              " +
"      longitude = parseFloat(DFMZH(dt.LONGITUDE));\r\n                }\r\n         " +
"       if (dt.LATITUDE) {\r\n                    latitude = parseFloat(DFMZH(dt.LA" +
"TITUDE));\r\n                }\r\n                data.push({ longitude: longitude, " +
"latitude: latitude });\r\n                mapCtlExt.addLocation(data,true);\r\n     " +
"       },\r\n            gridComplete: function () {\r\n                $(\'#\' + this" +
".id).setSelection(selectedRowIndex, false);\r\n            }\r\n        });\r\n    }\r\n" +
"\r\n    //规划治理多媒体\r\n    function MultiMediaView(GUID) {\r\n        //top.tablist.newT" +
"ab({\r\n            dialogOpen({\r\n            id: \"DataInspection\" + GUID,\r\n      " +
"      title: \"防治规划成果中文件详情\",\r\n            closed: true,\r\n            replace: tru" +
"e,\r\n            width: \'1100px\',\r\n            height: \'640px\',\r\n            url:" +
" top.contentPath + \"/JXGeoManage/TBL_ACHIEVEMENT_PREPLAN/TBL_PREPLANMultiMedia?k" +
"eyValue=\" + GUID \r\n        })\r\n    }\r\n\r\n\r\n    //详情\r\n    function btn_message() {" +
"\r\n        var keyValue = $(\"#gridTable\").jqGridRowValue(\'GUID\');\r\n        var ur" +
"l = document.location.protocol + \"//\" + document.location.host + \'/JXGeoManage/T" +
"BL_ACHIEVEMENT_PREPLAN/TBL_ACHIEVEMENT_PREPLANForm?&keyValue=\' + keyValue + \'&re" +
"adonly=01\' + \"&callback=\" + window.document.URL;\r\n        window.document.locati" +
"on.href = url;\r\n    }\r\n      //查询表格函数\r\n      function SearchEvent() {\r\n         " +
" var queryJson = $(\"#easySeach\").getWebControls();\r\n          queryJson[\"PROVINC" +
"E\"] = PROVINCE;\r\n          queryJson[\"CITY\"] = CITY;\r\n          queryJson[\"COUNT" +
"Y\"] = COUNTY;\r\n          queryJson[\"AreaCode\"] = AreaCode\r\n          BindMapMark" +
"er();\r\n            $(\"#gridTable\").jqGrid(\'setGridParam\', {\r\n                pos" +
"tData: { condition: JSON.stringify(WKTString), queryJson: JSON.stringify(queryJs" +
"on) },\r\n                loadBeforeSend: function (a) {\r\n                    a.se" +
"tRequestHeader(\"Authorization\", authToken);\r\n                },\r\n               " +
"  url: \"../../api/TBL_ACHIEVEMENT_PREPLAN/PostPageListJson\",\r\n                 p" +
"age: 1,\r\n                mtype:\'Post\',\r\n            }).trigger(\'reloadGrid\');\r\n " +
"     }\r\n      function SearchEvent_higher() {\r\n          var queryJson = $(\"#GJC" +
"X\").getWebControls();\r\n          queryJson[\"PROVINCE\"] = PROVINCE;\r\n          qu" +
"eryJson[\"CITY\"] = CITY;\r\n          queryJson[\"COUNTY\"] = COUNTY;\r\n          quer" +
"yJson[\"AreaCode\"] = AreaCode\r\n          BindMapMarker();\r\n          $(\"#gridTabl" +
"e\").jqGrid(\'setGridParam\', {\r\n              postData: { condition: JSON.stringif" +
"y(WKTString), queryJson: JSON.stringify(queryJson) },\r\n              loadBeforeS" +
"end: function (a) {\r\n                  a.setRequestHeader(\"Authorization\", authT" +
"oken);\r\n              },\r\n              url: \"../../api/TBL_ACHIEVEMENT_PREPLAN/" +
"PostPageListJson\",\r\n              page: 1,\r\n              mtype: \'Post\',\r\n      " +
"    }).trigger(\'reloadGrid\');\r\n      }\r\n\r\n\r\n      //导出《下载成果》word版本\r\n      functi" +
"on btn_Word() {\r\n          var keyValue = $(\"#gridTable\").jqGridRowValue(\"GUID\")" +
";\r\n          if (checkedRow(keyValue)) {\r\n              var selectedRowIndex = $" +
"(\'#gridTable\').getGridParam(\'selrow\');\r\n              var dt = $(\'#gridTable\').j" +
"qGrid(\"getRowData\", selectedRowIndex);\r\n              var fileName = dt.KQKM;\r\n " +
"             var queryJson = { \"GUID\": dt.GUID };\r\n              var url = \"../." +
"./JXGeoManage/TBL_ACHIEVEMENT_PREPLAN/ExportWord?filename=\" + fileName + \"&query" +
"Json=\" + JSON.stringify(queryJson);\r\n              window.location.href = url;\r\n" +
"          }\r\n      }\r\n\r\n\r\n\r\n      function ColDataGrid() {\r\n        var centerHe" +
"ight = $(\"#ui_center .ui-layout\").height();\r\n        var layout2 = $(\'#layout2\')" +
".layout();\r\n        if ($(\"#lr-colgrid i\").hasClass(\"fa-chevron-down\")) {\r\n     " +
"        var northH = centerHeight - 65;\r\n             layout2.sizePane(\"north\", " +
"northH);\r\n             $(\"#lr-colgrid i\").removeClass(\"fa-chevron-down\");\r\n     " +
"        $(\"#lr-colgrid i\").addClass(\"fa-chevron-up\");\r\n             if ($(\"#lr-c" +
"olmap i\").hasClass(\"fa-chevron-down\")) {\r\n                  $(\"#lr-colmap i\").re" +
"moveClass(\"fa-chevron-down\");\r\n                  $(\"#lr-colmap i\").addClass(\"fa-" +
"chevron-up\");\r\n             }\r\n        }\r\n        else {\r\n             layout2.s" +
"izePane(\"north\", layout2NorthH);\r\n             $(\"#lr-colgrid i\").removeClass(\"f" +
"a-chevron-up\");\r\n             $(\"#lr-colgrid i\").addClass(\"fa-chevron-down\");\r\n " +
"       }\r\n        mapCtlExt.updateSize();\r\n      }\r\n      function ColMapDiv() {" +
"\r\n        var layout2 = $(\'#layout2\').layout();\r\n        if ($(\"#lr-colmap i\").h" +
"asClass(\"fa-chevron-up\")) {\r\n            layout2.sizePane(\"north\", 1);\r\n        " +
"    $(\"#lr-colmap i\").removeClass(\"fa-chevron-up\");\r\n            $(\"#lr-colmap i" +
"\").addClass(\"fa-chevron-down\");\r\n            if ($(\"#lr-colgrid i\").hasClass(\"fa" +
"-chevron-up\")) {\r\n                $(\"#lr-colgrid i\").removeClass(\"fa-chevron-up\"" +
");\r\n                $(\"#lr-colgrid i\").addClass(\"fa-chevron-down\");\r\n           " +
" }\r\n        }\r\n        else {\r\n            layout2.sizePane(\"north\", layout2Nort" +
"hH);\r\n            $(\"#lr-colmap i\").removeClass(\"fa-chevron-down\");\r\n           " +
" $(\"#lr-colmap i\").addClass(\"fa-chevron-up\");\r\n            if (mapCtlExt != null" +
") {\r\n                mapCtlExt.setHeight($(\"#mapControl\").parent().height() - 32" +
" - 4);\r\n            }\r\n        }\r\n        mapCtlExt.updateSize();\r\n      }\r\n</sc" +
"ript>\r\n");

});

        }
    }
}
#pragma warning restore 1591