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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/WeChatManage/Views/App/Form.cshtml")]
    public partial class _Areas_WeChatManage_Views_App_Form_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_WeChatManage_Views_App_Form_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\WeChatManage\Views\App\Form.cshtml"
  
    ViewBag.Title = "应用表单";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 88), Tuple.Create("\"", 147)
, Tuple.Create(Tuple.Create("", 94), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/uploadify/ajaxfileupload.js")
, 94), false)
);

WriteLiteral(@"></script>
<script>
    $(function () {
        //应用类型
        $(""#F_AppType"").comboBox({
            description: ""==请选择=="",
        });
        $('#uploadFile').change(function () {
            var f = document.getElementById('uploadFile').files[0]
            var src = window.URL.createObjectURL(f);
            document.getElementById('uploadPreview').src = src;
        });
    });
    //保存表单
    function AcceptClick() {
        if (!document.getElementById('uploadFile').files[0]) {
            top.learun.dialogTop({ msg: '请添加应用Logo', type: 'error' });
            return false;
        }
        if (!$('#form1').Validform()) {
            return false;
        }
        var AppId = $(""#F_AppId"").val();
        //上传应用图标
        $.ajaxFileUpload({
            url: ""../../WeChatManage/App/UploadFile?AppId="" + AppId,
            secureuri: false,
            fileElementId: 'uploadFile',
            dataType: 'json',
            success: function (data) {
                var postData = $(""#form1"").getWebControls("""");
                postData[""F_AppLogo""] = data.message;
                learun.saveForm({
                    url: ""../../WeChatManage/App/SaveForm"",
                    param: postData,
                    loading: ""正在保存数据..."",
                    success: function () {
                        $.currentIframe().learun.reload();
                    }
                })
            }
        });
    }
</script>

<div");

WriteLiteral(" style=\"margin-left: 20px; margin-top: 20px; margin-right: 50px;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"applogo \"");

WriteLiteral(" style=\"text-align: center; margin-bottom: 15px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"file\"");

WriteLiteral(" style=\"width: 100px; height: 100px;\"");

WriteLiteral(">\r\n            <img");

WriteLiteral(" id=\"uploadPreview\"");

WriteLiteral(" style=\"width: 100px; height: 100px; border-radius: 100px;\"");

WriteAttribute("src", Tuple.Create(" src=\"", 1945), Tuple.Create("\"", 1988)
, Tuple.Create(Tuple.Create("", 1951), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/logo-headere47d5.png")
, 1951), false)
);

WriteLiteral(" />\r\n            <input");

WriteLiteral(" type=\"file\"");

WriteLiteral(" name=\"uploadFile\"");

WriteLiteral(" id=\"uploadFile\"");

WriteLiteral(">\r\n        </div>\r\n    </div>\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">应用名称</th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_AppId\"");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2259), Tuple.Create("\"", 2293)
            
            #line 61 "..\..\Areas\WeChatManage\Views\App\Form.cshtml"
, Tuple.Create(Tuple.Create("", 2267), Tuple.Create<System.Object, System.Int32>(Guid.NewGuid().ToString()
            
            #line default
            #line hidden
, 2267), false)
);

WriteLiteral(" />\r\n                <input");

WriteLiteral(" id=\"F_AppName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"2-16个字\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">应用类型</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_AppType\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(">\r\n                    <ul>\r\n                        <li");

WriteLiteral(" data-value=\"1\"");

WriteLiteral(">消息型应用</li>\r\n                        <li");

WriteLiteral(" data-value=\"2\"");

WriteLiteral(">主页型应用</li>\r\n                    </ul>\r\n                </div>\r\n            </td>" +
"\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">可信域名</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_RedirectDomain\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"填写应用的域名地址，如：qy.weixin.qq.com:8080\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 4px;\"");

WriteLiteral(">\r\n                应用介绍\r\n            </th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <textarea");

WriteLiteral(" id=\"F_Description\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"height: 70px;\"");

WriteLiteral(" placeholder=\"描述该应用的功能与特色，内容为4-120个字\"");

WriteLiteral(@"></textarea>
            </td>
        </tr>
    </table>
</div>


<style>
    .file {
        position: relative;
        display: inline-block;
        overflow: hidden;
        text-decoration: none;
        text-indent: 0;
        cursor: pointer !important;
    }

        .file input {
            position: absolute;
            font-size: 100px;
            right: 0;
            top: 0;
            opacity: 0;
            cursor: pointer !important;
        }

        .file:hover {
            text-decoration: none;
            cursor: pointer !important;
        }
</style>
");

        }
    }
}
#pragma warning restore 1591
