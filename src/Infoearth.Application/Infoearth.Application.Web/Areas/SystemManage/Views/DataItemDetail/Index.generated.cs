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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/SystemManage/Views/DataItemDetail/Index.cshtml")]
    public partial class _Areas_SystemManage_Views_DataItemDetail_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_SystemManage_Views_DataItemDetail_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\SystemManage\Views\DataItemDetail\Index.cshtml"
  
    ViewBag.Title = "字典管理";
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
"on();\r\n        });\r\n    }\r\n    //加载树\r\n    var _itemId = \"\";\r\n    var _itemName =" +
" \"\";\r\n    var _isTree = \"\";\r\n    function GetTree() {\r\n        var item = {\r\n   " +
"         height: $(window).height() - 52,\r\n            url: \"../../SystemManage/" +
"DataItem/GetTreeJson\",\r\n            onnodeclick: function (item) {\r\n            " +
"    if (item.parentnodes == \"0\") {\r\n                    return;\r\n               " +
" }\r\n                _itemId = item.id;\r\n                _itemName = item.text;\r\n" +
"                _isTree = item.isTree;\r\n                $(\"#titleinfo\").html(_it" +
"emName + \"(\" + item.value + \")\");\r\n                $(\"#txt_Keyword\").val(\"\");\r\n " +
"               $(\'#btn_Search\').trigger(\"click\");\r\n            }\r\n        };\r\n  " +
"      //初始化\r\n        $(\"#itemTree\").treeview(item);\r\n    }\r\n    //加载表格\r\n    func" +
"tion GetGrid() {\r\n        var selectedRowIndex = 0;\r\n        var $gridTable = $(" +
"\"#gridTable\");\r\n        $gridTable.jqGrid({\r\n            datatype: \"json\",\r\n    " +
"        height: $(window).height() - 141,\r\n            autowidth: true,\r\n       " +
"     colModel: [\r\n                { label: \'主键\', name: \'F_ItemDetailId\', hidden:" +
" true },\r\n                { label: \'&nbsp;&nbsp;&nbsp;&nbsp;项目名\', name: \'F_ItemN" +
"ame\', index: \'F_ItemName\', width: 200, align: \'left\', sortable: false },\r\n      " +
"          { label: \'项目值\', name: \'F_ItemValue\', index: \'F_ItemValue\', width: 200," +
" align: \'left\', sortable: false },\r\n                { label: \'简拼\', name: \'F_Simp" +
"leSpelling\', index: \'F_SimpleSpelling\', width: 150, align: \'left\', sortable: fal" +
"se },\r\n                { label: \'排序\', name: \'F_SortCode\', index: \'F_SortCode\', w" +
"idth: 80, align: \'center\', sortable: false },\r\n                {\r\n              " +
"      label: \"默认\", name: \"F_IsDefault\", index: \"F_IsDefault\", width: 50, align: " +
"\"center\", sortable: false,\r\n                    formatter: function (cellvalue) " +
"{\r\n                        return cellvalue == 1 ? \"<i class=\\\"fa fa-toggle-on\\\"" +
"></i>\" : \"<i class=\\\"fa fa-toggle-off\\\"></i>\";\r\n                    }\r\n         " +
"       },\r\n                {\r\n                    label: \"有效\", name: \"F_EnabledM" +
"ark\", index: \"F_EnabledMark\", width: 50, align: \"center\", sortable: false,\r\n    " +
"                formatter: function (cellvalue) {\r\n                        retur" +
"n cellvalue == 1 ? \"<i class=\\\"fa fa-toggle-on\\\"></i>\" : \"<i class=\\\"fa fa-toggl" +
"e-off\\\"></i>\";\r\n                    }\r\n                },\r\n                { lab" +
"el: \"备注\", name: \"F_Description\", index: \"F_Description\", width: 200, align: \"lef" +
"t\", sortable: false }\r\n            ],\r\n            treeGrid: true,\r\n            " +
"treeGridModel: \"nested\",\r\n            ExpandColumn: \"F_ItemValue\",\r\n            " +
"rowNum: \"10000\",\r\n            rownumbers: true,\r\n            onSelectRow: functi" +
"on () {\r\n                selectedRowIndex = $(\"#\" + this.id).getGridParam(\'selro" +
"w\');\r\n            },\r\n            gridComplete: function () {\r\n                $" +
"(\"#\" + this.id).setSelection(selectedRowIndex, false);\r\n            }\r\n        }" +
");\r\n        //查询条件\r\n        $(\"#queryCondition .dropdown-menu li\").click(functio" +
"n () {\r\n            var text = $(this).find(\'a\').html();\r\n            var value " +
"= $(this).find(\'a\').attr(\'data-value\');\r\n            $(\"#queryCondition .dropdow" +
"n-text\").html(text).attr(\'data-value\', value)\r\n        });\r\n        //查询事件\r\n    " +
"    $(\"#btn_Search\").click(function () {\r\n            $gridTable.jqGrid(\'setGrid" +
"Param\', {\r\n                url: \"../../SystemManage/DataItemDetail/GetTreeListJs" +
"on\",\r\n                postData: {\r\n                    itemId: _itemId,\r\n       " +
"             condition: $(\"#queryCondition\").find(\'.dropdown-text\').attr(\'data-v" +
"alue\'),\r\n                    keyword: $(\"#txt_Keyword\").val()\r\n                }" +
",\r\n            }).trigger(\'reloadGrid\');\r\n        });\r\n        //查询回车\r\n        $" +
"(\'#txt_Keyword\').bind(\'keypress\', function (event) {\r\n            if (event.keyC" +
"ode == \"13\") {\r\n                $(\'#btn_Search\').trigger(\"click\");\r\n            " +
"}\r\n        });\r\n    }\r\n    //新增\r\n    function btn_add() {\r\n        if (!_itemId)" +
" {\r\n            learun.dialogMsg({ msg: \'请选择字典分类！\', type: 0 });\r\n            ret" +
"urn false;\r\n        }\r\n        var parentId = $(\"#gridTable\").jqGridRowValue(\"F_" +
"ItemDetailId\");\r\n        if (_isTree != 1) {\r\n            parentId = 0;\r\n       " +
" }\r\n        learun.dialogOpen({\r\n            id: \"Form\",\r\n            title: \'添加" +
"字典\',\r\n            url: \'/SystemManage/DataItemDetail/Form?parentId=\' + parentId " +
"+ \"&itemId=\" + _itemId,\r\n            width: \"500px\",\r\n            height: \"370px" +
"\",\r\n            callBack: function (iframeId) {\r\n                getInfoTop().fr" +
"ames[iframeId].AcceptClick();\r\n            }\r\n        });\r\n    };\r\n    //编辑\r\n   " +
" function btn_edit() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowValue(\"F" +
"_ItemDetailId\");\r\n        if (learun.checkedRow(keyValue)) {\r\n            learun" +
".dialogOpen({\r\n                id: \"Form\",\r\n                title: \'编辑字典\',\r\n    " +
"            url: \'/SystemManage/DataItemDetail/Form?keyValue=\' + keyValue,\r\n    " +
"            width: \"500px\",\r\n                height: \"370px\",\r\n                c" +
"allBack: function (iframeId) {\r\n                    getInfoTop().frames[iframeId" +
"].AcceptClick();\r\n                }\r\n            });\r\n        }\r\n    }\r\n    //删除" +
"\r\n    function btn_delete() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowV" +
"alue(\"F_ItemDetailId\");\r\n        if (keyValue) {\r\n            learun.removeForm(" +
"{\r\n                url: \"../../SystemManage/DataItemDetail/RemoveForm\",\r\n       " +
"         param: { keyValue: keyValue },\r\n                success: function (data" +
") {\r\n                    $(\"#gridTable\").resetSelection();\r\n                    " +
"$(\"#gridTable\").trigger(\"reloadGrid\");\r\n                }\r\n            })\r\n     " +
"   } else {\r\n            learun.dialogMsg({ msg: \'请选择需要删除的字典！\', type: 0 });\r\n   " +
"     }\r\n    }\r\n    //详细\r\n    function btn_detail() {\r\n        var keyValue = $(\"" +
"#gridTable\").jqGridRowValue(\"F_ItemDetailId\");\r\n        if (learun.checkedRow(ke" +
"yValue)) {\r\n            learun.dialogOpen({\r\n                id: \"Detail\",\r\n    " +
"            title: \'字典信息\',\r\n                url: \'/SystemManage/DataItemDetail/D" +
"etail?keyValue=\' + keyValue,\r\n                width: \"500px\",\r\n                h" +
"eight: \"480px\",\r\n                btn: null\r\n            });\r\n        }\r\n    }\r\n " +
"   //字典分类\r\n    function btn_datacategory() {\r\n        learun.dialogOpen({\r\n     " +
"       id: \"DataItemSort\",\r\n            title: \'字典分类\',\r\n            url: \'/Syste" +
"mManage/DataItem/Index\',\r\n            width: \"800px\",\r\n            height: \"500p" +
"x\",\r\n            btn: null\r\n        });\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">字典分类</div>\r\n            <div");

WriteLiteral(" id=\"itemTree\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">\r\n                字典数据 - <span");

WriteLiteral(" id=\"titleinfo\"");

WriteLiteral(">未选择分类</span>\r\n            </div>\r\n            <div");

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

WriteLiteral(" data-value=\"ItemName\"");

WriteLiteral(">项目名</a></li>\r\n                                        <li><a");

WriteLiteral(" data-value=\"ItemValue\"");

WriteLiteral(">项目值</a></li>\r\n                                        <li><a");

WriteLiteral(" data-value=\"SimpleSpelling\"");

WriteLiteral(">拼音</a></li>\r\n                                    </ul>\r\n                        " +
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

WriteLiteral("></i>&nbsp;删除</a>\r\n                        <a");

WriteLiteral(" id=\"lr-detail\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_detail()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-list-alt\"");

WriteLiteral("></i>&nbsp;详细</a>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" id=\"lr-datacategory\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_datacategory()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-tags\"");

WriteLiteral("></i>&nbsp;字典分类</a>\r\n                    </div>\r\n                </div>\r\n        " +
"        <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n                <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
