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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/SystemManage/Views/DataBaseBackup/Index.cshtml")]
    public partial class _Areas_SystemManage_Views_DataBaseBackup_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_SystemManage_Views_DataBaseBackup_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\SystemManage\Views\DataBaseBackup\Index.cshtml"
  
    ViewBag.Title = "数据库备份";
    Layout = "~/Views/Shared/_LayoutIndex.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        InitialPage();\r\n        GetTree();\r\n    " +
"    GetGrid();\r\n    });\r\n    //初始化页面\r\n    function InitialPage() {\r\n        //la" +
"yout布局\r\n        $(\'#layout\').layout({\r\n            applyDemoStyles: true,\r\n     " +
"       onresize: function () {\r\n                $(window).resize()\r\n            " +
"}\r\n        });\r\n        //resize重设(表格、树形)宽高\r\n        $(window).resize(function (" +
"e) {\r\n            window.setTimeout(function () {\r\n                $(\'#gridTable" +
"\').setGridWidth(($(\'.gridPanel\').width()));\r\n                $(\"#gridTable\").set" +
"GridHeight($(window).height() - 141);\r\n                $(\"#itemTree\").setTreeHei" +
"ght($(window).height() - 52);\r\n            }, 200);\r\n            e.stopPropagati" +
"on();\r\n        });\r\n    }\r\n    //加载树\r\n    var _DataBaseLinkId = \"\";\r\n    functio" +
"n GetTree() {\r\n        var item = {\r\n            height: $(window).height() - 52" +
",\r\n            url: \"../../SystemManage/DataBaseLink/GetTreeJson\",\r\n            " +
"onnodeclick: function (item) {\r\n                if (item.parentnodes) {\r\n       " +
"             _DataBaseLinkId = item.id;\r\n                    $(\"#titleinfo\").htm" +
"l(\"[\" + item.text + \"]&nbsp;[\" + item.parentnodes + \"]&nbsp;[\" + item.title + \"]" +
"\");\r\n                    $(\"#txt_Keyword\").val(\"\");\r\n                    $(\'#btn" +
"_Search\').trigger(\"click\");\r\n                }\r\n            }\r\n        };\r\n     " +
"   //初始化\r\n        $(\"#itemTree\").treeview(item);\r\n    }\r\n    //加载表格\r\n    functio" +
"n GetGrid() {\r\n        var selectedRowIndex = 0;\r\n        var $gridTable = $(\"#g" +
"ridTable\");\r\n        $gridTable.jqGrid({\r\n            datatype: \"json\",\r\n       " +
"     height: $(window).height() - 141,\r\n            autowidth: true,\r\n          " +
"  colModel: [\r\n                { label: \'主键\', name: \'F_DatabaseBackupId\', hidden" +
": true },\r\n                { label: \'计划编号\', name: \'F_EnCode\', index: \'F_EnCode\'," +
" width: 100, align: \'left\' },\r\n                { label: \'计划名称\', name: \'F_FullNam" +
"e\', index: \'F_FullName\', width: 200, align: \'left\' },\r\n                {\r\n      " +
"              label: \'执行方式\', name: \'F_ExecuteMode\', index: \'F_ExecuteMode\', widt" +
"h: 100, align: \'center\',\r\n                    formatter: function (cellvalue, op" +
"tions, rowObject) {\r\n                        switch (cellvalue) {\r\n             " +
"               case 0:\r\n                                return \"每天\";\r\n          " +
"                  case 1:\r\n                                return \"每周一\";\r\n      " +
"                      case 2:\r\n                                return \"每周二\";\r\n  " +
"                          case 3:\r\n                                return \"每周三\";" +
"\r\n                            case 4:\r\n                                return \"每" +
"周四\";\r\n                            case 5:\r\n                                retur" +
"n \"每周五\";\r\n                            case 6:\r\n                                r" +
"eturn \"每周六\";\r\n                            case 7:\r\n                             " +
"   return \"每周日\";\r\n                            default:\r\n                        " +
"        return \"\";\r\n                        }\r\n                    }\r\n          " +
"      },\r\n                { label: \'执行时间\', name: \'F_ExecuteTime\', index: \'F_Exec" +
"uteTime\', width: 100, align: \'center\' },\r\n                { label: \'备份路径\', name:" +
" \'F_BackupPath\', index: \'F_BackupPath\', width: 300, align: \'left\' },\r\n          " +
"      {\r\n                    label: \"执行状态\", name: \"F_EnabledMark\", index: \"F_Ena" +
"bledMark\", width: 80, align: \"center\",\r\n                    formatter: function " +
"(cellvalue, options, rowObject) {\r\n                        if (cellvalue == 1) {" +
"\r\n                            return \'<span value=\' + cellvalue + \' class=\\\"labe" +
"l label-success\\\">启用</span>\';\r\n                        } else if (cellvalue == 0" +
") {\r\n                            return \'<span value=\' + cellvalue + \' class=\\\"l" +
"abel label-danger\\\">停用</span>\';\r\n                        } else {\r\n             " +
"               return \'未启用\';\r\n                        }\r\n                    }\r\n" +
"                },\r\n                { label: \"描述\", name: \"F_Description\", index:" +
" \"F_Description\", width: 200, align: \"left\" }\r\n            ],\r\n            onSel" +
"ectRow: function () {\r\n                selectedRowIndex = $(\"#\" + this.id).getGr" +
"idParam(\'selrow\');\r\n            },\r\n            gridComplete: function () {\r\n   " +
"             $(\"#\" + this.id).setSelection(selectedRowIndex, false);\r\n          " +
"  },\r\n            rowNum: \"1000\",\r\n            rownumbers: true,\r\n            sh" +
"rinkToFit: false,\r\n            gridview: true,\r\n            subGrid: true,\r\n    " +
"        subGridRowExpanded: function (subgrid_id, row_id) {\r\n                var" +
" databaseBackupId = $gridTable.jqGrid(\'getRowData\', row_id)[\'F_DatabaseBackupId\'" +
"];\r\n                var subgrid_table_id = subgrid_id + \"_t\";\r\n                $" +
"(\"#\" + subgrid_id).html(\"<table id=\'\" + subgrid_table_id + \"\'></table>\");\r\n     " +
"           $(\"#\" + subgrid_table_id).jqGrid({\r\n                    url: \"../../S" +
"ystemManage/DataBaseBackup/GetPathListJson\",\r\n                    postData: { da" +
"tabaseBackupId: databaseBackupId },\r\n                    datatype: \"json\",\r\n    " +
"                height: 260,\r\n                    colModel: [\r\n                 " +
"       { label: \'主键\', name: \'F_DatabaseBackupId\', hidden: true },\r\n             " +
"           { label: \'创建时间\', name: \'F_ExecuteTime\', index: \'F_ExecuteTime\', width" +
": 150, align: \'left\' },\r\n                        { label: \'文件大小\', name: \'F_FullN" +
"ame\', index: \'F_FullName\', width: 100, align: \'left\' },\r\n                       " +
" { label: \'文件路径\', name: \'F_FullName\', index: \'F_FullName\', width: 500, align: \'l" +
"eft\' }\r\n                    ],\r\n                    caption: \"备份文件信息列表\",\r\n      " +
"              rowNum: \"1000\",\r\n                    rownumbers: true,\r\n          " +
"          shrinkToFit: false,\r\n                    gridview: true,\r\n            " +
"        hidegrid: false\r\n                });\r\n            }\r\n        });\r\n      " +
"  //查询条件\r\n        $(\"#queryCondition .dropdown-menu li\").click(function () {\r\n  " +
"          var text = $(this).find(\'a\').html();\r\n            var value = $(this)." +
"find(\'a\').attr(\'data-value\');\r\n            $(\"#queryCondition .dropdown-text\").h" +
"tml(text).attr(\'data-value\', value)\r\n        });\r\n        //查询事件\r\n        $(\"#bt" +
"n_Search\").click(function () {\r\n            var queryJson = {\r\n                c" +
"ondition: $(\"#queryCondition\").find(\'.dropdown-text\').attr(\'data-value\'),\r\n     " +
"           keyword: $(\"#txt_Keyword\").val()\r\n            }\r\n            $gridTab" +
"le.jqGrid(\'setGridParam\', {\r\n                url: \"../../SystemManage/DataBaseBa" +
"ckup/GetListJson\",\r\n                postData: { dataBaseLinkId: _DataBaseLinkId," +
" queryJson: JSON.stringify(queryJson) },\r\n                page: 1\r\n            }" +
").trigger(\'reloadGrid\');\r\n        });\r\n        //查询回车\r\n        $(\'#txt_Keyword\')" +
".bind(\'keypress\', function (event) {\r\n            if (event.keyCode == \"13\") {\r\n" +
"                $(\'#btn_Search\').trigger(\"click\");\r\n            }\r\n        });\r\n" +
"        ////查询事件\r\n        //$(\"#btn_Search\").click(function () {\r\n        //    " +
"$gridTable.resetSelection();\r\n        //    selectedRowIndex = 0;\r\n        //   " +
" $gridTable.jqGrid(\'setGridParam\', {\r\n        //        url: \"../../SystemManage" +
"/DataBaseBackup/GetListJson\",\r\n        //        postData: { dataBaseLinkId: _Da" +
"taBaseLinkId, keyword: $(\"#txt_Keyword\").val() },\r\n        //    }).trigger(\'rel" +
"oadGrid\');\r\n        //});\r\n    }\r\n    //新增\r\n    function btn_add() {\r\n        if" +
" (_DataBaseLinkId) {\r\n            learun.dialogOpen({\r\n                id: \"Form" +
"\",\r\n                title: \'添加计划\',\r\n                url: \'/SystemManage/DataBase" +
"Backup/Form?dataBaseLinkId=\' + _DataBaseLinkId,\r\n                width: \"500px\"," +
"\r\n                height: \"450px\",\r\n                callBack: function (iframeId" +
") {\r\n                    getInfoTop().frames[iframeId].AcceptClick();\r\n         " +
"       }\r\n            });\r\n        } else {\r\n            learun.dialogMsg({ msg:" +
" \'请选择左边数据库！\', type: 0 });\r\n        }\r\n    };\r\n    //编辑\r\n    function btn_edit() " +
"{\r\n        var keyValue = $(\"#gridTable\").jqGridRowValue(\"F_DatabaseBackupId\");\r" +
"\n        if (learun.checkedRow(keyValue)) {\r\n            learun.dialogOpen({\r\n  " +
"              id: \"Form\",\r\n                title: \'编辑计划\',\r\n                url: " +
"\'/SystemManage/DataBaseBackup/Form?keyValue=\' + keyValue,\r\n                width" +
": \"500px\",\r\n                height: \"470px\",\r\n                callBack: function" +
" (iframeId) {\r\n                    getInfoTop().frames[iframeId].AcceptClick();\r" +
"\n                }\r\n            });\r\n        }\r\n    }\r\n    //删除\r\n    function bt" +
"n_delete() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowValue(\"F_DatabaseB" +
"ackupId\");\r\n        if (keyValue) {\r\n            learun.removeForm({\r\n          " +
"      url: \"../../SystemManage/DataBaseBackup/RemoveForm\",\r\n                para" +
"m: { keyValue: keyValue },\r\n                success: function (data) {\r\n        " +
"            $(\"#gridTable\").trigger(\"reloadGrid\");\r\n                }\r\n         " +
"   })\r\n        } else {\r\n            learun.dialogMsg({ msg: \'请选择需要删除的计划！\', type" +
": 0 });\r\n        }\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">数据库目录</div>\r\n            <div");

WriteLiteral(" id=\"itemTree\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">\r\n                数据库备份和还原 - <span");

WriteLiteral(" id=\"titleinfo\"");

WriteLiteral(">未选择数据库</span>\r\n            </div>\r\n            <div");

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

WriteLiteral(">计划编号</a></li>\r\n                                        <li><a");

WriteLiteral(" data-value=\"FullName\"");

WriteLiteral(">计划名称</a></li>\r\n                                    </ul>\r\n                      " +
"          </div>\r\n                            </td>\r\n                           " +
" <td");

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

WriteLiteral("></i>&nbsp;删除</a>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" id=\"lr-disabled\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_disabled()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-stop\"");

WriteLiteral("></i>&nbsp;停用</a>\r\n                        <a");

WriteLiteral(" id=\"lr-enabled\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_enabled()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-play\"");

WriteLiteral("></i>&nbsp;启用</a>\r\n                    </div>\r\n                </div>\r\n          " +
"      <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n                <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591