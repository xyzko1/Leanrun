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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/SystemManage/Views/DataBaseLink/Index.cshtml")]
    public partial class _Areas_SystemManage_Views_DataBaseLink_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_SystemManage_Views_DataBaseLink_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\SystemManage\Views\DataBaseLink\Index.cshtml"
  
    ViewBag.Title = "库连接管理";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        InitialPage();\r\n        GetGrid();\r\n    " +
"});\r\n    //初始化页面\r\n    function InitialPage() {\r\n        //resize重设(表格、树形)宽高\r\n   " +
"     $(window).resize(function (e) {\r\n            window.setTimeout(function () " +
"{\r\n                $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').width()));\r\n   " +
"             $(\"#gridTable\").setGridHeight($(window).height() - 108.5);\r\n       " +
"     }, 200);\r\n            e.stopPropagation();\r\n        });\r\n    }\r\n    //加载表格\r" +
"\n    function GetGrid() {\r\n        var selectedRowIndex = 0;\r\n        var $gridT" +
"able = $(\"#gridTable\");\r\n        $gridTable.jqGrid({\r\n            url: \"../../Sy" +
"stemManage/DataBaseLink/GetListJson\",\r\n            datatype: \"json\",\r\n          " +
"  height: $(window).height() - 108.5,\r\n            autowidth: true,\r\n           " +
" colModel: [\r\n                { label: \"主键\", name: \"F_DatabaseLinkId\", hidden: t" +
"rue },\r\n                { label: \"库类型\", name: \"F_DbType\", index: \"F_DbType\", wid" +
"th: 100, align: \"left\" },\r\n                { label: \"库版本\", name: \"F_Version\", in" +
"dex: \"F_Version\", width: 80, align: \"left\" },\r\n                { label: \"库名称\", n" +
"ame: \"F_DBName\", index: \"F_DBName\", width: 200, align: \"left\" },\r\n              " +
"  { label: \"库别名\", name: \"F_DBAlias\", index: \"F_DBAlias\", width: 200, align: \"lef" +
"t\" },\r\n                { label: \"服务地址\", name: \"F_ServerAddress\", index: \"F_Serve" +
"rAddress\", width: 180, align: \"left\" },\r\n                { label: \"备注\", name: \"F" +
"_Description\", index: \"F_Description\", width: 200, align: \"left\" }\r\n            " +
"],\r\n            rowNum: \"10000\",\r\n            rownumbers: true,\r\n            onS" +
"electRow: function () {\r\n                selectedRowIndex = $(\"#\" + this.id).get" +
"GridParam(\'selrow\');\r\n            },\r\n            gridComplete: function () {\r\n " +
"               $(\"#\" + this.id).setSelection(selectedRowIndex, false);\r\n        " +
"    }\r\n        });\r\n        //查询事件\r\n        $(\"#btn_Search\").click(function () {" +
"\r\n            $gridTable.jqGrid(\'setGridParam\', {\r\n                postData: { k" +
"eyword: $(\"#txt_Keyword\").val() },\r\n            }).trigger(\'reloadGrid\');\r\n     " +
"   });\r\n    }\r\n    //新增\r\n    function btn_add() {\r\n        var parentId = $(\"#gr" +
"idTable\").jqGridRowValue(\"F_ItemId\");\r\n        learun.dialogOpen({\r\n            " +
"id: \"Form\",\r\n            title: \'添加连接\',\r\n            url: \'/SystemManage/DataBas" +
"eLink/Form?parentId=\' + parentId,\r\n            width: \"500px\",\r\n            heig" +
"ht: \"400px\",\r\n            callBack: function (iframeId) {\r\n                getIn" +
"foTop().frames[iframeId].AcceptClick();\r\n            }\r\n        });\r\n    };\r\n   " +
" //编辑\r\n    function btn_edit() {\r\n        var keyValue = $(\"#gridTable\").jqGridR" +
"owValue(\"F_DatabaseLinkId\");\r\n        if (learun.checkedRow(keyValue)) {\r\n      " +
"      learun.dialogOpen({\r\n                id: \"Form\",\r\n                title: \'" +
"编辑连接\',\r\n                url: \'/SystemManage/DataBaseLink/Form?keyValue=\' + keyVa" +
"lue,\r\n                width: \"500px\",\r\n                height: \"400px\",\r\n       " +
"         callBack: function (iframeId) {\r\n                    getInfoTop().frame" +
"s[iframeId].AcceptClick();\r\n                }\r\n            });\r\n        }\r\n    }" +
"\r\n    //删除\r\n    function btn_delete() {\r\n        var keyValue = $(\"#gridTable\")." +
"jqGridRowValue(\"F_DatabaseLinkId\");\r\n        if (keyValue) {\r\n            learun" +
".removeForm({\r\n                url: \"../../SystemManage/DataBaseLink/RemoveForm\"" +
",\r\n                param: { keyValue: keyValue },\r\n                success: func" +
"tion (data) {\r\n                    $(\"#gridTable\").trigger(\"reloadGrid\");\r\n     " +
"           }\r\n            })\r\n        } else {\r\n            learun.dialogMsg({ m" +
"sg: \'请选择需要删除的库连接！\', type: 0 });\r\n        }\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n        <table>\r\n            <tr>\r\n                <td>\r\n                    <" +
"input");

WriteLiteral(" id=\"txt_Keyword\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入要查询关键字\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" style=\"padding-left: 5px;\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>&nbsp;查询</a>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n  " +
"  </div>\r\n    <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"learun.reload();\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>&nbsp;刷新</a>\r\n            <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_add()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>&nbsp;新增</a>\r\n            <a");

WriteLiteral(" id=\"lr-edit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_edit()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pencil-square-o\"");

WriteLiteral("></i>&nbsp;编辑</a>\r\n            <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_delete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>&nbsp;删除</a>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
