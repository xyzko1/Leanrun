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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_HAZARDBASICINFO_PC_GD/TBL_HAZARDBASICINFO_PC_GDForm" +
        ".cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_PC_GD_TBL_HAZARDBASICINFO_PC_GDForm_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_PC_GD_TBL_HAZARDBASICINFO_PC_GDForm_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO_PC_GD\TBL_HAZARDBASICINFO_PC_GDForm.cshtml"
  
    ViewBag.Title = "表单页面";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral(@"
<style>
    .form {
        width: 96%;
        margin: 0 auto;
    }

        .form td {
            border: 1px solid #ddd;
            height: 38px;
        }

    .formValue input[type=text] {
        border-top: 0;
        border-right: 0;
        border-left: 0;
    }
</style>
<div");

WriteLiteral(" style=\"padding-top:20px;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" style=\"float:right;margin-right:25px;\"");

WriteLiteral(" id=\"li_close\"");

WriteLiteral(">\r\n        <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" style=\"border:1px solid #ccc;border-radius:4px;margin-top:5px;padding:5px 10px;\"" +
"");

WriteLiteral(" onclick=\"thisClose(\'DZLSSJCX\')\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-close\"");

WriteLiteral("></i> 关闭</a>\r\n    </div>\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">灾害体类型</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"DISASTERTYPE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">排查编号</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"PCUNIFIEDCODE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">统一编号</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"UNIFIEDCODE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>       \r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" rowspan=\"2\"");

WriteLiteral(">地理位置</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" rowspan=\"2\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"LOCATION\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" rowspan=\"2\"");

WriteLiteral(">坐标</td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">经度</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"LONGITUDE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">纬度</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"LATITUDE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">X</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"X\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">Y</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"Y\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>          \r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">市</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"CITYNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral("><input");

WriteLiteral(" id=\"CITY\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">县/区</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"COUNTYNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral("><input");

WriteLiteral(" id=\"COUNTY\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">街道</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"STREET\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">监测责任人</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"MONITORINGPEOPLE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">联系电话</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"TELEPHONE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">手机</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"PHONE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">监测人</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"JCPEOPLE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">联系电话</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"TELEPHONE1\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">手机</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"PHONE1\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">灾害体规模</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"SCALE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>          \r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">威胁人员</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"THREATENPEOPLE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">潜在经济损失/万元</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"INDIRECTLOSS\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>        \r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">隐患点状态</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"YHSTATE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">危害性</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"DESTROYEDOBJECT\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">稳定性</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"CURSTABLESTATUS\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">有没应急预案</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"YJPLAN\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">防治对策</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"COUNTERMEASURES\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">工作措施</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"WORKMEASURES\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">上传人</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"UPLOADER\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">上报来源（1为手机端）</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"REPORTLY\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">发生时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"HAPPENDATE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">填报人</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"FILLTABLEPEOPLE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">填报时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"FILETIME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">审核人</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"VERIFYPEOPLE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">审核时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"SHTIME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">审核意见</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"5\"");

WriteLiteral("><input");

WriteLiteral(" id=\"SHOPINION\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">排查时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"PCTIME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" >发现时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"OCCURREDTIME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">填表人</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"FILLTABLEPEOPLE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">复核人</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"VERIFYPEOPLE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">填表日期</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"FILLTABLEDATE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">备注</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"5\"");

WriteLiteral("><input");

WriteLiteral(" id=\"REMARKS\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n      \r\n    </table>\r\n</div>\r\n");

            
            #line 153 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO_PC_GD\TBL_HAZARDBASICINFO_PC_GDForm.cshtml"
Write(System.Web.Optimization.Scripts.Render(
    "~/Content/scripts/plugins/infoearthcustom/dictionaryControl.js"
));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("Scripts", () => {

WriteLiteral(@"
<script>
    var keyValue = request('keyValue');
    $(function () {
        initControl();
    });
    function initControl() {

        $(""textarea"").attr(""disabled"", ""disabled"");
        $(""input"").attr(""disabled"", ""disabled"");
        if (!!keyValue) {
            $.SetForm({
                url: ""../../JXGeoManage/TBL_HAZARDBASICINFO_PC_GD/GetFormJson"",
                param: { keyValue: keyValue },
                success: function (data) {
                    $(""#form1"").SetWebControls(data);
                }
            })
        }
    }
    //保存表单;
    function AcceptClick() {
        if (!$('#form1').Validform()) {
            return false;
        }
        var postData = $(""#form1"").GetWebControls(keyValue);
        $.SaveForm({
            url: ""../../JXGeoManage/TBL_HAZARDBASICINFO_PC_GD/SaveForm?keyValue="" + keyValue,
            param: postData,
            loading: ""正在保存数据..."",
            success: function () {
                try {
                    getInfoTop().learun.currentIframe().$('#gridTable').trigger('reloadGrid');
                } catch (e) {
                    window.parent.$('#gridTable').trigger('reloadGrid');
                }
            }
        })
    }
</script>
");

});

        }
    }
}
#pragma warning restore 1591
