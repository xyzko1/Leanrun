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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/GeneratorManage/Views/SingleTable/EditSearch.cshtml")]
    public partial class _Areas_GeneratorManage_Views_SingleTable_EditSearch_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_GeneratorManage_Views_SingleTable_EditSearch_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\GeneratorManage\Views\SingleTable\EditSearch.cshtml"
  
    ViewBag.Title = "编辑查询条件";
    Layout = "~/Views/Shared/_LayoutIndex.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    var dataBaseLinkId = request(\'dataBaseLinkId\');\r\n    var tableNam" +
"e = request(\'tableName\');\r\n    $(function () {\r\n        var dataJson = getInfoTo" +
"p().Form.bindingTableJson;\r\n        if (dataJson != \"\") {\r\n            colModelJ" +
"son = dataJson.colModel;\r\n            if (dataJson.pager == true) {\r\n           " +
"     $(\"#Ispager\").attr(\"checked\", \'true\')\r\n            }\r\n        }\r\n        In" +
"itialPage();\r\n        GetTreeField();\r\n    });\r\n    //初始化页面\r\n    function Initia" +
"lPage() {\r\n        $(\'#TableField\').layout({\r\n            applyDemoStyles: true," +
"\r\n            west__size: 280,\r\n            spacing_open: 0,\r\n            onresi" +
"ze: function () {\r\n                $(window).resize()\r\n            }\r\n        })" +
";\r\n        $(\"#TableField\").height($(window).height() - 43)\r\n        $(\".center-" +
"Panel\").height($(window).height() - 44);\r\n        $(\"#align\").ComboBox({\r\n      " +
"      description: \"请选择\",\r\n        });\r\n        $(\"#hidden\").ComboBox({\r\n       " +
"     description: \"请选择\",\r\n        });\r\n        $(\"#sortable\").ComboBox({\r\n      " +
"      description: \"请选择\",\r\n        });\r\n        $(\"#formatter\").ComboBox({\r\n    " +
"        description: \"请选择\",\r\n        });\r\n    }\r\n    //加载表格字段\r\n    var colModelJ" +
"son = [];\r\n    function GetTreeField() {\r\n        var nameArray = [];\r\n        i" +
"f (colModelJson) {\r\n            $.each(colModelJson, function (i) {\r\n           " +
"     nameArray.push(colModelJson[i].name)\r\n            });\r\n        }\r\n        $" +
"(\"#itemTree\").treeview({\r\n            height: $(window).height() - 44,\r\n        " +
"    showcheck: true,\r\n            url: \"../../SystemManage/DataBaseTable/GetTabl" +
"eFiledTreeJson\",\r\n            param: { dataBaseLinkId: dataBaseLinkId, tableName" +
": tableName, nameId: String(nameArray) },\r\n            onnodeclick: function (it" +
"em) {\r\n                $.each(colModelJson, function (i) {\r\n                    " +
"var row = colModelJson[i];\r\n                    if (row.name == item.id) {\r\n    " +
"                    $(\"#field_form\").SetWebControls(row);\r\n                     " +
"   $(\"#btn_save_field\").removeAttr(\'disabled\');\r\n                        return " +
"false;\r\n                    } else {\r\n                        $(\"#btn_save_field" +
"\").attr(\'disabled\', \'disabled\');\r\n                        $(\"#field_form\").SetWe" +
"bControls({ label: \"\", name: \"\", width: \"\", align: \"\", hidden: \"\", sortable: \"\"," +
" formatter: \"\", });\r\n                    }\r\n                });\r\n            },\r" +
"\n            oncheckboxclick: function (item, status) {\r\n                if (sta" +
"tus == 1) {\r\n                    //添加字段\r\n                    var row = {\r\n      " +
"                  label: item.value,\r\n                        name: item.id,\r\n  " +
"                      width: 100,\r\n                        align: \'left\',\r\n     " +
"                   sortable: true,\r\n                        formatter: \'string\'," +
"\r\n                    }\r\n                    colModelJson.push(row);\r\n          " +
"          $(\"#field_form\").SetWebControls(row);\r\n                } else if (stat" +
"us == 0) {\r\n                    //删除字段\r\n                    $.each(colModelJson," +
" function (i) {\r\n                        if (colModelJson[i].name == item.id) {\r" +
"\n                            colModelJson.splice(i, 1);\r\n                       " +
"     return false;\r\n                        }\r\n                    });\r\n        " +
"        }\r\n            }\r\n        });\r\n        //保存字段\r\n        $(\"#btn_save_fiel" +
"d\").click(function () {\r\n            if (!$(\'#field_form\').Validform()) {\r\n     " +
"           return false;\r\n            }\r\n            var postData = {\r\n         " +
"       label: $(\"#label\").val(),\r\n                name: $(\"#name\").val(),\r\n     " +
"           width: $(\"#width\").val(),\r\n                align: $(\"#align\").attr(\'d" +
"ata-value\'),\r\n                sortable: $(\"#sortable\").attr(\'data-value\'),\r\n    " +
"            formatter: $(\"#formatter\").attr(\'data-value\'),\r\n            }\r\n     " +
"       if ($(\"#hidden\").attr(\'data-value\') == \"true\") {\r\n                postDat" +
"a[\"hidden\"] = true;\r\n            }\r\n            $.each(colModelJson, function (i" +
") {\r\n                if (colModelJson[i].name == postData.name) {\r\n             " +
"       colModelJson[i] = postData;\r\n                    return false;\r\n         " +
"       }\r\n            });\r\n        });\r\n    }\r\n    //保存表单\r\n    function AcceptCl" +
"ick(callBack) {\r\n        var dataJson = {\r\n            pager: $(\"#Ispager\").is(\"" +
":checked\"),\r\n            colModel: colModelJson\r\n        }\r\n        callBack(dat" +
"aJson);\r\n        dialogClose();\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" id=\"TableField\"");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(" style=\"margin: 0px; border-top: none; border-left: none; border-bottom: none;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"itemTree\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(" style=\"margin: 0px; border: none; background-color: #fff; overflow: auto;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"alert alert-danger\"");

WriteLiteral(" style=\"text-align: left; margin: 10px;\"");

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-question-circle alert-dismissible\"");

WriteLiteral(" style=\"position: relative; top: 1px; font-size: 15px; padding-right: 5px;\"");

WriteLiteral("></i>\r\n                注：请在左侧勾选需要查询的字段。\r\n            </div>\r\n            <div");

WriteLiteral(" style=\"margin-left: 0px; margin-top: 20px; margin-right: 15px;\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"field_form\"");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n                    <tr>\r\n                        <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width: 60px;\"");

WriteLiteral(">题头</th>\r\n                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" id=\"name\"");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" />\r\n                            <input");

WriteLiteral(" id=\"label\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n                        </td>\r\n                        <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width: 60px;\"");

WriteLiteral(">宽度</th>\r\n                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" id=\"width\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"Num\"");

WriteLiteral(" />\r\n                        </td>\r\n\r\n                    </tr>\r\n                " +
"    <tr>\r\n                        <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width: 60px;\"");

WriteLiteral(">隐藏</th>\r\n                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" id=\"hidden\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(">\r\n                                <ul>\r\n                                    <li");

WriteLiteral(" data-value=\"\"");

WriteLiteral(">请选择</li>\r\n                                    <li");

WriteLiteral(" data-value=\"true\"");

WriteLiteral(">是</li>\r\n                                    <li");

WriteLiteral(" data-value=\"false\"");

WriteLiteral(">否</li>\r\n                                </ul>\r\n                            </div" +
">\r\n                        </td>\r\n                        <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width: 60px;\"");

WriteLiteral(">对齐</th>\r\n                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" id=\"align\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(">\r\n                                <ul>\r\n                                    <li");

WriteLiteral(" data-value=\"left\"");

WriteLiteral(">左边</li>\r\n                                    <li");

WriteLiteral(" data-value=\"center\"");

WriteLiteral(">居中</li>\r\n                                    <li");

WriteLiteral(" data-value=\"right\"");

WriteLiteral(">右边</li>\r\n                                </ul>\r\n                            </di" +
"v>\r\n                        </td>\r\n                    </tr>\r\n                  " +
"  <tr>\r\n                        <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width: 60px;\"");

WriteLiteral(">排序</th>\r\n                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" id=\"sortable\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(">\r\n                                <ul>\r\n                                    <li");

WriteLiteral(" data-value=\"true\"");

WriteLiteral(">是</li>\r\n                                    <li");

WriteLiteral(" data-value=\"false\"");

WriteLiteral(">否</li>\r\n                                </ul>\r\n                            </div" +
">\r\n                        </td>\r\n                        <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width: 60px;\"");

WriteLiteral(">格式</th>\r\n                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" id=\"formatter\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(">\r\n                                <ul>\r\n                                    <li");

WriteLiteral(" data-value=\"\"");

WriteLiteral(">请选择</li>\r\n                                    <li");

WriteLiteral(" data-value=\"string\"");

WriteLiteral(">字符</li>\r\n                                    <li");

WriteLiteral(" data-value=\"date\"");

WriteLiteral(">日期</li>\r\n                                    <li");

WriteLiteral(" data-value=\"int\"");

WriteLiteral(">数字</li>\r\n                                    <li");

WriteLiteral(" data-value=\"money\"");

WriteLiteral(">金额</li>\r\n                                </ul>\r\n                            </di" +
"v>\r\n                        </td>\r\n                    </tr>\r\n                  " +
"  <tr>\r\n                        <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral("></td>\r\n                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" id=\"btn_save_field\"");

WriteLiteral(" disabled");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>&nbsp;保&nbsp;存</a>\r\n                        </td>\r\n                    </tr>" +
"\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</di" +
"v>\r\n");

        }
    }
}
#pragma warning restore 1591
