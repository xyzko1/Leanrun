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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_HAZARDBASICINFO/HarzardCompare.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_HarzardCompare_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_HarzardCompare_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO\HarzardCompare.cshtml"
  
    ViewBag.Title = "灾害信息页面对比";
    Layout = "~/Views/Shared/_IndexMap.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var keyValue = request(\'keyValue\');  //历史记录GUID\r\n    var dmt = re" +
"quest(\'dmt\');\r\n    var type = request(\'type\');\r\n    var flag = request(\'flag\');\r" +
"\n    var authToken = getAuthorizationToken();\r\n    var leftLoad = false;\r\n    va" +
"r rightLoad = false;\r\n    $(function () {\r\n        InitialPage();\r\n        Initi" +
"alData();\r\n    });\r\n\r\n    ////初始化数据\r\n    //function InitialData() {\r\n\r\n    //   " +
" if (!!type && !!keyValue) {\r\n    //        //获取当前数据\r\n    //        $(\'#left\').a" +
"ttr(\'src\', GetViewUrl(type) + \"?guid=\" + keyValue + \"&details=01\");\r\n    //     " +
"   //获取历史最新数据\r\n    //        $.SetForm({\r\n    //            url: GetRequestUrl(t" +
"ype),\r\n    //            param: { keyValue: keyValue },\r\n    //            authT" +
"oken: authToken,\r\n    //            success: function (data) {\r\n    //          " +
"      if (data) {\r\n    //                    var code = data.GUID;\r\n    //      " +
"              $(\'#right\').attr(\'src\', GetViewUrl(type) + \"?guid=\" + code + \"&det" +
"ails=01\");\r\n    //                    InializeScroll();\r\n    //                }" +
"\r\n    //                else {\r\n    //                    dialogMsg(\"历史版本信息未找到！\"" +
", 0);\r\n    //                }\r\n    //            }\r\n    //        });\r\n    //  " +
"  }\r\n    //}\r\n    //初始化数据\r\n    function InitialData() {\r\n        if (type && key" +
"Value) {\r\n            //获取当前数据\r\n            $(\'#left\').attr(\'src\', GetViewUrl(ty" +
"pe) + \"?guid=\" + keyValue + \"&details=01&dmt=\" + dmt + \"&flag=false\" + \"&callbac" +
"k=true\");\r\n\r\n            //获取历史最新数据\r\n            if (flag == \"true\") {\r\n        " +
"        $.SetForm({\r\n                    url: GetRequestUrl(type),\r\n            " +
"        param: { keyValue: keyValue },\r\n                    authToken: authToken" +
",\r\n                    success: function (data) {\r\n                        if (d" +
"ata) {\r\n                            var code = data.GUID;\r\n                     " +
"       $(\'#right\').attr(\'src\', GetViewUrl(type) + \"?guid=\" + code + \"&dmt=\" + dm" +
"t + \"&details=01&flag=false\");\r\n                          //  console.log(GetVie" +
"wUrl(type) + \"?guid=\" + code + \"&details=01\")\r\n                            Inial" +
"izeScroll();\r\n                            //$($(\'#right\')[0].contentWindow)[0].w" +
"indow.$(\"#li_DMT\").trigger(\"click\");\r\n                        }\r\n               " +
"         else {\r\n                            dialogMsg(\"历史版本信息未找到！\", 0);\r\n      " +
"                  }\r\n                    }\r\n                });\r\n            } e" +
"lse {\r\n                $(\'#compare\').hide();\r\n                $(\'#read\').css(\'wi" +
"dth\', \'100%\');\r\n                $(\'#left\').css(\'width\', \'1362px\');\r\n            " +
"}\r\n        }\r\n    }\r\n    //初始化滚动条事件\r\n    function InializeScroll() {\r\n        va" +
"r left = $($(\'#left\')[0].contentWindow);\r\n        var right = $($(\'#right\')[0].c" +
"ontentWindow)\r\n\r\n        var leftFrame = document.getElementById(\"left\");\r\n     " +
"   var rigthFrame = document.getElementById(\"right\");\r\n\r\n        if (leftFrame.a" +
"ttachEvent) {\r\n            leftFrame.attachEvent(\"onload\", function () {\r\n      " +
"          //添加滚动条事件\r\n                left[0].window.$(\".nav-tabs\").parent().scro" +
"ll(function () {\r\n                    right[0].window.$(\".nav-tabs\").parent().sc" +
"rollTop($(this).scrollTop());\r\n                });\r\n                //添加按钮切换事件\r\n" +
"                left[0].window.$(\".nav-tabs li\").click(function (e) {\r\n         " +
"           var id = $(this).attr(\'id\').replace(\"li_\", \"\");\r\n                    " +
"right[0].window.$(\"#li_DMT\").trigger(\"click\");\r\n                    if (e.target" +
".innerText == \"多媒体\") {\r\n                        right[0].window.$(\'#MultMedia\')." +
"attr(\'src\', contentPath + \"/SystemManage/MultMedia/Index?moduleID=\" + right[0].w" +
"indow.mid + \"&belongObjectGuid=\" + right[0].window.keyValue + \"&details=\" + righ" +
"t[0].window.details);\r\n                    }\r\n                    right[0].windo" +
"w.$(\".nav-tabs li a[href=\'#\" + id + \"\']\").tab(\'show\');\r\n                });\r\n\r\n " +
"               window.setTimeout(function () {\r\n                    //比较元素差异\r\n  " +
"                  left[0].$(\':input\').each(function () {\r\n                      " +
"  var value = $(this).val();\r\n                        var rightValue = right[0]." +
"$(\'#\' + this.id).val();\r\n                        if (this.id == \"\" || this.id ==" +
" undefined) {\r\n                            rightValue = right[0].$(\'[name=\"\' + $" +
"(this).attr(\'name\') + \'\"][value=\"\' + $(this).attr(\'value\') + \'\"]\').val();\r\n     " +
"                   }\r\n\r\n                        if (value != rightValue) {\r\n    " +
"                        $(this).parent().css(\'background\', \'red\');\r\n            " +
"                $(this).parent().css(\'color\', \'white\');\r\n                       " +
" }\r\n                        //判断checkbox和radio(name,value)\r\n                    " +
"    else {\r\n                            value = $(this)[0].checked;\r\n\r\n         " +
"                   if (this.id == \"\" || this.id == undefined) {\r\n               " +
"                 rightValue = right[0].$(\'[name=\"\' + $(this).attr(\'name\') + \'\"][" +
"value=\"\' + $(this).attr(\'value\') + \'\"]\')[0].checked;\r\n                          " +
"  }\r\n                            else {\r\n                                rightVa" +
"lue = right[0].$(\'#\' + this.id)[0].checked;\r\n                            }\r\n\r\n  " +
"                          if (value != rightValue) {\r\n                          " +
"      $(this).parent().css(\'background\', \'red\');\r\n                              " +
"  $(this).parent().css(\'color\', \'white\');\r\n                            }\r\n      " +
"                  }\r\n                    });\r\n                    left[0].$(\'.ui" +
"-select-text\').each(function () {\r\n                        var value = $(this).f" +
"ind(\"span\").html();\r\n                        var rightValue = right[0].$(\'#\' + $" +
"(this).parent().attr(\"id\")).find(\"span\").html();\r\n                        if (va" +
"lue != rightValue) {\r\n                            $(this).parent().css(\'backgrou" +
"nd\', \'red\');\r\n                            $(this).parent().css(\'color\', \'white\')" +
";\r\n                        }\r\n \r\n                    });\r\n                }, 300" +
");\r\n\r\n            });\r\n        }\r\n        else {\r\n            leftFrame.onload =" +
" function () {\r\n                //添加滚动条事件\r\n                left[0].window.$(\".na" +
"v-tabs\").parent().scroll(function (n, e) {\r\n                    right[0].window." +
"$(\".nav-tabs\").parent().scrollTop($(this).scrollTop());\r\n                });\r\n  " +
"              //添加按钮切换事件\r\n                left[0].window.$(\".nav-tabs li\").click" +
"(function (e) {\r\n                    if (e.target.innerText == \"多媒体\") {\r\n       " +
"                 right[0].window.$(\'#MultMedia\').attr(\'src\', contentPath + \"/Sys" +
"temManage/MultMedia/Index?moduleID=\" + right[0].window.mid + \"&belongObjectGuid=" +
"\" + right[0].window.keyValue + \"&details=\" + right[0].window.details);\r\n        " +
"            }\r\n                    var id = $(this).attr(\'id\').replace(\"li_\", \"\"" +
");\r\n                    right[0].window.$(\".nav-tabs li a[href=\'#\" + id + \"\']\")." +
"tab(\'show\');\r\n                });\r\n\r\n                window.setTimeout(function " +
"() {\r\n                    //比较元素差异\r\n                    left[0].$(\':input\').each" +
"(function () {\r\n                        var value = $(this).val();\r\n            " +
"            var rightValue = right[0].$(\'#\' + this.id).val();\r\n                 " +
"       if (this.id == \"\" || this.id == undefined) {\r\n                           " +
" rightValue = right[0].$(\'[name=\"\' + $(this).attr(\'name\') + \'\"][value=\"\' + $(thi" +
"s).attr(\'value\') + \'\"]\').val();\r\n                        }\r\n\r\n                  " +
"      if (value != rightValue) {\r\n                            $(this).parent().c" +
"ss(\'background\', \'red\');\r\n                            $(this).parent().css(\'colo" +
"r\', \'white\');\r\n                        }\r\n                        //判断checkbox和r" +
"adio(name,value)\r\n                        else {\r\n                            va" +
"lue = $(this)[0].checked;\r\n\r\n                            if (this.id == \"\" || th" +
"is.id == undefined) {\r\n                                rightValue = right[0].$(\'" +
"[name=\"\' + $(this).attr(\'name\') + \'\"][value=\"\' + $(this).attr(\'value\') + \'\"]\')[0" +
"].checked;\r\n                            }\r\n                            else {\r\n " +
"                               rightValue = right[0].$(\'#\' + this.id)[0].checked" +
";\r\n                            }\r\n\r\n                            if (value != rig" +
"htValue) {\r\n                                $(this).parent().css(\'background\', \'" +
"red\');\r\n                                $(this).parent().css(\'color\', \'white\');\r" +
"\n                            }\r\n                        }\r\n                    }" +
");\r\n                    left[0].$(\'.ui-select-text\').each(function () {\r\n       " +
"                 var value = $(this).find(\"span\").html();\r\n                     " +
"   var rightValue = right[0].$(\'#\' + $(this).parent().attr(\"id\")).find(\"span\").h" +
"tml();\r\n                        if (value != rightValue) {\r\n                    " +
"        $(this).parent().css(\'background\', \'red\');\r\n                            " +
"$(this).parent().css(\'color\', \'white\');\r\n                        }\r\n\r\n          " +
"          });\r\n                }, 300);\r\n            }\r\n        }\r\n\r\n        if " +
"(rigthFrame.attachEvent) {\r\n            rigthFrame.attachEvent(\"onload\", functio" +
"n () {\r\n                //添加滚动条事件\r\n                right[0].window.$(\".nav-tabs\"" +
").parent().scroll(function () {\r\n                    left[0].window.$(\".nav-tabs" +
"\").parent().scrollTop($(this).scrollTop());\r\n                });\r\n              " +
"  //添加按钮切换事件\r\n                right[0].window.$(\".nav-tabs li\").click(function (" +
") {\r\n                    left[0].window.$(\'#MultMedia\').attr(\'src\', contentPath " +
"+ \"/SystemManage/MultMedia/Index?moduleID=\" + left[0].window.mid + \"&belongObjec" +
"tGuid=\" + left[0].window.keyValue + \"&details=\" + left[0].window.details);\r\n    " +
"                var id = $(this).attr(\'id\').replace(\"li_\", \"\");\r\n               " +
"     left[0].window.$(\".nav-tabs li a[href=\'#\" + id + \"\']\").tab(\'show\');\r\n      " +
"          });\r\n            });\r\n        }\r\n        else {\r\n            rigthFram" +
"e.onload = function () {\r\n                //添加滚动条事件\r\n                right[0].wi" +
"ndow.$(\".nav-tabs\").parent().scroll(function (n, e) {\r\n                    left[" +
"0].window.$(\".nav-tabs\").parent().scrollTop($(this).scrollTop());\r\n             " +
"   });\r\n                //添加按钮切换事件\r\n                right[0].window.$(\".nav-tabs" +
" li\").click(function () {\r\n                    left[0].window.$(\'#MultMedia\').at" +
"tr(\'src\', contentPath + \"/SystemManage/MultMedia/Index?moduleID=\" + left[0].wind" +
"ow.mid + \"&belongObjectGuid=\" + left[0].window.keyValue + \"&details=\" + left[0]." +
"window.details);\r\n                    var id = $(this).attr(\'id\').replace(\"li_\"," +
" \"\");\r\n                    left[0].window.$(\".nav-tabs li a[href=\'#\" + id + \"\']\"" +
").tab(\'show\');\r\n                });\r\n            }\r\n        }\r\n\r\n\r\n        //处理横" +
"行滚动条\r\n        var leftX = $(\'#dvLeft\');\r\n        var rightX = $(\'#dvRight\');\r\n  " +
"      leftX.scroll(function () {\r\n            rightX.scrollLeft($(this).scrollLe" +
"ft());\r\n        });\r\n        rightX.scroll(function () {\r\n            leftX.scro" +
"llLeft($(this).scrollLeft());\r\n        });\r\n    }\r\n\r\n    //获取请求地址\r\n    function " +
"GetRequestUrl(v) {\r\n        var url = null;\r\n        switch (v) {\r\n            c" +
"ase \"01\":\r\n                url = \"../../api/TBL_LANDSLIP_HISTORYApi/GetAuditForm" +
"Json\";\r\n                break;\r\n            case \"02\":\r\n                url = \"." +
"./../api/TBL_AVALANCHE_HISTORYApi/GetAuditFormJson\";\r\n                break;\r\n  " +
"          case \"03\":\r\n                url = \"../../api/TBL_DEBRISFLOW_HISTORYApi" +
"/GetAuditFormJson\";\r\n                break;\r\n            case \"04\":\r\n           " +
"     url = \"../../api/TBL_LANDSETTLEMENT_HISTORYApi/GetAuditFormJson\";\r\n        " +
"        break;\r\n            case \"05\":\r\n                url = \"../../api/TBL_COL" +
"LAPSE_HISTORYApi/GetAuditFormJson\";\r\n                break;\r\n            case \"0" +
"6\":\r\n                url = \"../../api/TBL_LANDCRACK_HISTORYApi/GetAuditFormJson\"" +
";\r\n                break;\r\n            case \"07\":\r\n                url = \"../../" +
"api/TBL_SLOPE_HISTORYApi/GetAuditFormJson\";\r\n                break;\r\n           " +
" default:\r\n                break;\r\n        }\r\n        return url;\r\n    }\r\n\r\n    " +
"//获取详情地址\r\n    function GetViewUrl(v) {\r\n        var url = null;\r\n        switch " +
"(v) {\r\n            case \"01\":\r\n                url = \"/JXGeoManage/TBL_LANDSLIP/" +
"TBL_LANDSLIPForm\";\r\n                break;\r\n            case \"02\":\r\n            " +
"    url = \"/JXGeoManage/TBL_AVALANCHE/TBL_AVALANCHEForm\";\r\n                break" +
";\r\n            case \"03\":\r\n                url = \"/JXGeoManage/TBL_DEBRISFLOW/TB" +
"L_DEBRISFLOWForm\";\r\n                break;\r\n            case \"04\":\r\n            " +
"    url = \"/JXGeoManage/TBL_LANDSETTLEMENT/TBL_LANDSETTLEMENTForm\";\r\n           " +
"     break;\r\n            case \"05\":\r\n                url = \"/JXGeoManage/TBL_COL" +
"LAPSE/TBL_COLLAPSEForm\";\r\n                break;\r\n            case \"06\":\r\n      " +
"          url = \"/JXGeoManage/TBL_LANDCRACK/TBL_LANDCRACKForm\";\r\n               " +
" break;\r\n            case \"07\":\r\n                url = \"/JXGeoManage/TBL_SLOPE/T" +
"BL_SLOPEForm\";\r\n                break;\r\n            default:\r\n                br" +
"eak;\r\n        }\r\n        return url;\r\n    }\r\n\r\n    //初始化页面\r\n    function Initial" +
"Page() {\r\n        var layout = $(\'#layout\').layout({\r\n            applyDemoStyle" +
"s: true,\r\n            onresize: function () {\r\n            }\r\n        });\r\n\r\n   " +
"     layout.sizePane(\'west\', $(window).width() / 2);\r\n        $(window).resize(f" +
"unction (e) {\r\n            $(\'#left\').height($(window).height() - 65);\r\n        " +
"    $(\'#right\').height($(window).height() - 65);\r\n        });\r\n\r\n        $(\'#lef" +
"t\').height($(window).height() - 65);\r\n        $(\'#right\').height($(window).heigh" +
"t() - 65);\r\n    }\r\n\r\n</script>\r\n");

});

WriteLiteral("<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"width:100%;height:100%\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(" style=\"height:100%;width:50%\"");

WriteLiteral(" id=\"read\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(" style=\"height:40px;line-height:40px;background:rgba(236, 247, 255, 1)\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral("><span>当前数据信息</span></div>\r\n        </div>\r\n        <div");

WriteLiteral(" id=\"dvLeft\"");

WriteLiteral(" style=\"overflow-x:scroll;clear:both\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" id=\"left\"");

WriteLiteral(" style=\"width:1400px;\"");

WriteLiteral(" frameborder=\"0\"");

WriteLiteral(" src=\"\"");

WriteLiteral("></iframe>\r\n        </div>\r\n\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" style=\"height:100%;width:50%;border:solid 1px #ffd800\"");

WriteLiteral(" id=\"compare\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(" style=\"height:40px;line-height:40px;background:rgba(236, 247, 255, 1)\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral("><span>上版本数据信息</span></div>\r\n        </div>\r\n        <div");

WriteLiteral(" id=\"dvRight\"");

WriteLiteral(" style=\"overflow-x:scroll;clear:both\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" id=\"right\"");

WriteLiteral(" style=\"width:1400px;\"");

WriteLiteral(" frameborder=\"0\"");

WriteLiteral(" src=\"\"");

WriteLiteral("></iframe>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n");

        }
    }
}
#pragma warning restore 1591