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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CustomerManage/Views/Order/Detail.cshtml")]
    public partial class _Areas_CustomerManage_Views_Order_Detail_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_CustomerManage_Views_Order_Detail_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\CustomerManage\Views\Order\Detail.cshtml"
  
    ViewBag.Title = "订单详细";
    Layout = "~/Views/Shared/_OrderForm.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    $(function () {\r\n       " +
" InitialPage();\r\n        GetOrderEntryGrid();\r\n        InitControl();\r\n    });\r\n" +
"    //初始化页面\r\n    function InitialPage() {\r\n        $(\".bills\").height($(window)." +
"height() - 88);\r\n        //resize重设(表格、树形)宽高\r\n        $(window).resize(function " +
"(e) {\r\n            window.setTimeout(function () {\r\n                $(\'#gridTabl" +
"e\').setGridWidth(($(\'.gridPanel\').width()));\r\n                $(\".bills\").height" +
"($(window).height() - 88);\r\n            }, 200);\r\n            e.stopPropagation(" +
");\r\n        });\r\n        //客户名称\r\n        $(\"#F_CustomerId\").ComboBox({\r\n        " +
"    url: \"../../CustomerManage/Customer/GetListJson\",\r\n            id: \"F_Custom" +
"erId\",\r\n            text: \"F_FullName\",\r\n            description: \"==请选择==\",\r\n  " +
"          height: \"360px\",\r\n            width: \"280px\",\r\n            allowSearch" +
": true\r\n        });\r\n        //销售人员\r\n        $(\"#F_SellerId\").ComboBoxTree({\r\n  " +
"          url: \"../../BaseManage/User/GetTreeJson\",\r\n            description: \"=" +
"=请选择==\",\r\n            height: \"360px\",\r\n            width: \"280px\",\r\n           " +
" allowSearch: true\r\n        });\r\n        //收款方式\r\n        $(\"#F_PaymentMode\").Com" +
"boBox({\r\n            url: \"../../SystemManage/DataItemDetail/GetDataItemListJson" +
"\",\r\n            param: { EnCode: \"Client_PaymentMode\" },\r\n            id: \"F_Ite" +
"mValue\",\r\n            text: \"F_ItemName\",\r\n            description: \"==请选择==\",\r\n" +
"            height: \"200px\"\r\n        });\r\n    }\r\n    //初始化控件\r\n    function InitC" +
"ontrol() {\r\n        //获取表单\r\n        if (!!keyValue) {\r\n            $.SetForm({\r\n" +
"                url: \"../../CustomerManage/Order/GetFormJson\",\r\n                " +
"param: { keyValue: keyValue },\r\n                success: function (data) {\r\n    " +
"                //主表\r\n                    var order = data.order;\r\n             " +
"       $(\"#form1\").SetWebControls(order);\r\n                    $(\"#F_DiscountSum" +
"\").val(toDecimal(order.F_DiscountSum));\r\n                    $(\"#F_Accounts\").va" +
"l(toDecimal(order.F_Accounts));\r\n                    $(\"#F_SaleCost\").val(toDeci" +
"mal(order.F_SaleCost));\r\n                    //明细\r\n                    var order" +
"Entry = data.orderEntry;\r\n                    $(\"#gridTable\").find(\'[role=row]\')" +
".each(function (i) {\r\n                        var row = orderEntry[i - 1];\r\n    " +
"                    if (row != undefined) {\r\n                            $(this)" +
".find(\'td[aria-describedby=\"gridTable_F_OrderEntryId\"]\').html(row.F_OrderEntryId" +
");\r\n                            $(this).find(\'td[aria-describedby=\"gridTable_F_P" +
"roductName\"]\').html(row.F_ProductName);\r\n                            $(this).fin" +
"d(\'td[aria-describedby=\"gridTable_F_ProductCode\"]\').html(row.F_ProductCode);\r\n  " +
"                          $(this).find(\'td[aria-describedby=\"gridTable_F_UnitId\"" +
"]\').html(row.F_UnitId);\r\n                            $(this).find(\'td[aria-descr" +
"ibedby=\"gridTable_F_Qty\"]\').html(toDecimal(row.F_Qty));\r\n                       " +
"     $(this).find(\'td[aria-describedby=\"gridTable_F_Price\"]\').html(toDecimal(row" +
".F_Price));\r\n                            $(this).find(\'td[aria-describedby=\"grid" +
"Table_F_Amount\"]\').html(toDecimal(row.F_Amount));\r\n                            $" +
"(this).find(\'td[aria-describedby=\"gridTable_F_TaxRate\"]\').html(row.F_TaxRate);\r\n" +
"                            $(this).find(\'td[aria-describedby=\"gridTable_F_Taxpr" +
"ice\"]\').html(toDecimal(row.F_Taxprice));\r\n                            $(this).fi" +
"nd(\'td[aria-describedby=\"gridTable_F_Tax\"]\').html(toDecimal(row.F_Tax));\r\n      " +
"                      $(this).find(\'td[aria-describedby=\"gridTable_F_TaxAmount\"]" +
"\').html(toDecimal(row.F_TaxAmount));\r\n                            $(this).find(\'" +
"td[aria-describedby=\"gridTable_F_Description\"]\').html(row.F_Description);\r\n     " +
"                   }\r\n                    });\r\n                    //合计\r\n       " +
"             var TotalQty = 0.00, TotalPrice = 0.00, TotalAmount = 0.00, TotalTa" +
"xprice = 0.00, TotalTax = 0.00, TotalTaxAmount = 0.00;\r\n                    $(\"#" +
"gridTable\").find(\'[role=row]\').each(function (i) {\r\n                        var " +
"Qty = $(this).find(\'td:eq(5)\').html();\r\n                        if (Qty != \"\" &&" +
" Qty != undefined && Qty != \'&nbsp;\') {\r\n                            TotalQty +=" +
" Number(Qty);\r\n                        }\r\n                        var Price = $(" +
"this).find(\'td:eq(6)\').html();\r\n                        if (Price != \"\" && Price" +
" != undefined && Price != \'&nbsp;\') {\r\n                            TotalPrice +=" +
" Number(Price);\r\n                        }\r\n                        var Amount =" +
" $(this).find(\'td:eq(7)\').html();\r\n                        if (Amount != \"\" && A" +
"mount != undefined && Amount != \'&nbsp;\') {\r\n                            TotalAm" +
"ount += Number(Amount);\r\n                        }\r\n                        var " +
"Taxprice = $(this).find(\'td:eq(9)\').html();\r\n                        if (Taxpric" +
"e != \"\" && Taxprice != undefined && Taxprice != \'&nbsp;\') {\r\n                   " +
"         TotalTaxprice += Number(Taxprice);\r\n                        }\r\n        " +
"                var Tax = $(this).find(\'td:eq(10)\').html();\r\n                   " +
"     if (Tax != \"\" && Tax != undefined) {\r\n                            TotalTax " +
"+= Number(Tax);\r\n                        }\r\n                        var TaxAmoun" +
"t = $(this).find(\'td:eq(11)\').html();\r\n                        if (TaxAmount != " +
"\"\" && TaxAmount != undefined && TaxAmount != \'&nbsp;\') {\r\n                      " +
"      TotalTaxAmount += Number(TaxAmount);\r\n                        }\r\n         " +
"           });\r\n                    $(\"#TotalQty\").text(toDecimal(TotalQty));\r\n " +
"                   $(\"#TotalPrice\").text(toDecimal(TotalPrice));\r\n              " +
"      $(\"#TotalAmount\").text(toDecimal(TotalAmount));\r\n                    $(\"#T" +
"otalTaxprice\").text(toDecimal(TotalTaxprice));\r\n                    $(\"#TotalTax" +
"\").text(toDecimal(TotalTax));\r\n                    $(\"#TotalTaxAmount\").text(toD" +
"ecimal(TotalTaxAmount));\r\n                }\r\n            });\r\n        }\r\n    }\r\n" +
"    //加载明细\r\n    function GetOrderEntryGrid() {\r\n        var $grid = $(\"#gridTabl" +
"e\");\r\n        $grid.jqGrid({\r\n            unwritten: false,\r\n            datatyp" +
"e: \"local\",\r            height: \'100%\',\r\n            autowidth: true,\r\n         " +
"   colModel: [\r\n                { label: \'主键\', name: \'F_OrderEntryId\', hidden: t" +
"rue },\r\n                { label: \'商品名称\', name: \"F_ProductName\", width: 260, alig" +
"n: \'left\', sortable: false, resizable: false },\r\n                { label: \'商品编号\'" +
", name: \"F_ProductCode\", width: 100, align: \'center\', sortable: false, resizable" +
": false },\r\n                { label: \'单位\', name: \"F_UnitId\", width: 100, align: " +
"\'center\', sortable: false, resizable: false },\r\n                { label: \'数量\', n" +
"ame: \'F_Qty\', width: 80, align: \'center\', sortable: false, resizable: false },\r\n" +
"                { label: \'单价\', name: \'F_Price\', width: 80, align: \'center\', sort" +
"able: false, resizable: false },\r\n                { label: \'金额\', name: \'F_Amount" +
"\', width: 80, align: \'center\', sortable: false, resizable: false },\r\n           " +
"     { label: \'税率(%)\', name: \'F_TaxRate\', width: 80, align: \'center\', sortable: " +
"false, resizable: false },\r\n                { label: \'含税单价\', name: \'F_Taxprice\'," +
" width: 80, align: \'center\', sortable: false, resizable: false },\r\n             " +
"   { label: \'税额\', name: \'F_Tax\', width: 80, align: \'center\', sortable: false, re" +
"sizable: false },\r\n                { label: \'含税金额\', name: \'F_TaxAmount\', width: " +
"80, align: \'center\', sortable: false, resizable: false },\r\n                { lab" +
"el: \'说明信息\', name: \'F_Description\', width: 200, align: \'left\', sortable: false, r" +
"esizable: false }\r            ],\r\n            pager: false,\r\n            rownumb" +
"ers: true,\r\n            shrinkToFit: false,\r\n            gridview: true,\r\n      " +
"      footerrow: true,\r\n            gridComplete: function () {\r\n               " +
" //合计\r\n                $(this).footerData(\"set\", {\r\n                    \"F_UnitI" +
"d\": \"合计：\",\r\n                    \"F_Qty\": \"<span id=\'TotalQty\'>0.00</span>\",\r\n   " +
"                 \"F_Price\": \"<span id=\'TotalPrice\'>0.00</span>\",\r\n              " +
"      \"F_Amount\": \"<span id=\'TotalAmount\'>0.00</span>\",\r\n                    \"F_" +
"Taxprice\": \"<span id=\'TotalTaxprice\'>0.00</span>\",\r\n                    \"F_Tax\":" +
" \"<span id=\'TotalTax\'>0.00</span>\",\r\n                    \"F_TaxAmount\": \"<span i" +
"d=\'TotalTaxAmount\'>0.00</span>\"\r\n                });\r\n                $(\'table.u" +
"i-jqgrid-ftable td[aria-describedby=\"gridTable_F_UnitId\"]\').prevUntil().css(\"bor" +
"der-right-color\", \"#fff\");\r\n            }\r\n        });\r\n        //表头合并\r\n        " +
"$grid.jqGrid(\'setGroupHeaders\', {\r\n            useColSpanStyle: true,\r\n         " +
"   groupHeaders: [\r\n              { startColumnName: \'F_ProductName\', numberOfCo" +
"lumns: 3, titleText: \'商品信息\' },\r\n              { startColumnName: \'F_Qty\', number" +
"OfColumns: 7, titleText: \'价格信息\' }\r\n            ]\r\n        });\r\n        //默认添加13行" +
" 空行\r\n        for (var i = 1; i < 13; i++) {\r\n            var rowdata = {\r\n      " +
"          F_OrderEntryId: \'\',\r\n                F_ProductName: \'\',\r\n             " +
"   F_ProductCode: \'\',\r\n                F_UnitId: \'\',\r\n                F_Qty: \'\'," +
"\r\n                F_Price: \'\',\r\n                F_Amount: \'\',\r\n                F" +
"_TaxRate: \'\',\r\n                F_Taxprice: \'\',\r\n                F_Tax: \'\',\r\n    " +
"            F_TaxAmount: \'\',\r\n                F_Description: \'\',\r\n            }\r" +
"\n            $grid.jqGrid(\'addRowData\', i, rowdata);\r\n        };\r\n    }\r\n    //打" +
"印\r\n    function btn_print() {\r\n        $(\".bills\").printTable();\r\n    }\r\n    //导" +
"出\r\n    function btn_export() {\r\n        location.href = \"/CustomerManage/Order/E" +
"xportOrderEntry?orderId=\" + keyValue;\r\n    }\r\n    //前单\r\n    function btn_prev() " +
"{\r\n        $.ajax({\r\n            url: \"../../CustomerManage/Order/GetPrevJson?ke" +
"yValue=\" + keyValue,\r\n            type: \"get\",\r\n            dataType: \"json\",\r\n " +
"           async: false,\r\n            success: function (data) {\r\n              " +
"  if (data != null) {\r\n                    var src = top.contentPath + \"/Custome" +
"rManage/Order/Detail?keyValue=\" + data.F_OrderId;\r\n                    window.lo" +
"cation = src;\r\n                    $.currentIframe().att(\'src\', \'src\');\r\n       " +
"         }\r\n            }\r\n        });\r\n    }\r\n    //后单\r\n    function btn_next()" +
" {\r\n        $.ajax({\r\n            url: \"../../CustomerManage/Order/GetNextJson?k" +
"eyValue=\" + keyValue,\r\n            type: \"get\",\r\n            dataType: \"json\",\r\n" +
"            async: false,\r\n            success: function (data) {\r\n             " +
"   if (data != null) {\r\n                    var src = top.contentPath + \"/Custom" +
"erManage/Order/Detail?keyValue=\" + data.F_OrderId;\r\n                    window.l" +
"ocation = src;\r\n                    $.currentIframe().att(\'src\', \'src\');\r\n      " +
"          }\r\n            }\r\n        });\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" class=\"bills\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"printArea\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(" style=\"width: 100%; margin-bottom: 10px;\"");

WriteLiteral(">\r\n            <tr>\r\n                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width: 60px;\"");

WriteLiteral(">客户名称</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"F_CustomerId\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral("></div>\r\n                </td>\r\n                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">销售人员</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"F_SellerId\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral("></div>\r\n                </td>\r\n                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">单据日期</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"F_OrderDate\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                </td>\r\n                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">单据编号</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"F_OrderCode\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" onfocus=\"learun.isNumber(this.id)\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n        </table>\r\n    </div>\r\n    " +
"<div");

WriteLiteral(" class=\"gridPanel printArea\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"printArea\"");

WriteLiteral(">\r\n        <textarea");

WriteLiteral(" id=\"F_Description\"");

WriteLiteral(" placeholder=\"暂无备注信息\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"width: 100%; height: 50px; margin-top: 10px;\"");

WriteLiteral("></textarea>\r\n        <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(" style=\"width: 100%; margin-top: 5px;\"");

WriteLiteral(">\r\n            <tr>\r\n                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width: 60px;\"");

WriteLiteral(">优惠金额</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"F_DiscountSum\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" value=\"0.00\"");

WriteLiteral(" />\r\n                </td>\r\n                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">收款金额</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"F_Accounts\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" value=\"0.00\"");

WriteLiteral(" />\r\n                </td>\r\n                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">收款日期</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"F_PaymentDate\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                </td>\r\n                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">收款方式</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"F_PaymentMode\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral("></div>\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n            " +
"    <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width: 60px;\"");

WriteLiteral(">销售费用</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"F_SaleCost\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" value=\"0.00\"");

WriteLiteral(" />\r\n                </td>\r\n                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">制单人员</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"F_CreateUserName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">合同编号</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"F_ContractCode\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                </td>\r\n                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">合同附件</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"F_ContractFile\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                " +
"<th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">摘要信息</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"7\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"F_AbstractInfo\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n        </table>\r\n    </div>\r\n</di" +
"v>\r\n<div");

WriteLiteral(" id=\"bottomField\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n        <a");

WriteLiteral(" id=\"lr-print\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_print()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-print\"");

WriteLiteral("></i>&nbsp;打印</a>\r\n        <a");

WriteLiteral(" id=\"lr-export\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_export()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-sign-out\"");

WriteLiteral("></i>&nbsp;导出</a>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n        <a");

WriteLiteral(" id=\"lr-prev\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_prev()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-backward\"");

WriteLiteral("></i>&nbsp;前单</a>\r\n        <a");

WriteLiteral(" id=\"lr-next\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_next()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-forward\"");

WriteLiteral("></i>&nbsp;后单</a>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
