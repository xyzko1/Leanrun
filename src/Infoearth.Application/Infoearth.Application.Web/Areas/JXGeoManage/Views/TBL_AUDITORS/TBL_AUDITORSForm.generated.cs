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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_AUDITORS/TBL_AUDITORSForm.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_AUDITORS_TBL_AUDITORSForm_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_AUDITORS_TBL_AUDITORSForm_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_AUDITORS\TBL_AUDITORSForm.cshtml"
  
    ViewBag.Title = "表单页面";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" style=\"margin-top: 20px; margin-right: 30px;\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">GUID</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"GUID\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">行政区划编码</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"DISTRICTCODE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">审计人名</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"NAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">登录名</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"LOGINNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n        </tr>\r\n       \r\n    </table>\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral(@"
<script>
    var keyValue = request('keyValue');
    $(function () {
        initControl();
    });
    //初始化控件
    function initControl() {
        //获取表单
        if (!!keyValue) {
            $.SetForm({
                url: ""../../JXGeoManage/TBL_AUDITORS/GetFormJson"",
                param: { keyValue: keyValue },
                success: function (data) {
                    $(""#form1"").SetWebControls(data);
            })
        }
        }
    }
    //保存表单;
    function AcceptClick() {
        if (!$('#form1').Validform()) {
            return false;
        }
        var postData = $(""#form1"").GetWebControls(keyValue);
        $.SaveForm({
            url: ""../../JXGeoManage/TBL_AUDITORS/SaveForm?keyValue="" + keyValue,
            param: postData,
            loading: ""正在保存数据..."",
            success: function () {
                      try {
                            getInfoTop().learun.currentIframe().$('#gridTable').trigger('reloadGrid');
                      } catch (e) {
                            window.parent.$('#gridTable').trigger('reloadGrid');
                      }
            }
        })
    }
</script>
");

});

        }
    }
}
#pragma warning restore 1591
