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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CustomerManage/Views/Customer/Index.cshtml")]
    public partial class _Areas_CustomerManage_Views_Customer_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_CustomerManage_Views_Customer_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\CustomerManage\Views\Customer\Index.cshtml"
  ;
  ViewBag.Title = "列表页面";
  Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>;\r\n    $(function () {\r\n        InitialPage();\r\n        GetGrid();\r\n   " +
" });\r\n    //初始化页面\r\n    function InitialPage() {\r\n        //resize重设布局;\r\n        " +
"$(window).resize(function (e) {\r\n            window.setTimeout(function () {\r\n  " +
"              $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').width()));\r\n        " +
"        $(\'#gridTable\').setGridHeight($(window).height() - 136.5);\r\n            " +
"}, 200);\r\n            e.stopPropagation();\r\n        });\r\n    }\r\n    //加载表格\r\n    " +
"function GetGrid() {\r\n        var selectedRowIndex = 0;\r\n        var $gridTable " +
"= $(\'#gridTable\');\r\n        $gridTable.jqGrid({\r\n            autowidth: true,\r\n " +
"           height: $(window).height() - 136.5,\r\n            url: \"../../Customer" +
"Manage/Customer/GetPageListJson\",\r\n            datatype: \"json\",\r\n            co" +
"lModel: [\r\n                { label: \'客户主键\', name: \'F_CustomerId\', index: \'F_Cust" +
"omerId\', width: 100, align: \'left\', sortable: true, hidden: true },\r\n           " +
"     { label: \'客户编号\', name: \'F_EnCode\', index: \'F_EnCode\', width: 100, align: \'l" +
"eft\', sortable: true },\r\n                { label: \'客户名称\', name: \'F_FullName\', in" +
"dex: \'F_FullName\', width: 300, align: \'left\', sortable: true },\r\n               " +
" {\r\n                    label: \'客户级别\', name: \'F_CustLevelId\', index: \'F_CustLeve" +
"lId\', width: 80, align: \'center\', sortable: true,\r\n                    formatter" +
": function (cellvalue, options, rowObject) {\r\n                        return top" +
".learun.data.get([\"dataItem\", \"Client_Level\", cellvalue]);\r\n                    " +
"}\r\n                },\r\n                { label: \'客户类别\', name: \'F_CustTypeId\', in" +
"dex: \'F_CustTypeId\', width: 80, align: \'center\', sortable: true },\r\n            " +
"    { label: \'客户程度\', name: \'F_CustDegreeId\', index: \'F_CustDegreeId\', width: 80," +
" align: \'center\', sortable: true },\r\n                { label: \'公司行业\', name: \'F_C" +
"ustIndustryId\', index: \'F_CustIndustryId\', width: 80, align: \'center\', sortable:" +
" true },\r\n                { label: \'联系人\', name: \'F_Contact\', index: \'F_Contact\'," +
" width: 80, align: \'left\', sortable: true },\r\n                { label: \'跟进人员\', n" +
"ame: \'F_TraceUserName\', index: \'F_TraceUserName\', width: 80, align: \'left\', sort" +
"able: true },\r\n                { label: \'最后更新\', name: \'F_ModifyDate\', index: \'F_" +
"ModifyDate\', width: 130, align: \'left\', sortable: true, formatter: \"date\", forma" +
"toptions: { srcformat: \'Y-m-d H:i\', newformat: \'Y-m-d H:i\' } },\r\n               " +
" { label: \'备注\', name: \'F_Description\', index: \'F_Description\', width: 200, align" +
": \'left\', sortable: true },\r\n            ],\r\n            viewrecords: true,\r\n   " +
"         rowNum: 30,\r\n            rowList: [30, 50, 100],\r\n            pager: \"#" +
"gridPager\",\r\n            sortname: \'F_ModifyDate\',\r\n            sortorder: \'desc" +
"\',\r\n            rownumbers: true,\r\n            shrinkToFit: false,\r\n            " +
"gridview: true,\r\n            onSelectRow: function () {\r\n                selecte" +
"dRowIndex = $(\'#\' + this.id).getGridParam(\'selrow\');\r\n            },\r\n          " +
"  gridComplete: function () {\r\n                $(\'#\' + this.id).setSelection(sel" +
"ectedRowIndex, false);\r\n            }\r\n        });\r\n        //查询条件\r\n        $(\"#" +
"queryCondition .dropdown-menu li\").click(function () {\r\n            var text = $" +
"(this).find(\'a\').html();\r\n            var value = $(this).find(\'a\').attr(\'data-v" +
"alue\');\r\n            $(\"#queryCondition .dropdown-text\").html(text).attr(\'data-v" +
"alue\', value)\r\n        });\r\n        //查询事件\r\n        $(\"#btn_Search\").click(funct" +
"ion () {\r\n            var queryJson = {\r\n                condition: $(\"#queryCon" +
"dition\").find(\'.dropdown-text\').attr(\'data-value\'),\r\n                keyword: $(" +
"\"#txt_Keyword\").val()\r\n            }\r\n            $gridTable.jqGrid(\'setGridPara" +
"m\', {\r\n                postData: { queryJson: JSON.stringify(queryJson) },\r\n    " +
"            page: 1\r\n            }).trigger(\'reloadGrid\');\r\n        });\r\n       " +
" //查询回车\r\n        $(\'#txt_Keyword\').bind(\'keypress\', function (event) {\r\n        " +
"    if (event.keyCode == \"13\") {\r\n                $(\'#btn_Search\').trigger(\"clic" +
"k\");\r\n            }\r\n        });\r\n    }\r\n    //新增\r\n    function btn_add() {\r\n   " +
"     dialogOpen({\r\n            id: \'Form\',\r\n            title: \'添加客户\',\r\n        " +
"    url: \'/CustomerManage/Customer/Form\',\r\n            width: \'750px\',\r\n        " +
"    height: \'600px\',\r\n            callBack: function (iframeId) {\r\n             " +
"   getInfoTop().frames[iframeId].AcceptClick();\r\n            }\r\n        });\r\n   " +
" }\r\n    //编辑\r\n    function btn_edit() {\r\n        var keyValue = $(\"#gridTable\")." +
"jqGridRowValue(\'F_CustomerId\');\r\n        if (checkedRow(keyValue)) {\r\n          " +
"  dialogOpen({\r\n                id: \'Form\',\r\n                title: \'编辑客户\',\r\n   " +
"             url: \'/CustomerManage/Customer/Form?keyValue=\' + keyValue,\r\n       " +
"         width: \'750px\',\r\n                height: \'600px\',\r\n                call" +
"Back: function (iframeId) {\r\n                    getInfoTop().frames[iframeId].A" +
"cceptClick();\r\n                }\r\n            })\r\n        }\r\n    }\r\n    //删除\r\n  " +
"  function btn_delete() {\r\n        var keyValue = $(\"#gridTable\").jqGridRowValue" +
"(\'F_CustomerId\');\r\n        if (keyValue) {\r\n            $.RemoveForm({\r\n        " +
"        url: \'../../CustomerManage/Customer/RemoveForm\',\r\n                param:" +
" { keyValue: keyValue },\r\n                success: function (data) {\r\n          " +
"          $(\'#gridTable\').trigger(\'reloadGrid\');\r\n                }\r\n           " +
" })\r\n        } else {\r\n            dialogMsg(\'请选择需要删除的客户信息！\', 0);\r\n        }\r\n  " +
"  }\r\n    //详细\r\n    function btn_detail() {\r\n        var keyValue = $(\"#gridTable" +
"\").jqGridRowValue(\"F_CustomerId\");\r\n        if (checkedRow(keyValue)) {\r\n       " +
"     dialogOpen({\r\n                id: \"Detail\",\r\n                title: \'客户信息\'," +
"\r\n                url: \'/CustomerManage/Customer/Detail?keyValue=\' + keyValue,\r\n" +
"                width: \'750px\',\r\n                height: \'550px\',\r\n             " +
"   btn: null\r\n            });\r\n        }\r\n    }\r\n    //导出\r\n    function btn_expo" +
"rt() {\r\n        dialogOpen({\r\n            id: \"ExcelIExportDialog\",\r\n           " +
" title: \'导出客户数据\',\r\n            url: \'/Utility/ExcelExportForm?gridId=gridTable&f" +
"ilename=客户信息\',\r\n            width: \"500px\",\r\n            height: \"380px\",\r\n     " +
"       callBack: function (iframeId) {\r\n                getInfoTop().frames[ifra" +
"meId].AcceptClick();\r\n            }, btn: [\'导出Excel\', \'关闭\']\r\n        });\r\n    }\r" +
"\n    //联系人\r\n    function btn_contact() {\r\n        var keyValue = $(\"#gridTable\")" +
".jqGridRowValue(\'F_CustomerId\');\r\n        var fullName = $(\"#gridTable\").jqGridR" +
"owValue(\'F_FullName\');\r\n        if (keyValue) {\r\n            dialogOpen({\r\n     " +
"           id: \'ContactIndex\',\r\n                title: fullName + \' - 联系人\',\r\n   " +
"             url: \'/CustomerManage/Customer/ContactIndex?customerId=\' + keyValue" +
",\r\n                width: \'900px\',\r\n                height: \'550px\',\r\n          " +
"      btn: null\r\n            });\r\n        } else {\r\n            dialogMsg(\'请选择客户" +
"信息！\', 0);\r\n        }\r\n    }\r\n    //跟进记录\r\n    function btn_chancetrail() {\r\n     " +
"   var keyValue = $(\"#gridTable\").jqGridRowValue(\'F_CustomerId\');\r\n        var f" +
"ullName = $(\"#gridTable\").jqGridRowValue(\'F_FullName\');\r\n        if (keyValue) {" +
"\r\n            dialogOpen({\r\n                id: \'ChanceTrailIndex\',\r\n           " +
"     title: fullName + \' - 跟进记录\',\r\n                url: \'/CustomerManage/TrailRe" +
"cord/Index?objectId=\' + keyValue + \'&objectSort=2\',\r\n                width: \'750" +
"px\',\r\n                height: \'550px\',\r\n                btn: null\r\n            }" +
");\r\n        } else {\r\n            dialogMsg(\'请选择商机信息！\', 0);\r\n        }\r\n    }\r\n<" +
"/script>\r\n<div");

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

WriteLiteral(" data-value=\"EnCode\"");

WriteLiteral(">客户编号</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"FullName\"");

WriteLiteral(">客户名称</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"Contact\"");

WriteLiteral(">联系人</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"TraceUserName\"");

WriteLiteral(">跟进人员</a></li>\r\n                        </ul>\r\n                    </div>\r\n      " +
"          </td>\r\n                <td");

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

WriteLiteral("></i>&nbsp;删除</a>\r\n            <a");

WriteLiteral(" id=\"lr-detail\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_detail()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-list-alt\"");

WriteLiteral("></i>&nbsp;详细</a>\r\n            <a");

WriteLiteral(" id=\"lr-export\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_export()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-sign-out\"");

WriteLiteral("></i>&nbsp;导出</a>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"lr-contact\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_contact()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa fa-book\"");

WriteLiteral("></i>&nbsp;联系人</a>\r\n            <a");

WriteLiteral(" id=\"lr-chancetrail\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_chancetrail()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-clock-o\"");

WriteLiteral("></i>&nbsp;跟进记录</a>\r\n\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n    <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
