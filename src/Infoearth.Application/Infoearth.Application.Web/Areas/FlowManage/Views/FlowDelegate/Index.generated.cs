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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/FlowManage/Views/FlowDelegate/Index.cshtml")]
    public partial class _Areas_FlowManage_Views_FlowDelegate_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_FlowManage_Views_FlowDelegate_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\FlowManage\Views\FlowDelegate\Index.cshtml"
  
    ViewBag.Title = "工作委托";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    var type = \'rule\';\r\n    $(function () {\r\n        InitialPage();\r\n" +
"        GetGrid();\r\n    });\r\n    //初始化页面\r\n    function InitialPage() {\r\n        " +
"//resize重设(表格、树形)宽高\r\n        $(window).resize(function (e) {\r\n            window" +
".setTimeout(function () {\r\n                $(\'#RecordgridTable\').setGridWidth(e." +
"delegateTarget.innerWidth -22);\r\n                $(\"#RecordgridTable\").setGridHe" +
"ight($(window).height() - 139.5);\r\n\r\n                $(\'#RulegridTable\').setGrid" +
"Width(e.delegateTarget.innerWidth - 22);\r\n                $(\"#RulegridTable\").se" +
"tGridHeight($(window).height() - 139.5);\r\n            }, 200);\r\n            e.st" +
"opPropagation();\r\n        });\r\n    }\r\n    //加载表格\r\n    function GetGrid() {\r\n    " +
"    var selectedRowIndex = 0;\r\n        $(\"#RulegridTable\").jqGridEx({\r\n         " +
"   url: \"../../FlowManage/FlowDelegate/GetRulePageListJson\",\r\n            colMod" +
"el: [\r\n                { label: \'主键\', name: \'f_id\', hidden: true },\r\n           " +
"     { label: \'被委托人\', name: \'f_tousername\', index: \"f_tousername\", width: 100, a" +
"lign: \"left\" },\r\n                {\r\n                    label: \"开始时间\", name: \"f_" +
"begindate\", index: \"f_begindate\", width: 90, align: \"left\",\r\n                   " +
" formatter: function (cellvalue, options, rowObject) {\r\n                        " +
"return formatDate(cellvalue, \'yyyy-MM-dd\');\r\n                    }\r\n            " +
"    },\r\n                {\r\n                    label: \"结束时间\", name: \"f_enddate\"," +
" index: \"f_enddate\", width: 90, align: \"left\",\r\n                    formatter: f" +
"unction (cellvalue, options, rowObject) {\r\n                        return format" +
"Date(cellvalue, \'yyyy-MM-dd\');\r\n                    }\r\n                },\r\n     " +
"           { label: \'委托人\', name: \'f_createusername\', index: \'f_createusername\', " +
"width: 100, align: \'left\' },\r\n                {\r\n                    label: \"状态\"" +
", name: \"f_enabledmark\", index: \"f_enabledmark\", width: 60, align: \"center\",\r\n  " +
"                  formatter: function (cellvalue, options, rowObject) {\r\n       " +
"                 if (cellvalue == 1) {\r\n                            return \'<spa" +
"n  class=\\\"label label-success\\\">启用</span>\';\r\n                        } else if " +
"(rowObject.enabledmark == 0) {\r\n                            return \'<span  class" +
"=\\\"label label-danger\\\">停用</span>\';\r\n                        } else{\r\n          " +
"                  return \'\';\r\n                        }\r\n                    }\r\n" +
"                },\r\n                { label: \'工作模板数量\', name: \'f_shcemenum\', inde" +
"x: \"f_shcemenum\", width: 90, align: \"center\" },\r\n                {\r\n            " +
"        label: \"创建时间\", name: \"f_createdate\", index: \"f_createdate\", width: 150, " +
"align: \"left\",\r\n                    formatter: function (cellvalue, options, row" +
"Object) {\r\n                        return formatDate(cellvalue, \'yyyy-MM-dd hh:m" +
"m:ss\');\r\n                    }\r\n                },\r\n                { label: \"委托" +
"理由\", name: \"f_description\", index: \"f_description\", width: 200, align: \"left\" }\r" +
"\n            ]\r\n        });\r\n        $(\"#RecordgridTable\").jqGridEx({\r\n         " +
"   colModel: [\r\n                { label: \'主键\', name: \'f_id\', hidden: true },\r\n  " +
"              { label: \'实例主键\', name: \'f_processid\', hidden: true },\r\n           " +
"     { label: \'规则主键\', name: \'f_wfdelegateruleid\', hidden: true },\r\n             " +
"   { label: \'流程实例编号\', name: \'f_processcode\', index: \"f_processcode\", width: 100," +
" align: \"left\" },\r\n                { label: \'流程实例标题\', name: \'f_processname\', ind" +
"ex: \"f_processname\", width: 100, align: \"left\" },\r\n\r\n                { label: \'委" +
"托人\', name: \'f_fromusername\', index: \'f_fromusername\', width: 100, align: \'left\' " +
"},\r\n                { label: \'被委托人\', name: \'f_tousername\', index: \'f_tousername\'" +
", width: 100, align: \'left\' },\r\n                {\r\n                    label: \"创" +
"建时间\", name: \"f_createdate\", index: \"f_createdate\", width: 150, align: \"left\",\r\n " +
"                   formatter: function (cellvalue, options, rowObject) {\r\n      " +
"                  return formatDate(cellvalue, \'yyyy-MM-dd hh:mm:ss\');\r\n        " +
"            }\r\n                }\r\n            ],\r\n            pager: \"#recordgri" +
"dPager\",\r\n        });\r\n        //查询事件\r\n        $(\"#btn_Search\").click(function (" +
") {\r\n            var queryJson = { Keyword: $(\"#txt_Keyword\").val() };\r\n        " +
"    searchGrid(queryJson);\r\n        });\r\n        //切换\r\n        $(\'#queryConditio" +
"n .dropdown-menu a\').click(function () {\r\n            type = $(this).attr(\'data-" +
"value\');\r\n            var _name = $(this).html();\r\n            $(\'.dropdown-text" +
"\').html(_name);\r\n            $(\"#btn_Search\").trigger(\'click\');\r\n        });\r\n  " +
"  }\r\n    //查询函数\r\n    function searchGrid(queryJson)\r\n    {\r\n        var _url = \"" +
"\", _postData = { queryJson: JSON.stringify(queryJson) }, _$jqgrid;\r\n        $(\'#" +
"ruleTbale\').hide();\r\n        $(\'#recordTbale\').hide();\r\n        switch (type)\r\n " +
"       {\r\n            case \'rule\':\r\n                _url = \"../../FlowManage/Flo" +
"wDelegate/GetRulePageListJson\";\r\n                _$jqgrid = $(\"#RulegridTable\");" +
"\r\n                $(\'.btn-rule\').show();\r\n                $(\'#ruleTbale\').show()" +
";\r\n                break;\r\n            case \'fromRecord\':\r\n                _url " +
"= \"../../FlowManage/FlowDelegate/GetRecordPageListJson\";\r\n                _$jqgr" +
"id = $(\"#RecordgridTable\");\r\n                _postData[\'type\'] = 1;\r\n           " +
"     $(\'.btn-rule\').hide();\r\n                $(\'#recordTbale\').show();\r\n        " +
"        break;\r\n            case \'toRecord\':\r\n                _url = \"../../Flow" +
"Manage/FlowDelegate/GetRecordPageListJson\";\r\n                _$jqgrid = $(\"#Reco" +
"rdgridTable\");\r\n                _postData[\'type\'] = 2;\r\n                $(\'.btn-" +
"rule\').hide();\r\n                $(\'#recordTbale\').show();\r\n                break" +
";\r\n        }\r\n        $(\'#RecordgridTable\').setGridWidth($(window).width() - 22)" +
";\r\n        _$jqgrid.show();\r\n        _$jqgrid.jqGrid(\'setGridParam\', {\r\n        " +
"    url: _url,\r\n            postData: _postData,\r\n        }).trigger(\'reloadGrid" +
"\');\r\n    }\r\n    //新增\r\n    function btn_add() {\r\n        dialogOpen({\r\n          " +
"  id: \"form\",\r\n            title: \'新增委托\',\r\n            url: \'/FlowManage/FlowDel" +
"egate/Form\',\r\n            width: \"900px\",\r\n            height: \"520px\",\r\n       " +
"     callBack: function (iframeId) {\r\n                getInfoTop().frames[iframe" +
"Id].AcceptClick();\r\n            }\r\n        });\r\n    };\r\n    //编辑\r\n    function b" +
"tn_edit() {\r\n        var keyValue = $(\"#RulegridTable\").jqGridRowValue(\"f_id\");\r" +
"\n        if (checkedRow(keyValue)) {\r\n            dialogOpen({\r\n                " +
"id: \"form\",\r\n                title: \'修改委托\',\r\n                url: \'/FlowManage/F" +
"lowDelegate/Form?keyValue=\' + keyValue,\r\n                width: \"900px\",\r\n      " +
"          height: \"520px\",\r\n                callBack: function (iframeId) {\r\n   " +
"                 getInfoTop().frames[iframeId].AcceptClick();\r\n                }" +
"\r\n            });\r\n        }\r\n    }\r\n    //删除\r\n    function btn_delete() {\r\n    " +
"    var keyValue = $(\"#RulegridTable\").jqGridRowValue(\"f_id\");\r\n        if (keyV" +
"alue) {\r\n            $.RemoveForm({\r\n                url: \"../../FlowManage/Flow" +
"Delegate/DeleteRule\",\r\n                param: { keyValue: keyValue },\r\n         " +
"       success: function (data) {\r\n                    $(\"#RulegridTable\").trigg" +
"er(\"reloadGrid\");\r\n                }\r\n            })\r\n        } else {\r\n        " +
"    dialogMsg(\'请选择需要删除的表单模板！\', 0);\r\n        }\r\n    }\r\n    //禁用\r\n    function btn" +
"_disabled() {\r\n        var keyValue = $(\"#RulegridTable\").jqGridRowValue(\"f_id\")" +
";\r\n        if (keyValue) {\r\n            $.ConfirmAjax({\r\n                msg: \"请" +
"确认是否要【停用】委托规则？\",\r\n                url: \"../../FlowManage/FlowDelegate/UpdateRule" +
"Enable\",\r\n                param: { keyValue: keyValue, enableMark: 0 },\r\n       " +
"         success: function (data) {\r\n                    $(\"#gridTable\").trigger" +
"(\"reloadGrid\");\r\n                }\r\n            })\r\n        } else {\r\n          " +
"  dialogMsg(\'请选择要停用的委托规则！\', 0);\r\n        }\r\n    }\r\n    //启用\r\n    function btn_en" +
"abled() {\r\n        var keyValue = $(\"#RulegridTable\").jqGridRowValue(\"f_id\");\r\n " +
"       if (keyValue) {\r\n            $.ConfirmAjax({\r\n                msg: \"请确认是否" +
"要【启用】委托规则？\",\r\n                url: \"../../FlowManage/FlowDelegate/UpdateRuleEnab" +
"le\",\r\n                param: { keyValue: keyValue, enableMark: 1 },\r\n           " +
"     success: function (data) {\r\n                    $(\"#gridTable\").trigger(\"re" +
"loadGrid\");\r\n                }\r\n            })\r\n        } else {\r\n            di" +
"alogMsg(\'请选择要启用的委托规则！\', 0);\r\n        }\r\n    }\r\n</script>\r\n<div");

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

WriteLiteral(">我的委托规则</a>\r\n                        <a");

WriteLiteral(" class=\"btn btn-default dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral("><span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span></a>\r\n                        <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n                            <li><a");

WriteLiteral(" data-value=\"rule\"");

WriteLiteral(">我的委托规则</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"fromRecord\"");

WriteLiteral(">我的委托记录</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"toRecord\"");

WriteLiteral(">被委托记录</a></li>\r\n                        </ul>\r\n                    </div>\r\n     " +
"           </td>\r\n                <td");

WriteLiteral(" style=\"padding-left: 5px;\"");

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

WriteLiteral(" class=\"btn btn-default btn-rule\"");

WriteLiteral(" onclick=\"btn_add()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>&nbsp;新增</a>\r\n            <a");

WriteLiteral(" id=\"lr-edit\"");

WriteLiteral(" class=\"btn btn-default btn-rule\"");

WriteLiteral(" onclick=\"btn_edit()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pencil-square-o\"");

WriteLiteral("></i>&nbsp;编辑</a>\r\n            <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" class=\"btn btn-default btn-rule\"");

WriteLiteral(" onclick=\"btn_delete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>&nbsp;删除</a>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"btn-group btn-rule\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"lr-disabled\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_disabled()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-stop\"");

WriteLiteral("></i>&nbsp;停用</a>\r\n            <a");

WriteLiteral(" id=\"lr-enabled\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_enabled()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-play\"");

WriteLiteral("></i>&nbsp;启用</a>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"ruleTbale\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" id=\"RulegridTable\"");

WriteLiteral("></table>\r\n        <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"recordTbale\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" id=\"RecordgridTable\"");

WriteLiteral("></table>\r\n        <div");

WriteLiteral(" id=\"recordgridPager\"");

WriteLiteral("></div>\r\n    </div>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591