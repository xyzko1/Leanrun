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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/AuthorizeManage/Views/FilterIP/Index.cshtml")]
    public partial class _Areas_AuthorizeManage_Views_FilterIP_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_AuthorizeManage_Views_FilterIP_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\AuthorizeManage\Views\FilterIP\Index.cshtml"
  
    ViewBag.Title = "过滤IP";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n        <table>\r\n            <tr>\r\n                <td>\r\n                    <" +
"div");

WriteLiteral(" id=\"btn_visitType\"");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"btn btn-default active\"");

WriteLiteral(" data-value=\"1\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-key\"");

WriteLiteral("></i>&nbsp;授权访问</a>\r\n                        <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" data-value=\"0\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-lock\"");

WriteLiteral("></i>&nbsp;拒绝访问</a>\r\n                    </div>\r\n                </td>\r\n         " +
"   </tr>\r\n        </table>\r\n    </div>\r\n    <div");

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

WriteLiteral("></table>\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var objectId = request(\'objectId\');\r\n    var objectType = request" +
"(\'objectType\');\r\n    $(function () {\r\n        GetGrid();\r\n    });\r\n    //加载表格\r\n " +
"   function GetGrid() {\r\n        var selectedRowIndex = 0;\r\n        var $gridTab" +
"le = $(\"#gridTable\");\r\n        $gridTable.jqGrid({\r\n            url: \"../../Auth" +
"orizeManage/FilterIP/GetListJson\",\r\n            postData: { objectId: objectId, " +
"visitType: 1 },\r\n            datatype: \"json\",\r\n            height: $(window).he" +
"ight() - 115,\r\n            autowidth: true,\r\n            colModel: [\r\n          " +
"      { label: \"主键\", name: \"F_FilterIPId\", hidden: true },\r\n                {\r\n " +
"                   label: \"访问\", name: \"F_VisitType\", width: 80, align: \"center\"," +
" sortable: false,\r\n                    formatter: function (cellvalue) {\r\n      " +
"                  if (cellvalue == 0) {\r\n                            return \'<sp" +
"an value=\' + cellvalue + \' class=\\\"label label-danger\\\">拒绝</span>\';\r\n           " +
"             } else {\r\n                            return \'<span value=\' + cellv" +
"alue + \' class=\\\"label label-success\\\">授权</span>\';\r\n                        }\r\n " +
"                   }\r\n                },\r\n                { label: \"IP地址(子网掩码)\"," +
" name: \"F_IPLimit\", width: 200, align: \"left\", sortable: false }\r\n            ]," +
"\r\n            rowNum: \"10000\",\r\n            rownumbers: true,\r\n            onSel" +
"ectRow: function () {\r\n                selectedRowIndex = $(\"#\" + this.id).getGr" +
"idParam(\'selrow\');\r\n            },\r\n            gridComplete: function () {\r\n   " +
"             $(\"#\" + this.id).setSelection(selectedRowIndex, false);\r\n          " +
"  }\r\n        });\r\n        //授权、拒绝 访问事件\r\n        $(\"#btn_visitType a.btn-default\"" +
").click(function () {\r\n            $(\"#btn_visitType a.btn-default\").removeClass" +
"(\"active\");\r\n            $(this).addClass(\"active\");\r\n            $gridTable.jqG" +
"rid(\'setGridParam\', {\r\n                postData: { objectId: objectId, visitType" +
": $(this).attr(\'data-value\') },\r\n            }).trigger(\'reloadGrid\');\r\n        " +
"});\r\n    }\r\n    //新增\r\n    function btn_add() {\r\n        var visitType = $(\"#btn_" +
"visitType a.active\").attr(\'data-value\');\r\n        dialogOpen({\r\n            id: " +
"\"Form\",\r\n            title: \'添加IP地址\',\r\n            url: \'/AuthorizeManage/Filter" +
"IP/Form?objectId=\' + objectId + \'&objectType=\' + objectType + \"&visitType=\" + vi" +
"sitType,\r\n            width: \"400px\",\r\n            height: \"260px\",\r\n           " +
" callBack: function (iframeId) {\r\n                getInfoTop().frames[iframeId]." +
"AcceptClick();\r\n            }\r\n        });\r\n    };\r\n    //编辑\r\n    function btn_e" +
"dit() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowValue(\"F_FilterIPId\");\r" +
"\n        if (checkedRow(keyValue)) {\r\n            dialogOpen({\r\n                " +
"id: \"Form\",\r\n                title: \'编辑IP地址\',\r\n                url: \'/AuthorizeM" +
"anage/FilterIP/Form?keyValue=\' + keyValue,\r\n                width: \"400px\",\r\n   " +
"             height: \"260px\",\r\n                callBack: function (iframeId) {\r\n" +
"                    getInfoTop().frames[iframeId].AcceptClick();\r\n              " +
"  }\r\n            });\r\n        }\r\n    }\r\n    //删除\r\n    function btn_delete() {\r\n " +
"       var keyValue = $(\"#gridTable\").jqGridRowValue(\"F_FilterIPId\");\r\n        i" +
"f (keyValue) {\r\n            $.RemoveForm({\r\n                url: \"../../Authoriz" +
"eManage/FilterIP/RemoveForm\",\r\n                param: { keyValue: keyValue },\r\n " +
"               success: function (data) {\r\n                    $(\"#gridTable\").t" +
"rigger(\"reloadGrid\");\r\n                }\r\n            })\r\n        } else {\r\n    " +
"        dialogMsg(\'请选择需要删除的库连接！\', 0);\r\n        }\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
