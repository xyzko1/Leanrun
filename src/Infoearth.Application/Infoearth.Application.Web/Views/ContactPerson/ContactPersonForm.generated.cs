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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ContactPerson/ContactPersonForm.cshtml")]
    public partial class _Views_ContactPerson_ContactPersonForm_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_ContactPerson_ContactPersonForm_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\ContactPerson\ContactPersonForm.cshtml"
  
    ViewBag.Title = "列表页面";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var AreaId =request(\'AreaId\');\r\n    $(function () {\r\n        Init" +
"ialPage();\r\n        //查询条件\r\n        $(\"#queryCondition .dropdown-menu li\").click" +
"(function () {\r\n            var text = $(this).find(\'a\').html();\r\n            va" +
"r value = $(this).find(\'a\').attr(\'data-value\');\r\n            $(\"#queryCondition " +
".dropdown-text\").html(text).attr(\'data-value\', value)\r\n        });\r\n        GetG" +
"rid();\r\n        //查询点击事件\r\n        $(\"#btn_Search\").click(function () {\r\n        " +
"    SearchEvent();\r\n        });\r\n    });\r\n    //初始化页面\r\n    function InitialPage(" +
") {\r\n        //resize重设布局;\r\n        $(window).resize(function (e) {\r\n           " +
" window.setTimeout(function () {\r\n                $(\'#gridTable\').setGridWidth((" +
"$(\'.gridPanel\').width()));\r\n                $(\'#gridTable\').setGridHeight($(wind" +
"ow).height() - 108.5);\r\n            }, 200);\r\n            e.stopPropagation();\r\n" +
"        });\r\n    }\r\n    //加载表格\r\n    function GetGrid() {\r\n        var selectedRo" +
"wIndex = 0;\r\n        var $gridTable = $(\'#gridTable\');\r\n        var condition = " +
"$(\"#queryCondition\").find(\'.dropdown-text\').attr(\'data-value\');\r\n        if (con" +
"dition == undefined || condition == null || condition == \'\') {\r\n            cond" +
"ition = \'\';\r\n        }\r\n        var queryJson = $.extend($(\"#filter-form\").getWe" +
"bControls(), { \"condition\": condition });\r\n        queryJson.AreaCode = AreaId;\r" +
"\n        $gridTable.jqGrid({\r\n            autowidth: true,\r\n            height: " +
"$(window).height() - 138.5,\r\n            url: \"../../ContactPerson/GetContactPer" +
"son\",\r\n            postData: { queryJson: JSON.stringify(queryJson) },\r\n        " +
"    datatype: \"json\",\r\n            colModel: [\r\n                { label: \'Contac" +
"tPeopleID\', name: \'ContactPeopleID\', index: \'ContactPeopleID\', width: 100, align" +
": \'left\', sortable: true, hidden: true },\r\n                { label: \'部门ID\', name" +
": \'Dept\', index: \'Dept\', width: 100, align: \'left\', sortable: true, hidden: true" +
" },\r\n                { label: \'名称\', name: \'UserName\', index: \'UserName\', width: " +
"100, align: \'left\', sortable: true },\r\n                { label: \'登录名\', name: \'Lo" +
"ginName\', index: \'UserName\', width: 100, align: \'left\', sortable: true },\r\n     " +
"           { label: \'性别\', name: \'Sex\', index: \'Sex\', width: 100, align: \'left\', " +
"sortable: true, formatter: \"select\", editoptions: { value: \"0:男;1:女\" } },\r\n     " +
"           { label: \'手机\', name: \'Mobile\', index: \'Mobile\', width: 100, align: \'l" +
"eft\', sortable: true },\r\n                { label: \'电话\', name: \'Telephone\', index" +
": \'Telephone\', width: 100, align: \'left\', sortable: true },\r\n                { l" +
"abel: \'QQ\', name: \'Qq\', index: \'Qq\', width: 100, align: \'left\', sortable: true, " +
"hidden: true },\r\n                { label: \'Msn\', name: \'Msn\', index: \'Msn\', widt" +
"h: 100, align: \'left\', sortable: true, hidden: true },\r\n                { label:" +
" \'Email\', name: \'Email\', index: \'Email\', width: 100, align: \'left\', sortable: tr" +
"ue, hidden: true },\r\n                { label: \'部门名称\', name: \'DeptName\', index: \'" +
"DeptName\', width: 100, align: \'left\', sortable: true },\r\n                { label" +
": \'地址\', name: \'Address\', index: \'Address\', width: 100, align: \'left\', sortable: " +
"true },\r\n                { label: \'密码\', name: \'Password\', index: \'Password\', wid" +
"th: 100, align: \'left\', sortable: true, hidden: true },\r\n                { label" +
": \'行政区划编码\', name: \'DistrictCode\', index: \'DistrictCode\', width: 100, align: \'lef" +
"t\', sortable: true, hidden: true }\r\n\r\n            ],\r\n            viewrecords: t" +
"rue,\r\n            rowNum: 30,\r\n            rowList: [30, 50, 100],\r\n            " +
"pager: \"#gridPager\",\r\n            sortname: \'DeptNo\',\r\n            sortorder: \'d" +
"esc\',\r\n            rownumbers: true,\r\n            shrinkToFit: false,\r\n         " +
"   gridview: true,\r\n            onSelectRow: function (rowId, status) {\r\n       " +
"         selectedRowIndex = $(\'#\' + this.id).getGridParam(\'selrow\');\r\n          " +
"      selectData = $gridTable.jqGrid(\"getRowData\", rowId);\r\n            },\r\n    " +
"        gridComplete: function () {\r\n                //$(\'#\' + this.id).setSelec" +
"tion(selectedRowIndex, false);\r\n            }\r\n        });\r\n    }\r\n\r\n    var sel" +
"ectData = {};\r\n\r\n    //保存表单;\r\n    function AcceptClick() {\r\n        learun.dialo" +
"gClose();\r\n        return selectData;\r\n    }\r\n\r\n    //查询表格函数\r\n    function Searc" +
"hEvent() {\r\n        var condition = $(\"#queryCondition\").find(\'.dropdown-text\')." +
"attr(\'data-value\');\r\n        if (condition == undefined || condition == null || " +
"condition == \'\') {\r\n            condition = \'\';\r\n        }\r\n        if (conditio" +
"n == \'\') {\r\n            learun.dialogMsg({ msg: \'请选择需要查询关键字！\', type: 0 });\r\n    " +
"    }\r\n        var queryJson = $.extend($(\"#filter-form\").getWebControls(), { \"c" +
"ondition\": condition });\r\n        queryJson.AreaCode = AreaId;\r\n        $(\"#grid" +
"Table\").jqGrid(\'setGridParam\', {\r\n            postData: { queryJson: JSON.string" +
"ify(queryJson) },\r\n            url: \"../../ContactPerson/GetContactPerson\",\r\n   " +
"         page: 1\r\n        }).trigger(\'reloadGrid\');\r\n    }\r\n</script>\r\n");

});

WriteLiteral("<div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(" id=\"filter-form\"");

WriteLiteral(">\r\n        <table>\r\n            <tr>\r\n\r\n                <td>\r\n                   " +
" <div");

WriteLiteral(" id=\"queryCondition\"");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"btn btn-default dropdown-text\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" aria-expanded=\"false\"");

WriteLiteral(">选择条件</a>\r\n                        <a");

WriteLiteral(" class=\"btn btn-default dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" aria-expanded=\"true\"");

WriteLiteral("><span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span></a>\r\n                        <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n                            <li><a");

WriteLiteral(" data-value=\"UserName\"");

WriteLiteral(">名称</a></li>\r\n                            <li><a");

WriteLiteral(" data-value=\"Account\"");

WriteLiteral(">登陆名</a></li>\r\n                        </ul>\r\n                    </div>\r\n       " +
"         </td>\r\n                <td>\r\n                    <input");

WriteLiteral(" id=\"UserName\"");

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

WriteLiteral(" style=\"clear:both\"");

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
