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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/AdminPretty.cshtml")]
    public partial class _Views_Home_AdminPretty_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Home_AdminPretty_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\r\n    <title>");

            
            #line 7 "..\..\Views\Home\AdminPretty.cshtml"
      Write(Infoearth.Util.Config.GetValue("SystemName").ToString());

            
            #line default
            #line hidden
WriteLiteral("</title>\r\n    <link");

WriteLiteral(" rel=\"icon\"");

WriteAttribute("href", Tuple.Create(" href=\"", 250), Tuple.Create("\"", 285)
, Tuple.Create(Tuple.Create("", 257), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/favicon.ico")
, 257), false)
);

WriteLiteral(">\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 298), Tuple.Create("\"", 342)
, Tuple.Create(Tuple.Create("", 305), Tuple.Create<System.Object, System.Int32>(Href("~/Content/styles/font-awesome.min.css")
, 305), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 374), Tuple.Create("\"", 426)
, Tuple.Create(Tuple.Create("", 381), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/bootstrap/bootstrap.min.css")
, 381), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n");

WriteLiteral("    ");

            
            #line 11 "..\..\Views\Home\AdminPretty.cshtml"
Write(System.Web.Optimization.Styles.Render("~/Content/styles/learun-ui.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 536), Tuple.Create("\"", 573)
, Tuple.Create(Tuple.Create("", 543), Tuple.Create<System.Object, System.Int32>(Href("~/Content/styles/learun-im.css")
, 543), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n");

WriteLiteral("    ");

            
            #line 13 "..\..\Views\Home\AdminPretty.cshtml"
Write(System.Web.Optimization.Styles.Render("~/Content/adminPretty/css/home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</head>\r\n<body");

WriteLiteral(" style=\"overflow: hidden;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"ajax-loader\"");

WriteLiteral(" style=\"cursor: progress; position: fixed; top: -50%; left: -50%; width: 200%; he" +
"ight: 200%; background: #fff; z-index: 10000; overflow: hidden;\"");

WriteLiteral(">\r\n        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 902), Tuple.Create("\"", 940)
, Tuple.Create(Tuple.Create("", 908), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/ajax-loader.gif")
, 908), false)
);

WriteLiteral(" style=\"position: absolute; top: 0; left: 0; right: 0; bottom: 0; margin: auto;\"");

WriteLiteral(" />\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"lea-Head\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"logo\"");

WriteLiteral(">\r\n            <img");

WriteAttribute("src", Tuple.Create(" src=\"", 1110), Tuple.Create("\"", 1157)
, Tuple.Create(Tuple.Create("", 1116), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/Prettyimage/new.logo.png")
, 1116), false)
);

WriteLiteral(" />\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"left-bar\"");

WriteLiteral(" id=\"left-bar\"");

WriteLiteral(">\r\n            <ul");

WriteLiteral(" class=\"menu\"");

WriteLiteral(" id=\"top-menu\"");

WriteLiteral("></ul>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"right-bar\"");

WriteLiteral(">\r\n\r\n\r\n\r\n            <ul>\r\n\r\n                <li");

WriteLiteral(" class=\"dropdown user user-menu\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">\r\n                        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 1513), Tuple.Create("\"", 1591)
            
            #line 34 "..\..\Views\Home\AdminPretty.cshtml"
, Tuple.Create(Tuple.Create("", 1519), Tuple.Create<System.Object, System.Int32>(Infoearth.Application.Code.OperatorProvider.Provider.Current().HeadIcon
            
            #line default
            #line hidden
, 1519), false)
);

WriteLiteral("\r\n                             onerror=\"javascript: this.src = \'../../Content/ima" +
"ges/head/user2-160x160.jpg\'\"");

WriteLiteral(" class=\"user-image\"");

WriteLiteral(" alt=\"User Image\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"hidden-xs\"");

WriteLiteral(">");

            
            #line 36 "..\..\Views\Home\AdminPretty.cshtml"
                                           Write(Infoearth.Application.Code.OperatorProvider.Provider.Current().UserName);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </a>\r\n                    <ul");

WriteLiteral(" class=\"dropdown-menu pull-right\"");

WriteLiteral(">\r\n                        <li><a");

WriteLiteral(" id=\"UserSetting\"");

WriteLiteral(" ><i");

WriteLiteral(" class=\"fa fa-user\"");

WriteLiteral("></i>个人信息</a></li>\r\n                        <li><a ><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>清空缓存</a></li>\r\n                        <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\r\n                        <li><a");

WriteLiteral("  onclick=\"$.learunindex.indexOut()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"ace-icon fa fa-power-off\"");

WriteLiteral("></i>安全退出</a></li>\r\n                    </ul>\r\n                </li>\r\n           " +
" </ul>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"lea-tabs\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"menuTabs\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"page-tabs-content\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral(" id=\"mianFrame\"");

WriteLiteral(" class=\"menuTab active\"");

WriteLiteral(" data-id=\"~/Home/AdminPrettyDesktop\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-home\"");

WriteLiteral("></i>欢迎首页</a>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"tabs-right-tool\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" class=\"roll-nav tabLeft\"");

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa fa-chevron-left\"");

WriteLiteral("></i>\r\n            </button>\r\n            <button");

WriteLiteral(" class=\"roll-nav tabRight\"");

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa fa-chevron-right\"");

WriteLiteral(" style=\"margin-left: 3px;\"");

WriteLiteral("></i>\r\n            </button>\r\n            <button");

WriteLiteral(" class=\"roll-nav fullscreen\"");

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-arrows-alt\"");

WriteLiteral("></i>\r\n            </button>\r\n            <div");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" class=\"roll-nav dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-gear \"");

WriteLiteral("></i>\r\n                </button>\r\n                <ul");

WriteLiteral(" class=\"dropdown-menu dropdown-menu-right\"");

WriteLiteral(" style=\"margin-top:40px\"");

WriteLiteral(">\r\n                    <li><a");

WriteLiteral(" class=\"tabReload\"");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral(">刷新当前</a></li>\r\n                    <li><a");

WriteLiteral(" class=\"tabCloseCurrent\"");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral(">关闭当前</a></li>\r\n                    <li><a");

WriteLiteral(" class=\"tabCloseAll\"");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral(">全部关闭</a></li>\r\n                    <li><a");

WriteLiteral(" class=\"tabCloseOther\"");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral(">除此之外全部关闭</a></li>\r\n                </ul>\r\n            </div>\r\n        </div>\r\n  " +
"  </div>\r\n    <div");

WriteLiteral(" id=\"mainContent\"");

WriteLiteral(" class=\"lea-content\"");

WriteLiteral(">\r\n        <iframe");

WriteLiteral(" class=\"LRADMS_iframe\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" height=\"100%\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3921), Tuple.Create("\"", 3952)
, Tuple.Create(Tuple.Create("", 3927), Tuple.Create<System.Object, System.Int32>(Href("~/Home/AdminPrettyDesktop")
, 3927), false)
);

WriteLiteral(" frameborder=\"0\"");

WriteLiteral(" data-id=\"~/Home/AdminPrettyDesktop\"");

WriteLiteral("></iframe>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"footer\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" style=\"float: left; width: 30%;\"");

WriteLiteral(">\r\n            &nbsp;技术支持：<a");

WriteLiteral(" href=\"www.infoearth.com\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(" style=\"color: white;\"");

WriteLiteral(">武汉地大信息工程股份有限公司</a>\r\n        </div>\r\n        <div");

WriteLiteral(" style=\"float: left; width: 40%; text-align: center;\"");

WriteLiteral(">\r\n            Copyright © 2013 - 2017 By Infoearth\r\n        </div>\r\n        <div" +
"");

WriteLiteral(" style=\"float: left; width: 30%; text-align: right;\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" id=\"btn_message\"");

WriteLiteral(" class=\"fa fa-comments\"");

WriteLiteral(" title=\"消息通知\"");

WriteLiteral(" style=\"width: 30px; font-size: 22px; vertical-align: middle; cursor: pointer;mar" +
"gin-top:-1px;margin-right:5px;display:none;\"");

WriteLiteral("></i>\r\n        </div>\r\n    </div>\r\n\r\n\r\n    <div");

WriteLiteral(" id=\"loading_background\"");

WriteLiteral(" class=\"loading_background\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral("></div>\r\n    <div");

WriteLiteral(" id=\"loading_manage\"");

WriteLiteral(">\r\n        正在拼了命为您加载…\r\n    </div>\r\n    <!--聊天窗口start-->\r\n    ");

WriteLiteral("\r\n    <!--聊天窗口end-->\r\n</body>\r\n</html>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 7553), Tuple.Create("\"", 7604)
, Tuple.Create(Tuple.Create("", 7559), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/jquery/jquery-1.10.2.min.js")
, 7559), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 7624), Tuple.Create("\"", 7674)
, Tuple.Create(Tuple.Create("", 7630), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/bootstrap/bootstrap.min.js")
, 7630), false)
);

WriteLiteral("></script>\r\n");

            
            #line 159 "..\..\Views\Home\AdminPretty.cshtml"
Write(System.Web.Optimization.Scripts.Render(
"~/Content/scripts/plugins/cookie/js",
"~/Content/scripts/plugins/dialog/js",
"~/Content/scripts/utils/learun.js",
"~/Content/adminPretty/js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    var contentPath = \'");

            
            #line 165 "..\..\Views\Home\AdminPretty.cshtml"
                  Write(Url.Content("~"));

            
            #line default
            #line hidden
WriteLiteral("\'.substr(0, \'");

            
            #line 165 "..\..\Views\Home\AdminPretty.cshtml"
                                                Write(Url.Content("~"));

            
            #line default
            #line hidden
WriteLiteral(@"'.length - 1);
    var contentWebUrl = """";
    var ssoPath = ""http://localhost:4066/"";
    var queryUrl = ""/Home/GetWebPath"";
    $.ajax({
        url: queryUrl,
        async: false,
        type: ""GET"",
        success: function (data) {
            var info = JSON.parse(data);
            ssoPath = info.ssoUrl;
            contentWebUrl = info.webUrl;
        }, error: function (e) {
        },
        cache: false
    });
    $(function () {
        ");

WriteLiteral("\r\n\r\n        $(\"#mianFrame\").click(function () {\r\n            $(\'#mainContent\').fi" +
"nd(\'iframe.LRADMS_iframe\').show();\r\n        });\r\n    }\r\n    );\r\n</script>");

        }
    }
}
#pragma warning restore 1591