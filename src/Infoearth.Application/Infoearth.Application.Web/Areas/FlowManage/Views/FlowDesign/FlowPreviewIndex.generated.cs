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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/FlowManage/Views/FlowDesign/FlowPreviewIndex.cshtml")]
    public partial class _Areas_FlowManage_Views_FlowDesign_FlowPreviewIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_FlowManage_Views_FlowDesign_FlowPreviewIndex_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 6 "..\..\Areas\FlowManage\Views\FlowDesign\FlowPreviewIndex.cshtml"
  
    ViewBag.Title = "流程模板预览";
    Layout = "~/Views/Shared/_FlowForm.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<style>\r\n    body {\r\n        overflow: hidden;\r\n    }\r\n    .panels {\r\n        p" +
"adding: 10px;\r\n    }\r\n</style>\r\n<div");

WriteLiteral(" style=\"position:absolute;top:0; right:100px;z-index:1000;background:rgba(0, 0, 0" +
", 0.1);padding:10px;border-radius:0px 0px 5px 5px;\"");

WriteLiteral(">\r\n    <a");

WriteLiteral(" class=\"btn btn-success\"");

WriteLiteral(" onclick=\"$.indexJs.btn.flowshow()\"");

WriteLiteral(">&nbsp;流程预览</a>\r\n    <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"$.indexJs.btn.fromshow()\"");

WriteLiteral(">&nbsp;表单预览</a>\r\n</div>\r\n<div");

WriteLiteral(" class=\"panels\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"formPreviewPanel\"");

WriteLiteral(" style=\"overflow-y:auto;background-color:#fff;display:none;border: 1px solid #ccc" +
";\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" id=\"formAreas\"");

WriteLiteral(" style=\"margin: 30px auto;max-width: 1000px;\"");

WriteLiteral(">\r\n            <ul");

WriteLiteral(" id=\"formTitle\"");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n            </ul>\r\n            <div");

WriteLiteral(" id=\"formContent\"");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"flowPreviewPanel\"");

WriteLiteral(" style=\"margin: 0px;border: 1px solid #ccc;\"");

WriteLiteral("></div>\r\n</div>\r\n<script>\r\n    (function ($) {\r\n        \"use strict\";\r\n\r\n        " +
"$.indexJs = {\r\n            schemeInfoId: \"\",\r\n            schemeVersion: \"\",\r\n  " +
"          processSchemeId: \"\",\r\n            allForm: {},\r\n            formWidth:" +
"1000,\r\n            initialPage: function () {\r\n                //resize重设(表格、树形)" +
"宽高\r\n                $(window).resize(function (e) {\r\n                    window." +
"setTimeout(function () {\r\n                        $(\'#formPreviewPanel\').css(\"he" +
"ight\", e.currentTarget.innerHeight - 20);\r\n                        $(\'#formAreas" +
"\').css(\"width\", e.currentTarget.innerWidth * 0.9 - 20);\r\n                       " +
" if (!!$.indexJs.schemeContent) {\r\n                            $(\'#flowPreviewPa" +
"nel\').flowdesign({\r\n                                height: e.currentTarget.inne" +
"rHeight - 18,\r\n                                width: e.currentTarget.innerWidth" +
" - 20,\r\n                                flowcontent: schemeContent.Flow,\r\n      " +
"                          haveTool: false\r\n                            });\r\n    " +
"                    }\r\n                    }, 200);\r\n                    e.stopP" +
"ropagation();\r\n                });\r\n                $(\'#formAreas\').css(\"width\"," +
" $(window).width() * 0.9 - 20);\r\n                $(\'#formPreviewPanel\').css(\"hei" +
"ght\", $(window).height() - 20);\r\n\r\n                $.indexJs.formWidth = $(windo" +
"w).width() * 0.9 - 20;\r\n                if ($.indexJs.formWidth > 1000) {\r\n     " +
"               $.indexJs.formWidth = 1000;\r\n                }\r\n            },\r\n " +
"           initialData: function () {\r\n                $.indexJs.schemeInfoId = " +
"learun.request(\'schemeInfoId\');\r\n                $.indexJs.processSchemeId = lea" +
"run.request(\'processSchemeId\');\r\n            },\r\n            loadData:function()" +
"{\r\n                if (!!$.indexJs.schemeInfoId) {\r\n                    $.SetFor" +
"m({\r\n                        url: \"../../FlowManage/FlowDesign/GetFormJson\",\r\n  " +
"                      param: { keyValue: $.indexJs.schemeInfoId},\r\n             " +
"           success: function (data) {\r\n                            $.indexJs.sch" +
"emeContent = JSON.parse(data.schemeinfo.F_SchemeContent);\r\n                     " +
"       if (data.F_FormList != \"\")\r\n                            {\r\n              " +
"                  var dlist = data.schemeinfo.F_FormList.split(\',\');\r\n          " +
"                      for (var d in dlist)\r\n                                {\r\n " +
"                                   var done = dlist[d];\r\n                       " +
"             learun.getDataForm({\r\n                                        type:" +
" \'get\',\r\n                                        url: \"../../FormManage/FormModu" +
"le/GetEntityJson\",\r\n                                        param: { keyValue: d" +
"one },\r\n                                        success: function (dd) {\r\n      " +
"                                      if (dd != null) {\r\n                       " +
"                         var _dataJson = JSON.parse(dd.F_FrmContent);\r\n         " +
"                                       $.indexJs.allForm[done] = _dataJson;\r\n   " +
"                                             var $li = $(\'<li><a href=\"#form_\' +" +
" dd.F_FrmId + \'\" data-toggle=\"tab\">\' + dd.F_FrmName + \'</a></li>\');\r\n           " +
"                                     var $div = $(\'<div id=\"form_\' + dd.F_FrmId " +
"+ \'\" class=\"tab-pane\" ><div class=\"app_layout app_preview\" id=\"formContent_\' + d" +
"d.F_FrmId + \'\"></div></div>\');\r\n                                                " +
"if (d == 0) {\r\n                                                    $li.addClass(" +
"\'active\');\r\n                                                    $div.addClass(\'a" +
"ctive\');\r\n                                                }\r\n                   " +
"                             $(\'#formTitle\').append($li);\r\n                     " +
"                           $(\'#formContent\').append($div);\r\n                    " +
"                            if (_dataJson.type == 2) {\r\n                        " +
"                            $(\'#formContent_\' + dd.F_FrmId).html(\'<iframe id=\"fo" +
"rmIframe_\' + dd.F_FrmId + \'\" frameborder=\"no\" border=\"0\" marginwidth=\"0\" marginh" +
"eight=\"0\" scrolling=\"no\" style=\"height:100%;width:100%;\"></iframe>\');\r\n         " +
"                                           learun.loadSystemForm(\'formIframe_\' +" +
" dd.F_FrmId, _dataJson.data.url);\r\n                                             " +
"   }\r\n                                                else {\r\n                  " +
"                                  $(\'#formContent_\' + dd.F_FrmId).formRendering(" +
"\'init\', { formData: _dataJson.data });;\r\n                                       " +
"         }\r\n                                            }\r\n                     " +
"                       $(\'#formContent\').find(\'iframe\').height($(window).height(" +
") - 130);\r\n                                        }\r\n                          " +
"          });\r\n                                }\r\n                            }\r" +
"\n                            $(\'#flowPreviewPanel\').flowDesigner({\r\n            " +
"                    height: $(window).height() - 18,\r\n                          " +
"      width: $(window).width() - 20,\r\n                                schemeCont" +
"ent: $.indexJs.schemeContent,\r\n                                frmData: [],//JSO" +
"N.parse(schemeContent.Frm == \"\" ?\"[]\":schemeContent.Frm.F_FrmContent),\r\n        " +
"                        haveTool: false,\r\n                                previe" +
"w: 1\r\n                            });\r\n\r\n                            \r\n         " +
"                  \r\n\r\n                        }\r\n                    });\r\n      " +
"          }\r\n                else {\r\n                    $.SetForm({\r\n          " +
"              url: \"../../FlowManage/FlowProcess/GetProcessSchemeJson\",\r\n       " +
"                 param: { keyValue: processSchemeId },\r\n                        " +
"success: function (data) {\r\n                            $.indexJs.schemeContent " +
"= JSON.parse(JSON.parse(data.F_SchemeContent).SchemeContent);\r\n\r\n               " +
"             if (typeof $.indexJs.schemeContent.Frm == \"string\") {\r\n            " +
"                    $(\'#frmpreview\').html(\'<iframe src=\"\' + $.indexJs.schemeCont" +
"ent.Frm + \'\" style=\"    width: 100%;border: 0px;\"></iframe>\');\r\n                " +
"                $(\'#frmpreview\').find(\'iframe\').height($(window).height() - 100)" +
";\r\n                            }\r\n                            else {\r\n          " +
"                      $(\'#frmpreview\').frmPreview({\r\n                           " +
"         tablecotent: $.indexJs.schemeContent.Frm.F_FrmContent,\r\n               " +
"                     width: $.indexJs.formWidth,\r\n                              " +
"  });\r\n                                $(\'#frmname\').html($.indexJs.schemeConten" +
"t.Frm.F_FrmName);\r\n                            }\r\n\r\n                            " +
"$(\'#flowPreviewPanel\').flowDesigner({\r\n                                height: $" +
"(window).height() - 18,\r\n                                width: $(window).width(" +
") - 20,\r\n                                schemeContent: $.indexJs.schemeContent." +
"Flow,\r\n                                frmData: JSON.parse($.indexJs.schemeConte" +
"nt.Frm == \"\" ? \"[]\" : schemeContent.Frm.F_FrmContent),\r\n                        " +
"        haveTool: false,\r\n                                preview: 1\r\n          " +
"                  });\r\n                        }\r\n                    });\r\n     " +
"           }\r\n            },\r\n            btn: {\r\n                flowshow: func" +
"tion () {\r\n                    $(\'#formPreviewPanel\').hide();\r\n                 " +
"   $(\'#flowPreviewPanel\').show();\r\n                },\r\n                fromshow:" +
" function () {\r\n                    $(\'#flowPreviewPanel\').hide();\r\n            " +
"        $(\'#formPreviewPanel\').show();\r\n                }\r\n            }\r\n      " +
"  };\r\n        $(function () {\r\n            \r\n            $.indexJs.initialPage()" +
";\r\n            $.indexJs.initialData();\r\n            $.indexJs.loadData();\r\n    " +
"    });\r\n    })(window.jQuery);\r\n</script>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
