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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/ReportManage/Views/ReportDemo/Sales.cshtml")]
    public partial class _Areas_ReportManage_Views_ReportDemo_Sales_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_ReportManage_Views_ReportDemo_Sales_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
  
    ViewBag.Title = "销售报表";
    Layout = "~/Views/Shared/_ReportIndex.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        GetGrid();\r\n    })\r\n    function GetGrid" +
"() {\r\n        var $gridTable = $(\'#gridTable\');\r\n        $gridTable.jqGrid({\r\n  " +
"          url: \"../../ReportManage/ReportDemo/GetSalesJson\",\r\n            dataty" +
"pe: \"json\",\r\n            height: $(window).height() - 230.5,\r\n            autowi" +
"dth: true,\r\n            colModel: [\r\n                { name: \"date\", label: \"销售日" +
"期\", width: 80, align: \"center\" },\r\n                { name: \"billNo\", label: \"销售单" +
"据号\", width: 110, align: \"center\" },\r\n                { name: \"salesName\", label:" +
" \"销售人员\", width: 80 },\r\n                { name: \"buName\", label: \"客户\", width: 150" +
", align: \"left\" },\r\n                { name: \"invNo\", label: \"商品编号\", width: 100, " +
"align: \"left\" },\r\n                { name: \"invName\", label: \"商品名称\", width: 200, " +
"align: \"left\" },\r\n                { name: \"unit\", label: \"单位\", width: 80, align:" +
" \"center\" },\r\n                { name: \"location\", label: \"仓库\", width: 80 },\r\n   " +
"             { name: \"qty\", label: \"数量\", width: 80, align: \"left\" },\r\n          " +
"      { name: \"unitPrice\", label: \"单价\", width: 80, align: \"left\", formatter: \'nu" +
"mber\', formatoptions: { thousandsSeparator: \"\", decimalPlaces: 2 } },\r\n         " +
"       { name: \"amount\", label: \"金额\", width: 80, align: \"left\", formatter: \'numb" +
"er\', formatoptions: { thousandsSeparator: \"\", decimalPlaces: 2 } },\r\n           " +
"     { name: \"description\", label: \"备注\", width: 150, align: \"left\" }\r\n          " +
"  ],\r\n            viewrecords: true,\r\n            rowNum: 1000,\r\n            foo" +
"terrow: true,\r\n            gridComplete: function () {\r\n                var tota" +
"lamount = $(this).getCol(\"amount\", false, \"sum\");\r\n                //合计\r\n       " +
"         $(this).footerData(\"set\", {\r\n                    \"location\": \"合计：\",\r\n  " +
"                  \"amount\": totalamount,\r\n                });\r\n                $" +
"(\'table.ui-jqgrid-ftable td\').prevUntil().css(\"border-right-color\", \"#fff\");\r\n  " +
"          }\r\n        });\r\n        //点击时间范围（今天、近7天、近一个月、近三个月）\r\n        $(\"#time_h" +
"orizon a.btn-default\").click(function () {\r\n            $(\"#time_horizon a.btn-d" +
"efault\").removeClass(\"active\");\r\n            $(this).addClass(\"active\");\r\n      " +
"      switch ($(this).attr(\'data-value\')) {\r\n                case \"1\"://今天\r\n    " +
"                $(\"#StartTime\").val(\"");

            
            #line 49 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
                                    Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    $(\"#EndTime\").val(\"");

            
            #line 50 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
                                  Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    break;\r\n                case \"2\"://近7天\r\n                " +
"    $(\"#StartTime\").val(\"");

            
            #line 53 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
                                    Write(DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    $(\"#EndTime\").val(\"");

            
            #line 54 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
                                  Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    break;\r\n                case \"3\"://近一个月\r\n               " +
"     $(\"#StartTime\").val(\"");

            
            #line 57 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
                                    Write(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    $(\"#EndTime\").val(\"");

            
            #line 58 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
                                  Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    break;\r\n                case \"4\"://近三个月\r\n               " +
"     $(\"#StartTime\").val(\"");

            
            #line 61 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
                                    Write(DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    $(\"#EndTime\").val(\"");

            
            #line 62 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
                                  Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    break;\r\n                default:\r\n                    br" +
"eak;\r\n            }\r\n            $(\"#SelectedStartTime\").html($(\"#StartTime\").va" +
"l());\r\n            $(\"#SelectedEndTime\").html($(\"#EndTime\").val());\r\n        });" +
"\r\n        //查询条件\r\n        $(\"#queryCondition .dropdown-menu li\").click(function " +
"() {\r\n            var text = $(this).find(\'a\').html();\r\n            var value = " +
"$(this).find(\'a\').attr(\'data-value\');\r\n            $(\"#queryCondition .dropdown-" +
"text\").html(text).attr(\'data-value\', value)\r\n        });\r\n        //查询事件\r\n      " +
"  $(\"#btn_Search\").click(function () {\r\n            var queryJson = {\r\n         " +
"       condition: $(\"#queryCondition\").find(\'.dropdown-text\').attr(\'data-value\')" +
",\r\n                keyword: $(\"#txt_Keyword\").val()\r\n            }\r\n            " +
"$gridTable.jqGrid(\'setGridParam\', {\r\n                postData: { queryJson: JSON" +
".stringify(queryJson) },\r\n                page: 1\r\n            }).trigger(\'reloa" +
"dGrid\');\r\n        });\r\n        //查询回车\r\n        $(\'#txt_Keyword\').bind(\'keypress\'" +
", function (event) {\r\n            if (event.keyCode == \"13\") {\r\n                " +
"$(\'#btn_Search\').trigger(\"click\");\r\n            }\r\n        });\r\n    }\r\n    //打印\r" +
"\n    function btn_print() {\r\n        $(\"#gridPanel\").printTable();\r\n    }\r\n    /" +
"/导出\r\n    function btn_export() {\r\n        dialogOpen({\r\n            id: \"ExcelIE" +
"xportDialog\",\r\n            title: \'导出销售报表\',\r\n            url: \'/Utility/ExcelExp" +
"ortForm?gridId=gridTable\',\r\n            width: \"500px\",\r\n            height: \"38" +
"0px\",\r\n            callBack: function (iframeId) {\r\n                getInfoTop()" +
".frames[iframeId].AcceptClick();\r\n            }, btn: [\'导出Excel\', \'关闭\']\r\n       " +
" });\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" class=\"ui-report\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n            <table>\r\n                <tr>\r\n                    <td>查询条件</td>\r\n" +
"                    <td");

WriteLiteral(" style=\"padding-left: 10px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"ui-filter\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"ui-filter-text\"");

WriteLiteral(">\r\n                                <strong");

WriteLiteral(" id=\"SelectedStartTime\"");

WriteLiteral(">");

            
            #line 121 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
                                                          Write(DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("</strong> 至 <strong");

WriteLiteral(" id=\"SelectedEndTime\"");

WriteLiteral(">");

            
            #line 121 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
                                                                                                                                                   Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n                            </div>\r\n                            <div");

WriteLiteral(" class=\"ui-filter-list\"");

WriteLiteral(" style=\"width: 350px;\"");

WriteLiteral(">\r\n                                <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(" id=\"filter-form\"");

WriteLiteral(">\r\n                                    <tr>\r\n                                    " +
"    <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">单据日期：</th>\r\n                                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" id=\"Category\"");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" value=\"1\"");

WriteLiteral(" />\r\n                                            <div");

WriteLiteral(" style=\"float: left; width: 45%;\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" id=\"StartTime\"");

WriteLiteral(" readonly");

WriteLiteral(" type=\"text\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6078), Tuple.Create("\"", 6118)
            
            #line 130 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
                  , Tuple.Create(Tuple.Create("", 6086), Tuple.Create<System.Object, System.Int32>(Infoearth.Util.Time.GetDate(-7)
            
            #line default
            #line hidden
, 6086), false)
);

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({maxDate:\'%y-%M-%d\'})\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <div");

WriteLiteral(" style=\"float: left; width: 10%; text-align: center;\"");

WriteLiteral(">至</div>\r\n                                            <div");

WriteLiteral(" style=\"float: left; width: 45%;\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" id=\"EndTime\"");

WriteLiteral(" readonly");

WriteLiteral(" type=\"text\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6540), Tuple.Create("\"", 6579)
            
            #line 134 "..\..\Areas\ReportManage\Views\ReportDemo\Sales.cshtml"
                , Tuple.Create(Tuple.Create("", 6548), Tuple.Create<System.Object, System.Int32>(Infoearth.Util.Time.GetToday()
            
            #line default
            #line hidden
, 6548), false)
);

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({maxDate:\'%y-%M-%d\'})\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"              </td>\r\n                                    </tr>\r\n                " +
"                    <tr>\r\n                                        <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">单据编号：</td>\r\n                                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" id=\"OrderCode\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                                        </td>\r\n                               " +
"     </tr>\r\n                                    <tr>\r\n                          " +
"              <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">客户名称：</td>\r\n                                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" id=\"CustomerName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                                        </td>\r\n                               " +
"     </tr>\r\n                                    <tr>\r\n                          " +
"              <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">商品编号：</td>\r\n                                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" id=\"GoodsCode\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                                        </td>\r\n                               " +
"     </tr>\r\n                                    <tr>\r\n                          " +
"              <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">商品名称：</td>\r\n                                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" id=\"GoodsName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                                        </td>\r\n                               " +
"     </tr>\r\n                                </table>\r\n                          " +
"      <div");

WriteLiteral(" class=\"ui-filter-list-bottom\"");

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" id=\"btn_Reset\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(">&nbsp;重&nbsp;&nbsp;置</a>\r\n                                    <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">&nbsp;查&nbsp;&nbsp;询</a>\r\n                                </div>\r\n              " +
"              </div>\r\n                        </div>\r\n                    </td>\r" +
"\n                    <td");

WriteLiteral(" style=\"padding-left: 10px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" id=\"time_horizon\"");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" data-value=\"1\"");

WriteLiteral(">今天</a>\r\n                            <a");

WriteLiteral(" class=\"btn btn-default active\"");

WriteLiteral(" data-value=\"2\"");

WriteLiteral(">近7天</a>\r\n                            <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" data-value=\"3\"");

WriteLiteral(">近1个月</a>\r\n                            <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" data-value=\"4\"");

WriteLiteral(">近3个月</a>\r\n                        </div>\r\n                    </td>\r\n           " +
"     </tr>\r\n            </table>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"learun.reload();\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>&nbsp;刷新</a>\r\n                <a");

WriteLiteral(" id=\"lr-print\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_print()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-print\"");

WriteLiteral("></i>&nbsp;打印</a>\r\n                <a");

WriteLiteral(" id=\"lr-export\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_export()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-sign-out\"");

WriteLiteral("></i>&nbsp;导出</a>\r\n            </div>\r\n            \"\"\r\n        </div>\r\n        <d" +
"iv");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(" id=\"gridPanel\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"printArea\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"grid-title\"");

WriteLiteral(">销售明细表</div>\r\n            <div");

WriteLiteral(" class=\"grid-subtitle\"");

WriteLiteral(">日期: 2012-03-05 至 2016-03-28</div>\r\n            <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
