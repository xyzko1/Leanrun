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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/PublicInfoManage/Views/Schedule/Form.cshtml")]
    public partial class _Areas_PublicInfoManage_Views_Schedule_Form_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_PublicInfoManage_Views_Schedule_Form_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\PublicInfoManage\Views\Schedule\Form.cshtml"
  ;
  ViewBag.Title = "表单页面";
  Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral(@"
<script>
    var startDate = request('startDate');
    var startTime = request('startTime');
    
    $(function () {
        initControl();
        $(""#F_StartDate"").val(startDate);
        $(""#F_StartTime"").ComboBoxSetValue(startTime);
    });
    //初始化控件
    function initControl() {
        //开始时间
        $(""#F_StartTime"").ComboBox({
            description: ""==请选择=="",
            height: ""200px"",
        })
        //结束时间
        $(""#F_EndTime"").ComboBox({
            description: ""==请选择=="",
            height: ""160px"",
        });
    }
    //保存表单;
    function AcceptClick() {
        if (!$('#form1').Validform()) {
            return false;
        }
        var postData = $(""#form1"").GetWebControls("""");
        $.SaveForm({
            url: ""../../PublicInfoManage/Schedule/SaveForm"",
            param: postData,
            loading: ""正在保存数据..."",
            success: function () {
                //alert(11)
                $.currentIframe().callback();
            }
        })
    }
</script>
<div");

WriteLiteral(" style=\"margin-top: 20px; margin-right: 30px;\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">开始日期<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_StartDate\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"var endDate = $dp.$(\'F_EndTime\'); WdatePicker({ onpicked: function () {" +
" EndTime.focus(); }, maxDate: \'#F{$dp.$D(\\\'F_EndTime\\\')}\' })\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(">\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width: 30px; text-align: center; padding-right: 0px;\"");

WriteLiteral(">时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_StartTime\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(">\r\n                    <ul>\r\n                        <li");

WriteLiteral(" data-value=\"0000\"");

WriteLiteral(">00:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0030\"");

WriteLiteral(">00:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0100\"");

WriteLiteral(">01:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0130\"");

WriteLiteral(">01:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0200\"");

WriteLiteral(">02:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0230\"");

WriteLiteral(">02:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0300\"");

WriteLiteral(">03:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0330\"");

WriteLiteral(">03:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0400\"");

WriteLiteral(">04:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0430\"");

WriteLiteral(">04:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0500\"");

WriteLiteral(">05:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0530\"");

WriteLiteral(">05:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0600\"");

WriteLiteral(">06:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0630\"");

WriteLiteral(">06:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0700\"");

WriteLiteral(">07:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0730\"");

WriteLiteral(">07:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0800\"");

WriteLiteral(">08:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0830\"");

WriteLiteral(">08:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0900\"");

WriteLiteral(">09:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0930\"");

WriteLiteral(">09:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1000\"");

WriteLiteral(">10:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1030\"");

WriteLiteral(">10:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1100\"");

WriteLiteral(">11:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1130\"");

WriteLiteral(">11:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1200\"");

WriteLiteral(">12:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1230\"");

WriteLiteral(">12:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1300\"");

WriteLiteral(">13:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1330\"");

WriteLiteral(">13:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1400\"");

WriteLiteral(">14:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1430\"");

WriteLiteral(">14:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1500\"");

WriteLiteral(">15:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1530\"");

WriteLiteral(">15:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1600\"");

WriteLiteral(">16:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1630\"");

WriteLiteral(">16:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1700\"");

WriteLiteral(">17:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1730\"");

WriteLiteral(">17:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1800\"");

WriteLiteral(">18:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1830\"");

WriteLiteral(">18:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1900\"");

WriteLiteral(">19:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1930\"");

WriteLiteral(">19:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"2000\"");

WriteLiteral(">20:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"2030\"");

WriteLiteral(">20:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"2100\"");

WriteLiteral(">21:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"2130\"");

WriteLiteral(">21:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"2200\"");

WriteLiteral(">22:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"2230\"");

WriteLiteral(">22:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"2300\"");

WriteLiteral(">23:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"2330\"");

WriteLiteral(">23:30</li>\r\n                    </ul>\r\n                </div>\r\n            </td>" +
"\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">结束日期<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_EndDate\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({ minDate: \'#F{$dp.$D(\\\'F_StartDate\\\')}\' })\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(">\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"width: 30px; text-align: center; padding-right: 0px;\"");

WriteLiteral(">时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_EndTime\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(">\r\n                    <ul>\r\n                        <li");

WriteLiteral(" data-value=\"0000\"");

WriteLiteral(">00:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0030\"");

WriteLiteral(">00:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0100\"");

WriteLiteral(">01:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0130\"");

WriteLiteral(">01:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0200\"");

WriteLiteral(">02:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0230\"");

WriteLiteral(">02:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0300\"");

WriteLiteral(">03:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0330\"");

WriteLiteral(">03:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0400\"");

WriteLiteral(">04:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0430\"");

WriteLiteral(">04:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0500\"");

WriteLiteral(">05:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0530\"");

WriteLiteral(">05:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0600\"");

WriteLiteral(">06:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0630\"");

WriteLiteral(">06:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0700\"");

WriteLiteral(">07:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0730\"");

WriteLiteral(">07:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0800\"");

WriteLiteral(">08:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0830\"");

WriteLiteral(">08:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"0900\"");

WriteLiteral(">09:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"0930\"");

WriteLiteral(">09:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1000\"");

WriteLiteral(">10:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1030\"");

WriteLiteral(">10:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1100\"");

WriteLiteral(">11:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1130\"");

WriteLiteral(">11:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1200\"");

WriteLiteral(">12:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1230\"");

WriteLiteral(">12:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1300\"");

WriteLiteral(">13:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1330\"");

WriteLiteral(">13:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1400\"");

WriteLiteral(">14:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1430\"");

WriteLiteral(">14:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1500\"");

WriteLiteral(">15:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1530\"");

WriteLiteral(">15:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1600\"");

WriteLiteral(">16:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1630\"");

WriteLiteral(">16:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1700\"");

WriteLiteral(">17:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1730\"");

WriteLiteral(">17:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1800\"");

WriteLiteral(">18:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1830\"");

WriteLiteral(">18:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"1900\"");

WriteLiteral(">19:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"1930\"");

WriteLiteral(">19:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"2000\"");

WriteLiteral(">20:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"2030\"");

WriteLiteral(">20:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"2100\"");

WriteLiteral(">21:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"2130\"");

WriteLiteral(">21:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"2200\"");

WriteLiteral(">22:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"2230\"");

WriteLiteral(">22:30</li>\r\n                        <li");

WriteLiteral(" data-value=\"2300\"");

WriteLiteral(">23:00</li>\r\n                        <li");

WriteLiteral(" data-value=\"2330\"");

WriteLiteral(">23:30</li>\r\n                    </ul>\r\n                </div>\r\n            </td>" +
"\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">提前提醒<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Early\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" value=\"2\"");

WriteLiteral(" placeholder=\"小时提醒我\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"Num\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 10px;\"");

WriteLiteral(">日程内容<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(">\r\n                <textarea");

WriteLiteral(" id=\"F_ScheduleContent\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"记录你将要做的一件事...\"");

WriteLiteral(" style=\"height: 70px;\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral("></textarea>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral("></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n                    <label>\r\n                        <input");

WriteLiteral(" id=\"F_IsMailAlert\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" checked=\"checked\"");

WriteLiteral(" />\r\n                        邮件提醒\r\n                    </label>\r\n                " +
"    <label>\r\n                        <input");

WriteLiteral(" id=\"F_IsWeChatAlert\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" checked=\"checked\"");

WriteLiteral(" />\r\n                        微信提醒\r\n                    </label>\r\n                " +
"    <label>\r\n                        <input");

WriteLiteral(" id=\"F_IsMobileAlert\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" checked=\"checked\"");

WriteLiteral(" />\r\n                        手机提醒\r\n                    </label>\r\n                " +
"</div>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591