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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_BQBR/TBL_BQBRHZForm.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_BQBR_TBL_BQBRHZForm_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_BQBR_TBL_BQBRHZForm_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_BQBR\TBL_BQBRHZForm.cshtml"
  
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

WriteLiteral(">灾害点搬迁避让列表</a></li>\n            <li");

WriteLiteral(" style=\"float: right; margin-right: 25px; \"");

WriteLiteral(" id=\"li_close\"");

WriteLiteral(">\n                <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" style=\"border: 1px solid #ccc; border-radius: 4px; margin-top: 5px; padding: 5px" +
" 10px;\"");

WriteLiteral(" onclick=\"thisClose(\'BQBRHZXQ\')\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-close\"");

WriteLiteral("></i>关闭</a>\n            </li>\n        </ul>\n    </div>\n\n    <div");

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

            
            #line 94 "..\..\Areas\JXGeoManage\Views\TBL_BQBR\TBL_BQBRHZForm.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/Content/adminWater/index.js"));

            
            #line default
            #line hidden
WriteLiteral("\n<script>\n    var tabCtl;\n    var keyValue = request(\'keyValue\');\n    var authTok" +
"en = getAuthorizationToken();\n    var readonly = request(\'readonly\');\n    var un" +
"ifycode = request(\'unifycode\');\n    var details = request(\'details\');\n    var bj" +
" = request(\'bj\');\n    var callback = request(\'callback\');//\"返回\"跳转url\n    $(funct" +
"ion () {\n        InitialPage();\n        GetGrid();\n        if (bj == 01) {\r\n    " +
"        $(\"#li_close\").hide();\r\n        }\n    });\n    //加载表格\n    function GetGri" +
"d() {\n        var selectedRowIndex = 0;\n        var queryJson = {}\n        query" +
"Json[\"UNIFIEDCODE\"] = keyValue;\n        var $gridTable = $(\'#gridTable\');\n      " +
"  $gridTable.jqGrid({\n            autowidth: true,\n            loadBeforeSend: f" +
"unction (a) {\n                a.setRequestHeader(\"Authorization\", authToken);\n  " +
"          },\n            height: $(window).height() - 120,\n            url: \"../" +
"../api/TBL_BQBRApi/GetPageListJson\",\n            datatype: \"json\",\n            m" +
"type: \'GET\',\n            postData: { queryJson: JSON.stringify(queryJson) },\n   " +
"         colModel: [\n                { label: \'GUID\', name: \'GUID\', index: \'GUID" +
"\', width: 100, align: \'left\', sortable: true,hidden:true },\n                {\n  " +
"                  label: \'户主姓名\', name: \'HOUSEHOLDERNAME\', index: \'HOUSEHOLDERNAM" +
"E\', width: 250, align: \'left\', sortable: true, formatter: function (cellvalue, o" +
"ptions, rowObject) {\n                        if (cellvalue) {\n                  " +
"          return \'<a onclick=ViewMonitorDetail(\"\' + rowObject.GUID + \'\"); style=" +
"\"cursor:pointer;text-decoration:underline;color:#0099ff !important;\">\' + cellval" +
"ue + \'</a>\';\n                        } else {\n                            return" +
" \"\";\n                        }\n                    }\n                },\n        " +
"        { label: \'单户搬迁人数\', name: \'MOVEDECIMAL\', index: \'MOVEDECIMAL\', width: 150" +
", align: \'left\', sortable: true },\n                {\n                    label: " +
"\'安置方式\', name: \'RESETTLEMENT\', index: \'RESETTLEMENT\', width: 100, align: \'left\', " +
"sortable: true, formatter: function (cellvalue, options, rowObject) {\n          " +
"              if (cellvalue == \"1\") {\n                            return \'集中安置\';" +
"\n                        } else if (cellvalue == \"2\") {\n                        " +
"    return \'分散安置\';\n                        } else if (cellvalue == \"3\") {\n      " +
"                      return \'购房安置\';\n                        } else if (cellvalu" +
"e == \"4\") {\n                            return \'其它安置\';\n                        }" +
" else\n                            return \"\";\n                    }\n             " +
"   },\n                { label: \'安置点\', name: \'AZDMC\', index: \'AZDMC\', width: 100," +
" align: \'left\', sortable: true, hidden: true },\n                { label: \'总安置补贴金" +
"额（万元）\', name: \'ZAZBTJE\', index: \'ZAZBTJE\', width: 200, align: \'left\', sortable: " +
"true},\n                { label: \'已发金额（万元）\', name: \'YFJE\', index: \'YFJE\', width: " +
"150, align: \'left\', sortable: true },\n                { label: \'代发金额（万元）\', name:" +
" \'DFJR\', index: \'DFJR\', width: 150, align: \'left\', sortable: true },\n           " +
"     {\n                    label: \'是否完成\', name: \'SFWC\', index: \'SFWC\', width: 15" +
"0, align: \'left\', sortable: true, formatter: function (cellvalue, options, rowOb" +
"ject) {\n                        if (cellvalue == \"1\") {\n                        " +
"    return \'是\';\n                        }\n                        else if (cellv" +
"alue == \"0\") {\n                            return \'否\';\n                        }" +
"\n                        else\n                            return \"\";\n           " +
"         }\n                },\n                {\n                    label: \'是否验收" +
"\', name: \'SFYS\', index: \'SFYS\', width: 150, align: \'left\', sortable: true, forma" +
"tter: function (cellvalue, options, rowObject) {\n                        if (cel" +
"lvalue == \"1\") {\n                            return \'是\';\n                       " +
" }\n                        else if (cellvalue == \"0\") {\n                        " +
"    return \'否\';\n                        }\n                        else\n         " +
"                   return \"\";\n                    }\n                },\n         " +
"   ],\n            viewrecords: true,\n            rowNum: 30,\n            rowList" +
": [30, 50, 100],\n            pager: \"#gridPager\",\n            sortname: \'UNIFIED" +
"CODE\',\n            sortorder: \'desc\',\n            rownumbers: true,\n            " +
"shrinkToFit: false,\n            gridview: true,\n            onSelectRow: functio" +
"n (rowId, status) {\n                selectedRowIndex = $(\'#\' + this.id).getGridP" +
"aram(\'selrow\');\n            },\n            gridComplete: function () {\n         " +
"       $(\'#\' + this.id).setSelection(selectedRowIndex, false);\n            }\n   " +
"     });\n    }\n    //详情新标签栏打开方式\n    function ViewMonitorDetail1(keyValue) {\n    " +
"    var url = \'/JXGeoManage/TBL_BQBR/TBL_BQBRForm?keyValue=\' + keyValue + \'&deta" +
"ils=01&IdetIfrem=Idetnew\' + \"&readonly=01\";\n            newTabs({\n              " +
"  id: \"BQBRXQ\",\n                url: url\n            });\n        }\n    function " +
"ViewMonitorDetail(keyValue) {\r\n      //  var keyValue = $(\"#gridTable\").jqGridRo" +
"wValue(\'GUID\');\r\n        if (checkedRow(keyValue)) {\r\n            dialogOpen({\r\n" +
"                id: \'BQBRXQ\',\r\n                title: \'搬迁避让信息表\',\r\n              " +
"  url: \'/JXGeoManage/TBL_BQBR/TBL_BQBRForm?keyValue=\' + keyValue + \'&details=01&" +
"IdetIfrem=Idetnew\' + \"&readonly=01\",\r\n                width: \'1300px\',\r\n        " +
"        height: \'700px\',\r\n                callBack: function (iframeId) {\r\n     " +
"               getInfoTop().frames[iframeId].AcceptClick();\r\n                }\r\n" +
"            })\r\n        }\r\n    }\n\n    //初始化页面\r\n    function InitialPage() {\r\n   " +
"     \r\n        //resize重设布局;\r\n        $(window).resize(function (e) {\r\n         " +
"   resize();\r\n            e.stopPropagation();\r\n        });\r\n        function re" +
"size() {\r\n            window.setTimeout(function () {\r\n                $(\'#gridT" +
"able\').setGridWidth(($(\'.gridPanel\').width()) - 20);\r\n                $(\'#layout" +
"2 .ui-layout-center\').width($(\'#layout2 .ui-layout-center\').parent().width() - 2" +
"0);\r\n                $(\'#layout2 .ui-layout-resizer\').width($(\'#layout2 .ui-layo" +
"ut-center\').parent().width() - 20);\r\n                $(\'.ui-jqgrid-bdiv\').height" +
"($(window).height() - 120);\r\n                $(\'#layout2 .ui-layout-center\').hei" +
"ght($(window).height() - 120);\r\n                $(\'#gridTable\').setGridHeight($(" +
"window).height() - 120);\r\n                //$(\'#layout2 .ui-layout-center\').css(" +
"\'overflow\', \'hidden\');\r\n            }, 200);\r\n        };\r\n        $(window).resi" +
"ze();\r\n    }\n</script>\n");

});

        }
    }
}
#pragma warning restore 1591
