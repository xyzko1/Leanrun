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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CustomerManage/Views/Customer/ContactIndex.cshtml")]
    public partial class _Areas_CustomerManage_Views_Customer_ContactIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_CustomerManage_Views_Customer_ContactIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\CustomerManage\Views\Customer\ContactIndex.cshtml"
  
    ViewBag.Title = "联系人列表";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>    ;\r\n    var customerId = request(\'customerId\');\r\n    $(function () {" +
"\r\n        InitialPage();\r\n        GetGrid();\r\n    });\r\n    //初始化页面\r\n    function" +
" InitialPage() {\r\n        //resize重设布局;\r\n        $(window).resize(function (e) {" +
"\r\n            window.setTimeout(function () {\r\n                $(\'#gridTable\').s" +
"etGridWidth(($(\'.gridPanel\').width()));\r\n                $(\'#gridTable\').setGrid" +
"Height($(window).height() - 108.5);\r\n            }, 200);\r\n            e.stopPro" +
"pagation();\r\n        });\r\n    }\r\n    //加载表格\r\n    function GetGrid() {\r\n        v" +
"ar selectedRowIndex = 0;\r\n        var $gridTable = $(\'#gridTable\');\r\n        $gr" +
"idTable.jqGrid({\r\n            autowidth: true,\r\n            height: $(window).he" +
"ight() - 108.5,\r\n            url: \"../../CustomerManage/Customer/GetContactListJ" +
"son\",\r\n            postData: { queryJson: JSON.stringify({ customerId: customerI" +
"d }) },\r\n            datatype: \"json\",\r\n            colModel: [\r\n               " +
" { label: \'主键\', name: \'F_CustomerContactId\', hidden: true },\r\n                { " +
"label: \'联系人\', name: \'F_Contact\', index: \'F_Contact\', width: 100, align: \'left\', " +
"sortable: true },\r\n                { label: \'手机\', name: \'F_Mobile\', index: \'F_Mo" +
"bile\', width: 120, align: \'left\', sortable: true },\r\n                { label: \'电" +
"话\', name: \'F_Tel\', index: \'F_Tel\', width: 120, align: \'left\', sortable: true },\r" +
"\n                { label: \'QQ\', name: \'F_QQ\', index: \'F_QQ\', width: 120, align: " +
"\'left\', sortable: true },\r\n                { label: \'微信\', name: \'F_Wechat\', inde" +
"x: \'F_Wechat\', width: 120, align: \'left\', sortable: true },\r\n                { l" +
"abel: \'职位\', name: \'F_PostId\', index: \'F_PostId\', width: 100, align: \'left\', sort" +
"able: true },\r\n                { label: \'备注\', name: \'F_Description\', index: \'F_D" +
"escription\', width: 200, align: \'left\', sortable: true }\r\n            ],\r\n      " +
"      rownumbers: true,\r\n            onSelectRow: function () {\r\n               " +
" selectedRowIndex = $(\'#\' + this.id).getGridParam(\'selrow\');\r\n            },\r\n  " +
"          gridComplete: function () {\r\n                $(\'#\' + this.id).setSelec" +
"tion(selectedRowIndex, false);\r\n            }\r\n        });\r\n        //查询条件\r\n    " +
"    $(\"#queryCondition .dropdown-menu li\").click(function () {\r\n            var " +
"text = $(this).find(\'a\').html();\r\n            var value = $(this).find(\'a\').attr" +
"(\'data-value\');\r\n            $(\"#queryCondition .dropdown-text\").html(text).attr" +
"(\'data-value\', value)\r\n        });\r\n        //查询事件\r\n        $(\"#btn_Search\").cli" +
"ck(function () {\r\n            var queryJson = {\r\n                condition: $(\"#" +
"queryCondition\").find(\'.dropdown-text\').attr(\'data-value\'),\r\n                key" +
"word: $(\"#txt_Keyword\").val(),\r\n                customerId: customerId,\r\n       " +
"     }\r\n            $gridTable.jqGrid(\'setGridParam\', {\r\n                postDat" +
"a: { queryJson: JSON.stringify(queryJson) },\r\n            }).trigger(\'reloadGrid" +
"\');\r\n        });\r\n        //查询回车\r\n        $(\'#txt_Keyword\').bind(\'keypress\', fun" +
"ction (event) {\r\n            if (event.keyCode == \"13\") {\r\n                $(\'#b" +
"tn_Search\').trigger(\"click\");\r\n            }\r\n        });\r\n    }\r\n    //新增\r\n    " +
"function btn_add() {\r\n        dialogOpen({\r\n            id: \'ContactForm\',\r\n    " +
"        title: \'添加联系人\',\r\n            url: \'/CustomerManage/Customer/ContactForm?" +
"customerId=\' + customerId,\r\n            width: \'600px\',\r\n            height: \'35" +
"0px\',\r\n            callBack: function (iframeId) {\r\n                getInfoTop()" +
".frames[iframeId].AcceptClick();\r\n            }\r\n        });\r\n    }\r\n    //编辑\r\n " +
"   function btn_edit() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowValue(" +
"\'F_CustomerContactId\');\r\n        if (checkedRow(keyValue)) {\r\n            dialog" +
"Open({\r\n                id: \'ContactForm\',\r\n                title: \'编辑联系人\',\r\n   " +
"             url: \'/CustomerManage/Customer/ContactForm?keyValue=\' + keyValue + " +
"\'&customerId=\' + customerId,\r\n                width: \'600px\',\r\n                h" +
"eight: \'350px\',\r\n                callBack: function (iframeId) {\r\n              " +
"      getInfoTop().frames[iframeId].AcceptClick();\r\n                }\r\n         " +
"   })\r\n        }\r\n    }\r\n    //删除\r\n    function btn_delete() {\r\n        var keyV" +
"alue = $(\"#gridTable\").jqGridRowValue(\'F_CustomerContactId\');\r\n        if (keyVa" +
"lue) {\r\n            $.RemoveForm({\r\n                url: \'../../CustomerManage/C" +
"ustomer/RemoveContactForm\',\r\n                param: { keyValue: keyValue },\r\n   " +
"             success: function (data) {\r\n                    $(\'#gridTable\').tri" +
"gger(\'reloadGrid\');\r\n                }\r\n            })\r\n        } else {\r\n      " +
"      dialogMsg(\'请选择需要删除的联系人！\', 0);\r\n        }\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n        <table>\r\n            <tr>\r\n                <td>\r\n                    <" +
"div");

WriteLiteral(" id=\"queryCondition\"");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"btn btn-default dropdown-text\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">选择条件</a>\r\n                        <a");

WriteLiteral(" class=\"btn btn-default dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral("><span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span></a>\r\n                        <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n                            <li><a");

WriteLiteral(" data-value=\"Contact\"");

WriteLiteral(">联系人</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"Mobile\"");

WriteLiteral(">手机</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"Tel\"");

WriteLiteral(">电话</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"QQ\"");

WriteLiteral(">QQ</a></li>\r\n                        </ul>\r\n                    </div>\r\n        " +
"        </td>\r\n                <td");

WriteLiteral(" style=\"padding-left: 2px;\"");

WriteLiteral(">\r\n                    <input");

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
