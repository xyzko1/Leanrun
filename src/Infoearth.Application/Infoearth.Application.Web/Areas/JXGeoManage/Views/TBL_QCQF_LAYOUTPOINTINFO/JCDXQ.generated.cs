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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_QCQF_LAYOUTPOINTINFO/JCDXQ.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_QCQF_LAYOUTPOINTINFO_JCDXQ_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_QCQF_LAYOUTPOINTINFO_JCDXQ_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_QCQF_LAYOUTPOINTINFO\JCDXQ.cshtml"
  
    ViewBag.Title = "表单页面";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 5 "..\..\Areas\JXGeoManage\Views\TBL_QCQF_LAYOUTPOINTINFO\JCDXQ.cshtml"
  
    ViewBag.Title = "列表页面";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<style>\r\n    .form td {\r\n        border: 1px solid #d6d6d6;\r\n        text-align" +
": center !important;\r\n    }\r\n</style>\r\n<div");

WriteLiteral(" style=\"padding:10px;\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(" id=\"formqcqc_la\"");

WriteLiteral(">\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">灾害点名称</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"DISASTERNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" readonly=\"readonly\"");

WriteLiteral("/>\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">地理位置</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"LOCATION\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" readonly=\"readonly\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">责任人</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"ZRRNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  readonly=\"readonly\"");

WriteLiteral("/>\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">责任人电话</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"ZRRPHONE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  readonly=\"readonly\"");

WriteLiteral("/>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">灾害点编号</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"UNIFIEDCODE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("   readonly=\"readonly\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">监测类型</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"MONITORPOINTTYPE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("   readonly=\"readonly\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">监测类型编号</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"MONITORPOINTCODE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  readonly=\"readonly\"");

WriteLiteral("/>\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">监测部位</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"MONITORPOINTPOSITION\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  readonly=\"readonly\"");

WriteLiteral("/>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">经度</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"LON\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  readonly=\"readonly\"");

WriteLiteral("/>\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">纬度</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"LAT\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  readonly=\"readonly\"");

WriteLiteral("/>\r\n            </td>\r\n        </tr>\r\n       <tr");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">GUID</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"GUID\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n       </tr>\r\n    </table>\r\n</div>\r\n<div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    var queryJson = [];\r\n   " +
" var authToken = getAuthorizationToken();\r\n    $(function () {\r\n        initCont" +
"rol();\r\n        GetGrid();\r\n    });\r\n    //初始化控件\r\n    function initControl() {\r\n" +
"        //获取表单\r\n        if (!!keyValue) {\r\n            $.SetForm({\r\n            " +
"    url: \"../../api/TBL_QCQF_LAYOUTPOINTINFOApi/GetFormJson\",\r\n                p" +
"aram: { keyValue: keyValue },\r\n                authToken: authToken,\r\n          " +
"      success: function (data) {\r\n                    $(\"#formqcqc_la\").SetWebCo" +
"ntrols(data);\r\n                    var strMONITORPOINTTYPE = \"\";\r\n              " +
"      switch (data[\"MONITORPOINTCODE\"].substring(0, 2)) {\r\n                     " +
"   case \"DG\":\r\n                            strMONITORPOINTTYPE = \"地鼓\";\r\n        " +
"                    break;\r\n                        case \"DL\":\r\n                " +
"            strMONITORPOINTTYPE = \"地裂\";\r\n                            break;\r\n   " +
"                     case \"QL\":\r\n                            strMONITORPOINTTYPE" +
" = \"墙裂\";\r\n                            break;\r\n                        case \"JS\":" +
"\r\n                            strMONITORPOINTTYPE = \"井水\";\r\n                     " +
"       break;\r\n                        case \"QS\":\r\n                            s" +
"trMONITORPOINTTYPE = \"泉水\";\r\n                            break;\r\n                " +
"        default:\r\n                            break;\r\n                    }\r\n   " +
"                 $(\"#MONITORPOINTTYPE\").val(strMONITORPOINTTYPE);\r\n             " +
"   }\r\n            })\r\n        }\r\n        //获取jqgrid数据\r\n        var values = [];\r" +
"\n        $.ajax({\r\n            url: \"../../api/TBL_QCQF_POINTOBSERVATIONApi/GetL" +
"istByUNIFIEDCODE\",\r\n            type: \"GET\",\r\n            async: false,\r\n       " +
"     data: { UNIFIEDCODE: keyValue },\r\n            beforeSend: function (a) {\r\n " +
"               a.setRequestHeader(\"Authorization\", authToken);\r\n            },\r\n" +
"            success: function (data) {\r\n                if (data != undefined &&" +
" data != null && data != \'\') {\r\n                    for (var i = 0; i < data.len" +
"gth; i++) {\r\n                        values.push(data[i][\"ID\"]);\r\n              " +
"      }\r\n                }\r\n            }\r\n        })\r\n        GetGrid(values);\r" +
"\n        queryJson = values;\r\n    }\r\n\r\n\r\n    //加载表格\r\n    function GetGrid(data) " +
"{\r\n        var selectedRowIndex = 0;\r\n        var $gridTable = $(\'#gridTable\');\r" +
"\n        if (data != undefined && data != null && data != \'\') {\r\n            que" +
"ryJson = data;\r\n        }\r\n        $gridTable.jqGrid({\r\n            autowidth: t" +
"rue,\r\n            height: $(window).height() - 286.5 - 28,\r\n            url: \".." +
"/../JXGeoManage/TBL_QCQF_POINTOBSERVATION/GetDataJcr\",\r\n            datatype: \"j" +
"son\",\r\n            postData: { id: keyValue },\r\n            loadBeforeSend: func" +
"tion (a) {\r\n                a.setRequestHeader(\"Authorization\", authToken);\r\n   " +
"         },\r\n            colModel: [\r\n                { label: \'GUID\', name: \'GU" +
"ID\', index: \'GUID\', width: 100, align: \'left\', sortable: true, hidden: true },\r\n" +
"                { label: \'观测人姓名\', name: \'OBSERVATIONPEOPLE\', index: \'OBSERVATION" +
"PEOPLE\', width: 150, align: \'left\', sortable: true },\r\n                { label: " +
"\'观测人电话\', name: \'OBSERVATIONPHONE\', index: \'OBSERVATIONPHONE\', width: 150, align:" +
" \'left\', sortable: true },\r\n            ],\r\n            viewrecords: true,\r\n    " +
"        sortname: \'GUID\',\r\n            sortorder: \'desc\',\r\n            rownumber" +
"s: true,\r\n            shrinkToFit: false,\r\n            gridview: true,\r\n        " +
"    onSelectRow: function () {\r\n                selectedRowIndex = $(\'#\' + this." +
"id).getGridParam(\'selrow\');\r\n            },\r\n            gridComplete: function " +
"() {\r\n                $(\'#\' + this.id).setSelection(selectedRowIndex, false);\r\n " +
"           }\r\n        });\r\n    }\r\n\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
