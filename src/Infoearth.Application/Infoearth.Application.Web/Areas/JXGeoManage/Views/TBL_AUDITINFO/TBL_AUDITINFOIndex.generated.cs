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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_AUDITINFO/TBL_AUDITINFOIndex.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_AUDITINFO_TBL_AUDITINFOIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_AUDITINFO_TBL_AUDITINFOIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_AUDITINFO\TBL_AUDITINFOIndex.cshtml"
  
    ViewBag.Title = "审核页面";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" id=\"DZHJManage\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(" style=\"background:rgba(236, 247, 255, 1)\"");

WriteLiteral(">\r\n        <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(" id=\"li_HPGL\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#HPGL\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">待审核</a></li>\r\n        <li");

WriteLiteral(" id=\"li_BTGL\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#BTGL\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">审核历史</a></li>\r\n    </ul>\r\n    <div");

WriteLiteral(" id=\"myTabContent\"");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" id=\"HPGL\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" style=\"width:100%;height:80px;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" style=\"width:100%;height:40px;display:flex;align-items: center;justify-content: " +
"flex-start;\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">关键字:</span><input");

WriteLiteral(" id=\"txt_Keyword1\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入要查询关键字\"");

WriteLiteral(" style=\"width: 20%;\"");

WriteLiteral(" />\r\n                    <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">修改类型:</span><div");

WriteLiteral(" id=\"updateTypes\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 20%;\"");

WriteLiteral("></div>\r\n                </div>\r\n                <div");

WriteLiteral(" style=\"width:100%;height:40px;display:flex;align-items: center;justify-content: " +
"flex-start;\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">开始时间:</span><input");

WriteLiteral(" id=\"StartTime1\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({ dateFmt: \'yyyy-MM-dd 00:00:00\' })\"");

WriteLiteral(" style=\"width:20%\"");

WriteLiteral(" />\r\n                    <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">结束时间:</span><input");

WriteLiteral(" id=\"EndTime1\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({ dateFmt: \'yyyy-MM-dd 23:59:59\' })\"");

WriteLiteral(" style=\"width:20%\"");

WriteLiteral(" />\r\n                    <a");

WriteLiteral(" id=\"btn_Search_Submit\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"margin-left:30px\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i> 查询</a>\r\n                    <a");

WriteLiteral(" id=\"btn_Submit\"");

WriteLiteral(" onclick=\"\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"margin-left:30px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>&nbsp;数据审核</a>\r\n                </div>\r\n            </div>\r\n            <div" +
"");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n                <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"tab-pane fade\"");

WriteLiteral(" id=\"BTGL\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" style=\"width:100%;height:80px;\"");

WriteLiteral(" id=\"filter-form\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" style=\"width:100%;height:40px;display:flex;align-items: center;justify-content: " +
"flex-start;\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">关键字:</span><input");

WriteLiteral(" id=\"txt_Keyword\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入要查询关键字\"");

WriteLiteral(" style=\"width: 20%;\"");

WriteLiteral(" />\r\n                    <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">审核状态:</span><div");

WriteLiteral(" id=\"status\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 20%;\"");

WriteLiteral("></div>\r\n                    <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">修改类型:</span><div");

WriteLiteral(" id=\"updateType\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 20%;\"");

WriteLiteral("></div>\r\n                </div>\r\n                <div");

WriteLiteral(" style=\"width:100%;height:40px;display:flex;align-items: center;justify-content: " +
"flex-start;\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">开始时间:</span><input");

WriteLiteral(" id=\"StartTime\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({ dateFmt: \'yyyy-MM-dd 00:00:00\' })\"");

WriteLiteral(" style=\"width:20%\"");

WriteLiteral(" />\r\n                    <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">结束时间:</span><input");

WriteLiteral(" id=\"EndTime\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({ dateFmt: \'yyyy-MM-dd 23:59:59\' })\"");

WriteLiteral(" style=\"width:20%\"");

WriteLiteral(" />\r\n                    <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"margin-left:30px\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i> 查询</a>\r\n                </div>\r\n                ");

WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"gridTablehistory\"");

WriteLiteral("></table>\r\n                <div");

WriteLiteral(" id=\"gridPagerhistory\"");

WriteLiteral(@"></div>
            </div>
        </div>
    </div>
</div>
<style>
    .spans {
        display: inline-block;
        width: 100px;
        min-width: 100px;
        text-align: center;
        height: 40px;
        line-height: 40px
    }

    .form-control, .ui-select-text {
        border-radius: 4px;
    }

    body {
        margin: 0;
    }

    #gridTable td, #gridTablehistory td {
        border-right: 1px solid #ccc !important;
    }

    .ui-jqgrid-btable tr:nth-child(odd) {
        /*background: #DCDCDC*/
    }

    .ui-state-highlight, .ui-widget-content .ui-state-highlight, .ui-widget-header .ui-state-highlight, .ui-widget-content td a {
        color: #fff
    }
</style>

");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    var authToken = getAuthorizationToken();\r\n    var bussnessType = request(\'" +
"bussnessType\');\r\n    var columns = [];\r\n    $(function () {\r\n        InitialPage" +
"();\r\n        initSelect();\r\n        GetGrid();\r\n        GetGridhistor();\r\n\r\n    " +
"    //查询点击事件\r\n        $(\"#btn_Search\").click(function () {\r\n            SearchEv" +
"ent();\r\n        });\r\n        $(\"#btn_Search_Submit\").click(function () {\r\n      " +
"      SearchEvent_Submit();\r\n        });\r\n        $(\"#btn_Submit\").click(functio" +
"n () {\r\n            SubmitAudit();\r\n        });\r\n\r\n\r\n        $(\'#gridTable\').set" +
"GridWidth(($(window).width()));\r\n        $(\'#gridTable\').setGridHeight($(window)" +
".height() - 195 + 12);\r\n        $(\'#gridTablehistory\').setGridWidth(($(window).w" +
"idth()));\r\n        $(\'#gridTablehistory\').setGridHeight($(window).height() - 195" +
" + 12);\r\n    });\r\n    //初始化页面\r\n    function InitialPage() {\r\n        //resize重设布" +
"局;\r\n        $(window).resize(function (e) {\r\n            window.setTimeout(funct" +
"ion () {\r\n                $(\'#gridTable\').setGridWidth(($(window).width()));\r\n  " +
"              $(\'#gridTable\').setGridHeight($(window).height() - 195 + 12);\r\n   " +
"             $(\'#gridTablehistory\').setGridWidth(($(\'#gridTable\').width()));\r\n  " +
"              $(\'#gridTablehistory\').setGridHeight($(window).height() - 195 + 12" +
");\r\n            }, 200);\r\n            e.stopPropagation();\r\n        });\r\n\r\n     " +
"   if (bussnessType == \"A\") {\r\n            columns = [{ label: \'审核ID\', name: \'GU" +
"ID\', index: \'GUID\', width: 150, align: \'left\', sortable: true, hidden: true },\r\n" +
"            { label: \'业务ID\', name: \'BUSINESSID\', index: \'BUSINESSID\', width: 150" +
", align: \'left\', sortable: true, hidden: true },\r\n            {\r\n               " +
" label: \'统一编号\', name: \'BASICINFO\', index: \'BASICINFO\', width: 150, align: \'left\'" +
", sortable: true, formatter: function (cellvalue, options, rowObject) {\r\n       " +
"             if (cellvalue) {\r\n                        return cellvalue.split(\'," +
"\')[2];\r\n                    } else\r\n                        return \'\';\r\n        " +
"        }\r\n            },\r\n            {\r\n                label: \'灾害点名称\', name: " +
"\'BASICINFO\', index: \'BASICINFO\', width: 250, align: \'left\', sortable: true, form" +
"atter: function (cellvalue, options, rowObject) {\r\n                    if (cellv" +
"alue) {\r\n                        return cellvalue.split(\',\')[1];\r\n              " +
"      } else\r\n                        return \'\';\r\n                }\r\n           " +
" },\r\n            {\r\n                label: \'灾害类型\', name: \'BASICINFO\', index: \'BA" +
"SICINFO\', width: 100, align: \'center\', sortable: true, formatter: function (cell" +
"value, options, rowObject) {\r\n                    if (cellvalue) {\r\n            " +
"            return cellvalue.split(\',\')[3];\r\n                    } else\r\n       " +
"                 return \'\';\r\n                }\r\n            },\r\n            {\r\n " +
"               label: \'审核状态\', name: \'STATUS\', index: \'STATUS\', width: 150, align" +
": \'center\', sortable: true,\r\n                formatter: function (cellvalue, opt" +
"ions, rowObject) {\r\n                    if (cellvalue == 0) {\r\n                 " +
"       return \'<span class=\\\"label label-default\\\">未提交</span>\';\r\n               " +
"     } else if (cellvalue == 1) {\r\n                        return \'<span class=\\" +
"\"label label-default\\\">待审核</span>\';\r\n                    } else if (cellvalue ==" +
" 2) {\r\n                        return \'<span class=\\\"label label-success\\\">审核通过<" +
"/span>\';\r\n                    } else if (cellvalue == 3) {\r\n                    " +
"    return \'<span class=\\\"label label-danger\\\" >审核不通过</span>\';\r\n                " +
"    } else if (cellvalue == 4) {\r\n                        return \'<span class=\\\"" +
"label label-default\\\" >已撤销</span>\';\r\n                    }\r\n                }\r\n " +
"           },\r\n            { label: \'审核时间\', name: \'AUDITTIME\', index: \'AUDITTIME" +
"\', width: 200, align: \'left\', sortable: true, hidden: true },\r\n            { lab" +
"el: \'提交人\', name: \'UPDATEUSER\', index: \'UPDATEUSER\', width: 200, align: \'center\'," +
" sortable: true },\r\n            { label: \'修改类型\', name: \'UPDATETYPE\', index: \'UPD" +
"ATETYPE\', width: 100, align: \'center\', sortable: true, formatter: \"select\", edit" +
"options: { value: \"A:新增;U:更新;D:销号;R:删除;I:批量导入\" } },\r\n            { label: \'修改日期\'" +
", name: \'UPDATETIME\', index: \'UPDATETIME\', width: 200, align: \'left\', sortable: " +
"true },\r\n            {\r\n                label: \'对比信息\', name: \'BASICINFO\', index:" +
" \'BASICINFO\', width: 200, align: \'center\', sortable: true, formatter: function (" +
"cellvalue, options, rowObject) {\r\n                    if (rowObject.UPDATETYPE =" +
"= \'A\' || rowObject.UPDATETYPE == \'D\' || rowObject.UPDATETYPE == \'R\') {\r\n        " +
"                var guidType = rowObject.BUSINESSID + \",\" + cellvalue.split(\',\')" +
"[3] + \",\" + cellvalue.split(\',\')[2];\r\n                        var cc = guidType." +
"split(\',\');\r\n                        var str = cc[0] + \",\" + escape(cc[1]) + \",\"" +
" + cc[2];\r\n                        return \"<a style=\'color:blue;cursor: pointer;" +
"\' onclick=\'Read(\\\"\" + str + \"\\\")\'>查看</a>\";\r\n                    } else if (cellv" +
"alue) {\r\n                        var guidType = rowObject.BUSINESSID + \",\" + cel" +
"lvalue.split(\',\')[3] + \",\" + cellvalue.split(\',\')[2];\r\n                        r" +
"eturn \"<a style=\'color:blue;cursor: pointer;\' onclick=\'Compare(\\\"\" + guidType + " +
"\"\\\")\'>对比</a>\";\r\n                    } else {\r\n                        return \'\';" +
"\r\n                    }\r\n\r\n                }\r\n            }];\r\n        }\r\n    }\r" +
"\n\r\n    function Compare(cellvalue) {\r\n        var cc = cellvalue.split(\',\');\r\n  " +
"      var type = \'01\';\r\n        switch (cc[1]) {\r\n            case \"滑坡\":\r\n      " +
"          type = \'01\';\r\n                break;\r\n            case \"崩塌\":\r\n        " +
"        type = \'02\';\r\n                break;\r\n            case \"泥石流\":\r\n         " +
"       type = \'03\';\r\n                break;\r\n            case \"地面沉降\":\r\n         " +
"       type = \'04\';\r\n                break;\r\n            case \"地面塌陷\":\r\n         " +
"       type = \'05\';\r\n                break;\r\n            case \"地裂缝\":\r\n          " +
"      type = \'06\';\r\n                break;\r\n            case \"斜坡\":\r\n            " +
"    type = \'07\';\r\n                break;\r\n            default:\r\n                " +
"break;\r\n        }\r\n\r\n        dialogOpen({\r\n            id: \'CompareForm\',\r\n     " +
"       title: \'对比\' + cc[1] + \'信息\',\r\n            url: \'/JXGeoManage/TBL_HAZARDBAS" +
"ICINFO/HarzardCompare?type=\' + type + \"&keyValue=\" + cc[0] + \"&dmt=\" + cc[2] + \"" +
"&flag=true\",\r\n            width: \'100%\',\r\n            height: \'\',\r\n            b" +
"tn: []\r\n        });\r\n    }\r\n    function Read(cellvalue) {\r\n        var cc = cel" +
"lvalue.split(\',\');\r\n        var str = unescape(cc[1]);\r\n       var type = \'01\';\r" +
"\n        switch (str) {\r\n            case \"滑坡\":\r\n                type = \'01\';\r\n " +
"               break;\r\n            case \"崩塌\":\r\n                type = \'02\';\r\n   " +
"             break;\r\n            case \"泥石流\":\r\n                type = \'03\';\r\n    " +
"            break;\r\n            case \"地面沉降\":\r\n                type = \'04\';\r\n    " +
"            break;\r\n            case \"地面塌陷\":\r\n                type = \'05\';\r\n    " +
"            break;\r\n            case \"地裂缝\":\r\n                type = \'06\';\r\n     " +
"           break;\r\n            case \"斜坡\":\r\n                type = \'07\';\r\n       " +
"         break;\r\n            default:\r\n                break;\r\n        }\r\n\r\n    " +
"    dialogOpen({\r\n            id: \'CompareForm\',\r\n            title: \'查看\' + str " +
"+ \'信息\',\r\n            url: \'/JXGeoManage/TBL_HAZARDBASICINFO/HarzardCompare?type=" +
"\' + type + \"&dmt=\" + cc[2] + \"&keyValue=\" + cc[0] + \"&flag=false\",\r\n            " +
"width: \'1366px\',\r\n            height: \'\',\r\n            btn: []\r\n        });\r\n   " +
" }\r\n    //加载表格\r\n    function GetGrid() {\r\n        var selectedRowIndex = 0;\r\n   " +
"     var $gridTable = $(\'#gridTable\');\r\n        var queryJson = $(\"#filter-form\"" +
").getWebControls();\r\n        queryJson.bussnessType = bussnessType;\r\n        que" +
"ryJson[\"status\"] = \"1\";\r\n\r\n        $gridTable.jqGrid({\r\n            autowidth: t" +
"rue,\r\n            height: $(window).height() - 205 + 12,\r\n            url: \"../." +
"./api/TBL_AUDITINFOApi/GetPageAuditListJson\",\r\n            loadBeforeSend: funct" +
"ion (a) {\r\n                a.setRequestHeader(\"Authorization\", authToken);\r\n    " +
"        },\r\n            postData: { queryJson: JSON.stringify(queryJson) },\r\n   " +
"         datatype: \"json\",\r\n            colModel: columns,\r\n            multisel" +
"ect: true,\r\n            viewrecords: true,\r\n            rowList: [30, 50, 100],\r" +
"\n            pager: \"#gridPager\",\r\n            sortname: \'UPDATETIME\',\r\n        " +
"    rowNum: 30,\r\n            sortorder: \'desc\',\r\n            rownumbers: true,\r\n" +
"            shrinkToFit: true,\r\n            gridview: true,\r\n            onSelec" +
"tRow: function () {\r\n                selectedRowIndex = $(\'#\' + this.id).getGrid" +
"Param(\'selrow\');\r\n            },\r\n            gridComplete: function () {\r\n     " +
"          // $(\'#\' + this.id).setSelection(selectedRowIndex, false);\r\n          " +
"  }\r\n        });\r\n    }\r\n    //加载表格\r\n    function GetGridhistor() {\r\n        var" +
" selectedRowIndex = 0;\r\n        var $gridTable = $(\'#gridTablehistory\');\r\n      " +
"  var queryJson = $(\"#filter-form\").getWebControls();\r\n        queryJson.bussnes" +
"sType = bussnessType;\r\n        $gridTable.jqGrid({\r\n            autowidth: true," +
"\r\n            height: $(window).height() - 195 + 12,\r\n            url: \"../../ap" +
"i/TBL_AUDITINFOApi/GetPageAuditListJson\",\r\n            postData: { queryJson: JS" +
"ON.stringify(queryJson) },\r\n            datatype: \"json\",\r\n            colModel:" +
" columns,\r\n            viewrecords: true,\r\n            rowList: [30, 50, 100],\r\n" +
"            pager: \"#gridPagerhistory\",\r\n            sortname: \'AUDITTIME\',\r\n   " +
"         sortorder: \'desc\',\r\n            rownumbers: true,\r\n            rowNum: " +
"30,\r\n            shrinkToFit: true,\r\n            gridview: true,\r\n            lo" +
"adBeforeSend: function (a) {\r\n                a.setRequestHeader(\"Authorization\"" +
", authToken);\r\n            },\r\n            onSelectRow: function () {\r\n         " +
"       selectedRowIndex = $(\'#\' + this.id).getGridParam(\'selrow\');\r\n            " +
"},\r\n            gridComplete: function () {\r\n               // $(\'#\' + this.id)." +
"setSelection(selectedRowIndex, false);\r\n            }\r\n        });\r\n    }\r\n\r\n   " +
" //查询表格函数\r\n    function SearchEvent_Submit() {\r\n        var queryJson = $(\"#filt" +
"er-form\").getWebControls();\r\n        queryJson.bussnessType = bussnessType;\r\n   " +
"     queryJson[\"status\"] = \"1\";\r\n        queryJson[\"txt_Keyword\"] = $(\"#txt_Keyw" +
"ord1\").val();\r\n        queryJson[\"updateType\"] = $(\"#updateTypes\").attr(\"data-va" +
"lue\");\r\n        queryJson[\"StartTime\"] = $(\"#StartTime1\").val();\r\n        queryJ" +
"son[\"EndTime\"] = $(\"#EndTime1\").val();\r\n        $(\"#gridTable\").jqGrid(\'setGridP" +
"aram\', {\r\n            postData: { queryJson: JSON.stringify(queryJson) },\r\n     " +
"       loadBeforeSend: function (a) {\r\n                a.setRequestHeader(\"Autho" +
"rization\", authToken);\r\n            },\r\n            url: \"../../api/TBL_AUDITINF" +
"OApi/GetPageAuditListJson\",\r\n            page: 1\r\n        }).trigger(\'reloadGrid" +
"\');\r\n    }\r\n    function SearchEvent() {\r\n        var queryJson = $(\"#filter-for" +
"m\").getWebControls();\r\n        queryJson.bussnessType = bussnessType;\r\n        $" +
"(\"#gridTablehistory\").jqGrid(\'setGridParam\', {\r\n            postData: { queryJso" +
"n: JSON.stringify(queryJson) },\r\n            loadBeforeSend: function (a) {\r\n   " +
"             a.setRequestHeader(\"Authorization\", authToken);\r\n            },\r\n  " +
"          url: \"../../api/TBL_AUDITINFOApi/GetPageAuditListJson\",\r\n            p" +
"age: 1\r\n        }).trigger(\'reloadGrid\');\r\n    }\r\n    //审核按钮\r\n    function Submi" +
"tAudit() {\r\n        var $gridTable = $(\'#gridTable\');\r\n        var rowIndexs = $" +
"gridTable.jqGrid(\'getGridParam\', \'selarrrow\');\r\n        if (rowIndexs.length > 0" +
") {\r\n            //打开审核窗口\r\n            learun.dialogOpenConfirm({\r\n             " +
"   id: \'Form1\',\r\n                title: \'提交审核信息\',\r\n                url: \'/JXGeoM" +
"anage/TBL_AUDITINFO/AuditInfoForm\',\r\n                width: \'700px\',\r\n          " +
"      height: \'500px\',\r\n                btn: [\"审核通过\", \"审核不通过\"],\r\n               " +
" isClose:true,\r\n                callBack: function (iframeId, b) {              " +
" \r\n                    var auditInfo = getInfoTop().frames[iframeId].AcceptClick" +
"();\r\n                    auditInfo.state = b == true ? 2 : 3;                  \r" +
"\n                    //获取需要审核的数据业务ID\r\n                    var busnessIds = new A" +
"rray();\r\n                    for (var i = 0; i < rowIndexs.length; i++) {\r\n     " +
"                   var data = $gridTable.jqGrid(\'getRowData\', rowIndexs[i]);\r\n  " +
"                      busnessIds.push(data.GUID);\r\n                    }\r\n      " +
"              auditInfo.keyValues = busnessIds;\r\n                    $(\'#gridTab" +
"le\').trigger(\'reloadGrid\');\r\n                    $.SaveForm({\r\n                 " +
"       url: \"../../api/TBL_AUDITINFOApi/AuditData\",\r\n                        loa" +
"ding: \"正在提交数据...\",\r\n                        param: auditInfo,\r\n                 " +
"       authToken: authToken,\r\n                        success: function () {\r\n  " +
"                          try {\r\n                                \r\n             " +
"                   getInfoTop().learun.currentIframe().$(\'#gridTable\').trigger(\'" +
"reloadGrid\');\r\n                                getInfoTop().learun.currentIframe" +
"().$(\'#gridTablehistory\').trigger(\'reloadGrid\');\r\n                              " +
"  $(\'#gridTable\').trigger(\'reloadGrid\');\r\n                                $(\'#gr" +
"idTablehistory\').trigger(\'reloadGrid\');\r\n                                \r\n     " +
"                       } catch (e) {\r\n                                $(\'#gridTa" +
"ble\').trigger(\'reloadGrid\');\r\n                                $(\'#gridTablehisto" +
"ry\').trigger(\'reloadGrid\');\r\n                                window.parent.$(\'#g" +
"ridTable\').trigger(\'reloadGrid\');\r\n                                window.parent" +
".$(\'#gridTablehistory\').trigger(\'reloadGrid\');\r\n                            }\r\n " +
"                       }\r\n                    })\r\n\r\n                }\r\n         " +
"   });\r\n        }\r\n        else {\r\n            dialogMsg(\'请选择需要审核的数据！\', 0);\r\n   " +
"     }\r\n    }\r\n\r\n    function initSelect() {\r\n        $(\"#status\").ComboBox({\r\n " +
"           id: \"value\",\r\n            text: \"label\",\r\n            description: \"全" +
"部审核状态\",\r\n            height: \"170px\",\r\n            data: [\r\n                { la" +
"bel: \"待审核\", value: \"1\" },\r\n                { label: \"审核通过\", value: \"2\" },\r\n     " +
"           { label: \"审核不通过\", value: \"3\" }\r\n            ]\r\n        });\r\n\r\n       " +
" $(\"#updateType\").ComboBox({\r\n            id: \"value\",\r\n            text: \"label" +
"\",\r\n            description: \"全部修改类型\",\r\n            height: \"170px\",\r\n          " +
"  data: [\r\n                { label: \"新增\", value: \"A\" },\r\n                { label" +
": \"更新\", value: \"U\" },\r\n                { label: \"销号\", value: \"D\" },\r\n           " +
"     { label: \"删除\", value: \"R\" }\r\n            ]\r\n        });\r\n\r\n        $(\"#upda" +
"teTypes\").ComboBox({\r\n            id: \"value\",\r\n            text: \"label\",\r\n    " +
"        description: \"全部修改类型\",\r\n            height: \"170px\",\r\n            data: " +
"[\r\n                { label: \"新增\", value: \"A\" },\r\n                { label: \"更新\", " +
"value: \"U\" },\r\n                { label: \"销号\", value: \"D\" },\r\n                { l" +
"abel: \"删除\", value: \"R\" }\r\n            ]\r\n        });\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
