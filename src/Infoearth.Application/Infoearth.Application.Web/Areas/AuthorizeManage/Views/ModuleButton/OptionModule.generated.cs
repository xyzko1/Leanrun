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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/AuthorizeManage/Views/ModuleButton/OptionModule.cshtml")]
    public partial class _Areas_AuthorizeManage_Views_ModuleButton_OptionModule_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_AuthorizeManage_Views_ModuleButton_OptionModule_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\AuthorizeManage\Views\ModuleButton\OptionModule.cshtml"
  
    ViewBag.Title = "复制按钮";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" style=\"margin: 10px; margin-bottom: 0px;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"ModuleTree\"");

WriteLiteral(" style=\"height: 388px; overflow: auto;\"");

WriteLiteral(">\r\n    </div>\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral(@"
<script>
    var keyValue = learun.request('keyValue');
    $(function () {
        GetModuleTree();
    })
    //加载功能模块树
    var moduleId = """";
    function GetModuleTree() {
        var item = {
            onnodeclick: function (item) {
                moduleId = item.id;
            },
            url: ""../../AuthorizeManage/Module/GetTreeJson""
        };
        $(""#ModuleTree"").treeview(item);
    }
    //保存事件
    function AcceptClick() {
        if (moduleId) {
            learun.saveForm({
                url: ""../../AuthorizeManage/ModuleButton/CopyForm"",
                param: { keyValue: keyValue, moduleId: moduleId },
                loading: ""正在提交数据..."",
                success: function () {

                }
            })
        } else {
            learun.dialogMsg({ msg: '请选择系统功能！', type: 0 });
        }
    }
</script>
");

});

        }
    }
}
#pragma warning restore 1591
