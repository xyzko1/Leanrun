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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Index.cshtml")]
    public partial class _Views_Shared__Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\r\n    <title>");

            
            #line 6 "..\..\Views\Shared\_Index.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</title>\r\n\r\n    <script");

WriteLiteral(" type=\'text/javascript\'");

WriteLiteral(@">window.BWEUM || (BWEUM = {}); BWEUM.info = { ""stand"": true, ""agentType"": ""browser"", ""agent"": ""browsercollector.oneapm.com/static/js/bw-send-416.7.31.js"", ""beaconUrl"": ""browsercollector.oneapm.com/beacon"", ""licenseKey"": ""Jrq2e~u3MQZ6IuMV"", ""applicationID"": 9991162 };</script>
    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"//browsercollector.oneapm.com/static/js/bw-loader-416.7.31.js\"");

WriteLiteral("></script>\r\n    <!--兼容IE10及以下-->\r\n    <!--[if lte IE 10]>\r\n        <style>\r\n     " +
"       .mic-col-ipt{\r\n                padding-top:8px !important;\r\n            }" +
"\r\n        </style>\r\n    <![endif]-->\r\n</head>\r\n<body>\r\n    <div");

WriteLiteral(" id=\"ajax-loader\"");

WriteLiteral(" style=\"cursor: progress; position: fixed; top: -50%; left: -50%; width: 200%; he" +
"ight: 200%; background: #fff; z-index: 10000; \"");

WriteLiteral(">\r\n        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 986), Tuple.Create("\"", 1024)
, Tuple.Create(Tuple.Create("", 992), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/ajax-loader.gif")
, 992), false)
);

WriteLiteral(" style=\"position: absolute; top: 0; left: 0; right: 0; bottom: 0; margin: auto;\"");

WriteLiteral(" />\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"loading_background\"");

WriteLiteral(" class=\"loading_background\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral("></div>\r\n    <div");

WriteLiteral(" id=\"loading_manage\"");

WriteLiteral(">\r\n        正在拼了命为您加载…\r\n    </div>\r\n");

WriteLiteral("    ");

            
            #line 27 "..\..\Views\Shared\_Index.cshtml"
Write(System.Web.Optimization.Styles.Render("~/Content/styles/base.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 28 "..\..\Views\Shared\_Index.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/Content/scripts/base.js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 29 "..\..\Views\Shared\_Index.cshtml"
Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 30 "..\..\Views\Shared\_Index.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/Content/scripts/plugins/datepicker/WdatePicker.js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    \r\n    <style>\r\n        body {\r\n            margin: 10px;\r\n            margi" +
"n-bottom: 0px;\r\n            overflow: hidden;\r\n            overflow-y: auto;\r\n  " +
"      }\r\n    </style>\r\n</body>\r\n</html>\r\n");

            
            #line 42 "..\..\Views\Shared\_Index.cshtml"
Write(System.Web.Optimization.Styles.Render(
    "~/Content/scripts/plugins/jqgrid/css",
    "~/Content/scripts/plugins/tree/css",
    "~/Content/scripts/plugins/datetime/css",
    "~/Content/styles/learun.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 47 "..\..\Views\Shared\_Index.cshtml"
Write(System.Web.Optimization.Scripts.Render(
    "~/Content/scripts/utils/learun.js",
    "~/Content/scripts/utils/learunEx.js",
    "~/Content/scripts/utils/clientdata",
    "~/Content/scripts/plugins/tree/js",
    "~/Content/scripts/plugins/validator/js",
    "~/Content/scripts/plugins/wizard/js",
    "~/Content/scripts/plugins/jqgrid/js",
            "~/Content/scripts/plugins/dialog/js"
    ));

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    var contentPath = \'");

            
            #line 58 "..\..\Views\Shared\_Index.cshtml"
                  Write(Url.Content("~"));

            
            #line default
            #line hidden
WriteLiteral("\'.substr(0, \'");

            
            #line 58 "..\..\Views\Shared\_Index.cshtml"
                                                Write(Url.Content("~"));

            
            #line default
            #line hidden
WriteLiteral("\'.length - 1);\r\n    var Account = \'");

            
            #line 59 "..\..\Views\Shared\_Index.cshtml"
              Write(Infoearth.Application.Code.OperatorProvider.Provider.Current().Account);

            
            #line default
            #line hidden
WriteLiteral("\';\r\n    var XZQHCode = \'");

            
            #line 60 "..\..\Views\Shared\_Index.cshtml"
               Write(Infoearth.Application.Code.OperatorProvider.Provider.Current().XZQHCode);

            
            #line default
            #line hidden
WriteLiteral("\';\r\n    (function ($, learun) {\r\n        $(function () {\r\n            learun.chil" +
"dInit();\r\n        })\r\n    })(window.jQuery, window.learun)\r\n</script>\r\n");

            
            #line 67 "..\..\Views\Shared\_Index.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/Content/business/comForm.js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 68 "..\..\Views\Shared\_Index.cshtml"
Write(RenderSection("scripts", false));

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591