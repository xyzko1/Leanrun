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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_RWJJ_GOVERNMENT/CreateCodeIndex.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_RWJJ_GOVERNMENT_CreateCodeIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_RWJJ_GOVERNMENT_CreateCodeIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_RWJJ_GOVERNMENT\CreateCodeIndex.cshtml"
  
    ViewBag.Title = "获取统一编号";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral(@"
<style>
    body {
        overflow-y:hidden;
    }
    td {
    border:none !important;
    vertical-align: baseline !important;
    }
    .formTitle {
text-align:center;
width: 180px !important;
    }
    body {
height:auto;
    }
</style>
<div");

WriteLiteral(" style=\"margin:10px\"");

WriteLiteral(" id=\"districtControl\"");

WriteLiteral(">\r\n<div");

WriteLiteral(" id=\"districtControl\"");

WriteLiteral(" style=\"width:100%\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" style=\"width:100%\"");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n        <tr");

WriteLiteral(" style=\"width:100%\"");

WriteLiteral(">\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">省<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(" style=\"color:red\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"PROVINCE\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral("checkexpession=\"NotNull\"");

WriteLiteral("></div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">市<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(" style=\"color:red\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"CITY\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral("checkexpession=\"NotNull\"");

WriteLiteral("></div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">县<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(" style=\"color:red\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"COUNTY\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral("checkexpession=\"NotNull\"");

WriteLiteral("></div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">乡镇<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(" style=\"color:red\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"TOWN\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral("checkexpession=\"NotNull\"");

WriteLiteral("></div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(" style=\"color:red;\"");

WriteLiteral("><span");

WriteLiteral(" style=\"display:inline-block;float:left;margin-left:39px\"");

WriteLiteral(">人文经济顺序编号四位数,不满四位者,前面加0</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td" +
"");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">人文经济顺序编号<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(" style=\"color:red\"");

WriteLiteral(">*</font>：</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"ZHDCODE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" maxlength=\"5\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" onkeyup=\"this.value=this.value.replace(/[^\\d]/g,\'\') \"");

WriteLiteral(" onafterpaste=\"this.value=this.value.replace(/[^\\d]/g,\'\') \"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"color:red;\"");

WriteLiteral(">人文经济编号规则：</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" style=\"display:flex;\"");

WriteLiteral(">\r\n                 <a");

WriteLiteral(" style=\"float:none;width:30%;margin-right:5px\"");

WriteLiteral(" id=\"btn_genercode\"");

WriteLiteral(" onclick=\"genercode()\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"float:right\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>&nbsp;生成编码</a>\r\n                 <input");

WriteLiteral(" id=\"typecode\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"width:70%;display:inline-block;border-radius:3px\"");

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral("/>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">\r\n                 <textarea");

WriteLiteral(" id=\"\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" rows=\"4\"");

WriteLiteral(" style=\"color:red\"");

WriteLiteral(">由16位ASCII码构成（图），分为4级，行政区划国标代码共9位（含省市、地区、县区、乡镇4级）；前两位固定为RW；随机编号在行政区划代码后面，编号递增增长；最" +
"后一位为固定字母（K-企业，G-学校，F-医院，H-政府，R-居民住宅）</textarea>\r\n            </td>\r\n        </tr" +
">\r\n    </table>\r\n</div>\r\n</div>\r\n\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 3113), Tuple.Create("\"", 3167)
, Tuple.Create(Tuple.Create("", 3119), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/districts/districts.js")
, 3119), false)
);

WriteLiteral("></script>\r\n<script>\r\n    var tabhtml = request(\'tabhtml\');\r\n    var code = GetCo" +
"nfig(\"DefalutCode\");\r\n    var authToken = getAuthorizationToken();\r\n    //  aler" +
"t(tabhtml)\r\n    $(function () {\r\n        initControl();\r\n        if ($(\"#ZHDCODE" +
"\").val) {\r\n\r\n        }\r\n        $(\"#ZHDCODE\").blur(function () {\r\n        })\r\n  " +
"  })\r\n    //初始化控件\r\n    function initControl() {\r\n        //默认选择\"陕西省\"\r\n        va" +
"r html = $(\"#districtControl\").html();\r\n        var district = $(\"#districtContr" +
"ol\").districtsCtl({\r\n            provinceId: code,\r\n            selectProviceId:" +
" code,\r\n            selectCityId: \"\",\r\n            selectCounty: \"\",\r\n          " +
"  html: html\r\n        });\r\n        var _provinceCommbox = $(\"#PROVINCE\");\r\n     " +
"   var _cityCommbox = $(\"#CITY\");\r\n        var _countyCommbox = $(\"#COUNTY\");\r\n " +
"       var _townCommbox = $(\"#TOWN\")\r\n        //省份\r\n        _provinceCommbox.Com" +
"boBox({\r\n            url: \"../../SystemManage/Area/GetProvinceListJson\",\r\n      " +
"      param: { parentId: \"0\", provinceIds: code },\r\n            id: \"F_AreaCode\"" +
",\r\n            text: \"F_AreaName\",\r\n            description: \"选择省\",\r\n           " +
" height: \"170px\"\r\n        }).bind(\"change\", function () {\r\n            var value" +
" = $(this).attr(\'data-value\');\r\n            _cityCommbox[0].innerHTML = \"选择市\";\r\n" +
"            _cityCommbox.attr(\'data-value\', \'\');\r\n            _countyCommbox[0]." +
"innerHTML = \"选择县/区\";\r\n            _countyCommbox.attr(\'data-value\', \'\');\r\n      " +
"      _townCommbox[0].innerHTML = \"选择乡/镇\";\r\n            _townCommbox.attr(\'data-" +
"value\', \'\');\r\n            if (!value) {\r\n                value = \"abcdef\";\r\n    " +
"        }\r\n            _cityCommbox.ComboBox({\r\n                url: \"../../Syst" +
"emManage/Area/GetAreaListJson\",\r\n                param: { parentId: value },\r\n  " +
"              id: \"F_AreaCode\",\r\n                text: \"F_AreaName\",\r\n          " +
"      description: \"选择市\",\r\n                height: \"170px\"\r\n            });\r\n   " +
"         _countyCommbox.ComboBox({\r\n                //url: \"../../SystemManage/A" +
"rea/GetAreaListJson\",\r\n                param: { parentId: value },\r\n            " +
"    id: \"F_AreaCode\",\r\n                text: \"F_AreaName\",\r\n                desc" +
"ription: \"选择县/区\",\r\n                height: \"170px\"\r\n            });\r\n           " +
" _townCommbox.ComboBox({\r\n                //url: \"../../SystemManage/Area/GetAre" +
"aListJson\",\r\n                param: { parentId: value },\r\n                id: \"F" +
"_AreaCode\",\r\n                text: \"F_AreaName\",\r\n                description: \"" +
"选择乡/镇\",\r\n                height: \"170px\"\r\n            });\r\n        });\r\n        " +
"//城市\r\n        _cityCommbox.ComboBox({\r\n            description: \"选择市\",\r\n        " +
"    height: \"170px\"\r\n        }).bind(\"change\", function () {\r\n            var va" +
"lue = $(this).attr(\'data-value\');\r\n            _countyCommbox[0].innerHTML = \"选择" +
"县/区\";\r\n            _countyCommbox.attr(\'data-value\', \'\');\r\n            _townComm" +
"box[0].innerHTML = \"选择乡/镇\";\r\n            _townCommbox.attr(\'data-value\', \'\');\r\n " +
"           if (!value) {\r\n                value = \"abcdef\";\r\n            }\r\n    " +
"        //if (value) {\r\n            _countyCommbox.ComboBox({\r\n                u" +
"rl: \"../../SystemManage/Area/GetAreaListJson\",\r\n                param: { parentI" +
"d: value },\r\n                id: \"F_AreaCode\",\r\n                text: \"F_AreaNam" +
"e\",\r\n                description: \"选择县/区\",\r\n                height: \"170px\"\r\n   " +
"         });\r\n            _townCommbox.ComboBox({\r\n                //url: \"../.." +
"/SystemManage/Area/GetAreaListJson\",\r\n                param: { parentId: value }" +
",\r\n                id: \"F_AreaCode\",\r\n                text: \"F_AreaName\",\r\n     " +
"           description: \"选择乡/镇\",\r\n                height: \"170px\"\r\n            }" +
");\r\n\r\n        });\r\n        //县/区\r\n        _countyCommbox.ComboBox({\r\n           " +
" description: \"选择县/区\",\r\n            height: \"170px\"\r\n        }).bind(\"change\", f" +
"unction () {\r\n            var value = $(this).attr(\'data-value\');\r\n            _" +
"townCommbox[0].innerHTML = \"选择乡/镇\";\r\n            _townCommbox.attr(\'data-value\'," +
" \'\');\r\n            if (!value) {\r\n                value = \"abcdef\";\r\n           " +
" }\r\n            //if (value) {\r\n            _townCommbox.ComboBox({\r\n           " +
"     url: \"../../SystemManage/Area/GetAreaListJson\",\r\n                param: { p" +
"arentId: value },\r\n                id: \"F_AreaCode\",\r\n                text: \"F_A" +
"reaName\",\r\n                description: \"选择乡/镇\",\r\n                height: \"170px" +
"\"\r\n            });\r\n\r\n        });\r\n    }\r\n\r\n    function getDistrictValue() {\r\n " +
"       var _provinceCommbox = $(\"#PROVINCE\");\r\n        var _cityCommbox = $(\"#CI" +
"TY\");\r\n        var _countyCommbox = $(\"#COUNTY\");\r\n        var _townCommbox = $(" +
"\"#TOWN\")\r\n        var districtInfo = {\r\n            provinceId: \"\",\r\n           " +
" provinceName: \"\",\r\n            cityId: \"\",\r\n            cityName: \"\",\r\n        " +
"    countyId: \"\",\r\n            countyName: \"\",\r\n            townId: \"\",\r\n       " +
"     townName: \"\"\r\n        };\r\n        districtInfo.provinceId = _provinceCommbo" +
"x[0].dataset.value;\r\n        districtInfo.provinceName = _provinceCommbox[0].inn" +
"erText;\r\n        districtInfo.cityId = _cityCommbox[0].dataset.value;\r\n        d" +
"istrictInfo.cityName = _cityCommbox[0].innerText;\r\n        districtInfo.countyId" +
" = _countyCommbox[0].dataset.value;\r\n        districtInfo.countyName = _countyCo" +
"mmbox[0].innerText;\r\n        districtInfo.townId = _townCommbox[0].dataset.value" +
";\r\n        districtInfo.townName = _townCommbox[0].innerText;\r\n        return di" +
"strictInfo;\r\n    }\r\n\r\n\r\n\r\n    //保存表单\r\n    function AcceptClick(callback) {\r\n    " +
"    var data = getDistrictValue();\r\n        data[\"UNIFIEDCODE\"] = genercode();\r\n" +
"        learun.dialogClose();\r\n        return data;\r\n    }\r\n    //获取请求地址\r\n    fu" +
"nction GetRequestUrl(v) {\r\n        var url = null;\r\n        switch (v) {\r\n      " +
"      case \"H\":\r\n                url = \"../../JXGeoManage/TBL_RWJJ_GOVERNMENT/Ge" +
"tFormJson\";\r\n                break;\r\n            case \"K\":\r\n                url " +
"= \"../../JXGeoManage/TBL_RWJJ_GOVERNMENT/GetFormJson\";\r\n                break;\r\n" +
"            case \"F\":\r\n                url = \"../../JXGeoManage/TBL_RWJJ_GOVERNM" +
"ENT/GetFormJson\";\r\n                break;\r\n            case \"G\":\r\n              " +
"  url = \"../../JXGeoManage/TBL_RWJJ_GOVERNMENT/GetFormJson\";\r\n                br" +
"eak;\r\n            case \"R\":\r\n                url = \"../../JXGeoManage/TBL_RWJJ_G" +
"OVERNMENT/GetFormJson\";\r\n                break;\r\n            default:\r\n         " +
"       break;\r\n        }\r\n        return url;\r\n    }\r\n    function genercode() {" +
"\r\n        var NEWZHDCODE = null;\r\n        var ZHDCODE = $(\"#ZHDCODE\").val();//顺序" +
"编号\r\n        if (ZHDCODE.length == 1) {         //灾害点编号判断\r\n            NEWZHDCODE" +
" = \"000\" + ZHDCODE\r\n        } else if (ZHDCODE.length == 2) {\r\n            NEWZH" +
"DCODE = \"00\" + ZHDCODE\r\n        } else if (ZHDCODE.length == 3) {\r\n            N" +
"EWZHDCODE = \"0\" + ZHDCODE\r\n        } else if (ZHDCODE.length == 4) {\r\n          " +
"  NEWZHDCODE =ZHDCODE\r\n        }\r\n        if (!$(\'#form1\').Validform()) {\r\n     " +
"       return false;\r\n        }\r\n        var TOWN = $(\"#TOWN\").attr(\'data-value\'" +
");\r\n        var value = \"RW\" + TOWN + NEWZHDCODE + tabhtml;\r\n        $(\"#typecod" +
"e\").val(value);\r\n        //校验编号是否已存在\r\n        $.ajax({\r\n            url: GetRequ" +
"estUrl(tabhtml),\r\n            type: \"GET\",\r\n            beforeSend: function (re" +
"quest) {\r\n                request.setRequestHeader(\"Authorization\", authToken);\r" +
"\n            },\r\n            data: { keyValue: value },\r\n            async: fals" +
"e,\r\n            success: function (data) {\r\n                if (data == null || " +
"data == \'\' || data == \'null\') {\r\n                    $(\"#typecode\").val(value);\r" +
"\n                }\r\n                else {\r\n                    value = \'\';\r\n   " +
"                 $(\"#ZHDCODE\").val(\"\");\r\n                    $(\"#typecode\").val(" +
"\"\");\r\n                    learun.dialogMsg({ msg: \'该统一编号已存在！\', type: 0 });\r\n    " +
"            }\r\n            }\r\n        });\r\n        return value;\r\n    }\r\n</scrip" +
"t>\r\n");

});

        }
    }
}
#pragma warning restore 1591
