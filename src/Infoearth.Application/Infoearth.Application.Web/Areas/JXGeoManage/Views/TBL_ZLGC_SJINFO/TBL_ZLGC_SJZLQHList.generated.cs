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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_ZLGC_SJINFO/TBL_ZLGC_SJZLQHList.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_ZLGC_SJINFO_TBL_ZLGC_SJZLQHList_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_ZLGC_SJINFO_TBL_ZLGC_SJZLQHList_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_ZLGC_SJINFO\TBL_ZLGC_SJZLQHList.cshtml"
  
    ViewBag.Title = "治理工程-施工设计-治理区域划分";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 5 "..\..\Areas\JXGeoManage\Views\TBL_ZLGC_SJINFO\TBL_ZLGC_SJZLQHList.cshtml"
  
    ViewBag.Title = "表单页面";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<style>\r\n    body {\r\n        height:auto\r\n    }\r\n</style>\r\n<div");

WriteLiteral(" style=\"margin: 10px;\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(" id=\"gridTable_SJQYHF\"");

WriteLiteral(">\r\n        <tr");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">QYHFID</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"QYHFID\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">治理区域名称</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"QYHFNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">经度</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"LONGITUDE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">纬度</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"LATITUDE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td> \r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">治理面积</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"ZLAREA\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td> \r\n        </tr>\r\n    </table>\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    var ZLGCID = request(\"ZL" +
"GCID\");\r\n    var NewkeyValue = request(\"NewkeyValue\");\r\n\r\n    var ulrinfo = wind" +
"ow.location.href;\r\n    var Info_QYHFID = \"\";\r\n    var Info_QYHFNAME = \"\";\r\n    v" +
"ar Info_LONGITUDE = \"\";\r\n    var Info_LATITUDE = \"\";\r\n    var Info_ZLAREA = \"\";\r" +
"\n    if (ulrinfo.split(\"&\")[3] != undefined && ulrinfo.split(\"&\")[3] != \"\") {\r\n " +
"       var infoS = ulrinfo.split(\"&\")[3].split(\"=\")[1];\r\n        var info = deco" +
"deURI(infoS);\r\n        if (info != \"\" || info != undefined) {\r\n            var i" +
"nfoArrry = info.split(\',\');\r\n            Info_QYHFID = infoArrry[0];\r\n          " +
"  Info_QYHFNAME = infoArrry[1];\r\n            Info_LONGITUDE = infoArrry[2];\r\n   " +
"         Info_LATITUDE = infoArrry[3];\r\n            Info_ZLAREA = infoArrry[4];\r" +
"\n        }\r\n    }\r\n\r\n    var authToken = getAuthorizationToken();\r\n    $(functio" +
"n () {\r\n        initControl();\r\n    });\r\n    //初始化控件\r\n    function initControl()" +
" {\r\n        //获取表单\r\n        var queryJson = {};\r\n        queryJson[\"keyValue\"] =" +
" keyValue;\r\n        queryJson[\"ZLGCID\"] = ZLGCID;\r\n\r\n        if (keyValue) {\r\n  " +
"          $(\'#QYHFID\').val(Info_QYHFID);\r\n            $(\'#QYHFNAME\').val(Info_QY" +
"HFNAME);\r\n            $(\'#LONGITUDE\').val(Info_LONGITUDE);\r\n            $(\'#LATI" +
"TUDE\').val(Info_LATITUDE);\r\n            $(\'#ZLAREA\').val(Info_ZLAREA);\r\n        " +
"}\r\n        else {\r\n            //新增keyValue的值为空\r\n            //获取根据ZLGCID获取对应存在的" +
"\r\n            $(\'#QYHFID\').val(NewkeyValue);\r\n        }\r\n    }\r\n    //保存表单;\r\n   " +
" function AcceptClick(callback) {\r\n        if (!$(\'#gridTable_SJQYHF\').Validform" +
"()) {\r\n            return false;\r\n        }\r\n        data = JSON.stringify($(\"#g" +
"ridTable_SJQYHF\").GetWebControls(keyValue));\r\n        callback(data);\r\n        l" +
"earun.dialogClose();\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
