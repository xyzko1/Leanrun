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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_HAZARDBASICINFO/DeleteInfo.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_DeleteInfo_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_DeleteInfo_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO\DeleteInfo.cshtml"
  
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

WriteLiteral(" style=\"float:right;margin-right:25px;display:none;\"");

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

WriteLiteral(">灾害点名称<font>*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"DISASTERNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请单击选择灾害点名称\"");

WriteLiteral(" onclick=\"zhxx()\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" readonly=\"readonly\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">原统一编号<font>*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"UNIFIEDCODE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral(" />\r\n                <input");

WriteLiteral(" id=\"PROJECTID\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">野外编号</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"OUTDOORCODE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">灾害类型</td>\r\n            <td");

WriteLiteral(" colspan=\"5\"");

WriteLiteral("><div");

WriteLiteral(" id=\"DISASTERTYPE\"");

WriteLiteral("></div></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

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

WriteLiteral(">批准销号时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral("><input");

WriteLiteral(" id=\"XHSJ\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" /></td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">销号点情况</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral("><div");

WriteLiteral(" id=\"XHQK\"");

WriteLiteral("></div></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" rowspan=\"13\"");

WriteLiteral(">批准销号原因</td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" rowspan=\"5\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" onclick=\"zlgcxz()\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"ISZLGC\"");

WriteLiteral(" value=\"0\"");

WriteLiteral(">完成工程治理</label>\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">防治工程等级/工程投资</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"ZLGCQK\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control wczlgc\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">主要防治措施</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"ZLGCQK2\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control wczlgc\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">工程竣工时间与竣工验收情况</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"ZLGCQK3\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control wczlgc\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">治理效果和监测情况</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"ZLGCQK4\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control wczlgc\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">现场核实治理工程变形情况丶毁损丶完整性丶稳定情况</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"ZLGCQK5\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control wczlgc\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" rowspan=\"6\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" onclick=\"bqbrxz()\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"ISBQBR\"");

WriteLiteral(" value=\"0\"");

WriteLiteral(">完成搬迁避让</label>\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">搬迁户数/人数</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"BQBQQK\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control wcbqbr\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">搬迁避让项目实施部门</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"BQBQQK2\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control wcbqbr\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">是否全部实施搬迁</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"BQBQQK3\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control wcbqbr\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">影响范围内有误耕地以外的其他保护对象</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"BQBQQK4\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control wcbqbr\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">搬迁后房屋是否全部拆除丶居民有无回流可能</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"BQBQQK5\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control wcbqbr\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">搬迁地质灾害点是否已设置警示标志</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"BQBQQK6\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control wcbqbr\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" onclick=\"zrztxz()\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"ISZRZT\"");

WriteLiteral(" value=\"1\"");

WriteLiteral(">确认责任主体</label>\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">责任主体明确情况</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"ZRZTQK\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">其他</td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">灾害点现状</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral("><input");

WriteLiteral(" id=\"ZHDXZ\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">同意销号意见</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"5\"");

WriteLiteral("><input");

WriteLiteral(" id=\"BZ\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">填表单位</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"5\"");

WriteLiteral("><input");

WriteLiteral(" id=\"FILLTABLEUNIT\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

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

WriteLiteral(" /></td>\r\n        </tr>\r\n    </table>\r\n</div>\r\n");

            
            #line 142 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO\DeleteInfo.cshtml"
Write(System.Web.Optimization.Scripts.Render(
    "~/Content/scripts/plugins/infoearthcustom/dictionaryControl.js"
));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script");

WriteLiteral(" src=");

WriteLiteral("></script>\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    var projectid " +
"= \"\";\r\n    var authToken = getAuthorizationToken();\r\n    var guid = request(\'gui" +
"d\');  //核销数据的GUID\r\n    var types = \"\";\r\n    $(function () {\r\n        initSelect(" +
");\r\n        initControl();\r\n    });\r\n    //先获取当前用户\r\n    function GetCurrentUserC" +
"ode() {\r\n        $.ajax({\r\n            url: ssoPath + \'api/AdministrativeApi/Get" +
"CurrentUserCode\',\r\n            async: false,\r\n            beforeSend: function (" +
"a) {\r\n                a.setRequestHeader(\"Authorization\", authToken);\r\n         " +
"   },\r\n            type: \'GET\',\r\n            dataType: \"json\",\r\n            succ" +
"ess: function (data) {\r\n                if (WebApiResultWrap) {\r\n               " +
"     data = data.Result;\r\n                }\r\n                if (data.length == " +
"1) {\r\n                    if (data.join(\",\").indexOf(\"000000\") < 0) {\r\n         " +
"               selectCityId = data[0].substring(0, 4) + \"00\";\r\n                 " +
"       selectCounty = data[0].substring(0, 6);\r\n                        xzqhCode" +
" = data[0].substring(0, 6);\r\n                    }\r\n                    else {\r\n" +
"                        xzqhCode = AreaCode;\r\n                    }\r\n           " +
"     } else if (data.join(\",\").indexOf(\"0000\") < 0) {\r\n                    for (" +
"var i = 0; i < data.length; i++) {\r\n                        if (data[i].substrin" +
"g(4, 6) == \"00\" && data[i].length < 9) {\r\n                            selectCity" +
"Id = data[i];\r\n                            xzqhCode = data[i];\r\n                " +
"        }\r\n                    }\r\n                }\r\n\r\n\r\n            }, error: f" +
"unction (e) {\r\n            },\r\n            cache: false\r\n        });\r\n    }\r\n   " +
" //初始化控件\r\n    function initControl() {\r\n        if (guid) {\r\n            //$(\"#l" +
"i_close\").show();\r\n            $.ajax({\r\n                url: \'../../api/TBL_XIA" +
"OHAOApi/GetFormJson\',\r\n                data: { keyValue: guid },\r\n              " +
"  beforeSend: function (a) {\r\n                    if (authToken)\r\n              " +
"          a.setRequestHeader(\"Authorization\", authToken);\r\n                },\r\n " +
"               type: \"GET\",\r\n                dataType: \'json\',\r\n                " +
"success: function (data) {\r\n                    $(\"input\").attr(\"disabled\", \"dis" +
"abled\");\r\n                    $(\"#form1\").SetWebControls(data);\r\n               " +
" }, error: function (e) {\r\n                },\r\n                cache: false\r\n   " +
"         });\r\n        } else {\r\n            if (keyValue) {\r\n                var" +
" queryJson = {\r\n                    \'UNIFIEDCODE\': keyValue\r\n                };\r" +
"\n                $.ajax({\r\n                    url: \'../../api/TBL_HAZARDBASICIN" +
"FOApi/GetListJson\',\r\n                    data: { queryJson: JSON.stringify(query" +
"Json) },\r\n                    beforeSend: function (a) {\r\n                      " +
"  if (authToken)\r\n                            a.setRequestHeader(\"Authorization\"" +
", authToken);\r\n                    },\r\n                    type: \"GET\",\r\n       " +
"             dataType: \'json\',\r\n                    success: function (data) {\r\n" +
"                        data = data[0]\r\n                        $(\"#form1\").SetW" +
"ebControls(data);\r\n                        zlgcxz();\r\n                        bq" +
"brxz();\r\n                        zrztxz();\r\n                        $(\"#UNIFIEDC" +
"ODE\").attr(\'disabled\', \'disabled\');\r\n                        $(\"#DISASTERNAME\")." +
"attr(\'disabled\', \'disabled\');\r\n                        if (data && data.DISASTER" +
"TYPE) {\r\n                            for (var i = 0; i < $(\'#DISASTERTYPE label\'" +
").length; i++) {\r\n                                if ($(\'#DISASTERTYPE label\').e" +
"q(i).text() == data.DISASTERTYPE) {\r\n                                    $(\'#DIS" +
"ASTERTYPE input\').eq(i).attr(\"checked\", true);\r\n                                " +
"    $(\'#DISASTERTYPE input\').attr(\'disabled\', \'disabled\');\r\n                    " +
"                types = $(\'#DISASTERTYPE label\').eq(i).text();\r\n                " +
"                    return\r\n                                }\r\n                 " +
"           }\r\n                        }\r\n\r\n                    }, error: functio" +
"n (e) {\r\n                    },\r\n                    cache: false\r\n             " +
"   });\r\n                //工程治理\r\n                $.ajax({\r\n                    ur" +
"l: \'../../api/TBL_ZLGC/GetListJson\',\r\n                    data: { queryJson: JSO" +
"N.stringify(queryJson) },\r\n                    beforeSend: function (a) {\r\n     " +
"                   if (authToken)\r\n                            a.setRequestHeade" +
"r(\"Authorization\", authToken);\r\n                    },\r\n                    type" +
": \"GET\",\r\n                    dataType: \'json\',\r\n                    success: fu" +
"nction (data) {\r\n                        if (data.length == 0) {\r\n              " +
"              console.log(\'治理\');\r\n                            $(\"#ISZLGC\").attr(" +
"\'disabled\', \'disabled\');\r\n                        }\r\n                    }, erro" +
"r: function (e) {\r\n                    },\r\n                    cache: false\r\n   " +
"             });\r\n                //搬迁避让\r\n                $.ajax({\r\n            " +
"        url: \'../../api/TBL_BQBRApi/GetListJson\',\r\n                    data: { q" +
"ueryJson: JSON.stringify(queryJson) },\r\n                    beforeSend: function" +
" (a) {\r\n                        if (authToken)\r\n                            a.se" +
"tRequestHeader(\"Authorization\", authToken);\r\n                    },\r\n           " +
"         type: \"GET\",\r\n                    dataType: \'json\',\r\n                  " +
"  success: function (data) {\r\n                        if (data.length == 0) {\r\n " +
"                           $(\"#ISBQBR\").attr(\'disabled\', \'disabled\');\r\n         " +
"               }\r\n                    }, error: function (e) {\r\n                " +
"    },\r\n                    cache: false\r\n                });\r\n            } els" +
"e {\r\n                $(\'.wczlgc\').attr(\'disabled\', \'disabled\');\r\n               " +
" $(\'.wcbqbr\').attr(\'disabled\', \'disabled\');\r\n                $(\'#ZRZTQK\').attr(\'" +
"disabled\', \'disabled\');\r\n            }\r\n        }\r\n    }\r\n    //保存表单;\r\n    funct" +
"ion AcceptClick() {\r\n        if (keyValue) {\r\n            if (types == \"滑坡\") {\r\n" +
"                types = \"01\"\r\n            } else if (types == \"崩塌\") {\r\n         " +
"       types = \"02\"\r\n            } else if (types == \"泥石流\") {\r\n                t" +
"ypes = \"03\"\r\n            } else if (types == \"地面沉降\") {\r\n                types = " +
"\"04\"\r\n            } else if (types == \"地面塌陷\") {\r\n                types = \"05\"\r\n " +
"           } else if (types == \"地裂缝\") {\r\n                types = \"06\"\r\n         " +
"   } else if (types == \"斜坡\") {\r\n                types = \"00\"\r\n            }\r\n   " +
"         var queryJson = { \'unifycode\': keyValue, \"type\": types }\r\n            $" +
".ajax({\r\n                url: \"../../api/TBL_AUDITINFOApi/GetPageNoAuditListJson" +
"\",\r\n                beforeSend: function (request) {\r\n                    reques" +
"t.setRequestHeader(\"Authorization\", authToken);\r\n                },\r\n           " +
"     data: { queryJson: JSON.stringify(queryJson) },\r\n                type: \"get" +
"\",\r\n                async: false,\r\n                dataType: \"json\",\r\n          " +
"      success: function (res) {\r\n                    if (res.rows.length > 0) {\r" +
"\n                        dialogMsg(\'该点存在未审核数据，请审核后再执行此操作！\', 0);\r\n               " +
"         return;\r\n                    } else {\r\n                        SaveInfo" +
"();\r\n                    }\r\n                },\r\n            });\r\n        }\r\n\r\n  " +
"  }\r\n\r\n    function SaveInfo() {\r\n        if (!$(\'#form1\').Validform()) {\r\n     " +
"       return false;\r\n        }\r\n        var entity = $(\"#form1\").GetWebControls" +
"(keyValue);\r\n        //entity.DISASTERTYPE = $(\'#DISASTERTYPE label\').eq(entity." +
"DISASTERTYPE).text();\r\n        $.SaveForm({\r\n            url: \"../../api/TBL_XIA" +
"OHAOApi/SaveForm?keyValue=\" + keyValue,\r\n            param: entity,\r\n           " +
" authToken: authToken,\r\n            loading: \"正在保存数据...\",\r\n            success: " +
"function () {\r\n                try {\r\n                    getInfoTop().learun.cu" +
"rrentIframe().$(\'#gridTable\').trigger(\'reloadGrid\');\r\n                } catch (e" +
") {\r\n                    window.parent.$(\'#gridTable\').trigger(\'reloadGrid\');\r\n " +
"               }\r\n            }\r\n        })\r\n    }\r\n    function initSelect() {\r" +
"\n        $(\"#DISASTERTYPE\").dictionaryControl({ dicCode: \"HazardType\", type: \"ra" +
"dio\" });\r\n        $(\"#XHQK\").dictionaryControl({ dicCode: \"xhdqk\", type: \"radio\"" +
" });\r\n    }\r\n    function zlgcxz() {\r\n        if ($(\'#ISZLGC\').is(\":checked\")) {" +
"\r\n            $(\'.wczlgc\').removeAttr(\'disabled\');\r\n        } else {\r\n          " +
"  $(\'.wczlgc\').val(\'\');\r\n            $(\'.wczlgc\').attr(\'disabled\', \'disabled\');\r" +
"\n        }\r\n    }\r\n    function bqbrxz() {\r\n        if ($(\'#ISBQBR\').is(\":checke" +
"d\")) {\r\n            $(\'.wcbqbr\').removeAttr(\'disabled\');\r\n        } else {\r\n    " +
"        $(\'.wcbqbr\').val(\'\');\r\n            $(\'.wcbqbr\').attr(\'disabled\', \'disabl" +
"ed\');\r\n        }\r\n    }\r\n    function zrztxz() {\r\n        if ($(\'#ISZRZT\').is(\":" +
"checked\")) {\r\n            $(\'#ZRZTQK\').removeAttr(\'disabled\');\r\n        } else {" +
"\r\n            $(\'#ZRZTQK\').val(\'\');\r\n            $(\'#ZRZTQK\').attr(\'disabled\', \'" +
"disabled\');\r\n        }\r\n    }\r\n    //选择灾害点信息\r\n    function zhxx() {\r\n        dia" +
"logOpen({\r\n            id: \'Form2\',\r\n            title: \'获取灾害信息\',\r\n            u" +
"rl: \'/JXGeoManage/TBL_HAZARDBASICINFO/HAZARDBASCOMMONIndex\',\r\n            width:" +
" \'970px\',\r\n            height: \'460px\',\r\n            isClose: true,\r\n           " +
" callBack: function (iframeId) {\r\n                var selectedRowIndex = getInfo" +
"Top().frames[iframeId].$(\'#gridTable\').getGridParam(\'selrow\');\r\n                " +
"var dt = getInfoTop().frames[iframeId].$(\'#gridTable\').jqGrid(\"getRowData\", sele" +
"ctedRowIndex);\r\n                $(\"#UNIFIEDCODE\").val(dt.UNIFIEDCODE);\r\n        " +
"        $(\"#DISASTERNAME\").val(dt.DISASTERNAME);\r\n                $(\"#UNIFIEDCOD" +
"E\").attr(\'disabled\', \'disabled\');\r\n                $(\"#DISASTERNAME\").attr(\'disa" +
"bled\', \'disabled\');\r\n                $(\"#PROJECTID\").val(dt.PROJECTID);\r\n       " +
"         $(\"#OUTDOORCODE\").val(dt.OUTDOORCODE);\r\n                $(\"#LOCATION\")." +
"val(dt.LOCATION);\r\n                projectid = dt.PROJECTID;\r\n                if" +
" (dt.DISASTERTYPE) {\r\n                    for (var i = 0; i < $(\'#DISASTERTYPE l" +
"abel\').length; i++) {\r\n                        if ($(\'#DISASTERTYPE label\').eq(i" +
").text() == dt.DISASTERTYPE) {\r\n                            $(\'#DISASTERTYPE inp" +
"ut\').eq(i).attr(\"checked\", true);\r\n                            $(\'#DISASTERTYPE " +
"input\').attr(\'disabled\', \'disabled\');\r\n                        }\r\n              " +
"      }\r\n                }\r\n            }\r\n        });\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
