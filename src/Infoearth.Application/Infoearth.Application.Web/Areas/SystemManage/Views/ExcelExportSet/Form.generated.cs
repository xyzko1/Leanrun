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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/SystemManage/Views/ExcelExportSet/Form.cshtml")]
    public partial class _Areas_SystemManage_Views_ExcelExportSet_Form_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_SystemManage_Views_ExcelExportSet_Form_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\SystemManage\Views\ExcelExportSet\Form.cshtml"
  
    ViewBag.Title = "excel导出配置";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    $(function () {\r\n       " +
" initControl();\r\n    })\r\n    //初始化控件\r\n    function initControl() {\r\n        //绑定" +
"功能\r\n        $(\"#F_ModuleId\").comboBoxTree({\r\n            url: \"../../AuthorizeMa" +
"nage/Module/GetTreeJson\",\r\n            description: \"==请选择==\",\r\n            maxH" +
"eight: \"160px\",\r\n            allowSearch: true,\r\n            click: function (it" +
"em) {\r\n                if (item.F_Target == \"iframe\") {\r\n                    $(\"" +
".tip_container\").remove();\r\n                    //绑定按钮\r\n                    $(\"#" +
"F_ModuleBtnId\").comboBox({\r\n                        url: \"../../AuthorizeManage/" +
"ModuleButton/GetTreeListJson?moduleId=\" + item.id,\r\n                        id: " +
"\"F_ModuleButtonId\",\r\n                        text: \"F_FullName\",\r\n              " +
"          maxHeight: \"160px\",\r\n                        allowSearch: true,\r\n     " +
"                   dataName: \"rows\"\r\n                    });\r\n                }\r" +
"\n                else {\r\n                    learun.dialogTop({ msg: \"请选择功能页面\", " +
"type: \"error\" });\r\n                    return \"false\";\r\n                }\r\n     " +
"       }\r\n        });\r\n        //绑定按钮\r\n        $(\"#F_ModuleBtnId\").comboBox({});" +
"\r\n    }\r\n    //保存表单\r\n    function AcceptClick() {\r\n        if (!$(\'#form1\').Vali" +
"dform()) {\r\n            return false;\r\n        }\r\n        var postData = $(\"#for" +
"m1\").GetWebControls(keyValue);\r\n        $.SaveForm({\r\n            url: \"../../Sy" +
"stemManage/ExcelExportSet/SaveForm?keyValue=\" + keyValue,\r\n            param: po" +
"stData,\r\n            loading: \"正在保存数据...\",\r\n            success: function () {\r\n" +
"                try {\r\n                    getInfoTop().learun.currentIframe().$" +
"(\"#gridTable\").trigger(\"reloadGrid\");\r\n                } catch (e) {\r\n          " +
"          window.parent.$(\"#gridTable\").trigger(\"reloadGrid\");\r\n                " +
"}\r\n            }\r\n        })\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" style=\"margin-left: 20px; margin-top: 20px; margin-right: 20px;\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width:62px;\"");

WriteLiteral(">绑定功能<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_ModuleId\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral("></div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width:62px;\"");

WriteLiteral(">绑定按钮<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_ModuleBtnId\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral("></div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">导出名称<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Name\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("  isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">JqGridID<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_GridId\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n       \r\n</table>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
