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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_QCQF_LAYOUTPOINTINFO/XZZHD.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_QCQF_LAYOUTPOINTINFO_XZZHD_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_QCQF_LAYOUTPOINTINFO_XZZHD_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_QCQF_LAYOUTPOINTINFO\XZZHD.cshtml"
  
    ViewBag.Title = "列表页面";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<style>\r\n    body {\r\n        margin:0;\r\n    }\r\n    .spans {\r\n        padding: 0" +
" 10px;\r\n        width: 9%;\r\n        text-align: center;\r\n        height: 28px;\r\n" +
"        line-height: 28px;\r\n        min-width: 100px;\r\n    }\r\n</style>\r\n<div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(" style=\"background-color: rgba(236, 247, 255, 1);color:#000;height:35px\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-bars\"");

WriteLiteral("></i>查询条件</div>\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(" style=\"width: 100%; height: 40px;color:#000;display: flex; align-items: center;f" +
"lex-wrap:wrap;padding:0\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">灾害点名称:</span><input");

WriteLiteral(" id=\"DISASTERNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入灾害点名称\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral(" />\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">灾害类型:</span><div");

WriteLiteral(" id=\"DISASTERTYPE\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" placeholder=\"请输入灾害类型\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">地理位置:</span><input");

WriteLiteral(" id=\"LOCATION\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入地理位置\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral(" />\r\n        <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"margin-bottom:0;margin-left:30px\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i> 查询</a>\r\n       <a");

WriteLiteral(" id=\"btn_Reset\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"margin-bottom:0;margin-left:30px;background:gray;border-color:gray;cursor" +
": pointer;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i> 重置</a>&nbsp;  \r\n    </div>\r\n    <div");

WriteLiteral(" style=\"background-color: rgba(236, 247, 255, 1);width:100%;height:35px;color:#00" +
"0;display:flex;align-items: center;\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" style=\"flex:1;font-weight:700;padding-left:9px;height:35px;line-height:35px\"");

WriteLiteral(">数据列表</span>\r\n    </div>\r\n    <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n    <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var authToken = getAuthorizationToken();\r\n    $(function () {\r\n  " +
"      InitialPage();\r\n        GetGrid();\r\n    });\r\n    //初始化页面\r\n    function Ini" +
"tialPage() {\r\n        //resize重设布局;\r\n        $(window).resize(function (e) {\r\n  " +
"          //初始化控件\r\n            $(\"#btn_Search\").click(SearchEvent);\r\n           " +
" $(\"#btn_Reset\").click(ClearEvent);\r\n\r\n            window.setTimeout(function ()" +
" {\r\n                $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').width()));\r\n  " +
"              $(\'#gridTable\').setGridHeight($(window).height() - 136.5 - 34);\r\n " +
"           }, 200);\r\n            e.stopPropagation();\r\n        });\r\n        //灾害" +
"类型\r\n        $(\"#DISASTERTYPE\").ComboBox({\r\n            url: \"../../SystemManage/" +
"DataItemDetail/GetDataItemTreeJson\",\r\n            param: { EnCode: \"HazardType\" " +
"},\r\n            id: \"text\",\r\n            text: \"text\",\r\n            height: \'200" +
"px\',\r\n            description: \"==请选择==\"\r\n        });\r\n    }\r\n    //重置\r\n    docu" +
"ment.getElementById(\"btn_Reset\").onclick=function ClearEvent() {\r\n        $(\".ti" +
"tle-search\").find(\"input[type=\'text\']\").val(\"\");\r\n        $(\"#DISASTERTYPE\").Com" +
"boBoxSetValue(\" \");\r\n\r\n    }\r\n    //查询\r\n    document.getElementById(\"btn_Search\"" +
").onclick = function SearchEvent() {\r\n        var queryJson = $(\".title-search\")" +
".getWebControls();\r\n        $(\"#gridTable\").jqGrid(\'setGridParam\', {\r\n          " +
"  postData: { queryJson: JSON.stringify(queryJson) },\r\n            loadBeforeSen" +
"d: function (a) {\r\n                a.setRequestHeader(\"Authorization\", authToken" +
");\r\n            },\r\n            url: \"../../api/TBL_HAZARDBASICINFOApi/GetPageLi" +
"stJsonQCQFSearchZHD\",\r\n            page: 1\r\n        }).trigger(\'reloadGrid\');\r\n " +
"   }\r\n\r\n\r\n    var selectData = {};\r\n    //加载表格\r\n    function GetGrid() {\r\n      " +
"  var selectedRowIndex = 0;\r\n        var queryJson = $(\"#search\").getWebControls" +
"();\r\n        var $gridTable = $(\'#gridTable\');\r\n        $gridTable.jqGrid({\r\n   " +
"         autowidth: true,\r\n            postData: { queryJson: JSON.stringify(que" +
"ryJson) },\r\n            height: $(window).height() - 172,\r\n            url: \"../" +
"../api/TBL_HAZARDBASICINFOApi/GetPageListJsonQCQFSearchZHD\",\r\n            dataty" +
"pe: \"json\",\r\n            loadBeforeSend: function (a) {\r\n                if (aut" +
"hToken != null)\r\n                    a.setRequestHeader(\"Authorization\", authTok" +
"en);\r\n            },\r\n            colModel: [\r\n                { label: \'灾害点编号\'," +
" name: \'UNIFIEDCODE\', index: \'UNIFIEDCODE\', width: 300, align: \'left\', sortable:" +
" false },\r\n                { label: \'灾害点名称\', name: \'DISASTERNAME\', index: \'DISAS" +
"TERNAME\', width: 500, align: \'left\', sortable: false },\r\n                { label" +
": \'灾害点类型\', name: \'DISASTERTYPE\', index: \'DISASTERTYPE\', width: 200, align: \'left" +
"\', sortable: false },\r\n                { label: \'经度\', name: \'LONGITUDE\', index: " +
"\'LONGITUDE\', width: 100, align: \'left\', sortable: true, hidden: true },\r\n       " +
"         { label: \'纬度\', name: \'LATITUDE\', index: \'LATITUDE\', width: 100, align: " +
"\'left\', sortable: true, hidden: true },\r\n                //{ label: \'险情等级\', name" +
": \'DANGERLEVEL\', index: \'DANGERLEVEL\', width: 200, align: \'left\', sortable: fals" +
"e },\r\n                //{ label: \'灾害等级\', name: \'DISASTERLEVEL\', index: \'DISASTER" +
"LEVEL\', width: 200, align: \'left\', sortable: false },\r\n                 { label:" +
" \'地理位置\', name: \'LOCATION\', index: \'LOCATION\', width: 500, align: \'left\', sortabl" +
"e: false },\r\n                { label: \'市\', name: \'CITY\', index: \'CITY\', width: 1" +
"00, align: \'left\', sortable: false, hidden: true },\r\n                { label: \'市" +
"名称\', name: \'CITYNAME\', index: \'CITYNAME\', width: 100, align: \'left\', sortable: f" +
"alse, hidden: true },\r\n                { label: \'县\', name: \'COUNTY\', index: \'COU" +
"NTY\', width: 100, align: \'left\', sortable: false, hidden: true },\r\n             " +
"   { label: \'县名称\', name: \'COUNTYNAME\', index: \'COUNTYNAME\', width: 100, align: \'" +
"left\', sortable: false, hidden: true },\r\n                { label: \'乡镇\', name: \'T" +
"OWN\', index: \'TOWN\', width: 100, align: \'left\', sortable: false, hidden: true }," +
"\r\n                { label: \'乡镇名称\', name: \'TOWNNAME\', index: \'TOWNNAME\', width: 1" +
"00, align: \'left\', sortable: false, hidden: true },\r\n                { label: \'目" +
"前稳定程度\', name: \'CURSTABLESTATUS\', index: \'CURSTABLESTATUS\', width: 100, align: \'l" +
"eft\', sortable: false, hidden: true },\r\n                { label: \'今后变化趋势\', name:" +
" \'STABLETREND\', index: \'STABLETREND\', width: 100, align: \'left\', sortable: false" +
", hidden: true },\r\n                { label: \'威胁人口\', name: \'THREATENPEOPLE\', inde" +
"x: \'THREATENPEOPLE\', width: 100, align: \'left\', sortable: false, hidden: true }," +
"\r\n                { label: \'威胁财产\', name: \'THREATENASSETS\', index: \'THREATENASSET" +
"S\', width: 100, align: \'left\', sortable: false, hidden: true },\r\n               " +
" { label: \'死亡人口\', name: \'DEATHTOLL\', index: \'DEATHTOLL\', width: 100, align: \'lef" +
"t\', sortable: false, hidden: true },\r\n                { label: \'财产损失\', name: \'AS" +
"SETSLOSE\', index: \'ASSETSLOSE\', width: 100, align: \'left\', sortable: false, hidd" +
"en: true },\r\n                { label: \'防治建议\', name: \'TREATMENTSUGGESTION\', index" +
": \'TREATMENTSUGGESTION\', width: 100, align: \'left\', sortable: false, hidden: tru" +
"e },\r\n                { label: \'隐患点\', name: \'HIDDENDANGER\', index: \'HIDDENDANGER" +
"\', width: 100, align: \'left\', sortable: false, hidden: true },\r\n                " +
"{ label: \'监测建议\', name: \'MONITORSUGGESTION\', index: \'MONITORSUGGESTION\', width: 1" +
"00, align: \'left\', sortable: false, hidden: true }\r\n\r\n            ],\r\n          " +
"  viewrecords: true,\r\n            rowNum: 30,\r\n            rowList: [30, 50, 100" +
"],\r\n            pager: \"#gridPager\",\r\n            sortname: \'UNIFIEDCODE\',\r\n    " +
"        sortorder: \'desc\',\r\n            rownumbers: true,\r\n            shrinkToF" +
"it: true,\r\n            gridview: true,\r\n            onSelectRow: function (rowId" +
", status) {\r\n                selectedRowIndex = $(\'#\' + this.id).getGridParam(\'s" +
"elrow\');\r\n                selectData = $gridTable.jqGrid(\"getRowData\", rowId);\r\n" +
"            },\r\n            gridComplete: function () {\r\n                $(\'#\' +" +
" this.id).setSelection(selectedRowIndex, false);\r\n            }\r\n        });\r\n  " +
"  }\r\n\r\n\r\n    //保存表单;\r\n    function AcceptClick() {\r\n        learun.dialogClose()" +
";\r\n        return selectData;\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
