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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CustomerManage/Views/Invoice/Form.cshtml")]
    public partial class _Areas_CustomerManage_Views_Invoice_Form_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_CustomerManage_Views_Invoice_Form_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\CustomerManage\Views\Invoice\Form.cshtml"
  ;
  ViewBag.Title = "表单页面";
  Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral(@"
<script>
    var keyValue = request('keyValue');
    $(function () {
        initControl();
    });
    //初始化控件
    function initControl() {
        //客户名称
        $(""#F_CustomerId"").ComboBox({
            url: ""../../CustomerManage/Customer/GetListJson"",
            id: ""F_CustomerId"",
            text: ""F_FullName"",
            description: ""==请选择=="",
            height: ""220px"",
            allowSearch: true
        });
        //获取表单
        if (!!keyValue) {
            $.SetForm({
                url: ""../../CustomerManage/Invoice/GetFormJson"",
                param: { keyValue: keyValue },
                success: function (data) {
                    $(""#form1"").SetWebControls(data);
                }
            })
        }
    }
    //保存表单;
    function AcceptClick() {
        if (!$('#form1').Validform()) {
            return false;
        }
        var postData = $(""#form1"").GetWebControls(keyValue);
        postData[""F_CustomerName""] = $(""#F_CustomerId"").attr('data-text');
        $.SaveForm({
            url: ""../../CustomerManage/Invoice/SaveForm?keyValue="" + keyValue,
            param: postData,
            loading: ""正在保存数据..."",
            success: function () {
                $.currentIframe().$(""#gridTable"").trigger(""reloadGrid"");
            }
        })
    }
</script>
<div");

WriteLiteral(" style=\"margin-top: 20px; margin-right: 30px;\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" >客户名称</th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_CustomerId\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral("></div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 4px;\"");

WriteLiteral(">开票信息</th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <textarea");

WriteLiteral(" id=\"F_InvoiceContent\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"height: 230px;\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral("></textarea>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591