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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/SystemManage/Views/DataItem/Form.cshtml")]
    public partial class _Areas_SystemManage_Views_DataItem_Form_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_SystemManage_Views_DataItem_Form_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\SystemManage\Views\DataItem\Form.cshtml"
  
    ViewBag.Title = "分类管理";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var keyValue = learun.request(\'keyValue\');\r\n    var parentId = le" +
"arun.request(\'parentId\');\r\n    $(function () {\r\n        initControl();\r\n    })\r\n" +
"    //初始化控件\r\n    function initControl() {\r\n        //上级\r\n        $(\"#F_ParentId\"" +
").comboBoxTree({\r\n            url: \"../../SystemManage/DataItem/GetTreeJson\",\r\n " +
"           maxHeight: \"230px\"\r\n        });\r\n        //获取表单\r\n        if (!!keyVal" +
"ue) {\r\n            learun.setForm({\r\n                url: \"../../SystemManage/Da" +
"taItem/GetFormJson\",\r\n                param: { keyValue: keyValue },\r\n          " +
"      success: function (data) {\r\n                    $(\"#form1\").setWebControls" +
"(data);\r\n                }\r\n            });\r\n        } else {\r\n            $(\"#F" +
"_ParentId\").comboBoxTreeSetValue(parentId);\r\n        }\r\n    }\r\n    //保存表单\r\n    f" +
"unction AcceptClick() {\r\n        if (!$(\'#form1\').Validform()) {\r\n            re" +
"turn false;\r\n        }\r\n        if (keyValue == undefined) {\r\n            keyVal" +
"ue = \"\";\r\n        } \r\n        var postData = $(\"#form1\").getWebControls(keyValue" +
");\r\n        if (postData[\"F_ParentId\"] == \"\") {\r\n            postData[\"F_ParentI" +
"d\"] = 0;\r\n        }\r\n        learun.saveForm({\r\n            url: \"../../SystemMa" +
"nage/DataItem/SaveForm?keyValue=\" + keyValue,\r\n            param: postData,\r\n   " +
"         loading: \"正在保存数据...\",\r\n            success: function () {\r\n            " +
"    getInfoTop().DataItemSort.$(\"#gridTable\").resetSelection();\r\n               " +
" getInfoTop().DataItemSort.$(\"#gridTable\").trigger(\"reloadGrid\");\r\n            }" +
"\r\n        })\r\n    }\r\n</script>\r\n    ");

});

WriteLiteral("<div");

WriteLiteral(" style=\"margin-top: 20px; margin-right: 30px;\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">上级</th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_ParentId\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral("></div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">名称<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_ItemName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" onblur=\"$.ExistField(this.id,\'../../SystemManage/DataItem/ExistItemName\')\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入名称\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">编号<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_ItemCode\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" onblur=\"$.ExistField(this.id,\'../../SystemManage/DataItem/ExistItemCode\')\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入编号\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">排序<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_SortCode\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"Num\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"height: 37px;\"");

WriteLiteral("></th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n                    <label>\r\n                        <input");

WriteLiteral(" id=\"F_IsTree\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" />\r\n                        树型\r\n                    </label>\r\n                  " +
"  <label>\r\n                        <input");

WriteLiteral(" id=\"F_EnabledMark\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" checked=\"checked\"");

WriteLiteral(" />\r\n                        有效\r\n                    </label>\r\n                </" +
"div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 4px;\"");

WriteLiteral(">备注\r\n            </th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <textarea");

WriteLiteral(" id=\"F_Description\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"height: 70px;\"");

WriteLiteral("></textarea>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
