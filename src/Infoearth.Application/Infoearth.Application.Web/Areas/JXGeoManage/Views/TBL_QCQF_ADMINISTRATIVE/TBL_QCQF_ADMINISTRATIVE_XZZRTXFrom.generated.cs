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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_QCQF_ADMINISTRATIVE/TBL_QCQF_ADMINISTRATIVE_XZZRTXF" +
        "rom.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_QCQF_ADMINISTRATIVE_TBL_QCQF_ADMINISTRATIVE_XZZRTXFrom_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_QCQF_ADMINISTRATIVE_TBL_QCQF_ADMINISTRATIVE_XZZRTXFrom_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_QCQF_ADMINISTRATIVE\TBL_QCQF_ADMINISTRATIVE_XZZRTXFrom.cshtml"
  
    ViewBag.Title = "表单页面";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral(@"

<style>
    .center_div {
        line-height: 40px;
        text-align: center;
    }

    .spans {
        display: inline-block;
        padding-right: 20px;
        width: 120px;
        text-align: right;
        line-height: 40px;
        white-space: nowrap;
    }

    .center_div input {
        width: 26% !important;
        min-width: 170px !important;
    }
</style>
<div");

WriteLiteral(" id=\"form1\"");

WriteLiteral(">\n    <div");

WriteLiteral(" style=\"width: 100%;background: #fff; padding: 36px 0 0 0\"");

WriteLiteral(">\n        <div");

WriteLiteral(" class=\"center_div\"");

WriteLiteral(">\n            <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">村组名称:</span><input");

WriteLiteral(" id=\"VILLAGENAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control XZQH\"");

WriteLiteral(" style=\"display:inline-block;\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\n            <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">乡镇名称:</span><input");

WriteLiteral(" id=\"TOWNNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control XZQH\"");

WriteLiteral(" style=\"display:inline-block;\"");

WriteLiteral(" />\n            <input");

WriteLiteral(" id=\"TOWNCODE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" />\n        </div>\n        <div");

WriteLiteral(" class=\"center_div\"");

WriteLiteral(">\n            ");

WriteLiteral("\n            ");

WriteLiteral("\n            <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">联系人:</span><input");

WriteLiteral(" id=\"USERNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"display:inline-block;\"");

WriteLiteral(" />\n            <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">手机:</span><input");

WriteLiteral(" id=\"Telephone\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"display:inline-block;\"");

WriteLiteral(" />\n        </div>\n        <div");

WriteLiteral(" class=\"center_div\"");

WriteLiteral(" style=\"margin-top:8px;\"");

WriteLiteral(">\n            <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">描述:</span>\n            <textarea");

WriteLiteral(" id=\"MEMO\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"display:inline-block;width:calc(43% + 196px);vertical-align:middle\"");

WriteLiteral("></textarea>\n        </div>\n    </div>\n</div>\n\n");

DefineSection("Scripts", () => {

WriteLiteral(@"
<script>
    var keyValue = request('keyValue');
    var TOWNCODE = request('TOWNCODE');
    var TOWNNAME = request('TOWNNAME');
    $(function () {
        initControl();

    });
    //初始化控件
    function initControl() {
        //获取表单
        if (keyValue) {
            $.SetForm({
                url: ""../../JXGeoManage/TBL_QCQF_VILLAGEINFO/GetFormJson"",


                param: { keyValue: keyValue },
                success: function (data) {
                    $(""#form1"").SetWebControls(data);
                }
            })
        }
        $('#TOWNNAME').val(unescape(TOWNNAME));
    }
    //保存表单;
    function AcceptClick() {
        if (!$('#form1').Validform()) {
            return false;
        }
        var postData = $(""#form1"").GetWebControls(keyValue);
        postData.TOWNCODE = TOWNCODE;
        $.SaveForm({
            url: ""../../JXGeoManage/TBL_QCQF_VILLAGEINFO/SaveForm?keyValue="" + keyValue,
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
