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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/SystemManage/Views/DataItemList/Index.cshtml")]
    public partial class _Areas_SystemManage_Views_DataItemList_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_SystemManage_Views_DataItemList_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 6 "..\..\Areas\SystemManage\Views\DataItemList\Index.cshtml"
  
    ViewBag.Title = "辅助资料";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

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

WriteLiteral(" data-value=\"ItemName\"");

WriteLiteral(">项目名</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"ItemValue\"");

WriteLiteral(">项目值</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"SimpleSpelling\"");

WriteLiteral(">拼音</a></li>\r\n                        </ul>\r\n                    </div>\r\n        " +
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

WriteLiteral(" onclick=\"$.indexJs.btn.add()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>&nbsp;新增</a>\r\n            <a");

WriteLiteral(" id=\"lr-edit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"$.indexJs.btn.edit()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pencil-square-o\"");

WriteLiteral("></i>&nbsp;编辑</a>\r\n            <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"$.indexJs.btn.btndelete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>&nbsp;删除</a>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n</div>\r\n<script>\r\n    (function ($) {\r\n        \"use strict\";\r\n\r\n      " +
"  $.indexJs = {\r\n            encode: \"\",\r\n            initialPage: function () {" +
"\r\n                //resize重设(表格、树形)宽高\r\n                $(window).resize(function" +
" (e) {\r\n                    window.setTimeout(function () {\r\n                   " +
"     $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').width()));\r\n                 " +
"       $(\"#gridTable\").setGridHeight($(window).height() - 108.5);\r\n             " +
"       }, 200);\r\n                    e.stopPropagation();\r\n                });\r\n" +
"            },\r\n            loadGrid: function () {\r\n                var selecte" +
"dRowIndex = 0;\r\n                var $gridTable = $(\"#gridTable\");\r\n             " +
"   $gridTable.jqGrid({\r\n                    url: \"../../SystemManage/DataItemLis" +
"t/GetListJson?encode=\" + $.indexJs.encode,\r\n                    datatype: \"json\"" +
",\r\n                    height: $(window).height() - 108.5,\r\n                    " +
"autowidth: true,\r\n                    colModel: [\r\n                        { lab" +
"el: \'主键\', name: \'F_ItemDetailId\', hidden: true },\r\n                       { labe" +
"l: \'&nbsp;&nbsp;&nbsp;&nbsp;项目名\', name: \'F_ItemName\', index: \'F_ItemName\', width" +
": 200, align: \'left\', sortable: false },\r\n                        { label: \'项目值\'" +
", name: \'F_ItemValue\', index: \'F_ItemValue\', width: 200, align: \'left\', sortable" +
": false },\r\n                        { label: \'简拼\', name: \'F_SimpleSpelling\', ind" +
"ex: \'F_SimpleSpelling\', width: 150, align: \'left\', sortable: false },\r\n         " +
"               { label: \'排序\', name: \'F_SortCode\', index: \'F_SortCode\', width: 80" +
", align: \'left\' },\r\n                        {\r\n                            label" +
": \"有效\", name: \"F_EnabledMark\", index: \"F_EnabledMark\", width: 50, align: \"center" +
"\",\r\n                            formatter: function (cellvalue) {\r\n             " +
"                   return cellvalue == 1 ? \"<i class=\\\"fa fa-toggle-on\\\"></i>\" :" +
" \"<i class=\\\"fa fa-toggle-off\\\"></i>\";\r\n                            }\r\n         " +
"               },\r\n                        { label: \"备注\", name: \"F_Description\"," +
" index: \"F_Description\", width: 200, align: \"left\" }\r\n                    ],\r\n  " +
"                  treeGrid: true,\r\n                    treeGridModel: \"nested\",\r" +
"\n                    ExpandColumn: \"F_ItemValue\",\r\n                    rowNum: \"" +
"10000\",\r\n                    rownumbers: true,\r\n                    onSelectRow:" +
" function () {\r\n                        selectedRowIndex = $(\"#\" + this.id).getG" +
"ridParam(\'selrow\');\r\n                    },\r\n                    gridComplete: f" +
"unction () {\r\n                        $(\"#\" + this.id).setSelection(selectedRowI" +
"ndex, false);\r\n                    }\r\n                });\r\n                //查询条" +
"件\r\n                $(\"#queryCondition .dropdown-menu li\").click(function () {\r\n " +
"                   var text = $(this).find(\'a\').html();\r\n                    var" +
" value = $(this).find(\'a\').attr(\'data-value\');\r\n                    $(\"#queryCon" +
"dition .dropdown-text\").html(text).attr(\'data-value\', value)\r\n                })" +
";\r\n                //查询事件\r\n                $(\"#btn_Search\").click(function () {\r" +
"\n                    var queryJson = {\r\n                        condition: $(\"#q" +
"ueryCondition\").find(\'.dropdown-text\').attr(\'data-value\'),\r\n                    " +
"    keyword: $(\"#txt_Keyword\").val()\r\n                    }\r\n                   " +
" $gridTable.jqGrid(\'setGridParam\', {\r\n                        postData: queryJso" +
"n,\r\n                    }).trigger(\'reloadGrid\');\r\n                });\r\n        " +
"        //查询回车\r\n                $(\'#txt_Keyword\').bind(\'keypress\', function (eve" +
"nt) {\r\n                    if (event.keyCode == \"13\") {\r\n                       " +
" $(\'#btn_Search\').trigger(\"click\");\r\n                    }\r\n                });\r" +
"\n            },\r\n            btn: {\r\n                add: function () { //新增\r\n  " +
"                  var parentId = $(\"#gridTable\").jqGridRowValue(\"F_ItemDetailId\"" +
");\r\n                    var itemId = \'");

            
            #line 123 "..\..\Areas\SystemManage\Views\DataItemList\Index.cshtml"
                             Write(ViewBag.itemId);

            
            #line default
            #line hidden
WriteLiteral("\';\r\n                    var isTree = \'");

            
            #line 124 "..\..\Areas\SystemManage\Views\DataItemList\Index.cshtml"
                             Write(ViewBag.isTree);

            
            #line default
            #line hidden
WriteLiteral("\';\r\n                    if (isTree != 1) {\r\n                        parentId = 0;" +
"\r\n                    }\r\n                    dialogOpen({\r\n                     " +
"   id: \"Form\",\r\n                        title: \'添加分类\',\r\n                        " +
"url: \'/SystemManage/DataItemList/Form?parentId=\' + parentId + \"&itemId=\" + itemI" +
"d,\r\n                        width: \"500px\",\r\n                        height: \"37" +
"0px\",\r\n                        callBack: function (iframeId) {\r\n                " +
"            getInfoTop().frames[iframeId].AcceptClick();\r\n                      " +
"  }\r\n                    });\r\n                },\r\n                edit: function" +
" () { //编辑\r\n                    var keyValue = $(\"#gridTable\").jqGridRowValue(\"F" +
"_ItemDetailId\");\r\n                    if (checkedRow(keyValue)) {\r\n             " +
"           dialogOpen({\r\n                            id: \"Form\",\r\n              " +
"              title: \'编辑分类\',\r\n                            url: \'/SystemManage/Da" +
"taItemList/Form?keyValue=\' + keyValue,\r\n                            width: \"500p" +
"x\",\r\n                            height: \"370px\",\r\n                            c" +
"allBack: function (iframeId) {\r\n                                getInfoTop().fra" +
"mes[iframeId].AcceptClick();\r\n                            }\r\n                   " +
"     });\r\n                    }\r\n                },\r\n                btndelete: " +
"function () {//删除\r\n                    var keyValue = $(\"#gridTable\").jqGridRowV" +
"alue(\"F_ItemDetailId\");\r\n                    if (keyValue) {\r\n                  " +
"      $.RemoveForm({\r\n                            url: \"../../SystemManage/DataI" +
"temList/RemoveForm\",\r\n                            param: { keyValue: keyValue }," +
"\r\n                            success: function (data) {\r\n                      " +
"          $(\"#gridTable\").resetSelection();\r\n                                $(\"" +
"#gridTable\").trigger(\"reloadGrid\");\r\n                            }\r\n            " +
"            })\r\n                    } else {\r\n                        dialogMsg(" +
"\'请选择需要删除的数据！\', 0);\r\n                    }\r\n                }\r\n            }\r\n   " +
"     }\r\n\r\n        $(function () {\r\n            $.indexJs.encode = request(\'ItemC" +
"ode\');\r\n            $.indexJs.initialPage();\r\n            $.indexJs.loadGrid();\r" +
"\n        });\r\n    })(window.jQuery);\r\n</script>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
