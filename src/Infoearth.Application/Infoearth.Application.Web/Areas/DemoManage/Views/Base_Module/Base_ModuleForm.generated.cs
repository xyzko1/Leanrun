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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/DemoManage/Views/Base_Module/Base_ModuleForm.cshtml")]
    public partial class _Areas_DemoManage_Views_Base_Module_Base_ModuleForm_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_DemoManage_Views_Base_Module_Base_ModuleForm_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\DemoManage\Views\Base_Module\Base_ModuleForm.cshtml"
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
        //获取表单
        if (!!keyValue) {
            $.SetForm({
                url: ""../../DemoManage/Base_Module/GetFormJson"",
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
        $.SaveForm({
            url: ""../../DemoManage/Base_Module/SaveForm?keyValue="" + keyValue,
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

WriteLiteral(">\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">功能主键</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_ModuleId\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">父级主键</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_ParentId\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">编码</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_EnCode\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">名称</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_FullName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">图标</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Icon\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">导航地址</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_UrlAddress\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">导航目标</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Target\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">菜单选项</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_IsMenu\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">允许展开</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_AllowExpand\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            \r\n    </table>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591