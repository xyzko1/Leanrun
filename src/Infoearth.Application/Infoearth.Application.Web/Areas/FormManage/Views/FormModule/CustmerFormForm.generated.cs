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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/FormManage/Views/FormModule/CustmerFormForm.cshtml")]
    public partial class _Areas_FormManage_Views_FormModule_CustmerFormForm_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_FormManage_Views_FormModule_CustmerFormForm_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\FormManage\Views\FormModule\CustmerFormForm.cshtml"
  
    ViewBag.Title = "自定义表单新增编辑";
    Layout = "~/Views/Shared/_CustmerForm.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    var formRelationId = req" +
"uest(\'formRelationId\');\r\n    $(function () {\r\n        $.pageFn.init();\r\n    });\r" +
"\n    (function ($) {\r\n        var frm = {\r\n            content: JSON.parse($.cur" +
"rentIframe().$.pageFn.frmEntity.F_FrmContent),\r\n            loadForm: function (" +
") {\r\n                $(\'#frmpreview\').height($(window).height());\r\n             " +
"   $(\'#frmpreview\').formRendering(\'init\', { formData: frm.content.data });\r\n    " +
"        }\r\n        };\r\n        var getData = function () {\r\n            if (!!ke" +
"yValue) {\r\n                //获取表单\r\n                $.SetForm({\r\n                " +
"    url: \"../../FormManage/FormModule/GetInstanceEntityJson\",\r\n                 " +
"   param: { keyValue: keyValue },\r\n                    success: function (data) " +
"{\r\n                        $(\'#frmpreview\').formRendering(\'set\', { data: JSON.pa" +
"rse(data.F_FrmInstanceJson) });\r\n                    }\r\n                });\r\n   " +
"         }\r\n        };\r\n        $.pageFn = {\r\n            init: function () {\r\n " +
"               frm.loadForm();\r\n                getData();\r\n            }\r\n     " +
"   };\r\n    })(window.jQuery);\r\n    //保存表单\r\n    function AcceptClick() {\r\n       " +
" var data = $(\'#frmpreview\').formRendering(\'get\');\r\n        if (!!data)\r\n       " +
" {\r\n            var postData = {\r\n                F_FrmContentId: $.currentIfram" +
"e().$.pageFn.frmEntity.F_Id,\r\n                F_FrmInstanceJson: JSON.stringify(" +
"data),\r\n                F_ObjectId: formRelationId\r\n            };\r\n            " +
"$.SaveForm({\r\n                url: \"../../FormManage/FormModule/SaveCustmerFormI" +
"nstance?keyValue=\" + keyValue,\r\n                param: postData,\r\n              " +
"  loading: \"正在保存数据...\",\r\n                success: function () {\r\n               " +
"     $.currentIframe().$(\"#gridTable\").trigger(\"reloadGrid\");\r\n                }" +
"\r\n            });\r\n        }\r\n    };\r\n</script>\r\n<div");

WriteLiteral(" id=\"frmpreview\"");

WriteLiteral(" style=\"padding-right:20px;overflow-y:auto;\"");

WriteLiteral(">\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
