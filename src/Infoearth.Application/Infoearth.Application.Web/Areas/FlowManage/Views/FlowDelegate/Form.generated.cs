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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/FlowManage/Views/FlowDelegate/Form.cshtml")]
    public partial class _Areas_FlowManage_Views_FlowDelegate_Form_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_FlowManage_Views_FlowDelegate_Form_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\FlowManage\Views\FlowDelegate\Form.cshtml"
  
    ViewBag.Title = "角色成员";
    Layout = "~/Views/Shared/_LayoutIndex.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    $(function () {\r\n       " +
" InitialPage();\r\n        GetMember();\r\n    });\r\n    //初始化页面\r\n    function Initia" +
"lPage() {\r\n        //layout布局\r\n        $(\'#layout\').layout({\r\n            applyD" +
"emoStyles: true,\r\n            west__size: 260,\r\n            spacing_open: 0,\r\n  " +
"          onresize: function () {\r\n                $(window).resize()\r\n         " +
"   }\r\n        });\r\n        $(\".center-Panel\").height($(window).height() - 40)\r\n " +
"       $(\".west-Panel\").height($(window).height());\r\n\r\n        //被委托人\r\n        $" +
"(\"#F_ToUserId\").ComboBoxTree({\r\n            url: \"../../BaseManage/User/GetTreeJ" +
"son\",\r\n            description: \"==请选择==\",\r\n            height: \"348px\",\r\n      " +
"      allowSearch: true\r\n        });\r\n        if (!!keyValue)\r\n        {\r\n      " +
"      //获取表单\r\n            $.SetForm({\r\n                url: \"../../FlowManage/Fl" +
"owDelegate/GetRuleEntityJson\",\r\n                param: { keyValue: keyValue },\r\n" +
"                success: function (data) {\r\n                    $(\"#ruleinfo\").S" +
"etWebControls(data);\r\n                }\r\n            });\r\n        }\r\n    }\r\n    " +
"//加载成员\r\n    function GetMember() {\r\n        $.ajax({\r\n            url: \"../../Fl" +
"owManage/FlowDelegate/GetSchemeInfoList?ruleId=\" + keyValue,\r\n            type: " +
"\"get\",\r\n            dataType: \"json\",\r\n            async: false,\r\n            su" +
"ccess: function (data) {\r\n                var _html = \"\";\r\n                $.eac" +
"h(data, function (i, row) {\r\n                    var imgName = \"Scheme.png\";\r\n  " +
"                  var active = \"\";\r\n                    if (row.f_ischecked == 1" +
") {\r\n                        active = \"active\";\r\n                    }\r\n        " +
"            _html += \'<div class=\"card-box shcemeinfocheck \' + active + \'\">\';\r\n " +
"                   _html += \'    <div class=\"card-box-img\">\';\r\n                 " +
"   _html += \'        <img src=\"/Content/images/filetype/\' + imgName + \'\" />\';\r\n " +
"                   _html += \'    </div>\';\r\n                    _html += \'    <di" +
"v id=\"\' + row.f_id + \'\" class=\"card-box-content\">\';\r\n                    _html +" +
"= \'        <p>编号：\' + row.f_schemecode + \'</p>\';\r\n                    _html += \' " +
"       <p>名称：\' + row.f_schemename + \'</p>\';\r\n                    _html += \'     " +
"   <p>类别：\' + row.f_schemetypename + \'</p>\';\r\n                    _html += \'    <" +
"/div><i></i>\';\r\n                    _html += \'</div>\';\r\n                });\r\n   " +
"             $(\".gridPanel\").html(_html);\r\n                $(\".card-box\").click(" +
"function () {\r\n                    if (!$(this).hasClass(\"active\")) {\r\n         " +
"               $(this).addClass(\"active\")\r\n                    } else {\r\n       " +
"                 $(this).removeClass(\"active\")\r\n                    }\r\n         " +
"       });\r\n                learun.loading({ isShow: false });\r\n            }, b" +
"eforeSend: function () {\r\n                learun.loading({ isShow: true });\r\n   " +
"         }\r\n        });\r\n        //模糊查询模板（注：这个方法是理由jquery查询）\r\n        $(\"#txt_Tr" +
"eeKeyword\").keyup(function () {\r\n            var value = $(this).val();\r\n       " +
"     if (value != \"\") {\r\n                window.setTimeout(function () {\r\n      " +
"              $(\".shcemeinfocheck\")\r\n                     .hide()\r\n             " +
"        .filter(\":contains(\'\" + (value) + \"\')\")\r\n                     .show();\r\n" +
"                }, 200);\r\n            } else {\r\n                $(\".shcemeinfoch" +
"eck\").show();\r\n            }\r\n        }).keyup();\r\n    }\r\n    //保存表单\r\n    functi" +
"on AcceptClick() {\r\n        if (!$(\'#ruleinfo\').Validform()) {\r\n            retu" +
"rn false;\r\n        }\r\n        var _schemeInfoIds = [];\r\n        $(\'.gridPanel .a" +
"ctive .card-box-content\').each(function () {\r\n            _schemeInfoIds.push($(" +
"this).attr(\'id\'));\r\n        });\r\n        var postData = $(\"#ruleinfo\").GetWebCon" +
"trols();\r\n        postData[\"F_ToUserName\"] = $(\'#F_ToUserId\').attr(\'data-text\');" +
"\r\n        $.SaveForm({\r\n            url: \"../../FlowManage/FlowDelegate/SaveDele" +
"gateRule\",\r\n            param: { keyValue: keyValue, rlueStr: JSON.stringify(pos" +
"tData), shcemeInfoIds: String(_schemeInfoIds) },\r\n            loading: \"正在保存委托规则" +
"...\",\r\n            success: function () {\r\n                $.currentIframe().$(\"" +
"#RulegridTable\").trigger(\"reloadGrid\");\r\n            }\r\n        })\r\n    }\r\n</scr" +
"ipt>\r\n<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(" style=\"margin: 0px; border-top: none; border-left: none; border-bottom: none;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" style=\"color:#9f9f9f;padding-top:5px; padding-bottom:5px;padding-left:8px;\"");

WriteLiteral("><i");

WriteLiteral(" style=\"padding-right:5px;\"");

WriteLiteral(" class=\"fa fa-info-circle\"");

WriteLiteral("></i><span>填写内容,选择右侧工作流模板</span></div>\r\n            <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(" id=\"ruleinfo\"");

WriteLiteral(">\r\n                <tr>\r\n                    <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">被委托人<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></th>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" id=\"F_ToUserId\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(">\r\n                        </div>\r\n                    </td>\r\n                </t" +
"r>\r\n                <tr>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">开始时间<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"F_BeginDate\"");

WriteLiteral(" readonly");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-datepicker\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" onfocus=\"WdatePicker({ minDate: \'%y-%M-%d\' })\"");

WriteLiteral(">\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n      " +
"              <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">结束时间<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"F_EndDate\"");

WriteLiteral(" readonly");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-datepicker\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" onfocus=\"WdatePicker({ minDate: \'%y-%M-%d\' })\"");

WriteLiteral(">\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n      " +
"              <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 4px;\"");

WriteLiteral(">\r\n                        委托理由\r\n                    </th>\r\n                </tr>" +
"\r\n                <tr>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">\r\n                        <textarea");

WriteLiteral(" id=\"F_Description\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"height: 267px;\"");

WriteLiteral("></textarea>\r\n                    </td>\r\n                </tr>\r\n            </tab" +
"le>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"treesearch\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" id=\"txt_TreeKeyword\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"border-top: none;\"");

WriteLiteral(" placeholder=\"请输入要查询关键字\"");

WriteLiteral(" />\r\n            <span");

WriteLiteral(" id=\"btn_TreeSearch\"");

WriteLiteral(" class=\"input-query\"");

WriteLiteral(" title=\"Search\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i></span>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(" style=\"margin: 0px; border-right: none; border-left: none; border-bottom: none; " +
"background-color: #fff; overflow: auto; padding-bottom: 10px;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(@">
            </div>
        </div>
    </div>
</div>
<style>
    .form .formTitle {
        width:65px;
    }
    .card-box-img {
    line-height:initial;
    }
    .card-box-img img {
    width: 59px;
    height: 58px;
    border-radius: 0px;
    margin-left:0px;
    }
</style>
");

        }
    }
}
#pragma warning restore 1591
