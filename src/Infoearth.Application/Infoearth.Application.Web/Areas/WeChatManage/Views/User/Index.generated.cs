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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/WeChatManage/Views/User/Index.cshtml")]
    public partial class _Areas_WeChatManage_Views_User_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_WeChatManage_Views_User_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\WeChatManage\Views\User\Index.cshtml"
  
    ViewBag.Title = "企业号成员";
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
"able = $(\'#gridTable\');\r\n        $gridTable.jqGrid({\r\n            url: \"../../We" +
"ChatManage/User/GetListJson\",\r\n            datatype: \"json\",\r\n            height" +
": $(window).height() - 108.5,\r\n            autowidth: true,\r\n            colMode" +
"l: [\r\n                { label: \'Id\', name: \'F_Id\', hidden: true },\r\n            " +
"    { label: \'账户\', name: \'F_UserId\', index: \'F_UserId\', width: 100, align: \'left" +
"\' },\r\n                { label: \'姓名\', name: \'F_RealName\', index: \'F_RealName\', wi" +
"dth: 100, align: \'left\', sortable: false },\r\n                {\r\n                " +
"    label: \'性别\', name: \'F_Gender\', index: \'F_Gender\', width: 45, align: \'center\'" +
", sortable: false,\r\n                    formatter: function (cellvalue, options," +
" rowObject) {\r\n                        return cellvalue == 1 ? \"男\" : \"女\";\r\n     " +
"               }\r\n                },\r\n                { label: \'手机\', name: \'F_Mo" +
"bile\', width: 100, align: \'center\', sortable: false },\r\n                { label:" +
" \'邮箱\', name: \'F_Email\', width: 150, align: \'left\', sortable: false },\r\n         " +
"       { label: \'微信\', name: \'F_WeChat\', width: 150, align: \'left\', sortable: fal" +
"se },\r\n                { label: \'部门\', name: \'F_DeptName\', index: \'F_DeptName\', w" +
"idth: 100, align: \'left\', sortable: false },\r\n                { label: \'职位\', nam" +
"e: \'F_PostName\', width: 100, align: \'left\', sortable: false },\r\n                " +
"{\r\n                    label: \"同步时间\", name: \"F_CreateDate\", index: \"F_CreateDate" +
"\", width: 130, align: \"center\",\r\n                    formatter: function (cellva" +
"lue, options, rowObject) {\r\n                        return learun.formatDate(cel" +
"lvalue, \'yyyy-MM-dd hh:mm\');\r\n                    }\r\n                },\r\n       " +
"         {\r\n                    label: \"同步状态\", name: \"F_SyncState\", index: \"F_Sy" +
"ncState\", width: 80, align: \"center\",\r\n                    formatter: function (" +
"cellvalue, options, rowObject) {\r\n                        if (cellvalue == -1) {" +
"\r\n                            return \"<span class=\\\"label label-danger\\\">未同步</sp" +
"an>\";\r\n                        } else if (cellvalue == 1) {\r\n                   " +
"         return \"<span class=\\\"label label-success\\\">已关注</span>\";\r\n             " +
"           } else if (cellvalue == 2) {\r\n                            return \"<sp" +
"an class=\\\"label label-default\\\">已禁用</span>\";\r\n                        } else if" +
" (cellvalue == 4) {\r\n                            return \"<span class=\\\"label lab" +
"el-info\\\">未关注</span>\";\r\n                        } else {\r\n                      " +
"      return cellvalue;\r\n                        }\r\n                    }\r\n     " +
"           },\r\n                { label: \"同步日志\", name: \"F_SyncLog\", width: 200, a" +
"lign: \"left\", sortable: false }\r\n            ],\r\n            pager: false,\r\n    " +
"        rowNum: \"1000\",\r\n            rownumbers: true,\r\n            shrinkToFit:" +
" false,\r\n            gridview: true,\r\n            onSelectRow: function () {\r\n  " +
"              selectedRowIndex = $(\"#\" + this.id).getGridParam(\'selrow\');\r\n     " +
"       },\r\n            gridComplete: function () {\r\n                $(\"#\" + this" +
".id).setSelection(selectedRowIndex, false);\r\n            }\r\n        });\r\n       " +
" //查询条件\r\n        $(\"#queryCondition .dropdown-menu li\").click(function () {\r\n   " +
"         var text = $(this).find(\'a\').html();\r\n            var value = $(this).f" +
"ind(\'a\').attr(\'data-value\');\r\n            $(\"#queryCondition .dropdown-text\").ht" +
"ml(text).attr(\'data-value\', value)\r\n        });\r\n        //查询事件\r\n        $(\"#btn" +
"_Search\").click(function () {\r\n            var queryJson = {\r\n                co" +
"ndition: $(\"#queryCondition\").find(\'.dropdown-text\').attr(\'data-value\'),\r\n      " +
"          keyword: $(\"#txt_Keyword\").val()\r\n            }\r\n            $gridTabl" +
"e.jqGrid(\'setGridParam\', {\r\n                postData: { queryJson: JSON.stringif" +
"y(queryJson) }\r\n            }).trigger(\'reloadGrid\');\r\n        });\r\n        //查询" +
"回车\r\n        $(\'#txt_Keyword\').bind(\'keypress\', function (event) {\r\n            i" +
"f (event.keyCode == \"13\") {\r\n                $(\'#btn_Search\').trigger(\"click\");\r" +
"\n            }\r\n        });\r\n    }\r\n    //添加成员\r\n    function btn_member() {\r\n   " +
"     learun.dialogOpen({\r\n            id: \"Member\",\r\n            title: \'添加成员\',\r" +
"\n            url: \'/WeChatManage/User/MemberForm\',\r\n            width: \"840px\",\r" +
"\n            height: \"520px\",\r\n            callBack: function (iframeId) {\r\n    " +
"            getInfoTop().frames[iframeId].AcceptClick();\r\n            }\r\n       " +
" });\r\n    }\r\n    //删除\r\n    function btn_delete() {\r\n        var keyValue = $(\"#g" +
"ridTable\").jqGridRowValue(\"F_UserId\");\r\n        if (keyValue) {\r\n            lea" +
"run.removeForm({\r\n                url: \"../../WeChatManage/User/DeleteMember\",\r\n" +
"                param: { keyValue: keyValue },\r\n                success: functio" +
"n (data) {\r\n                    $(\"#gridTable\").trigger(\"reloadGrid\");\r\n        " +
"        }\r\n            })\r\n        } else {\r\n            learun.dialogMsg({ msg:" +
" \'请选择需要移除的成员！\', type: 0 });\r\n        }\r\n    }\r\n    //一键同步\r\n    function btn_sync" +
"hronization() {\r\n        var userIds = [];\r\n        var getRowData = $(\"#gridTab" +
"le\").jqGrid(\"getRowData\");\r\n        if (getRowData.length == 0) {\r\n            r" +
"eturn false;\r\n        }\r\n        for (var i = 0; i < getRowData.length; i++) {\r\n" +
"            userIds.push(getRowData[i].F_Id);\r\n        }\r\n        learun.confirm" +
"Ajax({\r\n            msg: \"注：您确定要一键同步成员到微信企业号里面吗？\",\r\n            url: \"../../WeCh" +
"atManage/User/Synchronization\",\r\n            param: { userIds: String(userIds) }" +
",\r\n            success: function (data) {\r\n                $(\"#gridTable\").trigg" +
"er(\"reloadGrid\");\r\n            }\r\n        })\r\n    }\r\n\r\n\r\n</script>\r\n<div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n        <table>\r\n            <tr>\r\n                <td>\r\n                    <" +
"div");

WriteLiteral(" id=\"queryCondition\"");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"btn btn-default dropdown-text\"");

WriteLiteral(">选择条件</a>\r\n                        <a");

WriteLiteral(" class=\"btn btn-default dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral("><span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span></a>\r\n                        <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n                            <li><a");

WriteLiteral(" data-value=\"Account\"");

WriteLiteral(">账户</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"RealName\"");

WriteLiteral(">姓名</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"Mobile\"");

WriteLiteral(">手机</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"Mobile\"");

WriteLiteral(">邮箱</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"Mobile\"");

WriteLiteral(">微信</a></li>\r\n                        </ul>\r\n                    </div>\r\n        " +
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

WriteLiteral(" id=\"lr-member\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_member()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>&nbsp;添加成员</a>\r\n            <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_delete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>&nbsp;移除成员</a>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"lr-synchronization\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_synchronization()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>&nbsp;一键同步</a>\r\n        </div>\r\n    </div>\r\n    <div");

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
