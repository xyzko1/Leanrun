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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_ACHIEVEMENT_PREPLAN/TBL_PREPLANMultiMedia.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_ACHIEVEMENT_PREPLAN_TBL_PREPLANMultiMedia_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_ACHIEVEMENT_PREPLAN_TBL_PREPLANMultiMedia_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_ACHIEVEMENT_PREPLAN\TBL_PREPLANMultiMedia.cshtml"
  
    ViewBag.Title = "防治规划表单页面";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral(@"
<style>
    #mainContent {
        background:#fff
    }
    .formTitle {
        width: 110px !important;
        background: transparent;
    }
    .form td {
        border:1px solid #d6d6d6;
        text-align:center !important;
    }
    .form td input{
        border-top:none;
        border-left:none;
        border-right:none;
    }
    .form td textarea{
        border-top:none;
        border-left:none;
        border-right:none;
    }
    .form-control:disabled
    {
        background:#fff;
    }
</style>

<div");

WriteLiteral(" style=\"margin:20px 30px 0 30px;background:#fff\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n        <tr>\r\n            <td");

WriteLiteral(" style=\"width: 100%; height: 600px;\"");

WriteLiteral(" colspan=\"6\"");

WriteLiteral(">\r\n                <iframe");

WriteLiteral(" class=\"LRADMS_iframe\"");

WriteLiteral(" id=\"MultMedia\"");

WriteLiteral(" frameborder=\"0\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" style=\"border: none; width: 100%; height: 100%\"");

WriteLiteral("></iframe>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</div>\r\n\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 1027), Tuple.Create("\"", 1095)
, Tuple.Create(Tuple.Create("", 1033), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/infoearthcustom/dictionaryControl.js")
, 1033), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 1115), Tuple.Create("\"", 1179)
, Tuple.Create(Tuple.Create("", 1121), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/Kneecoordinate/Kneecoordinate.js")
, 1121), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 1199), Tuple.Create("\"", 1233)
, Tuple.Create(Tuple.Create("", 1205), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/comForm.js")
, 1205), false)
);

WriteLiteral(@"></script>
<script>
    var keyValue = request('keyValue');
    var belongGuid = keyValue == """" ? null : keyValue;
    var authToken = getAuthorizationToken();
    $(function () {
        //initControl();
        //治理工程的moduleID--modeId_ZLGCInfo
        $('#MultMedia').attr('src', ""/SystemManage/MultMedia/Index?moduleID=5f8a0a55-9a83-4e12-bd23-a8b1c2be7974&belongObjectGuid="" + keyValue + ""&details=01"");
    });
    //初始化控件
    //function initControl() {




    //}

</script>
");

});

        }
    }
}
#pragma warning restore 1591
