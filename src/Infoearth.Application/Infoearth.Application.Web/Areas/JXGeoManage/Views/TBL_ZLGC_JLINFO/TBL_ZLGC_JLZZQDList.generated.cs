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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_ZLGC_JLINFO/TBL_ZLGC_JLZZQDList.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_ZLGC_JLINFO_TBL_ZLGC_JLZZQDList_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_ZLGC_JLINFO_TBL_ZLGC_JLZZQDList_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_ZLGC_JLINFO\TBL_ZLGC_JLZZQDList.cshtml"
  
    ViewBag.Title = "治理工程-工程监理-资质清单";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 5 "..\..\Areas\JXGeoManage\Views\TBL_ZLGC_JLINFO\TBL_ZLGC_JLZZQDList.cshtml"
  
    ViewBag.Title = "";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<style>\r\n    body {\r\n        height:auto\r\n    }\r\n</style>\r\n<div");

WriteLiteral(" style=\"margin: 10px;\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(" id=\"gridTable_JLZZQD\"");

WriteLiteral(">\r\n        <tr");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">JLZZQDID</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"JLZZQDID\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">资质名称</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"JLZZNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">资质等级</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"JLZZLEVE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">备注</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"JLBZ\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  />\r\n            </td> \r\n        </tr>\r\n    </table>\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    var ZLGCID = request(\"ZL" +
"GCID\");\r\n    var NewkeyValue = request(\"NewkeyValue\");\r\n\r\n    var ulrinfo = wind" +
"ow.location.href;\r\n    var Info_ZZQDID = \"\";\r\n    var Info_NAME = \"\";\r\n    var I" +
"nfo_Leve = \"\";\r\n    var Info_BZ = \"\";\r\n    if (ulrinfo.split(\"&\")[3] != undefine" +
"d && ulrinfo.split(\"&\")[3] != \"\")\r\n    {\r\n        var infoS = ulrinfo.split(\"&\")" +
"[3].split(\"=\")[1];\r\n        var info = decodeURI(infoS);\r\n        if (info != \"\"" +
" || info != undefined)\r\n        {\r\n            var infoArrry = info.split(\',\');\r" +
"\n            Info_ZZQDID = infoArrry[0];\r\n            Info_NAME = infoArrry[1];\r" +
"\n            Info_Leve = infoArrry[2];\r\n            Info_BZ = infoArrry[3];\r\n   " +
"     }\r\n    }   \r\n    var authToken = getAuthorizationToken();\r\n    $(function (" +
") {\r\n        initControl();\r\n    });\r\n    //初始化控件\r\n    function initControl() {\r" +
"\n        //获取表单\r\n        var queryJson = {};\r\n        queryJson[\"keyValue\"] = ke" +
"yValue;\r\n        queryJson[\"ZLGCID\"] = ZLGCID;\r\n        \r\n        if (keyValue) " +
"{\r\n            $(\'#JLZZQDID\').val(Info_ZZQDID);\r\n            $(\'#JLZZNAME\').val(" +
"Info_NAME);\r\n            $(\'#JLZZLEVE\').val(Info_Leve);\r\n            $(\'#JLBZ\')." +
"val(Info_BZ);\r\n        }\r\n        else\r\n        {\r\n            //新增keyValue的值为空\r" +
"\n            //获取根据ZLGCID获取对应存在的\r\n            $(\'#JLZZQDID\').val(NewkeyValue);\r\n" +
"        }\r\n    }\r\n    //保存表单;\r\n    function AcceptClick(callback) {\r\n        if " +
"(!$(\'#gridTable_JLZZQD\').Validform()) {\r\n            return false;\r\n        }\r\n " +
"       data = JSON.stringify($(\"#gridTable_JLZZQD\").GetWebControls(keyValue));\r\n" +
"        callback(data);\r\n        learun.dialogClose();\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
