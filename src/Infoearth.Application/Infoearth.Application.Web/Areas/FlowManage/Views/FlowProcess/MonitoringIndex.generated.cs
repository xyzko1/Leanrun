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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/FlowManage/Views/FlowProcess/MonitoringIndex.cshtml")]
    public partial class _Areas_FlowManage_Views_FlowProcess_MonitoringIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_FlowManage_Views_FlowProcess_MonitoringIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\FlowManage\Views\FlowProcess\MonitoringIndex.cshtml"
  
    ViewBag.Title = "流程监控";
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
"GridHeight($(window).height() - 169.5);\r\n                $(\"#itemTree\").setTreeH" +
"eight($(window).height() - 52);\r\n            }, 200);\r\n            e.stopPropaga" +
"tion();\r\n        });\r\n    }\r\n    //加载树\r\n    function GetTree() {\r\n        var it" +
"em = {\r\n            height: $(window).height() - 52,\r\n            param: { EnCod" +
"e: \"FlowSort\" },\r\n            url: \"../../FlowManage/FlowDesign/GetTreeJson\",\r\n " +
"           onnodeclick: function (item) {\r\n                if (item.Sort != \"Sch" +
"emeType\")\r\n                {\r\n                    var queryJson = { WFSchemeInfo" +
"Id: item.id };\r\n                    searchGrid(queryJson);\r\n                }\r\n " +
"           }\r\n        };\r\n        //初始化\r\n        $(\"#itemTree\").treeview(item);\r" +
"\n    }\r\n    //加载表格流程是否完成(0运行中,1运行结束,2被召回,3不同意,4表示被驳回)\r\n    function GetGrid() {\r" +
"\n        var selectedRowIndex = 0;\r\n        $(\"#gridTable\").jqGrid({\r\n          " +
"  url: \"../../FlowManage/FlowProcess/GetProcessPageListJson\",\r\n            datat" +
"ype: \"json\",\r\n            height: $(window).height() - 169.5,\r\n            autow" +
"idth: true,\r\n            colModel: [\r\n                { label: \'主键\', name: \'f_id" +
"\', hidden: true },\r\n                { label: \'节点id\', name: \'f_activityid\', hidde" +
"n: true },\r\n                { label: \'实例模板id\', name: \'f_processschemeid\', hidden" +
": true },\r\n                { label: \'实例编号\', name: \'f_code\', index: \'f_code\', wid" +
"th: 100, align: \'left\' },\r\n                { label: \'实例名称\', name: \'f_name\', inde" +
"x: \'f_customname\', width: 150, align: \'left\' },\r\n                { label: \'分类\', " +
"name: \'f_schemetypename\', index: \'f_schemetypename\', width: 80, align: \'left\' }," +
"\r\n                {\r\n                    label: \"等级\", name: \"f_wflevel\", index: " +
"\"f_wflevel\", width: 50, align: \"center\",\r\n                    formatter: functio" +
"n (cellvalue, options, rowObject) {\r\n                        if (cellvalue == 1)" +
" {\r\n                            return \'<span  class=\\\"label label-danger\\\">重要</" +
"span>\';\r\n                        } else if (cellvalue == 2) {\r\n                 " +
"           return \'<span  class=\\\"label label-primary\\\">普通</span>\';\r\n           " +
"             } else {\r\n                            return \'<span  class=\\\"label " +
"label-success\\\">一般</span>\';\r\n                        }\r\n                    }\r\n " +
"               },\r\n                { label: \"当前节点\", name: \"f_activityname\", inde" +
"x: \"f_activityname\", width: 90, align: \"left\", hidden: true },\r\n                " +
"{\r\n                    label: \"状态\", name: \"f_isfinish\", index: \"f_isfinish\", wid" +
"th: 80, align: \"center\",hidden: true,\r\n                    formatter: function (" +
"cellvalue, options, rowObject) {\r\n                        if (rowObject.f_enable" +
"dmark == 1) {\r\n                            if (cellvalue == 0) {\r\n              " +
"                  return \'<span  class=\\\"label label-success\\\">运行中</span>\';\r\n   " +
"                         }\r\n                            else if (cellvalue == 1)" +
" {\r\n                                return \'<span  class=\\\"label label-info\\\">运行" +
"结束</span>\';\r\n                            }\r\n                            else if " +
"(cellvalue == 2) {\r\n                                return \'<span  class=\\\"label" +
" label-important-learun\\\">取消</span>\';\r\n                            }\r\n          " +
"                  else if (cellvalue == 3) {\r\n                                re" +
"turn \'<span  class=\\\"label label-danger\\\">不同意</span>\';\r\n                        " +
"    }\r\n                            else if (cellvalue == 4) {\r\n                 " +
"               return \'<span  class=\\\"label label-warning \\\">被驳回</span>\';\r\n     " +
"                       }\r\n                        }\r\n                        els" +
"e {\r\n                            return \'<span  class=\\\"label label-inverse-lear" +
"un \\\">暂停</span>\';\r\n                        }\r\n\r\n                        \r\n      " +
"              }\r\n                },\r\n                { label: \"创建用户\", name: \"f_c" +
"reateusername\", index: \"f_createusername\", width: 80, align: \"left\" },\r\n        " +
"        {\r\n                    label: \"创建时间\", name: \"f_createdate\", index: \"f_cr" +
"eatedate\", width: 150, align: \"left\",\r\n                    formatter: function (" +
"cellvalue, options, rowObject) {\r\n                        return formatDate(cell" +
"value, \'yyyy-MM-dd hh:mm:ss\');\r\n                    }\r\n                },\r\n     " +
"           { label: \"备注\", name: \"f_description\", index: \"f_description\", width: " +
"200, align: \"left\" }\r\n            ],\r\n            viewrecords: true,\r\n          " +
"  rowNum: 30,\r\n            rowList: [30, 50, 100],\r\n            pager: \"#gridPag" +
"er\",\r\n            sortname: \'F_CreateDate desc\',\r\n            rownumbers: true,\r" +
"\n            shrinkToFit: false,\r\n            gridview: true,\r\n            onSel" +
"ectRow: function () {\r\n                selectedRowIndex = $(\"#\" + this.id).getGr" +
"idParam(\'selrow\');\r\n            },\r\n            gridComplete: function () {\r\n   " +
"             $(\"#\" + this.id).setSelection(selectedRowIndex, false);\r\n          " +
"  }\r\n        });\r\n        //查询事件\r\n        $(\"#btn_Search\").click(function () {\r\n" +
"            var queryJson = { Keyword: $(\"#txt_Keyword\").val() };\r\n            s" +
"earchGrid(queryJson);\r\n        });\r\n    }\r\n    //查询函数\r\n    function searchGrid(q" +
"ueryJson) {\r\n        $(\"#gridTable\").jqGrid(\'setGridParam\', {\r\n            postD" +
"ata: { queryJson: JSON.stringify(queryJson) },\r\n        }).trigger(\'reloadGrid\')" +
";\r\n    }\r\n    //查看\r\n    function btn_flowpreview()\r\n    {\r\n        var _processI" +
"d = $(\"#gridTable\").jqGridRowValue(\"f_id\");\r\n        var _processname = $(\"#grid" +
"Table\").jqGridRowValue(\"f_name\");\r\n        if (_processId) {\r\n            dialog" +
"Open({\r\n                id: \"ProcessLookForm\",\r\n                title: \'进度查看【\' +" +
" _processname + \'】\',\r\n                url: \'../../FlowManage/FlowProcess/Process" +
"LookFrom?processId=\' + _processId,\r\n                width: \"1100px\",\r\n          " +
"      height: \"700px\",\r\n                btn: null,\r\n                callBack: fu" +
"nction (iframeId) {\r\n                }\r\n            });\r\n        } else {\r\n     " +
"       dialogMsg(\'请选择需要查看的实例！\', 0);\r\n        }\r\n    }\r\n    //取消\r\n    function bt" +
"n_delete() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowValue(\"f_id\");\r\n  " +
"      if (keyValue) {\r\n            $.ConfirmAjax({\r\n                msg: \"注：您确定要" +
"取消吗？该操作将无法恢复\",\r\n                url: \"../../FlowManage/FlowProcess/OperateProces" +
"s\",\r\n                param: { keyValue: keyValue,state:2 },\r\n                suc" +
"cess: function (data) {\r\n                    $(\"#gridTable\").trigger(\"reloadGrid" +
"\");\r\n                }\r\n            })\r\n        } else {\r\n            dialogMsg(" +
"\'请选择要取消的实例！\', 0);\r\n        }\r\n    }\r\n    //暂停\r\n    function btn_disabled() {\r\n  " +
"      var keyValue = $(\"#gridTable\").jqGridRowValue(\"f_id\");\r\n        if (keyVal" +
"ue) {\r\n            $.ConfirmAjax({\r\n                msg: \"注：您确定要暂停吗？\",\r\n        " +
"        url: \"../../FlowManage/FlowProcess/OperateProcess\",\r\n                par" +
"am: { keyValue: keyValue,state:0 },\r\n                success: function (data) {\r" +
"\n                    $(\"#gridTable\").trigger(\"reloadGrid\");\r\n                }\r\n" +
"            })\r\n        } else {\r\n            dialogMsg(\'请选择要暂停的实例！\', 0);\r\n     " +
"   }\r\n    }\r\n    //启用\r\n    function btn_enabled() {\r\n        var keyValue = $(\"#" +
"gridTable\").jqGridRowValue(\"f_id\");\r\n        if (keyValue) {\r\n            $.Conf" +
"irmAjax({\r\n                msg: \"注：您确定要启用吗？\",\r\n                url: \"../../FlowM" +
"anage/FlowProcess/OperateProcess\",\r\n                param: { keyValue: keyValue " +
",state:1},\r\n                success: function (data) {\r\n                    $(\"#" +
"gridTable\").trigger(\"reloadGrid\");\r\n                }\r\n            })\r\n        }" +
" else {\r\n            dialogMsg(\'请选择要启用的实例！\', 0);\r\n        }\r\n    }\r\n</script>\r\n<" +
"div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">流程模板</div>\r\n            <div");

WriteLiteral(" id=\"itemTree\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">流程实例</div>\r\n            <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n                    <table>\r\n                        <tr>\r\n                   " +
"         <td>\r\n                                <input");

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

WriteLiteral(" id=\"lr-flowpreview\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_flowpreview()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-eye\"");

WriteLiteral("></i>&nbsp;查看</a>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" id=\"lr-disabled\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_disabled()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-stop\"");

WriteLiteral("></i>&nbsp;暂停</a>\r\n                        <a");

WriteLiteral(" id=\"lr-enabled\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_enabled()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-play\"");

WriteLiteral("></i>&nbsp;启用</a>\r\n                        <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_delete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>&nbsp;取消</a>\r\n                    </div>\r\n                </div>\r\n          " +
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
