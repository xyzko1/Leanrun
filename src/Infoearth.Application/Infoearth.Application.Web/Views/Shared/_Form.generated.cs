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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Form.cshtml")]
    public partial class _Views_Shared__Form_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__Form_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" http-equiv=\"content-type\"");

WriteLiteral(" content=\"text/html; charset=UTF-8\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\r\n    <title>");

            
            #line 6 "..\..\Views\Shared\_Form.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(@"</title>
    <style>
        #LAST table {
            margin-top:5px;
        }
        .form .formTitle {
            white-space:pre-wrap !important;
            background:#F2F2F2;
        }
        .title .formTitle {
            background:#fff
        }
        .form-control[disabled], fieldset[disabled] .form-control {
            background:#dedcdc !important;
        }
        .form-control {
            border-radius:4px;
        }
        .ui-select-text {
            border-radius:4px
        }
        label {
            margin:0 5px;
        }
        .nav-tabs {
            padding-top:0!important;
        }
        html, body, #form1 {
            height: 100%;
        }
      .required {
        color: red;
        /*padding-left: 5px;*/
        vertical-align: middle;
    }
    </style>
</head>
<body>
    <div");

WriteLiteral(" id=\"ajax-loader\"");

WriteLiteral(" style=\"cursor: progress; position: fixed; top: -50%; left: -50%; width: 200%; he" +
"ight: 200%; background: #fff; z-index: 10000; overflow: hidden;\"");

WriteLiteral(">\r\n        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 1218), Tuple.Create("\"", 1256)
, Tuple.Create(Tuple.Create("", 1224), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/ajax-loader.gif")
, 1224), false)
);

WriteLiteral(" style=\"position: absolute; top: 0; left: 0; right: 0; bottom: 0; margin: auto;\"");

WriteLiteral(" />\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"loading_background\"");

WriteLiteral(" class=\"loading_background\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral("></div>\r\n    <div");

WriteLiteral(" id=\"loading_manage\"");

WriteLiteral(">\r\n        正在拼了命为您加载…\r\n    </div>\r\n    <form");

WriteLiteral(" id=\"form1\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 52 "..\..\Views\Shared\_Form.cshtml"
   Write(System.Web.Optimization.Styles.Render("~/Content/styles/base.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 53 "..\..\Views\Shared\_Form.cshtml"
   Write(System.Web.Optimization.Scripts.Render("~/Content/scripts/base.js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 54 "..\..\Views\Shared\_Form.cshtml"
   Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 55 "..\..\Views\Shared\_Form.cshtml"
   Write(System.Web.Optimization.Scripts.Render("~/Content/scripts/plugins/datepicker/WdatePicker.js"));

            
            #line default
            #line hidden
WriteLiteral(" \r\n    </form>\r\n</body>\r\n</html>\r\n");

            
            #line 59 "..\..\Views\Shared\_Form.cshtml"
Write(System.Web.Optimization.Styles.Render(
    "~/Content/scripts/plugins/tree/css",
    "~/Content/scripts/plugins/datetime/css",
    "~/Content/scripts/plugins/wizard/css",
"~/Content/scripts/plugins/jqgrid/css",
    "~/Content/styles/learun.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 65 "..\..\Views\Shared\_Form.cshtml"
Write(System.Web.Optimization.Scripts.Render(
    "~/Content/scripts/utils/learun.js",
    "~/Content/scripts/utils/clientdata",
    "~/Content/scripts/plugins/tree/js",
    "~/Content/scripts/plugins/validator/js",
    "~/Content/scripts/plugins/wizard/js",
    "~/Content/scripts/plugins/dialog/js",
    "~/Content/scripts/plugins/jqgrid/js",
    "~/Content/scripts/plugins/districts/districts.js"

    ));

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\n    var contentPath = \'");

            
            #line 77 "..\..\Views\Shared\_Form.cshtml"
                  Write(Url.Content("~"));

            
            #line default
            #line hidden
WriteLiteral("\'.substr(0, \'");

            
            #line 77 "..\..\Views\Shared\_Form.cshtml"
                                                Write(Url.Content("~"));

            
            #line default
            #line hidden
WriteLiteral("\'.length - 1);\r\n    var Account = \'");

            
            #line 78 "..\..\Views\Shared\_Form.cshtml"
              Write(Infoearth.Application.Code.OperatorProvider.Provider.Current().Account);

            
            #line default
            #line hidden
WriteLiteral("\';\n    var XZQHCode = \'");

            
            #line 79 "..\..\Views\Shared\_Form.cshtml"
               Write(Infoearth.Application.Code.OperatorProvider.Provider.Current().XZQHCode);

            
            #line default
            #line hidden
WriteLiteral(@"';
    //经纬度验证
    function isJD(thisObj) {
        var _this = thisObj;
        var k = /^[EW]?((\d|[1-9]\d|1[0-7]\d)[s\-,;°度](\d|[0-5]\d)[s\-,;′＇’′'分](\d|[0-5]\d)(\.\d{1,2})?[s\-,;/""＂”″秒]?$)/;
        var l = /^[EW]?((\d|[1-9]\d|1[0-7]\d)[s\-,;°度]?$)/;
        var m = /^[EW]?((\d|[1-9]\d|1[0-7]\d)[s\-,;°度](\d|[0-5]\d)[s\-,;′＇’′'分 ]?$)/;
        var g = /^\d+(\.\d+)?$/;
        var thisValue = $(_this).val().replace(/\s/g, """").replace('""', ""″"");//清空所有空格替换最后的英文状态引号
        if (thisValue != """") {
            if (k.test(thisValue) || g.test(thisValue) || l.test(thisValue) || m.test(thisValue)) {
                $(_this).val(thisValue);//返回值
            } else {
                dialogMsg('请输入度分秒或者小数点！', 0);
                $(_this).val("""");
            }
        }
    }
    (function ($, learun) {
        $(function () {
            learun.childInit();
            $(""#PROVINCENAME"").prop(""disabled"", ""disabled"");
            $(""#CITYNAME"").prop(""disabled"", ""disabled"");
            //$(""#TOWNNAME"").prop(""disabled"", ""disabled"");
        })
    })(window.jQuery, window.learun)
</script>
");

            
            #line 106 "..\..\Views\Shared\_Form.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/Content/business/comForm.js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 107 "..\..\Views\Shared\_Form.cshtml"
Write(RenderSection("scripts", false));

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
