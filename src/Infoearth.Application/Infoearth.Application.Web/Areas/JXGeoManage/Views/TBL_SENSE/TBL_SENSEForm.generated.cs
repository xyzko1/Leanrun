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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_SENSE/TBL_SENSEForm.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_SENSE_TBL_SENSEForm_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_SENSE_TBL_SENSEForm_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_SENSE\TBL_SENSEForm.cshtml"
  
    ViewBag.Title = "表单页面";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral(@"

<style>
    input {
        border-left: none !important;
        border-top: none !important;
        border-right: none !important;
    }

    .title .formValue input {
        border-left: none !important;
        border-top: none !important;
        border-right: none !important;
    }

    td {
        border: 1px solid #ccc;
        text-align: center !important;
    }

    .title td {
        border: none;
    }

    .formValue {
        background: #fff;
    }

    .formTitle {
        height: 30px;
        white-space: inherit !important;
        width: auto !important;
    }

    label {
        margin: 5px;
    }
</style>
<div");

WriteLiteral(" style=\"height:100%;overflow-x: hidden;\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n        <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(" id=\"li_FIRST\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#FIRST\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">第一页</a></li>\r\n        <li");

WriteLiteral(" id=\"li_DMT\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#DMT\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">多媒体</a></li>\r\n    </ul>\r\n    <div");

WriteLiteral(" id=\"myTabContent\"");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(" style=\"height: calc(100% - 55px);\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" id=\"FIRST\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n            <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n                <tr>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">统一编号<span");

WriteLiteral(" class=\"required\"");

WriteLiteral(" style=\"color:red\"");

WriteLiteral(">*</span></td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"4\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"UNIFIEDCODE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control readonly\"");

WriteLiteral(" readonly=\"readonly\"");

WriteLiteral(" placeholder=\"点击获取统一编号\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" onclick=\"btn_Create()\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">图幅编号</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"4\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SENSECODE\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">遥感图像编号</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"4\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SENSEIMGCODE\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n    " +
"                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">图幅名</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"6\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SENSENAME\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">项目名称</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"6\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"DISASTERUNITNAME\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                </tr>\r\n\r\n                <tr>\r\n\r\n" +
"                    ");

WriteLiteral("\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" rowspan=\"2\"");

WriteLiteral(">坐标</td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">经度</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"LONGITUDE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" onblur=\"isJD(this)\"");

WriteLiteral(" placeholder=\"双击获取经纬度\"");

WriteLiteral(" ondblclick=\"position_select()\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">解译点编号</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"4\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"INDOORCODE\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">野外编号</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"4\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"OUTDOORCODE\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n    " +
"                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">纬度</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"LATITUDE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" onblur=\"isJD(this)\"");

WriteLiteral(" placeholder=\"双击获取经纬度\"");

WriteLiteral(" ondblclick=\"position_select()\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">规模</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SCALE\"");

WriteLiteral(" class=\"form-control RYX\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">X</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"X\"");

WriteLiteral(" type=\"number\"");

WriteLiteral(" class=\"form-control TDX DC\"");

WriteLiteral(" onkeyup=\"value=value.replace(/\\.\\d{1,}$/,value.substr(value.indexOf(\'.\'),9))\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">Y</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"Y\"");

WriteLiteral(" type=\"number\"");

WriteLiteral(" class=\"form-control MDX YICENG\"");

WriteLiteral(" onkeyup=\"value=value.replace(/\\.\\d{1,}$/,value.substr(value.indexOf(\'.\'),9))\"");

WriteLiteral(" />\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n    " +
"                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" rowspan=\"1\"");

WriteLiteral(">地理位置（村）</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"PROVINCENAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">省</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"PROVINCE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"CITYNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">市</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"CITY\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"COUNTYNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">县</td>\r\n\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"TOWNNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">乡镇</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" id=\"TOWN\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"VILLAGE\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">村</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"TEAM\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">组</td>\r\n                </tr>\r\n                <tr>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"15\"");

WriteLiteral(">灾害类型</td>\r\n                </tr>\r\n                <tr>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">滑坡</td>\r\n                    <td");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"DISASTERTYPE\"");

WriteLiteral(" value=\"A\"");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" id=\"DY1\"");

WriteLiteral("></input>\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">崩塌</td>\r\n                    <td");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"DISASTERTYPE\"");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" value=\"B\"");

WriteLiteral(" id=\"DY2\"");

WriteLiteral("></input>\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">泥石流</td>\r\n                    <td");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"DISASTERTYPE\"");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" value=\"C\"");

WriteLiteral(" id=\"DY3\"");

WriteLiteral("></input>\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">不稳定斜坡</td>\r\n                    <td");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"DISASTERTYPE\"");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" value=\"D\"");

WriteLiteral(" id=\"DY4\"");

WriteLiteral("></input>\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">地裂缝</td>\r\n                    <td");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"DISASTERTYPE\"");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" value=\"E\"");

WriteLiteral(" id=\"DY5\"");

WriteLiteral("></input>\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">地面沉降</td>\r\n                    <td");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"DISASTERTYPE\"");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" value=\"F\"");

WriteLiteral(" id=\"DY6\"");

WriteLiteral("></input>\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">地面塌陷</td>\r\n                    <td");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"DISASTERTYPE\"");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" value=\"G\"");

WriteLiteral(" id=\"DY7\"");

WriteLiteral("></input>\r\n                    </td>\r\n\r\n                </tr>\r\n                <t" +
"r");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">地质环境点</td>\r\n                    <td");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" colspan=\"1\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"DISASTERTYPE\"");

WriteLiteral(" style=\"width:13px !important;height:13px;\"");

WriteLiteral(" value=\"H\"");

WriteLiteral(" id=\"DY8\"");

WriteLiteral("></input>\r\n                    </td>\r\n\r\n                </tr>\r\n                <t" +
"r>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"15\"");

WriteLiteral(">解译结果</td>\r\n                </tr>\r\n                <tr>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">遥感影像特征</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"14\"");

WriteLiteral(">\r\n                        <textarea");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"IMGFEATURES\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("></textarea>\r\n                    </td>\r\n                </tr>\r\n                <" +
"tr>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">解译结果</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"14\"");

WriteLiteral(">\r\n                        <textarea");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"EXPLAIN\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("></textarea>\r\n                    </td>\r\n                </tr>\r\n                <" +
"tr>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">野外验证结果</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"14\"");

WriteLiteral(">\r\n                        <textarea");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"OUTRESULT\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("></textarea>\r\n                    </td>\r\n                </tr>\r\n                <" +
"tr>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">是否核查</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"ISAUDIT\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">审核人</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"AUDITPEOPLE\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">顺序号</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"NUMBER\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">解译人</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"EXPLAINPEOPLE\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">解译时间</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"EXPLAINTIME\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n                    </td>\r\n                </tr>\r\n                <tr");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">地理位置</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"LOCATION\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n\r\n                </tr>\r\n                <tr");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">guid</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"GUID\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n\r\n                </tr>\r\n                <tr");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n\r\n                    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">灾害类型</td>\r\n                    <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(" style=\"background: transparent\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"DISASTERTYPE\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                    </td>\r\n\r\n                </tr>\r\n            </table>\r\n  " +
"      </div>\r\n\r\n        <div");

WriteLiteral(" class=\"tab-pane fade\"");

WriteLiteral(" id=\"DMT\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" class=\"LRADMS_iframe\"");

WriteLiteral(" id=\"MultMedia\"");

WriteLiteral(" frameborder=\"0\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" style=\"border: none; width: 100%; height: 100%;\"");

WriteLiteral("></iframe>\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n    <script>\r\n        var keyValue = request(\'keyValue\');  //统一编号\r\n        var " +
"details = request(\'details\');\r\n        var guid = request(\'guid\');  //历史数据的GUID\r" +
"\n        var TYBH = request(\'TYBH\');  //编号\r\n        var authToken = getAuthoriza" +
"tionToken();\r\n        var callback = request(\'callback\');\r\n        $(function ()" +
" {\r\n            initControl();\r\n            if (TYBH) {\r\n                var que" +
"ryJson = { \'UnifyCode\': TYBH }\r\n                $.ajax({\r\n                    ur" +
"l: \"../../api/TBL_HAZARDBASICINFOApi/GetSingleFillListJson?queryJson=\" + JSON.st" +
"ringify(queryJson),\r\n                    beforeSend: function (a) {\r\n           " +
"             a.setRequestHeader(\"Authorization\", authToken);\r\n                  " +
"  },\r\n                    type: \'GET\',\r\n                    dataType: \"json\",\r\n " +
"                   success: function (data) {\r\n                        if (data)" +
" {\r\n                            var str = \"\", clas = \'\';\r\n                      " +
"      if (data.length > 0) {\r\n                                var mag = ($(\'#xgj" +
"l\').width() - 100 * data.length) / (data.length + 1)\r\n                          " +
"      for (var i = 0; i < data.length; i++) {\r\n                                 " +
"   clas = i == 0 ? \'actives\' : \'\';\r\n                                    if (data" +
"[i].FILLTABLEDATE != null) {\r\n                                        data[i].FI" +
"LLTABLEDATE = data[i].FILLTABLEDATE.slice(0, 10);\r\n                             " +
"       } else {\r\n                                        data[i].FILLTABLEDATE =" +
" \"\";\r\n                                    }\r\n                                   " +
" str += \'<div class=\"timeflag\" style=\"left:\' + mag * (i + 1) + \'px\"><div class=\"" +
"radio \' + clas + \'\" onclick=\"radioGUID(\\\'\' + data[i].GUID + \'\\\')\"></div><p>\' + d" +
"ata[i].FILLTABLEDATE + \'</p></div>\'\r\n                                }\r\n        " +
"                        $(\'#xgjl\').html(str);\r\n                            }\r\n  " +
"                      }\r\n                    },\r\n                    cache: fals" +
"e\r\n\r\n                })\r\n            }\r\n            $(\"#TEAM\").attr(\"disabled\", " +
"\"disabled\")\r\n            $(\"#VILLAGE\").blur(function () {\r\n                if ($" +
"(\"#VILLAGE\").val() == \"\") {\r\n                    dialogMsg(\'请先填写村！\', 0);\r\n      " +
"              $(\"#TEAM\").attr(\"disabled\", \"disabled\")\r\n                    $(\"#T" +
"EAM\").val(\"\")\r\n                } else {\r\n                    $(\"#TEAM\").prop(\"di" +
"sabled\", \"\")\r\n                }\r\n            })\r\n            if (details == \"01\"" +
") {\r\n                $(\"input\").attr(\"disabled\", \"disabled\")\r\n            }\r\n   " +
"         //多媒体\r\n            $(\".nav-tabs li\").click(function () {\r\n             " +
"   var id = $(this).attr(\'id\').replace(\"li_\", \"\");\r\n                switch (id) " +
"{\r\n                    case \"DMT\":\r\n                        window.setTimeout(fu" +
"nction () {\r\n                            $(\'#MultMedia\').attr(\'src\', contentPath" +
" + \"/SystemManage/MultMedia/Index?moduleID=dcd1d0aa-1d51-4142-ae82-db812158b0da&" +
"belongObjectGuid=\" + keyValue + \"&details=\" + details);\r\n                       " +
" }, 300);\r\n\r\n                        break;\r\n                    default:\r\n     " +
"           }\r\n            });\r\n\r\n        });\r\n\r\n        //初始化控件\r\n        functio" +
"n initControl() {\r\n            //获取表单\r\n            if (!!keyValue) {\r\n          " +
"      $.SetForm({\r\n                    url: \"../../JXGeoManage/TBL_SENSE/GetForm" +
"Json\",\r\n                    param: { keyValue: keyValue },\r\n                    " +
"success: function (data) {\r\n                        SetControl(data);\r\n         " +
"           }\r\n                })\r\n            } else if (guid) {\r\n              " +
"  $.SetForm({\r\n                    url: \"../../api/TBL_SENSE_HIDDENApi/GetFormJs" +
"on\",\r\n                    param: { keyValue: guid },\r\n                    authTo" +
"ken: authToken,\r\n                    success: function (data) {\r\n               " +
"         SetControl(data);\r\n                    }\r\n                });\r\n\r\n      " +
"          $(\"input\").attr(\"disabled\", \"disabled\")\r\n            }\r\n        }\r\n\r\n " +
"       function SetControl(data) {\r\n            if (data.DISASTERTYPE == \"A,B,C," +
"D,E,F,G,H\") {\r\n                $(\"#DY1\").prop(\"checked\", \"checked\")\r\n           " +
"     $(\"#DY2\").prop(\"checked\", \"checked\")\r\n                $(\"#DY3\").prop(\"check" +
"ed\", \"checked\")\r\n                $(\"#DY4\").prop(\"checked\", \"checked\")\r\n         " +
"       $(\"#DY5\").prop(\"checked\", \"checked\")\r\n                $(\"#DY6\").prop(\"che" +
"cked\", \"checked\")\r\n                $(\"#DY7\").prop(\"checked\", \"checked\")\r\n       " +
"         $(\"#DY8\").prop(\"checked\", \"checked\")\r\n            } else if (data.DISAS" +
"TERTYPE == \"A,B,C,D,E,F,G,\") {\r\n                $(\"#DY1\").prop(\"checked\", \"check" +
"ed\")\r\n                $(\"#DY2\").prop(\"checked\", \"checked\")\r\n                $(\"#" +
"DY3\").prop(\"checked\", \"checked\")\r\n                $(\"#DY4\").prop(\"checked\", \"che" +
"cked\")\r\n                $(\"#DY5\").prop(\"checked\", \"checked\")\r\n                $(" +
"\"#DY6\").prop(\"checked\", \"checked\")\r\n                $(\"#DY7\").prop(\"checked\", \"c" +
"hecked\")\r\n            } else if (data.DISASTERTYPE == \"A,B,C,D,E,F,\") {\r\n       " +
"         $(\"#DY1\").prop(\"checked\", \"checked\")\r\n                $(\"#DY2\").prop(\"c" +
"hecked\", \"checked\")\r\n                $(\"#DY3\").prop(\"checked\", \"checked\")\r\n     " +
"           $(\"#DY4\").prop(\"checked\", \"checked\")\r\n                $(\"#DY5\").prop(" +
"\"checked\", \"checked\")\r\n                $(\"#DY6\").prop(\"checked\", \"checked\")\r\n   " +
"         } else if (data.DISASTERTYPE == \"A,B,C,D,E,\") {\r\n                $(\"#DY" +
"1\").prop(\"checked\", \"checked\")\r\n                $(\"#DY2\").prop(\"checked\", \"check" +
"ed\")\r\n                $(\"#DY3\").prop(\"checked\", \"checked\")\r\n                $(\"#" +
"DY4\").prop(\"checked\", \"checked\")\r\n                $(\"#DY5\").prop(\"checked\", \"che" +
"cked\")\r\n            } else if (data.DISASTERTYPE == \"A,B,C,D,\") {\r\n             " +
"   $(\"#DY1\").prop(\"checked\", \"checked\")\r\n                $(\"#DY2\").prop(\"checked" +
"\", \"checked\")\r\n                $(\"#DY3\").prop(\"checked\", \"checked\")\r\n           " +
"     $(\"#DY4\").prop(\"checked\", \"checked\")\r\n            } else if (data.DISASTERT" +
"YPE == \"A,B,C,\") {\r\n                $(\"#DY1\").prop(\"checked\", \"checked\")\r\n      " +
"          $(\"#DY2\").prop(\"checked\", \"checked\")\r\n                $(\"#DY3\").prop(\"" +
"checked\", \"checked\")\r\n            } else if (data.DISASTERTYPE == \"A,B,\") {\r\n   " +
"             $(\"#DY1\").prop(\"checked\", \"checked\")\r\n                $(\"#DY2\").pro" +
"p(\"checked\", \"checked\")\r\n            } else if (data.DISASTERTYPE == \"A,\") {\r\n  " +
"              $(\"#DY1\").prop(\"checked\", \"checked\")\r\n            }\r\n            $" +
"(\"#form1\").SetWebControls(data);\r\n        }\r\n        //保存表单;\r\n        function A" +
"cceptClick() {\r\n            if (keyValue) {\r\n                var queryJson = { \'" +
"unifycode\': keyValue, \"type\": \"09\" }\r\n                $.ajax({\r\n                " +
"    url: \"../../api/TBL_AUDITINFOApi/GetPageNoAuditListJson\",\r\n                 " +
"   beforeSend: function (request) {\r\n                        request.setRequestH" +
"eader(\"Authorization\", authToken);\r\n                    },\r\n                    " +
"async: false,\r\n                    data: { queryJson: JSON.stringify(queryJson) " +
"},\r\n                    type: \"get\",\r\n                    dataType: \"json\",\r\n   " +
"                 success: function (res) {\r\n                        if (res.rows" +
".length > 0) {\r\n                            dialogMsg(\'该点存在未审核数据，请审核后再执行此操作！\', 0" +
");\r\n                            return;\r\n                        }\r\n            " +
"        },\r\n                });\r\n            }\r\n            if (!$(\'#form1\').Val" +
"idform()) {\r\n                return false;\r\n            }\r\n            //获取引发因素类" +
"型的值\r\n            var val = \"\";\r\n            var postData = $(\"#form1\").GetWebCon" +
"trols(keyValue);\r\n            $(\"input[name=\'DISASTERTYPE\']\").each(function () {" +
"\r\n                if ($(this).prop(\"checked\")) {\r\n                    val += $(t" +
"his).val() + \",\"\r\n                    postData.DISASTERTYPE = val;\r\n            " +
"    }\r\n            })\r\n            $.SaveForm({\r\n                url: \"../../JXG" +
"eoManage/TBL_SENSE/SaveForm?keyValue=\" + keyValue,\r\n                param: postD" +
"ata,\r\n                loading: \"正在保存数据...\",\r\n                success: function (" +
"data) {\r\n                    if ($(\"#MultMedia\").attr(\"src\") != \"\") {\r\n         " +
"               $(\"#MultMedia\")[0].contentWindow.SaveFileInfo(data.resultdata);\r\n" +
"                    }\r\n                    try {\r\n                        getInf" +
"oTop().learun.currentIframe().$(\'#gridTable\').trigger(\'reloadGrid\');\r\n          " +
"          } catch (e) {\r\n                        window.parent.$(\'#gridTable\').t" +
"rigger(\'reloadGrid\');\r\n                    }\r\n                }\r\n            })\r" +
"\n        }\r\n        //GUID自动生成\r\n        function S4() {\r\n            return (((1" +
" + Math.random()) * 0x10000) | 0).toString(16).substring(1);\r\n        }\r\n       " +
" function NweGuid() {\r\n            return (S4() + S4() + \"-\" + S4() + \"-\" + S4()" +
" + \"-\" + S4() + \"-\" + S4() + S4());\r\n        }\r\n        //生成统一编号\r\n        functi" +
"on btn_Create() {\r\n            learun.dialogOpen({\r\n                id: \'Form2\'," +
"\r\n                title: \'获取统一编号\',\r\n                url: \'../../JXGeoManage/TBL_" +
"HAZARDBASICINFO/CreateCodeWaterIndex?tabhtml=09\',\r\n                width: \'500px" +
"\',\r\n                height: \'450px\',\r\n                isClose: true,\r\n          " +
"      callBack: function (iframeId) {\r\n                    var data = getInfoTop" +
"().frames[iframeId].AcceptClick();\r\n                    $(\"#PROVINCE\").val(data[" +
"\"provinceId\"]);\r\n                    $(\"#CITY\").val(data[\"cityId\"]);\r\n          " +
"          $(\"#COUNTY\").val(data[\"countyId\"]);\r\n                    $(\"#TOWN\").va" +
"l(data[\"townId\"]);\r\n                    $(\"#UNIFIEDCODE\").val(data[\"UNIFIEDCODE\"" +
"]);\r\n                    //省市县名称\r\n                    $(\"#PROVINCENAME\").val(dat" +
"a.provinceName);\r\n                    $(\"#CITYNAME\").val(data.cityName + \",\" + d" +
"ata.countyName);\r\n                    $(\"#COUNTYNAME\").val(data.countyName);\r\n  " +
"                  $(\"#LOCATION\").val(data.provinceName + data.cityName + data.co" +
"untyName);\r\n                }\r\n            });\r\n        }\r\n        //获取经纬度\r\n    " +
"    function position_select() {\r\n            dialogOpen({\r\n                id: " +
"\'TBL_YJBZ_POSITIONSelect\',\r\n                title: \'获取经纬度信息\',\r\n                u" +
"rl: \'../../JXGeoManage/TBL_QCQF_ADMINISTRATIVE/TBL_YJBZ_POSITIONSelect\',\r\n      " +
"          width: \'970px\',\r\n                height: \"450px\",\r\n                isC" +
"lose: true,\r\n                callBack: function (iframeId) {\r\n                  " +
"  var dt1 = getInfoTop().frames[iframeId].$(\'#LONGITUDE\').val();\r\n              " +
"      var dt2 = getInfoTop().frames[iframeId].$(\'#LATITUDE\').val();\r\n           " +
"         $(\'#LONGITUDE\').val(dt1);\r\n                    $(\'#LATITUDE\').val(dt2);" +
"\r\n                }\r\n            });\r\n        }\r\n    </script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
