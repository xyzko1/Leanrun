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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/AppManage/Views/AppDesign/phoneDIndex.cshtml")]
    public partial class _Areas_AppManage_Views_AppDesign_phoneDIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_AppManage_Views_AppDesign_phoneDIndex_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"initial-scale=1, maximum-scale=1, user-scalable=no, width=device-width\"" +
"");

WriteLiteral(">\r\n    <title></title>\r\n\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 202), Tuple.Create("\"", 249)
, Tuple.Create(Tuple.Create("", 209), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/lib/ionic/css/ionic.css")
, 209), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(">\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 279), Tuple.Create("\"", 324)
, Tuple.Create(Tuple.Create("", 286), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/lib/icon/iconfont.css")
, 286), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 356), Tuple.Create("\"", 401)
, Tuple.Create(Tuple.Create("", 363), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/css/learun-iframe.css")
, 363), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 433), Tuple.Create("\"", 477)
, Tuple.Create(Tuple.Create("", 440), Tuple.Create<System.Object, System.Int32>(Href("~/Content/styles/font-awesome.min.css")
, 440), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <!-- IF using Sass (run gulp sass first), then uncomment below and remov" +
"e the CSS includes above\r\n    <link href=\"css/ionic.app.css\" rel=\"stylesheet\">\r\n" +
"    -->\r\n    <!-- ionic/angularjs js -->\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 711), Tuple.Create("\"", 762)
, Tuple.Create(Tuple.Create("", 717), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/lib/ionic/js/ionic.bundle.js")
, 717), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 786), Tuple.Create("\"", 827)
, Tuple.Create(Tuple.Create("", 792), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/js/learun-appkv.js")
, 792), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 851), Tuple.Create("\"", 895)
, Tuple.Create(Tuple.Create("", 857), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/js/learun-uirouter.js")
, 857), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 919), Tuple.Create("\"", 964)
, Tuple.Create(Tuple.Create("", 925), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/js/learun-directive.js")
, 925), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 988), Tuple.Create("\"", 1027)
, Tuple.Create(Tuple.Create("", 994), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/js/learun-app.js")
, 994), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1051), Tuple.Create("\"", 1096)
, Tuple.Create(Tuple.Create("", 1057), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/js/learun-component.js")
, 1057), false)
);

WriteLiteral("></script>\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1122), Tuple.Create("\"", 1173)
, Tuple.Create(Tuple.Create("", 1128), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/jquery/jquery-1.10.2.min.js")
, 1128), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1197), Tuple.Create("\"", 1262)
, Tuple.Create(Tuple.Create("", 1203), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/lib/ionic/js/jquery-ui/jquery-ui-1.11.4.js")
, 1203), false)
);

WriteLiteral("></script>\r\n</head>\r\n<body");

WriteLiteral(" ng-app=\"starter\"");

WriteLiteral(" animation=\"no-animation\"");

WriteLiteral(" data-tab-disabled=\"true\"");

WriteLiteral(" class=\"lr-platform-browser\"");

WriteLiteral(" id=\"phonestarter\"");

WriteLiteral(">\r\n    <ion-nav-bar");

WriteLiteral(" class=\"bar-positive nav-title-slide-ios7\"");

WriteLiteral(">\r\n        <ion-nav-back-button></ion-nav-back-button>\r\n    </ion-nav-bar>\r\n    <" +
"ion-nav-view>\r\n    </ion-nav-view>\r\n    <lr-select-box></lr-select-box>\r\n</body>" +
"\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591
