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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/SystemManage/Views/DataSource/Index.cshtml")]
    public partial class _Areas_SystemManage_Views_DataSource_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_SystemManage_Views_DataSource_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\SystemManage\Views\DataSource\Index.cshtml"
  
    ViewBag.Title = "辅助资料";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    var encode = request(\'ItemCode\');\r\n    $(function () {\r\n        I" +
"nitialPage();\r\n        GetGrid();\r\n    });\r\n    //初始化页面\r\n    function InitialPag" +
"e() {\r\n        //resize重设(表格、树形)宽高\r\n        $(window).resize(function (e) {\r\n   " +
"         window.setTimeout(function () {\r\n                $(\'#gridTable\').setGri" +
"dWidth(($(\'.gridPanel\').width()));\r\n                $(\"#gridTable\").setGridHeigh" +
"t($(window).height() - 136.5);\r\n            }, 200);\r\n            e.stopPropagat" +
"ion();\r\n        });\r\n    }\r\n    //加载表格\r\n    function GetGrid() {\r\n        var se" +
"lectedRowIndex = 0;\r\n        var $gridTable = $(\"#gridTable\");\r\n        $gridTab" +
"le.jqGrid({\r\n            url: \"../../SystemManage/DataSource/GetPageListJson\",\r\n" +
"            datatype: \"json\",\r\n            height: $(window).height() - 136.5,\r\n" +
"            autowidth: true,\r\n            colModel: [\r\n                { label: " +
"\'主键\', name: \'F_Id\', hidden: true },\r\n                { label: \'数据名称\', name: \'F_N" +
"ame\', index: \'F_Name\', width: 150, align: \'left\', sortable: false },\r\n          " +
"      { label: \'数据编号\', name: \'F_Code\', index: \'F_Code\', width: 150, align: \'left" +
"\', sortable: false },\r\n                { label: \'数据库名\', name: \'F_DbName\', index:" +
" \'F_DbName\', width: 150, align: \'left\', sortable: false },\r\n                { la" +
"bel: \'创建人\', name: \'F_CreateUserName\', index: \'F_CreateUserName\', width: 100, ali" +
"gn: \'left\', sortable: false },\r\n                { label: \'创建时间\', name: \'F_Create" +
"Date\', index: \'F_CreateDate\', width: 150, align: \'left\', sortable: false },\r\n   " +
"             { label: \"备注\", name: \"F_Description\", index: \"F_Description\", width" +
": 200, align: \"left\" }\r\n            ],\r\n            viewrecords: true,\r\n        " +
"    rowNum: 30,\r\n            rowList: [30, 50, 100],\r\n            pager: \"#gridP" +
"ager\",\r\n            sortname: \'F_CreateDate desc\',\r\n            rownumbers: true" +
",\r\n            shrinkToFit: false,\r\n            gridview: true,\r\n            onS" +
"electRow: function () {\r\n                selectedRowIndex = $(\"#\" + this.id).get" +
"GridParam(\'selrow\');\r\n            },\r\n            gridComplete: function () {\r\n " +
"               $(\"#\" + this.id).setSelection(selectedRowIndex, false);\r\n        " +
"    }\r\n        });\r\n        //查询事件\r\n        $(\"#btn_Search\").click(function () {" +
"\r\n            var queryJson = {\r\n                keyword: $(\"#txt_Keyword\").val(" +
")\r\n            }\r\n            $gridTable.jqGrid(\'setGridParam\', {\r\n             " +
"   postData: { queryJson: JSON.stringify(queryJson) },\r\n            }).trigger(\'" +
"reloadGrid\');\r\n        });\r\n        //查询回车\r\n        $(\'#txt_Keyword\').bind(\'keyp" +
"ress\', function (event) {\r\n            if (event.keyCode == \"13\") {\r\n           " +
"     $(\'#btn_Search\').trigger(\"click\");\r\n            }\r\n        });\r\n    }\r\n    " +
"//新增\r\n    function btn_add() {\r\n        dialogOpen({\r\n            id: \"Form\",\r\n " +
"           title: \'新建数据源\',\r\n            url: \'/SystemManage/DataSource/Form\',\r\n " +
"           width: \"650px\",\r\n            height: \"450px\",\r\n            btn:null,\r" +
"\n            callBack: function (iframeId) {\r\n                getInfoTop().frame" +
"s[iframeId].AcceptClick();\r\n            }\r\n        });\r\n    };\r\n    //编辑\r\n    fu" +
"nction btn_edit() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowValue(\"F_Id" +
"\");\r\n        if (checkedRow(keyValue)) {\r\n            dialogOpen({\r\n            " +
"    id: \"Form\",\r\n                title: \'编辑数据源\',\r\n                url: \'/SystemM" +
"anage/DataSource/Form?keyValue=\'+keyValue,\r\n                width: \"650px\",\r\n   " +
"             height: \"450px\",\r\n                btn: null,\r\n                callB" +
"ack: function (iframeId) {\r\n                    getInfoTop().frames[iframeId].Ac" +
"ceptClick();\r\n                }\r\n            });\r\n        }\r\n    }\r\n    //预览数据\r\n" +
"    function btn_preview() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowVa" +
"lue(\"F_Id\");\r\n        if (checkedRow(keyValue)) {\r\n            dialogOpen({\r\n   " +
"             id: \"Form\",\r\n                title: \'编辑数据源\',\r\n                url: " +
"\'/SystemManage/DataSource/PreviewForm?keyValue=\' + keyValue,\r\n                wi" +
"dth: \"650px\",\r\n                height: \"500px\",\r\n                btn: null,\r\n   " +
"             callBack: function (iframeId) {\r\n                    getInfoTop().f" +
"rames[iframeId].AcceptClick();\r\n                }\r\n            });\r\n        }\r\n " +
"   }\r\n    //删除\r\n    function btn_delete() {\r\n        var keyValue = $(\"#gridTabl" +
"e\").jqGridRowValue(\"F_Id\");\r\n        if (keyValue) {\r\n            $.RemoveForm({" +
"\r\n                url: \"../../SystemManage/DataSource/RemoveForm\",\r\n            " +
"    param: { keyValue: keyValue },\r\n                success: function (data) {\r\n" +
"                    $(\"#gridTable\").trigger(\"reloadGrid\");\r\n                }\r\n " +
"           })\r\n        } else {\r\n            dialogMsg(\'请选择需要删除的数据！\', 0);\r\n     " +
"   }\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n        <table>\r\n            <tr>\r\n                <td>\r\n                    <" +
"input");

WriteLiteral(" id=\"txt_Keyword\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入要查询数据源名称\"");

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

WriteLiteral(" id=\"lr-preview\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_preview()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-eye\"");

WriteLiteral("></i>&nbsp;测试</a>\r\n            <a");

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

WriteLiteral("></table>\r\n    <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
