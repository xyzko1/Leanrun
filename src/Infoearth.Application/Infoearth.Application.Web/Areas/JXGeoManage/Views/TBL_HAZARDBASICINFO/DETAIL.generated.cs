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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_HAZARDBASICINFO/DETAIL.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_DETAIL_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_DETAIL_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO\DETAIL.cshtml"
  
    ViewBag.Title = "表单页面";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<style>\r\n    html, body, #form1 {\r\n        height: 100%;\r\n    }\r\n\r\n    .nav-tab" +
"s {\r\n        padding-top: 2px;\r\n    }\r\n    .xxx {\r\nbackground-color:#fff;\r\ncolor" +
":#666;\r\nborder:1px solid #d8d8d8;\r\n    }\r\n</style>\r\n    <div");

WriteLiteral(" id=\"test\"");

WriteLiteral(" style=\"width:100%;height:100%;background:#fff\"");

WriteLiteral(">\r\n        <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(" style=\"background-color: rgba(236, 247, 255, 1);border-bottom:1px solid #ccc\"");

WriteLiteral(">\r\n            <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(" id=\"li_XXXX\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#XXXX\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(" class=\"xxx\"");

WriteLiteral(">详细信息</a></li>\r\n            <li");

WriteLiteral(" id=\"li_QCQF\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#QCQF\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">群测群防</a></li>\r\n            <li");

WriteLiteral(" id=\"li_BQBR\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#BQBR\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">搬迁避让</a></li>\r\n            <li");

WriteLiteral(" id=\"li_ZLGC\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#ZLGC\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">治理工程</a></li>\r\n            <li");

WriteLiteral(" id=\"li_JCXX\"");

WriteLiteral("><a");

WriteLiteral(" href=\"###\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(" style=\"color:#b6b6b6;background:#dedcdc;\"");

WriteLiteral(">监测信息</a></li>\r\n            <li");

WriteLiteral(" id=\"li_LSXX\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#LSXX\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(" >历史险情</a></li>\r\n            <li");

WriteLiteral(" id=\"li_LSYJ\"");

WriteLiteral("><a");

WriteLiteral(" href=\"###\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(" style=\"color:#b6b6b6;background:#dedcdc;\"");

WriteLiteral(">历史预警</a></li>\r\n            <li");

WriteLiteral(" id=\"li_LSSJ\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#LSSJ\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">历史数据</a></li>\r\n            <li");

WriteLiteral(" id=\"li_XHXQ\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#XHXQ\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">销号详情</a></li>\r\n            <li");

WriteLiteral(" style=\"float:right;margin-right:25px;display:none\"");

WriteLiteral(" id=\"li_close\"");

WriteLiteral(" onclick=\"thisClose(\'DZDCCXXQ\')\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" style=\"background:#107fff;color:#fff;border:1px solid #ccc;border-radius:4px;mar" +
"gin-top:2px;padding:6px 10px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-close\"");

WriteLiteral("></i> 返回</a>\r\n            </li>\r\n        </ul>\r\n    <div");

WriteLiteral(" id=\"myTabContent\"");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(" style=\"height:calc(100% - 38px); width: 100%;background:#fff;overflow:hidden\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" id=\"XXXX\"");

WriteLiteral(" style=\"width:100%;height:100%\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" id=\"XXXXS\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral("  onscroll=\"no\"");

WriteLiteral(" style=\"border:none;height:100%\"");

WriteLiteral("></iframe>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"BQBR\"");

WriteLiteral(" style=\"height: 100%; width: 100%;background:#fff\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" id=\"BQBRS\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral("  src=\"\"");

WriteLiteral("  onscroll=\"no\"");

WriteLiteral(" style=\"border:none;height:100%\"");

WriteLiteral("></iframe>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"ZLGC\"");

WriteLiteral(" style=\"height: 100%; width: 100%;background:#fff\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" id=\"ZLGCS\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral("   src=\"\"");

WriteLiteral(" onscroll=\"no\"");

WriteLiteral(" style=\"border:none;height:100%\"");

WriteLiteral("></iframe>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"JCXX\"");

WriteLiteral(" style=\"height: 100%; width: 100%;background:#fff\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" id=\"JCXXS\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" onscroll=\"no\"");

WriteLiteral(" style=\"border:none;height:100%\"");

WriteLiteral("></iframe>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"QCQF\"");

WriteLiteral(" style=\"height: 100%; width: 100%;background:#fff\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" id=\"QCQFS\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" onscroll=\"no\"");

WriteLiteral(" style=\"border:none;height:100%\"");

WriteLiteral("></iframe>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"LSXX\"");

WriteLiteral(" style=\"height: 100%; width: 100%;background:#fff\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" id=\"LSXXS\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" onscroll=\"no\"");

WriteLiteral(" style=\"border:none;height:100%\"");

WriteLiteral("></iframe>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"LSYJ\"");

WriteLiteral(" style=\"height: 100%; width: 100%;background:#fff\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" id=\"LSYJS\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" onscroll=\"no\"");

WriteLiteral(" style=\"border:none;height:100%\"");

WriteLiteral("></iframe>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"DMT\"");

WriteLiteral(" style=\"height: 100%; width: 100%;background:#fff\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" id=\"DMTS\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" onscroll=\"no\"");

WriteLiteral(" style=\"border:none;height:100%\"");

WriteLiteral("></iframe>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"LSSJ\"");

WriteLiteral(" style=\"height: 100%; width: 100%;background:#fff\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" id=\"LSSJS\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" onscroll=\"no\"");

WriteLiteral(" style=\"border:none;height:100%\"");

WriteLiteral("></iframe>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"XHXQ\"");

WriteLiteral(" style=\"height: 100%; width: 100%;background:#fff\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" id=\"XHXQS\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" onscroll=\"no\"");

WriteLiteral(" style=\"border:none;height:100%\"");

WriteLiteral("></iframe>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

DefineSection("Scripts", () => {

            
            #line 67 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO\DETAIL.cshtml"
    
            
            #line default
            #line hidden
WriteLiteral("\r\n    <script>\r\n        var keyValue = request(\'keyValue\');\r\n        var keyNAME " +
"= request(\'keyNAME\');\r\n        var types = request(\'types\');\r\n        var xhguid" +
" = request(\'xhguid\');//销号点的guid       \r\n        var authToken = getAuthorization" +
"Token();\r\n        var callback = request(\'callback\');//\"返回\"跳转url\r\n        var qc" +
"qfState = \"\", bqbrState = \"\", zlgcState = \"\", lsState = \"\";\r\n        var yjURL =" +
" \"\"; var lsxqState =0;\r\n        $(function () {\r\n            $.ajax({\r\n         " +
"       url: \"../../Utility/GetAppSetting\",\r\n                async: false, //同步请求" +
"\r\n                data: { key: \"YJDCUrl\" },\r\n                type: \"GET\",\r\n     " +
"           success: function (data) {\r\n                    yjURL = data;\r\n      " +
"              aa();\r\n                    pdsta();\r\n                }\r\n          " +
"  });\r\n            $(\"#XXXX\").height($(\"layui-layer-content\").height())\r\n       " +
"     $(\'#XXXXS\').attr(\'src\', GetUrl(types) + \"?keyValue=\" + keyValue + \"&details" +
"=01&XQing=01\");\r\n            if (callback) {\r\n                $(\"#li_close\").sho" +
"w();\r\n            }\r\n            if (xhguid != null && xhguid != \"\") {\r\n        " +
"        $(\"#li_XHXQ\").show();\r\n            }\r\n        });\r\n        function aa()" +
" {\r\n            var queryJson = {};\r\n            queryJson[\"DISASTERCODE\"] = key" +
"Value;\r\n            $.ajax({\r\n                type: \"get\",\r\n                asyn" +
"c: true,\r\n                url: yjURL + \"../../api/TBL_YJZH_DANGECASEINFOApi/GetL" +
"istJson\",\r\n                data: { queryJson: JSON.stringify(queryJson) },\r\n    " +
"            beforeSend: function (XHR) {\r\n                    XHR.setRequestHead" +
"er(\'Authorization\', getAuthorizationToken());\r\n                },\r\n             " +
"   success: function (data) {\r\n                    if (data.length > 0) {\r\n     " +
"                   lsxqState = 1;\r\n                    }\r\n\r\n                },\r\n" +
"                error: function (e) {\r\n                },\r\n                compl" +
"ete: function () {\r\n                }\r\n            });\r\n        }\r\n        funct" +
"ion pdsta() {\r\n            $.ajax({\r\n                url: \'../../api/TBL_QCQF_AD" +
"MINISTRATIVEApi/PdState\',\r\n                type: \'get\',\r\n                datatyp" +
"e: \'json\',\r\n                data: { id: keyValue },\r\n                beforeSend:" +
" function (a) {\r\n                    a.setRequestHeader(\"Authorization\", authTok" +
"en);\r\n                },\r\n                success: function (data) {\r\n          " +
"          console.log(data.qcqfState);\r\n                    qcqfState = data.qcq" +
"fState; bqbrState = data.bqbrState;\r\n                    zlgcState = data.zlgcSt" +
"ate; lsState = data.lsState;\r\n                    if (qcqfState == \"0\") {\r\n     " +
"                   $(\"#li_QCQF a\").css(\"background-color\", \"#dedcdc\");\r\n        " +
"                $(\"#li_QCQF a\").css(\"color\", \"#b6b6b6\");\r\n                    } " +
"else {\r\n                        $(\"#li_QCQF a\").css(\"background-color\", \"#fff\");" +
"\r\n                        $(\"#li_QCQF a\").css(\"color\", \"#666\");\r\n               " +
"         $(\"#li_QCQF a\").css(\"border\", \"1px solid #d8d8d8\");\r\n                  " +
"  }\r\n                    if (bqbrState == \"0\") {\r\n                        $(\"#li" +
"_BQBR a\").css(\"background-color\", \"#dedcdc\");\r\n                        $(\"#li_BQ" +
"BR a\").css(\"color\", \"#b6b6b6\");\r\n                    } else {\r\n                 " +
"       $(\"#li_BQBR a\").css(\"background-color\", \"#fff\");\r\n                       " +
" $(\"#li_BQBR a\").css(\"color\", \"#666\");\r\n                        $(\"#li_BQBR a\")." +
"css(\"border\", \"1px solid #d8d8d8\");\r\n                    }\r\n                    " +
"if (zlgcState == \"0\") {\r\n                        $(\"#li_ZLGC a\").css(\"background" +
"-color\", \"#dedcdc\");\r\n                        $(\"#li_ZLGC a\").css(\"color\", \"#b6b" +
"6b6\");\r\n                    } else {\r\n                        $(\"#li_ZLGC a\").cs" +
"s(\"background-color\", \"#fff\");\r\n                        $(\"#li_ZLGC a\").css(\"col" +
"or\", \"#666\");\r\n                        $(\"#li_ZLGC a\").css(\"border\", \"1px solid " +
"#d8d8d8\");\r\n                    }\r\n                    if (lsState == \"0\") {\r\n  " +
"                      $(\"#li_LSSJ a\").css(\"background-color\", \"#dedcdc\");\r\n     " +
"                   $(\"#li_LSSJ a\").css(\"color\", \"#b6b6b6\");\r\n                   " +
" } else {\r\n                        $(\"#li_LSSJ a\").css(\"background-color\", \"#fff" +
"\");\r\n                        $(\"#li_LSSJ a\").css(\"color\", \"#666\");\r\n            " +
"            $(\"#li_LSSJ a\").css(\"border\", \"1px solid #d8d8d8\");\r\n               " +
"     }\r\n                    if (lsxqState == \"0\") {\r\n                        $(\"" +
"#li_LSXX a\").css(\"background-color\", \"#dedcdc\");\r\n                        $(\"#li" +
"_LSXX a\").css(\"color\", \"#b6b6b6\");\r\n                    } else {\r\n              " +
"          $(\"#li_LSXX a\").css(\"background-color\", \"#fff\");\r\n                    " +
"    $(\"#li_LSXX a\").css(\"color\", \"#666\");\r\n                        $(\"#li_LSXX a" +
"\").css(\"border\", \"1px solid #d8d8d8\");\r\n                    }\r\n                 " +
"   $(\".nav-tabs li\").click(function () {\r\n                        var id = $(thi" +
"s).attr(\'id\').replace(\"li_\", \"\");\r\n                        switch (id) {\r\n      " +
"                      case \"BQBR\":\r\n                                if (bqbrStat" +
"e == \"0\") {\r\n                                    event.stopPropagation();\r\n     " +
"                           }\r\n                                if ($(\'#BQBRS\').at" +
"tr(\"src\") == \"\") {\r\n                                    $(\'#BQBRS\').attr(\"src\", " +
"\"/JXGeoManage/TBL_BQBR/TBL_BQBRHZForm?keyValue=\" + keyValue + \"&IdetIfrem=Idetne" +
"w\" + \"&readonly=01\" + \"&details=01&bj=01\");\r\n                                   " +
"// $(\'#BQBRS\').attr(\"src\", \"/JXGeoManage/TBL_BQBR/TBL_BQBRForm?keyValue=\" + keyV" +
"alue + \"&IdetIfrem=Idetnew\" + \"&readonly=01\" + \"&details=01&bj=\'yincang\'\");\r\n   " +
"                                 }\r\n                                \r\n          " +
"                      break;\r\n                            case \"ZLGC\"://治理工程\r\n  " +
"                              if (zlgcState == \"0\") {\r\n                         " +
"           event.stopPropagation();\r\n                                }\r\n        " +
"                        if (zlgcState != \"0\") {\r\n                               " +
"     if ($(\'#ZLGCS\').attr(\'src\') == \"\") {\r\n                                     " +
"   //keyValue = keyValue.substring(0, 6);\r\n                                     " +
"   $(\'#ZLGCS\').attr(\'src\', \"/JXGeoManage/TBL_ZLGC_BASEINFO/TBL_ZLGC_TJResultForm" +
"\" + \"?compparam=\" + keyValue + \"&readonly=01&bj=\'yincang\'&details=01\");\r\n       " +
"                                // $(\'#ZLGCS\').attr(\'src\', \"/JXGeoManage/TBL_ZLG" +
"C_BASEINFO/TBL_ZLGC_BASICAMANAGE\" + \"?keyValue=\" + keyValue + \"&readonly=01&deta" +
"ils=01\");\r\n                                    }\r\n                              " +
"  }\r\n                                break;\r\n                            case \"J" +
"CXX\":\r\n                                event.stopPropagation();\r\n               " +
"                 //if ($(\'#JCXXS\').attr(\'src\') == \"\") {\r\n                       " +
"         //    var url = \"http://192.168.1.49:8882/JXGeoManage/TBL_JC_MONITORPOI" +
"NTINFO/JCDXQ?DISASTERUNITCODE=\" + keyValue + \"&IdetIfrem=Idetnew\" + \"&readonly=0" +
"1&IsDetail=true&details=01\";\r\n                                //    $(\'#JCXXS\')." +
"attr(\'src\', url);\r\n                                //}\r\n                        " +
"        break;\r\n                            case \"QCQF\":\r\n                      " +
"          if (qcqfState == \"0\"||qcqfState == \"\") {\r\n                            " +
"        event.stopPropagation();\r\n                                }\r\n           " +
"                     if (qcqfState != \"0\") {\r\n                                  " +
"  window.setTimeout(function () {\r\n                                        $(\'#Q" +
"CQFS\').attr(\'src\', \"/JXGeoManage/TBL_QCQF_ADMINISTRATIVE/TBL_QCQF_ADMINISTRATIVE" +
"Form\" + \"?keyValue=\" + keyValue + \"&UNIFIEDCODE=\" + keyValue + \"&readonaly=01&de" +
"tails=01\");\r\n                                    }, 200);\r\n                     " +
"           }\r\n                                break;\r\n                          " +
"  case \"LSXX\":\r\n                                if (lsxqState == \"0\" || qcqfStat" +
"e == \"\") {\r\n                                    event.stopPropagation();\r\n      " +
"                          }\r\n                                if ($(\'#LSXXS\').att" +
"r(\'src\') == \"\") {\r\n                                    $(\'#LSXXS\').attr(\"src\", \"" +
"/JXGeoManage/TBL_BQBR/TBL_LSXQ?keyValue=\" + keyValue + \"&IdetIfrem=Idetnew\" + \"&" +
"readonly=01\" + \"&details=01\");\r\n                                }\r\n             " +
"                   break;\r\n                            case \"LSYJ\":\r\n           " +
"                     event.stopPropagation();\r\n                                /" +
"/if ($(\'#LSYJS\').attr(\'src\') == \"\") {\r\n                                //    $(\'" +
"#LSYJS\').attr(\'src\', GetUrl(types) + \"?keyValue=\" + keyValue + \"&details=01\");\r\n" +
"                                //}\r\n                                break;\r\n   " +
"                         case \"LSSJ\"://历史数据\r\n                                if " +
"(lsState == \"0\") {\r\n                                    event.stopPropagation();" +
"\r\n                                }\r\n                                if (lsState" +
" != \"0\") {\r\n                                    if ($(\'#LSSJS\').attr(\'src\') == \"" +
"\") {\r\n                                        $(\'#LSSJS\').attr(\'src\', GetUrl(typ" +
"es) + \"?TYBH=\" + keyValue + \"&details=01&XQing=01&flag=true&callback=callback\");" +
"\r\n                                        //$(\'#LSSJS\').attr(\'src\', \"/JXGeoManag" +
"e/TBL_HAZARDBASICINFO/TBL_LSSJIndex?keyValue=\" + keyValue + \"&readonly=01&detail" +
"s=01\" + \'&types=\' + types);\r\n                                    }\r\n            " +
"                    }\r\n                                break;\r\n                 " +
"           case \"XHXQ\"://销号详情\r\n                                if (lsState == \"0" +
"\") {\r\n                                    event.stopPropagation();\r\n            " +
"                    }\r\n                                if (lsState != \"0\") {\r\n  " +
"                                  if ($(\'#XHXQS\').attr(\'src\') == \"\") {\r\n        " +
"                                $(\'#XHXQS\').attr(\'src\', \"/JXGeoManage/TBL_HAZARD" +
"BASICINFO/DeleteInfo?guid=\" + xhguid + \"&callback=callback\");\r\n                 " +
"                   }\r\n                                }\r\n                       " +
"         break;\r\n                                //case \"DMT\":\r\n                " +
"                //    if ($(\'#DMTS\').attr(\'src\') == \"\") {\r\n                     " +
"           //        window.setTimeout(function () {\r\n                          " +
"      //            $(\'#DMTS\').attr(\'src\', contentPath + \"/SystemManage/MultMedi" +
"a/Index?moduleID=dcd1d0aa-1d51-4142-ae82-db812158b0da&belongObjectGuid=\" + keyVa" +
"lue + \"&details=01\");\r\n                                //        }, 300);\r\n     " +
"                           //    }\r\n                                //    break;" +
"\r\n                                case \"close\":\r\n                               " +
"     if (callback && window.parent) {\r\n                                        d" +
"ocument.location.href = callback;\r\n                                    }\r\n      " +
"                          break;\r\n                            default:\r\n        " +
"                }\r\n                    });\r\n\r\n                },\r\n              " +
"  cache: false\r\n\r\n            });\r\n        }\r\n        //function Close() {\r\n    " +
"    //    var layout = parent.window.document.getElementById(\"layout\");\n        " +
"//    layout.style.display = \"block\";\n        //    $(\"#test\").css(\"display\", \"n" +
"one\");\r\n        //}\r\n        //获取地址\r\n        function GetUrl(v) {\r\n            v" +
"ar url = null;\r\n            switch (v) {\r\n                case \"001\":\r\n         " +
"           url = \"/JXGeoManage/TBL_LANDSLIP/TBL_LANDSLIPForm\";\r\n                " +
"    break;\r\n                case \"002\":\r\n                    url = \"/JXGeoManage" +
"/TBL_AVALANCHE/TBL_AVALANCHEForm\";\r\n                    break;\r\n                " +
"case \"003\":\r\n                    url = \"/JXGeoManage/TBL_DEBRISFLOW/TBL_DEBRISFL" +
"OWForm\";\r\n                    break;\r\n                case \"004\":\r\n             " +
"       url = \"/JXGeoManage/TBL_LANDSETTLEMENT/TBL_LANDSETTLEMENTForm\";\r\n        " +
"            break;\r\n                case \"005\":\r\n                    url = \"/JXG" +
"eoManage/TBL_COLLAPSE/TBL_COLLAPSEForm\";\r\n                    break;\r\n          " +
"      case \"006\":\r\n                    url = \"/JXGeoManage/TBL_LANDCRACK/TBL_LAN" +
"DCRACKForm\";\r\n                    break;\r\n                case \"007\":\r\n         " +
"           url = \"/JXGeoManage/TBL_SLOPE/TBL_SLOPEForm\";\r\n                    br" +
"eak;\r\n                default:\r\n                    break;\r\n            }\r\n     " +
"       return url;\r\n        }\r\n    </script>\r\n    ");

});

        }
    }
}
#pragma warning restore 1591
