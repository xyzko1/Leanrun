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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/FormManage/Views/FormModule/CustmerFormIndex.cshtml")]
    public partial class _Areas_FormManage_Views_FormModule_CustmerFormIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_FormManage_Views_FormModule_CustmerFormIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\FormManage\Views\FormModule\CustmerFormIndex.cshtml"
  
    ViewBag.Title = "系统表单管理";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 5 "..\..\Areas\FormManage\Views\FormModule\CustmerFormIndex.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/Content/scripts/utils/custmerform/formindexjs"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n            <table>\r\n                <tr>\r\n                    <td");

WriteLiteral(" style=\"padding-left: 5px;\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>&nbsp;查询</a>\r\n                    </td>\r\n                </tr>\r\n            " +
"</table>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"learun.reload();\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>&nbsp;刷新</a>\r\n                <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_add()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>&nbsp;新增</a>\r\n                <a");

WriteLiteral(" id=\"lr-edit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_edit()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pencil-square-o\"");

WriteLiteral("></i>&nbsp;编辑</a>\r\n                <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_delete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>&nbsp;删除</a>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n        <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591