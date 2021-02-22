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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/AppManage/Views/AppDesign/Index.cshtml")]
    public partial class _Areas_AppManage_Views_AppDesign_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_AppManage_Views_AppDesign_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\AppManage\Views\AppDesign\Index.cshtml"
  
    ViewBag.Title = "移动端设计";
    Layout = "~/Views/Shared/_WebAppIndex.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" ng-app=\"webAppDesign\"");

WriteLiteral(" ng-controller=\"lrAppCtrl\"");

WriteLiteral(" id=\"webAppDesign\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"lr-app-tool-bar\"");

WriteLiteral(" style=\"width:{{$root.windowWidth}}\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"leftToolbar\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" ng-model=\"designer.projectName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入App项目名称\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(" />\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"rightToolbar\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" id=\"lr-save\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" ng-click=\"btnSaveProject()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>&nbsp;保存</a>\r\n                <a");

WriteLiteral(" id=\"lr-download\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" ng-click=\"btnDownProject()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-download\"");

WriteLiteral("></i>&nbsp;下载</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"lr-app-left-bar\"");

WriteLiteral(" style=\"height:{{$root.windowHeight-50}}px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"lr-app-pageDirectory\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"lr-app-pageTool\"");

WriteLiteral(">\r\n                <span>页面模板</span>\r\n                <div");

WriteLiteral(" class=\"dropdown lrbtnAddPage\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"addPhonePage\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" role=\"button\"");

WriteLiteral(" aria-haspopup=\"true\"");

WriteLiteral(" aria-expanded=\"false\"");

WriteLiteral("><span");

WriteLiteral(" class=\"fa fa-plus-square-o\"");

WriteLiteral("></span>添加</div>\r\n                    <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(" aria-labelledby=\"addPhonePage\"");

WriteLiteral(">\r\n                        <li");

WriteLiteral(" ng-repeat=\"pageTemplate in pageTemplates\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" ng-click=\"addPage(pageTemplate)\"");

WriteLiteral("><img");

WriteLiteral(" src=\"{{pageTemplate.png}}\"");

WriteLiteral(" style=\"width: 110px; height: 90px\"");

WriteLiteral("><span>{{pageTemplate.text}}</span></a>\r\n                        </li>\r\n         " +
"           </ul>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"lr-app-pageContent\"");

WriteLiteral(">\r\n                <lrapp-pagetree");

WriteLiteral(" ng-model=\"$root.designer.templates.fnPageTree.init\"");

WriteLiteral("></lrapp-pagetree>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"lr-app-tabctrl\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"lr-app-tabTool\"");

WriteLiteral(">\r\n                <span>Tabs页面</span>\r\n                <lrapp-toggleb");

WriteLiteral(" ng-model=\"$root.designer.isTabsAdded\"");

WriteLiteral("></lrapp-toggleb>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"lr-app-tabContent\"");

WriteLiteral(" ng-hide=\"!$root.designer.isTabsAdded\"");

WriteLiteral(">\r\n                <lrapp-pagetree");

WriteLiteral(" ng-model=\"$root.designer.templates.fnTabsTree.init\"");

WriteLiteral("></lrapp-pagetree>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"lr-app-component\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"lr-app-componentTool\"");

WriteLiteral(">\r\n                <span>组件</span>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"lr-app-componentContent\"");

WriteLiteral(" style=\"height:{{$root.windowHeight-($root.designer.isTabsAdded?496:396)}}px;\"");

WriteLiteral(">\r\n                <lrapp-components></lrapp-components>\r\n            </div>\r\n   " +
"     </div>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"lr-app-mid-bar\"");

WriteLiteral(" ng-controller=\"lrAppMidbarCtrl\"");

WriteLiteral(" style=\"height:{{$root.windowHeight-50}}px;width:{{$root.windowWidth-600}}px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"lr-app-phoneTool\"");

WriteLiteral(">\r\n            <select");

WriteLiteral(" ng-change=\"changePhoneScale()\"");

WriteLiteral(" ng-model=\"phoneScale\"");

WriteLiteral(">\r\n                <option");

WriteLiteral(" value=\"1\"");

WriteLiteral(">100%</option>\r\n                <option");

WriteLiteral(" value=\"0.9\"");

WriteLiteral(">90%</option>\r\n                <option");

WriteLiteral(" value=\"0.8\"");

WriteLiteral(">80%</option>\r\n                <option");

WriteLiteral(" value=\"0.7\"");

WriteLiteral(">70%</option>\r\n                <option");

WriteLiteral(" value=\"0.6\"");

WriteLiteral(">60%</option>\r\n                <option");

WriteLiteral(" value=\"0.5\"");

WriteLiteral(">50%</option>\r\n            </select>\r\n        </div>\r\n        <div");

WriteLiteral(" style=\"height:{{$root.windowHeight-82}}px;overflow-y:auto;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"lr-app-phone\"");

WriteLiteral(" style=\"margin-top:{{marginTop}};height:{{phoneHeight }};background-size: {{phone" +
"Width}} {{phoneHeight}};\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"lr-app-iframe\"");

WriteLiteral(" style=\"height:{{phoneIframeH}};width: {{phoneIframeW }};transform: scale3d(1, 1," +
" 1);transition: out 0s ease;transform-origin: center top 0px;margin-top: {{phone" +
"IframeMT}};\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"app-status\"");

WriteLiteral(" style=\"transition:0s ease-out;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" style=\"height:20px;padding:5px;transition:0s ease-out;\"");

WriteLiteral(">\r\n                            <img");

WriteAttribute("src", Tuple.Create(" src=\"", 3889), Tuple.Create("\"", 3938)
, Tuple.Create(Tuple.Create("", 3895), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/img/ios-statusbar-left.png")
, 3895), false)
);

WriteLiteral(" style=\"float:left;height:10px;transition:0s ease-out;margin-top:-1px;\"");

WriteLiteral(">\r\n                            <img");

WriteAttribute("src", Tuple.Create(" src=\"", 4045), Tuple.Create("\"", 4096)
, Tuple.Create(Tuple.Create("", 4051), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/img/ios-statusbar-center.png")
, 4051), false)
);

WriteLiteral(" style=\"float:none;height:10px;transition:0s ease-out;margin-top:-7px;\"");

WriteLiteral(">\r\n                            <img");

WriteAttribute("src", Tuple.Create(" src=\"", 4203), Tuple.Create("\"", 4253)
, Tuple.Create(Tuple.Create("", 4209), Tuple.Create<System.Object, System.Int32>(Href("~/Content/webApp/img/ios-statusbar-right.png")
, 4209), false)
);

WriteLiteral(" style=\"float:right;height:10px;transition:0s ease-out;\"");

WriteLiteral(">\r\n                        </div>\r\n                    </div>\r\n                  " +
"  <iframe");

WriteLiteral(" class=\"iframe-content\"");

WriteLiteral(" src=\"/AppManage/AppDesign/phoneDIndex\"");

WriteLiteral(" id=\"phoneDIndex\"");

WriteLiteral(" style=\"height:100%;width: 100%;\"");

WriteLiteral("></iframe>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div" +
">\r\n\r\n    <div");

WriteLiteral(" class=\"lr-app-right-bar\"");

WriteLiteral(" style=\"height:{{$root.windowHeight-50}}px;\"");

WriteLiteral(">\r\n       \r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"lr-app-splash\"");

WriteLiteral(" ng-hide=\"$root.designer.vm.isBeginView\"");

WriteLiteral(" style=\"height:{{$root.windowHeight}}px;width:{{$root.windowWidth}}px;\"");

WriteLiteral(">\r\n        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 4857), Tuple.Create("\"", 4895)
, Tuple.Create(Tuple.Create("", 4863), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/icon-webApp.png")
, 4863), false)
);

WriteLiteral(" style=\"margin-top:{{$root.windowHeight/2-150}}px;\"");

WriteLiteral("/>\r\n        <div><span>数据加载中...</span></div>\r\n    </div>\r\n\r\n    \r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
