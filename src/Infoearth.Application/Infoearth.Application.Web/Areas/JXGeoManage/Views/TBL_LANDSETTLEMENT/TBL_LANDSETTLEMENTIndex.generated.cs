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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_LANDSETTLEMENT/TBL_LANDSETTLEMENTIndex.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_LANDSETTLEMENT_TBL_LANDSETTLEMENTIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_LANDSETTLEMENT_TBL_LANDSETTLEMENTIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_LANDSETTLEMENT\TBL_LANDSETTLEMENTIndex.cshtml"
  
    ViewBag.Title = "列表页面";
    Layout = "~/Views/Shared/_IndexMap.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n <style>\r\n    .ui-layout-center {\r\n       overflow-x: hidden !important;\r\n    }" +
"\r\n    .ui-layout-resizer {\r\n        background-color:#f0f3f4 !important;\r\n    }\r" +
"\n</style>\r\n<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(">\r\n             <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">行政区划信息</div>\r\n             <div");

WriteLiteral(" id=\"itemTree\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" id=\"ui_center\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(" style=\"height: 100%;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout2\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n           <div");

WriteLiteral(" class=\"ui-layout-north\"");

WriteLiteral(" id=\"ui_map\"");

WriteLiteral(" style=\"height: 432px;\"");

WriteLiteral(">\r\n                  <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">地图</div>\r\n                  <div");

WriteLiteral(" id=\"mapControl\"");

WriteLiteral(" style=\"height:400px;\"");

WriteLiteral("></div>\r\n          </div>\r\n          <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" id=\"ui_grid\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(" id=\"filter-form\"");

WriteLiteral(">\r\n                           <table>\r\n                               <tr>\r\n     " +
"                             <td>\r\n                                     <input");

WriteLiteral(" id=\"UNIFIEDCODE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入要查询关键字\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(" />\r\n                                   </td>\r\n                                  " +
" <td");

WriteLiteral(" style=\"padding-left: 5px;\"");

WriteLiteral(">\r\n                                       <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>查询</a>\r\n                                   </td>\r\n                          " +
"     </tr>\r\n                           </table>\r\n                       </div>\r\n" +
"                       <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"btn-group\"");

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

WriteLiteral("></i>删除</a>\r\n                            </div>\r\n                        <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" id=\"lr-colgrid\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"ColDataGrid()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-chevron-down\"");

WriteLiteral("></i>列表</a>\r\n                            <a");

WriteLiteral(" id=\"lr-colmap\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"ColMapDiv()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-chevron-up\"");

WriteLiteral("></i>地图</a>\r\n                        </div>\r\n                      </div>\r\n      " +
"            </div>\r\n                  <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n                      <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n                    <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n                   </div>\r\n              </div>\r\n          </div>\r\n     " +
"  </div>\r\n    </div>\r\n </div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var layout2NorthH = 1;\r\n    $(function () {\r\n        InitialPage(" +
");\r\n        GetTree();\r\n        GetMapData();\r\n        GetGrid();\r\n        //查询点" +
"击事件\r\n        $(\"#btn_Search\").click(function () {\r\n            SearchEvent();\r\n " +
"       });\r\n    });\r\n    //初始化页面\r\n    function InitialPage() {\r\n        //layout" +
"布局\r\n        $(\'#layout\').layout({\r\n                applyDemoStyles: true,\r\n     " +
"           onresize: function () {\r\n                if (isResize < 10) {\r\n      " +
"              isResize++;\r\n                }\r\n                resize();\r\n       " +
"      }\r\n         });\r\n        var isResize = 0;\r\n        var count = 0;\r\n      " +
"  var resized = 0;\r\n        $(\'#layout2\').layout({\r\n            applyDemoStyles:" +
" true,\r\n            onresize: function () {\r\n                resize();\r\n        " +
"        if (isResize > 1) {\r\n                resized = 1;\r\n                 } el" +
"se {\r\n                    if (count == 1 || resized == 0) {\r\n                   " +
"     $(\'#layout2 .ui-layout-center\').height($(\'#layout2 .ui-layout-center\').heig" +
"ht() - 18);\r\n                    }\r\n                 }\r\n                  count+" +
"+;\r\n             }\r\n         });\r\n          //resize重设布局;\r\n         $(window).re" +
"size(function (e) {\r\n              if (isResize<10) {\r\n                 isResize" +
" ++;\r\n              }\r\n              resize();\r\n              e.stopPropagation(" +
");\r\n         });\r\n         function resize() {\r\n              window.setTimeout(" +
"function () {\r\n                  if (mapCtlExt != null) {\r\n                     " +
"   mapCtlExt.setHeight($(\'#mapControl\').parent().height() - 32 - 4);\r\n          " +
"        }\r\n                  $(\'.center-Panel\').height($(\'#layout\').parent().hei" +
"ght() - 20);\r\n                  $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').wi" +
"dth()));\r\n                  $(\'#layout2 .ui-layout-center\').width($(\'#layout2 .u" +
"i-layout-center\').parent().width() - 10);\r\n                  $(\'#layout2 .ui-lay" +
"out-resizer\').width($(\'#layout2 .ui-layout-center\').parent().width() - 10);\r\n   " +
"               $(\'#gridTable\').setGridHeight($(window).height() - $(\'#mapControl" +
"\').height() - $(\'.panel-Title\').height());\r\n                  $(\'#gridTable\').se" +
"tGridHeight($(\'#layout2 .ui-layout-center\').height() - 60 - 60);\r\n              " +
"    $(\'.ui-jqgrid-bdiv\').height($(\'#layout2 .ui-layout-center\').height() - 60 - " +
"60);\r\n                  $(\'#itemTree\').setTreeHeight($(window).height() - 52);\r\n" +
"                  $(\'#layout2 .ui-layout-center\').height($(\'#layout2\').height() " +
"- $(\'#layout2 .ui-layout-north\').height() - 15);\r\n                  $(\'#gridTabl" +
"e\').setGridHeight($(\'#layout2 .ui-layout-center\').height() - 115);\r\n            " +
"      $(\'#layout2 .ui-layout-center\').css(\'overflow\', \'hidden\');\r\n              " +
"}, 200);\r\n           };\r\n           $(window).resize();\r\n           $(\'#layout2 " +
".ui-layout-center\').height($(\'#layout2 .ui-layout-center\').height() - 18);\r\n    " +
"       layout2NorthH = $(\"#layout2 .ui-layout-north\").height();\r\n     }\r\n    //加" +
"载行政区划树\r\n    var AreaCode = 0;\r\n    function GetTree() {\r\n        var item = {\r\n " +
"           height: $(window).height() - 52,\r\n            isAllExpand: false,\r\n  " +
"          url: \"../../Map/GetTreeJsonForMap\",\r\n            onnodeclick: function" +
" (item) {\r\n                AreaCode = item.id;\r\n                if(item.value.sp" +
"lit(\',\')[1]  < 3) {\r\n                     //展开下级\r\n                     $(\".bbit-" +
"tree-selected\").children(\'.bbit-tree-ec-icon\').trigger(\"click\");\r\n              " +
"  }\r\n                $(\'#btn_Search\').trigger(\"click\");\r\n            },\r\n       " +
" };\r\n        //初始化\r\n        $(\"#itemTree\").treeview(item);\r\n    };\r\n    //加载地图\r\n" +
"    var mapCtlExt = null;\r\n    function GetMapData() {\r\n          $.ajax({\r\n    " +
"         url: \'../../Map/GetMapDatas\',\r\n             async: false,\r\n            " +
" type: \"GET\",\r\n             success: function (data) {\r\n                       v" +
"ar dataSet = JSON.parse(data);\r\n                        mapCtlExt= $(\"#mapContro" +
"l\").mapCtl({\r\n                                mapwidth: 1500,\r\n                 " +
"               isShowGisLayer:false,\r\n                                isFrame:tr" +
"ue,\r\n                                dataset: dataSet,\r\n                        " +
"        isCluster: true\r\n                             });\r\n                     " +
"   }, error: function (e) {\r\n                    },\r\n             cache: false\r\n" +
"         });\r\n     };\r\n    //加载表格\r\n    function GetGrid() {\r\n        var selecte" +
"dRowIndex = 0;\r\n        var queryJson = $(\"#filter-form\").getWebControls();\r\n   " +
"     queryJson[\"AreaCode\"] = AreaCode;\r\n        var $gridTable = $(\'#gridTable\')" +
";\r\n        $gridTable.jqGrid({\r\n            autowidth: true,\r\n            postDa" +
"ta: { queryJson: JSON.stringify(queryJson) },\r\n            height: $(window).hei" +
"ght() - 570,\r\n            url: \"../../JXGeoManage/TBL_LANDSETTLEMENT/GetPageList" +
"Json\",\r\n            datatype: \"json\",\r\n            colModel: [\r\n                " +
"{ label: \'统一编号\', name: \'UNIFIEDCODE\', index: \'UNIFIEDCODE\', width: 100, align: \'" +
"left\',sortable: true  },\r\n                { label: \'CGH系统灾害点编码\', name: \'CGHUNIFI" +
"EDCODE\', index: \'CGHUNIFIEDCODE\', width: 100, align: \'left\',sortable: true  },\r\n" +
"                { label: \'名称\', name: \'DISASTERUNITNAME\', index: \'DISASTERUNITNAM" +
"E\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'室内编号" +
"\', name: \'INDOORCODE\', index: \'INDOORCODE\', width: 100, align: \'left\',sortable: " +
"true  },\r\n                { label: \'野外编号\', name: \'OUTDOORCODE\', index: \'OUTDOORC" +
"ODE\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'省\'" +
", name: \'PROVINCE\', index: \'PROVINCE\', width: 100, align: \'left\',sortable: true " +
" },\r\n                { label: \'市（县）\', name: \'CITY\', index: \'CITY\', width: 100, a" +
"lign: \'left\',sortable: true  },\r\n                { label: \'乡镇\', name: \'TOWN\', in" +
"dex: \'TOWN\', width: 100, align: \'left\',sortable: true  },\r\n                { lab" +
"el: \'地理位置（村）\', name: \'LOCATION\', index: \'LOCATION\', width: 100, align: \'left\',so" +
"rtable: true  },\r\n                { label: \'经度\', name: \'LONGITUDE\', index: \'LONG" +
"ITUDE\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'" +
"X坐标\', name: \'X\', index: \'X\', width: 100, align: \'left\',sortable: true  },\r\n     " +
"           { label: \'纬度\', name: \'LATITUDE\', index: \'LATITUDE\', width: 100, align" +
": \'left\',sortable: true  },\r\n                { label: \'Y坐标\', name: \'Y\', index: \'" +
"Y\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'Z坐标\'" +
", name: \'Z\', index: \'Z\', width: 100, align: \'left\',sortable: true  },\r\n         " +
"       { label: \'发生时间\', name: \'HAPPENTIME\', index: \'HAPPENTIME\', width: 100, ali" +
"gn: \'left\',sortable: true  },\r\n                { label: \'沉降类型\', name: \'SETTLEMEN" +
"TTYPE\', index: \'SETTLEMENTTYPE\', width: 100, align: \'left\',sortable: true  },\r\n " +
"               { label: \'沉降中心位置\', name: \'SETTLEMENTCENTERLOCATION\', index: \'SETT" +
"LEMENTCENTERLOCATION\', width: 100, align: \'left\',sortable: true  },\r\n           " +
"     { label: \'沉降中心经度\', name: \'SETTLEMENTCENTERLONGITUDE\', index: \'SETTLEMENTCEN" +
"TERLONGITUDE\', width: 100, align: \'left\',sortable: true  },\r\n                { l" +
"abel: \'沉降中心纬度\', name: \'SETTLEMENTCENTERLATITUDE\', index: \'SETTLEMENTCENTERLATITU" +
"DE\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'沉降区" +
"面积\', name: \'SETTLEMENTAREA\', index: \'SETTLEMENTAREA\', width: 100, align: \'left\'," +
"sortable: true  },\r\n                { label: \'年平均沉降量\', name: \'AVERAGEYEARSETTLEM" +
"ENTVOLUME\', index: \'AVERAGEYEARSETTLEMENTVOLUME\', width: 100, align: \'left\',sort" +
"able: true  },\r\n                { label: \'历年累计沉降量\', name: \'ACCUMULATIVESETTLEMEN" +
"TVOLUME\', index: \'ACCUMULATIVESETTLEMENTVOLUME\', width: 100, align: \'left\',sorta" +
"ble: true  },\r\n                { label: \'平均沉降速率\', name: \'AVERAGESETTLEMENTRATE\'," +
" index: \'AVERAGESETTLEMENTRATE\', width: 100, align: \'left\',sortable: true  },\r\n " +
"               { label: \'地形地貌\', name: \'TOPOGRAPHY\', index: \'TOPOGRAPHY\', width: " +
"100, align: \'left\',sortable: true  },\r\n                { label: \'地质构造及活动情况\', nam" +
"e: \'GEOLOGICALSTRUCTURE\', index: \'GEOLOGICALSTRUCTURE\', width: 100, align: \'left" +
"\',sortable: true  },\r\n                { label: \'岩性\', name: \'LITH\', index: \'LITH\'" +
", width: 100, align: \'left\',sortable: true  },\r\n                { label: \'厚度\', n" +
"ame: \'DEPTH\', index: \'DEPTH\', width: 100, align: \'left\',sortable: true  },\r\n    " +
"            { label: \'结构\', name: \'ARCH\', index: \'ARCH\', width: 100, align: \'left" +
"\',sortable: true  },\r\n                { label: \'空间变化规律\', name: \'SPACECHANGELAW\'," +
" index: \'SPACECHANGELAW\', width: 100, align: \'left\',sortable: true  },\r\n        " +
"        { label: \'主要沉降层位\', name: \'MAINSETTLEMENTLOCATION\', index: \'MAINSETTLEMEN" +
"TLOCATION\', width: 100, align: \'left\',sortable: true  },\r\n                { labe" +
"l: \'水文地质特征\', name: \'HYDROLOGYGEOLOGYFEATURE\', index: \'HYDROLOGYGEOLOGYFEATURE\', " +
"width: 100, align: \'left\',sortable: true  },\r\n                { label: \'年开采量\', n" +
"ame: \'YEARMININGVOLUME\', index: \'YEARMININGVOLUME\', width: 100, align: \'left\',so" +
"rtable: true  },\r\n                { label: \'年补给量\', name: \'YEARSUPPLYVOLUME\', ind" +
"ex: \'YEARSUPPLYVOLUME\', width: 100, align: \'left\',sortable: true  },\r\n          " +
"      { label: \'年水位变化幅度\', name: \'YEARWATLEVCHANGEMARGIN\', index: \'YEARWATLEVCHAN" +
"GEMARGIN\', width: 100, align: \'left\',sortable: true  },\r\n                { label" +
": \'地下水埋深\', name: \'GROUNDWATERDEPTH\', index: \'GROUNDWATERDEPTH\', width: 100, alig" +
"n: \'left\',sortable: true  },\r\n                { label: \'其它\', name: \'OTHER\', inde" +
"x: \'OTHER\', width: 100, align: \'left\',sortable: true  },\r\n                { labe" +
"l: \'诱发沉降原因\', name: \'INDUCEDSUBSIDENCECAUSES\', index: \'INDUCEDSUBSIDENCECAUSES\', " +
"width: 100, align: \'left\',sortable: true  },\r\n                { label: \'变化规律\', n" +
"ame: \'CHANGELAW\', index: \'CHANGELAW\', width: 100, align: \'left\',sortable: true  " +
"},\r\n                { label: \'沉降现状\', name: \'SETTLEMENTCURRENTSITUATION\', index: " +
"\'SETTLEMENTCURRENTSITUATION\', width: 100, align: \'left\',sortable: true  },\r\n    " +
"            { label: \'发展趋势\', name: \'DEVELOPMENTTREND\', index: \'DEVELOPMENTTREND\'" +
", width: 100, align: \'left\',sortable: true  },\r\n                { label: \'主要危害\'," +
" name: \'MAINHARM\', index: \'MAINHARM\', width: 100, align: \'left\',sortable: true  " +
"},\r\n                { label: \'经济损失\', name: \'ECONOMICLOSSES\', index: \'ECONOMICLOS" +
"SES\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'治理" +
"措施\', name: \'CONTROLMEASURES\', index: \'CONTROLMEASURES\', width: 100, align: \'left" +
"\',sortable: true  },\r\n                { label: \'治理效果\', name: \'CONTROLEFFECT\', in" +
"dex: \'CONTROLEFFECT\', width: 100, align: \'left\',sortable: true  },\r\n            " +
"    { label: \'填表人\', name: \'FILLTABLEPEOPLE\', index: \'FILLTABLEPEOPLE\', width: 10" +
"0, align: \'left\',sortable: true  },\r\n                { label: \'调查负责人\', name: \'SU" +
"RVEYHEADER\', index: \'SURVEYHEADER\', width: 100, align: \'left\',sortable: true  }," +
"\r\n                { label: \'审核人\', name: \'VERIFYPEOPLE\', index: \'VERIFYPEOPLE\', w" +
"idth: 100, align: \'left\',sortable: true  },\r\n                { label: \'调查单位\', na" +
"me: \'SURVEYDEPT\', index: \'SURVEYDEPT\', width: 100, align: \'left\',sortable: true " +
" },\r\n                { label: \'填表日期\', name: \'FILLTABLEDATE\', index: \'FILLTABLEDA" +
"TE\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'记录状" +
"态\', name: \'RECORDSTATUS\', index: \'RECORDSTATUS\', width: 100, align: \'left\',sorta" +
"ble: true  },\r\n                { label: \'更新时间\', name: \'UPDATETIME\', index: \'UPDA" +
"TETIME\', width: 100, align: \'left\',sortable: true  },\r\n                { label: " +
"\'导出状态\', name: \'EXPSTATUS\', index: \'EXPSTATUS\', width: 100, align: \'left\',sortabl" +
"e: true  },\r\n                { label: \'防灾情况\', name: \'CONTROLSTATE\', index: \'CONT" +
"ROLSTATE\', width: 100, align: \'left\',sortable: true  },\r\n                { label" +
": \'创建者ID\', name: \'CREATORUSERID\', index: \'CREATORUSERID\', width: 100, align: \'le" +
"ft\',sortable: true  },\r\n                { label: \'创建时间\', name: \'CREATORTIME\', in" +
"dex: \'CREATORTIME\', width: 100, align: \'left\',sortable: true  },\r\n              " +
"  { label: \'更新者ID\', name: \'UPDATEUSERID\', index: \'UPDATEUSERID\', width: 100, ali" +
"gn: \'left\',sortable: true  },\r\n                { label: \'更新次数\', name: \'UPDATETIM" +
"ES\', index: \'UPDATETIMES\', width: 100, align: \'left\',sortable: true  },\r\n       " +
"         { label: \'防灾预案\', name: \'PREVENTIONPLAN\', index: \'PREVENTIONPLAN\', width" +
": 100, align: \'left\',sortable: true  },\r\n                { label: \'项目编号\', name: " +
"\'PROJECTID\', index: \'PROJECTID\', width: 100, align: \'left\',sortable: true  },\r\n " +
"               { label: \'图幅编号\', name: \'MAPID\', index: \'MAPID\', width: 100, align" +
": \'left\',sortable: true  },\r\n                { label: \'图幅名称\', name: \'MAPNAME\', i" +
"ndex: \'MAPNAME\', width: 100, align: \'left\',sortable: true  },\r\n                {" +
" label: \'县市编号\', name: \'COUNTYCODE\', index: \'COUNTYCODE\', width: 100, align: \'lef" +
"t\',sortable: true  },\r\n                { label: \'遥感解译点（0：否；1：是）\', name: \'ISRSPNT" +
"\', index: \'ISRSPNT\', width: 100, align: \'left\',sortable: true  },\r\n             " +
"   { label: \'勘查点（0：否；1：是）\', name: \'ISSURVEYPNT\', index: \'ISSURVEYPNT\', width: 10" +
"0, align: \'left\',sortable: true  },\r\n                { label: \'测绘点（0：否；1：是）\', na" +
"me: \'ISMEASURINGPNT\', index: \'ISMEASURINGPNT\', width: 100, align: \'left\',sortabl" +
"e: true  },\r\n                { label: \'村\', name: \'VILLAGE\', index: \'VILLAGE\', wi" +
"dth: 100, align: \'left\',sortable: true  },\r\n                { label: \'是否隐患点（0：否；" +
"1：是）\', name: \'HIDDENDANGER\', index: \'HIDDENDANGER\', width: 100, align: \'left\',so" +
"rtable: true  },\r\n                { label: \'组\', name: \'TEAM\', index: \'TEAM\', wid" +
"th: 100, align: \'left\',sortable: true  },\r\n                { label: \'死亡人数（人）\', n" +
"ame: \'DEATHSPEOPLE\', index: \'DEATHSPEOPLE\', width: 100, align: \'left\',sortable: " +
"true  },\r\n                { label: \'直接损失（万元）\', name: \'DIRECTLOSS\', index: \'DIREC" +
"TLOSS\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'" +
"威胁房屋（户）\', name: \'THREATENHOME\', index: \'THREATENHOME\', width: 100, align: \'left\'" +
",sortable: true  },\r\n                { label: \'威胁人数（人）\', name: \'THREATENPEOPLE\'," +
" index: \'THREATENPEOPLE\', width: 100, align: \'left\',sortable: true  },\r\n        " +
"        { label: \'威胁财产（万元）\', name: \'THREATENASSETS\', index: \'THREATENASSETS\', wi" +
"dth: 100, align: \'left\',sortable: true  },\r\n                { label: \'危害对象\', nam" +
"e: \'DESTROYEDOBJECT\', index: \'DESTROYEDOBJECT\', width: 100, align: \'left\',sortab" +
"le: true  },\r\n                { label: \'威胁对象\', name: \'THREATENOBJECT\', index: \'T" +
"HREATENOBJECT\', width: 100, align: \'left\',sortable: true  },\r\n                { " +
"label: \'野外记录信息\', name: \'OUTDOORRECORD\', index: \'OUTDOORRECORD\', width: 100, alig" +
"n: \'left\',sortable: true  },\r\n                { label: \'流域\', name: \'RIVERBASIN\'," +
" index: \'RIVERBASIN\', width: 100, align: \'left\',sortable: true  },\r\n            " +
"    { label: \'失踪人数\', name: \'MISSINGPERSON\', index: \'MISSINGPERSON\', width: 100, " +
"align: \'left\',sortable: true  },\r\n                { label: \'受伤人数\', name: \'INJURE" +
"DPERSON\', index: \'INJUREDPERSON\', width: 100, align: \'left\',sortable: true  },\r\n" +
"                { label: \'是否治理工程\', name: \'ISZLGCPNT\', index: \'ISZLGCPNT\', width:" +
" 100, align: \'left\',sortable: true  },\r\n                { label: \'是否有监测点\', name:" +
" \'ISMONITORPNT\', index: \'ISMONITORPNT\', width: 100, align: \'left\',sortable: true" +
"  },\r\n                { label: \'遥感解译\', name: \'DISASTERSID\', index: \'DISASTERSID\'" +
", width: 100, align: \'left\',sortable: true  },\r\n                { label: \'更新人(最近" +
")\', name: \'UPDATEUSER\', index: \'UPDATEUSER\', width: 100, align: \'left\',sortable:" +
" true  },\r\n                { label: \'调查负责人ID\', name: \'SURVEYHEADERID\', index: \'S" +
"URVEYHEADERID\', width: 100, align: \'left\',sortable: true  },\r\n                { " +
"label: \'填表人ID\', name: \'FILLTABLEPEOPLEID\', index: \'FILLTABLEPEOPLEID\', width: 10" +
"0, align: \'left\',sortable: true  },\r\n                { label: \'调查单位ID\', name: \'S" +
"URVEYDEPTID\', index: \'SURVEYDEPTID\', width: 100, align: \'left\',sortable: true  }" +
",\r\n                { label: \'审核人ID\', name: \'VERIFYPEOPLEID\', index: \'VERIFYPEOPL" +
"EID\', width: 100, align: \'left\', sortable: true },\r\n                { label: \'灾情" +
"等级\', name: \'DISASTERLEVEL\', index: \'DISASTERLEVEL\', width: 100, align: \'left\', s" +
"ortable: true },\r\n                { label: \'险情等级\', name: \'DANGERLEVEL\', index: \'" +
"DANGERLEVEL\', width: 100, align: \'left\', sortable: true },\r\n            ],\r\n    " +
"        viewrecords: true,\r\n            rowNum: 30,\r\n            rowList: [30, 5" +
"0, 100],\r\n            pager: \"#gridPager\",\r\n            sortname: \'UNIFIEDCODE\'," +
"\r\n            sortorder: \'desc\',\r\n            rownumbers: true,\r\n            shr" +
"inkToFit: false,\r\n            gridview: true,\r\n            onSelectRow: function" +
" () {\r\n                selectedRowIndex = $(\'#\' + this.id).getGridParam(\'selrow\'" +
");\r\n            },\r\n            gridComplete: function () {\r\n                $(\'" +
"#\' + this.id).setSelection(selectedRowIndex, false);\r\n            }\r\n        });" +
"\r\n    }\r\n    //新增\r\n    function btn_add() {\r\n        dialogOpen({\r\n            i" +
"d: \'Form\',\r\n            title: \'添加地面沉降调查表\',\r\n            url: \'/JXGeoManage/TBL_" +
"LANDSETTLEMENT/TBL_LANDSETTLEMENTForm\',\r\n            width: \'px\',\r\n            h" +
"eight: \'px\',\r\n            callBack: function (iframeId) {\r\n                getIn" +
"foTop().frames[iframeId].AcceptClick();\r\n            }\r\n        });\r\n    }\r\n    " +
"//编辑\r\n    function btn_edit() {\r\n        var keyValue = $(\"#gridTable\").jqGridRo" +
"wValue(\'UNIFIEDCODE\');\r\n        if (checkedRow(keyValue)) {\r\n            dialogO" +
"pen({\r\n                id: \'Form\',\r\n                title: \'编辑地面沉降调查表\',\r\n       " +
"         url: \'/JXGeoManage/TBL_LANDSETTLEMENT/TBL_LANDSETTLEMENTForm?keyValue=\'" +
" + keyValue,\r\n                width: \'px\',\r\n                height: \'px\',\r\n     " +
"           callBack: function (iframeId) {\r\n                    getInfoTop().fra" +
"mes[iframeId].AcceptClick();\r\n                }\r\n            })\r\n        }\r\n    " +
"}\r\n    //删除\r\n    function btn_delete() {\r\n        var keyValue = $(\"#gridTable\")" +
".jqGridRowValue(\'UNIFIEDCODE\');\r\n        if (keyValue) {\r\n            $.RemoveFo" +
"rm({\r\n                url: \'../../JXGeoManage/TBL_LANDSETTLEMENT/RemoveForm\',\r\n " +
"               param: { keyValue: keyValue },\r\n                success: function" +
" (data) {\r\n                    $(\'#gridTable\').trigger(\'reloadGrid\');\r\n         " +
"       }\r\n            })\r\n        } else {\r\n            dialogMsg(\'请选择需要删除的地面沉降调" +
"查表！\', 0);\r\n        }\r\n    }\r\n      //查询表格函数\r\n      function SearchEvent() {\r\n   " +
"     var queryJson = $(\"#filter-form\").getWebControls();\r\n        queryJson[\"Are" +
"aCode\"] = AreaCode\r\n            $(\"#gridTable\").jqGrid(\'setGridParam\', {\r\n      " +
"           postData: { queryJson: JSON.stringify(queryJson) },\r\n                " +
" url: \"../../JXGeoManage/TBL_LANDSETTLEMENT/GetPageListJson\",\r\n                 " +
" page: 1\r\n            }).trigger(\'reloadGrid\');\r\n        }\r\n      function ColDa" +
"taGrid() {\r\n        var centerHeight = $(\"#ui_center .ui-layout\").height();\r\n   " +
"     var layout2 = $(\'#layout2\').layout();\r\n        if ($(\"#lr-colgrid i\").hasCl" +
"ass(\"fa-chevron-down\")) {\r\n             var northH = centerHeight - 65;\r\n       " +
"      layout2.sizePane(\"north\", northH);\r\n             $(\"#lr-colgrid i\").remove" +
"Class(\"fa-chevron-down\");\r\n             $(\"#lr-colgrid i\").addClass(\"fa-chevron-" +
"up\");\r\n             if ($(\"#lr-colmap i\").hasClass(\"fa-chevron-down\")) {\r\n      " +
"            $(\"#lr-colmap i\").removeClass(\"fa-chevron-down\");\r\n                 " +
" $(\"#lr-colmap i\").addClass(\"fa-chevron-up\");\r\n             }\r\n        }\r\n      " +
"  else {\r\n             layout2.sizePane(\"north\", layout2NorthH);\r\n             $" +
"(\"#lr-colgrid i\").removeClass(\"fa-chevron-up\");\r\n             $(\"#lr-colgrid i\")" +
".addClass(\"fa-chevron-down\");\r\n        }\r\n        mapCtlExt.updateSize();\r\n     " +
" }\r\n      function ColMapDiv() {\r\n        var layout2 = $(\'#layout2\').layout();\r" +
"\n        if ($(\"#lr-colmap i\").hasClass(\"fa-chevron-up\")) {\r\n            layout2" +
".sizePane(\"north\", 1);\r\n            $(\"#lr-colmap i\").removeClass(\"fa-chevron-up" +
"\");\r\n            $(\"#lr-colmap i\").addClass(\"fa-chevron-down\");\r\n            if " +
"($(\"#lr-colgrid i\").hasClass(\"fa-chevron-up\")) {\r\n                $(\"#lr-colgrid" +
" i\").removeClass(\"fa-chevron-up\");\r\n                $(\"#lr-colgrid i\").addClass(" +
"\"fa-chevron-down\");\r\n            }\r\n        }\r\n        else {\r\n            layou" +
"t2.sizePane(\"north\", layout2NorthH);\r\n            $(\"#lr-colmap i\").removeClass(" +
"\"fa-chevron-down\");\r\n            $(\"#lr-colmap i\").addClass(\"fa-chevron-up\");\r\n " +
"           if (mapCtlExt != null) {\r\n                mapCtlExt.setHeight($(\"#map" +
"Control\").parent().height() - 32 - 4);\r\n            }\r\n        }\r\n        mapCtl" +
"Ext.updateSize();\r\n      }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591