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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Error/ErrorMessage.cshtml")]
    public partial class _Views_Error_ErrorMessage_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Error_ErrorMessage_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width\"");

WriteLiteral(" />\r\n    <title>错误页面</title>\r\n</head>\r\n<body>\r\n    <div");

WriteLiteral(" style=\"border: 2px solid #ddd; padding: 5px; margin: 5px;\"");

WriteLiteral(">\r\n        <h3><span");

WriteLiteral(" style=\"color: Red\"");

WriteLiteral(">错误信息详细内容</span></h3>\r\n        <p");

WriteLiteral(" style=\"padding: 5px; margin: 5px; font-size: 12px;color:#666;\"");

WriteLiteral(">\r\n");

            
            #line 12 "..\..\Views\Error\ErrorMessage.cshtml"
            
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Error\ErrorMessage.cshtml"
             foreach (var stakerholder in ViewData["Message"] as Dictionary<string, string>)
            { 

            
            #line default
            #line hidden
WriteLiteral("                <b>");

            
            #line 14 "..\..\Views\Error\ErrorMessage.cshtml"
              Write(stakerholder.Key);

            
            #line default
            #line hidden
WriteLiteral("：</b>");

            
            #line 14 "..\..\Views\Error\ErrorMessage.cshtml"
                                         
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Error\ErrorMessage.cshtml"
                                    Write(stakerholder.Value);

            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Error\ErrorMessage.cshtml"
                                                            ;
            
            #line default
            #line hidden
WriteLiteral("<br/>");

WriteLiteral("<br/>   \r\n");

            
            #line 15 "..\..\Views\Error\ErrorMessage.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </p>\r\n    </div>\r\n</body>\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591
