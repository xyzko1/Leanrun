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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/WeChatManage/Views/App/FormHome.cshtml")]
    public partial class _Areas_WeChatManage_Views_App_FormHome_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_WeChatManage_Views_App_FormHome_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\WeChatManage\Views\App\FormHome.cshtml"
  
    ViewBag.Title = "主页型应用";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 89), Tuple.Create("\"", 148)
, Tuple.Create(Tuple.Create("", 95), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/uploadify/ajaxfileupload.js")
, 95), false)
);

WriteLiteral("></script>\r\n<script>\r\n    var keyValue = learun.request(\'keyValue\');\r\n    var f =" +
" null;\r\n    $(function () {\r\n        if (!!keyValue) {\r\n            learun.setFo" +
"rm({\r\n                url: \"../../WeChatManage/App/GetFormJson\",\r\n              " +
"  param: { keyValue: keyValue },\r\n                success: function (data) {\r\n  " +
"                  $(\"#form1\").setWebControls(data);\r\n                    documen" +
"t.getElementById(\'uploadPreview\').src = top.contentPath + data.F_AppLogo;\r\n     " +
"           }\r\n            });\r\n        }\r\n        $(\'#uploadFile\').change(functi" +
"on () {\r\n            f = document.getElementById(\'uploadFile\').files[0]\r\n       " +
"     var src = window.URL.createObjectURL(f);\r\n            document.getElementBy" +
"Id(\'uploadPreview\').src = src;\r\n        });\r\n    });\r\n    //保存表单\r\n    function A" +
"cceptClick() {\r\n        var AppId = $(\"#F_AppId\").val();\r\n        if (document.g" +
"etElementById(\'uploadFile\').src == \"~/Content/images/logo-headere47d5.png\") {\r\n " +
"           top.learun.dialogTop({ msg: \'请添加应用Logo\', type: \'error\' });\r\n         " +
"   return false;\r\n        } else {\r\n            if (!$(\'#form1\').Validform()) {\r" +
"\n                return false;\r\n            }\r\n            if (f != null) {\r\n   " +
"             //上传应用图标\r\n                $.ajaxFileUpload({\r\n                    u" +
"rl: \"../../WeChatManage/App/UploadFile?AppId=\" + AppId,\r\n                    sec" +
"ureuri: false,\r\n                    fileElementId: \'uploadFile\',\r\n              " +
"      dataType: \'json\',\r\n                    success: function (data) {\r\n       " +
"                 var postData = $(\"#form1\").getWebControls(\"\");\r\n               " +
"         postData[\"F_AppLogo\"] = data.message;\r\n                        learun.s" +
"aveForm({\r\n                            url: \"../../WeChatManage/App/SaveForm?key" +
"Value=\" + keyValue,\r\n                            param: postData,\r\n             " +
"               loading: \"正在保存数据...\",\r\n                            success: funct" +
"ion () {\r\n                                learun.currentIframe().learun.reload()" +
";\r\n                            }\r\n                        })\r\n                  " +
"  }\r\n                });\r\n            }\r\n            else {\r\n                var" +
" postData = $(\"#form1\").getWebControls(\"\");\r\n                learun.saveForm({\r\n" +
"                    url: \"../../WeChatManage/App/SaveForm?keyValue=\" + keyValue," +
"\r\n                    param: postData,\r\n                    loading: \"正在保存数据...\"" +
",\r\n                    success: function () {\r\n                        learun.cu" +
"rrentIframe().learun.reload();\r\n                    }\r\n                });\r\n    " +
"        }\r\n           \r\n            \r\n        }\r\n    }\r\n</script>\r\n\r\n<div");

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

WriteAttribute("src", Tuple.Create(" src=\"", 3087), Tuple.Create("\"", 3130)
, Tuple.Create(Tuple.Create("", 3093), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/logo-headere47d5.png")
, 3093), false)
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

WriteAttribute("value", Tuple.Create(" value=\"", 3401), Tuple.Create("\"", 3435)
            
            #line 85 "..\..\Areas\WeChatManage\Views\App\FormHome.cshtml"
, Tuple.Create(Tuple.Create("", 3409), Tuple.Create<System.Object, System.Int32>(Guid.NewGuid().ToString()
            
            #line default
            #line hidden
, 3409), false)
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

WriteLiteral(">主页URL</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_AppUrl\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"填写应用的域名地址，如：qy.weixin.qq.com:8080\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

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

WriteLiteral(">应用介绍\r\n            </th>\r\n            <td");

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
