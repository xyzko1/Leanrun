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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/ReportManage/Views/Report/ReportGuide.cshtml")]
    public partial class _Areas_ReportManage_Views_Report_ReportGuide_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_ReportManage_Views_Report_ReportGuide_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\ReportManage\Views\Report\ReportGuide.cshtml"
  
    ViewBag.Title = "报表开发";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<!--表格组件end-->\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    $(functi" +
"on () {\r\n        initControl();\r\n        //加载导向\r\n        $(\'#wizard\').wizard().o" +
"n(\'change\', function (e, data) {\r\n            var $finish = $(\"#btn_finish\");\r\n " +
"           var $next = $(\"#btn_next\");\r\n            if (data.direction == \"next\"" +
") {\r\n                switch (data.step) {\r\n                    case 1:\r\n        " +
"                if (!$(\'#tempform\').Validform()) {\r\n                            " +
"return false;\r\n                        }\r\n                        break;\r\n      " +
"              case 2:\r\n                        if (!$(\'#tempGraphform\').Validfor" +
"m()) {\r\n                            return false;\r\n                        }\r\n  " +
"                      break;\r\n                    case 3:\r\n                     " +
"   if (!$(\'#tempListform\').Validform()) {\r\n                            return fa" +
"lse;\r\n                        }\r\n                        $finish.removeAttr(\'dis" +
"abled\');\r\n                        $next.attr(\'disabled\', \'disabled\');\r\n         " +
"               break;\r\n                    default:\r\n                        bre" +
"ak;\r\n                }\r\n            } else {\r\n                $finish.attr(\'disa" +
"bled\', \'disabled\');\r\n                $next.removeAttr(\'disabled\');\r\n            " +
"}\r\n        });\r\n        //完成，保存事件\r\n        $(\"#btn_finish\").click(function () {\r" +
"\n            var tempJson = $(\"#tempbody\").GetWebControls();\r\n            //aler" +
"t(JSON.stringify(tempJson));\r\n            tempJson[\"F_Description\"] = $(\"#F_Temp" +
"Description\").val();\r\n            $.SaveForm({\r\n                url: \"../../Repo" +
"rtManage/Report/SaveForm?keyValue=\" + keyValue,\r\n                param: { tempJs" +
"on: JSON.stringify(tempJson), __RequestVerificationToken: tempJson[\"__RequestVer" +
"ificationToken\"] },\r\n                loading: \"正在保存数据...\",\r\n                succ" +
"ess: function () {\r\n                    $.currentIframe().$(\"#gridTable\").trigge" +
"r(\"reloadGrid\");\r\n                }\r\n            })\r\n        })\r\n        //发布报表事" +
"件\r\n        $(\"#publish_btn\").click(function () {\r\n            $(\"#publish_panel\"" +
").animate({ top: 50, speed: 2000 });\r\n            return false;\r\n        });\r\n  " +
"  });\r\n    //初始化控件\r\n    function initControl() {\r\n        //报表类别\r\n        $(\"#F_" +
"TempCategory\").ComboBoxTree({\r\n            param: { EnCode: \"ReportSort\" },\r\n   " +
"         url: \"../../SystemManage/DataItemDetail/GetDataItemTreeJson\",\r\n        " +
"    description: \"==请选择==\",\r\n            height: \"230px\"\r\n        });\r\n        /" +
"/图表类型\r\n        $(\"#F_TempType\").ComboBox({\r\n            description: \"==请选择==\",\r" +
"\n            height: \"200px\"\r\n        }).bind(\"change\", function () {\r\n         " +
"   type = $(this).attr(\'data-value\');\r\n            SetRemark();\r\n        });\r\n  " +
"      //模块目标\r\n        $(\"#F_Target\").ComboBox({\r\n            description: \"==请选择" +
"==\",\r\n            height: \"200px\"\r\n        });\r\n        //模块上级\r\n        $(\"#Pare" +
"ntId\").ComboBoxTree({\r\n            url: \"../../AuthorizeManage/Module/GetCatalog" +
"TreeJson\",\r\n            description: \"==请选择==\",\r\n            height: \"195px\",\r\n " +
"           allowSearch: true\r\n        });\r\n        //获取表单\r\n        if (!!keyValu" +
"e) {\r\n            $.SetForm({\r\n                url: \"../../ReportManage/Report/G" +
"etFormJson\",\r\n                param: { keyValue: keyValue },\r\n                su" +
"ccess: function (data) {\r\n                    console.log(data);\r\n              " +
"      $(\"#tempbody\").SetWebControls(data);\r\n                    $(\"#F_TempDescri" +
"ption\").val(data.F_Description);\r\n\r\n                    var paramjson = JSON.par" +
"se(data.F_ParamJson);\r\n                    $(\"#title\").val(paramjson.title)\r\n   " +
"                 $(\"#sqlString\").val(paramjson.sqlString);\r\n                    " +
"$(\"#Description\").val(paramjson.Description);\r\n                    $(\"#listSqlSt" +
"ring\").val(paramjson.listSqlString);\r\n                    $(\"#ParentId\").ComboBo" +
"xSetValue(paramjson.ParentId);\r\n                    $(\"#Icon\").val(paramjson.Ico" +
"n);\r\n                    //$(\"#listDescription\").val(paramjson.listDescription);" +
"\r\n                    type = data.F_TempType;\r\n                    SetRemark();\r" +
"\n                }\r\n            });\r\n        }\r\n    }\r\n    function SetRemark() " +
"{\r\n        var remark = \"\";\r\n        switch (type) {\r\n            case \'line\':\r\n" +
"                remark = \" <i class=\'fa fa-question-circle alert-dismissible\' st" +
"yle=\'position: relative; top: 1px; font-size: 15px; padding-right: 5px;\'></i>注：折" +
"线图的SQL语句至少需要两个字段，name代表项目名称;value代表图例上的值;group代表组。如：select 月份 as name , sum(金额) " +
"as value,产品 as group from 订单表 group by 月份,产品\"\r\n                break;\r\n         " +
"   case \'bar\':\r\n                remark = \" <i class=\'fa fa-question-circle alert" +
"-dismissible\' style=\'position: relative; top: 1px; font-size: 15px; padding-righ" +
"t: 5px;\'></i>注：柱型图的SQL语句至少需要两个字段，name代表项目名称;value代表图例上的值;group代表组。如：select 月份 as" +
" name , sum(金额) as value,产品 as group from 订单表 group by 月份,产品\"\r\n                b" +
"reak;\r\n            case \'pie\':\r\n                remark = \" <i class=\'fa fa-quest" +
"ion-circle alert-dismissible\' style=\'position: relative; top: 1px; font-size: 15" +
"px; padding-right: 5px;\'></i>注：饼图的SQL语句至少需要两个字段，name代表项目名称;value代表图例上的值;group代表组" +
"。如：select 产品 as name , sum(金额) as value from 订单表 group by 产品\"\r\n                b" +
"reak;\r\n            case \'map\':\r\n                remark = \" <i class=\'fa fa-quest" +
"ion-circle alert-dismissible\' style=\'position: relative; top: 1px; font-size: 15" +
"px; padding-right: 5px;\'></i>注：地图的SQL语句至少需要两个字段，name代表城市名称;value代表值;group代表组。如：s" +
"elect 城市 as name , sum(金额) as value,产品 as group from 订单表 group by 城市,产品\"\r\n      " +
"          break;\r\n            default:\r\n        }\r\n        $(\"#div_remark\").html" +
"(remark);\r\n    }\r\n    function SelectIcon() {\r\n        dialogOpen({\r\n           " +
" id: \"SelectIcon\",\r\n            title: \'选取图标\',\r\n            url: \'/AuthorizeMana" +
"ge/Module/Icon?ControlId=Icon\',\r\n            width: \"1000px\",\r\n            heigh" +
"t: \"600px\",\r\n            btn: false\r\n        })\r\n    }\r\n\r\n</script>\r\n<div");

WriteLiteral(" class=\"widget-body\"");

WriteLiteral(" id=\"tempbody\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"wizard\"");

WriteLiteral(" class=\"wizard\"");

WriteLiteral(" data-target=\"#wizard-steps\"");

WriteLiteral(" style=\"border-left: none; border-top: none; border-right: none;\"");

WriteLiteral(">\r\n        <ul");

WriteLiteral(" class=\"steps\"");

WriteLiteral(">\r\n            <li");

WriteLiteral(" data-target=\"#step-1\"");

WriteLiteral(" class=\"active\"");

WriteLiteral("><span");

WriteLiteral(" class=\"step\"");

WriteLiteral(">1</span>基础设置<span");

WriteLiteral(" class=\"chevron\"");

WriteLiteral("></span></li>\r\n            <li");

WriteLiteral(" data-target=\"#step-2\"");

WriteLiteral("><span");

WriteLiteral(" class=\"step\"");

WriteLiteral(">2</span>图表设置<span");

WriteLiteral(" class=\"chevron\"");

WriteLiteral("></span></li>\r\n            <li");

WriteLiteral(" data-target=\"#step-3\"");

WriteLiteral("><span");

WriteLiteral(" class=\"step\"");

WriteLiteral(">3</span>列表设置<span");

WriteLiteral(" class=\"chevron\"");

WriteLiteral("></span></li>\r\n            <li");

WriteLiteral(" data-target=\"#step-4\"");

WriteLiteral("><span");

WriteLiteral(" class=\"step\"");

WriteLiteral(">4</span>自动创建<span");

WriteLiteral(" class=\"chevron\"");

WriteLiteral("></span></li>\r\n        </ul>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"step-content\"");

WriteLiteral(" id=\"wizard-steps\"");

WriteLiteral(" style=\"border-left: none; border-bottom: none; border-right: none;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"step-pane active\"");

WriteLiteral(" id=\"step-1\"");

WriteLiteral(" style=\"margin-left: 0px; margin-top: 15px; margin-right: 30px;\"");

WriteLiteral(">\r\n            <table");

WriteLiteral(" id=\"tempform\"");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n                <tr>\r\n                    <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">报表编号<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></th>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"F_EnCode\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n    " +
"                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">报表名称<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></th>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"F_FullName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n    " +
"                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">图表类型<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></th>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" id=\"F_TempType\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(">\r\n                            <ul>\r\n                                <li");

WriteLiteral(" data-value=\"line\"");

WriteLiteral(">折线图</li>\r\n                                <li");

WriteLiteral(" data-value=\"bar\"");

WriteLiteral(">柱形图</li>\r\n                                <li");

WriteLiteral(" data-value=\"pie\"");

WriteLiteral(">饼图</li>\r\n                                <li");

WriteLiteral(" data-value=\"map\"");

WriteLiteral(">地图</li>\r\n                            </ul>\r\n                        </div>\r\n    " +
"                </td>\r\n                </tr>\r\n                <tr>\r\n            " +
"        <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">报表分类<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></th>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" id=\"F_TempCategory\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral("></div>\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n" +
"                    <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 4px;\"");

WriteLiteral(">报表介绍</th>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                        <textarea");

WriteLiteral(" id=\"TempDescription\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"height: 70px;\"");

WriteLiteral("></textarea>\r\n                    </td>\r\n                </tr>\r\n            </tab" +
"le>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"step-pane\"");

WriteLiteral(" id=\"step-2\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"div_remark\"");

WriteLiteral(" class=\"alert alert-danger\"");

WriteLiteral(" style=\"text-align: left; margin: 5px; margin-bottom: 10px;\"");

WriteLiteral("></div>\r\n            <div");

WriteLiteral(" style=\"margin-top: 15px; margin-right: 30px;\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"tempGraphform\"");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n                    <tr>\r\n                        <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">报表标题</th>\r\n                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" id=\"title\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                        </td>\r\n                    </tr>\r\n                  " +
"  <tr>\r\n                        <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 4px;\"");

WriteLiteral(">SQL语句</th>\r\n                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                            <textarea");

WriteLiteral(" id=\"sqlString\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"height: 210px;\"");

WriteLiteral("></textarea>\r\n                        </td>\r\n                    </tr>\r\n         " +
"       </table>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"step-pane\"");

WriteLiteral(" id=\"step-3\"");

WriteLiteral(" style=\"margin-top: 15px; margin-right: 30px;\"");

WriteLiteral(">\r\n            <table");

WriteLiteral(" id=\"tempListform\"");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n                <tr>\r\n                    <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">列表说明</th>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"Description\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n    " +
"                <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 4px;\"");

WriteLiteral(">SQL语句</th>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                        <textarea");

WriteLiteral(" id=\"listSqlString\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"height: 210px;\"");

WriteLiteral("></textarea>\r\n                    </td>\r\n                </tr>\r\n            </tab" +
"le>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"step-pane\"");

WriteLiteral(" id=\"step-4\"");

WriteLiteral(" style=\"margin-top: 15px; margin-right: 30px;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" style=\"height: 400px;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"drag-tip\"");

WriteLiteral(" style=\"text-align: center; padding-top: 50px;\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-check-circle\"");

WriteLiteral(" style=\"font-size: 204px; color: #0FA74F;\"");

WriteLiteral("></i>\r\n                    <div");

WriteLiteral(" id=\"finish-msg\"");

WriteLiteral(" style=\"font-weight: bold; font-size: 24px; color: #0FA74F; margin-top: 20px;\"");

WriteLiteral(">\r\n                    </div>\r\n                    <p");

WriteLiteral(" style=\"color: #666; font-size: 12px; margin-top: 10px;\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" id=\"publish_btn\"");

WriteLiteral(">发布报表</a>\r\n                    </p>\r\n                </div>\r\n                <div" +
"");

WriteLiteral(" id=\"publish_panel\"");

WriteLiteral(" style=\"position: absolute; height: 350px; top: 560px; z-index: 100; background: " +
"#ffffff; margin-top: 15px; margin-right: 30px;\"");

WriteLiteral(">\r\n                    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n                        <tr>\r\n                            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">上级</th>\r\n                            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" id=\"ParentId\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(">\r\n                                </div>\r\n                            </td>\r\n   " +
"                         <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">图标</th>\r\n                            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                <input");

WriteLiteral(" id=\"Icon\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                                <span");

WriteLiteral(" class=\"input-button\"");

WriteLiteral(" onclick=\"SelectIcon()\"");

WriteLiteral(" title=\"选取图标\"");

WriteLiteral(">...</span>\r\n                            </td>\r\n                        </tr>\r\n  " +
"                      <tr>\r\n                            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 4px;\"");

WriteLiteral(">描述\r\n                            </th>\r\n                            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(">\r\n                                <textarea");

WriteLiteral(" id=\"Description\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"height: 70px;\"");

WriteLiteral("></textarea>\r\n                            </td>\r\n                        </tr>\r\n " +
"                   </table>\r\n                </div>\r\n            </div>\r\n       " +
" </div>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"form-button\"");

WriteLiteral(" id=\"wizard-actions\"");

WriteLiteral(">\r\n    <a");

WriteLiteral(" id=\"btn_last\"");

WriteLiteral(" disabled");

WriteLiteral(" class=\"btn btn-default btn-prev\"");

WriteLiteral(">上一步</a>\r\n    <a");

WriteLiteral(" id=\"btn_next\"");

WriteLiteral(" class=\"btn btn-default btn-next\"");

WriteLiteral(">下一步</a>\r\n    <a");

WriteLiteral(" id=\"btn_finish\"");

WriteLiteral(" disabled");

WriteLiteral(" class=\"btn btn-success\"");

WriteLiteral(">完成</a>\r\n</div>\r\n<style>\r\n    body {\r\n        overflow: hidden;\r\n    }\r\n</style>\r" +
"\n\r\n");

        }
    }
}
#pragma warning restore 1591
