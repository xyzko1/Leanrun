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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_BQBR/TBL_LSXQ.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_BQBR_TBL_LSXQ_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_BQBR_TBL_LSXQ_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_BQBR\TBL_LSXQ.cshtml"
  
    ViewBag.Title = "表单页面";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral(@"
<style>
    .Ndispplay {
        display: none;
    }

    #mainContent {
        background: #fff;
    }

    .formTitle {
        width: 110px !important;
        background: #f6f6f6;
    }

    .haszard {
        background: #C3C3C3;
    }

    .form td {
        border: 1px solid #d6d6d6;
        text-align: center !important;
    }

        .form td input {
            border-top: none;
            border-left: none;
            border-right: none;
        }

        .form td textarea {
            border-top: none;
            border-left: none;
            border-right: none;
        }

    .form-control:disabled {
        background: #fff;
    }

    .formValue {
        background: #fff;
    }

    .btn-group.open .dropdown-toggle {
        -webkit-box-shadow: none;
        box-shadow: none;
    }

    .readonly {
        background: #f5f5f5 !important;
    }

    #DEVICETYPECODE, #MONITORPOINTCODE_DEVICE {
        border: 1px solid #ccc;
        border-radius: 4px;
    }
    .ui-state-highlight a, .ui-widget-content .ui-state-highlight a {
color:#fff !important;
cursor:pointer;
    }
    #form1 {
        height:auto;
    }
    #BQBRXQ {
        height:99%;
    }
</style>
<div");

WriteLiteral(" style=\"width: 100%; height: 100%\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(">\n    <div");

WriteLiteral(" style=\"height: 40px; width: 100%;\"");

WriteLiteral(">\n        <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(" style=\"padding-top: 2px\"");

WriteLiteral(">\n            <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(" id=\"li_XMXX\"");

WriteLiteral("><a");

WriteLiteral(" href=\"\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">历史险情列表</a></li>\n            <li");

WriteLiteral(" style=\"float: right; margin-right: 25px; \"");

WriteLiteral(" id=\"li_close\"");

WriteLiteral(">\n                <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" style=\"border: 1px solid #ccc; float:left;border-radius: 4px; margin-top: 5px; p" +
"adding: 5px 10px;\"");

WriteLiteral(" onclick=\"xiangqing()\"");

WriteLiteral(">详情</a>\r\n\n            </li>\n        </ul>\n    </div>\n\n    <div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout2\"");

WriteLiteral(" style=\"height: calc(100% - 40px); width: 100%;\"");

WriteLiteral(">\n        <div");

WriteLiteral(" id=\"myTabContent\"");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\n\n            <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\n                <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral("></table>\n                <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\n            </div>\n        </div>\n    </div>\n</div>\n\n");

DefineSection("Scripts", () => {

WriteLiteral("\n");

            
            #line 95 "..\..\Areas\JXGeoManage\Views\TBL_BQBR\TBL_LSXQ.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/Content/adminWater/index.js"));

            
            #line default
            #line hidden
WriteLiteral("\n<script>\n    var tabCtl;\n    var keyValue = request(\'keyValue\');\n    var authTok" +
"en = getAuthorizationToken();\n    var readonly = request(\'readonly\');\n    var un" +
"ifycode = request(\'unifycode\');\n    var details = request(\'details\');\n    var bj" +
" = request(\'bj\');\n    var callback = request(\'callback\');//\"返回\"跳转url\n    var yjU" +
"RL = \"\";\n    $(function () {\n        $.ajax({\r\n            url: \"../../Utility/G" +
"etAppSetting\",\r\n            async: false, //同步请求\r\n            data: { key: \"YJDC" +
"Url\" },\r\n            type: \"GET\",\r\n            success: function (data) {\r\n     " +
"           yjURL = data;\r\n                GetGrid();\r\n            }\r\n        })\n" +
"        InitialPage();\n    });\n    //加载表格\n    function GetGrid() {\r\n        var " +
"selectedRowIndex = 0;\r\n        var $gridTable = $(\'#gridTable\');\r\n        var qu" +
"eryJson = {};\r\n        queryJson[\"DISASTERCODE\"] = keyValue;\r\n        $gridTable" +
".jqGrid({\r\n            autowidth: true,\r\n            mtype: \'POST\',\r\n           " +
" postData: { queryJson: JSON.stringify(queryJson) },\r\n            loadBeforeSend" +
": function (a) {\r\n                a.setRequestHeader(\"Authorization\", authToken)" +
";\r\n            },\r\n            url: yjURL + \"../../api/TBL_YJZH_DANGECASEINFOApi" +
"/PostPageListJson\",\r\n            datatype: \"json\",\r\n            colModel: [\r\n   " +
"             { label: \'灾险情唯一编号\', name: \'UNIFIEDCODE\', index: \'UNIFIEDCODE\', hidd" +
"en: true, width: 100, align: \'left\', sortable: true },\r\n                { label:" +
" \'灾险情名称\', name: \'DANGECASETITLE\', index: \'DANGECASETITLE\', width: 260, align: \'l" +
"eft\', sortable: true },\r\n                { label: \'灾害点名称\', name: \'DISASTRENAME\'," +
" index: \'DISASTRENAME\', width: 260, align: \'left\', sortable: true },\r\n          " +
"      {\r\n                    label: \'灾害类型\', name: \'DISASTRETYPE\', index: \'DISAST" +
"RETYPE\', width: 150, align: \'left\', sortable: true\r\n                },\r\n        " +
"        {\r\n                    label: \'发生时间\', name: \'OCCURTIME\', index: \'OCCURTI" +
"ME\', hidden: true, width: 100, align: \'left\', sortable: true,\r\n                 " +
"   formatter: function (cellvalue) {\r\n                        if (cellvalue) { r" +
"eturn learun.formatDate(cellvalue, \'yyyy-MM-dd hh:mm:ss\'); } else { return \'\' }\r" +
"\n                    }\r\n                },\r\n                { label: \'灾险情地点\', na" +
"me: \'OCCURPLACE\', index: \'OCCURPLACE\', hidden: true, width: 100, align: \'left\', " +
"sortable: true },\r\n                { label: \'报警人\', name: \'ALARMPERSON\', index: \'" +
"ALARMPERSON\', hidden: true, width: 100, align: \'left\', sortable: true },\r\n      " +
"          { label: \'报警人联系电话\', name: \'PHONE\', index: \'PHONE\', hidden: true, width" +
": 100, align: \'left\', sortable: true },\r\n                {\r\n                    " +
"label: \'灾险情等级\', name: \'ALARMLEVEL\', index: \'ALARMLEVEL\', width: 100, align: \'lef" +
"t\', sortable: true,\r\n                    formatter: function (cellvalue, options" +
", rowObject) {\r\n                        return getInfoTop().learun.data.get([\"da" +
"taItem\", \"DANGECASELEVEL\", cellvalue]);\r\n                    }\r\n                " +
"},\r\n                {\r\n                    label: \'处理状态\', name: \'STATUS\', index:" +
" \'STATUS\', width: 100, align: \'left\', sortable: true,\r\n                    forma" +
"tter: function (cellvalue, options, rowObject) {\r\n                        return" +
" getInfoTop().learun.data.get([\"dataItem\", \"STATUS\", cellvalue]);\r\n             " +
"       }\r\n                },\r\n                {\r\n                    label: \'灾险情" +
"类型\', name: \'ISZAIQINGORXIANQING\', index: \'ISZAIQINGORXIANQING\', width: 100, alig" +
"n: \'left\', sortable: true,\r\n                    formatter: function (cellvalue, " +
"options, rowObject) {\r\n                        return getInfoTop().learun.data.g" +
"et([\"dataItem\", \"ISZAIQINGORXIANQING\", cellvalue]);\r\n                    }\r\n    " +
"            },\r\n                {\r\n                    label: \'报警时间\', name: \'ALA" +
"RMTIME\', index: \'ALARMTIME\', width: 100, align: \'left\', sortable: true,\r\n       " +
"             formatter: function (cellvalue) {\r\n                        if (cell" +
"value) { return learun.formatDate(cellvalue, \'yyyy-MM-dd hh:mm:ss\'); } else { re" +
"turn \'\' }\r\n                    }\r\n                },\r\n                { label: \'" +
"灾害点编号\', name: \'DISASTERCODE\', index: \'DISASTERCODE\', hidden: true, width: 100, a" +
"lign: \'left\', sortable: true },\r\n                { label: \'村名\', name: \'VILLAGE\'," +
" index: \'VILLAGE\', hidden: true, width: 100, align: \'left\', sortable: true },\r\n " +
"               { label: \'报警方式\', name: \'ALARMTYPE\', index: \'ALARMTYPE\', hidden: t" +
"rue, width: 100, align: \'left\', sortable: true },\r\n                { label: \'报警信" +
"息来源\', name: \'ALARMSOURCE\', index: \'ALARMSOURCE\', hidden: true, width: 100, align" +
": \'left\', sortable: true },\r\n                { label: \'报警摘要\', name: \'ALARMDETAIL" +
"\', index: \'ALARMDETAIL\', hidden: true, width: 100, align: \'left\', sortable: true" +
" },\r\n                { label: \'接警人ID\', name: \'RECEIVEPERSONID\', index: \'RECEIVEP" +
"ERSONID\', hidden: true, width: 100, align: \'left\', sortable: true },\r\n          " +
"      { label: \'接警时间\', name: \'ALARMTIME\', index: \'ALARMTIME\', hidden: true, widt" +
"h: 100, align: \'left\', sortable: true, },\r\n                { label: \'接警单位ID\', na" +
"me: \'RECEIVEUNITID\', index: \'RECEIVEUNITID\', hidden: true, width: 100, align: \'l" +
"eft\', sortable: true },\r\n                { label: \'上报人ID\', name: \'CHECKPERSONID\'" +
", index: \'CHECKPERSONID\', hidden: true, width: 100, align: \'left\', sortable: tru" +
"e },\r\n                { label: \'上报单位ID\', name: \'CHECKUNITID\', index: \'CHECKUNITI" +
"D\', hidden: true, width: 100, align: \'left\', sortable: true },\r\n                " +
"{ label: \'经度\', name: \'LONGITUDE\', index: \'LONGITUDE\', width: 100, align: \'left\'," +
" sortable: true, hidden: true },\r\n                { label: \'纬度\', name: \'LATITUDE" +
"\', index: \'LATITUDE\', width: 100, align: \'left\', sortable: true, hidden: true }," +
"\r\n            ],\r\n            viewrecords: true,\r\n            rowNum: 30,\r\n     " +
"       rowList: [30, 50, 100],\r\n            pager: \"#gridPager\",\r\n            so" +
"rtname: \'OCCURPLACE\',\r\n            sortorder: \'desc\',\r\n            rownumbers: t" +
"rue,\r\n            shrinkToFit: true,\r\n            gridview: true,\r\n            a" +
"ltRows: true,\r\n            onSelectRow: function (rowId, status) {\r\n            " +
"    selectedRowIndex = $(\'#\' + this.id).getGridParam(\'selrow\');\r\n            },\r" +
"\n            gridComplete: function () {\r\n                $(\'#\' + this.id).setSe" +
"lection(selectedRowIndex, false);\r\n            }\r\n        });\r\n    }\n  \n\n    //初" +
"始化页面\r\n    function InitialPage() {\r\n        \r\n        //resize重设布局;\r\n        $(w" +
"indow).resize(function (e) {\r\n            resize();\r\n            e.stopPropagati" +
"on();\r\n        });\r\n        function resize() {\r\n            window.setTimeout(f" +
"unction () {\r\n                $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').widt" +
"h()) - 20);\r\n                $(\'#layout2 .ui-layout-center\').width($(\'#layout2 ." +
"ui-layout-center\').parent().width() - 20);\r\n                $(\'#layout2 .ui-layo" +
"ut-resizer\').width($(\'#layout2 .ui-layout-center\').parent().width() - 20);\r\n    " +
"            $(\'.ui-jqgrid-bdiv\').height($(window).height() - 120);\r\n            " +
"    $(\'#layout2 .ui-layout-center\').height($(window).height() - 120);\r\n         " +
"       $(\'#gridTable\').setGridHeight($(window).height() - 120);\r\n               " +
" //$(\'#layout2 .ui-layout-center\').css(\'overflow\', \'hidden\');\r\n            }, 20" +
"0);\r\n        };\r\n        $(window).resize();\r\n    }\n\n    function xiangqing() {\r" +
"\n        var keyValue = $(\"#gridTable\").jqGridRowValue(\'UNIFIEDCODE\');\n        i" +
"f (checkedRow(keyValue)) {\r\n            dialogOpen({\r\n                id: \'Form\'" +
",\n                title: \'查看灾（险）情信息表\',\n                url:yjURL+ \'/YJZHManage/T" +
"BL_YJZH_DANGECASEINFO/TBL_YJZH_DANGECASEINFOForm?keyValue=\' + keyValue + \"&Type=" +
"2\",\n                width: \'1000px\',\n                height: \"\",\n               " +
" btn: [],\n                callBack: function (iframeId) {\r\n                    g" +
"etInfoTop().frames[iframeId].AcceptClick();\r\n                }\r\n            })\r\n" +
"        }\r\n    }\n</script>\n");

});

        }
    }
}
#pragma warning restore 1591
