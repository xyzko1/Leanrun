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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_FlowForm.cshtml")]
    public partial class _Views_Shared__FlowForm_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__FlowForm_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" http-equiv=\"content-type\"");

WriteLiteral(" content=\"text/html; charset=UTF-8\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\r\n    <title>");

            
            #line 7 "..\..\Views\Shared\_FlowForm.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</title>\r\n    <!--框架必需start-->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 235), Tuple.Create("\"", 286)
, Tuple.Create(Tuple.Create("", 241), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/jquery/jquery-1.10.2.min.js")
, 241), false)
);

WriteLiteral("></script>\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 308), Tuple.Create("\"", 352)
, Tuple.Create(Tuple.Create("", 315), Tuple.Create<System.Object, System.Int32>(Href("~/Content/styles/font-awesome.min.css")
, 315), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 384), Tuple.Create("\"", 444)
, Tuple.Create(Tuple.Create("", 391), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/jquery-ui/jquery-ui.min.css")
, 391), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 478), Tuple.Create("\"", 536)
, Tuple.Create(Tuple.Create("", 484), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/jquery-ui/jquery-ui.min.js")
, 484), false)
);

WriteLiteral("></script>\r\n    <!--框架必需end-->\r\n    <!--bootstrap组件start-->\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 607), Tuple.Create("\"", 659)
, Tuple.Create(Tuple.Create("", 614), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/bootstrap/bootstrap.min.css")
, 614), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 691), Tuple.Create("\"", 749)
, Tuple.Create(Tuple.Create("", 698), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/bootstrap/bootstrap.extension.css")
, 698), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 783), Tuple.Create("\"", 833)
, Tuple.Create(Tuple.Create("", 789), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/bootstrap/bootstrap.min.js")
, 789), false)
);

WriteLiteral("></script>\r\n    <!--bootstrap组件end-->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 884), Tuple.Create("\"", 941)
, Tuple.Create(Tuple.Create("", 890), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/datepicker/WdatePicker.js")
, 890), false)
);

WriteLiteral("></script>\r\n\r\n");

WriteLiteral("    ");

            
            #line 21 "..\..\Views\Shared\_FlowForm.cshtml"
Write(System.Web.Optimization.Styles.Render(
    "~/Content/scripts/plugins/tree/css",
    "~/Content/scripts/plugins/datetime/css",
    "~/Content/scripts/plugins/wizard/css",
    "~/Content/styles/learun.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 26 "..\..\Views\Shared\_FlowForm.cshtml"
Write(System.Web.Optimization.Scripts.Render(
    "~/Content/scripts/utils/learun.js",
    "~/Content/scripts/plugins/tree/js",
    "~/Content/scripts/plugins/validator/js",
    "~/Content/scripts/plugins/wizard/js",
    "~/Content/scripts/plugins/datepicker/js"
    ));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <!--工作流设计器依赖start-->\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1484), Tuple.Create("\"", 1542)
, Tuple.Create(Tuple.Create("", 1491), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/css/simditor.css")
, 1491), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1574), Tuple.Create("\"", 1637)
, Tuple.Create(Tuple.Create("", 1581), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/cxColor/css/jquery.cxcolor.css")
, 1581), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1673), Tuple.Create("\"", 1730)
, Tuple.Create(Tuple.Create("", 1679), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/js/module.min.js")
, 1679), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1754), Tuple.Create("\"", 1813)
, Tuple.Create(Tuple.Create("", 1760), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/js/uploader.min.js")
, 1760), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1837), Tuple.Create("\"", 1895)
, Tuple.Create(Tuple.Create("", 1843), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/js/hotkeys.min.js")
, 1843), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1919), Tuple.Create("\"", 1978)
, Tuple.Create(Tuple.Create("", 1925), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/js/simditor.min.js")
, 1925), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2002), Tuple.Create("\"", 2062)
, Tuple.Create(Tuple.Create("", 2008), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/cxColor/js/jquery.cxcolor.js")
, 2008), false)
);

WriteLiteral("></script>\r\n\r\n");

WriteLiteral("    ");

            
            #line 44 "..\..\Views\Shared\_FlowForm.cshtml"
Write(System.Web.Optimization.Styles.Render("~/Content/scripts/plugins/uploadify/css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 45 "..\..\Views\Shared\_FlowForm.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/Content/scripts/plugins/uploadify/js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("    ");

            
            #line 47 "..\..\Views\Shared\_FlowForm.cshtml"
Write(System.Web.Optimization.Styles.Render("~/Content/styles/custmerform.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 48 "..\..\Views\Shared\_FlowForm.cshtml"
Write(System.Web.Optimization.Styles.Render("~/Content/scripts/plugins/flow-ui/css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 49 "..\..\Views\Shared\_FlowForm.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/Content/scripts/utils/custmerform/formcompontsjs"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 50 "..\..\Views\Shared\_FlowForm.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/Content/scripts/utils/custmerform/formrenderingjs"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 51 "..\..\Views\Shared\_FlowForm.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/Content/scripts/plugins/flow-ui/js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <!--工作流设计器依赖end-->\r\n</head>\r\n<body>\r\n    <div");

WriteLiteral(" id=\"ajaxLoader\"");

WriteLiteral(" style=\"cursor: progress; position: fixed; top: -50%; left: -50%; width: 200%; he" +
"ight: 200%; background: #f1f1f1; z-index: 10000; overflow: hidden;\"");

WriteLiteral(">\r\n    </div>\r\n    <form");

WriteLiteral(" id=\"form1\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 58 "..\..\Views\Shared\_FlowForm.cshtml"
   Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </form>\r\n</body>\r\n</html>\r\n<script>\r\n    $(function () {\r\n        learun.ch" +
"ildInit();\r\n    })\r\n</script>");

        }
    }
}
#pragma warning restore 1591