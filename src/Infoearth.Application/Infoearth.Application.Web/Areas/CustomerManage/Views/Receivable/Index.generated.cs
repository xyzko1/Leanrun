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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CustomerManage/Views/Receivable/Index.cshtml")]
    public partial class _Areas_CustomerManage_Views_Receivable_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_CustomerManage_Views_Receivable_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
  
    ViewBag.Title = "应收账款";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        InitialPage();\r\n        GetGrid();\r\n    " +
"});\r\n    //初始化页面\r\n    function InitialPage() {\r\n        //收款状态\r\n        $(\"#Paym" +
"entState\").ComboBox({\r\n            description: \"==请选择==\",\r\n        });\r\n       " +
" //resize重设(表格、树形)宽高\r\n        $(window).resize(function (e) {\r\n            windo" +
"w.setTimeout(function () {\r\n                $(\'#gridTable\').setGridWidth(($(\'.gr" +
"idPanel\').width()));\r\n                $(\"#gridTable\").setGridHeight($(window).he" +
"ight() - 136.5);\r\n            }, 200);\r\n            e.stopPropagation();\r\n      " +
"  });\r\n    }\r\n    //加载表格\r\n    function GetGrid() {\r\n        var selectedRowIndex" +
" = 0;\r\n        var $gridTable = $(\'#gridTable\');\r\n        $gridTable.jqGrid({\r\n " +
"           url: \"../../CustomerManage/Receivable/GetPaymentPageListJson\",\r\n     " +
"       postData: { queryJson: JSON.stringify($(\"#filter-form\").GetWebControls())" +
" },\r\n            datatype: \"json\",\r\n            height: $(window).height() - 136" +
".5,\r\n            autowidth: true,\r\n            colModel: [\r\n                { la" +
"bel: \'主键\', name: \'F_OrderId\', hidden: true },\r\n                { label: \"单据日期\", " +
"name: \"F_OrderDate\", width: 100, align: \"left\", formatter: \"date\", formatoptions" +
": { newformat: \'Y-m-d\' } },\r\n                { label: \"单据编号\", name: \"F_OrderCode" +
"\", width: 130, align: \"left\" },\r\n                { label: \"客户名称\", name: \"F_Custo" +
"merName\", width: 250, align: \"left\" },\r\n                { label: \"销售人员\", name: \"" +
"F_SellerName\", width: 80, align: \"left\" },\r\n                { label: \"应收金额\", nam" +
"e: \"F_Accounts\", width: 80, align: \"left\", formatter: \'number\', formatoptions: {" +
" thousandsSeparator: \"\", decimalPlaces: 2 } },\r\n                {\r\n             " +
"       label: \"已收金额\", name: \"F_ReceivedAmount\", width: 80, align: \"left\",\r\n     " +
"               formatter: function (cellvalue, options, rowObject) {\r\n          " +
"              return \"<span style=\'color:blue\'>\" + toDecimal(cellvalue) + \"</spa" +
"n>\"\r\n                    }\r\n                },\r\n                {\r\n             " +
"       label: \"未收金额\", name: \"F_Uncollected\", width: 80, align: \"left\",\r\n        " +
"            formatter: function (cellvalue, options, rowObject) {\r\n             " +
"           var uncollected = rowObject.Accounts - rowObject.ReceivedAmount;\r\n   " +
"                     return \"<span style=\'color:red\'>\" + toDecimal(uncollected) " +
"+ \"</span>\"\r\n                    }\r\n                },\r\n                { label:" +
" \"备注\", name: \"F_Description\", width: 200, align: \"left\" }\r\n            ],\r\n     " +
"       viewrecords: true,\r\n            rowNum: 30,\r\n            rowList: [30, 50" +
", 100],\r\n            pager: \"#gridPager\",\r\n            sortname: \'F_CreateDate\'," +
"\r\n            sortorder: \'desc\',\r\n            rownumbers: true,\r\n            shr" +
"inkToFit: false,\r\n            gridview: true,\r\n            onSelectRow: function" +
" () {\r\n                selectedRowIndex = $(\"#\" + this.id).getGridParam(\'selrow\'" +
");\r\n            },\r\n            gridComplete: function () {\r\n                $(\"" +
"#\" + this.id).setSelection(selectedRowIndex, false);\r\n            },\r\n          " +
"  subGrid: true,\r\n            subGridRowExpanded: function (subgrid_id, row_id) " +
"{\r\n                var orderId = $gridTable.jqGrid(\'getRowData\', row_id)[\'F_Orde" +
"rId\'];\r\n                var subgrid_table_id = subgrid_id + \"_t\";\r\n             " +
"   $(\"#\" + subgrid_id).html(\"<table id=\'\" + subgrid_table_id + \"\'></table>\");\r\n " +
"               $(\"#\" + subgrid_table_id).jqGrid({\r\n                    url: \"../" +
"../CustomerManage/Receivable/GetPaymentRecordJson\",\r\n                    postDat" +
"a: { orderId: orderId },\r\n                    datatype: \"json\",\r\n               " +
"     height: \"100%\",\r\n                    colModel: [\r\n                        {" +
"\r\n                            label: \"收款方式\", name: \"F_PaymentMode\", width: 80, a" +
"lign: \"center\",\r\n                            formatter: function (cellvalue, opt" +
"ions, rowObject) {\r\n                                if (cellvalue != null) {\r\n  " +
"                                  return top.learun.data.get([\"Client_PaymentMod" +
"e\", cellvalue]);\r\n                                } else {\r\n                    " +
"                return \"\";\r\n                                }\r\n                 " +
"           }\r\n                        },\r\n                        {\r\n           " +
"                 label: \"收款账户\", name: \"F_PaymentAccount\", width: 100, align: \"le" +
"ft\",\r\n                            formatter: function (cellvalue, options, rowOb" +
"ject) {\r\n                                if (cellvalue != null) {\r\n             " +
"                       return top.learun.data.get([\"Client_PaymentAccount\", cell" +
"value]);\r\n                                } else {\r\n                            " +
"        return \"\";\r\n                                }\r\n                         " +
"   }\r\n                        },\r\n                        { label: \'收款日期\', name:" +
" \"F_PaymentTime\", width: 100, align: \"left\", formatter: \"date\", formatoptions: {" +
" newformat: \'Y-m-d\' } },\r\n                        { label: \'收款金额\', name: \'F_Paym" +
"entPrice\', width: 100, align: \'left\', formatter: \'number\', formatoptions: { thou" +
"sandsSeparator: \"\", decimalPlaces: 2 } },\r\n                        { label: \"创建人" +
"员\", name: \"F_CreateUserName\", width: 100, align: \"left\" },\r\n                    " +
"    { label: \"创建时间\", name: \"F_CreateDate\", width: 130, align: \'left\', sortable: " +
"true, formatter: \"date\", formatoptions: { srcformat: \'Y-m-d H:i\', newformat: \'Y-" +
"m-d H:i\' } },\r\n                        { label: \'备注信息\', name: \'F_Description\', w" +
"idth: 200, align: \'left\' }\r\n                    ],\r\n                    caption:" +
" \"收款记录\",\r\n                    rowNum: \"1000\",\r\n                    rownumbers: t" +
"rue,\r\n                    shrinkToFit: false,\r\n                    gridview: tru" +
"e,\r\n                    hidegrid: false\r\n                });\r\n            }\r\n   " +
"     });\r\n        //点击时间范围（今天、近7天、近一个月、近三个月）\r\n        $(\"#time_horizon a.btn-def" +
"ault\").click(function () {\r\n            $(\"#time_horizon a.btn-default\").removeC" +
"lass(\"active\");\r\n            $(this).addClass(\"active\");\r\n            switch ($(" +
"this).attr(\'data-value\')) {\r\n                case \"1\"://今天\r\n                    " +
"$(\"#StartTime\").val(\"");

            
            #line 124 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
                                    Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    $(\"#EndTime\").val(\"");

            
            #line 125 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
                                  Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    break;\r\n                case \"2\"://近7天\r\n                " +
"    $(\"#StartTime\").val(\"");

            
            #line 128 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
                                    Write(DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    $(\"#EndTime\").val(\"");

            
            #line 129 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
                                  Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    break;\r\n                case \"3\"://近一个月\r\n               " +
"     $(\"#StartTime\").val(\"");

            
            #line 132 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
                                    Write(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    $(\"#EndTime\").val(\"");

            
            #line 133 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
                                  Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    break;\r\n                case \"4\"://近三个月\r\n               " +
"     $(\"#StartTime\").val(\"");

            
            #line 136 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
                                    Write(DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    $(\"#EndTime\").val(\"");

            
            #line 137 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
                                  Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n                    break;\r\n                default:\r\n                    br" +
"eak;\r\n            }\r\n            $(\"#SelectedStartTime\").html($(\"#StartTime\").va" +
"l());\r\n            $(\"#SelectedEndTime\").html($(\"#EndTime\").val());\r\n           " +
" $(\'#btn_Search\').trigger(\"click\");\r\n        });\r\n        //查询点击事件\r\n        $(\"#" +
"btn_Search\").click(function () {\r\n            if (!$(\".ui-filter-text\").next(\'.u" +
"i-filter-list\').is(\":hidden\")) {\r\n                $(\".ui-filter-text\").trigger(\"" +
"click\");\r\n            }\r\n            $(\"#SelectedStartTime\").html($(\"#StartTime\"" +
").val());\r\n            $(\"#SelectedEndTime\").html($(\"#EndTime\").val());\r\n       " +
"     var queryJson = $(\"#filter-form\").GetWebControls();\r\n            $gridTable" +
".jqGrid(\'setGridParam\', {\r\n                postData: { queryJson: JSON.stringify" +
"(queryJson) },\r\n                page: 1\r\n            }).trigger(\'reloadGrid\');\r\n" +
"        });\r\n    }\r\n    //收款\r\n    function btn_receipt() {\r\n        var orderId " +
"= $(\"#gridTable\").jqGridRowValue(\'F_OrderId\');\r\n        var orderCode = $(\"#grid" +
"Table\").jqGridRowValue(\'F_OrderCode\');\r\n        var customerName = $(\"#gridTable" +
"\").jqGridRowValue(\'F_CustomerName\');\r\n        if (checkedRow(orderId)) {\r\n      " +
"      dialogOpen({\r\n                id: \'ReceiptForm\',\r\n                title: \'" +
"收款录入【单号】- \' + orderCode,\r\n                url: \'/CustomerManage/Receivable/Recei" +
"ptForm?orderId=\' + orderId,\r\n                width: \"500px\",\r\n                he" +
"ight: \"415px\",\r\n                callBack: function (iframeId) {\r\n               " +
"     getInfoTop().frames[iframeId].AcceptClick();\r\n                }\r\n          " +
"  })\r\n        }\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n        <table>\r\n            <tr>\r\n                <td>查询条件</td>\r\n            " +
"    <td");

WriteLiteral(" style=\"padding-left: 10px;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"ui-filter\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"ui-filter-text\"");

WriteLiteral(">\r\n                            <strong");

WriteLiteral(" id=\"SelectedStartTime\"");

WriteLiteral(">");

            
            #line 187 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
                                                      Write(DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("</strong> 至 <strong");

WriteLiteral(" id=\"SelectedEndTime\"");

WriteLiteral(">");

            
            #line 187 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
                                                                                                                                               Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"ui-filter-list\"");

WriteLiteral(" style=\"width: 350px;\"");

WriteLiteral(">\r\n                            <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(" id=\"filter-form\"");

WriteLiteral(">\r\n                                <tr>\r\n                                    <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">单据日期：</th>\r\n                                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                        <input");

WriteLiteral(" id=\"Category\"");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" value=\"1\"");

WriteLiteral(" />\r\n                                        <div");

WriteLiteral(" style=\"float: left; width: 45%;\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" id=\"StartTime\"");

WriteLiteral(" readonly");

WriteLiteral(" type=\"text\"");

WriteAttribute("value", Tuple.Create(" value=\"", 9730), Tuple.Create("\"", 9788)
            
            #line 196 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
              , Tuple.Create(Tuple.Create("", 9738), Tuple.Create<System.Object, System.Int32>(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd")
            
            #line default
            #line hidden
, 9738), false)
);

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({maxDate:\'%y-%M-%d\'})\"");

WriteLiteral(">\r\n                                        </div>\r\n                              " +
"          <div");

WriteLiteral(" style=\"float: left; width: 10%; text-align: center;\"");

WriteLiteral(">至</div>\r\n                                        <div");

WriteLiteral(" style=\"float: left; width: 45%;\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" id=\"EndTime\"");

WriteLiteral(" readonly");

WriteLiteral(" type=\"text\"");

WriteAttribute("value", Tuple.Create(" value=\"", 10194), Tuple.Create("\"", 10233)
            
            #line 200 "..\..\Areas\CustomerManage\Views\Receivable\Index.cshtml"
           , Tuple.Create(Tuple.Create("", 10202), Tuple.Create<System.Object, System.Int32>(Infoearth.Util.Time.GetToday()
            
            #line default
            #line hidden
, 10202), false)
);

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({maxDate:\'%y-%M-%d\'})\"");

WriteLiteral(">\r\n                                        </div>\r\n                              " +
"      </td>\r\n                                </tr>\r\n                            " +
"    <tr>\r\n                                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">单据编号：</td>\r\n                                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                        <input");

WriteLiteral(" id=\"OrderCode\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                                    </td>\r\n                                </t" +
"r>\r\n                                <tr>\r\n                                    <t" +
"d");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">客户名称：</td>\r\n                                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                        <input");

WriteLiteral(" id=\"CustomerName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                                    </td>\r\n                                </t" +
"r>\r\n                                <tr>\r\n                                    <t" +
"d");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">销售人员：</td>\r\n                                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                        <input");

WriteLiteral(" id=\"SellerName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                                    </td>\r\n                                </t" +
"r>\r\n                            </table>\r\n                            <div");

WriteLiteral(" class=\"ui-filter-list-bottom\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" id=\"btn_Reset\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(">&nbsp;重&nbsp;&nbsp;置</a>\r\n                                <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">&nbsp;查&nbsp;&nbsp;询</a>\r\n                            </div>\r\n                  " +
"      </div>\r\n                    </div>\r\n                </td>\r\n               " +
" <td");

WriteLiteral(" style=\"padding-left: 10px;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"time_horizon\"");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" data-value=\"1\"");

WriteLiteral(">今天</a>\r\n                        <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" data-value=\"2\"");

WriteLiteral(">近7天</a>\r\n                        <a");

WriteLiteral(" class=\"btn btn-default active\"");

WriteLiteral(" data-value=\"3\"");

WriteLiteral(">近1个月</a>\r\n                        <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" data-value=\"4\"");

WriteLiteral(">近3个月</a>\r\n                    </div>\r\n                </td>\r\n            </tr>\r\n" +
"        </table>\r\n    </div>\r\n    <div");

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

WriteLiteral(" id=\"lr-receipt\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_receipt()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-rmb\"");

WriteLiteral("></i>&nbsp;收款</a>\r\n        </div>\r\n    </div>\r\n    <div");

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