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
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Infoearth.Application.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_ZLGC_KCINFO/TBL_ZLGC_KCINFOIndex.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_ZLGC_KCINFO_TBL_ZLGC_KCINFOIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_ZLGC_KCINFO_TBL_ZLGC_KCINFOIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_ZLGC_KCINFO\TBL_ZLGC_KCINFOIndex.cshtml"
  
    ViewBag.Title = "列表页面";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

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

WriteLiteral("></i>查询</a>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n    </di" +
"v>\r\n    <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"reload()\"");

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

WriteLiteral("></i>&nbsp;删除</a>\r\n        </div>\r\n    </div>\r\n                      <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        InitialPage();\r\n        GetGrid();\r\n    " +
"});\r\n    //初始化页面\r\n    function InitialPage() {\r\n        //resize重设布局;\r\n        $" +
"(window).resize(function (e) {\r\n            window.setTimeout(function () {\r\n   " +
"             $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').width()));\r\n         " +
"       $(\'#gridTable\').setGridHeight($(window).height() - 108.5);\r\n            }" +
", 200);\r\n            e.stopPropagation();\r\n        });\r\n    }\r\n    //加载表格\r\n    f" +
"unction GetGrid() {\r\n        var selectedRowIndex = 0;\r\n        var $gridTable =" +
" $(\'#gridTable\');\r\n        $gridTable.jqGrid({\r\n            autowidth: true,\r\n  " +
"          height: $(window).height() - 108.5,\r\n            url: \"../../JXGeoMana" +
"ge/TBL_ZLGC_KCINFO/GetListJson\",\r\n            datatype: \"json\",\r\n            col" +
"Model: [\r\n            ],\r\n            onSelectRow: function () {\r\n              " +
"  selectedRowIndex = $(\'#\' + this.id).getGridParam(\'selrow\');\r\n            },\r\n " +
"           gridComplete: function () {\r\n                $(\'#\' + this.id).setSele" +
"ction(selectedRowIndex, false);\r\n            }\r\n        });\r\n    }\r\n    //新增\r\n  " +
"  function btn_add() {\r\n        dialogOpen({\r\n            id: \'Form\',\r\n         " +
"   title: \'添加治理工程-野外勘察\',\r\n            url: \'/JXGeoManage/TBL_ZLGC_KCINFO/TBL_ZLG" +
"C_KCINFOForm\',\r\n            width: \'px\',\r\n            height: \'px\',\r\n           " +
" callBack: function (iframeId) {\r\n                getInfoTop().frames[iframeId]." +
"AcceptClick();\r\n            }\r\n        });\r\n    }\r\n    //编辑\r\n    function btn_ed" +
"it() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowValue(\'ZLGCID\');\r\n      " +
"  if (checkedRow(keyValue)) {\r\n            dialogOpen({\r\n                id: \'Fo" +
"rm\',\r\n                title: \'编辑治理工程-野外勘察\',\r\n                url: \'/JXGeoManage/" +
"TBL_ZLGC_KCINFO/TBL_ZLGC_KCINFOForm?keyValue=\' + keyValue,\r\n                widt" +
"h: \'px\',\r\n                height: \'px\',\r\n                callBack: function (ifr" +
"ameId) {\r\n                    getInfoTop().frames[iframeId].AcceptClick();\r\n    " +
"            }\r\n            })\r\n        }\r\n    }\r\n    //删除\r\n    function btn_dele" +
"te() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowValue(\'ZLGCID\');\r\n      " +
"  if (keyValue) {\r\n            $.RemoveForm({\r\n                url: \'../../JXGeo" +
"Manage/TBL_ZLGC_KCINFO/RemoveForm\',\r\n                param: { keyValue: keyValue" +
" },\r\n                success: function (data) {\r\n                    $(\'#gridTab" +
"le\').trigger(\'reloadGrid\');\r\n                }\r\n            })\r\n        } else {" +
"\r\n            dialogMsg(\'请选择需要删除的治理工程-野外勘察！\', 0);\r\n        }\r\n    }\r\n</script>\r\n" +
"");

});

        }
    }
}
#pragma warning restore 1591