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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_ZLGC_KCINFO/TBL_ZLGC_KCINFOForm.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_ZLGC_KCINFO_TBL_ZLGC_KCINFOForm_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_ZLGC_KCINFO_TBL_ZLGC_KCINFOForm_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_ZLGC_KCINFO\TBL_ZLGC_KCINFOForm.cshtml"
  
    ViewBag.Title = "表单页面";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<style>\r\n    body {\r\n        height: auto\r\n    }\r\n\r\n    .form .formTitle {\r\n   " +
"     background: #fff\r\n    }\r\n</style>\r\n<div");

WriteLiteral(" style=\"margin: 10px;\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(" id=\"ZLGC_KC\"");

WriteLiteral(">\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">勘察单位<span");

WriteLiteral(" class=\"required\"");

WriteLiteral(" style=\"color:red\"");

WriteLiteral(">*</span></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"KCDW\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                <input");

WriteLiteral(" id=\"MEDIAGUID\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral("/>\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">联系电话</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"LXDH\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">勘察费用(万元)</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"KCFY\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">勘察开始时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"KCKSSJ\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">勘察结束时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"KCJSSJ\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">合同签订时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"HTQDSJ\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">招标时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"ZHAOBIAOSJ\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">中标时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"ZHONGBIAOSJ\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">勘察审查专家</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"KCSCZJ\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">勘察审查时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"KCSCSJ\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        ");

WriteLiteral("\r\n        <tr");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">治理工程名称</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"ZLGCNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">治理工程编号</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"ZLGCID\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n    </table>\r\n    <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(" style=\"background-color: rgba(236, 247, 255, 1); color: #000; height: 30px; bord" +
"er-radius: 5px\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-bars\"");

WriteLiteral("></i>附件</div>\r\n    <div");

WriteLiteral(" style=\"height: 450px; width: 100%;\"");

WriteLiteral(">\r\n        <iframe");

WriteLiteral(" class=\"LRADMS_iframe\"");

WriteLiteral(" id=\"QCQFLmedia2\"");

WriteLiteral(" frameborder=\"0\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" style=\"border: none; width: 100%; height: 100%;\"");

WriteLiteral("></iframe>\r\n    </div>\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    var authToken = getAutho" +
"rizationToken();\r\n    var readonly = request(\'readonly\');\r\n    var xq = request(" +
"\'xq\');\r\n    $(function () {\r\n        initControl();\r\n    });\r\n    //初始化控件\r\n    f" +
"unction initControl() {\r\n        //获取表单\r\n        if (!!keyValue) {\r\n            " +
"$.SetForm({\r\n                //url: \"../../JXGeoManage/TBL_ZLGC_KCINFO/GetFormJs" +
"on\", //控制器写法\r\n                url: \"../../api/TBL_ZLGC/GetYWKC\",                " +
"      //api写法\r\n                authToken: authToken,\r\n                param: { k" +
"eyValue: keyValue },\r\n                success: function (data) {\r\n              " +
"      $(\"#ZLGC_KC\").SetWebControls(data);\r\n                }\r\n            })\r\n  " +
"      }\r\n        if (readonly == 01||xq==02) {\r\n            $(\"input\").attr(\"dis" +
"abled\", \"disabled\");\r\n        }\r\n    }\r\n    //保存表单;\r\n    function AcceptClick() " +
"{\r\n        if (!$(\'#form1\').Validform()) {\r\n            return false;\r\n        }" +
"\r\n        var postData = $(\"#form1\").GetWebControls(keyValue);\r\n        $.SaveFo" +
"rm({\r\n            url: \"../../JXGeoManage/TBL_ZLGC_KCINFO/SaveForm?keyValue=\" + " +
"keyValue,   //控制器写法\r\n            param: postData,\r\n            loading: \"正在保存数据." +
"..\",\r\n            success: function () {\r\n                      try {\r\n         " +
"                   getInfoTop().learun.currentIframe().$(\'#gridTable\').trigger(\'" +
"reloadGrid\');\r\n                      } catch (e) {\r\n                            " +
"window.parent.$(\'#gridTable\').trigger(\'reloadGrid\');\r\n                      }\r\n " +
"           }\r\n        })\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591