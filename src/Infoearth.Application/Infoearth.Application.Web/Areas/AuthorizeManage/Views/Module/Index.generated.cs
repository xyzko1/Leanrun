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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/AuthorizeManage/Views/Module/Index.cshtml")]
    public partial class _Areas_AuthorizeManage_Views_Module_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_AuthorizeManage_Views_Module_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\AuthorizeManage\Views\Module\Index.cshtml"
  
    ViewBag.Title = "系统功能";
    Layout = "~/Views/Shared/_LayoutIndex.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">功能目录</div>\r\n            <div");

WriteLiteral(" id=\"itemTree\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">功能信息</div>\r\n            <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n                    <table>\r\n                        <tr>\r\n                   " +
"         <td>\r\n                                <div");

WriteLiteral(" id=\"queryCondition\"");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" class=\"btn btn-default dropdown-text\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">选择条件</a>\r\n                                    <a");

WriteLiteral(" class=\"btn btn-default dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral("><span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span></a>\r\n                                    <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n                                        <li><a");

WriteLiteral(" data-value=\"EnCode\"");

WriteLiteral(">编号</a></li>\r\n                                        <li><a");

WriteLiteral(" data-value=\"FullName\"");

WriteLiteral(">名称</a></li>\r\n                                        <li><a");

WriteLiteral(" data-value=\"UrlAddress\"");

WriteLiteral(">地址</a></li>\r\n                                    </ul>\r\n                        " +
"        </div>\r\n                            </td>\r\n                            <" +
"td");

WriteLiteral(" style=\"padding-left: 2px;\"");

WriteLiteral(">\r\n                                <input");

WriteLiteral(" id=\"txt_Keyword\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入要查询关键字\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(" />\r\n                            </td>\r\n                            <td");

WriteLiteral(" style=\"padding-left: 5px;\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>&nbsp;查询</a>\r\n                            </td>\r\n                        </t" +
"r>\r\n                    </table>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"learun.reload();\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>&nbsp;刷新</a>\r\n                        <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_add()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>&nbsp;新增</a>\r\n                        <a");

WriteLiteral(" id=\"lr-edit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_edit()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pencil-square-o\"");

WriteLiteral("></i>&nbsp;编辑</a>\r\n                        <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_delete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>&nbsp;删除</a>\r\n                    </div>\r\n                    \r\n            " +
"    </div>\r\n                <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        InitialPage();\r\n        GetTree();\r\n    " +
"    GetGrid();\r\n    });\r\n    //初始化页面\r\n    function InitialPage() {\r\n        //la" +
"yout布局\r\n        $(\'#layout\').layout({\r\n            applyDemoStyles: true,\r\n     " +
"       onresize: function () {\r\n                $(window).resize()\r\n            " +
"}\r\n        });\r\n        //resize重设(表格、树形)宽高\r\n        $(window).resize(function (" +
"e) {\r\n            window.setTimeout(function () {\r\n                $(\'#gridTable" +
"\').setGridWidth(($(\'.gridPanel\').width()));\r\n                $(\"#gridTable\").set" +
"GridHeight($(window).height() - 141.5);\r\n                $(\"#itemTree\").setTreeH" +
"eight($(window).height() - 52);\r\n            }, 200);\r\n            e.stopPropaga" +
"tion();\r\n        });\r\n    }\r\n    //初始化控件\r\n    function initControl() {\r\n        " +
"//获取表单\r\n        if (!!keyValue) {\r\n            $.SetForm({\r\n                url:" +
" \"../../BaseManage/BASE_AREA/GetFormJson\",\r\n                param: { keyValue: k" +
"eyValue },\r\n                success: function (data) {\r\n                    $(\"#" +
"form1\").SetWebControls(data);\r\n                }\r\n            })\r\n        } \r\n  " +
"  }\r\n    \r\n    //加载树\r\n    var _parentId = \"\";\r\n    function GetTree() {\r\n       " +
" var item = {\r\n            height: $(window).height() - 52,\r\n            url: \"." +
"./../AuthorizeManage/Module/GetTreeJsonExt\",\r\n            onnodeclick: function " +
"(item) {\r\n                _parentId = item.id;\r\n                $(\'#btn_Search\')" +
".trigger(\"click\");\r\n            },\r\n            isAllExpand:false\r\n        };\r\n " +
"       //初始化\r\n        $(\"#itemTree\").treeview(item);\r\n    }\r\n    //加载表格\r\n    fun" +
"ction GetGrid() {\r\n        var selectedRowIndex = 0;\r\n        var $gridTable = $" +
"(\'#gridTable\');\r\n        $gridTable.jqGrid({\r\n            url: \"../../AuthorizeM" +
"anage/Module/GetListJson?parentid=0\",\r\n            datatype: \"json\",\r\n          " +
"  height: $(window).height() - 141.5,\r\n            autowidth: true,\r\n           " +
" colModel: [\r\n                { label: \"主键\", name: \"F_ModuleId\", index: \"F_Modul" +
"eId\", hidden: true },\r\n                { label: \"编号\", name: \"F_EnCode\", index: \"" +
"F_EnCode\", width: 150, align: \"left\" },\r\n                { label: \"名称\", name: \"F" +
"_FullName\", index: \"F_FullName\", width: 150, align: \"left\" },\r\n                {" +
" label: \"地址\", name: \"F_UrlAddress\", index: \"F_UrlAddress\", width: 350, align: \"l" +
"eft\" },\r\n                { label: \"目标\", name: \"F_Target\", index: \"F_Target\", wid" +
"th: 60, align: \"center\" },\r\n                {\r\n                    label: \"菜单\", " +
"name: \"F_IsMenu\", index: \"F_IsMenu\", width: 50, align: \"center\",\r\n              " +
"      formatter: function (cellvalue, options, rowObject) {\r\n                   " +
"     return cellvalue == 1 ? \"<i value=\" + cellvalue + \" class=\\\"fa fa-toggle-on" +
"\\\"></i>\" : \"<i value=\" + cellvalue + \" class=\\\"fa fa-toggle-off\\\"></i>\";\r\n      " +
"              }\r\n                },\r\n                {\r\n                    labe" +
"l: \"展开\", name: \"F_AllowExpand\", index: \"F_AllowExpand\", width: 50, align: \"cente" +
"r\",\r\n                    formatter: function (cellvalue, options, rowObject) {\r\n" +
"                        return cellvalue == 1 ? \"<i class=\\\"fa fa-toggle-on\\\"></" +
"i>\" : \"<i class=\\\"fa fa-toggle-off\\\"></i>\";\r\n                    }\r\n            " +
"    },\r\n                {\r\n                    label: \"公共\", name: \"F_IsPublic\", " +
"index: \"F_IsPublic\", width: 50, align: \"center\",\r\n                    formatter:" +
" function (cellvalue, options, rowObject) {\r\n                        return cell" +
"value == 1 ? \"<i class=\\\"fa fa-toggle-on\\\"></i>\" : \"<i class=\\\"fa fa-toggle-off\\" +
"\"></i>\";\r\n                    }\r\n                },\r\n                {\r\n        " +
"            label: \"有效\", name: \"F_EnabledMark\", index: \"F_EnabledMark\", width: 5" +
"0, align: \"center\",\r\n                    formatter: function (cellvalue, options" +
", rowObject) {\r\n                        return cellvalue == 1 ? \"<i class=\\\"fa f" +
"a-toggle-on\\\"></i>\" : \"<i class=\\\"fa fa-toggle-off\\\"></i>\";\r\n                   " +
" }\r\n                },\r\n                {\r\n                    label: \"菜单位置\", na" +
"me: \"F_ModuleLoc\", index: \"F_ModuleLoc\", width: 80, align: \"center\",\r\n          " +
"          formatter: function (cellvalue, options, rowObject) {\r\n               " +
"         var str = \"\";\r\n                        if (cellvalue == 1) {\r\n         " +
"                   str = \"左侧\";\r\n                        } else if (cellvalue == " +
"0) {\r\n                            str = \"顶部\";\r\n                        }\r\n      " +
"                 \r\n                        return str;\r\n                    }\r\n " +
"               },\r\n                { label: \"描述\", name: \"F_Description\", index: " +
"\"F_Description\", width: 100, align: \"left\" }\r\n            ],\r\n            pager:" +
" false,\r\n            rowNum: \"1000\",\r\n            rownumbers: true,\r\n           " +
" shrinkToFit: false,\r\n            gridview: true,\r\n            onSelectRow: func" +
"tion () {\r\n                selectedRowIndex = $(\"#\" + this.id).getGridParam(\'sel" +
"row\');\r\n            },\r\n            gridComplete: function () {\r\n               " +
" $(\"#\" + this.id).setSelection(selectedRowIndex, false);\r\n            }\r\n       " +
" });\r\n        //查询条件\r\n        $(\"#queryCondition .dropdown-menu li\").click(funct" +
"ion () {\r\n            var text = $(this).find(\'a\').html();\r\n            var valu" +
"e = $(this).find(\'a\').attr(\'data-value\');\r\n            $(\"#queryCondition .dropd" +
"own-text\").html(text).attr(\'data-value\', value)\r\n        });\r\n        //查询事件\r\n  " +
"      $(\"#btn_Search\").click(function () {\r\n            $gridTable.jqGrid(\'setGr" +
"idParam\', {\r\n                url: \"../../AuthorizeManage/Module/GetListJson\",\r\n " +
"               postData: {\r\n                    parentid: _parentId,\r\n          " +
"          condition: $(\"#queryCondition\").find(\'.dropdown-text\').attr(\'data-valu" +
"e\'),\r\n                    keyword: $(\"#txt_Keyword\").val()\r\n                }\r\n " +
"           }).trigger(\'reloadGrid\');\r\n        });\r\n        //查询回车\r\n        $(\'#t" +
"xt_Keyword\').bind(\'keypress\', function (event) {\r\n            if (event.keyCode " +
"== \"13\") {\r\n                $(\'#btn_Search\').trigger(\"click\");\r\n            }\r\n " +
"       });\r\n    }\r\n    //新增\r\n    function btn_add() {\r\n        learun.dialogOpen" +
"({\r\n            id: \"Form\",\r\n            title: \'添加功能\',\r\n            url: \'/Auth" +
"orizeManage/Module/Form?parentId=\' + _parentId,\r\n            width: \"700px\",\r\n  " +
"          height: \"470px\",\r\n            btn: null\r\n        });\r\n    };\r\n    //编辑" +
"\r\n    function btn_edit() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowVal" +
"ue(\"F_ModuleId\");\r\n        if (learun.checkedRow(keyValue)) {\r\n            learu" +
"n.dialogOpen({\r\n                id: \"Form\",\r\n                title: \'编辑功能\',\r\n   " +
"             url: \'/AuthorizeManage/Module/Form?keyValue=\' + keyValue,\r\n        " +
"        width: \"700px\",\r\n                height: \"470px\",\r\n                btn: " +
"null\r\n            });\r\n        }\r\n    }\r\n    //删除\r\n    function btn_delete() {\r\n" +
"        var keyValue = $(\"#gridTable\").jqGridRowValue(\"F_ModuleId\");\r\n        if" +
" (keyValue) {\r\n            learun.removeForm({\r\n                url: \"../../Auth" +
"orizeManage/Module/RemoveForm\",\r\n                param: { keyValue: keyValue },\r" +
"\n                success: function (data) {\r\n                    $(\"#gridTable\")" +
".trigger(\"reloadGrid\");\r\n                }\r\n            })\r\n        } else {\r\n  " +
"          learun.dialogMsg({ msg: \'请选择需要删除的数据项！\', type: 0 });\r\n        }\r\n    }\r" +
"\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591